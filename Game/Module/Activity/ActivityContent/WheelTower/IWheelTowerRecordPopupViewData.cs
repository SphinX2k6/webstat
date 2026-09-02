using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006211 RID: 25105
	[NullableContext(1)]
	public interface IWheelTowerRecordPopupViewData
	{
		// Token: 0x17009BB1 RID: 39857
		// (get) Token: 0x0603F561 RID: 259425
		// (set) Token: 0x0603F562 RID: 259426
		IWheelTowerPopupData BeforeData { get; set; }

		// Token: 0x17009BB2 RID: 39858
		// (get) Token: 0x0603F563 RID: 259427
		// (set) Token: 0x0603F564 RID: 259428
		IWheelTowerPopupData AfterData { get; set; }

		// Token: 0x17009BB3 RID: 39859
		// (get) Token: 0x0603F565 RID: 259429
		// (set) Token: 0x0603F566 RID: 259430
		bool IsEndless { get; set; }

		// Token: 0x17009BB4 RID: 39860
		// (get) Token: 0x0603F567 RID: 259431
		// (set) Token: 0x0603F568 RID: 259432
		int Round { get; set; }

		// Token: 0x17009BB5 RID: 39861
		// (get) Token: 0x0603F569 RID: 259433
		// (set) Token: 0x0603F56A RID: 259434
		[Nullable(2)]
		Action OnClickConfirm { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009BB6 RID: 39862
		// (get) Token: 0x0603F56B RID: 259435
		// (set) Token: 0x0603F56C RID: 259436
		[Nullable(2)]
		Action OnClickCancel { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
