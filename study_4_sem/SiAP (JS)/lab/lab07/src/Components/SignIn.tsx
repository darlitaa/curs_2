import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { authenticateUser } from '../Storage';

export default function SignIn() {
  const [formData, setFormData] = useState({
    email: '',
    password: ''
  });

  const [errors, setErrors] = useState({
    email: '',
    password: ''
  });

  const [showPassword, setShowPassword] = useState(false);
  const [successMessage, setSuccessMessage] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const validateEmail = (email: string): string => {
    if (!email.trim()) return 'Email обязателен для заполнения';
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) return 'Некорректный формат email';
    return '';
  };

  const validatePassword = (password: string): string => {
    if (!password) return 'Пароль обязателен для заполнения';
    return '';
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
    setErrorMessage('');

    let errorMessage = '';
    switch (name) {
      case 'email':
        errorMessage = validateEmail(value);
        break;
      case 'password':
        errorMessage = validatePassword(value);
        break;
    }

    setErrors(prev => ({ ...prev, [name]: errorMessage }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const cleanEmail = formData.email.trim().toLowerCase();
    const cleanPassword = formData.password;

    const emailError = validateEmail(cleanEmail);
    const passwordError = validatePassword(cleanPassword);

    setErrors({
      email: emailError,
      password: passwordError
    });

    if (!emailError && !passwordError) {
      const isAuthenticated = authenticateUser(cleanEmail, cleanPassword);

      if (isAuthenticated) {
        setSuccessMessage('Авторизация прошла успешно!');
        setErrorMessage('');

        setFormData({
          email: '',
          password: ''
        });
      } else {
        setSuccessMessage('');
        setErrorMessage('Неверный email или пароль');
      }
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Вход в аккаунт</h2>

      {successMessage && (<div className="success-message">{successMessage}</div>)}
      {errorMessage && (<div className="error-message">{errorMessage}</div>)}

      <div className="form-group">
        <label htmlFor="email">Email</label>
        <input
          type="email"
          id="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          className={errors.email ? 'error' : ''}
          placeholder="test@test.com"/>
        {errors.email && <div className="error-input">{errors.email}</div>}
      </div>

      <div className="form-group">
        <label htmlFor="password">Пароль</label>
        <div className="password-input-container">
          <input
            type={showPassword ? "text" : "password"}
            id="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            className={errors.password ? 'error' : ''}
            placeholder="54zw13tCt"/>
          <button 
            type="button"
            className="toggle-password"
            onClick={() => setShowPassword(!showPassword)}>
            {showPassword ? "Скрыть" : "Показать"}
          </button>
        </div>
        {errors.password && <div className="error-input">{errors.password}</div>}
      </div>

      <button type="submit" className="submit-button">Войти</button>
      <Link className="click" to="/sign-up">Зарегистрироваться</Link>
      <Link className="click" to="/reset-password">Я не помню пароль :(</Link>
    </form>
  );
}