module Euler495 where
import Data.Maybe 
import LibEuler



divs :: Integer -> Bool
divs n = and $ (prime $ n+1) : [ prime (x + div n x) | x <- [2..limit], rem n x == 0 ]
     where limit = (floor.sqrt.fromIntegral) n


zipplus (a:b:ls) = (a+b) : zipplus ls
zipplus _ = []


allPrimes :: [Integer] -> Bool
allPrimes [x] = prime x 
allPrimes (x:xs) = if prime x then allPrimes xs else False


test :: Integer -> Integer
test n = if allPrimes $ zipplus (1 : divisors n) then n else 0
--add 1 as first divisor is always 1 and 1+1 is a prime and n+1 must be a prime (by solve)


listF 2 n = filter (\x -> prime (x+1)) $ listF 1 n
listF 1 n = 1 : (filter even $ listF 0 n)
listF 0 n = [1..10^n]



solve n = sum $ map test (listF 2 n)

sol n = 4 + sol' n where sol' n = sum $ filter divs [1..10^n]