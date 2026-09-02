using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001543 RID: 5443
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressMainCaptionListPanel : UiPanelBase
{
	// Token: 0x060098B3 RID: 39091 RVA: 0x0028011E File Offset: 0x0027E31E
	public void Init(CommonTabComponentData<ActivityRegressTabItemPanel> data)
	{
		this.TabComponentData = data;
	}

	// Token: 0x060098B4 RID: 39092 RVA: 0x00280128 File Offset: 0x0027E328
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060098B5 RID: 39093 RVA: 0x002801B4 File Offset: 0x0027E3B4
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressMainCaptionListPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressMainCaptionListPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060098B6 RID: 39094 RVA: 0x002801F7 File Offset: 0x0027E3F7
	public void BindTabTitleCallBack(Action callBack)
	{
		this.TabTitle.OnBackBtnCallBack = callBack;
	}

	// Token: 0x060098B7 RID: 39095 RVA: 0x00280208 File Offset: 0x0027E408
	protected override void OnStart()
	{
		base.OnStart();
		this.ScrollView = base.GetScrollViewWithScrollbar(1);
		this.TabComponent = new TabComponent<ActivityRegressTabItemPanel>(this.ScrollView.Content.Get().GetUIItem(), new Func<UUIItem, int?, ActivityRegressTabItemPanel>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), null);
	}

	// Token: 0x060098B8 RID: 39096 RVA: 0x00280264 File Offset: 0x0027E464
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.TabTitle != null)
		{
			this.TabTitle.Destroy(null);
			this.TabTitle = null;
		}
	}

	// Token: 0x060098B9 RID: 39097 RVA: 0x002802A4 File Offset: 0x0027E4A4
	private void ToggleCallBack(int index)
	{
		CommonTabData commonTabData = this.TabComponentData.GetCommonData(index);
		if (commonTabData != null)
		{
			this.TabTitle.UpdateIcon(commonTabData.GetSmallIcon());
			this.TabTitle.UpdateTitle(commonTabData.GetTitleData());
		}
		this.TabComponentData.ToggleCallBack(index);
	}

	// Token: 0x060098BA RID: 39098 RVA: 0x002802F9 File Offset: 0x0027E4F9
	private ActivityRegressTabItemPanel ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return this.TabComponentData.ProxyCreate(uiItem, new int?(index.GetValueOrDefault()));
	}

	// Token: 0x060098BB RID: 39099 RVA: 0x00280318 File Offset: 0x0027E518
	public UniTask RefreshTabItemByDataAsync(List<CommonTabItemData> array)
	{
		ActivityRegressMainCaptionListPanel.<RefreshTabItemByDataAsync>d__13 <RefreshTabItemByDataAsync>d__;
		<RefreshTabItemByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabItemByDataAsync>d__.<>4__this = this;
		<RefreshTabItemByDataAsync>d__.array = array;
		<RefreshTabItemByDataAsync>d__.<>1__state = -1;
		<RefreshTabItemByDataAsync>d__.<>t__builder.Start<ActivityRegressMainCaptionListPanel.<RefreshTabItemByDataAsync>d__13>(ref <RefreshTabItemByDataAsync>d__);
		return <RefreshTabItemByDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060098BC RID: 39100 RVA: 0x00280363 File Offset: 0x0027E563
	public void SelectToggleByIndex(int index, bool bIgnored = false, bool bFire = true)
	{
		this.TabComponent.SelectToggleByIndex(index, bIgnored, bFire);
	}

	// Token: 0x060098BD RID: 39101 RVA: 0x00280373 File Offset: 0x0027E573
	public Dictionary<int, ActivityRegressTabItemPanel> GetTabItemMap()
	{
		return this.TabComponent.GetTabItemMap();
	}

	// Token: 0x060098BE RID: 39102 RVA: 0x00280380 File Offset: 0x0027E580
	[NullableContext(2)]
	public CommonTabData GetTabComponentData(int index)
	{
		return this.TabComponentData.GetCommonData(index);
	}

	// Token: 0x060098BF RID: 39103 RVA: 0x00280393 File Offset: 0x0027E593
	public void SetPnlListUiActive(bool bActive)
	{
		base.GetItem(2).SetUIActive(bActive);
	}

	// Token: 0x060098C0 RID: 39104 RVA: 0x002803A2 File Offset: 0x0027E5A2
	public void UpdateTitle([Nullable(2)] string iconPath, CommonTabTitleData title)
	{
		if (!string.IsNullOrEmpty(iconPath))
		{
			this.TabTitle.UpdateIcon(iconPath);
		}
		if (title != null)
		{
			this.TabTitle.UpdateTitle(title);
		}
	}

	// Token: 0x060098C1 RID: 39105 RVA: 0x002803C7 File Offset: 0x0027E5C7
	public void BindCanExecuteChange(Func<int, bool?, bool> canChange)
	{
		this.TabComponent.SetCanChange(canChange);
	}

	// Token: 0x040046A1 RID: 18081
	[Nullable(2)]
	protected ActivityRegressMainTabTitlePanel TabTitle;

	// Token: 0x040046A2 RID: 18082
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonTabComponentData<ActivityRegressTabItemPanel> TabComponentData;

	// Token: 0x040046A3 RID: 18083
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<ActivityRegressTabItemPanel> TabComponent;

	// Token: 0x040046A4 RID: 18084
	[Nullable(2)]
	private UUIScrollViewWithScrollbarComponent ScrollView;

	// Token: 0x020078FD RID: 30973
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029956 RID: 170326
		public const int PnlCaption = 0;

		// Token: 0x04029957 RID: 170327
		public const int SvList = 1;

		// Token: 0x04029958 RID: 170328
		public const int PnlList = 2;
	}
}
