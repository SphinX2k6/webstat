using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F8 RID: 21240
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class QuickHackOnScreenTargetInfo : IQuickHackOnScreenTargetInfo
	{
		// Token: 0x17008D0D RID: 36109
		// (get) Token: 0x0603638E RID: 222094 RVA: 0x00DAA037 File Offset: 0x00DA8237
		// (set) Token: 0x0603638F RID: 222095 RVA: 0x00DAA03F File Offset: 0x00DA823F
		[RequiredMember]
		public Dictionary<int, int> TargetIdToIndexMap { get; set; }

		// Token: 0x17008D0E RID: 36110
		// (get) Token: 0x06036390 RID: 222096 RVA: 0x00DAA048 File Offset: 0x00DA8248
		// (set) Token: 0x06036391 RID: 222097 RVA: 0x00DAA050 File Offset: 0x00DA8250
		[RequiredMember]
		public List<EntityHandle> Targets { get; set; }

		// Token: 0x17008D0F RID: 36111
		// (get) Token: 0x06036392 RID: 222098 RVA: 0x00DAA059 File Offset: 0x00DA8259
		// (set) Token: 0x06036393 RID: 222099 RVA: 0x00DAA061 File Offset: 0x00DA8261
		[RequiredMember]
		public List<double> SignedScreenDistSquaredList { get; set; }

		// Token: 0x17008D10 RID: 36112
		// (get) Token: 0x06036394 RID: 222100 RVA: 0x00DAA06A File Offset: 0x00DA826A
		// (set) Token: 0x06036395 RID: 222101 RVA: 0x00DAA072 File Offset: 0x00DA8272
		[RequiredMember]
		public List<double> DistSquaredList { get; set; }

		// Token: 0x06036396 RID: 222102 RVA: 0x00DAA07B File Offset: 0x00DA827B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public QuickHackOnScreenTargetInfo()
		{
		}
	}
}
