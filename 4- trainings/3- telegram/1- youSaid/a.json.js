let TOKEN = "6002859887:AAGUTnmypJY5s4dHPSeYcbCOOhlPf6KWZ_I"
let getMe = `https://api.telegram.org/bot${TOKEN}/getMe`
let getMeAnswer = 
{
    "ok":true,
    "result":{
        "id":6002859887,
        "is_bot":true,
        "first_name":"yousaid",
        "username":"yousaid_bot",
        "can_join_groups":true,
        "can_read_all_group_messages":false,
        "supports_inline_queries":false
    }
}
// before everything:
let getUpdates = `https://api.telegram.org/bot${TOKEN}/getUpdates`;
let getUpdatesAnswer = 
{
    "ok":true,
    "result":[]
}
// after click start:
let getUpdatesAnswer2 = // updates show user
{
    "ok":true,
    "result":
        [
            {
                "update_id":740564749,
                "message":
                    {
                        "message_id":1,
                        "from":
                            {
                                "id":84880827,
                                "is_bot":false,
                                "first_name":"kia",
                                "username":"kia_nsx",
                                "language_code":"en"
                            },
                        "chat":
                            {
                                "id":84880827,
                                "first_name":"kia",
                                "username":"kia_nsx",
                                "type":"private"
                            },
                        "date":1685807585,
                        "text":"/start",
                        "entities":
                            [
                                {
                                    "offset":0,
                                    "length":6,
                                    "type":"bot_command"
                                }
                            ]
                    }
            }
        ]
}
// after say hello from bot to user:
let sendMessage = `https://api.telegram.org/bot${TOKEN}/sendMessage?chat_id=84880827&text=hello`;
let sendMessageAnswer =
{
    "ok":true,
    "result":
        {
            "message_id":2,
            "from":
                {
                    "id":6002859887,
                    "is_bot":true,
                    "first_name":"yousaid",
                    "username":"yousaid_bot"
                },
            "chat":
                {
                    "id":84880827,
                    "first_name":"kia",
                    "username":"kia_nsx",
                    "type":"private"
                },
            "date":1685808224,
            "text":"hello"
        }
}
// now lets see getUpdates again:
let getUpdatesAnswer3 = // same as getUpdatesAnswer2=> so updates just get "user actions" not bot actions
{
    "ok":true,
    "result":
    [
        {
            "update_id":740564749,
            "message":
            {
                "message_id":1,
                "from":
                    {
                        "id":84880827,
                        "is_bot":false,
                        "first_name":"kia",
                        "username":"kia_nsx",
                        "language_code":"en"
                    },
                "chat":
                    {
                        "id":84880827,
                        "first_name":"kia",
                        "username":"kia_nsx",
                        "type":"private"
                    },
                "date":1685807585,
                "text":"/start",
                "entities":
                    [
                        {
                            "offset":0,
                            "length":6,
                            "type":"bot_command"
                        }
                    ]
            }
        }
    ]
}
// get webhook info:
let getwh = `https://api.telegram.org/bot${TOKEN}/getWebhookInfo`;
let getwhAnswer = 
{
    "ok":true,
    "result":
        {
            "url":"",
            "has_custom_certificate":false,
            "pending_update_count":1
        }
}
// set webhook info:
let setwh = `https://api.telegram.org/bot${TOKEN}/setWebhook?url=https://abeb-5-208-20-84.ngrok-free.app`;
let setwhAnswer =
{
    "ok":true,
    "result":true,
    "description":"Webhook was set"
}
// now again get wh info:
let getwh2 = `"...`;
let getwh2Answer =
{
    "ok":true,
    "result":
        {
            "url":"https://abeb-5-208-20-84.ngrok-free.app",
            "has_custom_certificate":false,
            "pending_update_count":1,
            "last_error_date":1685813066,
            "last_error_message":"Wrong response from the webhook: 404 Not Found",
            "max_connections":40,
            "ip_address":"3.125.209.94"
        }
}
// post with curl:
let pwCurl = 
{
    "ok":true,
    "result":
        {
            "message_id":15,
            "from":
                {
                    "id":6002859887,
                    "is_bot":true,
                    "first_name":"yousaid",
                    "username":"yousaid_bot"
                },
            "chat":
                {
                    "id":84880827,
                    "first_name":"kia",
                    "username":"kia_nsx",
                    "type":"private"
                },
            "date":1685886696,
            "text":"hello from php"
    }
}