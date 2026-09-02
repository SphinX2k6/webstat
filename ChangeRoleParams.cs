using System;

// Token: 0x02002964 RID: 10596
public class ChangeRoleParams : IChangeRoleParams
{
	// Token: 0x17001BB9 RID: 7097
	// (get) Token: 0x060150F1 RID: 86257 RVA: 0x005D3078 File Offset: 0x005D1278
	// (set) Token: 0x060150F2 RID: 86258 RVA: 0x005D3080 File Offset: 0x005D1280
	public bool? UseGoBattleSkill { get; set; }

	// Token: 0x17001BBA RID: 7098
	// (get) Token: 0x060150F3 RID: 86259 RVA: 0x005D3089 File Offset: 0x005D1289
	// (set) Token: 0x060150F4 RID: 86260 RVA: 0x005D3091 File Offset: 0x005D1291
	public double? CoolDown { get; set; }

	// Token: 0x17001BBB RID: 7099
	// (get) Token: 0x060150F5 RID: 86261 RVA: 0x005D309A File Offset: 0x005D129A
	// (set) Token: 0x060150F6 RID: 86262 RVA: 0x005D30A2 File Offset: 0x005D12A2
	public bool? GoDownWaitSkillEnd { get; set; }

	// Token: 0x17001BBC RID: 7100
	// (get) Token: 0x060150F7 RID: 86263 RVA: 0x005D30AB File Offset: 0x005D12AB
	// (set) Token: 0x060150F8 RID: 86264 RVA: 0x005D30B3 File Offset: 0x005D12B3
	public bool? AllowRefreshTransform { get; set; }

	// Token: 0x17001BBD RID: 7101
	// (get) Token: 0x060150F9 RID: 86265 RVA: 0x005D30BC File Offset: 0x005D12BC
	// (set) Token: 0x060150FA RID: 86266 RVA: 0x005D30C4 File Offset: 0x005D12C4
	public bool? ForceInheritTransform { get; set; }

	// Token: 0x17001BBE RID: 7102
	// (get) Token: 0x060150FB RID: 86267 RVA: 0x005D30CD File Offset: 0x005D12CD
	// (set) Token: 0x060150FC RID: 86268 RVA: 0x005D30D5 File Offset: 0x005D12D5
	public bool? ForceChangeRole { get; set; }
}
