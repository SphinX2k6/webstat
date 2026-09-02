using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A6A RID: 10858
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WeaponSkinModel : ModelBase<WeaponSkinModel>
{
	// Token: 0x06015C26 RID: 89126 RVA: 0x00609D8A File Offset: 0x00607F8A
	public WeaponSkinModel()
	{
		this.UnLockSkinDataMap = new Dictionary<int, int>();
		this.RoleWeaponSkinDataMap = new Dictionary<int, int>();
	}

	// Token: 0x06015C27 RID: 89127 RVA: 0x00609DA8 File Offset: 0x00607FA8
	protected override bool OnClear()
	{
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.WeaponSkinRedDot);
		return true;
	}

	// Token: 0x06015C28 RID: 89128 RVA: 0x00609DB8 File Offset: 0x00607FB8
	private bool TryAddWeaponSkinRedDot(int configId)
	{
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.WeaponSkinRedDot, configId))
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.WeaponSkinRedDot, configId);
		return true;
	}

	// Token: 0x06015C29 RID: 89129 RVA: 0x00609DDC File Offset: 0x00607FDC
	private void NotifyFightWeaponSkinChange(int roleId, int skinId)
	{
		if (skinId == -1)
		{
			int modelId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleId, true).GetItemConfig().ModelId;
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.FightWeaponSkinChange, roleId, modelId);
			return;
		}
		int modelId2 = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId).ModelId;
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.FightWeaponSkinChange, roleId, modelId2);
	}

	// Token: 0x06015C2A RID: 89130 RVA: 0x00609E40 File Offset: 0x00608040
	private void SetWeaponSkinData(IList<RoleSkinEquipData> skinEquipDataList)
	{
		foreach (RoleSkinEquipData roleSkinEquipData in skinEquipDataList)
		{
			this.RoleWeaponSkinDataMap[roleSkinEquipData.RoleID] = roleSkinEquipData.SkinItemId;
			this.NotifyFightWeaponSkinChange(roleSkinEquipData.RoleID, roleSkinEquipData.SkinItemId);
		}
	}

	// Token: 0x06015C2B RID: 89131 RVA: 0x00609EAC File Offset: 0x006080AC
	public void UpdateWeaponSkinData(int roleId, int weaponSkinId)
	{
		this.RoleWeaponSkinDataMap[roleId] = weaponSkinId;
		this.NotifyFightWeaponSkinChange(roleId, weaponSkinId);
	}

	// Token: 0x06015C2C RID: 89132 RVA: 0x00609EC3 File Offset: 0x006080C3
	public void NotifyWeaponSkinData([Nullable(new byte[]
	{
		2,
		1
	})] IList<RoleSkinEquipData> skinEquipDataList)
	{
		if (skinEquipDataList == null)
		{
			return;
		}
		this.SetWeaponSkinData(skinEquipDataList);
	}

	// Token: 0x06015C2D RID: 89133 RVA: 0x00609ED0 File Offset: 0x006080D0
	public void EquipWeaponSkinData([Nullable(new byte[]
	{
		2,
		1
	})] IList<RoleSkinEquipData> skinEquipDataList)
	{
		if (skinEquipDataList == null)
		{
			return;
		}
		this.SetWeaponSkinData(skinEquipDataList);
		RoleSkinEquipData roleSkinEquipData = skinEquipDataList[0];
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.EquipWeaponSkin, roleSkinEquipData.RoleID, roleSkinEquipData.SkinItemId);
	}

	// Token: 0x06015C2E RID: 89134 RVA: 0x00609F0C File Offset: 0x0060810C
	public void DeleteWeaponSkinData(int roleId)
	{
		this.RoleWeaponSkinDataMap.Remove(roleId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.UninstallWeaponSkin, roleId);
		this.NotifyFightWeaponSkinChange(roleId, -1);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.WeaponSkin;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "武器皮肤卸载";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015C2F RID: 89135 RVA: 0x00609F70 File Offset: 0x00608170
	public int GetSkinIdByRoleId(int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById != null && roleDataById.IsTrialRole())
		{
			WeaponTrialData weaponData = (roleDataById as RoleRobotData).GetWeaponData();
			return ((weaponData != null) ? new int?(weaponData.GetSkinId()) : null).GetValueOrDefault(-1);
		}
		int result;
		if (this.RoleWeaponSkinDataMap.TryGetValue(roleId, out result))
		{
			return result;
		}
		return -1;
	}

	// Token: 0x06015C30 RID: 89136 RVA: 0x00609FD8 File Offset: 0x006081D8
	public int? GetRoleIdBySkinId(int skinId)
	{
		foreach (KeyValuePair<int, int> keyValuePair in this.RoleWeaponSkinDataMap)
		{
			if (keyValuePair.Value == skinId)
			{
				return new int?(keyValuePair.Key);
			}
		}
		return null;
	}

	// Token: 0x06015C31 RID: 89137 RVA: 0x0060A048 File Offset: 0x00608248
	public void NotifyAllUnlockSkinData(IList<int> skinIdList)
	{
		foreach (int key in skinIdList)
		{
			this.UnLockSkinDataMap[key] = 1;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.WeaponSkin;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "武器皮肤登录推送";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skinIdList", skinIdList);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015C32 RID: 89138 RVA: 0x0060A0C0 File Offset: 0x006082C0
	public void SetUnlockSkinData(IList<int> skinIdList)
	{
		foreach (int num in skinIdList)
		{
			this.UnLockSkinDataMap[num] = 1;
			this.TryAddWeaponSkinRedDot(num);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.WeaponSkin;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "武器皮肤添加";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skinIdList", skinIdList);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015C33 RID: 89139 RVA: 0x0060A140 File Offset: 0x00608340
	public void RefreshUnlockSkinData(IList<int> skinIdList)
	{
		this.UnLockSkinDataMap.Clear();
		foreach (int key in skinIdList)
		{
			this.UnLockSkinDataMap[key] = 1;
		}
	}

	// Token: 0x06015C34 RID: 89140 RVA: 0x0060A19C File Offset: 0x0060839C
	public int GetSkinCountById(int skinId)
	{
		int result;
		if (this.UnLockSkinDataMap.TryGetValue(skinId, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x06015C35 RID: 89141 RVA: 0x0060A1BC File Offset: 0x006083BC
	public bool HasWeaponSkinRedDot(int skinType)
	{
		foreach (WeaponSkin weaponSkin in ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfigListByType(skinType))
		{
			if (this.UnLockSkinDataMap.ContainsKey(weaponSkin.Id) && !weaponSkin.HideInSkinView && ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.WeaponSkinRedDot, weaponSkin.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015C36 RID: 89142 RVA: 0x0060A240 File Offset: 0x00608440
	public bool RedDotWeaponSkinCondition(int roleId)
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(roleId);
		if (weaponInstanceByRoleId == null)
		{
			return false;
		}
		int weaponType = weaponInstanceByRoleId.GetWeaponConfig().Value.WeaponType;
		return this.HasWeaponSkinRedDot(weaponType);
	}

	// Token: 0x0400A6E1 RID: 42721
	private readonly Dictionary<int, int> UnLockSkinDataMap;

	// Token: 0x0400A6E2 RID: 42722
	private readonly Dictionary<int, int> RoleWeaponSkinDataMap;
}
