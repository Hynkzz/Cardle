using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cardle.Models;
using Cardle.Services;

namespace Cardle.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(
        AppDbContext context,
        string webRootPath
    )
    {
        // ===============================
        // ADMIN USER
        // ===============================
        if (!context.Users.Any(u => u.Username == "admin"))
        {
            context.Users.Add(new User
            {
                Username = "admin",
                Password = "1597",
                Role = "Admin"
            });

            await context.SaveChangesAsync();
        }

        if (context.Cars.Any())
            return;

        Console.WriteLine("🚀 ARABA LİSTESİ HAZIRLANIYOR...");

        var cars = new List<Car>
{
    // =====================
    // VOLKSWAGEN GROUP
    // =====================
    new Car { Brand="Volkswagen", Model="Golf", ParentCompany="VW Group", Body="Hatchback", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Volkswagen", Model="Passat", ParentCompany="VW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Volkswagen", Model="Polo", ParentCompany="VW Group", Body="Hatchback", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Volkswagen", Model="Tiguan", ParentCompany="VW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Volkswagen", Model="Touareg", ParentCompany="VW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},

    new Car { Brand="Audi", Model="A3", ParentCompany="VW Group", Body="Hatchback", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Audi", Model="A4", ParentCompany="VW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Audi", Model="A6", ParentCompany="VW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Audi", Model="Q5", ParentCompany="VW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Audi", Model="Q7", ParentCompany="VW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},

    new Car { Brand="Porsche", Model="911", ParentCompany="VW Group", Body="Coupe", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Porsche", Model="Cayenne", ParentCompany="VW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Porsche", Model="Taycan", ParentCompany="VW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="EV"},

    new Car { Brand="Skoda", Model="Octavia", ParentCompany="VW Group", Body="Hatchback", Country="Çekya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Skoda", Model="Superb", ParentCompany="VW Group", Body="Sedan", Country="Çekya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Skoda", Model="Kodiaq", ParentCompany="VW Group", Body="SUV", Country="Çekya", Continent="Avrupa", Power="ICE"},

    new Car { Brand="Seat", Model="Leon", ParentCompany="VW Group", Body="Hatchback", Country="İspanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Cupra", Model="Formentor", ParentCompany="VW Group", Body="SUV", Country="İspanya", Continent="Avrupa", Power="ICE"},

    
    // =====================
    // BMW GROUP
    // =====================
    new Car { Brand="BMW", Model="3 Serisi", ParentCompany="BMW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="BMW", Model="5 Serisi", ParentCompany="BMW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="BMW", Model="1 Serisi", ParentCompany="BMW Group", Body="Hatchback", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="BMW", Model="X3 Serisi", ParentCompany="BMW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="BMW", Model="X5 Serisi", ParentCompany="BMW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="BMW", Model="M3 Serisi", ParentCompany="BMW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="BMW", Model="M5 Serisi", ParentCompany="BMW Group", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},


    new Car { Brand="BMW", Model="iX", ParentCompany="BMW Group", Body="SUV", Country="Almanya", Continent="Avrupa", Power="EV"},

    new Car { Brand="Mini", Model="Cooper", ParentCompany="BMW Group", Body="Hatchback", Country="İngiltere", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Rolls-Royce", Model="Phantom", ParentCompany="BMW Group", Body="Sedan", Country="İngiltere", Continent="Avrupa", Power="ICE"},

    // =====================
    // MERCEDES / DAIMLER
    // =====================
    new Car { Brand="Mercedes-Benz", Model="A-Class", ParentCompany="Daimler", Body="Hatchback", Country="Almanya", Continent="Avrupa", Power="ICE"},

    new Car { Brand="Mercedes-Benz", Model="C-Class", ParentCompany="Daimler", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Mercedes-Benz", Model="E-Class", ParentCompany="Daimler", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Mercedes-Benz", Model="S-Class", ParentCompany="Daimler", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Mercedes-Benz", Model="GLC", ParentCompany="Daimler", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Mercedes-Benz", Model="G-Class", ParentCompany="Daimler", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},
    new Car { Brand="Mercedes-Benz", Model="EQS", ParentCompany="Daimler", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="EV"},

    // =====================
    // TOYOTA GROUP
    // =====================
    new Car { Brand="Toyota", Model="Corolla", ParentCompany="Toyota", Body="Sedan", Country="Japonya", Continent="Asya", Power="ICE"},
    new Car { Brand="Toyota", Model="RAV4", ParentCompany="Toyota", Body="SUV", Country="Japonya", Continent="Asya", Power="Hybrid"},
    new Car { Brand="Toyota", Model="Land Cruiser", ParentCompany="Toyota", Body="SUV", Country="Japonya", Continent="Asya", Power="ICE"},
    new Car { Brand="Toyota", Model="Supra", ParentCompany="Toyota", Body="Coupe", Country="Japonya", Continent="Asya", Power="ICE"},
    

    new Car { Brand="Lexus", Model="RX", ParentCompany="Toyota", Body="SUV", Country="Japonya", Continent="Asya", Power="Hybrid"},
    new Car { Brand="Lexus", Model="ES", ParentCompany="Toyota", Body="Sedan", Country="Japonya", Continent="Asya", Power="Hybrid"},
    // =====================
// STELLANTIS
// =====================
new Car { Brand="Peugeot", Model="308", ParentCompany="Stellantis", Body="Hatchback", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Peugeot", Model="508", ParentCompany="Stellantis", Body="Sedan", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Peugeot", Model="2008", ParentCompany="Stellantis", Body="SUV", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Peugeot", Model="3008", ParentCompany="Stellantis", Body="SUV", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Peugeot", Model="206", ParentCompany="Stellantis", Body="Hatchback", Country="Fransa", Continent="Avrupa", Power="ICE"},

new Car { Brand="Citroen", Model="C3", ParentCompany="Stellantis", Body="Hatchback", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Citroen", Model="C4", ParentCompany="Stellantis", Body="Hatchback", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Citroen", Model="C5 Aircross", ParentCompany="Stellantis", Body="SUV", Country="Fransa", Continent="Avrupa", Power="ICE"},

new Car { Brand="Opel", Model="Astra", ParentCompany="Stellantis", Body="Hatchback", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Opel", Model="Insignia", ParentCompany="Stellantis", Body="Sedan", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Opel", Model="Grandland", ParentCompany="Stellantis", Body="SUV", Country="Almanya", Continent="Avrupa", Power="ICE"},

new Car { Brand="Jeep", Model="Compass", ParentCompany="Stellantis", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Jeep", Model="Grand Cherokee", ParentCompany="Stellantis", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},

// =====================
// FORD
// =====================
new Car { Brand="Ford", Model="Focus", ParentCompany="Ford", Body="Hatchback", Country="ABD",Continent="Amerika", Power="ICE"},
new Car { Brand="Ford", Model="Mondeo", ParentCompany="Ford", Body="Sedan", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Ford", Model="Explorer", ParentCompany="Ford", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Ford", Model="Mustang", ParentCompany="Ford", Body="Coupe", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Ford", Model="Bronco", ParentCompany="Ford", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},



// =====================
// HYUNDAI / KIA
// =====================
new Car { Brand="Hyundai", Model="Accent", ParentCompany="Hyundai", Body="Sedan", Country="Güney Kore", Continent="Asya", Power="ICE"},

new Car { Brand="Hyundai", Model="İ20", ParentCompany="Hyundai", Body="Hatchback", Country="Güney Kore", Continent="Asya", Power="ICE"},

new Car { Brand="Hyundai", Model="Kona", ParentCompany="Hyundai", Body="SUV", Country="Güney Kore", Continent="Asya", Power="ICE"},

new Car { Brand="Kia", Model="Ceed", ParentCompany="Hyundai", Body="Hatchback", Country="Güney Kore", Continent="Asya", Power="ICE"},
new Car { Brand="Kia", Model="Sorento", ParentCompany="Hyundai", Body="SUV", Country="Güney Kore", Continent="Asya", Power="ICE"},
new Car { Brand="Kia", Model="Telluride", ParentCompany="Hyundai", Body="SUV", Country="Güney Kore", Continent="Asya", Power="ICE"},
// =====================
// DODGE (Stellantis)
// =====================
new Car { Brand="Dodge", Model="Charger", ParentCompany="Stellantis", Body="Sedan", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Dodge", Model="Challenger", ParentCompany="Stellantis", Body="Coupe", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Dodge", Model="Durango", ParentCompany="Stellantis", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Dodge", Model="Journey", ParentCompany="Stellantis", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},

// =====================
// CABRIO / CONVERTIBLE (farklı markalardan)
// =====================
new Car { Brand="Mazda", Model="MX-5", ParentCompany="Mazda", Body="Convertible", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="BMW", Model="Z4", ParentCompany="BMW Group", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Mercedes-Benz", Model="SL-Class", ParentCompany="Daimler", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Audi", Model="A5 Cabriolet", ParentCompany="VW Group", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Volkswagen", Model="Beetle", ParentCompany="VW Group", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Porsche", Model="911 Cabriolet", ParentCompany="VW Group", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Ford", Model="Mustang Convertible", ParentCompany="Ford", Body="Convertible", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Chevrolet", Model="Corvette Convertible", ParentCompany="GM", Body="Convertible", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Fiat", Model="500C", ParentCompany="Stellantis", Body="Convertible", Country="İtalya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Mini", Model="Convertible", ParentCompany="BMW Group", Body="Convertible", Country="İngiltere", Continent="Avrupa", Power="ICE"},
new Car { Brand="Toyota", Model="GR Supra", ParentCompany="Toyota", Body="Coupe", Country="Japonya", Continent="Asya", Power="ICE"}, // cabrio değil; Supra coupe diye bilinir
new Car { Brand="Jaguar", Model="F-Type", ParentCompany="JLR", Body="Convertible", Country="İngiltere", Continent="Avrupa", Power="ICE"},


// =====================
// JDM
// =====================
    
    new Car { Brand="Mitsubishi", Model="Lancer Evolution", ParentCompany="Mitsubishi", Body="Sedan", Country="Japonya", Continent="Asya", Power="ICE"},
    
new Car { Brand="Honda", Model="Civic", ParentCompany="Honda", Body="Sedan", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Honda", Model="Accord", ParentCompany="Honda", Body="Sedan", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Honda", Model="CR-V", ParentCompany="Honda", Body="SUV", Country="Japonya", Continent="Asya", Power="Hybrid"},
new Car { Brand="Honda", Model="HR-V", ParentCompany="Honda", Body="SUV", Country="Japonya", Continent="Asya", Power="ICE"},

new Car { Brand="Mazda", Model="3", ParentCompany="Mazda", Body="Hatchback", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Mazda", Model="6", ParentCompany="Mazda", Body="Sedan", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Mazda", Model="CX-5", ParentCompany="Mazda", Body="SUV", Country="Japonya", Continent="Asya", Power="ICE"},

new Car { Brand="Subaru", Model="Forester", ParentCompany="Subaru", Body="SUV", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Subaru", Model="Impreza", ParentCompany="Subaru", Body="Hatchback", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Subaru", Model="WRX", ParentCompany="Subaru", Body="Sedan", Country="Japonya", Continent="Asya", Power="ICE"},
// =====================
// GENERAL MOTORS
// =====================
new Car { Brand="Chevrolet", Model="Malibu", ParentCompany="GM", Body="Sedan", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Chevrolet", Model="Camaro", ParentCompany="GM", Body="Coupe", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Chevrolet", Model="Tahoe", ParentCompany="GM", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Chevrolet", Model="Corvette", ParentCompany="GM", Body="Coupe", Country="ABD", Continent="Amerika", Power="ICE"},

new Car { Brand="Cadillac", Model="Escalade", ParentCompany="GM", Body="SUV", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Cadillac", Model="CT5", ParentCompany="GM", Body="Sedan", Country="ABD", Continent="Amerika", Power="ICE"},

// =====================
// RENAULT GROUP
// =====================
new Car { Brand="Renault", Model="Clio", ParentCompany="Renault", Body="Hatchback", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Renault", Model="Megane", ParentCompany="Renault", Body="Hatchback", Country="Fransa", Continent="Avrupa", Power="ICE"},
new Car { Brand="Renault", Model="Austral", ParentCompany="Renault", Body="SUV", Country="Fransa", Continent="Avrupa", Power="Hybrid"},

new Car { Brand="Dacia", Model="Duster", ParentCompany="Renault", Body="SUV", Country="Romanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Dacia", Model="Sandero", ParentCompany="Renault", Body="Hatchback", Country="Romanya", Continent="Avrupa", Power="ICE"},

// =====================
// NISSAN
// =====================
new Car { Brand="Nissan", Model="Altima", ParentCompany="Nissan", Body="Sedan", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Nissan", Model="Qashqai", ParentCompany="Nissan", Body="SUV", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Nissan", Model="GT-R", ParentCompany="Nissan", Body="Coupe", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Nissan", Model="Micra", ParentCompany="Nissan", Body="Hatchback", Country="Japonya", Continent="Asya", Power="ICE"},


// =====================
// MAZDA (EK)
// =====================
new Car { Brand="Mazda", Model="MX-5", ParentCompany="Mazda", Body="Convertible", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Mazda", Model="RX-7", ParentCompany="Mazda", Body="Coupe", Country="Japonya", Continent="Asya", Power="ICE"},


// =====================
// SUZUKI
// =====================
new Car { Brand="Suzuki", Model="Swift", ParentCompany="Suzuki", Body="Hatchback", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Suzuki", Model="Vitara", ParentCompany="Suzuki", Body="SUV", Country="Japonya", Continent="Asya", Power="Hybrid"},

// =====================
// FIAT / FCA
// =====================
new Car { Brand="Fiat", Model="Egea", ParentCompany="Stellantis", Body="Sedan", Country="İtalya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Fiat", Model="500", ParentCompany="Stellantis", Body="Hatchback", Country="İtalya", Continent="Avrupa", Power="EV"},
new Car { Brand="Fiat", Model="Panda", ParentCompany="Stellantis", Body="Hatchback", Country="İtalya", Continent="Avrupa", Power="ICE"},

new Car { Brand="Alfa Romeo", Model="Giulietta", ParentCompany="Stellantis", Body="Hatchback", Country="İtalya", Continent="Avrupa", Power="ICE"},

new Car { Brand="Alfa Romeo", Model="Giulia", ParentCompany="Stellantis", Body="Sedan", Country="İtalya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Alfa Romeo", Model="Stelvio", ParentCompany="Stellantis", Body="SUV", Country="İtalya", Continent="Avrupa", Power="ICE"},

// =====================
// JAGUAR 
// =====================

new Car { Brand="Jaguar", Model="XF", ParentCompany="JLR", Body="Sedan", Country="İngiltere", Continent="Avrupa", Power="ICE"},
new Car { Brand="Jaguar", Model="F-Type", ParentCompany="JLR", Body="Coupe", Country="İngiltere", Continent="Avrupa", Power="ICE"},

// =====================
// PREMIUM & SPORT
// =====================
new Car { Brand="Volvo", Model="XC60", ParentCompany="Geely", Body="SUV", Country="İsveç", Continent="Avrupa", Power="Hybrid"},
new Car { Brand="Volvo", Model="S90", ParentCompany="Geely", Body="Sedan", Country="İsveç", Continent="Avrupa", Power="Hybrid"},

new Car { Brand="Ferrari", Model="Roma", ParentCompany="Ferrari", Body="Coupe", Country="İtalya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Ferrari", Model="F40", ParentCompany="Ferrari", Body="Coupe", Country="İtalya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Ferrari", Model="Portofino", ParentCompany="Ferrari", Body="Coupe", Country="İtalya", Continent="Avrupa", Power="ICE"},

new Car { Brand="McLaren", Model="GT", ParentCompany="McLaren", Body="Coupe", Country="İngiltere", Continent="Avrupa", Power="ICE"},
new Car { Brand="McLaren", Model="Artura", ParentCompany="McLaren", Body="Coupe", Country="İngiltere", Continent="Avrupa", Power="Hybrid"},

new Car { Brand="Lamborghini", Model="Aventador", ParentCompany="VW Group", Body="Coupe", Country="İtalya", Continent="Avrupa", Power="ICE"},

// =====================
// CONVERTIBLE (cabrio/roadster olarak meşhur olanlar)
// =====================
new Car { Brand="Mazda", Model="MX-5", ParentCompany="Mazda", Body="Convertible", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="BMW", Model="Z4", ParentCompany="BMW Group", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Mercedes-Benz", Model="SL-Class", ParentCompany="Daimler", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Porsche", Model="718 Boxster", ParentCompany="VW Group", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Audi", Model="TT Roadster", ParentCompany="VW Group", Body="Convertible", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Fiat", Model="124 Spider", ParentCompany="Stellantis", Body="Convertible", Country="İtalya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Mini", Model="Mini Convertible", ParentCompany="BMW Group", Body="Convertible", Country="İngiltere", Continent="Avrupa", Power="ICE"},
new Car { Brand="Ford", Model="Mustang Convertible", ParentCompany="Ford", Body="Convertible", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Chevrolet", Model="Corvette Convertible", ParentCompany="GM", Body="Convertible", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Jaguar", Model="F-Type", ParentCompany="JLR", Body="Convertible", Country="İngiltere", Continent="Avrupa", Power="ICE"},

// =====================
// STATION WAGON (Wagon / Estate / Avant / Touring / Combi)
// =====================
new Car { Brand="Volkswagen", Model="Passat Variant", ParentCompany="VW Group", Body="Wagon", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Volkswagen", Model="Golf Variant", ParentCompany="VW Group", Body="Wagon", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Audi", Model="A4 Avant", ParentCompany="VW Group", Body="Wagon", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Audi", Model="A6 Avant", ParentCompany="VW Group", Body="Wagon", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Skoda", Model="Octavia Combi", ParentCompany="VW Group", Body="Wagon", Country="Çekya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Skoda", Model="Superb Combi", ParentCompany="VW Group", Body="Wagon", Country="Çekya", Continent="Avrupa", Power="ICE"},
new Car { Brand="BMW", Model="3 Series Touring", ParentCompany="BMW Group", Body="Wagon", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="BMW", Model="5 Series Touring", ParentCompany="BMW Group", Body="Wagon", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Mercedes-Benz", Model="E-Class Estate", ParentCompany="Daimler", Body="Wagon", Country="Almanya", Continent="Avrupa", Power="ICE"},
new Car { Brand="Volvo", Model="V60", ParentCompany="Geely", Body="Wagon", Country="İsveç", Continent="Avrupa", Power="Hybrid"},

// =====================
// PICKUP
// =====================
new Car { Brand="Ford", Model="F-150", ParentCompany="Ford", Body="Pickup", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Ford", Model="Ranger", ParentCompany="Ford", Body="Pickup", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Toyota", Model="Hilux", ParentCompany="Toyota", Body="Pickup", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Toyota", Model="Tacoma", ParentCompany="Toyota", Body="Pickup", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Chevrolet", Model="Silverado", ParentCompany="GM", Body="Pickup", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="GMC", Model="Sierra", ParentCompany="GM", Body="Pickup", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Ram", Model="1500", ParentCompany="Stellantis", Body="Pickup", Country="ABD", Continent="Amerika", Power="ICE"},
new Car { Brand="Nissan", Model="Navara", ParentCompany="Nissan", Body="Pickup", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Mitsubishi", Model="L200", ParentCompany="Mitsubishi", Body="Pickup", Country="Japonya", Continent="Asya", Power="ICE"},
new Car { Brand="Isuzu", Model="D-Max", ParentCompany="Isuzu", Body="Pickup", Country="Japonya", Continent="Asya", Power="ICE"},


// =====================
// ELECTRIC
// =====================
new Car { Brand="Tesla", Model="Model S", ParentCompany="Tesla", Body="Sedan", Country="ABD", Continent="Amerika", Power="EV"},
new Car { Brand="Tesla", Model="Model X", ParentCompany="Tesla", Body="SUV", Country="ABD", Continent="Amerika", Power="EV"},
new Car { Brand="Tesla", Model="Model Y", ParentCompany="Tesla", Body="SUV", Country="ABD", Continent="Amerika", Power="EV"},

new Car { Brand="Polestar", Model="2", ParentCompany="Geely", Body="Sedan", Country="İsveç", Continent="Avrupa", Power="EV"},
new Car { Brand="BYD", Model="Atto 3", ParentCompany="BYD", Body="SUV", Country="Çin", Continent="Asya", Power="EV"},
new Car { Brand="TOGG", Model="T10X", ParentCompany="TOGG", Body="SUV", Country="Türkiye", Continent="Asya", Power="EV"},


};


        int i = 1;
        foreach (var car in cars)
        {
            Console.WriteLine($"⏳ [{i}/{cars.Count}] {car.Brand} {car.Model}");

            var wikiUrl = await WikiService.GetCarImageUrl(car.Brand, car.Model);

            if (!string.IsNullOrEmpty(wikiUrl))
            {
                car.ImageUrl = await ImageHelper.DownloadAndSaveImage(
                    wikiUrl,
                    car.Brand,
                    car.Model,
                    webRootPath
                );

                if (string.IsNullOrEmpty(car.ImageUrl))
                    car.ImageUrl = "/images/no-image.png";
            }
            else
            {
                car.ImageUrl = "/images/no-image.png";
            }

            context.Cars.Add(car);
            i++;

            await Task.Delay(200);
        }

        await context.SaveChangesAsync();
        Console.WriteLine("🏁 VERİTABANI VE RESİMLER HAZIR!");
    }
}
