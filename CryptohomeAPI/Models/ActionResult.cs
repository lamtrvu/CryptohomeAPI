namespace CryptohomeAPI.Models
{
    public class ActionResult
    {
        public enum ActionResultStatus
        {
            Success,
            Failure
        }

        public string result { get; set; }
        public string message { get; set; }

        public ActionResult(ActionResultStatus resultStatus, string resultMessage)
        {
            result = resultStatus.ToString();
            message = resultMessage;
        }
    }
}
