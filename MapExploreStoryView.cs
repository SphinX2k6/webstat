using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B9C RID: 7068
[NullableContext(2)]
[Nullable(0)]
public class MapExploreStoryView : UiViewBase
{
	// Token: 0x0600CDA6 RID: 52646 RVA: 0x0036C803 File Offset: 0x0036AA03
	[NullableContext(1)]
	public MapExploreStoryView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CDA7 RID: 52647 RVA: 0x0036C814 File Offset: 0x0036AA14
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CDA8 RID: 52648 RVA: 0x0036C904 File Offset: 0x0036AB04
	protected override UniTask OnBeforeStartAsync()
	{
		MapExploreStoryView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MapExploreStoryView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CDA9 RID: 52649 RVA: 0x0036C948 File Offset: 0x0036AB48
	protected override void OnBeforeShow()
	{
		MapExploreStoryViewParams dataParam = this.DataParam;
		ExploreAreaData exploreAreaData = (dataParam != null) ? dataParam.AreaData : null;
		if (exploreAreaData == null)
		{
			return;
		}
		string storyViewTitle = exploreAreaData.GetStoryViewTitle();
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(storyViewTitle, true);
		}
		float value = (float)exploreAreaData.GetProgress();
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(value);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		MapAreaOnlyShowItem areaShowItem = this.AreaShowItem;
		if (areaShowItem == null)
		{
			return;
		}
		areaShowItem.Refresh(exploreAreaData.GetIconPercentDataAreaStory(), null);
	}

	// Token: 0x0600CDAA RID: 52650 RVA: 0x0036C9E8 File Offset: 0x0036ABE8
	protected override void OnAfterPlayStartSequence()
	{
		if (this.JumpIndex >= 0 && this.StoryList != null)
		{
			for (int i = this.JumpIndex; i < this.StoryList.Count; i++)
			{
				if (this.StoryList[i].IsNewOpen.GetValueOrDefault())
				{
					GenericScrollViewNew<MapExploreStoryItem, IMapExploreStoryItemData> scrollView = this.ScrollView;
					if (scrollView != null)
					{
						MapExploreStoryItem scrollItemByIndex = scrollView.GetScrollItemByIndex(i);
						if (scrollItemByIndex != null)
						{
							scrollItemByIndex.PlayNewOpenAnim();
						}
					}
				}
			}
		}
	}

	// Token: 0x0600CDAB RID: 52651 RVA: 0x0036CA5C File Offset: 0x0036AC5C
	protected override void OnBeforeDestroy()
	{
		MapExploreStoryViewParams dataParam = this.DataParam;
		if (dataParam != null)
		{
			ExploreAreaData areaData = dataParam.AreaData;
			if (areaData != null)
			{
				areaData.SaveLocalAreaStoryProgress();
			}
		}
		MapExploreStoryViewParams dataParam2 = this.DataParam;
		if (dataParam2 != null)
		{
			ExploreAreaData areaData2 = dataParam2.AreaData;
			if (areaData2 != null)
			{
				areaData2.SaveLocalIconPercentAreaStory();
			}
		}
		this.PopupCaption = null;
		this.ScrollView = null;
		this.AreaShowItem = null;
	}

	// Token: 0x0600CDAC RID: 52652 RVA: 0x0036CAB7 File Offset: 0x0036ACB7
	private void OnCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400622F RID: 25135
	private MapExploreStoryViewParams DataParam;

	// Token: 0x04006230 RID: 25136
	private PopupCaptionItem PopupCaption;

	// Token: 0x04006231 RID: 25137
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MapExploreStoryItem, IMapExploreStoryItemData> ScrollView;

	// Token: 0x04006232 RID: 25138
	private MapAreaOnlyShowItem AreaShowItem;

	// Token: 0x04006233 RID: 25139
	private int JumpIndex = -1;

	// Token: 0x04006234 RID: 25140
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IMapExploreStoryItemData> StoryList;

	// Token: 0x02007E88 RID: 32392
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B1AB RID: 176555
		ItemCaption,
		// Token: 0x0402B1AC RID: 176556
		ScrollView,
		// Token: 0x0402B1AD RID: 176557
		ItemStory,
		// Token: 0x0402B1AE RID: 176558
		ItemExploreArea,
		// Token: 0x0402B1AF RID: 176559
		TxtAreaProgress,
		// Token: 0x0402B1B0 RID: 176560
		TxtTitle
	}
}
