using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using Google.Protobuf.Collections;

// Token: 0x0200244E RID: 9294
[NullableContext(1)]
[Nullable(0)]
public abstract class PhantomDataBase
{
	// Token: 0x06011F6E RID: 73582 RVA: 0x004F169A File Offset: 0x004EF89A
	public void SetPhantomLevel(int level)
	{
		this.PhantomLevel = level;
	}

	// Token: 0x06011F6F RID: 73583 RVA: 0x004F16A3 File Offset: 0x004EF8A3
	public static int GenerateLocalUniqueId(int roleId, int slotIndex)
	{
		return -1 * (roleId * 10) - slotIndex;
	}

	// Token: 0x06011F70 RID: 73584 RVA: 0x004F16AD File Offset: 0x004EF8AD
	public void SetIncId(int id)
	{
		this.IncrId = id;
	}

	// Token: 0x06011F71 RID: 73585 RVA: 0x004F16B6 File Offset: 0x004EF8B6
	public int GetPhantomLevel()
	{
		return this.PhantomLevel;
	}

	// Token: 0x06011F72 RID: 73586 RVA: 0x004F16BE File Offset: 0x004EF8BE
	public bool GetVisionNoCultivated()
	{
		return this.GetPhantomLevel() == 0 && this.GetExp() == 0;
	}

	// Token: 0x06011F73 RID: 73587 RVA: 0x004F16D3 File Offset: 0x004EF8D3
	public bool GetVisionIfCanRecovery(bool onlyGold)
	{
		return (!onlyGold || this.GetQuality() >= 5) && this.GetVisionNoCultivated() && !this.GetIsLock();
	}

	// Token: 0x06011F74 RID: 73588 RVA: 0x004F16F6 File Offset: 0x004EF8F6
	public bool GetVisionIfCanRefine(EVisionRefineRefineType refineType)
	{
		if (this.GetQuality() < 5)
		{
			return false;
		}
		if (refineType == EVisionRefineRefineType.Main)
		{
			return this.GetVisionNoCultivated();
		}
		return refineType == EVisionRefineRefineType.Sub && this.GetMaxSubPropCount() == this.PhantomSubProp.Count;
	}

	// Token: 0x06011F75 RID: 73589 RVA: 0x004F1726 File Offset: 0x004EF926
	public bool IsMax()
	{
		return this.PhantomLevel >= ControllerBase<PhantomBattleController>.Instance.GetMaxLevel(this.IncrId);
	}

	// Token: 0x06011F76 RID: 73590 RVA: 0x004F1743 File Offset: 0x004EF943
	public void SetPhantomExp(int exp)
	{
		this.PhantomExp = exp;
	}

	// Token: 0x06011F77 RID: 73591 RVA: 0x004F174C File Offset: 0x004EF94C
	public PhantomBattleInstance CurrentPhantomInstance()
	{
		return this.GetPhantomInstanceWithSkinId();
	}

	// Token: 0x06011F78 RID: 73592 RVA: 0x004F1754 File Offset: 0x004EF954
	[NullableContext(2)]
	public PhantomPropSlot GetCurrentSuspendSlotData()
	{
		return this.SuspendSlot;
	}

	// Token: 0x06011F79 RID: 73593 RVA: 0x004F175C File Offset: 0x004EF95C
	public virtual int GetFetterGroupId()
	{
		return this.FetterGroupId;
	}

	// Token: 0x06011F7A RID: 73594 RVA: 0x004F1764 File Offset: 0x004EF964
	public int GetEatFullExp()
	{
		int value = ConfigCommonParamById.GetIntConfig("PhantomExpReturnRatio").Value;
		return (int)Math.Floor((double)(this.GetFullExp() * value) / 1000.0);
	}

	// Token: 0x06011F7B RID: 73595 RVA: 0x004F17A0 File Offset: 0x004EF9A0
	public int GetFullExp()
	{
		if (this.GetPhantomLevel() == 0)
		{
			return this.PhantomExp;
		}
		int num = 0;
		for (int i = 1; i <= this.GetPhantomLevel(); i++)
		{
			num += ConfigBase<PhantomBattleConfig>.Instance.GetPhantomLevelExpByGroupIdAndLevel(this.GetPhantomInstance().PhantomItem.Value.LevelUpGroupId, i);
		}
		return num + this.PhantomExp;
	}

	// Token: 0x06011F7C RID: 73596 RVA: 0x004F1800 File Offset: 0x004EFA00
	public int GetExp()
	{
		return this.PhantomExp;
	}

	// Token: 0x06011F7D RID: 73597 RVA: 0x004F1808 File Offset: 0x004EFA08
	public void UpdateData(Aki.Protocol.PhantomItem data)
	{
		this.IncrId = data.IncrId;
		this.FuncValue = data.FuncValue;
		this.PhantomLevel = data.PhantomLevel;
		this.PhantomExp = data.PhantomExp;
		this.PhantomMainProp = data.PhantomMainProp.ToList<Aki.Protocol.PhantomPropInfo>();
		this.PhantomSubProp = data.PhantomSubProp.ToList<Aki.Protocol.PhantomPropInfo>();
		this.FetterGroupId = data.FetterGroupId;
		this.SkinIdInternal = data.SkinId;
		this.UnAckSubProp = data.UnAckSubProp.ToList<Aki.Protocol.PhantomPropInfo>();
		this.LockSubPropIndices = data.LockPropIndex.ToList<int>();
	}

	// Token: 0x06011F7E RID: 73598 RVA: 0x004F18A1 File Offset: 0x004EFAA1
	public void SetMainProp(List<Aki.Protocol.PhantomPropInfo> data)
	{
		this.PhantomMainProp = data;
	}

	// Token: 0x06011F7F RID: 73599 RVA: 0x004F18AA File Offset: 0x004EFAAA
	public void SetSubProp(List<Aki.Protocol.PhantomPropInfo> data)
	{
		this.PhantomSubProp = data;
	}

	// Token: 0x06011F80 RID: 73600 RVA: 0x004F18B3 File Offset: 0x004EFAB3
	public int GetIncrId()
	{
		return this.IncrId;
	}

	// Token: 0x06011F81 RID: 73601 RVA: 0x004F18BB File Offset: 0x004EFABB
	public void OnFunctionValueChange(int value)
	{
		this.FuncValue = value;
	}

