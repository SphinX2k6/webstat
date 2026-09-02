using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Kurotato.View.Overview;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A79 RID: 23161
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoPopupWeaponDetailView : UiViewBase
	{
		// Token: 0x0603A9BD RID: 240061 RVA: 0x00ED853B File Offset: 0x00ED673B
		public KurotatoPopupWeaponDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603A9BE RID: 240062 RVA: 0x00ED855C File Offset: 0x00ED675C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickRight));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A9BF RID: 240063 RVA: 0x00ED86CC File Offset: 0x00ED68CC
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoPopupWeaponDetailView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoPopupWeaponDetailView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A9C0 RID: 240064 RVA: 0x00ED8710 File Offset: 0x00ED6910
		private UniTask CreateWeaponTipAsync()
		{
			KurotatoPopupWeaponDetailView.<CreateWeaponTipAsync>d__9 <CreateWeaponTipAsync>d__;
			<CreateWeaponTipAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateWeaponTipAsync>d__.<>4__this = this;
			<CreateWeaponTipAsync>d__.<>1__state = -1;
			<CreateWeaponTipAsync>d__.<>t__builder.Start<KurotatoPopupWeaponDetailView.<CreateWeaponTipAsync>d__9>(ref <CreateWeaponTipAsync>d__);
			return <CreateWeaponTipAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A9C1 RID: 240065 RVA: 0x00ED8754 File Offset: 0x00ED6954
		protected override void OnStart()
		{
			this.CreateWeaponScrollList();
			IKurotatoPopupItemDetailOpenParam kurotatoPopupItemDetailOpenParam = (IKurotatoPopupItemDetailOpenParam)this.OpenParam;
			this.CardData = kurotatoPopupItemDetailOpenParam.CardData;
			this.Index = kurotatoPopupItemDetailOpenParam.Index;
			this.RefreshScrollList();
			this.RefreshArrows();
		}

		// Token: 0x0603A9C2 RID: 240066 RVA: 0x00ED8797 File Offset: 0x00ED6997
		private void CreateWeaponScrollList()
		{
			this.WeaponScrollList = new GenericScrollViewNew<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData>(base.GetScrollViewWithScrollbar(4), delegate()
			{
				KurotatoWeaponSmallItemGrid kurotatoWeaponSmallItemGrid = new KurotatoWeaponSmallItemGrid(false);
				kurotatoWeaponSmallItemGrid.BindCallback(new Action<IKurotatoSmallItemGridData, EToggleState, int>(this.OnClickGrid));
				return kurotatoWeaponSmallItemGrid;
			}, null, false, null);
		}

		// Token: 0x0603A9C3 RID: 240067 RVA: 0x00ED87BC File Offset: 0x00ED69BC
		private void RefreshScrollList()
		{
			KurotatoModel modelData = ModelBase<KurotatoModel>.Instance;
			List<IKurotatoSmallItemGridData> data = (from item in this.CardData
			select new KurotatoSmallItemGridData
			{
				Type = item.CardType,
				Id = (item.IsConfigId.GetValueOrDefault() ? item.SelectId : modelData.GetWeaponDataByIncId(item.SelectId).WeaponId),
				IncId = item.SelectId,
				Count = 0
			}).ToList<IKurotatoSmallItemGridData>();
			this.WeaponScrollList.RefreshByData(data, delegate
			{
				this.RefreshItemTip();
			}, false);
		}

		// Token: 0x0603A9C4 RID: 240068 RVA: 0x00ED8818 File Offset: 0x00ED6A18
		private void RefreshItemTip()
		{
			this.Index = Math.Max(0, Math.Min(this.Index, this.CardData.Count - 1));
			if (this.CardData.Count == 0)
			{
				return;
			}
			KurotatoWeaponSmallItemGrid selectItem = this.SelectItem;
			if (selectItem != null)
			{
				selectItem.SetSelected(false, false);
			}
			this.SelectItem = this.WeaponScrollList.GetScrollItemByIndex(this.Index);
			UUIItem itemByIndex = this.WeaponScrollList.GetItemByIndex(this.Index);
			this.ItemTip.Refresh(this.CardData[this.Index].CardType, this.CardData[this.Index].SelectId, true, false, null);
			KurotatoWeaponSmallItemGrid selectItem2 = this.SelectItem;
			if (selectItem2 != null)
			{
				selectItem2.SetSelected(true, false);
			}
			if (itemByIndex != null)
			{
				this.WeaponScrollList.LateScrollTo(itemByIndex, null, false);
			}
			this.RefreshArrows();
		}

		// Token: 0x0603A9C5 RID: 240069 RVA: 0x00ED8900 File Offset: 0x00ED6B00
		private void RefreshArrows()
		{
			bool uiactive = this.CardData.Count > 1;
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(uiactive);
				}
			}
			UUIButtonComponent button2 = base.GetButton(3);
			if (button2 == null)
			{
				return;
			}
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 == null)
			{
				return;
			}
			uuiitem2.SetUIActive(uiactive);
		}

		// Token: 0x0603A9C6 RID: 240070 RVA: 0x00ED8966 File Offset: 0x00ED6B66
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A9C7 RID: 240071 RVA: 0x00ED896F File Offset: 0x00ED6B6F
		private void OnClickLeft()
		{
			if (this.CardData.Count <= 1)
			{
				return;
			}
			this.Index = ((this.Index <= 0) ? (this.CardData.Count - 1) : (this.Index - 1));
			this.RefreshItemTip();
		}

		// Token: 0x0603A9C8 RID: 240072 RVA: 0x00ED89AC File Offset: 0x00ED6BAC
		private void OnClickRight()
		{
			if (this.CardData.Count <= 1)
			{
				return;
			}
			this.Index = ((this.Index >= this.CardData.Count - 1) ? 0 : (this.Index + 1));
			this.RefreshItemTip();
		}

		// Token: 0x0603A9C9 RID: 240073 RVA: 0x00ED89E9 File Offset: 0x00ED6BE9
		private void OnClickGrid(IKurotatoSmallItemGridData data, EToggleState state, int gridIndex)
		{
			if (state == EToggleState.ETT_Checked)
			{
				KurotatoWeaponSmallItemGrid selectItem = this.SelectItem;
				if (selectItem != null)
				{
					selectItem.SetSelected(false, false);
				}
				this.Index = gridIndex;
				this.RefreshItemTip();
			}
		}

		// Token: 0x04021282 RID: 135810
		private readonly KurotatoItemInfoTipPanel ItemTip = new KurotatoItemInfoTipPanel();

		// Token: 0x04021283 RID: 135811
		private List<KurotatoCardTip> CardData = new List<KurotatoCardTip>();

		// Token: 0x04021284 RID: 135812
		private int Index;

		// Token: 0x04021285 RID: 135813
		[Nullable(2)]
		private KurotatoWeaponSmallItemGrid SelectItem;

		// Token: 0x04021286 RID: 135814
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> WeaponScrollList;

		// Token: 0x0200BA40 RID: 47680
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04039841 RID: 235585
			public const int BtnClose = 0;

			// Token: 0x04039842 RID: 235586
			public const int TipItem = 1;

			// Token: 0x04039843 RID: 235587
			public const int BtnLeft = 2;

			// Token: 0x04039844 RID: 235588
			public const int BtnRight = 3;

			// Token: 0x04039845 RID: 235589
			public const int ScrollView = 4;

			// Token: 0x04039846 RID: 235590
			public const int ItemGrid = 5;
		}
	}
}
