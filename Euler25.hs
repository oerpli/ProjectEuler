module Euler25 where
import Data.List
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)

fac n = product [1..n]

fibonacci :: Integer -> Integer
fibonacci 0 = 0
fibonacci x = fst(mf x nfib (0,1))


nfib :: (Integer,Integer) -> (Integer,Integer)
nfib (x,y) = (y,y+x)


mf :: Integer -> (a->a)-> a -> a
mf 1 a y = a y
mf x a y = a (mf (x-1) a y)

gfib :: Int -> (Integer,Integer) -> Integer
gfib z (x,y)
 |length (digits y) >= z = y
 |length (digits y) <= 500 = gfib z (mf 500 nfib (x,y))
 |length (digits y) <= 950 = gfib z (mf 10 nfib (x,y))
 |length (digits y) <= 998 = gfib z (mf 1 nfib (x,y))