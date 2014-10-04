module Euler14 where
import Data.List               -- based on http://stackoverflow.com/a/1140100

collatzN :: Int -> Int
collatzN n = if rem n 2 == 0 then div n 2 else 3*n+1
