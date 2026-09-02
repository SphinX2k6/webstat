using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200236C RID: 9068
public class ParallelPackageConfig
{
	// Token: 0x0400885D RID: 34909
	public int version;

	// Token: 0x0400885E RID: 34910
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ParallelPackageUrlConfig> packageConfig;

	// Token: 0x0400885F RID: 34911
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<string, ParallelPackageLanguageContent> languageConfig;
}
