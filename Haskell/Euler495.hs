module Euler495 where
import Data.Maybe 

m :: [Int] -> [Int] -> Maybe [Int]
m [] [] = Just []
m (x:xs) (y:ys) = comb (if y > x then Nothing else Just (x-y)) (m xs ys)

comb :: Maybe Int -> Maybe [Int] -> Maybe [Int]
comb (Just x) (Just y) = Just (x:y)
comb Nothing _ = Nothing
comb _ Nothing = Nothing


next :: [Int] -> [Int] -> Int -> [Int]
next [m] [l] n = [l+n]
next m (l:ls) n =  cut m ((l+n):ls)

cut :: [Int] -> [Int] -> [Int]
cut (m:ms) (l:ls) = if l > m then cut (m:ms) ((l-m-1):(next ms ls 1)) else (l:ls)  --(mod l m):(next ms ls (div l m)) else (l:ls)

msum :: [Maybe Int] -> Int
msum (Nothing:xs) = msum xs
msum (Just x:xs) = x + msum xs

xprod :: [Int] -> Int
xprod [n] = n+1
xprod (x:xs) = (x+1) * xprod xs

-- partition x n l 
partition :: Int -> (Maybe [Int],[Int]) -> [Maybe Int]
partition _ (Nothing,_) = Nothing :[]
partition 1 (Just x,_) = Just 1 :[]
partition 0 _ = Nothing :[]
partition n (Just x,l) = concat $ map (partition (n-1)) [(m x (new),new) | new<- map (next x l) [0..xprod x -1]]



x :: [Int]
x = [2,2]
l :: [Int]
l = [0,0]
n :: Int
n = 2

 -- map (next [2,2] [0,0]) [0..xprod [2,2]]
