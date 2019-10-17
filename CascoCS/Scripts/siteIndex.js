// 初始化
$(function () {
    // 固定 Navigation
    $(window).scroll(function () {
        if ($(window).scrollTop() > 685) {
            $('#navigationBar').addClass('fixed-top');
        }
        if ($(window).scrollTop() < 686) {
            $('#navigationBar').removeClass('fixed-top');
        }
    });

    // 導覽項目點選
    $('.nav-link-item').on('click', function () {
        var targetSection = $($(this).attr('href'));

        if (targetSection) {
            $('html, body').animate({
                scrollTop: targetSection.offset().top - 44
            }, 1000);
            if (targetSection.prop('id') == 'section-AboutUs') Animatie(targetSection.prop('id'));
        }
    });

    // 案件實例輪播
    $('#carouselCase').carousel();

    // 服務項目切換
    $('.serviceIntro-List-Item').on('click', function () {
        var targetDiv;

        switch ($(this).data('target')) {
            case 'window':
                targetDiv = $('#serviceIntro-Unit-Desktop-Window');
                break;

            case 'decoration':
                targetDiv = $('#serviceIntro-Unit-Desktop-Decoration');
                break;

            case 'default':
                targetDiv = $('#serviceIntro-Unit-Desktop-Default');
                break;

            default:
                return;
        }

        // 清除項目樣式
        $('.serviceIntro-List-Item').removeClass('is-active');
        $(this).addClass('is-active');

        // 切換項目
        $('.serviceIntro-Unit').css('display', 'none');
        targetDiv.fadeIn(300, function () {
            $('.serviceIntro-Unit').removeClass('is-display');
            targetDiv.addClass('is-display');
        });
    });

    // 移動特效 - 關於我們
    $('#section-AboutUs').waypoint(function () {
        Animatie("section-AboutUs");
    }, { offset: '50%' });

    // 移動特效 - 預約估價
    $('#section-Reservation').waypoint(function () {
        Animatie("section-Reservation");
    }, { offset: '50%' });

    // 移動特效 - 聯絡我們
    $('#section-ContactUs').waypoint(function () {
        Animatie("section-ContactUs");
    }, { offset: '50%' });
});


// 建立特效
function Animatie(Section) {
    switch (Section) {
        // 關於我們
        case "section-AboutUs":
            $('.intro').addClass('animated  fadeIn');
            $('.featureUnit').addClass('animated  fadeInLeft');
            setTimeout(function () {
                $('.intro').removeClass('animated  fadeIn');
                $('.featureUnit').removeClass('animated  fadeInLeft');
            }, 2500);
            break;

        // 預約估價
        case "section-Reservation":
            $('.reservationFlow').addClass('animated fadeInLeft');
            $('.reservationForm').addClass('animated fadeInRight');
            setTimeout(function () {
                $('.reservationFlow').removeClass('animated fadeInLeft');
                $('.reservationForm').removeClass('animated fadeInRight');
            }, 2500);
            break;

        case "section-ContactUs":
            $('.contactUnit').addClass('animated fadeInLeft');
            setTimeout(function () {
                $('.contactUnit').removeClass('animated fadeInLeft');
            }, 2500);
    }
}

// 建立地圖
function ConstructMap() {
    var map = new GMaps({
        div: '#contactUnit-GoogleMap',
        lat: 25.071895,
        lng: 121.666147
    });

    map.addMarker({
        lat: 25.071895,
        lng: 121.666147,
        title: '好事多',
        infoWindow: {
            content: '<p>好事多</p>'
        }
    });
}

// 送出表單
function OnBegin() {
    Block("預約中...");
}

// 要求完成
function OnSuccess(Result) {
    ShowMsg(Result.Message);

    if (Result.Status) {
        $('#btnReset').click();
    } else {
        console.log(Result.ErrorMessage);
    }
}

// 要求失敗
function OnFailure() {
    ShowMsg("系統異常，請重新送出或洽詢 (02) 8648 - 2536");
}