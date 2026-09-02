using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FeedbackReward
{
	// Token: 0x02005D8B RID: 23947
	internal class TaskItem : GridProxyAbstract<int>
	{
		// Token: 0x0603C4BD RID: 246973 RVA: 0x00F4D48C File Offset: 0x00F4B68C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickHelpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C4BE RID: 246974 RVA: 0x00F4D5D8 File Offset: 0x00F4B7D8
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			GivebackTask? givebackTaskById = ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackTaskById(data);
			if (givebackTaskById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), givebackTaskById.Value.TaskName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), givebackTaskById.Value.TaskDes, Array.Empty<object>());
			int feedbackTaskCurrentPoint = ModelBase<FeedbackRewardModel>.Instance.GetFeedbackTaskCurrentPoint(data);
			base.GetText(4).SetText(feedbackTaskCurrentPoint.ToString(), true);
			base.GetText(5).SetText("/" + givebackTaskById.Value.MaxScore.ToString(), true);
			base.GetSprite(3).SetFillAmount((float)feedbackTaskCurrentPoint / (float)givebackTaskById.Value.MaxScore);
			base.GetItem(6).SetUIActive(feedbackTaskCurrentPoint >= givebackTaskById.Value.MaxScore);
			this.HelpId = givebackTaskById.Value.HelpBtn;
			base.GetButton(0).RootUIComp.Get().SetUIActive(this.HelpId > 0);
		}

		// Token: 0x0603C4BF RID: 246975 RVA: 0x00F4D70B File Offset: 0x00F4B90B
		private void OnClickHelpBtn()
		{
			if (this.HelpId == 0)
			{
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(this.HelpId);
		}

		// Token: 0x04021E8B RID: 138891
		private int HelpId;

		// Token: 0x0200BDBF RID: 48575
		private enum ETaskItem
		{
			// Token: 0x0403A6F1 RID: 239345
			HelpBtn,
			// Token: 0x0403A6F2 RID: 239346
			TitleText,
			// Token: 0x0403A6F3 RID: 239347
			DesText,
			// Token: 0x0403A6F4 RID: 239348
			BarSprite,
			// Token: 0x0403A6F5 RID: 239349
			CurrentCountText,
			// Token: 0x0403A6F6 RID: 239350
			TargetText,
			// Token: 0x0403A6F7 RID: 239351
			FinishItem
		}
	}
}
