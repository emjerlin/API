using System;
using RestSharp;
using Newtonsoft.Json;


namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            int charSelect = 0;
            while (charSelect == 0){
            Console.WriteLine("Choose your character! Write any pokemon to find out more about it!");

            string userPokemon = Console.ReadLine();

            RestClient client = new RestClient("https://pokeapi.co/api/v2/");

            RestRequest request = new RestRequest("pokemon/" + userPokemon);

            IRestResponse response = client.Get(request);

            Pokemon poke = JsonConvert.DeserializeObject<Pokemon>(response.Content);
            //Eftersom jag endast tillåter att den spelar som en karaktär i taget, kan jag använda samma instans av klass. Den byter ut det som
            //var där innan

            Console.WriteLine("Name: " + poke.name);
            Console.WriteLine("ID: " + poke.id);
            Console.WriteLine("Weight: " + poke.weight);
            Console.WriteLine("Height: " + poke.height);

            int responseValid= 0;

            while (responseValid ==0){
            Console.WriteLine("Do you want to play as this pokemon? [y/n]");

            string playQ = Console.ReadLine();
            if (playQ =="y"){
                charSelect++;
                responseValid++;
            }
            else if(playQ =="n"){
                Console.WriteLine("Alright...");
                responseValid++;
            }
            else{
                Console.WriteLine("Please only write y or n");
            }
            }
            //denna api tillåter även att göra requests via deras id istället för namn
            Random generator = new Random();
            int random = generator.Next(1,898); //det finns 898 pokemon i denna api 
            RestRequest requestBot = new RestRequest("pokemon/" + random);
            IRestResponse responseBot = client.Get(requestBot);
            Pokemon pokeBot = JsonConvert.DeserializeObject<Pokemon>(responseBot.Content);

            Console.Clear();
            Console.WriteLine("Commencing match...");
            Console.WriteLine(poke.name + " VS " + pokeBot.name );
            Console.ReadLine();
            
        }
    }
}}
