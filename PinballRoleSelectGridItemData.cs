using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020014DF RID: 5343
[NullableContext(1)]
[Nullable(0)]
public class PinballRoleSelectGridItemData : IPinballRoleSelectGridItemData
{
	// Token: 0x17000CE0 RID: 3296
	// (get) Token: 0x06009575 RID: 38261 RVA: 0x002709DF File Offset: 0x0026EBDF
	// (set) Token: 0x06009576 RID: 38262 RVA: 0x002709E7 File Offset: 0x0026EBE7
	public PinballRoleDataBase RoleData { get; set; }

	// Token: 0x17000CE1 RID: 3297
	// (get) Token: 0x06009577 RID: 38263 RVA: 0x002709F0 File Offset: 0x0026EBF0
	// (set) Token: 0x06009578 RID: 38264 RVA: 0x002709F8 File Offset: 0x0026EBF8
	public IPinballItemDataRole ItemData { get; set; }

	// Token: 0x17000CE2 RID: 3298
	// (get) Token: 0x06009579 RID: 38265 RVA: 0x00270A01 File Offset: 0x0026EC01
	// (set) Token: 0x0600957A RID: 38266 RVA: 0x00270A09 File Offset: 0x0026EC09
	public List<int> ClassIdList { get; set; }

	// Token: 0x17000CE3 RID: 3299
	// (get) Token: 0x0600957B RID: 38267 RVA: 0x00270A12 File Offset: 0x0026EC12
	// (set) Token: 0x0600957C RID: 38268 RVA: 0x00270A1A File Offset: 0x0026EC1A
	public bool IsSelected { get; set; }

	// Token: 0x17000CE4 RID: 3300
	// (get) Token: 0x0600957D RID: 38269 RVA: 0x00270A23 File Offset: 0x0026EC23
	// (set) Token: 0x0600957E RID: 38270 RVA: 0x00270A2B File Offset: 0x0026EC2B
	public int FormationIndex { get; set; }
}
