using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.View.BaseMap;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B4E RID: 19278
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapQuickNavigateComponent : MapComponent
	{
		// Token: 0x06032594 RID: 206228 RVA: 0x00C996EF File Offset: 0x00C978EF
		public WorldMapQuickNavigateComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17008677 RID: 34423
		// (get) Token: 0x06032595 RID: 206229 RVA: 0x00C996F8 File Offset: 0x00C978F8
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapQuickNavigate;
			}
		}

		// Token: 0x06032596 RID: 206230 RVA: 0x00C996FB File Offset: 0x00C978FB
		protected override void OnEnable()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapNavigate, new Action<NavigateMark>(this.EventWorldMapNavigate));
		}

		// Token: 0x06032597 RID: 206231 RVA: 0x00C99719 File Offset: 0x00C97919
		protected override void OnDisable()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapNavigate, new Action<NavigateMark>(this.EventWorldMapNavigate));
		}

		// Token: 0x06032598 RID: 206232 RVA: 0x00C99737 File Offset: 0x00C97937
		private void EventWorldMapNavigate(NavigateMark navigate)
		{
			this.NavigateTo(navigate.MarkId, navigate.MarkType, navigate.Focal.GetValueOrDefault(), navigate.FocusTween.GetValueOrDefault(true), navigate.NeedTempShow.GetValueOrDefault());
		}

		// Token: 0x06032599 RID: 206233 RVA: 0x00C99770 File Offset: 0x00C97970
		public bool NavigateTo(int markId, EMarkType markType, bool focal = false, bool focusTween = true, bool needTempShow = false)
		{
			WorldMapChangeMapDiffParams navigateMarkIsNeedChangeMap = this.GetNavigateMarkIsNeedChangeMap(markId, markType);
			if (navigateMarkIsNeedChangeMap.MapId != null)
			{
				Singleton<EventSystem>.Instance.Emit<WorldMapChangeMapParams>(EEventName.ChangeWorldMap, new WorldMapChangeMapParams
				{
					MarkId = markId,
					MarkType = markType,
					MapId = navigateMarkIsNeedChangeMap.MapId.Value,
					Focal = new bool?(focal),
					FocusTween = new bool?(focusTween),
					Gravity = navigateMarkIsNeedChangeMap.Gravity,
					NeedTempShow = new bool?(needTempShow)
				});
				return true;
			}
			Singleton<EventSystem>.Instance.Emit<int, EMarkType, bool, bool, bool?>(EEventName.WorldMapFocalMarkItem, markId, markType, focal, focusTween, new bool?(needTempShow));
			return false;
		}

		// Token: 0x0603259A RID: 206234 RVA: 0x00C99818 File Offset: 0x00C97A18
		public WorldMapChangeMapDiffParams GetNavigateMarkIsNeedChangeMap(int markId, EMarkType markType)
		{
			BaseMap map = (base.Parent.AsT3 as WorldMapUiEntity).Map;
			MarkItem markItem = map.GetMarkItem(markType, markId);
			int num = (markItem != null) ? markItem.MapId : ModelBase<MapModel>.Instance.GetMarkMapConfigId(markId, markType);
			EMapGravityDirection emapGravityDirection = (markItem != null) ? markItem.MarkItemEntity.GamePlay.Gravity : ModelBase<MapModel>.Instance.GetMarkMapGravity(markId, markType);
			int? num2 = (num != map.MapId) ? new int?(num) : null;
			emapGravityDirection = ModelBase<WorldMapModel>.Instance.GetFinalWorldMapGravity(num2 ?? map.MapId, new EMapGravityDirection?(emapGravityDirection));
			EMapGravityDirection? emapGravityDirection2 = (emapGravityDirection != map.MapGravity) ? new EMapGravityDirection?(emapGravityDirection) : null;
			if (emapGravityDirection2 != null)
			{
				return new WorldMapChangeMapDiffParams
				{
					MapId = new int?(num2 ?? map.MapId),
					Gravity = new EMapGravityDirection?(emapGravityDirection2.Value)
				};
			}
			return new WorldMapChangeMapDiffParams
			{
				MapId = num2
			};
		}
	}
}
