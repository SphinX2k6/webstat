using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E3C RID: 3644
public class WaterDetectedCapability : GameCapability, IWaterDetectedCapability, IGameCapability
{
	// Token: 0x06005735 RID: 22325 RVA: 0x00105427 File Offset: 0x00103627
	public virtual void OnWaterDetectedStart()
	{
	}

	// Token: 0x06005736 RID: 22326 RVA: 0x00105429 File Offset: 0x00103629
	public virtual void OnWaterDetectedEnd()
	{
	}

	// Token: 0x06005737 RID: 22327 RVA: 0x0010542B File Offset: 0x0010362B
	[NullableContext(1)]
	public virtual void OnWaterDetectedTick(float deltaTime, Vector impactPoint, Vector impactNormal)
	{
	}
}
