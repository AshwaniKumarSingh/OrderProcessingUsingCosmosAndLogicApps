function order(whereClause) {
    var collection = getContext().getCollection();

    var isAccepted = collection.queryDocuments(
        collection.getSelfLink(),
        'Select * FROM root r ' + whereClause,
        function (err, result, options) {
            if (err) {
                throw err;
            }

            if (!result || !result.length) {
                getContext().getResponse().setBody("No Results");
            }
            else {
                getContext().getResponse().setBody(JSON.stringify(result));
            }
        });

    if (!isAccepted) {
        throw new Error("Internal wrong");
    }
}