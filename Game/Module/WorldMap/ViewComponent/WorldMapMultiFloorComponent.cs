using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Ui.WorldMap.View.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B4C RID: 19276
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapMultiFloorComponent : MapComponent
	{
		// Token: 0x06032577 RID: 206199 RVA: 0x00C98E43 File Offset: 0x00C97043
		public WorldMapMultiFloorComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x1700866E RID: 34414
		// (get) Token: 0x06032578 RID: 206200 RVA: 0x00C98E4C File Offset: 0x00C9704C
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapMultiFloor;
			}
		}

		// Token: 0x1700866F RID: 34415
		// (get) Token: 0x06032579 RID: 206201 RVA: 0x00C98E4F File Offset: 0x00C9704F
		public int? SelectedMultiMapGroupId
		{
			get
			{
				return this.SelectedMultiMapGroupIdInner;
			}
		}

		// Token: 0x17008670 RID: 34416
		// (get) Token: 0x0603257A RID: 206202 RVA: 0x00C98E57 File Offset: 0x00C97057
		public int? SelectedMultiMapFloorId
		{
			get
			{
				return this.SelectedMultiMapFloorIdInner;
			}
		}

		// Token: 0x17008671 RID: 34417
		// (get) Token: 0x0603257B RID: 206203 RVA: 0x00C98E60 File Offset: 0x00C97060
		private WorldMapUiEntity WorldMapUiComponent
		{
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

		// Token: 0x0603257C RID: 206204 RVA: 0x00C98E9D File Offset: 0x00C9709D
		protected override void OnEnable()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSubMapChanged, new Action<int>(this.OnWorldMapSubMapChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.MultiMapUnlockChanged, new Action(this.OnMultiMapUnlockChanged));
		}

		// Token: 0x0603257D RID: 206205 RVA: 0x00C98ED7 File Offset: 0x00C970D7
		protected override void OnDisable()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapSubMapChanged, new Action<int>(this.OnWorldMapSubMapChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.MultiMapUnlockChanged, new Action(this.OnMultiMapUnlockChanged));
		}

		// Token: 0x0603257E RID: 206206 RVA: 0x00C98F11 File Offset: 0x00C97111
		public void Reset()
		{
			this.SelectedMultiMapGroupIdInner = null;
			this.SelectedMultiMapFloorIdInner = null;
			ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId = null;
			this.SetMultiMapMenuActive(false).Forget<bool>();
		}

		// Token: 0x0603257F RID: 206207 RVA: 0x00C98F48 File Offset: 0x00C97148
		public void InitMultiMap()
		{
			this.MultiMapMenuVisible = false;
			UUIItem multiMapFloorContainer = this.MultiMapFloorContainer;
			if (multiMapFloorContainer != null)
			{
				multiMapFloorContainer.SetUIActive(false);
			}
			if (!ModelBase<WorldMapModel>.Instance.IsMultiMapVisible)
			{
				return;
			}
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
			MultiMap? subMapConfigByAreaId = ConfigBase<MapConfig>.Instance.GetSubMapConfigByAreaId(currentAreaId);
			if (subMapConfigByAreaId != null)
			{
				int groupId = subMapConfigByAreaId.Value.GroupId;
				int floor = subMapConfigByAreaId.Value.Floor;
				this.SelectMultiMapFloor(currentAreaId, new int?(groupId), new int?(floor), false);
			}
		}

		// Token: 0x06032580 RID: 206208 RVA: 0x00C98FDC File Offset: 0x00C971DC
		public void UpdateMultiMap()
		{
			if (!ModelBase<WorldMapModel>.Instance.IsMultiMapVisible)
			{
				if (this.SelectedMultiMapGroupId != null || this.SelectedMultiMapFloorId != null)
				{
					this.DeSelectMultiMapFloor(true);
				}
				return;
			}
			global::Vector worldMapCenterPosition = this.WorldMapUiComponent.Map.GetWorldMapCenterPosition();
			int areaId = 0;
			MarkItem clickedItem = this.WorldMapUiComponent.ClickedItem;
			if (clickedItem != null && clickedItem.IsMultiMap())
			{
				int multiMapId = this.WorldMapUiComponent.ClickedItem.GetMultiMapId();
				MultiMap? subMapConfigById = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(multiMapId);
				if (subMapConfigById != null)
				{
					if (subMapConfigById.Value.AreaLength > 0)
					{
						areaId = subMapConfigById.Value.Area(0);
					}
					else
					{
						areaId = 0;
					}
				}
			}
			else if (worldMapCenterPosition != null)
			{
				areaId = this.WorldMapUiComponent.Map.GetMultiMapAreaIdByPosition(worldMapCenterPosition);
			}
			int num = (worldMapCenterPosition != null) ? this.WorldMapUiComponent.Map.GetSubMapGroupByPosition(worldMapCenterPosition) : 0;
			if (this.SelectedMultiMapGroupId.GetValueOrDefault() != num)
			{
				bool flag = (this.SelectedMultiMapFloorId ?? 0) == 0;
				if (flag)
				{
					if (num == 0)
					{
						this.SelectMultiMapFloor(areaId, null, null, true);
					}
					else
					{
						this.SelectMultiMapFloor(areaId, new int?(num), new int?(0), true);
					}
				}
			}
			if (worldMapCenterPosition != null)
			{
				this.WorldMapUiComponent.Map.UpdateCurrentAreaMapGroupId(worldMapCenterPosition);
			}
		}

		// Token: 0x06032581 RID: 206209 RVA: 0x00C99148 File Offset: 0x00C97348
		private int GetWorldMapFocusMultiMapAreaId()
		{
			MarkItem clickedItem = this.WorldMapUiComponent.ClickedItem;
			if (clickedItem != null && clickedItem.IsMultiMap())
			{
				int multiMapId = this.WorldMapUiComponent.ClickedItem.GetMultiMapId();
				MultiMap? subMapConfigById = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(multiMapId);
				if (subMapConfigById != null)
				{
					if (subMapConfigById.Value.AreaLength > 0)
					{
						return subMapConfigById.Value.Area(0);
					}
					return 0;
				}
			}
			global::Vector worldMapCenterPosition = this.WorldMapUiComponent.Map.GetWorldMapCenterPosition();
			if (worldMapCenterPosition == null)
			{
				return 0;
			}
			return this.WorldMapUiComponent.Map.GetMultiMapAreaIdByPosition(worldMapCenterPosition);
		}

		// Token: 0x06032582 RID: 206210 RVA: 0x00C991E0 File Offset: 0x00C973E0
		public void SelectMultiMapFloor(int areaId, int? multiMapGroupId = null, int? floor = null, bool playSubMapTween = true)
		{
			Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
			int areaId2 = (areaInfo != null) ? ModelBase<AreaModel>.Instance.GetAreaId(areaInfo.Value, new EAreaLevel?(EAreaLevel.FirstLevel)) : 0;
			bool multiMapMenuActive;
			if (!(multiMapMenuActive = ModelBase<MapModel>.Instance.CheckAreasUnlocked(areaId2, true)) || multiMapGroupId == null || floor == null)
			{
				this.SelectedMultiMapGroupIdInner = null;
				this.SelectedMultiMapFloorIdInner = null;
				ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId = null;
				multiMapMenuActive = false;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSelectMultiMap, 0);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSubMapChangedFromUpdate, 0);
				this.ChangeMultiMapFloor(0, false, new bool?(playSubMapTween));
				this.SetMultiMapMenuActive(multiMapMenuActive).Forget<bool>();
				return;
			}
			List<MultiMap> list = ConfigBase<MapConfig>.Instance.GetSubMapConfigByGroupId(multiMapGroupId.Value);
			list = (from multiMapFloorData in list
			where ModelBase<MapModel>.Instance.CheckUnlockMultiMapIds(multiMapFloorData.Id) || multiMapFloorData.Floor == 0
			select multiMapFloorData).ToList<MultiMap>();
			list.Sort((MultiMap a, MultiMap b) => b.Floor.CompareTo(a.Floor));
			if (list.Count == 1)
			{
				return;
			}
			int? selectedMultiMapFloorIdInner = null;
			int num = 0;
			if (floor != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					MultiMap multiMap = list[i];
					if (multiMap.Floor == floor.Value)
					{
						selectedMultiMapFloorIdInner = new int?(i);
						num = multiMap.Id;
						break;
					}
				}
			}
			this.SelectedMultiMapGroupIdInner = multiMapGroupId;
			this.SelectedMultiMapFloorIdInner = selectedMultiMapFloorIdInner;
			if (selectedMultiMapFloorIdInner != null)
			{
				ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId = new int?(num);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSelectMultiMap, num);
				this.ChangeMultiMapFloor(selectedMultiMapFloorIdInner.Value, false, new bool?(playSubMapTween));
			}
			this.SetMultiMapMenuActive(multiMapMenuActive).Forget<bool>();
			GenericLayout<WorldMapSubMapItem, MultiMap> multiMapFloorLayout = this.MultiMapFloorLayout;
			if (multiMapFloorLayout != null)
			{
				multiMapFloorLayout.RefreshByDataAsync(list, false, null).Forget();
			}
			GenericLayout<WorldMapSubMapItem, MultiMap> multiMapFloorLayout2 = this.MultiMapFloorLayout;
			if (multiMapFloorLayout2 != null)
			{
				multiMapFloorLayout2.SelectGridProxy(selectedMultiMapFloorIdInner.GetValueOrDefault(), false);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSubMapChangedFromUpdate, selectedMultiMapFloorIdInner.GetValueOrDefault());
		}

		// Token: 0x06032583 RID: 206211 RVA: 0x00C99418 File Offset: 0x00C97618
		public void DeSelectMultiMapFloor(bool playSubMapTween = true)
		{
			int worldMapFocusMultiMapAreaId = this.GetWorldMapFocusMultiMapAreaId();
			this.SelectMultiMapFloor(worldMapFocusMultiMapAreaId, null, null, playSubMapTween);
		}

		// Token: 0x06032584 RID: 206212 RVA: 0x00C99448 File Offset: 0x00C97648
		[NullableContext(0)]
		public UniTask<bool> SetMultiMapMenuActive(bool active)
		{
			WorldMapMultiFloorComponent.<SetMultiMapMenuActive>d__23 <SetMultiMapMenuActive>d__;
			<SetMultiMapMenuActive>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SetMultiMapMenuActive>d__.<>4__this = this;
			<SetMultiMapMenuActive>d__.active = active;
			<SetMultiMapMenuActive>d__.<>1__state = -1;
			<SetMultiMapMenuActive>d__.<>t__builder.Start<WorldMapMultiFloorComponent.<SetMultiMapMenuActive>d__23>(ref <SetMultiMapMenuActive>d__);
			return <SetMultiMapMenuActive>d__.<>t__builder.Task;
		}

		// Token: 0x06032585 RID: 206213 RVA: 0x00C99494 File Offset: 0x00C97694
		private void OnWorldMapSubMapChanged(int floor)
		{
			this.OnChangeMultiMapFloor(floor, null);
		}

		// Token: 0x06032586 RID: 206214 RVA: 0x00C994B4 File Offset: 0x00C976B4
		private void OnMultiMapUnlockChanged()
		{
			int? selectedMultiMapFloorIdInner = this.SelectedMultiMapFloorIdInner;
			if (this.SelectedMultiMapGroupId != null && selectedMultiMapFloorIdInner != null)
			{
				int? num = selectedMultiMapFloorIdInner;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					this.WorldMapUiComponent.Map.ShowSubMapTile(this.SelectedMultiMapGroupId.Value, selectedMultiMapFloorIdInner.Value, true);
					return;
				}
			}
		}

		// Token: 0x06032587 RID: 206215 RVA: 0x00C99520 File Offset: 0x00C97720
		private void OnChangeMultiMapFloor(int floor, bool? playShowSubMapTween = null)
		{
			this.ChangeMultiMapFloor(floor, true, new bool?(playShowSubMapTween.GetValueOrDefault(true)));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSubMapChangedFromUpdate, floor);
		}

		// Token: 0x06032588 RID: 206216 RVA: 0x00C99548 File Offset: 0x00C97748
		private void ChangeMultiMapFloor(int floor, bool updateMultiMapFloor, bool? playShowSubMapTween = null)
		{
			if (this.MultiMapMenuVisible)
			{
				GenericLayout<WorldMapSubMapItem, MultiMap> multiMapFloorLayout = this.MultiMapFloorLayout;
				if (multiMapFloorLayout != null)
				{
					multiMapFloorLayout.DeselectCurrentGridProxy();
				}
				GenericLayout<WorldMapSubMapItem, MultiMap> multiMapFloorLayout2 = this.MultiMapFloorLayout;
				if (multiMapFloorLayout2 != null)
				{
					multiMapFloorLayout2.SelectGridProxy(floor, false);
				}
			}
			this.SelectedMultiMapFloorIdInner = new int?(floor);
			if (this.SelectedMultiMapGroupId == null || floor == 0)
			{
				this.WorldMapUiComponent.Map.HideSubMapTile();
				if (updateMultiMapFloor)
				{
					this.UpdateMultiMap();
					return;
				}
			}
			else
			{
				this.WorldMapUiComponent.Map.ShowSubMapTile(this.SelectedMultiMapGroupId.Value, floor, !playShowSubMapTween.GetValueOrDefault(true));
			}
		}

		// Token: 0x0401D682 RID: 120450
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public GenericLayout<WorldMapSubMapItem, MultiMap> MultiMapFloorLayout;

		// Token: 0x0401D683 RID: 120451
		private int? SelectedMultiMapGroupIdInner;

		// Token: 0x0401D684 RID: 120452
		private int? SelectedMultiMapFloorIdInner;

		// Token: 0x0401D685 RID: 120453
		public UUIItem MultiMapFloorContainer;

		// Token: 0x0401D686 RID: 120454
		public TWorldMapPlaySequenceFunction WorldMapViewPlaySequenceFunction;

		// Token: 0x0401D687 RID: 120455
		private bool MultiMapMenuVisible;
	}
}
