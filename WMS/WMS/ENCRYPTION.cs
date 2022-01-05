using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Extra Using
using System.Security.Cryptography;
using System.IO;

namespace WMS
{
    /// <summary>
    /// 不可逆加密格式列舉
    /// </summary>
    internal enum HashEncryption : int
    {
        /// <summary>
        /// 不可逆編碼 MD5
        /// </summary>
        MD5 = 1,
        /// <summary>
        /// 不可逆編碼 SHA1
        /// </summary>
        SHA1 = 2,
        /// <summary>
        /// 不可逆編碼 SHA384
        /// </summary>
        SHA384 = 3
    }

    /// <summary>
    /// 可逆對稱式加密格式列舉
    /// </summary>
    internal enum CryptFormat
    {
        /// <summary>
        /// 可逆對稱式加密格式RB64，加密字串每次都不同
        /// </summary>
        RB64,
        /// <summary>
        /// 可逆對稱式加密格式DES，較為目前世界上較為廣泛運用的加密格式之一，加密字串隨Key不同而不同
        /// </summary>
        DES
    }

    /// <summary>
    /// 加密解密類別
    /// </summary>
    internal class ENCRYPTION
    {
        private string _defaultKey = "xyzabcsu";

        /// <summary>加密字串(不可解密)</summary>
        /// <param name="source">需要查湊的字串</param>
        /// <param name="encryptionEnum">加密格式</param>
        private string GetEncrypt(string source, HashEncryption encryptionEnum)
        {
            HashAlgorithm hashAlgorithm = null;

            switch (encryptionEnum)
            {
                case HashEncryption.MD5:
                    {
                        hashAlgorithm = new MD5CryptoServiceProvider();
                        break;
                    }
                case HashEncryption.SHA1:
                    {
                        hashAlgorithm = new SHA1CryptoServiceProvider();
                        break;
                    }
                case HashEncryption.SHA384:
                    {
                        hashAlgorithm = new SHA384Managed();
                        break;
                    }
                default:
                    //Error case
                    break;
            }

            byte[] byteValue1 = Encoding.UTF8.GetBytes(source);
            byte[] hashValue1 = hashAlgorithm.ComputeHash(byteValue1);

            return Convert.ToBase64String(hashValue1);
        }

