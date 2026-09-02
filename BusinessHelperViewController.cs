using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020013CD RID: 5069
[NullableContext(1)]
[Nullable(0)]
public class BusinessHelperViewController
{
	// Token: 0x06008C0E RID: 35854 RVA: 0x0024DB12 File Offset: 0x0024BD12
	public void RegisterView(BusinessHelperView view)
	{
		this.View = view;
	}

	// Token: 0x06008C0F RID: 35855 RVA: 0x0024DB1B File Offset: 0x0024BD1B
	public void Show()
	{
		this.View.ShowView(this.InInteractive);
	}

	// Token: 0x06008C10 RID: 35856 RVA: 0x0024DB30 File Offset: 0x0024BD30
	public UniTask RefreshSpine(int roleId)
	{
		BusinessHelperViewController.<RefreshSpine>d__7 <RefreshSpine>d__;
		<RefreshSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSpine>d__.<>4__this = this;
		<RefreshSpine>d__.roleId = roleId;
		<RefreshSpine>d__.<>1__state = -1;
		<RefreshSpine>d__.<>t__builder.Start<BusinessHelperViewController.<RefreshSpine>d__7>(ref <RefreshSpine>d__);
		return <RefreshSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06008C11 RID: 35857 RVA: 0x0024DB7B File Offset: 0x0024BD7B
	public void SkipToHelpPanel()
	{
		this.InInteractive = false;
		this.View.SkipToHelpPanel();
	}

	// Token: 0x06008C12 RID: 35858 RVA: 0x0024DB8F File Offset: 0x0024BD8F
	public void SkipToInteractivePanel()
	{
		this.InInteractive = true;
		this.View.SkipToInteractivePanel();
	}

	// Token: 0x06008C13 RID: 35859 RVA: 0x0024DBA3 File Offset: 0x0024BDA3
	public void SkipToTaskView(EMoonChasingTaskType taskType, int taskId)
	{
		ControllerBase<MoonChasingController>.Instance.OpenTaskView(taskType, taskId, false);
	}

	// Token: 0x06008C14 RID: 35860 RVA: 0x0024DBB2 File Offset: 0x0024BDB2
	public void SkipToBuildingView(int buildingId)
	{
		ControllerBase<MoonChasingController>.Instance.OpenBuildingTipsInfoView(buildingId);
	}

	// Token: 0x06008C15 RID: 35861 RVA: 0x0024DBC0 File Offset: 0x0024BDC0
	public void SkipToBuildingPreview()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MoonChasingMainView);
		if (viewByName == null)
		{
			return;
		}
		MoonChasingMainViewModel moonChasingMainViewModel = viewByName.OpenParam as MoonChasingMainViewModel;
		if (moonChasingMainViewModel != null)
		{
			moonChasingMainViewModel.SkipTarget = EMoonChasingSkipDefine.Build;
		}
		Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.MoonChasingMainView, null, true);
	}

	// Token: 0x06008C16 RID: 35862 RVA: 0x0024DC08 File Offset: 0x0024BE08
	public void RefreshInteractivePanel()
	{
		if (this.InInteractive)
		{
			this.View.RefreshInteractivePanel();
		}
	}

	// Token: 0x06008C17 RID: 35863 RVA: 0x0024DC1D File Offset: 0x0024BE1D
	public void BackToLastState()
	{
		if (this.InInteractive)
		{
			this.SkipToHelpPanel();
			return;
		}
		this.View.CloseMe(null);
	}

	// Token: 0x06008C18 RID: 35864 RVA: 0x0024DC3A File Offset: 0x0024BE3A
	public void OpenHelpView()
	{
		if (this.InInteractive)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(106);
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(105);
	}

	// Token: 0x04004144 RID: 16708
	private const int INTERACTIVE_HELPID = 106;

	// Token: 0x04004145 RID: 16709
	private const int HELP_HELPID = 105;

	// Token: 0x04004146 RID: 16710
	private BusinessHelperView View;

	// Token: 0x04004147 RID: 16711
	private bool InInteractive;

	// Token: 0x04004148 RID: 16712
	public int SelectedRoleId;
}
