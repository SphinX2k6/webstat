using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FEB RID: 8171
[NullableContext(1)]
[Nullable(0)]
public class InfluenceSearchView : UiViewBase
{
	// Token: 0x0600F6AB RID: 63147 RVA: 0x00438962 File Offset: 0x00436B62
	public InfluenceSearchView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F6AC RID: 63148 RVA: 0x00438978 File Offset: 0x00436B78
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.RefreshClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.CloseClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F6AD RID: 63149 RVA: 0x00438AA4 File Offset: 0x00436CA4
	private void RefreshClick()
	{
		base.GetInputText(0).SetText("", true);
	}

	// Token: 0x0600F6AE RID: 63150 RVA: 0x00438AB8 File Offset: 0x00436CB8
	private void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F6AF RID: 63151 RVA: 0x00438AC1 File Offset: 0x00436CC1
	protected override void OnBeforeCreate()
	{
		this.CurrentCountryId = (int)this.OpenParam;
	}

	// Token: 0x0600F6B0 RID: 63152 RVA: 0x00438AD4 File Offset: 0x00436CD4
	protected override void OnStart()
	{
		this.ScrollView = new GenericScrollView<InfluenceSearchGrid>(base.GetScrollViewWithScrollbar(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<InfluenceSearchGrid>(this.InitItem), null);
		base.GetInputText(0).OnTextChange.Bind(new Action<string>(this.InputTextChange));
	}

	// Token: 0x0600F6B1 RID: 63153 RVA: 0x00438B12 File Offset: 0x00436D12
	protected override void OnAfterShow()
	{
		this.RefreshSearchResult();
	}

	// Token: 0x0600F6B2 RID: 63154 RVA: 0x00438B1C File Offset: 0x00436D1C
	protected void RefreshSearchResult()
	{
		int[] array;
		if (string.IsNullOrEmpty(this.InputText))
		{
			array = new int[]
			{
				this.CurrentCountryId
			};
		}
		else
		{
			array = ModelBase<InfluenceReputationModel>.Instance.GetUnLockCountry();
			Array.Sort<int>(array, delegate(int aCountryId, int bCountryId)
			{
				if (aCountryId == this.CurrentCountryId)
				{
					return -1;
				}
				if (bCountryId == this.CurrentCountryId)
				{
					return 1;
				}
				return aCountryId - bCountryId;
			});
		}
		InfluenceSearchData influenceSearchData = ModelBase<InfluenceReputationModel>.Instance.FilterUnLockInfluenceList(array, this.InputText);
		bool hasResult = influenceSearchData.HasResult;
		base.GetItem(3).SetUIActive(!hasResult);
		this.ScrollView.SetActive(hasResult);
		if (hasResult)
		{
			this.ScrollView.RefreshByData<ValueTuple<int, List<int>>>(influenceSearchData.InfluenceList, null);
		}
	}

	// Token: 0x0600F6B3 RID: 63155 RVA: 0x00438BB8 File Offset: 0x00436DB8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private ILayoutItem<InfluenceSearchGrid> InitItem(object tempData, UUIItem uiItem, int index)
	{
		ValueTuple<int, int[]> valueTuple = (ValueTuple<int, int[]>)tempData;
		if (this.CurrentCountryId == valueTuple.Item1)
		{
			InfluenceSearchGrid influenceSearchGrid = new InfluenceSearchGrid(uiItem);
			influenceSearchGrid.UpdateGrid(valueTuple.Item1, valueTuple.Item2);
			return new LayoutItem<InfluenceSearchGrid>
			{
				Key = index,
				Value = influenceSearchGrid
			};
		}
		if (valueTuple.Item2.Length == 0)
		{
			uiItem.SetUIActive(false);
			return null;
		}
		InfluenceSearchGrid influenceSearchGrid2 = new InfluenceSearchGrid(uiItem);
		influenceSearchGrid2.UpdateGrid(valueTuple.Item1, valueTuple.Item2);
		return new LayoutItem<InfluenceSearchGrid>
		{
			Key = index,
			Value = influenceSearchGrid2
		};
	}

	// Token: 0x0600F6B4 RID: 63156 RVA: 0x00438C52 File Offset: 0x00436E52
	private void InputTextChange(string inString)
	{
		this.InputText = inString;
		this.RefreshSearchResult();
	}

	// Token: 0x0600F6B5 RID: 63157 RVA: 0x00438C61 File Offset: 0x00436E61
	protected override void OnBeforeDestroy()
	{
		this.ScrollView.ClearChildren();
		this.ScrollView = null;
	}

	// Token: 0x0400772E RID: 30510
	protected int CurrentCountryId;

	// Token: 0x0400772F RID: 30511
	private string InputText = "";

	// Token: 0x04007730 RID: 30512
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<InfluenceSearchGrid> ScrollView;

	// Token: 0x02008369 RID: 33641
	[NullableContext(0)]
	private enum EInfluenceSearchView
	{
		// Token: 0x0402C92A RID: 182570
		InputText,
		// Token: 0x0402C92B RID: 182571
		RefreshButton,
		// Token: 0x0402C92C RID: 182572
		ScrollView,
		// Token: 0x0402C92D RID: 182573
		NoSearchText,
		// Token: 0x0402C92E RID: 182574
		MaskButton
	}
}
