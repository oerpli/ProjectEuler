module Euler58 where
import LibEuler
import Data.List

t [] _ _ = []
t x 0 n = t x 4 (n+2)
t x a n = head (drop n x) : t (drop n x) (a-1) n

tt x 0 n = tt x 4 (n+2)
tt x a n = (x+n) : tt (x+n) (a-1) n

diag n = takeWhile (<=n^2) $ 1 : tt 1 0 0

nextF n = take 4 $ tt (n^2) 0 (n-1)

dynStep n m (p,f) = ratio : dynStep (n+2) m  (np, nf)
  where
    x = nextF n
    np = p + cp x
    nf = f + 4
    ratio = (fromIntegral np) / (fromIntegral nf)

cp x = length $ filter prime x

primeRatio x = (fromIntegral $ length (filter prime (diag x))) / (fromIntegral $ x*2-1)


dyn = dynStep 1 100 (0,1) -- calculates prime ratios of diags from squares with l=3,5,...

calc = 1 + 2 * (length $ 0 : takeWhile (>= 0.1) dyn) -- [a,b,c ...] to [3,5,7 ...]

