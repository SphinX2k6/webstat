using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FFB RID: 20475
	[NullableContext(2)]
	public interface ISeasonSwitchJob
	{
		// Token: 0x17008AA5 RID: 35493
		// (get) Token: 0x06034C68 RID: 216168
		// (set) Token: 0x06034C69 RID: 216169
		ESeason TargetSeason { get; set; }

		// Token: 0x17008AA6 RID: 35494
		// (get) Token: 0x06034C6A RID: 216170
		// (set) Token: 0x06034C6B RID: 216171
		double TargetValue { get; set; }

		// Token: 0x17008AA7 RID: 35495
		// (get) Token: 0x06034C6C RID: 216172
		// (set) Token: 0x06034C6D RID: 216173
		double Speed { get; set; }

		// Token: 0x17008AA8 RID: 35496
		// (get) Token: 0x06034C6E RID: 216174
		// (set) Token: 0x06034C6F RID: 216175
		double RemainDistance { get; set; }

		// Token: 0x17008AA9 RID: 35497
		// (get) Token: 0x06034C70 RID: 216176
		// (set) Token: 0x06034C71 RID: 216177
		TSeasonSwitchCallback OnComplete { get; set; }
	}
}
