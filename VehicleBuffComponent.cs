using System;
using System.Runtime.CompilerServices;

// Token: 0x02003269 RID: 12905
[NullableContext(1)]
[Nullable(0)]
public class VehicleBuffComponent : CharacterBuffComponent
{
	// Token: 0x0601AF9C RID: 110492 RVA: 0x0080E734 File Offset: 0x0080C934
	protected override bool OnStart()
	{
		this.VehiclePerformComp = base.Entity.GetComponent<BaseVehiclePerformComponent>();
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		this.MotorContextId = ((component != null) ? component.MotorContextId : 0L);
		return base.OnStart();
	}

	// Token: 0x0601AF9D RID: 110493 RVA: 0x0080E76C File Offset: 0x0080C96C
	public override bool HasBuffAuthority()
	{
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPlayerId()) : null;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int? num2 = num;
		return id.GetValueOrDefault() == num2.GetValueOrDefault() & id != null == (num2 != null);
	}

	// Token: 0x0601AF9E RID: 110494 RVA: 0x0080E7C5 File Offset: 0x0080C9C5
	[NullableContext(2)]
	protected override bool NeedBroadcastBuff(ActiveBuffInternal buff, bool fromServer = false)
	{
		return (buff == null || !NoBroadCastBuff.Values.Contains(buff.Id)) && base.NeedBroadcastBuff(buff, fromServer);
	}

	// Token: 0x0601AF9F RID: 110495 RVA: 0x0080E7E8 File Offset: 0x0080C9E8
	public override void AddBuff(long buffId, AddBuffParam buffParams)
	{
		if (buffParams.PreMessageId == null && this.MotorContextId != 0L)
		{
			buffParams.PreMessageId = new long?(this.MotorContextId);
		}
		base.AddBuff(buffId, buffParams);
	}

	// Token: 0x0601AFA0 RID: 110496 RVA: 0x0080E828 File Offset: 0x0080CA28
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleBuffComponent vehicleBuffComponent = (VehicleBuffComponent)componentTemplate;
		if (base.CanResetComponentProperty("VehiclePerformComp"))
		{
			if (vehicleBuffComponent.VehiclePerformComp == null)
			{
				this.VehiclePerformComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseVehiclePerformComponent>(this.VehiclePerformComp), "VehiclePerformComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MotorContextId"))
		{
			this.MotorContextId = vehicleBuffComponent.MotorContextId;
		}
		return true;
	}

	// Token: 0x0400DAEF RID: 56047
	[Nullable(2)]
	public BaseVehiclePerformComponent VehiclePerformComp;

	// Token: 0x0400DAF0 RID: 56048
	public long MotorContextId;
}
