using System;
using System.Runtime.CompilerServices;

// Token: 0x0200008D RID: 141
[NullableContext(1)]
public interface IEntityArgs
{
	// Token: 0x06000378 RID: 888
	T GetP1<[Nullable(2)] T>();

	// Token: 0x06000379 RID: 889
	T GetP2<[Nullable(2)] T>();

	// Token: 0x0600037A RID: 890
	T GetP3<[Nullable(2)] T>();

	// Token: 0x0600037B RID: 891
	T GetP4<[Nullable(2)] T>();

	// Token: 0x0600037C RID: 892
	T GetP5<[Nullable(2)] T>();
}
