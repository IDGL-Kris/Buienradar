public static class Analysis
{
    public static Averages Averages(Root buienradarModel)
    {
        var actualWeahter = buienradarModel.actual.stationmeasurements;

        var averages = new Averages();
        averages.AverageTemp = actualWeahter.Average(x => x.temperature);
        averages.AverageFeelingTemp = actualWeahter.Average(x => x.feeltemperature);
        averages.AverageGroundTemp = actualWeahter.Average(x => x.groundtemperature);
        averages.AverageSunPower = actualWeahter.Average(x => x.sunpower);
        return averages;
    }
}