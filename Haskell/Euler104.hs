module Euler104 where
import LibFib
import Data.List

lpan :: Integer -> Bool
lpan x = sort (show (mod x (10^9))) == "123456789"

fpan :: Integer -> Bool
fpan x = sort (take 9 (show x)) == "123456789"

bpan x = lpan x && fpan x

flpan ::Integer ->  Integer
flpan x
 | lpan (fib x) = if fpan (fib x) then x else flpan (x+1)
 |otherwise = flpan (x+1)
 

main :: IO ()
main = print (xx 1 1)


xx :: Integer -> Integer -> Integer
xx a b
 | bpan a = 1
 | bpan b = 2
 | otherwise = 2 + xx (a+b) (a+b+b)
  
