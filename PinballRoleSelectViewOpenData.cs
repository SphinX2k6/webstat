using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;

// Token: 0x020014DE RID: 5342
[NullableContext(1)]
[Nullable(0)]
public class PinballRoleSelectViewOpenData : IPinballRoleSelectViewOpenData
{
	// Token: 0x17000CDB RID: 3291
	// (get) Token: 0x0600956A RID: 38250 RVA: 0x00270982 File Offset: 0x0026EB82
	// (set) Token: 0x0600956B RID: 38251 RVA: 0x0027098A File Offset: 0x0026EB8A
	public PinballActivityData ActivityData { get; set; }

	// Token: 0x17000CDC RID: 3292
	// (get) Token: 0x0600956C RID: 38252 RVA: 0x00270993 File Offset: 0x0026EB93
	// (set) Token: 0x0600956D RID: 38253 RVA: 0x0027099B File Offset: 0x0026EB9B
	public int SelectedRoleId { get; set; }

	// Token: 0x17000CDD RID: 3293
	// (get) Token: 0x0600956E RID: 38254 RVA: 0x002709A4 File Offset: 0x0026EBA4
	// (set) Token: 0x0600956F RID: 38255 RVA: 0x002709AC File Offset: 0x0026EBAC
	public List<PinballRoleDataBase> RoleDataList { get; set; }

	// Token: 0x17000CDE RID: 3294
	// (get) Token: 0x06009570 RID: 38256 RVA: 0x002709B5 File Offset: 0x0026EBB5
	// (set) Token: 0x06009571 RID: 38257 RVA: 0x002709BD File Offset: 0x0026EBBD
	[Nullable(2)]
	public int[] FormationRoleIds { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000CDF RID: 3295
	// (get) Token: 0x06009572 RID: 38258 RVA: 0x002709C6 File Offset: 0x0026EBC6
	// (set) Token: 0x06009573 RID: 38259 RVA: 0x002709CE File Offset: 0x0026EBCE
	public Action<int> OnSelectConfirm { get; set; }
}
