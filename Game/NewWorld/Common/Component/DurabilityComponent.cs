using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem.Manipulate;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C1 RID: 18625
	[NullableContext(2)]
	[Nullable(0)]
	public class DurabilityComponent : EntityComponent
	{
		// Token: 0x170082C5 RID: 33477
		// (get) Token: 0x06030912 RID: 198930 RVA: 0x00BF08D0 File Offset: 0x00BEEAD0
		public bool IsDestroyed
		{
			get
			{
				DurabilityComponent.ESceneItemDestroyState? state = this.State;
				DurabilityComponent.ESceneItemDestroyState esceneItemDestroyState = DurabilityComponent.ESceneItemDestroyState.Destroying;
				return state.GetValueOrDefault() >= esceneItemDestroyState & state != null;
			}
		}

		// Token: 0x06030913 RID: 198931 RVA: 0x00BF08FC File Offset: 0x00BEEAFC
		protected override bool OnInit()
		{
			this.CreatureDataComponent = base.Entity.GetComponent<CreatureDataComponent>();
			this.State = new DurabilityComponent.ESceneItemDestroyState?(DurabilityComponent.ESceneItemDestroyState.Alive);
			this.DelayTimerId = null;
			DestructibleItem component = TdUtils.GetComponent<DestructibleItem>(this.CreatureDataComponent.GetPbEntityInitData().ComponentsData, EConfigComponent.DestructibleItem);
			IDurabilityStateConfig durabilityStateConfig = component.DurabilityStateConfig;
			if (durabilityStateConfig == null || !durabilityStateConfig.NonDestructable.GetValueOrDefault())
			{
				this.DeadActions = component.DestructionActions;
			}
			base.Entity.GetComponent<PawnSensoryInfoComponent>().SetLogicRange(ConfigBase<ManipulateConfig>.Instance.SearchRange);
			return true;
		}

		// Token: 0x06030914 RID: 198932 RVA: 0x00BF098B File Offset: 0x00BEEB8B
		protected override bool OnStart()
		{
			this.OnSceneItemDurabilityChange = delegate(int durability)
			{
				this.CheckDurablePoint();
			};
			Singleton<EventSystem>.Instance.AddWithTarget<int>(base.Entity, EEventName.OnSceneItemDurabilityChange, this.OnSceneItemDurabilityChange);
			this.CheckDurablePoint();
			return true;
		}

		// Token: 0x06030915 RID: 198933 RVA: 0x00BF09C4 File Offset: 0x00BEEBC4
		protected override bool OnEnd()
		{
			if (this.OnSceneItemDurabilityChange != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int>(base.Entity, EEventName.OnSceneItemDurabilityChange, this.OnSceneItemDurabilityChange);
				this.OnSceneItemDurabilityChange = null;
			}
			this.State = null;
			if (this.DelayTimerId != null && TimerSystem.Instance.Has(this.DelayTimerId))
			{
				TimerSystem.Instance.Remove(this.DelayTimerId);
			}
			this.DelayTimerId = null;
			return true;
		}

		// Token: 0x06030916 RID: 198934 RVA: 0x00BF0A3C File Offset: 0x00BEEC3C
		private void CheckDurablePoint()
		{
			DurabilityComponent.ESceneItemDestroyState? state = this.State;
			DurabilityComponent.ESceneItemDestroyState esceneItemDestroyState = DurabilityComponent.ESceneItemDestroyState.Alive;
			if (!(state.GetValueOrDefault() == esceneItemDestroyState & state != null))
			{
				return;
			}
			if (this.CreatureDataComponent.GetDurabilityValue() > 0)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.OnSceneItemDurabilityEmpty, base.Entity);
			this.State = new DurabilityComponent.ESceneItemDestroyState?(DurabilityComponent.ESceneItemDestroyState.Destroying);
		}

		// Token: 0x06030917 RID: 198935 RVA: 0x00BF0A98 File Offset: 0x00BEEC98
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			DurabilityComponent durabilityComponent = (DurabilityComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComponent"))
			{
				if (durabilityComponent.CreatureDataComponent == null)
				{
					this.CreatureDataComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("State"))
			{
				this.State = durabilityComponent.State;
			}
			if (base.CanResetComponentProperty("DelayTimerId"))
			{
				if (durabilityComponent.DelayTimerId == null)
				{
					this.DelayTimerId = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.DelayTimerId), "DelayTimerId"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("OnSceneItemDurabilityChange"))
			{
				if (durabilityComponent.OnSceneItemDurabilityChange == null)
				{
					this.OnSceneItemDurabilityChange = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action<int>>(this.OnSceneItemDurabilityChange), "OnSceneItemDurabilityChange"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DeadActions"))
			{
				if (durabilityComponent.DeadActions == null)
				{
					this.DeadActions = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<ActionInfo>>(this.DeadActions), "DeadActions"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401BE90 RID: 114320
		private CreatureDataComponent CreatureDataComponent;

		// Token: 0x0401BE91 RID: 114321
		private DurabilityComponent.ESceneItemDestroyState? State;

		// Token: 0x0401BE92 RID: 114322
		private TimerHandle DelayTimerId;

		// Token: 0x0401BE93 RID: 114323
		private Action<int> OnSceneItemDurabilityChange;

		// Token: 0x0401BE94 RID: 114324
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> DeadActions;

		// Token: 0x0200A992 RID: 43410
		[NullableContext(0)]
		private enum ESceneItemDestroyState
		{
			// Token: 0x04034831 RID: 215089
			Alive,
			// Token: 0x04034832 RID: 215090
			Destroying,
			// Token: 0x04034833 RID: 215091
			Destroyed
		}
	}
}
