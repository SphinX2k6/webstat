using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002084 RID: 8324
[NullableContext(2)]
[Nullable(0)]
public class ItemConvertTipsView : UiViewBase
{
	// Token: 0x0600FD8B RID: 64907 RVA: 0x00458A6C File Offset: 0x00456C6C
	[NullableContext(1)]
	public ItemConvertTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FD8C RID: 64908 RVA: 0x00458A78 File Offset: 0x00456C78
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

	// Token: 0x0600FD8D RID: 64909 RVA: 0x00458B44 File Offset: 0x00456D44
	private void OnCancelButtonClick(int _)
	{
		this.Param.OnCancelCallBack();
		base.CloseMe(null);
	}

	// Token: 0x0600FD8E RID: 64910 RVA: 0x00458B5D File Offset: 0x00456D5D
	private void OnConfirmButtonClick(int _)
	{
		this.Param.OnConfirmCallBack();
		base.CloseMe(null);
	}

	// Token: 0x0600FD8F RID: 64911 RVA: 0x00458B78 File Offset: 0x00456D78
	protected override UniTask OnBeforeStartAsync()
	{
		ItemConvertTipsView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemConvertTipsView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FD90 RID: 64912 RVA: 0x00458BBB File Offset: 0x00456DBB
	protected override void OnBeforeShow()
	{
		this.Refresh(this.Param);
	}

	// Token: 0x0600FD91 RID: 64913 RVA: 0x00458BCC File Offset: 0x00456DCC
	[NullableContext(1)]
	public void Refresh(ItemConvertTipsParam param)
	{
		this.BeforeItem.Refresh(param.BeforeItemData.Value);
		this.AfterItem.Refresh(param.AfterItemData.Value);
		base.GetText(0).SetText(param.ShowText, true);
	}

	// Token: 0x040079AE RID: 31150
	private ItemConvertTipsParam Param;

	// Token: 0x040079AF RID: 31151
	private CommonItemSmallItemGrid BeforeItem;

	// Token: 0x040079B0 RID: 31152
	private CommonItemSmallItemGrid AfterItem;

	// Token: 0x040079B1 RID: 31153
	private ButtonItem CancelButton;

	// Token: 0x040079B2 RID: 31154
	private ButtonItem ConfirmButton;
}
