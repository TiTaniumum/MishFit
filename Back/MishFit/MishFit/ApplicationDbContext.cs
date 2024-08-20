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
    }
}