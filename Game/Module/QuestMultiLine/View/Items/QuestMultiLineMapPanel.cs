using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005330 RID: 21296
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineMapPanel : UiPanelBase
	{
		// Token: 0x0603655B RID: 222555 RVA: 0x00DB1E64 File Offset: 0x00DB0064
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUINiagara)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
		}

		// Token: 0x0603655C RID: 222556 RVA: 0x00DB1F70 File Offset: 0x00DB0170
		protected override void OnStart()
		{
			this.PathItem = base.GetItem(10);
			this.PathItem.SetUIActive(false);
			this.PathItemParent = base.GetItem(0);
			this.InitMapMove();
		}

		// Token: 0x0603655D RID: 222557 RVA: 0x00DB1F9F File Offset: 0x00DB019F
		protected override void OnBeforeDestroy()
		{
			this.StopComponentMoveAlongPath();
			this.StopAllPathDraw();
			this.DestroyMapMove();
		}

		// Token: 0x0603655E RID: 222558 RVA: 0x00DB1FB4 File Offset: 0x00DB01B4
		public void RefreshFightArea(Dictionary<int, bool> fightAreaMap)
		{
			int num = 3;
			for (int i = 0; i < 6; i++)
			{
				int name = num + i;
				UUIItem item = base.GetItem(name);
				if (item != null)
				{
					item.SetUIActive(fightAreaMap.GetValueOrDefault(i + 1, false));
				}
			}
		}

		// Token: 0x0603655F RID: 222559 RVA: 0x00DB1FF0 File Offset: 0x00DB01F0
		private void InitMapMove()
		{
			this.MapDraggableItem = base.GetItem(0);
			if (this.MapDraggableItem == null)
			{
				return;
			}
			AActor owner = this.MapDraggableItem.GetOwner();
			UUIDraggableComponent uuidraggableComponent = ((owner != null) ? owner.GetComponentByClass(UUIDraggableComponent.StaticClass()) : null) as UUIDraggableComponent;
			if (uuidraggableComponent == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				UUIItem uuiitem = texture;
				FVector fvector = new FVector(1f, 1f, 1f);
				uuiitem.SetUIRelativeScale3D(fvector);
			}
			this.ComputeCenterBounds();
			this.MoveComponent = new QuestMultiLineMapMoveComponent(uuidraggableComponent);
			this.MoveComponent.PointerUpExtraCallBack = new Action<ULGUIPointerEventData>(this.OnMapMoveEnd);
			this.RefreshMoveSpeed();
			this.CenterDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector2SetterDynamic>(new Action<FVector2D>(this.OnCenterTweenUpdate));
			FVector2D anchorOffset = this.MapDraggableItem.GetAnchorOffset();
			this.LastAnchorOffsetX = anchorOffset.X;
			this.LastAnchorOffsetY = anchorOffset.Y;
		}

		// Token: 0x06036560 RID: 222560 RVA: 0x00DB20D0 File Offset: 0x00DB02D0
		private void ComputeCenterBounds()
		{
			int num = Math.Max(0, ConfigCommonParamById.GetIntConfig("QuestMultiLineDragOffsetX").GetValueOrDefault(100));
			int num2 = Math.Max(0, ConfigCommonParamById.GetIntConfig("QuestMultiLineDragOffsetY").GetValueOrDefault(100));
			this.CenterSafeArea.MinX = (float)(-(float)num);
			this.CenterSafeArea.MaxX = (float)num;
			this.CenterSafeArea.MinY = (float)(-(float)num2);
			this.CenterSafeArea.MaxY = (float)num2;
		}

		// Token: 0x06036561 RID: 222561 RVA: 0x00DB214C File Offset: 0x00DB034C
		public void MapShow()
		{
			if (this.MoveComponent == null || this.IsMapInputBound)
			{
				return;
			}
			this.MoveComponent.AddGamepadEvent();
			this.MoveComponent.AddMoveListener(true);
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			this.IsMapInputBound = true;
		}

		// Token: 0x06036562 RID: 222562 RVA: 0x00DB21A4 File Offset: 0x00DB03A4
		public void OnTick(float delta)
		{
			if (this.MoveComponent == null || this.MapDraggableItem == null)
			{
				return;
			}
			this.MoveComponent.TickMove();
			FVector2D anchorOffset = this.MapDraggableItem.GetAnchorOffset();
			if (anchorOffset.X != this.LastAnchorOffsetX || anchorOffset.Y != this.LastAnchorOffsetY)
			{
				this.LastAnchorOffsetX = anchorOffset.X;
				this.LastAnchorOffsetY = anchorOffset.Y;
				this.RefreshAllDialogueSides();
			}
		}

		// Token: 0x06036563 RID: 222563 RVA: 0x00DB2214 File Offset: 0x00DB0414
		public void MapHide()
		{
			if (this.MoveComponent == null || !this.IsMapInputBound)
			{
				return;
			}
			this.MoveComponent.RemoveGamepadEvent();
			this.MoveComponent.RemoveMoveListener();
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			this.IsMapInputBound = false;
		}

		// Token: 0x06036564 RID: 222564 RVA: 0x00DB226C File Offset: 0x00DB046C
		private void RefreshMoveSpeed()
		{
			if (this.MoveComponent == null)
			{
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.MoveComponent.MoveSpeed = ConfigCommonParamById.GetFloatConfig("QuestMultiLineMapMoveSpeedGamepad").GetValueOrDefault(1f);
				return;
			}
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				this.MoveComponent.MoveSpeed = ConfigCommonParamById.GetFloatConfig("QuestMultiLineMapMoveSpeedKeyboard").GetValueOrDefault(1f);
			}
		}

		// Token: 0x06036565 RID: 222565 RVA: 0x00DB22DF File Offset: 0x00DB04DF
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshMoveSpeed();
		}

		// Token: 0x06036566 RID: 222566 RVA: 0x00DB22E7 File Offset: 0x00DB04E7
		private void OnMapMoveEnd(ULGUIPointerEventData eventData)
		{
			this.RefreshAllDialogueSides();
		}

		// Token: 0x06036567 RID: 222567 RVA: 0x00DB22EF File Offset: 0x00DB04EF
		private void OnCenterTweenUpdate(FVector2D value)
		{
			UUIItem mapDraggableItem = this.MapDraggableItem;
			if (mapDraggableItem != null)
			{
				mapDraggableItem.SetAnchorOffset(value);
			}
			this.RefreshAllDialogueSides();
		}

		// Token: 0x06036568 RID: 222568 RVA: 0x00DB2309 File Offset: 0x00DB0509
		private void KillCenterTweener()
		{
			if (this.CenterTweener != null)
			{
				this.CenterTweener.Kill(false);
				this.CenterTweener = null;
			}
		}

		// Token: 0x06036569 RID: 222569 RVA: 0x00DB2328 File Offset: 0x00DB0528
		private void RefreshAllDialogueSides()
		{
			if (this.ComponentItems == null)
			{
				return;
			}
			foreach (QuestMultiLineComponentItem questMultiLineComponentItem in this.ComponentItems)
			{
				questMultiLineComponentItem.RefreshDialogueSide();
			}
		}

		// Token: 0x0603656A RID: 222570 RVA: 0x00DB2384 File Offset: 0x00DB0584
		private void DestroyMapMove()
		{
			this.KillCenterTweener();
			this.MapHide();
			QuestMultiLineMapMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent != null)
			{
				moveComponent.Destroy();
			}
			this.MoveComponent = null;
			if (this.CenterDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector2D>(this.OnCenterTweenUpdate));
				this.CenterDelegate = null;
			}
		}

		// Token: 0x0603656B RID: 222571 RVA: 0x00DB23D8 File Offset: 0x00DB05D8
		private UniTask ClearComponents()
		{
			QuestMultiLineMapPanel.<ClearComponents>d__34 <ClearComponents>d__;
			<ClearComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearComponents>d__.<>4__this = this;
			<ClearComponents>d__.<>1__state = -1;
			<ClearComponents>d__.<>t__builder.Start<QuestMultiLineMapPanel.<ClearComponents>d__34>(ref <ClearComponents>d__);
			return <ClearComponents>d__.<>t__builder.Task;
		}

		// Token: 0x0603656C RID: 222572 RVA: 0x00DB241C File Offset: 0x00DB061C
		private UniTask ClearPathItems()
		{
			QuestMultiLineMapPanel.<ClearPathItems>d__35 <ClearPathItems>d__;
			<ClearPathItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ClearPathItems>d__.<>4__this = this;
			<ClearPathItems>d__.<>1__state = -1;
			<ClearPathItems>d__.<>t__builder.Start<QuestMultiLineMapPanel.<ClearPathItems>d__35>(ref <ClearPathItems>d__);
			return <ClearPathItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603656D RID: 222573 RVA: 0x00DB2460 File Offset: 0x00DB0660
		public UniTask RefreshComponents(List<QuestMultiLineComponentData> components)
		{
			QuestMultiLineMapPanel.<RefreshComponents>d__36 <RefreshComponents>d__;
			<RefreshComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshComponents>d__.<>4__this = this;
			<RefreshComponents>d__.components = components;
			<RefreshComponents>d__.<>1__state = -1;
			<RefreshComponents>d__.<>t__builder.Start<QuestMultiLineMapPanel.<RefreshComponents>d__36>(ref <RefreshComponents>d__);
			return <RefreshComponents>d__.<>t__builder.Task;
		}

		// Token: 0x0603656E RID: 222574 RVA: 0x00DB24AC File Offset: 0x00DB06AC
		public UniTask DrawComponentMovePath(List<QuestMultiLineComponentData> components)
		{
			QuestMultiLineMapPanel.<DrawComponentMovePath>d__37 <DrawComponentMovePath>d__;
			<DrawComponentMovePath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DrawComponentMovePath>d__.<>4__this = this;
			<DrawComponentMovePath>d__.components = components;
			<DrawComponentMovePath>d__.<>1__state = -1;
			<DrawComponentMovePath>d__.<>t__builder.Start<QuestMultiLineMapPanel.<DrawComponentMovePath>d__37>(ref <DrawComponentMovePath>d__);
			return <DrawComponentMovePath>d__.<>t__builder.Task;
		}

		// Token: 0x0603656F RID: 222575 RVA: 0x00DB24F8 File Offset: 0x00DB06F8
		public void StopComponentMoveAlongPath()
		{
			foreach (TimerHandle timerHandle in this.ComponentMoveTimerHandles.Values)
			{
				timerHandle.Remove();
			}
			this.ComponentMoveTimerHandles.Clear();
			foreach (Action action in this.ComponentMoveAbortCallbackMap.Values)
			{
				action();
			}
			this.ComponentMoveAbortCallbackMap.Clear();
		}

		// Token: 0x06036570 RID: 222576 RVA: 0x00DB25A8 File Offset: 0x00DB07A8
		public void PlayComponentMoveAlongPath(QuestMultiLineComponentData componentData, float? speedUiPxPerSec = null, [Nullable(2)] Action onComplete = null)
		{
			QuestMultiLineMapPanel.<>c__DisplayClass39_0 CS$<>8__locals1 = new QuestMultiLineMapPanel.<>c__DisplayClass39_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.onComplete = onComplete;
			CS$<>8__locals1.componentId = componentData.Id;
			TimerHandle timerHandle;
			if (this.ComponentMoveTimerHandles.TryGetValue(CS$<>8__locals1.componentId, out timerHandle))
			{
				timerHandle.Remove();
				this.ComponentMoveTimerHandles.Remove(CS$<>8__locals1.componentId);
			}
			float num = speedUiPxPerSec ?? ((float)componentData.MoveSpeed);
			List<QuestMultiLineComponentData> components = this.Components;
			int num2 = (components != null) ? components.FindIndex((QuestMultiLineComponentData c) => c.Id == CS$<>8__locals1.componentId) : -1;
			if (num2 < 0 || this.ComponentItems == null || num2 >= this.ComponentItems.Count)
			{
				return;
			}
			IntVector2D[] animMovePoint = componentData.AnimMovePoint;
			if (animMovePoint == null || animMovePoint.Length < 2)
			{
				return;
			}
			CS$<>8__locals1.curve = new CatmullRomCurve(animMovePoint);
			CS$<>8__locals1.arcLengthLookup = CatmullRomCurve.CreateArcLengthLookup(CS$<>8__locals1.curve, 100);
			CS$<>8__locals1.rootItem = this.ComponentItems[num2].GetRootItem();
			if (num <= 0f)
			{
				CS$<>8__locals1.<PlayComponentMoveAlongPath>g__ApplyPoint|1(1f);
				Action onComplete2 = CS$<>8__locals1.onComplete;
				if (onComplete2 == null)
				{
					return;
				}
				onComplete2();
				return;
			}
			else
			{
				CS$<>8__locals1.<PlayComponentMoveAlongPath>g__ApplyPoint|1(0f);
				CS$<>8__locals1.totalArcLength = CS$<>8__locals1.arcLengthLookup.TotalLength;
				if (CS$<>8__locals1.totalArcLength > 0.0)
				{
					CS$<>8__locals1.speedAlongCurvePxPerMs = num / 1000f;
					CS$<>8__locals1.traveledArcLength = 0.0;
					TimerHandle timerHandle2 = TimerSystem.Instance.Forever(delegate(float delta)
					{
						CS$<>8__locals1.traveledArcLength = Math.Min(CS$<>8__locals1.totalArcLength, CS$<>8__locals1.traveledArcLength + (double)(CS$<>8__locals1.speedAlongCurvePxPerMs * delta));
						double parameterByArcLength = CatmullRomCurve.GetParameterByArcLength(CS$<>8__locals1.arcLengthLookup, CS$<>8__locals1.traveledArcLength);
						base.<PlayComponentMoveAlongPath>g__ApplyPoint|1((float)parameterByArcLength);
						if (CS$<>8__locals1.traveledArcLength >= CS$<>8__locals1.totalArcLength)
						{
							TimerHandle timerHandle3;
							if (CS$<>8__locals1.<>4__this.ComponentMoveTimerHandles.TryGetValue(CS$<>8__locals1.componentId, out timerHandle3))
							{
								timerHandle3.Remove();
							}
							CS$<>8__locals1.<>4__this.ComponentMoveTimerHandles.Remove(CS$<>8__locals1.componentId);
							Action onComplete4 = CS$<>8__locals1.onComplete;
							if (onComplete4 == null)
							{
								return;
							}
							onComplete4();
						}
					}, 20f, 1f, null, "QuestMultiLineMapPanel.ComponentMoveCatmullRom", true);
					if (timerHandle2 != null)
					{
						this.ComponentMoveTimerHandles[CS$<>8__locals1.componentId] = timerHandle2;
					}
					return;
				}
				CS$<>8__locals1.<PlayComponentMoveAlongPath>g__ApplyPoint|1(1f);
				Action onComplete3 = CS$<>8__locals1.onComplete;
				if (onComplete3 == null)
				{
					return;
				}
				onComplete3();
				return;
			}
		}

		// Token: 0x06036571 RID: 222577 RVA: 0x00DB2770 File Offset: 0x00DB0970
		public UniTask DrawDebugPath(IReadOnlyList<global::Vector> points)
		{
			QuestMultiLineMapPanel.<DrawDebugPath>d__40 <DrawDebugPath>d__;
			<DrawDebugPath>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DrawDebugPath>d__.<>4__this = this;
			<DrawDebugPath>d__.points = points;
			<DrawDebugPath>d__.<>1__state = -1;
			<DrawDebugPath>d__.<>t__builder.Start<QuestMultiLineMapPanel.<DrawDebugPath>d__40>(ref <DrawDebugPath>d__);
			return <DrawDebugPath>d__.<>t__builder.Task;
		}

		// Token: 0x06036572 RID: 222578 RVA: 0x00DB27BC File Offset: 0x00DB09BC
		public void HideComponentsPath()
		{
			foreach (QuestMultiLinePathItem questMultiLinePathItem in this.PathItems)
			{
				questMultiLinePathItem.SetUiActive(false);
			}
		}

		// Token: 0x06036573 RID: 222579 RVA: 0x00DB2810 File Offset: 0x00DB0A10
		public void ClearAllComponentSelection()
		{
			if (this.ComponentItems == null)
			{
				return;
			}
			foreach (QuestMultiLineComponentItem questMultiLineComponentItem in this.ComponentItems)
			{
				questMultiLineComponentItem.RefreshSelected(false);
			}
		}

		// Token: 0x06036574 RID: 222580 RVA: 0x00DB286C File Offset: 0x00DB0A6C
		public void RefreshFullScreenNiagara(bool isActive, string path)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(9);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(isActive);
			}
			if (isActive)
			{
				base.SetNiagaraSystemByPath(path, uiNiagara, null);
			}
		}

		// Token: 0x06036575 RID: 222581 RVA: 0x00DB2898 File Offset: 0x00DB0A98
		public void HideAllForSequencer()
		{
			if (this.ComponentItems != null)
			{
				foreach (QuestMultiLineComponentItem questMultiLineComponentItem in this.ComponentItems)
				{
					questMultiLineComponentItem.SetVisibleForAnim(false);
				}
			}
			foreach (QuestMultiLinePathItem questMultiLinePathItem in this.PathItems)
			{
				questMultiLinePathItem.SetVisibleForAnim(false);
			}
			int num = 3;
			for (int i = 0; i < 6; i++)
			{
				UUIItem item = base.GetItem(num + i);
				if (item != null)
				{
					item.SetUIActive(false);
				}
			}
			UUINiagara uiNiagara = base.GetUiNiagara(9);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetUIActive(false);
		}

		// Token: 0x06036576 RID: 222582 RVA: 0x00DB2968 File Offset: 0x00DB0B68
		public UniTask PlayComponentAppearAsync(QuestMultiLineComponentData componentData)
		{
			QuestMultiLineMapPanel.<PlayComponentAppearAsync>d__45 <PlayComponentAppearAsync>d__;
			<PlayComponentAppearAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayComponentAppearAsync>d__.<>4__this = this;
			<PlayComponentAppearAsync>d__.componentData = componentData;
			<PlayComponentAppearAsync>d__.<>1__state = -1;
			<PlayComponentAppearAsync>d__.<>t__builder.Start<QuestMultiLineMapPanel.<PlayComponentAppearAsync>d__45>(ref <PlayComponentAppearAsync>d__);
			return <PlayComponentAppearAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036577 RID: 222583 RVA: 0x00DB29B4 File Offset: 0x00DB0BB4
		public UniTask PlayPathAppearAsync(QuestMultiLineComponentData componentData)
		{
			QuestMultiLineMapPanel.<PlayPathAppearAsync>d__46 <PlayPathAppearAsync>d__;
			<PlayPathAppearAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayPathAppearAsync>d__.<>4__this = this;
			<PlayPathAppearAsync>d__.componentData = componentData;
			<PlayPathAppearAsync>d__.<>1__state = -1;
			<PlayPathAppearAsync>d__.<>t__builder.Start<QuestMultiLineMapPanel.<PlayPathAppearAsync>d__46>(ref <PlayPathAppearAsync>d__);
			return <PlayPathAppearAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036578 RID: 222584 RVA: 0x00DB2A00 File Offset: 0x00DB0C00
		public void StopAllPathDraw()
		{
			foreach (QuestMultiLinePathItem questMultiLinePathItem in this.PathItemMap.Values)
			{
				questMultiLinePathItem.StopDraw();
			}
			foreach (Action action in this.PathDrawAbortCallbackMap.Values)
			{
				action();
			}
			this.PathDrawAbortCallbackMap.Clear();
		}

		// Token: 0x06036579 RID: 222585 RVA: 0x00DB2AA4 File Offset: 0x00DB0CA4
		public UniTask PlayComponentMoveAlongPathAsync(QuestMultiLineComponentData componentData, float? speedUiPxPerSec = null)
		{
			QuestMultiLineMapPanel.<PlayComponentMoveAlongPathAsync>d__48 <PlayComponentMoveAlongPathAsync>d__;
			<PlayComponentMoveAlongPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayComponentMoveAlongPathAsync>d__.<>4__this = this;
			<PlayComponentMoveAlongPathAsync>d__.componentData = componentData;
			<PlayComponentMoveAlongPathAsync>d__.speedUiPxPerSec = speedUiPxPerSec;
			<PlayComponentMoveAlongPathAsync>d__.<>1__state = -1;
			<PlayComponentMoveAlongPathAsync>d__.<>t__builder.Start<QuestMultiLineMapPanel.<PlayComponentMoveAlongPathAsync>d__48>(ref <PlayComponentMoveAlongPathAsync>d__);
			return <PlayComponentMoveAlongPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603657A RID: 222586 RVA: 0x00DB2AF8 File Offset: 0x00DB0CF8
		public void ShowFightArea(int areaId)
		{
			if (areaId < 1 || areaId > 6)
			{
				return;
			}
			int num = 3;
			UUIItem item = base.GetItem(num + (areaId - 1));
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}

		// Token: 0x0603657B RID: 222587 RVA: 0x00DB2B26 File Offset: 0x00DB0D26
		public void ShowScreenEffectInstant(string screenEffectPath)
		{
			this.RefreshFullScreenNiagara(!string.IsNullOrEmpty(screenEffectPath), screenEffectPath);
		}

		// Token: 0x0603657C RID: 222588 RVA: 0x00DB2B38 File Offset: 0x00DB0D38
		public Action ApplyZoomPivotOnComponent(QuestMultiLineComponentData componentData)
		{
			Action result = delegate()
			{
			};
			if (this.MapDraggableItem == null)
			{
				return result;
			}
			List<QuestMultiLineComponentData> components = this.Components;
			int num = (components != null) ? components.FindIndex((QuestMultiLineComponentData c) => c.Id == componentData.Id) : -1;
			if (num < 0 || this.ComponentItems == null || num >= this.ComponentItems.Count)
			{
				return result;
			}
			UUIItem draggable = this.MapDraggableItem;
			FVector2D oldPivot = draggable.GetPivot();
			UUIItem draggable3 = draggable;
			FVector2D fvector2D = new FVector2D(0f, 0f);
			FVector lguispaceAbsolutePositionByPivot = draggable3.GetLGUISpaceAbsolutePositionByPivot(fvector2D);
			UUIItem draggable2 = draggable;
			fvector2D = new FVector2D(1f, 1f);
			FVector lguispaceAbsolutePositionByPivot2 = draggable2.GetLGUISpaceAbsolutePositionByPivot(fvector2D);
			FVector lguispaceCenterAbsolutePosition = this.ComponentItems[num].GetRootItem().GetLGUISpaceCenterAbsolutePosition();
			float num2 = lguispaceAbsolutePositionByPivot2.X - lguispaceAbsolutePositionByPivot.X;
			float num3 = lguispaceAbsolutePositionByPivot2.Y - lguispaceAbsolutePositionByPivot.Y;
			if ((double)Math.Abs(num2) < 0.001 || (double)Math.Abs(num3) < 0.001)
			{
				return result;
			}
			FVector2D pivot = new FVector2D(QuestMultiLineUtils.ClampValue((lguispaceCenterAbsolutePosition.X - lguispaceAbsolutePositionByPivot.X) / num2, 0f, 1f), QuestMultiLineUtils.ClampValue((lguispaceCenterAbsolutePosition.Y - lguispaceAbsolutePositionByPivot.Y) / num3, 0f, 1f));
			draggable.SetPivot(pivot);
			return delegate()
			{
				if (this.MapDraggableItem == draggable)
				{
					draggable.SetPivot(oldPivot);
				}
			};
		}

		// Token: 0x0603657D RID: 222589 RVA: 0x00DB2CD8 File Offset: 0x00DB0ED8
		public UniTask PanMapToCenterOnComponentAsync(QuestMultiLineComponentData componentData, bool clampToSafeArea = true)
		{
			QuestMultiLineMapPanel.<PanMapToCenterOnComponentAsync>d__52 <PanMapToCenterOnComponentAsync>d__;
			<PanMapToCenterOnComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PanMapToCenterOnComponentAsync>d__.<>4__this = this;
			<PanMapToCenterOnComponentAsync>d__.componentData = componentData;
			<PanMapToCenterOnComponentAsync>d__.clampToSafeArea = clampToSafeArea;
			<PanMapToCenterOnComponentAsync>d__.<>1__state = -1;
			<PanMapToCenterOnComponentAsync>d__.<>t__builder.Start<QuestMultiLineMapPanel.<PanMapToCenterOnComponentAsync>d__52>(ref <PanMapToCenterOnComponentAsync>d__);
			return <PanMapToCenterOnComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603657E RID: 222590 RVA: 0x00DB2D2C File Offset: 0x00DB0F2C
		public void PlayAllComponentsAppearStart()
		{
			if (this.ComponentItems == null)
			{
				return;
			}
			foreach (QuestMultiLineComponentItem questMultiLineComponentItem in this.ComponentItems)
			{
				questMultiLineComponentItem.PlayAppearAsync();
			}
		}

		// Token: 0x0603657F RID: 222591 RVA: 0x00DB2D88 File Offset: 0x00DB0F88
		[NullableContext(2)]
		private QuestMultiLineComponentItem FindComponentItem(int componentId)
		{
			if (this.Components == null || this.ComponentItems == null)
			{
				return null;
			}
			int num = this.Components.FindIndex((QuestMultiLineComponentData c) => c.Id == componentId);
			if (num < 0)
			{
				return null;
			}
			return this.ComponentItems[num];
		}

		// Token: 0x06036580 RID: 222592 RVA: 0x00DB2DDE File Offset: 0x00DB0FDE
		public void SetComponentFunction(Action<QuestMultiLineComponentData> componentFunction)
		{
			this.ComponentFunction = componentFunction;
		}

		// Token: 0x06036581 RID: 222593 RVA: 0x00DB2DE8 File Offset: 0x00DB0FE8
		public void SetComponentsClickable(bool clickable)
		{
			if (this.ComponentItems == null)
			{
				return;
			}
			foreach (QuestMultiLineComponentItem questMultiLineComponentItem in this.ComponentItems)
			{
				questMultiLineComponentItem.SetClickable(clickable);
			}
		}

		// Token: 0x06036582 RID: 222594 RVA: 0x00DB2E44 File Offset: 0x00DB1044
		public void RefreshComponentsClickable()
		{
			if (this.ComponentItems == null || this.Components == null)
			{
				return;
			}
			int num = 0;
			while (num < this.ComponentItems.Count && num < this.Components.Count)
			{
				QuestMultiLineComponentData questMultiLineComponentData = this.Components[num];
				if (questMultiLineComponentData != null)
				{
					this.ComponentItems[num].SetClickable(QuestMultiLineUtils.IsComponentClickable(questMultiLineComponentData));
				}
				num++;
			}
		}

		// Token: 0x06036583 RID: 222595 RVA: 0x00DB2EB0 File Offset: 0x00DB10B0
		public void PanMapToCenterOnComponent(QuestMultiLineComponentData componentData, bool clampToSafeArea = true)
		{
			if (this.MapDraggableItem == null || Singleton<UiLayer>.Instance.UiRootItem == null)
			{
				return;
			}
			List<QuestMultiLineComponentData> components = this.Components;
			int num = (components != null) ? components.FindIndex((QuestMultiLineComponentData c) => c.Id == componentData.Id) : -1;
			if (num < 0 || this.ComponentItems == null || num >= this.ComponentItems.Count)
			{
				return;
			}
			FVector lguispaceCenterAbsolutePosition = this.ComponentItems[num].GetRootItem().GetLGUISpaceCenterAbsolutePosition();
			FVector lguispaceCenterAbsolutePosition2 = Singleton<UiLayer>.Instance.UiRootItem.GetLGUISpaceCenterAbsolutePosition();
			float num2 = lguispaceCenterAbsolutePosition2.X - lguispaceCenterAbsolutePosition.X;
			float num3 = lguispaceCenterAbsolutePosition2.Y - lguispaceCenterAbsolutePosition.Y;
			if (num2 == 0f && num3 == 0f)
			{
				return;
			}
			this.KillCenterTweener();
			FVector2D anchorOffset = this.MapDraggableItem.GetAnchorOffset();
			float num4 = anchorOffset.X + num2;
			float num5 = anchorOffset.Y + num3;
			if (clampToSafeArea)
			{
				num4 = QuestMultiLineUtils.ClampValue(num4, this.CenterSafeArea.MinX, this.CenterSafeArea.MaxX);
				num5 = QuestMultiLineUtils.ClampValue(num5, this.CenterSafeArea.MinY, this.CenterSafeArea.MaxY);
			}
			if (anchorOffset.X == num4 && anchorOffset.Y == num5)
			{
				return;
			}
			if (this.CenterDelegate != null)
			{
				ULTweener ultweener = ULTweenBPLibrary.Vector2To(GlobalData.World, this.CenterDelegate, anchorOffset, new FVector2D(num4, num5), 0.35f, 0f, LTweenEase.OutCubic);
				if (ultweener != null)
				{
					this.CenterTweener = ultweener;
					return;
				}
			}
			else
			{
				this.MapDraggableItem.SetAnchorOffset(new FVector2D(num4, num5));
			}
		}

		// Token: 0x06036584 RID: 222596 RVA: 0x00DB3040 File Offset: 0x00DB1240
		[NullableContext(2)]
		public UUIItem GetGuideComponentUiItem(int componentId)
		{
			if (this.Components == null || this.ComponentItems == null)
			{
				return null;
			}
			int num = this.Components.FindIndex((QuestMultiLineComponentData c) => c.Id == componentId);
			if (num < 0 || num >= this.ComponentItems.Count)
			{
				return null;
			}
			this.PanMapToCenterOnComponent(this.Components[num], true);
			return this.ComponentItems[num].GetRootItem();
		}

		// Token: 0x06036585 RID: 222597 RVA: 0x00DB30BC File Offset: 0x00DB12BC
		private void OnClickComponent(QuestMultiLineComponentData timePoint)
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				this.ComponentItems[i].RefreshSelected(this.Components[i] == timePoint);
			}
			this.PanMapToCenterOnComponent(timePoint, true);
			Action<QuestMultiLineComponentData> componentFunction = this.ComponentFunction;
			if (componentFunction == null)
			{
				return;
			}
			componentFunction(timePoint);
		}

		// Token: 0x06036586 RID: 222598 RVA: 0x00DB3118 File Offset: 0x00DB1318
		public bool TryClickComponentAtMousePosition()
		{
			if (this.ComponentItems == null || this.Components == null)
			{
				return false;
			}
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return false;
			}
			FKey key = new FKey(new FName(EKey.LeftMouseButton));
			if (!Singleton<Info>.Instance.IsInTouch() && !characterController.IsInputKeyDown(key) && !characterController.WasInputKeyJustReleased(key))
			{
				return false;
			}
			float num = 0f;
			float num2 = 0f;
			if (!characterController.GetMousePosition(ref num, ref num2))
			{
				return false;
			}
			for (int i = this.ComponentItems.Count - 1; i >= 0; i--)
			{
				UUIItem rootItem = this.ComponentItems[i].GetRootItem();
				if (rootItem != null && rootItem.IsUIActiveInHierarchy())
				{
					ULGUIBPLibrary.GetUIWorldPosForceUpdate(rootItem);
					UUIItem uuiitem = rootItem;
					bool bIsScaledByDPI = true;
					FVector2D fvector2D = new FVector2D(0f, 0f);
					FVector2D positionInViewportWithPivot = uuiitem.GetPositionInViewportWithPivot(bIsScaledByDPI, fvector2D);
					UUIItem uuiitem2 = rootItem;
					bool bIsScaledByDPI2 = true;
					fvector2D = new FVector2D(1f, 1f);
					FVector2D positionInViewportWithPivot2 = uuiitem2.GetPositionInViewportWithPivot(bIsScaledByDPI2, fvector2D);
					float num3 = Math.Min(positionInViewportWithPivot.X, positionInViewportWithPivot2.X);
					float num4 = Math.Max(positionInViewportWithPivot.X, positionInViewportWithPivot2.X);
					float num5 = Math.Min(positionInViewportWithPivot.Y, positionInViewportWithPivot2.Y);
					float num6 = Math.Max(positionInViewportWithPivot.Y, positionInViewportWithPivot2.Y);
					if (num >= num3 && num <= num4 && num2 >= num5 && num2 <= num6)
					{
						QuestMultiLineComponentData questMultiLineComponentData = this.Components[i];
						if (questMultiLineComponentData != null && QuestMultiLineUtils.IsComponentClickable(questMultiLineComponentData))
						{
							this.OnClickComponent(questMultiLineComponentData);
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0401F3E3 RID: 127971
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<QuestMultiLineComponentData> Components;

		// Token: 0x0401F3E4 RID: 127972
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<QuestMultiLineComponentItem> ComponentItems;

		// Token: 0x0401F3E5 RID: 127973
		private List<QuestMultiLinePathItem> PathItems = new List<QuestMultiLinePathItem>();

		// Token: 0x0401F3E6 RID: 127974
		private readonly Dictionary<int, QuestMultiLinePathItem> PathItemMap = new Dictionary<int, QuestMultiLinePathItem>();

		// Token: 0x0401F3E7 RID: 127975
		[Nullable(2)]
		private UUIItem PathItem;

		// Token: 0x0401F3E8 RID: 127976
		[Nullable(2)]
		private UUIItem PathItemParent;

		// Token: 0x0401F3E9 RID: 127977
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<QuestMultiLineComponentData> ComponentFunction;

		// Token: 0x0401F3EA RID: 127978
		private readonly Dictionary<int, TimerHandle> ComponentMoveTimerHandles = new Dictionary<int, TimerHandle>();

		// Token: 0x0401F3EB RID: 127979
		private readonly Dictionary<int, Action> ComponentMoveAbortCallbackMap = new Dictionary<int, Action>();

		// Token: 0x0401F3EC RID: 127980
		private readonly Dictionary<int, Action> PathDrawAbortCallbackMap = new Dictionary<int, Action>();

		// Token: 0x0401F3ED RID: 127981
		[Nullable(2)]
		private QuestMultiLineMapMoveComponent MoveComponent;

		// Token: 0x0401F3EE RID: 127982
		[Nullable(2)]
		private UUIItem MapDraggableItem;

		// Token: 0x0401F3EF RID: 127983
		private bool IsMapInputBound;

		// Token: 0x0401F3F0 RID: 127984
		private float LastAnchorOffsetX;

		// Token: 0x0401F3F1 RID: 127985
		private float LastAnchorOffsetY;

		// Token: 0x0401F3F2 RID: 127986
		[Nullable(2)]
		private ULTweener CenterTweener;

		// Token: 0x0401F3F3 RID: 127987
		[Nullable(2)]
		private FLTweenVector2SetterDynamic CenterDelegate;

		// Token: 0x0401F3F4 RID: 127988
		private IDragArea CenterSafeArea;
	}
}
