.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib msvcrt.lib
includelib "..\Debug\SE_asm01a.lib"
getmin PROTO : DWORD, : DWORD
getmax PROTO : DWORD, : DWORD

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD
SetConsoleTitleA PROTO : DWORD
GetStdHandle PROTO :DWORD
WriteConsoleA PROTO :DWORD, :DWORD, :DWORD, :DWORD, :DWORD

.STACK 4096

.CONST

.DATA

INT_ARRAY		DWORD		1, 2, 3, 4, 5, 6, 7, 8, 9, 10
TitleCon		DB			"console",0
Text			DB			"getmin + getmax = ", 0
output			DB			10 dup(0)
consolehandle	DD			0h
max				DWORD		?

.CODE			

int_to_char PROC pstr : dword, intfield : sdword
    mov edi, pstr             ; Копируем адрес строки в EDI
    mov esi, 0                ; Счетчик символов в результате
    mov eax, intfield         ; Загружаем число в EAX
    cdq                       ; Расширяем знак числа
    mov ebx, 10               ; Основание (10) для десятичной системы
    idiv ebx                  ; Делим EAX на 10, остаток в EDX
    test eax, 80000000h       ; Проверяем знаковый бит
    jz plus                   ; Если положительное, переходим к plus
    neg eax                   ; Меняем знак EAX
    neg edx                   ; Меняем знак EDX
    mov cl, '-'               ; Записываем '-' как первый символ результата
    mov [edi], cl             ; Сохраняем символ в строку
    inc edi                   ; Переходим к следующему символу

plus:                       ; Начало цикла преобразования
    push dx                   ; Сохраняем остаток в стек
    inc esi                   ; Увеличиваем счетчик
    test eax, eax             ; Проверяем, равно ли EAX нулю
    jz fin                    ; Если да, переходим к fin
    cdq                       ; Расширяем знак EAX
    idiv ebx                  ; Делим EAX на 10
    jmp plus                  ; Переходим к следующей итерации

fin:                        ; Завершение цикла
    mov ecx, esi             ; Сохраняем количество остатков в ECX
write:                      ; Начало цикла записи результата
    pop bx                   ; Извлекаем остаток из стека в BX
    add bl, '0'              ; Преобразуем остаток в символ
    mov [edi], bl            ; Сохраняем символ в строку
    inc edi                  ; Переходим к следующему символу
    loop write               ; Если ECX не ноль, продолжаем

    ret                      ; Возврат из процедуры
int_to_char ENDP

main proc 

	push offset TitleCon
	call SetConsoleTitleA

	push -11
	call GetStdHandle
	mov consolehandle, eax

	push 0 
	push 0
	push sizeof Text
	push offset Text
	push consolehandle
	call WriteConsoleA

	INVOKE getmax, OFFSET INT_ARRAY, LENGTHOF INT_ARRAY
	mov max, eax

	INVOKE getmin, OFFSET INT_ARRAY, LENGTHOF INT_ARRAY
	add eax, max

	INVOKE int_to_char, OFFSET output, eax
	push 0
	push 0
	push sizeof output
	push offset output
	push consolehandle
	call WriteConsoleA

	push -1
	call ExitProcess

main ENDP

end main
