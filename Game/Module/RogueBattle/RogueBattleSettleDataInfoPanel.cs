using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200520F RID: 21007
	public class RogueBattleSettleDataInfoPanel : UiPanelBase
	{
		// Token: 0x06035DE6 RID: 220646 RVA: 0x00D8E9A0 File Offset: 0x00D8CBA0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText))
			};
		}

		// Token: 0x06035DE7 RID: 220647 RVA: 0x00D8EAAC File Offset: 0x00D8CCAC
		protected override void OnBeforeShow()
		{
			base.GetText(0).SetText(this.ResultView.Score.ToString(), true);
			base.GetText(1).SetText(this.ResultView.EventCount.ToString(), true);
			base.GetText(2).SetText(this.ResultView.SumMoodConsume.ToString(), true);
			base.GetText(3).SetText(this.ResultView.SumGoldAdd.ToString(), true);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (EventInfo eventInfo in this.ResultView.EventInfos)
			{
				if (eventInfo.EventType == 5)
				{
					num = eventInfo.Count;
				}
				if (eventInfo.EventType == 4)
				{
					num2 = eventInfo.Count;
				}
				if (eventInfo.EventType == 3)
				{
					num3 = eventInfo.Count;
				}
				if (eventInfo.EventType == 1)
				{
					num4 = eventInfo.Count;
				}
			}
			base.GetText(4).SetText(num.ToString(), true);
			base.GetText(5).SetText(num2.ToString(), true);
			base.GetText(6).SetText(num3.ToString(), true);
			base.GetText(7).SetText(num4.ToString(), true);
			base.GetText(8).SetText(this.ResultView.ShopItemCount.ToString(), true);
			if (this.ResultView.ShopItemCount == 0 && this.ResultView.ShopItemMax)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RogueRes_Settle_ItemMaxCount", Array.Empty<object>());
			}
			else
			{
				base.GetText(8).SetText(this.ResultView.ShopItemCount.ToString(), true);
			}
			if (this.ResultView.SkillPoint == 0 && this.ResultView.SkillPointMax)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "RogueRes_Settle_ItemMaxCount", Array.Empty<object>());
			}
			else
			{
				base.GetText(9).SetText(this.ResultView.SkillPoint.ToString(), true);
			}
			if (this.ResultView.NewIllustrationCount == 0 && this.ResultView.IllustrationMax)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "RogueRes_Settle_ItemMaxCount", Array.Empty<object>());
				return;
			}
			base.GetText(10).SetText(this.ResultView.NewIllustrationCount.ToString(), true);
		}

		// Token: 0x0401EF0E RID: 126734
		private const int BOSS_EVENT_TYPE = 5;

		// Token: 0x0401EF0F RID: 126735
		private const int DIFFICULT_EVENT_TYPE = 4;

		// Token: 0x0401EF10 RID: 126736
		private const int SIMPLE_EVENT_TYPE = 3;

		// Token: 0x0401EF11 RID: 126737
		private const int RANDOM_EVENT_TYPE = 1;

		// Token: 0x0401EF12 RID: 126738
		public int IncId;

		// Token: 0x0401EF13 RID: 126739
		[Nullable(2)]
		public InstResultView ResultView;
	}
}
