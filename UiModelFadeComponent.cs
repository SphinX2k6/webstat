using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C85 RID: 11397
[NullableContext(2)]
[Nullable(0)]
public class UiModelFadeComponent : UiModelComponentBase
{
	// Token: 0x06016DD3 RID: 93651 RVA: 0x006581B9 File Offset: 0x006563B9
	protected override void OnCreate()
	{
		this.Destroyed = false;
	}

	// Token: 0x06016DD4 RID: 93652 RVA: 0x006581C2 File Offset: 0x006563C2
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
	}

	// Token: 0x06016DD5 RID: 93653 RVA: 0x006581D5 File Offset: 0x006563D5
	protected override void OnEnd()
	{
		if (this.NeedTick)
		{
			UiModelDataComponent modelDataComponent = this.ModelDataComponent;
			if (modelDataComponent != null)
			{
				modelDataComponent.SetDitherEffect(this.EndValue);
			}
		}
		this.Destroyed = true;
		this.Reset();
	}

	// Token: 0x06016DD6 RID: 93654 RVA: 0x00658204 File Offset: 0x00656404
	[NullableContext(1)]
	public void Fade(float startValue, float endValue, float duration, string curveId, [Nullable(2)] Action finishCallback = null)
	{
		if (this.Destroyed)
		{
			return;
		}
		this.Reset();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(curveId);
		this.HandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(resourcePath, delegate([Nullable(2)] UCurveFloat curve, string path)
		{
			if (curve != null)
			{
				this.FadeInternal(startValue, endValue, duration, curve, finishCallback);
			}
		}, 100, "Ui.UiSceneModel");
	}

	// Token: 0x06016DD7 RID: 93655 RVA: 0x0065827C File Offset: 0x0065647C
	[NullableContext(1)]
	private void FadeInternal(float startValue, float endValue, float duration, UCurveFloat curve, [Nullable(2)] Action finishCallback = null)
	{
		if (this.Destroyed)
		{
			return;
		}
		this.StartValue = startValue;
		this.EndValue = endValue;
		this.Duration = duration;
		this.Curve = curve;
		this.ElapseTime = 0f;
		this.NeedTick = true;
		this.FadeFinishCallBack = finishCallback;
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		if (modelDataComponent == null)
		{
			return;
		}
		modelDataComponent.SetDitherEffect(startValue);
	}

	// Token: 0x06016DD8 RID: 93656 RVA: 0x006582DC File Offset: 0x006564DC
	public override void Tick(float deltaTime)
	{
		this.ElapseTime += deltaTime * 1000f;
		if (this.Curve != null)
		{
			float ditherEffect = this.Curve.GetFloatValue(this.ElapseTime / this.Duration) * (this.EndValue - this.StartValue) + this.StartValue;
			UiModelDataComponent modelDataComponent = this.ModelDataComponent;
			if (modelDataComponent != null)
			{
				modelDataComponent.SetDitherEffect(ditherEffect);
			}
		}
		if (this.ElapseTime >= this.Duration)
		{
			Action fadeFinishCallBack = this.FadeFinishCallBack;
			if (fadeFinishCallBack != null)
			{
				fadeFinishCallBack();
			}
			this.Reset();
		}
	}

	// Token: 0x06016DD9 RID: 93657 RVA: 0x0065836A File Offset: 0x0065656A
	public void StopFade()
	{
		this.Reset();
	}

	// Token: 0x06016DDA RID: 93658 RVA: 0x00658372 File Offset: 0x00656572
	private void CancelLoad()
	{
		if (this.HandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
		}
		this.HandleId = -1;
	}

	// Token: 0x06016DDB RID: 93659 RVA: 0x00658394 File Offset: 0x00656594
	private void Reset()
	{
		this.StartValue = 0f;
		this.EndValue = 0f;
		this.Duration = 0f;
		this.Curve = null;
		this.ElapseTime = 0f;
		this.NeedTick = false;
		this.FadeFinishCallBack = null;
		this.CancelLoad();
	}

	// Token: 0x0400B067 RID: 45159
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B068 RID: 45160
	private float StartValue;

	// Token: 0x0400B069 RID: 45161
	private float EndValue;

	// Token: 0x0400B06A RID: 45162
	private float ElapseTime;

	// Token: 0x0400B06B RID: 45163
	private float Duration;

	// Token: 0x0400B06C RID: 45164
	private UCurveFloat Curve;

	// Token: 0x0400B06D RID: 45165
	private bool Destroyed;

	// Token: 0x0400B06E RID: 45166
	private int HandleId = -1;

	// Token: 0x0400B06F RID: 45167
	protected Action FadeFinishCallBack;
}
