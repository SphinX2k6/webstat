using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Kurotato.View.Overview;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.PopupItemDetail
{
	// Token: 0x02005A8B RID: 23179
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoPopupItemDetailView : UiViewBase
	{
		// Token: 0x0603AA59 RID: 240217 RVA: 0x00EDBEA4 File Offset: 0x00EDA0A4
		public KurotatoPopupItemDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AA5A RID: 240218 RVA: 0x00EDBF08 File Offset: 0x00EDA108
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AA5B RID: 240219 RVA: 0x00EDC098 File Offset: 0x00EDA298
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoPopupItemDetailView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoPopupItemDetailView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA5C RID: 240220 RVA: 0x00EDC0DC File Offset: 0x00EDA2DC
		private UniTask CreateCaptionAsync()
		{
			KurotatoPopupItemDetailView.<CreateCaptionAsync>d__14 <CreateCaptionAsync>d__;
			<CreateCaptionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaptionAsync>d__.<>4__this = this;
			<CreateCaptionAsync>d__.<>1__state = -1;
			<CreateCaptionAsync>d__.<>t__builder.Start<KurotatoPopupItemDetailView.<CreateCaptionAsync>d__14>(ref <CreateCaptionAsync>d__);
			return <CreateCaptionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA5D RID: 240221 RVA: 0x00EDC120 File Offset: 0x00EDA320
		private UniTask CreateWeaponTipAsync()
		{
			KurotatoPopupItemDetailView.<CreateWeaponTipAsync>d__15 <CreateWeaponTipAsync>d__;
			<CreateWeaponTipAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateWeaponTipAsync>d__.<>4__this = this;
			<CreateWeaponTipAsync>d__.<>1__state = -1;
			<CreateWeaponTipAsync>d__.<>t__builder.Start<KurotatoPopupItemDetailView.<CreateWeaponTipAsync>d__15>(ref <CreateWeaponTipAsync>d__);
			return <CreateWeaponTipAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA5E RID: 240222 RVA: 0x00EDC164 File Offset: 0x00EDA364
		private UniTask CreateBtnComposeAsync()
		{
			KurotatoPopupItemDetailView.<CreateBtnComposeAsync>d__16 <CreateBtnComposeAsync>d__;
			<CreateBtnComposeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBtnComposeAsync>d__.<>4__this = this;
			<CreateBtnComposeAsync>d__.<>1__state = -1;
			<CreateBtnComposeAsync>d__.<>t__builder.Start<KurotatoPopupItemDetailView.<CreateBtnComposeAsync>d__16>(ref <CreateBtnComposeAsync>d__);
			return <CreateBtnComposeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA5F RID: 240223 RVA: 0x00EDC1A8 File Offset: 0x00EDA3A8
		private UniTask CreateBtnSellAsync()
		{
			KurotatoPopupItemDetailView.<CreateBtnSellAsync>d__17 <CreateBtnSellAsync>d__;
			<CreateBtnSellAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBtnSellAsync>d__.<>4__this = this;
			<CreateBtnSellAsync>d__.<>1__state = -1;
			<CreateBtnSellAsync>d__.<>t__builder.Start<KurotatoPopupItemDetailView.<CreateBtnSellAsync>d__17>(ref <CreateBtnSellAsync>d__);
			return <CreateBtnSellAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA60 RID: 240224 RVA: 0x00EDC1EC File Offset: 0x00EDA3EC
		private UniTask CreateCurrencyAsync()
		{
			KurotatoPopupItemDetailView.<CreateCurrencyAsync>d__18 <CreateCurrencyAsync>d__;
			<CreateCurrencyAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCurrencyAsync>d__.<>4__this = this;
			<CreateCurrencyAsync>d__.<>1__state = -1;
			<CreateCurrencyAsync>d__.<>t__builder.Start<KurotatoPopupItemDetailView.<CreateCurrencyAsync>d__18>(ref <CreateCurrencyAsync>d__);
			return <CreateCurrencyAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA61 RID: 240225 RVA: 0x00EDC22F File Offset: 0x00EDA42F
		private void CreateItemLayout()
		{
			this.ItemLayout = new GenericLayout<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData>(base.GetHorizontalLayout(4), delegate()
			{
				KurotatoWeaponSmallItemGrid kurotatoWeaponSmallItemGrid = new KurotatoWeaponSmallItemGrid(true);
				kurotatoWeaponSmallItemGrid.BindCallback(new Action<IKurotatoSmallItemGridData, EToggleState, int>(this.OnClickGrid));
				return kurotatoWeaponSmallItemGrid;
			}, null, false, true);
		}

		// Token: 0x0603AA62 RID: 240226 RVA: 0x00EDC252 File Offset: 0x00EDA452
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnUpdateWeapon));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.KurotatoOnWeaponRefined, new Action<int>(this.OnWeaponRefined));
		}

		// Token: 0x0603AA63 RID: 240227 RVA: 0x00EDC28C File Offset: 0x00EDA48C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnWeaponUpdate, new Action(this.OnUpdateWeapon));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.KurotatoOnWeaponRefined, new Action<int>(this.OnWeaponRefined));
		}

		// Token: 0x0603AA64 RID: 240228 RVA: 0x00EDC2C8 File Offset: 0x00EDA4C8
		protected override void OnStart()
		{
			IKurotatoPopupItemDetailOpenParam kurotatoPopupItemDetailOpenParam = (IKurotatoPopupItemDetailOpenParam)this.OpenParam;
			this.CardData = new List<IKurotatoCardTip>(kurotatoPopupItemDetailOpenParam.CardData);
			this.Index = kurotatoPopupItemDetailOpenParam.Index;
			this.Price = (kurotatoPopupItemDetailOpenParam.Price ?? new List<int>());
			this.RefreshItemLayout(null);
			this.RefreshBtn();
		}

		// Token: 0x0603AA65 RID: 240229 RVA: 0x00EDC328 File Offset: 0x00EDA528
		private void SyncWeaponDataAndRefresh(int? composeIncId = null)
		{
			List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
			List<IKurotatoCardTip> list = new List<IKurotatoCardTip>();
			List<int> list2 = new List<int>();
			foreach (IKurotatoWeaponData kurotatoWeaponData in holdWeaponData)
			{
				list.Add(new KurotatoCardTip
				{
					CardType = EKurotatoCardType.Weapon,
					SelectId = kurotatoWeaponData.IncId
				});
				list2.Add(kurotatoWeaponData.SellPrice);
			}
			if (composeIncId == null && this.IsCardDataSame(list) && this.IsPriceSame(list2))
			{
				return;
			}
			this.CardData = list;
			this.Price = list2;
			if (composeIncId != null)
			{
				int num = this.CardData.FindIndex((IKurotatoCardTip card) => card.CardType == EKurotatoCardType.Weapon && card.SelectId == composeIncId.Value);
				if (num >= 0)
				{
					this.Index = num;
				}
			}
			this.Index = Math.Min(this.Index, Math.Max(this.CardData.Count - 1, 0));
			this.RefreshItemLayout(composeIncId);
		}

		// Token: 0x0603AA66 RID: 240230 RVA: 0x00EDC450 File Offset: 0x00EDA650
		private bool IsCardDataSame(List<IKurotatoCardTip> newCardData)
		{
			if (this.CardData.Count != newCardData.Count)
			{
				return false;
			}
			for (int i = 0; i < newCardData.Count; i++)
			{
				if (this.CardData[i].CardType != newCardData[i].CardType || this.CardData[i].SelectId != newCardData[i].SelectId)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603AA67 RID: 240231 RVA: 0x00EDC4C4 File Offset: 0x00EDA6C4
		private bool IsPriceSame(List<int> newPrice)
		{
			if (this.Price.Count != newPrice.Count)
			{
				return false;
			}
			for (int i = 0; i < newPrice.Count; i++)
			{
				if (this.Price[i] != newPrice[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603AA68 RID: 240232 RVA: 0x00EDC510 File Offset: 0x00EDA710
		private void RefreshBtn()
		{
			if (((IKurotatoPopupItemDetailOpenParam)this.OpenParam).IsOutSide.GetValueOrDefault())
			{
				this.BtnComposeItem.GetRootItem().SetUIActive(false);
				this.BtnSellItem.GetRootItem().SetUIActive(false);
				return;
			}
			string str = (this.Index < this.Price.Count) ? this.Price[this.Index].ToString() : "0";
			this.BtnSellItem.SetLocalTextNew("PrefabTextItem_3275109564_Text", new object[]
			{
				"+" + str
			});
			if (this.Index < 0 || this.Index >= this.CardData.Count)
			{
				return;
			}
			IKurotatoCardTip kurotatoCardTip = this.CardData[this.Index];
			if (kurotatoCardTip == null || kurotatoCardTip.CardType != EKurotatoCardType.Weapon)
			{
				return;
			}
			this.BtnComposeItem.SetEnableClick(this.CanCompose(kurotatoCardTip.SelectId));
			List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
			this.BtnSellItem.SetEnableClick(holdWeaponData.Count > 1);
		}

		// Token: 0x0603AA69 RID: 240233 RVA: 0x00EDC624 File Offset: 0x00EDA824
		private bool CanCompose(int weaponIncId)
		{
			IKurotatoWeaponData weaponDataByIncId = ModelBase<KurotatoModel>.Instance.GetWeaponDataByIncId(weaponIncId);
			if (weaponDataByIncId == null)
			{
				return false;
			}
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoWeapon? weaponConfigByWeaponId = instance.GetWeaponConfigByWeaponId(weaponDataByIncId.WeaponId);
			if (weaponConfigByWeaponId == null)
			{
				return false;
			}
			int maxQualityByGroupId = instance.GetMaxQualityByGroupId(weaponConfigByWeaponId.Value.GroupId);
			if (weaponConfigByWeaponId.Value.Quality >= maxQualityByGroupId)
			{
				return false;
			}
			foreach (IKurotatoWeaponData kurotatoWeaponData in ModelBase<KurotatoModel>.Instance.GetHoldWeaponData())
			{
				if (kurotatoWeaponData.IncId != weaponDataByIncId.IncId)
				{
					KurotatoWeapon? weaponConfigByWeaponId2 = instance.GetWeaponConfigByWeaponId(kurotatoWeaponData.WeaponId);
					if (weaponConfigByWeaponId2 != null && weaponConfigByWeaponId2.Value.GroupId == weaponConfigByWeaponId.Value.GroupId && weaponConfigByWeaponId2.Value.Quality == weaponConfigByWeaponId.Value.Quality)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603AA6A RID: 240234 RVA: 0x00EDC748 File Offset: 0x00EDA948
		private void RefreshItemLayout(int? composeIncId = null)
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			HashSet<int> bagPairArrowIncIds = instance.GetComposeHighlight().BagPairArrowIncIds;
			List<IKurotatoSmallItemGridData> list = new List<IKurotatoSmallItemGridData>();
			foreach (IKurotatoCardTip kurotatoCardTip in this.CardData)
			{
				int id = kurotatoCardTip.IsConfigId.GetValueOrDefault() ? kurotatoCardTip.SelectId : instance.GetWeaponDataByIncId(kurotatoCardTip.SelectId).WeaponId;
				list.Add(new KurotatoSmallItemGridData
				{
					Type = kurotatoCardTip.CardType,
					Id = id,
					IncId = kurotatoCardTip.SelectId,
					Count = 0,
					PlayComposeFx = new bool?(composeIncId != null && kurotatoCardTip.CardType == EKurotatoCardType.Weapon && kurotatoCardTip.SelectId == composeIncId.Value),
					ShowArrow = new bool?(!kurotatoCardTip.IsConfigId.GetValueOrDefault() && kurotatoCardTip.CardType == EKurotatoCardType.Weapon && bagPairArrowIncIds.Contains(kurotatoCardTip.SelectId))
				});
			}
			this.ItemLayout.RefreshByData(list, delegate
			{
				this.RefreshItemTip();
				ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			}, false);
		}

		// Token: 0x0603AA6B RID: 240235 RVA: 0x00EDC898 File Offset: 0x00EDAA98
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
			this.SelectItem = this.ItemLayout.GetLayoutItemByIndex(this.Index);
			this.ItemTip.Refresh(this.CardData[this.Index].CardType, this.CardData[this.Index].SelectId, false, false, null);
			KurotatoWeaponSmallItemGrid selectItem2 = this.SelectItem;
			if (selectItem2 != null)
			{
				selectItem2.SetSelected(true, false);
			}
			this.RefreshBtn();
		}

		// Token: 0x0603AA6C RID: 240236 RVA: 0x00EDC95C File Offset: 0x00EDAB5C
		private void OnClickCompose()
		{
			IKurotatoCardTip kurotatoCardTip = this.CardData[this.Index];
			if (kurotatoCardTip.CardType != EKurotatoCardType.Weapon)
			{
				return;
			}
			IKurotatoWeaponData weaponDataByIncId = ModelBase<KurotatoModel>.Instance.GetWeaponDataByIncId(kurotatoCardTip.SelectId);
			if (weaponDataByIncId == null)
			{
				return;
			}
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoWeapon? weaponConfigByWeaponId = instance.GetWeaponConfigByWeaponId(weaponDataByIncId.WeaponId);
			if (weaponConfigByWeaponId == null)
			{
				return;
			}
			int maxQualityByGroupId = instance.GetMaxQualityByGroupId(weaponConfigByWeaponId.Value.GroupId);
			if (weaponConfigByWeaponId.Value.Quality >= maxQualityByGroupId)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Kurotato_Weapon_Level_Max", Array.Empty<object>());
				return;
			}
			List<IKurotatoWeaponData> holdWeaponData = ModelBase<KurotatoModel>.Instance.GetHoldWeaponData();
			bool flag = false;
			foreach (IKurotatoWeaponData kurotatoWeaponData in holdWeaponData)
			{
				if (kurotatoWeaponData.IncId != weaponDataByIncId.IncId)
				{
					KurotatoWeapon? weaponConfigByWeaponId2 = instance.GetWeaponConfigByWeaponId(kurotatoWeaponData.WeaponId);
					if (weaponConfigByWeaponId2 != null && weaponConfigByWeaponId2.Value.GroupId == weaponConfigByWeaponId.Value.GroupId && weaponConfigByWeaponId2.Value.Quality == weaponConfigByWeaponId.Value.Quality)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Kurotato_Weapon_Synthesis_Failed", Array.Empty<object>());
				return;
			}
			ControllerBase<KurotatoController>.Instance.RequestKurotatoRefineWeapon(kurotatoCardTip.SelectId).Forget<bool>();
		}

		// Token: 0x0603AA6D RID: 240237 RVA: 0x00EDCAE0 File Offset: 0x00EDACE0
		private void OnClickSell()
		{
			IKurotatoCardTip kurotatoCardTip = this.CardData[this.Index];
			if (ModelBase<KurotatoModel>.Instance.GetHoldWeaponData().Count <= 1)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Kurotato_Weapon_Quantity_Min", Array.Empty<object>());
				return;
			}
			if (kurotatoCardTip.CardType == EKurotatoCardType.Weapon)
			{
				if (ModelBase<KurotatoModel>.Instance.HideSellWeaponConfirmBox)
				{
					this.DoSellWeapon(kurotatoCardTip.SelectId).Forget();
					return;
				}
				this.OpenSellWeaponConfirm(kurotatoCardTip.SelectId);
			}
		}

		// Token: 0x0603AA6E RID: 240238 RVA: 0x00EDCB58 File Offset: 0x00EDAD58
		private void OpenSellWeaponConfirm(int weaponIncId)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KurotatoSellWeaponConfirm);
			string text = (this.Index < this.Price.Count) ? this.Price[this.Index].ToString() : "0";
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				text ?? ""
			});
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleTextKey = "Text_ItemRecycleConfirmToggle_text";
			confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnToggleSellWeaponConfirm));
			Action value = delegate()
			{
				ModelBase<KurotatoModel>.Instance.HideSellWeaponConfirmBox = false;
			};
			confirmBoxDataNew.FunctionMap[0] = value;
			confirmBoxDataNew.FunctionMap[1] = value;
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.DoSellWeapon(weaponIncId).Forget();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603AA6F RID: 240239 RVA: 0x00EDCC54 File Offset: 0x00EDAE54
		private void OnToggleSellWeaponConfirm(bool isSelectedOn)
		{
			ModelBase<KurotatoModel>.Instance.HideSellWeaponConfirmBox = isSelectedOn;
		}

		// Token: 0x0603AA70 RID: 240240 RVA: 0x00EDCC61 File Offset: 0x00EDAE61
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603AA71 RID: 240241 RVA: 0x00EDCC6C File Offset: 0x00EDAE6C
		private UniTask DoSellWeapon(int weaponIncId)
		{
			KurotatoPopupItemDetailView.<DoSellWeapon>d__35 <DoSellWeapon>d__;
			<DoSellWeapon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DoSellWeapon>d__.weaponIncId = weaponIncId;
			<DoSellWeapon>d__.<>1__state = -1;
			<DoSellWeapon>d__.<>t__builder.Start<KurotatoPopupItemDetailView.<DoSellWeapon>d__35>(ref <DoSellWeapon>d__);
			return <DoSellWeapon>d__.<>t__builder.Task;
		}

		// Token: 0x0603AA72 RID: 240242 RVA: 0x00EDCCB0 File Offset: 0x00EDAEB0
		private void OnUpdateWeapon()
		{
			this.SyncWeaponDataAndRefresh(null);
		}

		// Token: 0x0603AA73 RID: 240243 RVA: 0x00EDCCCC File Offset: 0x00EDAECC
		private void OnWeaponRefined(int newWeaponIncId)
		{
			this.SyncWeaponDataAndRefresh(new int?(newWeaponIncId));
		}

		// Token: 0x0603AA74 RID: 240244 RVA: 0x00EDCCDA File Offset: 0x00EDAEDA
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

		// Token: 0x040212BE RID: 135870
		private readonly PopupCaptionItem CaptionItem = new PopupCaptionItem(null);

		// Token: 0x040212BF RID: 135871
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> ItemLayout;

		// Token: 0x040212C0 RID: 135872
		[Nullable(2)]
		private KurotatoWeaponSmallItemGrid SelectItem;

		// Token: 0x040212C1 RID: 135873
		private readonly KurotatoItemInfoTipPanel ItemTip = new KurotatoItemInfoTipPanel();

		// Token: 0x040212C2 RID: 135874
		private readonly ButtonItem BtnComposeItem = new ButtonItem(null);

		// Token: 0x040212C3 RID: 135875
		private readonly ButtonItem BtnSellItem = new ButtonItem(null);

		// Token: 0x040212C4 RID: 135876
		private readonly KurotatoCurrencyItem CurrencyItem = new KurotatoCurrencyItem();

		// Token: 0x040212C5 RID: 135877
		private List<IKurotatoCardTip> CardData = new List<IKurotatoCardTip>();

		// Token: 0x040212C6 RID: 135878
		private List<int> Price = new List<int>();

		// Token: 0x040212C7 RID: 135879
		private int Index;

		// Token: 0x0200BA6D RID: 47725
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04039901 RID: 235777
			Caption,
			// Token: 0x04039902 RID: 235778
			PanelCost,
			// Token: 0x04039903 RID: 235779
			BtnBack,
			// Token: 0x04039904 RID: 235780
			TipItem,
			// Token: 0x04039905 RID: 235781
			HorizontalLayout,
			// Token: 0x04039906 RID: 235782
			WeaponItem,
			// Token: 0x04039907 RID: 235783
			BtnCompose,
			// Token: 0x04039908 RID: 235784
			BtnSell,
			// Token: 0x04039909 RID: 235785
			BtnClose
		}
	}
}
