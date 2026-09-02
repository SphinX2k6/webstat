using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.NewWorld.Character.Custom.Components
{
	// Token: 0x020048E9 RID: 18665
	[NullableContext(2)]
	[Nullable(0)]
	public class SafetyLocationComponent : EntityComponent
	{
		// Token: 0x06030BD0 RID: 199632 RVA: 0x00C0AD20 File Offset: 0x00C08F20
		protected override bool OnInitData(IEntityArgs args = null)
		{
			LocationSafetyComponent compConfig = args.GetP1<CreateEntityData>().GetParam<SafetyLocationComponent>() as LocationSafetyComponent;
			this.CompConfig = compConfig;
			return true;
		}

		// Token: 0x06030BD1 RID: 199633 RVA: 0x00C0AD46 File Offset: 0x00C08F46
		protected override bool OnStart()
		{
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnMyPlayerOverlapCallback));
			return true;
		}

		// Token: 0x06030BD2 RID: 199634 RVA: 0x00C0AD6B File Offset: 0x00C08F6B
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnMyPlayerOverlapCallback));
			if (this.IsMyPlayerInRange)
			{
				this.OnMyPlayerOverlapCallback(false);
			}
			return true;
		}

		// Token: 0x06030BD3 RID: 199635 RVA: 0x00C0ADA0 File Offset: 0x00C08FA0
		private void OnMyPlayerOverlapCallback(bool isEnter)
		{
			this.IsMyPlayerInRange = isEnter;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			RoleLocationSafetyComponent roleLocationSafetyComponent;
			if (baseCharacter == null)
			{
				roleLocationSafetyComponent = null;
			}
			else
			{
				Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
				roleLocationSafetyComponent = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<RoleLocationSafetyComponent>() : null);
			}
			RoleLocationSafetyComponent roleLocationSafetyComponent2 = roleLocationSafetyComponent;
			if (roleLocationSafetyComponent2 == null)
			{
				return;
			}
			if (isEnter)
			{
				roleLocationSafetyComponent2.AddSafetyLocationConfig(base.Entity, this.CompConfig);
				return;
			}
			roleLocationSafetyComponent2.RemoveSafetyLocationConfig(base.Entity);
		}

		// Token: 0x06030BD4 RID: 199636 RVA: 0x00C0ADF8 File Offset: 0x00C08FF8
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SafetyLocationComponent safetyLocationComponent = (SafetyLocationComponent)componentTemplate;
			if (base.CanResetComponentProperty("CompConfig"))
			{
				if (safetyLocationComponent.CompConfig == null)
				{
					this.CompConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LocationSafetyComponent>(this.CompConfig), "CompConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsMyPlayerInRange"))
			{
				this.IsMyPlayerInRange = safetyLocationComponent.IsMyPlayerInRange;
			}
			return true;
		}

		// Token: 0x0401C02E RID: 114734
		private LocationSafetyComponent CompConfig;

		// Token: 0x0401C02F RID: 114735
		private bool IsMyPlayerInRange;
	}
}
