function [ output_args ] = e36( m)
c = 1;
for i=1:10^m
    dec = de2bi(i,[],10);
    if(dec(1) == dec(end))
        if ispalindrome(dec)
            bin = de2bi(i,[],2);
            if ispalindrome(bin)
                output_args(c) = i;
                i
                c = c +1;
            end
        end
    end
end
end


function [x] = ispalindrome(n)
f = length(n);
fl = floor((f+1)/2);
fc = ceil((f+1)/2);
ind = 1:fl;
indr = f:-1:fc;
x = all(n(ind) == n(indr));
end


function [A] = digits(n)
A = de2bi(n,[],10);
end