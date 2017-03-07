from itertools import groupby
import collections


class Card():
    values = {'2': 2,
              '3': 3,
              '4': 4,
              '5': 5,
              '6': 6,
              '7': 7,
              '8': 8,
              '9': 9,
              'T': 10,
              'J': 11,
              'Q': 12,
              'K': 13,
              'A': 14}

    def __init__(self, value, suit):
        self.suit = suit
        self.valueO = value
        self.value = Card.values[value]

    def __str__(self):
        return "{}{}".format(self.suit, self.value)


class Hand():
    def __init__(self, cards):
        if(len(cards) != 5):
            print("Only {} cards dealt".format(len(cards)))
        else:
            self.cards = cards

        # find out value of hand
        self.flush = self.Flush()
        self.straight = self.Straight()
        self.Kinds()

    def RoyalFlush(s):
        return s.flush and s.straight and s.HighCard(False) == 14

    def StraightFlush(s, val=False):
        if val:
            return s.HighCard()
        return s.flush and s.straight > 0

    def Poker(s, val=False):
        if val:
            return s.poker[0]
        return len(s.poker) > 0

    def FullHouse(s, val=False):
        if val:
            return s.threes[0] * 15 + s.twos
        return s.Three() and s.OnePair()

    def Flush(self, val=False):
        if val:
            return self.HighCard()
        suits = [x.suit for x in self.cards]
        return suits[1:] == suits[: -1]

    def Straight(self, val=False):
        vals = [x.value for x in self.cards]
        vals.sort()
        if val:
            return vals[-1]
        return vals == list(range(min(vals), max(vals) + 1))

    def Three(s, val=False):
        if val:
            return s.threes[0]
        return len(s.threes) == 1

    def TwoPair(s, val=False):
        if val:
            return s.twos[0] * 15 + s.twos[1]
        return len(s.twos) == 2

    def OnePair(s, val=False):
        if val:
            return s.twos[0]
        return len(s.twos) == 1

    def HighCard(s, val=True):
        vals = [x.value for x in s.cards]
        if val:
            vals.sort()
            return (vals[0] + vals[1] * 15 + vals[2] * 225 + vals[3] * 225 * 15 + vals[4] * 225 * 255)
        else:
            return max(vals)

    def Kinds(self):
        vals = [x.value for x in self.cards]
        c = collections.Counter(vals)
        z = [x for x in c.most_common() if x[1] > 1]
        self.poker = [x[0] for x in z if x[1] == 4]
        self.threes = [x[0] for x in z if x[1] == 3]
        self.twos = [x[0] for x in z if x[1] == 2]
        self.twos.sort(reverse=True)

    def BestCombination(s):
        lst = [s.RoyalFlush, s.StraightFlush, s.Poker, s.FullHouse,
               s.Flush, s.Straight, s.Three, s.TwoPair, s.OnePair]
        i = 0
        for x in lst:
            if x():
                break
            else:
                i = i + 1
        return i

    def High(s, v):
        lst = [s.RoyalFlush, s.StraightFlush, s.Poker, s.FullHouse,
               s.Flush, s.Straight, s.Three, s.TwoPair, s.OnePair, s.HighCard]
        return lst[v](True)

    def Versus(self, other):
        s = self.BestCombination()
        o = other.BestCombination()
        if s < o:
            return 1
        else:
            if s == o:
                # if they have the same combination the better highcard wins
                s = self.High(s)
                o = other.High(o)
                if s > o:
                    return 1
        return 0

    def __str__(self):
        return "{}".format([str(x) for x in self.cards])


def ReadFile(path):
    file = open("./data/p054_poker.txt", "r")
    p1counter = 0
    for line in file:
        p = []
        h = []
        for word in line.split(" "):
            h.append(Card(word[0], word[1]))
            if(len(h) == 5):
                p.append(Hand(h))
                h = []
        p1counter = p1counter + p[0].Versus(p[1])
    print("Player 1 wins: {}".format(p1counter))


ReadFile('')

print("fin")
