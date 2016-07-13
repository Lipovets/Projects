var obj = {
    item: -1,
    imgLinks: ["~/Scripts/wall.jpg","users.png"],
    updateImage: function () {
        id = setInterval(function () {
            obj.item++;
            $("#img0").attr("src", obj.imgLinks[obj.item])
            if (obj.item == obj.imgLinks.length - 1)
                obj.item = -1;
        }, 3000)
    }
}

window.onload = function () {

    obj.updateImage();

    $("#prev").click(function () {

        if (obj.item == 0) {

            obj.item = obj.imgLinks.length - 1;
            $("#img0").attr("src", obj.imgLinks[obj.item])
            clearInterval(id);
            obj.updateImage();
        }
        else {
            obj.item -= 1;
            $("#img0").attr("src", obj.imgLinks[obj.item])
            clearInterval(id);
            obj.updateImage();
        }
    })

    $("#next").click(function () {

        if (obj.item == obj.imgLinks.length - 1) {
            obj.item = 0; 
            $("#img0").attr("src", obj.imgLinks[obj.item])
            clearInterval(id);
            obj.updateImage();
        }
        else {
            obj.item += 1;
            $("#img0").attr("src", obj.imgLinks[obj.item])
            clearInterval(id);
            obj.updateImage();
        }
    })
}