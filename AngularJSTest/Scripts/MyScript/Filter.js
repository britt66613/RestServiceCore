app.filter("status", function () {
    return function (status) {
        switch (status) {
            case 0:
                return "Open";
            case 1:
                return "Close";

        }
    }
})