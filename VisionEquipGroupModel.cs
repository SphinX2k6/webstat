using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x0200249E RID: 9374
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class VisionEquipGroupModel : ModelBase<VisionEquipGroupModel>
{
	// Token: 0x060122FD RID: 74493 RVA: 0x00500D30 File Offset: 0x004FEF30
	public VisionEquipGroupModel()
	{
		this.VisionEquipGroupList = new List<VisionEquipGroupData>();
	}

	// Token: 0x060122FE RID: 74494 RVA: 0x00500D44 File Offset: 0x004FEF44
	public void RefreshVisionEquipGroupData(List<PhantomEquipGroupInfo> data)
	{
		this.VisionEquipGroupList = new List<VisionEquipGroupData>();
		int count = data.Count;
		for (int i = 0; i < count; i++)
		{
			VisionEquipGroupData visionEquipGroupData = new VisionEquipGroupData();
			visionEquipGroupData.Phrase(i, data[i]);
			this.VisionEquipGroupList.Add(visionEquipGroupData);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionGroupDataUpdate);
	}

	// Token: 0x060122FF RID: 74495 RVA: 0x00500DA0 File Offset: 0x004FEFA0
	public bool CheckVisionListIfInGroup(List<int> incIdList)
	{
		int count = this.VisionEquipGroupList.Count;
		for (int i = 0; i < count; i++)
		{
			VisionEquipGroupData visionEquipGroupData = this.VisionEquipGroupList[i];
			bool flag = true;
			foreach (int value in incIdList)
			{
				if (!visionEquipGroupData.GetVisionUniqueIdList().Contains(value))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012300 RID: 74496 RVA: 0x00500E2C File Offset: 0x004FF02C
	public List<VisionEquipGroupData> GetVisionEquipGroupList()
	{
		return this.VisionEquipGroupList;
	}

	// Token: 0x06012301 RID: 74497 RVA: 0x00500E34 File Offset: 0x004FF034
	[NullableContext(2)]
	public VisionEquipGroupData GetVisionEquipGroupDataByIndex(int index)
	{
		foreach (VisionEquipGroupData visionEquipGroupData in this.VisionEquipGroupList)
		{
			if (visionEquipGroupData.GetIndex() == index)
			{
				return visionEquipGroupData;
			}
		}
		return null;
	}

	// Token: 0x06012302 RID: 74498 RVA: 0x00500E90 File Offset: 0x004FF090
	public List<VisionFetterData> GetVisionFetterDataByIncIdList(List<int> incIdList)
	{
		List<PhantomDataBase> list = new List<PhantomDataBase>();
		int count = incIdList.Count;
		for (int i = 0; i < count; i++)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incIdList[i]);
			if (phantomBattleData != null)
			{
				list.Add(phantomBattleData);
			}
		}
		Dictionary<int, int> suitMap = PhantomDataBase.CalculateFetterByPhantomBattleData(list);
		Dictionary<int, Dictionary<int, int>> fetterMapResultBySuitMap = ConfigBase<PhantomBattleConfig>.Instance.GetFetterMapResultBySuitMap(suitMap);
		List<VisionFetterData> list2 = new List<VisionFetterData>();
		foreach (KeyValuePair<int, Dictionary<int, int>> keyValuePair in fetterMapResultBySuitMap)
		{
			int key = keyValuePair.Key;
			foreach (KeyValuePair<int, int> keyValuePair2 in keyValuePair.Value)
			{
				int key2 = keyValuePair2.Key;
				int value = keyValuePair2.Value;
				list2.Add(new VisionFetterData
				{
					FetterGroupId = key,
					FetterId = key2,
					NeedActiveNum = value,
					ActiveFetterGroupNum = value,
					ActiveState = true
				});
			}
		}
		return list2;
	}

	// Token: 0x06012303 RID: 74499 RVA: 0x00500FC8 File Offset: 0x004FF1C8
	public List<VisionAssembleAttrData> GetVisionAssembleViewAttrData(int groupIndex, bool compareMode, int currentSelectRoleId)
	{
		List<int> incIdList;
		if (groupIndex == -1)
		{
			incIdList = ModelBase<RoleModel>.Instance.GetRoleDataById(currentSelectRoleId, true).GetPhantomData().GetIncrIdList();
		}
		else
		{
			VisionEquipGroupData visionEquipGroupDataByIndex = this.GetVisionEquipGroupDataByIndex(groupIndex);
			if (visionEquipGroupDataByIndex == null)
			{
				return new List<VisionAssembleAttrData>();
			}
			incIdList = new List<int>(visionEquipGroupDataByIndex.GetVisionUniqueIdList());
		}
		List<VisionAssembleAttrData> visionAttrDataListByIncIdList = this.GetVisionAttrDataListByIncIdList(incIdList, compareMode);
		if (!compareMode)
		{
			visionAttrDataListByIncIdList.Sort(new Comparison<VisionAssembleAttrData>(this.SortAttrList));
			return visionAttrDataListByIncIdList;
		}
		List<VisionAssembleAttrData> currentRoleAttrData = this.GetCurrentRoleAttrData(currentSelectRoleId, compareMode);
		this.CombineAttrList(visionAttrDataListByIncIdList, currentRoleAttrData);
		visionAttrDataListByIncIdList.Sort(new Comparison<VisionAssembleAttrData>(this.SortAttrList));
		return visionAttrDataListByIncIdList;
	}

	// Token: 0x06012304 RID: 74500 RVA: 0x00501054 File Offset: 0x004FF254
	private int SortAttrList(VisionAssembleAttrData dataB, VisionAssembleAttrData dataA)
	{
		int priority = dataA.GetPriority();
		int priority2 = dataB.GetPriority();
		bool flag = priority != 0;
		bool flag2 = priority2 != 0;
		if (flag && flag2)
		{
			if (priority == priority2)
			{
				int num = (!dataA.IfPercentage) ? 1 : 0;
				int num2 = (!dataB.IfPercentage) ? 1 : 0;
				return num - num2;
			}
			return priority - priority2;
		}
		else
		{
			if (flag)
			{
				return -1;
			}
			if (flag2)
			{
				return 1;
			}
			return dataA.GetId() - dataB.GetId();
		}
	}

	// Token: 0x06012305 RID: 74501 RVA: 0x005010B8 File Offset: 0x004FF2B8
	private void CombineAttrList(List<VisionAssembleAttrData> compareAttrDataList, List<VisionAssembleAttrData> currentAttrDataList)
	{
		int count = currentAttrDataList.Count;
		for (int i = 0; i < count; i++)
		{
			VisionAssembleAttrData visionAssembleAttrData = currentAttrDataList[i];
			bool flag = false;
			foreach (VisionAssembleAttrData visionAssembleAttrData2 in compareAttrDataList)
			{
				if (visionAssembleAttrData2.AttrId == visionAssembleAttrData.AttrId && visionAssembleAttrData2.IfPercentage == visionAssembleAttrData.IfPercentage)
				{
					visionAssembleAttrData2.CompareValue = visionAssembleAttrData.CurrentValue;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				compareAttrDataList.Add(new VisionAssembleAttrData
				{
					AttrId = visionAssembleAttrData.AttrId,
					IfPercentage = visionAssembleAttrData.IfPercentage,
					CompareValue = visionAssembleAttrData.CurrentValue,
					CompareMode = true
				});
			}
		}
	}

	// Token: 0x06012306 RID: 74502 RVA: 0x00501194 File Offset: 0x004FF394
	private List<VisionAssembleAttrData> GetCurrentRoleAttrData(int currentSelectRoleId, bool compareMode)
	{
		List<int> incrIdList = ModelBase<RoleModel>.Instance.GetRoleDataById(currentSelectRoleId, true).GetPhantomData().GetIncrIdList();
		return this.GetVisionAttrDataListByIncIdList(incrIdList, compareMode);
	}

	// Token: 0x06012307 RID: 74503 RVA: 0x005011C0 File Offset: 0x004FF3C0
	private List<VisionAssembleAttrData> GetVisionAttrDataListByIncIdList(List<int> incIdList, bool compareMode)
	{
		List<VisionAssembleAttrData> list = new List<VisionAssembleAttrData>();
		int count = incIdList.Count;
		for (int i = 0; i < count; i++)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incIdList[i]);
			if (phantomBattleData != null)
			{
				foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in phantomBattleData.GetPhantomMainProp())
				{
					PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropInfo.PhantomPropId);
					bool flag = phantomMainPropertyItemId.AddType == 2;
					bool flag2 = false;
					foreach (VisionAssembleAttrData visionAssembleAttrData in list)
					{
						if (visionAssembleAttrData.AttrId == phantomMainPropertyItemId.PropId && visionAssembleAttrData.IfPercentage == flag)
						{
							visionAssembleAttrData.CurrentValue += phantomPropInfo.Value;
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						VisionAssembleAttrData visionAssembleAttrData2 = new VisionAssembleAttrData();
						visionAssembleAttrData2.AttrId = phantomMainPropertyItemId.PropId;
						visionAssembleAttrData2.IfPercentage = flag;
						visionAssembleAttrData2.CurrentValue += phantomPropInfo.Value;
						visionAssembleAttrData2.CompareMode = compareMode;
						list.Add(visionAssembleAttrData2);
					}
				}
				foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo2 in phantomBattleData.GetPhantomSubProp())
				{
					PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo2.PhantomPropId);
					bool flag3 = phantomSubPropertyById.AddType == 2;
					bool flag4 = false;
					foreach (VisionAssembleAttrData visionAssembleAttrData3 in list)
					{
						if (visionAssembleAttrData3.AttrId == phantomSubPropertyById.PropId && visionAssembleAttrData3.IfPercentage == flag3)
						{
							visionAssembleAttrData3.CurrentValue += phantomPropInfo2.Value;
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						VisionAssembleAttrData visionAssembleAttrData4 = new VisionAssembleAttrData();
						visionAssembleAttrData4.AttrId = phantomSubPropertyById.PropId;
						visionAssembleAttrData4.IfPercentage = flag3;
						visionAssembleAttrData4.CurrentValue += phantomPropInfo2.Value;
						visionAssembleAttrData4.CompareMode = compareMode;
						list.Add(visionAssembleAttrData4);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06012308 RID: 74504 RVA: 0x0050143C File Offset: 0x004FF63C
	public void SaveLocalTopTipState(bool state)
	{
		int value = (state > false) ? 1 : 0;
		LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.VisionTopTipsState, value);
	}

	// Token: 0x06012309 RID: 74505 RVA: 0x00501457 File Offset: 0x004FF657
	public bool GetLocalTipsState()
	{
		return LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.VisionTopTipsState, 0) == 1;
	}

	// Token: 0x0601230A RID: 74506 RVA: 0x00501464 File Offset: 0x004FF664
	public bool GetVisionGroupFirstOpenState()
	{
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.VisionGroup);
		ServerStorageUtil.OverrideLocalBooleanToServerBoolean(ELocalStoragePlayerKey.FirstOpenVisionGroup, EClientStorageSystemIdType.FirstOpenVisionGroup);
		return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FirstOpenVisionGroup) as ServerStorageBoolean).Get().GetValueOrDefault(true) && flag;
	}

	// Token: 0x0601230B RID: 74507 RVA: 0x005014AC File Offset: 0x004FF6AC
	public void SaveVisionGroupFirstOpenState(bool state)
	{
		(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FirstOpenVisionGroup) as ServerStorageBoolean).Set(new bool?(state));
	}

	// Token: 0x04008DF4 RID: 36340
	private List<VisionEquipGroupData> VisionEquipGroupList;

	// Token: 0x04008DF5 RID: 36341
	public int FilterDataLength;
}
