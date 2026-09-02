using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E4D RID: 7757
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HandBookCommonItem : LoopScrollSmallItemGrid<HandBookCommonItemData>
{
	// Token: 0x0600E5B9 RID: 58809 RVA: 0x003E10E4 File Offset: 0x003DF2E4
	[NullableContext(1)]
	protected override void OnRefresh(HandBookCommonItemData data, bool isSelected, int gridIndex)
	{
		this.HandBookCommonItemData = data;
		bool isLock = data.IsLock;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			IsNotFoundVisible = new bool?(isLock),
			IsNewVisible = new bool?(data.IsNew),
			IconPath = (isLock ? null : data.Icon),
			QualityId = new int?(isLock ? 0 : data.QualityId)
		};
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0600E5BA RID: 58810 RVA: 0x003E1159 File Offset: 0x003DF359
	public HandBookCommonItemData GetData()
	{
		return this.HandBookCommonItemData;
	}

	// Token: 0x0600E5BB RID: 58811 RVA: 0x003E1161 File Offset: 0x003DF361
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x0600E5BC RID: 58812 RVA: 0x003E116B File Offset: 0x003DF36B
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x04006EA8 RID: 28328
	protected HandBookCommonItemData HandBookCommonItemData;
}
