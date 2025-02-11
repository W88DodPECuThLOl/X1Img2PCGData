    .z80

    .module asm_x1pcg

    ; void pcgWrite(u8* pcgDataAddress);
    .globl _pcgWrite

    .area _CODE

; -------------------------------------------------------------------
; void pcgWrite(u8* pcgDataAddress);
_pcgWrite:

    ; 漢字
    ld  bc, #0x3FFF
    xor a
    out (c), a
    ; 属性
    ld  b, #0x27        ; bc is 0x27FF
    ld  a, #0x20
    out (c), a

    ; PCG高速アクセス
    ld  bc, #0x1fd0
    in  d, (c)
    or  d               ; a reg is 0x20
    out (c), a

    ; 設定する文字の数
    ld  d,(hl)
    inc hl
loop0:
        ; 設定する文字
        ld   bc, #0x37FF + #0x100
        outi

        ; pcg書き込む 
        ; b
        ld   bc, #0x1500 + #0x100
        call pcgWriteSub
        ; r
        ld   bc, #0x1600 + #0x100
        call pcgWriteSub
        ; g
        ld   bc, #0x1700 + #0x100
        call pcgWriteSub
    dec d
    jr  nz,loop0

    ; PCG通常アクセス
    ld  bc, #0x1fd0
    in  a, (c)
    and #0xdf
    out (c), a
    ret

pcgWriteSub:
    outi
    ld  e, #7
loop1:
        inc	c
        inc	c
        inc	b
        outi
    dec e
    jr  nz,loop1
    ret
