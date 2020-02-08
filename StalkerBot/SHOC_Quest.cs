using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace StalkerBot
{
    public partial class StalkerBot
    {
        async void shoc(TelegramBotClient Bot, CallbackQueryEventArgs cqea)
        {
            string folder = path + "/res/shoc/";

            var message = cqea.CallbackQuery.Message;
            var ChatId = message.Chat.Id;

            await Bot.AnswerCallbackQueryAsync(cqea.CallbackQuery.Id);

            switch (cqea.CallbackQuery.Data)
            {
                case "shocnew":
                    await Bot.SendTextMessageAsync(ChatId, "Сервер: Старт");
                    await Bot.SendTextMessageAsync(ChatId, "Створення нової гри");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження шейдерів");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження геометрії");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження бази просторів");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження форми об'єктів");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження детальних об'єктів");
                    await Bot.SendTextMessageAsync(ChatId, "Кешування об'єктів");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження симуляції життя");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження ШІ об'єктів");
                    await Bot.SendTextMessageAsync(ChatId, "Завантаження текстур");
                    await Bot.SendTextMessageAsync(ChatId, "Клієнт: Синхронізація");

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "intro_l01_escape.jpg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Почати", "start") }));
                    break;

                case "start":
                    await Bot.SendVideoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "intro_stalker.mp4")).Content);
                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_monolog1.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader1b.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти", "escape_trader_walk"), InlineKeyboardButton.WithCallbackData("Не підходити", "escape_trader_stay") }));

                    break;

                case "escape_trader_walk":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_start_dialog_3.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Досвідчений", "escape_trader_experienced"), InlineKeyboardButton.WithCallbackData("Новачок", "escape_trader_novice") }));
                    break;

                case "escape_trader_stay":
                    switch (R.Next(0, 4))
                    {
                        case 0:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_script1b_3.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти", "escape_trader_walk"), InlineKeyboardButton.WithCallbackData("Не підходити", "escape_trader_stay") }));
                            break;

                        case 1:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_script1b_4.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти", "escape_trader_walk"), InlineKeyboardButton.WithCallbackData("Не підходити", "escape_trader_stay") }));
                            break;

                        case 2:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_script1b_5.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти", "escape_trader_walk"), InlineKeyboardButton.WithCallbackData("Не підходити", "escape_trader_stay") }));
                            break;

                        case 3:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_tutorial_rejection_4.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти", "escape_trader_walk"), InlineKeyboardButton.WithCallbackData("Не підходити", "escape_trader_stay") }));
                            break;
                    }
                    break;

                case "escape_trader_experienced":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_start_dialog_111.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Піти до табору новачків", "escape_trader_goto_village_first") }));
                    break;

                case "escape_trader_novice":
                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "ui_pda.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_tutorial_pda_1.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_tutorial_pda_on_1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("…", "escape_trader_tutorial_pda_on") }));

                    break;

                case "escape_trader_tutorial_pda_on":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_tutorial_pda_on_4.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Я запам'ятав", "escape_trader_experienced") }));
                    break;

                case "escape_trader_goto_village_first":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_servomotor.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_start.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_script1c_5.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_closing.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_stop.ogg")).Content);

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_wolf_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "wolf_thanks_1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти до Вовка", "escape_wolf_hello_respond"), InlineKeyboardButton.WithCallbackData("Сісти біля вогнища", "escape_wolf_hello_notresponded") }));

                    break;

                case "escape_wolf_hello_notresponded":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/fire/fire2.ogg")).Content);

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "stalker_novice_" + R.Next(1, 6).ToString() + ".png")).Content);

                    switch (R.Next(1, 7))
                    {
                        case 1:
                        case 2:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_" + R.Next(1, 4).ToString() + "/novice/intro_music_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/fire/guitar_" + R.Next(1, 12).ToString() + ".ogg")).Content);
                            break;

                        case 3:
                            switch (R.Next(1, 4))
                            {
                                case 1:
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_1/novice/idle_" + R.Next(1, 40).ToString() + ".ogg")).Content);
                                    break;

                                case 2:
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_2/novice/idle_" + R.Next(1, 39).ToString() + ".ogg")).Content);
                                    break;

                                case 3:
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_3/novice/idle_" + R.Next(1, 40).ToString() + ".ogg")).Content);
                                    break;
                            }
                            break;

                        case 4:
                        case 5:
                        case 6:
                            switch (R.Next(1, 4))
                            {
                                case 1:
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_1/novice/intro_joke_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_1/novice/joke_" + R.Next(1, 14).ToString() + ".ogg")).Content);
                                    break;

                                case 2:
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_2/novice/intro_joke_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_2/novice/joke_" + R.Next(1, 16).ToString() + ".ogg")).Content);
                                    break;

                                case 3:
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_3/novice/intro_joke_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_3/novice/joke_" + R.Next(1, 14).ToString() + ".ogg")).Content);
                                    break;
                            }
                            break;
                    }

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_wolf_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "wolf_thanks_1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти до Вовка", "escape_wolf_hello_respond"), InlineKeyboardButton.WithCallbackData("Сидіти біля вогнища", "escape_wolf_hello_notresponded") }));

                    break;

                case "escape_wolf_hello_respond":
                    await Bot.SendTextMessageAsync(ChatId, "Привіт. Навіщо прийшов?", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Привіт. Мені потрібен Спритник. Не підкажеш, де його знайти?", "escape_lager_volk_talk_111") }));
                    break;

                case "escape_lager_volk_talk_111":
                    await Bot.SendTextMessageAsync(ChatId, "Зі Спритником кепсько... Тут неподалік на його групу бандити напали й забрали Спритника із собою - він тільки і встиг, що SOS скинути. Його напарники, схоже, накрилися. Хлопці повідомили, що бандюки зараз у старому АТП, що за дорогою.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Ви своїх із полону не визволяєте? Якось не по-дружньому... Чи боїтеся?", "escape_lager_volk_talk_11111") }));
                    break;

                case "escape_lager_volk_talk_11111":
                    await Bot.SendTextMessageAsync(ChatId, "Ет, врізати б тобі по пиці… але користі не буде. Не так усе просто. Людей у мене мало, та й не люди - суцільні новачки. Не можу я ризикувати. Якщо ми цей табір втратимо, усім нормальним сталкерам буде зле. А ти сам що? Якщо не боїшся, від допомоги не відмовлюся, не гордий. То як, допоможеш із бандюками розібратися?", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Пропонуєш мені самому?", "escape_lager_volk_talk_1111111") }));
                    break;

                case "escape_lager_volk_talk_1111111":
                    await Bot.SendTextMessageAsync(ChatId, "Та ні, так нічого в тебе не вийде. Розвідники мої - бійці що треба. Зараз вони саме тих виродків пасуть. Разом ви, у принципі, маєте непогані шанси. Ну то що? Чи боїшся?", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Я спробую.", "escape_lager_volk_talk_111111111"), InlineKeyboardButton.WithCallbackData("Не боюся. Але не піду.", "escape_lager_volk_talk_111111112") }));
                    break;

                case "escape_lager_volk_talk_111111112":
                    await Bot.SendTextMessageAsync(ChatId, "Значить, таки боїшся... Ну й котися звідси до біса!", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Я спробую.", "escape_lager_volk_talk_111111111") }));
                    break;

                case "escape_lager_volk_talk_111111111":
                    await Bot.SendTextMessageAsync(ChatId, "Поважаю! Ось тобі зброя та припаси, а координати хлопців я вже скинув на твій КПК. Їх самих щодо тебе зараз попереджу.");
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "wolf_to_rangers.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "wolf_to_rangers_1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Відправитися до розвідників", "from_village_on_the_road") }));

                    break;

                case "from_village_on_the_road":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "megafon_1.ogg")).Content);

                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "helicopter.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "heli_radio_part_1.ogg")).Content);

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_tolic_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tolik_help_tutor_1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Дати аптечку", "escape_tolik_help"), InlineKeyboardButton.WithCallbackData("Забрати аптечку собі", "escape_tolik_nohelp") }));

                    break;

                case "escape_tolik_help":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tolik_thanks.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Бувай", "escape_petruha_greetings") }));
                    break;

                case "escape_tolik_nohelp":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "death_4.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Обшукати труп", "escape_tolik_search") }));
                    break;

                case "escape_tolik_search":
                    await Bot.SendTextMessageAsync(ChatId, "КПК Толіка");
                    await Bot.SendTextMessageAsync(ChatId, "Щоденник Толіка: «Крамар послав стежити за військовими на НДІ «Агропром». Туди приперлися, усіх постріляли, бандитів і військових. Нарили щось цікаве, інше передаю шифром *абракадабра, типу шифр*.»", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Іти далі", "escape_petruha_greetings") }));
                    break;

                case "escape_petruha_greetings":
                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_petruha_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "petruha_call.ogg")).Content);
                    await Bot.SendTextMessageAsync(ChatId, "Привіт, друже. Вовк нас уже попередив. Якісь додаткові питання є?", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Так. Скільки бандитів у таборі?", "escape_factory_assault_start_311") }));

                    break;

                case "escape_factory_assault_start_311":
                    await Bot.SendTextMessageAsync(ChatId, "Семеро-восьмеро. Двоє біля воріт, двоє у будівлі справа біля багаття, двоє у будівлі ліворуч - там і Спритника тримають. Ще двором час від часу хтось швендяє... а так наче й усе. Ну що, почнемо із Богом?", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Почнемо. Піднімай своїх.", "escape_factory_assault_start_31111") }));
                    break;

                case "escape_factory_assault_start_31111":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "assault_raid.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "assault_attack.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "assault_go_1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Вперед!", "assault_attack") }));

                    break;

                case "assault_attack":
                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit_novice_" + R.Next(1, 5).ToString() + ".png")).Content);

                    switch (R.Next(1, 3))
                    {
                        case 1:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit/detour_" + R.Next(1, 7).ToString() + ".ogg")).Content);
                            break;

                        case 2:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit/attack_many_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                            break;
                    }

                    switch (R.Next(1, 3))
                    {
                        case 1:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "pm_shoot.ogg")).Content);
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "t_pm_shot.ogg")).Content);
                            break;

                        case 2:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "toz34_shoot.ogg")).Content);
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tm_toz34_shot.ogg")).Content);
                            break;
                    }

                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "whine_3.ogg")).Content);

                    for (int i = 1; i < 4; ++i)
                    {
                        switch (R.Next(1, 3))
                        {
                            case 1:
                                await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit_novice_" + R.Next(1, 5).ToString() + ".png")).Content);

                                switch (R.Next(1, 3))
                                {
                                    case 1:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit/detour_" + R.Next(1, 7).ToString() + ".ogg")).Content);
                                        break;

                                    case 2:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit/attack_many_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                                        break;
                                }

                                switch (R.Next(1, 3))
                                {
                                    case 1:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "pm_shoot.ogg")).Content);
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "t_pm_shot.ogg")).Content);
                                        break;

                                    case 2:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "toz34_shoot.ogg")).Content);
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tm_toz34_shot.ogg")).Content);
                                        break;
                                }

                                await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "whine_" + i.ToString() + ".ogg")).Content);
                                break;

                            case 2:
                                await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "stalker_novice_" + R.Next(1, 6).ToString() + ".png")).Content);

                                switch (R.Next(1, 4))
                                {
                                    case 1:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_1/novice/attack_many_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                                        break;

                                    case 2:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_2/novice/attack_many_" + R.Next(1, 7).ToString() + ".ogg")).Content);
                                        break;

                                    case 3:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_3/novice/attack_many_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                                        break;
                                }

                                switch (R.Next(1, 3))
                                {
                                    case 1:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "pm_shoot.ogg")).Content);
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "t_pm_shot.ogg")).Content);
                                        break;

                                    case 2:
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "toz34_shoot.ogg")).Content);
                                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tm_toz34_shot.ogg")).Content);
                                        break;
                                }

                                await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit_novice_" + R.Next(1, 5).ToString() + ".png")).Content);
                                await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/bandit/death_" + R.Next(1, 11).ToString() + ".ogg")).Content);

                                break;
                        }
                    }

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "stalker_novice_" + R.Next(1, 6).ToString() + ".png")).Content);

                    switch (R.Next(1, 4))
                    {
                        case 1:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_1/novice/attack_many_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                            break;

                        case 2:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_2/novice/attack_many_" + R.Next(1, 7).ToString() + ".ogg")).Content);
                            break;

                        case 3:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/stalker_3/novice/attack_many_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                            break;
                    }

                    switch (R.Next(1, 3))
                    {
                        case 1:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "pm_shoot.ogg")).Content);
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "t_pm_shot.ogg")).Content);
                            break;

                        case 2:
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "toz34_shoot.ogg")).Content);
                            await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tm_toz34_shot.ogg")).Content);
                            break;
                    }

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bandit_novice_" + R.Next(1, 5).ToString() + ".png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/bandit/death_" + R.Next(1, 11).ToString() + ".ogg")).Content);

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_petruha_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "assault_victory.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Перемога!", "assault_victory") }));
                    break;

                case "assault_victory":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "petruha_raport_p.ogg")).Content);

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_shustryi_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "shustryi_asked_3.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Визволити Спритника", "shustryi_asked") }));

                    break;

                case "shustryi_asked":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "shustryi_thanks.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Слухай, мені потрібна флешка, котру ти ніс Крамарові. Вона при тобі?", "escape_shustryi_start_111") }));
                    break;

                case "escape_shustryi_start_111":
                    await Bot.SendTextMessageAsync(ChatId, "Є таке діло... Флешка була надійно захована, а ці бики навіть обшукувати як слід не вміють. А, добре, забирай! Ти мені, як не як, життя врятував.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Спасибі. А де ти її ховав? Мало що - може, придасться коли.", "escape_shustryi_start_11111") }));
                    break;

                case "escape_shustryi_start_11111":
                    await Bot.SendTextMessageAsync(ChatId, "Не нижче пояса, не бійсь. Я давно на Крамара працюю, ховати інфу вмію!", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Відправитися до Сидоровича", "from_shustryi_to_bunker") }));
                    break;

                case "from_shustryi_to_bunker":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_start.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_closing.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_stop.ogg")).Content);

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_script1a_5.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Притягнув флешку", "escape_trader_start_dialog_521111") }));
                    break;

                case "escape_trader_start_dialog_521111":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_script1c_6.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_jobs_6.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Припустимо", "escape_trader_jobs_6") }));
                    break;

                case "escape_trader_jobs_6":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_jobs_611.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Згода", "escape_trader_jobs_611") }));
                    break;

                case "escape_trader_jobs_611":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_jobs_61111.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Продовжуй", "escape_trader_jobs_61111") }));
                    break;

                case "escape_trader_jobs_61111":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_jobs_6111111.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Так", "escape_trader_jobs_6111111") }));
                    break;

                case "escape_trader_jobs_6111111":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_jobs_611111111.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Відправитися у серйозну вилазку", "escape_trader_goto_bridge") }));
                    break;

                case "escape_trader_goto_bridge":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_start.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_script1c_5.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_closing.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "door_stop.ogg")).Content);

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_kuznetsov_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bridge_soldier.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Підійти", "escape_kuznetsov") }));

                    break;

                case "escape_kuznetsov":
                    await Bot.SendTextMessageAsync(ChatId, "Тут прохід заборонено, сталкер.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Мені треба далі.", "esc_bridge_soldiers_start_12") }));
                    break;

                case "esc_bridge_soldiers_start_12":
                    await Bot.SendTextMessageAsync(ChatId, "А не можна!\nАле як дуже хочеться... то можна. Наприклад, за п'ятсот грошових одиниць.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Тримай.", "esc_bridge_soldiers_start_14"), InlineKeyboardButton.WithCallbackData("Грошей у мене немає.", "esc_bridge_soldiers_start_24") }));
                    break;

                case "esc_bridge_soldiers_start_14":
                    await Bot.SendTextMessageAsync(ChatId, "Тепер слухай сюди. Ми годину робимо вигляд, що крім комарів та метеликів тут нічого не пурхало. А далі - вибачай.");
                    await Bot.SendTextMessageAsync(ChatId, "Вали, вали звідси! Не затримуйся, поки ми добрі.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Перетнути блокпост", "esc_bridge_crossed") }));
                    break;

                case "esc_bridge_soldiers_start_24":
                    await Bot.SendTextMessageAsync(ChatId, "Тоді гуляй туди, звідки прийшов. Розживешся - приходь. А вирішиш пробратися нишком - як собаку пристрелимо.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Піти на захід", "esc_bridge_west"), InlineKeyboardButton.WithCallbackData("Піти на схід", "esc_bridge_east") }));
                    break;

                case "esc_bridge_east":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "geiger_8.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "geiger_8.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Пролізти крізь дірку в паркані", "esc_bridge_crossed") }));
                    break;

                case "esc_bridge_west":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "da-2_beep1.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "da-2_beep1.ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "electra_idle1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Обшукати труп біля аномалії", "esc_bridge_west_body") }));
                    break;

                case "esc_bridge_west_body":
                    await Bot.SendTextMessageAsync(ChatId, "У КПК загиблого сталкера Ви знайшли його спостереження за аномаліями в тунелі. Виявляється, він знайшов закономірність у їхній роботі.");
                    await Bot.SendTextMessageAsync(ChatId, "Тут якась дуже дивна аномалія. Схоже, що вона пересувається. Я спробую обчислити її траєкторію та час переміщення, бо платити солдатам на мосту за прохід у мене грошей не стане.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Пройти тунелем", "esc_bridge_crossed") }));
                    break;

                case "esc_bridge_crossed":
                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/escape_trader_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "/escape_trader/trader_pda_fox.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Допомогти Лисові", "esc_pda_fox_help") }));
                    break;

                case "esc_pda_fox_help":
                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_fox_icon.png")).Content);
                    await Bot.SendTextMessageAsync(ChatId, "Сталкере, аптечку! Дай аптечку!", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("На, тримай.", "escape_fox_hello_dialog_55"), InlineKeyboardButton.WithCallbackData("Немає в мене аптечки. Вибач.", "escape_fox_hello_dialog_56") }));
                    break;

                case "escape_fox_hello_dialog_55":
                    await Bot.SendTextMessageAsync(ChatId, "Спасибі.");
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "fox_alert.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Я допоможу", "esc_fox_help") }));
                    break;

                case "escape_fox_hello_dialog_56":
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "death_1.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Обшукати труп", "esc_fox_search_body") }));
                    break;

                case "esc_fox_search_body":
                    await Bot.SendTextMessageAsync(ChatId, "КПК Лиса");
                    await Bot.SendTextMessageAsync(ChatId, "Сірий - Лисові: «Один знайомий попрохав зустріти групу сталкерів, які розкопали схованку Стрільця. Я буду зі своїми людьми на Смітнику в ангарі, то як щось станеться - підходь.»", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Відправитися на смітник", "the_end") }));
                    break;

                case "esc_fox_help":
                    for (int i = 0; i < 2; ++i)
                    {
                        await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "blind_dog_" + R.Next(1, 4).ToString() + ".png")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bdog_groan_" + R.Next(0, 4).ToString() + ".ogg")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bdog_attack_" + R.Next(0, 3).ToString() + ".ogg")).Content);

                        await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_fox_icon.png")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "toz34_shoot.ogg")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tm_toz34_shot.ogg")).Content);

                        await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "blind_dog_" + R.Next(1, 4).ToString() + ".png")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "bdog_die_" + R.Next(0, 4).ToString() + ".ogg")).Content);
                    }

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_fox_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "fox_thanks.ogg")).Content);
                    await Bot.SendTextMessageAsync(ChatId, "Спасибі. \nТак, тепер я тебе уважно слухаю.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Крамар сказав, що в тебе є інформація про Стрільця.", "escape_fox_hello_dialog_31") }));
                    break;

                case "escape_fox_hello_dialog_31":
                    await Bot.SendTextMessageAsync(ChatId, "І чого це тим Стрільцем усі в останній час зацікавилися? Ну, сказати, що я його особисто знав - то збрехав би, не було такого. Досвід спілкування, щоправда, деякий є: якось його група моїх хлопців обстріляла. Ніхто не постраждав, бо вони явно на інших чекали, тож далі розійшлися мирно. Поматюкали одне одного через яр, та й розійшлися. Сірий, мій братуха, зараз в ангарі на Смітнику - я тобі скину координати. Він про Стрільця більше знає. \nНа виході обережніше: там бандитська компанія засіла. До речі, тут за мною мутанти гналися, і не думаю, щоб вони вгамувалися. Не допоможеш мені їх відстріляти? Раз-два, та й по всьому...", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Спасибі за інформацію, врахую.", "escape_fox_hello_dialog_3111") }));
                    break;

                case "escape_fox_hello_dialog_3111":
                    for (int i = 0; i < 2; ++i)
                    {
                        await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "boar_" + R.Next(1, 3).ToString() + ".png")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "boar_aggressive_" + R.Next(0, 4).ToString() + ".ogg")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "boar_attack_" + R.Next(0, 3).ToString() + ".ogg")).Content);

                        await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_fox_icon.png")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "toz34_shoot.ogg")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "tm_toz34_shot.ogg")).Content);

                        await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "boar_" + R.Next(1, 3).ToString() + ".png")).Content);
                        await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "boar_death_" + R.Next(0, 4).ToString() + ".ogg")).Content);
                    }

                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "escape_fox_icon.png")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "fox_thanks.ogg")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("…", "escape_fox_thanks_again") }));
                    break;

                case "escape_fox_thanks_again":
                    await Bot.SendTextMessageAsync(ChatId, "Чуєш, приятелю… ти мене двічі уже виручив, а я таких речей не забуваю. Тримай ось. Як то кажуть, чим багатий!..");
                    await Bot.SendPhotoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "fox_thanks_inv.png")).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Відправитися на смітник", "the_end") }));
                    break;

                case "the_end":
                    await Bot.SendVideoAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "outro_stalker.gif")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(System.IO.File.OpenRead(folder + "magnitofon_2.ogg")).Content);
                    await Bot.SendTextMessageAsync(ChatId, "На цьому все. Сподіваюсь, вам сподобалося грати. Наразі це всього лише концепт, і невідомо, чи буде коли-небудь фінальна версія гри. Проте, ви можете написати свої відгуки мені, @taybenberg. Можливо, саме ваше добре або зле слово змотивує мене надалі працювати над сталкерською функцією @TheElderUkrainianBot. Ну що, вдалого тобі полювання сталкере! Хоча, хто зна, що для тебе краще...");

                    break;
            }
        }
    }
}