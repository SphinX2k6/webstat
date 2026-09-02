using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA2 RID: 23970
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkBossInstanceData
	{
		// Token: 0x0603C5A0 RID: 247200 RVA: 0x00F507B2 File Offset: 0x00F4E9B2
		public DreamLinkBossInstanceData(int typeId, int instId, int conditionGroupId)
		{
			this.TypeId = typeId;
			this.InstId = instId;
			this.ConditionGroupId = conditionGroupId;
		}

		// Token: 0x0603C5A1 RID: 247201 RVA: 0x00F507DC File Offset: 0x00F4E9DC
		public string GetUnlockText()
		{
			string result = "";
			if ((double)this.UnlockTime <= Singleton<TimeUtil>.Instance.GetServerTime())
			{
				if (this.ConditionGroupId != 0)
				{
					result = (ConfigMultiTextLang.GetLocalTextNew(LevelGeneralCommons.GetConditionGroupHintText(this.ConditionGroupId) ?? "", null) ?? "");
				}
			}
			else
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("DaMaoUnLockTime", null);
				result = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.UnlockTime, localTextNew ?? "");
			}
			return result;
		}

		// Token: 0x0603C5A2 RID: 247202 RVA: 0x00F50858 File Offset: 0x00F4EA58
		public bool GetTickState()
		{
			return !this.IsUnlock && (double)this.UnlockTime > Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x0603C5A3 RID: 247203 RVA: 0x00F5087A File Offset: 0x00F4EA7A
		public void SetBossRoleIdByIndex(int index, int roleId)
		{
			this.EnterBossRoleIdList[index] = roleId;
		}

		// Token: 0x0603C5A4 RID: 247204 RVA: 0x00F50885 File Offset: 0x00F4EA85
		public int GetBossRoleIdByIndex(int index)
		{
			return this.EnterBossRoleIdList[index];
		}

		// Token: 0x0603C5A5 RID: 247205 RVA: 0x00F5088F File Offset: 0x00F4EA8F
		public int[] GetBossRoleIdList()
		{
			return this.EnterBossRoleIdList;
		}

		// Token: 0x04021EEE RID: 138990
		public int TypeId;

		// Token: 0x04021EEF RID: 138991
		public int InstId;

		// Token: 0x04021EF0 RID: 138992
		public int ConditionGroupId;

		// Token: 0x04021EF1 RID: 138993
		public int Score;

		// Token: 0x04021EF2 RID: 138994
		public bool IsUnlock;

		// Token: 0x04021EF3 RID: 138995
		public long UnlockTime;

		// Token: 0x04021EF4 RID: 138996
		public bool IsFinished;

		// Token: 0x04021EF5 RID: 138997
		private int[] EnterBossRoleIdList = new int[3];
	}
}
