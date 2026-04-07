namespace SailClubLibrary.Helpers
{
    public class ADO
    {
        public static T GetEnumValueFromInt<T>(int givenInt) where T : Enum
        {
            T chosenEnumValue = (T)(object)givenInt;
            return chosenEnumValue;
        }
    }
}
