using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001445 RID: 5189
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class MowingTowerRewardItem : GridProxyAbstract<IActivityRewardData>
{
	// Token: 0x06009063 RID: 36963 RVA: 0x0025F3C4 File Offset: 0x0025D5C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickButton))
		};
	}

	// Token: 0x06009064 RID: 36964 RVA: 0x0025F499 File Offset: 0x0025D699
	protected override void OnStart()
	{
		this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
	}

	// Token: 0x06009065 RID: 36965 RVA: 0x0025F4BC File Offset: 0x0025D6BC
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06009066 RID: 36966 RVA: 0x0025F4C4 File Offset: 0x0025D6C4
	public override void Refresh(IActivityRewardData data, bool isSelected, int gridIndex)
	{
		this.RewardData = data;
		if (data.NameTextArgs != null)
		{
			base.GetText(1).SetText(data.NameTextArgs[1] + "/" + data.NameTextArgs[0], true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "BossRushRewardText", new <>z__ReadOnlySingleElementList<object>(data.NameTextArgs[0]));
		}
		base.GetButton(4).RootUIComp.Get().SetUIActive(data.RewardState == EActivityRewardState.Enable);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(data.RewardState == EActivityRewardState.Disabled);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(data.RewardState == EActivityRewardState.Claimed);
		}
		List<TItem> data2 = (data.RewardList != null) ? new List<TItem>(data.RewardList) : new List<TItem>();
		GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout = this.ItemLayout;
		if (itemLayout == null)
		{
			return;
		}
		itemLayout.RefreshByData(data2, null, false);
	}

	// Token: 0x06009067 RID: 36967 RVA: 0x0025F5B0 File Offset: 0x0025D7B0
	private void OnClickButton()
	{
		IActivityRewardData rewardData = this.RewardData;
		if (rewardData == null)
		{
			return;
		}
		Action clickFunction = rewardData.ClickFunction;
		if (clickFunction == null)
		{
			return;
		}
		clickFunction();
	}

	// Token: 0x0400430D RID: 17165
	[Nullable(2)]
	private IActivityRewardData RewardData;

	// Token: 0x0400430E RID: 17166
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;
}
