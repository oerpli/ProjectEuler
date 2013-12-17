module Euler12 where
import Data.List
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)




factors x = length ([y|y<-[1..(div x 2)],mod x y == 0]) +1
triang x = sum [1..x]

gf x = if factors (triang x) >= 101 then x else gf (x+1)

-- mag x = sum (map fac (digits x))

-- magic :: [Integer]->Integer
-- magic [] = 0
-- magic (x:xs)
 -- |mag x == x = x + magic xs
 -- |otherwise = magic xs

