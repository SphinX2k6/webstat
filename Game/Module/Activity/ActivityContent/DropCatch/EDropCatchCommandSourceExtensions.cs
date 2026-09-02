using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068DA RID: 26842
	public static class EDropCatchCommandSourceExtensions
	{
		// Token: 0x06042BB8 RID: 273336 RVA: 0x01120D24 File Offset: 0x0111EF24
		public static string ToEnumString(this EDropCatchCommandSource value)
		{
			string result;
			if (value == EDropCatchCommandSource.Skill)
			{
				result = "Skill";
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}

		// Token: 0x06042BB9 RID: 273337 RVA: 0x01120D4C File Offset: 0x0111EF4C
		public static EDropCatchCommandSource FromString(string name)
		{
			EDropCatchCommandSource result;
			if (!EDropCatchCommandSourceExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDropCatchCommandSource 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042BBA RID: 273338 RVA: 0x01120D75 File Offset: 0x0111EF75
		public static bool TryFromString(string name, out EDropCatchCommandSource value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDropCatchCommandSource.Skill;
				return false;
			}
			if (name == "Skill")
			{
				value = EDropCatchCommandSource.Skill;
				return true;
			}
			value = EDropCatchCommandSource.Skill;
			return false;
		}

		// Token: 0x06042BBB RID: 273339 RVA: 0x01120D9A File Offset: 0x0111EF9A
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Skill"
			};
		}

		// Token: 0x06042BBC RID: 273340 RVA: 0x01120DAA File Offset: 0x0111EFAA
		public static EDropCatchCommandSource[] GetValues()
		{
			return new EDropCatchCommandSource[1];
		}

		// Token: 0x06042BBD RID: 273341 RVA: 0x01120DB2 File Offset: 0x0111EFB2
		public static string[] GetNames()
		{
			return new string[]
			{
				"Skill"
			};
		}
	}
}
