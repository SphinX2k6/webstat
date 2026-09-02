using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006814 RID: 26644
	public class FishingPermanentRewardButton : UiPanelBase
	{
		// Token: 0x06042689 RID: 272009 RVA: 0x01106064 File Offset: 0x01104264
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

		// Token: 0x0604268A RID: 272010 RVA: 0x0110612B File Offset: 0x0110432B
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0604268B RID: 272011 RVA: 0x01106133 File Offset: 0x01104333
		public void Refresh()
		{
			this.RefreshRedDot();
			this.RefreshProgress();
		}

		// Token: 0x0604268C RID: 272012 RVA: 0x01106144 File Offset: 0x01104344
		private void RefreshRedDot()
		{
			bool handBookRewardRedDotState = ModelBase<FishingModel>.Instance.GetHandBookRewardRedDotState();
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(handBookRewardRedDotState);
		}

		// Token: 0x0604268D RID: 272013 RVA: 0x01106170 File Offset: 0x01104370
		private void RefreshProgress()
		{
			int handBookRewardHaveTakenCount = ModelBase<FishingModel>.Instance.GetHandBookRewardHaveTakenCount();
			int count = ModelBase<FishingModel>.Instance.FishingItemHandBookRewardMap.Count;
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(handBookRewardHaveTakenCount.ToString() + "/" + count.ToString(), true);
		}

		// Token: 0x0604268E RID: 272014 RVA: 0x011061C2 File Offset: 0x011043C2
		private void OnClickedButton()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingHandBookRewardView, null, null);
		}

		// Token: 0x0200C847 RID: 51271
		private class EComponents
		{
			// Token: 0x0403DA10 RID: 252432
			public const int Button = 0;

			// Token: 0x0403DA11 RID: 252433
			public const int TxtProgress = 1;

			// Token: 0x0403DA12 RID: 252434
			public const int RedDot = 2;
		}
	}
}
