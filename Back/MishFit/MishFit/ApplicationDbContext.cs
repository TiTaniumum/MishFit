﻿using Microsoft.EntityFrameworkCore;
using MishFit.Entities;

namespace MishFit;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; init; }

    public DbSet<Meal> Meals { get; init; }

    public DbSet<Activity> Activities { get; init; }

    public DbSet<Tracker> Trackers { get; init; }

    public DbSet<Recommendation> Recommendations { get; init; }

    private readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString("Database"))
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Recommendation>()
            .Property(t => t.AddDateTime)
            .HasDefaultValueSql("NOW()");
    }
    
    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => builder.AddConsole());

    public void SeedData()
    {
        if (!Activities.Any())
        {
            var sql = @"
                INSERT INTO ""Activities"" (""Name"", ""ActivityType"", ""Calories"")
                VALUES
                    ('Бег (8 км/ч)', 2, 10),
                    ('Бег (12 км/ч)', 2, 15),
                    ('Скакалка', 2, 12),
                    ('Велоспорт (средняя скорость)', 2, 7),
                    ('Плавание (свободный стиль)', 2, 10),
                    ('Занятие на эллипсоиде', 2, 7),
                    ('HIIT (высокоинтенсивные интервальные тренировки)', 2, 12),
                    ('Гребной тренажер', 2, 9),
                    ('Аэробика (высокой интенсивности)', 2, 8),
                    ('Йога (виниаса или горячая йога)', 2, 5),
                    ('Танцы (энергичные, например, зумба)', 2, 7),
                    ('Силовые тренировки (классические)', 2, 5),
                    ('Кроссфит (средней интенсивности)', 2, 13),
                    ('Пилатес', 2, 4),
                    ('Подъем по лестнице', 2, 8),
                    ('Пешие прогулки (быстрая ходьба)', 2, 5),
                    ('Бурпи', 1, 2),
                    ('Приседания с весом', 2, 5),
                    ('Отжимания', 1, 1),
                    ('Подтягивания', 1, 1),
                    ('Скалолазание (спортзал)', 2, 9),
                    ('Прыжки на батуте', 2, 5),
                    ('Теннис', 2, 6),
                    ('Бокс (с тенью или с мешком)', 2, 10),
                    ('Футбол (средняя интенсивность)', 2, 7),
                    ('Бадминтон', 2, 5),
                    ('Катание на роликах', 2, 6),
                    ('Катание на коньках', 2, 8),
                    ('Катание на лыжах (беговые лыжи)', 2, 10),
                    ('Гимнастика (на кольцах, параллельных брусьях)', 2, 5);
            ";
            Database.ExecuteSqlRaw(sql);
            SaveChanges();
        }

        if (!Meals.Any())
        {
            var sql = @"
                INSERT INTO
                    ""Meals"" (""Name"", ""Calories"")
                VALUES
                    ('Хлеб пшеничный', 265),
                    ('Яблоко', 52),
                    ('Молоко 2.5% жирности', 50),
                    ('Яйцо куриное', 155),
                    ('Картофель (вареный)', 87),
                    ('Рис вареный', 130),
                    ('Куриная грудка', 165),
                    ('Говядина (жареная)', 250),
                    ('Банан', 89),
                    ('Помидор', 18),
                    ('Огурец', 15),
                    ('Макароны вареные', 131),
                    ('Сыр твердый (чеддер)', 403),
                    ('Сыр плавленый', 276),
                    ('Йогурт натуральный', 61),
                    ('Кефир', 40),
                    ('Шоколад молочный', 535),
                    ('Мясо индейки', 189),
                    ('Капуста белокочанная', 25),
                    ('Морковь', 41),
                    ('Свекла', 43),
                    ('Репчатый лук', 40),
                    ('Рыба (лосось)', 206),
                    ('Авокадо', 160),
                    ('Апельсин', 47),
                    ('Гречка вареная', 110),
                    ('Персик', 39),
                    ('Ананас', 50),
                    ('Салат (айсберг)', 14),
                    ('Фасоль вареная', 132),
                    ('Греческий йогурт', 59),
                    ('Курица (гриль)', 239),
                    ('Куриные крылья (жареные)', 290),
                    ('Овсянка вареная', 71),
                    ('Сметана 20% жирности', 206),
                    ('Свинина (жареная)', 297),
                    ('Пельмени', 275),
                    ('Пицца Маргарита', 250),
                    ('Творог 9% жирности', 159),
                    ('Чипсы картофельные', 536),
                    ('Мороженое ванильное', 207),
                    ('Фрукты сушеные (курага)', 241),
                    ('Кус-кус вареный', 112),
                    ('Каши на молоке (манная)', 98),
                    ('Печенье песочное', 458),
                    ('Суп овощной', 35),
                    ('Суп куриный', 49),
                    ('Суп борщ', 43),
                    ('Суп грибной', 30),
                    ('Омлет (с молоком)', 154),
                    ('Колбаса вареная', 257),
                    ('Колбаса копченая', 420),
                    ('Бекон жареный', 541),
                    ('Кукуруза вареная', 96),
                    ('Груша', 57),
                    ('Виноград', 69),
                    ('Черника', 57),
                    ('Клубника', 32),
                    ('Вишня', 50),
                    ('Рыба (тунец)', 144),
                    ('Рыба (треска)', 82),
                    ('Сардины (консервированные)', 208),
                    ('Икра красная', 264),
                    ('Мидии', 172),
                    ('Креветки (вареные)', 99),
                    ('Куриный бульон', 15),
                    ('Хлеб ржаной', 165),
                    ('Каша гречневая на воде', 90),
                    ('Рис белый (сушеный)', 365),
                    ('Орехи грецкие', 654),
                    ('Арахис жареный', 585),
                    ('Миндаль', 575),
                    ('Изюм', 299),
                    ('Мед', 304),
                    ('Сахар', 387),
                    ('Масло сливочное', 717),
                    ('Масло подсолнечное', 884),
                    ('Масло оливковое', 884),
                    ('Майонез', 680),
                    ('Соус томатный', 29),
                    ('Кетчуп', 112),
                    ('Горчица', 66),
                    ('Соль поваренная', 0),
                    ('Вода (минеральная)', 0),
                    ('Кофе (черный, без сахара)', 2),
                    ('Чай зеленый (без сахара)', 1),
                    ('Квас', 27),
                    ('Компот из сухофруктов', 85),
                    ('Лимонад', 40),
                    ('Сок апельсиновый', 45),
                    ('Сок яблочный', 46),
                    ('Какао с молоком', 83),
                    ('Рататуй', 35),
                    ('Табуле', 130),
                    ('Рагу овощное', 65),
                    ('Лазанья', 135),
                    ('Суши (с лососем)', 142),
                    ('Ролл Филадельфия', 142),
                    ('Шаурма', 200),
                    ('Круассан с шоколадом', 406);
            ";
            Database.ExecuteSqlRaw(sql);
            SaveChanges();
        }

        if (!Recommendations.Any())
        {
            var sql = @"
                INSERT INTO
                    ""Recommendations"" (""Title"", ""Content"", ""RecommendationType"")
                VALUES
                        ('На пути к цели', 'Увеличьте количество шагов на сегодня, это здорово поможет снизить вес', 1),
                        ('Кардио всему голова', 'Вам стоит больше уделять времени кардио тренировкам, они способствуют понижению веса', 1),
                        ('Это база', 'Убедитесь что сжигаете калорий больше чем потребляете, это простейший и доказанный способ похудения', 1),
                        ('Набор веса', 'Не стоит недооценивать баланс калорий, привите себе привычку контролировать их!', 2),
                        ('Мышцы - сила', 'Сосредоточьтесь на силовых упражнениях, они отлично влияют на развитие и рост мышечной массы', 2),
                        ('Белки Жиры Углеводы', 'Не забудьте про белковый перекус после тренировки!', 2),
                        ('Вода - источник жизни', 'На сегодня вы ещё не достаточно выпили воды, убедитесь что достигните требуемого значения до конца дня', 3),
                        ('Пятилетку за три года', 'Нужно пить воду! Весь объем следует равномерно распределить с утра до вечера', 3),
                        ('Между первой и второй...', 'Перед приёмом пищи и после обязательно выпивайте стакан воды', 3),
                        ('На шаг ближе к цели', 'Вы ещё не достигли цели по шагам, позаботьтесь о том что бы её выполнить!', 4),
                        ('Маленький шаг для человека', 'Вы уверены что хотите сегодня пропустить эту задачу? Я бы на вашем месте встал и пошёл!', 4),
                        ('Дождик', 'Не заубдьте взять с собой зонт, если не хотите промокнуть', 5),
                        ('Солнечно', 'Прекрасный день для пробежки или других тренировок на свежем воздухе, а так же не забывайте пить достаточно воды', 6),
                        ('Пасмурно', 'Не слишком жарко, не слишком холодно, приятный день для физической нагрузки на открытом воздухе', 7),
                        ('Цветение', 'Вам не повезло если вы аллергик, избегайте прогулок на открытом воздухе в утренние часы и используйте солнцезащитные очки, чтобы уменьшить контакт с пыльцой', 8),
                        ('Метель', 'Рекомендуется не выходить без надобности, оставайтесь в тепле, упражняйтесь дома', 9),
                        ('Снегопад', 'Мороз и солнце, день чудесный! Подходящий день для катания на коньках, похода на лыжах или иных зимних физических активностей', 10),
                        ('Плохая погода', 'Погода за окном не всегда идеальна, но это не повод пропускать тренировку! Оставайтесь активным в любое время и в любых условиях!', 11),
                        ('Хорошая погода', 'На улице отличная погода - идеальный момент для активности на свежем воздухе! Выйдите на пробежку, займитесь ходьбой, попробуйте тренировку на открытом воздухе', 12),
                        ('Сон', 'А вы уже отметили своё качество сна прошлой ночью? Нет?! Тогда скорее заполнять трекер сна!', 13),
                        ('Продам гараж', 'Здесь могла бы быть ваша реклама...', 14),
                        ('Реклама', 'По всем вопросам связанных с рекламодательством нашего приложения обращаться на почту MishFitAd@gmail.com', 14),
                        ('А вот была бы подписка...', 'Приобретая премиум подписку нашего приложения вы избавляетесь от навязчивой рекламы в ваших рекомендациях', 14);
            ";
            Database.ExecuteSqlRaw(sql);
            SaveChanges();
        }
    }
}