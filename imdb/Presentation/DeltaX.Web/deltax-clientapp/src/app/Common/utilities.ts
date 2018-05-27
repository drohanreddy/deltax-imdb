export class Utilities {    
    isNullOrEmpty(val){
        return !(val !== null && val !== undefined)
    }
    isValidArray(arr){
        return arr !== null && arr !== undefined 
    }
}