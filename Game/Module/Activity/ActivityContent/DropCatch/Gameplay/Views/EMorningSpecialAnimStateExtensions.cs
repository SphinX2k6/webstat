using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006919 RID: 26905
	public static class EMorningSpecialAnimStateExtensions
	{
		// Token: 0x06042D15 RID: 273685 RVA: 0x01126B00 File Offset: 0x01124D00
		public static string ToEnumString(this EMorningSpecialAnimState value)
		{
			string result;
			switch (value)
			{
			case EMorningSpecialAnimState.IdleNothingLeft:
				result = "idle_nothing_R";
				break;
			case EMorningSpecialAnimState.IdleNothingRight:
				result = "idle_nothing_L";
				break;
			case EMorningSpecialAnimState.WalkNothingLeft:
				result = "walk_nothing_R";
				break;
			case EMorningSpecialAnimState.WalkNothingRight:
				result = "walk_nothing_L";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06042D16 RID: 273686 RVA: 0x01126B54 File Offset: 0x01124D54
		public static EMorningSpecialAnimState FromString(string name)
		{
			EMorningSpecialAnimState result;
			if (!EMorningSpecialAnimStateExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EMorningSpecialAnimState 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042D17 RID: 273687 RVA: 0x01126B80 File Offset: 0x01124D80
		public static bool TryFromString(string name, out EMorningSpecialAnimState value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EMorningSpecialAnimState.IdleNothingLeft;
				return false;
			}
			if (name == "idle_nothing_R")
			{
				value = EMorningSpecialAnimState.IdleNothingLeft;
				return true;
			}
			if (name == "idle_nothing_L")
			{
				value = EMorningSpecialAnimState.IdleNothingRight;
				return true;
			}
			if (name == "walk_nothing_R")
			{
				value = EMorningSpecialAnimState.WalkNothingLeft;
				return true;
			}
			if (!(name == "walk_nothing_L"))
			{
				value = EMorningSpecialAnimState.IdleNothingLeft;
				return false;
			}
			value = EMorningSpecialAnimState.WalkNothingRight;
			return true;
		}

		// Token: 0x06042D18 RID: 273688 RVA: 0x01126BE8 File Offset: 0x01124DE8
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"idle_nothing_R",
				"idle_nothing_L",
				"walk_nothing_R",
				"walk_nothing_L"
			};
		}

		// Token: 0x06042D19 RID: 273689 RVA: 0x01126C10 File Offset: 0x01124E10
		public static EMorningSpecialAnimState[] GetValues()
		{
			return new EMorningSpecialAnimState[]
			{
				EMorningSpecialAnimState.IdleNothingLeft,
				EMorningSpecialAnimState.IdleNothingRight,
				EMorningSpecialAnimState.WalkNothingLeft,
				EMorningSpecialAnimState.WalkNothingRight
			};
		}

		// Token: 0x06042D1A RID: 273690 RVA: 0x01126C23 File Offset: 0x01124E23
		public static string[] GetNames()
		{
			return new string[]
			{
				"IdleNothingLeft",
				"IdleNothingRight",
				"WalkNothingLeft",
				"WalkNothingRight"
			};
		}
	}
}
