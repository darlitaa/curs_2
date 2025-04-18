import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { isEmailRegistered, updatePassword } from '../Storage';

export default function ResetPassword() {
  const [email, setEmail] = useState('');
  const [error, setError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');
  const [newPassword, setNewPassword] = useState('');

  const validateEmail = (email: string): string => {
    if (!email.trim()) return 'Email обязателен для заполнения';
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) return 'Некорректный формат email';

    const normEmail = email.trim().toLowerCase();
    if (!isEmailRegistered(normEmail) && normEmail !== 'test@test.com') {
      return 'Пользователь с таким email не зарегистрирован';
    }

    return '';
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
    setError('');
    setSuccessMessage('');
    setNewPassword('');
  };

  const generatePassword = (length = 8) => {
    const lowerCase = 'abcdefghijklmnopqrstuvwxyz';
    const upperCase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const numbers = '0123456789';

    const passwordArray = [
      lowerCase[Math.floor(Math.random() * lowerCase.length)],
      upperCase[Math.floor(Math.random() * upperCase.length)],
      numbers[Math.floor(Math.random() * numbers.length)]
    ];

    const allCharacters = lowerCase + upperCase + numbers;
    for (let i = 3; i < length; i++) {
      passwordArray.push(allCharacters[Math.floor(Math.random() * allCharacters.length)]);
    }

    const shuffledPassword = passwordArray.sort(() => 0.5 - Math.random()).join('');

    return shuffledPassword;
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const normEmail = email.trim().toLowerCase();
    const emailError = validateEmail(normEmail);
    setError(emailError);

    if (!emailError) {
      const generatedPassword = generatePassword();
      updatePassword(normEmail, generatedPassword);
      setNewPassword(generatedPassword);
      setSuccessMessage(`На адрес ${normEmail} отправлено письмо с новым паролем ${generatedPassword}.`);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Восстановление пароля</h2>

      {successMessage && (<div className="success-message">{successMessage}</div>)}

      <div className="form-group">
        <label htmlFor="email">Email</label>
        <input
          type="email"
          id="email"
          name="email"
          value={email}
          onChange={handleChange}
          className={error ? 'error' : ''} />
        {error && <div className="error-input">{error}</div>}
      </div>

      <button type="submit" className="submit-button">Восстановить пароль</button>
      <Link className="click" to="/sign-in">Перейти к авторизации</Link>
    </form>
  );
}