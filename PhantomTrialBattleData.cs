using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002459 RID: 9305
[NullableContext(1)]
[Nullable(0)]
public class PhantomTrialBattleData : PhantomBattleData
{
	// Token: 0x06012030 RID: 73776 RVA: 0x004F54AE File Offset: 0x004F36AE
	public PhantomTrialBattleData()
	{
		this.MainPropValue = new Dictionary<int, AttributeValueData>();
		this.SubPropValueMap = new Dictionary<int, AttributeValueData>();
	}

	// Token: 0x06012031 RID: 73777 RVA: 0x004F54CC File Offset: 0x004F36CC
	public void SetMainPropValue(int propId, double propValue, bool isRadio)
	{
		AttributeValueData value = new AttributeValueData(propId, propValue, isRadio);
		this.MainPropValue[propId] = value;
	}

	// Token: 0x06012032 RID: 73778 RVA: 0x004F54F0 File Offset: 0x004F36F0
	public void SetSubPropValue(int propId, double propValue, bool isRadio)
	{
		AttributeValueData value = new AttributeValueData(propId, propValue, isRadio);
		this.SubPropValueMap[propId] = value;
	}

	// Token: 0x06012033 RID: 73779 RVA: 0x004F5513 File Offset: 0x004F3713
	public void SetFetterGroupId(int id)
	{
		this.TrailFetterGroup = id;
	}

	// Token: 0x06012034 RID: 73780 RVA: 0x004F551C File Offset: 0x004F371C
	public override int GetFetterGroupId()
	{
		return this.TrailFetterGroup;
	}

	// Token: 0x06012035 RID: 73781 RVA: 0x004F5524 File Offset: 0x004F3724
	public void SetSlotIndex(int slot)
	{
		this.SlotIndex = slot;
	}

	// Token: 0x06012036 RID: 73782 RVA: 0x004F552D File Offset: 0x004F372D
	public bool GetIfMain()
	{
		return this.SlotIndex == 0;
	}

	// Token: 0x06012037 RID: 73783 RVA: 0x004F5538 File Offset: 0x004F3738
	public override int GetUniqueId()
	{
		return base.GetIncrId();
	}

	// Token: 0x06012038 RID: 73784 RVA: 0x004F5540 File Offset: 0x004F3740
	public Dictionary<int, AttributeValueData> GetMainTrailProp()
	{
		return this.MainPropValue;
	}

	// Token: 0x06012039 RID: 73785 RVA: 0x004F5548 File Offset: 0x004F3748
	public Dictionary<int, AttributeValueData> GetSubTrailPropMap()
	{
		return this.SubPropValueMap;
	}

	// Token: 0x0601203A RID: 73786 RVA: 0x004F5550 File Offset: 0x004F3750
	[NullableContext(2)]
	public AttributeValueData GetBreachProp()
	{
		return this.BreachPropValue;
	}

	// Token: 0x0601203B RID: 73787 RVA: 0x004F5558 File Offset: 0x004F3758
	public override bool IsBreach()
	{
		return true;
	}

	// Token: 0x04008CFD RID: 36093
	private readonly Dictionary<int, AttributeValueData> MainPropValue;

	// Token: 0x04008CFE RID: 36094
	[Nullable(2)]
	private readonly AttributeValueData BreachPropValue;

	// Token: 0x04008CFF RID: 36095
	private readonly Dictionary<int, AttributeValueData> SubPropValueMap;

	// Token: 0x04008D00 RID: 36096
	private int SlotIndex;

	// Token: 0x04008D01 RID: 36097
	private int TrailFetterGroup;
}
