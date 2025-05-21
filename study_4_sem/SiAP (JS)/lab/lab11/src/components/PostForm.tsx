import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../app/store';
import { createPostThunk, updatePostThunk, setEditingPost } from '../features/posts/postsSlice';
import { useState, useEffect } from 'react';

const PostForm = () => {
  const dispatch = useDispatch<AppDispatch>();
  const editingPost = useSelector((state: RootState) => state.posts.editingPost);

  const [title, setTitle] = useState('');
  const [body, setBody] = useState('');

  useEffect(() => {
    if (editingPost) {
      setTitle(editingPost.title);
      setBody(editingPost.body);
    } else {
      setTitle('');
      setBody('');
    }
  }, [editingPost]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (editingPost) {
      dispatch(updatePostThunk({ ...editingPost, title, body }));
    } else {
      dispatch(createPostThunk({ title, body }));
    }
    setTitle('');
    setBody('');
  };

  return (
    <form onSubmit={handleSubmit}>
      <input value={title} onChange={e => setTitle(e.target.value)} placeholder="Title" />
      <textarea value={body} onChange={e => setBody(e.target.value)} placeholder="Body" />
      <button type="submit">{editingPost ? 'Update' : 'Create'}</button>
      {editingPost && <button onClick={() => dispatch(setEditingPost(null))}>Cancel</button>}
    </form>
  );
};

export default PostForm;
