using System;
using System.Collections.Generic;
using UnrealEngine;

// Token: 0x02002875 RID: 10357
public class RoleFavorDescComponent : RoleFavorViewComponentBase
{
	// Token: 0x06014823 RID: 84003 RVA: 0x005B0CFC File Offset: 0x005AEEFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06014824 RID: 84004 RVA: 0x005B0D58 File Offset: 0x005AEF58
	protected override void OnRefreshView()
	{
		if (this.ContentData == null)
		{
			return;
		}
		UUIText text = base.GetText(1);
		UUIText text2 = base.GetText(2);
		string title = this.ContentData.Title;
		string content = this.ContentData.Content;
		if (text != null)
		{
			text.SetText(title, true);
		}
		if (text2 != null)
		{
			text2.SetText(content, true);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		scrollViewWithScrollbar.SetScrollProgress(0f);
	}

	// Token: 0x06014825 RID: 84005 RVA: 0x005B0DC4 File Offset: 0x005AEFC4
	protected override void OnStart()
	{
		UUIText text = base.GetText(2);
		if (!ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text))
		{
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(text, ETermExplanationViewType.Side, ETermExplanationReportType.RoleInfo, ETermExplanationViewAttachDirection.Left, null, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
		}
	}

	// Token: 0x06014826 RID: 84006 RVA: 0x005B0E04 File Offset: 0x005AF004
	protected override void OnBeforeDestroy()
	{
		UUIText text = base.GetText(2);
		if (ControllerBase<TermExplanationController>.Instance.IsUiTextRegistered(text))
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(text);
		}
	}
}
