using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E0E RID: 24078
	[NullableContext(1)]
	[Nullable(0)]
	public class CookingIngredientsView : UiPanelBase
	{
		// Token: 0x0603C96A RID: 248170 RVA: 0x00F62490 File Offset: 0x00F60690
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C96B RID: 248171 RVA: 0x00F625FC File Offset: 0x00F607FC
		private void OnClickConfirmButton()
		{
			if (!base.GetButton(3).GetSelfInteractive())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("MaterialShort", Array.Empty<object>());
				return;
			}
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				ModelBase<CookModel>.Instance.CleanAddExp();
				ControllerBase<CookController>.Instance.SendCookFoodRequest(this.CookingItemData.ItemId, ModelBase<CookModel>.Instance.CurrentCookRoleId.Value, this.VerticalTextView.CurrentSetCount);
				return;
			}
			ControllerBase<CookController>.Instance.SendFoodProcessRequest(this.MachiningItemData.ItemId, ModelBase<CookModel>.Instance.GetTmpMachiningItemList(), this.VerticalTextView.CurrentSetCount);
		}

		// Token: 0x0603C96C RID: 248172 RVA: 0x00F626A0 File Offset: 0x00F608A0
		protected override UniTask OnBeforeStartAsync()
		{
			CookingIngredientsView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CookingIngredientsView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C96D RID: 248173 RVA: 0x00F626E3 File Offset: 0x00F608E3
		protected override void OnStart()
		{
			this.VerticalTextView.OnChangeMaterialSelectionDelegate = new Action(this.OnChangeMaterialSelection);
			base.GetButton(3).SetCanClickWhenDisable(true);
		}

		// Token: 0x0603C96E RID: 248174 RVA: 0x00F62709 File Offset: 0x00F60909
		public void RefreshTips(ICookingData itemData)
		{
			this.CookingItemData = itemData;
			this.MachiningItemData = null;
			this.RefreshCommon();
			this.RefreshCooking();
		}

		// Token: 0x0603C96F RID: 248175 RVA: 0x00F62725 File Offset: 0x00F60925
		public void RefreshTips(IMachiningData itemData)
		{
			this.MachiningItemData = itemData;
			this.CookingItemData = null;
			this.RefreshCommon();
			this.RefreshMachining();
		}

		// Token: 0x0603C970 RID: 248176 RVA: 0x00F62741 File Offset: 0x00F60941
		public void OnSecondTimerRefresh()
		{
			if (this.CookingItemData == null && this.MachiningItemData == null)
			{
				return;
			}
			CookingIngredientsVerticalView verticalTextView = this.VerticalTextView;
			if (verticalTextView == null)
			{
				return;
			}
			verticalTextView.OnSecondTimerRefresh();
		}

		// Token: 0x0603C971 RID: 248177 RVA: 0x00F62764 File Offset: 0x00F60964
		public void RefreshTipsWithSavedData()
		{
			if (this.CookingItemData != null)
			{
				this.RefreshTips(this.CookingItemData);
				return;
			}
			if (this.MachiningItemData != null)
			{
				this.RefreshTips(this.MachiningItemData);
			}
		}

		// Token: 0x0603C972 RID: 248178 RVA: 0x00F6278F File Offset: 0x00F6098F
		private void RefreshCommon()
		{
			this.RefreshName();
		}

		// Token: 0x0603C973 RID: 248179 RVA: 0x00F62798 File Offset: 0x00F60998
		private void RefreshName()
		{
			if (this.CookingItemData != null)
			{
				CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(this.CookingItemData.ItemId);
				string newText = ConfigBase<ItemConfig>.Instance.GetItemName(cookFormulaById.FoodItemId) ?? "";
				base.GetText(0).SetText(newText, true);
				return;
			}
			if (this.MachiningItemData != null)
			{
				CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(this.MachiningItemData.ItemId);
				string newText2 = ConfigBase<ItemConfig>.Instance.GetItemName(cookProcessedById.FinalItemId) ?? "";
				base.GetText(0).SetText(newText2, true);
			}
		}

		// Token: 0x0603C974 RID: 248180 RVA: 0x00F62834 File Offset: 0x00F60A34
		private void OnChangeMaterialSelection()
		{
			this.CheckCanInteractConfirm();
		}

		// Token: 0x0603C975 RID: 248181 RVA: 0x00F6283C File Offset: 0x00F60A3C
		private void RefreshMachining()
		{
			CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(this.MachiningItemData.ItemId);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(cookProcessedById.FinalItemId, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "Have", new <>z__ReadOnlySingleElementList<object>(commonItemCount));
			this.VerticalTextView.RefreshMachining(this.MachiningItemData);
			this.CheckCanInteractConfirm();
			if (this.MachiningItemData.IsUnLock)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "CookButtonText", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "Research", Array.Empty<object>());
		}

		// Token: 0x0603C976 RID: 248182 RVA: 0x00F628F0 File Offset: 0x00F60AF0
		public void RefreshCooking()
		{
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(this.CookingItemData.ItemId);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(cookFormulaById.FoodItemId, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "Have", new <>z__ReadOnlySingleElementList<object>(commonItemCount));
			this.VerticalTextView.RefreshCooking(this.CookingItemData);
			this.CheckCanInteractConfirm();
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "CookButtonText", Array.Empty<object>());
		}

		// Token: 0x0603C977 RID: 248183 RVA: 0x00F6297C File Offset: 0x00F60B7C
		private void CheckCanInteractConfirm()
		{
			ICookingData cookingItemData = this.CookingItemData;
			bool flag;
			if (cookingItemData == null)
			{
				IMachiningData machiningItemData = this.MachiningItemData;
				flag = (machiningItemData != null && machiningItemData.IsUnLock);
			}
			else
			{
				flag = cookingItemData.IsUnLock;
			}
			bool flag2 = flag;
			bool isCoinEnough = true;
			bool flag3 = true;
			bool flag4;
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				flag4 = ModelBase<CookModel>.Instance.CheckMaterialEnough(this.CookingItemData.ItemId);
				isCoinEnough = ModelBase<CookModel>.Instance.CheckCoinEnough(this.CookingItemData.ItemId);
				flag3 = ModelBase<CookModel>.Instance.CheckLimitCount(this.CookingItemData.ItemId);
			}
			else
			{
				bool flag5 = true;
				using (List<ISingleItemInfo>.Enumerator enumerator = ModelBase<CookModel>.Instance.GetTmpMachiningItemList().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (!enumerator.Current.Proto_IsUnlock)
						{
							flag5 = false;
						}
					}
				}
				flag4 = (ModelBase<CookModel>.Instance.CheckCanProcessedNew(this.MachiningItemData.ItemId) && flag5);
			}
			base.GetText(7).SetText(this.GetDisableText(flag2, flag4, isCoinEnough, flag3), true);
			base.GetItem(6).SetUIActive(!flag4 || !flag3 || !flag2);
			base.GetButton(3).GetRootComponent().SetUIActive(flag4 && flag3 && flag2);
		}

		// Token: 0x0603C978 RID: 248184 RVA: 0x00F62AB0 File Offset: 0x00F60CB0
		private string GetDisableText(bool isUnlock, bool isEnable, bool isCoinEnough, bool isCookCountEnough)
		{
			if (!isUnlock)
			{
				return ConfigMultiTextLang.GetLocalTextNew("GenericPrompt_Unlocked_TipsText", null);
			}
			if (!isEnable)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("LackMakeMaterial", null);
				if (!isCoinEnough)
				{
					return StringUtils.Format(localTextNew, new string[]
					{
						ConfigBase<ItemConfig>.Instance.GetItemName(ControllerBase<CookController>.Instance.CookCoinId)
					});
				}
				return StringUtils.Format(localTextNew, new string[]
				{
					ConfigMultiTextLang.GetLocalTextNew("Material_Text", null)
				});
			}
			else
			{
				if (isCookCountEnough)
				{
					return "";
				}
				string refreshLimitTime = ModelBase<CookModel>.Instance.GetRefreshLimitTime();
				if (refreshLimitTime != null)
				{
					return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("LackMakeCount", null), new string[]
					{
						refreshLimitTime
					});
				}
				return ConfigMultiTextLang.GetLocalTextNew("LackMakeCountWithoutTime", null);
			}
		}

		// Token: 0x040220DB RID: 139483
		[Nullable(2)]
		private ICookingData CookingItemData;

		// Token: 0x040220DC RID: 139484
		[Nullable(2)]
		private IMachiningData MachiningItemData;

		// Token: 0x040220DD RID: 139485
		[Nullable(2)]
		private CookingIngredientsVerticalView VerticalTextView;

		// Token: 0x0200BE47 RID: 48711
		[NullableContext(0)]
		private enum ECookIngredientsDefine
		{
			// Token: 0x0403A945 RID: 239941
			TxtName,
			// Token: 0x0403A946 RID: 239942
			TxtHaveNum,
			// Token: 0x0403A947 RID: 239943
			PanelBuy,
			// Token: 0x0403A948 RID: 239944
			BtnConfirm,
			// Token: 0x0403A949 RID: 239945
			PanelVertical,
			// Token: 0x0403A94A RID: 239946
			TxtConfirm,
			// Token: 0x0403A94B RID: 239947
			PnlActivate,
			// Token: 0x0403A94C RID: 239948
			TxtActivate
		}
	}
}
