using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace GetRSAParams
{
    public static class GetRSAObj
    {
        public static RSAParameters GetRSAParameters(string parametersString)
        {
            RSAParameters rsaparms = StringUtil.ConvertFromJson<RSAParametersSerializable>(parametersString).RSAParameters;
            return rsaparms;
        }
    }

    [Serializable]
    internal class RSAParametersSerializable : ISerializable
    {
        private RSAParameters _rsaParameters;

        public RSAParameters RSAParameters
        {
            get
            {
                return _rsaParameters;
            }
        }

        public RSAParametersSerializable(RSAParameters rsaParameters)
        {
            _rsaParameters = rsaParameters;
        }

        public RSAParametersSerializable(SerializationInfo information, StreamingContext context)
        {
            _rsaParameters = new RSAParameters()
            {
                D = (byte[])information.GetValue("d", typeof(byte[])),
                DP = (byte[])information.GetValue("dp", typeof(byte[])),
                DQ = (byte[])information.GetValue("dq", typeof(byte[])),
                Exponent = (byte[])information.GetValue("exponent", typeof(byte[])),
                InverseQ = (byte[])information.GetValue("inverseQ", typeof(byte[])),
                Modulus = (byte[])information.GetValue("modulus", typeof(byte[])),
                P = (byte[])information.GetValue("p", typeof(byte[])),
                Q = (byte[])information.GetValue("q", typeof(byte[]))
            };
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("d", _rsaParameters.D);
            info.AddValue("dp", _rsaParameters.DP);
            info.AddValue("dq", _rsaParameters.DQ);
            info.AddValue("exponent", _rsaParameters.Exponent);
            info.AddValue("inverseQ", _rsaParameters.InverseQ);
            info.AddValue("modulus", _rsaParameters.Modulus);
            info.AddValue("p", _rsaParameters.P);
            info.AddValue("q", _rsaParameters.Q);
        }
    }

    public static class StringUtil
    {
        //private static Lazy<JsonSerializerSettings> s_serializerSettings = new Lazy<JsonSerializerSettings>(() => new VssJsonMediaTypeFormatter().SerializerSettings);

        public static T ConvertFromJson<T>(string value)
        {
            //return JsonConvert.DeserializeObject<T>(value, s_serializerSettings.Value);
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
