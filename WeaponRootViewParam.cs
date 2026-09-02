using System;

// Token: 0x02002D0D RID: 11533
public class WeaponRootViewParam : IWeaponRootViewParam
{
	// Token: 0x17001EAB RID: 7851
	// (get) Token: 0x06017454 RID: 95316 RVA: 0x006733F3 File Offset: 0x006715F3
	// (set) Token: 0x06017455 RID: 95317 RVA: 0x006733FB File Offset: 0x006715FB
	public int WeaponIncId { get; set; }

	// Token: 0x17001EAC RID: 7852
	// (get) Token: 0x06017456 RID: 95318 RVA: 0x00673404 File Offset: 0x00671604
	// (set) Token: 0x06017457 RID: 95319 RVA: 0x0067340C File Offset: 0x0067160C
	public int WeaponSkinId { get; set; }

	// Token: 0x17001EAD RID: 7853
	// (get) Token: 0x06017458 RID: 95320 RVA: 0x00673415 File Offset: 0x00671615
	// (set) Token: 0x06017459 RID: 95321 RVA: 0x0067341D File Offset: 0x0067161D
	public bool IsFromRoleRootView { get; set; }
}
