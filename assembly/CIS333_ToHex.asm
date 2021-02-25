;Is there a limit to the number of terms that you could calculate?  Why or why not?
;--- The limit is the amount of numbers that can fit into the register that stores the values of the terms. 
;If there is a limit, what would happen if you hit it?  Is there anything you could do about it?
;--- A exception would be thrown that the limit was reached. TO get around this, the terms can be stored 
;--- in a stack to be printed at a later time once all requested terms have been calculated. 
.MODEL

.STACK  100h

.DATA
    
    hextable db '0123456789ABCDEF'
    comma db ',$'
    
.CODE
start:
    mov ax,@DATA
    mov ds,ax
    mov dl,0   ;initialize a counter in the dl
    
repeat:
    inc dl     ;increment the counter at the beginning of the loop
    mov al,dl  ;move the counter into the al and bl
    add al,1   ;adding one to the al for the formula
    mov bl,dl
    mul bl     ;al x bl
    mov bl,2
    div bl     ;al(n x n+1) / bl(2)
    call display_hex   ;call the copied code to display hex
    
    ;mov ah,09h
    ;lea di,comma
    ;int 21h
        
    cmp dl,25          ;check the counter if it has hit 25
    jnz repeat         ;repeat the loop if valid
            
exit:    
    mov ax, 4c00h ;exit to operating system
    int 21h 
    
    display_hex   PROC    near             
        ;---             
        ;--- We will use ax, bx, cx and dx in this routine             
        ;--- which would corrupt whatever data was in them             
        ;--- from the main program.  Therefore, we should             
        ;--- preserve a copy on the stack by pushing them...             
        push       ax             
        push       bx
        push       cx             
        push       dx             
        mov        bx,ax   ;Copy decimal number to bx which                                
                           ;is what we will dissect to get                                
                           ;4 binary digits to look up in                                
                           ;table             
        mov        cl,04   ;We will be rotating 4 digits at a time             
        mov        ch,04   ;Loop counter -- There are 4 hex digits max                                
                           ;in a word (which is size of ax)  
proc_digit:             
        rol        bx,cl   ;Rotate bits left to get digit to convert in                                
                           ;last 4 bits of bl             m
        mov        al,bl         ;Copy the BL into the AL             
        and        al,00001111b  ;Clear bits 4-7 of AL                                      
                                 ;-- bits 0-3 contain the digit and                                      
                                 ;  we can now point at table             
        push       bx            ;Save the BX's contents since we need                                      
                                 ;to convert other digits             
        lea        bx,hextable   ;Load the hextable's address into BX             
        xlat                     ;This instruction is used to look up                                      
                                 ;information in a table.  The BX must                                      
                                 ;point to the table's start (offset)                                      
                                 ;and AL must point to an entry (element)                                      
                                 ;in the table.  Once xlat is done AL                                      
                                 ;will contain the value from the table.             
        pop        bx            ;Restore bx for next digit             
        mov        dl,al         ;Call an interrupt to print out the                                      
                                 ;digit we got from the table             
        mov        ah,02h             
        int        21h             
        dec        ch            ;Decrement the ch counter by 1             
        jnz        proc_digit             
        ;---             
        ;--- Reload original register values prior to this proc call             
        ;---             
        pop        dx             
        pop        cx             
        pop        bx             
        pop        ax
        ret                        ;Return control to calling program
display_hex  ENDP
    
        END start
