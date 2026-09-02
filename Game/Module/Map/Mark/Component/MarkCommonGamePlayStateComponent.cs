using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.Marks;

namespace CSharpScript.Game.Module.Map.Mark.Component
{
	// Token: 0x02005827 RID: 22567
	public class MarkCommonGamePlayStateComponent : MapComponent
	{
		// Token: 0x060395D7 RID: 234967 RVA: 0x00E9013E File Offset: 0x00E8E33E
		public MarkCommonGamePlayStateComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17009236 RID: 37430
		// (get) Token: 0x060395D8 RID: 234968 RVA: 0x00E90147 File Offset: 0x00E8E347
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.MarkCommonGamePlayState;
			}
		}

		// Token: 0x17009237 RID: 37431
		// (get) Token: 0x060395D9 RID: 234969 RVA: 0x00E9014B File Offset: 0x00E8E34B
		// (set) Token: 0x060395DA RID: 234970 RVA: 0x00E90153 File Offset: 0x00E8E353
		public bool HasRequestGamePlay { get; set; }

		// Token: 0x060395DB RID: 234971 RVA: 0x00E9015C File Offset: 0x00E8E35C
		protected override void OnInit()
		{
			this.UpdateLevelPlayState();
		}

		// Token: 0x060395DC RID: 234972 RVA: 0x00E90164 File Offset: 0x00E8E364
		protected override void OnAdd()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LevelPlayStateDetailUpdate, new Action(this.OnLevelPlayStateUpdate));
			Singleton<EventSystem>.Instance.Add<int, ELevelPlayState>(EEventName.OnLevelPlayStateChange, new Action<int, ELevelPlayState>(this.EventUpdateLevelPlayState));
			Singleton<EventSystem>.Instance.Add(EEventName.LevelPlayRewardDetailUpdate, new Action(this.OnLevelPlayStateUpdate));
		}

		// Token: 0x060395DD RID: 234973 RVA: 0x00E901C8 File Offset: 0x00E8E3C8
		protected override void OnRemove()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelPlayStateDetailUpdate, new Action(this.OnLevelPlayStateUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLevelPlayStateChange, new Action<int, ELevelPlayState>(this.EventUpdateLevelPlayState));
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelPlayRewardDetailUpdate, new Action(this.OnLevelPlayStateUpdate));
		}

		// Token: 0x060395DE RID: 234974 RVA: 0x00E90229 File Offset: 0x00E8E429
		private void OnLevelPlayStateUpdate()
		{
			this.UpdateLevelPlayState();
		}

		// Token: 0x060395DF RID: 234975 RVA: 0x00E90234 File Offset: 0x00E8E434
		private void EventUpdateLevelPlayState(int id, ELevelPlayState eLevelPlayState)
		{
			int? relativeId = this.GetRelativeId();
			int? relativeDungeonId = this.GetRelativeDungeonId();
			int? num = relativeId;
			if (!(num.GetValueOrDefault() == id & num != null) || relativeDungeonId == null)
			{
				return;
			}
			ControllerBase<LevelPlayReportController>.Instance.RequestSingleLevelPlayStateListAsync(relativeDungeonId.Value, relativeId.Value);
			this.UpdateLevelPlayState();
		}

		// Token: 0x060395E0 RID: 234976 RVA: 0x00E90290 File Offset: 0x00E8E490
		private void UpdateLevelPlayState()
		{
			int? relativeId = this.GetRelativeId();
			int? relativeDungeonId = this.GetRelativeDungeonId();
			if (relativeId == null || relativeDungeonId == null)
			{
				return;
			}
			bool flag = ModelBase<LevelPlayReportModel>.Instance.IsCommonLevelPlayHide(relativeDungeonId.Value, relativeId.Value);
			EMarkGamePlayState emarkGamePlayState = EMarkGamePlayState.Lock;
			MapEntity parentEntity = base.ParentEntity;
			MarkConfigComponent markConfigComponent = (parentEntity != null) ? parentEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig) : null;
			OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>? oneOf = (markConfigComponent != null) ? new OneOf<MapMark, DynamicMapMark, TreasureBoxDetectorMark>?(markConfigComponent.Config) : null;
			int? num = null;
			if (oneOf != null)
			{
				if (oneOf.Value.IsT1)
				{
					num = new int?(oneOf.Value.AsT1.MarkId);
				}
				else if (oneOf.Value.IsT2)
				{
					num = new int?(oneOf.Value.AsT2.MarkId);
				}
			}
			if (flag)
			{
				emarkGamePlayState = EMarkGamePlayState.Hide;
			}
			else if (num != null && MarkItemDataUtil.IsCommonGamePlayMarkComplete(num.Value))
			{
				emarkGamePlayState = EMarkGamePlayState.Finish;
			}
			MapEntity parentEntity2 = base.ParentEntity;
			MarkGamePlayComponent markGamePlayComponent = (parentEntity2 != null) ? parentEntity2.GetComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay) : null;
			if (markGamePlayComponent != null && markGamePlayComponent.GamePlayState != emarkGamePlayState)
			{
				markGamePlayComponent.GamePlayState = emarkGamePlayState;
				if (num != null)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.CommonPlayMarkGamePlayStateUpdate, num.Value);
				}
			}
		}

		// Token: 0x060395E1 RID: 234977 RVA: 0x00E903EC File Offset: 0x00E8E5EC
		public int? GetRelativeId()
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

		// Token: 0x060395E2 RID: 234978 RVA: 0x00E904A4 File Offset: 0x00E8E6A4
		public int? GetRelativeDungeonId()
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
				return new int?(oneOf.Value.AsT1.RelativeDungeonId);
			}
			if (oneOf.Value.IsT2)
			{
				return new int?(oneOf.Value.AsT2.RelativeDungeonId);
			}
			return null;
		}

		// Token: 0x060395E3 RID: 234979 RVA: 0x00E9055C File Offset: 0x00E8E75C
		public bool NeedRequestGamePlayState()
		{
			return !this.HasRequestGamePlay && this.GetRelativeId().GetValueOrDefault() != 0;
		}
	}
}
