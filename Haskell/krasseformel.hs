
s [] x = x
s x [] = x
s (x:xs) (y:ys) = (x+y):(s xs ys)


-- x = replicate 200 40.0
f n = replicate 90 n

increment 0 x y = (x+y): (increment 90 (x+y) (y + 0.2))
increment n x y = (x+y): (increment (n-1) (x+y) y)


x = s base inc where
  base = [40,40..]
  inc = increment 90 0.0 0.4

  


