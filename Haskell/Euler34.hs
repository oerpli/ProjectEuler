module Euler34 where
import Data.List
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)

fac 0 = 1
fac x = x*(fac (x-1))

mag x = sum (map fac (digits x))

magic :: [Integer]->Integer
magic [] = 0
magic (x:xs)
 |mag x == x = x + magic xs
 |otherwise = magic xs

