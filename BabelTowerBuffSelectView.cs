using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011D3 RID: 4563
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerBuffSelectView : UiViewBase
{
	// Token: 0x0600786C RID: 30828 RVA: 0x001F8528 File Offset: 0x001F6728
	public BabelTowerBuffSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600786D RID: 30829 RVA: 0x001F853C File Offset: 0x001F673C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600786E RID: 30830 RVA: 0x001F870E File Offset: 0x001F690E
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x0600786F RID: 30831 RVA: 0x001F872C File Offset: 0x001F692C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BabelTowerRefreshLevelInfo, new Action(this.BabelTowerRefreshLevelInfo));
	}

	// Token: 0x06007870 RID: 30832 RVA: 0x001F874C File Offset: 0x001F694C
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerBuffSelectView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerBuffSelectView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007871 RID: 30833 RVA: 0x001F8790 File Offset: 0x001F6990
	protected override void OnStart()
	{
		this.BabelTowerBuffSelectViewInfo = (this.OpenParam as IBabelTowerBuffSelectViewInfo);
		base.GetItem(4).SetUIActive(true);
		base.GetItem(5).SetUIActive(false);
		this.BabelTowerBuffSelectViewInfo.AllBuffList.Sort(delegate(IBabelTowerBuffInfo a, IBabelTowerBuffInfo b)
		{
			int num = (!a.IsRecommend) ? 1 : 0;
			int num2 = (!b.IsRecommend) ? 1 : 0;
			return num - num2;
		});
		LoopScrollView<BabelTowerBuffSelectItem, IBabelTowerBuffInfo> loopScrollView = this.LoopScrollView;
		if (loopScrollView != null)
		{
			loopScrollView.RefreshByData(this.BabelTowerBuffSelectViewInfo.AllBuffList, false, delegate
			{
				IBabelTowerBuffSelectViewInfo babelTowerBuffSelectViewInfo = this.BabelTowerBuffSelectViewInfo;
				List<int> list = ((babelTowerBuffSelectViewInfo != null) ? babelTowerBuffSelectViewInfo.CurrentSelectBuffList : null) ?? new List<int>();
				foreach (BabelTowerBuffSelectItem babelTowerBuffSelectItem in this.BuffItemList)
				{
					if (list.Contains(babelTowerBuffSelectItem.BuffId))
					{
						babelTowerBuffSelectItem.SetToggleState(EToggleState.ETT_Checked);
					}
					else
					{
						babelTowerBuffSelectItem.SetToggleState(EToggleState.ETT_UnChecked);
					}
				}
			}, false);
		}
		if (this.BabelTowerBuffSelectViewInfo.ShowBuffId > 0)
		{
			this.RefreshView(this.BabelTowerBuffSelectViewInfo.ShowBuffId);
		}
		UUIInturnAnimController uuiinturnAnimController = base.GetLoopScrollViewComponent(1).Content.Get().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
		if (uuiinturnAnimController == null)
		{
			return;
		}
		uuiinturnAnimController.Play("", -1, false);
	}

	// Token: 0x06007872 RID: 30834 RVA: 0x001F887C File Offset: 0x001F6A7C
	private void RefreshView(int buffId)
	{
		base.GetItem(4).SetUIActive(false);
		base.GetItem(5).SetUIActive(true);
		BabelTowerBuff babelTowerBuff = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerBuff(buffId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), babelTowerBuff.NameText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), babelTowerBuff.DesText, Array.Empty<object>());
		List<IBabelTowerBuffSelectViewLevelItemData> list = new List<IBabelTowerBuffSelectViewLevelItemData>();
		EBabelTowerBuffState buffState = this.GetBuffState(buffId);
		for (int i = 0; i < babelTowerBuff.DifficultPreLevelLength; i++)
		{
			int levelId = babelTowerBuff.DifficultPreLevel(i);
			list.Add(new BabelTowerBuffSelectViewLevelItemData
			{
				LevelId = levelId,
				BuffId = buffId,
				State = buffState
			});
		}
		if (buffState == EBabelTowerBuffState.Use)
		{
			base.GetText(7).SetUIActive(false);
		}
		else if (buffState == EBabelTowerBuffState.Lock)
		{
			base.GetText(7).SetUIActive(true);
		}
		else if (buffState == EBabelTowerBuffState.Normal)
		{
			int difficultPreLevelLength = babelTowerBuff.DifficultPreLevelLength;
			base.GetText(7).SetUIActive(difficultPreLevelLength > 0);
		}
		GenericLayout<BabelTowerBuffSelectViewLevelItem, IBabelTowerBuffSelectViewLevelItemData> levelLayout = this.LevelLayout;
		if (levelLayout == null)
		{
			return;
		}
		levelLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06007873 RID: 30835 RVA: 0x001F898C File Offset: 0x001F6B8C
	private void OnClickConfirmBtn()
	{
		foreach (int buffId in this.BabelTowerBuffSelectViewInfo.CurrentSelectBuffList)
		{
			EBabelTowerBuffState buffState = this.GetBuffState(buffId);
			if (buffState == EBabelTowerBuffState.Use || buffState == EBabelTowerBuffState.Lock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerBuffCannotChose", Array.Empty<object>());
				this.RefreshView(buffId);
				return;
			}
		}
		IBabelTowerBuffSelectViewInfo babelTowerBuffSelectViewInfo = this.BabelTowerBuffSelectViewInfo;
		if (babelTowerBuffSelectViewInfo != null)
		{
			Action<List<int>> onConfirmCallBack = babelTowerBuffSelectViewInfo.OnConfirmCallBack;
			if (onConfirmCallBack != null)
			{
				IBabelTowerBuffSelectViewInfo babelTowerBuffSelectViewInfo2 = this.BabelTowerBuffSelectViewInfo;
				onConfirmCallBack(((babelTowerBuffSelectViewInfo2 != null) ? babelTowerBuffSelectViewInfo2.CurrentSelectBuffList : null) ?? new List<int>());
			}
		}
		base.CloseMe(null);
	}

	// Token: 0x06007874 RID: 30836 RVA: 0x001F8A48 File Offset: 0x001F6C48
	private BabelTowerBuffSelectItem InitItem()
	{
		BabelTowerBuffSelectItem babelTowerBuffSelectItem = new BabelTowerBuffSelectItem();
		babelTowerBuffSelectItem.CanClickCallBack = new Func<int, bool>(this.CanClickItem);
		babelTowerBuffSelectItem.OnClickToggleCallBack = new Action<int>(this.OnClickBuffItem);
		babelTowerBuffSelectItem.OnCancelClickToggleCallBack = new Action<int>(this.OnCancelClickBuffItem);
		this.BuffItemList.Add(babelTowerBuffSelectItem);
		return babelTowerBuffSelectItem;
	}

	// Token: 0x06007875 RID: 30837 RVA: 0x001F8A9E File Offset: 0x001F6C9E
	private BabelTowerBuffSelectViewLevelItem InitLevelItem()
	{
		return new BabelTowerBuffSelectViewLevelItem();
	}

	// Token: 0x06007876 RID: 30838 RVA: 0x001F8AA8 File Offset: 0x001F6CA8
	private bool CanClickItem(int buffId)
	{
		if (this.BabelTowerBuffSelectViewInfo.MaxSelectBuffCount == 1)
		{
			return true;
		}
		if (this.BabelTowerBuffSelectViewInfo.CurrentSelectBuffList.Count >= this.BabelTowerBuffSelectViewInfo.MaxSelectBuffCount)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelTowerBuffMax", Array.Empty<object>());
			this.RefreshView(buffId);
			return false;
		}
		return true;
	}

	// Token: 0x06007877 RID: 30839 RVA: 0x001F8B00 File Offset: 0x001F6D00
	private void OnClickBuffItem(int buffId)
	{
		IBabelTowerBuffSelectViewInfo babelTowerBuffSelectViewInfo = this.BabelTowerBuffSelectViewInfo;
		if (babelTowerBuffSelectViewInfo != null && babelTowerBuffSelectViewInfo.MaxSelectBuffCount == 1)
		{
			int count = this.BabelTowerBuffSelectViewInfo.AllBuffList.Count;
			for (int i = 0; i < count; i++)
			{
				LoopScrollView<BabelTowerBuffSelectItem, IBabelTowerBuffInfo> loopScrollView = this.LoopScrollView;
				BabelTowerBuffSelectItem babelTowerBuffSelectItem = (loopScrollView != null) ? loopScrollView.UnsafeGetGridProxy(i, false) : null;
				if (babelTowerBuffSelectItem == null || babelTowerBuffSelectItem.BuffId != buffId)
				{
					LoopScrollView<BabelTowerBuffSelectItem, IBabelTowerBuffInfo> loopScrollView2 = this.LoopScrollView;
					if (loopScrollView2 != null)
					{
						loopScrollView2.UnsafeGetGridProxy(i, false).SetToggleState(EToggleState.ETT_UnChecked);
					}
				}
			}
			this.BabelTowerBuffSelectViewInfo.CurrentSelectBuffList.Clear();
		}
		IBabelTowerBuffSelectViewInfo babelTowerBuffSelectViewInfo2 = this.BabelTowerBuffSelectViewInfo;
		if (babelTowerBuffSelectViewInfo2 != null)
		{
			babelTowerBuffSelectViewInfo2.CurrentSelectBuffList.Add(buffId);
		}
		this.RefreshView(buffId);
	}

	// Token: 0x06007878 RID: 30840 RVA: 0x001F8BB0 File Offset: 0x001F6DB0
	private void OnCancelClickBuffItem(int buffId)
	{
		IBabelTowerBuffSelectViewInfo babelTowerBuffSelectViewInfo = this.BabelTowerBuffSelectViewInfo;
		List<int> list = (babelTowerBuffSelectViewInfo != null) ? babelTowerBuffSelectViewInfo.CurrentSelectBuffList : null;
		if (((list != null) ? list.Count : 0) > 0)
		{
			int i = 0;
			while (i < list.Count)
			{
				if (list[i] == buffId)
				{
					IBabelTowerBuffSelectViewInfo babelTowerBuffSelectViewInfo2 = this.BabelTowerBuffSelectViewInfo;
					if (babelTowerBuffSelectViewInfo2 == null)
					{
						break;
					}
					babelTowerBuffSelectViewInfo2.CurrentSelectBuffList.RemoveAt(i);
					break;
				}
				else
				{
					i++;
				}
			}
		}
		this.RefreshView(buffId);
	}

	// Token: 0x06007879 RID: 30841 RVA: 0x001F8C1C File Offset: 0x001F6E1C
	private EBabelTowerBuffState GetBuffState(int buffId)
	{
		foreach (IBabelTowerBuffInfo babelTowerBuffInfo in this.BabelTowerBuffSelectViewInfo.AllBuffList)
		{
			if (babelTowerBuffInfo.Id == buffId)
			{
				return babelTowerBuffInfo.State;
			}
		}
		return EBabelTowerBuffState.Normal;
	}

	// Token: 0x0600787A RID: 30842 RVA: 0x001F8C84 File Offset: 0x001F6E84
	private void BabelTowerRefreshLevelInfo()
	{
		BabelTowerLevel babelTowerLevelConfig = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerLevelConfig(this.BabelTowerBuffSelectViewInfo.LevelId);
		bool isDifficult = babelTowerLevelConfig.IsDifficult;
		List<IBabelTowerBuffInfo> list = new List<IBabelTowerBuffInfo>();
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		for (int i = 0; i < babelTowerLevelConfig.OptionalBabelBuffLength; i++)
		{
			int num = babelTowerLevelConfig.OptionalBabelBuff(i);
			EBabelTowerBuffState state = EBabelTowerBuffState.Normal;
			if (isDifficult)
			{
				if (babelTowerData.GetBuffIsLock(num))
				{
					state = EBabelTowerBuffState.Lock;
				}
				else
				{
					int buffIsUse = babelTowerData.GetBuffIsUse(num);
					if (buffIsUse > 0 && buffIsUse != this.BabelTowerBuffSelectViewInfo.LevelId)
					{
						state = EBabelTowerBuffState.Use;
					}
				}
			}
			bool isRecommend = false;
			for (int j = 0; j < babelTowerLevelConfig.RecommendBuffLength; j++)
			{
				if (babelTowerLevelConfig.RecommendBuff(j) == num)
				{
					isRecommend = true;
					break;
				}
			}
			list.Add(new BabelTowerBuffInfo
			{
				Id = num,
				State = state,
				LevelId = new int?(this.BabelTowerBuffSelectViewInfo.LevelId),
				IsRecommend = isRecommend
			});
		}
		this.BabelTowerBuffSelectViewInfo.AllBuffList = list;
		foreach (BabelTowerBuffSelectItem babelTowerBuffSelectItem in this.BuffItemList)
		{
			EBabelTowerBuffState buffState = this.GetBuffState(babelTowerBuffSelectItem.BuffId);
			babelTowerBuffSelectItem.RefreshState(buffState);
		}
		foreach (BabelTowerBuffSelectViewLevelItem babelTowerBuffSelectViewLevelItem in this.LevelLayout.GetLayoutItemList())
		{
			babelTowerBuffSelectViewLevelItem.RefreshState(EBabelTowerBuffState.Normal);
		}
		if (!isDifficult)
		{
			return;
		}
		foreach (IBabelTowerBuffInfo babelTowerBuffInfo in this.BabelTowerBuffSelectViewInfo.AllBuffList)
		{
			if (babelTowerData.GetBuffIsLock(babelTowerBuffInfo.Id))
			{
				babelTowerBuffInfo.State = EBabelTowerBuffState.Lock;
			}
			else
			{
				int buffIsUse2 = babelTowerData.GetBuffIsUse(babelTowerBuffInfo.Id);
				if (buffIsUse2 > 0 && buffIsUse2 != this.BabelTowerBuffSelectViewInfo.LevelId)
				{
					babelTowerBuffInfo.State = EBabelTowerBuffState.Use;
				}
				else
				{
					babelTowerBuffInfo.State = EBabelTowerBuffState.Normal;
				}
			}
		}
	}

	// Token: 0x04003A29 RID: 14889
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003A2A RID: 14890
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BabelTowerBuffSelectItem, IBabelTowerBuffInfo> LoopScrollView;

	// Token: 0x04003A2B RID: 14891
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<BabelTowerBuffSelectViewLevelItem, IBabelTowerBuffSelectViewLevelItemData> LevelLayout;

	// Token: 0x04003A2C RID: 14892
	[Nullable(2)]
	private IBabelTowerBuffSelectViewInfo BabelTowerBuffSelectViewInfo;

	// Token: 0x04003A2D RID: 14893
	private readonly List<BabelTowerBuffSelectItem> BuffItemList = new List<BabelTowerBuffSelectItem>();

	// Token: 0x0200752C RID: 29996
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028722 RID: 165666
		public const int CaptionItem = 0;

		// Token: 0x04028723 RID: 165667
		public const int LoopScrollView = 1;

		// Token: 0x04028724 RID: 165668
		public const int LoopScrollItem = 2;

		// Token: 0x04028725 RID: 165669
		public const int ConfirmBtn = 3;

		// Token: 0x04028726 RID: 165670
		public const int EmptyItem = 4;

		// Token: 0x04028727 RID: 165671
		public const int NotEmptyItem = 5;

		// Token: 0x04028728 RID: 165672
		public const int BuffNameText = 6;

		// Token: 0x04028729 RID: 165673
		public const int InfoTitleText = 7;

		// Token: 0x0402872A RID: 165674
		public const int DesText = 8;

		// Token: 0x0402872B RID: 165675
		public const int LevelLayout = 9;

		// Token: 0x0402872C RID: 165676
		public const int LevelItem = 10;
	}
}
