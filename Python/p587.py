import numpy as np
N = 55000


def area():  # area of L-section
    return 1 - np.pi / 4


def calcX(n):  # calculates x coordinate of intersection of line and circle
    return np.min(np.roots([1 + 1.0 / (n * n), -2 * (1 + 1.0 / n), 1]))


def calcY(x, n):  # calculates y coordinate for a given x
    return x * 1.0 / n


def inTriangle(x, y):  # determines x,y point is below circle
    return pow(1 - x, 2) + pow(1 - y, 2) > 1


def calcRest(xn, yn, n):  # calculates the difficult part of the area
    xsamples = np.random.ranf(N) * (1 - xn) + xn
    ysamples = np.random.ranf(N) * yn
    it = 0
    for i in range(N):
        it += 1 if inTriangle(xsamples[i], ysamples[i]) else 0
    return (1 - xn) * yn * it * 1.0 / N


def calcT(n):  # calculates area under circle and under diagonal
    xn = calcX(n)
    yn = calcY(xn, n)
    return 0.5 * xn * yn + calcRest(xn, yn, n)


def ratio(n):
    return calcT(n) / area()


n = 1  # from here on binary search
while True:
    r = ratio(n)
    print("n: {}, r: {}".format(n, r))
    if r > 0.001:
        n *= 2
    else:
        L = int(n / 2)
        R = n
        break
while True:
    if L > R:
        N = 550000
        print("Solution is around {}, pick best value".format(L))
        print("Solution: {}, {}".format(L - 1, ratio(L)))
        print("Solution: {}, {}".format(L, ratio(L)))
        print("Solution: {}, {}".format(L + 1, ratio(L)))
        break
    m = int((L + R) / 2)
    r = ratio(m)
    print("n: {}, r: {}".format(m, r))
    if (r > 0.001):
        L = m + 1
    else:
        R = m - 1
