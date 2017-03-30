module Euler596 where
import LibEuler
import Data.List
import Data.Function 

sortT (a1, b1) (a2, b2)
  | a1 < a2 = LT
  | a1 > a2 = GT
  | a1 == a2 = EQ

gen r = [-n..n] where n = fromIntegral . floor . sqrt $ r
gen0 r = filter (\x -> x*x*4 > r) $ gen r

getp 1 r = trim [(r - x*x,4)| x <- gen0 r]
getp d r = trim [(y - x*x,z) |(y,z) <- getp (d-1) r,x <- gen y]

c r = sum . map snd $ getp 4 (r*r)

cmpfst x y = fst x == fst y

sumup x = (fst. head $ x, sum . map snd $ x)



gp [a] = [a]
gp (x:y:ys)
   | fst x == fst y = gp $ (fst x,snd x+ snd y):ys
   | otherwise = x : (gp $ (y:ys))

trim x = map sumup $ groupBy cmpfst $ sortBy sortT $ x

tr x = gp $ sortBy sortT $ x
