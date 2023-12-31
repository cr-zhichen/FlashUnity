using System;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// 扩展方法
/// </summary>
public static class Expand
{
    # region 链式调用

    /// <summary>
    /// 链式调用
    /// </summary>
    /// <param name="t">自身传递</param>
    /// <param name="action">委托调用</param>
    /// <typeparam name="T">自身类</typeparam>
    /// <returns>自身传出</returns>
    public static T Do<T>(this T t, Action<T> action)
    {
        action(t);
        return t;
    }

    #endregion

    #region md5计算

    /// <summary>
    /// 计算md5值
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <param name="toUpper">是否为大写</param>
    /// <param name="to16">是否为16位md5</param>
    /// <returns>md5</returns>
    public static string ToMd5(this string str, bool toUpper = false, bool to16 = false)
    {
        //将str进行MD5加密
        var md5 = System.Security.Cryptography.MD5.Create();
        var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        var sb = new StringBuilder();
        foreach (var b in bs)
        {
            sb.Append(b.ToString(toUpper ? "X2" : "x2"));
        }

        return to16 ? sb.ToString().Substring(8, 16) : sb.ToString();
    }

    /// <summary>
    /// 计算md5值
    /// </summary>
    /// <param name="bytes">自身传递</param>
    /// <param name="toUpper">是否为大写</param>
    /// <param name="to16">是否为16位md5</param>
    /// <returns>md5</returns>
    public static string ToMd5(this byte[] bytes, bool toUpper = false, bool to16 = false)
    {
        var md5 = System.Security.Cryptography.MD5.Create();
        var bs = md5.ComputeHash(bytes);
        var sb = new StringBuilder();
        foreach (var b in bs)
        {
            sb.Append(b.ToString(toUpper ? "X2" : "x2"));
        }

        return to16 ? sb.ToString().Substring(8, 16) : sb.ToString();
    }

    #endregion

    #region 字符串转换

    /// <summary>
    /// string转int
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <returns>int值</returns>
    /// <exception cref="Exception">转换失败</exception>
    public static int ToInt(this string str)
    {
        return int.TryParse(str, out var result) ? result : throw new Exception("string转换为int失败");
    }

    /// <summary>
    /// string转float
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <returns>float值</returns>
    /// <exception cref="Exception">转换失败</exception>
    public static float ToFloat(this string str)
    {
        return float.TryParse(str, out var result) ? result : throw new Exception("string转换为float失败");
    }

    /// <summary>
    /// string转double
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <returns>double值</returns>
    /// <exception cref="Exception">转换失败</exception>
    public static double ToDouble(this string str)
    {
        return double.TryParse(str, out var result) ? result : throw new Exception("string转换为double失败");
    }

    /// <summary>
    /// string转bool
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static bool ToBool(this string str)
    {
        return bool.TryParse(str, out var result) ? result : throw new Exception("string转换为bool失败");
    }

    #endregion

    #region 字符串格式判断

