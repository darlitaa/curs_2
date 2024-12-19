.586P											
.MODEL FLAT, STDCALL									
includelib kernel32.lib									

ExitProcess PROTO : DWORD								
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD	

.STACK 4096								

.CONST									

ZERO		EQU			0

.DATA									

myBytes		BYTE		10h, 20h, 30h, 40h
myWords		WORD		8Ah, 3Bh, 44h, 5Fh, 99h
myDoubles	DWORD		1, 2, 3, 4, 5, 6
myPointer	DWORD		myDoubles
result		DB			"Результат", 0
message0	DB			"В массиве есть нулевой элемент", 0
message1	DB			"В массиве нет нулевого элемента", 0
myArray		DWORD		5, 7, 4, 2, 6, 7, 3
HW			DD			?

.CODE									

main PROC 								

	mov ESI, offset myBytes				
	mov AH, [ESI + 1]
	mov AL, [ESI + 3]

	mov ESI, offset myArray				
	mov ECX, lengthof myArray			

	mov EAX, ZERO

CYCLE:

	add EAX, [ESI]						
	add	ESI, type myArray		
	loop CYCLE							

	mov ESI, offset myArray				
	mov ECX, lengthof myArray

CHECK_ZERO:
	cmp dword ptr [ESI], ZERO
	je CASE_ZERO
	add ESI, type myArray
	loop CHECK_ZERO
	
	jmp CASE_ONE

CASE_ZERO:
	mov EBX, zero
	INVOKE MessageBoxA, HW, offset message0, offset result, ZERO
	jmp ENDING

CASE_ONE:
	mov EBX, 1
	INVOKE MessageBoxA, HW, offset message1, offset result, ZERO

ENDING:
	push 0								
	call ExitProcess					

main ENDP								

end main