using System;
using System.Runtime.CompilerServices;

// Token: 0x0200140A RID: 5130
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingViewController
{
	// Token: 0x06008E20 RID: 36384 RVA: 0x00255848 File Offset: 0x00253A48
	public void RegisterView(MoonChasingMainView view)
	{
		this.View = view;
		this.Model = (MoonChasingMainViewModel)view.OpenParam;
	}

	// Token: 0x06008E21 RID: 36385 RVA: 0x00255864 File Offset: 0x00253A64
	private void Skip()
	{
		if (this.Model.SkipTarget == EMoonChasingSkipDefine.Build)
		{
			this.SkipToBuild();
		}
		else if (this.Model.SkipTarget == EMoonChasingSkipDefine.Business)
		{
			this.SkipToBusiness();
		}
		else if (this.Model.SkipTarget == EMoonChasingSkipDefine.Task)
		{
			this.SkipToTask(this.Model.TaskType, this.Model.IsLastTask);
		}
		this.Model.SkipTarget = EMoonChasingSkipDefine.None;
	}

	// Token: 0x06008E22 RID: 36386 RVA: 0x002558D3 File Offset: 0x00253AD3
	private void RefreshMapModule()
	{
		if (this.Model.RefreshBuildingId > 0)
		{
			this.View.RefreshMainModule(this.Model.RefreshBuildingId);
			this.Model.RefreshBuildingId = 0;
		}
	}

	// Token: 0x06008E23 RID: 36387 RVA: 0x00255905 File Offset: 0x00253B05
	public void Show()
	{
		this.Skip();
		this.RefreshMapModule();
		this.RefreshShowAnimation();
		this.View.RefreshBuildingModule();
		this.View.RefreshRedDot();
	}

	// Token: 0x06008E24 RID: 36388 RVA: 0x0025592F File Offset: 0x00253B2F
	public void SkipToBusinessByParam(int _)
	{
		this.SkipToBusiness();
	}

	// Token: 0x06008E25 RID: 36389 RVA: 0x00255937 File Offset: 0x00253B37
	public void SkipToBusiness()
	{
		ModelBase<MoonChasingModel>.Instance.RemoveDelegationRedDot();
		ControllerBase<MoonChasingController>.Instance.OpenBusinessMainView();
	}

	// Token: 0x06008E26 RID: 36390 RVA: 0x0025594D File Offset: 0x00253B4D
	public void SkipToReward(int _)
	{
		ControllerBase<MoonChasingController>.Instance.OpenRewardView(true);
	}

	// Token: 0x06008E27 RID: 36391 RVA: 0x0025595A File Offset: 0x00253B5A
	public void SkipToBuildByParam(int _)
	{
		this.SkipToBuild();
	}

	// Token: 0x06008E28 RID: 36392 RVA: 0x00255962 File Offset: 0x00253B62
	public void SkipToBuild()
	{
		this.Model.IsInBuildingModule = true;
		this.View.SkipToBuild();
	}

	// Token: 0x06008E29 RID: 36393 RVA: 0x0025597B File Offset: 0x00253B7B
	public void SkipToTask(EMoonChasingTaskType taskType = EMoonChasingTaskType.MainLine, bool isLastTask = false)
	{
		ControllerBase<MoonChasingController>.Instance.OpenTaskView(taskType, 0, isLastTask);
	}

	// Token: 0x06008E2A RID: 36394 RVA: 0x0025598A File Offset: 0x00253B8A
	public void SkipToHandbook(int _)
	{
		ControllerBase<MoonChasingController>.Instance.OpenHandbookView();
	}

	// Token: 0x06008E2B RID: 36395 RVA: 0x00255996 File Offset: 0x00253B96
	public void CloseSelf()
	{
		if (this.Model.IsInBuildingModule)
		{
			this.BuildingBackToMainView();
			return;
		}
		this.View.CloseMe(null);
	}

	// Token: 0x06008E2C RID: 36396 RVA: 0x002559B8 File Offset: 0x00253BB8
	public void OpenHelpView()
	{
		if (this.Model.IsInBuildingModule)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(102);
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(107);
	}

	// Token: 0x06008E2D RID: 36397 RVA: 0x002559E0 File Offset: 0x00253BE0
	public void BuildingBackToMainView()
	{
		this.View.RefreshRedDot();
		this.Model.IsInBuildingModule = false;
		this.View.BuildingBackToMainView();
		if (this.Model.BuildingBackToBusiness)
		{
			this.Model.BuildingBackToBusiness = false;
			this.SkipToBusiness();
		}
	}

	// Token: 0x06008E2E RID: 36398 RVA: 0x00255A30 File Offset: 0x00253C30
	private void RefreshShowAnimation()
	{
		if (ModelBase<MoonChasingModel>.Instance.HasEnteredMainViewFlag)
		{
			this.View.UiViewSequence.StartSequenceName = "Start";
			return;
		}
		this.View.UiViewSequence.StartSequenceName = "Start01";
		ModelBase<MoonChasingModel>.Instance.HasEnteredMainViewFlag = true;
	}

	// Token: 0x04004248 RID: 16968
	private MoonChasingMainView View;

	// Token: 0x04004249 RID: 16969
	private MoonChasingMainViewModel Model;
}
