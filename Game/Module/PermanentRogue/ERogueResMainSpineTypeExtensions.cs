using System;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056AF RID: 22191
	public static class ERogueResMainSpineTypeExtensions
	{
		// Token: 0x060387BB RID: 231355 RVA: 0x00E4FC84 File Offset: 0x00E4DE84
		public static string ToEnumString(this ERogueResMainSpineType value)
		{
			string result;
			if (value != ERogueResMainSpineType.Female)
			{
				if (value != ERogueResMainSpineType.Male)
				{
					result = value.ToString();
				}
				else
				{
					result = "Male";
				}
			}
			else
			{
				result = "Female";
			}
			return result;
		}

		// Token: 0x060387BC RID: 231356 RVA: 0x00E4FCBC File Offset: 0x00E4DEBC
		public static ERogueResMainSpineType FromString(string name)
		{
			ERogueResMainSpineType result;
			if (!ERogueResMainSpineTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ERogueResMainSpineType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x060387BD RID: 231357 RVA: 0x00E4FCE5 File Offset: 0x00E4DEE5
		public static bool TryFromString(string name, out ERogueResMainSpineType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ERogueResMainSpineType.Female;
				return false;
			}
			if (name == "Female")
			{
				value = ERogueResMainSpineType.Female;
				return true;
			}
			if (!(name == "Male"))
			{
				value = ERogueResMainSpineType.Female;
				return false;
			}
			value = ERogueResMainSpineType.Male;
			return true;
		}

		// Token: 0x060387BE RID: 231358 RVA: 0x00E4FD1E File Offset: 0x00E4DF1E
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Female",
				"Male"
			};
		}

		// Token: 0x060387BF RID: 231359 RVA: 0x00E4FD36 File Offset: 0x00E4DF36
		public static ERogueResMainSpineType[] GetValues()
		{
			return new ERogueResMainSpineType[]
			{
				ERogueResMainSpineType.Female,
				ERogueResMainSpineType.Male
			};
		}

		// Token: 0x060387C0 RID: 231360 RVA: 0x00E4FD42 File Offset: 0x00E4DF42
		public static string[] GetNames()
		{
			return new string[]
			{
				"Female",
				"Male"
			};
		}
	}
}
