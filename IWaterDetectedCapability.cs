using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E3B RID: 3643
public interface IWaterDetectedCapability : IGameCapability
{
	// Token: 0x06005732 RID: 22322
	void OnWaterDetectedStart();

	// Token: 0x06005733 RID: 22323
	void OnWaterDetectedEnd();

	// Token: 0x06005734 RID: 22324
	[NullableContext(1)]
	void OnWaterDetectedTick(float deltaTime, Vector impactPoint, Vector impactNormal);
}
