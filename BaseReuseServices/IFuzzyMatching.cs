namespace BaseReuseServices
{
    public interface IFuzzyMatching
    {
        double Distance(string string1, string string2);
        double Proximity(string string1, string string2);
    }
}
