using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002454 RID: 9300
[NullableContext(1)]
[Nullable(0)]
public class PhantomRoleEquipmentData
{
	// Token: 0x06012007 RID: 73735 RVA: 0x004F4E7C File Offset: 0x004F307C
	public PhantomRoleEquipmentData()
	{
		this.PhantomItemIncrId = new int[5];
	}

	// Token: 0x06012008 RID: 73736 RVA: 0x004F4E90 File Offset: 0x004F3090
	public void Phrase(object data)
	{
		RolePhantomEquipInfo rolePhantomEquipInfo = data as RolePhantomEquipInfo;
		if (rolePhantomEquipInfo != null)
		{
			this.RoleId = rolePhantomEquipInfo.RoleId;
			this.PhantomItemIncrId = ((rolePhantomEquipInfo.PhantomItemIncrId != null) ? rolePhantomEquipInfo.PhantomItemIncrId.ToArray<int>() : new int[5]);
			return;
		}
		RolePhantomPropInfo rolePhantomPropInfo = data as RolePhantomPropInfo;
		if (rolePhantomPropInfo != null)
		{
			this.Prop = rolePhantomPropInfo;
		}
	}

	// Token: 0x06012009 RID: 73737 RVA: 0x004F4EE6 File Offset: 0x004F30E6
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x0601200A RID: 73738 RVA: 0x004F4EF0 File Offset: 0x004F30F0
	public void RemoveIncrIdLocal(int uniqueId)
	{
		if (uniqueId > 0)
		{
			int num = Array.IndexOf<int>(this.PhantomItemIncrId, uniqueId);
			if (num >= 0)
			{
				this.PhantomItemIncrId[num] = 0;
			}
		}
	}

	// Token: 0x0601200B RID: 73739 RVA: 0x004F4F1B File Offset: 0x004F311B
	public List<int> GetIncrIdList()
	{
		return this.PhantomItemIncrId.ToList<int>();
	}

	// Token: 0x0601200C RID: 73740 RVA: 0x004F4F28 File Offset: 0x004F3128
	[NullableContext(2)]
	public RolePhantomPropInfo GetPropData()
	{
		return this.Prop;
	}

	// Token: 0x0601200D RID: 73741 RVA: 0x004F4F30 File Offset: 0x004F3130
	public bool CheckPhantomIsMain(int uniqueId)
	{
		return this.PhantomItemIncrId.Length != 0 && this.PhantomItemIncrId[0] == uniqueId;
	}

	// Token: 0x0601200E RID: 73742 RVA: 0x004F4F48 File Offset: 0x004F3148
	public bool CheckPhantomIsSub(int uniqueId)
	{
		return this.PhantomItemIncrId.Length != 0 && this.PhantomItemIncrId[0] != uniqueId && Array.IndexOf<int>(this.PhantomItemIncrId, uniqueId) >= 0;
	}

