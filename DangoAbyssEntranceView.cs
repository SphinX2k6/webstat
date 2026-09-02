using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001ADD RID: 6877
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssEntranceView : UiTickViewBase, IUiCameraBehavior
{
	// Token: 0x0600C5D7 RID: 50647 RVA: 0x0034408F File Offset: 0x0034228F
	public DangoAbyssEntranceView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C5D8 RID: 50648 RVA: 0x00344098 File Offset: 0x00342298
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnAbyssInsEntranceBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnWorldEntranceBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C5D9 RID: 50649 RVA: 0x003442B0 File Offset: 0x003424B0
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C5DA RID: 50650 RVA: 0x003442C0 File Offset: 0x003424C0
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssEntranceView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssEntranceView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C5DB RID: 50651 RVA: 0x00344304 File Offset: 0x00342504
	private void OnCloseBtnClick()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		IReadOnlyList<int> smallWorldInsIdList = ConfigBase<DangoAbyssConfig>.Instance.GetSmallWorldInsIdList();
		if (!((smallWorldInsIdList != null) ? new bool?(smallWorldInsIdList.Contains(instanceId)) : null).GetValueOrDefault())
		{
			base.CloseMe(null);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DangoQuitWorld);
		confirmBoxDataNew.FunctionMap.Add(2, new Action(DangoAbyssEntranceView.<OnCloseBtnClick>g__callBack|15_0));
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600C5DC RID: 50652 RVA: 0x00344384 File Offset: 0x00342584
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)"DangoAbyssStart", new int?(viewId), isBlend);
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName("DangoAbyssLoop", true, true, "1001", false, null, null);
	}

	// Token: 0x0600C5DD RID: 50653 RVA: 0x003443CE File Offset: 0x003425CE
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)"DangoAbyssStart", stackTopInfo, closeViewId, popOrDelete);
	}

	// Token: 0x0600C5DE RID: 50654 RVA: 0x003443E8 File Offset: 0x003425E8
	protected override void OnHandleLoadScene()
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("Ani_Tuanzi_Start0");
		this.PlaySceneLevelSequence(resourcePath, false, delegate
		{
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("Ani_Tuanzi_Loop");
			this.PlaySceneLevelSequence(resourcePath2, true, null);
		});
	}

	// Token: 0x0600C5DF RID: 50655 RVA: 0x0034441C File Offset: 0x0034261C
	private void OnWorldEntranceBtnClick()
	{
		if (ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance())
		{
			base.CloseMe(null);
			return;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			base.CloseMe(null);
			return;
		}
		int? teleportId = ConfigBase<DangoAbyssConfig>.Instance.GetWorldTeleportId();
		if (teleportId != null)
		{
			int? teleportId2 = teleportId;
			int num = 0;
			if (!(teleportId2.GetValueOrDefault() == num & teleportId2 != null))
			{
				if (ModelBase<QuestNewModel>.Instance.IsInFocusMode())
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CloseFocusQuestTips);
					confirmBoxDataNew.FunctionMap.Add(2, delegate
					{
						TeleportMisc.SendTeleportTransferRequest(teleportId.Value);
					});
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return;
				}
				TeleportMisc.SendTeleportTransferRequest(teleportId.Value);
				return;
			}
		}
	}

	// Token: 0x0600C5E0 RID: 50656 RVA: 0x003444E0 File Offset: 0x003426E0
	private void OnAbyssInsEntranceBtnClick()
	{
		int activityId = this.CurrentData.ActivityId;
		ControllerBase<DangoAbyssController>.Instance.OpenAbyssSelectViewByActivityId(activityId);
	}

	// Token: 0x0600C5E1 RID: 50657 RVA: 0x00344504 File Offset: 0x00342704
	protected override void OnBeforeShow()
	{
		this.PushCameraHandle((EUiViewName)"DangoAbyssLoop", base.GetViewId(), true);
		DangoAbyssActivityData activityData = this.GetActivityData();
		this.RefreshSceneNiagaraByCurrentChallenge(activityData);
		this.RefreshView();
		this.RefreshRedDot();
		this.RefreshDangaoShowState(activityData);
		this.RefreshBtns();
	}

	// Token: 0x0600C5E2 RID: 50658 RVA: 0x00344550 File Offset: 0x00342750
	private void RefreshBtns()
	{
		bool dangoUpAvailable = ModelBase<DangoAbyssModel>.Instance.GetDangoUpAvailable();
		this.DangoUpItem.SetUiActive(dangoUpAvailable);
		bool shopAvailable = ModelBase<DangoAbyssModel>.Instance.GetShopAvailable();
		this.ShopItem.SetUiActive(shopAvailable);
	}

	// Token: 0x0600C5E3 RID: 50659 RVA: 0x0034458C File Offset: 0x0034278C
	public void RefreshRedDot()
	{
		AbyssButtonItem limitRewadItem = this.LimitRewadItem;
		if (limitRewadItem != null)
		{
			ERedDotName redDotName = ERedDotName.RedDotDangoLimitReward;
			DangoAbyssEntraceViewData currentData = this.CurrentData;
			limitRewadItem.BindRedDot(redDotName, (currentData != null) ? new int?(currentData.ActivityId) : null);
		}
		AbyssButtonItem activityRewardItem = this.ActivityRewardItem;
		if (activityRewardItem != null)
		{
			ERedDotName redDotName2 = ERedDotName.RedDotDangoCommonReward;
			DangoAbyssEntraceViewData currentData2 = this.CurrentData;
			activityRewardItem.BindRedDot(redDotName2, (currentData2 != null) ? new int?(currentData2.ActivityId) : null);
		}
		AbyssButtonItem shopItem = this.ShopItem;
		if (shopItem != null)
		{
			shopItem.BindRedDot(ERedDotName.RedDotDangoPayShop, null);
		}
		AbyssButtonItem dangoUpItem = this.DangoUpItem;
		if (dangoUpItem == null)
		{
			return;
		}
		dangoUpItem.BindRedDot(ERedDotName.RedDotDangoDevelop, null);
	}

	// Token: 0x0600C5E4 RID: 50660 RVA: 0x00344640 File Offset: 0x00342840
	private void UnbindRedDot()
	{
		AbyssButtonItem limitRewadItem = this.LimitRewadItem;
		if (limitRewadItem != null)
		{
			limitRewadItem.UnBindRedDot();
		}
		AbyssButtonItem activityRewardItem = this.ActivityRewardItem;
		if (activityRewardItem != null)
		{
			activityRewardItem.UnBindRedDot();
		}
		AbyssButtonItem shopItem = this.ShopItem;
		if (shopItem != null)
		{
			shopItem.UnBindRedDot();
		}
		AbyssButtonItem dangoUpItem = this.DangoUpItem;
		if (dangoUpItem == null)
		{
			return;
		}
		dangoUpItem.UnBindRedDot();
	}

	// Token: 0x0600C5E5 RID: 50661 RVA: 0x00344690 File Offset: 0x00342890
	private void PlaySceneLevelSequence(string levelSequencePath, bool needLoop, [Nullable(2)] Action finishCallBack = null)
	{
		string[] sceneActors = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssActivityData(this.CurrentData.ActivityId).Value.SceneActor.Split(',', StringSplitOptions.None);
		Action <>9__1;
		Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(levelSequencePath, delegate(ULevelSequence levelSequence, string _)
		{
			if (!ObjectUtils.IsValid(levelSequence))
			{
				return;
			}
			if (this.SequenceActor == null)
			{
				ALevelSequenceActor sequenceActor = Singleton<ActorSystem>.Instance.Spawn(ALevelSequenceActor.StaticClass(), new FTransformDouble(), null) as ALevelSequenceActor;
				this.SequenceActor = sequenceActor;
			}
			this.SequenceActor.SetSequence(levelSequence);
			string[] sceneActors = sceneActors;
			for (int i = 0; i < sceneActors.Length; i++)
			{
				FName value = FNameUtil.GetDynamicFName(sceneActors[i]).Value;
				AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(value, ECollectActorType.UI);
				if (actorWithTag != null)
				{
					ALevelSequenceActor sequenceActor2 = this.SequenceActor;
					if (sequenceActor2 != null)
					{
						sequenceActor2.AddBindingByTag(value, actorWithTag, false, false);
					}
				}
			}
			FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
			fmovieSceneSequencePlaybackSettings.bRestoreState = true;
			fmovieSceneSequencePlaybackSettings.bPauseAtEnd = true;
			this.SequenceActor.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
			this.SequenceActor.SetTickableWhenPaused(true);
			UKuroSequenceRuntimeFunctionLibrary.SetSequenceInUiScene(levelSequence, true);
			this.SequencePlayer = this.SequenceActor.SequencePlayer;
			this.SequenceActor.bOverrideInstanceData = true;
			UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
			FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(ControllerBase<RenderModuleController>.Instance.GetKuroCurrentUiSceneTransform().Value);
			udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin;
			FOnMovieSceneSequencePlayerEvent onFinished = this.SequencePlayer.OnFinished;
			Action callback;
			if ((callback = <>9__1) == null)
			{
				callback = (<>9__1 = delegate()
				{
					Action finishCallBack2 = finishCallBack;
					if (finishCallBack2 == null)
					{
						return;
					}
					finishCallBack2();
				});
			}
			onFinished.Add(callback);
			if (needLoop)
			{
				this.SequencePlayer.PlayLooping(-1);
				return;
			}
			this.SequencePlayer.Play();
		}, 100, this.MemoryTag);
	}

	// Token: 0x0600C5E6 RID: 50662 RVA: 0x0034470B File Offset: 0x0034290B
	protected override void OnBeforeHide()
	{
		this.UnbindRedDot();
	}

	// Token: 0x0600C5E7 RID: 50663 RVA: 0x00344714 File Offset: 0x00342914
	protected override void OnBeforeDestroy()
	{
		ULevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null && sequencePlayer.IsValid())
		{
			ULevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null)
			{
				sequencePlayer2.Stop();
			}
			this.SequencePlayer = null;
		}
		ALevelSequenceActor sequenceActor = this.SequenceActor;
		if (sequenceActor != null && sequenceActor.IsValid())
		{
			ALevelSequenceActor sequenceActor2 = this.SequenceActor;
			if (sequenceActor2 != null)
			{
				sequenceActor2.K2_DestroyActor();
			}
			this.SequenceActor = null;
		}
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem == null)
		{
			return;
		}
		dangoWorldQuestItem.Clear();
	}

	// Token: 0x0600C5E8 RID: 50664 RVA: 0x0034478C File Offset: 0x0034298C
	private void RefreshView()
	{
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem != null)
		{
			dangoWorldQuestItem.Refresh();
		}
		DangoAbyssActivityData activityData = this.GetActivityData();
		this.RefreshCurrentTargetText(activityData);
		this.RefreshWorldProgressText(activityData);
		this.RefreshAbyssInsProgressText(activityData);
		this.RefreshLimitItemShowState(activityData);
		this.RefreshRewardProgressText(activityData);
	}

	// Token: 0x0600C5E9 RID: 50665 RVA: 0x003447D4 File Offset: 0x003429D4
	private void RefreshDangaoShowState(DangoAbyssActivityData data)
	{
		int currentLastFinishChallengeId = data.GetCurrentLastFinishChallengeId();
		if (currentLastFinishChallengeId == 0)
		{
			return;
		}
		string[] array = ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(currentLastFinishChallengeId).Value.AbyssShowCake.Split(',', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(array[i]).Value, ECollectActorType.UI);
			if (actorWithTag != null && actorWithTag.IsValid())
			{
				actorWithTag.SetActorHiddenInGame(false);
			}
		}
	}

	// Token: 0x0600C5EA RID: 50666 RVA: 0x00344851 File Offset: 0x00342A51
	private DangoAbyssActivityData GetActivityData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentData.ActivityId) as DangoAbyssActivityData;
	}

	// Token: 0x0600C5EB RID: 50667 RVA: 0x00344870 File Offset: 0x00342A70
	private void RefreshSceneNiagaraByCurrentChallenge(DangoAbyssActivityData data)
	{
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("shenyuan").Value, ECollectActorType.UI);
		if (actorWithTag != null && actorWithTag.IsValid())
		{
			int firstUnlockChallengeId = data.GetFirstUnlockChallengeId();
			if (firstUnlockChallengeId == 0)
			{
				return;
			}
			FColor fcolor = FColor.FromHex(ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(firstUnlockChallengeId).Value.AbyssColor);
			FLinearColor flinearColor = FLinearColor.FromSRGBColor(fcolor);
			(actorWithTag.GetComponentByClass(UNiagaraComponent.StaticClass()) as UNiagaraComponent).SetNiagaraVariableLinearColor("Color", flinearColor);
		}
	}

	// Token: 0x0600C5EC RID: 50668 RVA: 0x003448FC File Offset: 0x00342AFC
	private void RefreshLimitItemShowState(DangoAbyssActivityData data)
	{
		bool flag = data.CheckInLimitTime();
		base.GetItem(5).SetUIActive(flag);
		if (flag)
		{
			string remainTimeText = data.GetRemainTimeText();
			AbyssButtonItem limitRewadItem = this.LimitRewadItem;
			if (limitRewadItem == null)
			{
				return;
			}
			limitRewadItem.SetNumText(remainTimeText);
		}
	}

	// Token: 0x0600C5ED RID: 50669 RVA: 0x00344938 File Offset: 0x00342B38
	private void RefreshCurrentTargetText(DangoAbyssActivityData data)
	{
	}

	// Token: 0x0600C5EE RID: 50670 RVA: 0x0034493C File Offset: 0x00342B3C
	private void RefreshWorldProgressText(DangoAbyssActivityData data)
	{
		string abyssWorldProgressText = data.GetAbyssWorldProgressText();
		base.GetText(2).SetText(abyssWorldProgressText, true);
	}

	// Token: 0x0600C5EF RID: 50671 RVA: 0x00344960 File Offset: 0x00342B60
	private void RefreshAbyssInsProgressText(DangoAbyssActivityData data)
	{
		string abyssProgressText = data.GetAbyssProgressText();
		base.GetText(4).SetText(abyssProgressText, true);
	}

	// Token: 0x0600C5F0 RID: 50672 RVA: 0x00344984 File Offset: 0x00342B84
	private void RefreshRewardProgressText(DangoAbyssActivityData data)
	{
		string rewardFinishProgressText = data.GetRewardFinishProgressText();
		AbyssButtonItem activityRewardItem = this.ActivityRewardItem;
		if (activityRewardItem == null)
		{
			return;
		}
		activityRewardItem.SetNumText(rewardFinishProgressText);
	}

	// Token: 0x0600C5F1 RID: 50673 RVA: 0x003449A9 File Offset: 0x00342BA9
	private void OnClickDangoUp()
	{
		if (!ModelBase<DangoAbyssModel>.Instance.GetDangoUpAvailable())
		{
			return;
		}
		ControllerBase<DangoAbyssActivityController>.Instance.OpenCurrentRoleUpView();
	}

	// Token: 0x0600C5F2 RID: 50674 RVA: 0x003449C2 File Offset: 0x00342BC2
	private void OnClickShop()
	{
		if (!ModelBase<DangoAbyssModel>.Instance.GetShopAvailable())
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssShopView, null, null);
	}

	// Token: 0x0600C5F3 RID: 50675 RVA: 0x003449E2 File Offset: 0x00342BE2
	protected override void OnTick(float delta)
	{
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem == null)
		{
			return;
		}
		dangoWorldQuestItem.Tick();
	}

	// Token: 0x0600C5F4 RID: 50676 RVA: 0x003449F4 File Offset: 0x00342BF4
	[CompilerGenerated]
	internal static void <OnCloseBtnClick>g__callBack|15_0()
	{
		BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData != null)
		{
			childViewData.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.Mission, true, true, 0);
		}
		BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData2 != null)
		{
			childViewData2.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.Formation, true, true, 0);
		}
		BattleUiChildViewData childViewData3 = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData3 != null)
		{
			childViewData3.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.GamepadFormation, true, true, 0);
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
	}

	// Token: 0x04005ED3 RID: 24275
	[Nullable(2)]
	private DangoAbyssEntraceViewData CurrentData;

	// Token: 0x04005ED4 RID: 24276
	[Nullable(2)]
	private AbyssButtonItem LimitRewadItem;

	// Token: 0x04005ED5 RID: 24277
	[Nullable(2)]
	private AbyssButtonItem ActivityRewardItem;

	// Token: 0x04005ED6 RID: 24278
	[Nullable(2)]
	private AbyssButtonItem DangoUpItem;

	// Token: 0x04005ED7 RID: 24279
	[Nullable(2)]
	private AbyssButtonItem ShopItem;

	// Token: 0x04005ED8 RID: 24280
	[Nullable(2)]
	private ULevelSequencePlayer SequencePlayer;

	// Token: 0x04005ED9 RID: 24281
	[Nullable(2)]
	private ALevelSequenceActor SequenceActor;

	// Token: 0x04005EDA RID: 24282
	[Nullable(2)]
	private DangoWorldQuestItem DangoWorldQuestItem;

	// Token: 0x04005EDB RID: 24283
	private const string STARTCAMERAPOS = "DangoAbyssStart";

	// Token: 0x04005EDC RID: 24284
	private const string ENTRANCELOOP = "DangoAbyssLoop";

	// Token: 0x02007DB0 RID: 32176
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402ACE4 RID: 175332
		CloseBtn,
		// Token: 0x0402ACE5 RID: 175333
		WorldEntranceBtn,
		// Token: 0x0402ACE6 RID: 175334
		WorldProgressText,
		// Token: 0x0402ACE7 RID: 175335
		AbyssInsEntranceBtn,
		// Token: 0x0402ACE8 RID: 175336
		AbyssInsProgressText,
		// Token: 0x0402ACE9 RID: 175337
		LimitRewardItem,
		// Token: 0x0402ACEA RID: 175338
		ActivityRewardItem,
		// Token: 0x0402ACEB RID: 175339
		DangoUpItem,
		// Token: 0x0402ACEC RID: 175340
		ShopItem,
		// Token: 0x0402ACED RID: 175341
		GoalScroller,
		// Token: 0x0402ACEE RID: 175342
		GoalItem
	}
}
