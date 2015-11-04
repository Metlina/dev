def generator (f, pocetna):
    v = pocetna

    def g():
        nonlocal v
        v = f(v)
        return v

    return g

gen = generator(lambda s: s[:1] + str(int(s[1:]) + 1), "v0")
