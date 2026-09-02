using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005980 RID: 22912
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueMapModule : UiPanelBase
	{
		// Token: 0x0603A087 RID: 237703 RVA: 0x00EAFE40 File Offset: 0x00EAE040
		public MapRogueMapModule(MapRogueGameInfo gameInfo)
		{
			this.GameInfo = gameInfo;
		}

		// Token: 0x0603A088 RID: 237704 RVA: 0x00EAFF5C File Offset: 0x00EAE15C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUISliderComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(11, typeof(UUITexture)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnMaskBtnClick))
			};
		}

		// Token: 0x0603A089 RID: 237705 RVA: 0x00EB0144 File Offset: 0x00EAE344
		protected override UniTask OnBeforeStartAsync()
		{
			MapRogueMapModule.<OnBeforeStartAsync>d__32 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRogueMapModule.<OnBeforeStartAsync>d__32>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A08A RID: 237706 RVA: 0x00EB0188 File Offset: 0x00EAE388
		private UniTask InitMap()
		{
			MapRogueMapModule.<InitMap>d__33 <InitMap>d__;
			<InitMap>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMap>d__.<>4__this = this;
			<InitMap>d__.<>1__state = -1;
			<InitMap>d__.<>t__builder.Start<MapRogueMapModule.<InitMap>d__33>(ref <InitMap>d__);
			return <InitMap>d__.<>t__builder.Task;
		}

		// Token: 0x0603A08B RID: 237707 RVA: 0x00EB01CC File Offset: 0x00EAE3CC
		private void InitMoveComponent()
		{
			RogueResInstGrid? insGridConfigByInstId = ConfigBase<MapRogueConfig>.Instance.GetInsGridConfigByInstId(this.GameInfo.InstanceId);
			if (insGridConfigByInstId == null)
			{
				return;
			}
			UUIDraggableComponent draggable = base.GetDraggable(0);
			draggable.RootUIComp.Get().SetHeight((float)insGridConfigByInstId.Value.MapHeight);
			draggable.RootUIComp.Get().SetWidth((float)insGridConfigByInstId.Value.MapWidth);
			this.MoveComponent = new BuildingMapMoveComponent(base.GetDraggable(0), true, true, true);
			this.RefreshMoveComponent();
			this.MoveComponent.PointerBeginDragExtraCallBack = new Action<ULGUIPointerEventData>(this.OnBeginDrag);
			this.MoveComponent.PointerUpExtraCallBack = new Action<ULGUIPointerEventData>(this.OnEndDrag);
			double num = (double)insGridConfigByInstId.Value.MapScaleMin / 1000.0;
			double num2 = (double)insGridConfigByInstId.Value.MapScaleMax / 1000.0;
			double scale = Math.Max(Math.Min(num2, this.GameInfo.MapScale), num);
			this.MoveComponent.SetScaleSafeArea(num, num2);
			base.SetTextureByPath(insGridConfigByInstId.Value.MapBackground, base.GetTexture(11), null, null);
			this.MoveComponent.SetChangeScaleCallback(new Action<ESetScaleSource>(this.OnChangeScale));
			this.MoveComponent.SetScale(scale, ESetScaleSource.Other, null);
			this.GameInfo.TriggerGuideEventOnFocusStart();
			this.FocusOnGrid(this.GameInfo.PlayerGridIndex, false, null, null);
			this.GameInfo.TriggerGuideEventOnFocusEnd();
		}

		// Token: 0x0603A08C RID: 237708 RVA: 0x00EB0370 File Offset: 0x00EAE570
		private void RefreshMoveComponent()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.MoveComponent.MoveSpeed = ConfigCommonParamById.GetFloatConfig("MapRogueMapMoveSpeedGamepad").Value;
				return;
			}
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				this.MoveComponent.MoveSpeed = ConfigCommonParamById.GetFloatConfig("MapRogueMapMoveSpeedKeyboard").Value;
			}
		}

		// Token: 0x0603A08D RID: 237709 RVA: 0x00EB03D0 File Offset: 0x00EAE5D0
		public void MapShow()
		{
			this.ResetAllPath();
			this.MoveComponent.BindTouch();
			this.MoveComponent.AddGamepadEvent();
			this.MoveComponent.AddMoveListener(this.GameInfo.CanInteract);
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI左键点击", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603A08E RID: 237710 RVA: 0x00EB0448 File Offset: 0x00EAE648
		public void MapHide()
		{
			this.MoveComponent.UnbindTouch();
			this.MoveComponent.RemoveGamepadEvent();
			this.MoveComponent.RemoveMoveListener();
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI左键点击", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603A08F RID: 237711 RVA: 0x00EB04B0 File Offset: 0x00EAE6B0
		protected override void OnBeforeDestroy()
		{
			this.GridEventItemMap.Clear();
			this.GridPosItemMap.Clear();
			this.GridFogPosItemMap.Clear();
			this.MoveComponent.Destroy();
			LongPressButton scaleUp = this.ScaleUp;
			if (scaleUp != null)
			{
				scaleUp.OnDestroy();
			}
			LongPressButton scaleDown = this.ScaleDown;
			if (scaleDown != null)
			{
				scaleDown.OnDestroy();
			}
			this.CancelSingleClickTimer();
		}

		// Token: 0x0603A090 RID: 237712 RVA: 0x00EB0514 File Offset: 0x00EAE714
		public UniTask PlaySequence(string seqName)
		{
			MapRogueMapModule.<PlaySequence>d__39 <PlaySequence>d__;
			<PlaySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequence>d__.<>4__this = this;
			<PlaySequence>d__.seqName = seqName;
			<PlaySequence>d__.<>1__state = -1;
			<PlaySequence>d__.<>t__builder.Start<MapRogueMapModule.<PlaySequence>d__39>(ref <PlaySequence>d__);
			return <PlaySequence>d__.<>t__builder.Task;
		}

		// Token: 0x0603A091 RID: 237713 RVA: 0x00EB055F File Offset: 0x00EAE75F
		public void OnTick(float delta)
		{
			MapRoguePanelRole rolePanel = this.RolePanel;
			if (rolePanel != null)
			{
				rolePanel.OnTick(delta);
			}
			this.MoveComponent.TickMove();
			this.TickPendingList(delta);
		}

		// Token: 0x0603A092 RID: 237714 RVA: 0x00EB0588 File Offset: 0x00EAE788
		private bool IsMapMoveOffsetDiff()
		{
			Vector2D b = Vector2D.Create(this.MoveComponent.GetMapItem().GetAnchorOffset());
			return !this.MapTempPos.Equals(b, (double)this.ClickTolerance);
		}

		// Token: 0x0603A093 RID: 237715 RVA: 0x00EB05C8 File Offset: 0x00EAE7C8
		private void SetAnchorOffset(int id, UUIItem item)
		{
			ValueTuple<double, double> gridAnchorOffset = this.GetGridAnchorOffset(id, null);
			double item2 = gridAnchorOffset.Item1;
			double item3 = gridAnchorOffset.Item2;
			this.PosTempVector.Set(item2, item3);
			item.SetAnchorOffset(this.PosTempVector.ToUeVector2D(false));
		}

		// Token: 0x0603A094 RID: 237716 RVA: 0x00EB060C File Offset: 0x00EAE80C
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"X",
			"Y"
		})]
		private ValueTuple<double, double> GetGridAnchorOffset(int id, [Nullable(2)] IPos center = null)
		{
			if (center == null)
			{
				center = this.GameInfo.Center;
			}
			MapRogueMapPoint gridPos = this.GameInfo.GetGridPos(id);
			int y = gridPos.Y;
			int x = gridPos.X;
			int num = y - center.Y;
			int num2 = x - center.X;
			double item = 110.0 * (double)(num2 + num);
			double item2 = -64.0 * (double)(num - num2);
			return new ValueTuple<double, double>(item, item2);
		}

		// Token: 0x0603A095 RID: 237717 RVA: 0x00EB0678 File Offset: 0x00EAE878
		private double GetGridCreatePriority(int gridIndex)
		{
			MapRogueMapPoint gridPos = this.GameInfo.GetGridPos(this.GameInfo.PlayerGridIndex);
			ValueTuple<double, double> gridAnchorOffset = this.GetGridAnchorOffset(gridIndex, gridPos);
			double item = gridAnchorOffset.Item1;
			double item2 = gridAnchorOffset.Item2;
			ValueTuple<double, double> offsetDisRelativeToViewportCenterRatio = this.MoveComponent.GetOffsetDisRelativeToViewportCenterRatio(item, item2);
			double item3 = offsetDisRelativeToViewportCenterRatio.Item1;
			double item4 = offsetDisRelativeToViewportCenterRatio.Item2;
			if (item3 <= 1.2999999523162842 && item4 <= 1.2999999523162842)
			{
				return 0.0;
			}
			return item3 + item4;
		}

		// Token: 0x0603A096 RID: 237718 RVA: 0x00EB06F3 File Offset: 0x00EAE8F3
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshMoveComponent();
		}

		// Token: 0x0603A097 RID: 237719 RVA: 0x00EB06FC File Offset: 0x00EAE8FC
		[NullableContext(2)]
		public void FocusOnGrid(int gridId, bool needTween = true, Action callback = null, float? focusTweenTime = null)
		{
			ValueTuple<double, double> gridAnchorOffset = this.GetGridAnchorOffset(gridId, null);
			double item = gridAnchorOffset.Item1;
			double item2 = gridAnchorOffset.Item2;
			double num;
			if (!needTween)
			{
				num = 0.0;
			}
			else
			{
				float? num2 = focusTweenTime;
				num = ((num2 != null) ? ((double)num2.GetValueOrDefault()) : this.FocusTweenTime);
			}
			double tweenTime = num;
			this.MoveComponent.MoveToTarget(new double[]
			{
				item,
				item2
			}, LTweenEase.InOutSine, tweenTime, callback);
		}

		// Token: 0x0603A098 RID: 237720 RVA: 0x00EB0768 File Offset: 0x00EAE968
		public void SetInteractAvailable(bool bAvailable)
		{
			base.GetButton(5).RootUIComp.Get().SetUIActive(!bAvailable);
			this.MoveComponent.SwitchOnMove(bAvailable);
		}

		// Token: 0x0603A099 RID: 237721 RVA: 0x00EB07A0 File Offset: 0x00EAE9A0
		public void SetInteractState(bool move, bool check, int? gridIndex = null)
		{
			this.CanMove = move;
			this.CanCheck = check;
			if (gridIndex != null)
			{
				this.SetAnchorOffset(gridIndex.Value, base.GetItem(12));
			}
			base.GetItem(13).SetUIActive(move);
			base.GetItem(14).SetUIActive(check);
			base.GetItem(12).SetUIActive((move || check) && !this.MoveComponent.IsInDrag);
		}

		// Token: 0x0603A09A RID: 237722 RVA: 0x00EB0818 File Offset: 0x00EAEA18
		protected void TickPendingList(float delta)
		{
			if (!this.InCreating)
			{
				return;
			}
			this.CreateDeltaTime += delta;
			if (this.CreateDeltaTime < 100f)
			{
				return;
			}
			this.CreateDeltaTime = 0f;
			UiAsyncTask task = new UiAsyncTask("MapRogueMapModule.TickPendingList", delegate()
			{
				MapRogueMapModule.<<TickPendingList>b__54_0>d <<TickPendingList>b__54_0>d;
				<<TickPendingList>b__54_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<TickPendingList>b__54_0>d.<>4__this = this;
				<<TickPendingList>b__54_0>d.<>1__state = -1;
				<<TickPendingList>b__54_0>d.<>t__builder.Start<MapRogueMapModule.<<TickPendingList>b__54_0>d>(ref <<TickPendingList>b__54_0>d);
				return <<TickPendingList>b__54_0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603A09B RID: 237723 RVA: 0x00EB0878 File Offset: 0x00EAEA78
		private UniTask HandleCreatePending()
		{
			MapRogueMapModule.<HandleCreatePending>d__55 <HandleCreatePending>d__;
			<HandleCreatePending>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleCreatePending>d__.<>4__this = this;
			<HandleCreatePending>d__.<>1__state = -1;
			<HandleCreatePending>d__.<>t__builder.Start<MapRogueMapModule.<HandleCreatePending>d__55>(ref <HandleCreatePending>d__);
			return <HandleCreatePending>d__.<>t__builder.Task;
		}

		// Token: 0x0603A09C RID: 237724 RVA: 0x00EB08BC File Offset: 0x00EAEABC
		private void CheckViewLoadDone()
		{
			if (this.InCreating)
			{
				this.GameInfo.SetTipsItemProxy(true, "RogueRes_Map_Loading");
				return;
			}
			this.GameInfo.SetInteractAvailable(EMapForbiddenTag.GridCreate, true);
			CustomPromise viewLoadPromise = this.GameInfo.ViewLoadPromise;
			if (viewLoadPromise != null)
			{
				viewLoadPromise.SetResult();
			}
			this.GameInfo.SetTipsItemProxy(false, null);
		}

		// Token: 0x0603A09D RID: 237725 RVA: 0x00EB0914 File Offset: 0x00EAEB14
		private UniTask HandlePendingItem(IGridCreateInfo info)
		{
			MapRogueMapModule.<HandlePendingItem>d__57 <HandlePendingItem>d__;
			<HandlePendingItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandlePendingItem>d__.<>4__this = this;
			<HandlePendingItem>d__.info = info;
			<HandlePendingItem>d__.<>1__state = -1;
			<HandlePendingItem>d__.<>t__builder.Start<MapRogueMapModule.<HandlePendingItem>d__57>(ref <HandlePendingItem>d__);
			return <HandlePendingItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603A09E RID: 237726 RVA: 0x00EB0960 File Offset: 0x00EAEB60
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		protected UniTask<UiPoolActor> GetActor(string uiPath, [Nullable(2)] UUIItem parent = null)
		{
			MapRogueMapModule.<GetActor>d__58 <GetActor>d__;
			<GetActor>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiPoolActor>.Create();
			<GetActor>d__.<>4__this = this;
			<GetActor>d__.uiPath = uiPath;
			<GetActor>d__.parent = parent;
			<GetActor>d__.<>1__state = -1;
			<GetActor>d__.<>t__builder.Start<MapRogueMapModule.<GetActor>d__58>(ref <GetActor>d__);
			return <GetActor>d__.<>t__builder.Task;
		}

		// Token: 0x0603A09F RID: 237727 RVA: 0x00EB09B4 File Offset: 0x00EAEBB4
		public void RecycleAllActor()
		{
			foreach (UiPoolActor uiPoolActor in this.UiPoolActorHandle)
			{
				this.RecycleActor(uiPoolActor);
			}
			this.UiPoolActorHandle.Clear();
		}

		// Token: 0x0603A0A0 RID: 237728 RVA: 0x00EB0A14 File Offset: 0x00EAEC14
		protected void RecycleActor(UiPoolActor uiPoolActor)
		{
			if (this.GameInfo == null)
			{
				return;
			}
			if (this.GameInfo.ActorPool != null && !this.GameInfo.IsEnd)
			{
				this.GameInfo.ActorPool.RecycleAsync(uiPoolActor, uiPoolActor.Path);
			}
		}

		// Token: 0x0603A0A1 RID: 237729 RVA: 0x00EB0A50 File Offset: 0x00EAEC50
		private UUIItem CreateMapGridPosItem(UUIItem rootItem, UUIItem parentItem, MapGridData data)
		{
			UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(rootItem, parentItem);
			this.SetAnchorOffset(data.GridIndex, uuiitem);
			uuiitem.SetUIActive(true);
			return uuiitem;
		}

		// Token: 0x0603A0A2 RID: 237730 RVA: 0x00EB0A80 File Offset: 0x00EAEC80
		protected UniTask CreateMapGridBg(MapGridData data)
		{
			MapRogueMapModule.<CreateMapGridBg>d__68 <CreateMapGridBg>d__;
			<CreateMapGridBg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMapGridBg>d__.<>4__this = this;
			<CreateMapGridBg>d__.data = data;
			<CreateMapGridBg>d__.<>1__state = -1;
			<CreateMapGridBg>d__.<>t__builder.Start<MapRogueMapModule.<CreateMapGridBg>d__68>(ref <CreateMapGridBg>d__);
			return <CreateMapGridBg>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0A3 RID: 237731 RVA: 0x00EB0ACC File Offset: 0x00EAECCC
		protected UniTask CreateMapGridFog(int gridIndex)
		{
			MapRogueMapModule.<CreateMapGridFog>d__69 <CreateMapGridFog>d__;
			<CreateMapGridFog>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMapGridFog>d__.<>4__this = this;
			<CreateMapGridFog>d__.gridIndex = gridIndex;
			<CreateMapGridFog>d__.<>1__state = -1;
			<CreateMapGridFog>d__.<>t__builder.Start<MapRogueMapModule.<CreateMapGridFog>d__69>(ref <CreateMapGridFog>d__);
			return <CreateMapGridFog>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0A4 RID: 237732 RVA: 0x00EB0B18 File Offset: 0x00EAED18
		protected UniTask RefreshMapGridFogVision(int gridIndex, bool bHasVision)
		{
			MapRogueMapModule.<RefreshMapGridFogVision>d__70 <RefreshMapGridFogVision>d__;
			<RefreshMapGridFogVision>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshMapGridFogVision>d__.<>4__this = this;
			<RefreshMapGridFogVision>d__.gridIndex = gridIndex;
			<RefreshMapGridFogVision>d__.bHasVision = bHasVision;
			<RefreshMapGridFogVision>d__.<>1__state = -1;
			<RefreshMapGridFogVision>d__.<>t__builder.Start<MapRogueMapModule.<RefreshMapGridFogVision>d__70>(ref <RefreshMapGridFogVision>d__);
			return <RefreshMapGridFogVision>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0A5 RID: 237733 RVA: 0x00EB0B6C File Offset: 0x00EAED6C
		public void RefreshMapGrid(MapGridData data)
		{
			MapRogueMapModule.<>c__DisplayClass71_0 CS$<>8__locals1 = new MapRogueMapModule.<>c__DisplayClass71_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			MapRogueGrid mapRogueGrid = null;
			this.GridItemMap.TryGetValue(CS$<>8__locals1.data.GridIndex, out mapRogueGrid);
			mapRogueGrid.Refresh(CS$<>8__locals1.data);
			UiAsyncTask task = new UiAsyncTask("MapRogueMapModule.RefreshMapGridTask", delegate()
			{
				MapRogueMapModule.<>c__DisplayClass71_0.<<RefreshMapGrid>b__0>d <<RefreshMapGrid>b__0>d;
				<<RefreshMapGrid>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshMapGrid>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshMapGrid>b__0>d.<>1__state = -1;
				<<RefreshMapGrid>b__0>d.<>t__builder.Start<MapRogueMapModule.<>c__DisplayClass71_0.<<RefreshMapGrid>b__0>d>(ref <<RefreshMapGrid>b__0>d);
				return <<RefreshMapGrid>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603A0A6 RID: 237734 RVA: 0x00EB0BD4 File Offset: 0x00EAEDD4
		public void SetMapGridBgVision(int gridIndex, bool bHasVision)
		{
			MapRogueMapModule.<>c__DisplayClass72_0 CS$<>8__locals1 = new MapRogueMapModule.<>c__DisplayClass72_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.gridIndex = gridIndex;
			CS$<>8__locals1.bHasVision = bHasVision;
			UiAsyncTask task = new UiAsyncTask("MapRogueMapModule.SetMapGridBgVision", delegate()
			{
				MapRogueMapModule.<>c__DisplayClass72_0.<<SetMapGridBgVision>b__0>d <<SetMapGridBgVision>b__0>d;
				<<SetMapGridBgVision>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<SetMapGridBgVision>b__0>d.<>4__this = CS$<>8__locals1;
				<<SetMapGridBgVision>b__0>d.<>1__state = -1;
				<<SetMapGridBgVision>b__0>d.<>t__builder.Start<MapRogueMapModule.<>c__DisplayClass72_0.<<SetMapGridBgVision>b__0>d>(ref <<SetMapGridBgVision>b__0>d);
				return <<SetMapGridBgVision>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603A0A7 RID: 237735 RVA: 0x00EB0C1C File Offset: 0x00EAEE1C
		public void SetMapGridBgState(int gridIndex, bool bSelectOn, bool? bFireEvent = null)
		{
			MapRogueGrid mapRogueGrid = null;
			this.GridItemMap.TryGetValue(gridIndex, out mapRogueGrid);
			if (mapRogueGrid != null)
			{
				mapRogueGrid.SetGridToggleState(bSelectOn, bFireEvent.GetValueOrDefault());
			}
		}

		// Token: 0x0603A0A8 RID: 237736 RVA: 0x00EB0C4C File Offset: 0x00EAEE4C
		public void SetMapGridMoveEnable(int gridIndex, bool bEnable)
		{
			MapRogueGrid mapRogueGrid = null;
			this.GridItemMap.TryGetValue(gridIndex, out mapRogueGrid);
			if (mapRogueGrid != null)
			{
				mapRogueGrid.SetToggleMoveEnable(bEnable);
			}
		}

		// Token: 0x0603A0A9 RID: 237737 RVA: 0x00EB0C74 File Offset: 0x00EAEE74
		public void SetPerspectiveMode(int gridIndex, bool bOn)
		{
			if (this.MoveComponent.IsInDrag)
			{
				return;
			}
			MapRogueGrid mapRogueGrid = null;
			this.GridItemMap.TryGetValue(gridIndex, out mapRogueGrid);
			if (mapRogueGrid != null)
			{
				mapRogueGrid.SetPerspectiveMode(bOn);
			}
		}

		// Token: 0x0603A0AA RID: 237738 RVA: 0x00EB0CAC File Offset: 0x00EAEEAC
		[NullableContext(2)]
		public IGridRangeInfo GetGridRangeInfo(int gridIndex)
		{
			MapRogueGrid mapRogueGrid = null;
			this.GridItemMap.TryGetValue(gridIndex, out mapRogueGrid);
			if (mapRogueGrid == null)
			{
				return null;
			}
			FVector lguispaceAbsolutePosition = mapRogueGrid.GetOriginalItem().GetLGUISpaceAbsolutePosition();
			double num = (double)ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.GridValidRangeTolerance / 1000.0 * this.MoveComponent.MapScale;
			return new GridRangeInfo
			{
				CenterX = (double)lguispaceAbsolutePosition.X,
				CenterY = (double)lguispaceAbsolutePosition.Y + 16.0 * this.MoveComponent.MapScale,
				RadiusX = 110.0 * this.MoveComponent.MapScale + num,
				RadiusY = 62.0 * this.MoveComponent.MapScale + num
			};
		}

		// Token: 0x17009476 RID: 38006
		// (get) Token: 0x0603A0AB RID: 237739 RVA: 0x00EB0D7D File Offset: 0x00EAEF7D
		private bool NeedDoubleClick
		{
			get
			{
				return Singleton<Info>.Instance.IsInKeyBoard();
			}
		}

		// Token: 0x17009477 RID: 38007
		// (get) Token: 0x0603A0AC RID: 237740 RVA: 0x00EB0D89 File Offset: 0x00EAEF89
		private bool InClick
		{
			get
			{
				return this.InClickGridId >= 0;
			}
		}

		// Token: 0x0603A0AD RID: 237741 RVA: 0x00EB0D97 File Offset: 0x00EAEF97
		private void OnMaskBtnClick()
		{
		}

		// Token: 0x0603A0AE RID: 237742 RVA: 0x00EB0D99 File Offset: 0x00EAEF99
		private void CancelSingleClickTimer()
		{
			if (this.SingleClickTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.SingleClickTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.SingleClickTimerHandle);
			}
			this.SingleClickTimerHandle = null;
			this.InClickGridId = -1;
		}

		// Token: 0x0603A0AF RID: 237743 RVA: 0x00EB0DD4 File Offset: 0x00EAEFD4
		private void OnInputAction(string name, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (!this.NeedDoubleClick)
			{
				return;
			}
			if (!this.GameInfo.IsStageAvailable)
			{
				return;
			}
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				this.IsClickUp = true;
				return;
			}
			if (!this.InClick)
			{
				this.CancelSingleClickTimer();
				this.InClickGridId = this.GameInfo.CurHoverIndex;
				this.IsClickUp = false;
				this.SingleClickTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					if (this.InClick)
					{
						if (this.IsClickUp)
						{
							this.SetMapGridBgState(this.InClickGridId, true, new bool?(true));
						}
						this.SingleClickTimerHandle = null;
						this.InClickGridId = -1;
					}
				}, (float)this.DoubleClickIntervalTime, null, null, true, 1f);
				return;
			}
			if (this.CanMove)
			{
				this.GameInfo.OnMove(new int?(this.InClickGridId));
			}
			this.CancelSingleClickTimer();
		}

		// Token: 0x0603A0B0 RID: 237744 RVA: 0x00EB0E7C File Offset: 0x00EAF07C
		private bool OnGridBgExtendToggleCanExecute(EToggleState state, MapGridData data)
		{
			if (this.InClick)
			{
				return false;
			}
			if (this.IsMapMoveOffsetDiff())
			{
				return false;
			}
			if (this.GameInfo.CurHoverIndex != data.GridIndex)
			{
				this.GameInfo.HoverOnTarget(data.GridIndex, true);
			}
			return state == EToggleState.ETT_UnChecked && this.CanCheck;
		}

		// Token: 0x0603A0B1 RID: 237745 RVA: 0x00EB0ECD File Offset: 0x00EAF0CD
		private void OnGridBgPointerDown(EToggleState state, MapGridData data)
		{
			this.MapTempPos.FromUeVector2D(this.MoveComponent.GetMapItem().GetAnchorOffset());
			this.MoveComponent.EmitPointerDown();
		}

		// Token: 0x0603A0B2 RID: 237746 RVA: 0x00EB0EFA File Offset: 0x00EAF0FA
		private void OnGridBgExtendToggleStateChanged(EToggleState state, MapGridData data)
		{
			this.GameInfo.OnCheck(data.GridIndex);
		}

		// Token: 0x0603A0B3 RID: 237747 RVA: 0x00EB0F10 File Offset: 0x00EAF110
		private void OnGridBgHover(MapGridData data)
		{
			this.SetSelectPanel(data);
			if (this.InClick)
			{
				this.CancelSingleClickTimer();
			}
			if (this.MoveComponent.IsInDrag)
			{
				return;
			}
			this.GameInfo.HoverOnTarget(data.GridIndex, !Singleton<Info>.Instance.IsInTouch());
		}

		// Token: 0x0603A0B4 RID: 237748 RVA: 0x00EB0F5E File Offset: 0x00EAF15E
		private void OnGridBgUnHover(MapGridData data)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			this.GameInfo.UnHoverOnTarget(data.GridIndex);
		}

		// Token: 0x0603A0B5 RID: 237749 RVA: 0x00EB0F7E File Offset: 0x00EAF17E
		private void OnBackPlaneEnter()
		{
			if (this.InClick)
			{
				this.CancelSingleClickTimer();
			}
			this.GameInfo.BlankPlaneEnter();
		}

		// Token: 0x0603A0B6 RID: 237750 RVA: 0x00EB0F99 File Offset: 0x00EAF199
		private void OnBackPlanePointerDown()
		{
			this.MoveComponent.EmitPointerDown();
		}

		// Token: 0x0603A0B7 RID: 237751 RVA: 0x00EB0FA8 File Offset: 0x00EAF1A8
		private void OnBeginDrag(ULGUIPointerEventData _)
		{
			base.GetButton(16).RootUIComp.Get().SetUIActive(true);
			base.GetItem(12).SetUIActive(false);
		}

		// Token: 0x0603A0B8 RID: 237752 RVA: 0x00EB0FE0 File Offset: 0x00EAF1E0
		private void OnEndDrag(ULGUIPointerEventData _)
		{
			base.GetButton(16).RootUIComp.Get().SetUIActive(false);
			this.SetInteractState(this.CanMove, this.CanCheck, new int?(this.GameInfo.CurHoverIndex));
		}

		// Token: 0x0603A0B9 RID: 237753 RVA: 0x00EB102C File Offset: 0x00EAF22C
		protected UniTask CreateMapGridEvent(MapGridData data, bool bHasVision = true)
		{
			MapRogueMapModule.<CreateMapGridEvent>d__93 <CreateMapGridEvent>d__;
			<CreateMapGridEvent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMapGridEvent>d__.<>4__this = this;
			<CreateMapGridEvent>d__.data = data;
			<CreateMapGridEvent>d__.bHasVision = bHasVision;
			<CreateMapGridEvent>d__.<>1__state = -1;
			<CreateMapGridEvent>d__.<>t__builder.Start<MapRogueMapModule.<CreateMapGridEvent>d__93>(ref <CreateMapGridEvent>d__);
			return <CreateMapGridEvent>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0BA RID: 237754 RVA: 0x00EB1080 File Offset: 0x00EAF280
		protected UniTask RefreshMapGridEventVision(MapGridData data, bool bHasVision)
		{
			MapRogueMapModule.<RefreshMapGridEventVision>d__94 <RefreshMapGridEventVision>d__;
			<RefreshMapGridEventVision>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshMapGridEventVision>d__.<>4__this = this;
			<RefreshMapGridEventVision>d__.data = data;
			<RefreshMapGridEventVision>d__.bHasVision = bHasVision;
			<RefreshMapGridEventVision>d__.<>1__state = -1;
			<RefreshMapGridEventVision>d__.<>t__builder.Start<MapRogueMapModule.<RefreshMapGridEventVision>d__94>(ref <RefreshMapGridEventVision>d__);
			return <RefreshMapGridEventVision>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0BB RID: 237755 RVA: 0x00EB10D4 File Offset: 0x00EAF2D4
		public void RefreshAllEventLv()
		{
			foreach (MapRogueGridEvent mapRogueGridEvent in this.GridEventItemMap.Values)
			{
				mapRogueGridEvent.RefreshLv(true);
			}
		}

		// Token: 0x0603A0BC RID: 237756 RVA: 0x00EB112C File Offset: 0x00EAF32C
		public void CreateAllMapGridPath(List<int> lastGridIdList, List<int> gridIdList)
		{
			MapRogueMapModule.<>c__DisplayClass96_0 CS$<>8__locals1 = new MapRogueMapModule.<>c__DisplayClass96_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.lastGridIdList = lastGridIdList;
			CS$<>8__locals1.gridIdList = gridIdList;
			UiAsyncTask task = new UiAsyncTask("MapRogueMapModule.CreateAllMapGridPath", delegate()
			{
				MapRogueMapModule.<>c__DisplayClass96_0.<<CreateAllMapGridPath>b__0>d <<CreateAllMapGridPath>b__0>d;
				<<CreateAllMapGridPath>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<CreateAllMapGridPath>b__0>d.<>4__this = CS$<>8__locals1;
				<<CreateAllMapGridPath>b__0>d.<>1__state = -1;
				<<CreateAllMapGridPath>b__0>d.<>t__builder.Start<MapRogueMapModule.<>c__DisplayClass96_0.<<CreateAllMapGridPath>b__0>d>(ref <<CreateAllMapGridPath>b__0>d);
				return <<CreateAllMapGridPath>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603A0BD RID: 237757 RVA: 0x00EB1174 File Offset: 0x00EAF374
		public UniTask CreateAllMapGridPathAsync(List<int> lastGridIdList, List<int> gridIdList)
		{
			MapRogueMapModule.<CreateAllMapGridPathAsync>d__97 <CreateAllMapGridPathAsync>d__;
			<CreateAllMapGridPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAllMapGridPathAsync>d__.<>4__this = this;
			<CreateAllMapGridPathAsync>d__.lastGridIdList = lastGridIdList;
			<CreateAllMapGridPathAsync>d__.gridIdList = gridIdList;
			<CreateAllMapGridPathAsync>d__.<>1__state = -1;
			<CreateAllMapGridPathAsync>d__.<>t__builder.Start<MapRogueMapModule.<CreateAllMapGridPathAsync>d__97>(ref <CreateAllMapGridPathAsync>d__);
			return <CreateAllMapGridPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0BE RID: 237758 RVA: 0x00EB11C8 File Offset: 0x00EAF3C8
		protected UniTask CreateMapGridPath(int gridId, EShapeType shape, bool isLast, bool isCreate)
		{
			MapRogueMapModule.<CreateMapGridPath>d__98 <CreateMapGridPath>d__;
			<CreateMapGridPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMapGridPath>d__.<>4__this = this;
			<CreateMapGridPath>d__.gridId = gridId;
			<CreateMapGridPath>d__.shape = shape;
			<CreateMapGridPath>d__.isLast = isLast;
			<CreateMapGridPath>d__.isCreate = isCreate;
			<CreateMapGridPath>d__.<>1__state = -1;
			<CreateMapGridPath>d__.<>t__builder.Start<MapRogueMapModule.<CreateMapGridPath>d__98>(ref <CreateMapGridPath>d__);
			return <CreateMapGridPath>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0BF RID: 237759 RVA: 0x00EB122C File Offset: 0x00EAF42C
		protected EShapeType GetShapeType(int curId, int preId, int nextId)
		{
			EShapeType eshapeType = (EShapeType)MapRogueMapModule.<GetShapeType>g__directionFunc|99_0(curId, preId);
			int num = (int)MapRogueMapModule.<GetShapeType>g__directionFunc|99_0(curId, nextId);
			return eshapeType * (EShapeType)10 + num;
		}

		// Token: 0x0603A0C0 RID: 237760 RVA: 0x00EB1250 File Offset: 0x00EAF450
		public void ResetPath(int index)
		{
			MapRogueGridPath mapRogueGridPath = null;
			this.GridPathItemMap.TryGetValue(index, out mapRogueGridPath);
			if (mapRogueGridPath == null)
			{
				return;
			}
			mapRogueGridPath.SetUiActive(false);
			this.CachedPathItemList.Add(mapRogueGridPath);
			this.GridPathItemMap.Remove(index);
		}

		// Token: 0x0603A0C1 RID: 237761 RVA: 0x00EB1294 File Offset: 0x00EAF494
		public void ResetAllPath()
		{
			foreach (MapRogueGridPath mapRogueGridPath in this.GridPathItemMap.Values)
			{
				mapRogueGridPath.SetUiActive(false);
				this.CachedPathItemList.Add(mapRogueGridPath);
			}
			this.GridPathItemMap.Clear();
		}

		// Token: 0x0603A0C2 RID: 237762 RVA: 0x00EB1304 File Offset: 0x00EAF504
		private UniTask InitRole()
		{
			MapRogueMapModule.<InitRole>d__102 <InitRole>d__;
			<InitRole>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRole>d__.<>4__this = this;
			<InitRole>d__.<>1__state = -1;
			<InitRole>d__.<>t__builder.Start<MapRogueMapModule.<InitRole>d__102>(ref <InitRole>d__);
			return <InitRole>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0C3 RID: 237763 RVA: 0x00EB1348 File Offset: 0x00EAF548
		public void SetRolePos(int gridId)
		{
			UUIItem item = base.GetItem(4);
			this.SetAnchorOffset(gridId, item);
		}

		// Token: 0x0603A0C4 RID: 237764 RVA: 0x00EB1368 File Offset: 0x00EAF568
		public void SetRolePosByGrid(float progress, int lastGridId, int curGridId)
		{
			UUIItem item = base.GetItem(4);
			ValueTuple<double, double> gridAnchorOffset = this.GetGridAnchorOffset(lastGridId, null);
			double item2 = gridAnchorOffset.Item1;
			double item3 = gridAnchorOffset.Item2;
			ValueTuple<double, double> gridAnchorOffset2 = this.GetGridAnchorOffset(curGridId, null);
			double item4 = gridAnchorOffset2.Item1;
			double item5 = gridAnchorOffset2.Item2;
			double inX = Singleton<MathUtils>.Instance.Lerp(item2, item4, (double)progress);
			double inY = Singleton<MathUtils>.Instance.Lerp(item3, item5, (double)progress);
			this.PosTempVector.Set(inX, inY);
			item.SetAnchorOffset(this.PosTempVector.ToUeVector2D(false));
		}

		// Token: 0x0603A0C5 RID: 237765 RVA: 0x00EB13E8 File Offset: 0x00EAF5E8
		private void InitScaleSlider()
		{
			UUISliderComponent slider = base.GetSlider(9);
			slider.SetMinValue((float)this.MoveComponent.MapScaleSafeArea.Min, false, false);
			slider.SetMaxValue((float)this.MoveComponent.MapScaleSafeArea.Max, false, false);
			slider.SetValue((float)this.MoveComponent.MapScale, true);
			slider.OnValueChangeCb.Bind(new Action<float>(this.OnSliderValueChange));
			this.ScaleUp = new LongPressButton(base.GetButton(7), new Action<float>(this.OnScaleUp), 100);
			this.ScaleDown = new LongPressButton(base.GetButton(8), new Action<float>(this.OnScaleDown), 100);
		}

		// Token: 0x0603A0C6 RID: 237766 RVA: 0x00EB1498 File Offset: 0x00EAF698
		private void OnScaleDown(float _)
		{
			this.MoveComponent.LongPressScroll((float)(-(float)this.MoveComponent.ScaleStep));
		}

		// Token: 0x0603A0C7 RID: 237767 RVA: 0x00EB14B2 File Offset: 0x00EAF6B2
		private void OnScaleUp(float _)
		{
			this.MoveComponent.LongPressScroll((float)this.MoveComponent.ScaleStep);
		}

		// Token: 0x0603A0C8 RID: 237768 RVA: 0x00EB14CB File Offset: 0x00EAF6CB
		private void OnSliderValueChange(float value)
		{
			this.MoveComponent.SliderScroll(value);
		}

		// Token: 0x0603A0C9 RID: 237769 RVA: 0x00EB14DC File Offset: 0x00EAF6DC
		private void OnChangeScale(ESetScaleSource source)
		{
			this.GameInfo.MapScale = this.MoveComponent.MapScale;
			UUISliderComponent slider = base.GetSlider(9);
			if (source != ESetScaleSource.Slider)
			{
				slider.SetValue((float)this.MoveComponent.MapScale, false);
			}
			double min = this.MoveComponent.MapScaleSafeArea.Min;
			double max = this.MoveComponent.MapScaleSafeArea.Max;
			double alpha = (this.MoveComponent.MapScale - min) / (max - min);
			double num = Singleton<MathUtils>.Instance.Lerp(1.0, 1.2999999523162842, alpha);
			this.MapTempScaleVector.Set(num, num, num);
			base.GetTexture(11).SetUIItemScale(this.MapTempScaleVector.ToUeVectorOld());
			double num2 = 1.0 / this.MoveComponent.MapScale;
			this.MapTempScaleVector.Set(num2, num2, num2);
			base.GetItem(12).SetUIItemScale(this.MapTempScaleVector.ToUeVectorOld());
			if (this.RolePanel != null)
			{
				this.RolePanel.SetListRootItem(this.MapTempScaleVector);
			}
		}

		// Token: 0x0603A0CA RID: 237770 RVA: 0x00EB15F4 File Offset: 0x00EAF7F4
		private UniTask InitSelectPanel()
		{
			MapRogueMapModule.<InitSelectPanel>d__115 <InitSelectPanel>d__;
			<InitSelectPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSelectPanel>d__.<>4__this = this;
			<InitSelectPanel>d__.<>1__state = -1;
			<InitSelectPanel>d__.<>t__builder.Start<MapRogueMapModule.<InitSelectPanel>d__115>(ref <InitSelectPanel>d__);
			return <InitSelectPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0CB RID: 237771 RVA: 0x00EB1638 File Offset: 0x00EAF838
		protected void SetSelectPanel(MapGridData gridData)
		{
			int gridIndex = gridData.GridIndex;
			if (this.CachedSelectPanelList.Count <= this.LatestSelectPanelIndex)
			{
				return;
			}
			MapRogueGrid mapRogueGrid = null;
			this.GridItemMap.TryGetValue(gridIndex, out mapRogueGrid);
			if (mapRogueGrid == null)
			{
				return;
			}
			if (mapRogueGrid.SelectPanel.Count > 0)
			{
				return;
			}
			if (!gridData.Walkable)
			{
				return;
			}
			ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase> valueTuple = this.CachedSelectPanelList[this.LatestSelectPanelIndex];
			MapRogueGridSelectBase item = valueTuple.Item1;
			MapRogueGridSelectBase item2 = valueTuple.Item2;
			item.SetUiActive(false);
			item2.SetUiActive(false);
			int key = this.OccupiedSelectPanelIndex[this.LatestSelectPanelIndex];
			MapRogueGrid mapRogueGrid2 = null;
			this.GridItemMap.TryGetValue(key, out mapRogueGrid2);
			if (mapRogueGrid2 != null)
			{
				mapRogueGrid2.ClearSelectPanel();
			}
			mapRogueGrid.SetSelectPanel(item, item2);
			this.OccupiedSelectPanelIndex[this.LatestSelectPanelIndex] = gridIndex;
			this.LatestSelectPanelIndex++;
			if (this.LatestSelectPanelIndex >= this.CachedSelectPanelList.Count)
			{
				this.LatestSelectPanelIndex = 0;
			}
		}

		// Token: 0x0603A0CC RID: 237772 RVA: 0x00EB1724 File Offset: 0x00EAF924
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			int num;
			if (configParams[0] == "MapRougeGrid" && configParams.Length == 2 && int.TryParse(configParams[1], out num) && num > 0)
			{
				return this.GetGridGuideUiItem(num);
			}
			return null;
		}

		// Token: 0x0603A0CD RID: 237773 RVA: 0x00EB1768 File Offset: 0x00EAF968
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] GetGridGuideUiItem(int id)
		{
			MapRogueGrid mapRogueGrid = null;
			this.GridItemMap.TryGetValue(id, out mapRogueGrid);
			if (mapRogueGrid == null)
			{
				return null;
			}
			UUIItem rootItem = mapRogueGrid.GetRootItem();
			if (rootItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				rootItem,
				rootItem
			};
		}

		// Token: 0x0603A0D0 RID: 237776 RVA: 0x00EB181E File Offset: 0x00EAFA1E
		[CompilerGenerated]
		internal static EWayType <GetShapeType>g__directionFunc|99_0(int g0, int g1)
		{
			if (g0 < g1)
			{
				if (g0 + 1 == g1)
				{
					return EWayType.Right;
				}
				return EWayType.Down;
			}
			else
			{
				if (g0 - 1 == g1)
				{
					return EWayType.Left;
				}
				return EWayType.Up;
			}
		}

		// Token: 0x04020E9F RID: 134815
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04020EA0 RID: 134816
		protected BuildingMapMoveComponent MoveComponent;

		// Token: 0x04020EA1 RID: 134817
		public MapRoguePanelRole RolePanel;

		// Token: 0x04020EA2 RID: 134818
		protected readonly Dictionary<int, MapRogueGrid> GridItemMap = new Dictionary<int, MapRogueGrid>();

		// Token: 0x04020EA3 RID: 134819
		protected readonly Dictionary<int, MapRogueGridEvent> GridEventItemMap = new Dictionary<int, MapRogueGridEvent>();

		// Token: 0x04020EA4 RID: 134820
		protected readonly Dictionary<int, MapRogueGridPath> GridPathItemMap = new Dictionary<int, MapRogueGridPath>();

		// Token: 0x04020EA5 RID: 134821
		protected readonly Dictionary<int, MapRogueGridFog> GridFogItemMap = new Dictionary<int, MapRogueGridFog>();

		// Token: 0x04020EA6 RID: 134822
		protected readonly Dictionary<int, UUIItem> GridPosItemMap = new Dictionary<int, UUIItem>();

		// Token: 0x04020EA7 RID: 134823
		protected readonly Dictionary<int, UUIItem> GridFogPosItemMap = new Dictionary<int, UUIItem>();

		// Token: 0x04020EA8 RID: 134824
		protected readonly List<MapRogueGridPath> CachedPathItemList = new List<MapRogueGridPath>();

		// Token: 0x04020EA9 RID: 134825
		protected Vector2D PosTempVector = Vector2D.Create();

		// Token: 0x04020EAA RID: 134826
		protected Vector2D MapTempPos = Vector2D.Create();

		// Token: 0x04020EAB RID: 134827
		protected global::Vector MapTempScaleVector = global::Vector.Create();

		// Token: 0x04020EAC RID: 134828
		private readonly int ClickTolerance = ConfigCommonParamById.GetIntConfig("MapRogueClickOffsetTolerance").GetValueOrDefault(10);

		// Token: 0x04020EAD RID: 134829
		private readonly double FocusTweenTime = (double)ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.FocusTime / 1000.0;

		// Token: 0x04020EAE RID: 134830
		private const double X_BIAS = 110.0;

		// Token: 0x04020EAF RID: 134831
		private const double Y_BIAS = -64.0;

		// Token: 0x04020EB0 RID: 134832
		private const double CENTER_Y_BIAS = 16.0;

		// Token: 0x04020EB1 RID: 134833
		private const double RANGE_X = 110.0;

		// Token: 0x04020EB2 RID: 134834
		private const double RANGE_Y = 62.0;

		// Token: 0x04020EB3 RID: 134835
		private const double BG_MIN_SCALE = 1.0;

		// Token: 0x04020EB4 RID: 134836
		private const double BG_MAX_SCALE = 1.2999999523162842;

		// Token: 0x04020EB5 RID: 134837
		private const double VIEWPORT_PRIORITY_RATIO = 1.2999999523162842;

		// Token: 0x04020EB6 RID: 134838
		private const double THOUSANDTH_RATIO = 1000.0;

		// Token: 0x04020EB7 RID: 134839
		private const int PROCESSING_CREATE_COUNT = 120;

		// Token: 0x04020EB8 RID: 134840
		private const float PROCESSING_INTERVAL = 100f;

		// Token: 0x04020EB9 RID: 134841
		private const int CACHED_SELECT_PANEL_COUNT = 5;

		// Token: 0x04020EBA RID: 134842
		private const string RESOURCE_FRONT_PATH = "/Game/Aki/UI/UIResources/UiRogue/Prefabs/RogueMap/PnlMapPieceFront.PnlMapPieceFront";

		// Token: 0x04020EBB RID: 134843
		private const string RESOURCE_BACK_PATH = "/Game/Aki/UI/UIResources/UiRogue/Prefabs/RogueMap/PnlMapPieceBack.PnlMapPieceBack";

		// Token: 0x04020EBC RID: 134844
		protected MapRogueGameInfo GameInfo;

		// Token: 0x04020EBD RID: 134845
		protected List<UiPoolActor> UiPoolActorHandle = new List<UiPoolActor>();

		// Token: 0x04020EBE RID: 134846
		protected List<IGridCreateInfo> CreatePendingList = new List<IGridCreateInfo>();

		// Token: 0x04020EBF RID: 134847
		private int CurrentProcessingCount;

		// Token: 0x04020EC0 RID: 134848
		private float CreateDeltaTime;

		// Token: 0x04020EC1 RID: 134849
		private bool InCreating;

		// Token: 0x04020EC2 RID: 134850
		private readonly int DoubleClickIntervalTime = ConfigCommonParamById.GetIntConfig("MapRogueDoubleClickInterval").Value;

		// Token: 0x04020EC3 RID: 134851
		[Nullable(2)]
		private TimerHandle SingleClickTimerHandle;

		// Token: 0x04020EC4 RID: 134852
		private int InClickGridId = -1;

		// Token: 0x04020EC5 RID: 134853
		private bool IsClickUp;

		// Token: 0x04020EC6 RID: 134854
		private bool CanMove;

		// Token: 0x04020EC7 RID: 134855
		private bool CanCheck;

		// Token: 0x04020EC8 RID: 134856
		[Nullable(2)]
		protected LongPressButton ScaleUp;

		// Token: 0x04020EC9 RID: 134857
		[Nullable(2)]
		protected LongPressButton ScaleDown;

		// Token: 0x04020ECA RID: 134858
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		protected readonly List<ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase>> CachedSelectPanelList = new List<ValueTuple<MapRogueGridSelectBase, MapRogueGridSelectBase>>();

		// Token: 0x04020ECB RID: 134859
		private readonly int[] OccupiedSelectPanelIndex = new int[5];

		// Token: 0x04020ECC RID: 134860
		private int LatestSelectPanelIndex;
	}
}
