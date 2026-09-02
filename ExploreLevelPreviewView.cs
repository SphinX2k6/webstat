using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.ExploreLevel;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B63 RID: 7011
[NullableContext(1)]
[Nullable(0)]
public class ExploreLevelPreviewView : UiViewBase
{
	// Token: 0x0600CB0D RID: 51981 RVA: 0x003624EC File Offset: 0x003606EC
	public ExploreLevelPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CB0E RID: 51982 RVA: 0x003624F8 File Offset: 0x003606F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedHelpButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedLeftButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedRightButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CB0F RID: 51983 RVA: 0x003626F0 File Offset: 0x003608F0
	protected override UniTask OnBeforeStartAsync()
	{
		ExploreLevelPreviewView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ExploreLevelPreviewView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CB10 RID: 51984 RVA: 0x00362734 File Offset: 0x00360934
	private void OnPreviewItemGridClicked(MediumItemGridExtendCallback callbackParameter)
	{
		int itemId = (int)callbackParameter.Data;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
	}

	// Token: 0x0600CB11 RID: 51985 RVA: 0x0036275A File Offset: 0x0036095A
	private void OnClickedHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(this.PreviewExploreLevelRewardData.GetHelpId());
	}

	// Token: 0x0600CB12 RID: 51986 RVA: 0x00362771 File Offset: 0x00360971
	private void OnClickedLeftButton()
	{
		this.PreviewIndex = Math.Max(0, this.PreviewIndex - 1);
		this.RefreshPreviewDisplay();
	}

	// Token: 0x0600CB13 RID: 51987 RVA: 0x0036278D File Offset: 0x0036098D
	private void OnClickedRightButton()
	{
		this.PreviewIndex = Math.Min(this.PreviewIndex + 1, this.UnlockFunctionExploreLevelRewardDataList.Count - 1);
		this.RefreshPreviewDisplay();
	}

	// Token: 0x0600CB14 RID: 51988 RVA: 0x003627B8 File Offset: 0x003609B8
	protected override void OnStart()
	{
		this.CountryExploreLevelData = (this.OpenParam as CountryExploreLevelData);
		this.LoopScrollView = new LoopScrollView<ExploreLevelPreviewItem, CountryExploreLevelRewardData>(base.GetLoopScrollViewComponent(6), base.GetItem(7).GetOwner() as AUIBaseActor, new Func<ExploreLevelPreviewItem>(this.OnCreateExploreLevelPreviewItem), false);
		this.UnlockFunctionExploreLevelRewardDataList = this.CountryExploreLevelData.GetUnlockFunctionExploreLevelRewardDataList();
		this.PreviewIndex = this.GetPreviewExploreLevelRewardDataIndex(this.CountryExploreLevelData.GetExploreLevel()).GetValueOrDefault();
		this.RefreshPreviewDisplay();
		this.RefreshExploreLevelPreviewItemScrollView();
	}

	// Token: 0x0600CB15 RID: 51989 RVA: 0x00362842 File Offset: 0x00360A42
	protected override void OnBeforeDestroy()
	{
		this.CountryExploreLevelData = null;
		LoopScrollView<ExploreLevelPreviewItem, CountryExploreLevelRewardData> loopScrollView = this.LoopScrollView;
		if (loopScrollView != null)
		{
			loopScrollView.ClearGridProxies();
		}
		this.LoopScrollView = null;
	}

	// Token: 0x0600CB16 RID: 51990 RVA: 0x00362863 File Offset: 0x00360A63
	private ExploreLevelPreviewItem OnCreateExploreLevelPreviewItem()
	{
		return new ExploreLevelPreviewItem();
	}

