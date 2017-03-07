module Euler573 where
import LibEuler
import Data.List
import Data.Function 

-- exptected size of kth largest number
ex n k = (n-k+1) / (n+1)

-- avgs
avg n = map (ex n) [1..n]

time n = zipWith (*) (avg n) ([1..n])