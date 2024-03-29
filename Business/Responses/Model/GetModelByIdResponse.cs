﻿namespace Business.Responses.Model
{
    public class GetModelByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string? Brand { get; set; } = null;
        public int FuelId { get; set; }
        public string? Fuel { get; set; } = null;
        public int TransmissionId { get; set; }
        public string? Transmission { get; set; } = null;
        public short Year { get; set; }
        public decimal DailyPrice { get; set; }
    }
}