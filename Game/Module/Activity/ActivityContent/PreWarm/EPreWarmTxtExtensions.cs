using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x02006585 RID: 25989
	public static class EPreWarmTxtExtensions
	{
		// Token: 0x06040E88 RID: 265864 RVA: 0x010A7118 File Offset: 0x010A5318
		public static string ToEnumString(this EPreWarmTxt value)
		{
			string result;
			switch (value)
			{
			case EPreWarmTxt.RewardTxtUnFinish:
				result = "RestoreFrequency_Reward_0";
				break;
			case EPreWarmTxt.RewardTxtFinished:
				result = "RestoreFrequency_Reward_1";
				break;
			case EPreWarmTxt.BtnLockTimeTxt:
				result = "RestoreFrequency_Unlock_0";
				break;
			case EPreWarmTxt.BtnLockQuestTxt:
				result = "RestoreFrequency_Unlock_1";
				break;
			case EPreWarmTxt.TitleUnlock:
				result = "RestoreFrequency_Title_0";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06040E89 RID: 265865 RVA: 0x010A7178 File Offset: 0x010A5378
		public static EPreWarmTxt FromString(string name)
		{
			EPreWarmTxt result;
			if (!EPreWarmTxtExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EPreWarmTxt 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06040E8A RID: 265866 RVA: 0x010A71A4 File Offset: 0x010A53A4
		public static bool TryFromString(string name, out EPreWarmTxt value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EPreWarmTxt.RewardTxtUnFinish;
				return false;
			}
			if (name == "RestoreFrequency_Reward_0")
			{
				value = EPreWarmTxt.RewardTxtUnFinish;
				return true;
			}
			if (name == "RestoreFrequency_Reward_1")
			{
				value = EPreWarmTxt.RewardTxtFinished;
				return true;
			}
			if (name == "RestoreFrequency_Unlock_0")
			{
				value = EPreWarmTxt.BtnLockTimeTxt;
				return true;
			}
			if (name == "RestoreFrequency_Unlock_1")
			{
				value = EPreWarmTxt.BtnLockQuestTxt;
				return true;
			}
			if (!(name == "RestoreFrequency_Title_0"))
			{
				value = EPreWarmTxt.RewardTxtUnFinish;
				return false;
			}
			value = EPreWarmTxt.TitleUnlock;
			return true;
		}

		// Token: 0x06040E8B RID: 265867 RVA: 0x010A721E File Offset: 0x010A541E
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"RestoreFrequency_Reward_0",
				"RestoreFrequency_Reward_1",
				"RestoreFrequency_Unlock_0",
				"RestoreFrequency_Unlock_1",
				"RestoreFrequency_Title_0"
			};
		}

		// Token: 0x06040E8C RID: 265868 RVA: 0x010A724E File Offset: 0x010A544E
		public static EPreWarmTxt[] GetValues()
		{
			return new EPreWarmTxt[]
			{
				EPreWarmTxt.RewardTxtUnFinish,
				EPreWarmTxt.RewardTxtFinished,
				EPreWarmTxt.BtnLockTimeTxt,
				EPreWarmTxt.BtnLockQuestTxt,
				EPreWarmTxt.TitleUnlock
			};
		}

		// Token: 0x06040E8D RID: 265869 RVA: 0x010A7261 File Offset: 0x010A5461
		public static string[] GetNames()
		{
			return new string[]
			{
				"RewardTxtUnFinish",
				"RewardTxtFinished",
				"BtnLockTimeTxt",
				"BtnLockQuestTxt",
				"TitleUnlock"
			};
		}
	}
}
