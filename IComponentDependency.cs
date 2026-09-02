using System;
using System.Runtime.CompilerServices;

// Token: 0x02000097 RID: 151
public interface IComponentDependency
{
	// Token: 0x17000089 RID: 137
	// (get) Token: 0x060003F1 RID: 1009
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Type[] Dependencies { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; }
}
