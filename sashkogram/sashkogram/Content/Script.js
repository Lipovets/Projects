var object = {
    init: function () {
        this.getElement();
        this.leave();
        this.getPhoto();
        this.leavePhoto();
        this.clickStatus();
        this.clickSave();
        //this.slider();
        this.sliderClose();
        this.sliderAction();
        this.next();
    },

    getElement: function () {
        var there = document.getElementById("there");
        var item = document.getElementById("avatar");
        item.onmouseover = function () {
            item.style.display = "";
        }
        there.onmouseover = function () {
            item.style.display = "";
        }

    },

    leave: function () {
        var there = document.getElementById("there");
        var item = document.getElementById("avatar");

        there.onmouseout = function () {
            item.style.display = "none";
        }
        item.onmouseout = function () {
            item.style.display = "none";
        }
    },


    getPhoto: function () {
        var profilePhotos = document.getElementsByClassName("profilePhotos");
        var divOnPhoto = document.getElementsByClassName("divOnPhoto");
        function f(i) {
            return function () {
                divOnPhoto[i].style.display = "";
            }
        }

        for (var item = 0; item < profilePhotos.length; item++) {
            profilePhotos[item].onmouseover = f(item);
        }
        for (var item = 0; item < profilePhotos.length; item++) {
            divOnPhoto[item].onmouseover = f(item);
        }
    },

    leavePhoto: function () {
        var profilePhotos = document.getElementsByClassName("profilePhotos");
        var divOnPhoto = document.getElementsByClassName("divOnPhoto");
        function f(i) {
            return function () {
                divOnPhoto[i].style.display = "none";
            }
        }

        for (var item = 0; item < profilePhotos.length; item++) {
            profilePhotos[item].onmouseout = f(item);
        }
        for (var item = 0; item < profilePhotos.length; item++) {
            divOnPhoto[item].onmouseout = f(item);
        }
    },

    clickStatus: function () {
        var status = document.getElementById("ProfileStatus");
        var newStatus = document.getElementById("SetStatus");
        status.onclick = function () {
            if (newStatus.style.display == "none") {
                newStatus.style.display = ""
            }
            else {
                newStatus.style.display = "none";
            }
        }
    },

    clickSave: function () {
        var save = document.getElementById("hideEditor");
        var newStatus = document.getElementById("SetStatus");
        save.onclick = function () {
            newStatus.style.display = "none";
        }
    },

    slider: function () {
        var photo = document.getElementsByClassName("profilePhotos");
        var sliderDiv = document.getElementById("sliderDiv");
        var bigPhoto = document.getElementById("bigPhoto");
        var divOnPhoto = document.getElementsByClassName("divOnPhoto");

        function f(i) {
            return function () {
                sliderDiv.style.display = "";
                bigPhoto.src = photo[i].src;
            }
        }

        for (var item = 0; item < photo.length; item++) {
            photo[item].onclick = f(item);
            divOnPhoto[item].onclick = f(item);
        }
    },

    sliderClose: function () {
        var close = document.getElementById("photoClose");
        var sliderDiv = document.getElementById("sliderDiv");
        close.onclick = function () {
            sliderDiv.style.display = "none";
        }
    },

    sliderAction: function () {
        var divOnPhoto = document.getElementsByClassName("divOnPhoto");
        var photo = document.getElementsByClassName("profilePhotos");
        var sliderDiv = document.getElementById("sliderDiv");
        var bigPhoto = document.getElementById("bigPhoto");
        var ids = document.getElementsByClassName("number");

        function f(i) {
            return function () {
                sliderDiv.style.display = "";
                bigPhoto.src = photo[ids[i].value].src;
            }
        }
        
        for (var item = 0; item < photo.length; item++) {
            divOnPhoto[item].onclick = f(item);
        }
    },

    next: function () {
        var divOnPhoto = document.getElementsByClassName("divOnPhoto");
        var photo = document.getElementsByClassName("profilePhotos");
        var sliderDiv = document.getElementById("sliderDiv");
        var bigPhoto = document.getElementById("bigPhoto");
        var ids = document.getElementsByClassName("number");
        var nextPhoto = document.getElementById("next");

        function f(i) {
            return function () {
                sliderDiv.style.display = "";
                bigPhoto.src = photo[(ids[i].value++)].src;
            }
        }

        for (var item = 0; item < photo.length; item++) {
            nextPhoto.onclick = f(item);
        }
    },

    pref: function () {

    }
};

window.onload = function () {
    object.init();
};