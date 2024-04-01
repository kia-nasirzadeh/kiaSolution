            // ==UserScript==
            // @name         KiaRobot
            // @namespace    http://tampermonkey.net/
            // @version      0.1
            // @description  try to take over the world!
            // @author       You
            // @match        https://divar.ir/*
            // @icon         data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==
            // @require https://code.jquery.com/jquery-3.6.0.min.js
            // @require https://gist.github.com/raw/2625891/waitForKeyElements.js
            // @require http://userscripts-mirror.org/scripts/source/107941.user.js
            // @grant GM_setValue
            // @grant GM_getValue
            // @grant GM_deleteValue
            // @grant GM_setClipboard
            // @grant GM_listValues
            // @grant unsafeWindow
            // @grant window.close
            // @grant window.focus
            // @grant window.onurlchange
            // ==/UserScript==

            var PromisesLagTime = 2000;
            var IsNumberCopiedToGM; // when numberCopied say to user...
            var ModalOpen = false;
            var MenuOpen = false;
            var PicPanelOpen = false;

            $(document).keydown(function(e) {
                if (e.ctrlKey && e.which == 73) { // ctrl+i
                    $("button.post-actions__get-contact").click();
                } else if (e.ctrlKey && e.which == 77) { // ctrl+M
                    if (!ModalOpen) {
                        ModalOpen = true;
                        var tozihat = $($(".kt-description-row__text--primary")[0]).text();
                        $("body").append(kiaModal);
                        $("#kiaModalContent").append(tozihat);
                    } else {
                        $($(".kt-description-row__text--primary")[0]).append(ModalOpen);
                        ModalOpen = false;
                        // $("#kiaModalContent").empty();
                        $(".kiaModal").remove();
                    }
                } else if (e.ctrlKey && e.which == 186) { // ctrl+;
                    if (!PicPanelOpen) ShowPics();
                    else HidePics();
                }
            });
            async function ShowPics () {
                PicPanelOpen = true;
                $("body").prepend(`
                <div id="kiaPics" style="padding: 5px;background-color:#000000b3;border-radius:5px;position:fixed;width:90%;height:90%;z-index:1000000000;margin:auto;right:0;left:0;top:0;bottom:0;overflow-y: scroll;"></div>`);
                let uniqueSrcs = await LoadPics();
                uniqueSrcs.forEach(function (imgSrc) {
                    var imgSrcParts = imgSrc.split("/");
                    var imgLastPart = imgSrcParts[imgSrcParts.length - 1];
                    if (!imgLastPart.includes("resize"))
                    $("#kiaPics").append(`<img style="max-height: 45%;padding:2.5px;margin:2.5px;border:1px solid white;" src="${imgSrc}">`);
                });
            }
            function HidePics () {
                PicPanelOpen = false;
                $("#kiaPics").remove();
            }
            async function LoadPics () {
                let leftArrow = document.querySelector(".kt-icon.kt-icon-keyboard-arrow-left.kt-icon--lg.kt-carousel__control-icon");
                function SmallTimeOut () {
                    return new Promise(resolve => setTimeout(resolve, 600));
                };
                var allImgTags = document.querySelectorAll("img.kt-image-block__image.kt-image-block__image--fading");
                var allUniqueImgSrcs = [];
                allImgTags.forEach(function (img) {
                    var imgSrc = img.src;
                    var again = false;
                    allUniqueImgSrcs.forEach(function (uniqImgSrc) {
                        if (uniqImgSrc == imgSrc) again = true;
                    });
                    if (!again) allUniqueImgSrcs.push(imgSrc);
                });
                let picsNums = 0;
                allUniqueImgSrcs.forEach(function (imgSrc) {
                    var imgSrcParts = imgSrc.split("/");
                    var imgLastPart = imgSrcParts[imgSrcParts.length - 1];
                    if (imgLastPart.includes("resize")) picsNums += 1;
                });
                for (let i = 1; i <= picsNums; i++) {
                    await SmallTimeOut();
                    leftArrow.click();
                }
                await SmallTimeOut();
                var allImgTags = document.querySelectorAll("img.kt-image-block__image.kt-image-block__image--fading");
                var allUniqueImgSrcs = [];
                allImgTags.forEach(function (img) {
                    var imgSrc = img.src;
                    var again = false;
                    allUniqueImgSrcs.forEach(function (uniqImgSrc) {
                        if (uniqImgSrc == imgSrc) again = true;
                    });
                    if (!again) allUniqueImgSrcs.push(imgSrc);
                });
                return allUniqueImgSrcs;
            }
            function ChangeAdToVisited () {
                $(".kt-page-title__title.kt-page-title__title--responsive-sized, p").css("animation", "bgLighter 0.25s infinite");
            }
            function StartApp () {
                'use strict';
                ShowRobotStateOn();
                if (VisitedLink(window.location.href)) ChangeAdToVisited();
                // for agahi thumbnail mousewheel click:
                var agahiElement = $(".kt-post-card.kt-post-card--outlined.kt-post-card--padded.kt-post-card--has-action.kt-post-card--has-chat");
                agahiElement.parent("a").click(function (event) {
                    event.preventDefault();
                    $(this).children(":first").css("background-color", "#673ab77d");
                    var link = "https://divar.ir" + $(this).attr("href");
                    window.open(link, '_blank').focus();
                });
                agahiElement.parent("a").on("tap", function (event) {
                    event.preventDefault();
                    $(this).children(":first").css("background-color", "#673ab77d");
                    var link = "https://divar.ir" + $(this).attr("href");
                    window.open(link, '_blank').focus();
                });
                // for tamas btn click:
                $("button.post-actions__get-contact").on("click", OpenContactPanel);
            }
            async function OpenContactPanel () {
                function TimeOut () {
                    return new Promise(resolve => setTimeout(resolve, PromisesLagTime));
                }
                function SmallTimeOut () {
                    return new Promise(resolve => setTimeout(resolve, 500));
                }
                await TimeOut();
                if (!NumbersExists()) await TimeOut();
                if (!NumbersExists()) await TimeOut();
                if (!NumbersExists()) {
                    alert("oops! reload page please!");
                    return;
                }
                var phoneNumbers = NumbersExists();
                function replaceExpandableBox () {
                    $(".expandable-box").replaceWith(numberEl);
                    phoneNumbers.forEach(function (phoneNumber) {
                        var alreadyInDb = GM_getValue(TranslateNumberToEnglish(phoneNumber));
                        if (alreadyInDb == undefined) {
                            $("#kia-tbody").append(ANumberRow(phoneNumber, false));
                        }
                        else { // new contact:
                            $("#kia-tbody").append(ANumberRow(phoneNumber, alreadyInDb));
                        }
                    });

                    $(".kia-name-field")[0].focus();
                    $(".kia-name-field").keyup(function (e) {
                        if (e.ctrlKey && e.which == 13) {
                            SaveAzKaaseb()
                        } else if (!e.ctrlKey && e.keyCode == 13) {
                            SaveAzCustomer();
                        }
                    });

                    
                    var phoneNumber = $(".kia-name-field").parent("td").next().html();
                    phoneNumber = $.trim(phoneNumber);
                    phoneNumber = TranslateNumberToEnglish(phoneNumber);
                    $(".saveAsKaasebBtn").click(SaveAzKaaseb);
                    $(".editBtn").click(RemoveThisRow);
                    function SaveAzKaaseb () {
                        if ($(".kia-name-field").val() == "") return;
                        let namayeshgahName = prompt("che namayeshgahi? (age kaasebe aadie benevis: kaseb)");
                        try {
                            GM_setValue(phoneNumber, `N-${namayeshgahName}, ` + $(".kia-name-field").val());
                            PutInClipborad();
                            replaceExpandableBox();
                        } catch {
                            alert("error in saving number");
                        }
                    }
                    function SaveAzCustomer () {
                        try {
                            GM_setValue(phoneNumber, $(".kia-name-field").val());
                            PutInClipborad();
                            replaceExpandableBox();
                        } catch {
                            alert("error in saving number");
                        }
                    }
                    function RemoveThisRow () {
                        phoneNumber = TranslateNumberToEnglish(phoneNumber);
                        try {
                            GM_deleteValue(phoneNumber);
                            replaceExpandableBox();
                        } catch {
                            alert("error in delete number");
                        }
                    }
                    async function PutInClipborad () {
                        await navigator.clipboard.writeText(phoneNumber);
                        await SmallTimeOut();
                        await navigator.clipboard.writeText(window.location.href);
                        await SmallTimeOut();
                        await navigator.clipboard.writeText($(".kia-name-field").val());
                        $("#kia-tfoot").append(`
                        <tr>
                            <th colspan='3' style="background-color: #01a4ed;direction: ltr !important;">
                                numbers copied :)
                            </th>
                        </tr>
                        `);
                    }
                    // select range Start:
                    var phoneNumber_ = document.querySelector(".kia-number-place").innerHTML;
                    phoneNumber_ = phoneNumber_.trim();
                    let part1 = phoneNumber_.substring(0,4)
                    let highlight = phoneNumber_.substring(4,7);
                    let part2 = phoneNumber_.substring(7,11);
                    let highlightedPhoneNumber = part1 + `<span style="background-color: #3f51b5 !important">${highlight}</span>` + part2;
                    document.querySelector(".kia-number-place").innerHTML = highlightedPhoneNumber;
                    // select range End:
                }
                replaceExpandableBox();
            }
            function VisitedLink (link) {
                // first we should check if we are in an ad page:
                var linkParts = link.split("/");
                var linkFirstPart = linkParts[3];
                if (linkFirstPart != "v") return false;
                // now we can check if this link is repetitive:
                var VisitedLink = false;
                var viewedLinks_string = localStorage.getItem("RobotVisitedLinks");
                var viewdLinks = JSON.parse(viewedLinks_string);
                viewdLinks.forEach((visitedLink, index) => {
                    if (visitedLink == link) VisitedLink = true;
                });
                if (!VisitedLink) { // this is new link, we should add it and return a false VisitedLink:
                    viewdLinks[viewdLinks.length] = link;
                    viewedLinksArray = JSON.stringify(viewdLinks);
                    localStorage.setItem("RobotVisitedLinks", viewedLinksArray);
                    return VisitedLink;
                } else { // we already have this so we should just return a true VisitedLink;
                    return VisitedLink;
                }
            }
            function ShowAllVisitedLinks () {
                var articleElements = document.querySelectorAll("article");
                articleElements.forEach((articleEl) => {
                    var parentAnchorLink = $(articleEl).parent("a");
                    var href = parentAnchorLink.attr("href");
                    var hrefParts = href.split("/");
                    var articlePostId = hrefParts[hrefParts.length - 1];
                    var viewedPosts = localStorage.getItem("my-viewed-posts");
                    viewedPosts = viewedPosts.slice(1);
                    viewedPosts = viewedPosts.slice(0, viewedPosts.length - 1);
                    viewedPosts = viewedPosts.split("\"");
                    viewedPosts.forEach(function (postId) {
                        if (postId == articlePostId)
                        $(articleEl).css("background-color", "red");
                    });
                })
                CloseMenu();
            }
            function EstelamNumber () {
                let number = prompt("what is number?");
                let inDb = GM_getValue(number);
                if (inDb) alert("we have a record ► " + inDb);
                else alert("we have not this number");
            }
            function TranslateNumberToEnglish (number) {
                // ۰۱۲۳۴۵۶۷۸۹
                for (let i = 0; i < number.length; i++) {
                    switch (number.slice(i, i+1)) {
                        case "۰":
                            number = number.substring(0,i) + "0" + number.substring(i+1);
                            break;
                        case "۱":
                            number = number.substring(0,i) + "1" + number.substring(i+1);
                            break;
                        case "۲":
                            number = number.substring(0,i) + "2" + number.substring(i+1);
                            break;
                        case "۳":
                            number = number.substring(0,i) + "3" + number.substring(i+1);
                            break;
                        case "۴":
                            number = number.substring(0,i) + "4" + number.substring(i+1);
                            break;
                        case "۵":
                            number = number.substring(0,i) + "5" + number.substring(i+1);
                            break;
                        case "۶":
                            number = number.substring(0,i) + "6" + number.substring(i+1);
                            break;
                        case "۷":
                            number = number.substring(0,i) + "7" + number.substring(i+1);
                            break;
                        case "۸":
                            number = number.substring(0,i) + "8" + number.substring(i+1);
                            break;
                        case "۹":
                            number = number.substring(0,i) + "9" + number.substring(i+1);
                            break;
                    }
                }
                return number;
            }
            function ANumberRow (number, alreadyInDb) {
                if (!alreadyInDb) { // new contact:
                    var numberRowEl = `
                        <tr>
                            <td style="max-width:10px;"><button class="saveAsKaasebBtn" tabindex="2" style="white-space:pre-wrap; word-wrap:break-word;font-size:10px;color:black !important;max-width:100%;overflow:hidden;" type="button">save as namayeshgah</button></td>
                            <td data-title='Provider Name'>
                            <input tabindex="1" type="text" placeholder="name here" style="width:100%;padding: 5px !important;direction: ltr !important;color: #202932 !important;" class="kia-name-field"/>
                            </td>
                            <td data-title='E-mail' class="kia-number-place">
                            ${number}
                            </td>
                        </tr>
                    `;
                } else {
                    var numberRowEl = `
                        <tr>
                            <td style="max-width:10px;"><button class="editBtn" tabindex="2" style="padding:10px 5px !important;white-space:pre-wrap; word-wrap:break-word;font-size:10px;color:black !important;width:100%;height:100% !important;overflow:hidden;" type="button">edit</button></td>
                            <td data-title='Provider Name'>
                                <input type="text" value="${alreadyInDb}" style="width:100% !important;padding: 5px !important;direction: ltr !important;color: #202932 !important;" class="kia-name-field" disabled/>
                            </td>
                            <td data-title='E-mail' class="kia-number-place">
                                ${number}
                            </td>
                        </tr>
                    `;
                }
                return numberRowEl;
            }
            function ShowRobotStateOn () {
                $(".kt-button.kt-button--primary.kt-nav-button.nav-bar__submit-btn").css("animation", "mymoveOn 0.25s infinite");
            }
            function NumbersExists () {
                var RawContactLinks = $(".kt-unexpandable-row__action");
                contactLinks = [];
                RawContactLinks.each(function (i, link) {
                    var firstLetterOfLink = link.innerHTML.slice(0,1);
                    if (
                        firstLetterOfLink != "۰" &&
                        firstLetterOfLink != "۱" &&
                        firstLetterOfLink != "۲" &&
                        firstLetterOfLink != "۳" &&
                        firstLetterOfLink != "۴" &&
                        firstLetterOfLink != "۵" &&
                        firstLetterOfLink != "۶" &&
                        firstLetterOfLink != "۷" &&
                        firstLetterOfLink != "۸" &&
                        firstLetterOfLink != "۹"
                    ) return;
                    else contactLinks.push(link.innerHTML);
                });
                if (contactLinks.length > 0) return contactLinks;
                else return false;
            }
            function OpenMenu () {
                $("#kiaMenu").css("display", "block");
                MenuOpen = true;
            }
            function CloseMenu () {
                $("#kiaMenu").css("display", "none");
                MenuOpen = false;
            }
            (function() {
                StartApp();
                $(document).ready(() => {
                    $("body").prepend(`
                        <style>
                            @keyframes rotationAnime {
                                0%   {transform: rotate(0deg);}
                                50% {transform: rotate(360deg);}
                                100%   {transform: rotate(0deg);}
                            }
                            @keyframes mymoveOn {
                                0% { background-color: #a62626; }
                                50% { background-color: green; }
                                100% { background-color: #a62626; }
                            }
                            @keyframes bgLighter {
                                0% { color: black; }
                                50% { color: #c70000de; }
                                100% { color: black; }
                            }
                        </style>
                    `);
                    $("body").prepend(kiaMenu);
                    $("#kiaMenuThumbnail").click(() => {
                        if (!MenuOpen) {
                            OpenMenu();
                        }
                        else {
                            CloseMenu();
                        }
                    });
                    $("#showAllViewdPosts").click(() => {
                        ShowAllVisitedLinks();
                    })
                    $("#estelamBtn").click(() => {
                        EstelamNumber();
                    })
                });
                let oldPushState = history.pushState;
                history.pushState = function pushState() {
                    let ret = oldPushState.apply(this, arguments);
                    window.dispatchEvent(new Event('pushstate'));
                    window.dispatchEvent(new Event('locationchange'));
                    return ret;
                };

                let oldReplaceState = history.replaceState;
                history.replaceState = function replaceState() {
                    let ret = oldReplaceState.apply(this, arguments);
                    window.dispatchEvent(new Event('replacestate'));
                    window.dispatchEvent(new Event('locationchange'));
                    return ret;
                };

                window.addEventListener('popstate', (ev) => {
                    window.dispatchEvent(new Event('locationchange'));
                });
                window.addEventListener('locationchange', async function () {
                    function TimeOut () {
                        return new Promise(resolve => setTimeout(resolve, PromisesLagTime));
                    }
                    await TimeOut();
                    StartApp();
                });
            })();
            var numberEl = `
            <style>
            .copy-row * {
                box-sizing: border-box;
                color: white !important;
                padding: unset !important;
                margin: unset !important;
                direction: unset !important;
                -webkit-box-direction: unset !important;
                float: unset !important;
            }
            div.copy-row {
                background-color: #2C3845;
            }
            .copy-row table {
                display: block;
                direction: unset !important;
                position: relative !important;
            }

            .copy-row tr,
            .copy-row td,
            .copy-row tbody,
            .copy-row tfoot {
                display: block;
            }

            .copy-row thead {
                display: none;
            }

            .copy-row tr {
                padding-bottom: 10px;
            }

            .copy-row td {
                padding: 10px 10px 0;
                text-align: center;
            }

            .copy-row td:before {
                content: attr(data-title);
                color: #7a91aa;
                text-transform: uppercase;
                font-size: 1.4rem;
                padding-right: 10px;
                display: block;
            }

            .copy-row table {
                width: 100%;
            }

            .copy-row th {
                text-align: left;
                font-weight: 700;
            }

            .copy-row thead th {
                background-color: #202932;
                color: #fff;
                border: 1px solid #202932;
            }

            .copy-row tfoot th {
                display: block;
                padding: 10px;
                text-align: center;
                color: #b8c4d2;
            }

            .copy-row .button {
                line-height: 1;
                display: inline-block;
                font-size: 1.2rem;
                text-decoration: none;
                border-radius: 5px;
                color: #fff;
                padding: 8px;
                background-color: #4b908f;
            }

            .copy-row .select {
                padding-bottom: 20px;
                border-bottom: 1px solid #28333f;
            }

            .copy-row .select:before {
                display: none;
            }

            .copy-row .detail {
                background-color: #BD2A4E;
                width: 100%;
                height: 100%;
                padding: 40px 0;
                position: fixed;
                top: 0;
                left: 0;
                overflow: auto;
                -moz-transform: translateX(-100%);
                -ms-transform: translateX(-100%);
                -webkit-transform: translateX(-100%);
                transform: translateX(-100%);
                -moz-transition: -moz-transform 0.3s ease-out;
                -o-transition: -o-transform 0.3s ease-out;
                -webkit-transition: -webkit-transform 0.3s ease-out;
                transition: transform 0.3s ease-out;
            }

            .copy-row .detail.open {
                -moz-transform: translateX(0);
                -ms-transform: translateX(0);
                -webkit-transform: translateX(0);
                transform: translateX(0);
            }

            .copy-row .detail-container {
                margin: 0 auto;
                padding: 40px;
                max-width: 500px;
            }

            .copy-row dl {
                margin: 0;
                padding: 0;
            }

            .copy-row dt {
                font-size: 2.2rem;
                font-weight: 300;
            }

            .copy-row dd {
                margin: 0 0 40px 0;
                font-size: 1.8rem;
                padding-bottom: 5px;
                border-bottom: 1px solid #ac2647;
                box-shadow: 0 1px 0 #c52c51;
            }

            .copy-row .close {
                background: none;
                padding: 18px;
                color: #fff;
                font-weight: 300;
                border: 1px solid rgba(255, 255, 255, 0.4);
                border-radius: 4px;
                line-height: 1;
                font-size: 1.8rem;
                position: fixed;
                right: 40px;
                top: 20px;
                -moz-transition: border 0.3s linear;
                -o-transition: border 0.3s linear;
                -webkit-transition: border 0.3s linear;
                transition: border 0.3s linear;
            }

            .copy-row .close:hover,
            .copy-row .close:focus {
                background-color: #a82545;
                border: 1px solid #a82545;
            }

            @media (min-width: 460px) {
                .copy-row td {
                    text-align: left;
                }

                .copy-row td:before {
                    display: inline-block;
                    text-align: right;
                    width: 140px;
                }

                .copy-row .select {
                    padding-left: 160px;
                }
            }

            @media (min-width: 720px) {
                .copy-row table {
                    display: table;
                }

                .copy-row tr {
                    display: table-row;
                }

                .copy-row td,
                .copy-row th {
                    display: table-cell;
                }

                .copy-row tbody {
                    display: table-row-group;
                }

                .copy-row thead {
                    display: table-header-group;
                }

                .copy-row tfoot {
                    display: table-footer-group;
                }

                .copy-row td {
                    border: 1px solid #28333f;
                }

                .copy-row td:before {
                    display: none;
                }

                .copy-row td,
                .copy-row th {
                    padding: 10px;
                }

                .copy-row tr:nth-child(2n+2) td {
                    background-color: #242e39;
                }

                .copy-row tfoot th {
                    display: table-cell;
                }

                .copy-row .select {
                    padding: 10px;
                }
            }
        </style>
        <div class="expandable-box">
            <div class="copy-row" style="width:100%">
                <table dir="ltr">
                    <thead>
                        <tr>
                            <th>
                                Operation
                            </th>
                            <th>
                                name
                            </th>
                            <th>
                                number
                            </th>
                        </tr>
                    </thead>
                    <tfoot id="kia-tfoot" style="background-color: #a82545;">
                        <tr>
                            <th colspan='3'>
                                KiaRobot - Afraz Inc
                            </th>
                        </tr>
                    </tfoot>
                    <tbody id="kia-tbody">

                    </tbody>
                </table>
            </div>
        </div>
            `;
            var kiaModal = `
                <div class="kiaModal kt-dimmer kt-dimmer--darker kt-dimmer--open" role="button">
                    <div class="kt-dimmer__content">
                        <div style="height:99% !important;width:90% !important;" class="kt-modal kt-modal--scrollable kt-modal--medium kt-modal--full-screen-sm modal-button-content">
                        <div id="kiaModalContent" class="kt-modal__contents" style="white-space: pre-wrap;padding: 13px;">

                        </div>
                    </div>
                </div>
            `;
            var kiaMenu = `
                <style>
                #kiaMenuThumbnail {
                    z-index:10000000000;
                    position:fixed;
                    left:0px;
                    top:45%;
                    background-color: #9e9e9e66;
                    width: 30px;
                    height: 30px;
                    border-top-right-radius: 100%;
                    border-bottom-right-radius: 100%;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    cursor: pointer;
                    user-select: none;
                }
                #kiaMenu {
                    display: none;
                    z-index:10000000000;
                    position: fixed;
                    margin: auto;
                    left: 0;
                    right: 0;
                    top: 0;
                    bottom:0;
                    width: 30%;
                    height: 80%;
                    padding: 10px;
                    background-color: #9e9e9ee6;
                    border-radius: 5px;
                    box-shadow: 0px 0px 25px #00000073;
                }
                .kiaMenuBtn {
                    width: 100% !important;
                    padding: 5px !important;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    cursor: pointer;
                }
                #kiaMenuHelp {
                    border: 1px solid #9d8d8d;
                    margin: 30px;
                    background-color: #f5f5f58f;
                    direction: ltr;
                    text-align: left;
                    padding-bottom: 0px;
                }
                </style>
                <div id="kiaMenuThumbnail">
                🤖
                </div>
                <div id="kiaMenu">
                    <button id="showAllViewdPosts" class="kiaMenuBtn" type="button">show all visited posts</button>
                    <button id="estelamBtn" class="kiaMenuBtn" type="button">estelam</button>
                    <div id="kiaMenuHelp">
                        <ul>
                            <li>contact panel:
                                <ul>
                                    <li>ctrl+i => open</li>
                                    <li>Enter => save</li>
                                    <li>ctrl+Enter => save as namayeshgah</li>
                                </ul>
                            </li>
                            <li>explanation box => ctrl+m</li>
                            <li>pics box => ctrl+;</li>
                        </ul>
                        <h3 style="text-align:center;background-color:#4a4a4a42;color:#420202;margin-bottom:0px;">
                            afraz Inc. 2022
                        </h3>
                    </div>
                </div>
            `;