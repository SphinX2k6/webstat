using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001810 RID: 6160
[NullableContext(1)]
[Nullable(0)]
public class AttributeSelectPanel : UiPanelBase
{
	// Token: 0x0600AF56 RID: 44886 RVA: 0x002EBAC4 File Offset: 0x002E9CC4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x0600AF57 RID: 44887 RVA: 0x002EBB20 File Offset: 0x002E9D20
	protected override void OnStart()
	{
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), "VisionRefineAttributeSelect", Array.Empty<object>());
		this.Layout = new GenericLayout<AttributeSelectGrid, IRefineAttrItemData>(base.GetGridLayout(0), new Func<AttributeSelectGrid>(this.InitAttributeItem), base.GetItem(1).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600AF58 RID: 44888 RVA: 0x002EBB79 File Offset: 0x002E9D79
	private AttributeSelectGrid InitAttributeItem()
	{
		return new AttributeSelectGrid
		{
			OnClickToggleCallBack = new Action<IRefineAttrItemData, int>(this.OnClickAttributeItem)
		};
	}

	// Token: 0x0600AF59 RID: 44889 RVA: 0x002EBB92 File Offset: 0x002E9D92
	public void RefreshByData(IRefineAttrItemData[] dataList, int? chosenIndex = null)
	{
		this.RefreshByDataAsync(dataList, chosenIndex).Forget();
	}

	// Token: 0x0600AF5A RID: 44890 RVA: 0x002EBBA4 File Offset: 0x002E9DA4
	private UniTask RefreshByDataAsync(IRefineAttrItemData[] dataList, int? chosenIndex = null)
	{
		AttributeSelectPanel.<RefreshByDataAsync>d__7 <RefreshByDataAsync>d__;
		<RefreshByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshByDataAsync>d__.<>4__this = this;
		<RefreshByDataAsync>d__.dataList = dataList;
		<RefreshByDataAsync>d__.chosenIndex = chosenIndex;
		<RefreshByDataAsync>d__.<>1__state = -1;
		<RefreshByDataAsync>d__.<>t__builder.Start<AttributeSelectPanel.<RefreshByDataAsync>d__7>(ref <RefreshByDataAsync>d__);
		return <RefreshByDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF5B RID: 44891 RVA: 0x002EBBF7 File Offset: 0x002E9DF7
	private void OnClickAttributeItem(IRefineAttrItemData data, int index)
	{
		if (this.CallBackClick != null)
		{
			this.CallBackClick(data);
		}
		this.Layout.DeselectCurrentGridProxy();
		this.Layout.SelectGridProxy(index, false);
	}

	// Token: 0x04005320 RID: 21280
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<AttributeSelectGrid, IRefineAttrItemData> Layout;

	// Token: 0x04005321 RID: 21281
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IRefineAttrItemData> CallBackClick;

	// Token: 0x02007B90 RID: 31632
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A3BD RID: 172989
		Layout,
		// Token: 0x0402A3BE RID: 172990
		LayoutItem,
		// Token: 0x0402A3BF RID: 172991
		TextTitle
	}
}
