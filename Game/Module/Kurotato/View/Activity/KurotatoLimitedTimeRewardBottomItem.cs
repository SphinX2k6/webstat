using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005ADA RID: 23258
	public class KurotatoLimitedTimeRewardBottomItem : UiPanelBase
	{
		// Token: 0x0603ACD4 RID: 240852 RVA: 0x00EE95B4 File Offset: 0x00EE77B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ACD5 RID: 240853 RVA: 0x00EE965F File Offset: 0x00EE785F
		protected override void OnStart()
		{
			this.GiftLayout = new GenericLayout<GiftItem, int>(base.GetLayoutBase(1), new Func<GiftItem>(this.CreateGiftItem), null, false, true);
			this.ProgressBarWidth = base.GetSprite(3).GetWidth();
		}

		// Token: 0x0603ACD6 RID: 240854 RVA: 0x00EE9694 File Offset: 0x00EE7894
		[NullableContext(1)]
		private GiftItem CreateGiftItem()
		{
			return new GiftItem
			{
				ReceiveCallback = new Action(this.OnReceiveCallback)
			};
		}

		// Token: 0x0603ACD7 RID: 240855 RVA: 0x00EE96AD File Offset: 0x00EE78AD
		private void OnReceiveCallback()
		{
			this.Refresh();
		}

		// Token: 0x0603ACD8 RID: 240856 RVA: 0x00EE96B8 File Offset: 0x00EE78B8
		public void Refresh()
		{
			int currentMilestone = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetCurrentMilestone();
			List<int> tabIdList = (from config in ConfigBase<KurotatoConfig>.Instance.GetAllKurotatoScoreAwardConfig()
			select config.Id).ToList<int>();
			this.RefreshProgressItem(currentMilestone, tabIdList);
		}

		// Token: 0x0603ACD9 RID: 240857 RVA: 0x00EE9714 File Offset: 0x00EE7914
		[NullableContext(1)]
		public void RefreshProgressItem(int currentProgress, IReadOnlyList<int> tabIdList)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(currentProgress.ToString(), true);
			}
			float num = 0f;
			float num2 = 0f;
			int count = tabIdList.Count;
			int num3 = 0;
			for (int i = 0; i < count; i++)
			{
				int rewardId = tabIdList[i];
				KurotatoScoreAward value = ConfigBase<KurotatoConfig>.Instance.GetKurotatoScoreAwardConfigById(rewardId).Value;
				if (currentProgress >= value.Score)
				{
					num += 1f / (float)count;
				}
				else if (currentProgress > num3)
				{
					int score = value.Score;
					float num4 = this.ProgressBarWidth / (float)count - 130f;
					float num5 = (float)(currentProgress - num3) / (float)(score - num3);
					num2 = (num4 * num5 + 65f) / this.ProgressBarWidth;
					break;
				}
				num3 = value.Score;
			}
			base.GetSprite(3).SetFillAmount(num + num2);
			GenericLayout<GiftItem, int> giftLayout = this.GiftLayout;
			if (giftLayout == null)
			{
				return;
			}
			giftLayout.RefreshByData(tabIdList.ToList<int>(), null, false);
		}

		// Token: 0x040213AF RID: 136111
		private const int REWARD_ITEM_WIDTH = 130;

		// Token: 0x040213B0 RID: 136112
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<GiftItem, int> GiftLayout;

		// Token: 0x040213B1 RID: 136113
		private float ProgressBarWidth;

		// Token: 0x0200BB07 RID: 47879
		private enum EComponents
		{
			// Token: 0x04039B9F RID: 236447
			ProgressNum,
			// Token: 0x04039BA0 RID: 236448
			RewardLayout,
			// Token: 0x04039BA1 RID: 236449
			GiftItem,
			// Token: 0x04039BA2 RID: 236450
			ProgressBar
		}
	}
}
