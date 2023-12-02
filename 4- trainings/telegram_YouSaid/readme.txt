TOKEN:
6002859887:AAGUTnmypJY5s4dHPSeYcbCOOhlPf6KWZ_I

1- test your bot token
2- get your webhook information


1- botfather => /newbot => botname => get your token
yourToken = yourID:randomText
yourAPI = "api.telegram.org/bot" + yourToken

2- 
• yourAPI/getMe => {ok:true/false, result:json} 
i believe the result is a decoded json of yourToken
• any request has been sent to your bot can be inspected in:
yourAPI/getUpdates
• yourAPI/sendMessage?chat_id=xxx&text=helloFromBot
• yourAPI/getWebhookinfo
• yourAPI/setWebhook?url=ngrok

3- ngrok http 3000

now this is how everything works:

1- a user asks from to yourAPI by sending reqs to yourAPI
2- yourAPI (telegram) will ask you what to do by sending reqs to it's webhook(on ngrok)
3- ngrok will forward the message to your local php
4- your local php will send back answer by sending reqs to yourAPI again
                                _______
localhost:3000<-----Ngrok<-----|yourAPI|<------user
                     _______    ‾‾‾‾‾‾‾
localhost:3000----->|yourAPI|----->user
                     ‾‾‾‾‾‾‾

you will send reqs to yourAPI by php utilities (like curl);
telegram will ask you what to do 