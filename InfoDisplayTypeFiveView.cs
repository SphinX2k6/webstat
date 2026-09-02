using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002000 RID: 8192
public class InfoDisplayTypeFiveView : UiViewBase
{
	// Token: 0x0600F763 RID: 63331 RVA: 0x0043B9CA File Offset: 0x00439BCA
	[NullableContext(1)]
	public InfoDisplayTypeFiveView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F764 RID: 63332 RVA: 0x0043B9D4 File Offset: 0x00439BD4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCloseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F765 RID: 63333 RVA: 0x0043BA9C File Offset: 0x00439C9C
	protected override void OnStart()
	{
		InfoDisplay? config = ConfigInfoDisplayById.GetConfig(ModelBase<InfoDisplayModel>.Instance.CurrentInformationId(), true);
		if (config == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Value.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), config.Value.Text, Array.Empty<object>());
	}

	// Token: 0x0600F766 RID: 63334 RVA: 0x0043BB0E File Offset: 0x00439D0E
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x02008381 RID: 33665
	private class EComponentType
	{
		// Token: 0x0402C988 RID: 182664
		public const int TitleText = 0;

		// Token: 0x0402C989 RID: 182665
		public const int DescText = 1;

		// Token: 0x0402C98A RID: 182666
		public const int CloseButton = 2;
	}
}
