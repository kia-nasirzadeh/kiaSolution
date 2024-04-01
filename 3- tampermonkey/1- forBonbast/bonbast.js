// ==UserScript==
// @name         New Userscript
// @namespace    http://tampermonkey.net/
// @version      2024-03-05
// @description  try to take over the world!
// @author       You
// @match        https://bonbast.com/
// @require http://code.jquery.com/jquery-3.4.1.min.js
// @icon         data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==
// @grant        none
// ==/UserScript==

(function() {
    'use strict';
    setTimeout(() => {
        let ad_div_1 = document.querySelector("body > div:nth-child(3) > div:nth-child(1)");
        let ad_div_2 = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div.col-sm-4.col-xs-12 > div > div.col-xs-12.border-feature.widead > div:nth-child(2)");
        let ad_div_3 = document.querySelector("body > ins:nth-child(21)");
        let date_time_div = document.querySelector("body > div:nth-child(3) > div > div.col-sm-4.col-xs-12 > div > div.col-xs-12.border-feature.widead > div > div");
        let main_row = document.querySelector("body > div:nth-child(3) > div");
        let date_time_div_as_string = date_time_div.outerHTML;
        let new_row_for_dateTime = `
        <div class="row">
            <div class="col-12">
                ${date_time_div_as_string}
            </div>
        </div>
        `;
        $(main_row).before(new_row_for_dateTime);
        $(ad_div_1).remove();
        $(ad_div_2).remove();
        $(ad_div_3).remove();
        let dataTimeRow_container = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div.col-sm-4.col-xs-12");
        $(dataTimeRow_container).remove();
        let pricesRow = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div");
        $(pricesRow).removeClass('col-sm-8');
        $(pricesRow).addClass('col-12');
        let pricePack_1 = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(2) > div:nth-child(3)");
        let pricePack_2 = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(2) > div:nth-child(1)");
        $(pricePack_1).removeClass('col-lg-6');
        $(pricePack_2).removeClass('col-lg-6');
        $(pricePack_1).addClass('col-lg-4');
        $(pricePack_2).addClass('col-lg-4');
        let gold_pack = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(3) > div:nth-child(2)");
        $(gold_pack).removeClass('col-lg-6');
        $(gold_pack).addClass('col-lg-4');
        let pricesRow_again = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(2)");
        $(pricesRow_again).append(gold_pack.outerHTML);
        let secondPricesRow = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(3)");
        $(secondPricesRow).remove();
        let converterRow = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div.row.row-no-gutters");
        let footerNav = document.querySelector("body > nav.navbar.navbar-inverse.navbar-static-bottom");
        $(converterRow).remove();
        $(footerNav).remove();
        $('body').css({
            'background-color': 'black',
            'color': 'white'
        });
        $('tr').removeClass('active');
        let bottomPanel = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(3)");
        $(bottomPanel).css({
            'color': 'black'
        });
        let bottom_ad_1 = document.querySelector("body > ins:nth-child(21)");
        let bottom_ad_2 = document.querySelector("body > ins:nth-child(22)");
        let bottom_ad_3 = document.querySelector("body > div.GoogleActiveViewElement > div:nth-child(3)");
        let ad_4 = document.querySelector("body > ins:nth-child(20)");
        let ad_5 = document.querySelector("body > iframe:nth-child(19)");
        let ad_6 = document.querySelector("body > iframe:nth-child(18)");
        let ad_7 = document.querySelector("body > iframe:nth-child(17)");
        let ad_8 = document.querySelector("body > ins:nth-child(16)");
        let ad_9 = document.querySelector("body > iframe:nth-child(18)");
        let ad_10 = document.querySelector("body > iframe:nth-child(17)");
        let ad_11 = document.querySelector("body > ins:nth-child(16)");
        let ad_12 = document.querySelector("body > div.google-revocation-link-placeholder");
        let ad_13 = document.querySelector("body > div.google-revocation-link-placeholder");
        let ad_14 = document.querySelector("body > ins:nth-child(21)");
        $(bottom_ad_1).remove();
        $(bottom_ad_2).remove();
        $(bottom_ad_3).remove();
        $('tbody > tr:first-child').removeClass('info');
        $('tbody > tr:first-child').css({
            'background-color': '#24424d',
            'color': 'white',
            'font-weight': 'bold'
        });
        let first_table = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(2) > div:nth-child(1)");
        let usdTr = $(first_table).find('tbody').children('tr')[1];
        let usBuy = Number($(usdTr).find('td')[3].innerHTML);
        let usSell = Number($(usdTr).find('td')[2].innerHTML);
        let second_table = document.querySelector("body > div:nth-child(3) > div:nth-child(2) > div > div:nth-child(2) > div:nth-child(3)")
        console.log(usBuy);
        console.log(second_table);
        let dirhamTr = $(second_table).find('tbody').children('tr')[2];
        let dirhamBuy = Number($(dirhamTr).find('td')[3].innerHTML);
        let dirhamSell = Number($(dirhamTr).find('td')[2].innerHTML);
        let baharPriceTd = document.querySelector("#azadi12");
        let baharPrice = $(baharPriceTd).html();
        baharPrice = baharPrice.replace(/,/g, '');
        baharPrice = Number(baharPrice);
        let ounce = $(document.querySelector("#ounce")).html();
        ounce = Number(ounce.replace(/,/g, ''));
        function dollarByDirham(sellOrBuy) {
            if (sellOrBuy == 'sell') {
                return Math.floor(dirhamSell * 3.67);
            } else {
                return Math.floor(dirhamBuy * 3.67);
            }
        }
        function dollarByBahar(sellOrBuy) {
            if (sellOrBuy == 'sell') {
                return Math.floor((baharPrice/ounce)*4.2);
            } else {
                return Math.floor((baharPrice/ounce)*4);
            }
        }
        let usdTrText = $(usdTr)[0].outerHTML;
        let usdTr_sample = `
        <tr>
		    <td>
                <a href="/graph/usd"><img class="code-logo" style="background:url(/images/global.png) -144px -12px" alt="USD" src="/images/img_trans.gif">
                    USD
                </a>
            </td>
            <td>
                US Dollar
            </td>
            <td id="usd1" class="same_val">
                60850
            </td>
            <td id="usd2" class="same_val">
                60750
            </td>
        </tr>
        `;
        let usdTrByDirham = `
        <tr style="background-color: #20364b">
		    <td>
                <a href="/graph/usd"><img class="code-logo" style="background:url(/images/global.png) -144px -12px" alt="USD" src="/images/img_trans.gif">
                    USD
                </a>
            </td>
            <td>
                calculated by Dirham
            </td>
            <td id="usd1" class="same_val">
                ${dollarByDirham('sell')}
            </td>
            <td id="usd2" class="same_val">
                ${dollarByDirham('buy')}
            </td>
        </tr>
        `;
        let usdTrByBahar = `
        <tr style="background-color: #222f59">
		    <td>
                <a href="/graph/usd"><img class="code-logo" style="background:url(/images/global.png) -144px -12px" alt="USD" src="/images/img_trans.gif">
                    USD
                </a>
            </td>
            <td>
                calculated by Bahar
            </td>
            <td id="usd1" class="same_val">
                ${dollarByBahar('sell')}
            </td>
            <td id="usd2" class="same_val">
                ${dollarByBahar('buy')}
            </td>
        </tr>
        `;
        $(usdTr).after(usdTrByBahar);
        $(usdTr).after(usdTrByDirham);
    }, 5000);
})();