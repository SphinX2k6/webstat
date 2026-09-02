using System;
using System.Runtime.CompilerServices;

// Token: 0x02001FBE RID: 8126
public class FlyStrengthItemForMotorcycle : FlyStrengthItem
{
	// Token: 0x0600F4E7 RID: 62695 RVA: 0x00430A21 File Offset: 0x0042EC21
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_EnergyMoto";
	}

	// Token: 0x0600F4E8 RID: 62696 RVA: 0x00430A28 File Offset: 0x0042EC28
	protected override void OnStart()
	{
		this.StrengthAttributeId = EFormationAttributeId.MotorcycleSoarStrength;
		base.OnStart();
		this.OnEnableStrengthItem(this.IsEnableStrengthItem);
	}

	// Token: 0x0600F4E9 RID: 62697 RVA: 0x00430A44 File Offset: 0x0042EC44
	protected override void OnAddEntityEvents()
	{
		if (this.RoleData == null)
		{
			return;
		}
		BaseTagComponent gameplayTagComponent = this.RoleData.GameplayTagComponent;
		if (gameplayTagComponent == null)
		{
			return;
		}
		base.ListenForTagAddOrRemove(gameplayTagComponent, new int?(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.驾驶期间"]), new Action<int, bool>(this.OnDrivingTagChanged));
		EntityHandle entityHandle = this.RoleData.EntityHandle;
		object obj;
		if (entityHandle == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			obj = ((entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null);
		}
		object obj2 = obj;
		BaseTagComponent baseTagComponent;
		if (obj2 == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity vehicleEntity = obj2.VehicleEntity;
			baseTagComponent = ((vehicleEntity != null) ? vehicleEntity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 != null)
		{
			base.ListenForTagAddOrRemove(baseTagComponent2, new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]), new Action<int, bool>(this.OnMotorFlyTagChanged));
			base.ListenForTagAddOrRemove(baseTagComponent2, new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺"]), new Action<int, bool>(base.OnSpeedUpTagChanged));
			base.ListenForTagAddOrRemove(baseTagComponent2, new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.滑翔体力锁定"]), new Action<int, bool>(base.OnLockTagChanged));
			base.ListenForTagAddOrRemove(baseTagComponent2, new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.滑翔体力隐藏"]), new Action<int, bool>(base.OnHideTagChanged));
			this.IsFlying = baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.状态.空中.翱翔"]);
			this.IsSpeedUp = baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺"]);
			this.IsLock = baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.滑翔体力锁定"]);
			this.IsHideTag = baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.滑翔体力隐藏"]);
		}
	}

	// Token: 0x0600F4EA RID: 62698 RVA: 0x00430BDB File Offset: 0x0042EDDB
	protected override void OnRefreshRoleData()
	{
		base.RefreshSpeedUp();
		base.RefreshLockState();
		base.RefreshVisible();
	}

	// Token: 0x0600F4EB RID: 62699 RVA: 0x00430BEF File Offset: 0x0042EDEF
	private void OnDrivingTagChanged(int tagId, bool tagExists)
	{
		if (!tagExists)
		{
			base.OnFlyTagChanged(tagId, false);
			this.SetActive(false);
		}
	}

	// Token: 0x0600F4EC RID: 62700 RVA: 0x00430C03 File Offset: 0x0042EE03
	private void OnMotorFlyTagChanged(int tagId, bool tagExists)
	{
		base.OnFlyTagChanged(tagId, tagExists);
	}
}
