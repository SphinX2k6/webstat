using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC0 RID: 24512
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleQuestButton : BattleEntranceButton
	{
		// Token: 0x0603DA32 RID: 252466 RVA: 0x00FB43CB File Offset: 0x00FB25CB
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUIText)));
		}

		// Token: 0x0603DA33 RID: 252467 RVA: 0x00FB440C File Offset: 0x00FB260C
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnSequenceStart));
			this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			this.AddEvents();
		}

		// Token: 0x0603DA34 RID: 252468 RVA: 0x00FB4466 File Offset: 0x00FB2666
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603DA35 RID: 252469 RVA: 0x00FB4474 File Offset: 0x00FB2674
		protected override void OnShowBattleChildView()
		{
			base.OnShowBattleChildView();
			if (this.SequencePlayer.GetCurrentSequence() != null)
			{
				this.SequencePlayer.ResumeSequence();
			}
		}

		// Token: 0x0603DA36 RID: 252470 RVA: 0x00FB4494 File Offset: 0x00FB2694
		protected override void OnHideBattleChildView()
		{
			base.OnHideBattleChildView();
			if (this.SequencePlayer.GetCurrentSequence() != null)
			{
				this.SequencePlayer.PauseSequence();
			}
		}

		// Token: 0x0603DA37 RID: 252471 RVA: 0x00FB44B4 File Offset: 0x00FB26B4
		protected void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MissionUpdate, new Action<bool>(this.OnMissionUpdate));
		}

		// Token: 0x0603DA38 RID: 252472 RVA: 0x00FB44D2 File Offset: 0x00FB26D2
		protected void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MissionUpdate, new Action<bool>(this.OnMissionUpdate));
		}

		// Token: 0x0603DA39 RID: 252473 RVA: 0x00FB44F0 File Offset: 0x00FB26F0
		private void OnSequenceStart(string sequenceName)
		{
			if (!(sequenceName == "MissionUpgradeIn"))
			{
				sequenceName == "MissionUpgradeOut";
				return;
			}
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(ModelBase<BattleUiModel>.Instance.IsMissionPanelVisible);
		}

		// Token: 0x0603DA3A RID: 252474 RVA: 0x00FB4528 File Offset: 0x00FB2728
		private void OnSequenceClose(string sequenceName)
		{
			if (!(sequenceName == "MissionUpgradeIn"))
			{
				sequenceName == "MissionUpgradeOut";
				return;
			}
			this.SequencePlayer.PlayLevelSequenceByName("MissionUpgradeOut", false, null, false);
			if (ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled)
			{
				this.SequencePlayer.StopCurrentSequence(true, true);
			}
		}

		// Token: 0x0603DA3B RID: 252475 RVA: 0x00FB4588 File Offset: 0x00FB2788
		private void OnMissionUpdate(bool bNewQuest)
		{
			UUIText text = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalText(text, bNewQuest ? "QuestUpdateNewQuestTips" : "QuestUpdateNewGoalTips", Array.Empty<object>());
			this.SequencePlayer.StopCurrentSequence(true, true);
			this.SequencePlayer.PlayLevelSequenceByName("MissionUpgradeIn", false, null, false);
			if (ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled)
			{
				this.SequencePlayer.StopCurrentSequence(true, true);
			}
		}

		// Token: 0x04022993 RID: 141715
		private const string MISSION_UPGRADE_IN = "MissionUpgradeIn";

		// Token: 0x04022994 RID: 141716
		private const string MISSION_UPGRADE_OUT = "MissionUpgradeOut";

		// Token: 0x04022995 RID: 141717
		[Nullable(2)]
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0200C02A RID: 49194
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B288 RID: 242312
			AnimNode = 2,
			// Token: 0x0403B289 RID: 242313
			QuestUpdateText
		}
	}
}
