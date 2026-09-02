using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CFF RID: 11519
[NullableContext(1)]
[Nullable(0)]
public class MaterialData
{
	// Token: 0x06017424 RID: 95268 RVA: 0x00673249 File Offset: 0x00671449
	public MaterialData(ItemDataBase itemData, int useCount = 1)
	{
		this.ItemData = itemData;
		this.UseCount = useCount;
	}

	// Token: 0x06017425 RID: 95269 RVA: 0x0067325F File Offset: 0x0067145F
	public void AddCount()
	{
		this.UseCount++;
	}

	// Token: 0x06017426 RID: 95270 RVA: 0x0067326F File Offset: 0x0067146F
	public void ReduceCount()
	{
		this.UseCount--;
	}

	// Token: 0x06017427 RID: 95271 RVA: 0x0067327F File Offset: 0x0067147F
	public bool CheckEmpty()
	{
		return this.UseCount == 0;
	}

	// Token: 0x0400B2BD RID: 45757
	public ItemDataBase ItemData;

	// Token: 0x0400B2BE RID: 45758
	public int UseCount;
}
