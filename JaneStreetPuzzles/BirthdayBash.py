import numpy as np
n = 365
print("Input {}".format(n))

A = np.zeros((n + 1, n + 1))

for i in range(n + 1):
    A[i, i] = (i) / n
    if i < n:
        A[i + 1, i] = 1 - i / n
x = np.zeros((n + 1, 1))

x[0] = 1

print("A: {}".format(A))
print("x: {}".format(x))

count = 0
while x[- 1, 0] < 0.5:
    x = A.dot(x)
    count += 1
    print("{}: {}".format(count, (x[22, 0])))
    print("{}: {}".format(count, (x[23, 0])))
    if count == 25:
        print("Marvel at the original birthday paradox")
    print("{}: {}".format(count, (x[- 1, 0])))
