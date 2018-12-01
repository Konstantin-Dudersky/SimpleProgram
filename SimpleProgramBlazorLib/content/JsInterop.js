window.plotlyhelpers = {
    react: function (id, obj) {
        Plotly.react(id, obj);
        return true;
    },

    purge: function (id) {
        Plotly.purge(id);
        return true;
    },

    downloadImage: function(id) {
        // TODO название файла из заголовка
        Plotly.downloadImage(id, {format: 'png', width: 1600, height: 900, filename: 'График'});
        return true;
    }
};

window.filesaver = {
    save: function(id){
        var blob = new Blob([id], {type: "text/csv;charset=utf-8"});
        saveAs(blob, "Данные.csv");
        return true;
    },

    savePng: function(id) {
        var canvas = document.getElementById(id);
        canvas.toBlob(function(blob) {
            saveAs(blob, "pretty image.png");
        });
    }
};

window.jquery = {
    addClass: function(id, className) {
        $(id).addClass(className);
        return true;
    },
    removeClass: function(id, className) {
        $(id).removeClass(className);
        return true;
    },
    setAttribute: function(id, qualifiedName, value) {
        document.querySelector(id).setAttribute(qualifiedName, value);
        return true;
    }
};

window.global = {
    getCurrentLocation: function () {
        console.log(window.location);
        return window.location.href;
    },

    // Инициализация плагинов Foundation
    // вызывать в методе OnAfterRenderAsync()
    foundationInit: function()
    {
        $(document).foundation();
        return true;
    },

    foundationIdInit: function(id, command)
    {
        $(id).foundation(command);
        return true;
    },

    isHidden : function (selector) {
        return (document.querySelector(selector).offsetParent === null);
    },

    isExist : function(selector) {
        return !!document.querySelector(selector);
    },

    click : function (el) {
        document.querySelector(el).click();
        return true
    }

};