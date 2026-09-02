using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020010AC RID: 4268
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class GolemHackingController : ActivityControllerBase<GolemHackingController>
{
	// Token: 0x06006F4D RID: 28493 RVA: 0x001CF86E File Offset: 0x001CDA6E
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06006F4E RID: 28494 RVA: 0x001CF870 File Offset: 0x001CDA70
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_GolemHackingActivityMain";
	}

	// Token: 0x06006F4F RID: 28495 RVA: 0x001CF877 File Offset: 0x001CDA77
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new GolemHackingActivitySubView();
	}

	// Token: 0x06006F50 RID: 28496 RVA: 0x001CF87E File Offset: 0x001CDA7E
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new GolemHackingActivityData();
	}

	// Token: 0x06006F51 RID: 28497 RVA: 0x001CF891 File Offset: 0x001CDA91
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06006F52 RID: 28498 RVA: 0x001CF894 File Offset: 0x001CDA94
	[NullableContext(2)]
	public GolemHackingActivityData GetActivityData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as GolemHackingActivityData;
	}

	// Token: 0x06006F53 RID: 28499 RVA: 0x001CF8AC File Offset: 0x001CDAAC
	public void OnUiGameplayFinish(int configId)
	{
		GeneralLogicTreeController instance = ControllerBase<GeneralLogicTreeController>.Instance;
		UiGamePlayType type = UiGamePlayType.GolemCrack;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(configId);
		instance.RequestFinishUiGameplay(type, defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x06006F54 RID: 28500 RVA: 0x001CF8DC File Offset: 0x001CDADC
	public int OpenGameplayView(List<int> randomList, Action<bool> closeCb, bool isMainLevel, [Nullable(2)] TOpenViewCallBack openCb = null)
	{
		if (randomList.Count == 0)
		{
			return 0;
		}
		int randomItem = Singleton<MathUtils>.Instance.GetRandomItem<int>(randomList);
		GolemHackingOpenViewInfo param = new GolemHackingOpenViewInfo
		{
			ConfigId = randomItem,
			CloseCb = closeCb,
			IsMainLevel = isMainLevel
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GolemHackingGameView, param, openCb);
		return randomItem;
	}

	// Token: 0x06006F55 RID: 28501 RVA: 0x001CF930 File Offset: 0x001CDB30
	public int OpenGameplayViewByPlot(List<int> randomList, Action<bool> closeCb, bool isMainLevel)
	{
		if (randomList.Count == 0)
		{
			return 0;
		}
		int randomItem = Singleton<MathUtils>.Instance.GetRandomItem<int>(randomList);
		GolemHackingOpenViewInfo param = new GolemHackingOpenViewInfo
		{
			ConfigId = randomItem,
			CloseCb = closeCb,
			IsMainLevel = isMainLevel
		};
		Singleton<UiManager>.Instance.OpenViewByPlot(EUiViewName.GolemHackingGameView, param, null);
		return randomItem;
	}

	// Token: 0x06006F56 RID: 28502 RVA: 0x001CF980 File Offset: 0x001CDB80
	[NullableContext(0)]
	public UniTask<bool> RequestGolemCrackUpdate(int levelId)
	{
		GolemHackingController.<RequestGolemCrackUpdate>d__15 <RequestGolemCrackUpdate>d__;
		<RequestGolemCrackUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestGolemCrackUpdate>d__.<>4__this = this;
		<RequestGolemCrackUpdate>d__.levelId = levelId;
		<RequestGolemCrackUpdate>d__.<>1__state = -1;
		<RequestGolemCrackUpdate>d__.<>t__builder.Start<GolemHackingController.<RequestGolemCrackUpdate>d__15>(ref <RequestGolemCrackUpdate>d__);
		return <RequestGolemCrackUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x06006F57 RID: 28503 RVA: 0x001CF9CC File Offset: 0x001CDBCC
	public void CloseActivityView(IReadOnlySet<int> closeActivities, bool force = false)
	{
		if (closeActivities.Contains(this.ActivityId) || force)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
			confirmBoxDataNew.FunctionMap[1] = new Action(GolemHackingController.<CloseActivityView>g__ConfirmCallback|16_0);
			confirmBoxDataNew.FunctionMap[0] = new Action(GolemHackingController.<CloseActivityView>g__ConfirmCallback|16_0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x06006F59 RID: 28505 RVA: 0x001CFA35 File Offset: 0x001CDC35
	[CompilerGenerated]
	internal static void <CloseActivityView>g__ConfirmCallback|16_0()
	{
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x0400353B RID: 13627
	public int ActivityId;

	// Token: 0x0400353C RID: 13628
	public bool IsActivityOpen;

	// Token: 0x0400353D RID: 13629
	public int ActivityOpenTime;

	// Token: 0x0400353E RID: 13630
	public int CacheLevelId;

	// Token: 0x0400353F RID: 13631
	public bool CacheHardMode;

	// Token: 0x04003540 RID: 13632
	public bool CacheRewardFocus;
}
