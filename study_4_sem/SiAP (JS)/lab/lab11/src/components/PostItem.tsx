import { useDispatch } from 'react-redux';
import { AppDispatch } from '../app/store';
import { deletePostThunk, setEditingPost } from '../features/posts/postsSlice';
import { Post } from '../features/posts/postsAPI';

const PostItem = ({ post }: { post: Post }) => {
  const dispatch = useDispatch<AppDispatch>();

  return (
    <div>
      <h3>{post.title}</h3>
      <div className="post-info">
        <span className="post-id">ID: {post.id}</span>
        <span className="post-userid">User ID: {post.userId}</span>
      </div>
      <p>{post.body}</p>
      <button onClick={() => dispatch(setEditingPost(post))}>Edit</button>
      <button onClick={() => dispatch(deletePostThunk(post.id))}>Delete</button>
    </div>
  );
};

export default PostItem;
