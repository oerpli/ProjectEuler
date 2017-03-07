module Euler43 where
import Data.List

tt n = (take 3) . (drop (n-1))
pand = permutations [0..9]

filtered = filter f pand
solve = sum $ map glue filtered

glue [x] = x
glue (x:y:xs) = glue (10*x+y:xs)

(.&&.) f g a = (f a) && (g a)

-- more concise version
primes = [2,3,5,7,11,13,17]
check n x = 0 == mod (glue $ tt (n+1) x) (primes !! (n-1))
checks = map check [2..7]
-- f = foldr (.&&.) (check 1) checks

-- faster version
check2 x = 0 == mod (x !! 3) 2
check3 x = 0 == mod (sum $ tt 3 x) 3 
check4 x = or[(x !! 5)==0,(x !! 5) == 5]
check5 x = 0 == mod (glue $ tt 5 x) 7 
check6 x = 0 == mod (glue $ tt 6 x) 11 
check7 x = 0 == mod (glue $ tt 7 x) 13 
check8 x = 0 == mod (glue $ tt 8 x) 17 

f = foldr (.&&.) check2 [check4,check3,check8,check6,check7,check5] 