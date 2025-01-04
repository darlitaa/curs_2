.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib libucrt.lib
includelib "..\Debug\SE_asm01d.lib"

.STACK 4096

getmin PROTO : DWORD, : DWORD
getmax PROTO : DWORD, : DWORD

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD
SetConsoleTitleA PROTO : DWORD
GetStdHandle PROTO :DWORD
WriteConsoleA PROTO :DWORD, :DWORD, :DWORD, :DWORD, :DWORD


.CONST

.DATA

INT_ARRAY		DWORD		1, 2, 3, 4, 5, 6, 7, 8, 9, 20
TitleCon		DB			"console",0
Text			DB			"getmin + getmax = ", 0
output			DB			10 dup(0)
consolehandle	DD			0h
max				DWORD		?

.CODE			

int_to_char PROC pstr : dword, intfield : sdword
  mov edi, pstr           ; Копируем адрес строки в регистр EDI
  mov esi, 0              ; Счетчик символов в результате
  mov eax, intfield       ; Загружаем целое число в регистр EAX
  cdq                     ; Расширяем знак числа (EAX в EDX:EAX)
  mov ebx, 10             ; Основание системы счисления (10)
  idiv ebx                ; Делим EAX на 10, остаток в EDX
  test eax, 80000000h     ; Проверяем знаковый бит
  jz plus                 ; Если положительное, переходим к метке plus
  neg eax                 ; Меняем знак EAX, если число отрицательное
  neg edx                 ; Меняем знак EDX (остаток)
  mov cl, '-'             ; Записываем '-' как первый символ результата
  mov [edi], cl           ; Сохраняем символ '-' в строку
  inc edi                 ; Переходим к следующему символу

plus:                    ; Начало цикла для разложения числа
  push dx                 ; Сохраняем остаток в стек
  inc esi                 ; Увеличиваем счетчик символов
  test eax, eax           ; Проверяем, равно ли EAX нулю
  jz fin                  ; Если ноль, переходим к метке fin
  cdq                     ; Расширяем знак EAX
  idiv ebx                ; Делим EAX на 10, остаток в EDX
  jmp plus                ; Переходим к следующей итерации

fin:                     ; Завершение цикла
  mov ecx, esi           ; Количество остатков в ECX (число символов)

write:                  ; Начало цикла записи результата
  pop bx                 ; Извлекаем остаток из стека в BX
  add bl, '0'            ; Преобразуем остаток в символ ('0' - 48 в ASCII)
  mov [edi], bl          ; Сохраняем символ в строку
  inc edi                ; Переходим к следующему символу
  loop write             ; Если ECX не ноль, продолжаем

  ret                    ; Возврат из процедуры
int_to_char ENDP

main proc 

	push -11
	call GetStdHandle
	mov consolehandle, eax

	push 0
	push 0
	push lengthof Text
	push offset Text
	push consolehandle
	call WriteConsoleA

	push lengthof INT_ARRAY
	push offset INT_ARRAY
	call getmin

	mov ebx, eax

	push lengthof INT_ARRAY
	push offset INT_ARRAY
	call getmax

	add eax, ebx

	push eax
	push OFFSET output
	call int_to_char

	push 0
	push 0
	push sizeof output
	push offset output
	push consolehandle
	call WriteConsoleA

	push 0
	push 0
	call ExitProcess

main ENDP

end main
