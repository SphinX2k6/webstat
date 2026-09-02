using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068CE RID: 26830
	public static class EDropCatchResourceIdExtensions
	{
		// Token: 0x06042B82 RID: 273282 RVA: 0x0111FE6C File Offset: 0x0111E06C
		public static string ToEnumString(this EDropCatchResourceId value)
		{
			string result;
			switch (value)
			{
			case EDropCatchResourceId.DropItem:
				result = "UiItem_GoldCatchPnlDropItem";
				break;
			case EDropCatchResourceId.Role:
				result = "UiItem_GoldCatchPnlRole";
				break;
			case EDropCatchResourceId.RoleBuff:
				result = "UiItem_GoldCatchPnlRoleBuff";
				break;
			case EDropCatchResourceId.CountDown:
				result = "UiItem_GoldCatchCountdown";
				break;
			case EDropCatchResourceId.RoleFx:
				result = "UiItem_RoleFx";
				break;
			case EDropCatchResourceId.DropItemFx:
				result = "UiItem_DropItemFx";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06042B83 RID: 273283 RVA: 0x0111FED8 File Offset: 0x0111E0D8
		public static EDropCatchResourceId FromString(string name)
		{
			EDropCatchResourceId result;
			if (!EDropCatchResourceIdExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDropCatchResourceId 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042B84 RID: 273284 RVA: 0x0111FF04 File Offset: 0x0111E104
		public static bool TryFromString(string name, out EDropCatchResourceId value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDropCatchResourceId.DropItem;
				return false;
			}
			if (name == "UiItem_GoldCatchPnlDropItem")
			{
				value = EDropCatchResourceId.DropItem;
				return true;
			}
			if (name == "UiItem_GoldCatchPnlRole")
			{
				value = EDropCatchResourceId.Role;
				return true;
			}
			if (name == "UiItem_GoldCatchPnlRoleBuff")
			{
				value = EDropCatchResourceId.RoleBuff;
				return true;
			}
			if (name == "UiItem_GoldCatchCountdown")
			{
				value = EDropCatchResourceId.CountDown;
				return true;
			}
			if (name == "UiItem_RoleFx")
			{
				value = EDropCatchResourceId.RoleFx;
				return true;
			}
			if (!(name == "UiItem_DropItemFx"))
			{
				value = EDropCatchResourceId.DropItem;
				return false;
			}
			value = EDropCatchResourceId.DropItemFx;
			return true;
		}

		// Token: 0x06042B85 RID: 273285 RVA: 0x0111FF90 File Offset: 0x0111E190
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"UiItem_GoldCatchPnlDropItem",
				"UiItem_GoldCatchPnlRole",
				"UiItem_GoldCatchPnlRoleBuff",
				"UiItem_GoldCatchCountdown",
				"UiItem_RoleFx",
				"UiItem_DropItemFx"
			};
		}

		// Token: 0x06042B86 RID: 273286 RVA: 0x0111FFC8 File Offset: 0x0111E1C8
		public static EDropCatchResourceId[] GetValues()
		{
			return new EDropCatchResourceId[]
			{
				EDropCatchResourceId.DropItem,
				EDropCatchResourceId.Role,
				EDropCatchResourceId.RoleBuff,
				EDropCatchResourceId.CountDown,
				EDropCatchResourceId.RoleFx,
				EDropCatchResourceId.DropItemFx
			};
		}

		// Token: 0x06042B87 RID: 273287 RVA: 0x0111FFDB File Offset: 0x0111E1DB
		public static string[] GetNames()
		{
			return new string[]
			{
				"DropItem",
				"Role",
				"RoleBuff",
				"CountDown",
				"RoleFx",
				"DropItemFx"
			};
		}
	}
}
