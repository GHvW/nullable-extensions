using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableExtensions;

public static class NullableOps {

    public static bool IsNull<A>(this A? it) => it == null;

    public static bool IsNotNull<A>(this A? it) => it != null;

    public static A OrElseThrow<A>(this A? it, Exception exception) {
        if (it != null) {
            return it;
        }

        throw exception;
    }
}

public static class NullableRefOps {

    public static B? Select<A, B>(this A? x, Func<A, B> fn)
      where A : class
      where B : class {

        return x switch {
            null => null,
            A it => fn(it)
        };

    }

    public static B? SelectMany<A, B>(this A? x, Func<A, B?> fn)
        where A : class
        where B : class {

        return x switch {
            null => null,
            A it => fn(it)
        };
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : class
        where B : class
        where C : class {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : class
        where B : class
        where C : struct {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }
}

public static class NullableValueOps {

    public static B? Select<A, B>(this A? x, Func<A, B> fn)
        where A : struct
        where B : struct {

        return x switch {
            null => null,
            A it => fn(it)
        };
    }

    public static B? SelectMany<A, B>(this A? x, Func<A, B?> fn)
        where A : struct
        where B : struct {

        return x switch {
            null => null,
            A it => fn(it)
        };
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : struct
        where B : struct
        where C : struct {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : struct
        where B : struct
        where C : class {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }
}

public static class NullableValueToRefOps {

    public static B? Select<A, B>(this A? x, Func<A, B> fn)
        where A : struct
        where B : class {

        return x switch {
            null => null,
            A it => fn(it)
        };
    }

    public static B? SelectMany<A, B>(this A? x, Func<A, B?> fn)
        where A : struct
        where B : class {

        return x switch {
            null => null,
            A it => fn(it)
        };
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : struct
        where B : class
        where C : struct {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : struct
        where B : class
        where C : class {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }
}

public static class NullableRefToValueOps {

    public static B? Select<A, B>(this A? x, Func<A, B> fn)
        where A : class
        where B : struct {

        return x switch {
            null => null,
            A it => fn(it)
        };
    }

    public static B? SelectMany<A, B>(this A? x, Func<A, B?> fn)
        where A : class
        where B : struct {

        return x switch {
            null => null,
            A it => fn(it)
        };
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : class
        where B : struct
        where C : class {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }

    public static C? SelectMany<A, B, C>(this A? x, Func<A, B?> fn, Func<A, B, C?> selector)
        where A : class
        where B : struct
        where C : struct {

        return x.SelectMany(y => fn(y).SelectMany(z => selector(y, z)));
    }
}

