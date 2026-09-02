using System;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x0200206A RID: 8298
public class SliderItem : UiPanelBase
{
	// Token: 0x170012BC RID: 4796
	// (get) Token: 0x0600FCEA RID: 64746 RVA: 0x00456C72 File Offset: 0x00454E72
	// (set) Token: 0x0600FCEB RID: 64747 RVA: 0x00456C7A File Offset: 0x00454E7A
	public float AddShowTime
	{
		get
		{
			return this.AddShowTimeInternal;
		}
		set
		{
			this.AddShowTimeInternal = value;
		}
	}

	// Token: 0x170012BD RID: 4797
	// (get) Token: 0x0600FCEC RID: 64748 RVA: 0x00456C83 File Offset: 0x00454E83
	// (set) Token: 0x0600FCED RID: 64749 RVA: 0x00456C8B File Offset: 0x00454E8B
	public EStatus Status
	{
		get
		{
			return this.StatusInternal;
		}
		set
		{
			this.StatusInternal = value;
		}
	}

	// Token: 0x0600FCEE RID: 64750 RVA: 0x00456C94 File Offset: 0x00454E94
	public virtual UniTask AsyncLoadUiResource()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600FCEF RID: 64751 RVA: 0x00456C9B File Offset: 0x00454E9B
	public virtual void InitData()
	{
	}

	// Token: 0x0600FCF0 RID: 64752 RVA: 0x00456C9D File Offset: 0x00454E9D
	public virtual void Play()
	{
		this.StatusInternal = EStatus.Start;
		this.AddShowTime = 0f;
		this.PlayStart();
	}

	// Token: 0x0600FCF1 RID: 64753 RVA: 0x00456CB7 File Offset: 0x00454EB7
	protected virtual void PlayStart()
	{
	}

	// Token: 0x0600FCF2 RID: 64754 RVA: 0x00456CB9 File Offset: 0x00454EB9
	protected void FinishPlayStart()
	{
		this.StatusInternal = EStatus.Halfway;
		this.PlayHalfway();
	}

	// Token: 0x0600FCF3 RID: 64755 RVA: 0x00456CC8 File Offset: 0x00454EC8
	protected virtual void PlayHalfway()
	{
	}

	// Token: 0x0600FCF4 RID: 64756 RVA: 0x00456CCA File Offset: 0x00454ECA
	protected void FinishPlayHalfway()
	{
	}

	// Token: 0x0600FCF5 RID: 64757 RVA: 0x00456CCC File Offset: 0x00454ECC
	public virtual void PlayEnd()
	{
	}

	// Token: 0x0600FCF6 RID: 64758 RVA: 0x00456CCE File Offset: 0x00454ECE
	protected void FinishPlayEnd()
	{
		this.StatusInternal = EStatus.Finish;
	}

	// Token: 0x0600FCF7 RID: 64759 RVA: 0x00456CD7 File Offset: 0x00454ED7
	public virtual void Tick(float delta)
	{
		this.OnTick(delta);
	}

	// Token: 0x0600FCF8 RID: 64760 RVA: 0x00456CE0 File Offset: 0x00454EE0
	public virtual void ActiveStatusChange(bool status)
	{
		this.OnActiveStatusChange(status);
	}

	// Token: 0x0600FCF9 RID: 64761 RVA: 0x00456CE9 File Offset: 0x00454EE9
	protected virtual void OnActiveStatusChange(bool status)
	{
	}

	// Token: 0x0600FCFA RID: 64762 RVA: 0x00456CEB File Offset: 0x00454EEB
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x0600FCFB RID: 64763 RVA: 0x00456CED File Offset: 0x00454EED
	public virtual bool ShowTimeIsEnough(float time)
	{
		return this.AddShowTime >= time;
	}

	// Token: 0x0400795B RID: 31067
	protected float AddShowTimeInternal;

	// Token: 0x0400795C RID: 31068
	private EStatus StatusInternal;
}
