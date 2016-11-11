% tic; x = e85(0,40,500); toc; x
function [out] = e85()
out = zeros(53,2002); % never more than 53x53 needed 
minr = 100000000;
for i=1:size(out,1)
    for j=1:size(out,2)
        if (i < j)
            out(i,j) = abs(rect(i,j)-2000000);
            if out(i,j) < minr
                minr = out(i,j);
                MI = i;
                MJ = j;
            end
        end
    end
end
out = [MI*MJ,MI,MJ,minr, rect(MI,MJ)];
end

function [ out ] = rect(n,m)
out = n*(n+1)*m*(m+1)/4;
end