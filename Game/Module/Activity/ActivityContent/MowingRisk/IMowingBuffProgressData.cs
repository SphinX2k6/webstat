using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200667A RID: 26234
	[NullableContext(1)]
	public interface IMowingBuffProgressData
	{
		// Token: 0x17009FA9 RID: 40873
		// (get) Token: 0x06041860 RID: 268384
		// (set) Token: 0x06041861 RID: 268385
		int ArtifactId { get; set; }

		// Token: 0x17009FAA RID: 40874
		// (get) Token: 0x06041862 RID: 268386
		// (set) Token: 0x06041863 RID: 268387
		int CurBasicBuffCount { get; set; }

		// Token: 0x17009FAB RID: 40875
		// (get) Token: 0x06041864 RID: 268388
		// (set) Token: 0x06041865 RID: 268389
		int MaxBasicBuffCount { get; set; }

		// Token: 0x17009FAC RID: 40876
		// (get) Token: 0x06041866 RID: 268390
		// (set) Token: 0x06041867 RID: 268391
		string CountTextId { get; set; }

		// Token: 0x17009FAD RID: 40877
		// (get) Token: 0x06041868 RID: 268392
		// (set) Token: 0x06041869 RID: 268393
		string[] CountTextArgs { get; set; }

		// Token: 0x17009FAE RID: 40878
		// (get) Token: 0x0604186A RID: 268394
		// (set) Token: 0x0604186B RID: 268395
		float ProgressPercentage { get; set; }

		// Token: 0x17009FAF RID: 40879
		// (get) Token: 0x0604186C RID: 268396
		// (set) Token: 0x0604186D RID: 268397
		IMowingBuffUnitData[] SuperBuffList { get; set; }

		// Token: 0x17009FB0 RID: 40880
		// (get) Token: 0x0604186E RID: 268398
		// (set) Token: 0x0604186F RID: 268399
		IMowingBuffIntroduceData IntroduceData { get; set; }
	}
}
