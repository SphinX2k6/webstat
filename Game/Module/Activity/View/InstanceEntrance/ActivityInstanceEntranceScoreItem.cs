using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.View.InstanceEntrance
{
	// Token: 0x020061EC RID: 25068
	public class ActivityInstanceEntranceScoreItem : UiPanelBase
	{
		// Token: 0x0603F3FB RID: 259067 RVA: 0x0103B7A4 File Offset: 0x010399A4
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnScoreReward));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F3FC RID: 259068 RVA: 0x0103B86C File Offset: 0x01039A6C
		[NullableContext(2)]
		public void RefreshView(ActivityEntrancePointData data)
		{
			if (this.ViewData != null && this.ViewData.GetRedDotName() != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.ViewData.GetRedDotName().Value, base.GetItem(2), this.ViewData.GetRedDotId());
			}
			this.ViewData = data;
			if (this.ViewData != null && this.ViewData.GetRedDotName() != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(this.ViewData.GetRedDotName().Value, base.GetItem(2), null, this.ViewData.GetRedDotId());
			}
			IActivityRewardViewData rewardData = data.GetRewardData();
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(rewardData != null);
			}
			this.RefreshScore();
		}

		// Token: 0x0603F3FD RID: 259069 RVA: 0x0103B94C File Offset: 0x01039B4C
		private void RefreshScore()
		{
			string scoreDesc = this.ViewData.GetScoreDesc();
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(scoreDesc, true);
		}

		// Token: 0x0603F3FE RID: 259070 RVA: 0x0103B978 File Offset: 0x01039B78
		private void OnClickBtnScoreReward()
		{
			Action pointRewardBtnClickCallBack = this.ViewData.GetPointRewardBtnClickCallBack();
			if (pointRewardBtnClickCallBack != null)
			{
				pointRewardBtnClickCallBack();
			}
		}

		// Token: 0x0402382D RID: 145453
		[Nullable(2)]
		private ActivityEntrancePointData ViewData;

		// Token: 0x0200C32D RID: 49965
		private enum EComponent
		{
			// Token: 0x0403C271 RID: 246385
			BtnScoreReward,
			// Token: 0x0403C272 RID: 246386
			TxtScore,
			// Token: 0x0403C273 RID: 246387
			ScoreRedDot
		}
	}
}
