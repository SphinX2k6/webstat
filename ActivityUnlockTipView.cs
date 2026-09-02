using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001733 RID: 5939
[NullableContext(1)]
[Nullable(0)]
public class ActivityUnlockTipView : UiViewBase
{
	// Token: 0x0600A59F RID: 42399 RVA: 0x002BC76E File Offset: 0x002BA96E
	public ActivityUnlockTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x17000DC6 RID: 3526
	// (get) Token: 0x0600A5A0 RID: 42400 RVA: 0x002BC777 File Offset: 0x002BA977
	// (set) Token: 0x0600A5A1 RID: 42401 RVA: 0x002BC77F File Offset: 0x002BA97F
	protected ActivityBaseData ActivityBaseData { get; set; }

	// Token: 0x0600A5A2 RID: 42402 RVA: 0x002BC788 File Offset: 0x002BA988
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A5A3 RID: 42403 RVA: 0x002BC7D0 File Offset: 0x002BA9D0
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A5A4 RID: 42404 RVA: 0x002BC7D9 File Offset: 0x002BA9D9
	protected override void OnStart()
	{
		this.ActivityBaseData = (this.OpenParam as ActivityBaseData);
		this.Refresh();
	}

	// Token: 0x0600A5A5 RID: 42405 RVA: 0x002BC7F4 File Offset: 0x002BA9F4
	protected void Refresh()
	{
		this.SetTitle(this.ActivityBaseData.LocalConfig.Value.Title);
	}

	// Token: 0x0600A5A6 RID: 42406 RVA: 0x002BC81F File Offset: 0x002BAA1F
	protected void SetTitle(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
	}

	// Token: 0x02007A7F RID: 31359
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x04029F80 RID: 171904
		public const int Title = 0;
	}
}
