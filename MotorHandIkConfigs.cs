using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003037 RID: 12343
[NullableContext(1)]
[Nullable(0)]
public class MotorHandIkConfigs
{
	// Token: 0x060193DA RID: 103386 RVA: 0x0073B228 File Offset: 0x00739428
	public MotorHandIkConfigs(Transform handTrans, bool isRight)
	{
		this.HandTrans = handTrans;
		if (isRight)
		{
			this.MotorBone = FNameUtil.GetDynamicFName("Bone_Other002_R").Value;
			this.HandName = FNameUtil.GetDynamicFName("Bip001RHand").Value;
			return;
		}
		this.MotorBone = FNameUtil.GetDynamicFName("Bone_Other002_L").Value;
		this.HandName = FNameUtil.GetDynamicFName("Bip001LHand").Value;
	}

	// Token: 0x0400C69A RID: 50842
	public FName MotorBone = FNameUtil.EMPTY;

	// Token: 0x0400C69B RID: 50843
	public FName HandName = FNameUtil.EMPTY;

	// Token: 0x0400C69C RID: 50844
	public Transform HandTrans;
}
