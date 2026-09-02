using System;

namespace CSharpScript.Core.Define.TdConfigExtensions
{
	// Token: 0x0200713D RID: 28989
	public static class EPackageExtensions
	{
		// Token: 0x06046324 RID: 287524 RVA: 0x0126ED30 File Offset: 0x0126CF30
		public static string ToEnumString(this EPackage value)
		{
			string result;
			switch (value)
			{
			case EPackage.Message:
				result = "M";
				break;
			case EPackage.Connect:
				result = "C";
				break;
			case EPackage.ConnectAck:
				result = "CA";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06046325 RID: 287525 RVA: 0x0126ED78 File Offset: 0x0126CF78
		public static EPackage FromString(string name)
		{
			EPackage result;
			if (!EPackageExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EPackage 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06046326 RID: 287526 RVA: 0x0126EDA4 File Offset: 0x0126CFA4
		public static bool TryFromString(string name, out EPackage value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EPackage.Message;
				return false;
			}
			if (name == "M")
			{
				value = EPackage.Message;
				return true;
			}
			if (name == "C")
			{
				value = EPackage.Connect;
				return true;
			}
			if (!(name == "CA"))
			{
				value = EPackage.Message;
				return false;
			}
			value = EPackage.ConnectAck;
			return true;
		}

		// Token: 0x06046327 RID: 287527 RVA: 0x0126EDFA File Offset: 0x0126CFFA
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"M",
				"C",
				"CA"
			};
		}

		// Token: 0x06046328 RID: 287528 RVA: 0x0126EE1A File Offset: 0x0126D01A
		public static EPackage[] GetValues()
		{
			return new EPackage[]
			{
				EPackage.Message,
				EPackage.Connect,
				EPackage.ConnectAck
			};
		}

		// Token: 0x06046329 RID: 287529 RVA: 0x0126EE2A File Offset: 0x0126D02A
		public static string[] GetNames()
		{
			return new string[]
			{
				"Message",
				"Connect",
				"ConnectAck"
			};
		}
	}
}
