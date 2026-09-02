using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200632F RID: 25391
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorRewardBottomItem : UiPanelBase
	{
		// Token: 0x0603FC99 RID: 261273 RVA: 0x0105B0B8 File Offset: 0x010592B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FC9A RID: 261274 RVA: 0x0105B184 File Offset: 0x01059384
		protected override void OnStart()
		{
			this.GiftLayout = new GenericLayout<GiftItem, int>(base.GetLayoutBase(1), new Func<GiftItem>(this.CreateGiftItem), null, false, true);
			this.ProgressBarWidth = base.GetSprite(4).GetWidth();
		}

		// Token: 0x0603FC9B RID: 261275 RVA: 0x0105B1B9 File Offset: 0x010593B9
		private GiftItem CreateGiftItem()
		{
			return new GiftItem
			{
				ReceiveCallback = new Action(this.OnReceiveCallback)
			};
		}

		// Token: 0x0603FC9C RID: 261276 RVA: 0x0105B1D2 File Offset: 0x010593D2
		private void OnReceiveCallback()
		{
			this.Refresh();
		}

		// Token: 0x0603FC9D RID: 261277 RVA: 0x0105B1DC File Offset: 0x010593DC
		public void Refresh()
		{
			int currentMilestone = ModelBase<SpringManorModel>.Instance.ActivityData.GetCurrentMilestone();
			List<int> list = new List<int>();
			foreach (SpringFestivalScoreReward springFestivalScoreReward in ModelBase<SpringManorModel>.Instance.GetScoreRewardConfigList())
			{
				list.Add(springFestivalScoreReward.Id);
			}
			this.RefreshProgressItem(currentMilestone, list);
		}

		// Token: 0x0603FC9E RID: 261278 RVA: 0x0105B254 File Offset: 0x01059454
		public UniTask RefreshProgressItem(int currentProgress, List<int> dataList)
		{
			SpringManorRewardBottomItem.<RefreshProgressItem>d__7 <RefreshProgressItem>d__;
			<RefreshProgressItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshProgressItem>d__.<>4__this = this;
			<RefreshProgressItem>d__.currentProgress = currentProgress;
			<RefreshProgressItem>d__.dataList = dataList;
			<RefreshProgressItem>d__.<>1__state = -1;
			<RefreshProgressItem>d__.<>t__builder.Start<SpringManorRewardBottomItem.<RefreshProgressItem>d__7>(ref <RefreshProgressItem>d__);
			return <RefreshProgressItem>d__.<>t__builder.Task;
		}

		// Token: 0x04023D1C RID: 146716
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<GiftItem, int> GiftLayout;

		// Token: 0x04023D1D RID: 146717
		private float ProgressBarWidth;

		// Token: 0x04023D1E RID: 146718
		private const int REWARD_ITEM_WIDTH = 130;
	}
}
