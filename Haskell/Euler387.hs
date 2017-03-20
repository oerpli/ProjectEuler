module Euler387 where
import LibEuler
import Data.List


sumd2 0 acc = acc
sumd2 x acc = sumd2 (x `div` 10) (acc + (x `mod` 10))
dsum  = (flip sumd2) 0

trunc n = div n 10
trunc2 n = div n 100

digs 0 = []
digs x = digs (x `div` 10) ++ [x `mod` 10]

td n = 10* head (digs n) + (digs n !! 1)

harshad n = mod n (dsum n) == 0

th 0 = True
th n = harshad n && th (trunc n)

sh n = harshad n && prime (div n (dsum n))

shp n = th (trunc2 n) && sh (trunc n) --  && prime n

ht n = elem (td n) h100

h100 = filter harshad [1..100]

p = takeWhile (< 10^7) $ dropWhile (<10^1) primes

calc = filter shp p

scalc =90619 +  sum calc