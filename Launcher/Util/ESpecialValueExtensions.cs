using System;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044B0 RID: 17584
	public static class ESpecialValueExtensions
	{
		// Token: 0x0602E592 RID: 189842 RVA: 0x00AE293C File Offset: 0x00AE0B3C
		public static string ToEnumString(this ESpecialValue value)
		{
			string result;
			switch (value)
			{
			case ESpecialValue.Undefined:
				result = "___undefined___";
				break;
			case ESpecialValue.NaN:
				result = "___NaN___";
				break;
			case ESpecialValue.Infinity:
				result = "___Infinity___";
				break;
			case ESpecialValue.InfinityNegative:
				result = "___-Infinity___";
				break;
			case ESpecialValue.BigInt:
				result = "___BI___";
				break;
			case ESpecialValue.BooleanTrue:
				result = "___1B___";
				break;
			case ESpecialValue.BooleanFalse:
				result = "___0B___";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602E593 RID: 189843 RVA: 0x00AE29B4 File Offset: 0x00AE0BB4
		public static ESpecialValue FromString(string name)
		{
			ESpecialValue result;
			if (!ESpecialValueExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ESpecialValue 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602E594 RID: 189844 RVA: 0x00AE29E0 File Offset: 0x00AE0BE0
		public static bool TryFromString(string name, out ESpecialValue value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ESpecialValue.Undefined;
				return false;
			}
			if (name != null)
			{
				int length = name.Length;
				if (length <= 9)
				{
					if (length != 8)
					{
						if (length == 9)
						{
							if (name == "___NaN___")
							{
								value = ESpecialValue.NaN;
								return true;
							}
						}
					}
					else
					{
						char c = name[3];
						if (c != '0')
						{
							if (c != '1')
							{
								if (c == 'B')
								{
									if (name == "___BI___")
									{
										value = ESpecialValue.BigInt;
										return true;
									}
								}
							}
							else if (name == "___1B___")
							{
								value = ESpecialValue.BooleanTrue;
								return true;
							}
						}
						else if (name == "___0B___")
						{
							value = ESpecialValue.BooleanFalse;
							return true;
						}
					}
				}
				else if (length != 14)
				{
					if (length == 15)
					{
						char c = name[3];
						if (c != '-')
						{
							if (c == 'u')
							{
								if (name == "___undefined___")
								{
									value = ESpecialValue.Undefined;
									return true;
								}
							}
						}
						else if (name == "___-Infinity___")
						{
							value = ESpecialValue.InfinityNegative;
							return true;
						}
					}
				}
				else if (name == "___Infinity___")
				{
					value = ESpecialValue.Infinity;
					return true;
				}
			}
			value = ESpecialValue.Undefined;
			return false;
		}

		// Token: 0x0602E595 RID: 189845 RVA: 0x00AE2AEA File Offset: 0x00AE0CEA
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"___undefined___",
				"___NaN___",
				"___Infinity___",
				"___-Infinity___",
				"___BI___",
				"___1B___",
				"___0B___"
			};
		}

		// Token: 0x0602E596 RID: 189846 RVA: 0x00AE2B2A File Offset: 0x00AE0D2A
		public static ESpecialValue[] GetValues()
		{
			return new ESpecialValue[]
			{
				ESpecialValue.Undefined,
				ESpecialValue.NaN,
				ESpecialValue.Infinity,
				ESpecialValue.InfinityNegative,
				ESpecialValue.BigInt,
				ESpecialValue.BooleanTrue,
				ESpecialValue.BooleanFalse
			};
		}

		// Token: 0x0602E597 RID: 189847 RVA: 0x00AE2B3D File Offset: 0x00AE0D3D
		public static string[] GetNames()
		{
			return new string[]
			{
				"Undefined",
				"NaN",
				"Infinity",
				"InfinityNegative",
				"BigInt",
				"BooleanTrue",
				"BooleanFalse"
			};
		}
	}
}
