Parse.initialize("1aDfs1rC94XPfqGxm9uKil8nOLHuLGMUHgmKaGcf", "ehlesfUmOQ6OxyjiyhOA9pzB6Bu12aOycq1qMeyU");


var TestObject = Parse.Object.extend("TestObject");
var testObject = new TestObject();
testObject.save({ foo: "bar" }, {
    success: function (object) {
        alert("yay! it worked");
    }
});