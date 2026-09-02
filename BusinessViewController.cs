using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020013B6 RID: 5046
[NullableContext(1)]
[Nullable(0)]
public class BusinessViewController
{
	// Token: 0x06008B3A RID: 35642 RVA: 0x0024ADA8 File Offset: 0x00248FA8
	private void InitViewStateManager()
	{
		this.ViewStateManager.RegisterViewState(EBusinessSkipDefine.MainView, null, new Action(this.View.SkipToMainView));
		this.ViewStateManager.RegisterViewState(EBusinessSkipDefine.DelegationDetails, null, new Action<object[]>(this.View.SkipToDelegationDetails));
	}

	// Token: 0x06008B3B RID: 35643 RVA: 0x0024ADE6 File Offset: 0x00248FE6
	public void RegisterView(BusinessMainView view)
	{
		this.View = view;
		this.Model = (MoonChasingBusinessViewModel)view.OpenParam;
		this.InitViewStateManager();
	}

	// Token: 0x06008B3C RID: 35644 RVA: 0x0024AE08 File Offset: 0x00249008
	public UniTask BeforeShowAsync()
	{
		BusinessViewController.<BeforeShowAsync>d__7 <BeforeShowAsync>d__;
		<BeforeShowAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeforeShowAsync>d__.<>4__this = this;
		<BeforeShowAsync>d__.<>1__state = -1;
		<BeforeShowAsync>d__.<>t__builder.Start<BusinessViewController.<BeforeShowAsync>d__7>(ref <BeforeShowAsync>d__);
		return <BeforeShowAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B3D RID: 35645 RVA: 0x0024AE4C File Offset: 0x0024904C
	public void Show()
	{
		if (this.Model.SkipTarget != EBusinessSkipDefine.MainView)
		{
			this.ViewStateManager.SwitchToState(this.Model.SkipTarget, Array.Empty<object>());
		}
		else
		{
			this.View.Refresh();
		}
		bool inMainView = this.ViewStateManager.CurrentState == EBusinessSkipDefine.MainView;
		this.View.SwitchShowViewSequence(inMainView);
	}

	// Token: 0x06008B3E RID: 35646 RVA: 0x0024AEA9 File Offset: 0x002490A9
	public void SwitchToState(EBusinessSkipDefine state, params object[] params_)
	{
		this.ViewStateManager.SwitchToState(state, params_);
	}

	// Token: 0x06008B3F RID: 35647 RVA: 0x0024AEB8 File Offset: 0x002490B8
	public void BackToState(EBusinessSkipDefine state)
	{
		this.ViewStateManager.BackToState(state);
	}

	// Token: 0x06008B40 RID: 35648 RVA: 0x0024AEC8 File Offset: 0x002490C8
	public void SkipToBuild()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MoonChasingMainView);
		MoonChasingMainViewModel moonChasingMainViewModel = ((viewByName != null) ? viewByName.OpenParam : null) as MoonChasingMainViewModel;
		if (moonChasingMainViewModel != null)
		{
			moonChasingMainViewModel.SkipTarget = EMoonChasingSkipDefine.Build;
			moonChasingMainViewModel.BuildingBackToBusiness = true;
		}
		Singleton<UiManager>.Instance.NormalResetToView(EUiViewName.MoonChasingMainView, null, true);
	}

	// Token: 0x06008B41 RID: 35649 RVA: 0x0024AF18 File Offset: 0x00249118
	public void SkipToHelper()
	{
		ControllerBase<MoonChasingController>.Instance.OpenHelperView();
	}

	// Token: 0x06008B42 RID: 35650 RVA: 0x0024AF24 File Offset: 0x00249124
	public void JumpByConfigCondition(int id)
	{
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(id);
		if (delegationConfig.JumpType == 1)
		{
			this.JumpToMainTask(delegationConfig.JumpParam);
			return;
		}
		if (delegationConfig.JumpType == 2)
		{
			this.JumpToBranchTask(delegationConfig.JumpParam);
			return;
		}
		if (delegationConfig.JumpType == 3)
		{
			this.JumpToBuilding(delegationConfig.JumpParam);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Moonfiesta_EntrustLock", Array.Empty<object>());
	}

	// Token: 0x06008B43 RID: 35651 RVA: 0x0024AF9C File Offset: 0x0024919C
	private void JumpToMainTask(int mainTaskId)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingBusinessJumpToTask);
		MainLine? mainLineTaskById = ConfigBase<TaskConfig>.Instance.GetMainLineTaskById(mainTaskId);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ModelBase<QuestNewModel>.Instance.GetQuestConfig(mainLineTaskById.Value.TaskId).TidName, null);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			localTextNew
		});
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<MoonChasingController>.Instance.OpenTaskView(EMoonChasingTaskType.MainLine, mainTaskId, false);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06008B44 RID: 35652 RVA: 0x0024B02C File Offset: 0x0024922C
	private void JumpToBranchTask(int branchTaskId)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingBusinessJumpToTask);
		BranchLine? branchLineTaskById = ConfigBase<TaskConfig>.Instance.GetBranchLineTaskById(branchTaskId);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ModelBase<QuestNewModel>.Instance.GetQuestConfig(branchLineTaskById.Value.TaskId).TidName, null);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			localTextNew
		});
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<MoonChasingController>.Instance.OpenTaskView(EMoonChasingTaskType.BranchLine, branchTaskId, false);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06008B45 RID: 35653 RVA: 0x0024B0BC File Offset: 0x002492BC
	private void JumpToBuilding(int buildingId)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingBusinessJumpToBuilding);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId).Name, null);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			localTextNew
		});
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<MoonChasingController>.Instance.OpenBuildingTipsInfoView(buildingId);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06008B46 RID: 35654 RVA: 0x0024B134 File Offset: 0x00249334
	public void JumpEnergyNotEnough()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingBusinessEnergyNotEnough);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<MoonChasingController>.Instance.OpenTaskView(EMoonChasingTaskType.BranchLine, 0, false);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06008B47 RID: 35655 RVA: 0x0024B184 File Offset: 0x00249384
	public void JumpMoneyNotEnough()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingBusinessMoneyNotEnough);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06008B48 RID: 35656 RVA: 0x0024B1A8 File Offset: 0x002493A8
	public void BackToLastState()
	{
		if (this.ViewStateManager.CurrentState == EBusinessSkipDefine.MainView)
		{
			this.View.CloseMe(null);
			return;
		}
		this.ViewStateManager.BackToLastState();
	}

	// Token: 0x06008B49 RID: 35657 RVA: 0x0024B1CF File Offset: 0x002493CF
	public void OpenHelpView()
	{
		if (this.ViewStateManager.CurrentState == EBusinessSkipDefine.DelegationDetails)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(104);
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(103);
	}

	// Token: 0x0400410D RID: 16653
	private const int MAINVIEW_HELPID = 103;

	// Token: 0x0400410E RID: 16654
	private const int DELEGATE_HELPID = 104;

	// Token: 0x0400410F RID: 16655
	private BusinessMainView View;

	// Token: 0x04004110 RID: 16656
	private MoonChasingBusinessViewModel Model;

	// Token: 0x04004111 RID: 16657
	private readonly ViewStateManager ViewStateManager = new ViewStateManager();
}
