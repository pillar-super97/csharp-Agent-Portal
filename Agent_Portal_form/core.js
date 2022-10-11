function $S(a, b) {
    return NS(a.l & b.l, a.m & b.m, a.h & b.h)
}
function If(a) {
    return a.b
}
function uT(a) {
    var b, c, d, e, f;
    d = wT($S(a, qnd));
    c = wT(rT(a, 32));
    e = new Xad;
    b = _S(e, ~~c >> 28 & 15, false);
    b = _S(e, ~~c >> 22 & 63, b);
    b = _S(e, ~~c >> 16 & 63, b);
    b = _S(e, ~~c >> 10 & 63, b);
    b = _S(e, ~~c >> 4 & 63, b);
    f = (c & 15) << 2 | ~~d >> 30 & 3;
    b = _S(e, f, b);
    b = _S(e, ~~d >> 24 & 63, b);
    b = _S(e, ~~d >> 18 & 63, b);
    b = _S(e, ~~d >> 12 & 63, b);
    _S(e, ~~d >> 6 & 63, b);
    _S(e, d & 63, true);
    return If(e.b, e)
}

function $S(a, b) {
    return NS(a.l & b.l, a.m & b.m, a.h & b.h)
}
function d$(a, b) {
    i$(a.b, b)
}
function i$(a, b) {
    c$();
    Ff(a.b, b);
    a.b.b += gzd
}

function Ff(a, b) {
    a.b += b
}
function __(a, b, c, d) {
    X_(a, d);
    e0(a.b, b, c, d)
}
function e0(d, a, b, c) {
    d[c][2](a, b)
}
function $Y(a, b) {
    d$(a, uT(b.Ik()))
}
_.Ik = function jr() {
    return dT(this.q.getTime())
}
function dT(a) {
    var b, c, d, e, f;
    if (isNaN(a)) {
        return DT(),
        CT
    }
    if (a < -9223372036854775808) {
        return DT(),
        AT
    }
    if (a >= 9223372036854775807) {
        return DT(),
        zT
    }
    e = false;
    if (a < 0) {
        e = true;
        a = -a
    }
    d = 0;
    if (a >= 17592186044416) {
        d = os(a / 17592186044416);
        a -= d * 17592186044416
    }
    c = 0;
    if (a >= 4194304) {
        c = os(a / 4194304);
        a -= c * 4194304
    }
    b = os(a);
    f = NS(b, c, d);
    e && TS(f);
    return f
}

function os(a) {
    return ~~Math.max(Math.min(a, 2147483647), -2147483648)
}

function NS(a, b, c) {
    return _ = new FT,
    _.l = a,
    _.m = b,
    _.h = c,
    _
}

function wT(a) {
    return a.l | a.m << 22
}

function rT(a, b) {
    var c, d, e, f, g;
    b &= 63;
    c = a.h;
    d = (c & 524288) != 0;
    d && (c |= -1048576);
    if (b < 22) {
        g = ~~c >> b;
        f = ~~a.m >> b | c << 22 - b;
        e = ~~a.l >> b | a.m << 22 - b
    } else if (b < 44) {
        g = d ? 1048575 : 0;
        f = ~~c >> b - 22;
        e = ~~a.m >> b - 22 | c << 44 - b
    } else {
        g = d ? 1048575 : 0;
        f = d ? 4194303 : 0;
        e = ~~c >> b - 44
    }
    return NS(e & 4194303, f & 4194303, g & 1048575)
}

function _S(a, b, c) {
    var d;
    b > 0 && (c = true);
    if (c) {
        b < 26 ? (d = 65 + b) : b < 52 ? (d = 97 + b - 26) : b < 62 ? (d = 48 + b - 52) : b == 62 ? (d = 36) : (d = 95);
        Oad(a, d & 65535)
    }
    return c
}