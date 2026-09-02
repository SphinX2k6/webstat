using System;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004693 RID: 18067
	public static class TPublicConfigKeyExtensions
	{
		// Token: 0x0602F090 RID: 192656 RVA: 0x00B25180 File Offset: 0x00B23380
		public static string ToEnumString(this TPublicConfigKey value)
		{
			string result;
			switch (value)
			{
			case TPublicConfigKey.AppTag:
				result = "AppTag";
				break;
			case TPublicConfigKey.CheckEntryTime:
				result = "CheckEntryTime";
				break;
			case TPublicConfigKey.InternalPrefix:
				result = "InternalPrefix";
				break;
			case TPublicConfigKey.PushAppId:
				result = "PushAppId";
				break;
			case TPublicConfigKey.PushAppKey:
				result = "PushAppKey";
				break;
			case TPublicConfigKey.PushAppSecret:
				result = "PushAppSecret";
				break;
			case TPublicConfigKey.SdkArea:
				result = "SdkArea";
				break;
			case TPublicConfigKey.TaptapClientId:
				result = "TaptapClientId";
				break;
			case TPublicConfigKey.TaptapClientToken:
				result = "TaptapClientToken";
				break;
			case TPublicConfigKey.TDMAppId:
				result = "TDMAppId";
				break;
			case TPublicConfigKey.TDMAppKey:
				result = "TDMAppKey";
				break;
			case TPublicConfigKey.TDMUrl:
				result = "TDMUrl";
				break;
			case TPublicConfigKey.UrlPath:
				result = "UrlPath";
				break;
			case TPublicConfigKey.UseSDK:
				result = "UseSDK";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602F091 RID: 192657 RVA: 0x00B2524C File Offset: 0x00B2344C
		public static TPublicConfigKey FromString(string name)
		{
			TPublicConfigKey result;
			if (!TPublicConfigKeyExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 TPublicConfigKey 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602F092 RID: 192658 RVA: 0x00B25278 File Offset: 0x00B23478
		public static bool TryFromString(string name, out TPublicConfigKey value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = TPublicConfigKey.AppTag;
				return false;
			}
			if (name != null)
			{
				switch (name.Length)
				{
				case 6:
				{
					char c = name[0];
					if (c != 'A')
					{
						if (c != 'T')
						{
							if (c == 'U')
							{
								if (name == "UseSDK")
								{
									value = TPublicConfigKey.UseSDK;
									return true;
								}
							}
						}
						else if (name == "TDMUrl")
						{
							value = TPublicConfigKey.TDMUrl;
							return true;
						}
					}
					else if (name == "AppTag")
					{
						value = TPublicConfigKey.AppTag;
						return true;
					}
					break;
				}
				case 7:
				{
					char c = name[0];
					if (c != 'S')
					{
						if (c == 'U')
						{
							if (name == "UrlPath")
							{
								value = TPublicConfigKey.UrlPath;
								return true;
							}
						}
					}
					else if (name == "SdkArea")
					{
						value = TPublicConfigKey.SdkArea;
						return true;
					}
					break;
				}
				case 8:
					if (name == "TDMAppId")
					{
						value = TPublicConfigKey.TDMAppId;
						return true;
					}
					break;
				case 9:
				{
					char c = name[0];
					if (c != 'P')
					{
						if (c == 'T')
						{
							if (name == "TDMAppKey")
							{
								value = TPublicConfigKey.TDMAppKey;
								return true;
							}
						}
					}
					else if (name == "PushAppId")
					{
						value = TPublicConfigKey.PushAppId;
						return true;
					}
					break;
				}
				case 10:
					if (name == "PushAppKey")
					{
						value = TPublicConfigKey.PushAppKey;
						return true;
					}
					break;
				case 13:
					if (name == "PushAppSecret")
					{
						value = TPublicConfigKey.PushAppSecret;
						return true;
					}
					break;
				case 14:
				{
					char c = name[0];
					if (c != 'C')
					{
						if (c != 'I')
						{
							if (c == 'T')
							{
								if (name == "TaptapClientId")
								{
									value = TPublicConfigKey.TaptapClientId;
									return true;
								}
							}
						}
						else if (name == "InternalPrefix")
						{
							value = TPublicConfigKey.InternalPrefix;
							return true;
						}
					}
					else if (name == "CheckEntryTime")
					{
						value = TPublicConfigKey.CheckEntryTime;
						return true;
					}
					break;
				}
				case 17:
					if (name == "TaptapClientToken")
					{
						value = TPublicConfigKey.TaptapClientToken;
						return true;
					}
					break;
				}
			}
			value = TPublicConfigKey.AppTag;
			return false;
		}

		// Token: 0x0602F093 RID: 192659 RVA: 0x00B254B4 File Offset: 0x00B236B4
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"AppTag",
				"CheckEntryTime",
				"InternalPrefix",
				"PushAppId",
				"PushAppKey",
				"PushAppSecret",
				"SdkArea",
				"TaptapClientId",
				"TaptapClientToken",
				"TDMAppId",
				"TDMAppKey",
				"TDMUrl",
				"UrlPath",
				"UseSDK"
			};
		}

		// Token: 0x0602F094 RID: 192660 RVA: 0x00B2553D File Offset: 0x00B2373D
		public static TPublicConfigKey[] GetValues()
		{
			return new TPublicConfigKey[]
			{
				TPublicConfigKey.AppTag,
				TPublicConfigKey.CheckEntryTime,
				TPublicConfigKey.InternalPrefix,
				TPublicConfigKey.PushAppId,
				TPublicConfigKey.PushAppKey,
				TPublicConfigKey.PushAppSecret,
				TPublicConfigKey.SdkArea,
				TPublicConfigKey.TaptapClientId,
				TPublicConfigKey.TaptapClientToken,
				TPublicConfigKey.TDMAppId,
				TPublicConfigKey.TDMAppKey,
				TPublicConfigKey.TDMUrl,
				TPublicConfigKey.UrlPath,
				TPublicConfigKey.UseSDK
			};
		}

		// Token: 0x0602F095 RID: 192661 RVA: 0x00B25554 File Offset: 0x00B23754
		public static string[] GetNames()
		{
			return new string[]
			{
				"AppTag",
				"CheckEntryTime",
				"InternalPrefix",
				"PushAppId",
				"PushAppKey",
				"PushAppSecret",
				"SdkArea",
				"TaptapClientId",
				"TaptapClientToken",
				"TDMAppId",
				"TDMAppKey",
				"TDMUrl",
				"UrlPath",
				"UseSDK"
			};
		}
	}
}
