using System;

// Token: 0x020024B2 RID: 9394
public class PhantomInteractItemData : IPhantomInteractItemData
{
	// Token: 0x17001705 RID: 5893
	// (get) Token: 0x060123AE RID: 74670 RVA: 0x00504B6F File Offset: 0x00502D6F
	// (set) Token: 0x060123AF RID: 74671 RVA: 0x00504B77 File Offset: 0x00502D77
	public int ItemIndex { get; set; }

	// Token: 0x17001706 RID: 5894
	// (get) Token: 0x060123B0 RID: 74672 RVA: 0x00504B80 File Offset: 0x00502D80
	// (set) Token: 0x060123B1 RID: 74673 RVA: 0x00504B88 File Offset: 0x00502D88
	public int MonsterId { get; set; }

	// Token: 0x060123B2 RID: 74674 RVA: 0x00504B91 File Offset: 0x00502D91
	public void LoadData(int index, int monsterId)
	{
		this.ItemIndex = index;
		this.MonsterId = monsterId;
	}

	// Token: 0x060123B3 RID: 74675 RVA: 0x00504BA1 File Offset: 0x00502DA1
	public void LoadEmpty(int index)
	{
		this.ItemIndex = index;
		this.MonsterId = 0;
	}
}
