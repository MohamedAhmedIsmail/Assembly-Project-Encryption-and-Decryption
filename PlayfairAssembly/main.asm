INCLUDE Irvine32.inc
.data
Str_Max=1000
playfair byte 5 dup(0)
byte 5 dup(0)
byte 5 dup(0)
byte 5 dup(0)
byte 5 dup(0)
alphabet byte "ABCDEFGHIKLMNOPQRSTUVWXYZ"
nosp byte Str_Max dup(0)
nospdec byte Str_Max dup(0)
predecryption byte Str_Max dup(0)
i1 byte 0
i2 byte 0
j1 byte 0
j2 byte 0
tmpFileHandle HANDLE ?
.code
;converts a string to uppercase
ToUpper PROC str1:PTR BYTE, sz:DWORD
	push esi
	push ecx
	
	mov esi, str1
	mov ecx, sz
	l1:
		;input validations (Limitation the char to be between a and z)
		cmp byte ptr [esi], 'a'
		jb skip
		cmp byte ptr [esi], 'z'
		ja skip
		and byte ptr [esi], 11011111b
		skip:
		inc esi
	loop l1
	
	pop ecx
	pop esi
	ret
ToUpper ENDP
;receives edx pointing to playfair array,edi pointing to source keyword + alphabet,ebx pointing to edi
;ecx containing length of keyword + alphabet
;returns nothing
filterstring proc uses edx edi ebx ecx eax esi
cld
dec ecx 				
mov esi,1
mov eax,0
mov al,[edi]
mov [edx],al
inc ebx
inc edx
filter:
push ecx
push edi
mov ecx,esi
mov al,[ebx]
cmp al,' '
je skipfilter
repne scasb
je skipfilter
mov [edx],al
inc edx
skipfilter:
pop edi
pop ecx
inc ebx
inc esi 
loop filter
ret
filterstring ENDP
;fills the playfair array with the keyword + alphabet
;receives source keyword and its size
;returns nothing
FillPlayfair proc src:ptr byte,sz:dword
	pushad
	mov ecx,sz
	invoke ToUpper, src, ecx
	mov esi , src
	call jtoi
	mov esi,offset alphabet
	mov edi,src
	add edi,sz
	mov ecx,lengthof alphabet
	push ecx
	rep movsb
	pop ecx
	add ecx,sz
	mov edx, offset playfair
	mov edi, src
	mov ebx,edi
	call filterstring
	popad
ret
FillPlayfair endp
;encrypts a string using playfair algorithm
;receives source string, length of source string
;returns nothing
Encrypt Proc src:ptr byte,sz:dword,target:ptr byte
pushad
mov edi,offset nosp
mov ecx,lengthof nosp
mov eax,0
rep stosb
mov esi,src
mov edi,offset nosp
mov edx,target
mov ecx,sz
invoke toupper ,src,sz
call jtoi
call removespaces
mov edi,offset playfair
mov esi,offset nosp
mov eax,0
pairbypair:
cmp byte ptr [esi],0
je brk
mov al,[esi]
cmp byte ptr [esi+1],0
je odd
cmp al,[esi+1]
jne diff
odd:
call findindex
mov al,bl
cbw
mov ebx,0
mov bl,lengthof playfair
div bl
mov i1,al
mov j1,ah
mov al,'Q'
call findindex
mov al,bl
cbw
mov ebx,0
mov bl,lengthof playfair
div bl
mov i2,al
mov j2,ah
jmp done
diff:
call findindex
mov al,bl
cbw
mov ebx,0
mov bl,lengthof playfair
div bl
mov i1,al
mov j1,ah
inc esi
mov al,[esi]
call findindex
mov al,bl
cbw
mov ebx,0
mov bl,lengthof playfair
div bl
mov i2,al
mov j2,ah
done:
call returnencrypted
mov [edx],al
inc edx
mov [edx],bl
inc edx
inc esi
jmp pairbypair
brk:
popad
ret
Encrypt ENDP
removespaces proc uses esi edi ecx
remspaces: 
cmp byte ptr [esi],' '
je done
movsb
jmp Next
done:
inc esi
Next:
loop remspaces
ret
removespaces endp
;receives a letter in al, edi points to playfair array
;returns linear index in ebx
findindex PROC uses edi ecx
mov ecx,25
mov ebx,edi
repne scasb
dec edi
sub edi,ebx
mov ebx,edi
ret
findindex ENDP
;receives static variables i1,j1,i2,j2
;returns encrypted characters in al, bl
returnencrypted PROC uses edx
mov edx,0
mov dl,i1
cmp dl,i2
jne elseiff
inc j1
inc j2
cmp j1,5
jne notj15
mov j1,0
jmp done
notj15:
cmp j2,5
jne done
mov j2,0
jmp done
elseiff:
mov dl,j1
cmp dl,j2
jne elsef
inc i1
inc i2
cmp i1,5
jne noti15
mov i1,0
jmp done
noti15:
cmp i2,5
jne done
mov i2,0
jmp done
elsef:
mov dl,j1
xchg dl,j2
mov j1,dl
done:
mov eax,0
mov al,i1
mov ecx,0
mov cl,lengthof playfair
mul cl
add al,j1
mov al,playfair[eax]
push eax
mov eax,0
mov al,i2
mul cl
add al,j2
mov bl,playfair[eax]
pop eax
ret
returnencrypted ENDP

