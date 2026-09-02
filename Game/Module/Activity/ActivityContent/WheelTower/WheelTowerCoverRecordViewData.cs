using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200620E RID: 25102
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerCoverRecordViewData : IWheelTowerCoverRecordViewData
	{
		// Token: 0x17009BA1 RID: 39841
		// (get) Token: 0x0603F53F RID: 259391 RVA: 0x0103E8F0 File Offset: 0x0103CAF0
		// (set) Token: 0x0603F540 RID: 259392 RVA: 0x0103E8F8 File Offset: 0x0103CAF8
		public IWheelTowerCoverRecordData BeforeData { get; set; } = new WheelTowerCoverRecordData();

		// Token: 0x17009BA2 RID: 39842
		// (get) Token: 0x0603F541 RID: 259393 RVA: 0x0103E901 File Offset: 0x0103CB01
		// (set) Token: 0x0603F542 RID: 259394 RVA: 0x0103E909 File Offset: 0x0103CB09
		public IWheelTowerCoverRecordData AfterData { get; set; } = new WheelTowerCoverRecordData();

		// Token: 0x17009BA3 RID: 39843
		// (get) Token: 0x0603F543 RID: 259395 RVA: 0x0103E912 File Offset: 0x0103CB12
		// (set) Token: 0x0603F544 RID: 259396 RVA: 0x0103E91A File Offset: 0x0103CB1A
		public int TeamNum { get; set; }

		// Token: 0x17009BA4 RID: 39844
		// (get) Token: 0x0603F545 RID: 259397 RVA: 0x0103E923 File Offset: 0x0103CB23
		// (set) Token: 0x0603F546 RID: 259398 RVA: 0x0103E92B File Offset: 0x0103CB2B
		public bool IsEndless { get; set; }

		// Token: 0x17009BA5 RID: 39845
		// (get) Token: 0x0603F547 RID: 259399 RVA: 0x0103E934 File Offset: 0x0103CB34
		// (set) Token: 0x0603F548 RID: 259400 RVA: 0x0103E93C File Offset: 0x0103CB3C
		[Nullable(2)]
		public Action OnClickConfirm { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009BA6 RID: 39846
		// (get) Token: 0x0603F549 RID: 259401 RVA: 0x0103E945 File Offset: 0x0103CB45
		// (set) Token: 0x0603F54A RID: 259402 RVA: 0x0103E94D File Offset: 0x0103CB4D
		[Nullable(2)]
		public Action OnClickCancel { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
