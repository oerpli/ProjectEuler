module Euler92 where
import Data.List
digits :: Integer -> [Integer]
digits 0 = []
digits x = (mod x 10) : digits (div x 10)


