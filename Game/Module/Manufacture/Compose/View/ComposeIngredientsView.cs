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

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059C9 RID: 22985
	public class ComposeIngredientsView : UiPanelBase
	{
		// Token: 0x0603A3AC RID: 238508 RVA: 0x00EC0FB4 File Offset: 0x00EBF1B4
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

		// Token: 0x0603A3AD RID: 238509 RVA: 0x00EC1120 File Offset: 0x00EBF320
		protected override UniTask OnBeforeStartAsync()
		{
			ComposeIngredientsView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComposeIngredientsView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A3AE RID: 238510 RVA: 0x00EC1164 File Offset: 0x00EBF364
		private void OnClickConfirmButton()
		{
			if (base.GetButton(3).IsSelfInteractive)
			{
				Singleton<CommonManager>.Instance.SendManufacture(this.ComposeItemData.ConfigId, this.VerticalTextView.GetManufactureCount());
				return;
			}
			ControllerBase<ComposeController>.Instance.PlayCompositeFailDisplay(delegate
			{
				ControllerBase<ComposeController>.Instance.PlayCompositeLoopDisplay();
			});
		}

		// Token: 0x0603A3AF RID: 238511 RVA: 0x00EC11CC File Offset: 0x00EBF3CC
		protected override void OnStart()
		{
			this.VerticalTextView.BindChangeClickCall(new Action(this.OnClickChangeRole));
			this.AddEventListener();
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "ComposeButtonText", Array.Empty<object>());
			base.GetButton(3).SetCanClickWhenDisable(true);
		}

		// Token: 0x0603A3B0 RID: 238512 RVA: 0x00EC121E File Offset: 0x00EBF41E
		private void OnClickChangeRole()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenHelpRole, this.ComposeItemData.ConfigId);
		}

		// Token: 0x0603A3B1 RID: 238513 RVA: 0x00EC123B File Offset: 0x00EBF43B
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0603A3B2 RID: 238514 RVA: 0x00EC1244 File Offset: 0x00EBF444
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.CloseHelpRole, new Action(this.RefreshProficiencyAndHelpRoleWithCurrent));
			Singleton<EventSystem>.Instance.Add(EEventName.UpgradeComposeLevel, new Action(this.RefreshProficiencyAndHelpRoleWithCurrent));
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeSuccess, new Action(this.RefreshCurrentView));
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeFail, new Action(this.RefreshCurrentView));
		}

		// Token: 0x0603A3B3 RID: 238515 RVA: 0x00EC12C4 File Offset: 0x00EBF4C4
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseHelpRole, new Action(this.RefreshProficiencyAndHelpRoleWithCurrent));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpgradeComposeLevel, new Action(this.RefreshProficiencyAndHelpRoleWithCurrent));
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeSuccess, new Action(this.RefreshCurrentView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeFail, new Action(this.RefreshCurrentView));
		}

		// Token: 0x0603A3B4 RID: 238516 RVA: 0x00EC1341 File Offset: 0x00EBF541
		private void RefreshProficiencyAndHelpRoleWithCurrent()
		{
			if (this.ComposeItemData.MainType == EComposeListType.ReagentProduction)
			{
				this.VerticalTextView.RefreshProficiencyAndHelpRole((IReagentProductionData)this.ComposeItemData);
				return;
			}
			this.VerticalTextView.RefreshHelpRole();
		}

		// Token: 0x0603A3B5 RID: 238517 RVA: 0x00EC1373 File Offset: 0x00EBF573
		private void RefreshCurrentView()
		{
			this.RefreshTips(this.ComposeItemData);
		}

		// Token: 0x0603A3B6 RID: 238518 RVA: 0x00EC1381 File Offset: 0x00EBF581
		public void OnSecondTimerRefresh()
		{
			if (this.ComposeItemData == null)
			{
				return;
			}
			ComposeIngredientsVerticalView verticalTextView = this.VerticalTextView;
			if (verticalTextView == null)
			{
				return;
			}
			verticalTextView.OnSecondTimerRefresh();
		}

		// Token: 0x0603A3B7 RID: 238519 RVA: 0x00EC139C File Offset: 0x00EBF59C
		[NullableContext(1)]
		public void RefreshTips(IBaseItemData data)
		{
			this.ComposeItemData = data;
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
			string itemName = ConfigBase<ItemConfig>.Instance.GetItemName(synthesisFormulaById.Value.ItemId);
			base.GetText(0).SetText(itemName, true);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(synthesisFormulaById.Value.ItemId, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "Have", new <>z__ReadOnlySingleElementList<object>(commonItemCount));
			this.CheckCanInteractConfirm();
			switch (this.ComposeItemData.MainType)
			{
			case EComposeListType.ReagentProduction:
				this.RefreshReagentProduction();
				return;
			case EComposeListType.Structure:
				this.RefreshStructure();
				return;
			case EComposeListType.Purification:
				this.RefreshPurification();
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A3B8 RID: 238520 RVA: 0x00EC1464 File Offset: 0x00EBF664
		private void CheckCanInteractConfirm()
		{
			ComposeModel instance = ModelBase<ComposeModel>.Instance;
			bool flag = instance.CheckComposeMaterialEnough(this.ComposeItemData.ConfigId);
			bool flag2 = instance.CheckUnlock(this.ComposeItemData);
			bool isCoinEnough = instance.CheckCoinEnough(this.ComposeItemData.ConfigId);
			bool flag3 = instance.CheckLimitCount(this.ComposeItemData);
			base.GetText(7).SetText(this.GetDisableText(flag2, flag, isCoinEnough, flag3), true);
			base.GetItem(6).SetUIActive(!flag2 || !flag || !flag3);
			base.GetButton(3).RootUIComp.Get().SetUIActive(flag2 && flag && flag3);
		}

		// Token: 0x0603A3B9 RID: 238521 RVA: 0x00EC1508 File Offset: 0x00EBF708
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
						ConfigBase<ItemConfig>.Instance.GetItemName(ControllerBase<ComposeController>.Instance.ComposeCoinId)
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
				string refreshLimitTime = ModelBase<ComposeModel>.Instance.GetRefreshLimitTime();
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

		// Token: 0x0603A3BA RID: 238522 RVA: 0x00EC15B3 File Offset: 0x00EBF7B3
		private void RefreshReagentProduction()
		{
			this.VerticalTextView.RefreshReagentProduction((IReagentProductionData)this.ComposeItemData);
		}

		// Token: 0x0603A3BB RID: 238523 RVA: 0x00EC15CB File Offset: 0x00EBF7CB
		private void RefreshStructure()
		{
			this.VerticalTextView.RefreshStructure((IStructureData)this.ComposeItemData);
		}

		// Token: 0x0603A3BC RID: 238524 RVA: 0x00EC15E3 File Offset: 0x00EBF7E3
		private void RefreshPurification()
		{
			this.VerticalTextView.RefreshPurification((IPurificationData)this.ComposeItemData);
		}

		// Token: 0x0402101C RID: 135196
		[Nullable(2)]
		private IBaseItemData ComposeItemData;

		// Token: 0x0402101D RID: 135197
		[Nullable(2)]
		private ComposeIngredientsVerticalView VerticalTextView;

		// Token: 0x0200B997 RID: 47511
		private class EComposeIngredientsDefine
		{
			// Token: 0x04039584 RID: 234884
			public const int TxtName = 0;

			// Token: 0x04039585 RID: 234885
			public const int TxtHaveNum = 1;

			// Token: 0x04039586 RID: 234886
			public const int PanelBuy = 2;

			// Token: 0x04039587 RID: 234887
			public const int BtnConfirm = 3;

			// Token: 0x04039588 RID: 234888
			public const int PanelVertical = 4;

			// Token: 0x04039589 RID: 234889
			public const int TxtConfirm = 5;

			// Token: 0x0403958A RID: 234890
			public const int PnlActivate = 6;

			// Token: 0x0403958B RID: 234891
			public const int TxtActivate = 7;
		}
	}
}
