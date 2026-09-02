using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F48 RID: 12104
[NullableContext(1)]
[Nullable(0)]
public class BindBuffToVehicleEffect : BuffEffect
{
	// Token: 0x06018C49 RID: 101449 RVA: 0x007004A9 File Offset: 0x006FE6A9
	public BindBuffToVehicleEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C4A RID: 101450 RVA: 0x007004C4 File Offset: 0x006FE6C4
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			this.BuffIds = Array.Empty<long>();
			return;
		}
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array[i]);
		}
	}

	// Token: 0x06018C4B RID: 101451 RVA: 0x00700523 File Offset: 0x006FE723
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C4C RID: 101452 RVA: 0x00700528 File Offset: 0x006FE728
	public override void OnCreated()
	{
		if (!this.CheckAuthority())
		{
			return;
		}
		Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.ExactOwnerEntity, EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.ExactOwnerEntity, EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		CharacterDriveVehicleComponent characterDriveVehicleComponent = (exactOwnerEntity != null) ? exactOwnerEntity.GetComponent<CharacterDriveVehicleComponent>() : null;
		if (characterDriveVehicleComponent != null && characterDriveVehicleComponent.IsDriver)
		{
			this.AddBuffVehicle(characterDriveVehicleComponent.VehicleEntity, "OnCreated", null);
		}
	}

	// Token: 0x06018C4D RID: 101453 RVA: 0x007005BC File Offset: 0x006FE7BC
	public override void OnRemoved(bool bPremature)
	{
		if (!this.CheckAuthority())
		{
			return;
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.ExactOwnerEntity, EEventName.OnEnterVehicle, new Action<VehiclePassengerInfo, bool>(this.OnEnterVehicle));
		Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.ExactOwnerEntity, EEventName.OnLeaveVehicle, new Action<VehiclePassengerInfo, bool>(this.OnLeaveVehicle));
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		CharacterDriveVehicleComponent characterDriveVehicleComponent = (exactOwnerEntity != null) ? exactOwnerEntity.GetComponent<CharacterDriveVehicleComponent>() : null;
		if (characterDriveVehicleComponent != null && characterDriveVehicleComponent.IsDriver)
		{
			this.RemoveBuffVehicle(characterDriveVehicleComponent.VehicleEntity, "OnRemoved", null);
		}
	}

	// Token: 0x06018C4E RID: 101454 RVA: 0x00700650 File Offset: 0x006FE850
	protected void OnEnterVehicle(VehiclePassengerInfo info, bool byChangeRole)
	{
		if (!info.IsDriver)
		{
			return;
		}
		this.AddBuffVehicle(info.VehicleEntity, "OnEnterVehicle", null);
	}

	// Token: 0x06018C4F RID: 101455 RVA: 0x00700680 File Offset: 0x006FE880
	protected void OnLeaveVehicle(VehiclePassengerInfo info, bool byChangeRole)
	{
		if (!info.IsDriver)
		{
			return;
		}
		this.RemoveBuffVehicle(info.VehicleEntity, "OnLeaveVehicle", null);
	}

	// Token: 0x06018C50 RID: 101456 RVA: 0x007006B0 File Offset: 0x006FE8B0
	private unsafe void AddBuffVehicle([Nullable(2)] Entity vehicleEntity, string reason, int? stackCount = null)
	{
		IActiveBuff pendingBuff = base.PendingBuff;
		if (vehicleEntity == null || pendingBuff == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity ownerEntity = base.OwnerEntity;
			string message = "AddBuffToVehicleInvalid";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("vehicleEntityValid", vehicleEntity != null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("buffValid", pendingBuff != null);
			instance.Warn(flag, ownerEntity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		VehicleBuffComponent component = vehicleEntity.GetComponent<VehicleBuffComponent>();
		if (component != null)
		{
			foreach (long buffId in this.BuffIds)
			{
				component.AddIterativeBuff(buffId, pendingBuff, new int?(stackCount ?? pendingBuff.StackCount), false, "BindBuffToVehicle:" + reason, null, null);
			}
		}
	}

	// Token: 0x06018C51 RID: 101457 RVA: 0x007007C0 File Offset: 0x006FE9C0
	private unsafe void RemoveBuffVehicle([Nullable(2)] Entity vehicleEntity, string reason, int? stackCount = null)
	{
		IActiveBuff pendingBuff = base.PendingBuff;
		if (vehicleEntity == null || pendingBuff == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity ownerEntity = base.OwnerEntity;
			string message = "RemoveBindBuffVehicleInvalid";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("vehicleEntityValid", vehicleEntity != null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("buffValid", pendingBuff != null);
			instance.Warn(flag, ownerEntity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		VehicleBuffComponent component = vehicleEntity.GetComponent<VehicleBuffComponent>();
		if (component != null)
		{
			foreach (long buffId in this.BuffIds)
			{
				component.RemoveBuff(buffId, stackCount.GetValueOrDefault(-1), "BindBuffToVehicle:" + reason, pendingBuff.MessageId, null, null);
			}
		}
	}

	// Token: 0x06018C52 RID: 101458 RVA: 0x007008C4 File Offset: 0x006FEAC4
	public override void OnStackDecreased(int newCount, int oldCount, bool bPremature)
	{
		this.UpdateVehicleBuffStack(newCount, oldCount);
	}

	// Token: 0x06018C53 RID: 101459 RVA: 0x007008CE File Offset: 0x006FEACE
	public override void OnStackIncreased(int newCount, int oldCount, long? instigatorId)
	{
		this.UpdateVehicleBuffStack(newCount, oldCount);
	}

	// Token: 0x06018C54 RID: 101460 RVA: 0x007008D8 File Offset: 0x006FEAD8
	private void UpdateVehicleBuffStack(int newCount, int oldCount)
	{
		if (!this.CheckAuthority() || newCount == oldCount)
		{
			return;
		}
		Entity ownerEntity = base.OwnerEntity;
		CharacterDriveVehicleComponent characterDriveVehicleComponent = (ownerEntity != null) ? ownerEntity.GetComponent<CharacterDriveVehicleComponent>() : null;
		if (characterDriveVehicleComponent == null || !characterDriveVehicleComponent.IsDriver)
		{
			return;
		}
		Entity vehicleEntity = characterDriveVehicleComponent.VehicleEntity;
		if (vehicleEntity == null)
		{
			return;
		}
		if (newCount > oldCount)
		{
			this.AddBuffVehicle(vehicleEntity, "OnStackIncreased", new int?(newCount - oldCount));
			return;
		}
		this.RemoveBuffVehicle(vehicleEntity, "OnStackDecreased", new int?(oldCount - newCount));
	}

	// Token: 0x06018C55 RID: 101461 RVA: 0x00700949 File Offset: 0x006FEB49
	public override string GetDebugEffectString()
	{
		return "绑定buff到骑乘的载具上" + string.Join<long>(",", this.BuffIds);
	}

	// Token: 0x0400C0E7 RID: 49383
	public long[] BuffIds = Array.Empty<long>();
}
