using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001549 RID: 5449
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityRegressQuestionnaireLayoutItem : GridProxyAbstract<ActivityRegressQuestionnaireItemData>
{
	// Token: 0x060098EC RID: 39148 RVA: 0x00280B5E File Offset: 0x0027ED5E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x060098ED RID: 39149 RVA: 0x00280B84 File Offset: 0x0027ED84
	protected override void OnStart()
	{
		this.ItemGrid = new SmallItemGrid();
		this.ItemGrid.Initialize(base.GetItem(7).GetOwner());
		this.ItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.ItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnItemClick));
	}

	// Token: 0x060098EE RID: 39150 RVA: 0x00280BF4 File Offset: 0x0027EDF4
	public override void Refresh(ActivityRegressQuestionnaireItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		ActivityRegressHelper.RefreshItemGridByData(this.ItemGrid, data.ItemData.Value);
	}

	// Token: 0x060098EF RID: 39151 RVA: 0x00280C14 File Offset: 0x0027EE14
	private void OnItemClick(MediumItemGridExtendCallback _)
	{
		if (this.Data.ItemData.Value.RewardState == ERegressRewardState.Reached)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestClaimQuestionnaireReward(this.Data.Type);
			return;
		}
		int id = this.Data.ItemData.Value.ItemInfo.Value.Id;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(id, true, null);
	}

	// Token: 0x040046AE RID: 18094
	[Nullable(2)]
	private SmallItemGrid ItemGrid;

	// Token: 0x040046AF RID: 18095
	[Nullable(2)]
	private ActivityRegressQuestionnaireItemData Data;

	// Token: 0x02007904 RID: 30980
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029972 RID: 170354
		public const int ItemRoot = 7;
	}
}
