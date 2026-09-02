using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006212 RID: 25106
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerRecordPopupViewData : IWheelTowerRecordPopupViewData
	{
		// Token: 0x17009BB7 RID: 39863
		// (get) Token: 0x0603F56D RID: 259437 RVA: 0x0103E9DC File Offset: 0x0103CBDC
		// (set) Token: 0x0603F56E RID: 259438 RVA: 0x0103E9E4 File Offset: 0x0103CBE4
		public IWheelTowerPopupData BeforeData { get; set; } = new WheelTowerPopupData();

		// Token: 0x17009BB8 RID: 39864
		// (get) Token: 0x0603F56F RID: 259439 RVA: 0x0103E9ED File Offset: 0x0103CBED
		// (set) Token: 0x0603F570 RID: 259440 RVA: 0x0103E9F5 File Offset: 0x0103CBF5
		public IWheelTowerPopupData AfterData { get; set; } = new WheelTowerPopupData();

		// Token: 0x17009BB9 RID: 39865
		// (get) Token: 0x0603F571 RID: 259441 RVA: 0x0103E9FE File Offset: 0x0103CBFE
		// (set) Token: 0x0603F572 RID: 259442 RVA: 0x0103EA06 File Offset: 0x0103CC06
		public bool IsEndless { get; set; }

		// Token: 0x17009BBA RID: 39866
		// (get) Token: 0x0603F573 RID: 259443 RVA: 0x0103EA0F File Offset: 0x0103CC0F
		// (set) Token: 0x0603F574 RID: 259444 RVA: 0x0103EA17 File Offset: 0x0103CC17
		public int Round { get; set; }

		// Token: 0x17009BBB RID: 39867
		// (get) Token: 0x0603F575 RID: 259445 RVA: 0x0103EA20 File Offset: 0x0103CC20
		// (set) Token: 0x0603F576 RID: 259446 RVA: 0x0103EA28 File Offset: 0x0103CC28
		[Nullable(2)]
		public Action OnClickConfirm { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009BBC RID: 39868
		// (get) Token: 0x0603F577 RID: 259447 RVA: 0x0103EA31 File Offset: 0x0103CC31
		// (set) Token: 0x0603F578 RID: 259448 RVA: 0x0103EA39 File Offset: 0x0103CC39
		[Nullable(2)]
		public Action OnClickCancel { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
