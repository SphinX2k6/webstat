using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020027BD RID: 10173
[NullableContext(1)]
[Nullable(0)]
public class RolePhantomData : RoleModuleDataBase
{
	// Token: 0x060141D9 RID: 82393 RVA: 0x0059E4F9 File Offset: 0x0059C6F9
	public RolePhantomData(int roleId) : base(roleId)
	{
	}

	// Token: 0x060141DA RID: 82394 RVA: 0x0059E523 File Offset: 0x0059C723
	public void RefreshPhantom(int key, int value)
	{
		this.PhantomMap[key] = value;
	}

	// Token: 0x060141DB RID: 82395 RVA: 0x0059E532 File Offset: 0x0059C732
	public void SetIsTrial(bool isTrial)
	{
		this.IsTrial = isTrial;
	}

	// Token: 0x060141DC RID: 82396 RVA: 0x0059E53B File Offset: 0x0059C73B
	public void SetDataMap(int position, PhantomDataBase data)
	{
		this.DataMap[position] = data;
	}

	// Token: 0x060141DD RID: 82397 RVA: 0x0059E54C File Offset: 0x0059C74C
	public Dictionary<int, PhantomDataBase> GetDataMap()
	{
		if (this.IsTrial)
		{
			return this.DataMap;
		}
		List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(this.RoleId).GetIncrIdList();
		if (incrIdList == null)
		{
			return this.DataMap;
		}
		int i = 0;
		int count = incrIdList.Count;
		while (i < count)
		{
			int uniqueId = incrIdList[i];
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			this.DataMap[i] = phantomBattleData;
			i++;
		}
		return this.DataMap;
	}

	// Token: 0x060141DE RID: 82398 RVA: 0x0059E5C4 File Offset: 0x0059C7C4
	public List<int> GetIncrIdList()
	{
		return ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(this.RoleId).GetIncrIdList();
	}

	// Token: 0x060141DF RID: 82399 RVA: 0x0059E5DC File Offset: 0x0059C7DC
	[NullableContext(2)]
	public PhantomDataBase GetDataByIndex(int index)
	{
		PhantomDataBase result;
		if (!this.GetDataMap().TryGetValue(index, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x060141E0 RID: 82400 RVA: 0x0059E5FC File Offset: 0x0059C7FC
	public VisionFetterData[] GetPhantomFettersData()
	{
		List<VisionFetterData> list = new List<VisionFetterData>();
		foreach (KeyValuePair<int, Dictionary<int, int>> keyValuePair in this.GetPhantomFetterMap())
		{
			int key = keyValuePair.Key;
			foreach (KeyValuePair<int, int> keyValuePair2 in keyValuePair.Value)
			{
				int key2 = keyValuePair2.Key;
				int value = keyValuePair2.Value;
				list.Add(new VisionFetterData
				{
					FetterGroupId = key,
					FetterId = key2,
					NeedActiveNum = value,
					ActiveFetterGroupNum = value,
					ActiveState = true
				});
			}
		}
		return list.ToArray();
	}

	// Token: 0x060141E1 RID: 82401 RVA: 0x0059E6EC File Offset: 0x0059C8EC
	public Dictionary<int, Dictionary<int, int>> GetPhantomFetterMap()
	{
		Dictionary<int, int> fetterGroupSuitMap = this.GetFetterGroupSuitMap();
		return ConfigBase<PhantomBattleConfig>.Instance.GetFetterMapResultBySuitMap(fetterGroupSuitMap);
	}

	// Token: 0x060141E2 RID: 82402 RVA: 0x0059E70C File Offset: 0x0059C90C
	public List<int> GetPhantomFettersList()
	{
		Dictionary<int, int> fetterGroupSuitMap = this.GetFetterGroupSuitMap();
		this.FettersList = ConfigBase<PhantomBattleConfig>.Instance.GetFetterResultBySuitMap(fetterGroupSuitMap);
		return this.FettersList;
	}

	// Token: 0x060141E3 RID: 82403 RVA: 0x0059E738 File Offset: 0x0059C938
	private Dictionary<int, int> GetFetterGroupSuitMap()
	{
		Dictionary<int, PhantomDataBase> dataMap = this.GetDataMap();
		List<PhantomDataBase> list = new List<PhantomDataBase>();
		foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in dataMap)
		{
			int key = keyValuePair.Key;
			PhantomDataBase value = keyValuePair.Value;
			if (value != null)
			{
				list.Add(value);
			}
		}
		return PhantomDataBase.CalculateFetterByPhantomBattleData(list);
	}

	// Token: 0x060141E4 RID: 82404 RVA: 0x0059E7AC File Offset: 0x0059C9AC
	public void ClearPhantomFettersList()
	{
		this.FettersList.Clear();
	}

	// Token: 0x04009C75 RID: 40053
	protected Dictionary<int, int> PhantomMap = new Dictionary<int, int>();

	// Token: 0x04009C76 RID: 40054
	private bool IsTrial;

	// Token: 0x04009C77 RID: 40055
	private readonly Dictionary<int, PhantomDataBase> DataMap = new Dictionary<int, PhantomDataBase>();

	// Token: 0x04009C78 RID: 40056
	private List<int> FettersList = new List<int>();
}