	// Token: 0x0600CB17 RID: 51991 RVA: 0x0036286C File Offset: 0x00360A6C
	private int? GetPreviewExploreLevelRewardDataIndex(int fromExploreLevel)
	{
		int count = this.UnlockFunctionExploreLevelRewardDataList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.UnlockFunctionExploreLevelRewardDataList[i].GetExploreLevel() > fromExploreLevel)
			{
				return new int?(i);
			}
		}
		for (int j = count - 1; j > 0; j--)
		{
			if (this.UnlockFunctionExploreLevelRewardDataList[j].GetExploreLevel() < fromExploreLevel)
			{
				return new int?(j);
			}
		}
		return null;
	}

	// Token: 0x0600CB18 RID: 51992 RVA: 0x003628E0 File Offset: 0x00360AE0
	private void RefreshPreviewDisplay()
	{
		if (this.UnlockFunctionExploreLevelRewardDataList.Count > this.PreviewIndex)
		{
			CountryExploreLevelRewardData exploreLevelRewardData = this.UnlockFunctionExploreLevelRewardDataList[this.PreviewIndex];
			this.RefreshUnlockDisplay(exploreLevelRewardData);
			this.RefreshPreviewItemGrid(exploreLevelRewardData);
		}
		this.RefreshButtonVisible();
	}

	// Token: 0x0600CB19 RID: 51993 RVA: 0x00362928 File Offset: 0x00360B28
	private void RefreshUnlockDisplay(CountryExploreLevelRewardData exploreLevelRewardData)
	{
		this.PreviewExploreLevelRewardData = exploreLevelRewardData;
		if (!exploreLevelRewardData.IsShowUnlockSprite())
		{
			return;
		}
		this.SetSpriteByPath(exploreLevelRewardData.GetUnlockSpritePath(), base.GetSprite(5), false, null, null);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(exploreLevelRewardData.GetScoreNameId(), null);
		UUIText text = base.GetText(4);
		bool flag = exploreLevelRewardData.GetExploreLevel() <= this.CountryExploreLevelData.GetExploreLevel();
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ExploreUnlockRewardText", new <>z__ReadOnlySingleElementList<object>(localTextNew));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ExploreLockRewardText", new <>z__ReadOnlySingleElementList<object>(localTextNew));
		}
		base.GetSprite(8).SetUIActive(!flag);
		base.GetText(3).ShowTextNew(exploreLevelRewardData.GetRewardNameId());
	}

	// Token: 0x0600CB1A RID: 51994 RVA: 0x003629E4 File Offset: 0x00360BE4
	private void RefreshPreviewItemGrid(CountryExploreLevelRewardData exploreLevelRewardData)
	{
		int previewItemConfigId = exploreLevelRewardData.GetPreviewItemConfigId();
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = previewItemConfigId,
			ItemConfigId = new int?(previewItemConfigId)
		};
		SmallItemGrid previewItemGrid = this.PreviewItemGrid;
		if (previewItemGrid == null)
		{
			return;
		}
		previewItemGrid.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0600CB1B RID: 51995 RVA: 0x00362A28 File Offset: 0x00360C28
	private void RefreshButtonVisible()
	{
		int count = this.UnlockFunctionExploreLevelRewardDataList.Count;
		base.GetButton(2).RootUIComp.Get().SetUIActive(this.PreviewIndex < count - 1);
		base.GetButton(1).RootUIComp.Get().SetUIActive(this.PreviewIndex > 0);
	}

	// Token: 0x0600CB1C RID: 51996 RVA: 0x00362A88 File Offset: 0x00360C88
	private void RefreshExploreLevelPreviewItemScrollView()
	{
		List<CountryExploreLevelRewardData> data = this.CountryExploreLevelData.GetAllExploreLevelRewardData().Skip(1).ToList<CountryExploreLevelRewardData>();
		LoopScrollView<ExploreLevelPreviewItem, CountryExploreLevelRewardData> loopScrollView = this.LoopScrollView;
		if (loopScrollView == null)
		{
			return;
		}
		loopScrollView.ReloadData(data, false);
	}

	// Token: 0x04006118 RID: 24856
	[Nullable(2)]
	private CountryExploreLevelData CountryExploreLevelData;

	// Token: 0x04006119 RID: 24857
	[Nullable(2)]
	private CountryExploreLevelRewardData PreviewExploreLevelRewardData;

	// Token: 0x0400611A RID: 24858
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ExploreLevelPreviewItem, CountryExploreLevelRewardData> LoopScrollView;

	// Token: 0x0400611B RID: 24859
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IReadOnlyList<CountryExploreLevelRewardData> UnlockFunctionExploreLevelRewardDataList;

	// Token: 0x0400611C RID: 24860
	private int PreviewIndex;

	// Token: 0x0400611D RID: 24861
	[Nullable(2)]
	private SmallItemGrid PreviewItemGrid;

	// Token: 0x02007E4D RID: 32333
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B06F RID: 176239
		HelpButton,
		// Token: 0x0402B070 RID: 176240
		LeftButton,
		// Token: 0x0402B071 RID: 176241
		RightButton,
		// Token: 0x0402B072 RID: 176242
		UnlockNameText,
		// Token: 0x0402B073 RID: 176243
		UnlockDescriptionText,
		// Token: 0x0402B074 RID: 176244
		UnlockSprite,
		// Token: 0x0402B075 RID: 176245
		LoopScrollView,
		// Token: 0x0402B076 RID: 176246
		SourceRewardItem,
		// Token: 0x0402B077 RID: 176247
		LockSprite,
		// Token: 0x0402B078 RID: 176248
		PreviewItemGridItem
	}
}
