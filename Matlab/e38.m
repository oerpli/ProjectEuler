
function [ res ] = e38( input_args )
nums = perms(1:8);
p = ones(length(nums),1) > 0;
d = 4
for i = 1:length(nums)
    num = [9 nums(i,:)];
    p(i,1) = tonum(num(1:d))*2 == tonum(num(d+1:d+1+d));
end
sel = tonum(nums(p,:)) + 9*10^8;
res = max(sel)
end

function [out] = tonum(A)
out = zeros(size(A,1),1);
for j=1:size(A,1)
    n = 0;
    for i=1:size(A,2)
        n = n*10;
        n = n+A(j,i);
    end
    out(j) =n;
end
end

function [A] = digits(n)
A = sscanf(strrep(num2str(n),'.',''),'%1d')'
end