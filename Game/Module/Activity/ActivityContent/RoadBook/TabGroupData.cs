using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064BD RID: 25789
	[NullableContext(1)]
	[Nullable(0)]
	public class TabGroupData : ITabGroupData
	{
		// Token: 0x17009E62 RID: 40546
		// (get) Token: 0x060409EF RID: 264687 RVA: 0x01090A87 File Offset: 0x0108EC87
		// (set) Token: 0x060409F0 RID: 264688 RVA: 0x01090A8F File Offset: 0x0108EC8F
		public List<MotorChallengePlayData> TabDataList { get; set; } = new List<MotorChallengePlayData>();

		// Token: 0x17009E63 RID: 40547
		// (get) Token: 0x060409F1 RID: 264689 RVA: 0x01090A98 File Offset: 0x0108EC98
		// (set) Token: 0x060409F2 RID: 264690 RVA: 0x01090AA0 File Offset: 0x0108ECA0
		[Nullable(2)]
		public string GroupTitleId { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
