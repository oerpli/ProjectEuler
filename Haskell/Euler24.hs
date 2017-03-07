module Euler23 where
import Data.List               -- based on http://stackoverflow.com/a/1140100
import qualified Data.Map as M

-- max: 7 digits primes
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)

permutation :: Eq a => [a] -> [[a]]
permutation [] = [[]]
permutation xs = [x:ys | x <- xs, ys <-permutation (delete x xs)]