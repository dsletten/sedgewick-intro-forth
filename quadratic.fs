\   Hey, Emacs, this is a -*- Mode: Forth -*- file!
\
\   Look not mournfully into the past, it comes not back again. Wisely improve the present, it is thine. Go forth to meet the shadowy future without fear and with a manly heart.
\   -- Henry Wadsworth Longfellow
\
\   Name:               quadratic.fs
\
\   Started:            Sat Jan 18 00:18:13 2025
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

: 3dup   ( a b c -- a b c a b c ) dup 2over rot ;

\ : discriminant   ( b a c -- d ) 4e f* f* fswap fdup f* fswap f- ;
: discriminant   ( a b c -- a b d ) frot fdup frot -4e f* f* frot fdup fdup f* frot f+ ;

\ : quadratic   ( a b c -- r1 r2 ) 3dup rot swap discriminant
\ Assumes real roots for now
: quadratic   ( a b c -- r1 r2 ) discriminant fsqrt frot 2e f* fdup frot fswap f/ frot frot f/ fnegate fover fover f+ frot frot f- fnegate ;

\ (x - 7)(x - 9) = x2 - 16x + 63
\ (2x + 4)(x - 5) = 2x2 - 6x - 20

\ Complex roots -> nan

