using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DBC RID: 23996
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkLimitTimeRewardItem : UiPanelBase
	{
		// Token: 0x0603C6A8 RID: 247464 RVA: 0x00F5629F File Offset: 0x00F5449F
		public DreamLinkLimitTimeRewardItem(DreamLinkData Data)
		{
			this.Data = Data;
		}

		// Token: 0x0603C6A9 RID: 247465 RVA: 0x00F562BC File Offset: 0x00F544BC
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

		// Token: 0x0603C6AA RID: 247466 RVA: 0x00F56383 File Offset: 0x00F54583
		protected override void OnBeforeHide()
		{
			this.ClearTimer();
		}

		// Token: 0x0603C6AB RID: 247467 RVA: 0x00F5638C File Offset: 0x00F5458C
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

		// Token: 0x0603C6AC RID: 247468 RVA: 0x00F563DC File Offset: 0x00F545DC
		private void RefreshRedDot()
		{
			base.GetItem(2).SetUIActive(this.Data.CheckHasLimitTimeReward());
		}

		// Token: 0x0603C6AD RID: 247469 RVA: 0x00F563F8 File Offset: 0x00F545F8
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

		// Token: 0x0603C6AE RID: 247470 RVA: 0x00F56452 File Offset: 0x00F54652
		private void InitTimer()
		{
			this.ClearTimer();
			this.RefreshTimeHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshTime), 1000f, 1f, null, null, false);
		}

		// Token: 0x0603C6AF RID: 247471 RVA: 0x00F56483 File Offset: 0x00F54683
		private void ClearTimer()
		{
			if (this.RefreshTimeHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimeHandle);
				this.RefreshTimeHandle = null;
			}
		}

		// Token: 0x0603C6B0 RID: 247472 RVA: 0x00F564A5 File Offset: 0x00F546A5
		private void OnClickedButton()
		{
			if (this.LimitTimeRewardOn)
			{
				this.Data.SaveFirstCheckRedDotState(4, 0);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DreamLinkRewardViewLimit, null, null);
			}
		}

		// Token: 0x04021F73 RID: 139123
		private const int CHECKGAP = 1000;

		// Token: 0x04021F74 RID: 139124
		private bool LimitTimeRewardOn;

		// Token: 0x04021F75 RID: 139125
		private string RemainTimeText = "{0}";

		// Token: 0x04021F76 RID: 139126
		[Nullable(2)]
		private TimerHandle RefreshTimeHandle;

		// Token: 0x04021F77 RID: 139127
		private DreamLinkData Data;

		// Token: 0x0200BE0B RID: 48651
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403A820 RID: 239648
			public const int Button = 0;

			// Token: 0x0403A821 RID: 239649
			public const int TxtTime = 1;

			// Token: 0x0403A822 RID: 239650
			public const int RedDot = 2;
		}
	}
}
