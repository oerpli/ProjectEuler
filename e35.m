function [OUT] = circ(n)
if(mod(n,10^5) == 0)
    n/10^5
end
OUT = isprime(n);
if OUT
    digs = numel(num2str(n));
    for i = 1:digs
        if OUT
            n = rot(n,digs);
            OUT = isprime(n);
        end
    end
    OUT = all(OUT);
end
end


function [x] = rot(n,digs)
n = n*10;
x = floor(n/(10^digs));
n = mod(n+x,10^digs);
x = n;
end
