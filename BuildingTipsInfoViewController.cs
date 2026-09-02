using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020013AF RID: 5039
[NullableContext(1)]
[Nullable(0)]
public class BuildingTipsInfoViewController
{
	// Token: 0x06008AE9 RID: 35561 RVA: 0x00249ADC File Offset: 0x00247CDC
	private void SwitchBuildingId(bool isPrev)
	{
		int buildingDataSize = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataSize();
		if (isPrev)
		{
			this.Model.BuildingId = ((this.Model.BuildingId - 1 > 0) ? (this.Model.BuildingId - 1) : buildingDataSize);
			return;
		}
		this.Model.BuildingId = ((this.Model.BuildingId + 1 <= buildingDataSize) ? (this.Model.BuildingId + 1) : 1);
	}

	// Token: 0x06008AEA RID: 35562 RVA: 0x00249B4E File Offset: 0x00247D4E
	public void RegisterView(BuildingTipsInfoView view)
	{
		this.View = view;
		this.Model = (BuildingTipsInfoViewModel)view.OpenParam;
	}

	// Token: 0x06008AEB RID: 35563 RVA: 0x00249B68 File Offset: 0x00247D68
	public UniTask Refresh()
	{
		BuildingTipsInfoViewController.<Refresh>d__4 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<BuildingTipsInfoViewController.<Refresh>d__4>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x06008AEC RID: 35564 RVA: 0x00249BAC File Offset: 0x00247DAC
	public void SwitchPrev()
	{
		this.SwitchBuildingId(true);
		this.View.UiViewSequence.StopPrevSequence(false, true);
		this.View.UiViewSequence.PlaySequence("Switch", false, null);
		this.Refresh().Forget();
	}

	// Token: 0x06008AED RID: 35565 RVA: 0x00249BFC File Offset: 0x00247DFC
	public void SwitchNext()
	{
		this.SwitchBuildingId(false);
		this.View.UiViewSequence.StopPrevSequence(false, true);
		this.View.UiViewSequence.PlaySequence("Switch", false, null);
		this.Refresh().Forget();
	}

	// Token: 0x06008AEE RID: 35566 RVA: 0x00249C4C File Offset: 0x00247E4C
	public void JumpToMap()
	{
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.Model.BuildingId);
		if (buildingById.MapMarkId > 0)
		{
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(buildingById.MapMarkId),
				MarkType = EMarkType.None
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		}
	}

	// Token: 0x06008AEF RID: 35567 RVA: 0x00249CA8 File Offset: 0x00247EA8
	public void JumpToConditionTip()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingBuildingJumpToTask);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(this.Model.BuildingId);
			ControllerBase<MoonChasingController>.Instance.OpenTaskView((EMoonChasingTaskType)buildingById.JumpType, buildingById.JumpParam, false);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06008AF0 RID: 35568 RVA: 0x00249CE4 File Offset: 0x00247EE4
	public void CloseSelf()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MoonChasingMainView);
		MoonChasingMainViewModel moonChasingMainViewModel = ((viewByName != null) ? viewByName.OpenParam : null) as MoonChasingMainViewModel;
		if (moonChasingMainViewModel != null)
		{
			moonChasingMainViewModel.RefreshBuildingId = this.Model.BuildingId;
		}
		this.View.CloseMe(null);
	}

	// Token: 0x06008AF1 RID: 35569 RVA: 0x00249D34 File Offset: 0x00247F34
	public void UnlockOrLevelUp(int _)
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(this.Model.BuildingId);
		if (!buildingDataById.IsCanLevelUp)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingBuildingNotEnough);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<MoonChasingController>.Instance.OpenBusinessMainView();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (!buildingDataById.IsBuild)
		{
			this.View.UiViewSequence.HideSequenceName = "HideView01";
			ControllerBase<MoonChasingController>.Instance.BuildingUnLockRequest(this.Model.BuildingId);
			return;
		}
		this.View.UiViewSequence.HideSequenceName = "HideView02";
		ControllerBase<MoonChasingController>.Instance.BuildingLevelUpRequest(this.Model.BuildingId);
	}

	// Token: 0x040040F8 RID: 16632
	private BuildingTipsInfoView View;

	// Token: 0x040040F9 RID: 16633
	private BuildingTipsInfoViewModel Model;
}
