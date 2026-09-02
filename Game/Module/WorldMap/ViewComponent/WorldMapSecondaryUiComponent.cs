using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle;
using CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B53 RID: 19283
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapSecondaryUiComponent : MapComponent
	{
		// Token: 0x060325C8 RID: 206280 RVA: 0x00C9A1FE File Offset: 0x00C983FE
		public WorldMapSecondaryUiComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17008682 RID: 34434
		// (get) Token: 0x060325C9 RID: 206281 RVA: 0x00C9A212 File Offset: 0x00C98412
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapSecondaryUi;
			}
		}

		// Token: 0x17008683 RID: 34435
		// (get) Token: 0x060325CA RID: 206282 RVA: 0x00C9A218 File Offset: 0x00C98418
		// (set) Token: 0x060325CB RID: 206283 RVA: 0x00C9A245 File Offset: 0x00C98445
		public bool ExtraSecondaryUiOpen
		{
			get
			{
				return this.PropertyMap.TryGet(0, false, true).AsT2;
			}
			set
			{
				this.PropertyMap.Set(0, value);
			}
		}

		// Token: 0x17008684 RID: 34436
		// (get) Token: 0x060325CC RID: 206284 RVA: 0x00C9A25F File Offset: 0x00C9845F
		public bool IsSecondaryUiOpening
		{
			get
			{
				return this.ExtraSecondaryUiOpen || this.IsInternalSecondaryUiOpen();
			}
		}

		// Token: 0x17008685 RID: 34437
		// (get) Token: 0x060325CD RID: 206285 RVA: 0x00C9A274 File Offset: 0x00C98474
		[Nullable(2)]
		private WorldMapUiEntity WorldMapUiComponent
		{
			[NullableContext(2)]
			get
			{
				WorldMapUiEntity worldMapUiEntity = base.Parent.AsT3 as WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					base.LogError(ELogAuthor.LYX, "[地图系统]->二级界面组件没有附加到容器下！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return worldMapUiEntity;
			}
		}

		// Token: 0x060325CE RID: 206286 RVA: 0x00C9A2B4 File Offset: 0x00C984B4
		public bool IsInternalSecondaryUiOpen()
		{
			using (OrderedDictionary<ESecondaryPanel, WorldMapSecondaryUi>.ValueCollection.Enumerator enumerator = this.SecondaryPanels.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsUiCloseComplete)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060325CF RID: 206287 RVA: 0x00C9A314 File Offset: 0x00C98514
		protected override void OnRemove()
		{
			this.SecondaryPanels.Clear();
		}

		// Token: 0x060325D0 RID: 206288 RVA: 0x00C9A324 File Offset: 0x00C98524
		public void ShowPanel(MarkItem clickedItem, UUIItem parent, int customPanelMode = 1)
		{
			ESecondaryPanel secondaryUiType = clickedItem.GetSecondaryUiType();
			this.OpenUi(secondaryUiType, parent, new object[]
			{
				clickedItem,
				customPanelMode
			});
		}

		// Token: 0x060325D1 RID: 206289 RVA: 0x00C9A354 File Offset: 0x00C98554
		public void ShowMarkMenu(UUIItem parent, List<MarkItem> markItems)
		{
			this.OpenUi(ESecondaryPanel.MarkMenuPanel, parent, new object[]
			{
				markItems
			});
		}

		// Token: 0x060325D2 RID: 206290 RVA: 0x00C9A369 File Offset: 0x00C98569
		public void ShowTrackMenu(UUIItem parent, List<ITrackMenuItemData> markItems)
		{
			this.OpenUi(ESecondaryPanel.TrackMenuPanel, parent, new object[]
			{
				markItems
			});
		}

		// Token: 0x060325D3 RID: 206291 RVA: 0x00C9A37F File Offset: 0x00C9857F
		public void ShowWorldMapNotePanel(UUIItem parent, List<IMapNoteParams> mapNoteParamList)
		{
			this.OpenUi(ESecondaryPanel.WorldMapNotePanel, parent, new object[]
			{
				mapNoteParamList
			});
		}

		// Token: 0x060325D4 RID: 206292 RVA: 0x00C9A395 File Offset: 0x00C98595
		public void ShowMapMarkTogglePanel(UUIItem parent, [Nullable(new byte[]
		{
			2,
			1
		})] List<IMapMarkToggleItemData> markToggleDataList = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IMapMarkProgressItemData> markProgressDataList = null)
		{
			this.OpenUi(ESecondaryPanel.MapMarkTogglePanel, parent, new object[]
			{
				markToggleDataList,
				markProgressDataList
			});
		}

		// Token: 0x060325D5 RID: 206293 RVA: 0x00C9A3AF File Offset: 0x00C985AF
		public void ShowMapPeriodicActivityPanel(UUIItem parent)
		{
			this.OpenUi(ESecondaryPanel.ActivityListPanel, parent, Array.Empty<object>());
		}

		// Token: 0x060325D6 RID: 206294 RVA: 0x00C9A3C0 File Offset: 0x00C985C0
		public void ShowQuickNavigate(UUIItem parent, List<MarkItem> navigateMarkItems)
		{
			this.OpenUi(ESecondaryPanel.QuickNavigatePanel, parent, new object[]
			{
				navigateMarkItems
			}).Forget();
		}

		// Token: 0x060325D7 RID: 206295 RVA: 0x00C9A3DC File Offset: 0x00C985DC
		public UniTask OpenUi(ESecondaryPanel type, UUIItem parent, params object[] parameters)
		{
			WorldMapSecondaryUiComponent.<OpenUi>d__21 <OpenUi>d__;
			<OpenUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenUi>d__.<>4__this = this;
			<OpenUi>d__.type = type;
			<OpenUi>d__.parent = parent;
			<OpenUi>d__.parameters = parameters;
			<OpenUi>d__.<>1__state = -1;
			<OpenUi>d__.<>t__builder.Start<WorldMapSecondaryUiComponent.<OpenUi>d__21>(ref <OpenUi>d__);
			return <OpenUi>d__.<>t__builder.Task;
		}

		// Token: 0x060325D8 RID: 206296 RVA: 0x00C9A438 File Offset: 0x00C98638
		public void CloseUi(Action callback, bool playSequence = true)
		{
			foreach (WorldMapSecondaryUi worldMapSecondaryUi in this.SecondaryPanels.Values)
			{
				UUIItem rootItem = worldMapSecondaryUi.GetRootItem();
				if (worldMapSecondaryUi.IsUiOpen && rootItem != null)
				{
					worldMapSecondaryUi.CloseWithCallBack(callback, playSequence);
					break;
				}
			}
		}

		// Token: 0x060325D9 RID: 206297 RVA: 0x00C9A4A8 File Offset: 0x00C986A8
		[NullableContext(2)]
		public UUIItem GetSecondaryPanelGuideFocusUiItem(ESecondaryPanel panelIndex)
		{
			WorldMapSecondaryUi worldMapSecondaryUi;
			if (this.SecondaryPanels.TryGetValue(panelIndex, out worldMapSecondaryUi))
			{
				return worldMapSecondaryUi.GetGuideFocusUiItem();
			}
			return null;
		}

		// Token: 0x060325DA RID: 206298 RVA: 0x00C9A4D0 File Offset: 0x00C986D0
		public void AllSecondaryPanelsUpdateMap()
		{
			BaseMap map = this.WorldMapUiComponent.Map;
			foreach (WorldMapSecondaryUi worldMapSecondaryUi in this.SecondaryPanels.Values)
			{
				worldMapSecondaryUi.UpdateMap(map);
			}
		}

		// Token: 0x060325DB RID: 206299 RVA: 0x00C9A534 File Offset: 0x00C98734
		public bool CheckSecondaryUiIsOpen(ESecondaryPanel type)
		{
			WorldMapSecondaryUi worldMapSecondaryUi;
			return this.SecondaryPanels.TryGetValue(type, out worldMapSecondaryUi) && worldMapSecondaryUi.IsUiOpen;
		}

		// Token: 0x0401D69A RID: 120474
		private readonly OrderedDictionary<ESecondaryPanel, WorldMapSecondaryUi> SecondaryPanels = new OrderedDictionary<ESecondaryPanel, WorldMapSecondaryUi>();

		// Token: 0x0200AC1D RID: 44061
		[NullableContext(0)]
		public static class EPropertyType
		{
			// Token: 0x04035881 RID: 219265
			public const int ExtraSecondaryUiOpen = 0;
		}
	}
}
