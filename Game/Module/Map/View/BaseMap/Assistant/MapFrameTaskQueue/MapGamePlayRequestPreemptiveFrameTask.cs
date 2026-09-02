using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapFrameTaskQueue
{
	// Token: 0x0200580A RID: 22538
	[NullableContext(2)]
	[Nullable(0)]
	public class MapGamePlayRequestPreemptiveFrameTask : IMapGamePlayRequestPreemptiveFrameTask, IPreemptiveFrameTask
	{
		// Token: 0x17009212 RID: 37394
		// (get) Token: 0x06039555 RID: 234837 RVA: 0x00E8DE22 File Offset: 0x00E8C022
		// (set) Token: 0x06039556 RID: 234838 RVA: 0x00E8DE2A File Offset: 0x00E8C02A
		public int Priority { get; set; }

		// Token: 0x17009213 RID: 37395
		// (get) Token: 0x06039557 RID: 234839 RVA: 0x00E8DE33 File Offset: 0x00E8C033
		// (set) Token: 0x06039558 RID: 234840 RVA: 0x00E8DE3B File Offset: 0x00E8C03B
		[Nullable(1)]
		public TPreemptiveExecuteMethod Execute { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009214 RID: 37396
		// (get) Token: 0x06039559 RID: 234841 RVA: 0x00E8DE44 File Offset: 0x00E8C044
		// (set) Token: 0x0603955A RID: 234842 RVA: 0x00E8DE4C File Offset: 0x00E8C04C
		public TPreemptiveExecuteMethod FrameExecute { get; set; }

		// Token: 0x17009215 RID: 37397
		// (get) Token: 0x0603955B RID: 234843 RVA: 0x00E8DE55 File Offset: 0x00E8C055
		// (set) Token: 0x0603955C RID: 234844 RVA: 0x00E8DE5D File Offset: 0x00E8C05D
		public TPreemptiveIsCompleteMethod IsComplete { get; set; }

		// Token: 0x17009216 RID: 37398
		// (get) Token: 0x0603955D RID: 234845 RVA: 0x00E8DE66 File Offset: 0x00E8C066
		// (set) Token: 0x0603955E RID: 234846 RVA: 0x00E8DE6E File Offset: 0x00E8C06E
		public TPreemptiveCancelMethod Cancel { get; set; }

		// Token: 0x17009217 RID: 37399
		// (get) Token: 0x0603955F RID: 234847 RVA: 0x00E8DE77 File Offset: 0x00E8C077
		// (set) Token: 0x06039560 RID: 234848 RVA: 0x00E8DE7F File Offset: 0x00E8C07F
		public TGetPreemptiveResultMethod GetResult { get; set; }

		// Token: 0x17009218 RID: 37400
		// (get) Token: 0x06039561 RID: 234849 RVA: 0x00E8DE88 File Offset: 0x00E8C088
		// (set) Token: 0x06039562 RID: 234850 RVA: 0x00E8DE90 File Offset: 0x00E8C090
		public int MarkId { get; set; }

		// Token: 0x17009219 RID: 37401
		// (get) Token: 0x06039563 RID: 234851 RVA: 0x00E8DE99 File Offset: 0x00E8C099
		// (set) Token: 0x06039564 RID: 234852 RVA: 0x00E8DEA1 File Offset: 0x00E8C0A1
		public int GamePlayId { get; set; }

		// Token: 0x1700921A RID: 37402
		// (get) Token: 0x06039565 RID: 234853 RVA: 0x00E8DEAA File Offset: 0x00E8C0AA
		// (set) Token: 0x06039566 RID: 234854 RVA: 0x00E8DEB2 File Offset: 0x00E8C0B2
		public int InstId { get; set; }
	}
}
