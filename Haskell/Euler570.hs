module Euler570 where
import LibEuler

a n = a' 0 n 
a' _ 1 = 1
a' 0 n = 6*(a' 1 (n-1))
a' 1 n = 3*(a' 1 (n-1)) + 2*(a' 2 (n-1))
a' 2 n = 1*(a' 1 (n-1)) + 2*(a' 2 (n-1)) + (3^(n-2))

b n = ab 0 n

ab _ 1 = 0
ab 0 n = 6*(ab 1 (n-1))
ab 1 n = 3*(ab 1 (n-1)) + 2*(ab 2 (n-1))                + 1*(bb (n-1))
ab 2 n = 1*(ab 1 (n-1)) + 2*(ab 2 (n-1)) + (ab 3 (n-1)) + 2*(bb (n-1))
ab 3 n =                                 3*(ab 3 (n-1)) + 3*(bb (n-1))

fab n =3* (if n > 2 then 7*(fab (n-1)) - 12*(fab(n-2)) else (n-1))

bb n = b' 0 n
b' _ 1 = 1
b' 0 n = 6*(b' 1 (n-1))
b' 1 n = 3*(b' 1 (n-1)) + 2*(b' 2 (n-1))
b' 2 n = 4^(n-1)

g n = gcd (ff n) (b n)


-- aa 0 = 1
-- aa 1 = 6
-- aa n = 7*(aa (n-1)) - 12 * (aa (n-2))

-- more efficient a
ff n = f (2^(n-1)-1)
f n 
  | 0 == n           = 1
  | even n           = f (div n 2)
  | mod n 4 == 1     = 6* (f (div n 4))
  | mod n 4 == 3     = 7* (f (div n 2)) - 12* (f (div n 4))
  
fff n = flist !! (2^(n-1)-1)
flist = [ffl n | n <- [0..]]
ffl n 
  | 0 == n           = 1
  | even n           = flist !! (div n 2)
  | mod n 4 == 1     = 6* (flist !! (div n 4))
  | mod n 4 == 3     = 7* (flist !! (div n 2)) - 12* (flist !! (div n 4))
