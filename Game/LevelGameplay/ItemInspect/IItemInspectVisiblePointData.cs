using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect
{
	// Token: 0x02006E45 RID: 28229
	[NullableContext(1)]
	public interface IItemInspectVisiblePointData
	{
		// Token: 0x1700A37E RID: 41854
		// (get) Token: 0x06044820 RID: 280608
		// (set) Token: 0x06044821 RID: 280609
		int TagId { get; set; }

		// Token: 0x1700A37F RID: 41855
		// (get) Token: 0x06044822 RID: 280610
		// (set) Token: 0x06044823 RID: 280611
		Vector Location { get; set; }

		// Token: 0x1700A380 RID: 41856
		// (get) Token: 0x06044824 RID: 280612
		// (set) Token: 0x06044825 RID: 280613
		bool IsChecked { get; set; }
	}
}
