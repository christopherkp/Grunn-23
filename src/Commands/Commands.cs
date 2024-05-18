using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace _UnderwaterBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

        // Some trivial commands for later use or removal

        [Command("image")]
        public async Task Image() // Posts a picture from the internet
        {
            var embed = new EmbedBuilder();
            embed.WithImageUrl(""); // Link goes here

            await Context.Channel.SendMessageAsync("", false, embed.Build());

        }

        [Command("who")]
        public async Task Who() // Shows the user that sent the command
        {
            var embed = new EmbedBuilder();
            embed.WithFooter($"Command sent by {Context.User.Username}", Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, embed.Build());

        }

        [Command("gofish")]
        public async Task GoFish()
        {
            var embed = new EmbedBuilder();
            embed.WithDescription("You swung your rod and got a Koi!");
            embed.WithFooter($"{Context.User.Username} went fishing, and got a Koi!", Context.User.GetAvatarUrl());
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }

        [Command("avatar")]
        public async Task Avatar(SocketUser user) // Posts the avatar of tagged user
        {
            var embed = new EmbedBuilder();
            embed.WithImageUrl(user.GetAvatarUrl());
            // Reply only with the avatar of the user that issued the command
            // embed.WithImageUrl(Context.User.GetAvatarUrl());


            await Context.Channel.SendMessageAsync("", false, embed.Build());

        }

        [Command("tag")]
        public async Task Hello(SocketUser user) // Tags another user
        {

            await Context.Channel.SendMessageAsync($"You awake {user.Mention}?");

        }

        [Command("roll")]
        public async Task Roll() // Rolls a random number
        {
            Random roll = new Random();
            int rolling = roll.Next(1, 101);

            if (rolling != 100)
            {
                await Context.Channel.SendMessageAsync($"You rolled {rolling}!");
            }


            if (rolling == 100)
            {
                var embed = new EmbedBuilder();
                embed.WithImageUrl(" ");
                await Context.Channel.SendMessageAsync($"You rolled {rolling} RIGGED", false, embed.Build());
            }

        }

        [Command("flip")]
        public async Task Flip() // Flips a coin
        {
            Random flip = new Random();
            int flips = flip.Next(1, 3);

            if (flips == 1)
            {
                await Context.Channel.SendMessageAsync("Heads");
            }

            else

                await Context.Channel.SendMessageAsync("Tails");

        }
    }
}

