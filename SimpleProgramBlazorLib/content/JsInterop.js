// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.exampleJsFunctions = {
  showPrompt: function (message) {
    return prompt(message, 'Type anything here');
  }
};


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
        // TODO �������� ����� �� ��������� �������, ���� ��������� �����
        Plotly.downloadImage(id, {format: 'png', width: 1600, height: 900, filename: '������'});
        return true;
    }
};

window.filesaver = {
    save: function(id){
        var blob = new Blob([id], {type: "text/csv;charset=utf-8"});
        saveAs(blob, "������.csv");
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

    // ������������� �������� Foundation, � ������� ������������ JS
    // �������� � ������ OnAfterRenderAsync()
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