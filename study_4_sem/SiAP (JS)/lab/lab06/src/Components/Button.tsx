interface ButtonProps {
  darkTheme: boolean, 
  keyName: string,
  name: string, 
  callback: () => void
}

export default function Button({darkTheme, keyName, name, callback}: ButtonProps) {
  return (
    <button data-darktheme = {darkTheme} id = {keyName} onClick = {callback}>
      {name}
    </button> 
  );
}