using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02002A03 RID: 10755
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShopMediumItemGrid : LoopScrollMediumItemGrid<ShopItemFullInfo>
{
	// Token: 0x06015759 RID: 87897 RVA: 0x005F2E00 File Offset: 0x005F1000
	protected override void OnRefresh(ShopItemFullInfo data, bool isSelected, int gridIndex)
	{
		if (data == null)
		{
			return;
		}
		this.SetSelected(isSelected, false);
		this.ItemInfo = data;
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.ItemId),
			IsProhibit = new bool?(data.IsLocked),
			StarLevel = new int?(data.ItemInfo.QualityId),
			BottomTextId = data.ItemInfo.Name,
			IsDisable = new bool?(data.IsSoldOut()),
			IsOmitBottomText = new bool?(true)
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x0601575A RID: 87898 RVA: 0x005F2E9A File Offset: 0x005F109A
	public override void OnSelected(bool fireEvent)
	{
		ModelBase<ShopModel>.Instance.OpenItemInfo = this.ItemInfo;
		Singleton<EventSystem>.Instance.Emit(EEventName.OpenItemInfo);
		this.SetSelected(true, false);
	}

	// Token: 0x0601575B RID: 87899 RVA: 0x005F2EC4 File Offset: 0x005F10C4
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x0400A528 RID: 42280
	[Nullable(2)]
	public ShopItemFullInfo ItemInfo;
}
