using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020022EA RID: 8938
[NullableContext(2)]
public interface IOpenMotorcycleDiyRootViewData
{
	// Token: 0x170014E8 RID: 5352
	// (get) Token: 0x06010E47 RID: 69191
	// (set) Token: 0x06010E48 RID: 69192
	EUiTabViewName? OpenTabView { get; set; }

	// Token: 0x170014E9 RID: 5353
	// (get) Token: 0x06010E49 RID: 69193
	// (set) Token: 0x06010E4A RID: 69194
	int? PartTabIndex { get; set; }

	// Token: 0x170014EA RID: 5354
	// (get) Token: 0x06010E4B RID: 69195
	// (set) Token: 0x06010E4C RID: 69196
	bool? IsNeedResetMotor { get; set; }

	// Token: 0x170014EB RID: 5355
	// (get) Token: 0x06010E4D RID: 69197
	// (set) Token: 0x06010E4E RID: 69198
	MotorcycleDiyPresetData PresetData { get; set; }

	// Token: 0x170014EC RID: 5356
	// (get) Token: 0x06010E4F RID: 69199
	// (set) Token: 0x06010E50 RID: 69200
	EMotorcycleDiyCustomMode? CustomMode { get; set; }

	// Token: 0x170014ED RID: 5357
	// (get) Token: 0x06010E51 RID: 69201
	// (set) Token: 0x06010E52 RID: 69202
	Action<int> OnNewCustomPresetCreated { get; set; }
}
