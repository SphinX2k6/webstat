using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup
{
	// Token: 0x020059D6 RID: 22998
	[NullableContext(2)]
	public interface IComposePopupViewData
	{
		// Token: 0x170094AE RID: 38062
		// (get) Token: 0x0603A44C RID: 238668
		// (set) Token: 0x0603A44D RID: 238669
		[Nullable(1)]
		List<ISelectedData> SelectedItemList { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170094AF RID: 38063
		// (get) Token: 0x0603A44E RID: 238670
		// (set) Token: 0x0603A44F RID: 238671
		Action BeforeCompose { get; set; }

		// Token: 0x170094B0 RID: 38064
		// (get) Token: 0x0603A450 RID: 238672
		// (set) Token: 0x0603A451 RID: 238673
		Action ClickConfirm { get; set; }

		// Token: 0x170094B1 RID: 38065
		// (get) Token: 0x0603A452 RID: 238674
		// (set) Token: 0x0603A453 RID: 238675
		EUiViewName? BelongView { get; set; }
	}
}
