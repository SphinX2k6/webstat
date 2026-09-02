using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F33 RID: 24371
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MoraleBattleController : ControllerBase<MoraleBattleController>
	{
		// Token: 0x0603D382 RID: 250754 RVA: 0x00F9131C File Offset: 0x00F8F51C
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<MoraleInfoNotify>(ENotifyMessageId.MoraleInfoNotify, new Action<MoraleInfoNotify, Net.CallbackStatus>(this.HandleMoraleInfoNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoadingView));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoraleIndomitableLevelChanged, new Action<int, int>(this.OnMoraleIndomitableLevelChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.CharOnBuffAddShowMoraleBuffTips, new Action<int, GameplayCue, bool, int>(this.OnBuffAddShowMoraleBuffTips));
			return true;
		}

		// Token: 0x0603D383 RID: 250755 RVA: 0x00F9139C File Offset: 0x00F8F59C
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MoraleInfoNotify);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoadingView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoraleIndomitableLevelChanged, new Action<int, int>(this.OnMoraleIndomitableLevelChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharOnBuffAddShowMoraleBuffTips, new Action<int, GameplayCue, bool, int>(this.OnBuffAddShowMoraleBuffTips));
			return true;
		}

		// Token: 0x0603D384 RID: 250756 RVA: 0x00F9140E File Offset: 0x00F8F60E
		protected override bool OnLeaveLevel()
		{
			this.IsReviveFromMoraleBattle = false;
			return true;
		}

		// Token: 0x0603D385 RID: 250757 RVA: 0x00F91418 File Offset: 0x00F8F618
		[NullableContext(2)]
		private void HandleMoraleInfoNotify(MoraleInfoNotify notify, Net.CallbackStatus callbackStatus)
		{
			if (notify == null)
			{
				return;
			}
			if (ModelBase<CreatureModel>.Instance.GetPlayerId() != notify.PlayerId)
			{
				return;
			}
			ModelBase<MoraleBattleModel>.Instance.HandleMoraleInfoNotify(notify);
		}

		// Token: 0x0603D386 RID: 250758 RVA: 0x00F9143C File Offset: 0x00F8F63C
		private void OnCloseLoadingView()
		{
			if (!this.IsReviveFromMoraleBattle)
			{
				return;
			}
			this.IsReviveFromMoraleBattle = false;
			if (!ModelBase<MoraleBattleModel>.Instance.IsMoraleActive())
			{
				return;
			}
			if (ModelBase<MoraleBattleModel>.Instance.GetLastMoraleLevel() > 1)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleLevelDecreaseView, null, null);
			}
		}

		// Token: 0x0603D387 RID: 250759 RVA: 0x00F9147C File Offset: 0x00F8F67C
		private void OnMoraleIndomitableLevelChanged(int oldLevel, int newLevel)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MoraleOccupiedSuccessView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.MoraleOccupiedSuccessView, delegate(bool success)
				{
					if (success)
					{
						Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleOccupiedSuccessView, null, null);
					}
				});
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleOccupiedSuccessView, null, null);
		}

		// Token: 0x0603D388 RID: 250760 RVA: 0x00F914DC File Offset: 0x00F8F6DC
		private void OnBuffAddShowMoraleBuffTips(int entityId, GameplayCue cue, bool isAdd, int handleId)
		{
			if (cue.Parameters(0) != "0")
			{
				return;
			}
			string text = (cue.ParametersLength > 1) ? cue.Parameters(1) : null;
			int num;
			if (!string.IsNullOrEmpty(text) && int.TryParse(text, out num) && num == 632400018)
			{
				ModelBase<MoraleBattleModel>.Instance.SetIsUnlockTempMoraleMaxLevel(isAdd);
			}
		}

		// Token: 0x0603D389 RID: 250761 RVA: 0x00F91539 File Offset: 0x00F8F739
		public void SetReviveFromMoraleBattle(bool isReviveFromMoraleBattle)
		{
			this.IsReviveFromMoraleBattle = isReviveFromMoraleBattle;
		}

		// Token: 0x04022551 RID: 140625
		private const string MORALE_CHARACTER_BUFF_TIPS_PARAM = "0";

		// Token: 0x04022552 RID: 140626
		private const int EXTRA_TEMP_MORALE_MAX_LEVEL_BUFF_ID = 632400018;

		// Token: 0x04022553 RID: 140627
		private bool IsReviveFromMoraleBattle;
	}
}
