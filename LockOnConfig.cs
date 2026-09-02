using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;

// Token: 0x0200301E RID: 12318
public class LockOnConfig
{
	// Token: 0x06019213 RID: 102931 RVA: 0x00726876 File Offset: 0x00724A76
	[NullableContext(1)]
	public LockOnConfig(SLockOnConfig config)
	{
		this.IsOpened = config.IsOpened;
		this.Distance = (double)config.Distance;
		this.UpDistance = (double)config.UpDistance;
		this.DownDistance = (double)config.DownDistance;
	}

	// Token: 0x0400C533 RID: 50483
	public bool IsOpened;

	// Token: 0x0400C534 RID: 50484
	public double Distance;

	// Token: 0x0400C535 RID: 50485
	public double UpDistance;

	// Token: 0x0400C536 RID: 50486
	public double DownDistance;
}
