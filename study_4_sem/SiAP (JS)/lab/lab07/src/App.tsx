import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';

import SignUp from './Components/SignUp';
import SignIn from './Components/SignIn';
import ResetPassword from './Components/ResetPassword';

export default function App() {
  return (
    <Router>
      <Routes>
        <Route path="/sign-up" element={<SignUp />} />
        <Route path="/sign-in" element={<SignIn />} />
        <Route path="/reset-password" element={<ResetPassword />} />
        <Route path="*" element={<Navigate to="/sign-in" replace />} />
      </Routes>
    </Router>
  );
}
