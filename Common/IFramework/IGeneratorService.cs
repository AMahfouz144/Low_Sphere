namespace Common.Common
{
    public interface IGeneratorService
    {
        string GenerateReferenceId(int length = 10, bool containsChars = true, bool containsNumbers = true);
        string GeneratePassword(int length = 8, bool containsCaptelChars = true, bool containsNumbers = true, bool containsSpecialChars = true);
    }
}