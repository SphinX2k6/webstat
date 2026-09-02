using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006118 RID: 24856
	public class BattleFloatTipsView : UiViewBase
	{
		// Token: 0x0603ECA3 RID: 257187 RVA: 0x010143B4 File Offset: 0x010125B4
		[NullableContext(1)]
		public BattleFloatTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603ECA4 RID: 257188 RVA: 0x010143C0 File Offset: 0x010125C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ECA5 RID: 257189 RVA: 0x0101444C File Offset: 0x0101264C
		protected override void OnStart()
		{
			if (this.Timer == null)
			{
				this.Timer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerUpdate), 100f, 1f, null, null, true);
			}
			BattleUiFloatTipsData floatTipsData = ModelBase<BattleUiModel>.Instance.FloatTipsData;
			BattleUiFloatTip battleUiFloatTip = floatTipsData.CurTip;
			if (floatTipsData.CheckIsExpired(battleUiFloatTip))
			{
				battleUiFloatTip = floatTipsData.GetNextFloatTip();
			}
			if (battleUiFloatTip == null)
			{
				return;
			}
			this.CurTip = battleUiFloatTip;
			this.InitText();
		}

		// Token: 0x0603ECA6 RID: 257190 RVA: 0x010144BD File Offset: 0x010126BD
		protected override void OnBeforeDestroy()
		{
			if (this.Timer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.Timer);
				this.Timer = null;
			}
		}

		// Token: 0x0603ECA7 RID: 257191 RVA: 0x010144DF File Offset: 0x010126DF
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiFloatTipUpdate, new Action(this.OnBattleUiFloatTipUpdate));
		}

		// Token: 0x0603ECA8 RID: 257192 RVA: 0x010144FD File Offset: 0x010126FD
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiFloatTipUpdate, new Action(this.OnBattleUiFloatTipUpdate));
		}

		// Token: 0x0603ECA9 RID: 257193 RVA: 0x0101451C File Offset: 0x0101271C
		public void OnTimerUpdate(float _)
		{
			if (this.CurTip == null || (double)this.CurTip.EndTime <= Singleton<Time>.Instance.WorldTimeSeconds)
			{
				this.TryPlayNextTip();
				return;
			}
			if (this.CurTip.Type == EBattleUiFloatTip.Countdown)
			{
				int num = (int)Math.Max(Math.Ceiling((double)this.CurTip.CountdownEndTime - Singleton<Time>.Instance.WorldTimeSeconds), 0.0);
				if (num != this.CurSeconds)
				{
					this.CurSeconds = num;
					Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "BattleTipCountdown", new <>z__ReadOnlySingleElementList<object>(this.CurSeconds));
				}
			}
		}

		// Token: 0x0603ECAA RID: 257194 RVA: 0x010145C0 File Offset: 0x010127C0
		private void OnBattleUiFloatTipUpdate()
		{
			BattleUiFloatTipsData floatTipsData = ModelBase<BattleUiModel>.Instance.FloatTipsData;
			this.CurTip = floatTipsData.CurTip;
			this.InitText();
		}

		// Token: 0x0603ECAB RID: 257195 RVA: 0x010145EC File Offset: 0x010127EC
		private void TryPlayNextTip()
		{
			BattleUiFloatTip nextFloatTip = ModelBase<BattleUiModel>.Instance.FloatTipsData.GetNextFloatTip();
			if (nextFloatTip == null)
			{
				base.CloseMe(null);
				return;
			}
			this.CurTip = nextFloatTip;
			this.InitText();
		}

		// Token: 0x0603ECAC RID: 257196 RVA: 0x01014624 File Offset: 0x01012824
		private void InitText()
		{
			EBattleUiFloatTip type = this.CurTip.Type;
			if (type == EBattleUiFloatTip.Normal)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), this.CurTip.TextKey, Array.Empty<object>());
				base.GetText(1).SetText("", true);
				base.GetItem(2).SetUIActive(false);
				return;
			}
			if (type != EBattleUiFloatTip.Countdown)
			{
				return;
			}
			this.CurSeconds = (int)Math.Max(Math.Ceiling((double)this.CurTip.CountdownEndTime - Singleton<Time>.Instance.WorldTimeSeconds), 0.0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), this.CurTip.TextKey, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "BattleTipCountdown", new <>z__ReadOnlySingleElementList<object>(this.CurSeconds));
			base.GetItem(2).SetUIActive(true);
		}

		// Token: 0x04023380 RID: 144256
		private const int TIMER_INTERVAL = 100;

		// Token: 0x04023381 RID: 144257
		[Nullable(1)]
		private const string COUNTDOWN_TEXT_KEY = "BattleTipCountdown";

		// Token: 0x04023382 RID: 144258
		[Nullable(2)]
		private BattleUiFloatTip CurTip;

		// Token: 0x04023383 RID: 144259
		private int CurSeconds;

		// Token: 0x04023384 RID: 144260
		[Nullable(2)]
		private TimerHandle Timer;

		// Token: 0x0200C2A2 RID: 49826
		private enum EChildType
		{
			// Token: 0x0403C01A RID: 245786
			TxtTip,
			// Token: 0x0403C01B RID: 245787
			TxtTime,
			// Token: 0x0403C01C RID: 245788
			IconItem
		}
	}
}
