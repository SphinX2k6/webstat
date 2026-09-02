using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006789 RID: 26505
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingRewardLimitTimeButton : UiPanelBase
	{
		// Token: 0x06042121 RID: 270625 RVA: 0x010F399F File Offset: 0x010F1B9F
		public FishingRewardLimitTimeButton(ActivityFishingData data)
		{
			this.Data = data;
		}

		// Token: 0x06042122 RID: 270626 RVA: 0x010F39BC File Offset: 0x010F1BBC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042123 RID: 270627 RVA: 0x010F3A83 File Offset: 0x010F1C83
		protected override void OnBeforeHide()
		{
			this.ClearTimer();
		}

		// Token: 0x06042124 RID: 270628 RVA: 0x010F3A8C File Offset: 0x010F1C8C
		public void RefreshActive()
		{
			this.LimitTimeRewardOn = this.Data.IsLimitTimeRewardOn();
			this.SetActive(this.LimitTimeRewardOn);
			if (this.LimitTimeRewardOn)
			{
				this.OnRefreshTime(0f);
				this.RefreshRedDot();
				this.InitTimer();
				return;
			}
			this.ClearTimer();
		}

		// Token: 0x06042125 RID: 270629 RVA: 0x010F3ADC File Offset: 0x010F1CDC
		private void RefreshRedDot()
		{
			base.GetItem(2).SetUIActive(this.Data.GetTimeLimitRedDotState());
		}

		// Token: 0x06042126 RID: 270630 RVA: 0x010F3AF8 File Offset: 0x010F1CF8
		private void OnRefreshTime(float _)
		{
			long limitTimeEndTime = this.Data.GetLimitTimeEndTime();
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if ((double)limitTimeEndTime - serverTime <= 0.0)
			{
				this.RefreshActive();
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(limitTimeEndTime, this.RemainTimeText);
			base.GetText(1).SetText(remainTimeText, true);
		}

		// Token: 0x06042127 RID: 270631 RVA: 0x010F3B52 File Offset: 0x010F1D52
		private void InitTimer()
		{
			this.ClearTimer();
			this.RefreshTimeHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshTime), 1000f, 1f, null, null, false);
		}

		// Token: 0x06042128 RID: 270632 RVA: 0x010F3B83 File Offset: 0x010F1D83
		private void ClearTimer()
		{
			if (this.RefreshTimeHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimeHandle);
				this.RefreshTimeHandle = null;
			}
		}

		// Token: 0x06042129 RID: 270633 RVA: 0x010F3BA5 File Offset: 0x010F1DA5
		private void OnClickedButton()
		{
			if (this.LimitTimeRewardOn)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingTimeLimitView, null, null);
			}
		}

		// Token: 0x04024D53 RID: 150867
		private const int CHECKGAP = 1000;

		// Token: 0x04024D54 RID: 150868
		private bool LimitTimeRewardOn;

		// Token: 0x04024D55 RID: 150869
		private readonly string RemainTimeText = "{0}";

		// Token: 0x04024D56 RID: 150870
		[Nullable(2)]
		private TimerHandle RefreshTimeHandle;

		// Token: 0x04024D57 RID: 150871
		protected ActivityFishingData Data;

		// Token: 0x0200C7A5 RID: 51109
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D771 RID: 251761
			public const int Button = 0;

			// Token: 0x0403D772 RID: 251762
			public const int TxtTime = 1;

			// Token: 0x0403D773 RID: 251763
			public const int RedDot = 2;
		}
	}
}
