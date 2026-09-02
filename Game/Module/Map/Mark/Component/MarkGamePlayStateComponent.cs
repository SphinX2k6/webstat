using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Base;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x0200582D RID: 22573
	public class MarkGamePlayStateComponent : MapComponent
	{
		// Token: 0x0603961E RID: 235038 RVA: 0x00E91691 File Offset: 0x00E8F891
		public MarkGamePlayStateComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17009257 RID: 37463
		// (get) Token: 0x0603961F RID: 235039 RVA: 0x00E9169A File Offset: 0x00E8F89A
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkGamePlayState;
			}
		}

		// Token: 0x06039620 RID: 235040 RVA: 0x00E9169E File Offset: 0x00E8F89E
		protected override void OnInit()
		{
			this.UpdateLevelPlayState();
		}

		// Token: 0x06039621 RID: 235041 RVA: 0x00E916A6 File Offset: 0x00E8F8A6
		protected override void OnAdd()
		{
			Singleton<EventSystem>.Instance.Add<int, ELevelPlayState>(EEventName.OnLevelPlayStateChange, new Action<int, ELevelPlayState>(this.EventUpdateLevelPlayState));
		}

		// Token: 0x06039622 RID: 235042 RVA: 0x00E916C4 File Offset: 0x00E8F8C4
		protected override void OnRemove()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLevelPlayStateChange, new Action<int, ELevelPlayState>(this.EventUpdateLevelPlayState));
		}

		// Token: 0x06039623 RID: 235043 RVA: 0x00E916E4 File Offset: 0x00E8F8E4
		private int? GetRelativeId()
		{
			MapEntity parentEntity = base.ParentEntity;
			MarkConfigComponent markConfigComponent = (parentEntity != null) ? parentEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig) : null;
			OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>? oneOf = (markConfigComponent != null) ? new OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>?(markConfigComponent.Config) : null;
			if (oneOf == null)
			{
				return null;
			}
			if (oneOf.Value.IsT1)
			{
				return new int?(oneOf.Value.AsT1.RelativeId);
			}
			if (oneOf.Value.IsT2)
			{
				return new int?(oneOf.Value.AsT2.RelativeId);
			}
			return null;
		}

		// Token: 0x06039624 RID: 235044 RVA: 0x00E9179C File Offset: 0x00E8F99C
		private void EventUpdateLevelPlayState(int id, ELevelPlayState eLevelPlayState)
		{
			int? relativeId = this.GetRelativeId();
			if (relativeId.GetValueOrDefault() == id & relativeId != null)
			{
				this.UpdateLevelPlayState();
			}
		}

		// Token: 0x06039625 RID: 235045 RVA: 0x00E917CC File Offset: 0x00E8F9CC
		public void UpdateLevelPlayState()
		{
			int? relativeId = this.GetRelativeId();
			if (relativeId == null)
			{
				return;
			}
			LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(relativeId.Value);
			if (levelPlayInfo == null)
			{
				return;
			}
			EMarkGamePlayState emarkGamePlayState = EMarkGamePlayState.Lock;
			switch (levelPlayInfo.PlayState)
			{
			case ELevelPlayState.Close:
			case ELevelPlayState.Wait:
				emarkGamePlayState = EMarkGamePlayState.Lock;
				break;
			case ELevelPlayState.Open:
				emarkGamePlayState = EMarkGamePlayState.Processing;
				break;
			case ELevelPlayState.Finish:
			case ELevelPlayState.AllPlayerGetReward:
				emarkGamePlayState = EMarkGamePlayState.Finish;
				break;
			}
			MapEntity parentEntity = base.ParentEntity;
			MarkGamePlayComponent markGamePlayComponent = (parentEntity != null) ? parentEntity.GetComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay) : null;
			if (markGamePlayComponent != null && markGamePlayComponent.GamePlayState != emarkGamePlayState)
			{
				markGamePlayComponent.GamePlayState = emarkGamePlayState;
				MapEntity parentEntity2 = base.ParentEntity;
				MarkConfigComponent markConfigComponent = (parentEntity2 != null) ? parentEntity2.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig) : null;
				OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>? oneOf = (markConfigComponent != null) ? new OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>?(markConfigComponent.Config) : null;
				if (oneOf != null && oneOf.Value.IsT1)
				{
					int markId = oneOf.Value.AsT1.MarkId;
					if (markId != 0)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.LevelPlayMarkGamePlayStateUpdate, markId);
					}
				}
				if (oneOf != null && oneOf.Value.IsT2)
				{
					int markId2 = oneOf.Value.AsT2.MarkId;
					if (markId2 != 0)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.LevelPlayMarkGamePlayStateUpdate, markId2);
					}
				}
			}
		}
	}
}
