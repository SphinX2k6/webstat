using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001ECD RID: 7885
[NullableContext(1)]
[Nullable(0)]
public class IkTarget
{
	// Token: 0x0600E906 RID: 59654 RVA: 0x003F17D0 File Offset: 0x003EF9D0
	[NullableContext(2)]
	public IkTarget(Vector location = null, Quat rotation = null, double? alpha = null)
	{
		this.Location = (location ?? Vector.Create(0.0, 0.0, 0.0));
		this.Rotation = (rotation ?? Quat.Create(0f, 0f, 0f, 1f));
		this.Alpha = alpha.GetValueOrDefault();
	}

	// Token: 0x0600E907 RID: 59655 RVA: 0x003F1874 File Offset: 0x003EFA74
	[NullableContext(2)]
	public bool Equals(IkTarget inB)
	{
		if (inB != null)
		{
			return this.Location.Equals(inB.Location, 9.999999747378752E-05) && this.Rotation.Equals(inB.Rotation, 0.0001f) && this.Alpha == inB.Alpha;
		}
		return this.Alpha == 0.0;
	}

	// Token: 0x0600E908 RID: 59656 RVA: 0x003F18DC File Offset: 0x003EFADC
	[NullableContext(2)]
	public void DeepCopy(IkTarget other)
	{
		if (other != null)
		{
			this.Location.DeepCopy(other.Location);
			this.Rotation.DeepCopy(other.Rotation);
			this.Alpha = other.Alpha;
			return;
		}
		this.Alpha = 0.0;
	}

	// Token: 0x0600E909 RID: 59657 RVA: 0x003F192A File Offset: 0x003EFB2A
	public FIKTarget ToUeIkTarget()
	{
		FIKTarget cacheUeIkTarget = this.CacheUeIkTarget;
		cacheUeIkTarget.Location = this.Location.ToUeVectorOld();
		cacheUeIkTarget.Rotation = this.Rotation.ToUeQuat();
		cacheUeIkTarget.Alpha = (float)this.Alpha;
		return cacheUeIkTarget;
	}

	// Token: 0x0400707F RID: 28799
	public Vector Location = Vector.Create();

	// Token: 0x04007080 RID: 28800
	public Quat Rotation = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04007081 RID: 28801
	public double Alpha;

	// Token: 0x04007082 RID: 28802
	private readonly FIKTarget CacheUeIkTarget = new FIKTarget();
}
