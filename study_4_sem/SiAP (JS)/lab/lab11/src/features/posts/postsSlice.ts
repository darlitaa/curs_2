import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import { Post, fetchPosts, createPost, updatePost, deletePost } from './postsAPI';

interface PostsState {
  posts: Post[];
  status: 'idle' | 'loading' | 'succeeded' | 'failed';
  error: string | null;
  editingPost: Post | null;
}

const initialState: PostsState = {
  posts: [],
  status: 'idle',
  error: null,
  editingPost: null,
};

export const fetchPostsThunk = createAsyncThunk('posts/fetchPosts', fetchPosts);
export const createPostThunk = createAsyncThunk('posts/createPost', createPost);
export const updatePostThunk = createAsyncThunk('posts/updatePost', updatePost);
export const deletePostThunk = createAsyncThunk('posts/deletePost', deletePost);

const postsSlice = createSlice({
  name: 'posts',
  initialState,
  reducers: {
    setEditingPost(state, action: PayloadAction<Post | null>) {
      state.editingPost = action.payload;
    },
  },
  extraReducers: builder => {
    builder
    .addCase(fetchPostsThunk.fulfilled, (state, action) => {
      state.status = 'succeeded';
      state.posts = action.payload;
    })
    .addCase(createPostThunk.fulfilled, (state, action) => {
      state.posts.push(action.payload);
    })
    .addCase(updatePostThunk.fulfilled, (state, action) => {
      const index = state.posts.findIndex(p => p.id === action.payload.id);
      if (index !== -1) state.posts[index] = action.payload;
      state.editingPost = null;
    })
    .addCase(deletePostThunk.fulfilled, (state, action) => {
      state.posts = state.posts.filter(post => post.id !== action.meta.arg);
    });
  },
});
  
export const { setEditingPost } = postsSlice.actions;
export default postsSlice.reducer;