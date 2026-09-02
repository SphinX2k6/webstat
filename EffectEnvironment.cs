using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02000087 RID: 135
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EffectEnvironment : Singleton<EffectEnvironment>
{
	// Token: 0x17000067 RID: 103
	// (get) Token: 0x06000312 RID: 786 RVA: 0x00012BCC File Offset: 0x00010DCC
	// (set) Token: 0x06000313 RID: 787 RVA: 0x00012BD4 File Offset: 0x00010DD4
	public float GlobalTimeScale
	{
		get
		{
			return this.GlobalTimeScaleInternal;
		}
		set
		{
			if (this.GlobalTimeScaleInternal != value)
			{
				this.GlobalTimeScaleInternal = value;
				UKuroEffectSystemFunctionLibrary.SetGlobalTimeScale(value);
			}
		}
	}

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x06000314 RID: 788 RVA: 0x00012BEC File Offset: 0x00010DEC
	// (set) Token: 0x06000315 RID: 789 RVA: 0x00012BF4 File Offset: 0x00010DF4
	public bool DisableOtherEffect
	{
		get
		{
			return this.DisableOtherEffectInternal;
		}
		set
		{
			if (this.DisableOtherEffectInternal != value)
			{
				this.DisableOtherEffectInternal = value;
				UKuroEffectSystemFunctionLibrary.OnDisableOtherEffectChange(value);
			}
		}
	}

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x06000316 RID: 790 RVA: 0x00012C0C File Offset: 0x00010E0C
	// (set) Token: 0x06000317 RID: 791 RVA: 0x00012C14 File Offset: 0x00010E14
	public int EffectQualityBiasRemote
	{
		get
		{
			return this.EffectQualityBiasRemoteInternal;
		}
		set
		{
			if (this.EffectQualityBiasRemoteInternal != value)
			{
				this.EffectQualityBiasRemoteInternal = value;
				UKuroEffectSystemFunctionLibrary.OnEffectQualityBiasRemoteChange((float)value);
			}
		}
	}

	// Token: 0x06000318 RID: 792 RVA: 0x00012C2D File Offset: 0x00010E2D
	public void Initialize()
	{
		this.UseLog = Singleton<Info>.Instance.IsBuildDevelopmentOrDebug;
	}

	// Token: 0x06000319 RID: 793 RVA: 0x00012C40 File Offset: 0x00010E40
	public void Tick(float delta, UWorld world)
	{
		float num = delta * 0.001f;
		this.GameTimeInSeconds += (double)num;
	}

	// Token: 0x04000330 RID: 816
	public double GameTimeInSeconds;

	// Token: 0x04000331 RID: 817
	private float GlobalTimeScaleInternal = 1f;

	// Token: 0x04000332 RID: 818
	public bool UseLog = true;

	// Token: 0x04000333 RID: 819
	private bool DisableOtherEffectInternal;

	// Token: 0x04000334 RID: 820
	public bool UsePool = true;

	// Token: 0x04000335 RID: 821
	private int EffectQualityBiasRemoteInternal = -1;

	// Token: 0x04000336 RID: 822
	public bool CloseEffectSubStat = true;

	// Token: 0x04000337 RID: 823
	public readonly bool OpenVisibilityOptimize = true;

	// Token: 0x04000338 RID: 824
	public readonly bool OpenDistanceOptimize = true;
}
