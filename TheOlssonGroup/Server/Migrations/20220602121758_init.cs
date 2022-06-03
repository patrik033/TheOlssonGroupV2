using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheOlssonGroup.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ProductionYear = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOrdersDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOrdersDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOrdersDto_UserOrders_UserOrderId",
                        column: x => x.UserOrderId,
                        principalTable: "UserOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ebf560d-dec7-4e1f-acae-ab1a0d2148b7", "e3785046-c145-49ec-9078-e956d552d582", "Customer", "CUSTOMER" },
                    { "97858122-519a-40d6-845e-d5191267dce4", "130f2899-f256-4fbd-a8f5-038149b444cf", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7bd3e76d-6eb5-4dde-94b4-4bbd2e799614", 0, "e3014df7-eb94-4c03-a90d-ee85538c6d1e", "IdentityUser", "Admin@Olsson.com", true, false, null, null, null, null, null, false, "6649ab43-fa15-49c7-b8a6-f83b5197a7a7", false, "Admin@Olsson.com" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName", "GenreUrl" },
                values: new object[,]
                {
                    { 1, "Action", "action" },
                    { 2, "Sci-Fi", "sci-fi" },
                    { 3, "Drama", "drama" },
                    { 4, "Documentary", "documentary" },
                    { 5, "Comedy", "comedy" },
                    { 6, "Animé", "animé" },
                    { 7, "Horror", "horror" },
                    { 8, "Thriller", "thriller" },
                    { 9, "War", "war" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Featured", "GenreId", "LongDescription", "PosterImageUrl", "Price", "ProductionYear", "Rating", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 1, true, 1, "Over 10 years have passed since the first machine called The Terminator tried to kill Sarah Connor and her unborn son, John. The man who will become the future leader of the human resistance against the Machines is now a healthy young boy. However, another Terminator, called the T-1000, is sent back through time by the supercomputer Skynet. This new Terminator is more advanced and more powerful than its predecessor and its mission is to kill John Connor when he's still a child. However, Sarah and John do not have to face the threat of the T-1000 alone. Another Terminator(identical to the same model that tried and failed to kill Sarah Connor in 1984) is also sent back through time to protect them. Now, the battle for tomorrow has begun.", "/Images/ActionPosters/Terminator2poster.jpg", 17m, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.6f, "A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her ten-year-old son John from a more advanced and powerful cyborg.", "Terminator 2 Judgement day" },
                    { 2, false, 1, "When someone hacks into the computers at the FBI's Cyber Crime Division; the Director decides to round up all the hackers who could have done this. When he's told that because it's the 4th of July most of their agents are not around so they might have trouble getting people to get the hackers. So he instructs them to get local PD'S to take care of it. And one of the cops they ask is John McClane who is tasked with bringing a hacker named Farrell to the FBI. But as soon as he gets there someone starts shooting at them.McClane manages to get them out but they're still being pursued. And it's just when McClane arrives in Washington that the whole system breaks down and chaos ensues.", "/Images/ActionPosters/Live_Free_or_Die_Hard.jpg", 7m, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.1f, "John McClane and a young hacker join forces to take down master cyber-terrorist Thomas Gabriel in Washington D.C.", "Die hard 4 - Live Free Or Die Hard" },
                    { 3, true, 1, "John J.Rambo is a former United States Special Forces soldier who fought in Vietnam and won the Congressional Medal of Honor,but his time in Vietnam still haunts him. As he came to Hope, Washington to visit a friend,he was guided out of town by the Sheriff William Teasel who insults Rambo, but what Teasel does not know that his insult angered Rambo to the point where Rambo became violent and was arrested. As he was at the county jail being cleaned, he escapes and goes on a rampage through the forest to try to escape from the sheriffs who want to kill him. Then, as Rambo's commanding officer, Colonel Samuel Trautman tries to save both the Sheriff's department and Rambo before the situation gets out of hand.", "/Images/ActionPosters/First_blood_poster.jpg", 9m, new DateTime(1982, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7f, "A veteran Green Beret is forced by a cruel Sheriff and his deputies to flee into the mountains and wage an escalating one-man war against his pursuers.", "Rambo First Blood" },
                    { 4, false, 1, "Lara Croft (Alicia Vikander) is the fiercely independent daughter of eccentric adventurer Lord Richard Croft (Dominic West), who vanished when she was scarcely a teen.Now a young woman of twenty - one without any real focus or purpose, Lara navigates the chaotic streets of trendy East London as a bike courier, barely making the rent, and takes college courses, rarely making it to class. Determined to forge her own path, she refuses to take the reins of her father's global empire just as staunchly as she rejects the idea that he's truly gone. Advised to face the facts and move forward after seven years without him, even Lara can't understand what drives her to finally solve the puzzle of his mysterious death. Going explicitly against his final wishes, she leaves everything she knows behind in search of her dad's last-known destination: a fabled tomb on a mythical island that might be somewhere off the coast of Japan.But her mission will not be an easy one, just reaching the island will be extremely treacherous. Suddenly, the stakes couldn't be higher for Lara, who, against the odds and armed with only her sharp mind, blind faith, and inherently stubborn spirit, must learn to push herself beyond her limits as she journeys into the unknown.If she survives this perilous adventure, it could be the making of her, earning her the name tomb raider.", "/Images/ActionPosters/Tomb_Raider_(2018_film).png", 6m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.3f, "Lara Croft (Alicia Vikander), the fiercely independent daughter of a missing adventurer, must push herself beyond her limits when she discovers the island where her father,Lord Richard Croft(Dominic West) disappeared.", "Tomb Raider" },
                    { 5, false, 1, "Cameron Poe, a highly decorated Army Ranger, comes home to Alabama to his wife Tricia, to run into a few drunken regulars at the bar where she works. Cameron accidentally kills one of the drunks, and is sent to a federal penitentiary for involuntary manslaughter for seven years. He becomes eligible for parole and can now go home to his wife and daughter.Unfortunately, Cameron has to share a prison airplane with some of the country's most dangerous criminals, who take control of the plane and are now planning to escape the country. Cameron has to find a way to stop them while playing along.Meanwhile, United States Marshal Vince Larkin is trying to help Cameron get free and stop the criminals, led by Cyrus 'The Virus' Grissom", "/Images/ActionPosters/Conairinternational.jpg", 3m, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.9f, "Newly paroled ex-con and former U.S. Ranger Cameron Poe finds himself trapped in a prisoner transport plane when the passengers seize control.", "Con Air" },
                    { 6, false, 1, "Beyond the mists of time, having witnessed the brutal death of his blacksmith father and the massacre of the entire village by the murderous followers of Thulsa Doom,the undead evil wizard and servant of the serpent-god, Set, Conan, the orphaned young Cimmerian, is condemned to a life of slavery. Chained to the perpetual Wheel of Pain,the helpless boy grows into a man, and after years of rigorous training as a fierce gladiator, Conan, now an unstoppable mountain of muscle,regains his precious freedom. But, with the image of the blood-soaked raid etched on his mind, Conan teams up with Subotai, the Hyrkanian thief, and Valeria, the Queen of the Bandits,and embarks on a peril-laden journey to the mysterious Mountain of Power, and the impregnable Snake Cult Temple. Will Conan avenge his parents?", "/Images/ActionPosters/Conan_movie_psoter.jpg", 3m, new DateTime(1983, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.9f, "Short: A young boy, Conan, becomes a slave after his parents are killed and tribe destroyed by a savage warlord and sorcerer,Thulsa Doom.When he grows up he becomes a fearless, invincible fighter.Set free, he plots revenge against Thulsa Doom.", "Conan the barbarian" },
                    { 7, false, 2, "On the day of James T. Kirk's birth, his father dies on his damaged starship in a last stand against a Romulan mining vessel looking for Ambassador Spock, who in this time,has grown on Vulcan disdained by his neighbors for his half-human heritage. 25 years later,James T. Kirk has grown into a young rebellious troublemaker. Challenged by Captain Christopher Pike to realize his potential in Starfleet,he comes to annoy academy instructors like Commander Spock. Suddenly,there is an emergency on Vulcan and the newly-commissioned USS Enterprise is crewed with promising cadets like Nyota Uhura, Hikaru Sulu, Pavel Chekov and even Kirk himself,thanks to Leonard McCoy's medical trickery. Together, this crew will have an adventure in the final frontier where the old legend is altered forever as a new version of the legend begins", "/Images/Sci-fiPosters/Startrekposter.jpg", 16m, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8f, "The brash James T. Kirk tries to live up to his father's legacy with Mr. Spock keeping him in check as a vengeful Romulan from the future creates black holes to destroy the Federation one planet at a time.", "Star trek" },
                    { 8, true, 2, "Nearly three years have passed since the beginning of the Clone Wars. The Republic, with the help of the Jedi,take on Count Dooku and the Separatists. With a new threat rising, the Jedi Council sends Obi-Wan Kenobi and Anakin Skywalker to aid the captured Chancellor.Anakin feels he is ready to be promoted to Jedi Master. Obi-Wan is hunting down the Separatist General, Grievous.When Anakin has future visions of pain and suffering coming Padmé's way, he sees Master Yoda for counsel.When Darth Sidious executes Order 66, it destroys most of all the Jedi have built. Experience the birth of Darth Vader.Feel the betrayal that leads to hatred between two brothers. And witness the power of hope.", "/Images/Sci-fiPosters/Star_Wars_Episode_III_Revenge_of_the_Sith_poster.jpg", 12m, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.6f, "Three years into the Clone Wars, the Jedi rescue Palpatine from Count Dooku. As Obi-Wan pursues a new threat,Anakin acts as a double agent between the Jedi Council and Palpatine and is lured into a sinister plan to rule the galaxy.", "Episode III - Revenge of the Sith" },
                    { 9, true, 2, "In the distant future, the crew of the commercial spaceship Nostromo are on their way home when they pick up a distress call from a distant moon.The crew are under obligation to investigate and the spaceship descends on the moon afterwards.After a rough landing, three crew members leave the spaceship to explore the area on the moon. At the same time as they discover a hive colony of some unknown creature,the ship's computer deciphers the message to be a warning, not a distress call. When one of the eggs is disturbed,the crew realizes that they are not alone on the spaceship and they must deal with the consequences.", "/Images/Sci-fiPosters/Alien_movie_poster.jpg", 8m, new DateTime(1979, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.5f, "The crew of a commercial spacecraft encounter a deadly lifeform after investigating an unknown transmission.", "Alien" },
                    { 10, false, 2, "The infamous Riddick has been left for dead on a sun-scorched planet that appears to be lifeless. Soon, however, he finds himself fighting for survival against alien predators more lethal than any human he's encountered.The only way off is for Riddick to activate an emergency beacon and alert mercenaries who rapidly descend to the planet in search of their bounty.The first ship to arrive carries a new breed of merc, more lethal and violent, while the second is captained by a man whose pursuit of Riddick is more personal.With time running out and a storm on the horizon that no one could survive, his hunters won't leave the planet without Riddick's head as their trophy.", "/Images/Sci-fiPosters/Riddick_poster.jpg", 5m, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.4f, "Left for dead on a sun-scorched planet, Riddick finds himself up against an alien race of predators.Activating an emergency beacon alerts two ships: one carrying a new breed of mercenary, the other captained by a man from Riddick's past.", "Riddick" },
                    { 11, false, 2, "2001 is a story of evolution. Sometime in the distant past, someone or something nudged evolution by placing a monolith on Earth (presumably elsewhere throughout the universe as well).Evolution then enabled humankind to reach the moon's surface, where yet another monolith is found, one that signals the monolith placers that humankind has evolved that far.Now a race begins between computers (HAL) and human (Bowman) to reach the monolith placers. The winner will achieve the next step in evolution, whatever that may be.", "/Images/Sci-fiPosters/2001_A_Space_Odyssey_(1968).png", 6m, new DateTime(1986, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.3f, "The Monoliths push humanity to reach for the stars; after their discovery in Africa generations ago,the mysterious objects lead mankind on an awesome journey to Jupiter, with the help of H.A.L. 9000: the world's greatest supercomputer.", "2001: A Space Odyssey" },
                    { 12, false, 3, "Chronicles the experiences of a formerly successful banker as a prisoner in the gloomy jailhouse of Shawshank after being found guilty of a crime he did not commit.The film portrays the man's unique way of dealing with his new, torturous life; along the way he befriends a number of fellow prisoners, most notably a wise long-term inmate named Red.", "/Images/DramaPosters/ShawshankRedemptionMoviePoster.jpg", 9m, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.3f, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "The Shawshank Redemption" },
                    { 13, true, 3, "Death Row guards at a penitentiary, in the 1930's, have a moral dilemma with their job when they discover one of their prisoners, a convicted murderer, has a special gift.", "/Images/DramaPosters/The_Green_Mile_(movie_poster).jpg", 11m, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.6f, "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.", "The Green Mile" },
                    { 14, false, 3, "The setting is Detroit in 1995. The city is divided by 8 Mile, a road that splits the town in half along racial lines.A young white rapper, Jimmy B - Rabbit, Smith Jr. summons strength within himself to cross over these arbitrary boundaries to fulfill his dream of success in hip hop.With his pal Future and the three one third in place, all he has to do is not choke.", "/Images/DramaPosters/Eight_mile_ver2.jpg", 9m, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.2f, "A young rapper, struggling with every aspect of his life, wants to make it big but his friends and foes make this odyssey of rap harder than it may seem.", "8 mile" },
                    { 15, false, 3, "In 1978, five 12-year-olds win a CYO basketball championship. Thirty years later, they gather with their families for their coach's funeral and a weekend at a house on a lake where they used to party.By now, each is a grownup with problems and challenges: Marcus is alone and drinks too much. Rob, with three daughters he rarely sees,is always deeply in love until he turns on his next ex-wife. Eric is overweight and out of work. Kurt is a househusband, henpecked by wife and mother-in-law.Lenny is a successful Hollywood agent married to a fashion designer with three kids and his two sons take their privilege for granted.Can the outdoors help these grownups rediscover connections or is this chaos in the making?", "/Images/DramaPosters/Grownupsmovie.jpg", 7m, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.9f, "After their high school basketball coach passes away, five good friends and former teammates reunite for a Fourth of July holiday weekend.", "Grown ups" },
                    { 16, true, 3, "Gloucester, Massachusetts. As a Child of Deaf Adults and the only hearing person in her family, high school senior Ruby Rossi always has a lot on her plate.Indeed, trying to juggle back-breaking work on her father's fishing boat, schoolwork, social life, and the family's expectations can be too much for a teenager.But do her parents know Ruby loves to sing? When Ruby signs up for the school choir, singing becomes a passion, and suddenly,the talented young girl finds herself at a crossroads: should Ruby spread her wings and follow her dreams, or should she keep fighting everyday battles as a member of the proud Rossi clan?", "/Images/DramaPosters/Coda_poster.jpeg", 15m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.1f, "As a CODA (Child of Deaf Adults) Ruby is the only hearing person in her deaf family. When the family's fishing business is threatened,Ruby finds herself torn between pursuing her passion at Berklee College of Music and her fear of abandoning her parents.", "CODA" },
                    { 17, false, 4, "Academy Award-winning documentary filmmaker, Jean-Xavier de Lestrade, presents a gripping courtroom thriller, offering a rare and revealing inside look at a high-profile murder trial.In 2001, author Michael Peterson was arraigned for the murder of his wife Kathleen,whose body was discovered lying in a pool of blood on the stairway of their home. Granted unusual access to Peterson's lawyers,home and immediate family, de Lestrade's cameras capture the defense team as it considers its strategic options.The staircase is an engrossing look at contemporary American justice that features more twists than a legal bestseller.", "/Images/Documentary/The_Staircase.png", 8m, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.9f, "The high-profile murder trial of American novelist Michael Peterson following the death of his wife in 2001.", "The Staircase" },
                    { 18, false, 4, "It is the defining cultural tale of modern America - a saga of race, celebrity, media, violence, and the criminal justice system.And two decades after its unforgettable climax, it continues to fascinate, polarize, and even, yes, develop new chapters. Now, the producers of ESPN's award-winning 30 for 30 have made it the subject of their first documentary-event and most ambitious project yet. From Peabody and Emmy-award winning director Ezra Edelman, it's O.J.: Made in America,  a 10-hour multi-part production coming summer of 2016. To most observers, it's a story that began the night Nicole Brown Simpson and Ronald Goldman were brutally murdered outside her Brentwood apartment. But as O.J. lays bare, to truly grasp the significance of what happened not just that night, but the epic chronicle to follow, one has to travel back to a much different, much earlier origin point, at not the end, but the beginning of the 20th century, when African-Americans began migrating to California enmasse, in desperate, collective hope of a better life, trying desperately - and fruitlessly - to outrun the racismthat had defined their lives. And among the thousands who came west from the south were the grandparents of Orenthal JamesSimpson. The tale is familiar from there. In the mid-1960's, Simpson rose to instant fame as an unstoppable running back for the USC Trojans, and later, not just a record-settingHall of Famer in the NFL, but a crossover, charismatic superstar with a singular foothold in the celebrity landscape.In retirement, O.J. remained as popular as any active athlete - a broadcaster, pitch-man, and actor.But he stood alone for another reason as well. Living in the shadows of everything from the Civil Rights Movement to the Rodney King riots and so much in between, in a country forever divided by racial lines and a city with a horrific legacy of institutionalized police racism, O.J. Simpson managed always to find a way to transcendthe color of his skin. That is, until everything changedon that June night of 1994. O.J. revisits - and redefines - it all.The domestic abuse. The police investigation. The white Bronco chase. The trial of the century.The motive, the blood, the glove. The verdict. The aftermath. Drawing upon more than seventy interviews- from longtime friends and colleagues of Simpson to the recognizable protagonists of the murder investigation to observers and commentators with distinct connections to the story - the docu-event is an engrossing, compelling, and unforgettable look at a tantalizing saga. Because at the end of what seems like a search for the real truth about O.J. Simpson, what's revealed just as powerfully is a collection of indelible, unshakeable, and haunting truths about America, and about ourselves", "/Images/Documentary/OJ_Made_In_America.png", 7m, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.9f, "A chronicle of the rise and fall of O.J. Simpson, whose high-profile murder trial exposed the extent of American racial tensions, revealing a fractured and divided nation.", "O.J.: Made in America" },
                    { 19, true, 4, "In 2001, Andrew Bagby, a medical resident, is murdered not long after breaking up with his girlfriend. Soon after, when she announces she's pregnant, one of Andrew's many close friends, Kurt Kuenne,begins this film, a gift to the child. Friends, relatives, and colleagues say warm and loving things about Andrew, home movies confirm his exuberance. Andrew's parents, Kathleen and David, move to Newfoundland, Canada where the ex-girlfriend has gone. They await an arrest and trial of the murderer. They negotiate with the ex-girlfriend to visit their grandchild, Zachary, and they seek custody. Is there any justice; is Zachary a sweet and innocent consolation for the loss of their son?", "/Images/Documentary/DearZacharyTheatricalPoster.jpg", 12m, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.5f, "A filmmaker decides to memorialize a murdered friend when his friend's ex-girlfriend announces she is expecting his son.", "Dear Zachary" },
                    { 20, false, 4, "Richard O'Barry was the man who captured and trained the dolphins for the television show Flipper (1964). O'Barry's view of cetaceans in captivity changed from that experience when as the last straw he saw that one of the dolphins playing Flipper- her name being Kathy - basically committed suicide in his arms because of the stress of being in captivity. Since that time, he has become one of the leading advocates against cetaceans in captivity and for the preservation of cetaceans in the wild.O'Barry and filmmaker 'Louie Psihoyos (I)' go about trying to expose one of what they see as the most cruel acts against wild dolphins in the world in Taiji, Japan, where dolphins are routinely corralled, either to be sold alive to aquariums and marine parks, or slaughtered for meat. The primary secluded cove where this activity is taking place is heavily guarded. O'Barry and Psihoyos are well known as enemies by the authorities in Taiji, the authorities who will use whatever tactic to expel the two from Japan forever. O'Barry, Psihoyos and their team covertly try to film as a document of conclusive evidence this cruel behavior. They employ among others Hollywood cameramen and deep sea free divers. They also highlight what is considered the dangerous consumption of dolphin meat (due to its high concentration of mercury) which is often sold not as dolphin meat, and the Japanese government's methodical buying off of poorer third world nations for their support of Japan's whaling industry, that support most specifically at the International Whaling Commission.", "/Images/Documentary/The_Cove_2009_promo_image.jpg", 5m, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.4f, "Using state-of-the-art equipment, a group of activists, led by renowned dolphin trainer Ric O'Barry, infiltrate a cove near Taijii, Japan to expose both a shocking instance of animal abuse and a serious threat to human health.", "The Cove" },
                    { 21, false, 4, "Through ground breaking computer restoration technology, filmmaker Peter Jackson's team creates a moving real-to-life depiction of the WWI, as never seen before in restored,vivid colorizing & retiming of the film frames, in order to honor those who fought and more accurately depict this historical moment in world history.", "/Images/Documentary/They_Shall_Not_Grow_Old.jpg", 7m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.2f, "A documentary about World War I with never-before-seen footage to commemorate the centennial of the end of the war.", "They Shall Not Grow Old" },
                    { 22, false, 4, "In the early 1970s, Sixto Rodriguez was a Detroit folksinger who had a short-lived recording career with only two well received but non-selling albums. Unknown to Rodriguez, his musical story continued in South Africa where he became a pop music icon and inspiration for generations. Long rumored there to be dead by suicide, a few fans in the 1990s decided to seek out the truth of their hero's fate. What follows is a bizarrely heartening story in which they found far more in their quest than they ever hoped, while a Detroit construction laborer discovered that his lost artistic dreams came true after all.", "/Images/Documentary/Searching-for-sugar-man--poster.jpg", 14m, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.1f, "Two South Africans set out to discover what happened to their unlikely musical hero, the mysterious 1970s rock n roller, Rodriguez.", "Searching for Sugar Man" },
                    { 23, false, 4, "Alex Honnold attempts to become the first person to ever free solo climb El Capitan.", "/Images/Documentary/Free_Solo.png", 7m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.1f, "Alex Honnold attempts to become the first person to ever free solo climb El Capitan.", "Free Solo" },
                    { 24, true, 4, "Documents the sensational events surrounding the making of Apocalypse (1979)' and Francis Ford Coppola's struggle with nature, governments, actors, and self-doubt. Includes footage and sound secretly recorded by Eleanor Coppola, wife of Francis.", "/Images/Documentary/Hearts_of_Darkness,_A_Filmmaker's_Apocalypse_Poster.jpeg", 3m, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.1f, "Documentary that chronicles how Francis Ford Coppola's Apocalypse (1979) was plagued by extraordinary script, shooting, budget, and casting problems--nearly destroying the life and career of the celebrated director.", "Hearts of Darkness" },
                    { 25, true, 4, "In 1993, a horrific triple child murder was discovered in West Memphis, Arkansas, but the reaction to it precipitated a horror of its own. This film follows up on the story of the three boys, called the West Memphis Three, who were convicted for this crime with questionable evidence. For years, the boys' fate sparked a mass movement striving to prove their innocence while the state is equally determined to avoid admitting it could have been wrong. Through the swirl of new evidence and suspects, the Three tell their own tale about enduring this injustice against the opinions of the victim's families in a debate that eventually came to an inadequate resolution.", "/Images/Documentary/Paradise_Lost_3_Purgatory_poster.png", 5m, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8f, "A further followup of the case of the West Memphis Three and the decades long fight to exonerate them that finally gained traction with new DNA evidence.", "Paradise Lost 3: Purgatory" },
                    { 26, false, 5, "Seth and Evan are best friends, inseparable, navigating the last weeks of high school. Usually shunned by the popular kids, Seth and Evan luck into an invitation to a party, and spend a long day, with the help of their nerdy friend Fogell, trying to score enough alcohol to lubricate the party and inebriate two girls, Jules and Becca, so they can kick-start their sex lives and go off to college with a summer full of experience and new skills. Their quest is complicated by Fogell's falling in with two inept cops who both slow and assist the plan. If they do get the liquor to the party, what then? Is sex the only rite of passage at hand?", "/Images/Comedy/Superbad_Poster.png", 8m, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.6f, "Two co-dependent high school seniors are forced to deal with separation anxiety after their plan to stage a booze-soaked party goes awry.", "Superbad" },
                    { 27, false, 5, "Harry and Lloyd are two good friends who happen to be really stupid. The duo set out on a cross country trip from Providence to Aspen, Colorado to return a briefcase full of money to its rightful owner, a beautiful woman named Mary Swanson. After a trip of one mishap after another, the duo eventually make it to Aspen. But the two soon realize that Mary and her briefcase are the least of their problems.", "/Images/Comedy/Dumbanddumber.jpg", 4m, new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.3f, "After a woman leaves a briefcase at the airport terminal, a dumb limo driver and his dumber friend set out on a hilarious cross-country road trip to Aspen to return it.", "Dumb and Dumber" },
                    { 28, false, 5, "Brennan Huff and Dale Doback are both about 40 when Brennan's mom and Dale's dad marry. The sons still live with the parents so they must now share a room. Initial antipathy threatens the household's peace and the parents' relationship. Dad lays down the law: both slackers have a month to find a job. Out of the job search and their love of music comes a pact that leads to friendship but more domestic disarray compounded by the boys' sleepwalking. Hovering nearby are Brennan's successful brother and his lonely wife: the brother wants to help sell his step-father's house, the wife wants Dale's attention, and the newlyweds want to retire and sail the seven seas. Can harmony come from the discord?", "/Images/Comedy/StepbrothersMP08.jpg", 6m, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.9f, "Two aimless middle-aged losers still living at home are forced against their will to become roommates when their parents marry.", "Step Brothers" },
                    { 29, false, 5, "It's the last day of school at a high school in a small town in Texas in 1976. The upperclassmen are hazing the incoming freshmen, and everyone is trying to get stoned, drunk, or laid, even the football players that signed a pledge not to.", "/Images/Comedy/Dazed_and_Confused_(1993)_poster.jpg", 7m, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.6f, "The adventures of high school and junior high students on the last day of school in May 1976.", "Dazed and Confused" },
                    { 30, false, 5, "Preston, Idaho's most curious resident, Napoleon Dynamite, lives with his grandma and his 32-year-old brother (who cruises chat rooms for ladies) and works to help his best friend, Pedro, snatch the Student Body President title from mean teen Summer Wheatley.", "/Images/Comedy/Napoleon_dynamite_post.jpg", 10m, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.9f, "A listless and alienated teenager decides to help his new friend win the class presidency in their small western high school, while he must deal with his bizarre family life back home.", "Napoleon Dynamite" },
                    { 31, false, 5, "In the Initech office, the insecure Peter Gibbons hates his job and the obnoxious Division VP Bill Lumbergh who has just hired two efficiency consultants to downsize the company. His best friends are two software engineers Michael Bolton and Samir Nagheenanajar, that also hate Initech, and his intrusive next door neighbor Lawrence. He believes his girlfriend Anne is cheating on him but she convinces Peter to visit the hypnotherapist Dr. Swanson. Peter tells how miserable his life is and Dr. Swanson hypnotizes him and he goes into a state of ecstasy. However, Dr. Swanson dies immediately after giving the hypnotic suggestion to Peter. Peter, in his new state, starts to date the waitress Joanna and changes his attitude which results in his being promoted by the consultants. When he discovers that Michael and Samir will be downsized, they decide to plant a virus in the banking system to embezzle fraction of cents on each financial operation into Peter's account. However Michael commits a mistake in the software on the decimal place and they siphon off over $300 thousand. The desperate trio tries to fix the problem, return the money and avoid going to prison.", "/Images/Comedy/Office_space_poster.jpg", 2m, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7f, "Three company workers who hate their jobs decide to rebel against their greedy boss.", "Office Space" },
                    { 32, true, 6, "Chihiro and her parents are moving to a small Japanese town in the countryside, much to Chihiro's dismay. On the way to their new home, Chihiro's father makes a wrong turn and drives down a lonely one-lane road which dead-ends in front of a tunnel. Her parents decide to stop the car and explore the area. They go through the tunnel and find an abandoned amusement park on the other side, with its own little town. When her parents see a restaurant with great-smelling food but no staff, they decide to eat and pay later. However, Chihiro refuses to eat and decides to explore the theme park a bit more. She meets a boy named Haku who tells her that Chihiro and her parents are in danger, and they must leave immediately. She runs to the restaurant and finds that her parents have turned into pigs. In addition, the theme park turns out to be a town inhabited by demons, spirits, and evil gods. At the center of the town is a bathhouse where these creatures go to relax. The owner of the bathhouse is the evil witch Yubaba, who is intent on keeping all trespassers as captive workers, including Chihiro. Chihiro must rely on Haku to save her parents in hopes of returning to their world.", "/Images/Animé/Spirited_Away_Japanese_poster.png", 5m, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.6f, "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.", "Spirited Away" },
                    { 33, false, 6, "2019. 31 years after being destroyed during World War 3, Tokyo (now 'Neo-Tokyo') has been rebuilt and is a thriving metropolis. Shotaro Kaneda is the leader of a biker gang. His friend Tetsuo is injured in an accident and taken to a top-secret government facility. He develops telekinetic powers but decides to use them for evil rather than good. He has the same powers as Akira, the force that destroyed Tokyo in 1988, and now it appears that history will repeat itself.", "/Images/Animé/AKIRA_(1988_poster).jpg", 6m, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8f, "A secret military project endangers Neo-Tokyo when it turns a biker gang member into a rampaging psychic psychopath who can only be stopped by a teenager, his gang of biker friends and a group of psychics.", "Akira" },
                    { 34, false, 6, "Two young girls, 10-year-old Satsuki and her 4-year-old sister Mei, move into a house in the country with their father to be closer to their hospitalized mother. Satsuki and Mei discover that the nearby forest is inhabited by magical creatures called Totoros (pronounced toe-toe-ro). They soon befriend these Totoros, and have several magical adventures. ", "/Images/Animé/My_Neighbor_Totoro_-_Tonari_no_Totoro_(Movie_Poster).jpg", 10m, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.1f, "When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.", "My Neighbor Totoro" },
                    { 35, true, 6, "It is the year 2029. Technology has advanced so far that cyborgs are commonplace. In addition, human brains can connect to the internet directly. Major Motoko Kusanagi is an officer in Section 9, an elite, secretive police division that deals with special operations, including counter terrorism and cyber crime. She is currently on the trail of the Puppet Master, a cyber criminal who hacks into the brains of cyborgs in order to obtain information and to commit other crimes. ", "/Images/Animé/Ghostintheshellposter.jpg", 8m, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.9f, "A cyborg policewoman and her partner hunt a mysterious and powerful hacker called the Puppet Master.", "Ghost in the Shell" },
                    { 36, false, 6, "After successfully robbing the Monte Carlo Casino, Lupin The Third and Jigen Daisuke soon learn that their money is in fact counterfeit and they go after the man responsible: Count Lazare de Cagliostro. The two soon find out that the Count is behind something far worse than counterfeiting money for casinos: he has been keeping a family secret hidden deep in his castle. Can Lupin find out what this is and live to tell the tale? With the help of Jigen and the wise samurai Goemon Ishikawa XIII, Lupin is hell-bent on finding out the Cagliostro family's secret fortune and make it his own. ", "/Images/Animé/Castle_of_Cagliostro_poster.png", 5m, new DateTime(1979, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.6f, "A dashing thief, his gang of desperadoes and an intrepid cop struggle to free a princess from an evil count, and learn the secret of a treasure that she holds part of the key to.", "The Castle of Cagliostro" },
                    { 37, false, 6, "A love story between an 18-year-old girl named Sophie, cursed by a witch into an old woman's body, and a magician named Howl. Under the curse, Sophie sets out to seek her fortune, which takes her to Howl's strange moving castle. In the castle, Sophie meets Howl's fire demon, named Karishifâ. Seeing that she is under a curse, the demon makes a deal with Sophie--if she breaks the contract he is under with Howl, then Karushifâ will lift the curse that Sophie is under, and she will return to her 18-year-old shape.", "/Images/Animé/Howls-moving-castleposter.jpg", 12m, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.2f, "When an unconfident young woman is cursed with an old body by a spiteful witch, her only chance of breaking the spell lies with a self-indulgent yet insecure young wizard and his companions in his legged, walking castle.", "Howl's Moving Castle" },
                    { 38, false, 7, "A visiting actress in Washington, D.C., notices dramatic and dangerous changes in the behavior and physical make-up of her 12-year-old daughter. Meanwhile, a young priest at nearby Georgetown University begins to doubt his faith while dealing with his mother's terminal sickness. And, book-ending the story, a frail, elderly priest recognizes the necessity for a show-down with an old demonic enemy.", "/Images/Horror/Exorcist_ver2.jpg", 9m, new DateTime(1973, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.1f, "When a 12-year-old girl is possessed by a mysterious entity, her mother seeks the help of two priests to save her.", "The Exorcist" },
                    { 39, false, 7, "When her mentally ill mother passes away, Annie (Toni Collette), her husband (Gabriel Byrne), son (Alex Wolff), and daughter (Milly Shapiro) all mourn her loss. The family turn to different means to handle their grief, including Annie and her daughter both flirting with the supernatural. They each begin to have disturbing, otherworldly experiences linked to the sinister secrets and emotional trauma that have been passed through the generations of their family.", "/Images/Horror/Hereditary.png", 7m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.3f, "A grieving family is haunted by tragic and disturbing occurrences.", "Hereditary" },
                    { 40, false, 7, "In 1971, Carolyn and Roger Perron move their family into a dilapidated Rhode Island farm house and soon strange things start happening around it with escalating nightmarish terror. In desperation, Carolyn contacts the noted paranormal investigators, Ed and Lorraine Warren, to examine the house. What the Warrens discover is a whole area steeped in a satanic haunting that is now targeting the Perron family wherever they go. To stop this evil, the Warrens will have to call upon all their skills and spiritual strength to defeat this spectral menace at its source that threatens to destroy everyone involved.", "/Images/Horror/Conjuring_poster.jpg", 5m, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5f, "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse.", "The Conjuring" },
                    { 41, false, 7, "Haunted by a persistent writer's block, the aspiring author and recovering alcoholic, Jack Torrance, drags his wife, Wendy, and his gifted son, Danny, up snow-capped Colorado's secluded Overlook Hotel after taking up a job as an off-season caretaker. As the cavernous hotel shuts down for the season, the manager gives Jack a grand tour, and the facility's chef, the ageing Mr Hallorann, has a fascinating chat with Danny about a rare psychic gift called The Shining, making sure to warn him about the hotel's abandoned rooms, and, in particular, the off-limits Room 237. However, instead of overcoming the dismal creative rut, little by little, Jack starts losing his mind, trapped in an unforgiving environment of seemingly endless snowstorms, and a gargantuan silent prison riddled with strange occurrences and eerie visions. Now, the incessant voices inside Jack's head demand sacrifice. Is Jack capable of murder?", "/Images/Horror/The_Shining_(1980)_U.K._release_poster_-_The_tide_of_terror_that_swept_America_IS_HERE.jpg", 6m, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.4f, "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence, while his psychic son sees horrific forebodings from both past and future.", "The Shining" },
                    { 42, false, 7, " En route to visit their grandfather's grave (which has apparently been ritualistically desecrated), five teenagers drive past a slaughterhouse, pick up (and quickly drop) a sinister hitch-hiker, eat some delicious home-cured meat at a roadside gas station, before ending up at the old family home... where they're plunged into a never-ending nightmare as they meet a family of cannibals who more than make up in power tools what they lack in social skills... ", "/Images/Horror/The_Texas_Chain_Saw_Massacre_(1974)_theatrical_poster.jpg", 12m, new DateTime(1974, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.4f, "Five friends head out to rural Texas to visit the grave of a grandfather. On the way they stumble across what appears to be a deserted house, only to discover something sinister within. Something armed with a chainsaw.", "The Texas Chainsaw Massacre" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Featured", "GenreId", "LongDescription", "PosterImageUrl", "Price", "ProductionYear", "Rating", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 43, false, 7, "The year is 1963, the night: Halloween. Police are called to 43 Lampkin Ln. only to discover that 15 year old Judith Myers has been stabbed to death, by her 6 year-old brother, Michael. After being institutionalized for 15 years, Myers breaks out on the night before Halloween. No one knows, nor wants to find out, what will happen on October 31st 1978 besides Myers' psychiatrist, Dr. Loomis. He knows Michael is coming back to Haddonfield, but by the time the town realizes it, it'll be too late for many people. ", "/Images/Horror/Halloween_(1978)_theatrical_poster.jpg", 4m, new DateTime(1978, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.7f, "Fifteen years after murdering his sister on Halloween night 1963, Michael Myers escapes from a mental hospital and returns to the small town of Haddonfield, Illinois to kill again.", "Halloween" },
                    { 44, false, 7, "Crime writer Ellison Oswalt moves his family into a house where a horrific crime took place earlier, but his family doesn't know. He begins researching the crime in hopes of writing a book about it. Oswalt examines video footage that he finds in the house to help him in his research, but he soon discovers more than he bargained for. ", "/Images/Horror/SinisterMoviePoster2012.jpg", 7m, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.8f, "Washed-up true crime writer Ellison Oswalt finds a box of super 8 home movies in his new home that suggest the murder that he is currently researching is the work of a serial killer whose legacy dates back to the 1960s.", "Sinister" },
                    { 45, false, 8, "F.B.I. trainee Clarice Starling (Jodie Foster) works hard to advance her career, while trying to hide or put behind her West Virginia roots, of which if some knew, would automatically classify her as being backward or white trash. After graduation, she aspires to work in the agency's Behavioral Science Unit under the leadership of Jack Crawford (Scott Glenn). While she is still a trainee, Crawford asks her to question Dr. Hannibal Lecter (Sir Anthony Hopkins), a psychiatrist imprisoned, thus far, for eight years in maximum security isolation for being a serial killer who cannibalized his victims. Clarice is able to figure out the assignment is to pick Lecter's brains to help them solve another serial murder case, that of someone coined by the media as Buffalo Bill (Ted Levine), who has so far killed five victims, all located in the eastern U.S., all young women, who are slightly overweight (especially around the hips), all who were drowned in natural bodies of water, and all who were stripped of large swaths of skin. She also figures that Crawford chose her, as a woman, to be able to trigger some emotional response from Lecter. After speaking to Lecter for the first time, she realizes that everything with him will be a psychological game, with her often having to read between the very cryptic lines he provides. She has to decide how much she will play along, as his request in return for talking to him is to expose herself emotionally to him. The case takes a more dire turn when a sixth victim is discovered, this one from who they are able to retrieve a key piece of evidence, if Lecter is being forthright as to its meaning. A potential seventh victim is high profile Catherine Martin (Brooke Smith), the daughter of Senator Ruth Martin (Diane Baker), which places greater scrutiny on the case as they search for a hopefully still alive Catherine. Who may factor into what happens is Dr. Frederick Chilton (Anthony Heald), the warden at the prison, an opportunist who sees the higher profile with Catherine, meaning a higher profile for himself if he can insert himself successfully into the proceedings.", "/Images/Thriller/The_Silence_of_the_Lambs_poster.jpg", 10m, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.6f, "A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.", "The Silence of the Lambs" },
                    { 46, false, 8, "Memento chronicles two separate stories of Leonard, an ex-insurance investigator who can no longer build new memories, as he attempts to find the murderer of his wife, which is the last thing he remembers. One story line moves forward in time while the other tells the story backwards revealing more each time.", "/Images/Thriller/Memento_poster.jpg", 5m, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.4f, "A man with short-term memory loss attempts to track down his wife's murderer.", "Memento" },
                    { 47, false, 8, "The Kims - mother and father Chung-sook and Ki-taek, and their young adult offspring, son Ki-woo and daughter Ki-jung - are a poor family living in a shabby and cramped half basement apartment in a busy lower working class commercial district of Seoul. Without even knowing it, they, especially Mr. and Mrs. Kim, literally smell of poverty. Often as a collective, they perpetrate minor scams to get by, and even when they have jobs, they do the minimum work required. Ki-woo is the one who has dreams of getting out of poverty by one day going to university. Despite not having that university education, Ki-woo is chosen by his university student friend Min, who is leaving to go to school, to take over his tutoring job to Park Da-hye, who Min plans to date once he returns to Seoul and she herself is in university. The Parks are a wealthy family who for four years have lived in their modernistic house designed by and the former residence of famed architect Namgoong. While Mr. and Mrs. Park are all about status, Mrs. Park has a flighty, simpleminded mentality and temperament, which Min tells Ki-woo to feel comfortable in lying to her about his education to get the job. In getting the job, Ki-woo further learns that Mrs. Park is looking for an art therapist for the Parks' adolescent son, Da-song, Ki-woo quickly recommending his professional art therapist friend Jessica, really Ki-jung who he knows can pull off the scam in being the easiest liar of the four Kims. In Ki-woo also falling for Da-hye, he begins to envision himself in that house, and thus the Kims as a collective start a plan for all the Kims, like Ki-jung using assumed names, to replace existing servants in the Parks' employ in orchestrating reasons for them to be fired. The most difficult to get rid of may be Moon-gwang, the Parks' housekeeper who literally came with the house - she Namgoong's housekeeper when he lived there - and thus knows all the little nooks and crannies of it better than the Parks themselves. The question then becomes how far the Kims can take this scam in their quest to become their version of the Parks.", "/Images/Thriller/Parasite_(2019_film).png", 12m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.5f, "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.", "Parasite" },
                    { 48, false, 8, "Best-selling novelist Paul Sheldon is on his way home from his Colorado hideaway after completing his latest book, when he crashes his car in a freak blizzard. Paul is critically injured, but is rescued by former nurse Annie Wilkes, Paul's number one fan, who takes Paul back to her remote house in the mountains (without bothering to tell anybody). Unfortunately for Paul, Annie is also a headcase. When she discovers that Paul has killed off the heroine in her favorite novels, her reaction leaves Paul shattered (literally)...", "/Images/Thriller/Misery_(1990_film_poster).png", 3m, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.8f, "After a famous author is rescued from a car crash by a fan of his novels, he comes to realize that the care he is receiving is only the beginning of a nightmare of captivity and abuse.", "Misery" },
                    { 49, false, 8, "As the wavering cry of the foghorn fills the air, the taciturn former lumberjack, Ephraim Winslow, and the grizzled lighthouse keeper, Thomas Wake, set foot in a secluded and perpetually grey islet off the coast of late-19th-century New England. For the following four weeks of back-breaking work and unfavourable conditions, the tight-lipped men will have no one else for company except for each other, forced to endure irritating idiosyncrasies, bottled-up resentment, and burgeoning hatred. Then, amid bad omens, a furious and unending squall maroons the pale beacon's keepers in the already inhospitable volcanic rock, paving the way for a prolonged period of feral hunger; excruciating agony; manic isolation, and horrible booze-addled visions. Now, the eerie stranglehold of insanity tightens. Is there an escape from the wall-less prison of the mind?", "/Images/Thriller/The_Lighthouse.jpeg", 8m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.4f, "Two lighthouse keepers try to maintain their sanity while living on a remote and mysterious New England island in the 1890s.", "The Lighthouse" },
                    { 50, false, 9, "In German-occupied France, young Jewish refugee Shosanna Dreyfus witnesses the slaughter of her family by Colonel Hans Landa. Narrowly escaping with her life, she plots her revenge several years later when German war hero Fredrick Zoller takes a rapid interest in her and arranges an illustrious movie premiere at the theater she now runs. With the promise of every major Nazi officer in attendance, the event catches the attention of the Basterds, a group of Jewish-American guerrilla soldiers led by the ruthless Lt. Aldo Raine. As the relentless executioners advance and the conspiring young girl's plans are set in motion, their paths will cross for a fateful evening that will shake the very annals of history.", "/Images/War/Inglourious_Basterds_poster.jpg", 12m, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.3f, "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.", "Inglourious Basterds" },
                    { 51, false, 9, " May/June 1940. Four hundred thousand British and French soldiers are hole up in the French port town of Dunkirk. The only way out is via sea, and the Germans have air superiority, bombing the British soldiers and ships without much opposition. The situation looks dire and, in desperation, Britain sends civilian boats in addition to its hard-pressed Navy to try to evacuate the beleaguered forces. This is that story, seen through the eyes of a soldier amongst those trapped forces, two Royal Air Force fighter pilots, and a group of civilians on their boat, part of the evacuation fleet.", "/Images/War/Dunkirk_Film_poster.jpg", 10m, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.8f, "Allied soldiers from Belgium, the British Commonwealth and Empire, and France are surrounded by the German Army and evacuated during a fierce battle in World War II.", "Dunkirk" },
                    { 52, false, 9, "A two-segment look at the effect of the military mindset and war itself on Vietnam era Marines. The first half follows a group of recruits in boot camp under the command of the punishing Gunnery Sergeant Hartman. The second half shows one of those recruits, Joker, covering the war as a correspondent for Stars and Stripes, focusing on the Tet offensive.", "/Images/War/Full_Metal_Jacket_poster.jpg", 7m, new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.3f, "A pragmatic U.S. Marine observes the dehumanizing effects the Vietnam War has on his fellow recruits from their brutal boot camp training to the bloody street fighting in Hue.", "Full Metal Jacket" },
                    { 53, false, 9, " April 1917, the Western Front. Two British soldiers are sent to deliver an urgent message to an isolated regiment. If the message is not received in time the regiment will walk into a trap and be massacred. To get to the regiment they will need to cross through enemy territory. Time is of the essence and the journey will be fraught with danger.", "/Images/War/1917_(2019)_Film_Poster.jpeg", 11m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.2f, "April 6th, 1917. As an infantry battalion assembles to wage war deep in enemy territory, two soldiers are assigned to race against time and deliver a message that will stop 1,600 men from walking straight into a deadly trap.", "1917" },
                    { 54, true, 9, "Oskar Schindler is a vain and greedy German businessman who becomes an unlikely humanitarian amid the barbaric German Nazi reign when he feels compelled to turn his factory into a refuge for Jews. Based on the true story of Oskar Schindler who managed to save about 1100 Jews from being gassed at the Auschwitz concentration camp, it is a testament to the good in all of us.", "/Images/War/Schindler's_List_movie.jpg", 9m, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9f, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "Schindler's List" },
                    { 55, false, 9, "Chris Taylor is a young, naive American who gives up college and volunteers for combat in Vietnam. Upon arrival, he quickly discovers that his presence is quite nonessential, and is considered insignificant to the other soldiers, as he has not fought for as long as the rest of them and felt the effects of combat. Chris has two non-commissioned officers, the ill-tempered and indestructible Staff Sergeant Robert Barnes and the more pleasant and cooperative Sergeant Elias Grodin. A line is drawn between the two NCOs and a number of men in the platoon when an illegal killing occurs during a village raid. As the war continues, Chris himself draws towards psychological meltdown. And as he struggles for survival, he soon realizes he is fighting two battles, the conflict with the enemy and the conflict between the men within his platoon.", "/Images/War/Platoon_posters_86.jpg", 8m, new DateTime(1986, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.1f, " Chris Taylor, a neophyte recruit in Vietnam, finds himself caught in a battle of wills between two sergeants, one good and the other evil. A shrewd examination of the brutality of war and the duality of man in conflict.", "Platoon" },
                    { 56, false, 9, "It is the height of the war in Vietnam, and U.S. Army Captain Willard is sent by Colonel Lucas and a General to carry out a mission that, officially, 'does not exist - nor will it ever exist'. The mission: To seek out a mysterious Green Beret Colonel, Walter Kurtz, whose army has crossed the border into Cambodia and is conducting hit-and-run missions against the Viet Cong and NVA. The army believes Kurtz has gone completely insane and Willard's job is to eliminate him. Willard, sent up the Nung River on a U.S. Navy patrol boat, discovers that his target is one of the most decorated officers in the U.S. Army. His crew meets up with surfer-type Lt-Colonel Kilgore, head of a U.S Army helicopter cavalry group which eliminates a Viet Cong outpost to provide an entry point into the Nung River. After some hair-raising encounters, in which some of his crew are killed, Willard, Lance and Chef reach Colonel Kurtz's outpost, beyond the Do Lung Bridge. Now, after becoming prisoners of Kurtz, will Willard & the others be able to fulfill their mission?", "/Images/War/Apocalypse_Now_Redux.jpg", 7m, new DateTime(1979, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.5f, "A U.S. Army officer serving in Vietnam is tasked with assassinating a renegade Special Forces Colonel who sees himself as a god.", "Apocalypse Now" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListOrdersDto_UserOrderId",
                table: "ListOrdersDto",
                column: "UserOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ListOrdersDto");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
