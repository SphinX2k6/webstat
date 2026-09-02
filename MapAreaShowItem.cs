using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B91 RID: 7057
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MapAreaShowItem : GridProxyAbstract<ExploreAreaData>
{
	// Token: 0x0600CD25 RID: 52517 RVA: 0x00369BB4 File Offset: 0x00367DB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnRoot));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CD26 RID: 52518 RVA: 0x00369CC0 File Offset: 0x00367EC0
	protected override UniTask OnBeforeStartAsync()
	{
		MapAreaShowItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MapAreaShowItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD27 RID: 52519 RVA: 0x00369D03 File Offset: 0x00367F03
	protected override void OnStart()
	{
	}

	// Token: 0x0600CD28 RID: 52520 RVA: 0x00369D08 File Offset: 0x00367F08
	public override void Refresh(ExploreAreaData data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(2);
		this.AreaData = data;
		base.GetText(3).ShowTextNew(data.GetNameId());
		UUIText uuitext = text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetProgress());
		defaultInterpolatedStringHandler.AppendLiteral("%");
		uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIItem uuiitem = text;
		bool isReachMaxProgress = data.IsReachMaxProgress;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(isReachMaxProgress, fcolor);
		this.UpdateRedDot();
		MapAreaOnlyShowItem showItem = this.ShowItem;
		if (showItem != null)
		{
			showItem.Refresh(data.GetIconPercentDataAreaShow(), new int?(gridIndex));
		}
		data.SaveLocalIconPercentAreaShow();
	}

	// Token: 0x0600CD29 RID: 52521 RVA: 0x00369DAC File Offset: 0x00367FAC
	private void UpdateRedDot()
	{
		bool uiactive = this.AreaData.HasCanTakeStageReward();
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600CD2A RID: 52522 RVA: 0x00369DD7 File Offset: 0x00367FD7
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0600CD2B RID: 52523 RVA: 0x00369DD9 File Offset: 0x00367FD9
	private void OnClickBtnRoot()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.MapAreaShowClickArea, this.AreaData.AreaId);
	}

	// Token: 0x0400620C RID: 25100
	private ExploreAreaData AreaData;

	// Token: 0x0400620D RID: 25101
	private MapAreaOnlyShowItem ShowItem;

	// Token: 0x02007E72 RID: 32370
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B12B RID: 176427
		BtnRoot,
		// Token: 0x0402B12C RID: 176428
		ItemShow,
		// Token: 0x0402B12D RID: 176429
		UnlockPercent,
		// Token: 0x0402B12E RID: 176430
		TitleText,
		// Token: 0x0402B12F RID: 176431
		ItemRedDot
	}
}
