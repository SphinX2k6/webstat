using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.WeaponDecompose
{
	// Token: 0x020065AE RID: 26030
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponDecomposeView : UiViewBase
	{
		// Token: 0x06041087 RID: 266375 RVA: 0x010AFAF8 File Offset: 0x010ADCF8
		public PinballWeaponDecomposeView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041088 RID: 266376 RVA: 0x010AFB2C File Offset: 0x010ADD2C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action<EToggleState>(this.OnClickAllSelectToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041089 RID: 266377 RVA: 0x010AFD24 File Offset: 0x010ADF24
		protected override UniTask OnBeforeStartAsync()
		{
			PinballWeaponDecomposeView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballWeaponDecomposeView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604108A RID: 266378 RVA: 0x010AFD67 File Offset: 0x010ADF67
		protected override void OnStart()
		{
			this.InitScroll();
			this.FilterSortEntrance = new FilterSortEntrance<PinballWeaponData>(base.GetItem(3), delegate(List<PinballWeaponData> list, bool isOutSideChange, EFilterSortType operationType)
			{
				this.OnFilterSortRefresh(list);
			});
			UUIExtendToggle extendToggle = base.GetExtendToggle(10);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0604108B RID: 266379 RVA: 0x010AFDA3 File Offset: 0x010ADFA3
		private void InitScroll()
		{
			this.LoopScroll = new LoopScrollView<PinballItemWeaponGridView, PinballWeaponData>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<PinballItemWeaponGridView>(this.CreateGrid), false);
		}

		// Token: 0x0604108C RID: 266380 RVA: 0x010AFDD8 File Offset: 0x010ADFD8
		private PinballItemWeaponGridView CreateGrid()
		{
			PinballItemWeaponGridView pinballItemWeaponGridView = new PinballItemWeaponGridView();
			pinballItemWeaponGridView.BindOnExtendToggleClicked(new Action<IPinballItemToggleCallback>(this.ShowCurrentSelectedWeaponInfo));
			pinballItemWeaponGridView.BindReduceButtonCallback(new Func<IPinballItemButtonCallback, bool>(this.ReduceFunction));
			pinballItemWeaponGridView.BindOnStateChangeCallback(delegate(IPinballItemToggleCallback x)
			{
				this.AddFunction(x);
			});
			pinballItemWeaponGridView.BindOnCanExecuteChangeCallback(new Func<IPinballItemToggleCallback, bool>(this.OnCanExecuteChange));
			pinballItemWeaponGridView.BindFocusListenerDelegate(new Action<IPinballItemToggleCallback>(this.ShowCurrentSelectedWeaponInfo));
			return pinballItemWeaponGridView;
		}

		// Token: 0x0604108D RID: 266381 RVA: 0x010AFE44 File Offset: 0x010AE044
		protected override void OnBeforeShow()
		{
			this.RefreshList();
			this.RefreshWeaponInfo();
			this.RefreshPreviewItemAsync().Forget();
		}

		// Token: 0x0604108E RID: 266382 RVA: 0x010AFE60 File Offset: 0x010AE060
		private void RefreshList()
		{
			List<PinballWeaponData> allWeaponDataList = ModelBase<PinballModel>.Instance.GetAllWeaponDataList();
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(11), "Pinball_Weapon_Salvage_amount01", new <>z__ReadOnlySingleElementList<object>(allWeaponDataList.Count));
			FilterSortEntrance<PinballWeaponData> filterSortEntrance = this.FilterSortEntrance;
			if (filterSortEntrance == null)
			{
				return;
			}
			filterSortEntrance.UpdateData(EFilterSortGroupId.PinballWeaponDecompose, allWeaponDataList, Array.Empty<object>());
		}

		// Token: 0x0604108F RID: 266383 RVA: 0x010AFEB7 File Offset: 0x010AE0B7
		private void OnFilterSortRefresh(List<PinballWeaponData> list)
		{
			this.DataList = list;
			LoopScrollView<PinballItemWeaponGridView, PinballWeaponData> loopScroll = this.LoopScroll;
			if (loopScroll == null)
			{
				return;
			}
			loopScroll.RefreshByData(this.DataList, false, null, true);
		}

		// Token: 0x06041090 RID: 266384 RVA: 0x010AFED9 File Offset: 0x010AE0D9
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnPinballWeaponLockChanged, new Action<int, bool>(this.OnPinballWeaponLockChanged));
		}

		// Token: 0x06041091 RID: 266385 RVA: 0x010AFEF7 File Offset: 0x010AE0F7
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.OnPinballWeaponLockChanged, new Action<int, bool>(this.OnPinballWeaponLockChanged));
		}

		// Token: 0x06041092 RID: 266386 RVA: 0x010AFF18 File Offset: 0x010AE118
		private void OnClickAllSelectToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				using (List<PinballWeaponData>.Enumerator enumerator = this.DataList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						PinballWeaponData pinballWeaponData = enumerator.Current;
						if (this.CanAddItem(pinballWeaponData.IncId, false))
						{
							this.AddSelection(pinballWeaponData.IncId);
						}
					}
					goto IL_54;
				}
			}
			this.ClearSelection();
			IL_54:
			LoopScrollView<PinballItemWeaponGridView, PinballWeaponData> loopScroll = this.LoopScroll;
			if (loopScroll != null)
			{
				loopScroll.UpdateData(this.DataList);
			}
			this.RefreshPreviewItemAsync().Forget();
		}

		// Token: 0x06041093 RID: 266387 RVA: 0x010AFFAC File Offset: 0x010AE1AC
		private UniTask RefreshPreviewItemAsync()
		{
			PinballWeaponDecomposeView.<RefreshPreviewItemAsync>d__25 <RefreshPreviewItemAsync>d__;
			<RefreshPreviewItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshPreviewItemAsync>d__.<>4__this = this;
			<RefreshPreviewItemAsync>d__.<>1__state = -1;
			<RefreshPreviewItemAsync>d__.<>t__builder.Start<PinballWeaponDecomposeView.<RefreshPreviewItemAsync>d__25>(ref <RefreshPreviewItemAsync>d__);
			return <RefreshPreviewItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041094 RID: 266388 RVA: 0x010AFFF0 File Offset: 0x010AE1F0
		private void RefreshWeaponInfo()
		{
			if (this.CurrentSelectedIncId == -1)
			{
				UUIText text = base.GetText(5);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				PinballWeaponTipsTopView tipsTopView = this.TipsTopView;
				if (tipsTopView != null)
				{
					tipsTopView.Hide(null);
				}
				PinballWeaponAttrView attrView = this.AttrView;
				if (attrView == null)
				{
					return;
				}
				attrView.Hide(null);
				return;
			}
			else
			{
				UUIText text2 = base.GetText(5);
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
				PinballWeaponData weaponDataByIncId = ModelBase<PinballModel>.Instance.GetWeaponDataByIncId(this.CurrentSelectedIncId);
				if (weaponDataByIncId == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.PinballBattle;
					ELogAuthor author = ELogAuthor.CB;
					string message = "找不到武器数据";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IncId", this.CurrentSelectedIncId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				PinballWeaponTipsTopView tipsTopView2 = this.TipsTopView;
				if (tipsTopView2 != null)
				{
					tipsTopView2.Refresh(weaponDataByIncId);
				}
				PinballWeaponTipsTopView tipsTopView3 = this.TipsTopView;
				if (tipsTopView3 != null)
				{
					tipsTopView3.Show(null);
				}
				PinballWeaponAttrView attrView2 = this.AttrView;
				if (attrView2 != null)
				{
					attrView2.Refresh(weaponDataByIncId);
				}
				PinballWeaponAttrView attrView3 = this.AttrView;
				if (attrView3 == null)
				{
					return;
				}
				attrView3.Show(null);
				return;
			}
		}

		// Token: 0x06041095 RID: 266389 RVA: 0x010B00E0 File Offset: 0x010AE2E0
		private void OnClickBtnConfirm()
		{
			if (this.Selection.Count <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_NotEnoughItem_Text", Array.Empty<object>());
				return;
			}
			this.RequestWeaponDecomposeAsync().Forget();
		}

		// Token: 0x06041096 RID: 266390 RVA: 0x010B0110 File Offset: 0x010AE310
		private UniTask RequestWeaponDecomposeAsync()
		{
			PinballWeaponDecomposeView.<RequestWeaponDecomposeAsync>d__28 <RequestWeaponDecomposeAsync>d__;
			<RequestWeaponDecomposeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestWeaponDecomposeAsync>d__.<>4__this = this;
			<RequestWeaponDecomposeAsync>d__.<>1__state = -1;
			<RequestWeaponDecomposeAsync>d__.<>t__builder.Start<PinballWeaponDecomposeView.<RequestWeaponDecomposeAsync>d__28>(ref <RequestWeaponDecomposeAsync>d__);
			return <RequestWeaponDecomposeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041097 RID: 266391 RVA: 0x010B0154 File Offset: 0x010AE354
		private void OnPinballWeaponLockChanged(int incId, bool bLock)
		{
			if (bLock)
			{
				this.RemoveSelection(incId);
			}
			int gridIndex = -1;
			for (int i = 0; i < this.DataList.Count; i++)
			{
				if (this.DataList[i].IncId == incId)
				{
					gridIndex = i;
					break;
				}
			}
			LoopScrollView<PinballItemWeaponGridView, PinballWeaponData> loopScroll = this.LoopScroll;
			if (loopScroll != null)
			{
				loopScroll.RefreshGridProxy(gridIndex);
			}
			this.RefreshPreviewItemAsync().Forget();
		}

		// Token: 0x06041098 RID: 266392 RVA: 0x010B01B8 File Offset: 0x010AE3B8
		protected bool OnCanExecuteChange(IPinballItemToggleCallback callbackParameter)
		{
			int incId = ((IPinballItemDataWeapon)callbackParameter.Data).IncId;
			return this.CanAddItem(incId, true);
		}

		// Token: 0x06041099 RID: 266393 RVA: 0x010B01E0 File Offset: 0x010AE3E0
		protected bool AddFunction(IPinballItemToggleCallback @params)
		{
			int incId = ((IPinballItemDataWeapon)@params.Data).IncId;
			this.AddSelection(incId);
			@params.View.RefreshReduceBtnComponent(true).Forget();
			this.RefreshPreviewItemAsync().Forget();
			return true;
		}

		// Token: 0x0604109A RID: 266394 RVA: 0x010B0224 File Offset: 0x010AE424
		private void ShowCurrentSelectedWeaponInfo(IPinballItemToggleCallback @params)
		{
			this.CurrentSelectedIncId = ((IPinballItemDataWeapon)@params.Data).IncId;
			this.RefreshWeaponInfo();
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x0604109B RID: 266395 RVA: 0x010B0264 File Offset: 0x010AE464
		protected bool ReduceFunction(IPinballItemButtonCallback callbackParameter)
		{
			int incId = ((IPinballItemDataWeapon)callbackParameter.Data).IncId;
			this.RemoveSelection(incId);
			callbackParameter.View.RefreshReduceBtnComponent(false).Forget();
			int gridIndex = -1;
			for (int i = 0; i < this.DataList.Count; i++)
			{
				if (this.DataList[i].IncId == incId)
				{
					gridIndex = i;
					break;
				}
			}
			LoopScrollView<PinballItemWeaponGridView, PinballWeaponData> loopScroll = this.LoopScroll;
			if (loopScroll != null)
			{
				loopScroll.RefreshGridProxy(gridIndex);
			}
			this.RefreshPreviewItemAsync().Forget();
			return true;
		}

		// Token: 0x0604109C RID: 266396 RVA: 0x010B02E8 File Offset: 0x010AE4E8
		private bool CanAddItem(int incId, bool isShowTip)
		{
			PinballWeaponData weaponDataByIncId = ModelBase<PinballModel>.Instance.GetWeaponDataByIncId(incId);
			if (weaponDataByIncId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到武器数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IncId", incId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (weaponDataByIncId.GetIsLock())
			{
				if (isShowTip)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponLockTipsText", Array.Empty<object>());
				}
				return false;
			}
			if (weaponDataByIncId.RoleId > 0)
			{
				if (isShowTip)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Pinball_Weapon_ArmInfo03", Array.Empty<object>());
				}
				return false;
			}
			if (this.Selection.Count >= 1000)
			{
				if (isShowTip)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponFullMaterialText", Array.Empty<object>());
				}
				return false;
			}
			return true;
		}

		// Token: 0x0604109D RID: 266397 RVA: 0x010B03A4 File Offset: 0x010AE5A4
		private void AddSelection(int incId)
		{
			PinballWeaponData weaponDataByIncId = ModelBase<PinballModel>.Instance.GetWeaponDataByIncId(incId);
			if (weaponDataByIncId == null)
			{
				return;
			}
			weaponDataByIncId.IsSelected = true;
			this.Selection.Add(incId);
		}

		// Token: 0x0604109E RID: 266398 RVA: 0x010B03D8 File Offset: 0x010AE5D8
		private void RemoveSelection(int incId)
		{
			PinballWeaponData weaponDataByIncId = ModelBase<PinballModel>.Instance.GetWeaponDataByIncId(incId);
			if (weaponDataByIncId == null)
			{
				return;
			}
			weaponDataByIncId.IsSelected = false;
			this.Selection.Remove(incId);
		}

		// Token: 0x0604109F RID: 266399 RVA: 0x010B040C File Offset: 0x010AE60C
		private void ClearSelection()
		{
			foreach (int incId in this.Selection)
			{
				PinballWeaponData weaponDataByIncId = ModelBase<PinballModel>.Instance.GetWeaponDataByIncId(incId);
				if (weaponDataByIncId != null)
				{
					weaponDataByIncId.IsSelected = false;
				}
			}
			this.Selection.Clear();
		}

		// Token: 0x060410A0 RID: 266400 RVA: 0x010B047C File Offset: 0x010AE67C
		private void OnPreviewItemExtendToggleClicked(IPinballItemToggleCallback callbackParameter)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.PreviewItemData.ItemData.ItemId, true, null);
		}

		// Token: 0x060410A1 RID: 266401 RVA: 0x010B049A File Offset: 0x010AE69A
		private bool OnPreviewItemCanExecuteChange(IPinballItemToggleCallback callbackParameter)
		{
			return false;
		}

		// Token: 0x060410A2 RID: 266402 RVA: 0x010B049D File Offset: 0x010AE69D
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x060410A3 RID: 266403 RVA: 0x010B04A6 File Offset: 0x010AE6A6
		protected override void OnBeforeDestroy()
		{
			this.ClearSelection();
		}

		// Token: 0x0402474F RID: 149327
		private int CurrentSelectedIncId = -1;

		// Token: 0x04024750 RID: 149328
		private readonly HashSet<int> Selection = new HashSet<int>();

		// Token: 0x04024751 RID: 149329
		private List<PinballWeaponData> DataList;

		// Token: 0x04024752 RID: 149330
		private LoopScrollView<PinballItemWeaponGridView, PinballWeaponData> LoopScroll;

		// Token: 0x04024753 RID: 149331
		private FilterSortEntrance<PinballWeaponData> FilterSortEntrance;

		// Token: 0x04024754 RID: 149332
		private PinballItemView PreviewItemView;

		// Token: 0x04024755 RID: 149333
		private TItem PreviewItemData = new TItem(new InventoryDefine.GetItemData(89500002, 0), 0);

		// Token: 0x04024756 RID: 149334
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024757 RID: 149335
		private ButtonItem BtnConfirm;

		// Token: 0x04024758 RID: 149336
		private PinballWeaponTipsTopView TipsTopView;

		// Token: 0x04024759 RID: 149337
		private PinballWeaponAttrView AttrView;

		// Token: 0x0402475A RID: 149338
		private const int MAX_SELECT_COUNT = 1000;

		// Token: 0x0200C5A8 RID: 50600
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CD5A RID: 249178
			Caption,
			// Token: 0x0403CD5B RID: 249179
			LoopScroll,
			// Token: 0x0403CD5C RID: 249180
			LoopScrollItem,
			// Token: 0x0403CD5D RID: 249181
			SortFilter,
			// Token: 0x0403CD5E RID: 249182
			PnlWeapon,
			// Token: 0x0403CD5F RID: 249183
			TextEmptyTips,
			// Token: 0x0403CD60 RID: 249184
			PnlWeaponAttr,
			// Token: 0x0403CD61 RID: 249185
			PreviewItem,
			// Token: 0x0403CD62 RID: 249186
			TextSelectedCount,
			// Token: 0x0403CD63 RID: 249187
			BtnConfirm,
			// Token: 0x0403CD64 RID: 249188
			AllSelectToggle,
			// Token: 0x0403CD65 RID: 249189
			TextWeaponCount
		}
	}
}
