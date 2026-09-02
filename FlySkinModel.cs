using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;
using Google.Protobuf.Collections;

// Token: 0x02002A59 RID: 10841
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FlySkinModel : ModelBase<FlySkinModel>
{
	// Token: 0x06015B59 RID: 88921 RVA: 0x0060633D File Offset: 0x0060453D
	protected override bool OnClear()
	{
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.FlySkinRedDot);
		return true;
	}

	// Token: 0x06015B5A RID: 88922 RVA: 0x00606350 File Offset: 0x00604550
	public void UpdateFlySkinEquipDataList(IReadOnlyList<FlyEquipData> dataList)
	{
		this.SkinIdToRoleIds.Clear();
		this.RoleIdToRoleEquipData.Clear();
		this.UnlockSkinIdSet.Clear();
		foreach (FlyEquipData flyEquipData in dataList)
		{
			int skinId = flyEquipData.SkinId;
			RepeatedField<int> roleIds = flyEquipData.RoleIds;
			this.AddUnlockSkinIdInternal(skinId);
			int skinType = ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(skinId).Value.SkinType;
			foreach (int roleDataId in roleIds)
			{
				this.AddRoleFlySkinEquipData(roleDataId, skinId, (EFlySkinType)skinType);
			}
		}
	}

	// Token: 0x06015B5B RID: 88923 RVA: 0x00606420 File Offset: 0x00604620
	public void AddUnlockSkinId(int skinId)
	{
		if (skinId > 0)
		{
			this.AddUnlockSkinIdInternal(skinId);
			this.TryAddFlySkinRedDot(skinId);
		}
	}

	// Token: 0x06015B5C RID: 88924 RVA: 0x00606435 File Offset: 0x00604635
	private void AddUnlockSkinIdInternal(int skinId)
	{
		if (skinId > 0)
		{
			this.UnlockSkinIdSet.Add(skinId);
		}
	}

	// Token: 0x06015B5D RID: 88925 RVA: 0x00606448 File Offset: 0x00604648
	public bool CheckSkinIsUnlock(int skinId)
	{
		return skinId == 0 || this.UnlockSkinIdSet.Contains(skinId);
	}

	// Token: 0x06015B5E RID: 88926 RVA: 0x0060645B File Offset: 0x0060465B
	public int GetFlySkinItemCount(int skinItemId)
	{
		if (this.CheckSkinIsUnlock(skinItemId))
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06015B5F RID: 88927 RVA: 0x0060646C File Offset: 0x0060466C
	public void EquipFlySkin(int roleDataId, int skinId)
	{
		if (skinId <= 0)
		{
			return;
		}
		int skinType = ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(skinId).Value.SkinType;
		int roleEquipFlySkinId = this.GetRoleEquipFlySkinId(roleDataId, (EFlySkinType)skinType);
		if (roleEquipFlySkinId == skinId)
		{
			return;
		}
		this.DeleteRoleFlySkinEquipData(roleDataId, roleEquipFlySkinId, (EFlySkinType)skinType);
		this.AddRoleFlySkinEquipData(roleDataId, skinId, (EFlySkinType)skinType);
		Singleton<EventSystem>.Instance.Emit<int, EFlySkinType, int, int>(EEventName.OnRoleFlySkinChange, roleDataId, (EFlySkinType)skinType, roleEquipFlySkinId, skinId);
	}

	// Token: 0x06015B60 RID: 88928 RVA: 0x006064D0 File Offset: 0x006046D0
	public void UnLoadRoleFlySkinBySkinId(int roleDataId, int skinId)
	{
		int skinType = ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(skinId).Value.SkinType;
		if (this.DeleteRoleFlySkinEquipData(roleDataId, skinId, (EFlySkinType)skinType))
		{
			Singleton<EventSystem>.Instance.Emit<int, EFlySkinType, int, int>(EEventName.OnRoleFlySkinChange, roleDataId, (EFlySkinType)skinType, skinId, 0);
		}
	}

	// Token: 0x06015B61 RID: 88929 RVA: 0x00606518 File Offset: 0x00604718
	public void UnLoadRoleFlySkinBySkinType(int roleDataId, EFlySkinType skinType)
	{
		RoleFlySkinEquipData roleFlySkinEquipData;
		if (!this.RoleIdToRoleEquipData.TryGetValue(roleDataId, out roleFlySkinEquipData))
		{
			return;
		}
		int num;
		if (!roleFlySkinEquipData.SkinEquipMap.TryGetValue(skinType, out num))
		{
			return;
		}
		if (this.DeleteRoleFlySkinEquipData(roleDataId, num, skinType))
		{
			Singleton<EventSystem>.Instance.Emit<int, EFlySkinType, int, int>(EEventName.OnRoleFlySkinChange, roleDataId, skinType, num, 0);
		}
	}

	// Token: 0x06015B62 RID: 88930 RVA: 0x00606568 File Offset: 0x00604768
	private void AddRoleFlySkinEquipData(int roleDataId, int skinId, EFlySkinType skinType)
	{
		List<int> list;
		if (!this.SkinIdToRoleIds.TryGetValue(skinId, out list))
		{
			list = new List<int>
			{
				roleDataId
			};
			this.SkinIdToRoleIds.Add(skinId, list);
		}
		else
		{
			list.Add(roleDataId);
		}
		RoleFlySkinEquipData roleFlySkinEquipData;
		if (!this.RoleIdToRoleEquipData.TryGetValue(roleDataId, out roleFlySkinEquipData))
		{
			roleFlySkinEquipData = new RoleFlySkinEquipData
			{
				RoleDataId = roleDataId
			};
			this.RoleIdToRoleEquipData.Add(roleDataId, roleFlySkinEquipData);
		}
		roleFlySkinEquipData.SkinEquipMap[skinType] = skinId;
		roleFlySkinEquipData.SkinEquipSet.Add(skinId);
	}

	// Token: 0x06015B63 RID: 88931 RVA: 0x006065EC File Offset: 0x006047EC
	private bool DeleteRoleFlySkinEquipData(int roleDataId, int skinId, EFlySkinType skinType)
	{
		List<int> list;
		if (!this.SkinIdToRoleIds.TryGetValue(skinId, out list))
		{
			return false;
		}
		int num = list.FindIndex((int roleId) => roleId == roleDataId);
		if (num == -1)
		{
			return false;
		}
		RoleFlySkinEquipData roleFlySkinEquipData;
		if (!this.RoleIdToRoleEquipData.TryGetValue(roleDataId, out roleFlySkinEquipData))
		{
			return false;
		}
		list.RemoveAt(num);
		roleFlySkinEquipData.SkinEquipMap.Remove(skinType);
		roleFlySkinEquipData.SkinEquipSet.Remove(skinId);
		return true;
	}

	// Token: 0x06015B64 RID: 88932 RVA: 0x0060666C File Offset: 0x0060486C
	public int GetRoleEquipFlySkinId(int roleDataId, EFlySkinType skinType)
	{
		RoleFlySkinEquipData roleFlySkinEquipData;
		if (!this.RoleIdToRoleEquipData.TryGetValue(roleDataId, out roleFlySkinEquipData))
		{
			return 0;
		}
		int result;
		if (roleFlySkinEquipData.SkinEquipMap.TryGetValue(skinType, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x06015B65 RID: 88933 RVA: 0x006066A0 File Offset: 0x006048A0
	public bool CheckAllRoleEquipFlySkin(int skinId, EFlySkinType skinType)
	{
		foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetOfficialRoleList())
		{
			int roleEquipFlySkinId = this.GetRoleEquipFlySkinId(roleInstance.GetDataId(), skinType);
			if (skinId != roleEquipFlySkinId)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06015B66 RID: 88934 RVA: 0x006066DF File Offset: 0x006048DF
	public bool CheckRoleEquipFlySkin(int roleDataId, int skinId, EFlySkinType skinType)
	{
		return this.GetRoleEquipFlySkinId(roleDataId, skinType) == skinId;
	}

	// Token: 0x06015B67 RID: 88935 RVA: 0x006066EC File Offset: 0x006048EC
	public int GetRoleEquipParaglidingSkinId(int roleDataId)
	{
		return this.GetRoleEquipFlySkinId(roleDataId, EFlySkinType.Paragliding);
	}

	// Token: 0x06015B68 RID: 88936 RVA: 0x006066F6 File Offset: 0x006048F6
	public int GetRoleEquipSoarWingSkinId(int roleDataId)
	{
		return this.GetRoleEquipFlySkinId(roleDataId, EFlySkinType.SoarWing);
	}

	// Token: 0x06015B69 RID: 88937 RVA: 0x00606700 File Offset: 0x00604900
	private bool TryAddFlySkinRedDot(int skinId)
	{
		if (skinId == 0)
		{
			return false;
		}
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.FlySkinRedDot, skinId))
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.FlySkinRedDot, skinId);
		return true;
	}

	// Token: 0x06015B6A RID: 88938 RVA: 0x00606728 File Offset: 0x00604928
	public bool CheckFlySkinHasRedDotBySkinType(EFlySkinType skinType)
	{
		foreach (FlySkinConfig flySkinConfig in ConfigBase<SkinConfig>.Instance.GetFlySkinConfigListByType(skinType))
		{
			if (this.CheckSkinIsUnlock(flySkinConfig.Id) && ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.FlySkinRedDot, flySkinConfig.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015B6B RID: 88939 RVA: 0x006067A0 File Offset: 0x006049A0
	public bool CheckFlySkinHasRedDot()
	{
		return this.CheckFlySkinHasRedDotBySkinType(EFlySkinType.Paragliding) || this.CheckFlySkinHasRedDotBySkinType(EFlySkinType.SoarWing);
	}

	// Token: 0x06015B6C RID: 88940 RVA: 0x006067B4 File Offset: 0x006049B4
	public FlySkinData GetFlySkinData(int itemId)
	{
		FlySkinData result;
		if (this.FlySkinMap.TryGetValue(itemId, out result))
		{
			return result;
		}
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId)) != InventoryDefine.EItemDataType.FlySkinItem)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FlySkin;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "无效的飞行皮肤道具id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		FlySkinData flySkinData = new FlySkinData(itemId);
		this.FlySkinMap.Add(itemId, flySkinData);
		return flySkinData;
	}

	// Token: 0x0400A6A5 RID: 42661
	private readonly HashSet<int> UnlockSkinIdSet = new HashSet<int>();

	// Token: 0x0400A6A6 RID: 42662
	private readonly Dictionary<int, List<int>> SkinIdToRoleIds = new Dictionary<int, List<int>>();

	// Token: 0x0400A6A7 RID: 42663
	private readonly Dictionary<int, RoleFlySkinEquipData> RoleIdToRoleEquipData = new Dictionary<int, RoleFlySkinEquipData>();

	// Token: 0x0400A6A8 RID: 42664
	private readonly Dictionary<int, FlySkinData> FlySkinMap = new Dictionary<int, FlySkinData>();
}
