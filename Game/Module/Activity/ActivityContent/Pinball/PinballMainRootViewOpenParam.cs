using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball
{
	// Token: 0x02006590 RID: 26000
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballMainRootViewOpenParam : IPinballMainRootViewOpenParam
	{
		// Token: 0x17009EB8 RID: 40632
		// (get) Token: 0x06040F78 RID: 266104 RVA: 0x010AB4E3 File Offset: 0x010A96E3
		// (set) Token: 0x06040F79 RID: 266105 RVA: 0x010AB4EB File Offset: 0x010A96EB
		public string ChildView { get; set; }

		// Token: 0x17009EB9 RID: 40633
		// (get) Token: 0x06040F7A RID: 266106 RVA: 0x010AB4F4 File Offset: 0x010A96F4
		// (set) Token: 0x06040F7B RID: 266107 RVA: 0x010AB4FC File Offset: 0x010A96FC
		public int? LevelId { get; set; }

		// Token: 0x17009EBA RID: 40634
		// (get) Token: 0x06040F7C RID: 266108 RVA: 0x010AB505 File Offset: 0x010A9705
		// (set) Token: 0x06040F7D RID: 266109 RVA: 0x010AB50D File Offset: 0x010A970D
		public bool? IsFromInstanceDungeon { get; set; }
	}
}
