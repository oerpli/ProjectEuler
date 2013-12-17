module Euler41 where
import Data.List               -- based on http://stackoverflow.com/a/1140100
import qualified Data.Map as M

-- max: 7 digits primes
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)


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



-- main :: IO ()
-- main = print $ sumprimes 2000000

ps = 2 : [i | i <- [3..],  
              and [rem i p > 0 | p <- takeWhile ((<=i).(^2)) ps]]
			  
pandig x = length (nub (digits x))