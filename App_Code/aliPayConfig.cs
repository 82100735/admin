using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// config 的摘要说明
/// </summary>
public class aliPayConfig
{
    public aliPayConfig()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    // 应用ID,您的APPID
    public static string app_id = "2018052260132994";

    // 支付宝网关
    public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

    // 商户私钥，您的原始格式RSA私钥
    public static string private_key = "MIIEpgIBAAKCAQEA9p8q3ivgA5tu67Hk5IU/C5jGsvgmu4mlfQiycKZ/iwEGpsoeVNV7mLx1Ij7a6pdV2P8+3uNXjkHJgBwdFmHqS+YYDFT2S3YbxlYcBxPLEFJpGg1gGP45vTSXmZiPWzObfwMVbLmsmQyvIpiaPM6OsIw4eGuZtt69jJ0Uq+lH0RLUZj6pKy/1+3fshyZGxMSDFjGnvpcV0bx9HULecSv4xuYduzDlr0bsHSJEzsrETQaLbSjBu/jvLgisGTeJbmyyrISHEsCZ2Rr3H3oh8Z0SJ/XpSd4hM4uShVjrXKbSvem468HLHQiDgjAZGFdfBkPcsG3J6jq1Rk/L1ZKhn2p8DQIDAQABAoIBAQDivcgN58zXxCog7LeDGrayFM5qcRg7R/wsjrhwNcQBqvnQkvd8C6LM9EfFKoDfOjAlh9bn2aEAG6AE9tQPZgqhqXTmsZ6YFojGuxidsSb7ZKlY2H9Hu0SeniHbh5YVxcbq6YzjH3p+ZFkIt8Dmswoha2nn3RXAOd2P0EPXIm1y28z0C3EbcFHnsVGptPU0Y/g9Yv3Rn+bOAx8xm8O+fo6UZsqYLi8wRQFyYvaXr+9mwvDQ0JbR1y1Jvz19DZjFYyf24JE+aLfWOEUFmp4ubzNd2O8mFuMGCZzOdVJy9MaM2vC8K516EHUbEi8xKW9IOg25I+jRFJCAH74cLHjBRRcJAoGBAP7cf9cbkvRCo/fRcKlgdUsCvHwGjVpITrO5yaMv6yMZN9Dq8hSlkmg53/zQlYqh3C9YoaeM65tv8miwgww7DfVIJJKTqn0981BJvWZbOk9BN9EOpdyeHQNGH0HGtoyc/ss3ozMsVwMz+6OogmkCHuouStOqvtuBAHUJ2xxWVNUHAoGBAPe5PnRbWkv2n8Jkf10hChLGe74b25K1Fq8AS/ouVjwnDSSzqC2Sfq1XJxXjyZFMh2Yq52EB6gHd1LNv3RtxXfx+TEqp/V3LOVivamlHDG3SQQ9seGjlw2KX0XSYUAhllkeRJJPAm2ldV3vWj/O5LMg2P4npMhqV76QJgdjtFZVLAoGBAPxtSxW0Uu4pXxwiTjMEvcfo0uUI3FJSkdkDKArAeGWQIa+ENPdsMsGWqRpPQf5IaLxgTeSU9/tBethkE7g2eZG6vbaMGW3owSiBkN1jeDJthypCFteXp2bJukW82qwVB2wiFDuoLBqZDyE+0sPM/O+3oBdb46Ondtt1QpcjjuxbAoGBANR441ODozAyaRafggpLs0slSK9nT25Guh0BoSkFI1vWltRa762ez943OUPyK0nfnOaJeAlhTeep76y0Dq5iDx3o6eDEapdPHnGtixSfJs7vHnRvMduu7mWbF8DsfwCkuT/LAtdjxSibMdT61F9T/VAAD4FnLV1WKsPEj8WSnAd/AoGBAPWcRV89qjeSbl0jOE6DzYUfQOFSaJx0o+dROSdt5gdpvxUaE8/q/5wV0Tq4+flMisewbwtCBjE7pT9lEqpOqdqmxsPujvGhtJxLyokfDc0BYF2xNeRL/FDy7TOHp585qp3I4R3KiwHr075PiAMXSD6QksAc+jiMriuauoWdxlOo";

    // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
    public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgmiSwO/kPxg4Le6kRSQm+rwtHXyz0dQquqGcp1CEb/pMp4cWknmRQogu0gDKmjI6Zpsj3IvIw8UT5sniUkbCZslUFzC5gVdP90OJhU5IOT2xkwN/P4hQcXNXpZqW1S6xuolx4ctEjyTYZowxV3RpYP/xxliC/61JDMkKl4Pt6TbyrMJAmtBRY5L9Qv0HiMjaFhZBHT0B7rmbDegLttYNHFbsLmsP/X8PS3wl2/r36DGWz1XL6CUB/0LSOIKNrvnP07tAMDeQridPaSFaogEIf/Y45X6OfENVrqLiWvzbUuB5eo8/6Pi1DgvgwBIJW+2+Ef5joZAUKx1gDEokyH68oQIDAQAB";

    // 签名方式
    public static string sign_type = "RSA2";

    // 编码格式
    public static string charset = "UTF-8";
}