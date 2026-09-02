using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001335 RID: 4917
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FightPhotoTaskItem : GridProxyAbstract<FightPhotoTaskData>
{
	// Token: 0x0600863E RID: 34366 RVA: 0x00235F74 File Offset: 0x00234174
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnRewardBtnClickHandler))
		};
	}

	// Token: 0x0600863F RID: 34367 RVA: 0x00236033 File Offset: 0x00234233
	protected override void OnStart()
	{
		this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(4), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
	}

	// Token: 0x06008640 RID: 34368 RVA: 0x00236058 File Offset: 0x00234258
	public override void Refresh(FightPhotoTaskData data, bool isSelected, int gridIndex)
	{
		this.RewardScroll.RefreshByData(data.RewardList, delegate
		{
			this.RewardScroll.ScrollToLeft(0);
		}, false);
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(data.IsUnclaimed);
		}
		base.GetButton(0).RootUIComp.Get().SetUIActive(data.IsUnclaimed);
		base.GetItem(2).SetUIActive(data.IsFinished);
		base.GetText(1).SetUIActive(data.IsDoing);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.TaskName, Array.Empty<object>());
	}

	// Token: 0x06008641 RID: 34369 RVA: 0x002360FA File Offset: 0x002342FA
	private void OnRewardBtnClickHandler()
	{
		Action onRewardBtnClick = this.OnRewardBtnClick;
		if (onRewardBtnClick == null)
		{
			return;
		}
		onRewardBtnClick();
	}

	// Token: 0x06008642 RID: 34370 RVA: 0x0023610C File Offset: 0x0023430C
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x04003F7A RID: 16250
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

	// Token: 0x04003F7B RID: 16251
	[Nullable(2)]
	public Action OnRewardBtnClick;

	// Token: 0x020076D9 RID: 30425
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x04028EFB RID: 167675
		BtnReward,
		// Token: 0x04028EFC RID: 167676
		TextDoing,
		// Token: 0x04028EFD RID: 167677
		ItemFinish,
		// Token: 0x04028EFE RID: 167678
		TextName,
		// Token: 0x04028EFF RID: 167679
		ScrollReward,
		// Token: 0x04028F00 RID: 167680
		ItemLockPanel,
		// Token: 0x04028F01 RID: 167681
		ItemRedDot
	}
}
