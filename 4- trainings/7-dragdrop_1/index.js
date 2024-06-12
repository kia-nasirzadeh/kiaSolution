$('#dragme').draggable({
    revert: 'invalid',
    cursor: 'move'
});

$('#dragto').droppable({
    over: () => {
        $('#dragme').html('i\'m in, you can leave me :)');
    },
    out: () => {
        $('#dragme').html('dragme')
    },
    drop: () => {
        $('#dragme').css({
            left: 0,
            top: 0
        })
        $('#dragme').addClass('h-100');
        $('#dragto').html($('#dragme'));
        $('#dragme').html('i am dragged :))');
    }
})
$('#dragmeC').droppable({
    over: () => {
        $('#dragme').html('back home');
    },
    out: () => {
        $('#dragme').html('dragme');
    },
    drop: () => {
        $('#dragme').css({
            left:0,
            top:0
        })
        $('#dragme').removeClass('h-100');
        $('#dragmeC').html($('#dragme'));
        $('#dragme').html('dragme')
    }
})