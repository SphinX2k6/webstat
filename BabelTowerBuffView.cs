using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011DB RID: 4571
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerBuffView : UiViewBase
{
	// Token: 0x060078A1 RID: 30881 RVA: 0x001F9B4C File Offset: 0x001F7D4C
	[NullableContext(1)]
	public BabelTowerBuffView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060078A2 RID: 30882 RVA: 0x001F9B5C File Offset: 0x001F7D5C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnBuffToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnDeTermToggleClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060078A3 RID: 30883 RVA: 0x001F9D30 File Offset: 0x001F7F30
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerBuffView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerBuffView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060078A4 RID: 30884 RVA: 0x001F9D73 File Offset: 0x001F7F73
	protected override void OnBeforeShow()
	{
		if (this.SelectedToggle == null)
		{
			this.SelectBuffTabToggle();
		}
	}

	// Token: 0x060078A5 RID: 30885 RVA: 0x001F9D83 File Offset: 0x001F7F83
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060078A6 RID: 30886 RVA: 0x001F9D8C File Offset: 0x001F7F8C
	[NullableContext(1)]
	private BabelTowerBuffItem CreateBuffItem()
	{
		return new BabelTowerBuffItem
		{
			OnToggleClick = new Action<int>(this.OnBuffItemClick)
		};
	}

	// Token: 0x060078A7 RID: 30887 RVA: 0x001F9DA5 File Offset: 0x001F7FA5
	private void OnBuffItemClick(int index)
	{
		this.SelectBuffItemByIndex(index);
	}

	// Token: 0x060078A8 RID: 30888 RVA: 0x001F9DAE File Offset: 0x001F7FAE
	private void OnBuffToggleClick(EToggleState state)
	{
		this.SelectBuffTabToggle();
	}

	// Token: 0x060078A9 RID: 30889 RVA: 0x001F9DB6 File Offset: 0x001F7FB6
	private void OnDeTermToggleClick(EToggleState state)
	{
		this.SelectDeTermTabToggle();
	}

	// Token: 0x060078AA RID: 30890 RVA: 0x001F9DBE File Offset: 0x001F7FBE
	private void SelectBuffTabToggle()
	{
		this.SelectTabToggle(base.GetExtendToggle(2));
		this.OnBuffToggleSelected();
	}

	// Token: 0x060078AB RID: 30891 RVA: 0x001F9DD3 File Offset: 0x001F7FD3
	private void SelectDeTermTabToggle()
	{
		this.SelectTabToggle(base.GetExtendToggle(3));
		this.OnDeTermToggleSelected();
	}

	// Token: 0x060078AC RID: 30892 RVA: 0x001F9DE8 File Offset: 0x001F7FE8
	private void OnBuffToggleSelected()
	{
		UiAsyncTask task = new UiAsyncTask("BabelTowerBuffView.ToggleSelect", delegate()
		{
			BabelTowerBuffView.<<OnBuffToggleSelected>b__21_0>d <<OnBuffToggleSelected>b__21_0>d;
			<<OnBuffToggleSelected>b__21_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnBuffToggleSelected>b__21_0>d.<>4__this = this;
			<<OnBuffToggleSelected>b__21_0>d.<>1__state = -1;
			<<OnBuffToggleSelected>b__21_0>d.<>t__builder.Start<BabelTowerBuffView.<<OnBuffToggleSelected>b__21_0>d>(ref <<OnBuffToggleSelected>b__21_0>d);
			return <<OnBuffToggleSelected>b__21_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x060078AD RID: 30893 RVA: 0x001F9E18 File Offset: 0x001F8018
	private void OnDeTermToggleSelected()
	{
		UiAsyncTask task = new UiAsyncTask("BabelTowerBuffView.ToggleSelect", delegate()
		{
			BabelTowerBuffView.<<OnDeTermToggleSelected>b__22_0>d <<OnDeTermToggleSelected>b__22_0>d;
			<<OnDeTermToggleSelected>b__22_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnDeTermToggleSelected>b__22_0>d.<>4__this = this;
			<<OnDeTermToggleSelected>b__22_0>d.<>1__state = -1;
			<<OnDeTermToggleSelected>b__22_0>d.<>t__builder.Start<BabelTowerBuffView.<<OnDeTermToggleSelected>b__22_0>d>(ref <<OnDeTermToggleSelected>b__22_0>d);
			return <<OnDeTermToggleSelected>b__22_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x060078AE RID: 30894 RVA: 0x001F9E48 File Offset: 0x001F8048
	private UniTask OnTabBuffToggleSelectedAsync()
	{
		BabelTowerBuffView.<OnTabBuffToggleSelectedAsync>d__23 <OnTabBuffToggleSelectedAsync>d__;
		<OnTabBuffToggleSelectedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnTabBuffToggleSelectedAsync>d__.<>4__this = this;
		<OnTabBuffToggleSelectedAsync>d__.<>1__state = -1;
		<OnTabBuffToggleSelectedAsync>d__.<>t__builder.Start<BabelTowerBuffView.<OnTabBuffToggleSelectedAsync>d__23>(ref <OnTabBuffToggleSelectedAsync>d__);
		return <OnTabBuffToggleSelectedAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060078AF RID: 30895 RVA: 0x001F9E8C File Offset: 0x001F808C
	private UniTask OnTabDeTermToggleSelectedAsync()
	{
		BabelTowerBuffView.<OnTabDeTermToggleSelectedAsync>d__24 <OnTabDeTermToggleSelectedAsync>d__;
		<OnTabDeTermToggleSelectedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnTabDeTermToggleSelectedAsync>d__.<>4__this = this;
		<OnTabDeTermToggleSelectedAsync>d__.<>1__state = -1;
		<OnTabDeTermToggleSelectedAsync>d__.<>t__builder.Start<BabelTowerBuffView.<OnTabDeTermToggleSelectedAsync>d__24>(ref <OnTabDeTermToggleSelectedAsync>d__);
		return <OnTabDeTermToggleSelectedAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060078B0 RID: 30896 RVA: 0x001F9ECF File Offset: 0x001F80CF
	[NullableContext(1)]
	private void SelectTabToggle(UUIExtendToggle toggle)
	{
		UUIExtendToggle selectedToggle = this.SelectedToggle;
		if (selectedToggle != null)
		{
			selectedToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.SelectedToggle = toggle;
		this.SelectedToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x060078B1 RID: 30897 RVA: 0x001F9F00 File Offset: 0x001F8100
	private UniTask OnSelectedTabToggleChangeAsync()
	{
		BabelTowerBuffView.<OnSelectedTabToggleChangeAsync>d__26 <OnSelectedTabToggleChangeAsync>d__;
		<OnSelectedTabToggleChangeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnSelectedTabToggleChangeAsync>d__.<>4__this = this;
		<OnSelectedTabToggleChangeAsync>d__.<>1__state = -1;
		<OnSelectedTabToggleChangeAsync>d__.<>t__builder.Start<BabelTowerBuffView.<OnSelectedTabToggleChangeAsync>d__26>(ref <OnSelectedTabToggleChangeAsync>d__);
		return <OnSelectedTabToggleChangeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060078B2 RID: 30898 RVA: 0x001F9F44 File Offset: 0x001F8144
	private void RefreshDetailItem()
	{
		if (this.BuffItemDataList == null || this.SelectedBuffItemIndex < 0 || this.SelectedBuffItemIndex >= this.BuffItemDataList.Count)
		{
			return;
		}
		this.DetailItem.Update(this.BuffItemDataList[this.SelectedBuffItemIndex]);
	}

	// Token: 0x060078B3 RID: 30899 RVA: 0x001F9F94 File Offset: 0x001F8194
	private void UpdateEmptyState(bool isEmpty)
	{
		base.GetItem(6).SetUIActive(isEmpty);
		if (isEmpty)
		{
			string textStringId = "";
			BabelTowerBuffView.ETab? selectedTab = this.SelectedTab;
			BabelTowerBuffView.ETab etab = BabelTowerBuffView.ETab.BuffTab;
			if (selectedTab.GetValueOrDefault() == etab & selectedTab != null)
			{
				textStringId = "PrefabTextItem_1001383652_Text";
			}
			else if (this.SelectedTab.GetValueOrDefault() == BabelTowerBuffView.ETab.DeTermTab)
			{
				textStringId = "PrefabTextItem_438129107_Text";
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), textStringId, Array.Empty<object>());
		}
		UUIItem uuiitem = base.GetLoopScrollViewComponent(4).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(!isEmpty);
		}
		this.DetailItem.SetActive(!isEmpty);
	}

	// Token: 0x060078B4 RID: 30900 RVA: 0x001FA039 File Offset: 0x001F8239
	private void SelectBuffItemByIndex(int index)
	{
		if (this.BuffItemDataList == null || index < 0 || index >= this.BuffItemDataList.Count)
		{
			return;
		}
		this.SelectedBuffItemIndex = index;
		LoopScrollView<BabelTowerBuffItem, IBabelTowerBuffItemData> buffScrollView = this.BuffScrollView;
		if (buffScrollView != null)
		{
			buffScrollView.SelectGridProxy(index, false);
		}
		this.RefreshDetailItem();
	}

	// Token: 0x04003A39 RID: 14905
	private IBabelTowerBuffViewData Data;

	// Token: 0x04003A3A RID: 14906
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<BabelTowerBuffItem, IBabelTowerBuffItemData> BuffScrollView;

	// Token: 0x04003A3B RID: 14907
	private BabelTowerBuffDetailItem DetailItem;

	// Token: 0x04003A3C RID: 14908
	private UUIExtendToggle SelectedToggle;

	// Token: 0x04003A3D RID: 14909
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003A3E RID: 14910
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IBabelTowerBuffItemData> BuffItemDataList;

	// Token: 0x04003A3F RID: 14911
	private BabelTowerBuffView.ETab? SelectedTab;

	// Token: 0x04003A40 RID: 14912
	private int SelectedBuffItemIndex = -1;

	// Token: 0x02007537 RID: 30007
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028753 RID: 165715
		public const int CaptionItem = 0;

		// Token: 0x04028754 RID: 165716
		public const int BackButton = 1;

		// Token: 0x04028755 RID: 165717
		public const int BuffToggle = 2;

		// Token: 0x04028756 RID: 165718
		public const int DeTermToggle = 3;

		// Token: 0x04028757 RID: 165719
		public const int BuffItemScrollView = 4;

		// Token: 0x04028758 RID: 165720
		public const int BuffItem = 5;

		// Token: 0x04028759 RID: 165721
		public const int EmptyItem = 6;

		// Token: 0x0402875A RID: 165722
		public const int EmptyText = 7;

		// Token: 0x0402875B RID: 165723
		public const int TipsItem = 8;
	}

	// Token: 0x02007538 RID: 30008
	[NullableContext(0)]
	private enum ETab
	{
		// Token: 0x0402875D RID: 165725
		BuffTab,
		// Token: 0x0402875E RID: 165726
		DeTermTab
	}
}
