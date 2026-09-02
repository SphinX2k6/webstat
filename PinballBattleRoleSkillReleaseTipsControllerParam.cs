using System;
using System.Runtime.CompilerServices;

// Token: 0x020014D5 RID: 5333
[NullableContext(2)]
[Nullable(0)]
internal class PinballBattleRoleSkillReleaseTipsControllerParam : IPinballBattleRoleSkillReleaseTipsParam, IPinballBattleTipsBaseParam
{
	// Token: 0x17000CAF RID: 3247
	// (get) Token: 0x06009509 RID: 38153 RVA: 0x00270643 File Offset: 0x0026E843
	// (set) Token: 0x0600950A RID: 38154 RVA: 0x0027064B File Offset: 0x0026E84B
	public int RoleId { get; set; }

	// Token: 0x17000CB0 RID: 3248
	// (get) Token: 0x0600950B RID: 38155 RVA: 0x00270654 File Offset: 0x0026E854
	// (set) Token: 0x0600950C RID: 38156 RVA: 0x0027065C File Offset: 0x0026E85C
	public Action CloseCallback { get; set; }

	// Token: 0x17000CB1 RID: 3249
	// (get) Token: 0x0600950D RID: 38157 RVA: 0x00270665 File Offset: 0x0026E865
	// (set) Token: 0x0600950E RID: 38158 RVA: 0x0027066D File Offset: 0x0026E86D
	public bool? AddMask { get; set; }

	// Token: 0x17000CB2 RID: 3250
	// (get) Token: 0x0600950F RID: 38159 RVA: 0x00270676 File Offset: 0x0026E876
	// (set) Token: 0x06009510 RID: 38160 RVA: 0x0027067E File Offset: 0x0026E87E
	public int? CloseTime { get; set; }

	// Token: 0x17000CB3 RID: 3251
	// (get) Token: 0x06009511 RID: 38161 RVA: 0x00270687 File Offset: 0x0026E887
	// (set) Token: 0x06009512 RID: 38162 RVA: 0x0027068F File Offset: 0x0026E88F
	public bool? MoveToBehind { get; set; }
}
