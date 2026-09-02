using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006265 RID: 25189
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPreviewViewParam : ITotalTopUpPreviewViewParam
	{
		// Token: 0x17009C34 RID: 39988
		// (get) Token: 0x0603F77F RID: 259967 RVA: 0x01045757 File Offset: 0x01043957
		// (set) Token: 0x0603F780 RID: 259968 RVA: 0x0104575F File Offset: 0x0104395F
		public TotalTopUpReward RewardConfig { get; set; }

		// Token: 0x17009C35 RID: 39989
		// (get) Token: 0x0603F781 RID: 259969 RVA: 0x01045768 File Offset: 0x01043968
		// (set) Token: 0x0603F782 RID: 259970 RVA: 0x01045770 File Offset: 0x01043970
		public TotalTopUpRewardData RewardData { get; set; }
	}
}
