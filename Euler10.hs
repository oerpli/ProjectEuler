module Euler10 where
import Data.List               -- based on http://stackoverflow.com/a/1140100
import qualified Data.Map as M
 
primesMPE :: [Integer]
primesMPE = 2:mkPrimes 3 M.empty prs 9   -- postponed addition of primes into map;
  where                                  -- decoupled primes loop feed 
    prs = 3:mkPrimes 5 M.empty prs 9
    mkPrimes n m ps@ ~(p:t) q = case (M.null m, M.findMin m) of
        (False, (n', skips)) | n == n' ->
             mkPrimes (n+2) (addSkips n (M.deleteMin m) skips) ps q
        _ -> if n<q
             then    n : mkPrimes (n+2)  m                  ps q
             else        mkPrimes (n+2) (addSkip n m (2*p)) t (head t^2)
 
    addSkip n m s = M.alter (Just . maybe [s] (s:)) (n+s) m
    addSkips = foldl' . addSkip





sieb :: [Integer] -> Integer --Primzahlsieb
sieb [] = 0
sieb (l:ls) = l + sieb[x | x <- ls, mod x l /= 0]

sumprimes :: Integer -> Integer-- Primzahlen bis n
sumprimes n = sieb [2..n]


main :: IO ()
main = print $ sumprimes 2000000


primesT = sieve [2..]
  where
    sieve (p:xs) = p : sieve [x | x <- xs, rem x p /= 0]
	
ps = 2 : [i | i <- [3..],  
              and [rem i p > 0 | p <- takeWhile ((<=i).(^2)) ps]]

			  
