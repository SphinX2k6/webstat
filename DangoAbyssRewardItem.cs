using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001AFF RID: 6911
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssRewardItem : GridProxyAbstract<IActivityRewardData>
{
	// Token: 0x0600C70A RID: 50954 RVA: 0x0034A460 File Offset: 0x00348660
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C70B RID: 50955 RVA: 0x0034A610 File Offset: 0x00348810
	protected override void OnStart()
	{
		this.ItemLayout = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(7), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, null);
	}

	// Token: 0x0600C70C RID: 50956 RVA: 0x0034A633 File Offset: 0x00348833
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600C70D RID: 50957 RVA: 0x0034A63A File Offset: 0x0034883A
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

	// Token: 0x0600C70E RID: 50958 RVA: 0x0034A658 File Offset: 0x00348858
	public override void Refresh(IActivityRewardData data, bool isSelected, int gridIndex)
	{
		this.RewardData = data;
		if (data.NameTextArgs != null)
		{
			base.GetText(6).SetText(data.NameTextArgs[0] + "/" + data.NameTextArgs[1], true);
			base.GetText(5).SetText(data.NameText ?? "", true);
		}
		base.GetButton(2).RootUIComp.Get().SetUIActive(data.RewardState == EActivityRewardState.Enable);
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(data.RewardState == EActivityRewardState.Disabled);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(data.RewardState == EActivityRewardState.Claimed);
		}
		UUIItem item3 = base.GetItem(1);
		if (item3 != null)
		{
			item3.SetUIActive(data.RewardButtonRedDot.GetValueOrDefault());
		}
		GenericScrollViewNew<CommonItemSmallItemGrid, TItem> itemLayout = this.ItemLayout;
		if (itemLayout != null)
		{
			itemLayout.RefreshByData(data.RewardList.ToList<TItem>(), null, false);
		}
		string resourceId = (data.RewardState != EActivityRewardState.Claimed) ? "SP_ItemBgNor" : "SP_ItemBgFinish";
		string path = ConfigBase<UiResourceConfig>.Instance.GetResourceConfig(resourceId).Value.Path;
		this.SetSpriteByPath(path, base.GetSprite(0), false, null, null);
		UUIItem item4 = base.GetItem(9);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(data.RewardState == EActivityRewardState.Claimed);
	}

	// Token: 0x04005F5A RID: 24410
	[Nullable(2)]
	private IActivityRewardData RewardData;

	// Token: 0x04005F5B RID: 24411
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> ItemLayout;

	// Token: 0x02007DD6 RID: 32214
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ADCC RID: 175564
		public const int BgSprite = 0;

		// Token: 0x0402ADCD RID: 175565
		public const int ReDotItem = 1;

		// Token: 0x0402ADCE RID: 175566
		public const int Button = 2;

		// Token: 0x0402ADCF RID: 175567
		public const int DoingItem = 3;

		// Token: 0x0402ADD0 RID: 175568
		public const int ClaimedItem = 4;

		// Token: 0x0402ADD1 RID: 175569
		public const int NameText = 5;

		// Token: 0x0402ADD2 RID: 175570
		public const int ProgressText = 6;

		// Token: 0x0402ADD3 RID: 175571
		public const int RewardLayout = 7;

		// Token: 0x0402ADD4 RID: 175572
		public const int RewardItem = 8;

		// Token: 0x0402ADD5 RID: 175573
		public const int MaskItem = 9;
	}
}
