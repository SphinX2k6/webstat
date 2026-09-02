using System;

// Token: 0x0200170A RID: 5898
public interface IConflictInfo
{
	// Token: 0x17000D92 RID: 3474
	// (get) Token: 0x0600A398 RID: 41880
	// (set) Token: 0x0600A399 RID: 41881
	int RoleId { get; set; }

	// Token: 0x17000D93 RID: 3475
	// (get) Token: 0x0600A39A RID: 41882
	// (set) Token: 0x0600A39B RID: 41883
	bool WeaponConflict { get; set; }

	// Token: 0x17000D94 RID: 3476
	// (get) Token: 0x0600A39C RID: 41884
	// (set) Token: 0x0600A39D RID: 41885
	bool PhantomConflict { get; set; }
}
