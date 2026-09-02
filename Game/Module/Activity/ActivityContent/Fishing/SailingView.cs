using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006815 RID: 26645
	public class SailingView : UiViewBase
	{
		// Token: 0x06042690 RID: 272016 RVA: 0x011061DD File Offset: 0x011043DD
		[NullableContext(1)]
		public SailingView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042691 RID: 272017 RVA: 0x011061E8 File Offset: 0x011043E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 8;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBackBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickSkinBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickTimeHelpBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnClickTimeNowToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnClickTimeDayToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickTimeNightToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickDurabilityHelpBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickConfirmBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042692 RID: 272018 RVA: 0x011065E3 File Offset: 0x011047E3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingShipSkinChangeSuccess, new Action(this.FishingShipSkinChangeSuccess));
			Singleton<EventSystem>.Instance.Add(EEventName.FishingShipSkinClick, new Action(this.FishingShipSkinChangeSuccess));
		}

		// Token: 0x06042693 RID: 272019 RVA: 0x0110661D File Offset: 0x0110481D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingShipSkinChangeSuccess, new Action(this.FishingShipSkinChangeSuccess));
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingShipSkinClick, new Action(this.FishingShipSkinChangeSuccess));
		}

		// Token: 0x06042694 RID: 272020 RVA: 0x01106658 File Offset: 0x01104858
		protected override UniTask OnBeforeStartAsync()
		{
			SailingView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SailingView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042695 RID: 272021 RVA: 0x0110669C File Offset: 0x0110489C
		protected override void OnStart()
		{
			ModelBase<FishingModel>.Instance.LocalSailingTime = ESailTime.Now;
			this.CurrentToggle = base.GetExtendToggle(4);
			UUIExtendToggle currentToggle = this.CurrentToggle;
			if (currentToggle != null)
			{
				currentToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, true, false);
			}
			if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.SailingIsFix, false))
			{
				base.GetExtendToggle(14).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
		}

		// Token: 0x06042696 RID: 272022 RVA: 0x011066F2 File Offset: 0x011048F2
		protected override void OnBeforeShow()
		{
			this.RefreshTimeItem();
			this.RefreshSkinItem();
			this.RefreshDurability();
		}

		// Token: 0x06042697 RID: 272023 RVA: 0x01106708 File Offset: 0x01104908
		private void RefreshTimeItem()
		{
			string hourMinuteString = ModelBase<TimeOfDayModel>.Instance.GameTime.HourMinuteString;
			base.GetText(3).SetText(hourMinuteString, true);
			int currentTraceEntrust = ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust;
			if (currentTraceEntrust <= 0)
			{
				base.GetItem(19).SetUIActive(false);
				return;
			}
			FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(currentTraceEntrust);
			bool uiactive = fishingEntrust != null && fishingEntrust.Value.IsNight;
			base.GetItem(19).SetUIActive(uiactive);
		}

		// Token: 0x06042698 RID: 272024 RVA: 0x01106788 File Offset: 0x01104988
		private void RefreshSkinItem()
		{
			int currentSkinId = ModelBase<FishingModel>.Instance.GetShipData().GetCurrentSkinId();
			FishingShipSkin fishingShipSkinConfig = ConfigBase<FishingConfig>.Instance.GetFishingShipSkinConfig(currentSkinId);
			base.SetTextureByPath(fishingShipSkinConfig.IconTexture, base.GetTexture(8), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), fishingShipSkinConfig.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), fishingShipSkinConfig.DesText, Array.Empty<object>());
			foreach (int value in ModelBase<FishingModel>.Instance.UnlockShipSkin)
			{
				if (!ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.FishingShipSkinRecord, value))
				{
					base.GetItem(18).SetUIActive(true);
					return;
				}
			}
			base.GetItem(18).SetUIActive(false);
		}

		// Token: 0x06042699 RID: 272025 RVA: 0x01106880 File Offset: 0x01104A80
		private void RefreshDurability()
		{
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			float currentHp = shipData.GetCurrentHp();
			float maxHp = shipData.GetMaxHp();
			base.GetText(12).SetText(currentHp.ToString() + "/" + maxHp.ToString(), true);
			base.SetTextureByPath(ConfigBase<ItemConfig>.Instance.GetConfig(ModelBase<FishingModel>.Instance.FishingShipFixItem).Value.IconSmall, base.GetTexture(16), null, null);
			int fishingShipFixCost = ModelBase<FishingModel>.Instance.FishingShipFixCost;
			float num = (maxHp - currentHp) * (float)fishingShipFixCost;
			base.GetText(13).SetText(num.ToString() ?? "", true);
		}

		// Token: 0x0604269A RID: 272026 RVA: 0x01106939 File Offset: 0x01104B39
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0604269B RID: 272027 RVA: 0x01106942 File Offset: 0x01104B42
		private void OnClickSkinBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipSkinView, null, null);
		}

		// Token: 0x0604269C RID: 272028 RVA: 0x01106955 File Offset: 0x01104B55
		private void OnClickTimeHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(185);
		}

		// Token: 0x0604269D RID: 272029 RVA: 0x01106966 File Offset: 0x01104B66
		private void OnClickDurabilityHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(186);
		}

		// Token: 0x0604269E RID: 272030 RVA: 0x01106977 File Offset: 0x01104B77
		private void OnClickTimeNowToggle(EToggleState toggleState)
		{
			UUIExtendToggle currentToggle = this.CurrentToggle;
			if (currentToggle != null)
			{
				currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentToggle = base.GetExtendToggle(4);
			ModelBase<FishingModel>.Instance.LocalSailingTime = ESailTime.Now;
		}

		// Token: 0x0604269F RID: 272031 RVA: 0x011069A7 File Offset: 0x01104BA7
		private void OnClickTimeDayToggle(EToggleState toggleState)
		{
			UUIExtendToggle currentToggle = this.CurrentToggle;
			if (currentToggle != null)
			{
				currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentToggle = base.GetExtendToggle(5);
			ModelBase<FishingModel>.Instance.LocalSailingTime = ESailTime.Day;
		}

		// Token: 0x060426A0 RID: 272032 RVA: 0x011069D7 File Offset: 0x01104BD7
		private void OnClickTimeNightToggle(EToggleState toggleState)
		{
			UUIExtendToggle currentToggle = this.CurrentToggle;
			if (currentToggle != null)
			{
				currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentToggle = base.GetExtendToggle(6);
			ModelBase<FishingModel>.Instance.LocalSailingTime = ESailTime.Night;
		}

		// Token: 0x060426A1 RID: 272033 RVA: 0x01106A08 File Offset: 0x01104C08
		private void OnClickConfirmBtn()
		{
			bool isAutoFix = base.GetExtendToggle(14).ToggleState == EToggleState.ETT_Checked;
			int currentTraceEntrust = ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust;
			FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(currentTraceEntrust);
			if (fishingEntrust != null && fishingEntrust.Value.IsNight && (ModelBase<FishingModel>.Instance.LocalSailingTime == ESailTime.Day || (ModelBase<FishingModel>.Instance.LocalSailingTime == ESailTime.Now && !ModelBase<FishingQuestModel>.Instance.IsInNight())))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FishingNightTraceSailingInDay);
				confirmBoxDataNew.FunctionMap.Add(1, delegate
				{
					ControllerBase<FishingController>.Instance.RequestFishingSailingRequest(isAutoFix, ModelBase<FishingModel>.Instance.DockId, (int)ModelBase<FishingModel>.Instance.LocalSailingTime);
				});
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ControllerBase<FishingController>.Instance.RequestFishingSailingRequest(isAutoFix, ModelBase<FishingModel>.Instance.DockId, 2);
				});
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<FishingController>.Instance.RequestFishingSailingRequest(isAutoFix, ModelBase<FishingModel>.Instance.DockId, (int)ModelBase<FishingModel>.Instance.LocalSailingTime);
		}

		// Token: 0x060426A2 RID: 272034 RVA: 0x01106B02 File Offset: 0x01104D02
		private void FishingShipSkinChangeSuccess()
		{
			this.RefreshSkinItem();
		}

		// Token: 0x04024FA6 RID: 151462
		[Nullable(2)]
		private UUIExtendToggle CurrentToggle;

		// Token: 0x0200C848 RID: 51272
		private class EComponentDefine
		{
			// Token: 0x0403DA13 RID: 252435
			public const int TitleText = 0;

			// Token: 0x0403DA14 RID: 252436
			public const int BackBtn = 1;

			// Token: 0x0403DA15 RID: 252437
			public const int TimeHelpBtn = 2;

			// Token: 0x0403DA16 RID: 252438
			public const int TimeText = 3;

			// Token: 0x0403DA17 RID: 252439
			public const int TimeNowToggle = 4;

			// Token: 0x0403DA18 RID: 252440
			public const int TimeDayToggle = 5;

			// Token: 0x0403DA19 RID: 252441
			public const int TimeNightToggle = 6;

			// Token: 0x0403DA1A RID: 252442
			public const int SkinBtn = 7;

			// Token: 0x0403DA1B RID: 252443
			public const int SkinTexture = 8;

			// Token: 0x0403DA1C RID: 252444
			public const int SkinNameText = 9;

			// Token: 0x0403DA1D RID: 252445
			public const int SkinEffectText = 10;

			// Token: 0x0403DA1E RID: 252446
			public const int DurabilityHelpBtn = 11;

			// Token: 0x0403DA1F RID: 252447
			public const int DurabilityText = 12;

			// Token: 0x0403DA20 RID: 252448
			public const int DurabilityFixText = 13;

			// Token: 0x0403DA21 RID: 252449
			public const int AutoFixToggle = 14;

			// Token: 0x0403DA22 RID: 252450
			public const int ConfirmBtn = 15;

			// Token: 0x0403DA23 RID: 252451
			public const int FixItemTexture = 16;

			// Token: 0x0403DA24 RID: 252452
			public const int FishingCurrencyItem = 17;

			// Token: 0x0403DA25 RID: 252453
			public const int SkinRedDotItem = 18;

			// Token: 0x0403DA26 RID: 252454
			public const int NightItem = 19;
		}
	}
}
