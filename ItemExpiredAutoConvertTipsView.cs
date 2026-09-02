using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200202F RID: 8239
[NullableContext(2)]
[Nullable(0)]
public class ItemExpiredAutoConvertTipsView : UiViewBase
{
	// Token: 0x0600FAFD RID: 64253 RVA: 0x0044E77C File Offset: 0x0044C97C
	[NullableContext(1)]
	public ItemExpiredAutoConvertTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FAFE RID: 64254 RVA: 0x0044E788 File Offset: 0x0044C988
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600FAFF RID: 64255 RVA: 0x0044E854 File Offset: 0x0044CA54
	protected override UniTask OnBeforeStartAsync()
	{
		ItemExpiredAutoConvertTipsView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemExpiredAutoConvertTipsView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FB00 RID: 64256 RVA: 0x0044E898 File Offset: 0x0044CA98
	protected override void OnBeforeShow()
	{
		this.CancelButton.SetActive(this.Data.OnCancelCallBack != null);
		this.BeforeConvertShowItem.Refresh(this.Data.BeforeTitleText, this.Data.BeforeItemList);
		this.AfterConvertShowItem.Refresh(this.Data.AfterTitleText, this.Data.AfterItemList);
		base.GetText(0).ShowTextNew(this.Data.TitleText);
	}

	// Token: 0x04007885 RID: 30853
	private ItemExpiredAutoConvertTipsViewDefine Data;

	// Token: 0x04007886 RID: 30854
	private ButtonItem CancelButton;

	// Token: 0x04007887 RID: 30855
	private ButtonItem ConfirmButton;

	// Token: 0x04007888 RID: 30856
	private ConvertShowItem BeforeConvertShowItem;

	// Token: 0x04007889 RID: 30857
	private ConvertShowItem AfterConvertShowItem;
}
