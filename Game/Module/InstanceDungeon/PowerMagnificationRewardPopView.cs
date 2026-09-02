using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD4 RID: 23508
	[NullableContext(2)]
	[Nullable(0)]
	public class PowerMagnificationRewardPopView : UiViewBase
	{
		// Token: 0x0603B851 RID: 243793 RVA: 0x00F16F20 File Offset: 0x00F15120
		[NullableContext(1)]
		public PowerMagnificationRewardPopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B852 RID: 243794 RVA: 0x00F16F2C File Offset: 0x00F1512C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnHelpButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B853 RID: 243795 RVA: 0x00F17078 File Offset: 0x00F15278
		protected override UniTask OnBeforeStartAsync()
		{
			PowerMagnificationRewardPopView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PowerMagnificationRewardPopView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B854 RID: 243796 RVA: 0x00F170BB File Offset: 0x00F152BB
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPowerChanged, new Action(this.OnPowerChange));
		}

		// Token: 0x0603B855 RID: 243797 RVA: 0x00F170D9 File Offset: 0x00F152D9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPowerChanged, new Action(this.OnPowerChange));
		}

		// Token: 0x0603B856 RID: 243798 RVA: 0x00F170F8 File Offset: 0x00F152F8
		protected override void OnBeforeShow()
		{
			PowerCurrencyItem overPowerCurrencyItem = this.OverPowerCurrencyItem;
			if (overPowerCurrencyItem != null)
			{
				UUIItem originalItem = overPowerCurrencyItem.GetOriginalItem();
				if (originalItem != null)
				{
					IUiPopFrameInterface childPopView = this.ChildPopView;
					UUIItem inParent;
					if (childPopView == null)
					{
						inParent = null;
					}
					else
					{
						CommonPopViewBase popItem = childPopView.PopItem;
						inParent = ((popItem != null) ? popItem.GetCostParent() : null);
					}
					originalItem.SetUIParent(inParent, false);
				}
			}
			PowerCurrencyItem powerCurrencyItem = this.PowerCurrencyItem;
			if (powerCurrencyItem != null)
			{
				UUIItem originalItem2 = powerCurrencyItem.GetOriginalItem();
				if (originalItem2 != null)
				{
					IUiPopFrameInterface childPopView2 = this.ChildPopView;
					UUIItem inParent2;
					if (childPopView2 == null)
					{
						inParent2 = null;
					}
					else
					{
						CommonPopViewBase popItem2 = childPopView2.PopItem;
						inParent2 = ((popItem2 != null) ? popItem2.GetCostParent() : null);
					}
					originalItem2.SetUIParent(inParent2, false);
				}
			}
			this.PowerCurrencyItem.ShowWithoutText(5);
			PowerCurrencyItem powerCurrencyItem2 = this.PowerCurrencyItem;
			if (powerCurrencyItem2 == null)
			{
				return;
			}
			powerCurrencyItem2.SetButtonFunction(delegate(int _)
			{
				ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, 0);
			});
		}

		// Token: 0x0603B857 RID: 243799 RVA: 0x00F171B6 File Offset: 0x00F153B6
		private void OnPowerChange()
		{
			PowerRewardButtonItem singleButtonItem = this.SingleButtonItem;
			if (singleButtonItem != null)
			{
				singleButtonItem.RefreshPowerState();
			}
			PowerRewardButtonItem doubleButtonItem = this.DoubleButtonItem;
			if (doubleButtonItem == null)
			{
				return;
			}
			doubleButtonItem.RefreshPowerState();
		}

		// Token: 0x0603B858 RID: 243800 RVA: 0x00F171D9 File Offset: 0x00F153D9
		private void OnHelpButtonClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(128);
		}

		// Token: 0x0603B859 RID: 243801 RVA: 0x00F171EC File Offset: 0x00F153EC
		private UniTask InitCurrency()
		{
			PowerMagnificationRewardPopView.<InitCurrency>d__15 <InitCurrency>d__;
			<InitCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurrency>d__.<>4__this = this;
			<InitCurrency>d__.<>1__state = -1;
			<InitCurrency>d__.<>t__builder.Start<PowerMagnificationRewardPopView.<InitCurrency>d__15>(ref <InitCurrency>d__);
			return <InitCurrency>d__.<>t__builder.Task;
		}

		// Token: 0x0603B85A RID: 243802 RVA: 0x00F17230 File Offset: 0x00F15430
		private bool RewardByCount(int count)
		{
			if (this.Data == null)
			{
				return false;
			}
			int value = count * this.Data.SinglePowerCost;
			if (!ModelBase<PowerModel>.Instance.IsPowerEnough(new int?(value)))
			{
				string textById = ConfigBase<TextConfig>.Instance.GetTextById("ReceiveLevelPlayPowerNotEnough");
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
				ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, ModelBase<PowerModel>.Instance.GetCurrentNeedPower(new int?(value)));
				return false;
			}
			this.Data.RewardCallBack(count);
			base.CloseMe(null);
			return true;
		}

		// Token: 0x0603B85B RID: 243803 RVA: 0x00F172B8 File Offset: 0x00F154B8
		protected override void OnBeforeDestroy()
		{
			PowerMagnificationRewardPopViewData data = this.Data;
			if (data != null && data.NeedResetLevelPlayModelRewardFlag.GetValueOrDefault())
			{
				ModelBase<LevelPlayModel>.Instance.IsInReceiveReward = false;
			}
			PowerMagnificationRewardPopViewData data2 = this.Data;
			if (data2 == null)
			{
				return;
			}
			Action closeCallBack = data2.CloseCallBack;
			if (closeCallBack == null)
			{
				return;
			}
			closeCallBack();
		}

		// Token: 0x04021852 RID: 137298
		private PowerMagnificationRewardPopViewData Data;

		// Token: 0x04021853 RID: 137299
		private PowerCurrencyItem PowerCurrencyItem;

		// Token: 0x04021854 RID: 137300
		private PowerCurrencyItem OverPowerCurrencyItem;

		// Token: 0x04021855 RID: 137301
		private PowerRewardButtonItem SingleButtonItem;

		// Token: 0x04021856 RID: 137302
		private PowerRewardButtonItem DoubleButtonItem;

		// Token: 0x04021857 RID: 137303
		private const int POWER_MAGIFICATION_REWARD_HELPID = 128;

		// Token: 0x0200BC3F RID: 48191
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x0403A0F5 RID: 237813
			public const int TitleText = 0;

			// Token: 0x0403A0F6 RID: 237814
			public const int ContentText = 1;

			// Token: 0x0403A0F7 RID: 237815
			public const int LeftButtonItem = 2;

			// Token: 0x0403A0F8 RID: 237816
			public const int RightButtonItem = 3;

			// Token: 0x0403A0F9 RID: 237817
			public const int HelpButton = 4;

			// Token: 0x0403A0FA RID: 237818
			public const int DoubleCountItem = 5;

			// Token: 0x0403A0FB RID: 237819
			public const int DoubleCountText = 6;
		}
	}
}
