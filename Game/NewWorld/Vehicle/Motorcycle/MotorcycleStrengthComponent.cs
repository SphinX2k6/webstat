using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047AB RID: 18347
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorcycleStrengthComponent : EntityComponent
	{
		// Token: 0x0602F9E9 RID: 195049 RVA: 0x00B5D728 File Offset: 0x00B5B928
		private void SetBannedSprint(bool banned)
		{
			if (this.BannedSprint == banned)
			{
				return;
			}
			this.BannedSprint = banned;
			if (banned)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp == null)
				{
					return;
				}
				tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用氮气.氮气耗尽"]));
				return;
			}
			else
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 == null)
				{
					return;
				}
				tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用氮气.氮气耗尽"]));
				return;
			}
		}

		// Token: 0x0602F9EA RID: 195050 RVA: 0x00B5D793 File Offset: 0x00B5B993
		private void RegisterStrengthListener()
		{
			if (this.IsListeningStrength)
			{
				return;
			}
			this.IsListeningStrength = true;
			ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthChanged), null);
		}

		// Token: 0x0602F9EB RID: 195051 RVA: 0x00B5D7BE File Offset: 0x00B5B9BE
		private void UnregisterStrengthListener()
		{
			if (!this.IsListeningStrength)
			{
				return;
			}
			this.IsListeningStrength = false;
			ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthChanged));
		}

		// Token: 0x0602F9EC RID: 195052 RVA: 0x00B5D7E8 File Offset: 0x00B5B9E8
		private void OnStrengthChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
		{
			if (this.BannedSprint)
			{
				if (newValue > 20f)
				{
					this.SetBannedSprint(false);
					return;
				}
			}
			else if (newValue < 1f)
			{
				this.SetBannedSprint(true);
			}
		}

		// Token: 0x0602F9ED RID: 195053 RVA: 0x00B5D814 File Offset: 0x00B5BA14
		private void OnVehicleDriverChange(Entity oldDriver, Entity newDriver)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num = (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null;
			if (newDriver != null)
			{
				int id = newDriver.Id;
				int? num2 = num;
				if (id == num2.GetValueOrDefault() & num2 != null)
				{
					this.RegisterStrengthListener();
					float value = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.MotorcycleStrength);
					if (value < 1f)
					{
						this.SetBannedSprint(true);
						return;
					}
					if (value > 20f)
					{
						this.SetBannedSprint(false);
						return;
					}
					return;
				}
			}
			if (oldDriver != null)
			{
				int id2 = oldDriver.Id;
				int? num2 = num;
				if (id2 == num2.GetValueOrDefault() & num2 != null)
				{
					this.UnregisterStrengthListener();
					this.SetBannedSprint(false);
				}
			}
		}

		// Token: 0x0602F9EE RID: 195054 RVA: 0x00B5D8BC File Offset: 0x00B5BABC
		protected override bool OnStart()
		{
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			if (!this.TagComp)
			{
				return false;
			}
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
			return true;
		}

		// Token: 0x0602F9EF RID: 195055 RVA: 0x00B5D90C File Offset: 0x00B5BB0C
		protected override bool OnEnd()
		{
			this.UnregisterStrengthListener();
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
			return true;
		}

		// Token: 0x0602F9F0 RID: 195056 RVA: 0x00B5D938 File Offset: 0x00B5BB38
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcycleStrengthComponent motorcycleStrengthComponent = (MotorcycleStrengthComponent)componentTemplate;
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (motorcycleStrengthComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BannedSprint"))
			{
				this.BannedSprint = motorcycleStrengthComponent.BannedSprint;
			}
			if (base.CanResetComponentProperty("IsListeningStrength"))
			{
				this.IsListeningStrength = motorcycleStrengthComponent.IsListeningStrength;
			}
			return true;
		}

		// Token: 0x0401B3E9 RID: 111593
		private const float BANNED_SPRINT_THRESHOLD_MIN = 1f;

		// Token: 0x0401B3EA RID: 111594
		private const float BANNED_SPRINT_THRESHOLD_MAX = 20f;

		// Token: 0x0401B3EB RID: 111595
		protected BaseTagComponent TagComp;

		// Token: 0x0401B3EC RID: 111596
		private bool BannedSprint;

		// Token: 0x0401B3ED RID: 111597
		private bool IsListeningStrength;
	}
}
