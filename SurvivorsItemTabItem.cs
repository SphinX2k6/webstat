using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02002B2D RID: 11053
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsItemTabItem : LoopScrollMediumItemGrid<SurvivorsRogueItemCard>
{
	// Token: 0x060160F5 RID: 90357 RVA: 0x0061F2C4 File Offset: 0x0061D4C4
	protected override void OnRefresh(SurvivorsRogueItemCard data, bool isSelected, int gridIndex)
	{
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			QualityId = new int?(data.QualityId),
			IconPath = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsItem(data.Id).Value.Icon,
			IsNewVisible = new bool?(!data.LockState.GetValueOrDefault() && data.IsNew.GetValueOrDefault()),
			BottomTextId = data.TitleId,
			IsProhibit = new bool?(data.LockState.GetValueOrDefault())
		};
		base.Apply<PropMediumItemGrid>(parameters);
		this.SetSelected(isSelected, true);
	}

	// Token: 0x060160F6 RID: 90358 RVA: 0x0061F375 File Offset: 0x0061D575
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, true);
		if (fireEvent)
		{
			this.OnExtendToggleStateChanged(this.GetItemGridExtendToggle().ToggleState);
		}
	}

	// Token: 0x060160F7 RID: 90359 RVA: 0x0061F393 File Offset: 0x0061D593
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x060160F8 RID: 90360 RVA: 0x0061F39D File Offset: 0x0061D59D
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		Action<SurvivorsRogueItemCard, SurvivorsItemTabItem> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack((SurvivorsRogueItemCard)this.Data, this);
	}

	// Token: 0x0400A9CA RID: 43466
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<SurvivorsRogueItemCard, SurvivorsItemTabItem> OnClickCallBack;
}
