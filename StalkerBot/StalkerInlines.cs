using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InlineQueryResults;

namespace StalkerBot
{
    public partial class StalkerBot
    {
        async void inlineQuery(TelegramBotClient Bot, InlineQueryEventArgs iqea)
        {
            await Bot.AnswerInlineQueryAsync(iqea.InlineQuery.Id, new InlineQueryResultVoice[]
            {
                new InlineQueryResultVoice("0",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152630&authkey=ANEl5SuhOYpHpJk",
                    "Cheeki breeki radio"),

                new InlineQueryResultVoice("1",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152934&authkey=AIgJ96vtXRW-VuQ",
                    "Anuu cheeki breeki i v damke"),

                new InlineQueryResultVoice("2",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152933&authkey=ADNsV2n4PTAiCLM",
                    "Mliaa ia masleenu poimal"),

                new InlineQueryResultVoice("3",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152932&authkey=ABCFW63kzL2ndg0",
                    "Ia dyriavyj"),

                new InlineQueryResultVoice("4",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152931&authkey=ANrToz9xGca6CLQ",
                    "Aii mliaa"),

                new InlineQueryResultVoice("5",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152960&authkey=ABsq02_kaeN5VfA",
                    "Malacca"),

                new InlineQueryResultVoice("6",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152963&authkey=AGLstjZiSF4n6gI",
                    "Eii aleen'"),

                new InlineQueryResultVoice("7",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152961&authkey=AMM4GrYP82jyYHc",
                    "Kandeeha veselei"),

                new InlineQueryResultVoice("8",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152962&authkey=ALFiAEmgQg7qSCI",
                    "Shelupoon'"),

                new InlineQueryResultVoice("9",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152969&authkey=AAr0FEWkEUDOtfg",
                    "Ia ne poniav"),

                new InlineQueryResultVoice("10",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152968&authkey=ABaBUnrLVneYc84",
                    "Ty kudy kydaiesh scooqa"),

                new InlineQueryResultVoice("11",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152967&authkey=ADvID-ferSydH9E",
                    "Bushlat derevianyi"),

                new InlineQueryResultVoice("12",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152966&authkey=AMSVLMKu-_PDTiA",
                    "Ty sho ofonarel"),

                new InlineQueryResultVoice("13",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152965&authkey=ANPtGVyVz3uAJfc",
                    "Nu ty j looh"),

                new InlineQueryResultVoice("14",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152973&authkey=AMVgs1cIdeMTKVc",
                    "Ia taschuus'"),

                new InlineQueryResultVoice("15",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152971&authkey=AG_6E7V_eCjvTwU",
                    "Ty v nature plesen'"),

                new InlineQueryResultVoice("16",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152972&authkey=ANepo45Qw0Rj2l4",
                    "Smeschno priam nymagu"),

                new InlineQueryResultVoice("17",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152975&authkey=AIU0UKqbL7YxNDo",
                    "Loh pa zhyzni"),

                new InlineQueryResultVoice("18",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152982&authkey=ABxSHxbRaE_KwK4",
                    "Karoche tipa ot cho"),

                new InlineQueryResultVoice("19",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152983&authkey=AAFG5aRkulmtcLg",
                    "Scha scha ia zbaccaiu"),

                new InlineQueryResultVoice("20",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152976&authkey=AJPmBte1ulcW3qU",
                    "Zhyrno zhyrno"),

                new InlineQueryResultVoice("21",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152980&authkey=AEREA5EjXo7axss",
                    "Aaa skateena"),

                new InlineQueryResultVoice("22",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152979&authkey=AHT_9gQt4MzoIOc",
                    "Koresh meni zara ne do tiorok"),

                new InlineQueryResultVoice("23",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152978&authkey=ABd-uyT4Hha2_bE",
                    "Ssysysh odvaly"),

                new InlineQueryResultVoice("24",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152977&authkey=AKh2S9tL8lOcpLQ",
                    "Nie nu sho ty khlebalo rozkryv"),

                new InlineQueryResultVoice("25",
                    "https://onedrive.live.com/download?cid=DC5D1991291792D2&resid=DC5D1991291792D2%2152981&authkey=AHRpYOyLnQsbRE8",
                    "Raz dva vse dela")
            });
        }
    }
}