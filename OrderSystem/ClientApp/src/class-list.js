
export default function classList(list) {

    const classes = list.flatMap(item =>
    {
        if (typeof item === "string")
        {
            return item;
        }
        else if (typeof item === "object")
        {
            const result = [];

            for (const cls in item)
            {
                if (item[cls])
                    result.push(cls);
            }

            return result;
        }
    });

    return classes.join(" ");
}