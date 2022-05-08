
export class RequiredValidationRule {
    validate(value) {
        return value !== undefined && value !== null && value !== "";
    }
}

export class RangeValidationRule {

    constructor(min, max) {
        this.min = min;
        this.max = max;
    }

    validate(value) {
        return (!this.min || value >= this.min) &&
            (!this.max || value <= this.max); 
    }
}

export class LengthValidationRule {

    constructor(min, max) {
        this.min = min;
        this.max = max;
    }

    validate(value) {
        const length = value.length;
        return (!this.min || length >= this.min) &&
            (!this.max || length <= this.max);
    }
}

export class CompositeValidationRule {
    
    constructor(rules) {
        this.rules = rules;
    }

    validate(value) {
        for (const r of this.rules) {
            if (!r.validate(value)) return false;
        }
        return true;
    }
}