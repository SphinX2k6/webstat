using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x02001AF4 RID: 6900
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RecoveryRewardItem : LoopScrollSmallItemGrid<DangoAbyssDefine.IRecoveryRewardData>
{
	// Token: 0x0600C6B8 RID: 50872 RVA: 0x00348850 File Offset: 0x00346A50
	protected override void OnRefresh(DangoAbyssDefine.IRecoveryRewardData data, bool isSelected, int gridIndex)
	{
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.ItemId),
			BottomText = data.Count.ToString()
		};
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0600C6B9 RID: 50873 RVA: 0x00348893 File Offset: 0x00346A93
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600C6BA RID: 50874 RVA: 0x00348898 File Offset: 0x00346A98
	protected override void OnExtendToggleClicked()
	{
		DangoAbyssDefine.IRecoveryRewardData recoveryRewardData = this.Data as DangoAbyssDefine.IRecoveryRewardData;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(recoveryRewardData.ItemId, true, null);
	}
}
