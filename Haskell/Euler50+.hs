module Euler50 where
import LibEuler

-- inefficient, could be a implemented by a factor s faster 
consec s [] = []
consec s (x:xs) =  filter prime $  sum (x: take (s-1) xs) : consec s xs

solve n = best_both
  where
    best_even = solveF n  -- first run this as it could be more efficient
    best_both = solve' (1+ fst best_even) n best_even -- then look if there are longer odd chain sums, else return previous result
    
-- solve odd cases
solve' s n p = if (sum $ take s primes) > n then p -- if the chain of s starting from the first is bigger than the cutoff there is no valid sol for higher s
    else solve' (s+2) n (if x > n then p else (s,x)) -- if new solution is valid use this, else stay with previous
    where x = head $ consec s primes 


every n xs = case drop (n-1) xs of
              (y:ys) -> y : every n ys
              [] -> []

-- now using the linear version
solveF n = last $ filter (prime . snd) $ zip [2,4..] $ takeWhile (<=n) $ every 2 $ progsum primes

-- solve even cases (something s^2 instead of the possible O(s) algorithm)
s n = solve'' 2 n (0,0)
solve'' s n p = if (sum $ take s primes) > n then p -- if it's bigger than cutof output prevous
    else solve'' (s+2) n (if prime x then (s,x) else p) -- if it's a prime use the new sum, else the old one
    where x = sum $ take s primes