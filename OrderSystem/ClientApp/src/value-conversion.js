
export const DateConverter = {
    convertToModelType(value) {
        return value ? new Date(value) : null;
    },
    convertFromModelType(value) {
        return value instanceof Date ? value.toISOString().split("T")[0] : "";
    }
};

export const NumberConverter = {
    convertToModelType(value) {
        return value ? Number(value) : 0;
    },
    convertFromModelType(value) {
        return typeof value === "number" ? String(value) : 0;
    }
};