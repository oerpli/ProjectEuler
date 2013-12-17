module Euler20 where
import Data.List
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)

fac 0 = 1
fac x = x*(fac (x-1))


sumd x = sum $ digits x