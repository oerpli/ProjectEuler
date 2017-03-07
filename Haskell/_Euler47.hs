module Euler243 where
import LibEuler
import Data.List
import Data.List (nub)

result = head [n | n <- [1..], all ((== 4) . length . nub . pfactors) [n .. n + 3]]

main = print result
-- bruteforce approach

pfour :: Integer -> Integer ->[[Integer]] -> [[Integer]] 
pfour n c x = (tail x) ++ [dfactors (n+c)]

dfactors :: Integer -> [Integer]
dfactors = nub . pfactors

check :: Integer -> [[Integer]] -> Bool
check c x = (map (toInteger . length) x) == [c|i<-[1..c]]

xx :: Integer -> Integer -> [[Integer]]
xx n c = [dfactors x | x <- [n..n+(c-1)]]

get :: Integer -> Integer
get c = getf 0 (xx 0 c) c

getf n x c= if check c x then n else getf (n+1) (pfour n c x) c

cf = 1 : [x|i<-[2..],x<-[sum[1|p<-takeWhile (<=i) primes, rem i p == 0]]]

findNN :: Integer -> Integer -> [Integer] -> Integer
findNN f n (x:xs)
 | f == n = 1-n
 | x == n = 1 + findNN (f+1) n xs
 | otherwise = 1 + findNN 0 n xs