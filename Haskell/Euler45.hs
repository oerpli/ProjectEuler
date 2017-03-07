module Euler45 where
import LibEuler

t n = div (n*(n+1)) 2
p n = div (n*(3*n-1)) 2
h n = (n*(2*n-1))

tt = map t [2..]
pp = map p [2..]
hh = map h [2..]

filtr (t:ts) (p:ps) (h:hs)
 | t < h || t < p = filtr ts (p:ps) (h:hs)
 | p < h || p < t = filtr (t:ts) ps (h:hs)
 | h < p || h < t = filtr (t:ts) (p:ps) hs
 | otherwise = (t,p,h) : filtr ts ps hs
 
solve = take 2 $ filtr tt pp hh