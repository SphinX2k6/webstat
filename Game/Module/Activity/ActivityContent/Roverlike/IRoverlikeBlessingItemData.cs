using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006449 RID: 25673
	public interface IRoverlikeBlessingItemData
	{
		// Token: 0x17009DFE RID: 40446
		// (get) Token: 0x06040701 RID: 263937
		// (set) Token: 0x06040702 RID: 263938
		int BlessId { get; set; }

		// Token: 0x17009DFF RID: 40447
		// (get) Token: 0x06040703 RID: 263939
		// (set) Token: 0x06040704 RID: 263940
		int? IncId { get; set; }

		// Token: 0x17009E00 RID: 40448
		// (get) Token: 0x06040705 RID: 263941
		// (set) Token: 0x06040706 RID: 263942
		bool? AllowToggleInteract { get; set; }

		// Token: 0x17009E01 RID: 40449
		// (get) Token: 0x06040707 RID: 263943
		// (set) Token: 0x06040708 RID: 263944
		bool? IsUp { get; set; }

		// Token: 0x17009E02 RID: 40450
		// (get) Token: 0x06040709 RID: 263945
		// (set) Token: 0x0604070A RID: 263946
		bool? CheckSameSlot { get; set; }

		// Token: 0x17009E03 RID: 40451
		// (get) Token: 0x0604070B RID: 263947
		// (set) Token: 0x0604070C RID: 263948
		bool? ShowRecommend { get; set; }
	}
}
