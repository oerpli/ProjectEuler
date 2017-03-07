module Euler573 where
import LibEuler
import Data.List
import Data.Function 



next :: (Integer,Integer) -> [Integer] -> [(Integer,Integer)]
next (x,y) (p:v:ps) = (x+p,y+p) : next (x+p+v,y+p-v) ps


tops = next (0,0) primes

getA (a,b) (x,y) = ((fromInteger (y-b))/(fromInteger(x-a)))

filterINC _ [] = 0
filterINC k (x:xs)
  | k < 0 = countTops (fst x)
  -- | countTops (fst x) == 1 = 1
  | snd x < k = 1 + filterINC (snd x) xs 
  | otherwise = filterINC k xs




countTops n = filterINC 123123123 a where
  t = take n tops
  l = last t
  a = reverse $ zip [1..] (map (getA l) (init t))
  
  
