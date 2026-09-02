using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065B6 RID: 26038
	public class PinballSettleProgressRewardView : UiPanelBase
	{
		// Token: 0x060410F4 RID: 266484 RVA: 0x010B1874 File Offset: 0x010AFA74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060410F5 RID: 266485 RVA: 0x010B1964 File Offset: 0x010AFB64
		protected override UniTask OnBeforeStartAsync()
		{
			PinballSettleProgressRewardView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballSettleProgressRewardView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060410F6 RID: 266486 RVA: 0x010B19A8 File Offset: 0x010AFBA8
		[NullableContext(1)]
		public void ShowProgressRewardList(int progress, int[] progressList, int[] scoreLevelDropId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), "Pinball_BattleSettlement_Score", new <>z__ReadOnlySingleElementList<object>(progress));
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetFillAmount((progress < progressList[0]) ? 0f : ((float)(progress - progressList[0]) / (float)(progressList[1] - progressList[0])));
			}
			UUISprite sprite2 = base.GetSprite(2);
			if (sprite2 != null)
			{
				sprite2.SetFillAmount((progress < progressList[1]) ? 0f : ((float)(progress - progressList[1]) / (float)(progressList[2] - progressList[1])));
			}
			for (int i = 0; i < this.Items.Count; i++)
			{
				PinballLevelScoreData data = new PinballLevelScoreData
				{
					CurScore = progress,
					ConfigScore = progressList[i],
					ConfigDropId = scoreLevelDropId[i]
				};
				this.Items[i].Refresh(data);
			}
		}

		// Token: 0x0402476C RID: 149356
		[Nullable(1)]
		private readonly List<PinballLevelInfoScoreItem> Items = new List<PinballLevelInfoScoreItem>();

		// Token: 0x0200C5B7 RID: 50615
		private enum EComponent
		{
			// Token: 0x0403CDA5 RID: 249253
			TextScore,
			// Token: 0x0403CDA6 RID: 249254
			ProgressOne,
			// Token: 0x0403CDA7 RID: 249255
			ProgressTwo,
			// Token: 0x0403CDA8 RID: 249256
			ProgressRewardItemOne,
			// Token: 0x0403CDA9 RID: 249257
			ProgressRewardItemTwo,
			// Token: 0x0403CDAA RID: 249258
			ProgressRewardItemThree
		}
	}
}
