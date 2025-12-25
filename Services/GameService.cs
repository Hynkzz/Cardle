using System;
using System.Collections.Generic;
using System.Linq;
using Cardle.Data;
using Cardle.Models;

namespace Cardle.Services;

public class GameService
{
    private readonly AppDbContext _context;
    
    // Günün Arabası (Herkes için aynı)
    public Car? DailyCar { get; private set; }

    public GameService(AppDbContext context)
    {
        _context = context;
        SetDailyCar();
    }

    // Tüm arabaları getir (Arama kutusu için)
    public List<Car> GetAllCars()
    {
        return _context.Cars.ToList();
    }

    // Rastgele bir araba getir (Sonsuz mod için)
    public Car GetRandomCar(int excludeId = -1)
    {
        var cars = _context.Cars.Where(c => c.Id != excludeId).ToList();
        if (!cars.Any()) return null;
        
        var random = new Random();
        return cars[random.Next(cars.Count)];
    }

    // Günün arabasını belirle (Tarihe göre sabit)
    private void SetDailyCar()
    {
        var cars = _context.Cars.ToList();
        if (!cars.Any()) return;

        // Bugünün tarihine göre rastgele ama sabit bir sayı üret
        int seed = DateTime.UtcNow.Year * 1000 + DateTime.UtcNow.DayOfYear;
        var random = new Random(seed);
        
        DailyCar = cars[random.Next(cars.Count)];
    }
}