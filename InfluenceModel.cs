using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001FDE RID: 8158
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class InfluenceModel : ModelBase<InfluenceModel>
{
	// Token: 0x0600F639 RID: 63033 RVA: 0x004368F0 File Offset: 0x00434AF0
	public void AddUnlockCountry(int[] unlockItems)
	{
		for (int i = 0; i < unlockItems.Length; i++)
		{
			if (!this.UnlockCountry.Contains(unlockItems[i]))
			{
				this.UnlockCountry.Add(unlockItems[i]);
			}
		}
	}

	// Token: 0x0600F63A RID: 63034 RVA: 0x0043692C File Offset: 0x00434B2C
	public void AddUnlockInfluence(int[] unlockItems)
	{
		for (int i = 0; i < unlockItems.Length; i++)
		{
			if (!this.UnlockInfluence.Contains(unlockItems[i]))
			{
				this.UnlockInfluence.Add(unlockItems[i]);
			}
		}
	}

	// Token: 0x04007709 RID: 30473
	public HashSet<int> UnlockCountry = new HashSet<int>();

	// Token: 0x0400770A RID: 30474
	public HashSet<int> UnlockInfluence = new HashSet<int>();

	// Token: 0x0400770B RID: 30475
	public int CurrentSelectAreaId;

	// Token: 0x0400770C RID: 30476
	public int CurrentSelectInfluenceId;
}
