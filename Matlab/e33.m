function [OUT] = e33( n,d)
o = n/ d;

n1 = mod(n,10);
n2 = floor(n/10);

d1 = mod(d,10);
d2 = floor(d/10);


t = [n1 == d1,n1 == d2, n2 == d1,n2 == d2];

f(1) = n2 / d2;
f(2) = n2 / d1;
f(3) = n1 / d2;
f(4) = n1 / d1;




triv = n1 == 0 && d1 == 0;
triv = 1 - triv;
OUT = all([o  < 1, triv,n ~= d,f(t) == o, any(t)]);

if OUT
    o
end
end

