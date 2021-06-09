using Newtonsoft.Json;

namespace Shares.Common.ObjectSerializer
{
    public abstract class JsonHelper
    {
        #region Fascade

        public static TResult Deserialize<TResult>(string jsonString) where TResult : class
        {
            return Handler.Instance.Deserialize<TResult>(jsonString);
        }
        public static string Serialize<TInput>(TInput input) where TInput : class
        {
            return Handler.Instance.Serialize(input);
        }



        #endregion

        #region Handler

        public class Handler
        {
            public static Handler Instance = new Handler();
            public TResult Deserialize<TResult>(string jsonString) where TResult : class
            {
                return JsonConvert.DeserializeObject<TResult>(jsonString);
            }
            public string Serialize<TInput>(TInput input) where TInput : class
            {
                return JsonConvert.SerializeObject(input);
            }
        }


        #endregion
    }
}
