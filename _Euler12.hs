module Euler12 where
import Data.List               -- based on http://stackoverflow.com/a/1140100
import qualified Data.Map as M

divisors number = divisors' number isquare 1 0 - (fromEnum $ square == fromIntegral isquare)
    where square = sqrt $ fromIntegral number
          isquare = floor square

divisors' :: Int -> Int -> Int -> Int -> Int
divisors' number sqrt candidate0 count0 = go candidate0 count0
  where
  go candidate count
    | candidate > sqrt = count
    | number `rem` candidate == 0 = go (candidate + 1) (count + 2)
    | otherwise = go (candidate + 1) count

divis = map divisors $ map sum [[1..x]|x<-[1,2..]]
divr y z = map divisors $ map sum [[1..x]|x<-[y..z]]
divs x y = divr x y 