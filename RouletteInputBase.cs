using System;
using System.Runtime.CompilerServices;

// Token: 0x0200293C RID: 10556
[NullableContext(2)]
[Nullable(0)]
public abstract class RouletteInputBase
{
	// Token: 0x06014F37 RID: 85815 RVA: 0x005CC3AC File Offset: 0x005CA5AC
	public RouletteInputBase(Vector2D pos = null, ERouletteViewType? rouletteViewType = null, int? touchId = null, float? limit = null)
	{
		this.BeginPos = pos;
		this.RouletteViewType = rouletteViewType.GetValueOrDefault(ERouletteViewType.Main);
	}

	// Token: 0x06014F38 RID: 85816 RVA: 0x005CC40F File Offset: 0x005CA60F
	public void ActivateInput(bool isOn)
	{
		this.ActivateOn = isOn;
	}

	// Token: 0x06014F39 RID: 85817 RVA: 0x005CC418 File Offset: 0x005CA618
	public void Destroy()
	{
		this.ActivateInput(false);
		this.UnBindEvent();
		this.OnDestroy();
	}

	// Token: 0x06014F3A RID: 85818 RVA: 0x005CC42D File Offset: 0x005CA62D
	protected void Reset()
	{
		this.AreaIndex = 0;
		this.Angle = -1;
	}

	// Token: 0x06014F3B RID: 85819 RVA: 0x005CC43D File Offset: 0x005CA63D
	protected void EndInput()
	{
		this.ActivateOn = false;
		Action onEndInputEvent = this.OnEndInputEvent;
		if (onEndInputEvent == null)
		{
			return;
		}
		onEndInputEvent();
	}

	// Token: 0x06014F3C RID: 85820 RVA: 0x005CC456 File Offset: 0x005CA656
	[NullableContext(1)]
	public void SetEndInputEvent(Action eventHandler)
	{
		this.OnEndInputEvent = eventHandler;
	}

	// Token: 0x06014F3D RID: 85821 RVA: 0x005CC45F File Offset: 0x005CA65F
	public void SetIsNeedEmpty(bool canEmpty)
	{
		this.NeedEmptyChoose = canEmpty;
	}

	// Token: 0x06014F3E RID: 85822 RVA: 0x005CC468 File Offset: 0x005CA668
	public virtual void OnInit()
	{
	}

	// Token: 0x06014F3F RID: 85823 RVA: 0x005CC46A File Offset: 0x005CA66A
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x06014F40 RID: 85824 RVA: 0x005CC46C File Offset: 0x005CA66C
	public virtual void BindEvent()
	{
	}

	// Token: 0x06014F41 RID: 85825 RVA: 0x005CC46E File Offset: 0x005CA66E
	protected virtual void UnBindEvent()
	{
	}

	// Token: 0x06014F42 RID: 85826 RVA: 0x005CC470 File Offset: 0x005CA670
	protected virtual void InputTick(float delta)
	{
	}

	// Token: 0x06014F43 RID: 85827 RVA: 0x005CC474 File Offset: 0x005CA674
	[NullableContext(0)]
	public ValueTuple<int?, int?> Tick(float delta)
	{
		if (!this.ActivateOn)
		{
			return new ValueTuple<int?, int?>(null, null);
		}
		int areaIndex = this.AreaIndex;
		int angle = this.Angle;
		this.InputTick(delta);
		int? item = (areaIndex != this.AreaIndex) ? new int?(this.AreaIndex) : null;
		int? item2 = (angle != this.Angle) ? new int?(this.Angle) : null;
		return new ValueTuple<int?, int?>(item, item2);
	}

	// Token: 0x0400A178 RID: 41336
	protected bool ActivateOn;

	// Token: 0x0400A179 RID: 41337
	protected int AreaIndex;

	// Token: 0x0400A17A RID: 41338
	protected int Angle = -1;

	// Token: 0x0400A17B RID: 41339
	protected bool NeedEmptyChoose = true;

	// Token: 0x0400A17C RID: 41340
	public ERouletteViewType RouletteViewType = ERouletteViewType.Main;

	// Token: 0x0400A17D RID: 41341
	public Vector2D BeginPos;

	// Token: 0x0400A17E RID: 41342
	[Nullable(1)]
	protected readonly Vector ForwardVector = Vector.Create(0.0, -1.0, 0.0);

	// Token: 0x0400A17F RID: 41343
	private Action OnEndInputEvent;
}
