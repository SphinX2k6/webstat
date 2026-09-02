using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGameplay.SplineConstrainedDrag.Capability
{
	// Token: 0x020069FB RID: 27131
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class DragGroupStat : IDragGroupStat
	{
		// Token: 0x1700A200 RID: 41472
		// (get) Token: 0x0604338A RID: 275338 RVA: 0x01148052 File Offset: 0x01146252
		// (set) Token: 0x0604338B RID: 275339 RVA: 0x0114805A File Offset: 0x0114625A
		public int Total { get; set; }

		// Token: 0x1700A201 RID: 41473
		// (get) Token: 0x0604338C RID: 275340 RVA: 0x01148063 File Offset: 0x01146263
		// (set) Token: 0x0604338D RID: 275341 RVA: 0x0114806B File Offset: 0x0114626B
		[RequiredMember]
		public int[] StateCounts { get; set; }

		// Token: 0x1700A202 RID: 41474
		// (get) Token: 0x0604338E RID: 275342 RVA: 0x01148074 File Offset: 0x01146274
		// (set) Token: 0x0604338F RID: 275343 RVA: 0x0114807C File Offset: 0x0114627C
		public int ConditionOkCount { get; set; }

		// Token: 0x1700A203 RID: 41475
		// (get) Token: 0x06043390 RID: 275344 RVA: 0x01148085 File Offset: 0x01146285
		// (set) Token: 0x06043391 RID: 275345 RVA: 0x0114808D File Offset: 0x0114628D
		public bool HasActive { get; set; }

		// Token: 0x06043392 RID: 275346 RVA: 0x01148096 File Offset: 0x01146296
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DragGroupStat()
		{
		}
	}
}
