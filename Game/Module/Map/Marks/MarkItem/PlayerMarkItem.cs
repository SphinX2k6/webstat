using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005852 RID: 22610
	[NullableContext(1)]
	[Nullable(0)]
	public class PlayerMarkItem : MarkItem
	{
		// Token: 0x170092C5 RID: 37573
		// (get) Token: 0x06039804 RID: 235524 RVA: 0x00E97595 File Offset: 0x00E95795
		// (set) Token: 0x06039805 RID: 235525 RVA: 0x00E9759D File Offset: 0x00E9579D
		public override int MarkId
		{
			get
			{
				return this.PlayerId;
			}
			set
			{
				this.PlayerId = value;
			}
		}

		// Token: 0x170092C6 RID: 37574
		// (get) Token: 0x06039806 RID: 235526 RVA: 0x00E975A6 File Offset: 0x00E957A6
		public override EMarkType MarkType
		{
			get
			{
				return EMarkType.OtherPlayers;
			}
		}

		// Token: 0x170092C7 RID: 37575
		// (get) Token: 0x06039807 RID: 235527 RVA: 0x00E975AA File Offset: 0x00E957AA
		public override int MapId
		{
			get
			{
				return this.PlayerInfo.MapId;
			}
		}

		// Token: 0x06039808 RID: 235528 RVA: 0x00E975B8 File Offset: 0x00E957B8
		public PlayerMarkItem(UUIItem parent, PlayerMarkCreateInfo playerInfo, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(parent, mapType, markScale, trackSource)
		{
			this.PlayerId = playerInfo.PlayerId;
			this.PlayerIndex = playerInfo.PlayerIndex;
			this.PlayerStartPosition = global::Vector.Create(playerInfo.Position);
			this.PlayerInfo = playerInfo;
		}

		// Token: 0x06039809 RID: 235529 RVA: 0x00E97610 File Offset: 0x00E95810
		protected override void OnInitialize()
		{
			if (base.MapType == EMapType.MiniMap)
			{
				float configScale = 0.8f;
				base.SetConfigScale(configScale);
			}
			string resourceId = WorldMapDefine.OnlinePlayerIconPathList[this.PlayerIndex - 1];
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.IconPath = resourcePath;
			this.BindEvent();
			base.SetTrackData(this.PlayerStartPosition);
			this.UpdatePlayerGravity();
			this.UpdateVisibleRelativeState();
			this.IsHide = false;
		}

		// Token: 0x0603980A RID: 235530 RVA: 0x00E9767F File Offset: 0x00E9587F
		public override void Destroy(bool recycleToPoolImmediately = true)
		{
			this.UnBindEvent();
			base.Destroy(recycleToPoolImmediately);
		}

		// Token: 0x0603980B RID: 235531 RVA: 0x00E9768E File Offset: 0x00E9588E
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.PlayerMarkItemView;
		}

		// Token: 0x0603980C RID: 235532 RVA: 0x00E97692 File Offset: 0x00E95892
		[PreserveBaseOverrides]
		protected new virtual PlayerMarkItemView CreateView()
		{
			return new PlayerMarkItemView(this);
		}

		// Token: 0x0603980D RID: 235533 RVA: 0x00E9769C File Offset: 0x00E9589C
		protected override void UpdateVisibleRelativeState()
		{
			MarkItemEntity markItemEntity = base.MarkItemEntity;
			MarkViewLifeCircleComponent viewLifeCircle = markItemEntity.ViewLifeCircle;
			bool flag = !base.IsInConsistentDistrict(false);
			bool flag2 = base.CheckCanShowInGravityLayer(this.IsTracking());
			flag = (flag && flag2);
			base.IsCanShowView = (flag && this.CheckCanShowView() && !this.IsHide);
			viewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.GravityReverse, markItemEntity.GamePlay.CanShowGravityChildIcon);
			viewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.MarkView, base.IsCanShowView);
		}

		// Token: 0x0603980E RID: 235534 RVA: 0x00E9770E File Offset: 0x00E9590E
		private void BindEvent()
		{
			Singleton<EventSystem>.Instance.Add<int, global::Vector>(EEventName.ScenePlayerLocationChanged, new Action<int, global::Vector>(this.OnPositionChanged));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.ScenePlayerMarkItemStateChange, new Action<int, bool>(this.OnMarkItemStateChange));
		}

		// Token: 0x0603980F RID: 235535 RVA: 0x00E97748 File Offset: 0x00E95948
		private void UnBindEvent()
		{
			if (Singleton<EventSystem>.Instance.Has<int, global::Vector>(EEventName.ScenePlayerLocationChanged, new Action<int, global::Vector>(this.OnPositionChanged)))
			{
				Singleton<EventSystem>.Instance.Remove<int, global::Vector>(EEventName.ScenePlayerLocationChanged, new Action<int, global::Vector>(this.OnPositionChanged));
			}
			if (Singleton<EventSystem>.Instance.Has<int, bool>(EEventName.ScenePlayerMarkItemStateChange, new Action<int, bool>(this.OnMarkItemStateChange)))
			{
				Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.ScenePlayerMarkItemStateChange, new Action<int, bool>(this.OnMarkItemStateChange));
			}
		}

		// Token: 0x06039810 RID: 235536 RVA: 0x00E977C7 File Offset: 0x00E959C7
		private void OnMarkItemStateChange(int playerId, bool isShow)
		{
			if (this.PlayerId == playerId)
			{
				this.IsHide = true;
			}
		}

		// Token: 0x06039811 RID: 235537 RVA: 0x00E977D9 File Offset: 0x00E959D9
		private void OnPositionChanged(int playerId, global::Vector location)
		{
			if (this.PlayerId == playerId)
			{
				base.SetTrackData(location);
				this.UpdatePlayerGravity();
				if (this.IsHide)
				{
					this.IsHide = false;
				}
			}
		}

		// Token: 0x06039812 RID: 235538 RVA: 0x00E97808 File Offset: 0x00E95A08
		private void UpdatePlayerGravity()
		{
			SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(this.PlayerId);
			long? num;
			if (teamPlayerData == null)
			{
				num = null;
			}
			else
			{
				SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
				if (currentGroup == null)
				{
					num = null;
				}
				else
				{
					SceneTeamRole currentRole = currentGroup.GetCurrentRole();
					num = ((currentRole != null) ? new long?(currentRole.CreatureDataId) : null);
				}
			}
			long? num2 = num;
			if (num2 == null)
			{
				bool flag = ModelBase<WorldMapModel>.Instance.IsGravityMap(this.MapId);
				base.MarkItemEntity.GamePlay.Gravity = (flag ? EMapGravityDirection.Down : EMapGravityDirection.All);
				return;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num2.Value);
			bool? flag2;
			if (entity == null)
			{
				flag2 = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				if (entity2 == null)
				{
					flag2 = null;
				}
				else
				{
					BaseMoveComponent component = entity2.GetComponent<BaseMoveComponent>();
					flag2 = ((component != null) ? new bool?(component.IsStandardGravity) : null);
				}
			}
			bool? flag3 = flag2;
			base.MarkItemEntity.GamePlay.Gravity = (flag3.GetValueOrDefault() ? EMapGravityDirection.Down : EMapGravityDirection.Up);
		}

		// Token: 0x06039813 RID: 235539 RVA: 0x00E9790C File Offset: 0x00E95B0C
		public override bool CheckCanShowView()
		{
			return true;
		}

		// Token: 0x06039814 RID: 235540 RVA: 0x00E9790F File Offset: 0x00E95B0F
		public override bool GetInteractiveFlag()
		{
			return false;
		}

		// Token: 0x06039815 RID: 235541 RVA: 0x00E97914 File Offset: 0x00E95B14
		public override void SetTitleText(UUIText uiText)
		{
			WorldTeamPlayerFightInfo worldTeamPlayerFightInfo = ModelBase<OnlineModel>.Instance.GetWorldTeamPlayerFightInfo(this.PlayerId);
			string newText = ((worldTeamPlayerFightInfo != null) ? worldTeamPlayerFightInfo.Name : null) ?? this.PlayerId.ToString();
			uiText.SetText(newText, true);
		}

		// Token: 0x06039816 RID: 235542 RVA: 0x00E97955 File Offset: 0x00E95B55
		public override bool IsMultiMap()
		{
			return this.GetMultiMapId() != 0;
		}

		// Token: 0x06039817 RID: 235543 RVA: 0x00E97960 File Offset: 0x00E95B60
		public override int GetMultiMapId()
		{
			ScenePlayerData scenePlayerData = ModelBase<CreatureModel>.Instance.GetScenePlayerData(this.PlayerId);
			if (scenePlayerData != null)
			{
				MultiMap? subMapConfigByAreaId = ConfigBase<MapConfig>.Instance.GetSubMapConfigByAreaId(scenePlayerData.GetAreaId());
				if (subMapConfigByAreaId == null)
				{
					return 0;
				}
				return subMapConfigByAreaId.GetValueOrDefault().Id;
			}
			else
			{
				OtherScenePlayerData otherScenePlayerDataByPlayerId = ModelBase<OnlineModel>.Instance.GetOtherScenePlayerDataByPlayerId(this.PlayerId);
				if (otherScenePlayerDataByPlayerId == null)
				{
					return 0;
				}
				MultiMap? subMapConfigByAreaId2 = ConfigBase<MapConfig>.Instance.GetSubMapConfigByAreaId(otherScenePlayerDataByPlayerId.Area);
				if (subMapConfigByAreaId2 == null)
				{
					return 0;
				}
				return subMapConfigByAreaId2.GetValueOrDefault().Id;
			}
		}

		// Token: 0x06039818 RID: 235544 RVA: 0x00E979EF File Offset: 0x00E95BEF
		public override bool LocateInGround()
		{
			return this.GetMultiMapId() == 0;
		}

		// Token: 0x04020A76 RID: 133750
		public int PlayerId;

		// Token: 0x04020A77 RID: 133751
		public int PlayerIndex;

		// Token: 0x04020A78 RID: 133752
		[Nullable(2)]
		public global::Vector PlayerStartPosition;

		// Token: 0x04020A79 RID: 133753
		public bool IsHide = true;

		// Token: 0x04020A7A RID: 133754
		[Nullable(2)]
		private readonly PlayerMarkCreateInfo PlayerInfo;
	}
}
