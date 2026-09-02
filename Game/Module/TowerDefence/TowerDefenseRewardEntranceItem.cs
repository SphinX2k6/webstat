using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004ED3 RID: 20179
	public class TowerDefenseRewardEntranceItem : UiPanelBase
	{
		// Token: 0x06034208 RID: 213512 RVA: 0x00D08798 File Offset: 0x00D06998
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnReward));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034209 RID: 213513 RVA: 0x00D088A4 File Offset: 0x00D06AA4
		public void RefreshItem()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(ControllerBase<TowerDefenseController>.Instance.CheckHasReward());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "TowerDefence_PintDesc", Array.Empty<object>());
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetText(ControllerBase<TowerDefenseController>.Instance.BuildTotalScoreContent(), true);
			}
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount((float)ControllerBase<TowerDefenseController>.Instance.GetTotalScoreProgress());
		}

		// Token: 0x0603420A RID: 213514 RVA: 0x00D08921 File Offset: 0x00D06B21
		private void OnClickBtnReward()
		{
			ControllerBase<TowerDefenseController>.Instance.HandleOnClickReward();
		}

		// Token: 0x0200AE7A RID: 44666
		private class ERewardEntranceComponent
		{
			// Token: 0x040362C3 RID: 221891
			public const int RewardBtn = 0;

			// Token: 0x040362C4 RID: 221892
			public const int ProgressSpr = 1;

			// Token: 0x040362C5 RID: 221893
			public const int TitleTxt = 2;

			// Token: 0x040362C6 RID: 221894
			public const int ProgressTxt = 3;

			// Token: 0x040362C7 RID: 221895
			public const int RedDotItem = 4;
		}
	}
}
