using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Kpose.Blueprint;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020017F1 RID: 6129
[NullableContext(2)]
[Nullable(0)]
public class CalabashCollectTabView : UiTabViewBase
{
	// Token: 0x0600AE2D RID: 44589 RVA: 0x002E5024 File Offset: 0x002E3224
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnBackButtonClick))
		};
	}

	// Token: 0x0600AE2E RID: 44590 RVA: 0x002E5154 File Offset: 0x002E3354
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ChangeCalabashCollectSimplyState, new Action(this.OnSimplyStateChange));
	}

	// Token: 0x0600AE2F RID: 44591 RVA: 0x002E5172 File Offset: 0x002E3372
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeCalabashCollectSimplyState, new Action(this.OnSimplyStateChange));
	}

	// Token: 0x0600AE30 RID: 44592 RVA: 0x002E5190 File Offset: 0x002E3390
	private void OnSimplyStateChange()
	{
		if (ModelBase<CalabashModel>.Instance.GetIfSimpleState())
		{
			this.DetailItem.PlayDetailShowSequence();
			return;
		}
		this.DetailItem.PlayDetailHideSequence();
	}

	// Token: 0x0600AE31 RID: 44593 RVA: 0x002E51B5 File Offset: 0x002E33B5
	private void OnBackButtonClick()
	{
		if (this.IsOnlyShow)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CalabashRootView, null);
			return;
		}
		this.QuitInternalView();
	}

	// Token: 0x0600AE32 RID: 44594 RVA: 0x002E51D8 File Offset: 0x002E33D8
	protected override UniTask OnBeforeStartAsync()
	{
		CalabashCollectTabView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CalabashCollectTabView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AE33 RID: 44595 RVA: 0x002E521B File Offset: 0x002E341B
	protected override void OnStart()
	{
		if (this.IsOnlyShow)
		{
			this.StopPlayingUiTabSequence();
		}
	}

	// Token: 0x0600AE34 RID: 44596 RVA: 0x002E522C File Offset: 0x002E342C
	protected override void OnBeforeShow()
	{
		this.FilterEntrance.UpdateData(EFilterSortGroupId.CalabashCollect, ModelBase<CalabashModel>.Instance.GetCalabashDevelopRewardSortData().ToList<CalabashDevelopRewardData>(), Array.Empty<object>());
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(EFilterSortGroupId.CalabashCollect);
		this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId);
		this.SortEntrance.UpdateData(EFilterSortGroupId.CalabashCollect, ModelBase<CalabashModel>.Instance.GetCalabashDevelopRewardSortData().ToList<CalabashDevelopRewardData>(), Array.Empty<object>());
		int uniqueIdByGroupId2 = this.SortEntrance.GetUniqueIdByGroupId(EFilterSortGroupId.CalabashCollect);
		this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId2);
		this.DetailItem.RefreshDetailState();
		base.GetButton(9).RootUIComp.Get().SetUIActive(this.IsInternal);
	}

	// Token: 0x0600AE35 RID: 44597 RVA: 0x002E52DA File Offset: 0x002E34DA
	protected override void OnBeforeHide()
	{
		this.WaitToSelectMonsterId = this.CurrentSelectedMonsterId;
		this.LoadingItem.SetLoadingActive(false);
		this.CancelSelect();
	}

	// Token: 0x0600AE36 RID: 44598 RVA: 0x002E52FA File Offset: 0x002E34FA
	protected override void OnBeforeDestroy()
	{
		this.DestroyVision();
		this.LoadingItem.Destroy(null);
	}

	// Token: 0x0600AE37 RID: 44599 RVA: 0x002E530E File Offset: 0x002E350E
	[NullableContext(1)]
	private CalabashCollectGridItem CreateProxy()
	{
		return new CalabashCollectGridItem
		{
			OnToggleClick = new Action<int>(this.OnToggleClick),
			CanToggleChange = new Func<int, bool>(this.CanToggleChange)
		};
	}

	// Token: 0x0600AE38 RID: 44600 RVA: 0x002E5339 File Offset: 0x002E3539
	private void OnToggleClick(int gridIndex)
	{
		this.LoopScroll.SelectGridProxy(gridIndex, false);
		this.OnPhantomSelectChange();
	}

	// Token: 0x0600AE39 RID: 44601 RVA: 0x002E534E File Offset: 0x002E354E
	private bool CanToggleChange(int gridIndex)
	{
		LoopScrollView<CalabashCollectGridItem, CalabashDevelopRewardData> loopScroll = this.LoopScroll;
		return loopScroll == null || loopScroll.GetSelectedGridIndex() != gridIndex;
	}

	// Token: 0x0600AE3A RID: 44602 RVA: 0x002E5368 File Offset: 0x002E3568
	[NullableContext(1)]
	private void UpdateDataList(List<CalabashDevelopRewardData> list, bool isOutSideChange, EFilterSortType operationType)
	{
		this.DataList = list.ToArray();
		this.LoopScroll.RefreshByData(this.DataList.ToList<CalabashDevelopRewardData>(), false, new Action(this.AfterLoopScrollRefresh), true);
		if (this.DataList.Length == 0)
		{
			return;
		}
		if (operationType == EFilterSortType.Sort)
		{
			this.CurrentSelectedMonsterId = this.DataList[0].DevelopRewardData.MonsterId;
		}
	}

	// Token: 0x0600AE3B RID: 44603 RVA: 0x002E53D0 File Offset: 0x002E35D0
	private void AfterLoopScrollRefresh()
	{
		int toSelectId = 0;
		if (this.WaitToSelectMonsterId > 0)
		{
			toSelectId = this.WaitToSelectMonsterId;
			this.WaitToSelectMonsterId = 0;
		}
		else if (this.CurrentSelectedMonsterId > 0)
		{
			toSelectId = this.CurrentSelectedMonsterId;
		}
		int num = 0;
		if (toSelectId > 0 && this.DataList != null)
		{
			num = Array.FindIndex<CalabashDevelopRewardData>(this.DataList, (CalabashDevelopRewardData data) => data.DevelopRewardData.MonsterId == toSelectId);
			if (num < 0)
			{
				int? parentMonsterId = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinMonsterIdMapByMonsterId(toSelectId);
				if (parentMonsterId != null)
				{
					num = Array.FindIndex<CalabashDevelopRewardData>(this.DataList, (CalabashDevelopRewardData data) => data.DevelopRewardData.MonsterId == parentMonsterId.Value);
				}
			}
		}
		num = Math.Max(0, num);
		this.LoopScroll.SelectGridProxy(num, false);
		this.LoopScroll.ScrollToGridIndex(num, true);
		this.OnPhantomSelectChange();
	}

	// Token: 0x0600AE3C RID: 44604 RVA: 0x002E54B8 File Offset: 0x002E36B8
	private void OnPhantomSelectChange()
	{
		int selectedGridIndex = this.LoopScroll.GetSelectedGridIndex();
		CalabashDevelopRewardData calabashDevelopRewardData = this.DataList[selectedGridIndex];
		this.DetailItem.Update(calabashDevelopRewardData);
		this.CurrentSelectedMonsterId = calabashDevelopRewardData.DevelopRewardData.MonsterId;
		this.DestroyVision();
		if (this.IsOnlyShow)
		{
			this.CurrentSelectedMonsterId = this.ShowMonsterId;
			this.SetEmptyState(true, false);
			this.LoadVision();
			this.StopPlayingUiTabSequence();
			this.EnterInternalView(true);
			ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "CalabashCollectOnlyShow");
			return;
		}
		this.SetEmptyState(false, !calabashDevelopRewardData.UnlockData);
		if (calabashDevelopRewardData.UnlockData)
		{
			this.LoadVision();
		}
	}

	// Token: 0x0600AE3D RID: 44605 RVA: 0x002E5562 File Offset: 0x002E3762
	private void EnterInternalView()
	{
		this.EnterInternalView(false);
	}

	// Token: 0x0600AE3E RID: 44606 RVA: 0x002E556C File Offset: 0x002E376C
	private void EnterInternalView(bool skipUiAnim)
	{
		if (this.IsInternal)
		{
			Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.LZK, "重复进入声骸图鉴的内部界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.IsInternal = true;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Enter", true, null, skipUiAnim);
		}
		UiCamera uiCamera = UiCameraManager.Get();
		UiCameraControlRotationComponent rotationComponent = uiCamera.GetUiCameraComponent<UiCameraControlRotationComponent>();
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.CurrentSelectedMonsterId);
		MonsterBodyTypeConfig? bodyTypeConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterBodyTypeConfig(calabashDevelopRewardByMonsterId.Value.MonsterBodyType);
		Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(bodyTypeConfig.Value.MoveForwardCurvePath, delegate([Nullable(2)] UCurveFloat curve, string _)
		{
			if (curve != null)
			{
				rotationComponent.DoMoveForward((float)bodyTypeConfig.Value.MoveForwardDistance, (float)bodyTypeConfig.Value.MoveForwardDuration, curve);
			}
		}, 100, this.MemoryTag);
		this.VisionCameraInputItem.CanPitchInput = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.CalabashEnterInternalView);
	}

	// Token: 0x0600AE3F RID: 44607 RVA: 0x002E5662 File Offset: 0x002E3862
	private void StopPlayingUiTabSequence()
	{
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.StopPlayingSequence(false, true);
	}

	// Token: 0x0600AE40 RID: 44608 RVA: 0x002E5682 File Offset: 0x002E3882
	private void ChangeMonsterSkin(int monsterSkinId, bool isLock)
	{
		this.DetailItem.UpdateSkinInfo(monsterSkinId);
		this.CurrentSelectedMonsterId = monsterSkinId;
		this.DestroyVision();
		this.SetEmptyState(true, isLock);
		if (!isLock)
		{
			this.LoadVision();
		}
	}

	// Token: 0x0600AE41 RID: 44609 RVA: 0x002E56B0 File Offset: 0x002E38B0
	private void QuitInternalView()
	{
		if (!this.IsInternal)
		{
			Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.LZK, "重复退出声骸图鉴的内部界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.IsInternal = false;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Back", true, null, false);
		}
		UiCamera uiCamera = UiCameraManager.Get();
		UiCameraControlRotationComponent rotationComponent = uiCamera.GetUiCameraComponent<UiCameraControlRotationComponent>();
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.CurrentSelectedMonsterId);
		MonsterBodyTypeConfig? bodyTypeConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterBodyTypeConfig(calabashDevelopRewardByMonsterId.Value.MonsterBodyType);
		Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(bodyTypeConfig.Value.MoveForwardCurvePath, delegate([Nullable(2)] UCurveFloat curve, string _)
		{
			if (curve != null)
			{
				BP_KposeBase_C handBookVision = Singleton<UiSceneManager>.Instance.GetHandBookVision();
				if (handBookVision != null && handBookVision.IsValid())
				{
					rotationComponent.SetArmLength((float)handBookVision.CameraArmLength);
					rotationComponent.SetArmRotationByDefaultCamera();
					rotationComponent.StartFade((float)bodyTypeConfig.Value.MoveForwardDuration, curve, true, true, true, true);
				}
			}
		}, 100, this.MemoryTag);
		this.VisionCameraInputItem.CanPitchInput = false;
		Singleton<EventSystem>.Instance.Emit(EEventName.CalabashQuitInternalView);
	}

	// Token: 0x0600AE42 RID: 44610 RVA: 0x002E57A8 File Offset: 0x002E39A8
	private void LoadVision()
	{
		if (this.BpHandle != -1 || Singleton<UiSceneManager>.Instance.GetHandBookVision() != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.LZK, "声骸模型重复加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.LoadingItem.SetLoadingActive(true);
		int monsterId = this.CurrentSelectedMonsterId;
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(monsterId);
		this.BpHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(calabashDevelopRewardByMonsterId.Value.HandBookBp + "_C", delegate([Nullable(2)] UClass csClass, string _)
		{
			this.SetVisionInfo(monsterId, csClass);
		}, 100, this.MemoryTag);
	}

	// Token: 0x0600AE43 RID: 44611 RVA: 0x002E5860 File Offset: 0x002E3A60
	[NullableContext(1)]
	private void SetVisionInfo(int monsterId, UClass csClass)
	{
		Singleton<UiSceneManager>.Instance.CreateHandBookVision(csClass);
		BP_KposeBase_C handBookVision = Singleton<UiSceneManager>.Instance.GetHandBookVision();
		handBookVision.SetActorHiddenInGame(true);
		TArray<USkeletalMesh> tarray = new TArray<USkeletalMesh>();
		TArray<UStaticMesh> tarray2 = new TArray<UStaticMesh>();
		TArray<UActorComponent> tarray3 = handBookVision.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		TArray<UActorComponent> tarray4 = handBookVision.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
		if (tarray3 != null)
		{
			for (int i = 0; i < tarray3.Num(); i++)
			{
				USkeletalMeshComponent uskeletalMeshComponent = tarray3.Get(i) as USkeletalMeshComponent;
				uskeletalMeshComponent.SetForcedLOD(1);
				tarray.Add(uskeletalMeshComponent.SkeletalMesh);
			}
		}
		if (tarray4 != null)
		{
			for (int j = 0; j < tarray4.Num(); j++)
			{
				UStaticMeshComponent ustaticMeshComponent = tarray4.Get(j) as UStaticMeshComponent;
				ustaticMeshComponent.SetForcedLodModel(1);
				tarray2.Add(ustaticMeshComponent.StaticMesh);
			}
		}
		MeshStreamTaskContext meshStreamTaskContext = new MeshStreamTaskContext();
		meshStreamTaskContext.SkeletalMeshes = tarray;
		meshStreamTaskContext.StaticMeshes = tarray2;
		meshStreamTaskContext.OnTaskFinish = delegate()
		{
			this.OnLoadFinish(monsterId);
		};
		this.MeshStreamTaskId = ControllerBase<MeshStreamController>.Instance.AddMeshStreamTask(meshStreamTaskContext);
	}

	// Token: 0x0600AE44 RID: 44612 RVA: 0x002E5984 File Offset: 0x002E3B84
	private void OnLoadFinish(int monsterId)
	{
		UiCameraControlRotationComponent uiCameraComponent = UiCameraManager.Get().GetUiCameraComponent<UiCameraControlRotationComponent>();
		BP_KposeBase_C handBookVision = Singleton<UiSceneManager>.Instance.GetHandBookVision();
		if (handBookVision == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.LZK, "声骸模型为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (handBookVision.CameraArmLength <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.LZK, "相机臂长配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(monsterId);
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(calabashDevelopRewardByMonsterId.Value.HandBookCamera, false, false, "1001", false, null, null);
		uiCameraComponent.SetArmLength((float)handBookVision.CameraArmLength);
		if (handBookVision != null)
		{
			handBookVision.SetActorHiddenInGame(false);
		}
		if (handBookVision != null)
		{
			handBookVision.PlayStart();
		}
		RoleModelLoadingItem loadingItem = this.LoadingItem;
		if (loadingItem == null)
		{
			return;
		}
		loadingItem.SetLoadingActive(false);
	}

	// Token: 0x0600AE45 RID: 44613 RVA: 0x002E5A60 File Offset: 0x002E3C60
	private void DestroyVision()
	{
		if (this.BpHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.BpHandle);
			this.BpHandle = -1;
		}
		if (this.MeshStreamTaskId != -1)
		{
			ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(this.MeshStreamTaskId);
			this.MeshStreamTaskId = -1;
		}
		if (Singleton<UiSceneManager>.Instance.GetHandBookVision() != null)
		{
			Singleton<UiSceneManager>.Instance.DestroyHandBookVision();
		}
	}

	// Token: 0x0600AE46 RID: 44614 RVA: 0x002E5AC4 File Offset: 0x002E3CC4
	private void InitScheduleText()
	{
		int calabashAllSchedule = ModelBase<CalabashModel>.Instance.GetCalabashAllSchedule();
		int calabashOwnSchedule = ModelBase<CalabashModel>.Instance.GetCalabashOwnSchedule();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Illustration_Progress_Iteration", new <>z__ReadOnlyArray<object>(new object[]
		{
			calabashOwnSchedule,
			calabashAllSchedule
		}));
	}

	// Token: 0x0600AE47 RID: 44615 RVA: 0x002E5B1A File Offset: 0x002E3D1A
	private void CancelSelect()
	{
		this.CurrentSelectedMonsterId = 0;
		LoopScrollView<CalabashCollectGridItem, CalabashDevelopRewardData> loopScroll = this.LoopScroll;
		if (loopScroll != null)
		{
			loopScroll.DeselectCurrentGridProxy(false);
		}
		this.DestroyVision();
	}

	// Token: 0x0600AE48 RID: 44616 RVA: 0x002E5B3B File Offset: 0x002E3D3B
	private void SetEmptyState(bool isSkin, bool isEmpty)
	{
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(!isSkin && isEmpty);
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(isSkin && isEmpty);
	}

	// Token: 0x04005271 RID: 21105
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterEntrance<CalabashDevelopRewardData> FilterEntrance;

	// Token: 0x04005272 RID: 21106
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SortEntrance<CalabashDevelopRewardData> SortEntrance;

	// Token: 0x04005273 RID: 21107
	private CalabashCollectDetailItem DetailItem;

	// Token: 0x04005274 RID: 21108
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<CalabashCollectGridItem, CalabashDevelopRewardData> LoopScroll;

	// Token: 0x04005275 RID: 21109
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CalabashDevelopRewardData[] DataList;

	// Token: 0x04005276 RID: 21110
	private VisionCameraInputItem VisionCameraInputItem;

	// Token: 0x04005277 RID: 21111
	private RoleModelLoadingItem LoadingItem;

	// Token: 0x04005278 RID: 21112
	private int WaitToSelectMonsterId;

	// Token: 0x04005279 RID: 21113
	private int CurrentSelectedMonsterId;

	// Token: 0x0400527A RID: 21114
	private int BpHandle = -1;

	// Token: 0x0400527B RID: 21115
	private int MeshStreamTaskId = -1;

	// Token: 0x0400527C RID: 21116
	private bool IsInternal;

	// Token: 0x0400527D RID: 21117
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400527E RID: 21118
	private int ShowMonsterId;

	// Token: 0x0400527F RID: 21119
	private bool IsOnlyShow;

	// Token: 0x02007B6A RID: 31594
	[NullableContext(0)]
	private enum ECompDefine
	{
		// Token: 0x0402A305 RID: 172805
		LoopScroll,
		// Token: 0x0402A306 RID: 172806
		LoopScrollItem,
		// Token: 0x0402A307 RID: 172807
		FilterEntrance,
		// Token: 0x0402A308 RID: 172808
		SortEntrance,
		// Token: 0x0402A309 RID: 172809
		DetailItem,
		// Token: 0x0402A30A RID: 172810
		ScheduleText,
		// Token: 0x0402A30B RID: 172811
		EmptyItem,
		// Token: 0x0402A30C RID: 172812
		DragItem,
		// Token: 0x0402A30D RID: 172813
		LeftItem,
		// Token: 0x0402A30E RID: 172814
		BackButton,
		// Token: 0x0402A30F RID: 172815
		EmptySkinItem
	}
}
