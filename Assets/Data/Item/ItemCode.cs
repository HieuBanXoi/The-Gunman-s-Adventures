public enum ItemCode
{
    NoItem = 0,

    IronOre = 1,
    Coin = 2,
    Gun2 =3,
}
public static class ItemCodeParse
{
    public static ItemCode FromString(string str)
    {
        if (string.IsNullOrEmpty(str)) return ItemCode.NoItem;
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), str);
    }
}