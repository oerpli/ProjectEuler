module Euler97 where

main :: IO ()
main = print (mod (28433*2^(7830457)+1) (10^10))