using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068DC RID: 26844
	public static class EDropCatchGameplayLeftMsgTypeExtensions
	{
		// Token: 0x06042BC1 RID: 273345 RVA: 0x01120E00 File Offset: 0x0111F000
		public static string ToEnumString(this EDropCatchGameplayLeftMsgType value)
		{
			string result;
			if (value != EDropCatchGameplayLeftMsgType.Gameplay)
			{
				if (value != EDropCatchGameplayLeftMsgType.DropItem)
				{
					result = value.ToString();
				}
				else
				{
					result = "DropItem";
				}
			}
			else
			{
				result = "Gameplay";
			}
			return result;
		}

		// Token: 0x06042BC2 RID: 273346 RVA: 0x01120E38 File Offset: 0x0111F038
		public static EDropCatchGameplayLeftMsgType FromString(string name)
		{
			EDropCatchGameplayLeftMsgType result;
			if (!EDropCatchGameplayLeftMsgTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDropCatchGameplayLeftMsgType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042BC3 RID: 273347 RVA: 0x01120E61 File Offset: 0x0111F061
		public static bool TryFromString(string name, out EDropCatchGameplayLeftMsgType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDropCatchGameplayLeftMsgType.Gameplay;
				return false;
			}
			if (name == "Gameplay")
			{
				value = EDropCatchGameplayLeftMsgType.Gameplay;
				return true;
			}
			if (!(name == "DropItem"))
			{
				value = EDropCatchGameplayLeftMsgType.Gameplay;
				return false;
			}
			value = EDropCatchGameplayLeftMsgType.DropItem;
			return true;
		}

		// Token: 0x06042BC4 RID: 273348 RVA: 0x01120E9A File Offset: 0x0111F09A
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Gameplay",
				"DropItem"
			};
		}

		// Token: 0x06042BC5 RID: 273349 RVA: 0x01120EB2 File Offset: 0x0111F0B2
		public static EDropCatchGameplayLeftMsgType[] GetValues()
		{
			return new EDropCatchGameplayLeftMsgType[]
			{
				EDropCatchGameplayLeftMsgType.Gameplay,
				EDropCatchGameplayLeftMsgType.DropItem
			};
		}

		// Token: 0x06042BC6 RID: 273350 RVA: 0x01120EBE File Offset: 0x0111F0BE
		public static string[] GetNames()
		{
			return new string[]
			{
				"Gameplay",
				"DropItem"
			};
		}
	}
}
