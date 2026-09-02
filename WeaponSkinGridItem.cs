using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A69 RID: 10857
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeaponSkinGridItem : LoopScrollSmallItemGrid<WeaponSkinData>
{
	// Token: 0x06015C21 RID: 89121 RVA: 0x00609BE8 File Offset: 0x00607DE8
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.SetSelected(true, true);
		}
		WeaponSkinData weaponSkinData = this.Data as WeaponSkinData;
		if (weaponSkinData.IsNew)
		{
			ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.WeaponSkinRedDot, weaponSkinData.SkinId);
			base.SetNewFlagVisible(new bool?(false));
		}
	}

	// Token: 0x06015C22 RID: 89122 RVA: 0x00609C33 File Offset: 0x00607E33
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06015C23 RID: 89123 RVA: 0x00609C40 File Offset: 0x00607E40
	protected override void OnRefresh(WeaponSkinData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			IconPath = (data.IsEmptyData ? ConfigBase<SkinConfig>.Instance.GetDefaultWeaponSkinIconPath() : null),
			ItemConfigId = (data.IsEmptyData ? null : new int?(data.SkinId)),
			IsNewVisible = new bool?(data.IsNew)
		};
		base.Apply<PropSmallItemGrid>(parameters);
		this.SetSelected(isSelected, false);
		base.SetLockBlackVisible(data.GetIsLock());
		this.RefreshVisible();
	}

	// Token: 0x06015C24 RID: 89124 RVA: 0x00609CD4 File Offset: 0x00607ED4
	public void RefreshVisible()
	{
		WeaponSkinData weaponSkinData = this.Data as WeaponSkinData;
		base.SetSelectVisible(weaponSkinData.IsCurrentEquipSkinId());
		if (weaponSkinData.IsCurrentEquipSkinId())
		{
			base.SetRoleHead(null);
			return;
		}
		WeaponSkinModel instance = ModelBase<WeaponSkinModel>.Instance;
		int? num = (instance != null) ? instance.GetRoleIdBySkinId(weaponSkinData.SkinId) : null;
		if (num == null)
		{
			base.SetRoleHead(null);
			return;
		}
		RoleSkinModel instance2 = ModelBase<RoleSkinModel>.Instance;
		RoleSkinData roleSkinData = (instance2 != null) ? instance2.GetRoleSkinDataByRoleId(num.Value) : null;
		base.SetRoleHead((roleSkinData != null) ? new int?(roleSkinData.GetItemId()) : null);
	}
}
