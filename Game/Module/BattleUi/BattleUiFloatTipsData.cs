using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F70 RID: 24432
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiFloatTipsData
	{
		// Token: 0x0603D554 RID: 251220 RVA: 0x00F9937E File Offset: 0x00F9757E
		public void Init()
		{
		}

		// Token: 0x0603D555 RID: 251221 RVA: 0x00F99380 File Offset: 0x00F97580
		public void OnLeaveLevel()
		{
			this.CurTip = null;
			this.Tips.Clear();
		}

		// Token: 0x0603D556 RID: 251222 RVA: 0x00F99394 File Offset: 0x00F97594
		public void Clear()
		{
		}

		// Token: 0x0603D557 RID: 251223 RVA: 0x00F99398 File Offset: 0x00F97598
		[NullableContext(2)]
		public BattleUiFloatTip GetNextFloatTip()
		{
			BattleUiFloatTip battleUiFloatTip;
			while (this.Tips.TryPop(out battleUiFloatTip))
			{
				if (!this.CheckIsExpired(battleUiFloatTip))
				{
					return battleUiFloatTip;
				}
			}
			return null;
		}

		// Token: 0x0603D558 RID: 251224 RVA: 0x00F993C0 File Offset: 0x00F975C0
		public void PlayNormalFloatTip(string textKey, float duration)
		{
			BattleUiFloatTip tip = new BattleUiFloatTip
			{
				Type = EBattleUiFloatTip.Normal,
				TextKey = textKey,
				EndTime = (float)Singleton<Time>.Instance.WorldTimeSeconds + duration
			};
			this.AddNewFloatTip(tip);
		}

		// Token: 0x0603D559 RID: 251225 RVA: 0x00F993FC File Offset: 0x00F975FC
		public void PlayCountdownFloatTip(string textKey, float duration, float countdown)
		{
			BattleUiFloatTip tip = new BattleUiFloatTip
			{
				Type = EBattleUiFloatTip.Countdown,
				TextKey = textKey,
				EndTime = (float)Singleton<Time>.Instance.WorldTimeSeconds + duration,
				CountdownEndTime = (float)Singleton<Time>.Instance.WorldTimeSeconds + countdown
			};
			this.AddNewFloatTip(tip);
		}

		// Token: 0x0603D55A RID: 251226 RVA: 0x00F9944C File Offset: 0x00F9764C
		public void AddNewFloatTip(BattleUiFloatTip tip)
		{
			if (this.CurTip == null)
			{
				this.CurTip = tip;
			}
			else
			{
				this.Tips.Add(this.CurTip);
				this.CurTip = tip;
			}
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattleFloatTipsView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BattleFloatTipsView, null, null);
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiFloatTipUpdate);
		}

		// Token: 0x0603D55B RID: 251227 RVA: 0x00F994B5 File Offset: 0x00F976B5
		public bool CheckIsExpired(BattleUiFloatTip tip)
		{
			return tip.EndTime - (float)Singleton<Time>.Instance.WorldTimeSeconds < 0.1f;
		}

		// Token: 0x04022702 RID: 141058
		private const float MIN_VALID_TIME = 0.1f;

		// Token: 0x04022703 RID: 141059
		private readonly List<BattleUiFloatTip> Tips = new List<BattleUiFloatTip>();

		// Token: 0x04022704 RID: 141060
		[Nullable(2)]
		public BattleUiFloatTip CurTip;
	}
}
