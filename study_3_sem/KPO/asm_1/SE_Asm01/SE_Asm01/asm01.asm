.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
MB_OK   EQU 1
STR1    DB "Моя первая программа", 0
STR2    DB "Привет всем!", 0
HW      DD ?

.CODE

main PROC
START :
		PUSH	MB_OK
		PUSH	OFFSET STR1
		PUSH	OFFSET STR2
		PUSH	HW
		CALL	MessageBoxa

	push - 1
	call ExitProcess
main ENDP

end main