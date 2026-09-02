using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BE1 RID: 23521
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceDungeonBuffItemData
	{
		// Token: 0x170097A0 RID: 38816
		// (get) Token: 0x0603B8BF RID: 243903 RVA: 0x00F18151 File Offset: 0x00F16351
		// (set) Token: 0x0603B8C0 RID: 243904 RVA: 0x00F18159 File Offset: 0x00F16359
		public string BuffText { get; set; }

		// Token: 0x170097A1 RID: 38817
		// (get) Token: 0x0603B8C1 RID: 243905 RVA: 0x00F18162 File Offset: 0x00F16362
		// (set) Token: 0x0603B8C2 RID: 243906 RVA: 0x00F1816A File Offset: 0x00F1636A
		public bool ShowMonsterPreview { get; set; }

		// Token: 0x170097A2 RID: 38818
		// (get) Token: 0x0603B8C3 RID: 243907 RVA: 0x00F18173 File Offset: 0x00F16373
		// (set) Token: 0x0603B8C4 RID: 243908 RVA: 0x00F1817B File Offset: 0x00F1637B
		public InstanceDungeonBuffItem.EBuffInfoType BuffInfoType { get; set; }
	}
}
