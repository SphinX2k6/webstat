using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200232B RID: 9003
[NullableContext(1)]
public interface INpcIconFunction
{
	// Token: 0x06011200 RID: 70144
	Vector GetSelfLocation();

	// Token: 0x06011201 RID: 70145
	[NullableContext(2)]
	UPrimitiveComponent GetAttachToMeshComponent();

	// Token: 0x06011202 RID: 70146
	string GetAttachToSocketName();

	// Token: 0x06011203 RID: 70147
	void GetAttachToLocation(Vector outVec);

	// Token: 0x06011204 RID: 70148
	double GetAddOffsetZ();

	// Token: 0x06011205 RID: 70149
	bool IsShowNameInfo();

	// Token: 0x06011206 RID: 70150
	bool IsShowPlayerInfo();

	// Token: 0x06011207 RID: 70151
	bool IsShowQuestInfo();

	// Token: 0x06011208 RID: 70152
	float GetDialogWorldScale3D();

	// Token: 0x06011209 RID: 70153
	bool CanTick(float deltaTime);

	// Token: 0x0601120A RID: 70154
	bool IsInHeadItemShowRange(double disSquared, double maxShowRangeDisSquared, double minShowRangeDisSquared);
}
