using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F4C RID: 24396
	public class BattleUiAudioInfo
	{
		// Token: 0x0603D48B RID: 251019 RVA: 0x00F9697C File Offset: 0x00F94B7C
		public void PlayAudio()
		{
			if (Singleton<Time>.Instance.Now < this.CoolDownEndTime)
			{
				return;
			}
			if (!ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(this.UiChildType))
			{
				return;
			}
			this.PlayAudioImmediately();
		}

		// Token: 0x0603D48C RID: 251020 RVA: 0x00F969AF File Offset: 0x00F94BAF
		private void PlayAudioImmediately()
		{
			this.CoolDownEndTime = Singleton<Time>.Instance.Now + 500.0;
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.BattleUiPlayAudio, BattleUiAudioInfo.AudioIds[(int)this.AudioType]);
		}

		// Token: 0x0603D48D RID: 251021 RVA: 0x00F969E7 File Offset: 0x00F94BE7
		public void Reset()
		{
			this.CoolDownEndTime = 0.0;
		}

		// Token: 0x0402260D RID: 140813
		private const int DEFAULT_COOL_DOWN = 500;

		// Token: 0x0402260E RID: 140814
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly string[] AudioIds = new string[]
		{
			"play_ui_fb_concerto_energy",
			"play_ui_fb_concerto_energy_rogue",
			"play_scene_ui_fight_focus_on",
			"play_scene_ui_fight_focus_switch"
		};

		// Token: 0x0402260F RID: 140815
		public EBattleUiAudioType AudioType;

		// Token: 0x04022610 RID: 140816
		public double CoolDownEndTime;

		// Token: 0x04022611 RID: 140817
		public EBattleUiChild UiChildType;
	}
}
