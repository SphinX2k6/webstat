using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Phantom.Vision.View;

// Token: 0x02001988 RID: 6536
[NullableContext(1)]
[Nullable(0)]
public class TipsVisionData : ItemTipsData
{
	// Token: 0x0600BBE5 RID: 48101 RVA: 0x0031E49C File Offset: 0x0031C69C
	public TipsVisionData(ItemTipsParam tipsParam) : base(tipsParam)
	{
		Aki.Protocol.PhantomItem phantomItem = tipsParam.ExtraParam as Aki.Protocol.PhantomItem;
		AttributeItemData attributeItemData;
		if (phantomItem != null)
		{
			attributeItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemDataByPhantomItem(phantomItem);
		}
		else
		{
			attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(this.IncId);
		}
		Aki.Config.PhantomItem? phantomItemConfig = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfig(this.ConfigId);
		Aki.Config.PhantomItem? phantomItem2 = (this.IncId != 0) ? attributeItemData.GetConfig().As<Aki.Config.PhantomItem>() : phantomItemConfig;
		if (phantomItem2 == null)
		{
			return;
		}
		PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
		PhantomBattleData phantomBattleData = null;
		if (phantomItem != null)
		{
			phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleDataByPhantomItem(phantomItem);
		}
		else
		{
			phantomBattleData = ((this.IncId != 0) ? instance.GetPhantomBattleData(this.IncId) : null);
		}
		int level = (phantomBattleData != null) ? phantomBattleData.GetPhantomLevel() : 0;
		int quality = (phantomBattleData != null) ? phantomBattleData.GetQuality() : 1;
		this.ItemType = EItemTipsType.Vision;
		this.VisionId = phantomItem2.Value.MonsterId;
		int rarity = phantomItem2.Value.Rarity;
		this.VisionType = ConfigPhantomRarityByRare.GetConfig(rarity, true).Value.Desc;
		this.Cost = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost;
		this.ConfigId = ((phantomBattleData != null) ? phantomBattleData.GetConfigId(true) : this.ConfigId);
		this.Title = ((phantomBattleData != null) ? phantomBattleData.GetMonsterName() : this.Title);
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("VisionLevel");
		this.UpgradeLevel = StringUtils.Format(textById, new string[]
		{
			level.ToString()
		});
		VisionDetailInfoComponentData visionDetailInfoComponentData = new VisionDetailInfoComponentData();
		if (phantomItemConfig != null && phantomBattleData == null)
		{
			int skillId = phantomItemConfig.Value.SkillId;
			PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(skillId);
			if (phantomSkillBySkillId != null)
			{
				this.MainSkillText = phantomSkillBySkillId.Value.DescriptionEx;
				this.MainSkillParams = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExByPhantomSkillIdAndQuality(skillId, quality);
				foreach (VisionDetailDesc data in VisionDetailDesc.ConvertVisionSkillDescToDescData(phantomSkillBySkillId.Value, level, true, true, quality))
				{
					visionDetailInfoComponentData.AddDescData(data);
				}
			}
		}
		List<ITipsAttributeItemData> list = new List<ITipsAttributeItemData>();
		List<AttrListScrollData> list2 = (phantomBattleData != null) ? phantomBattleData.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false) : null;
		if (list2 != null)
		{
			foreach (AttrListScrollData attrListScrollData in list2)
			{
				PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrListScrollData.Id);
				TipsAttributeItemData item = new TipsAttributeItemData
				{
					Id = attrListScrollData.Id,
					IsMainAttribute = true,
					Name = propertyIndexInfo.Value.Name,
					IconPath = propertyIndexInfo.Value.Icon,
					Value = attrListScrollData.BaseValue,
					IsRatio = attrListScrollData.IsRatio
				};
				list.Add(item);
			}
		}
		List<AttrListScrollData> list3 = (phantomBattleData != null) ? phantomBattleData.GetSubPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType) : null;
		if (list3 != null)
		{
			foreach (AttrListScrollData attrListScrollData2 in list3)
			{
				PropertyIndex? propertyIndexInfo2 = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrListScrollData2.Id);
				TipsAttributeItemData item2 = new TipsAttributeItemData
				{
					Id = attrListScrollData2.Id,
					IsMainAttribute = false,
					Name = propertyIndexInfo2.Value.Name,
					IconPath = propertyIndexInfo2.Value.Icon,
					Value = attrListScrollData2.BaseValue,
					IsRatio = attrListScrollData2.IsRatio
				};
				list.Add(item2);
			}
		}
		this.AttributeData = list.ToArray();
		int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(this.IncId);
		if (equipRole != null)
		{
			this.EquippedId = equipRole;
			int? equippedId = this.EquippedId;
			int num = 0;
			this.IsEquip = !(equippedId.GetValueOrDefault() == num & equippedId != null);
		}
		visionDetailInfoComponentData.DataBase = phantomBattleData;
		int num2 = -1;
		List<VisionFetterData> list4 = (phantomBattleData != null) ? phantomBattleData.GetPreviewShowFetterList(-1, 0) : null;
		bool ifPreview = true;
		if (phantomBattleData != null)
		{
			foreach (VisionDetailDesc data2 in VisionDetailDesc.ConvertVisionSkillDescToDescData(phantomBattleData.GetNormalSkillConfig().Value, phantomBattleData.GetPhantomLevel(), num2 == -1, ifPreview, quality))
			{
				visionDetailInfoComponentData.AddDescData(data2);
			}
		}
		if (list4 != null)
		{
			foreach (VisionDetailDesc data3 in VisionDetailDesc.ConvertVisionFetterDataToDetailDescData(list4, false, null, null))
			{
				visionDetailInfoComponentData.AddDescData(data3);
			}
		}
		this.VisionDetailInfoComponentData = visionDetailInfoComponentData;
	}

	// Token: 0x0600BBE6 RID: 48102 RVA: 0x0031EA10 File Offset: 0x0031CC10
	protected override bool OnIsShowIconBig()
	{
		return true;
	}

	// Token: 0x040058E6 RID: 22758
	public int VisionId;

	// Token: 0x040058E7 RID: 22759
	public string VisionType = "";

	// Token: 0x040058E8 RID: 22760
	public int Cost;

	// Token: 0x040058E9 RID: 22761
	public string UpgradeLevel = "";

	// Token: 0x040058EA RID: 22762
	public string MainSkillText = "";

	// Token: 0x040058EB RID: 22763
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] MainSkillParams;

	// Token: 0x040058EC RID: 22764
	[Nullable(2)]
	public string SkillUniqueText;

	// Token: 0x040058ED RID: 22765
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] SkillUniqueTextParam;

	// Token: 0x040058EE RID: 22766
	public int? SkillUniqueRoleId;

	// Token: 0x040058EF RID: 22767
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public ITipsAttributeItemData[] AttributeData;

	// Token: 0x040058F0 RID: 22768
	public bool IsEquip;

	// Token: 0x040058F1 RID: 22769
	public int? EquippedId;

	// Token: 0x040058F2 RID: 22770
	[Nullable(2)]
	public VisionDetailInfoComponentData VisionDetailInfoComponentData;
}
