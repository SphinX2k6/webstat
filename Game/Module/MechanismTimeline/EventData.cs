using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057DE RID: 22494
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class EventData : IEventData
	{
		// Token: 0x170091BE RID: 37310
		// (get) Token: 0x0603927F RID: 234111 RVA: 0x00E7DAA3 File Offset: 0x00E7BCA3
		// (set) Token: 0x06039280 RID: 234112 RVA: 0x00E7DAAB File Offset: 0x00E7BCAB
		[RequiredMember]
		public string EventName { get; set; }

		// Token: 0x170091BF RID: 37311
		// (get) Token: 0x06039281 RID: 234113 RVA: 0x00E7DAB4 File Offset: 0x00E7BCB4
		// (set) Token: 0x06039282 RID: 234114 RVA: 0x00E7DABC File Offset: 0x00E7BCBC
		[RequiredMember]
		public string EventType { get; set; }

		// Token: 0x170091C0 RID: 37312
		// (get) Token: 0x06039283 RID: 234115 RVA: 0x00E7DAC5 File Offset: 0x00E7BCC5
		// (set) Token: 0x06039284 RID: 234116 RVA: 0x00E7DACD File Offset: 0x00E7BCCD
		public bool IsAnimNotifyState { get; set; }

		// Token: 0x170091C1 RID: 37313
		// (get) Token: 0x06039285 RID: 234117 RVA: 0x00E7DAD6 File Offset: 0x00E7BCD6
		// (set) Token: 0x06039286 RID: 234118 RVA: 0x00E7DADE File Offset: 0x00E7BCDE
		public int StartFrame { get; set; }

		// Token: 0x170091C2 RID: 37314
		// (get) Token: 0x06039287 RID: 234119 RVA: 0x00E7DAE7 File Offset: 0x00E7BCE7
		// (set) Token: 0x06039288 RID: 234120 RVA: 0x00E7DAEF File Offset: 0x00E7BCEF
		public int EndFrame { get; set; }

		// Token: 0x170091C3 RID: 37315
		// (get) Token: 0x06039289 RID: 234121 RVA: 0x00E7DAF8 File Offset: 0x00E7BCF8
		// (set) Token: 0x0603928A RID: 234122 RVA: 0x00E7DB00 File Offset: 0x00E7BD00
		public int RowIndex { get; set; }

		// Token: 0x0603928B RID: 234123 RVA: 0x00E7DB09 File Offset: 0x00E7BD09
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public EventData()
		{
		}
	}
}
