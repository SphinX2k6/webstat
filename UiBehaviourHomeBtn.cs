using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02002C57 RID: 11351
[NullableContext(1)]
[Nullable(0)]
public class UiBehaviourHomeBtn : IUiBehavior
{
	// Token: 0x06016C2C RID: 93228 RVA: 0x006502B4 File Offset: 0x0064E4B4
	public void SetViewInfo(UiViewBase baseView)
	{
		this.CurrentView = baseView;
	}

	// Token: 0x06016C2D RID: 93229 RVA: 0x006502BD File Offset: 0x0064E4BD
	public UniTask OnUiCreateAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x06016C2E RID: 93230 RVA: 0x006502C4 File Offset: 0x0064E4C4
	public void OnAfterUiStart()
	{
		if (this.CurrentView == null)
		{
			return;
		}
		ControllerBase<HomeBtnController>.Instance.CreateHomeBtnFromView(this.CurrentView);
	}

	// Token: 0x06016C2F RID: 93231 RVA: 0x006502DF File Offset: 0x0064E4DF
	public void OnAfterUiShow()
	{
	}

	// Token: 0x06016C30 RID: 93232 RVA: 0x006502E1 File Offset: 0x0064E4E1
	public void OnBeforeUiHide()
	{
	}

	// Token: 0x06016C31 RID: 93233 RVA: 0x006502E3 File Offset: 0x0064E4E3
	public void OnBeforeDestroy()
	{
		if (this.CurrentView == null)
		{
			return;
		}
		ControllerBase<HomeBtnController>.Instance.RemoveExtraCallback(this.CurrentView.ViewInfo.Name);
	}

	// Token: 0x06016C32 RID: 93234 RVA: 0x00650308 File Offset: 0x0064E508
	public void AddExtraAsyncCallback(Func<UniTask> callback)
	{
		if (this.CurrentView == null)
		{
			return;
		}
		ControllerBase<HomeBtnController>.Instance.AddExtraAsyncCallback(this.CurrentView.ViewInfo.Name, callback);
	}

	// Token: 0x06016C33 RID: 93235 RVA: 0x0065032E File Offset: 0x0064E52E
	public void AddExtraCallback(Action callback)
	{
		if (this.CurrentView == null)
		{
			return;
		}
		ControllerBase<HomeBtnController>.Instance.AddExtraCallback(this.CurrentView.ViewInfo.Name, callback);
	}

	// Token: 0x0400AF6A RID: 44906
	[Nullable(2)]
	private UiViewBase CurrentView;
}
