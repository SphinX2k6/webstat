using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E6A RID: 7786
[NullableContext(1)]
[Nullable(0)]
public class HandBookEntranceView : UiViewBase
{
	// Token: 0x0600E63A RID: 58938 RVA: 0x003E234D File Offset: 0x003E054D
	public HandBookEntranceView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.HandBookEntranceList = new List<HandBookEntrance>();
		this.HandBookEntranceItemList = new List<HandBookEntranceItem>();
	}

	// Token: 0x0600E63B RID: 58939 RVA: 0x003E236C File Offset: 0x003E056C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600E63C RID: 58940 RVA: 0x003E23DC File Offset: 0x003E05DC
	protected override UniTask OnBeforeStartAsync()
	{
		HandBookEntranceView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HandBookEntranceView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E63D RID: 58941 RVA: 0x003E2417 File Offset: 0x003E0617
	protected override void OnStart()
	{
		this.InitCommonTabTitle();
		this.OnHandBookRedDotUpdate();
		this.OnHandBookDataInit();
	}

	// Token: 0x0600E63E RID: 58942 RVA: 0x003E242B File Offset: 0x003E062B
	protected override void OnBeforeShow()
	{
		ControllerBase<HandBookController>.Instance.SendIllustratedRedDotRequest().ContinueWith(new Action(this.OnHandBookRedDotUpdate)).Forget();
	}

	// Token: 0x0600E63F RID: 58943 RVA: 0x003E244D File Offset: 0x003E064D
	protected void OnHandBookDataInit()
	{
		this.InitVerticalLayout();
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600E640 RID: 58944 RVA: 0x003E2468 File Offset: 0x003E0668
	protected void OnHandBookRedDotUpdate()
	{
		int count = this.HandBookEntranceItemList.Count;
		for (int i = 0; i < count; i++)
		{
			this.HandBookEntranceItemList[i].RefreshRedDot();
		}
	}

	// Token: 0x0600E641 RID: 58945 RVA: 0x003E24A0 File Offset: 0x003E06A0
	protected void InitCommonTabTitle()
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("HandBookEntrance");
		string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("HandBookEntrance");
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickCloseButton));
		this.CaptionItem.SetTitleLocalText(textContentIdById);
		this.CaptionItem.SetTitleIcon(resourcePath);
	}

	// Token: 0x0600E642 RID: 58946 RVA: 0x003E2510 File Offset: 0x003E0710
	protected void InitVerticalLayout()
	{
		List<HandBookEntrance> list = ConfigCommon.ToList<HandBookEntrance>(ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfigList());
		list.Sort(new Comparison<HandBookEntrance>(this.SortIndex));
		this.HandBookEntranceList = list;
		if (this.ScrollView == null)
		{
			this.ScrollView = new GenericScrollViewNew<HandBookEntranceItem, HandBookEntrance>(base.GetScrollViewWithScrollbar(2), new Func<HandBookEntranceItem>(this.InitItem), null, false, null);
		}
		this.ScrollView.RefreshByData(this.HandBookEntranceList, null, false);
		IHandBookEntranceViewParam param = this.OpenParam as IHandBookEntranceViewParam;
		if (param != null)
		{
			int index = this.HandBookEntranceList.FindIndex((HandBookEntrance entrance) => entrance.Id == (int)param.SelectedTabType);
			UUIItem itemByIndex = this.ScrollView.GetItemByIndex(index);
			if (itemByIndex != null)
			{
				GenericScrollViewNew<HandBookEntranceItem, HandBookEntrance> scrollView = this.ScrollView;
				if (scrollView == null)
				{
					return;
				}
				scrollView.LateScrollTo(itemByIndex, null, false);
			}
		}
	}

	// Token: 0x0600E643 RID: 58947 RVA: 0x003E25DC File Offset: 0x003E07DC
	private HandBookEntranceItem InitItem()
	{
		HandBookEntranceItem handBookEntranceItem = new HandBookEntranceItem();
		this.HandBookEntranceItemList.Add(handBookEntranceItem);
		return handBookEntranceItem;
	}

	// Token: 0x0600E644 RID: 58948 RVA: 0x003E25FC File Offset: 0x003E07FC
	private int SortIndex(HandBookEntrance a, HandBookEntrance b)
	{
		return a.SortId - b.SortId;
	}

	// Token: 0x0600E645 RID: 58949 RVA: 0x003E260D File Offset: 0x003E080D
	private void OnClickCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.HandBookEntranceView, null);
	}

	// Token: 0x0600E646 RID: 58950 RVA: 0x003E261F File Offset: 0x003E081F
	protected override void OnBeforeDestroy()
	{
		this.HandBookEntranceList = new List<HandBookEntrance>();
		this.HandBookEntranceItemList = new List<HandBookEntranceItem>();
	}

	// Token: 0x04006F07 RID: 28423
	private List<HandBookEntrance> HandBookEntranceList;

	// Token: 0x04006F08 RID: 28424
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<HandBookEntranceItem, HandBookEntrance> ScrollView;

	// Token: 0x04006F09 RID: 28425
	private List<HandBookEntranceItem> HandBookEntranceItemList;

	// Token: 0x04006F0A RID: 28426
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;
}
