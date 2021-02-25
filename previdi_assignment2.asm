;Assignment 1
;---------------------------------------  
.MODEL  small               
.DATA 
blank       db 10,13,' $'                  
dashes      db '////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\$'
summary     db 10,13,'/                     Fractured Economies Banking                     \$'
dashes2     db 10,13,'////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\$'
info        db 10,13,'Account Information:$'
naming      db 10,13,'Brett Previdi$'
checking    db 10,13,'Checking:  2,405,401.08           Account Number: 1-0A-7154432$'
savings     db 10,13,'Savings:  14,302,392.72           Account Number: 1-0B-7463736$'
menu        db 10,13,'Account Menu Options:$'
withdraw    db 10,13,'  1) Withdrawal$'
deposit     db 10,13,'  2) Deposit$'
inquiry     db 10,13,'  3) Account Inquiry$'
transfer    db 10,13,'  4) Funds Transfer$'
crush       db 10,13,'  5) Crush local economy$'
request     db 10,13,'  6) Request a loan that will never be repaid$'
logoff      db 10,13,'  7) Logoff System$'
endpoint    db 10,13,'<->$'
bigline     db 10,13,'+--------------------------------------------------------------------+$'
valued      db 10,13,'|  No Fee Too Small To Charge Our Valued Customers! (Cool 3D, eh?)   ||$' 
bigline2    db 10,13,'+--------------------------------------------------------------------+|$'
bigline3    db 10,13,' ---------------------------------------------------------------------+$'  
          
.CODE                   

start: mov     ax,@DATA            
       mov     ds,ax             
          
       lea     dx,dashes
       mov     ah,09h
       int     21h 
       
       lea     dx,summary
       mov     ah,09h
       int     21h 
       
       lea     dx,dashes2
       mov     ah,09h
       int     21h 
       
       lea     dx,blank
       mov     ah,09h
       int     21h    
       
       lea     dx,info
       mov     ah,09h
       int     21h 
       
       lea     dx,naming
       mov     ah,09h
       int     21h 
       
       lea     dx,blank
       mov     ah,09h
       int     21h
       
       lea     dx,checking
       mov     ah,09h
       int     21h 
       
       lea     dx,savings
       mov     ah,09h
       int     21h 
       
       lea     dx,blank
       mov     ah,09h
       int     21h
       
       lea     dx,menu
       mov     ah,09h
       int     21h 
       
       lea     dx,blank
       mov     ah,09h
       int     21h
       
       lea     dx,withdraw
       mov     ah,09h
       int     21h 
       
       lea     dx,deposit
       mov     ah,09h
       int     21h 
       
       lea     dx,inquiry
       mov     ah,09h
       int     21h 
       
       lea     dx,transfer
       mov     ah,09h
       int     21h 
       
       lea     dx,crush
       mov     ah,09h
       int     21h 
       
       lea     dx,request
       mov     ah,09h
       int     21h 
       
       lea     dx,logoff
       mov     ah,09h
       int     21h 
       
       lea     dx,endpoint
       mov     ah,09h
       int     21h 
       
       lea     dx,bigline
       mov     ah,09h
       int     21h 
       
       lea     dx,valued
       mov     ah,09h
       int     21h 
       
       lea     dx,bigline2
       mov     ah,09h
       int     21h 
       
       lea     dx,bigline3
       mov     ah,09h
       int     21h 
       
       mov     ah,02h
       mov     dh,19
       mov     dl,3
       int     10h
       
       mov     ah,1
       int     21h      
        
exit:  mov     ax,4C00h                
       int     21h                   
       END     start