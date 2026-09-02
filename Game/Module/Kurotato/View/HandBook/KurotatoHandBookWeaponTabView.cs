using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Kurotato.View.Overview;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.HandBook
{
	// Token: 0x02005ABB RID: 23227
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoHandBookWeaponTabView : UiTabViewBase
	{
		// Token: 0x0603ABAE RID: 240558 RVA: 0x00EE38A8 File Offset: 0x00EE1AA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUILoopScrollViewComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ABAF RID: 240559 RVA: 0x00EE3998 File Offset: 0x00EE1B98
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoHandBookWeaponTabView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoHandBookWeaponTabView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ABB0 RID: 240560 RVA: 0x00EE39DB File Offset: 0x00EE1BDB
		protected override void OnShowUiTabViewFromToggle()
		{
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			if (tabBehavior != null)
			{
				tabBehavior.PlaySequence("Switch");
			}
			this.RefreshCurrentList();
		}

		// Token: 0x0603ABB1 RID: 240561 RVA: 0x00EE39F9 File Offset: 0x00EE1BF9
		protected override void OnShowUiTabViewFromView()
		{
			this.RefreshCurrentList();
		}

		// Token: 0x0603ABB2 RID: 240562 RVA: 0x00EE3A01 File Offset: 0x00EE1C01
		private void RefreshCurrentList()
		{
			if (this.TabType == EKurotatoCardType.None)
			{
				return;
			}
			LoopScrollView<KurotatoWeaponMediumItemGrid, IKurotatoMediumItemGridData> weaponLoopScrollView = this.WeaponLoopScrollView;
			if (weaponLoopScrollView == null)
			{
				return;
			}
			weaponLoopScrollView.RefreshAllGridProxies();
		}

		// Token: 0x0603ABB3 RID: 240563 RVA: 0x00EE3A1D File Offset: 0x00EE1C1D
		protected override void OnHideUiTabViewBase(bool fromToggle)
		{
			this.ActivityData.ReadKurotatoItemRedDot();
			this.ActivityData.ReadKurotatoWeaponRedDot();
		}

		// Token: 0x0603ABB4 RID: 240564 RVA: 0x00EE3A38 File Offset: 0x00EE1C38
		private void OnTabToggleClick(EKurotatoCardType tabType)
		{
			if (this.TabType == EKurotatoCardType.Weapon)
			{
				this.ActivityData.ReadKurotatoWeaponRedDot();
			}
			if (this.TabType == EKurotatoCardType.Item)
			{
				this.ActivityData.ReadKurotatoItemRedDot();
			}
			this.TabType = tabType;
			GenericLayout<KurotatoHandBookWeaponViewTabItem, EKurotatoCardType> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.SelectGridProxyByKey((int)tabType, false);
			}
			List<IKurotatoMediumItemGridData> list = (tabType == EKurotatoCardType.Weapon) ? this.ActivityData.GetKurotatoWeaponList() : this.ActivityData.GetKurotatoItemList();
			this.CurrentIdList = (from data in list
			select data.Id).ToList<int>();
			LoopScrollView<KurotatoWeaponMediumItemGrid, IKurotatoMediumItemGridData> weaponLoopScrollView = this.WeaponLoopScrollView;
			if (weaponLoopScrollView != null)
			{
				weaponLoopScrollView.SelectGridProxy(-1, false);
			}
			LoopScrollView<KurotatoWeaponMediumItemGrid, IKurotatoMediumItemGridData> weaponLoopScrollView2 = this.WeaponLoopScrollView;
			if (weaponLoopScrollView2 != null)
			{
				weaponLoopScrollView2.RefreshByData(list, false, delegate
				{
					this.OnGirdItemToggleClick(list[0].Id);
					LoopScrollView<KurotatoWeaponMediumItemGrid, IKurotatoMediumItemGridData> weaponLoopScrollView3 = this.WeaponLoopScrollView;
					if (weaponLoopScrollView3 == null)
					{
						return;
					}
					weaponLoopScrollView3.ScrollToGridIndex(0, true);
				}, true);
			}
			int item;
			int item2;
			if (tabType != EKurotatoCardType.Weapon)
			{
				ValueTuple<int, int> valueTuple = this.ActivityData.GetItemUnlockNum();
				item = valueTuple.Item1;
				item2 = valueTuple.Item2;
			}
			else
			{
				ValueTuple<int, int> valueTuple = this.ActivityData.GetWeaponUnlockNum();
				item = valueTuple.Item1;
				item2 = valueTuple.Item2;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Kurotato_Handbook_Collect", new <>z__ReadOnlyArray<object>(new object[]
			{
				item,
				item2
			}));
		}

		// Token: 0x0603ABB5 RID: 240565 RVA: 0x00EE3B94 File Offset: 0x00EE1D94
		private void OnGirdItemToggleClick(int itemId)
		{
			int gridIndex = this.CurrentIdList.FindIndex((int id) => id == itemId);
			LoopScrollView<KurotatoWeaponMediumItemGrid, IKurotatoMediumItemGridData> weaponLoopScrollView = this.WeaponLoopScrollView;
			if (weaponLoopScrollView != null)
			{
				weaponLoopScrollView.SelectGridProxy(gridIndex, false);
			}
			KurotatoItemInfoTipPanel itemInfoTip = this.ItemInfoTip;
			if (itemInfoTip == null)
			{
				return;
			}
			itemInfoTip.Refresh(this.TabType, itemId, true, false, null);
		}

		// Token: 0x0603ABB6 RID: 240566 RVA: 0x00EE3C00 File Offset: 0x00EE1E00
		private KurotatoHandBookWeaponViewTabItem CreateTabItem()
		{
			return new KurotatoHandBookWeaponViewTabItem
			{
				OnToggleCallBack = new Action<EKurotatoCardType>(this.OnTabToggleClick)
			};
		}

		// Token: 0x0603ABB7 RID: 240567 RVA: 0x00EE3C1C File Offset: 0x00EE1E1C
		private KurotatoWeaponMediumItemGrid CreateWeaponItem()
		{
			KurotatoWeaponMediumItemGrid item = new KurotatoWeaponMediumItemGrid();
			item.IsShowItemCount = false;
			item.IsShowLock = true;
			item.IsShowNew = true;
			item.BindCallback(delegate(EToggleState state)
			{
				if (state == EToggleState.ETT_Checked)
				{
					this.OnGirdItemToggleClick(item.Data.Id);
				}
			});
			return item;
		}

		// Token: 0x04021354 RID: 136020
		private KurotatoActivityData ActivityData;

		// Token: 0x04021355 RID: 136021
		private EKurotatoCardType TabType = EKurotatoCardType.None;

		// Token: 0x04021356 RID: 136022
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<KurotatoHandBookWeaponViewTabItem, EKurotatoCardType> TabLayout;

		// Token: 0x04021357 RID: 136023
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<KurotatoWeaponMediumItemGrid, IKurotatoMediumItemGridData> WeaponLoopScrollView;

		// Token: 0x04021358 RID: 136024
		private List<int> CurrentIdList = new List<int>();

		// Token: 0x04021359 RID: 136025
		[Nullable(2)]
		private KurotatoItemInfoTipPanel ItemInfoTip;

		// Token: 0x0200BACA RID: 47818
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04039A94 RID: 236180
			LayoutTab,
			// Token: 0x04039A95 RID: 236181
			ItemTab,
			// Token: 0x04039A96 RID: 236182
			LayoutWeapon,
			// Token: 0x04039A97 RID: 236183
			ItemWeapon,
			// Token: 0x04039A98 RID: 236184
			TextCollected,
			// Token: 0x04039A99 RID: 236185
			ItemInfoPanel,
			// Token: 0x04039A9A RID: 236186
			ScrollWeapon
		}
	}
}
