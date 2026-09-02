using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002DFB RID: 11771
public class BulletChildInfo
{
	// Token: 0x06017C68 RID: 97384 RVA: 0x006A0598 File Offset: 0x0069E798
	public void SetIsNumberNotEnough(bool value)
	{
		this.IsNumberNotEnough = value;
	}

	// Token: 0x06017C69 RID: 97385 RVA: 0x006A05A1 File Offset: 0x0069E7A1
	public void SetIsActiveSummonChildBullet(bool value)
	{
		this.IsActiveSummonChildBullet = value;
	}

	// Token: 0x0400B7A3 RID: 47011
	public bool IsNumberNotEnough;

	// Token: 0x0400B7A4 RID: 47012
	public bool IsActiveSummonChildBullet;

	// Token: 0x0400B7A5 RID: 47013
	public bool HaveSpecialChildrenBullet;

	// Token: 0x0400B7A6 RID: 47014
	[Nullable(2)]
	public List<int> HaveSummonedBulletNumber;
}
