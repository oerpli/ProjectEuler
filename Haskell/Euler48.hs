module Euler48 where
main = print $ reverse $ take 10 $ reverse $ show $ sum [ n^n | n <- [1..1000]]

-- xx :: (Integer -> Integer -> Integer) -> Integer
xx (_,0,r) = r
xx (b,e,r) = xx (b,e-1,mod (r*b) (10^10))


ser x = xx (x,x,1)

sumser [] = 0
sumser (x:xs) = ser x + sumser xs

series = map ser [1..1000]

-- main = mod (sum series) 10