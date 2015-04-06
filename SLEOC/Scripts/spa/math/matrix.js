define(["require", "exports", "./vector2", "./vector3", "./matrix3", "./matrix4"], function(require, exports, __vector2__, __vector3__, __matrix3__, __matrix4__) {
    var vector2 = __vector2__;
    var vector3 = __vector3__;
    var matrix3 = __matrix3__;
    var matrix4 = __matrix4__;

    var result = {
        V2: vector2,
        V3: vector3,
        M3: matrix3,
        M4: matrix4
    };
    
    return result;
});
