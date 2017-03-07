module Euler23 where
import Data.List               -- based on http://stackoverflow.com/a/1140100
import qualified Data.Map as M

-- max: 7 digits primes
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)


factorSum :: Integer -> Integer
factorSum x = sum ([y|y<-[1..(div x 2)],mod x y == 0]) 

abundant :: [Integer] -> [Integer]
abundant [] = []
abundant (x:xs) = (if factorSum x > x then [x] else [] )++ abundant xs


