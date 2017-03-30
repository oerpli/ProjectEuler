import numpy as np
import itertools as it
R = 5
D = 2

# the idea is to partition the hyperball into quadratic parts and
# enumerate the rest.

# for D = 2 the biggest cube fitting inside has diagonal that fits in hyperball
c1 = np.floor(2 * R / np.sqrt(D))

n1 = pow(c1 + 1, D)
