using System;
using System.Runtime.CompilerServices;

// Token: 0x02003135 RID: 12597
public class ILogicalStructure
{
	// Token: 0x0400D14C RID: 53580
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public ILogicalStructure[] And;

	// Token: 0x0400D14D RID: 53581
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public ILogicalStructure[] Or;

	// Token: 0x0400D14E RID: 53582
	[Nullable(2)]
	public ILogicalStructure Not;

	// Token: 0x0400D14F RID: 53583
	public int? Index;
}
