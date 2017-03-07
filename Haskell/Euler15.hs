module Euler15 where
fac 0 = 1
fac x = x*(fac (x-1))

grid x y = fac (x+y)/fac(x)/fac(y)