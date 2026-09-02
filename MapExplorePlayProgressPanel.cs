using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B99 RID: 7065
[NullableContext(1)]
[Nullable(0)]
public class MapExplorePlayProgressPanel : UiPanelBase
{
	// Token: 0x0600CD94 RID: 52628 RVA: 0x0036C3B0 File Offset: 0x0036A5B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CD95 RID: 52629 RVA: 0x0036C41C File Offset: 0x0036A61C
	public UniTask Init(UUIItem item)
	{
		MapExplorePlayProgressPanel.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<MapExplorePlayProgressPanel.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD96 RID: 52630 RVA: 0x0036C467 File Offset: 0x0036A667
	protected override void OnBeforeShow()
	{
		this.PlayLayout = new GenericLayout<MapExplorePlayProgressItem, IExplorePlayProgressItemData>(base.GetHorizontalLayout(0), () => new MapExplorePlayProgressItem(), null, false, true);
	}

	// Token: 0x0600CD97 RID: 52631 RVA: 0x0036C4A0 File Offset: 0x0036A6A0
	public void UpdateData(List<IExplorePlayProgressItemData> data, [Nullable(2)] Action finishCallback = null)
	{
		GenericLayout<MapExplorePlayProgressItem, IExplorePlayProgressItemData> playLayout = this.PlayLayout;
		if (playLayout == null)
		{
			return;
		}
		playLayout.RefreshByData(data, delegate
		{
			Action finishCallback2 = finishCallback;
			if (finishCallback2 == null)
			{
				return;
			}
			finishCallback2();
		}, false);
	}

	// Token: 0x0600CD98 RID: 52632 RVA: 0x0036C4D8 File Offset: 0x0036A6D8
	public void CheckPlayStateChanged()
	{
		GenericLayout<MapExplorePlayProgressItem, IExplorePlayProgressItemData> playLayout = this.PlayLayout;
		List<MapExplorePlayProgressItem> list = (playLayout != null) ? playLayout.GetLayoutItemList() : null;
		if (list == null)
		{
			return;
		}
		foreach (MapExplorePlayProgressItem mapExplorePlayProgressItem in list)
		{
			mapExplorePlayProgressItem.CheckPlayStateChanged();
		}
	}

	// Token: 0x0400622B RID: 25131
	private GenericLayout<MapExplorePlayProgressItem, IExplorePlayProgressItemData> PlayLayout;

	// Token: 0x02007E83 RID: 32387
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B199 RID: 176537
		RootLayout,
		// Token: 0x0402B19A RID: 176538
		PlayPointItem
	}
}
