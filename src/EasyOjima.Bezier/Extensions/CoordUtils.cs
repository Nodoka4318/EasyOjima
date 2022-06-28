using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EasyOjima.Bezier.Extensions {
    internal static class CoordUtils {
        // 定数
        const double SIZE = 284d;

        internal static int ToRateX(this int actualCoord) {
            return (int)(((double)actualCoord) / SIZE * 100d);
        }

        internal static int ToRateY(this int actualCoord) {
            return (int)((SIZE - (double)actualCoord) / SIZE * 100d);
        }

        internal static int ToSizeX(this int rate) {
            return (int)(SIZE * (double)rate / 100d);
        }

        internal static int ToSizeY(this int rate) {
            return (int)(SIZE - (SIZE * (double)rate / 100d));
        }

        internal static bool IsOnDot(this Point cursor, int dotcX, int dotcY) {
            var rad = Editor.DOT_RADIUS;
            return (cursor.X <= dotcX + rad && dotcX <= cursor.X + rad && cursor.Y <= dotcY + rad && dotcY <= cursor.Y + rad);
        }
    }
}
