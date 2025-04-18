const keyStorage = 'registered_users';

export const getRegisteredUsers = (): { email: string; password: string }[] => {
  const users = localStorage.getItem(keyStorage);
  return users ? JSON.parse(users) : [];
};

export const isEmailRegistered = (email: string): boolean => {
  const users = getRegisteredUsers();
  const normalizedEmail = email.toLowerCase().trim();
  return users.some(user => user.email.toLowerCase().trim() === normalizedEmail);
};

export const registerUser = (email: string, password: string): boolean => {
  const users = getRegisteredUsers();
  const normalizedEmail = email.toLowerCase().trim();

  if (isEmailRegistered(normalizedEmail)) return false;

  const newUser = { email: normalizedEmail, password };
  const updatedUsers = [...users, newUser];
  localStorage.setItem(keyStorage, JSON.stringify(updatedUsers));

  return true;
};

export const updatePassword = (email: string, newPassword: string): boolean => {
  const users = getRegisteredUsers();
  const userIndex = users.findIndex(user => user.email.toLowerCase().trim() === email.toLowerCase().trim());

  if (userIndex !== -1) {
    users[userIndex].password = newPassword;
    localStorage.setItem(keyStorage, JSON.stringify(users));
    return true;
  }

  return false;
};

export const authenticateUser = (email: string, password: string): boolean => {
  const users = getRegisteredUsers();
  const user = users.find(user => user.email.toLowerCase().trim() === email.toLowerCase().trim());
  return user ? user.password === password : false;
};