	// Token: 0x06011F82 RID: 73602 RVA: 0x004F18C4 File Offset: 0x004EFAC4
	public List<AttrListScrollData> GetSuspendAttributeData()
	{
		RepeatedField<Aki.Protocol.PhantomPropInfo> phantomProp = this.SuspendSlot.PhantomProp;
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in phantomProp)
		{
			PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo.PhantomPropId);
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(phantomPropInfo.PhantomPropId);
			bool isRatio = phantomSubPropertyById.AddType == 2;
			double propRatioValue = TipsDataTool.GetPropRatioValue((double)phantomPropInfo.Value, isRatio);
			list.Add(new AttrListScrollData(phantomSubPropertyById.PropId, 0.0, propRatioValue, propertyIndexInfo.Value.Priority, isRatio, CommonComponentDefine.EAttributeType.PhantomType));
		}
		return list;
	}

	// Token: 0x06011F83 RID: 73603 RVA: 0x004F1988 File Offset: 0x004EFB88
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<AttrListScrollData> GetSlotIndexAttributeData(int index, CommonComponentDefine.EAttributeType attributeType)
	{
		if (this.GetSlotIndexDataEx(index) != null)
		{
			Aki.Protocol.PhantomPropInfo slotIndexDataEx = this.GetSlotIndexDataEx(index);
			List<AttrListScrollData> list = new List<AttrListScrollData>();
			PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(slotIndexDataEx.PhantomPropId);
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(slotIndexDataEx.PhantomPropId);
			bool isRatio = phantomSubPropertyById.AddType == 2;
			double propRatioValue = TipsDataTool.GetPropRatioValue((double)slotIndexDataEx.Value, isRatio);
			list.Add(new AttrListScrollData(phantomSubPropertyById.PropId, 0.0, propRatioValue, propertyIndexInfo.Value.Priority, isRatio, attributeType));
			return list;
		}
		return null;
	}

	// Token: 0x06011F84 RID: 73604 RVA: 0x004F1A18 File Offset: 0x004EFC18
	public bool IsFunctionValue(InventoryDefine.EItemDataFunctionType functionType)
	{
		return (this.FuncValue & 1 << (int)functionType) > 0;
	}

	// Token: 0x06011F85 RID: 73605 RVA: 0x004F1A2A File Offset: 0x004EFC2A
	public bool GetIsLock()
	{
		return this.IsFunctionValue(InventoryDefine.EItemDataFunctionType.Lock);
	}

	// Token: 0x06011F86 RID: 73606 RVA: 0x004F1A33 File Offset: 0x004EFC33
	public bool GetIsDeprecated()
	{
		return this.IsFunctionValue(InventoryDefine.EItemDataFunctionType.Deprecate);
	}

	// Token: 0x06011F87 RID: 73607 RVA: 0x004F1A3C File Offset: 0x004EFC3C
	public int GetEquipRoleId()
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(this.GetIncrId()).GetValueOrDefault();
	}

	// Token: 0x06011F88 RID: 73608 RVA: 0x004F1A64 File Offset: 0x004EFC64
	public int GetEquipRoleIndex()
	{
		int equipRoleId = this.GetEquipRoleId();
		if (equipRoleId > 0)
		{
			List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(equipRoleId).GetIncrIdList();
			if (incrIdList.Contains(this.GetIncrId()))
			{
				return incrIdList.IndexOf(this.GetIncrId());
			}
		}
		return -1;
	}

	// Token: 0x06011F89 RID: 73609 RVA: 0x004F1AAC File Offset: 0x004EFCAC
	public string GetNameColor()
	{
		return ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(this.GetQuality()).Value.DropColor;
	}

	// Token: 0x06011F8A RID: 73610 RVA: 0x004F1ADC File Offset: 0x004EFCDC
	private IReadOnlyList<int> CalculateFinalIncList(int index, int roleId)
	{
		List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIncrIdList();
		if (index == -1)
		{
			return incrIdList;
		}
		int indexPhantomId = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIndexPhantomId(index);
		int incrId = this.GetIncrId();
		if (indexPhantomId == incrId)
		{
			return incrIdList;
		}
		List<int> list = new List<int>(ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIncrIdList());
		if (indexPhantomId == 0)
		{
			if (this.GetEquipRoleId() == roleId)
			{
				int equipRoleIndex = this.GetEquipRoleIndex();
				list[equipRoleIndex] = 0;
				list[index] = incrId;
			}
			else
			{
				list[index] = incrId;
			}
		}
		else if (indexPhantomId != incrId)
		{
			if (this.GetEquipRoleId() == roleId)
			{
				int equipRoleIndex2 = this.GetEquipRoleIndex();
				list[equipRoleIndex2] = list[index];
				list[index] = incrId;
			}
			else
			{
				list[index] = incrId;
			}
		}
		return list;
	}

	// Token: 0x06011F8B RID: 73611 RVA: 0x004F1BA0 File Offset: 0x004EFDA0
	[return: Nullable(2)]
	public static Dictionary<int, int> CalculateFetterByPhantomBattleData(List<PhantomDataBase> phantomBattleData)
	{
		int count = phantomBattleData.Count;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, List<int>> dictionary2 = new Dictionary<int, List<int>>();
		for (int i = 0; i < count; i++)
		{
			PhantomDataBase phantomDataBase = phantomBattleData[i];
			if (phantomDataBase != null)
			{
				int fetterGroupId = phantomDataBase.GetFetterGroupId();
				List<int> list;
				if (!dictionary2.TryGetValue(fetterGroupId, out list))
				{
					list = new List<int>();
				}
				if (!list.Contains(phantomDataBase.GetMonsterId(false)))
				{
					int num;
					if (!dictionary.TryGetValue(fetterGroupId, out num))
					{
						num = 0;
					}
					int value = num + 1;
					dictionary[fetterGroupId] = value;
					list.Add(phantomDataBase.GetMonsterId(false));
				}
				dictionary2[fetterGroupId] = list;
			}
		}
		return dictionary;
	}

	// Token: 0x06011F8C RID: 73612 RVA: 0x004F1C40 File Offset: 0x004EFE40
	public bool IfEquipSameNameMonsterOnRole(int index, int roleId)
	{
		List<int> list = new List<int>();
		foreach (int uniqueId in this.CalculateFinalIncList(index, roleId))
		{
			PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId);
			if (phantomDataBase != null)
			{
				list.Add(phantomDataBase.GetMonsterId(false));
			}
		}
		HashSet<int> hashSet = new HashSet<int>(list);
		return list.Count != hashSet.Count;
	}

	// Token: 0x06011F8D RID: 73613 RVA: 0x004F1CC8 File Offset: 0x004EFEC8
	public bool IfEquipOverNeedOnRole(List<VisionFetterData> fetterData)
	{
		if (fetterData.Count <= 0)
		{
			return false;
		}
		VisionFetterData visionFetterData = fetterData[0];
		for (int i = 1; i < fetterData.Count; i++)
		{
			if (fetterData[i].NeedActiveNum > visionFetterData.NeedActiveNum)
			{
				visionFetterData = fetterData[i];
			}
		}
		return visionFetterData.ActiveFetterGroupNum > visionFetterData.NeedActiveNum;
	}

	// Token: 0x06011F8E RID: 73614 RVA: 0x004F1D24 File Offset: 0x004EFF24
	public List<VisionFetterData> GetPreviewShowFetterList(int index, int roleId)
	{
		List<VisionFetterData> list = new List<VisionFetterData>();
		if (this.FetterGroupId <= 0)
		{
			return list;
		}
		Dictionary<int, int> fetterGroupFetterDataById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupFetterDataById(this.FetterGroupId);
		IReadOnlyList<int> readOnlyList = this.CalculateFinalIncList(index, roleId);
		VisionFetterData[] roleFetterData = ModelBase<PhantomBattleModel>.Instance.GetRoleFetterData(roleId);
		int count = readOnlyList.Count;
		List<PhantomDataBase> list2 = new List<PhantomDataBase>();
		for (int i = 0; i < count; i++)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(readOnlyList[i]);
			if (phantomBattleData != null)
			{
				list2.Add(phantomBattleData);
			}
		}
		Dictionary<int, int> dictionary = PhantomDataBase.CalculateFetterByPhantomBattleData(list2);
		int num = roleFetterData.Length;
		foreach (KeyValuePair<int, int> keyValuePair in fetterGroupFetterDataById)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			VisionFetterData visionFetterData = new VisionFetterData();
			visionFetterData.FetterGroupId = this.FetterGroupId;
			visionFetterData.FetterId = value;
			visionFetterData.NeedActiveNum = key;
			int num2;
			if (!dictionary.TryGetValue(this.FetterGroupId, out num2))
			{
				num2 = 0;
			}
			visionFetterData.ActiveFetterGroupNum = num2;
			visionFetterData.ActiveState = (num2 >= key);
			bool flag = num2 >= key;
			bool flag2 = false;
			for (int j = 0; j < num; j++)
			{
				if (roleFetterData[j].FetterId == value && roleFetterData[j].ActiveState != flag && flag)
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				visionFetterData.NewAdd = true;
			}
			list.Add(visionFetterData);
		}
		return list;
	}

	// Token: 0x06011F8F RID: 73615 RVA: 0x004F1EBC File Offset: 0x004F00BC
	public List<VisionAttributeVariantTwoData> GetPreviewCurrentShowFetterList()
	{
		return new List<VisionAttributeVariantTwoData>();
	}

	// Token: 0x06011F90 RID: 73616 RVA: 0x004F1EC4 File Offset: 0x004F00C4
	public List<VisionAttributeVariantTwoData> GetShowFetterList(int index, int roleId)
	{
		List<VisionAttributeVariantTwoData> list = new List<VisionAttributeVariantTwoData>();
		if (index != -1)
		{
			foreach (int fetterId in this.GetAddFetterList(index, roleId))
			{
				list.Add(new VisionAttributeVariantTwoData
				{
					FetterId = fetterId,
					State = EFetterCompare.Add
				});
			}
			foreach (int fetterId2 in this.GetDelFetterList(index, roleId))
			{
				list.Add(new VisionAttributeVariantTwoData
				{
					FetterId = fetterId2,
					State = EFetterCompare.Decrease
				});
			}
		}
		foreach (int fetterId3 in this.GetCanActiveFetterList())
		{
			if (!this.CheckFetterInList(list, fetterId3))
			{
				list.Add(new VisionAttributeVariantTwoData
				{
					FetterId = fetterId3,
					State = EFetterCompare.Normal
				});
			}
		}
		return list;
	}

	// Token: 0x06011F91 RID: 73617 RVA: 0x004F1F98 File Offset: 0x004F0198
	private bool CheckFetterInList(List<VisionAttributeVariantTwoData> data, int fetterId)
	{
		for (int i = data.Count - 1; i >= 0; i--)
		{
			if (data[i].FetterId == fetterId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011F92 RID: 73618 RVA: 0x004F1FCA File Offset: 0x004F01CA
	public int[] GetCanActiveFetterList()
	{
		return ModelBase<PhantomBattleModel>.Instance.GetTargetCanActiveFettersList(this.GetIncrId());
	}

	// Token: 0x06011F93 RID: 73619 RVA: 0x004F1FDC File Offset: 0x004F01DC
	public int[] GetDelFetterList(int index, int roleId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPreviewFettersDel(this, index, roleId);
	}

	// Token: 0x06011F94 RID: 73620 RVA: 0x004F1FEB File Offset: 0x004F01EB
	public int[] GetAddFetterList(int index, int roleId)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPreviewFetterAdd(this, index, roleId);
	}

	// Token: 0x06011F95 RID: 73621 RVA: 0x004F1FFA File Offset: 0x004F01FA
	public PhantomFetterGroup GetFetterGroupConfig()
	{
		return ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.GetFetterGroupId());
	}

	// Token: 0x06011F96 RID: 73622 RVA: 0x004F200C File Offset: 0x004F020C
	public bool GetIsFetterGroupSpecial()
	{
		return this.GetFetterGroupConfig().FetterType == 1;
	}

	// Token: 0x06011F97 RID: 73623 RVA: 0x004F202C File Offset: 0x004F022C
	public int GetCost()
	{
		int rarity = this.GetConfig().Rarity;
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost;
	}

	// Token: 0x06011F98 RID: 73624 RVA: 0x004F2064 File Offset: 0x004F0264
	public PhantomRarity? GetRareConfig()
	{
		int rarity = this.GetConfig().Rarity;
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity);
	}

	// Token: 0x06011F99 RID: 73625 RVA: 0x004F208C File Offset: 0x004F028C
	public ILevelUpSuccessAttributeData GetNewSubPropSuccessData(List<Aki.Protocol.PhantomPropInfo> pastSubProp)
	{
		int count = pastSubProp.Count;
		int count2 = this.PhantomSubProp.Count;
		List<AttrListScrollData> subPropShowAttributeList = this.GetSubPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType);
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		for (int i = count; i < count2; i++)
		{
			subPropShowAttributeList[i].AddValue = subPropShowAttributeList[i].BaseValue;
			subPropShowAttributeList[i].BaseValue = 0.0;
			list.Add(subPropShowAttributeList[i]);
		}
		List<IAttributeInfo> list2 = new List<IAttributeInfo>();
		foreach (AttrListScrollData attrData in list)
		{
			IAttributeInfo attributeInfo = RoleLevelUpSuccessController.ConvertsAttrListScrollDataToAttributeInfo(attrData);
			attributeInfo.ShowArrow = new bool?(false);
			attributeInfo.PreText = null;
			list2.Add(attributeInfo);
		}
		return new LevelUpSuccessAttributeData
		{
			Title = "IdentifySuccess",
			WiderScrollView = new bool?(false),
			AttributeInfo = list2,
			IsShowArrow = new bool?(false)
		};
	}

	// Token: 0x06011F9A RID: 73626 RVA: 0x004F219C File Offset: 0x004F039C
	[NullableContext(2)]
	public Aki.Protocol.PhantomPropInfo GetSlotIndexDataEx(int index)
	{
		List<Aki.Protocol.PhantomPropInfo> phantomSubProp = this.PhantomSubProp;
		if (phantomSubProp.Count > index)
		{
			return phantomSubProp[index];
		}
		return null;
	}

	// Token: 0x06011F9B RID: 73627 RVA: 0x004F21C4 File Offset: 0x004F03C4
	public int GetMaxSubPropCount()
	{
		int quality = this.GetQuality();
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSlotUnlockLevel(quality).Length;
	}

	// Token: 0x06011F9C RID: 73628 RVA: 0x004F21E8 File Offset: 0x004F03E8
	public List<VisionSubPropData> GetSubPropIdentifyPreviewData(int currentLevel, int identifyNum)
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(currentLevel);
		int num = 0;
		int count = levelSubPropData.Count;
		for (int i = 0; i < count; i++)
		{
			if (levelSubPropData[i].SlotState == EVisionSlotState.UnlockAndNoProp && identifyNum - num > 0)
			{
				levelSubPropData[i].SlotState = EVisionSlotState.PrepareToIdentify;
				num++;
			}
		}
		return levelSubPropData;
	}

	// Token: 0x06011F9D RID: 73629 RVA: 0x004F223C File Offset: 0x004F043C
	public List<VisionSubPropData> GetLevelSubPropPreviewData(int currentLevel, int targetLevel)
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(currentLevel);
		List<VisionSubPropData> levelSubPropData2 = this.GetLevelSubPropData(targetLevel);
		int count = levelSubPropData2.Count;
		for (int i = 0; i < count; i++)
		{
			if (levelSubPropData2[i].SlotState != EVisionSlotState.Lock && levelSubPropData[i].SlotState == EVisionSlotState.Lock)
			{
				levelSubPropData2[i].SlotState = EVisionSlotState.PreviewUnLock;
			}
		}
		return levelSubPropData2;
	}

	// Token: 0x06011F9E RID: 73630 RVA: 0x004F2298 File Offset: 0x004F0498
	public List<VisionSubPropData> GetEquipmentViewPreviewData()
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(this.GetPhantomLevel());
		int count = levelSubPropData.Count;
		List<VisionSubPropData> list = new List<VisionSubPropData>();
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			if (levelSubPropData[i].SlotState == EVisionSlotState.UnlockAndHaveProp)
			{
				list.Add(levelSubPropData[i]);
			}
			if (levelSubPropData[i].SlotState == EVisionSlotState.UnlockAndNoProp && num == 0)
			{
				list.Add(levelSubPropData[i]);
				num++;
			}
		}
		return list;
	}

	// Token: 0x06011F9F RID: 73631 RVA: 0x004F2315 File Offset: 0x004F0515
	public int GetIdentifyCostItemId()
	{
		return 2;
	}

	// Token: 0x06011FA0 RID: 73632 RVA: 0x004F2318 File Offset: 0x004F0518
	public int GetIdentifyCostItemValue()
	{
		return ConfigBase<PhantomBattleConfig>.Instance.GetQualityIdentifyCost(this.GetQuality());
	}

	// Token: 0x06011FA1 RID: 73633 RVA: 0x004F232C File Offset: 0x004F052C
	public Dictionary<int, int> GetCurrentIdentifyCost()
	{
		int quality = this.GetQuality();
		PhantomQuality? phantomQualityByItemQuality = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityByItemQuality(quality);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = 0; i < phantomQualityByItemQuality.Value.IdentifyCostLength; i++)
		{
			DicIntInt? dicIntInt = phantomQualityByItemQuality.Value.IdentifyCost(i);
			dictionary.TryAdd(dicIntInt.Value.Key, dicIntInt.Value.Value);
		}
		return dictionary;
	}

	// Token: 0x06011FA2 RID: 73634 RVA: 0x004F23A8 File Offset: 0x004F05A8
	public int GetCurrentSubPropLockCount()
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(this.GetPhantomLevel());
		int num = 0;
		using (List<VisionSubPropData>.Enumerator enumerator = levelSubPropData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState == EVisionSlotState.Lock)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06011FA3 RID: 73635 RVA: 0x004F2408 File Offset: 0x004F0608
	public bool GetIfHaveEnoughIdentifyGold(int identifyNum)
	{
		int num = this.GetIdentifyCostItemValue() * identifyNum;
		int num2 = 0;
		List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(this.GetIdentifyCostItemId());
		if (itemDataBaseByConfigId.Count > 0)
		{
			num2 = itemDataBaseByConfigId[0].GetCount();
		}
		return num2 - num >= 0;
	}

	// Token: 0x06011FA4 RID: 73636 RVA: 0x004F2450 File Offset: 0x004F0650
	public bool GetIfHaveEnoughIdentifyConsumeItem(int identifyNum)
	{
		int num = this.GetCurrentIdentifyCostValue() * identifyNum;
		List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(this.GetCurrentIdentifyCostId());
		int num2 = 0;
		if (itemDataBaseByConfigId.Count > 0)
		{
			num2 = itemDataBaseByConfigId[0].GetCount();
		}
		return num2 - num >= 0;
	}

	// Token: 0x06011FA5 RID: 73637 RVA: 0x004F2498 File Offset: 0x004F0698
	public int GetNextIdentifyLevel()
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(this.GetPhantomLevel());
		int result = 0;
		foreach (VisionSubPropData visionSubPropData in levelSubPropData)
		{
			if (visionSubPropData.SlotState == EVisionSlotState.Lock)
			{
				result = visionSubPropData.GetUnlockLevel();
				break;
			}
		}
		return result;
	}

	// Token: 0x06011FA6 RID: 73638 RVA: 0x004F2500 File Offset: 0x004F0700
	public int GetCurrentIdentifyCostId()
	{
		Dictionary<int, int> currentIdentifyCost = this.GetCurrentIdentifyCost();
		int result = 0;
		foreach (KeyValuePair<int, int> keyValuePair in currentIdentifyCost)
		{
			result = keyValuePair.Key;
		}
		return result;
	}

	// Token: 0x06011FA7 RID: 73639 RVA: 0x004F2558 File Offset: 0x004F0758
	public int GetCurrentIdentifyCostValue()
	{
		Dictionary<int, int> currentIdentifyCost = this.GetCurrentIdentifyCost();
		int result = 0;
		foreach (KeyValuePair<int, int> keyValuePair in currentIdentifyCost)
		{
			result = keyValuePair.Value;
		}
		return result;
	}

	// Token: 0x06011FA8 RID: 73640 RVA: 0x004F25B0 File Offset: 0x004F07B0
	public int GetCurrentCanIdentifyCount()
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(this.GetPhantomLevel());
		int num = 0;
		using (List<VisionSubPropData>.Enumerator enumerator = levelSubPropData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState == EVisionSlotState.UnlockAndNoProp)
				{
					num++;
				}
			}
		}
		int num2 = num;
		foreach (KeyValuePair<int, int> keyValuePair in this.GetCurrentIdentifyCost())
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			int num3 = 0;
			List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(key);
			if (itemDataBaseByConfigId.Count > 0)
			{
				num3 = (int)Math.Floor((double)itemDataBaseByConfigId[0].GetCount() / (double)value);
			}
			if (num3 < num2)
			{
				num2 = num3;
			}
		}
		return num2;
	}

	// Token: 0x06011FA9 RID: 73641 RVA: 0x004F26A0 File Offset: 0x004F08A0
	public int GetLevelUnlockSubPropSlotCount(int level)
	{
		int maxSubPropCount = this.GetMaxSubPropCount();
		int num = 0;
		for (int i = 0; i < maxSubPropCount; i++)
		{
			if (level >= this.GetSubPropUnlockLevel(i))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06011FAA RID: 73642 RVA: 0x004F26D4 File Offset: 0x004F08D4
	public List<VisionSubPropData> GetLevelSubPropData(int level)
	{
		int maxSubPropCount = this.GetMaxSubPropCount();
		List<VisionSubPropData> list = new List<VisionSubPropData>();
		for (int i = 0; i < maxSubPropCount; i++)
		{
			VisionSubPropData visionSubPropData = new VisionSubPropData(i, this);
			if (level >= this.GetSubPropUnlockLevel(i))
			{
				Aki.Protocol.PhantomPropInfo slotIndexDataEx = this.GetSlotIndexDataEx(i);
				if (slotIndexDataEx != null)
				{
					visionSubPropData.SlotState = EVisionSlotState.UnlockAndHaveProp;
					visionSubPropData.PhantomSubProp = slotIndexDataEx;
				}
				else
				{
					visionSubPropData.SlotState = EVisionSlotState.UnlockAndNoProp;
				}
			}
			else
			{
				visionSubPropData.SlotState = EVisionSlotState.Lock;
			}
			list.Add(visionSubPropData);
		}
		return list;
	}

	// Token: 0x06011FAB RID: 73643 RVA: 0x004F2744 File Offset: 0x004F0944
	public bool GetIfHaveLockSubProp()
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(this.GetPhantomLevel());
		bool result = false;
		using (List<VisionSubPropData>.Enumerator enumerator = levelSubPropData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState == EVisionSlotState.Lock)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06011FAC RID: 73644 RVA: 0x004F27A4 File Offset: 0x004F09A4
	public bool GetIfHaveUnIdentifySubProp()
	{
		List<VisionSubPropData> levelSubPropData = this.GetLevelSubPropData(this.GetPhantomLevel());
		bool result = false;
		using (List<VisionSubPropData>.Enumerator enumerator = levelSubPropData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState == EVisionSlotState.UnlockAndNoProp)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06011FAD RID: 73645 RVA: 0x004F2804 File Offset: 0x004F0A04
	public int GetSubPropUnlockLevel(int index)
	{
		int quality = this.GetQuality();
		int[] phantomSlotUnlockLevel = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSlotUnlockLevel(quality);
		if (phantomSlotUnlockLevel.Length < index)
		{
			return 9999;
		}
		return phantomSlotUnlockLevel[index];
	}

	// Token: 0x06011FAE RID: 73646 RVA: 0x004F2834 File Offset: 0x004F0A34
	public int GetMaxSlotCount()
	{
		int levelLimit = this.GetLevelLimit();
		IEnumerable<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("PhantomSlotUnlockLevel");
		int num = 0;
		foreach (int num2 in intArrayConfig)
		{
			if (levelLimit >= num2)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06011FAF RID: 73647 RVA: 0x004F2890 File Offset: 0x004F0A90
	public int GetSlotUnlockLevel(int index)
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("PhantomSlotUnlockLevel");
		if (intArrayConfig.Count < index)
		{
			return 9999;
		}
		return intArrayConfig[index];
	}

	// Token: 0x06011FB0 RID: 73648 RVA: 0x004F28BE File Offset: 0x004F0ABE
	public bool GetSlotLockState(int index)
	{
		return this.GetPhantomLevel() < this.GetSlotUnlockLevel(index);
	}

	// Token: 0x06011FB1 RID: 73649 RVA: 0x004F28D4 File Offset: 0x004F0AD4
	public float GetIdentifyBackRadio()
	{
		return (float)ConfigCommonParamById.GetIntConfig("PhantomIdentifyReturnRatio").Value / 1000f;
	}

	// Token: 0x06011FB2 RID: 73650 RVA: 0x004F28FA File Offset: 0x004F0AFA
	public int GetCurrentIdentifyNum()
	{
		return this.PhantomSubProp.Count;
	}

	// Token: 0x06011FB3 RID: 73651 RVA: 0x004F2908 File Offset: 0x004F0B08
	public Dictionary<int, int> GetIdentifyBackItem()
	{
		float currentIdentifyCostValue = (float)this.GetCurrentIdentifyCostValue();
		int currentIdentifyCostId = this.GetCurrentIdentifyCostId();
		int currentIdentifyNum = this.GetCurrentIdentifyNum();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int num = (int)Math.Floor((double)(currentIdentifyCostValue * (float)currentIdentifyNum * this.GetIdentifyBackRadio()));
		if (num > 0)
		{
			dictionary[currentIdentifyCostId] = num;
		}
		return dictionary;
	}

	// Token: 0x06011FB4 RID: 73652 RVA: 0x004F2950 File Offset: 0x004F0B50
	public List<VisionSlotData> GetLevelSlotData(int level)
	{
		int maxSlotCount = this.GetMaxSlotCount();
		List<VisionSlotData> list = new List<VisionSlotData>();
		if (maxSlotCount >= 1 && level < this.GetSlotUnlockLevel(0))
		{
			return list;
		}
		for (int i = 0; i < maxSlotCount; i++)
		{
			VisionSlotData visionSlotData = new VisionSlotData();
			if (level >= this.GetSlotUnlockLevel(i))
			{
				if (this.GetSlotIndexDataEx(i) != null)
				{
					visionSlotData.SlotState = EVisionSlotState.UnlockAndHaveProp;
				}
				else
				{
					visionSlotData.SlotState = EVisionSlotState.UnlockAndNoProp;
				}
			}
			else
			{
				visionSlotData.SlotState = EVisionSlotState.Lock;
			}
			list.Add(visionSlotData);
		}
		return list;
	}

	// Token: 0x06011FB5 RID: 73653 RVA: 0x004F29C0 File Offset: 0x004F0BC0
	public List<VisionSlotData> GetCurrentSlotData()
	{
		return this.GetLevelSlotData(this.GetPhantomLevel());
	}

	// Token: 0x06011FB6 RID: 73654 RVA: 0x004F29D0 File Offset: 0x004F0BD0
	public List<VisionSlotData> GetPreviewSlotData(int previewLevel)
	{
		List<VisionSlotData> currentSlotData = this.GetCurrentSlotData();
		List<VisionSlotData> levelSlotData = this.GetLevelSlotData(previewLevel);
		int count = levelSlotData.Count;
		for (int i = 0; i < count; i++)
		{
			if (currentSlotData.Count == 0)
			{
				int slotUnlockLevel = this.GetSlotUnlockLevel(i);
				if (previewLevel >= slotUnlockLevel)
				{
					levelSlotData[i].SlotState = EVisionSlotState.PreviewUnLock;
				}
				else
				{
					levelSlotData[i].SlotState = EVisionSlotState.Lock;
				}
			}
			else if (currentSlotData.Count > i && currentSlotData[i].SlotState != levelSlotData[i].SlotState)
			{
				levelSlotData[i].SlotState = EVisionSlotState.PreviewUnLock;
			}
		}
		return levelSlotData;
	}

	// Token: 0x06011FB7 RID: 73655 RVA: 0x004F2A64 File Offset: 0x004F0C64
	public int GetCurrentSkillId()
	{
		return this.GetPhantomInstanceWithSkinId().PhantomItem.Value.SkillId;
	}

	// Token: 0x06011FB8 RID: 73656 RVA: 0x004F2A8C File Offset: 0x004F0C8C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] GetSkillDescExParam(int skillId)
	{
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExBySkillIdAndQuality(skillId, this.GetQuality());
	}

	// Token: 0x06011FB9 RID: 73657 RVA: 0x004F2AA0 File Offset: 0x004F0CA0
	[NullableContext(2)]
	public IMainSkillInfoData GetNormalSkillDesc()
	{
		PhantomBattleInstance phantomInstanceWithSkinId = this.GetPhantomInstanceWithSkinId();
		PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(phantomInstanceWithSkinId.PhantomItem.Value.SkillId);
		if (phantomSkillBySkillId == null)
		{
			return null;
		}
		return new MainSkillInfoData
		{
			MainSkillText = phantomSkillBySkillId.Value.DescriptionEx,
			MainSkillParameter = this.GetSkillDescExParam(phantomSkillBySkillId.Value.Id),
			MainSkillIcon = phantomSkillBySkillId.Value.BattleViewIcon
		};
	}

	// Token: 0x06011FBA RID: 73658 RVA: 0x004F2B30 File Offset: 0x004F0D30
	public PhantomSkill? GetNormalSkillConfig()
	{
		PhantomBattleInstance phantomInstanceWithSkinId = this.GetPhantomInstanceWithSkinId();
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(phantomInstanceWithSkinId.PhantomItem.Value.SkillId);
	}

	// Token: 0x06011FBB RID: 73659 RVA: 0x004F2B64 File Offset: 0x004F0D64
	public int GetNormalSkillId()
	{
		return this.GetPhantomInstanceWithSkinId().PhantomItem.Value.SkillId;
	}

	// Token: 0x06011FBC RID: 73660 RVA: 0x004F2B8C File Offset: 0x004F0D8C
	public int GetPersonalSkillId()
	{
		return 0;
	}

	// Token: 0x06011FBD RID: 73661 RVA: 0x004F2B90 File Offset: 0x004F0D90
	public PhantomBattleInstance GetPhantomInstanceWithSkinId()
	{
		int skinId = this.SkinId;
		if (skinId != 0)
		{
			return ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(skinId);
		}
		return this.GetPhantomInstance();
	}

	// Token: 0x06011FBE RID: 73662 RVA: 0x004F2BB9 File Offset: 0x004F0DB9
	private PhantomBattleInstance GetPhantomInstance()
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(this.GetConfigId(false));
	}

	// Token: 0x06011FBF RID: 73663 RVA: 0x004F2BCC File Offset: 0x004F0DCC
	public List<AttrListScrollData> GetLevelUpPreviewData(int targetLevel)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		Dictionary<int, int> mainPropValueMapInTargetLevel = this.GetMainPropValueMapInTargetLevel(targetLevel);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in this.PhantomMainProp)
		{
			dictionary[phantomPropInfo.PhantomPropId] = phantomPropInfo.Value;
		}
		foreach (KeyValuePair<int, int> keyValuePair in mainPropValueMapInTargetLevel)
		{
			int key = keyValuePair.Key;
			double value = (double)keyValuePair.Value;
			int num;
			if (!dictionary.TryGetValue(key, out num))
			{
				num = 0;
			}
			PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(key);
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(phantomMainPropertyItemId.PropId);
			bool isRatio = phantomMainPropertyItemId.AddType == 2;
			double propRatioValue = TipsDataTool.GetPropRatioValue((double)num, isRatio);
			double propRatioValue2 = TipsDataTool.GetPropRatioValue(value, isRatio);
			list.Add(new AttrListScrollData(phantomMainPropertyItemId.PropId, propRatioValue, propRatioValue2, propertyIndexInfo.Value.Priority, isRatio, CommonComponentDefine.EAttributeType.PhantomType));
		}
		return list;
	}

	// Token: 0x06011FC0 RID: 73664 RVA: 0x004F2D0C File Offset: 0x004F0F0C
	public List<Aki.Protocol.PhantomPropInfo> GetPhantomMainProp()
	{
		return this.PhantomMainProp;
	}

	// Token: 0x06011FC1 RID: 73665 RVA: 0x004F2D14 File Offset: 0x004F0F14
	public Aki.Protocol.PhantomPropInfo GetPhantomFirstMainProp()
	{
		return this.PhantomMainProp[0];
	}

	// Token: 0x06011FC2 RID: 73666 RVA: 0x004F2D24 File Offset: 0x004F0F24
	public Dictionary<int, int> GetMainPropValueMapInTargetLevel(int level)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in this.GetPhantomMainProp())
		{
			PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropInfo.PhantomPropId);
			int phantomGrowthValueByGrowthIdAndLevel = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomGrowthValueByGrowthIdAndLevel(phantomMainPropertyItemId.GrowthId, level);
			double attributeValue = TipsDataTool.GetAttributeValue((double)phantomMainPropertyItemId.StandardProperty, (double)phantomGrowthValueByGrowthIdAndLevel, false);
			dictionary[phantomPropInfo.PhantomPropId] = (int)Math.Floor(attributeValue);
		}
		return dictionary;
	}

	// Token: 0x06011FC3 RID: 73667 RVA: 0x004F2DC4 File Offset: 0x004F0FC4
	public List<Aki.Protocol.PhantomPropInfo> GetPhantomSubProp()
	{
		return this.PhantomSubProp;
	}

	// Token: 0x06011FC4 RID: 73668 RVA: 0x004F2DCC File Offset: 0x004F0FCC
	public List<Aki.Protocol.PhantomPropInfo> GetUnAckSubProp()
	{
		return this.UnAckSubProp;
	}

	// Token: 0x06011FC5 RID: 73669 RVA: 0x004F2DD4 File Offset: 0x004F0FD4
	public List<int> GetLockSubPropIndices()
	{
		return this.LockSubPropIndices;
	}

	// Token: 0x06011FC6 RID: 73670 RVA: 0x004F2DDC File Offset: 0x004F0FDC
	public void SetConfigId(int itemId)
	{
		this.ItemId = itemId;
	}

	// Token: 0x06011FC7 RID: 73671 RVA: 0x004F2DE5 File Offset: 0x004F0FE5
	public void SetSkinId(int skinId)
	{
		this.SkinIdInternal = skinId;
	}

	// Token: 0x1700169C RID: 5788
	// (get) Token: 0x06011FC8 RID: 73672 RVA: 0x004F2DEE File Offset: 0x004F0FEE
	public int SkinId
	{
		get
		{
			return this.SkinIdInternal;
		}
	}

	// Token: 0x06011FC9 RID: 73673 RVA: 0x004F2DF8 File Offset: 0x004F0FF8
	public int GetConfigId(bool useSkin = false)
	{
		int skinId = this.SkinId;
		if (useSkin && skinId != 0)
		{
			return skinId;
		}
		return this.ItemId;
	}

	// Token: 0x06011FCA RID: 73674 RVA: 0x004F2E1A File Offset: 0x004F101A
	public Aki.Config.PhantomItem GetConfig()
	{
		if (this.ConfigCache == null)
		{
			this.ConfigCache = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(this.ItemId);
		}
		return this.ConfigCache.Value;
	}

	// Token: 0x06011FCB RID: 73675 RVA: 0x004F2E4C File Offset: 0x004F104C
	public Aki.Config.PhantomItem GetSkinConfig()
	{
		int skinId = this.SkinId;
		if (skinId != 0)
		{
			return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(skinId).Value;
		}
		return this.GetConfig();
	}

	// Token: 0x06011FCC RID: 73676 RVA: 0x004F2E80 File Offset: 0x004F1080
	public Aki.Config.MonsterInfo? GetMonsterConfig()
	{
		Aki.Config.MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(this.GetMonsterId(false));
		if (monsterInfoConfig == null)
		{
			return null;
		}
		return monsterInfoConfig;
	}

	// Token: 0x06011FCD RID: 73677 RVA: 0x004F2EB4 File Offset: 0x004F10B4
	public int GetLevelLimit()
	{
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityByItemQuality(this.GetQuality()).Value.LevelLimit;
	}

	// Token: 0x06011FCE RID: 73678 RVA: 0x004F2EE4 File Offset: 0x004F10E4
	public int GetQuality()
	{
		return this.GetConfig().QualityId;
	}

	// Token: 0x06011FCF RID: 73679 RVA: 0x004F2F00 File Offset: 0x004F1100
	public int GetMonsterId(bool useSkin = false)
	{
		if (useSkin && this.SkinId != 0)
		{
			return this.GetSkinConfig().MonsterId;
		}
		return this.GetConfig().MonsterId;
	}

	// Token: 0x06011FD0 RID: 73680 RVA: 0x004F2F38 File Offset: 0x004F1138
	public string GetMonsterName()
	{
		if (this.SkinId != 0)
		{
			return this.GetSkinConfig().MonsterName;
		}
		return this.GetConfig().MonsterName;
	}

	// Token: 0x06011FD1 RID: 73681 RVA: 0x004F2F6C File Offset: 0x004F116C
	public AttrListScrollData GetFirstMainPropAttribute(CommonComponentDefine.EAttributeType attributeType, bool needAddType = false)
	{
		int phantomPropId = this.PhantomMainProp[0].PhantomPropId;
		double value = (double)this.PhantomMainProp[0].Value;
		PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropId);
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(phantomMainPropertyItemId.PropId);
		double propRatioValue = TipsDataTool.GetPropRatioValue(value, phantomMainPropertyItemId.AddType == 2);
		return new AttrListScrollData(phantomMainPropertyItemId.PropId, propRatioValue, (double)((!needAddType) ? 0 : phantomMainPropertyItemId.AddType), propertyIndexInfo.Value.Priority, phantomMainPropertyItemId.AddType == 2, attributeType);
	}

	// Token: 0x06011FD2 RID: 73682 RVA: 0x004F3004 File Offset: 0x004F1204
	public List<AttrListScrollData> GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType attributeType, bool needAddType = false)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in this.PhantomMainProp)
		{
			dictionary[phantomPropInfo.PhantomPropId] = phantomPropInfo.Value;
		}
		List<int> list2 = new List<int>(dictionary.Keys);
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(list2[i]);
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(phantomMainPropertyItemId.PropId);
			double propRatioValue = TipsDataTool.GetPropRatioValue((double)dictionary[list2[i]], phantomMainPropertyItemId.AddType == 2);
			list.Add(new AttrListScrollData(phantomMainPropertyItemId.PropId, propRatioValue, (double)((!needAddType) ? 0 : phantomMainPropertyItemId.AddType), propertyIndexInfo.Value.Priority, phantomMainPropertyItemId.AddType == 2, attributeType));
		}
		return list;
	}

	// Token: 0x06011FD3 RID: 73683 RVA: 0x004F3120 File Offset: 0x004F1320
	public List<AttrListScrollData> GetSubPropShowAttributeList(CommonComponentDefine.EAttributeType attributeType)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in this.PhantomSubProp)
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(phantomPropInfo.PhantomPropId);
			PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo.PhantomPropId);
			bool isRatio = phantomSubPropertyById.AddType == 2;
			double propRatioValue = TipsDataTool.GetPropRatioValue((double)phantomPropInfo.Value, isRatio);
			list.Add(new AttrListScrollData(phantomSubPropertyById.PropId, propRatioValue, 0.0, propertyIndexInfo.Value.Priority, phantomSubPropertyById.AddType == 2, attributeType));
		}
		return list;
	}

	// Token: 0x06011FD4 RID: 73684 RVA: 0x004F31F0 File Offset: 0x004F13F0
	public bool CheckIfHaveSelectRecommendMainAttr()
	{
		List<VisionSelectRecommendData> currentSelectMainAttrArray = ModelBase<VisionRecommendModel>.Instance.CurrentSelectMainAttrArray;
		if (currentSelectMainAttrArray.Count == 0)
		{
			return true;
		}
		foreach (VisionSelectRecommendData visionSelectRecommendData in currentSelectMainAttrArray)
		{
			foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in this.PhantomMainProp)
			{
				PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropInfo.PhantomPropId);
				if (phantomMainPropertyItemId.AddType == visionSelectRecommendData.AddType && phantomMainPropertyItemId.PropId == visionSelectRecommendData.AttrId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06011FD5 RID: 73685 RVA: 0x004F32C4 File Offset: 0x004F14C4
	public bool CheckIfHaveSelectRecommendSubAttr()
	{
		foreach (VisionSelectRecommendData visionSelectRecommendData in ModelBase<VisionRecommendModel>.Instance.CurrentSelectSubAttrArray)
		{
			bool flag = false;
			foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in this.PhantomSubProp)
			{
				PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo.PhantomPropId);
				if (phantomSubPropertyById.AddType == visionSelectRecommendData.AddType && phantomSubPropertyById.PropId == visionSelectRecommendData.AttrId)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06011FD6 RID: 73686 RVA: 0x004F3394 File Offset: 0x004F1594
	public bool CheckIfHaveSelectMainPhantomType()
	{
		VisionMainSelectPhantomData currentMainPhantom = ModelBase<VisionRecommendModel>.Instance.CurrentMainPhantom;
		return currentMainPhantom == null || (this.FetterGroupId == currentMainPhantom.FetterGroupId && this.GetMonsterId(false) == currentMainPhantom.MonsterId);
	}

	// Token: 0x06011FD7 RID: 73687 RVA: 0x004F33D0 File Offset: 0x004F15D0
	public List<AttrListScrollData> GetPropShowAttributeList(CommonComponentDefine.EAttributeType attributeType)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in this.PhantomMainProp)
		{
			dictionary[phantomPropInfo.PhantomPropId] = phantomPropInfo.Value;
		}
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo2 in this.PhantomSubProp)
		{
			dictionary2[phantomPropInfo2.PhantomPropId] = phantomPropInfo2.Value;
			if (!dictionary.ContainsKey(phantomPropInfo2.PhantomPropId))
			{
				dictionary[phantomPropInfo2.PhantomPropId] = 0;
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
			list.Add(new AttrListScrollData(list2[i], (double)dictionary[list2[i]], (double)num, propertyIndexInfo.Value.Priority, false, attributeType));
		}
		return list;
	}

	// Token: 0x06011FD8 RID: 73688 RVA: 0x004F3538 File Offset: 0x004F1738
	protected static int? GetPropValue(IPhantomPropInfo prop, bool ifSub)
	{
		return prop.Value;
	}

	// Token: 0x06011FD9 RID: 73689
	public abstract bool IsBreach();

	// Token: 0x04008CD0 RID: 36048
	protected List<Aki.Protocol.PhantomPropInfo> PhantomMainProp = new List<Aki.Protocol.PhantomPropInfo>();

	// Token: 0x04008CD1 RID: 36049
	protected List<Aki.Protocol.PhantomPropInfo> PhantomSubProp = new List<Aki.Protocol.PhantomPropInfo>();

	// Token: 0x04008CD2 RID: 36050
	protected List<Aki.Protocol.PhantomPropInfo> UnAckSubProp = new List<Aki.Protocol.PhantomPropInfo>();

	// Token: 0x04008CD3 RID: 36051
	protected List<int> LockSubPropIndices = new List<int>();

	// Token: 0x04008CD4 RID: 36052
	protected int PhantomLevel;

	// Token: 0x04008CD5 RID: 36053
	protected int PhantomExp;

	// Token: 0x04008CD6 RID: 36054
	protected int ItemId;

	// Token: 0x04008CD7 RID: 36055
	protected int FuncValue;

	// Token: 0x04008CD8 RID: 36056
	[Nullable(2)]
	protected PhantomPropSlot SuspendSlot;

	// Token: 0x04008CD9 RID: 36057
	private int IncrId;

	// Token: 0x04008CDA RID: 36058
	protected int FetterGroupId;

	// Token: 0x04008CDB RID: 36059
	private int SkinIdInternal;

	// Token: 0x04008CDC RID: 36060
	private Aki.Config.PhantomItem? ConfigCache;
}
