import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { isEmailRegistered, registerUser } from '../Storage';

export default function SignUp() {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: ''
  });

  const [errors, setErrors] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: ''
  });

  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);
  const [successMessage, setSuccessMessage] = useState('');

  const validateName = (name: string): string => {
    if (!name.trim()) return 'Имя обязательно для заполнения';
    if (name.trim().length < 2) return 'Имя должно содержать не менее 2 символов';
    if (name.trim().length > 50) return 'Имя должно содержать не более 50 символов';
    if (!/^[A-Za-zА-Яа-я\s]+$/.test(name)) return 'Имя должно содержать только буквы и пробелы';
    return '';
  };

  const validateEmail = (email: string): string => {
    if (!email.trim()) return 'Email обязателен для заполнения';
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) return 'Некорректный формат email';
    if (isEmailRegistered(email.trim())) return 'Этот email уже зарегистрирован в системе';
    return '';
  };

  const validatePassword = (password: string): string => {
    if (!password.trim()) return 'Пароль обязателен для заполнения';
    if (password.trim().length < 8) return 'Пароль должен содержать не менее 8 символов';
    if (!/[A-Z]/.test(password)) return 'Пароль должен содержать хотя бы одну заглавную букву';
    if (!/[a-z]/.test(password)) return 'Пароль должен содержать хотя бы одну строчную букву';
    if (!/[0-9]/.test(password)) return 'Пароль должен содержать хотя бы одну цифру';
    if (/\s/.test(password)) return 'Пароль не должен содержать пробелы';
    return '';
  };

  const validateConfirmPassword = (confirmPassword: string, password: string): string => {
    if (!confirmPassword) return 'Подтверждение пароля обязательно';
    if (confirmPassword !== password) return 'Пароли не совпадают';
    return '';
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });

    if (successMessage) { setSuccessMessage(''); }

    let errorMessage = '';
    switch (name) {
      case 'name':
        errorMessage = validateName(value);
        break;
      case 'email':
        errorMessage = validateEmail(value);
        break;
      case 'password':
        errorMessage = validatePassword(value);
        break;
      case 'confirmPassword':
        errorMessage = validateConfirmPassword(value, formData.password);
        break;
    }

    setErrors(prev => ({ ...prev, [name]: errorMessage }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    const nameError = validateName(formData.name);
    const emailError = validateEmail(formData.email);
    const passwordError = validatePassword(formData.password);
    const confirmPasswordError = validateConfirmPassword(formData.confirmPassword, formData.password);

    setErrors({
      name: nameError,
      email: emailError,
      password: passwordError,
      confirmPassword: confirmPasswordError
    });

    if (!nameError && !emailError && !passwordError && !confirmPasswordError) {
      const normEmail = formData.email.trim().toLowerCase();
      const password = formData.password;
      const success = registerUser(normEmail, password);

      if (success) {
        setSuccessMessage('Регистрация прошла успешно!');

        setFormData({
          name: '',
          email: '',
          password: '',
          confirmPassword: ''
        });
      }

    } else {
      setSuccessMessage('');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Регистрация</h2>

      {successMessage && (<div className="success-message">{successMessage}</div>)}

      <div className="form-group">
        <label htmlFor="name">Имя</label>
        <input
          type="text"
          id="name"
          name="name"
          value={formData.name}
          onChange={handleChange}
          className={errors.name ? 'error' : ''} />
        {errors.name && <div className="error-input">{errors.name}</div>}
      </div>

      <div className="form-group">
        <label htmlFor="email">Email</label>
        <input
          type="email"
          id="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          className={errors.email ? 'error' : ''} />
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
            className={errors.password ? 'error' : ''} />
          <button 
            type="button" 
            className="toggle-password"
            onClick={() => setShowPassword(!showPassword)}>
            {showPassword ? "Скрыть" : "Показать"}
          </button>
        </div>
        {errors.password && <div className="error-input">{errors.password}</div>}
      </div>

      <div className="form-group">
        <label htmlFor="confirmPassword">Подтверждение пароля</label>
        <div className="password-input-container">
          <input
            type={showConfirmPassword ? "text" : "password"}
            id="confirmPassword"
            name="confirmPassword"
            value={formData.confirmPassword}
            onChange={handleChange}
            className={errors.confirmPassword ? 'error' : ''} />
          <button 
            type="button" 
            className="toggle-password"
            onClick={() => setShowConfirmPassword(!showConfirmPassword)} >
            {showConfirmPassword ? "Скрыть" : "Показать"}
          </button>
        </div>
        {errors.confirmPassword && <div className="error-input">{errors.confirmPassword}</div>}
      </div>

      <button type="submit" className="submit-button">Зарегистрироваться</button>
      <Link className="click" to="/sign-in">Перейти к авторизации</Link>
    </form>
  );
}