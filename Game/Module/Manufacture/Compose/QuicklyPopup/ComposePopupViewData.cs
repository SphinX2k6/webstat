using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup
{
	// Token: 0x020059D7 RID: 22999
	[NullableContext(2)]
	[Nullable(0)]
	public class ComposePopupViewData : IComposePopupViewData
	{
		// Token: 0x170094B2 RID: 38066
		// (get) Token: 0x0603A454 RID: 238676 RVA: 0x00EC61F8 File Offset: 0x00EC43F8
		// (set) Token: 0x0603A455 RID: 238677 RVA: 0x00EC6200 File Offset: 0x00EC4400
		[Nullable(1)]
		public List<ISelectedData> SelectedItemList { [NullableContext(1)] get; [NullableContext(1)] set; } = new List<ISelectedData>();

		// Token: 0x170094B3 RID: 38067
		// (get) Token: 0x0603A456 RID: 238678 RVA: 0x00EC6209 File Offset: 0x00EC4409
		// (set) Token: 0x0603A457 RID: 238679 RVA: 0x00EC6211 File Offset: 0x00EC4411
		public Action BeforeCompose { get; set; }

		// Token: 0x170094B4 RID: 38068
		// (get) Token: 0x0603A458 RID: 238680 RVA: 0x00EC621A File Offset: 0x00EC441A
		// (set) Token: 0x0603A459 RID: 238681 RVA: 0x00EC6222 File Offset: 0x00EC4422
		public Action ClickConfirm { get; set; }

		// Token: 0x170094B5 RID: 38069
		// (get) Token: 0x0603A45A RID: 238682 RVA: 0x00EC622B File Offset: 0x00EC442B
		// (set) Token: 0x0603A45B RID: 238683 RVA: 0x00EC6233 File Offset: 0x00EC4433
		public EUiViewName? BelongView { get; set; }
	}
}
