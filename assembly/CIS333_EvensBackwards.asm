;---Brett Previdi
;---CIS333
;---This program will increment even numbers to an array from 2 to 100   
;---then display then beginning at the last index to the first
;---adding a comma between each and stopping at the last index

.MODEL
.STACK 100h
.DATA
    array   db  50 DUP (?)
    hextable db '0123456789ABCDEF' 
    comma   db  ', $'
    
.CODE
start:
    mov     ax,@DATA
    mov     ds,ax
    
    call    clrscr       ;I felt I should include the function to clear the screen
    
    mov     cx,50        ;Loop counter
    mov     di,00        ;Array index counter
    mov     al,2         ;Initial array value
    
repeat:                  ;First loop to store the values then inc by 2
    mov     array[di],al ;Send variable to array
    inc     di           ;Increment index counter
    inc     al           ;Double increment variable
    inc     al
    loop    repeat 
    
    mov     cx,50        ;Loop counter
    mov     di,50        ;Reset index counter
    
repeat2:                 ;Second loop to print in reverse order
    mov     al,array[di] ;Move array variables to al to be displayed
    call    display_hex  ;Display hex code from previous assignment
    
    dec     di           ;Decrement index
    
    cmp     di,0         ;If the index is 0, jump to exit
    jnz     code2        ;otherwise, print the comma
    
code1:   
    jmp     exit
  
code2:    
    mov     dl,comma     ;Print a comma between each number
    mov     ah,02h
    int     21h
    
    loop    repeat2      ;Repeat loop
    
exit:  
    mov     ax,4c00h     ;End Program
    int     21h

;----------------Code from notes-------------------    
clrscr      PROC  near
    mov     cx,0000     
    mov     dx,184Fh    
    mov     bh,07     
    mov     ax,0600h    
    int     10h
    ret
clrscr      endp  

display_hex   PROC    near             
                  
    push    ax             
    push    bx
    push    cx             
    push    dx             
    mov     bx,ax   
                     
    mov     cl,04                
    mov     ch,04  
          
proc_digit:             
    rol     bx,cl                                   
                           
    mov     al,bl                     
    and     al,00001111b  
                   
    push    bx                       
    lea     bx,hextable 
       
    xlat
                        
    pop     bx                         
    mov     dl,al        
                     
    mov     ah,02h             
    int     21h 
                    
    dec     ch                         
    jnz     proc_digit             
                
    pop     dx             
    pop     cx             
    pop     bx             
    pop     ax
    ret                        ;Return control to calling program
display_hex  ENDP               
    
    END     start    
