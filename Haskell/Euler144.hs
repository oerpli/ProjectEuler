module Euler144 where
import Data.List

s = (0.0,10.1)
sv = opV (-) (1.4,-9.6) s

out (x,y) = 4*x*x  + y*y - 100
slope (x,y) = -4*x / y

opV f (a,b) (x,y) = (f a x,f b y)

binary s v crit
  | crit t > 0 = binary s (opV (*) v (0.5,0.5)) crit
  | crit t < -0.01 = opV (+) t (binary t v crit)
  | otherwise = t
   where t = opV (+) s v


isect (a,b) (e,f) = binary (a,b) (e,f) out


scp (a,b) (x,y) = a*x+b*y*y
nrm (a,b) = sqrt (a^2 + b^2)
scale a (x,y) = (a*x,a*y)

mirror :: (Floating a, Eq a) => (a,a) -> (a,a) -> ((a,a)->a) -> (a,a)
mirror p v f= v' where
  line = if snd p == 0 then (0,1) else (1, f p)
  pr = scale ((scp v line)/(nrm line)^2) line
  v' = opV (-) (scale 2 pr) v
  

  
points s v = t : (points t v') where
  t = isect s v
  v' = mirror t v slope