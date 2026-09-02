using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002C83 RID: 11395
[NullableContext(2)]
[Nullable(0)]
public class UiModelEffectPlayContext
{
	// Token: 0x06016DBC RID: 93628 RVA: 0x006576EC File Offset: 0x006558EC
	public void Reset()
	{
		this.EffectPath = null;
		this.Transform = Singleton<MathUtils>.Instance.DefaultTransformDouble;
		this.AttachTargetComponent = null;
		this.Attached = true;
		this.AttachLocationOnly = false;
		this.SocketName = FNameUtil.EMPTY;
		this.IsForceShow = true;
		this.Location = Vector.ZeroVectorDouble;
		this.Rotator = global::Rotator.ZeroRotator;
		this.Scale = Vector.OneVectorDouble;
		this.LocationRule = EAttachmentRule.KeepRelative;
		this.RotationRule = EAttachmentRule.KeepRelative;
		this.ScaleRule = EAttachmentRule.KeepRelative;
		this.EffectType = EEffectType.UiScene3D;
		this.Callback = null;
	}

	// Token: 0x0400B04E RID: 45134
	public string EffectPath;

	// Token: 0x0400B04F RID: 45135
	public FTransformDouble Transform = Singleton<MathUtils>.Instance.DefaultTransformDouble;

	// Token: 0x0400B050 RID: 45136
	public USceneComponent AttachTargetComponent;

	// Token: 0x0400B051 RID: 45137
	public bool Attached = true;

	// Token: 0x0400B052 RID: 45138
	public bool AttachLocationOnly;

	// Token: 0x0400B053 RID: 45139
	public FName SocketName = FNameUtil.EMPTY;

	// Token: 0x0400B054 RID: 45140
	public bool IsForceShow = true;

	// Token: 0x0400B055 RID: 45141
	public FVectorDouble Location = Vector.ZeroVectorDouble;

	// Token: 0x0400B056 RID: 45142
	public FRotator Rotator = global::Rotator.ZeroRotator;

	// Token: 0x0400B057 RID: 45143
	public FVectorDouble Scale = Vector.OneVectorDouble;

	// Token: 0x0400B058 RID: 45144
	public EAttachmentRule LocationRule;

	// Token: 0x0400B059 RID: 45145
	public EAttachmentRule RotationRule;

	// Token: 0x0400B05A RID: 45146
	public EAttachmentRule ScaleRule;

	// Token: 0x0400B05B RID: 45147
	public EEffectType EffectType = EEffectType.UiScene3D;

	// Token: 0x0400B05C RID: 45148
	public Action<ELoadEffectResult, int> Callback;
}
