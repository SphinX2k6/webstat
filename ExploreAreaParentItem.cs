using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B83 RID: 7043
[NullableContext(2)]
[Nullable(0)]
public class ExploreAreaParentItem : UiPanelBase, IDynamicScrollItem<ExploreAreaViewData>
{
	// Token: 0x17001084 RID: 4228
	// (get) Token: 0x0600CC94 RID: 52372 RVA: 0x00367534 File Offset: 0x00365734
	// (set) Token: 0x0600CC95 RID: 52373 RVA: 0x0036753C File Offset: 0x0036573C
	public ExploreAreaViewData Data { get; private set; }

	// Token: 0x17001085 RID: 4229
	// (get) Token: 0x0600CC96 RID: 52374 RVA: 0x00367545 File Offset: 0x00365745
	// (set) Token: 0x0600CC97 RID: 52375 RVA: 0x0036754D File Offset: 0x0036574D
	public ExploreAreaItem ExploreAreaItem { get; private set; }

	// Token: 0x0600CC98 RID: 52376 RVA: 0x00367558 File Offset: 0x00365758
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

	// Token: 0x0600CC99 RID: 52377 RVA: 0x003675C1 File Offset: 0x003657C1
	[NullableContext(1)]
	public AUIBaseActor GetUsingItem(ExploreAreaViewData data)
	{
		if (data.IsCountry)
		{
			return base.GetItem(0).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(1).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600CC9A RID: 52378 RVA: 0x003675F0 File Offset: 0x003657F0
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		ExploreAreaParentItem.<Init>d__14 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ExploreAreaParentItem.<Init>d__14>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600CC9B RID: 52379 RVA: 0x0036763B File Offset: 0x0036583B
	protected override void OnStart()
	{
		this.ExploreCountryItem = new ExploreCountryItem();
		this.ExploreCountryItem.Initialize(base.GetItem(0));
		this.ExploreAreaItem = new ExploreAreaItem();
		this.ExploreAreaItem.Initialize(base.GetItem(1));
	}

	// Token: 0x0600CC9C RID: 52380 RVA: 0x00367677 File Offset: 0x00365877
	[NullableContext(1)]
	private void OnCountrySelected(ExploreCountryItem exploreCountryItem, ExploreAreaViewData data, EToggleState state)
	{
		Action<ExploreCountryItem, ExploreAreaViewData, EToggleState> onCountrySelectedCallback = this.OnCountrySelectedCallback;
		if (onCountrySelectedCallback == null)
		{
			return;
		}
		onCountrySelectedCallback(exploreCountryItem, data, state);
	}

	// Token: 0x0600CC9D RID: 52381 RVA: 0x0036768C File Offset: 0x0036588C
	[NullableContext(1)]
	private void OnAreaSelected(ExploreAreaItem exploreAreaItem, ExploreAreaViewData data, bool bSelected)
	{
		Action<ExploreAreaItem, ExploreAreaViewData, bool> onAreaSelectedCallback = this.OnAreaSelectedCallback;
		if (onAreaSelectedCallback == null)
		{
			return;
		}
		onAreaSelectedCallback(exploreAreaItem, data, bSelected);
	}

	// Token: 0x0600CC9E RID: 52382 RVA: 0x003676A4 File Offset: 0x003658A4
	[NullableContext(1)]
	public void Update(ExploreAreaViewData data, int index)
	{
		this.Data = data;
		bool isCountry = data.IsCountry;
		if (isCountry)
		{
			this.ExploreCountryItem.BindOnSelected(new Action<ExploreCountryItem, ExploreAreaViewData, EToggleState>(this.OnCountrySelected));
			this.ExploreCountryItem.BindCanExecuteChange(new Func<bool>(this.OnCountryItemCanExecuteChange));
			this.ExploreCountryItem.Refresh(data);
		}
		else
		{
			this.ExploreAreaItem.BindOnSelected(new Action<ExploreAreaItem, ExploreAreaViewData, bool>(this.OnAreaSelected));
			this.ExploreAreaItem.BindCanExecuteChange(new Func<bool>(this.OnAreaItemCanExecuteChange));
			this.ExploreAreaItem.Refresh(data);
		}
		this.ExploreCountryItem.SetActive(isCountry);
		this.ExploreAreaItem.SetActive(!isCountry);
	}

	// Token: 0x0600CC9F RID: 52383 RVA: 0x00367753 File Offset: 0x00365953
	private bool OnCountryItemCanExecuteChange()
	{
		return true;
	}

	// Token: 0x0600CCA0 RID: 52384 RVA: 0x00367756 File Offset: 0x00365956
	private bool OnAreaItemCanExecuteChange()
	{
		return true;
	}

	// Token: 0x0600CCA1 RID: 52385 RVA: 0x00367759 File Offset: 0x00365959
	[NullableContext(1)]
	public void BindOnCountrySelected(Action<ExploreCountryItem, ExploreAreaViewData, EToggleState> onSelectedCallback)
	{
		this.OnCountrySelectedCallback = onSelectedCallback;
	}

	// Token: 0x0600CCA2 RID: 52386 RVA: 0x00367762 File Offset: 0x00365962
	[NullableContext(1)]
	public void BindOnAreaSelected(Action<ExploreAreaItem, ExploreAreaViewData, bool> onSelectedCallback)
	{
		this.OnAreaSelectedCallback = onSelectedCallback;
	}

	// Token: 0x0600CCA3 RID: 52387 RVA: 0x0036776B File Offset: 0x0036596B
	public void ClearItem()
	{
		this.Data = null;
		ExploreCountryItem exploreCountryItem = this.ExploreCountryItem;
		if (exploreCountryItem != null)
		{
			exploreCountryItem.Destroy(null);
		}
		this.ExploreCountryItem = null;
		ExploreAreaItem exploreAreaItem = this.ExploreAreaItem;
		if (exploreAreaItem != null)
		{
			exploreAreaItem.Destroy(null);
		}
		this.ExploreAreaItem = null;
	}

	// Token: 0x040061D3 RID: 25043
	private ExploreCountryItem ExploreCountryItem;

	// Token: 0x040061D5 RID: 25045
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<ExploreCountryItem, ExploreAreaViewData, EToggleState> OnCountrySelectedCallback;

	// Token: 0x040061D6 RID: 25046
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<ExploreAreaItem, ExploreAreaViewData, bool> OnAreaSelectedCallback;

	// Token: 0x02007E63 RID: 32355
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B0D8 RID: 176344
		CountryItem,
		// Token: 0x0402B0D9 RID: 176345
		AreaItem
	}
}
