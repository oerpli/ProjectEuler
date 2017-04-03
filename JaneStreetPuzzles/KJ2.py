import numpy as np
n = 10
print("Input {}".format(n))


def init():
    A = np.zeros((n, n), dtype=int)
    A[0, 0] = 1
    A[2, 1] = 4
    A[3, 5] = 7
    A[4, 9] = 10
    A[1, 9] = 13
    A[4, 5] = 16
    A[7, 3] = 19
    A[9, 2] = 22
    A[8, 2] = 25
    A[5, 4] = 28
    A[5, 9] = 31
    A[5, 8] = 34
    A[8, 8] = 37
    A[2, 9] = 40
    A[0, 6] = 43
    A[3, 2] = 46
    A[6, 0] = 49
    return A


def fixed():
    return [4,  7, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 43, 46, 49]


def Regions(i):
    if i == 0:
        return [(0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (1, 0), (2, 0), (3, 0)]
    if i == 1:
        return [(1, 1), (1, 2), (2, 1), (3, 1), (4, 1), (3, 2), (4, 2), (4, 3), (4, 4), (4, 5), (5, 3)]
    if i == 2:
        return [(4, 0), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0), (5, 1)]
    if i == 3:
        return [(5, 2), (6, 2), (6, 1), (7, 1), (8, 1), (8, 2)]
    if i == 4:
        return [(9, 1), (9, 2), (9, 3), (9, 4), (8, 3), (7, 3), (7, 2), (6, 3)]
    if i == 5:
        return [(2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7), (4, 6)]
    if i == 6:
        return [(0, 4), (0, 5), (0, 6), (0, 7), (0, 8), (0, 9), (1, 8), (1, 7), (1, 6), (1, 5), (1, 4)]
    if i == 7:
        return [(1, 9), (2, 9), (3, 9), (2, 8), (2, 7)]
    if i == 8:
        return [(3, 8), (4, 8), (5, 8), (4, 9), (5, 9)]
    if i == 9:
        return [(5, 5), (5, 6), (5, 7), (4, 7), (6, 7), (7, 7), (6, 8), (6, 9)]
    if i == 10:
        return [(7, 5), (8, 5), (9, 5), (8, 4), (9, 6)]
    if i == 11:
        return [(6, 4), (5, 4), (9, 7), (6, 6), (7, 6), (9, 8), (9, 9), (8, 9), (7, 4), (8, 8), (8, 7), (8, 6), (7, 8), (6, 5), (7, 9)]


def Reg():
    r = []
    for i in range(12):
        r.append(Regions(i))
    return r


def initMap():
    m = np.zeros((n, n))
    for i, e in enumerate(Reg()):
        for (x, y) in e:
            m[x, y] = i
    return m


def cReg():
    c = Reg()
    return sum(c, [])


def sumRow(A):
    sr = []
    for i, e in enumerate(A):
        sr.append(0)
        for x in e:
            if x > 0:
                sr[-1] += 1
    return sr


def sumCol(A):
    return sumRow(A.transpose())


def sumReg(A):
    r = Reg()
    sr = []
    for reg in r:
        sr.append(0)
        for (a, b) in reg:
            if A[a, b] > 0:
                sr[-1] += 1
    return sr


def check(A):
    chkFun = [sumReg, sumCol, sumRow]
    sums = [f(A) for f in chkFun]
    return all([min(x) == max(x) for x in sums])


def steps(A, x, y):
    global M
    ps = [(1, 2), (-1, 2), (1, -2), (-1, -2),
          (2, 1), (-2, 1), (2, -1), (-2, -1)]
    v = A[x, y] + 1
    f = v in fixed()
    if f:
        for (a, b) in ps:
            a += x
            b += y
            if a >= 0 and b >= 0 and a < n and b < n:
                if A[a, b] == v:
                    yield (a, b)
                    return
    else:
        for (a, b) in ps:
            a += x
            b += y
            if a >= 0 and b >= 0 and a < n and b < n:
                if A[a, b] == 0 and M[a, b] != M[x, y]:
                    yield (a, b)


def markFin(A):
    for i, e in enumerate(sumReg(A)):
        if e >= 5:
            for (a, b) in Regions(i):
                if A[a, b] == 0:
                    A[a, b] = -1
    for b, e in enumerate(sumCol(A)):
        if e >= 6:
            for a in range(n):
                if A[a, b] == 0:
                    A[a, b] = -1
    for a, e in enumerate(sumRow(A)):
        if e >= 6:
            for b in range(n):
                if A[a, b] == 0:
                    A[a, b] = -1
    return A


def explore(Ain=init(), x=0, y=0):
    v = Ain[x, y]
    if v == 60:
        if check(Ain):
            return (v, Ain)
        else:
            return (0, 0)
    ret = (0, Ain)
    for (a, b) in steps(Ain, x, y):
        A = Ain.copy()
        A[a, b] = v + 1
        (r, B) = explore(markFin(A), a, b)
        if (r == 60):
            return (r, B)
        if(r > ret[0]):
            ret = (r, B)
    return ret


M = 0


def Solve():
    global M
    A = init()
    M = initMap()
    (r, b) = explore()
    b[b == -1] = 0
    return b


if __name__ == "__main__":
    Solve()
