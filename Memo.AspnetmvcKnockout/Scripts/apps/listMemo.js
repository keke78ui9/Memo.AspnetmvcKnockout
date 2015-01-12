function Memo(data) {
    this.id = ko.observable(data.Id);
    this.memo = ko.observable(data.MemoText);
    this.date = ko.observable(data.CreatedDate);
}

function ListMemoViewModel() {
    var self = this;
    self.memos = ko.observableArray([]);
    var mappedMemos = $.map(_listData, function (item) { return new Memo(item) });
    self.memos(mappedMemos);

    var textUpdatedSuccess = function () {

    };

    var deleteMemoSuccess = function () {

    };

    self.deleteMemo = function (e) {
        
        $.ajax("/api/memoapi/delete/" + e.id(), {
            type: "delete",
            contentType: "application/json",
            success: deleteMemoSuccess
        });

        self.memos.remove(e);
    };

    self.textUpdated = function (e) {
        $.ajax("/api/memoapi/update", {
            data: ko.toJSON(
                {
                    MemoText: e.memo(),
                    Id: e.id()
                }),
            type: "post",
            contentType: "application/json",
            success: textUpdatedSuccess
        });
    };
}

ko.applyBindings(new ListMemoViewModel());