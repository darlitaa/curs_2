import axios from "axios";

export interface Post{
    id: number;
    userId: number;
    title: string;
    body: string;
}

export interface NewPost{
    title: string;
    body: string;
}

const API_URL = 'https://jsonplaceholder.typicode.com/posts';

export const fetchPosts = async (): Promise<Post[]> => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const createPost = async (post: NewPost): Promise<Post> => {
    const response = await axios.post(API_URL, post);
    return response.data;
};

export const updatePost = async (post: Post): Promise<Post> => {
    const response = await axios.put(`${API_URL}/${post.id}`, post);
    return response.data;
};

export const deletePost = async (id: number): Promise<void> => {
    const response = await axios.delete(`${API_URL}/${id}`);
};