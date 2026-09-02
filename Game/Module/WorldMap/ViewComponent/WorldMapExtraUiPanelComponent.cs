using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant;
using CSharpScript.Game.Module.Map.View.SubView;
using CSharpScript.Game.Module.PhantomArena.Prepare.Entrance;
using CSharpScript.Game.Module.Sheriff.View.Map;
using CSharpScript.Game.Module.WorldMap.SubViews;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B49 RID: 19273
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapExtraUiPanelComponent : MapComponent
	{
		// Token: 0x060324FE RID: 206078 RVA: 0x00C9637B File Offset: 0x00C9457B
		public WorldMapExtraUiPanelComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x1700864E RID: 34382
		// (get) Token: 0x060324FF RID: 206079 RVA: 0x00C96396 File Offset: 0x00C94596
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapExtraUiPanel;
			}
		}

		// Token: 0x1700864F RID: 34383
		// (get) Token: 0x06032500 RID: 206080 RVA: 0x00C9639C File Offset: 0x00C9459C
		[Nullable(2)]
		public WorldMapUiEntity WorldMapUiComponent
		{
			[NullableContext(2)]
			get
			{
				WorldMapUiEntity worldMapUiEntity = base.Parent.AsT3 as WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					base.LogError(ELogAuthor.LRX, "[地图系统]->二级界面组件没有附加到容器下！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return worldMapUiEntity;
			}
		}

		// Token: 0x06032501 RID: 206081 RVA: 0x00C963D9 File Offset: 0x00C945D9
		protected override void OnAdd()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapAfterChangeMap, new Action(this.OnWorldMapAfterChangeMap));
		}

		// Token: 0x06032502 RID: 206082 RVA: 0x00C963F7 File Offset: 0x00C945F7
		protected override void OnRemove()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapAfterChangeMap, new Action(this.OnWorldMapAfterChangeMap));
			this.CloseAllUi();
		}

		// Token: 0x06032503 RID: 206083 RVA: 0x00C9641B File Offset: 0x00C9461B
		private void OnWorldMapAfterChangeMap()
		{
			this.RefreshDragAndScaleParam();
		}

		// Token: 0x06032504 RID: 206084 RVA: 0x00C96424 File Offset: 0x00C94624
		public UniTask OpenUi(EWorldMapExtraUiPanelName panelName, UUIItem parent, [Nullable(2)] object param = null)
		{
			WorldMapExtraUiPanelComponent.<OpenUi>d__16 <OpenUi>d__;
			<OpenUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenUi>d__.<>4__this = this;
			<OpenUi>d__.panelName = panelName;
			<OpenUi>d__.parent = parent;
			<OpenUi>d__.param = param;
			<OpenUi>d__.<>1__state = -1;
			<OpenUi>d__.<>t__builder.Start<WorldMapExtraUiPanelComponent.<OpenUi>d__16>(ref <OpenUi>d__);
			return <OpenUi>d__.<>t__builder.Task;
		}

		// Token: 0x06032505 RID: 206085 RVA: 0x00C96480 File Offset: 0x00C94680
		public unsafe void CloseUi(WorldMapExtraUiPanel panel)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Map;
			ELogAuthor author = ELogAuthor.CB;
			string message = "关闭地图外部二级界面";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("panelName", panel.PanelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ComponentId", panel.ComponentId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (worldMapExtraUiPanel != null)
			{
				if (worldMapExtraUiPanel != panel)
				{
					global::Stack<WorldMapExtraUiPanel> stack = new global::Stack<WorldMapExtraUiPanel>();
					bool flag = false;
					while (this.ExtraUiPanelStack.Size > 0)
					{
						WorldMapExtraUiPanel worldMapExtraUiPanel2 = this.ExtraUiPanelStack.Pop();
						if (worldMapExtraUiPanel2 == panel)
						{
							flag = true;
							IL_F7:
							while (stack.Size > 0)
							{
								this.ExtraUiPanelStack.Push(stack.Pop());
							}
							if (flag)
							{
								this.OnBeforeCloseUiView();
								panel.Destroy(null);
								goto IL_175;
							}
							goto IL_175;
						}
						else
						{
							stack.Push(worldMapExtraUiPanel2);
						}
					}
					goto IL_F7;
				}
				this.ExtraUiPanelStack.Pop();
				this.OnBeforeCloseUiView();
				panel.Destroy(null);
				IL_175:
				this.OnCloseUiView(panel);
				if (this.ExtraUiPanelStack.Size > 0)
				{
					WorldMapExtraUiPanel worldMapExtraUiPanel3 = this.ExtraUiPanelStack.Peek();
					if (worldMapExtraUiPanel3 == null)
					{
						return;
					}
					worldMapExtraUiPanel3.Show(null);
				}
				return;
			}
			ELogAuthor author2 = ELogAuthor.CB;
			string message2 = "关闭地图外部二级界面失败，栈中没有元素";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("panelName", panel.PanelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ComponentId", panel.ComponentId);
			base.LogError(author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}

		// Token: 0x06032506 RID: 206086 RVA: 0x00C9662D File Offset: 0x00C9482D
		public void CloseAllUi()
		{
			while (this.ExtraUiPanelStack.Size > 0)
			{
				this.CloseUi(this.ExtraUiPanelStack.Peek());
			}
		}

		// Token: 0x06032507 RID: 206087 RVA: 0x00C96650 File Offset: 0x00C94850
		private void OnBeforeOpenUiView()
		{
			this.RefreshExtraMark();
			this.RefreshMultiMapVisible();
			this.RefreshFogParam(true);
			this.RefreshPlayerMark();
			this.RefreshDragAndScaleParam();
			this.RefreshMapRangeVisible();
		}

		// Token: 0x06032508 RID: 206088 RVA: 0x00C96677 File Offset: 0x00C94877
		private void OnBeforeCloseUiView()
		{
			this.RefreshExtraMark();
		}

		// Token: 0x06032509 RID: 206089 RVA: 0x00C96680 File Offset: 0x00C94880
		private void OnOpenUiView(WorldMapExtraUiPanel panel)
		{
			Action<WorldMapExtraUiPanel> onExtraUiViewOpened = this.OnExtraUiViewOpened;
			if (onExtraUiViewOpened != null)
			{
				onExtraUiViewOpened(panel);
			}
			this.RefreshSlider(true);
			this.RefreshCanAutoPilotTrack(true);
			this.PlayBackgroundMusic(panel);
			ModelBase<WorldMapModel>.Instance.WorldExtraUiCount++;
			Singleton<EventSystem>.Instance.Emit<EWorldMapExtraUiPanelName>(EEventName.OnWorldMapExtraUiOpen, panel.PanelName);
			this.UpdateMarkItems();
		}

		// Token: 0x0603250A RID: 206090 RVA: 0x00C966E4 File Offset: 0x00C948E4
		private void OnCloseUiView(WorldMapExtraUiPanel panel)
		{
			Action onExtraUiViewClosed = this.OnExtraUiViewClosed;
			if (onExtraUiViewClosed != null)
			{
				onExtraUiViewClosed();
			}
			this.RefreshSlider(false);
			this.RefreshDragAndScaleParam();
			this.RefreshFogParam(false);
			this.RefreshPlayerMark();
			this.RefreshCanAutoPilotTrack(false);
			this.RefreshMapRangeVisible();
			this.RefreshMultiMapVisible();
			this.StopBackgroundMusic(panel);
			ModelBase<WorldMapModel>.Instance.WorldExtraUiCount--;
			Singleton<EventSystem>.Instance.Emit<EWorldMapExtraUiPanelName>(EEventName.OnWorldMapExtraUiClose, panel.PanelName);
			this.UpdateMarkItems();
		}

		// Token: 0x0603250B RID: 206091 RVA: 0x00C96764 File Offset: 0x00C94964
		private void PlayBackgroundMusic(WorldMapExtraUiPanel panel)
		{
			string backgroundMusicAudioEvent = panel.GetBackgroundMusicAudioEvent();
			AActor rootActor = panel.GetRootActor();
			if (!string.IsNullOrEmpty(backgroundMusicAudioEvent) && rootActor != null)
			{
				Singleton<UiAudioModel>.Instance.SetLoopAudioEventShow(panel.ComponentId, rootActor, backgroundMusicAudioEvent);
			}
		}

		// Token: 0x0603250C RID: 206092 RVA: 0x00C9679C File Offset: 0x00C9499C
		private void StopBackgroundMusic(WorldMapExtraUiPanel panel)
		{
			string backgroundMusicAudioEvent = panel.GetBackgroundMusicAudioEvent();
			AActor rootActor = panel.GetRootActor();
			if (!string.IsNullOrEmpty(backgroundMusicAudioEvent) && rootActor != null)
			{
				Singleton<UiAudioModel>.Instance.SetLoopAudioEventDestroy(panel.ComponentId, rootActor, backgroundMusicAudioEvent);
			}
		}

		// Token: 0x17008650 RID: 34384
		// (get) Token: 0x0603250D RID: 206093 RVA: 0x00C967D4 File Offset: 0x00C949D4
		public bool IsExtraUiViewOpened
		{
			get
			{
				return this.ExtraUiPanelStack.Size > 0;
			}
		}

		// Token: 0x0603250E RID: 206094 RVA: 0x00C967E4 File Offset: 0x00C949E4
		private void RefreshSlider(bool isOpen)
		{
			if (this.WorldMapUiComponent == null)
			{
				return;
			}
			if (isOpen && this.ExtraUiPanelStack.Size == 1)
			{
				this.OriginalScaleSlider = this.WorldMapUiComponent.ScaleComponent.ScaleSlider;
			}
			UUISliderComponent targetSlider = this.GetTargetSlider();
			this.WorldMapUiComponent.ScaleComponent.ScaleSlider = targetSlider;
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			if (worldMapUiComponent == null)
			{
				return;
			}
			worldMapUiComponent.ScaleComponent.Initialize();
		}

		// Token: 0x0603250F RID: 206095 RVA: 0x00C9684E File Offset: 0x00C94A4E
		[NullableContext(2)]
		private UUISliderComponent GetTargetSlider()
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			return ((worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.GetScaleSlider() : null) ?? this.OriginalScaleSlider;
		}

		// Token: 0x06032510 RID: 206096 RVA: 0x00C96884 File Offset: 0x00C94A84
		public bool ClickEmpty(Vector2D clickedPosition)
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (worldMapExtraUiPanel == null || !worldMapExtraUiPanel.OnClickEmpty(clickedPosition))
			{
				return false;
			}
			ControllerBase<WorldMapController>.Instance.ClearFocalMarkItem();
			return true;
		}

		// Token: 0x06032511 RID: 206097 RVA: 0x00C968C8 File Offset: 0x00C94AC8
		public bool ClickSingleMark(MarkItem clickedItem)
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			ClickMarkItemRet clickMarkItemRet = (worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.OnClickMarkItem(clickedItem) : null;
			if (clickMarkItemRet == null || !clickMarkItemRet.IsExtraUiLogic)
			{
				return false;
			}
			if (clickMarkItemRet.IsNeedSelected)
			{
				this.ClearClickItem();
				this.SetClickItem(clickedItem);
			}
			return true;
		}

		// Token: 0x06032512 RID: 206098 RVA: 0x00C96928 File Offset: 0x00C94B28
		public bool ClickMarks(List<MarkItem> clickedItems, Vector2D clickedPosition)
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (worldMapExtraUiPanel == null || !worldMapExtraUiPanel.OnClickMarks(clickedItems, clickedPosition))
			{
				return false;
			}
			ControllerBase<WorldMapController>.Instance.ClearFocalMarkItem();
			return true;
		}

		// Token: 0x06032513 RID: 206099 RVA: 0x00C9696C File Offset: 0x00C94B6C
		public int? GetCustomClickRange()
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (worldMapExtraUiPanel == null)
			{
				return null;
			}
			return worldMapExtraUiPanel.GetCustomClickRange();
		}

		// Token: 0x06032514 RID: 206100 RVA: 0x00C969A8 File Offset: 0x00C94BA8
		public void SetClickItem(MarkItem clickedItem)
		{
			if (clickedItem.IsOutOfBound)
			{
				WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
				if (worldMapUiComponent != null)
				{
					worldMapUiComponent.MoveComponent.SetMapPosition(clickedItem, true, EClampType.ClampToSafeArea, null, null, true, true);
				}
			}
			this.WorldMapUiComponent.ClickedItem = clickedItem;
			WorldMapUiEntity worldMapUiComponent2 = this.WorldMapUiComponent;
			if (worldMapUiComponent2 != null)
			{
				MarkItem clickedItem2 = worldMapUiComponent2.ClickedItem;
				if (clickedItem2 != null)
				{
					clickedItem2.SetSelected(true);
				}
			}
			WorldMapUiEntity worldMapUiComponent3 = this.WorldMapUiComponent;
			if (worldMapUiComponent3 != null)
			{
				worldMapUiComponent3.UpdateSingleMarkItem(clickedItem, true);
			}
			WorldMapUiEntity worldMapUiComponent4 = this.WorldMapUiComponent;
			bool flag;
			if (worldMapUiComponent4 == null)
			{
				flag = false;
			}
			else
			{
				MarkItem clickedItem3 = worldMapUiComponent4.ClickedItem;
				flag = ((clickedItem3 != null) ? new bool?(clickedItem3.IsMultiMap()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				WorldMapUiEntity worldMapUiComponent5 = this.WorldMapUiComponent;
				int? num;
				if (worldMapUiComponent5 == null)
				{
					num = null;
				}
				else
				{
					MarkItem clickedItem4 = worldMapUiComponent5.ClickedItem;
					num = ((clickedItem4 != null) ? new int?(clickedItem4.GetMultiMapId()) : null);
				}
				int? num2 = num;
				int valueOrDefault = num2.GetValueOrDefault();
				MultiMap? subMapConfigById = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(valueOrDefault);
				if (subMapConfigById != null)
				{
					int num3;
					if (subMapConfigById.Value.AreaLength <= 0)
					{
						WorldMapUiEntity worldMapUiComponent6 = this.WorldMapUiComponent;
						num3 = ((worldMapUiComponent6 != null) ? worldMapUiComponent6.Map.GetWorldMapCenterAreaId() : 0);
					}
					else
					{
						num3 = subMapConfigById.Value.Area(0);
					}
					int areaId = num3;
					int groupId = subMapConfigById.Value.GroupId;
					int floor = subMapConfigById.Value.Floor;
					WorldMapUiEntity worldMapUiComponent7 = this.WorldMapUiComponent;
					if (worldMapUiComponent7 == null)
					{
						return;
					}
					worldMapUiComponent7.MultiFloorComponent.SelectMultiMapFloor(areaId, new int?(groupId), new int?(floor), true);
					return;
				}
			}
			else
			{
				WorldMapUiEntity worldMapUiComponent8 = this.WorldMapUiComponent;
				if (worldMapUiComponent8 == null)
				{
					return;
				}
				worldMapUiComponent8.MultiFloorComponent.DeSelectMultiMapFloor(true);
			}
		}

		// Token: 0x06032515 RID: 206101 RVA: 0x00C96B58 File Offset: 0x00C94D58
		public void ClearClickItem()
		{
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			if (((worldMapUiComponent != null) ? worldMapUiComponent.ClickedItem : null) != null)
			{
				this.WorldMapUiComponent.ClickedItem.IsIgnoreScaleShow = false;
				this.WorldMapUiComponent.ClickedItem.SetSelected(false);
				this.WorldMapUiComponent.UpdateSingleMarkItem(this.WorldMapUiComponent.ClickedItem, true);
				this.WorldMapUiComponent.ClickedItem = null;
			}
		}

		// Token: 0x06032516 RID: 206102 RVA: 0x00C96BBE File Offset: 0x00C94DBE
		public bool OnPointerDrag(Vector2D delta)
		{
			ControllerBase<WorldMapController>.Instance.ClearFocalMarkItem();
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			return worldMapExtraUiPanel != null && worldMapExtraUiPanel.OnPointerDrag(delta);
		}

		// Token: 0x17008651 RID: 34385
		// (get) Token: 0x06032517 RID: 206103 RVA: 0x00C96BF8 File Offset: 0x00C94DF8
		public bool IsEnableMapScale
		{
			get
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
				return worldMapExtraUiPanel == null || worldMapExtraUiPanel.GetIsEnableMapScale();
			}
		}

		// Token: 0x17008652 RID: 34386
		// (get) Token: 0x06032518 RID: 206104 RVA: 0x00C96C30 File Offset: 0x00C94E30
		public bool IsEnableMapCursorButton
		{
			get
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
				return worldMapExtraUiPanel == null || worldMapExtraUiPanel.GetIsEnableMapCursorButton();
			}
		}

		// Token: 0x17008653 RID: 34387
		// (get) Token: 0x06032519 RID: 206105 RVA: 0x00C96C65 File Offset: 0x00C94E65
		public float MapDefaultScale
		{
			get
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
				if (worldMapExtraUiPanel == null)
				{
					return 0f;
				}
				return worldMapExtraUiPanel.GetDefaultMapScale();
			}
		}

		// Token: 0x17008654 RID: 34388
		// (get) Token: 0x0603251A RID: 206106 RVA: 0x00C96C92 File Offset: 0x00C94E92
		public float MapMaxScale
		{
			get
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
				if (worldMapExtraUiPanel == null)
				{
					return 0f;
				}
				return worldMapExtraUiPanel.GetMaxMapScale();
			}
		}

		// Token: 0x17008655 RID: 34389
		// (get) Token: 0x0603251B RID: 206107 RVA: 0x00C96CBF File Offset: 0x00C94EBF
		public float MapMinScale
		{
			get
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
				if (worldMapExtraUiPanel == null)
				{
					return 0f;
				}
				return worldMapExtraUiPanel.GetMinMapScale();
			}
		}

		// Token: 0x17008656 RID: 34390
		// (get) Token: 0x0603251C RID: 206108 RVA: 0x00C96CEC File Offset: 0x00C94EEC
		[Nullable(2)]
		public ITileNum TileNum
		{
			[NullableContext(2)]
			get
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
				IEnumerable<string> enumerable = (worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.GetTileRange() : null;
				if (enumerable == null)
				{
					return null;
				}
				TileNum tileNum = new TileNum
				{
					MaxX = int.MinValue,
					MinX = int.MaxValue,
					MaxY = int.MinValue,
					MinY = int.MaxValue
				};
				foreach (string text in enumerable)
				{
					string[] array = text.Split('_', StringSplitOptions.None);
					int val = int.Parse(array[0]);
					int val2 = int.Parse(array[1]);
					tileNum.MaxX = Math.Max(val, tileNum.MaxX);
					tileNum.MinX = Math.Min(val, tileNum.MinX);
					tileNum.MaxY = Math.Max(val2, tileNum.MaxY);
					tileNum.MinY = Math.Min(val2, tileNum.MinY);
				}
				return tileNum;
			}
		}

		// Token: 0x17008657 RID: 34391
		// (get) Token: 0x0603251D RID: 206109 RVA: 0x00C96DF4 File Offset: 0x00C94FF4
		public bool IsShowPlayerMark
		{
			get
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
				return worldMapExtraUiPanel == null || worldMapExtraUiPanel.GetIsShowPlayerMark();
			}
		}

		// Token: 0x0603251E RID: 206110 RVA: 0x00C96E20 File Offset: 0x00C95020
		public void RefreshScaleParam()
		{
			if (this.MapDefaultScale == 0f || this.MapMaxScale == 0f || this.MapMinScale == 0f)
			{
				ModelBase<WorldMapModel>.Instance.ResetMapScale();
				WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
				if (worldMapUiComponent == null)
				{
					return;
				}
				worldMapUiComponent.ScaleComponent.Initialize();
				return;
			}
			else
			{
				ModelBase<WorldMapModel>.Instance.MapScaleMax = this.MapMaxScale / this.MapDefaultScale;
				ModelBase<WorldMapModel>.Instance.MapScaleMin = this.MapMinScale / this.MapDefaultScale;
				float mapScale = this.MapDefaultScale / 100f;
				ModelBase<WorldMapModel>.Instance.MapScale = mapScale;
				WorldMapUiEntity worldMapUiComponent2 = this.WorldMapUiComponent;
				if (worldMapUiComponent2 == null)
				{
					return;
				}
				worldMapUiComponent2.ScaleComponent.Initialize();
				return;
			}
		}

		// Token: 0x0603251F RID: 206111 RVA: 0x00C96ED0 File Offset: 0x00C950D0
		private void RefreshDragParam()
		{
			if (this.TileNum == null)
			{
				WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
				if (worldMapUiComponent != null)
				{
					BaseMap map = worldMapUiComponent.Map;
					if (map != null)
					{
						map.ResetDraggableParams();
					}
				}
				MapModel instance = ModelBase<MapModel>.Instance;
				if (instance != null)
				{
					instance.ClearExtraUiTileRange(EMapType.WorldMap);
				}
			}
			else
			{
				WorldMapUiEntity worldMapUiComponent2 = this.WorldMapUiComponent;
				if (worldMapUiComponent2 != null)
				{
					BaseMap map2 = worldMapUiComponent2.Map;
					if (map2 != null)
					{
						map2.UpdateDraggableParams(this.TileNum);
					}
				}
				MapModel instance2 = ModelBase<MapModel>.Instance;
				if (instance2 != null)
				{
					instance2.SetExtraUiTileRange(EMapType.WorldMap, this.TileNum);
				}
			}
			WorldMapUiEntity worldMapUiComponent3 = this.WorldMapUiComponent;
			if (worldMapUiComponent3 == null)
			{
				return;
			}
			worldMapUiComponent3.RecalculateMapSize();
		}

		// Token: 0x06032520 RID: 206112 RVA: 0x00C96F5D File Offset: 0x00C9515D
		private void RefreshPlayerMark()
		{
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			if (worldMapUiComponent == null)
			{
				return;
			}
			worldMapUiComponent.InitSelfPlayerMark();
		}

		// Token: 0x06032521 RID: 206113 RVA: 0x00C96F6F File Offset: 0x00C9516F
		public void RefreshDragAndScaleParam()
		{
			this.RefreshDragParam();
			this.RefreshScaleParam();
		}

		// Token: 0x06032522 RID: 206114 RVA: 0x00C96F80 File Offset: 0x00C95180
		private void RefreshFogParam(bool isOpen)
		{
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			MapTileMgr mapTileMgr;
			if (worldMapUiComponent == null)
			{
				mapTileMgr = null;
			}
			else
			{
				BaseMap map = worldMapUiComponent.Map;
				mapTileMgr = ((map != null) ? map.MapTileMgr : null);
			}
			MapTileMgr mapTileMgr2 = mapTileMgr;
			if (mapTileMgr2 == null)
			{
				return;
			}
			if (isOpen && this.ExtraUiPanelStack.Size == 1)
			{
				this.OriginalOpenFogSet = mapTileMgr2.OpenFogSet;
			}
			int[] array;
			if (this.ExtraUiPanelStack.Size <= 0)
			{
				array = null;
			}
			else
			{
				WorldMapExtraUiPanel worldMapExtraUiPanel = this.ExtraUiPanelStack.Peek();
				array = ((worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.GetUnlockFogs() : null);
			}
			int[] array2 = array;
			if (array2 != null && this.OriginalOpenFogSet != null)
			{
				HashSet<int> hashSet = new HashSet<int>();
				foreach (int num in this.OriginalOpenFogSet)
				{
					if (array2.Contains(num))
					{
						hashSet.Add(num);
					}
				}
				mapTileMgr2.OpenFogSet = hashSet;
			}
			else
			{
				mapTileMgr2.OpenFogSet = this.OriginalOpenFogSet;
			}
			mapTileMgr2.UpdateOpenArea();
		}

		// Token: 0x06032523 RID: 206115 RVA: 0x00C97078 File Offset: 0x00C95278
		public void UpdateMarkItems()
		{
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			if (worldMapUiComponent == null)
			{
				return;
			}
			worldMapUiComponent.UpdateMarkItems(new bool?(true));
		}

		// Token: 0x06032524 RID: 206116 RVA: 0x00C97090 File Offset: 0x00C95290
		private void HideAllMarkItems()
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (((worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.GetExtraMarkTypes() : null) != null)
			{
				MapModel instance = ModelBase<MapModel>.Instance;
				if (instance != null)
				{
					instance.InitExtraUiMarkType(EMapType.WorldMap);
				}
			}
			if (((worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.GetExtraMarkIds() : null) != null)
			{
				MapModel instance2 = ModelBase<MapModel>.Instance;
				if (instance2 != null)
				{
					instance2.InitExtraUiMarkId(EMapType.WorldMap);
				}
			}
			this.UpdateMarkItems();
		}

		// Token: 0x06032525 RID: 206117 RVA: 0x00C97100 File Offset: 0x00C95300
		public void RefreshExtraMark()
		{
			MapModel instance = ModelBase<MapModel>.Instance;
			if (instance != null)
			{
				instance.ClearExtraUiMarkType(EMapType.WorldMap);
			}
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			EMarkType[] array = (worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.GetExtraMarkTypes() : null;
			if (array != null)
			{
				foreach (EMarkType markType in array)
				{
					MapModel instance2 = ModelBase<MapModel>.Instance;
					if (instance2 != null)
					{
						instance2.AddExtraUiMarkType(EMapType.WorldMap, markType);
					}
					WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
					Dictionary<int, MarkItem> dictionary;
					if (worldMapUiComponent == null)
					{
						dictionary = null;
					}
					else
					{
						BaseMap map = worldMapUiComponent.Map;
						dictionary = ((map != null) ? map.GetMarkItemsByType(markType, true) : null);
					}
					Dictionary<int, MarkItem> dictionary2 = dictionary;
					if (dictionary2 != null)
					{
						foreach (KeyValuePair<int, MarkItem> keyValuePair in dictionary2)
						{
							int num;
							MarkItem markItem;
							keyValuePair.Deconstruct(out num, out markItem);
							markItem.NeedPlayStartSequence = true;
						}
					}
				}
			}
			MapModel instance3 = ModelBase<MapModel>.Instance;
			if (instance3 != null)
			{
				instance3.ClearExtraUiMarkId(EMapType.WorldMap);
			}
			int[] array3 = (worldMapExtraUiPanel != null) ? worldMapExtraUiPanel.GetExtraMarkIds() : null;
			if (array3 != null)
			{
				foreach (int markId in array3)
				{
					MapModel instance4 = ModelBase<MapModel>.Instance;
					if (instance4 != null)
					{
						instance4.AddExtraUiMarkId(EMapType.WorldMap, markId);
					}
				}
			}
		}

		// Token: 0x06032526 RID: 206118 RVA: 0x00C9724C File Offset: 0x00C9544C
		private void RefreshCanAutoPilotTrack(bool isOpen)
		{
			if (isOpen && this.ExtraUiPanelStack.Size == 1)
			{
				this.OriginalIsCanAutoPilotTrack = ModelBase<WorldMapModel>.Instance.IsCanAutoPilotTrack;
			}
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (worldMapExtraUiPanel == null)
			{
				ModelBase<WorldMapModel>.Instance.IsCanAutoPilotTrack = this.OriginalIsCanAutoPilotTrack;
				return;
			}
			ModelBase<WorldMapModel>.Instance.IsCanAutoPilotTrack = worldMapExtraUiPanel.GetIsCanAutoPilotTrack();
		}

		// Token: 0x06032527 RID: 206119 RVA: 0x00C972BC File Offset: 0x00C954BC
		private void RefreshMapRangeVisible()
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			ModelBase<WorldMapModel>.Instance.IsMapRangeVisible = (worldMapExtraUiPanel == null || worldMapExtraUiPanel.GetIsMapRangeVisible());
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			if (worldMapUiComponent == null)
			{
				return;
			}
			BaseMap map = worldMapUiComponent.Map;
			if (map == null)
			{
				return;
			}
			MapRangePanel mapRangePanel = map.MapRangePanel;
			if (mapRangePanel == null)
			{
				return;
			}
			mapRangePanel.CheckExploreMarkRangeInfo();
		}

		// Token: 0x06032528 RID: 206120 RVA: 0x00C97320 File Offset: 0x00C95520
		private void RefreshMultiMapVisible()
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			ModelBase<WorldMapModel>.Instance.IsMultiMapVisible = (worldMapExtraUiPanel == null || worldMapExtraUiPanel.GetIsMultiMapVisible());
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			if (worldMapUiComponent == null)
			{
				return;
			}
			worldMapUiComponent.MultiFloorComponent.UpdateMultiMap();
		}

		// Token: 0x06032529 RID: 206121 RVA: 0x00C97378 File Offset: 0x00C95578
		public bool HideTopPanel()
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (worldMapExtraUiPanel != null)
			{
				worldMapExtraUiPanel.Hide(null);
				return true;
			}
			return false;
		}

		// Token: 0x0603252A RID: 206122 RVA: 0x00C973B0 File Offset: 0x00C955B0
		public bool ShowTopPanel()
		{
			WorldMapExtraUiPanel worldMapExtraUiPanel = (this.ExtraUiPanelStack.Size > 0) ? this.ExtraUiPanelStack.Peek() : null;
			if (worldMapExtraUiPanel != null)
			{
				worldMapExtraUiPanel.Show(null);
				return true;
			}
			return false;
		}

		// Token: 0x0603252B RID: 206123 RVA: 0x00C973E8 File Offset: 0x00C955E8
		// Note: this type is marked as 'beforefieldinit'.
		static WorldMapExtraUiPanelComponent()
		{
			Dictionary<EWorldMapExtraUiPanelName, ValueTuple<WorldMapExtraUiPanelComponent.ExtraUiPanelCtor, string>> dictionary = new Dictionary<EWorldMapExtraUiPanelName, ValueTuple<WorldMapExtraUiPanelComponent.ExtraUiPanelCtor, string>>();
			dictionary[EWorldMapExtraUiPanelName.PhantomArenaMapEntrance] = new ValueTuple<WorldMapExtraUiPanelComponent.ExtraUiPanelCtor, string>((EWorldMapExtraUiPanelName panelName, WorldMapExtraUiPanelComponent component) => new PhantomArenaMapEntrancePanel(panelName, component), "UiView_SoundRemnantArenaMap");
			dictionary[EWorldMapExtraUiPanelName.SheriffMapPanel] = new ValueTuple<WorldMapExtraUiPanelComponent.ExtraUiPanelCtor, string>((EWorldMapExtraUiPanelName panelName, WorldMapExtraUiPanelComponent component) => new SheriffMapPanel(panelName, component), "UiView_SkyEyesMap");
			WorldMapExtraUiPanelComponent.ExtraUiPanelInfoMap = dictionary;
		}

		// Token: 0x0401D661 RID: 120417
		private readonly global::Stack<WorldMapExtraUiPanel> ExtraUiPanelStack = new global::Stack<WorldMapExtraUiPanel>();

		// Token: 0x0401D662 RID: 120418
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<WorldMapExtraUiPanel> OnExtraUiViewOpened;

		// Token: 0x0401D663 RID: 120419
		[Nullable(2)]
		public Action OnExtraUiViewClosed;

		// Token: 0x0401D664 RID: 120420
		[Nullable(2)]
		private UUISliderComponent OriginalScaleSlider;

		// Token: 0x0401D665 RID: 120421
		[Nullable(2)]
		private HashSet<int> OriginalOpenFogSet;

		// Token: 0x0401D666 RID: 120422
		private bool OriginalIsCanAutoPilotTrack = true;

		// Token: 0x0401D667 RID: 120423
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EWorldMapExtraUiPanelName, ValueTuple<WorldMapExtraUiPanelComponent.ExtraUiPanelCtor, string>> ExtraUiPanelInfoMap;

		// Token: 0x0200AC14 RID: 44052
		// (Invoke) Token: 0x0604BC5D RID: 310365
		[NullableContext(0)]
		private delegate WorldMapExtraUiPanel ExtraUiPanelCtor(EWorldMapExtraUiPanelName panelName, WorldMapExtraUiPanelComponent extraUiPanelComponent);
	}
}
