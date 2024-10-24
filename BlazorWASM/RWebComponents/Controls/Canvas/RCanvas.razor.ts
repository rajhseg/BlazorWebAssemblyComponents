



let Dict: { [key : string]: any } = {};

let num = 111;

let objsAddToDict = [
                        'createConicGradient', 'createLinearGradient', 'createRadialGradient',
                        'createPattern', 'getTransform', 'invertSelf', 'multiplySelf',
                        'preMultiplySelf', 'rotateAxisAngleSelf', 'rotateFromVectorSelf', 
                        'rotateSelf', 'scale3dSelf','scaleSelf', 'setMatrixValue', 
                        'skewXSelf', 'skewYSelf', 'translateSelf',
                        'translate', 'transformPoint',
                        'skewY', 'skewX', 'scaleNonUniform', 'scale3d',
                        'scale', 'rotateFromVector', 'rotateAxisAngle', 'rotate',
                        'multiply', 'inverse', 'flipY', 'flipX', 'matrixTransform'
                    ]
                    

 export function ClearContext(obj: {Id: string}){

 }

 export function CreateContext(obj: {Id: string}) {
    let canvasElement = document.getElementById(obj.Id) as HTMLCanvasElement;
    let value = {};

    if(canvasElement){
        let context = canvasElement.getContext('2d');
        if(context){
            Dict[obj.Id] = context;
            value = ConvertToJsonString(context);                    
        }
    }

    for(let dictkey in Dict)
    {
        let insObj = Dict[dictkey];
        let context = Dict[obj.Id];

        for(let propkey in context)
        {
            if(context[propkey] === insObj){
                value[propkey] = dictkey;
            }
        }
    }

    return value;
}

 export function ConvertToJsonString(obj: object){
    let value = JSON.stringify(MapProps(obj)).toString();        
    let jsonObj = ConvertToJson(value);

    return jsonObj;
}

export function DispatchProps(args:{ prop: any[] }){
    if(args && args.prop.length > 0){
        let id = args.prop[0];
        let propname = args.prop[1];
        
        let context = Dict[id];
        let rsubid = args.prop[2];

        if(context){
            if(Dict[rsubid]){
                context[propname] = Dict[rsubid];
            } else {
                context[propname] = args.prop[2];
            }
        }
    }
}

export function DispatchOperation(args: { prop: any[] }){
    if(args && args.prop.length > 0) {
        let id = args.prop[0];
        let functionname = args.prop[1];

        let props = args.prop.slice(2);
        let parameters = props.filter(x => x != null);
                
        let context = Dict[id];
        
        if(context){
            context[functionname].apply(context, parameters);
        }
    }
}


export function DispatchOperationReturn(args: { prop: any[] }): any {
    let obj = undefined;
    let resultAddToDict = false;  
        
    if(args && args.prop.length > 0) {
        let id = args.prop[0];
        let functionname = args.prop[1];        
                              
        let props = args.prop.slice(2);
        let parameters = props.filter(x => x != null);
        
        let findIndex = objsAddToDict.findIndex(x=>x.toLowerCase()==functionname.toLowerCase());

        if(findIndex > -1){
            num = num + 1;
            resultAddToDict = true;
        }

        let context = Dict[id];
        
        if(context){
           obj = context[functionname].apply(context, parameters);
        }

        if(resultAddToDict && obj){
            let subId = id+"_"+num;
            Dict[subId] = obj;
        }
    }

    if(obj){
        let value = JSON.stringify(MapProps(obj)).toString();
        let jsonObj = JSON.parse(value);   
        
        if(resultAddToDict) 
        {
            jsonObj["rsubId"] = args.prop[0] + "_" + num;     
        }

        return jsonObj;
    }

    return {};
}

export function MapProps(obj: object){       
    let newObj = {};

    Object.getOwnPropertyNames(obj).forEach(x=>{
        if(typeof obj[x] === 'function')
            newObj[x] = x;
        else
            newObj[x] = obj[x];
    })

    let parent = Object.getPrototypeOf(obj);
    while(parent){

        Object.getOwnPropertyNames(parent).forEach(x=>{
            if(!newObj.hasOwnProperty(x) && parent.hasOwnProperty(x) && x != 'canvas') {
                if(typeof obj[x] === 'function')
                    newObj[x] = x;
                else
                    newObj[x] = obj[x];
            }
        });

        parent = Object.getPrototypeOf(parent);

        if(Object.prototype == parent){
            parent = undefined;
        }
    }

    return newObj;
}

export function ConvertToJson(obj: string){
    let value = JSON.parse(obj);
    return value;
}

// export { CreateContext, ConvertToJsonString };