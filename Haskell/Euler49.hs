module Euler40 where
import LibEuler
import Data.List
import Data.Function 


prim = filter (>1000) $ takeWhile (<10000) primes

-- prim =  [13,31,1487, 4817, 8147]

buckets = zip (map (sort . show) prim) prim


mySort = sortBy (compare `on` fst)

sorted [x] = True
sorted (x:y:ys) = x <= y && sorted (y:ys)

-- part :: [(a,b)] -> [(a,[b])]
part [] = []
part [(a,b)] = [(a,[b])]
part ((a,b):xs) = (a,b: map snd eq) : part neq where
   eq  = takeWhile (\x ->a==fst x) xs
   neq = dropWhile (\x ->a==fst x) xs
   


ft x = filter f3 (map snd x)
f3 x = 3<= length x

p x = mapM_ print x

bs = map sort $  ft . part $ mySort buckets


f x = or [length x > 3,1 == length (nub $ zipWith (-) x (drop 1 x))]

ff = filter f bs


subsets []  = [[]]
subsets (x:xs) = subsets xs ++ map (x:) (subsets xs)

f3x x = 3== length x
m = take 5 ff
fff =  filter f3x $ concat $ map subsets ff

solve = map concat $ map (map show) $ filter (\x -> 1 == length (nub $ zipWith (-) x (drop 1 x))) fff
