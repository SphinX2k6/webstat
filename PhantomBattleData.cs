using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200245D RID: 9309
[NullableContext(1)]
[Nullable(0)]
public class PhantomBattleData : PhantomDataBase
{
	// Token: 0x060120D9 RID: 73945 RVA: 0x004F7944 File Offset: 0x004F5B44
	public void SetData(Aki.Protocol.PhantomItem phantomItemInfo)
	{
		this.UniqueId = phantomItemInfo.IncrId;
		this.PhantomLevel = phantomItemInfo.PhantomLevel;
		this.ItemId = phantomItemInfo.Id;
		this.PhantomExp = phantomItemInfo.PhantomExp;
		this.PhantomMainProp = phantomItemInfo.PhantomMainProp.ToList<Aki.Protocol.PhantomPropInfo>();
		this.PhantomSubProp = phantomItemInfo.PhantomSubProp.ToList<Aki.Protocol.PhantomPropInfo>();
		this.FetterGroupId = phantomItemInfo.FetterGroupId;
		this.FuncValue = phantomItemInfo.FuncValue;
		base.SetSkinId(phantomItemInfo.SkinId);
		base.SetIncId(this.UniqueId);
		this.UnAckSubProp = phantomItemInfo.UnAckSubProp.ToList<Aki.Protocol.PhantomPropInfo>();
		this.LockSubPropIndices = phantomItemInfo.LockPropIndex.ToList<int>();
	}

	// Token: 0x060120DA RID: 73946 RVA: 0x004F79F5 File Offset: 0x004F5BF5
	public virtual int GetUniqueId()
	{
		return this.UniqueId;
	}

	// Token: 0x060120DB RID: 73947 RVA: 0x004F7A00 File Offset: 0x004F5C00
	public List<PhantomSortStruct> GetMainPropArray()
	{
		List<PhantomSortStruct> list = new List<PhantomSortStruct>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in base.GetPhantomMainProp())
		{
			PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropInfo.PhantomPropId);
			list.Add(new PhantomSortStruct
			{
				PhantomPropId = phantomMainPropertyItemId.PropId,
				Value = phantomPropInfo.Value,
				IfPercentage = (phantomMainPropertyItemId.AddType == 2)
			});
		}
		return list;
	}

	// Token: 0x060120DC RID: 73948 RVA: 0x004F7AA0 File Offset: 0x004F5CA0
	public List<PhantomSortStruct> GetSubPropArray()
	{
		List<PhantomSortStruct> list = new List<PhantomSortStruct>();
		foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in base.GetPhantomSubProp())
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(phantomPropInfo.PhantomPropId);
			PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo.PhantomPropId);
			list.Add(new PhantomSortStruct
			{
				PhantomPropId = propertyIndexInfo.Value.Id,
				Value = phantomPropInfo.Value,
				IfPercentage = (phantomSubPropertyById.AddType == 2)
			});
		}
		return list;
	}

	// Token: 0x060120DD RID: 73949 RVA: 0x004F7B5C File Offset: 0x004F5D5C
	public bool GetIfHaveRecommendMainProp(int roleId)
	{
		VisionAttrRecommendInfo roleCostAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleCostAttrRecommendInfo(roleId, base.GetCost());
		List<AttrRecommendInfo> list = (roleCostAttrRecommendInfo != null) ? roleCostAttrRecommendInfo.GetMainAttrRecommendInfo() : null;
		if (list != null)
		{
			foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in base.GetPhantomMainProp())
			{
				PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(phantomPropInfo.PhantomPropId);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (phantomMainPropertyItemId.AddType == list[i].GetAddType() && phantomMainPropertyItemId.PropId == list[i].GetAttrId())
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x060120DE RID: 73950 RVA: 0x004F7C2C File Offset: 0x004F5E2C
	public bool GetIfHaveRecommendSubProp(int roleId)
	{
		VisionAttrRecommendInfo roleCostAttrRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleCostAttrRecommendInfo(roleId, base.GetCost());
		List<AttrRecommendInfo> list = (roleCostAttrRecommendInfo != null) ? roleCostAttrRecommendInfo.GetSubAttrRecommendInfo() : null;
		if (list != null)
		{
			foreach (Aki.Protocol.PhantomPropInfo phantomPropInfo in base.GetPhantomSubProp())
			{
				PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropInfo.PhantomPropId);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (phantomSubPropertyById.AddType == list[i].GetAddType() && phantomSubPropertyById.PropId == list[i].GetAttrId())
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x060120DF RID: 73951 RVA: 0x004F7CFC File Offset: 0x004F5EFC
	public override bool IsBreach()
	{
		return this.PhantomSubProp.Count > 0;
	}

	// Token: 0x04008D06 RID: 36102
	private int UniqueId;
}
