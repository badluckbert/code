;---Brett Previdi---
;---CIS 333---
;---Assignment 5---
;-This program should ask the user for inputs
;-one line at a time, then write that input data
;-to a created txt file. The file is closed then
;-reopened to be read from.

.MODEL      small   
.STACK      10h
.DATA  
    ;---Messages and Input Instructions---
    input1      db  'Order Number:$'
    input2      db  'Customer ID:$'
    input3      db  'Sprocket Type:$'
    input4      db  'Part Quantity:$'
    input5      db  'Order Total:$'    
    msg1        db  0Dh,0Ah,0Dh,0Ah,'Struct written to file:$'
    msg2        db  'C:\Orders\OrderInfo.txt',0Dh,0Ah,0Dh,0Ah,'$'
    msg3        db  0Dh,0Ah,'Program Finished$' 
    
    ;---File Attributes---
    file_buf    db  5*10 DUP (?)
    file_name   db  'C:\Orders\OrderInfo.txt', 00h   
    dir_name    db  'C:\Orders', 00h
    
    ;---Input Stuff---
    INPUTSTRUCT LABEL   BYTE
    MaxLen      db      8
    ActLen      db      0
    InputBuf    db      8 DUP(?)
    CRLFBuf     db      0Dh, 0Ah, '$'     
    handle1     DW      0
    
    ;---Error Checking---
    cr          EQU 0Dh
    lf          EQU 0Ah
    errtbl      DW  0,err1,err2,err3,err4,err5,err6
                DW  5 DUP (0)
                DW  err12
    err1        db  'Invalid function number',lf,cr,'$'
    err2        db  'File not found',lf,cr,'$'   
    err3        db  'Path not found',lf,cr,'$'
    err4        db  'Too many open files',lf,cr,'$'      
    err5        db  'Access denied',lf,cr,'$'
    err6        db  'Invalid handle',lf,cr,'$'    
    err12       db  'Invalid access code',lf,cr,'$'
        
start:
    mov     ax, @DATA
    mov     ds, ax       
    
    ;--- Create Directory 
    mov     ax, SEG dir_name
    mov     ds, ax
    mov     dx, OFFSET dir_name   
    mov     ah, 39h
    int     21h   
    call    err_chk
        
    ;--- Create and Open File    
    mov     ah, 3Ch
    mov     cx, 00
    lea     dx, file_name
    int     21h    
    call    err_chk
    mov     handle1, ax  
    
    ;---Input Time---
    mov     ah, 9
    lea     dx, input1 ;Order Number 
    int     21h
    call    input
    
    mov     ah, 9
    lea     dx, CRLFBuf ;New Line
    int     21h
    
    mov     ah, 9
    lea     dx, input2 ;Customer ID
    int     21h
    call    input
     
     
    mov     ah, 9
    lea     dx, CRLFBuf
    int     21h
     
    mov     ah, 9
    lea     dx, input3 ;Sprocket Type
    int     21h
    call    input
    
     
    mov     ah, 9
    lea     dx, CRLFBuf
    int     21h
    
    mov     ah, 9
    lea     dx, input4 ;Part Quantity
    int     21h
    call    input
    
     
    mov     ah, 9
    lea     dx, CRLFBuf
    int     21h
       
    mov     ah, 9
    lea     dx, input5 ;Order Total
    int     21h
    call    input     
    
    ;---Close File---
    mov     ah, 3Eh
    mov     bx, handle1
    int     21h
    call    err_chk
    
    ;---Display Written Confirmation---
    mov     ah, 9
    lea     dx, msg1 ;Confirmation of Write
    int     21h
    
    mov     ah, 9
    lea     dx, msg2 ;to file_name
    int     21h

    ;---Reading Time--- 
    
    call readfile
    
    ;---Close File---
    mov     ah, 3Eh
    mov     bx, handle1
    int     21h
    call    err_chk
    
    ;---Print Completion---
    mov     ah, 9
    lea     dx, CRLFBuf
    int     21h  
    
    mov     ah, 9
    lea     dx, msg3
    int     21h
    
end:    
    mov     ax, 4c00h
    int     21h
        
    
;-------------Methods-----------------    
err_chk     PROC    near
    jnc     exitproc
    mov     bx, ax
    mov     ah, 9
    mov     dx, errtbl[bx]
    int     21h         
    mov     ax, 4C00h
    int     21h  
    exitproc:   ret
err_chk     ENDP 


input       PROC    near
    lea     dx, INPUTSTRUCT
    mov     ah, 0Ah
    int     21h    
    
    mov     bh, 00h
    mov     bl, ActLen
    mov     InputBuf[bx], 00h 
    
    mov     cx, 10
    mov     ah, 40h
    mov     bx, handle1
    lea     dx, INPUTSTRUCT+2
    int     21h 
    
    call    err_chk
exit_input: ret
input       ENDP  


readfile   PROC    near    
    ;---Read Information From File---
    mov     ah, 3Dh 
    mov     al, 000b
    lea     dx, file_name
    int     21h
    call    err_chk
    mov     handle1, ax
    
    ;---Get File Length---
    mov     ah, 42h
    mov     al, 02h
    mov     bx, handle1
    xor     cx, cx
    xor     dx, dx
    int     21h
    push    ax
    call    err_chk   
    
    ;---Reset File Pointer to Beginning of File---
    mov     ah, 42h
    mov     al, 00h
    mov     bx, handle1
    xor     cx, cx
    xor     dx, dx
    int     21h 
    call    err_chk
    
     ;---Read File---
    mov     ah, 3Fh
    mov     bx, handle1
    pop     cx
    lea     dx, file_buf
    int     21h
    call    err_chk
    
    ;---Display Data in File Buffer---
    mov     ah, 9
    lea     dx, input1 ;Order Number
    int     21h
    
    call    clearbuffer
    
    mov     ah, 40h
    mov     bx, 1
    mov     cx, 10
    lea     dx, file_buf
    int     21h 
    
    ;---Display Data in File Buffer---    
    mov     ah, 9
    lea     dx, input2 ;Customer ID
    int     21h
       
    call    clearbuffer
    
    mov     ah, 40h
    mov     bx, 1
    mov     cx, 10
    lea     dx, file_buf+10
    int     21h
     
    ;---Display Data in File Buffer---     
    mov     ah, 9
    lea     dx, input3 ;Sprocket Type
    int     21h    
    
    call    clearbuffer
    
    mov     ah, 40h
    mov     bx, 1
    mov     cx, 10
    lea     dx, file_buf+20
    int     21h
    
     ;---Display Data in File Buffer---     
    mov     ah, 9
    lea     dx, input4 ;Part Quantity
    int     21h    
    
    call    clearbuffer
   
    mov     ah, 40h
    mov     bx, 1
    mov     cx, 10
    lea     dx, file_buf+30
    int     21h
    
    ;---Display Data in File Buffer---
    mov     ah, 9
    lea     dx, input5 ;Order Total
    int     21h    
    
    call    clearbuffer
    
    mov     ah, 40h
    mov     bx, 1
    mov     cx, 10
    lea     dx, file_buf+40
    int     21h    
   
exit_readfile:  ret
readfile   ENDP


clearbuffer PROC    near
    mov     cl, MaxLen 
    mov     si, 0000
    
clearloop:
    mov     InputBuf[si], 20h
    inc     si
    loop    clearloop 
    
exit_clearbuffer: ret
clearbuffer ENDP      
    
    END     start 