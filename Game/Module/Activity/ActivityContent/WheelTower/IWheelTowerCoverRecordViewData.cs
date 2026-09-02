using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200620D RID: 25101
	[NullableContext(1)]
	public interface IWheelTowerCoverRecordViewData
	{
		// Token: 0x17009B9B RID: 39835
		// (get) Token: 0x0603F533 RID: 259379
		// (set) Token: 0x0603F534 RID: 259380
		IWheelTowerCoverRecordData BeforeData { get; set; }

		// Token: 0x17009B9C RID: 39836
		// (get) Token: 0x0603F535 RID: 259381
		// (set) Token: 0x0603F536 RID: 259382
		IWheelTowerCoverRecordData AfterData { get; set; }

		// Token: 0x17009B9D RID: 39837
		// (get) Token: 0x0603F537 RID: 259383
		// (set) Token: 0x0603F538 RID: 259384
		int TeamNum { get; set; }

		// Token: 0x17009B9E RID: 39838
		// (get) Token: 0x0603F539 RID: 259385
		// (set) Token: 0x0603F53A RID: 259386
		bool IsEndless { get; set; }

		// Token: 0x17009B9F RID: 39839
		// (get) Token: 0x0603F53B RID: 259387
		// (set) Token: 0x0603F53C RID: 259388
		[Nullable(2)]
		Action OnClickConfirm { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009BA0 RID: 39840
		// (get) Token: 0x0603F53D RID: 259389
		// (set) Token: 0x0603F53E RID: 259390
		[Nullable(2)]
		Action OnClickCancel { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
