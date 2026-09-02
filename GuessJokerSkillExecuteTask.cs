using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020010F7 RID: 4343
public class GuessJokerSkillExecuteTask : GuessJokerTaskBase
{
	// Token: 0x06007112 RID: 28946 RVA: 0x001D9130 File Offset: 0x001D7330
	[NullableContext(1)]
	public GuessJokerSkillExecuteTask(JokerGuessSkillExecAction data)
	{
		this.Data = data;
		this.SkillId = data.JokerSkillId;
		this.PlayerType = GuessJokerUtils.ServerPlayerTransToClient(data.Owner);
		this.IsUseSkill = GuessJokerUtils.ServerUseSkillTransToClient(data.Result);
		this.FinishTime = 1500f;
	}

	// Token: 0x06007113 RID: 28947 RVA: 0x001D918C File Offset: 0x001D738C
	protected override void OnExecute()
	{
		if (this.Data == null)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, string.Format("技能执行：玩家类型{0} 技能ID{1} 是否使用{2}", this.PlayerType, this.SkillId, this.IsUseSkill), default(ReadOnlySpan<ValueTuple<string, object>>));
		bool isJokerReturnFlagForGuide = false;
		if (this.Data.PlayerHandCards != null && this.Data.PlayerHandCards.CardIds != null)
		{
			List<int> list = new List<int>();
			foreach (int item in this.Data.PlayerHandCards.CardIds)
			{
				list.Add(item);
			}
			GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
			if (instance != null)
			{
				instance.UpdateCardBelongPlayerType(list.ToArray(), new EGuessJokerPlayerType?(EGuessJokerPlayerType.Me));
			}
			foreach (int cardId in this.Data.PlayerHandCards.CardIds)
			{
				GuessJokerGamePlayModel instance2 = ModelBase<GuessJokerGamePlayModel>.Instance;
				GuessJokerCardData guessJokerCardData = (instance2 != null) ? instance2.GetCardDataById(cardId) : null;
				if (guessJokerCardData != null && guessJokerCardData.Type == EGuessJokerCardType.Joker)
				{
					isJokerReturnFlagForGuide = true;
					break;
				}
			}
		}
		if (this.Data.AiHandCards != null && this.Data.AiHandCards.CardIds != null)
		{
			List<int> list2 = new List<int>();
			foreach (int item2 in this.Data.AiHandCards.CardIds)
			{
				list2.Add(item2);
			}
			GuessJokerGamePlayModel instance3 = ModelBase<GuessJokerGamePlayModel>.Instance;
			if (instance3 != null)
			{
				instance3.UpdateCardBelongPlayerType(list2.ToArray(), new EGuessJokerPlayerType?(EGuessJokerPlayerType.Ai));
			}
		}
		if (this.IsUseSkill)
		{
			this.DoUseSkill(isJokerReturnFlagForGuide);
			return;
		}
		this.DoNotUseSkill();
	}

	// Token: 0x06007114 RID: 28948 RVA: 0x001D9388 File Offset: 0x001D7588
	private void DoUseSkill(bool isJokerReturnFlagForGuide)
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		GuessJokerGamePlayView guessJokerGamePlayView = (instance != null) ? instance.GetGamePlayView() : null;
		if (guessJokerGamePlayView != null)
		{
			guessJokerGamePlayView.UpdateSkill(this.PlayerType);
			if (ModelBase<GuessJokerGamePlayModel>.Instance.ShouldPlaySkillEffect(this.SkillId))
			{
				List<GuessJokerPlotAction> list = new List<GuessJokerPlotAction>();
				list.Add(new GuessJokerPlotAction(this.PlayerType, EGuessJokerPlotTiming.ExecuteSkill, new int?(this.SkillId)));
				list.Add(new GuessJokerPlotAction(GuessJokerUtils.GetOtherPlayerType(this.PlayerType), EGuessJokerPlotTiming.ExecuteSkill, new int?(this.SkillId)));
				ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(list.ToArray());
				guessJokerGamePlayView.PlaySkillEffect(this.SkillId, delegate
				{
					if (isJokerReturnFlagForGuide)
					{
						Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "GuessJokerJokerReturn");
					}
					this.FinishTask();
				});
				return;
			}
			if (isJokerReturnFlagForGuide)
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "GuessJokerJokerReturn");
			}
			base.FinishTask();
		}
	}

	// Token: 0x06007115 RID: 28949 RVA: 0x001D9474 File Offset: 0x001D7674
	private void DoNotUseSkill()
	{
		if (ModelBase<GuessJokerGamePlayModel>.Instance.ShowPlayGiveUpSkillTip(this.SkillId))
		{
			JokerSkill? jokerSkill = ConfigBase<GuessJokerConfig>.Instance.GetJokerSkill(this.SkillId);
			string text = (jokerSkill != null) ? jokerSkill.GetValueOrDefault().SkillName : null;
			if (text != null)
			{
				string text2 = ConfigMultiTextLang.GetLocalTextNew(text, null) ?? text;
				ControllerBase<GuessJokerController>.Instance.OpenGuessJokerFloatTipsView("GuessJoker_NotUseSkill", new string[]
				{
					text2
				});
			}
		}
		base.FinishTask();
	}

	// Token: 0x04003661 RID: 13921
	[Nullable(2)]
	private readonly JokerGuessSkillExecAction Data;

	// Token: 0x04003662 RID: 13922
	public int SkillId;

	// Token: 0x04003663 RID: 13923
	public EGuessJokerPlayerType PlayerType = EGuessJokerPlayerType.Ai;

	// Token: 0x04003664 RID: 13924
	public bool IsUseSkill;
}
