var Dict = {};
var num = 111;
var objsAddToDict = [
    'createConicGradient', 'createLinearGradient', 'createRadialGradient',
    'createPattern'
];
export function ClearContext(obj) {
}
export function CreateContext(obj) {
    var canvasElement = document.getElementById(obj.Id);
    var value = {};
    if (canvasElement) {
        var context = canvasElement.getContext('2d');
        if (context) {
            Dict[obj.Id] = context;
            value = ConvertToJsonString(context);
        }
    }
    for (var dictkey in Dict) {
        var insObj = Dict[dictkey];
        var context = Dict[obj.Id];
        for (var propkey in context) {
            if (context[propkey] === insObj) {
                value[propkey] = dictkey;
            }
        }
    }
    return value;
}
export function ConvertToJsonString(obj) {
    var value = JSON.stringify(MapProps(obj)).toString();
    var jsonObj = ConvertToJson(value);
    return jsonObj;
}
export function DispatchProps(args) {
    if (args && args.prop.length > 0) {
        var id = args.prop[0];
        var propname = args.prop[1];
        var context = Dict[id];
        var rsubid = args.prop[2];
        if (context) {
            if (Dict[rsubid]) {
                context[propname] = Dict[rsubid];
            }
            else {
                context[propname] = args.prop[2];
            }
        }
    }
}
export function DispatchOperation(args) {
    if (args && args.prop.length > 0) {
        var id = args.prop[0];
        var functionname = args.prop[1];
        var removeCount = 0;
        var readLastIndex = 0;
        for (var index = args.prop.length - 1; index > 1; index--) {
            var element = args.prop[index];
            if (element == null) {
                removeCount++;
            }
            else {
                readLastIndex = index;
                break;
            }
        }
        var parameters = [];
        for (var index = 2; index <= readLastIndex; index++) {
            var element = args.prop[index];
            parameters.push(element);
        }
        var context = Dict[id];
        if (context) {
            context[functionname].apply(context, parameters);
        }
    }
}
export function DispatchOperationReturn(args) {
    var obj = undefined;
    var resultAddToDict = false;
    if (args && args.prop.length > 0) {
        var id = args.prop[0];
        var functionname_1 = args.prop[1];
        var removeCount = 0;
        var readLastIndex = 0;
        for (var index = args.prop.length - 1; index > 1; index--) {
            var element = args.prop[index];
            if (element == null) {
                removeCount++;
            }
            else {
                readLastIndex = index;
                break;
            }
        }
        var parameters = [];
        for (var index = 2; index <= readLastIndex; index++) {
            var element = args.prop[index];
            parameters.push(element);
        }
        var findIndex = objsAddToDict.findIndex(function (x) { return x.toLowerCase() == functionname_1.toLowerCase(); });
        if (findIndex > -1) {
            num = num + 1;
            resultAddToDict = true;
        }
        var context = Dict[id];
        if (context) {
            obj = context[functionname_1].apply(context, parameters);
        }
        if (resultAddToDict && obj) {
            var subId = id + "_" + num;
            Dict[subId] = obj;
        }
    }
    if (obj) {
        var value = JSON.stringify(MapProps(obj)).toString();
        var jsonObj = JSON.parse(value);
        if (resultAddToDict) {
            jsonObj["rsubId"] = args.prop[0] + "_" + num;
        }
        return jsonObj;
    }
    return {};
}
export function MapProps(obj) {
    var newObj = {};
    Object.getOwnPropertyNames(obj).forEach(function (x) {
        if (typeof obj[x] === 'function')
            newObj[x] = x;
        else
            newObj[x] = obj[x];
    });
    var parent = Object.getPrototypeOf(obj);
    while (parent) {
        Object.getOwnPropertyNames(parent).forEach(function (x) {
            if (!newObj.hasOwnProperty(x) && parent.hasOwnProperty(x) && x != 'canvas') {
                if (typeof obj[x] === 'function')
                    newObj[x] = x;
                else
                    newObj[x] = obj[x];
            }
        });
        parent = Object.getPrototypeOf(parent);
        if (Object.prototype == parent) {
            parent = undefined;
        }
    }
    return newObj;
}
export function ConvertToJson(obj) {
    var value = JSON.parse(obj);
    return value;
}
// export { CreateContext, ConvertToJsonString };