jtoi proc uses esi ecx
L:
cmp byte ptr [esi],'J'
jne continue
mov byte ptr [esi],'I' 
continue:
inc esi
Loop L
ret
jtoi endp
;decrypts a string using playfair algorithm
;receives source string, length of source string
;returns nothing
Decrypt Proc src:ptr byte,sz:dword,target:ptr byte
pushad
mov edi,offset nospdec
mov ecx,lengthof nospdec
mov eax,0
rep stosb
mov edi,offset predecryption
mov ecx,lengthof predecryption
rep stosb
mov esi,src
mov edi,offset nospdec
mov edx,offset predecryption
mov ecx,sz
invoke toupper ,src,sz
call removespaces
mov edi,offset playfair
mov esi,offset nospdec
mov eax,0
pairbypair:
cmp byte ptr [esi],0
je brk
mov al,[esi]
call findindex
mov al,bl
cbw
mov ebx,0
mov bl,lengthof playfair
div bl
mov i1,al
mov j1,ah
inc esi
mov al,[esi]
call findindex
mov al,bl
cbw
mov ebx,0
mov bl,lengthof playfair
div bl
mov i2,al
mov j2,ah
inc esi
call returndecrypted
mov [edx],al
inc edx
mov [edx],bl
inc edx
jmp pairbypair
brk:
mov esi,offset predecryption
mov edi,target
call filterq
popad
ret
Decrypt ENDP

;removes extra q's in the decrypted plain text
;receives esi pointing to predecrypted text,edi pointing to the final output (target)
;returns nothing
filterq PROC uses esi edi edx
movsb
mov edx,0
checkq:
cmp byte ptr [esi],0
je brk
cmp byte ptr [esi],'Q'
jne notq
mov dl,[esi-1]
cmp dl,[esi+1]
jne testnull
inc esi
jmp notq
testnull:
cmp byte ptr [esi+1],0
je brk
movsb
jmp checkq
notq:
movsb
jmp checkq
brk:
ret
filterq ENDP

;receives static variables i1,j1,i2,j2
;returns decrypted characters in al, bl
returndecrypted PROC uses edx
mov edx,0
mov dl,i1
cmp dl,i2
jne elseiff
dec j1
dec j2
cmp j1,-1
jne notj1neg1
mov j1,4
jmp done
notj1neg1:
cmp j2,-1
jne done
mov j2,4
jmp done
elseiff:
mov dl,j1
cmp dl,j2
jne elsef
dec i1
dec i2
cmp i1,-1
jne noti1neg1
mov i1,4
jmp done
noti1neg1:
cmp i2,-1
jne done
mov i2,4
jmp done
elsef:
mov dl,j1
xchg dl,j2
mov j1,dl
done:
mov eax,0
mov al,i1
mov ecx,0
mov cl,lengthof playfair
mul cl
add al,j1
mov al,playfair[eax]
push eax
mov eax,0
mov al,i2
mul cl
add al,j2
mov bl,playfair[eax]
pop eax
ret
returndecrypted ENDP

WriteToAFile PROC filename:ptr byte,src:ptr byte,sz:dword
MOV EDX, filename
CALL CreateOutputFile				; EAX will contain a valid file handle (32-bit integer) if the file was created successfully. Otherwise, EAX equals INVALID_HANDLE_VALUE
MOV tmpFileHandle, EAX
;Write to file
MOV ECX, sz
MOV EDX, src	
CALL WriteToFile
CALL CloseFile
ret
WriteToAFile ENDP

ReadFromAFile PROC filename:ptr byte,src:ptr byte,sz:dword
MOV EDX, filename
CALL OpenInputFile										
MOV tmpFileHandle, EAX
;Read from file
MOV EDX, src			;buffer to read in it
MOV ECX, Str_Max	
CALL ReadFromFile
mov sz,eax
MOV EAX, tmpFileHandle
CALL CloseFile 
ret
ReadFromAFile ENDP
  
DllMain PROC hInstance:DWORD, fdwReason:DWORD, lpReserved:DWORD
mov eax, 1 ; Return true to caller.
ret
DllMain ENDP
END DllMain