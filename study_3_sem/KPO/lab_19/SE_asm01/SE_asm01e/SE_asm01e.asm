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
  mov edi, pstr           ; �������� ����� ������ � ������� EDI
  mov esi, 0              ; ������� �������� � ����������
  mov eax, intfield       ; ��������� ����� ����� � ������� EAX
  cdq                     ; ��������� ���� ����� (EAX � EDX:EAX)
  mov ebx, 10             ; ��������� ������� ��������� (10)
  idiv ebx                ; ����� EAX �� 10, ������� � EDX
  test eax, 80000000h     ; ��������� �������� ���
  jz plus                 ; ���� �������������, ��������� � ����� plus
  neg eax                 ; ������ ���� EAX, ���� ����� �������������
  neg edx                 ; ������ ���� EDX (�������)
  mov cl, '-'             ; ���������� '-' ��� ������ ������ ����������
  mov [edi], cl           ; ��������� ������ '-' � ������
  inc edi                 ; ��������� � ���������� �������

plus:                    ; ������ ����� ��� ���������� �����
  push dx                 ; ��������� ������� � ����
  inc esi                 ; ����������� ������� ��������
  test eax, eax           ; ���������, ����� �� EAX ����
  jz fin                  ; ���� ����, ��������� � ����� fin
  cdq                     ; ��������� ���� EAX
  idiv ebx                ; ����� EAX �� 10, ������� � EDX
  jmp plus                ; ��������� � ��������� ��������

fin:                     ; ���������� �����
  mov ecx, esi           ; ���������� �������� � ECX (����� ��������)

write:                  ; ������ ����� ������ ����������
  pop bx                 ; ��������� ������� �� ����� � BX
  add bl, '0'            ; ����������� ������� � ������ ('0' - 48 � ASCII)
  mov [edi], bl          ; ��������� ������ � ������
  inc edi                ; ��������� � ���������� �������
  loop write             ; ���� ECX �� ����, ����������

  ret                    ; ������� �� ���������
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
