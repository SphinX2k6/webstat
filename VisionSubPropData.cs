using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200244D RID: 9293
[NullableContext(1)]
[Nullable(0)]
public class VisionSubPropData
{
	// Token: 0x06011F67 RID: 73575 RVA: 0x004F1591 File Offset: 0x004EF791
	public VisionSubPropData(int slotIndex, PhantomDataBase sourceData)
	{
		this.SlotIndex = slotIndex;
		this.Data = sourceData;
	}

	// Token: 0x06011F68 RID: 73576 RVA: 0x004F15A7 File Offset: 0x004EF7A7
	public string GetSubPropName()
	{
		return this.GetSubPropNameByPropId(this.PhantomSubProp.PhantomPropId);
	}

	// Token: 0x06011F69 RID: 73577 RVA: 0x004F15BC File Offset: 0x004EF7BC
	public string GetSubPropNameByPropId(int propId)
	{
		int propId2 = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(propId).PropId;
		return ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(propId2).Value.Name;
	}

	// Token: 0x06011F6A RID: 73578 RVA: 0x004F15F8 File Offset: 0x004EF7F8
	public int GetSlotIndex()
	{
		return this.SlotIndex;
	}

	// Token: 0x06011F6B RID: 73579 RVA: 0x004F1600 File Offset: 0x004EF800
	public string GetAttributeValueString()
	{
		return this.GetAttributeValueStringByPropId(this.PhantomSubProp.PhantomPropId, this.PhantomSubProp.Value);
	}

	// Token: 0x06011F6C RID: 73580 RVA: 0x004F1620 File Offset: 0x004EF820
	public string GetAttributeValueStringByPropId(int propId, int propValue)
	{
		PhantomSubProperty phantomSubPropertyById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(propId);
		bool isRatio = phantomSubPropertyById.AddType == 2;
		double propRatioValue = TipsDataTool.GetPropRatioValue((double)propValue, isRatio);
		return ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(phantomSubPropertyById.PropId, propRatioValue, isRatio);
	}

	// Token: 0x06011F6D RID: 73581 RVA: 0x004F1660 File Offset: 0x004EF860
	public int GetUnlockLevel()
	{
		int quality = this.Data.GetQuality();
		int[] phantomSlotUnlockLevel = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSlotUnlockLevel(quality);
		if (phantomSlotUnlockLevel.Length > this.SlotIndex)
		{
			return phantomSlotUnlockLevel[this.SlotIndex];
		}
		return 0;
	}

	// Token: 0x04008CCC RID: 36044
	private readonly int SlotIndex;

	// Token: 0x04008CCD RID: 36045
	[Nullable(2)]
	private readonly PhantomDataBase Data;

	// Token: 0x04008CCE RID: 36046
	public EVisionSlotState SlotState;

	// Token: 0x04008CCF RID: 36047
	[Nullable(2)]
	public Aki.Protocol.PhantomPropInfo PhantomSubProp;
}
