module Euler40 where
import Data.Maybe 
import LibEuler
import Data.Char

digs n = map  (x !!) (map (10^) [0..n])

d n = map digitToInt (digs n)

solve n = product (d n)

x ='x' : ( take (10^7) $ concat $ map show [1..])