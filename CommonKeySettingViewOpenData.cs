using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.KeySetting;

// Token: 0x02002090 RID: 8336
[NullableContext(2)]
[Nullable(0)]
internal class CommonKeySettingViewOpenData : ICommonKeySettingViewOpenData
{
	// Token: 0x170012E5 RID: 4837
	// (get) Token: 0x0600FE54 RID: 65108 RVA: 0x0045C231 File Offset: 0x0045A431
	// (set) Token: 0x0600FE55 RID: 65109 RVA: 0x0045C239 File Offset: 0x0045A439
	public EKeySettingExclusiveType ViewType { get; set; }

	// Token: 0x170012E6 RID: 4838
	// (get) Token: 0x0600FE56 RID: 65110 RVA: 0x0045C242 File Offset: 0x0045A442
	// (set) Token: 0x0600FE57 RID: 65111 RVA: 0x0045C24A File Offset: 0x0045A44A
	public string BgSourceId { get; set; }
}
