using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;

namespace HackathonJonnhyBot.Dialogs
{

    [LuisModel("f622194b-3878-43ae-a10e-c19ea18bf256", "f38bf4995495414c85df9ec1071192d9")]
    [Serializable]
    public class MeBotLuisDialog : LuisDialog<object>
    {

        private int rndFactor01 = new Random().Next(1, 5);
        private int rndFactor02 = new Random().Next(1, 10);

        public int rating = 0;

        public int flagGreetingDone = 0;
        public int flagCityInformed = 0;
        public int flagAgeInformed = 0;
        public int flagStateInformed = 0;

        public int flagCityObtained = 0;
        public int flagAgeObtained = 0;
        public int flagStateObtained = 0;

        public int flagSexualLevel = 0;
        public int flagInformalLevel = 0;
        public int flagMispellingLevel = 0;

        //- Bravo  + Feliz
        public int flagEmotionalLevel = 0;

        public MeBotLuisDialog()
        {



        }


        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {

            checkHumorChanges();

            string resp = "";
            if (rndFactor02 == 1) resp = "naum entendi";
            if (rndFactor02 == 2) resp = "???";
            if (rndFactor02 == 3) resp = "oi? ta doido kkk";
            if (rndFactor02 == 4) resp = "que isso? kkk";
            if (rndFactor02 == 5) resp = "ixi";
            if (rndFactor02 >= 6) resp = "nao entendi";
            if (rndFactor02 >= 7) resp = "";

            if (resp != "")
            {
                await context.PostAsync(resp);
                context.Wait(MessageReceived);
            }

        }










        // Saudacao direta sem resposta especifica
        [LuisIntent("saudacao01")]
        public async Task Saudacao01(IDialogContext context, LuisResult result)
        {

            flagGreetingDone++;
            string resp = "";
            if (rndFactor01 == 1) resp = "oiiii";
            if (rndFactor01 == 2) resp = ":*";
            if (rndFactor01 == 3) resp = "ois";
            if (rndFactor01 == 4) resp = ":)";
            if (rndFactor01 == 5) resp = "oi";

            if (flagGreetingDone >= 3)
                resp = "zzz cansei de falar oi kkk";

            if (resp != "")
            {
                await context.PostAsync(resp);
                context.Wait(MessageReceived);
            }

        }

        // Saudacao02-09 -> Saudacao direta com resposta especifica
        [LuisIntent("saudacao02")]
        public async Task Saudacao02(IDialogContext context, LuisResult result)
        {

            await context.PostAsync("Tudo!");
            context.Wait(MessageReceived);
        }

        // Saudacao02-09 -> Saudacao direta com resposta especifica
        [LuisIntent("saudacao03")]
        public async Task Saudacao03(IDialogContext context, LuisResult result)
        {

            flagGreetingDone++;
            string resp = "";
            if (result.Query.IndexOf("noite") >= 0) resp = "boa noite";
            if (result.Query.IndexOf("tarde") >= 0) resp = "boa tarde";
            if (result.Query.IndexOf("dia") >= 0) resp = "bom dia";
            await context.PostAsync(resp);
            context.Wait(MessageReceived);
        }



        // Saudacao02-09 -> Saudacao direta com resposta especifica
        [LuisIntent("tcdeonde")]
        public async Task TcDeOnde(IDialogContext context, LuisResult result)
        {

            flagCityInformed++;
            await context.PostAsync("sao paulo");

            if (flagCityInformed >=2)
                await context.PostAsync("ja falei 3 vezes onde moro, vc naum ta prestando atencao");

            context.Wait(MessageReceived);
        }












        // Saudacao02-09 -> Saudacao direta com resposta especifica
        [LuisIntent("surpresa01")]
        public async Task surpresa01(IDialogContext context, LuisResult result)
        {

            string resp = "";
            if (rndFactor01 == 1) resp = "rs q foi?";
            if (rndFactor01 == 2) resp = "assustou pq?";
            if (rndFactor01 == 3) resp = "kkk te assustei?";
            if (rndFactor01 == 4) resp = "assustou :o";
            if (rndFactor01 >= 5) resp = "";

            if (resp != "")
            {
                await context.PostAsync(resp);
                context.Wait(MessageReceived);
            }
        }

        [LuisIntent("ocupada")]
        public async Task ocupada(IDialogContext context, LuisResult result)
        {

            string resp = "";
            if (rndFactor01 == 1) resp = "rs muita gente falando ao mesmo tempo eu me perco";
            if (rndFactor01 == 2) resp = "oi desulpaaaa rs";
            if (rndFactor01 == 3) resp = "rs me perdi no chat";
            if (rndFactor01 == 4) resp = "kkk mais ou menos muita gente tcnd";
            if (rndFactor01 >= 5) resp = "";

            if (resp != "")
            {
                await context.PostAsync(resp);
                context.Wait(MessageReceived);
            }
        }


        [LuisIntent("idade01")]
        public async Task idade01(IDialogContext context, LuisResult result)
        {

            string resp = "";
            resp = "14";
            if (flagAgeObtained == 0) resp = "14 e vc?";

            await context.PostAsync(resp);
            context.Wait(MessageReceived);

        }



        [LuisIntent("testedeturing01")]
        public async Task testedeturing01(IDialogContext context, LuisResult result)
        {

            string resp = "";
            resp = "nao to mentindo nao kkk";

            await context.PostAsync(resp);
            context.Wait(MessageReceived);

        }


        [LuisIntent("muitonova")]
        public async Task muitonova(IDialogContext context, LuisResult result)
        {

            string resp = "";
            resp = "rsrsrs nao sou nao";

            await context.PostAsync(resp);
            context.Wait(MessageReceived);

        }


        private void checkHumorChanges()
        {
            // Consulta o Watson para obter o tom da mensagem atual.

        }




    }

}