using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CD6 RID: 11478
[NullableContext(1)]
[Nullable(0)]
public abstract class LguiTweenBase<[Nullable(2)] T>
{
	// Token: 0x0601720C RID: 94732 RVA: 0x00668DE8 File Offset: 0x00666FE8
	protected void PlayFillAmount(T value)
	{
		Action<T> updateTween = this.UpdateTween;
		if (updateTween == null)
		{
			return;
		}
		updateTween(value);
	}

	// Token: 0x0601720D RID: 94733 RVA: 0x00668DFB File Offset: 0x00666FFB
	private void PlayTweenStart()
	{
		Action startTween = this.StartTween;
		if (startTween == null)
		{
			return;
		}
		startTween();
	}

	// Token: 0x0601720E RID: 94734 RVA: 0x00668E0D File Offset: 0x0066700D
	private void PlayTweenComplete()
	{
		this.IsFinished = true;
		this.KillTween();
		Action completeTween = this.CompleteTween;
		if (completeTween == null)
		{
			return;
		}
		completeTween();
	}

	// Token: 0x0601720F RID: 94735 RVA: 0x00668E2C File Offset: 0x0066702C
	public void PlayTween(T start, T end, float time, [Nullable(2)] UCurveFloat curve = null)
	{
		this.IsFinished = false;
		this.KillTween();
		this.Tweener = this.CreateTween(start, end, time);
		if (this.Tweener != null)
		{
			if (curve != null)
			{
				this.Tweener.SetEase(LTweenEase.CurveFloat);
				this.Tweener.SetCurveFloat(curve);
			}
			this.Tweener.OnStartCallBack.Bind(new Action(this.PlayTweenStart));
			this.Tweener.OnCompleteCallBack.Bind(new Action(this.PlayTweenComplete));
		}
	}

	// Token: 0x06017210 RID: 94736 RVA: 0x00668EB5 File Offset: 0x006670B5
	public void SetCurrentEase(LTweenEase ease)
	{
		if (this.Tweener != null)
		{
			this.Tweener.SetEase(ease);
		}
	}

	// Token: 0x06017211 RID: 94737 RVA: 0x00668ECC File Offset: 0x006670CC
	public void KillTween()
	{
		if (this.Tweener != null)
		{
			this.Tweener.Kill(false);
			this.Tweener.OnStartCallBack.Unbind();
			this.Tweener.OnCompleteCallBack.Unbind();
			this.Tweener = null;
		}
	}

	// Token: 0x06017212 RID: 94738 RVA: 0x00668F09 File Offset: 0x00667109
	public void BindStartTween(Action startTween)
	{
		this.StartTween = startTween;
	}

	// Token: 0x06017213 RID: 94739 RVA: 0x00668F12 File Offset: 0x00667112
	public void BindUpdateTween(Action<T> updateTween)
	{
		this.UpdateTween = updateTween;
	}

	// Token: 0x06017214 RID: 94740 RVA: 0x00668F1B File Offset: 0x0066711B
	public void BindCompleteTween(Action completeTween)
	{
		this.CompleteTween = completeTween;
	}

	// Token: 0x06017215 RID: 94741 RVA: 0x00668F24 File Offset: 0x00667124
	public void Destroy()
	{
		this.KillTween();
		this.OnDestroy();
	}

	// Token: 0x06017216 RID: 94742 RVA: 0x00668F32 File Offset: 0x00667132
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x06017217 RID: 94743
	[return: Nullable(2)]
	protected abstract ULTweener CreateTween(T start, T end, float time);

	// Token: 0x0400B1F7 RID: 45559
	public bool IsFinished;

	// Token: 0x0400B1F8 RID: 45560
	[Nullable(2)]
	protected ULTweener Tweener;

	// Token: 0x0400B1F9 RID: 45561
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<T> UpdateTween;

	// Token: 0x0400B1FA RID: 45562
	[Nullable(2)]
	public Action StartTween;

	// Token: 0x0400B1FB RID: 45563
	[Nullable(2)]
	public Action CompleteTween;
}
