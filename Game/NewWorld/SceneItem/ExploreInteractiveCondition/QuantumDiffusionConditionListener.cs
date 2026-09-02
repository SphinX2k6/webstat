using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;

namespace CSharpScript.Game.NewWorld.SceneItem.ExploreInteractiveCondition
{
	// Token: 0x02004866 RID: 18534
	public class QuantumDiffusionConditionListener : CustomConditionListener
	{
		// Token: 0x06030379 RID: 197497 RVA: 0x00BB8B29 File Offset: 0x00BB6D29
		[NullableContext(1)]
		public QuantumDiffusionConditionListener(Action<bool> onConditionChange) : base(onConditionChange)
		{
		}

		// Token: 0x0603037A RID: 197498 RVA: 0x00BB8B34 File Offset: 0x00BB6D34
		public override bool CheckCondition()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
			PlayerFollowableComponent playerFollowableComponent = (playerEntity != null) ? playerEntity.GetComponent<PlayerFollowableComponent>() : null;
			if (playerFollowableComponent == null)
			{
				return false;
			}
			EntityHandle follower = playerFollowableComponent.GetFollower();
			if (follower == null || !follower.IsInit)
			{
				return false;
			}
			if (!playerFollowableComponent.IsFollowerEnable())
			{
				return false;
			}
			BaseTagComponent component = follower.Entity.GetComponent<BaseTagComponent>();
			return component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["辅助机.量子转换.持有中"]);
		}

		// Token: 0x0603037B RID: 197499 RVA: 0x00BB8BB2 File Offset: 0x00BB6DB2
		public override void SetListenerEnable(bool enable)
		{
			if (enable)
			{
				this.AddEvents();
				return;
			}
			this.RemoveEvents();
		}

		// Token: 0x0603037C RID: 197500 RVA: 0x00BB8BC4 File Offset: 0x00BB6DC4
		private void AddEvents()
		{
			if (!Singleton<EventSystem>.Instance.Has<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange)))
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange));
			}
		}

		// Token: 0x0603037D RID: 197501 RVA: 0x00BB8BFF File Offset: 0x00BB6DFF
		private void RemoveEvents()
		{
			if (Singleton<EventSystem>.Instance.Has<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange)))
			{
				Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange));
			}
		}

		// Token: 0x0603037E RID: 197502 RVA: 0x00BB8C3A File Offset: 0x00BB6E3A
		private void OnPlayerFollowerEnableChange(bool isEnable)
		{
			Action<bool> onConditionChange = this.OnConditionChange;
			if (onConditionChange == null)
			{
				return;
			}
			onConditionChange(this.CheckCondition());
		}
	}
}
