// ==UserScript==
// @name         KiaRobot
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  try to take over the world!
// @author       You
// @match        https://divar.ir/*
// @icon         data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==
// @require https://code.jquery.com/jquery-3.6.0.min.js
// @require     https://raw.githubusercontent.com/eligrey/FileSaver.js/master/dist/FileSaver.min.js
// @require http://userscripts-mirror.org/scripts/source/107941.user.js
// @grant GM_setValue
// @grant GM_getValue
// @grant GM_setClipboard
// @grant GM_listValues
// @grant unsafeWindow
// @grant window.close
// @grant window.focus
// @grant window.onurlchange
// ==/UserScript==

(function() {
    'use strict';
    $("body").prepend(`<button type="button" style="z-index:100000;position:absolute;left:0;" id="clickk2">show</button>`);
    $("body").prepend(`<button type="button" style="z-index:100000;position:absolute;" id="clickk">save</button>`);
    $(".filter-box").prepend(`
    <section>
        <h2 class="kt-accordion-title kt-caption">دسته‌ها</h2>
        <ul class="kt-accordion">
            <li class="kt-accordion-item kt-accordion-item--active kt-accordion-item--with-icon">
                <a class="kt-accordion-item__header" role="button" tabindex="0" href="/s/tehran/vehicles">
                <i class="kt-icon kt-icon-cat-vehicles kt-accordion-item__icon">
                </i>وسایل نقلیه</a><ul class="kt-accordion">
            <li class="kt-accordion-item kt-accordion-item--active">
                <a class="kt-accordion-item__header" role="button" tabindex="0" href="/s/tehran/auto">خودرو</a>
                <ul class="kt-accordion"><li class="kt-accordion-item kt-accordion-item--active">
                <a class="kt-accordion-item__header" role="button" tabindex="0" href="/s/tehran/car">سواری و وانت</a>
            </li>
        </ul>
    </section>
    `);

    $("body").prepend(`
    <style>
    @keyframes mymove {
      0%   {background-color: #4ec7fd;}
      100% {background-color: #95deff;}
    }
    header {
      animation: mymove 1s infinite;
    }
    </style>
    `);

    $("#clickk").click(() => {
        GM_setValue("kia", "qw");
        GM_setValue("kia2", "qqw");
        GM_setValue("kia3", "qqqw");
        let mydate = new Date(Date.now());
        let mypersiandate = mydate.toLocaleDateString('fa-IR');
        console.log(mypersiandate);
    });

    $("#clickk2").click(() => {
        let myVal = GM_getValue("kia");
        alert(myVal);
        console.log(GM_listValues());
    });

    let a = false;
    if (a) {
        var blob = new Blob(["Hello, world!"], {type: "text/plain;charset=utf-8"});
        saveAs(blob, "a.txt");
    }

    $(window).on('load', function () {

        $(".filter-box").prepend(`
        <section style="background-color:#999;">
            <h1 class="kt-accordion-title kt-caption" style="background-color:#999;text-align:center;color:white !important;text-align:center;font-weight:bold;">kia-Robot</h1>
            <ul class="kt-accordion">
                <li class="kt-accordion-item kt-accordion-item--active kt-accordion-item--with-icon">
                    <a class="kt-accordion-item__header" role="button" tabindex="0" href="/s/tehran/vehicles">
                    <i class="kt-icon kt-icon-cat-vehicles kt-accordion-item__icon">
                    </i>وسایل نقلیه</a><ul class="kt-accordion">
                <li class="kt-accordion-item kt-accordion-item--active">
                    <a class="kt-accordion-item__header" role="button" tabindex="0" href="/s/tehran/auto">خودرو</a>
                    <ul class="kt-accordion"><li class="kt-accordion-item kt-accordion-item--active">
                    <a class="kt-accordion-item__header" role="button" tabindex="0" href="/s/tehran/car">سواری و وانت</a>
                </li>
            </ul>
        </section>
        `);
        });

    // $("#clickk").click(() => {
    //     GM_setValue("kia", "qw");
    //     GM_setValue("kia2", "qqw");
    //     GM_setValue("kia3", "qqqw");
    // });
    // $("#clickk2").click(() => {
    //     let myVal = GM_getValue("kia");
    //     alert(myVal);
    //     console.log(GM_listValues());
    // });
    // let a = false;

    // if (a) {
    //     var blob = new Blob(["Hello, world!"], {type: "text/plain;charset=utf-8"});
    //     saveAs(blob, "a.txt");
    // }
    // Your code here...
})();