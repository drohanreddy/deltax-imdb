export class Utilities {    
    isNullOrEmpty(val){
        return val == null || val.length
    }
    isValidArray(arr){
        return arr !== null && arr !== undefined && arr.length
    }
}