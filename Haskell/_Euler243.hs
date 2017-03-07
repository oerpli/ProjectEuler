module Euler243 where
import LibEuler

res :: Integer -> Integer
res n = fromIntegral(length $ filter (1==) (map (gcd  n) [1..n-1]))

resBT :: Integer -> Bool
resBT n = (94744*(res n)) < (15499*(n-1))


ppr n = product (take n primes)


---XD
rev :: [a]->[a]
rev [] = []
rev (x:xs) = rev xs ++ [x]

fbn :: Integer -> Integer
fbn 0 = 1
fbn 1 = 1
fbn n = fbn (n-1) + fbn (n-2)