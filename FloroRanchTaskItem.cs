using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C6D RID: 7277
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchTaskItem : GridProxyAbstract<FloroRanchTaskData>
{
	// Token: 0x0600D462 RID: 54370 RVA: 0x0038ABFC File Offset: 0x00388DFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, this.OnGetBtnClick);
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnJumpBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D463 RID: 54371 RVA: 0x0038ADA7 File Offset: 0x00388FA7
	protected override void OnStart()
	{
		this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
	}

	// Token: 0x0600D464 RID: 54372 RVA: 0x0038ADCA File Offset: 0x00388FCA
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600D465 RID: 54373 RVA: 0x0038ADD4 File Offset: 0x00388FD4
	public override void Refresh(FloroRanchTaskData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RewardScroll.RefreshByData(data.RewardList, delegate
		{
			this.RewardScroll.ScrollToLeft(0);
		}, false);
		bool uiactive = data.Status == EActivityTaskState.FinishedAndClaimed;
		bool uiactive2 = data.Status == EActivityTaskState.FinishedAndUnclaimed;
		bool flag = data.Status == EActivityTaskState.Active;
		base.GetButton(4).RootUIComp.Get().SetUIActive(uiactive2);
		base.GetItem(7).SetUIActive(uiactive2);
		base.GetSprite(6).SetUIActive(uiactive);
		base.GetText(5).SetUIActive(flag && data.JumpId == 0);
		UUIButtonComponent button = base.GetButton(8);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag && data.JumpId > 0);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.TaskName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BlackCoastTheme_TaskProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			data.Current,
			data.Target
		}));
	}

	// Token: 0x0600D466 RID: 54374 RVA: 0x0038AEFA File Offset: 0x003890FA
	private void OnJumpBtnClick()
	{
		SkipTaskManager.RunByConfigId(this.Data.JumpId, null);
	}

	// Token: 0x0400650C RID: 25868
	[Nullable(2)]
	private FloroRanchTaskData Data;

	// Token: 0x0400650D RID: 25869
	public Action OnGetBtnClick = delegate()
	{
	};

	// Token: 0x0400650E RID: 25870
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

	// Token: 0x02007F95 RID: 32661
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B6FB RID: 177915
		public const int TextName = 0;

		// Token: 0x0402B6FC RID: 177916
		public const int TextProgress = 1;

		// Token: 0x0402B6FD RID: 177917
		public const int ScrollReward = 2;

		// Token: 0x0402B6FE RID: 177918
		public const int ItemReward = 3;

		// Token: 0x0402B6FF RID: 177919
		public const int ButtonGet = 4;

		// Token: 0x0402B700 RID: 177920
		public const int TextDoing = 5;

		// Token: 0x0402B701 RID: 177921
		public const int SpriteFinish = 6;

		// Token: 0x0402B702 RID: 177922
		public const int ItemRedDot = 7;

		// Token: 0x0402B703 RID: 177923
		public const int ButtonJump = 8;
	}
}
