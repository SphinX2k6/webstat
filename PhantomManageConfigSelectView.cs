using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002039 RID: 8249
[NullableContext(1)]
[Nullable(0)]
public class PhantomManageConfigSelectView : UiViewBase
{
	// Token: 0x0600FB4D RID: 64333 RVA: 0x0044FF8F File Offset: 0x0044E18F
	public PhantomManageConfigSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FB4E RID: 64334 RVA: 0x0044FF98 File Offset: 0x0044E198
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedClear));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FB4F RID: 64335 RVA: 0x00450082 File Offset: 0x0044E282
	protected override void OnBeforeCreate()
	{
		this.ViewData = (this.OpenParam as InventoryDefine.ISelectViewData);
	}

	// Token: 0x0600FB50 RID: 64336 RVA: 0x00450098 File Offset: 0x0044E298
	protected override UniTask OnCreateAsync()
	{
		PhantomManageConfigSelectView.<OnCreateAsync>d__7 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<PhantomManageConfigSelectView.<OnCreateAsync>d__7>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FB51 RID: 64337 RVA: 0x004500DC File Offset: 0x0044E2DC
	protected override void OnStart()
	{
		this.ItemGrid.SetUIParent(base.GetScrollViewWithScrollbar(0).ContentUIItem, false);
		this.Scroll = new GenericScrollViewNew<SelectGroup, InventoryDefine.ISelectGroupData>(base.GetScrollViewWithScrollbar(0), new Func<SelectGroup>(this.InitSelectGroup), this.ItemGrid.GetOwner() as AUIBaseActor, false, null);
		InventoryDefine.ISelectGroupData[] source = this.ConvertData();
		this.Scroll.RefreshByData(source.ToList<InventoryDefine.ISelectGroupData>(), null, false);
	}

	// Token: 0x0600FB52 RID: 64338 RVA: 0x00450150 File Offset: 0x0044E350
	private InventoryDefine.ISelectGroupData[] ConvertData()
	{
		InventoryDefine.ISelectViewData viewData = this.ViewData;
		int[] ruleIdList = viewData.RuleIdList;
		int filterId = viewData.FilterId;
		bool isSupportSelectAll = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterId).Value.IsSupportSelectAll;
		List<InventoryDefine.ISelectGroupData> list = new List<InventoryDefine.ISelectGroupData>();
		foreach (int num in ruleIdList)
		{
			FilterRule? filterRuleConfig = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(num);
			int[] array2;
			int[] valueList;
			if (viewData.ValueMap.TryGetValue(num, out array2))
			{
				valueList = array2;
			}
			else
			{
				valueList = Array.Empty<int>();
			}
			InventoryDefine.SelectGroupData item = new InventoryDefine.SelectGroupData
			{
				FilterId = filterId,
				FilterRuleId = num,
				HasSelectAll = isSupportSelectAll,
				NeedChangeColor = filterRuleConfig.Value.NeedChangeColor,
				ValueList = valueList
			};
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600FB53 RID: 64339 RVA: 0x0045022F File Offset: 0x0044E42F
	private SelectGroup InitSelectGroup()
	{
		return new SelectGroup();
	}

	// Token: 0x0600FB54 RID: 64340 RVA: 0x00450238 File Offset: 0x0044E438
	private Dictionary<int, int[]> GetAllSelectData()
	{
		List<SelectGroup> scrollItemList = this.Scroll.GetScrollItemList();
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		foreach (SelectGroup selectGroup in scrollItemList)
		{
			int ruleId = selectGroup.GetRuleId();
			int[] selectValueList = selectGroup.GetSelectValueList();
			dictionary.Add(ruleId, selectValueList);
		}
		return dictionary;
	}

	// Token: 0x0600FB55 RID: 64341 RVA: 0x004502A4 File Offset: 0x0044E4A4
	private void OnClickedClear()
	{
		foreach (SelectGroup selectGroup in this.Scroll.GetScrollItemList())
		{
			selectGroup.ResetSelect();
		}
	}

	// Token: 0x0600FB56 RID: 64342 RVA: 0x004502FC File Offset: 0x0044E4FC
	private void OnClickedConfirm()
	{
		Dictionary<int, int[]> allSelectData = this.GetAllSelectData();
		this.ViewData.CallbackConfirm(allSelectData);
		base.CloseMe(null);
	}

	// Token: 0x040078AE RID: 30894
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericScrollViewNew<SelectGroup, InventoryDefine.ISelectGroupData> Scroll;

	// Token: 0x040078AF RID: 30895
	[Nullable(2)]
	private InventoryDefine.ISelectViewData ViewData;

	// Token: 0x040078B0 RID: 30896
	[Nullable(2)]
	private UUIItem ItemGrid;

	// Token: 0x020083E4 RID: 33764
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402CB64 RID: 183140
		Scroll,
		// Token: 0x0402CB65 RID: 183141
		ClearButton,
		// Token: 0x0402CB66 RID: 183142
		ConfirmButton
	}
}
