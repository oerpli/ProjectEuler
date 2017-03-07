module Euler55 where
main :: IO ()
main = print (lyc 10000)

pal :: Integer -> Bool
pal a = a = rev a

rev :: Integer -> Integer
rev = read . reverse . show

next :: Integer -> Integer
next x = x + (rev x)

lychrel :: Integer -> Integer -> Bool
lychrel x 1 = not (pal x)
lychrel x c
 | pal x = False
 | otherwise = lychrel (next x) (c-1)

ggg x = lychrel x 20
 
gg :: Integer -> Integer
gg x 
 | pal x = 0
 | otherwise = 1 + gg (next x)
 
lyc :: Integer -> Integer
lyc 1 = 0
lyc x = (if ggg x then 1 else 0 ) + lyc (x-1)


