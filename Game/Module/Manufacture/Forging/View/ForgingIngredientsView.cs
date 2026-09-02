using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Forging.View
{
	// Token: 0x020059AF RID: 22959
	public class ForgingIngredientsView : UiPanelBase
	{
		// Token: 0x0603A1EF RID: 238063 RVA: 0x00EB622C File Offset: 0x00EB442C
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

		// Token: 0x0603A1F0 RID: 238064 RVA: 0x00EB6398 File Offset: 0x00EB4598
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.CloseHelpRole, new Action(this.RefreshHelpRole));
			Singleton<EventSystem>.Instance.Add(EEventName.ForgingSuccess, new Action(this.RefreshCurrentView));
			Singleton<EventSystem>.Instance.Add(EEventName.ForgingFail, new Action(this.RefreshCurrentView));
		}

		// Token: 0x0603A1F1 RID: 238065 RVA: 0x00EB63FC File Offset: 0x00EB45FC
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseHelpRole, new Action(this.RefreshHelpRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.ForgingSuccess, new Action(this.RefreshCurrentView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ForgingFail, new Action(this.RefreshCurrentView));
		}

		// Token: 0x0603A1F2 RID: 238066 RVA: 0x00EB645D File Offset: 0x00EB465D
		private void RefreshCurrentView()
		{
			this.RefreshTips(this.ForgingItemData);
		}

		// Token: 0x0603A1F3 RID: 238067 RVA: 0x00EB646B File Offset: 0x00EB466B
		private void RefreshHelpRole()
		{
			this.VerticalTextView.RefreshHelpRole();
		}

		// Token: 0x0603A1F4 RID: 238068 RVA: 0x00EB6478 File Offset: 0x00EB4678
		protected override UniTask OnBeforeStartAsync()
		{
			ForgingIngredientsView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ForgingIngredientsView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A1F5 RID: 238069 RVA: 0x00EB64BB File Offset: 0x00EB46BB
		protected override void OnStart()
		{
			this.AddEventListener();
			this.VerticalTextView.BindChangeClickCall(new Action(this.OnClickChangeRole));
			base.GetButton(3).SetCanClickWhenDisable(true);
		}

		// Token: 0x0603A1F6 RID: 238070 RVA: 0x00EB64E7 File Offset: 0x00EB46E7
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
			this.VerticalTextView.Destroy(null);
		}

		// Token: 0x0603A1F7 RID: 238071 RVA: 0x00EB64FC File Offset: 0x00EB46FC
		private void OnClickConfirmButton()
		{
			if (!base.GetButton(3).IsSelfInteractive)
			{
				ControllerBase<ForgingController>.Instance.PlayForgingFailDisplay(delegate
				{
					ControllerBase<ForgingController>.Instance.PlayForgingLoopDisplay();
				});
				return;
			}
			if (this.ForgingItemData.IsUnlock == 0)
			{
				ControllerBase<ForgingController>.Instance.SendForgeFormulaUnlockRequest(this.ForgingItemData.ItemId);
				return;
			}
			Singleton<CommonManager>.Instance.SendManufacture(this.ForgingItemData.ItemId, this.VerticalTextView.GetManufactureCount());
		}

		// Token: 0x0603A1F8 RID: 238072 RVA: 0x00EB6584 File Offset: 0x00EB4784
		private void OnClickChangeRole()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenHelpRole, this.ForgingItemData.ItemId);
		}

		// Token: 0x0603A1F9 RID: 238073 RVA: 0x00EB65A1 File Offset: 0x00EB47A1
		public void OnSecondTimerRefresh()
		{
			if (this.ForgingItemData == null)
			{
				return;
			}
			ForgingIngredientsVerticalView verticalTextView = this.VerticalTextView;
			if (verticalTextView == null)
			{
				return;
			}
			verticalTextView.OnSecondTimerRefresh();
		}

		// Token: 0x0603A1FA RID: 238074 RVA: 0x00EB65BC File Offset: 0x00EB47BC
		[NullableContext(1)]
		public void RefreshTips(IWeaponForgingData data)
		{
			this.ForgingItemData = data;
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(data.ItemId);
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(forgeFormulaById.Value.ItemId);
			base.GetText(0).ShowTextNew(((weaponConfigByItemId != null) ? weaponConfigByItemId.GetValueOrDefault().WeaponName : null) ?? "");
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(forgeFormulaById.Value.ItemId, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "Have", new <>z__ReadOnlySingleElementList<object>(itemCountByConfigId));
			this.VerticalTextView.RefreshForging(this.ForgingItemData);
			this.CheckCanInteractConfirm();
		}

		// Token: 0x0603A1FB RID: 238075 RVA: 0x00EB6680 File Offset: 0x00EB4880
		private void CheckCanInteractConfirm()
		{
			bool flag = true;
			ForgingModel instance = ModelBase<ForgingModel>.Instance;
			bool flag2 = instance.CheckUnlock(this.ForgingItemData);
			bool isCoinEnough = instance.CheckCoinEnough(this.ForgingItemData.ItemId);
			bool flag3 = instance.CheckLimitCount(this.ForgingItemData);
			string textById;
			if (flag2)
			{
				textById = ConfigBase<TextConfig>.Instance.GetTextById("WeaponMaking");
				flag = instance.CheckMaterialEnough(this.ForgingItemData.ItemId);
				base.GetItem(2).SetUIActive(true);
			}
			else
			{
				textById = ConfigBase<TextConfig>.Instance.GetTextById("UnlockWeapon");
				base.GetItem(2).SetUIActive(false);
			}
			base.GetText(5).SetText(textById, true);
			base.GetText(7).SetText(this.GetDisableText(flag2, flag, isCoinEnough, flag3), true);
			base.GetItem(6).SetUIActive(!flag2 || !flag || !flag3);
			base.GetButton(3).RootUIComp.Get().SetUIActive(flag2 && flag && flag3);
		}

		// Token: 0x0603A1FC RID: 238076 RVA: 0x00EB6778 File Offset: 0x00EB4978
		[NullableContext(1)]
		private string GetDisableText(bool isUnlock, bool isMatEnough, bool isCoinEnough, bool isMakeCountEnough)
		{
			if (!isUnlock)
			{
				return ConfigMultiTextLang.GetLocalTextNew("GenericPrompt_Unlocked_TipsText", null);
			}
			if (!isMatEnough)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("LackMakeMaterial", null);
				if (!isCoinEnough)
				{
					return StringUtils.Format(localTextNew, new string[]
					{
						ConfigBase<ItemConfig>.Instance.GetItemName(ControllerBase<ForgingController>.Instance.ForgingCostId)
					});
				}
				return StringUtils.Format(localTextNew, new string[]
				{
					ConfigMultiTextLang.GetLocalTextNew("Material_Text", null)
				});
			}
			else
			{
				if (isMakeCountEnough)
				{
					return "";
				}
				string refreshLimitTime = ModelBase<ForgingModel>.Instance.GetRefreshLimitTime();
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

		// Token: 0x04020F6E RID: 135022
		[Nullable(2)]
		private IWeaponForgingData ForgingItemData;

		// Token: 0x04020F6F RID: 135023
		[Nullable(2)]
		private ForgingIngredientsVerticalView VerticalTextView;

		// Token: 0x0200B96E RID: 47470
		public class EForgingIngredientsDefine
		{
			// Token: 0x04039466 RID: 234598
			public const int TxtName = 0;

			// Token: 0x04039467 RID: 234599
			public const int TxtHaveNum = 1;

			// Token: 0x04039468 RID: 234600
			public const int PanelBuy = 2;

			// Token: 0x04039469 RID: 234601
			public const int BtnConfirm = 3;

			// Token: 0x0403946A RID: 234602
			public const int PanelVertical = 4;

			// Token: 0x0403946B RID: 234603
			public const int TxtConfirm = 5;

			// Token: 0x0403946C RID: 234604
			public const int PnlActivate = 6;

			// Token: 0x0403946D RID: 234605
			public const int TxtActivate = 7;
		}
	}
}
