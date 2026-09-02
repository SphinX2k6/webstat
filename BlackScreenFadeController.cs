using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020017BC RID: 6076
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BlackScreenFadeController : UiControllerBase<BlackScreenFadeController>
{
	// Token: 0x17000DEC RID: 3564
	// (get) Token: 0x0600AB59 RID: 43865 RVA: 0x002DCAB6 File Offset: 0x002DACB6
	// (set) Token: 0x0600AB5A RID: 43866 RVA: 0x002DCABE File Offset: 0x002DACBE
	public bool NeedGuarantee
	{
		get
		{
			return this.NeedGuaranteeInternal;
		}
		set
		{
			this.NeedGuaranteeInternal = value;
		}
	}

	// Token: 0x0600AB5B RID: 43867 RVA: 0x002DCAC7 File Offset: 0x002DACC7
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UiManagerInit, new Action(this.PreloadBlackFadeScreen));
		Singleton<EventSystem>.Instance.Add<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
	}

	// Token: 0x0600AB5C RID: 43868 RVA: 0x002DCAFE File Offset: 0x002DACFE
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UiManagerInit, new Action(this.PreloadBlackFadeScreen));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
	}

	// Token: 0x0600AB5D RID: 43869 RVA: 0x002DCB35 File Offset: 0x002DAD35
	private void PreloadBlackFadeScreen()
	{
		if (this.BlackScreen != null)
		{
			return;
		}
		this.BlackScreen = new BlackScreenFadeView();
		this.BlackScreen.CreateByResourceIdAsync("UiView_BlackFadeScreen_Prefab", Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.Loading, 0), true);
	}

	// Token: 0x0600AB5E RID: 43870 RVA: 0x002DCB70 File Offset: 0x002DAD70
	private void OnTeamLivingStateChange(bool isMyTeam, ETeamGroupType groupType, ETeamLivingState state, ETeamLivingState oldState)
	{
		if (isMyTeam && groupType == ETeamGroupType.Battle && state == ETeamLivingState.Dead)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseAllBlackScreenLoading();
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "OnAllDead关闭黑幕", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0600AB5F RID: 43871 RVA: 0x002DCBB4 File Offset: 0x002DADB4
	[NullableContext(2)]
	public bool CheckCanOpen(EUiViewName viewName, object param)
	{
		UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
		return uiViewInfo != null && (uiViewInfo.Type != ELayerType.Normal || !this.NotEnableViews.Contains(viewName));
	}

	// Token: 0x0600AB60 RID: 43872 RVA: 0x002DCBEC File Offset: 0x002DADEC
	public void AddFadeBlackScreen(float num, bool needBackToFight, bool needCheckOpenView, int? treeId, string tag)
	{
		ModelBase<LevelLoadingModel>.Instance.CameraFadeShowPromise = new CustomPromise();
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (ModelBase<SceneTeamModel>.Instance.GetGroupLivingState(playerId, ETeamGroupType.Battle) == ETeamLivingState.Dead)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseAllBlackScreenLoading();
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "因复活界面打开,黑幕关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (treeId != null && ModelBase<LevelPlayModel>.Instance.GetProcessingLevelPlayInfo(treeId.Value) == null)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseAllBlackScreenLoading();
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.BlackScreen;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "此玩法已经被销毁，不执行进入黑幕：";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", treeId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.NeedInputDis = true;
		ModelBase<InputDistributeModel>.Instance.RefreshInputDistributeTag();
		Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("BlackScreen");
		if (needBackToFight)
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}
		if (needCheckOpenView)
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "黑幕期间禁止打开部分界面");
		}
		this.SetIsFadeIn(true);
		this.SetFadeTime(num);
		this.BlackScreen.ShowItem();
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.BlackScreen;
		ELogAuthor author2 = ELogAuthor.JYS;
		string message2 = "开始显示黑幕";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("标签", tag);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x0600AB61 RID: 43873 RVA: 0x002DCD38 File Offset: 0x002DAF38
	public void RemoveFadeBlackScreen(float num, string tag)
	{
		if (this.BlackScreen == null)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.BlackScreen;
		ELogAuthor author = ELogAuthor.JYS;
		string message = "触发结束黑屏";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		BlackScreenController instance2 = ControllerBase<BlackScreenController>.Instance;
		EFadeInScreenShowType? screenColorType = this.GetScreenColorType();
		EFadeInScreenShowType efadeInScreenShowType = EFadeInScreenShowType.White;
		instance2.ConsumePendingBlackScreen((screenColorType.GetValueOrDefault() == efadeInScreenShowType & screenColorType != null) ? "White" : "Black");
		this.SetIsFadeIn(false);
		this.SetFadeTime(num);
		this.BlackScreen.HideItem();
	}

	// Token: 0x0600AB62 RID: 43874 RVA: 0x002DCDC4 File Offset: 0x002DAFC4
	protected override bool OnClear()
	{
		if (this.BlackScreen != null)
		{
			this.BlackScreen.Destroy(null);
			this.BlackScreen = null;
		}
		return true;
	}

	// Token: 0x0600AB63 RID: 43875 RVA: 0x002DCDE2 File Offset: 0x002DAFE2
	public void ChangeColor(EFadeInScreenShowType screenType)
	{
		if (this.BlackScreen != null)
		{
			this.BlackScreen.UpdateScreenColor(screenType);
		}
	}

	// Token: 0x0600AB64 RID: 43876 RVA: 0x002DCDF8 File Offset: 0x002DAFF8
	public void ChangeColorByForce(EFadeInScreenShowType screenType)
	{
		if (this.BlackScreen != null)
		{
			this.BlackScreen.UpdateScreenColorAndChangeVisible(screenType);
		}
	}

	// Token: 0x0600AB65 RID: 43877 RVA: 0x002DCE0E File Offset: 0x002DB00E
	public bool ChangeAspect(float aspectRatio, bool? bInstantly = null)
	{
		return this.BlackScreen != null && this.BlackScreen.ChangeAspect(aspectRatio, bInstantly);
	}

	// Token: 0x0600AB66 RID: 43878 RVA: 0x002DCE27 File Offset: 0x002DB027
	private void SetFadeTime(float num)
	{
		if (this.BlackScreen != null)
		{
			this.BlackScreen.SetFadeTime(num);
		}
	}

	// Token: 0x0600AB67 RID: 43879 RVA: 0x002DCE3D File Offset: 0x002DB03D
	private void SetIsFadeIn(bool value)
	{
		if (this.BlackScreen != null)
		{
			this.BlackScreen.SetIsFadeIn(value);
		}
	}

	// Token: 0x0600AB68 RID: 43880 RVA: 0x002DCE53 File Offset: 0x002DB053
	public bool GetIsFadeIn()
	{
		BlackScreenFadeView blackScreen = this.BlackScreen;
		return blackScreen != null && blackScreen.GetActive();
	}

	// Token: 0x0600AB69 RID: 43881 RVA: 0x002DCE68 File Offset: 0x002DB068
	public bool CheckIfInCommon()
	{
		List<ELoadingReason> reasonsByPerform = ModelBase<LevelLoadingModel>.Instance.GetReasonsByPerform(ELoadingPerform.CameraFade);
		return reasonsByPerform.Contains(ELoadingReason.Common) && reasonsByPerform.Count == 1;
	}

	// Token: 0x0600AB6A RID: 43882 RVA: 0x002DCE98 File Offset: 0x002DB098
	public int GetHierarchyIndex()
	{
		BlackScreenFadeView blackScreen = this.BlackScreen;
		int? num;
		if (blackScreen == null)
		{
			num = null;
		}
		else
		{
			UUIItem rootItem = blackScreen.GetRootItem();
			num = ((rootItem != null) ? new int?(rootItem.GetHierarchyIndex()) : null);
		}
		int? num2 = num;
		return num2.GetValueOrDefault();
	}

	// Token: 0x0600AB6B RID: 43883 RVA: 0x002DCEE0 File Offset: 0x002DB0E0
	public EFadeInScreenShowType? GetScreenColorType()
	{
		BlackScreenFadeView blackScreen = this.BlackScreen;
		if (blackScreen == null)
		{
			return null;
		}
		return blackScreen.GetScreenColorType();
	}

	// Token: 0x04005186 RID: 20870
	[Nullable(2)]
	private BlackScreenFadeView BlackScreen;

	// Token: 0x04005187 RID: 20871
	public bool NeedInputDis;

	// Token: 0x04005188 RID: 20872
	private readonly HashSet<EUiViewName> NotEnableViews = new HashSet<EUiViewName>
	{
		EUiViewName.GuideTutorialView,
		EUiViewName.GuideTutorialPopView
	};

	// Token: 0x04005189 RID: 20873
	private bool NeedGuaranteeInternal = true;
}
