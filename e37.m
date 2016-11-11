function [ res ] = e37( input_args )
c = 1;
i = 10;
while c < 12
    i = i+1;
    if isprime(i)
       [f,b] = truncate(i);
       if all(isprime(f)) && all(isprime(b))
           res(c) = i
           sum(res)
           c = c +1
       end
    end
end

end


function [f,b] = truncate(n)
digs = numel(num2str(n))-1;
f(1) = floor(n/10);
b(1) = mod(n,10^(digs));
for i=2:digs
   f(i) = floor(n/10^i); 
   b(i) = mod(n,10^(digs-i+1));
end

end


function [A] = digits(n)
A = sscanf(strrep(num2str(n),'.',''),'%1d')'
end