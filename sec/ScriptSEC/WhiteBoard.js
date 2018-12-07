$('#slcAmigo').on('change', function () {
    var idAmigo = parseInt($(this).val());
    if (idAmigo > 0) {
        var html = '';
        var nomeAmigo = $(this).find(':selected').text();
        html += '<div class="chip">' + nomeAmigo + '<small class="close-pref removeMigo" ref="' + idAmigo + '">x</small></div>';
        $('option:selected', this).remove();
        $('#divAmigos').append(html);
        $('.removeMigo').on('click', function () {
            var nomeMigo = $(this).parent().text();
            nomeMigo = nomeMigo.slice(0, -1);
            var idMigo = parseInt($(this).attr('ref'));
            var idsSelect = [];
            $('#slcAmigo').find('option').each(function (item) {
                idsSelect.push(parseInt($(this).val()));
            });
            if (!idsSelect.includes(idMigo)) {
                $("#slcAmigo").append(new Option(nomeMigo, idMigo));
                $(this).parent().remove();
            }
    
        });
    }
});

window.onload = function () {
    var myCanvas = document.getElementById("whiteboard");
    var ctx = myCanvas.getContext("2d");

    // Fill Window Width and Height
    myCanvas.width = window.innerWidth - 100;
    myCanvas.height = window.innerHeight - 100;

    // Set Background Color
    ctx.fillStyle = "#fff";
    ctx.fillRect(0, 0, myCanvas.width, myCanvas.height);

    // Mouse Event Handlers
    if (myCanvas) {
        var isDown = false;
        var canvasX, canvasY;
        ctx.lineWidth = 5;

        $(myCanvas)
            .mousedown(function (e) {
                isDown = true;
                ctx.beginPath();
                canvasX = e.pageX - myCanvas.offsetLeft;
                canvasY = e.pageY - myCanvas.offsetTop;
                ctx.moveTo(canvasX, canvasY);
            })
            .mousemove(function (e) {
                if (isDown !== false) {
                    canvasX = e.pageX - myCanvas.offsetLeft;
                    canvasY = e.pageY - myCanvas.offsetTop;
                    ctx.lineTo(canvasX, canvasY);
                    ctx.strokeStyle = "#000";
                    ctx.stroke();
                }
            })
            .mouseup(function (e) {
                isDown = false;
                ctx.closePath();
            });
    }

    // Touch Events Handlers
    draw = {
        started: false,
        start: function (evt) {

            ctx.beginPath();
            ctx.moveTo(
                evt.touches[0].pageX,
                evt.touches[0].pageY
            );

            this.started = true;

        },
        move: function (evt) {

            if (this.started) {
                ctx.lineTo(
                    evt.touches[0].pageX,
                    evt.touches[0].pageY
                );

                ctx.strokeStyle = "#000";
                ctx.lineWidth = 5;
                ctx.stroke();
            }

        },
        end: function (evt) {
            this.started = false;
        }
    };

    // Touch Events
    myCanvas.addEventListener('touchstart', draw.start, false);
    myCanvas.addEventListener('touchend', draw.end, false);
    myCanvas.addEventListener('touchmove', draw.move, false);

    // Disable Page Move
    document.body.addEventListener('touchmove', function (evt) {
        evt.preventDefault();
    }, false);
};

