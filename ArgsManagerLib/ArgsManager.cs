using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArgsManagerLib
{
    public class ArgsManager
    {
        public List<string> Args { get; private set; } = new List<string>();
        public List<string> Keys { get; private set; } = new List<string>();
        public Dictionary<string, string> KeyValuePairs { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// インデクサー
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>Value</returns>
        public string this[string key]
        {
            get { return GetValue(key); }
        }
    
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="keys">定義情報(ex. "-p xxxx"なら-pの部分)</param>
        /// <param name="args">コマンドライン引数</param>
        public ArgsManager(string[]? keys, string[]? args)
        {
            if (args != null)
            {
                this.Args = new List<string>(args);
            }

            if (keys != null)
            {
                this.Keys = new List<string>(keys);
            }

            foreach (var key in this.Keys)
            {
                this.KeyValuePairs.Add(key, GetValue(key));
            }
        }

        /// <summary>
        /// Argsの長さ
        /// </summary>
        public int Length { get {  return this.Args.Count; } }

        /// <summary>
        /// キーの長さ
        /// </summary>
        public int KeyLength { get { return this.Keys.Count; } }


        /// <summary>
        /// 指定したキーで値を取り出す
        /// </summary>
        /// <param name="key">キー情報(ex. "-p xxxx"なら-pの部分)</param>
        /// <returns>キーの次のインデックスの値(存在しない場合はstring.Empty)</returns>
        public string GetValue(string key)
        {
            var tmp = (from x in this.Keys
                       where x.Equals(key)
                       select x).FirstOrDefault();

            if (tmp == null)
                return string.Empty;

            int index = this.Args.IndexOf(key);

            if (index >= 0)
            {
                if (this.Args.Count > index + 1)
                {
                    var tmp2 = (from x in this.Keys
                                where x.Equals(this.Args[index + 1])
                                select x).FirstOrDefault();

                    if (tmp2 == null)
                    {
                        return this.Args[index + 1];
                    }
                    else
                    {
                        return "true";
                    }
                }
                else
                {
                    return "true";
                }
            }
            else
            {
                return "false";
            }
        }
    }
}
