module Euler50 where
import LibEuler
import Data.List

flt n x = (f x) == (f $ x*n) where f = (sort . show)
s 1 = [1..]
s n = filter (flt n) (s (n-1))
solve = head $ s 6
sg = head . s
