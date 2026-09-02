using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F7 RID: 21239
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class QuickHackLockTargetInfo : IQuickHackLockTargetInfo
	{
		// Token: 0x17008D0B RID: 36107
		// (get) Token: 0x06036389 RID: 222089 RVA: 0x00DAA00D File Offset: 0x00DA820D
		// (set) Token: 0x0603638A RID: 222090 RVA: 0x00DAA015 File Offset: 0x00DA8215
		public EQuickHackTargetType? HackType { get; set; }

		// Token: 0x17008D0C RID: 36108
		// (get) Token: 0x0603638B RID: 222091 RVA: 0x00DAA01E File Offset: 0x00DA821E
		// (set) Token: 0x0603638C RID: 222092 RVA: 0x00DAA026 File Offset: 0x00DA8226
		[RequiredMember]
		public IEnumerable<EntityHandle> Targets { get; set; }

		// Token: 0x0603638D RID: 222093 RVA: 0x00DAA02F File Offset: 0x00DA822F
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public QuickHackLockTargetInfo()
		{
		}
	}
}
