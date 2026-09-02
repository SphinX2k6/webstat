using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001813 RID: 6163
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineAttributePanel : UiPanelBase
{
	// Token: 0x0600AF6E RID: 44910 RVA: 0x002EBF70 File Offset: 0x002EA170
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickMainNew))
		};
	}

	// Token: 0x0600AF6F RID: 44911 RVA: 0x002EC01C File Offset: 0x002EA21C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineAttributePanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineAttributePanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF70 RID: 44912 RVA: 0x002EC060 File Offset: 0x002EA260
	[NullableContext(1)]
	public void RefreshItemNow(AttrListScrollData[] dataList)
	{
		if (dataList.Length < 2)
		{
			Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.WDX, "声骸属性少于2", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		AttrListScrollData attributeData = dataList[0];
		AttrListScrollData attributeData2 = dataList[1];
		this.ItemMainNow.RefreshUi(attributeData);
		this.ItemSubNow.RefreshUi(attributeData2);
		this.ItemSubNew.RefreshUi(attributeData2);
	}

	// Token: 0x0600AF71 RID: 44913 RVA: 0x002EC0BF File Offset: 0x002EA2BF
	public void RefreshItemSwitch(IRefineAttrItemData data)
	{
		this.ItemMainNew.RefreshUi(data);
	}

	// Token: 0x0600AF72 RID: 44914 RVA: 0x002EC0CD File Offset: 0x002EA2CD
	[NullableContext(1)]
	public void BindClickCallBack(Action callback)
	{
		this.OnClickCallBack = callback;
	}

	// Token: 0x0600AF73 RID: 44915 RVA: 0x002EC0D6 File Offset: 0x002EA2D6
	private void OnClickMainNew()
	{
		if (this.OnClickCallBack != null)
		{
			this.OnClickCallBack();
		}
	}

	// Token: 0x0400532F RID: 21295
	private PhantomTipsAttributeItem ItemMainNow;

	// Token: 0x04005330 RID: 21296
	private PhantomTipsAttributeItem ItemSubNow;

	// Token: 0x04005331 RID: 21297
	private PhantomTipsAttributeItem ItemSubNew;

	// Token: 0x04005332 RID: 21298
	private AttributeSelectItem ItemMainNew;

	// Token: 0x04005333 RID: 21299
	private Action OnClickCallBack;

	// Token: 0x02007B94 RID: 31636
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A3D2 RID: 173010
		TextTips,
		// Token: 0x0402A3D3 RID: 173011
		ItemMainNow,
		// Token: 0x0402A3D4 RID: 173012
		ItemMainNew,
		// Token: 0x0402A3D5 RID: 173013
		ItemSubNow,
		// Token: 0x0402A3D6 RID: 173014
		ItemSubNew
	}
}
