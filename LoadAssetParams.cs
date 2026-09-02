using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F46 RID: 3910
public class LoadAssetParams<TD> where TD : UDataAsset
{
	// Token: 0x04002EFE RID: 12030
	[Nullable(2)]
	public UObject Context;

	// Token: 0x04002EFF RID: 12031
	public int Id;

	// Token: 0x04002F00 RID: 12032
	[Nullable(1)]
	public string Path = "";

	// Token: 0x04002F01 RID: 12033
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TMap<TD, int> NativeContainer;

	// Token: 0x04002F02 RID: 12034
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<TD> Callback;

	// Token: 0x04002F03 RID: 12035
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<string> FailCallback;

	// Token: 0x04002F04 RID: 12036
	public int KscWorldHandle;
}
