module Euler46 where
import LibEuler

squares = [2* n^2|n<-[0..]]


prm n = takeWhile (<=n) primes
sqr n = takeWhile (<=n) squares

test n = not $ elem n $ concat $ map (testp n) (prm n)

testp n p = map (+p) (sqr n)


odds = filter odd [2..]
comps = filter (not . prime) odds

solve = find test comps