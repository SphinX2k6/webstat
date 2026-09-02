using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200667B RID: 26235
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffProgressData : IMowingBuffProgressData
	{
		// Token: 0x17009FB1 RID: 40881
		// (get) Token: 0x06041870 RID: 268400 RVA: 0x010D0C31 File Offset: 0x010CEE31
		// (set) Token: 0x06041871 RID: 268401 RVA: 0x010D0C39 File Offset: 0x010CEE39
		public int ArtifactId { get; set; }

		// Token: 0x17009FB2 RID: 40882
		// (get) Token: 0x06041872 RID: 268402 RVA: 0x010D0C42 File Offset: 0x010CEE42
		// (set) Token: 0x06041873 RID: 268403 RVA: 0x010D0C4A File Offset: 0x010CEE4A
		public int CurBasicBuffCount { get; set; }

		// Token: 0x17009FB3 RID: 40883
		// (get) Token: 0x06041874 RID: 268404 RVA: 0x010D0C53 File Offset: 0x010CEE53
		// (set) Token: 0x06041875 RID: 268405 RVA: 0x010D0C5B File Offset: 0x010CEE5B
		public int MaxBasicBuffCount { get; set; }

		// Token: 0x17009FB4 RID: 40884
		// (get) Token: 0x06041876 RID: 268406 RVA: 0x010D0C64 File Offset: 0x010CEE64
		// (set) Token: 0x06041877 RID: 268407 RVA: 0x010D0C6C File Offset: 0x010CEE6C
		public string CountTextId { get; set; }

		// Token: 0x17009FB5 RID: 40885
		// (get) Token: 0x06041878 RID: 268408 RVA: 0x010D0C75 File Offset: 0x010CEE75
		// (set) Token: 0x06041879 RID: 268409 RVA: 0x010D0C7D File Offset: 0x010CEE7D
		public string[] CountTextArgs { get; set; }

		// Token: 0x17009FB6 RID: 40886
		// (get) Token: 0x0604187A RID: 268410 RVA: 0x010D0C86 File Offset: 0x010CEE86
		// (set) Token: 0x0604187B RID: 268411 RVA: 0x010D0C8E File Offset: 0x010CEE8E
		public float ProgressPercentage { get; set; }

		// Token: 0x17009FB7 RID: 40887
		// (get) Token: 0x0604187C RID: 268412 RVA: 0x010D0C97 File Offset: 0x010CEE97
		// (set) Token: 0x0604187D RID: 268413 RVA: 0x010D0C9F File Offset: 0x010CEE9F
		public IMowingBuffUnitData[] SuperBuffList { get; set; }

		// Token: 0x17009FB8 RID: 40888
		// (get) Token: 0x0604187E RID: 268414 RVA: 0x010D0CA8 File Offset: 0x010CEEA8
		// (set) Token: 0x0604187F RID: 268415 RVA: 0x010D0CB0 File Offset: 0x010CEEB0
		public IMowingBuffIntroduceData IntroduceData { get; set; }
	}
}
