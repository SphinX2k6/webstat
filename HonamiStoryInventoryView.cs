using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F20 RID: 7968
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryInventoryView : UiViewBase
{
	// Token: 0x0600EE66 RID: 61030 RVA: 0x00411C7C File Offset: 0x0040FE7C
	public HonamiStoryInventoryView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EE67 RID: 61031 RVA: 0x00411C88 File Offset: 0x0040FE88
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EE68 RID: 61032 RVA: 0x00411CF4 File Offset: 0x0040FEF4
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryInventoryView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryInventoryView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE69 RID: 61033 RVA: 0x00411D37 File Offset: 0x0040FF37
	protected override void OnBeforeShow()
	{
		TabComponentWithCaptionItem<CalabashTabItem> captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SelectToggleByIndex(0, true);
	}

	// Token: 0x0600EE6A RID: 61034 RVA: 0x00411D4C File Offset: 0x0040FF4C
	private UniTask InitCaption()
	{
		HonamiStoryInventoryView.<InitCaption>d__8 <InitCaption>d__;
		<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaption>d__.<>4__this = this;
		<InitCaption>d__.<>1__state = -1;
		<InitCaption>d__.<>t__builder.Start<HonamiStoryInventoryView.<InitCaption>d__8>(ref <InitCaption>d__);
		return <InitCaption>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE6B RID: 61035 RVA: 0x00411D8F File Offset: 0x0040FF8F
	private CalabashTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? _)
	{
		return new CalabashTabItem();
	}

	// Token: 0x0600EE6C RID: 61036 RVA: 0x00411D98 File Offset: 0x0040FF98
	private void ToggleCallBack(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		string childViewName = uiDynamicTab.ChildViewName;
		CalabashTabItem tabItemByIndex = this.CaptionItem.GetTabItemByIndex(index);
		this.TabViewComponent.ToggleCallBack(uiDynamicTab, (EUiTabViewName)childViewName, tabItemByIndex, null, null);
	}

	// Token: 0x0600EE6D RID: 61037 RVA: 0x00411DE9 File Offset: 0x0040FFE9
	private bool CheckTabViewCloseToRoot()
	{
		return false;
	}

	// Token: 0x0600EE6E RID: 61038 RVA: 0x00411DEC File Offset: 0x0040FFEC
	private void OnClickBtnClose()
	{
		if (this.CheckTabViewCloseToRoot())
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600EE6F RID: 61039 RVA: 0x00411E00 File Offset: 0x00410000
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = ModelBase<CalabashModel>.Instance.GetViewTabList()[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x04007267 RID: 29287
	private List<UiDynamicTab> TabDataList;

	// Token: 0x04007268 RID: 29288
	private TabComponentWithCaptionItem<CalabashTabItem> CaptionItem;

	// Token: 0x04007269 RID: 29289
	private TabViewComponent<object> TabViewComponent;

	// Token: 0x02008297 RID: 33431
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C4AE RID: 181422
		CaptionItem,
		// Token: 0x0402C4AF RID: 181423
		Content
	}
}
