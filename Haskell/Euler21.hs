module Euler21 where

sdivi :: Integer -> Integer
sdivi x = sum [y|y<-[1..(div x 2)],mod x y == 0]

amic :: Integer -> Bool
amic a = sdivi (x) == a && x /= a where x = sdivi a

sumamic :: Integer -> Integer
sumamic y = sum [x|x<-[1..y], amic x]

main :: IO ()
main = print (sumamic 10000)