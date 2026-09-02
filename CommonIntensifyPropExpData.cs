using System;
using System.Runtime.CompilerServices;

// Token: 0x020019FA RID: 6650
public class CommonIntensifyPropExpData
{
	// Token: 0x04005984 RID: 22916
	public int CurrentLevel;

	// Token: 0x04005985 RID: 22917
	public int CurrentMaxLevel;

	// Token: 0x04005986 RID: 22918
	public int CurrentExp;

	// Token: 0x04005987 RID: 22919
	[Nullable(2)]
	public Func<int, int> MaxExpFunction;

	// Token: 0x04005988 RID: 22920
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<ISelectedData, int> GetItemExpFunction;
}
