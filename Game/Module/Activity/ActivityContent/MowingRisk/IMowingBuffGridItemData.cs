using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006682 RID: 26242
	[NullableContext(1)]
	public interface IMowingBuffGridItemData
	{
		// Token: 0x17009FD5 RID: 40917
		// (get) Token: 0x060418BC RID: 268476
		// (set) Token: 0x060418BD RID: 268477
		int BuffId { get; set; }

		// Token: 0x17009FD6 RID: 40918
		// (get) Token: 0x060418BE RID: 268478
		// (set) Token: 0x060418BF RID: 268479
		string QualityPath { get; set; }

		// Token: 0x17009FD7 RID: 40919
		// (get) Token: 0x060418C0 RID: 268480
		// (set) Token: 0x060418C1 RID: 268481
		string IconPath { get; set; }

		// Token: 0x17009FD8 RID: 40920
		// (get) Token: 0x060418C2 RID: 268482
		// (set) Token: 0x060418C3 RID: 268483
		string NameTextId { get; set; }

		// Token: 0x17009FD9 RID: 40921
		// (get) Token: 0x060418C4 RID: 268484
		// (set) Token: 0x060418C5 RID: 268485
		bool IsShowBackground { get; set; }

		// Token: 0x17009FDA RID: 40922
		// (get) Token: 0x060418C6 RID: 268486
		// (set) Token: 0x060418C7 RID: 268487
		bool IsChosen { get; set; }

		// Token: 0x17009FDB RID: 40923
		// (get) Token: 0x060418C8 RID: 268488
		// (set) Token: 0x060418C9 RID: 268489
		bool IsUnlock { get; set; }

		// Token: 0x17009FDC RID: 40924
		// (get) Token: 0x060418CA RID: 268490
		// (set) Token: 0x060418CB RID: 268491
		string LevelContent { get; set; }
	}
}
