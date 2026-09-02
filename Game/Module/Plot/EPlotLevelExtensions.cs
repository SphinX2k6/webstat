using System;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200537D RID: 21373
	public static class EPlotLevelExtensions
	{
		// Token: 0x0603682C RID: 223276 RVA: 0x00DC6BD8 File Offset: 0x00DC4DD8
		public static string ToEnumString(this EPlotLevel value)
		{
			string result;
			switch (value)
			{
			case EPlotLevel.LevelA:
				result = "LevelA";
				break;
			case EPlotLevel.LevelB:
				result = "LevelB";
				break;
			case EPlotLevel.LevelC:
				result = "LevelC";
				break;
			case EPlotLevel.LevelD:
				result = "LevelD";
				break;
			case EPlotLevel.LevelE:
				result = "LevelE";
				break;
			case EPlotLevel.Prompt:
				result = "Prompt";
				break;
			case EPlotLevel.ControlEntity:
				result = "ControlEntity";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0603682D RID: 223277 RVA: 0x00DC6C50 File Offset: 0x00DC4E50
		public static EPlotLevel FromString(string name)
		{
			EPlotLevel result;
			if (!EPlotLevelExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EPlotLevel 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0603682E RID: 223278 RVA: 0x00DC6C7C File Offset: 0x00DC4E7C
		public static bool TryFromString(string name, out EPlotLevel value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EPlotLevel.LevelA;
				return false;
			}
			if (name != null)
			{
				int length = name.Length;
				if (length != 6)
				{
					if (length == 13)
					{
						if (name == "ControlEntity")
						{
							value = EPlotLevel.ControlEntity;
							return true;
						}
					}
				}
				else
				{
					char c = name[5];
					switch (c)
					{
					case 'A':
						if (name == "LevelA")
						{
							value = EPlotLevel.LevelA;
							return true;
						}
						break;
					case 'B':
						if (name == "LevelB")
						{
							value = EPlotLevel.LevelB;
							return true;
						}
						break;
					case 'C':
						if (name == "LevelC")
						{
							value = EPlotLevel.LevelC;
							return true;
						}
						break;
					case 'D':
						if (name == "LevelD")
						{
							value = EPlotLevel.LevelD;
							return true;
						}
						break;
					case 'E':
						if (name == "LevelE")
						{
							value = EPlotLevel.LevelE;
							return true;
						}
						break;
					default:
						if (c == 't')
						{
							if (name == "Prompt")
							{
								value = EPlotLevel.Prompt;
								return true;
							}
						}
						break;
					}
				}
			}
			value = EPlotLevel.LevelA;
			return false;
		}

		// Token: 0x0603682F RID: 223279 RVA: 0x00DC6D73 File Offset: 0x00DC4F73
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"LevelA",
				"LevelB",
				"LevelC",
				"LevelD",
				"LevelE",
				"Prompt",
				"ControlEntity"
			};
		}

		// Token: 0x06036830 RID: 223280 RVA: 0x00DC6DB3 File Offset: 0x00DC4FB3
		public static EPlotLevel[] GetValues()
		{
			return new EPlotLevel[]
			{
				EPlotLevel.LevelA,
				EPlotLevel.LevelB,
				EPlotLevel.LevelC,
				EPlotLevel.LevelD,
				EPlotLevel.LevelE,
				EPlotLevel.Prompt,
				EPlotLevel.ControlEntity
			};
		}

		// Token: 0x06036831 RID: 223281 RVA: 0x00DC6DC6 File Offset: 0x00DC4FC6
		public static string[] GetNames()
		{
			return new string[]
			{
				"LevelA",
				"LevelB",
				"LevelC",
				"LevelD",
				"LevelE",
				"Prompt",
				"ControlEntity"
			};
		}
	}
}
