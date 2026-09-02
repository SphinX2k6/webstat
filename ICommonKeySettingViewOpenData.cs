using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.KeySetting;

// Token: 0x0200208F RID: 8335
[NullableContext(2)]
internal interface ICommonKeySettingViewOpenData
{
	// Token: 0x170012E3 RID: 4835
	// (get) Token: 0x0600FE50 RID: 65104
	// (set) Token: 0x0600FE51 RID: 65105
	EKeySettingExclusiveType ViewType { get; set; }

	// Token: 0x170012E4 RID: 4836
	// (get) Token: 0x0600FE52 RID: 65106
	// (set) Token: 0x0600FE53 RID: 65107
	string BgSourceId { get; set; }
}
