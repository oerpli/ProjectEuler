

c n 
  | n == 0 = 1
  | n < 0 = 0
  | n > 0 = c (n-5) + c (n-2) + c (n-1)
  
  
-- count 0 _ = 1
-- count _ [] = 0
-- count x (c:coins) = sum [ count (x - (n * c)) coins | n <- [0..(quot x c)] ]

count = foldr addCoin (1:repeat 0)
	where addCoin c oldlist = newlist
		where newlist = (take c oldlist) ++ zipWith (+) newlist (drop c oldlist)