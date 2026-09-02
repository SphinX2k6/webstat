using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001ECC RID: 7884
[NullableContext(1)]
[Nullable(0)]
public class HandRuntime
{
	// Token: 0x0600E904 RID: 59652 RVA: 0x003F15E1 File Offset: 0x003EF7E1
	public void LerpAlphas(double damping, double deltaTime)
	{
		if (this.IkTarget == null)
		{
			return;
		}
		this.IkTarget.Alpha = Singleton<MathUtils>.Instance.InterpTo(this.IkTarget.Alpha, (double)this.TargetAlpha, deltaTime, 1.0 / damping);
	}

	// Token: 0x04007056 RID: 28758
	public bool InBind;

	// Token: 0x04007057 RID: 28759
	public EHandType HandType;

	// Token: 0x04007058 RID: 28760
	public double MaxBendLength;

	// Token: 0x04007059 RID: 28761
	public FTransform? CachedClavicle;

	// Token: 0x0400705A RID: 28762
	public FTransform? CachedShoulder;

	// Token: 0x0400705B RID: 28763
	public FTransform? CachedHand;

	// Token: 0x0400705C RID: 28764
	public FTransform? CachedRingFinger;

	// Token: 0x0400705D RID: 28765
	public Transform RootAfterIk = Transform.Create();

	// Token: 0x0400705E RID: 28766
	public Transform Clavicle = Transform.Create();

	// Token: 0x0400705F RID: 28767
	public Transform Shoulder = Transform.Create();

	// Token: 0x04007060 RID: 28768
	public Transform Hand = Transform.Create();

	// Token: 0x04007061 RID: 28769
	public Transform RingFinger = Transform.Create();

	// Token: 0x04007062 RID: 28770
	public Vector FingerLocalPos = Vector.Create();

	// Token: 0x04007063 RID: 28771
	public Quat FingerLocalRot = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04007064 RID: 28772
	public double FingerOffsetSize;

	// Token: 0x04007065 RID: 28773
	public Vector AnimBindPos = Vector.Create();

	// Token: 0x04007066 RID: 28774
	public Vector AnimBindVec = Vector.Create();

	// Token: 0x04007067 RID: 28775
	public double AnimBendLength;

	// Token: 0x04007068 RID: 28776
	public Vector AnimHandNormal = Vector.Create();

	// Token: 0x04007069 RID: 28777
	public Vector AnimFingerNormal = Vector.Create();

	// Token: 0x0400706A RID: 28778
	public Vector ClavicleDir = Vector.Create();

	// Token: 0x0400706B RID: 28779
	public Vector BindPos = Vector.Create();

	// Token: 0x0400706C RID: 28780
	public Vector BindDir = Vector.Create();

	// Token: 0x0400706D RID: 28781
	public Vector BindDirSmooth = Vector.Create();

	// Token: 0x0400706E RID: 28782
	public Vector BindVec = Vector.Create();

	// Token: 0x0400706F RID: 28783
	public double BendLength;

	// Token: 0x04007070 RID: 28784
	public Vector FingerNormal = Vector.Create();

	// Token: 0x04007071 RID: 28785
	public Vector HandNormal = Vector.Create();

	// Token: 0x04007072 RID: 28786
	public Vector HandPosTarget = Vector.Create();

	// Token: 0x04007073 RID: 28787
	public Quat HandRotTarget = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04007074 RID: 28788
	public float TargetAlpha;

	// Token: 0x04007075 RID: 28789
	[Nullable(2)]
	public IkTarget IkTarget = new IkTarget(null, null, null);

	// Token: 0x04007076 RID: 28790
	[Nullable(2)]
	public FIKTarget IkTargetUe;

	// Token: 0x04007077 RID: 28791
	public Quat BindDirDeltaRot = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04007078 RID: 28792
	public Quat ArmDeltaRot = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04007079 RID: 28793
	public Vector ShoulderDir = Vector.Create();

	// Token: 0x0400707A RID: 28794
	public Vector ShoulderDirLocal = Vector.Create();

	// Token: 0x0400707B RID: 28795
	public Rotator ShoulderLocalEuler = Rotator.Create();

	// Token: 0x0400707C RID: 28796
	public Vector BindVecOnNormal = Vector.Create();

	// Token: 0x0400707D RID: 28797
	public Vector BindDirRootSpace = Vector.Create();

	// Token: 0x0400707E RID: 28798
	public Rotator BindDirRsEuler = Rotator.Create();
}
