using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Common
{
	// Token: 0x020047D5 RID: 18389
	[NullableContext(1)]
	[Nullable(0)]
	public class VehicleActionComponent : EntityComponent
	{
		// Token: 0x170081DD RID: 33245
		// (get) Token: 0x0602FB32 RID: 195378 RVA: 0x00B69C8E File Offset: 0x00B67E8E
		public new static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(VehicleCatapultComponent),
					typeof(VehicleSkillComponent),
					typeof(VehicleActorComponent)
				};
			}
		}

		// Token: 0x0602FB33 RID: 195379 RVA: 0x00B69CBD File Offset: 0x00B67EBD
		protected override bool OnStart()
		{
			this.VehicleCatapultComponent = base.Entity.GetComponent<VehicleCatapultComponent>();
			this.VehicleSkillComponent = base.Entity.GetComponent<VehicleSkillComponent>();
			this.VehicleActorComponent = base.Entity.GetComponent<VehicleActorComponent>();
			return true;
		}

		// Token: 0x0602FB34 RID: 195380 RVA: 0x00B69CF4 File Offset: 0x00B67EF4
		[NullableContext(0)]
		public UniTask<bool> StartBounce([Nullable(1)] BounceParam param)
		{
			VehicleActionComponent.<StartBounce>d__14 <StartBounce>d__;
			<StartBounce>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartBounce>d__.<>4__this = this;
			<StartBounce>d__.param = param;
			<StartBounce>d__.<>1__state = -1;
			<StartBounce>d__.<>t__builder.Start<VehicleActionComponent.<StartBounce>d__14>(ref <StartBounce>d__);
			return <StartBounce>d__.<>t__builder.Task;
		}

		// Token: 0x0602FB35 RID: 195381 RVA: 0x00B69D40 File Offset: 0x00B67F40
		[return: Nullable(0)]
		public UniTask<bool> StartCatapultToTarget(Vector targetLocation, Vector locationOffset, float heightOffset, float gravityMagnitude = 1960f, bool preciseMode = true, int skillId = 0)
		{
			VehicleActionComponent.<StartCatapultToTarget>d__15 <StartCatapultToTarget>d__;
			<StartCatapultToTarget>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartCatapultToTarget>d__.<>4__this = this;
			<StartCatapultToTarget>d__.targetLocation = targetLocation;
			<StartCatapultToTarget>d__.locationOffset = locationOffset;
			<StartCatapultToTarget>d__.heightOffset = heightOffset;
			<StartCatapultToTarget>d__.gravityMagnitude = gravityMagnitude;
			<StartCatapultToTarget>d__.preciseMode = preciseMode;
			<StartCatapultToTarget>d__.skillId = skillId;
			<StartCatapultToTarget>d__.<>1__state = -1;
			<StartCatapultToTarget>d__.<>t__builder.Start<VehicleActionComponent.<StartCatapultToTarget>d__15>(ref <StartCatapultToTarget>d__);
			return <StartCatapultToTarget>d__.<>t__builder.Task;
		}

		// Token: 0x0602FB36 RID: 195382 RVA: 0x00B69DB8 File Offset: 0x00B67FB8
		[return: Nullable(0)]
		public UniTask<bool> StartCatapult(Entity catapultEntity, IMotorCatapultParam config, int skillId = 0)
		{
			VehicleActionComponent.<StartCatapult>d__16 <StartCatapult>d__;
			<StartCatapult>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartCatapult>d__.<>4__this = this;
			<StartCatapult>d__.catapultEntity = catapultEntity;
			<StartCatapult>d__.config = config;
			<StartCatapult>d__.skillId = skillId;
			<StartCatapult>d__.<>1__state = -1;
			<StartCatapult>d__.<>t__builder.Start<VehicleActionComponent.<StartCatapult>d__16>(ref <StartCatapult>d__);
			return <StartCatapult>d__.<>t__builder.Task;
		}

		// Token: 0x0602FB37 RID: 195383 RVA: 0x00B69E14 File Offset: 0x00B68014
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			VehicleActionComponent vehicleActionComponent = (VehicleActionComponent)componentTemplate;
			if (base.CanResetComponentProperty("VehicleCatapultComponent"))
			{
				if (vehicleActionComponent.VehicleCatapultComponent == null)
				{
					this.VehicleCatapultComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleCatapultComponent>(this.VehicleCatapultComponent), "VehicleCatapultComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("VehicleSkillComponent"))
			{
				if (vehicleActionComponent.VehicleSkillComponent == null)
				{
					this.VehicleSkillComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleSkillComponent>(this.VehicleSkillComponent), "VehicleSkillComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("VehicleActorComponent"))
			{
				if (vehicleActionComponent.VehicleActorComponent == null)
				{
					this.VehicleActorComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleActorComponent>(this.VehicleActorComponent), "VehicleActorComponent"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B53A RID: 111930
		[Nullable(2)]
		private VehicleCatapultComponent VehicleCatapultComponent;

		// Token: 0x0401B53B RID: 111931
		[Nullable(2)]
		private VehicleSkillComponent VehicleSkillComponent;

		// Token: 0x0401B53C RID: 111932
		[Nullable(2)]
		private VehicleActorComponent VehicleActorComponent;

		// Token: 0x0401B53D RID: 111933
		private const float DEFAULT_CATAPULT_TIME = 0.6f;

		// Token: 0x0401B53E RID: 111934
		private const float DEFAULT_CATAPULT_GRAVITY = 1960f;

		// Token: 0x0401B53F RID: 111935
		[StaticVariableRuleIgnore]
		private static readonly Vector TmpVector = Vector.Create();

		// Token: 0x0401B540 RID: 111936
		[StaticVariableRuleIgnore]
		private static readonly Vector TmpVector2 = Vector.Create();

		// Token: 0x0401B541 RID: 111937
		[StaticVariableRuleIgnore]
		private static readonly Vector TmpVector3 = Vector.Create();

		// Token: 0x0401B542 RID: 111938
		[StaticVariableRuleIgnore]
		private static readonly Rotator TmpRotator = Rotator.Create();

		// Token: 0x0401B543 RID: 111939
		[StaticVariableRuleIgnore]
		private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401B544 RID: 111940
		[StaticVariableRuleIgnore]
		private static readonly CatapultToTargetResult CatapultResult = new CatapultToTargetResult();
	}
}
