using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity
{
	// Token: 0x02006473 RID: 25715
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityRogueData : ActivityBaseData
	{
		// Token: 0x17009E45 RID: 40517
		// (get) Token: 0x0604080C RID: 264204 RVA: 0x01087A99 File Offset: 0x01085C99
		// (set) Token: 0x0604080B RID: 264203 RVA: 0x01087A7A File Offset: 0x01085C7A
		public bool FunctionBtnRedDot
		{
			get
			{
				return this.FunctionBtnRedDotInternal;
			}
			set
			{
				this.FunctionBtnRedDotInternal = value;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}
		}

		// Token: 0x17009E46 RID: 40518
		// (get) Token: 0x0604080D RID: 264205 RVA: 0x01087AA1 File Offset: 0x01085CA1
		public RogueSeasonData SeasonData
		{
			get
			{
				return this.SeasonDataInternal;
			}
		}

		// Token: 0x0604080E RID: 264206 RVA: 0x01087AAC File Offset: 0x01085CAC
		[NullableContext(1)]
		protected override void PhraseEx(ActivityData data)
		{
			RoguelikeActivityData roguelikeActivityData = data.RoguelikeActivityData;
			if (roguelikeActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.BB, "ActivityRougeData无肉鸽额外数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SeasonDataInternal = roguelikeActivityData.RogueSeasonData;
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			RogueSeasonData rogueSeasonData = roguelikeActivityData.RogueSeasonData;
			instance.TempCountdown = ((rogueSeasonData != null) ? new long?(rogueSeasonData.EndTime) : null);
			this.FunctionBtnRedDotInternal = base.GetIfFirstOpen();
		}

		// Token: 0x0604080F RID: 264207 RVA: 0x01087B24 File Offset: 0x01085D24
		public override bool NeedSelfControlFirstRedPoint()
		{
			return false;
		}

		// Token: 0x17009E47 RID: 40519
		// (get) Token: 0x06040810 RID: 264208 RVA: 0x01087B27 File Offset: 0x01085D27
		public override bool RedPointShowState
		{
			get
			{
				return this.GetRogueActivityState() != ERogueActivityState.Close && (base.GetIfFirstOpen() || (base.IsUnLock() && this.GetExDataRedPointShowState()));
			}
		}

		// Token: 0x06040811 RID: 264209 RVA: 0x01087B54 File Offset: 0x01085D54
		public RogueActivity? GetExtraConfig()
		{
			ActivityRogueConfig instance = ConfigBase<ActivityRogueConfig>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.GetActivityUniversalConfig(base.Id);
		}

		// Token: 0x06040812 RID: 264210 RVA: 0x01087B7F File Offset: 0x01085D7F
		public override bool GetExDataRedPointShowState()
		{
			return base.GetPreGuideQuestFinishState() && (this.FunctionBtnRedDotInternal || ModelBase<RoguelikeModel>.Instance.GetRoguelikeAchievementRedDot() || ModelBase<RoguelikeModel>.Instance.CheckHasCanUnlockSkill() || ModelBase<RoguelikeModel>.Instance.CheckRoguelikeShopRedDot());
		}

		// Token: 0x06040813 RID: 264211 RVA: 0x01087BB7 File Offset: 0x01085DB7
		public ERogueActivityState GetRogueActivityState()
		{
			if (this.CheckIfInOpenTime())
			{
				return ERogueActivityState.Open;
			}
			return ERogueActivityState.Close;
		}

		// Token: 0x06040814 RID: 264212 RVA: 0x01087BC4 File Offset: 0x01085DC4
		public void OnQuestStateChange(int questId, QuestState state)
		{
			if (!this.LocalConfig.Value.PreShowGuideQuest().Contains(questId))
			{
				return;
			}
			if (state != QuestState.Finish)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0402419E RID: 147870
		private bool FunctionBtnRedDotInternal;

		// Token: 0x0402419F RID: 147871
		private RogueSeasonData SeasonDataInternal;
	}
}
