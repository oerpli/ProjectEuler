module LibEuler where 
import Data.List
import qualified Data.Map as M

---------------------------------------------------------------------------
-- Fibonacci
data PhiNum a = PhiNum { numPart :: a, phiPart :: a } deriving (Eq, Show)
instance Num a => Num (PhiNum a) where
    fromInteger n = PhiNum (fromInteger n) 0
    PhiNum a b + PhiNum c d = PhiNum (a+c) (b+d)
    PhiNum a b * PhiNum c d = PhiNum (a*c+b*d) (a*d+b*c+b*d)
    negate (PhiNum a b) = PhiNum (-a) (-b)
    abs = undefined
    signum = undefined
 
fib n = phiPart $ PhiNum 0 1 ^ n

fibS a b = a: fibS b (a+b)
fibs :: [Integer]
fibs = fibS 0 1

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
-- Allgemeines Zeug
kgt :: [Integer] -> Integer -- gcd of a list
kgt [] = 1
kgt [x] = x
kgt [x,y] = gcd x y
kgt (x:y:r) = gcd x (kgt (y:r))






