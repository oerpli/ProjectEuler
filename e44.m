function [ out ] = e44()
n = 5000;
x = 1:n';
pans = x.*(3*x-1)/2;
c = 1;
out = []; 
for i=1:n
    p = pans(i);
    sum = p+pans;
    diff = pans-p;
    x = ispan(sum') .* ispan(diff');
    sel = pans(x>0);
    for sols = 1:length(sel)
        out(c) = abs(p-sel(sols));
        c = c+1;
    end
%out = abs(out(:,1) -out(:,2));
out = min(out);
end

end

function [out] = ispan(y)
y = y*2;
out = zeros(size(y)) > 0;
for i=1:size(y,1)
    for j=1:size(y,2)
        x = 1/6*(sqrt(12*y(i,j)+1)+1);
        out(i,j) = x == round(x);
    end
end
end