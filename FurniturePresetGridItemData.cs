using System;
using Aki.Config;

// Token: 0x0200109B RID: 4251
public class FurniturePresetGridItemData : IFurniturePresetGridItemData
{
	// Token: 0x17000905 RID: 2309
	// (get) Token: 0x06006EDB RID: 28379 RVA: 0x001CD548 File Offset: 0x001CB748
	// (set) Token: 0x06006EDC RID: 28380 RVA: 0x001CD550 File Offset: 0x001CB750
	public Furniture FurnitureConfig { get; set; }

	// Token: 0x17000906 RID: 2310
	// (get) Token: 0x06006EDD RID: 28381 RVA: 0x001CD559 File Offset: 0x001CB759
	// (set) Token: 0x06006EDE RID: 28382 RVA: 0x001CD561 File Offset: 0x001CB761
	public bool IsLock { get; set; }

	// Token: 0x17000907 RID: 2311
	// (get) Token: 0x06006EDF RID: 28383 RVA: 0x001CD56A File Offset: 0x001CB76A
	// (set) Token: 0x06006EE0 RID: 28384 RVA: 0x001CD572 File Offset: 0x001CB772
	public bool IsFinished { get; set; }
}