	// Token: 0x0601200F RID: 73743 RVA: 0x004F4F74 File Offset: 0x004F3174
	public bool CheckMonsterIsEquip(int monsterId)
	{
		int num = this.PhantomItemIncrId.Length;
		for (int i = 0; i < num; i++)
		{
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.PhantomItemIncrId[i]);
			if (phantomItemDataByUniqueId != null && phantomItemDataByUniqueId.GetMonsterId(false) == monsterId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012010 RID: 73744 RVA: 0x004F4FBC File Offset: 0x004F31BC
	public int GetPhantomIndex(int uniqueId)
	{
		int num = this.PhantomItemIncrId.Length;
		for (int i = 0; i < num; i++)
		{
			if (this.PhantomItemIncrId[i] == uniqueId)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06012011 RID: 73745 RVA: 0x004F4FEC File Offset: 0x004F31EC
	public int GetIndexPhantomId(int index)
	{
		if (this.PhantomItemIncrId.Length <= index)
		{
			return 0;
		}
		return this.PhantomItemIncrId[index];
	}

	// Token: 0x06012012 RID: 73746 RVA: 0x004F5004 File Offset: 0x004F3204
	public int GetSumEquipLevel()
	{
		int num = 0;
		foreach (int uniqueId in this.PhantomItemIncrId)
		{
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(uniqueId);
			if (phantomItemDataByUniqueId != null)
			{
				num += phantomItemDataByUniqueId.GetPhantomLevel();
			}
		}
		return num;
	}

	// Token: 0x06012013 RID: 73747 RVA: 0x004F5048 File Offset: 0x004F3248
	public int GetAverageEquipLevel()
	{
		int num = this.PhantomItemIncrId.Length;
		if (num <= 0)
		{
			return 0;
		}
		return this.GetSumEquipLevel() / num;
	}

	// Token: 0x06012014 RID: 73748 RVA: 0x004F506C File Offset: 0x004F326C
	public EEquipType GetPhantomOperationState(int index, int uniqueId)
	{
		int num = this.PhantomItemIncrId[index];
		if (num == 0)
		{
			return EEquipType.Equip;
		}
		if (num == uniqueId)
		{
			return EEquipType.UnEquip;
		}
		return EEquipType.Replace;
	}

	// Token: 0x06012015 RID: 73749 RVA: 0x004F5090 File Offset: 0x004F3290
	public int GetCombinationActiveNum(List<int> monsterIdList)
	{
		int num = 0;
		List<int> list = new List<int>();
		foreach (int num2 in monsterIdList)
		{
			foreach (int uniqueId in this.GetIncrIdList())
			{
				PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(uniqueId);
				if (phantomItemDataByUniqueId != null && num2 == phantomItemDataByUniqueId.GetMonsterId(false) && !list.Contains(num2))
				{
					list.Add(num2);
					num++;
				}
			}
		}
		return monsterIdList.Count - num;
	}

	// Token: 0x06012016 RID: 73750 RVA: 0x004F5158 File Offset: 0x004F3358
	public List<AttrListScrollData> GetPropDetailAttributeList()
	{
		IEnumerable<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("VisionMainViewExtraAttribute");
		List<AttrListScrollData> propShowAttributeList = this.GetPropShowAttributeList();
		int count = propShowAttributeList.Count;
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		foreach (int num in intArrayConfig)
		{
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				if (propShowAttributeList[i].Id == num)
				{
					list.Add(propShowAttributeList[i]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(new RoleAttrListScrollData(num, 0.0, 0.0, ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(num).Value.Priority, false, CommonComponentDefine.EAttributeType.PhantomType));
			}
		}
		return list;
	}

	// Token: 0x06012017 RID: 73751 RVA: 0x004F523C File Offset: 0x004F343C
	public List<AttrListScrollData> GetPropShowAttributeList()
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		RolePhantomPropInfo prop = this.Prop;
		if (((prop != null) ? prop.BaseProp : null) != null)
		{
			foreach (ArrayIntInt arrayIntInt in this.Prop.BaseProp)
			{
				dictionary[arrayIntInt.Key] = arrayIntInt.Value;
			}
		}
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		RolePhantomPropInfo prop2 = this.Prop;
		if (((prop2 != null) ? prop2.AddProp : null) != null)
		{
			foreach (ArrayIntInt arrayIntInt2 in this.Prop.AddProp)
			{
				dictionary2[arrayIntInt2.Key] = arrayIntInt2.Value;
				if (!dictionary.ContainsKey(arrayIntInt2.Key))
				{
					dictionary[arrayIntInt2.Key] = 0;
				}
			}
		}
		List<int> list2 = new List<int>(dictionary.Keys);
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(list2[i]);
			int num;
			if (!dictionary2.TryGetValue(list2[i], out num))
			{
				num = 0;
			}
			list.Add(new RoleAttrListScrollData(list2[i], (double)dictionary[list2[i]], (double)num, propertyIndexInfo.Value.Priority, false, CommonComponentDefine.EAttributeType.PhantomType));
		}
		return list;
	}

	// Token: 0x06012018 RID: 73752 RVA: 0x004F53D4 File Offset: 0x004F35D4
	public bool CheckHasEmpty()
	{
		if (this.PhantomItemIncrId == null)
		{
			return false;
		}
		return Array.FindIndex<int>(this.PhantomItemIncrId, (int x) => x == 0) >= 0;
	}

	// Token: 0x06012019 RID: 73753 RVA: 0x004F5410 File Offset: 0x004F3610
	public int GetEquippedNum()
	{
		if (this.PhantomItemIncrId == null)
		{
			return 0;
		}
		int num = 0;
		int[] phantomItemIncrId = this.PhantomItemIncrId;
		for (int i = 0; i < phantomItemIncrId.Length; i++)
		{
			if (phantomItemIncrId[i] > 0)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x04008CF5 RID: 36085
	private int RoleId;

	// Token: 0x04008CF6 RID: 36086
	private int[] PhantomItemIncrId;

	// Token: 0x04008CF7 RID: 36087
	[Nullable(2)]
	private RolePhantomPropInfo Prop;
}
