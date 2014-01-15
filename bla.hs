data Bla = Zero | S Bla deriving (Show)
zahl :: Bla -> Integer
zahl Zero=0
zahl (S m)= 1 + zahl m


add :: Bla -> Bla -> Bla
add a Zero = a
add Zero b = b
add (S a) b = S (add a b)

bla :: Integer -> Bla
bla 0 = Zero
bla n = if n < 0 then error "n > 0!!!" else S (bla (n-1))


mult :: Bla -> Bla -> Bla
mult _ Zero = Zero
mult Zero _ = Zero
mult (S a) b = add b (mult a b)


fac :: Bla -> Bla
fac Zero = S Zero
fac (S a) = mult (S a) (fac a)