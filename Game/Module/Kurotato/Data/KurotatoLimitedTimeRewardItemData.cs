using System;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AF4 RID: 23284
	public class KurotatoLimitedTimeRewardItemData : KurotatoRewardItemData
	{
		// Token: 0x0603AE23 RID: 241187 RVA: 0x00EEE9F8 File Offset: 0x00EECBF8
		public KurotatoLimitedTimeRewardItemData(int rewardId, int current, int target, int status) : base(rewardId, current, target, status)
		{
			base.LimitConfig = ConfigBase<KurotatoConfig>.Instance.GetLimitRewardConfigById(rewardId);
		}

		// Token: 0x0603AE24 RID: 241188 RVA: 0x00EEEA18 File Offset: 0x00EECC18
		public int GetTabId()
		{
			return base.LimitConfig.Value.TabId;
		}
	}
}
