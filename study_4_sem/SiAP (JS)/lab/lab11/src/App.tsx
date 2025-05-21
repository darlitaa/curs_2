import PostForm from './components/PostForm';
import Posts from './features/posts/Posts';
import './App.css';

const App = () => (
  <div className="App">
    <h1>Post Manager</h1>
    <PostForm />
    <Posts />
  </div>
);

export default App;