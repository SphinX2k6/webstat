using System;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AF3 RID: 23283
	public class KurotatoNormalRewardItemData : KurotatoRewardItemData
	{
		// Token: 0x0603AE22 RID: 241186 RVA: 0x00EEE9DA File Offset: 0x00EECBDA
		public KurotatoNormalRewardItemData(int rewardId, int current, int target, int status) : base(rewardId, current, target, status)
		{
			base.NormalConfig = ConfigBase<KurotatoConfig>.Instance.GetNormalRewardConfigById(rewardId);
		}
	}
}
