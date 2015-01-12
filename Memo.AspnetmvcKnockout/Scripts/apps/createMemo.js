function CreateMemoViewModel() {
    var self = this;
    self.newMemo = ko.observable();
    self.created = ko.observable(false);

    var saveSuccess = function(){
        self.created(true);
    };

    self.save = function () {
        $.ajax("/api/memoapi/create", {
            data: ko.toJSON({ MemoText: self.newMemo }),
            type: "post",
            contentType: "application/json",
            success: saveSuccess
        });

    };
}

ko.applyBindings(new CreateMemoViewModel());