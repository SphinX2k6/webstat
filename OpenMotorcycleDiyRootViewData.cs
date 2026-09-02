using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020022EB RID: 8939
[NullableContext(2)]
[Nullable(0)]
public class OpenMotorcycleDiyRootViewData : IOpenMotorcycleDiyRootViewData
{
	// Token: 0x170014EE RID: 5358
	// (get) Token: 0x06010E53 RID: 69203 RVA: 0x004A09F6 File Offset: 0x0049EBF6
	// (set) Token: 0x06010E54 RID: 69204 RVA: 0x004A09FE File Offset: 0x0049EBFE
	public EUiTabViewName? OpenTabView { get; set; }

	// Token: 0x170014EF RID: 5359
	// (get) Token: 0x06010E55 RID: 69205 RVA: 0x004A0A07 File Offset: 0x0049EC07
	// (set) Token: 0x06010E56 RID: 69206 RVA: 0x004A0A0F File Offset: 0x0049EC0F
	public int? PartTabIndex { get; set; }

	// Token: 0x170014F0 RID: 5360
	// (get) Token: 0x06010E57 RID: 69207 RVA: 0x004A0A18 File Offset: 0x0049EC18
	// (set) Token: 0x06010E58 RID: 69208 RVA: 0x004A0A20 File Offset: 0x0049EC20
	public bool? IsNeedResetMotor { get; set; }

	// Token: 0x170014F1 RID: 5361
	// (get) Token: 0x06010E59 RID: 69209 RVA: 0x004A0A29 File Offset: 0x0049EC29
	// (set) Token: 0x06010E5A RID: 69210 RVA: 0x004A0A31 File Offset: 0x0049EC31
	public MotorcycleDiyPresetData PresetData { get; set; }

	// Token: 0x170014F2 RID: 5362
	// (get) Token: 0x06010E5B RID: 69211 RVA: 0x004A0A3A File Offset: 0x0049EC3A
	// (set) Token: 0x06010E5C RID: 69212 RVA: 0x004A0A42 File Offset: 0x0049EC42
	public EMotorcycleDiyCustomMode? CustomMode { get; set; }

	// Token: 0x170014F3 RID: 5363
	// (get) Token: 0x06010E5D RID: 69213 RVA: 0x004A0A4B File Offset: 0x0049EC4B
	// (set) Token: 0x06010E5E RID: 69214 RVA: 0x004A0A53 File Offset: 0x0049EC53
	public Action<int> OnNewCustomPresetCreated { get; set; }
}