    /// <summary>
    /// 判断是否是Email格式
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <returns></returns>
    public static bool IsEmail(this string str)
    {
        return Regex.IsMatch(str,
            @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
    }

    /// <summary>
    /// 判断是否是手机号格式
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <returns></returns>
    public static bool IsMobile(this string str)
    {
        return Regex.IsMatch(str, @"^1[3456789]\d{9}$");
    }

    /// <summary>
    /// 判断是否是身份证号格式
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <returns></returns>
    public static bool IsIdCard(this string str)
    {
        return Regex.IsMatch(str,
            @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$|^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X|x)$");
    }

    /// <summary>
    /// 判断是否是Url格式
    /// </summary>
    /// <param name="str">自身传递</param>
    /// <returns></returns>
    public static bool IsUrl(this string str)
    {
        return Regex.IsMatch(str,
            @"^(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*$");
    }

    /// <summary>
    /// 判断是否是ipv4格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsIpv4(this string str)
    {
        return Regex.IsMatch(str, @"^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$");
    }

    /// <summary>
    /// 判断是否是ipv6格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsIpv6(this string str)
    {
        return Regex.IsMatch(str,
            @"^([\da-fA-F]{1,4}:){6}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^::([\da-fA-F]{1,4}:){0,4}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:):([\da-fA-F]{1,4}:){0,3}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){2}:([\da-fA-F]{1,4}:){0,2}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){3}:([\da-fA-F]{1,4}:){0,1}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){4}:((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){7}[\da-fA-F]{1,4}$|^:((:[\da-fA-F]{1,4}){1,6}|:)$|^[\da-fA-F]{1,4}:((:[\da-fA-F]{1,4}){1,5}|:)$|^([\da-fA-F]{1,4}:){2}((:[\da-fA-F]{1,4}){1,4}|:)$|^([\da-fA-F]{1,4}:){3}((:[\da-fA-F]{1,4}){1,3}|:)$|^([\da-fA-F]{1,4}:){4}((:[\da-fA-F]{1,4}){1,2}|:)$|^([\da-fA-F]{1,4}:){5}:([\da-fA-F]{1,4})?$|^([\da-fA-F]{1,4}:){6}:$");
    }

    /// <summary>
    /// 判断是否是ip格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsIp(this string str)
    {
        return Regex.IsMatch(str,
            @"^((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){6}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^::([\da-fA-F]{1,4}:){0,4}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:):([\da-fA-F]{1,4}:){0,3}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){2}:([\da-fA-F]{1,4}:){0,2}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){3}:([\da-fA-F]{1,4}:){0,1}((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){4}:((25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[01]?\d\d?)$|^([\da-fA-F]{1,4}:){7}[\da-fA-F]{1,4}$|^:((:[\da-fA-F]{1,4}){1,6}|:)$|^[\da-fA-F]{1,4}:((:[\da-fA-F]{1,4}){1,5}|:)$|^([\da-fA-F]{1,4}:){2}((:[\da-fA-F]{1,4}){1,4}|:)$|^([\da-fA-F]{1,4}:){3}((:[\da-fA-F]{1,4}){1,3}|:)$|^([\da-fA-F]{1,4}:){4}((:[\da-fA-F]{1,4}){1,2}|:)$|^([\da-fA-F]{1,4}:){5}:([\da-fA-F]{1,4})?$|^([\da-fA-F]{1,4}:){6}:$");
    }

    /// <summary>
    /// 判断是否包含中文
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsChinese(this string str)
    {
        return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
    }

    /// <summary>
    /// 判断是否是中文姓名格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsChineseName(this string str)
    {
        return Regex.IsMatch(str, @"^[\u4e00-\u9fa5]{2,4}$");
    }

    /// <summary>
    /// 判断是否是英文
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsEnglish(this string str)
    {
        return Regex.IsMatch(str, @"^[A-Za-z]+$");
    }

    /// <summary>
    /// 判断是否是大写英文
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsUpperEnglish(this string str)
    {
        return Regex.IsMatch(str, @"^[A-Z]+$");
    }

    /// <summary>
    /// 判断是否是小写英文
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsLowerEnglish(this string str)
    {
        return Regex.IsMatch(str, @"^[a-z]+$");
    }

    #endregion

    #region 敏感信息处理

    /// <summary>
    /// 身份证号码脱敏
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string MaskIdCard(this string str)
    {
        return str.IsIdCard()
            ? str.Substring(0, 6) + "********" + str.Substring(14, 4)
            : throw new Exception("不是有效的身份证号码");
    }

    /// <summary>
    /// 手机号码脱敏
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static string MaskMobile(this string str)
    {
        return str.IsMobile()
            ? str.Substring(0, 3) + "****" + str.Substring(7, 4)
            : throw new Exception("不是有效的手机号码");
    }

    /// <summary>
    /// 邮箱脱敏
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static string MaskEmail(this string str)
    {
        return str.IsEmail()
            ? str.Substring(0, 3) + "****" + str.Substring(str.IndexOf('@'))
            : throw new Exception("不是有效的邮箱地址");
    }

    #endregion

    #region 时间戳转换

    /// <summary>
    /// 获取毫秒级时间戳
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static double GetTotalMilliseconds(this DateTime dt)
    {
        return (dt - new DateTime(1970, 1, 1)).TotalMilliseconds;
    }

    /// <summary>
    /// 获取秒级时间戳
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static double GetTotalSeconds(this DateTime dt)
    {
        return (dt - new DateTime(1970, 1, 1)).TotalSeconds;
    }

    /// <summary>
    /// 毫秒级时间戳转换为DateTime
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static DateTime ToDateTimeMilliseconds(this double timestamp)
    {
        return new DateTime(1970, 1, 1).AddMilliseconds(timestamp);
    }

    /// <summary>
    /// 秒级时间戳转换为DateTime
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public static DateTime ToDateTimeSeconds(this double timestamp)
    {
        return new DateTime(1970, 1, 1).AddSeconds(timestamp);
    }

    /// <summary>
    /// 获取时间差
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="dt2">传入时间</param>
    /// <returns>返回时间差 小于0为在之前，大于0为在之后 </returns>
    public static TimeSpan GetTimeDifference(this DateTime dt, DateTime dt2 = default)
    {
        return dt - (dt2 == default(DateTime) ? DateTime.UtcNow : dt2);
    }

    #endregion

    #region Unity中扩展

    #region Debug打印

    public static void Log<T>(this T t)
    {
        UnityEngine.Debug.Log(t.ToString());
    }

    public static void LogWarning<T>(this T t)
    {
        UnityEngine.Debug.LogWarning(t.ToString());
    }

    public static void LogError<T>(this T t)
    {
        UnityEngine.Debug.LogError(t.ToString());
    }

    #endregion

    #region GameObgect扩展

    /// <summary>
    /// 快速实例化
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="parent"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public static GameObject Instantiate(this GameObject obj, Transform parent = default, Quaternion rotation = default)
    {
        return GameObject.Instantiate(obj, parent);
    }

    /// <summary>
    /// 设置子物体层级
    /// </summary>
    /// <param name="go"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static GameObject SetLayer(this GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform item in go.transform)
        {
            SetLayer(item.gameObject, layer);
        }

        return go;
    }

    #endregion

    #region 图片转换
    
    //去除base64前缀
    public static string RemoveBase64Prefix(this string base64)
    {
        return base64.Substring(base64.IndexOf(',') + 1);
    }

    /// <summary>
    /// base64转换为Texture2D
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public static Texture2D ToTexture2D(this string base64)
    {
        byte[] bytes = Convert.FromBase64String(base64);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }

    /// <summary>
    /// Texture2D转换为base64
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static string ToBase64(this Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG();
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// RenderTexture转换为Texture2D
    /// </summary>
    /// <param name="renderTexture"></param>
    /// <returns></returns>
    public static Texture2D ToTexture2D(this RenderTexture renderTexture)
    {
        int width = renderTexture.width;

        int height = renderTexture.height;

        Texture2D texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);

        RenderTexture.active = renderTexture;

        texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);

        texture2D.Apply();

        return texture2D;
    }

    #endregion

    #region 颜色转换

    /// <summary>
    /// 16进制转换为颜色
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Color ToColor(this string color)
    {
        ColorUtility.TryParseHtmlString(color, out Color c);
        return c;
    }

    #endregion

    #endregion
}