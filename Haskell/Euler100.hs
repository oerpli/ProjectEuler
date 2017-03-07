module Euler100 where

pre = f 1 1

g n m = compare (2*(n*n-n)) ((n+m)*(n+m-1))


f n m 
  | g n m == GT = f n (m+1) 
  | g n m == LT = f (n+1) m 
  | g n m == EQ = (n+m,n,m)
  
next (_,n,m) = f (n+1) m


list x = x:(list $ next x)

t n = take n $ list pre