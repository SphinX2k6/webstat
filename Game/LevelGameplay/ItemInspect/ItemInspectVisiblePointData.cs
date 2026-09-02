using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect
{
	// Token: 0x02006E43 RID: 28227
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemInspectVisiblePointData : IItemInspectVisiblePointData
	{
		// Token: 0x1700A37B RID: 41851
		// (get) Token: 0x060447EA RID: 280554 RVA: 0x011CD5FC File Offset: 0x011CB7FC
		// (set) Token: 0x060447EB RID: 280555 RVA: 0x011CD604 File Offset: 0x011CB804
		public int TagId { get; set; }

		// Token: 0x1700A37C RID: 41852
		// (get) Token: 0x060447EC RID: 280556 RVA: 0x011CD60D File Offset: 0x011CB80D
		// (set) Token: 0x060447ED RID: 280557 RVA: 0x011CD615 File Offset: 0x011CB815
		public Vector Location { get; set; } = Vector.Create();

		// Token: 0x1700A37D RID: 41853
		// (get) Token: 0x060447EE RID: 280558 RVA: 0x011CD61E File Offset: 0x011CB81E
		// (set) Token: 0x060447EF RID: 280559 RVA: 0x011CD626 File Offset: 0x011CB826
		public bool IsChecked { get; set; }
	}
}
