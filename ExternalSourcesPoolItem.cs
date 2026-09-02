using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200002F RID: 47
[NullableContext(1)]
[Nullable(0)]
public class ExternalSourcesPoolItem
{
	// Token: 0x060000CC RID: 204 RVA: 0x00006779 File Offset: 0x00004979
	public ExternalSourcesPoolItem(UAkExternalMediaAsset asset)
	{
		this.ExternalSources = asset;
		this.UseTime = Singleton<Time>.Instance.Now;
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00006798 File Offset: 0x00004998
	public void ClearData(string path)
	{
		if (this.ExternalSources != null)
		{
			this.ExternalSources = null;
		}
	}

	// Token: 0x0400009C RID: 156
	public double UseTime;

	// Token: 0x0400009D RID: 157
	[Nullable(2)]
	private UAkExternalMediaAsset ExternalSources;
}
