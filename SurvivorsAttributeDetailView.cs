using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B3D RID: 11069
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsAttributeDetailView : UiViewBase
{
	// Token: 0x0601614B RID: 90443 RVA: 0x00620729 File Offset: 0x0061E929
	public SurvivorsAttributeDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601614C RID: 90444 RVA: 0x00620734 File Offset: 0x0061E934
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0601614D RID: 90445 RVA: 0x00620790 File Offset: 0x0061E990
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnBackButtonClick));
		this.CaptionItem.SetTitleLocalText("PrefabTextItem_1302715335_Text");
		List<ISurvivorsAttributeUiData> data = this.OpenParam as List<ISurvivorsAttributeUiData>;
		this.AttrScrollList = new GenericScrollViewNew<SurvivorsRoleAttributeItem, ISurvivorsAttributeUiData>(base.GetScrollViewWithScrollbar(1), new Func<SurvivorsRoleAttributeItem>(this.InitAttrItem), null, false, null);
		this.AttrScrollList.RefreshByData(data, null, false);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.AttributeComponentEvent, true);
	}

	// Token: 0x0601614E RID: 90446 RVA: 0x00620822 File Offset: 0x0061EA22
	protected override void OnBeforeDestroy()
	{
		this.CaptionItem.Destroy(null);
		if (this.AttrScrollList != null)
		{
			this.AttrScrollList = null;
		}
	}

	// Token: 0x0601614F RID: 90447 RVA: 0x0062083F File Offset: 0x0061EA3F
	private SurvivorsRoleAttributeItem InitAttrItem()
	{
		return new SurvivorsRoleAttributeItem();
	}

	// Token: 0x06016150 RID: 90448 RVA: 0x00620846 File Offset: 0x0061EA46
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400AA07 RID: 43527
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400AA08 RID: 43528
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<SurvivorsRoleAttributeItem, ISurvivorsAttributeUiData> AttrScrollList;
}
