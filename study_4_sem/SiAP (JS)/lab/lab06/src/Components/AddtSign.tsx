export default function AddSign(expression: string, sign: string): string {
  let last: string = expression.charAt(expression.length - 1); 
  
  if (Number.isNaN(+last) || last === "") {
    if (last === "" && sign === "-") {
      return expression + sign;
    }
    if (last === "" || last === sign) {
      return expression; 
    } else {
      return expression.slice(0, expression.length - 1) + sign;
    }
  }
  return expression + sign;
}