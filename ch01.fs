\   Hey, Emacs, this is a -*- Mode: Forth -*- file!
\
\   Come forth into the light of things, let nature be your teacher.
\   -- William Wordsworth
\
\   Name:               ch01.fs
\
\   Started:            Thu Feb 20 09:40:43 2025
\   Modifications:
\
\   Purpose:
\
\
\
\   Calling Sequence:
\
\
\   Inputs:
\
\   Outputs:
\
\   Example:
\
\   Notes:
\
\

\ Ex. 1.2.21
\ 100e 12e 1e compoundInterest'  ok
\ f. 112.749685157938  ok
\ 3000e 7e 5e compoundInterest'  ok
\ f. 4257.20264577977  ok
\ 5000e 9e 15e compoundInterest'  ok
\ f. 19287.1276534849  ok

: ?valid ( r -- f ) f0> ;

: checkXY ( x y -- f )
    fswap ?valid if ?valid if true
                           else ." Bad y" false then
                 else ." Bad x" fdrop false then ;

: checkXYZ ( x y z -- f ) 
    frot ?valid if fswap ?valid if ?valid if true
                                          else ." Bad z" false then
                                else ." Bad y" fdrop false then
                else ." Bad x" fdrop fdrop false then ;
             
: compoundInterest'   ( p r t -- a )
    fswap
    100e f/ ( Convert rate to % )
    f* fexp f* ;

\ : compoundInterest   ( p r t -- a )
\     fdup ?valid if frot fdup ?valid if frot fdup ?valid if frot compoundInterest'
\             else ." Invalid interest rate"
\             else ." Invalid principal"
\             else ." Invalid term" then then then ;

: compoundInterest   ( p r t -- a )
    fdup ?valid
    frot fdup ?valid and
    frot fdup ?valid and
    if frot compoundInterest'
    else ." Invalid input for formula" fdrop fdrop fdrop then ;        

\ Ex. 1.2.22
: windChill'   ( t v -- w )
    0.16e f** fswap
    fdup
    0.4275e f*
    35.75e f-
    frot
    f*
    fswap
    0.6215e f*
    35.74e f+
    f+ ;

\ : windChill   ( t v -- w )
\    fdup 3e f>= if windChill' else ." Bad wind speed" drop drop then ;

: windChill   ( t v -- w )
    fdup ?validWindSpeed fswap fdup ?validTemperature and if fswap windChill' else
        ." Invalid input for formula" fdrop fdrop then ;

: ?validTemperature   ( t --  ) fabs 50e f<= ;
\ : ?validTemperature   ( t -- f ) fdup fabs 50e f<= ;

: ?validWindSpeed    ( v -- ) fdup 3e f>= 120e f<= and ;

\ Ex. 1.2.23

: hypotenuse   ( r1 r2 -- r3 ) fdup f* fswap fdup f* f+ fsqrt ;

: cartesian->polar   ( x y -- r theta ) fdup frot fdup frot hypotenuse frot frot fatan2 ;
