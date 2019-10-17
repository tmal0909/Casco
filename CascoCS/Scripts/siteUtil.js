// 顯示訊息
function ShowMsg(Message) {
    $('body').loading({
        theme: 'dark',
        message: Message || ""
    });

    setTimeout(UnBlock, 2000);
}

// 鎖住畫面
function Block(Message) {
    $('body').loading({
        theme: 'dark',
        message: Message || 'Loading'
    })
}

// 解鎖畫面
function UnBlock() {
    $('body').loading('stop');
}