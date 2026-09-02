using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DAE RID: 23982
	public class DreamLinkScoreRewardItem : UiPanelBase
	{
		// Token: 0x0603C634 RID: 247348 RVA: 0x00F543C9 File Offset: 0x00F525C9
		[NullableContext(1)]
		public DreamLinkScoreRewardItem(DreamLinkData data)
		{
			this.Data = data;
			this.MaxEnergy = this.Data.MaxEnergy;
		}

		// Token: 0x0603C635 RID: 247349 RVA: 0x00F543F0 File Offset: 0x00F525F0
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

		// Token: 0x0603C636 RID: 247350 RVA: 0x00F544B7 File Offset: 0x00F526B7
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeCurrencyUpdate, new Action(this.OnDreamLinkRewardRefresh));
			this.RefreshPerformance();
		}

		// Token: 0x0603C637 RID: 247351 RVA: 0x00F544DB File Offset: 0x00F526DB
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeCurrencyUpdate, new Action(this.OnDreamLinkRewardRefresh));
		}

		// Token: 0x0603C638 RID: 247352 RVA: 0x00F544F9 File Offset: 0x00F526F9
		private void OnDreamLinkRewardRefresh()
		{
			this.RefreshPerformance();
		}

		// Token: 0x0603C639 RID: 247353 RVA: 0x00F54504 File Offset: 0x00F52704
		public void RefreshPerformance()
		{
			int energyItemCount = this.Data.GetEnergyItemCount();
			if (this.CurrentEnergy != energyItemCount)
			{
				this.CurrentEnergy = energyItemCount;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "DreamLink_Reward_Ins_Progress", new <>z__ReadOnlyArray<object>(new object[]
				{
					this.CurrentEnergy,
					this.MaxEnergy
				}));
			}
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.Data.CheckHasEnergyReward());
		}

		// Token: 0x0603C63A RID: 247354 RVA: 0x00F54586 File Offset: 0x00F52786
		private void OnClickedButton()
		{
			this.Data.SaveFirstCheckRedDotState(5, 0);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DreamLinkRewardViewEnergy, null, null);
		}

		// Token: 0x04021F47 RID: 139079
		private int CurrentEnergy = -1;

		// Token: 0x04021F48 RID: 139080
		private readonly int MaxEnergy;

		// Token: 0x04021F49 RID: 139081
		[Nullable(1)]
		protected readonly DreamLinkData Data;

		// Token: 0x0200BDF7 RID: 48631
		private class EComponents
		{
			// Token: 0x0403A7BB RID: 239547
			public const int Button = 0;

			// Token: 0x0403A7BC RID: 239548
			public const int TxtScore = 1;

			// Token: 0x0403A7BD RID: 239549
			public const int RedDot = 2;
		}
	}
}
