define(["require", "exports"], function(require, exports) {
    function area(pts) {
        var p1, p2;
        switch (pts.length) {
            case 0:
            case 1:
                return 0;

            case 2:
                p1 = pts[0];
                p2 = pts[1];
                var x = p2.x - p1.x, y = p2.y - p1.y;

                return Math.sqrt((x * x) + (y * y));

            default:
                var area = 0, nPts = pts.length, i, j = nPts - 1;

                for (i = 0; i < nPts; j = i++) {
                    p1 = pts[i];
                    p2 = pts[j];
                    area += p1.x * p2.y;
                    area -= p1.y * p2.x;
                }

                area /= 2;

                return area;
        }
    }
    exports.area = area;

    function center(pts, _area) {
        var p1, p2;
        switch (pts.length) {
            case 0:
                return null;

            case 1:
                p1 = pts[0];
                return { x: p1.x, y: p1.y };

            case 2:
                p1 = pts[0];
                p2 = pts[1];

                return {
                    x: (p1.x + p2.x) / 2,
                    y: (p1.y + p2.y) / 2
                };

            default:
                var nPts = pts.length, x = 0, y = 0, f, i, j = nPts - 1;

                for (i = 0; i < nPts; j = i++) {
                    p1 = pts[i];
                    p2 = pts[j];
                    f = p1.x * p2.y - p2.x * p1.y;
                    x += (p1.x + p2.x) * f;
                    y += (p1.y + p2.y) * f;
                }

                f = (_area || exports.area(pts)) * 6;

                return { x: x / f, y: y / f };
        }
    }
    exports.center = center;

    function centerArea(pts) {
        var p1, p2;
        switch (pts.length) {
            case 0:
                return null;

            case 1:
                p1 = pts[0];
                return { x: p1.x, y: p1.y, a: 0 };

            case 2:
                p1 = pts[0];
                p2 = pts[1];
                var x = p2.x - p1.x, y = p2.y - p1.y;

                return {
                    x: (p1.x + p2.x) / 2,
                    y: (p1.y + p2.y) / 2,
                    a: Math.sqrt((x * x) + (y * y))
                };

            default:
                var area = 0, nPts = pts.length, x = 0, y = 0, i, f, j = nPts - 1, sortedPts = pts.sort(function (a, b) {
                    return (a.y + a.x) - (b.y + b.x);
                });

                for (i = 0; i < nPts; j = i++) {
                    p1 = sortedPts[i];
                    p2 = sortedPts[j];
                    f = p1.x * p2.y - p2.x * p1.y;

                    x += (p1.x + p2.x) * f;
                    y += (p1.y + p2.y) * f;
                    area += f;
                }

                area /= 2;
                f = area * 6;

                return { x: x / f, y: y / f, a: area };
        }
    }
    exports.centerArea = centerArea;
});
