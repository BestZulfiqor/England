namespace England.User;

public class UserData
{
    public string StepikId { get; set; }

    public override string ToString()
    {
        return $"Stepik={StepikId}";
    }
}