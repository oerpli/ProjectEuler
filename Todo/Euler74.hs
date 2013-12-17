module Euler74 where
import Data.List
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)

fac :: Integer -> Integer
fac 0 = 1
fac x = x*(fac (x-1))

next :: Integer -> Integer
next x = sum $ map fac $digits x


lchain s c l p
 |s == c = [(s,c,l,p)]
 |c == p = [(s,c,l,p)]
 |otherwise = (s,c,l,p) : lchain s (next c) (l+1) c


chain x = lchain x (next x) 1 x