        /// <summary>加密字串(可解密)</summary>
        /// <param name="source">需要查湊的字串</param>
        /// <param name="key">加密鑰匙</param>
        /// <param name="cryptFormat">加密格式</param>
        /// <returns>傳回加密字串且須金鑰才可以解密</returns>
        private string GetEncrypt(string source, string key, CryptFormat cryptFormat)
        {
            string str = string.Empty;

            try
            {
                switch (cryptFormat)
                {
                    case CryptFormat.RB64:
                        str = GetEncryptByRB64(source, key);
                        break;

                    case CryptFormat.DES:
                        str = EncryptByDES(source, key);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return str;
        }

        /// <summary>加密字串(可解密)</summary>
        /// <param name="source">需要查湊的字串</param>
        /// <param name="cryptFormat">加密格式</param>
        /// <returns>傳回加密字串且不用金鑰就可以解密</returns>
        internal string GetEncrypt(string source, CryptFormat cryptFormat)
        {
            return GetEncrypt(source, _defaultKey, cryptFormat);
        }

        /// <summary>
        /// 傳回解密字串
        /// </summary>
        /// <param name="source">需解密字串</param>
        /// <param name="key">解密鑰匙</param>
        /// <param name="cryptFormat">解密格式</param>
        /// <returns>Key正確傳回解密結果錯誤傳回未解密字串</returns>
        private string GetDecrypt(string source, string key, CryptFormat cryptFormat)
        {
            string str = string.Empty;

            try
            {
                switch (cryptFormat)
                {
                    case CryptFormat.RB64:
                        str = GetDecryptByRB64(source, key);
                        break;

                    case CryptFormat.DES:
                        str = DecryptByDES(source, key);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return str;
        }

        /// <summary>
        /// 傳回解密字串
        /// </summary>
        /// <param name="source">需解密字串</param>
        /// <param name="key">解密鑰匙</param>
        /// <param name="cryptFormat">解密格式</param>
        /// <returns>傳回解密結果錯誤傳回未解密字串</returns>
        internal string GetDecrypt(string source, CryptFormat cryptFormat)
        {
            return GetDecrypt(source, _defaultKey, cryptFormat);
        }

        /// <summary>
        /// 加密使用RB64
        /// </summary>
        /// <param name="stringSource">來源字串</param>
        /// <param name="key">加密鑰匙</param>
        /// <returns>傳回加密字串且須金鑰才可以解密</returns>
        private string GetEncryptByRB64(string stringSource, string key)
        {
            byte[] stringSourceBytes = System.Text.Encoding.UTF8.GetBytes(key + stringSource);

            int defaultLength = 30;                               //預設加密後的長度

            byte[] stringBytes_New = null;

            //如果原始字串長度沒有超過 設定的長度
            if (stringSourceBytes.Length <= defaultLength - 7)  //0 = KEY位置、1,2 = 原字串長度、3=原字串開始位置、4,5=外部key、KEY(隨機位置)
            {
                stringBytes_New = new byte[defaultLength];
            }
            else
            {
                stringBytes_New = new byte[stringSourceBytes.Length + 7];
            }

            Random ran = new Random(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second);

            int ranKey = ran.Next(1, 10);     //加密的KEY

            int keyPosition = 6;                      //放入Key要放的位置 必須大於1且小於長度

            if ((stringBytes_New.Length) > 256)
            {
                keyPosition = ran.Next(6, 255);                      //放入Key要放的位置 必須大於1且小於長度
            }
            else
            {
                keyPosition = ran.Next(6, stringBytes_New.Length - 1);                      //放入Key要放的位置 必須大於1且小於長度
            }

            //放入Key要放的位置
            stringBytes_New[0] = Convert.ToByte(keyPosition);

            //原字串開始位置
            int sourceStart = ran.Next(6, (stringBytes_New.Length - stringSourceBytes.Length) - 1);
            stringBytes_New[1] = Convert.ToByte(sourceStart);

            //原字串Bytes長度 2 Byte
            stringBytes_New[2] = Convert.ToByte(Math.Floor(Convert.ToDecimal((stringSourceBytes.Length + stringBytes_New[1]) / 256)));                        //原字串Bytes長度進位(字串長度加密)
            stringBytes_New[3] = Convert.ToByte((stringSourceBytes.Length + stringBytes_New[1]) % 256);                        //原字串Bytes長度餘數(字串長度加密)

            stringBytes_New[4] = Convert.ToByte(Math.Floor(Convert.ToDecimal((key.Length + stringBytes_New[1]) / 256)));                        //key長度進位
            stringBytes_New[5] = Convert.ToByte((key.Length + stringBytes_New[1]) % 256);                        //key長度進位餘數

            //計算結束位置
            int sourceEnd = 0;
            if (keyPosition >= sourceStart && keyPosition < sourceStart + stringSourceBytes.Length)
            {
                sourceEnd = sourceStart + stringSourceBytes.Length;
            }
            else
            {
                sourceEnd = sourceStart + stringSourceBytes.Length - 1;
            }

            //執行來源字串加密及key存放
            int newByteTemp;
            int iIndex_Source = 0;
            for (int i = 6; i < stringBytes_New.Length; i++)
            {
                //指向來源字串區間時
                if (i >= sourceStart && i <= sourceEnd && keyPosition != i) //達到原字串開始位置
                {
                    newByteTemp = stringSourceBytes[iIndex_Source] + ranKey; // 放入來源字串並使用KEY加密

                    iIndex_Source++;

                    if (newByteTemp > 255)
                    {
                        newByteTemp = newByteTemp - 255 - 1;
                    }
                }
                else if (keyPosition == i) //指向key位置時
                {
                    newByteTemp = Convert.ToByte(ranKey);
                }
                else   //指向其他位置時
                {
                    newByteTemp = Convert.ToByte(ran.Next(0, 255));         //加入亂數
                }

                stringBytes_New[i] = Convert.ToByte(newByteTemp);
            }

            return Convert.ToBase64String(stringBytes_New);
        }

        /// <summary>
        /// 傳回解密字串使用RB64
        /// </summary>
        /// <param name="stringSource">需解密字串</param>
        /// <param name="key">解密鑰匙</param>
        /// <returns>Key正確傳回解密結果錯誤傳回未解密字串</returns>
        private string GetDecryptByRB64(string stringSource, string key)
        {
            //key position
            byte[] stringBytes_code = Convert.FromBase64String(stringSource);

            int key_position_decode = stringBytes_code[0];
            int key_code = stringBytes_code[key_position_decode];

            //原字串長度
            int source_length_code = ((stringBytes_code[2]) * 256) + (stringBytes_code[3] - stringBytes_code[1]);

            //原字串開始位置
            int source_strat_code = stringBytes_code[1];

            byte[] stringBytes_Decode_temp = new byte[source_length_code];

            int iIndex_Code = 0;
            int byteTemp_code = 0;
            int source_end_decode = 0;

            if (key_position_decode >= source_strat_code && key_position_decode < source_strat_code + source_length_code)
            {
                source_end_decode = source_strat_code + source_length_code;
            }
            else
            {
                source_end_decode = source_strat_code + source_length_code - 1;
            }

            for (int i = source_strat_code; i <= source_end_decode; i++)
            {
                if (i == key_position_decode)
                {
                    continue;
                }

                byteTemp_code = stringBytes_code[i] - key_code;

                if (byteTemp_code < 0)
                {
                    byteTemp_code = 256 + byteTemp_code;
                }
                stringBytes_Decode_temp[iIndex_Code] = Convert.ToByte(byteTemp_code);
                iIndex_Code++;
            }
            //------------------------------------------------------------------------------------------------------------------------------------------------------------

            byte[] stringBytes_Decode = new byte[stringBytes_Decode_temp.Length];
            for (int i = 0; i < stringBytes_Decode.Length; i++)
            {
                stringBytes_Decode[i] = stringBytes_Decode_temp[i];
            }

            //解密結果含Key
            string decodeFinish = System.Text.Encoding.UTF8.GetString(stringBytes_Decode);

            //比對Key正確傳回解密結果錯誤傳回未解密字串
            //原字串長度
            int key_length = ((stringBytes_code[4]) * 256) + stringBytes_code[5] - stringBytes_code[1];
            if (decodeFinish.Length >= key_length && decodeFinish.Substring(0, key_length) == key)
            {
                decodeFinish = decodeFinish.Substring(key.Length, decodeFinish.Length - key.Length);
            }
            else
            {
                decodeFinish = stringSource;
            }

            return decodeFinish;
        }

        /// <summary>
        /// 使用DES格式加密
        /// </summary>
        /// <param name="stringInput">輸入字串</param>
        /// <param name="key">金鑰，必須為8碼的英文數字</param>
        /// <returns></returns>
        private string EncryptByDES(string stringInput, string key)
        {
            string str = string.Empty;
            try
            {
                //建立 串流、加密用介面、取得使用者使定的Key、提供固定的VI供加密用、加密結果
                MemoryStream ms = new MemoryStream();
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
                cryptoProvider.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform iCryptoTransform = cryptoProvider.CreateEncryptor(cryptoProvider.Key, cryptoProvider.IV);
                byte[] buffer = System.Text.Encoding.Unicode.GetBytes(stringInput);

                //建立加密串流
                CryptoStream cryptStream = new CryptoStream(ms, iCryptoTransform, CryptoStreamMode.Write);
                cryptStream.Write(buffer, 0, buffer.Length);
                cryptStream.FlushFinalBlock();

                str = Convert.ToBase64String(ms.ToArray());

                buffer = null;
                cryptStream.Close();
                ms.Close();
            }
            catch (CryptographicException)
            {
                str = stringInput;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        /// <summary>
        /// 使用DES格式解密
        /// </summary>
        /// <param name="stringInput">輸入字串</param>
        /// <param name="key">金鑰，必須為8碼的英文數字</param>
        /// <returns></returns>
        private string DecryptByDES(string stringInput, string key)
        {
            string str = string.Empty;
            try
            {
                //建立 串流、解密用介面、取得使用者使定的Key、提供固定的VI供解密用、解密結果
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                cryptoProvider.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
                cryptoProvider.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
                ICryptoTransform iCryptoTransform = cryptoProvider.CreateDecryptor(cryptoProvider.Key, cryptoProvider.IV);
                byte[] buffer = Convert.FromBase64String(stringInput);
                MemoryStream ms = new MemoryStream(buffer);
                //建立解密串流
                CryptoStream cryptStream = new CryptoStream(ms, iCryptoTransform, CryptoStreamMode.Read);

                StreamReader streamReader = new StreamReader(cryptStream, System.Text.Encoding.GetEncoding(System.Text.Encoding.Unicode.EncodingName));

                str = streamReader.ReadToEnd();

                buffer = null;

                streamReader.Close();
                cryptStream.Close();
                ms.Close();
            }
            catch (CryptographicException)
            {
                str = stringInput;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        #region 註解備份

        ///// <summary>
        ///// 加密使用R01
        ///// </summary>
        ///// <param name="stringSource">來源字串</param>
        ///// <param name="key">加密鑰匙</param>
        ///// <returns></returns>
        //private string GetEncryptByR01(string stringSource, string key)
        //{
        //    byte[] stringSourceTemp = System.Text.Encoding.UTF8.GetBytes(key + stringSource);

        //    byte[] stringBytes = new byte[stringSourceTemp.Length * 2];  //將一個byte拆成2個byte長度(為了中文的Byte可以轉成ASCII(英文及符號)代碼範圍33~126 = 94bit

        //    byte getByte = 0;

        //    for (int i = 0; i < stringSourceTemp.Length; i++)
        //    {
        //        getByte = Convert.ToByte(Math.Floor(Convert.ToDecimal(stringSourceTemp[i]) / 16));
        //        stringBytes[i * 2] = Convert.ToByte(getByte + 32);
        //        getByte = Convert.ToByte(stringSourceTemp[i] % 16);
        //        stringBytes[(i * 2) + 1] = Convert.ToByte(getByte + 32);
        //    }

        //    int defaultLength = 30;                               //預設加密後的長度

        //    //LOG_String("int defaultLength = 30;                               //預設加密後的長度 ");

        //    byte[] stringBytes_New = null;
        //    int byteLength = 1; //字串長度需要的byte數
        //    //如果原始字串長度沒有超過 設定的長度-2(KEY、KEY位置)
        //    if (stringBytes.Length <= defaultLength - 5)  //0 = KEY位置、1=原字串開始位置、2~n = 原字串結束位置、KEY(隨機位置)
        //    {
        //        stringBytes_New = new byte[defaultLength];
        //    }
        //    else
        //    {
        //        //計算字串長度需要的byte數
        //        while (stringBytes.Length > Math.Pow(93, byteLength))   //33~126有效所以用126-33=93計算
        //        {
        //            byteLength++;
        //        }

        //        //字串轉成byte後的長度(stringBytes.Length)+KEY位置+原字串開始位置+紀錄原字串結束位置所用Bytes數量+原字串結束位置(byteLength)+KEY(隨機位置)
        //        stringBytes_New = new byte[stringBytes.Length + byteLength + 4];
        //    }

        //    Random ran = new Random(DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second);


        //    int ranKey = ran.Next(1, 10);     //加密的KEY

        //    int keyPosition = 3 + byteLength;                      //放入Key要放的位置 必須大於1且小於長度
        //    if ((stringBytes_New.Length - 1 + 29) > 126)
        //    {
        //        keyPosition = ran.Next(3 + byteLength, 126 - 29);                      //放入Key要放的位置 必須大於1且小於長度
        //    }
        //    else
        //    {
        //        keyPosition = ran.Next(3 + byteLength, stringBytes_New.Length - 1);                      //放入Key要放的位置 必須大於1且小於長度
        //    }

        //    int index_New = 0;

        //    stringBytes_New[index_New++] = Convert.ToByte(keyPosition + 29);

        //    int sourceStart = ran.Next(3 + byteLength, (stringBytes_New.Length - stringBytes.Length) - 1);     //原字串開始位置

        //    stringBytes_New[index_New++] = Convert.ToByte(sourceStart + 30);


        //    stringBytes_New[index_New++] = Convert.ToByte(byteLength + 33);  //紀錄使用來記錄字串bytes結束位置的bytes數量



        //    //stringBytes_New[iIndex_Source++] = Convert.ToByte(Math.Floor(Convert.ToDecimal((stringBytes.Length + stringBytes_New[1]) / 130)) + 33);                        //原字串Bytes長度進位(字串長度加密)

        //    decimal stringBytesEndTemp = Convert.ToDecimal(stringBytes.Length - 1 + stringBytes_New[1] - 30);  //字串bytes結束位置

        //    for (int i = byteLength; i > 1; i--)
        //    {
        //        stringBytes_New[index_New] = Convert.ToByte(Math.Floor(Convert.ToDecimal(stringBytesEndTemp / Convert.ToDecimal(Math.Pow(93, i - 1))) + 33));                        //原字串Bytes長度進位(字串長度加密)
        //        stringBytesEndTemp -= (stringBytes_New[index_New] - 33) * Convert.ToDecimal(Math.Pow(93, i - 1));
        //        index_New++;
        //    }

        //    stringBytes_New[index_New++] = Convert.ToByte((stringBytesEndTemp % 93) + 33);

        //    //stringBytes_New[3] = Convert.ToByte((stringBytes.Length + stringBytes_New[1]) % 130);                        //原字串Bytes長度餘數(字串長度加密)

        //    int newByteTemp;

        //    int sourceEnd = 0;

        //    if (keyPosition >= sourceStart && keyPosition < sourceStart + stringBytes.Length)
        //    {
        //        sourceEnd = sourceStart + stringBytes.Length;
        //    }
        //    else
        //    {
        //        sourceEnd = sourceStart + stringBytes.Length - 1;
        //    }

        //    int iIndex_Source = 0;
        //    for (int i = index_New; i < stringBytes_New.Length; i++)
        //    {
        //        if (i >= sourceStart && i <= sourceEnd && keyPosition != i) //達到原字串開始位置
        //        {

        //            newByteTemp = stringBytes[iIndex_Source] + ranKey; // 放入來源字串並使用KEY加密

        //            iIndex_Source++;

        //            if (newByteTemp > 255)
        //            {
        //                newByteTemp = newByteTemp - 255 - 1;
        //            }
        //        }
        //        else if (keyPosition == i)
        //        {
        //            newByteTemp = Convert.ToByte(ranKey + 42);
        //        }
        //        else   //未達到原字串開始位置
        //        {
        //            newByteTemp = Convert.ToByte(ran.Next(33, 126));         //加入亂數
        //        }

        //        stringBytes_New[i] = Convert.ToByte(newByteTemp);
        //    }

        //    return System.Text.Encoding.ASCII.GetString(stringBytes_New);
        //}


        ///// <summary>
        ///// 傳回解密字串使用R01
        ///// </summary>
        ///// <param name="stringSource">需解密字串</param>
        ///// <param name="key">解密鑰匙</param>
        ///// <returns>Key正確傳回解密結果錯誤傳回未解密字串</returns>
        //private string GetDecryptByR01(string stringSource, string key)
        //{
        //    //key position
        //    byte[] stringBytes_code = System.Text.Encoding.ASCII.GetBytes(stringSource);

        //    int key_position_decode = stringBytes_code[0] - 29;
        //    int key_code = stringBytes_code[key_position_decode] - 42;

        //    //原字串開始位置
        //    int source_strat_code = stringBytes_code[1] - 30;


        //    //原字串結束位置
        //    //------------------------------------------------------------------------------------------------------------------
        //    int stringBytesLengthUsedBytesCount = stringBytes_code[2] - 33;      //取得紀錄原字串結束位置使用的byte數量
        //    int source_end_decode = 0;
        //    for (int i = stringBytesLengthUsedBytesCount; i > 1; i--)
        //    {
        //        source_end_decode += ((stringBytes_code[stringBytesLengthUsedBytesCount - i + 3] - 33) * Convert.ToInt32(Math.Pow(93, i - 1)));
        //    }
        //    source_end_decode += stringBytes_code[stringBytesLengthUsedBytesCount + 2] - 33;
        //    //------------------------------------------------------------------------------------------------------------------

        //    byte[] stringBytes_Decode_temp = new byte[source_end_decode - source_strat_code + 1];

        //    int iIndex_Code = 0;
        //    int byteTemp_code = 0;

        //    if (key_position_decode >= source_strat_code && key_position_decode <= source_end_decode)
        //    {
        //        source_end_decode += 1;
        //    }

        //    for (int i = source_strat_code; i <= source_end_decode; i++)
        //    {
        //        if (i == key_position_decode)
        //        {
        //            continue;
        //        }

        //        byteTemp_code = stringBytes_code[i] - key_code;

        //        if (byteTemp_code < 0)
        //        {
        //            byteTemp_code = 256 + byteTemp_code;
        //        }
        //        stringBytes_Decode_temp[iIndex_Code] = Convert.ToByte(byteTemp_code);
        //        iIndex_Code++;
        //    }


        //    byte[] stringBytes_Decode = new byte[stringBytes_Decode_temp.Length / 2];

        //    int getByte_Decode = 0;
        //    for (int i = 0; i < stringBytes_Decode.Length; i++)
        //    {
        //        getByte_Decode = stringBytes_Decode_temp[i * 2] - 32;
        //        getByte_Decode = getByte_Decode * 16;
        //        getByte_Decode = getByte_Decode + stringBytes_Decode_temp[(i * 2) + 1] - 32;
        //        stringBytes_Decode[i] = Convert.ToByte(getByte_Decode);
        //    }

        //    //解密結果含Key
        //    string decodeFinish = System.Text.Encoding.UTF8.GetString(stringBytes_Decode);

        //    //比對Key正確傳回解密結果錯誤傳回未解密字串
        //    if (decodeFinish.StartsWith(key) == true)
        //    {
        //        decodeFinish = decodeFinish.Substring(key.Length, decodeFinish.Length - key.Length);

        //        //如果解出來的字串不等於原長度+Key長度及判斷為Key錯誤
        //        if ((decodeFinish.Length + key.Length) != ((source_length_code - source_strat_code) / 2))
        //        {
        //            decodeFinish = stringSource;
        //        }
        //    }
        //    else
        //    {
        //        decodeFinish = stringSource;
        //    }

        //    return decodeFinish;
        //}

        #endregion
    }
}
