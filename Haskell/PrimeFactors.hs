module LibEuler where 
import Data.List
import qualified Data.Map as M

---------------------------------------------------------------------------
-- Primes
prime n = n > 1 && foldr (\p r -> p*p > n || ((n `rem` p) /= 0 && r)) True primes
primes :: [Integer]
primes = 2:mkPrimes 3 M.empty prs 9   -- postponed addition of primes into map;
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
-- primes = 2 : [i | i <- [3..],   --20% slower
	-- and [rem i p > 0 | p <- takeWhile ((<=i).(^2)) primes]]
----------------------------------------------------------------------------
-- factors :: Integer -> [Integer]
-- factors n = factP n [2..]

factors :: Integer -> [Integer]
factors n
	| n < 1 = error "argument not positive"
	| n == 1 = []
	| otherwise = p : factors (div n p) where p = ld n

factP :: Integer -> [Integer] -> [Integer]
factP n (p:ps)
 | p*p <= n = if mod n p == 0 then [p] ++ factP (div n p) (p:ps) else factP n ps
 |otherwise = [n]
 
 