using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x0200588E RID: 22670
	[NullableContext(1)]
	[Nullable(0)]
	public class MarkItemComponentContext : IMarkItemComponentContext
	{
		// Token: 0x17009307 RID: 37639
		// (get) Token: 0x060399FD RID: 236029 RVA: 0x00E9DBA9 File Offset: 0x00E9BDA9
		// (set) Token: 0x060399FE RID: 236030 RVA: 0x00E9DBB1 File Offset: 0x00E9BDB1
		public MarkItemEntity MarkItemEntity { get; set; }

		// Token: 0x17009308 RID: 37640
		// (get) Token: 0x060399FF RID: 236031 RVA: 0x00E9DBBA File Offset: 0x00E9BDBA
		// (set) Token: 0x06039A00 RID: 236032 RVA: 0x00E9DBC2 File Offset: 0x00E9BDC2
		public UUISprite TopRightIconSprite { get; set; }

		// Token: 0x17009309 RID: 37641
		// (get) Token: 0x06039A01 RID: 236033 RVA: 0x00E9DBCB File Offset: 0x00E9BDCB
		// (set) Token: 0x06039A02 RID: 236034 RVA: 0x00E9DBD3 File Offset: 0x00E9BDD3
		public TSetSpriteByPathAction SetSpriteByPathAction { get; set; }

		// Token: 0x1700930A RID: 37642
		// (get) Token: 0x06039A03 RID: 236035 RVA: 0x00E9DBDC File Offset: 0x00E9BDDC
		// (set) Token: 0x06039A04 RID: 236036 RVA: 0x00E9DBE4 File Offset: 0x00E9BDE4
		public UUIItem MarkComponentContainer { get; set; }

		// Token: 0x1700930B RID: 37643
		// (get) Token: 0x06039A05 RID: 236037 RVA: 0x00E9DBED File Offset: 0x00E9BDED
		// (set) Token: 0x06039A06 RID: 236038 RVA: 0x00E9DBF5 File Offset: 0x00E9BDF5
		public UUIItem MarkParentItem { get; set; }

		// Token: 0x1700930C RID: 37644
		// (get) Token: 0x06039A07 RID: 236039 RVA: 0x00E9DBFE File Offset: 0x00E9BDFE
		// (set) Token: 0x06039A08 RID: 236040 RVA: 0x00E9DC06 File Offset: 0x00E9BE06
		public UUIItem MarkRootItem { get; set; }

		// Token: 0x1700930D RID: 37645
		// (get) Token: 0x06039A09 RID: 236041 RVA: 0x00E9DC0F File Offset: 0x00E9BE0F
		// (set) Token: 0x06039A0A RID: 236042 RVA: 0x00E9DC17 File Offset: 0x00E9BE17
		public MarkItem MarkItem { get; set; }

		// Token: 0x06039A0B RID: 236043 RVA: 0x00E9DC20 File Offset: 0x00E9BE20
		public bool CanExecuteComponentLogic()
		{
			return this.MarkItemEntity != null && (!this.MarkItem.IsDestroy || MapDefine.HasSingleComponentMarkType.Contains(this.MarkItem.MarkType));
		}
	}
}
