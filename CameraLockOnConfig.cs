using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;

// Token: 0x0200301F RID: 12319
[NullableContext(1)]
[Nullable(0)]
public class CameraLockOnConfig
{
	// Token: 0x06019214 RID: 102932 RVA: 0x007268B1 File Offset: 0x00724AB1
	public CameraLockOnConfig(SCameraLockOnConfig config)
	{
		this.IsEnabled = config.IsEnabled;
		this.CameraLockOnBoneName = config.CameraLockOnBoneName;
	}

	// Token: 0x0400C537 RID: 50487
	public bool IsEnabled;

	// Token: 0x0400C538 RID: 50488
	public string CameraLockOnBoneName = "";
}
