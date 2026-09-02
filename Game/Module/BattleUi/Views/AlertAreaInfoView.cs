using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.AlertArea;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F91 RID: 24465
	public class AlertAreaInfoView : BattleVisibleChildView
	{
		// Token: 0x0603D6B4 RID: 251572 RVA: 0x00FA03FA File Offset: 0x00F9E5FA
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.AddEvents();
		}

		// Token: 0x0603D6B5 RID: 251573 RVA: 0x00FA0418 File Offset: 0x00F9E618
		public override void Reset()
		{
			base.Reset();
			this.RemoveEvents();
		}

		// Token: 0x0603D6B6 RID: 251574 RVA: 0x00FA0428 File Offset: 0x00F9E628
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D6B7 RID: 251575 RVA: 0x00FA0557 File Offset: 0x00F9E757
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, float>(EEventName.OnUpdateAreaAlertValue, new Action<int, float>(this.OnUpdateAreaAlertValue));
		}

		// Token: 0x0603D6B8 RID: 251576 RVA: 0x00FA0575 File Offset: 0x00F9E775
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateAreaAlertValue, new Action<int, float>(this.OnUpdateAreaAlertValue));
		}

		// Token: 0x0603D6B9 RID: 251577 RVA: 0x00FA0594 File Offset: 0x00F9E794
		public void Tick(float delta)
		{
			AlertAreaUpdateMachine updateMachine = this.UpdateMachine;
			if (((updateMachine != null) ? new bool?(updateMachine.Update(delta)) : null).GetValueOrDefault())
			{
				this.OnMachineDataChange();
			}
		}

		// Token: 0x0603D6BA RID: 251578 RVA: 0x00FA05D4 File Offset: 0x00F9E7D4
		public void OnMachineDataChange()
		{
			if (this.UpdateMachine == null)
			{
				return;
			}
			int progressDir = this.UpdateMachine.GetProgressDir();
			float barCurPercent = this.UpdateMachine.GetBarCurPercent();
			float barTargetPercent = this.UpdateMachine.GetBarTargetPercent();
			if (progressDir > 0)
			{
				this.SetBarProgressByPercent(barCurPercent);
				this.SetBarProgressBufferByPercent(barTargetPercent);
				return;
			}
			this.SetBarProgressByPercent(barTargetPercent);
			this.SetBarProgressBufferByPercent(barCurPercent);
		}

		// Token: 0x0603D6BB RID: 251579 RVA: 0x00FA0630 File Offset: 0x00F9E830
		private void OnUpdateAreaAlertValue(int areaId, float value)
		{
			if (this.AreaId != areaId)
			{
				return;
			}
			float alertValue = this.AlertValue;
			this.AlertValue = ModelBase<AlertAreaModel>.Instance.GetAreaAlertValue(areaId);
			AlertAreaUpdateMachine updateMachine = this.UpdateMachine;
			if (updateMachine != null)
			{
				updateMachine.ChangeTargetPercent(this.AlertValue);
			}
			this.SetTxtProgressByPercent(this.AlertValue);
			this.UpdateWarningAnimByPercent(alertValue, this.AlertValue);
			float deltaPercent = this.AlertValue - alertValue;
			this.ShowTxtProgressTip(true, deltaPercent);
		}

		// Token: 0x0603D6BC RID: 251580 RVA: 0x00FA06A0 File Offset: 0x00F9E8A0
		public void StartShow(int areaId)
		{
			this.AreaId = areaId;
			this.AlertValue = ModelBase<AlertAreaModel>.Instance.GetAreaAlertValue(areaId);
			this.UpdateMachine = new AlertAreaUpdateMachine();
			this.InitTweenAnim();
			base.SetVisible(1, true);
			this.UpdateMachine.Init(this.AlertValue);
			this.SetBarProgressByPercent(this.AlertValue);
			this.SetBarProgressBufferByPercent(this.AlertValue);
			this.SetTxtProgressByPercent(this.AlertValue);
			this.HideTxtProgressTip();
		}

		// Token: 0x0603D6BD RID: 251581 RVA: 0x00FA071C File Offset: 0x00F9E91C
		public void EndShow(int? areaId = null)
		{
			if (areaId != null)
			{
				int? num = areaId;
				int areaId2 = this.AreaId;
				if (!(num.GetValueOrDefault() == areaId2 & num != null))
				{
					return;
				}
			}
			base.SetVisible(1, false);
			this.ClearTweenAnim();
			this.AreaId = 0;
			this.AlertValue = 0f;
			this.UpdateMachine = null;
		}

		// Token: 0x0603D6BE RID: 251582 RVA: 0x00FA0778 File Offset: 0x00F9E978
		private void SetBarProgressByPercent(float percent)
		{
			float num = Singleton<MathUtils>.Instance.RangeClamp(percent, 0f, 100f, 42f, 83f);
			base.GetSprite(1).SetFillAmount(num * 0.01f);
		}

		// Token: 0x0603D6BF RID: 251583 RVA: 0x00FA07B8 File Offset: 0x00F9E9B8
		private void SetBarProgressBufferByPercent(float percent)
		{
			float num = Singleton<MathUtils>.Instance.RangeClamp(percent, 0f, 100f, 42f, 83f);
			base.GetSprite(0).SetFillAmount(num * 0.01f);
		}

		// Token: 0x0603D6C0 RID: 251584 RVA: 0x00FA07F8 File Offset: 0x00F9E9F8
		private void SetTxtProgressByPercent(float percent)
		{
			int num = (int)MathCommon.Clamp(Math.Round((double)percent), 0.0, 100.0);
			base.GetText(2).SetText(num.ToString(), true);
		}

		// Token: 0x0603D6C1 RID: 251585 RVA: 0x00FA083C File Offset: 0x00F9EA3C
		private void UpdateWarningAnimByPercent(float oldPercent, float newPercent)
		{
			if (newPercent >= 100f)
			{
				if (oldPercent < 100f)
				{
					if (oldPercent >= 80f)
					{
						BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
						if (tweenPlayer != null)
						{
							tweenPlayer.StopTweenAnim(5);
						}
						BattleUiTweenAnimPlayer tweenPlayer2 = this.TweenPlayer;
						if (tweenPlayer2 == null)
						{
							return;
						}
						tweenPlayer2.PlayTweenAnim(6);
						return;
					}
					else
					{
						BattleUiTweenAnimPlayer tweenPlayer3 = this.TweenPlayer;
						if (tweenPlayer3 == null)
						{
							return;
						}
						tweenPlayer3.PlayTweenAnim(6);
						return;
					}
				}
			}
			else if (newPercent >= 80f)
			{
				if (oldPercent >= 100f)
				{
					BattleUiTweenAnimPlayer tweenPlayer4 = this.TweenPlayer;
					if (tweenPlayer4 != null)
					{
						tweenPlayer4.StopTweenAnim(6);
					}
					BattleUiTweenAnimPlayer tweenPlayer5 = this.TweenPlayer;
					if (tweenPlayer5 == null)
					{
						return;
					}
					tweenPlayer5.PlayTweenAnim(5);
					return;
				}
				else if (oldPercent < 80f)
				{
					BattleUiTweenAnimPlayer tweenPlayer6 = this.TweenPlayer;
					if (tweenPlayer6 == null)
					{
						return;
					}
					tweenPlayer6.PlayTweenAnim(5);
					return;
				}
			}
			else if (oldPercent >= 100f)
			{
				BattleUiTweenAnimPlayer tweenPlayer7 = this.TweenPlayer;
				if (tweenPlayer7 != null)
				{
					tweenPlayer7.StopTweenAnim(6);
				}
				BattleUiTweenAnimPlayer tweenPlayer8 = this.TweenPlayer;
				if (tweenPlayer8 == null)
				{
					return;
				}
				tweenPlayer8.PlayTweenAnim(4);
				return;
			}
			else if (oldPercent >= 80f)
			{
				BattleUiTweenAnimPlayer tweenPlayer9 = this.TweenPlayer;
				if (tweenPlayer9 != null)
				{
					tweenPlayer9.StopTweenAnim(5);
				}
				BattleUiTweenAnimPlayer tweenPlayer10 = this.TweenPlayer;
				if (tweenPlayer10 == null)
				{
					return;
				}
				tweenPlayer10.PlayTweenAnim(4);
			}
		}

		// Token: 0x0603D6C2 RID: 251586 RVA: 0x00FA0940 File Offset: 0x00F9EB40
		private void ShowTxtProgressTip(bool updateText, float deltaPercent = 0f)
		{
			if (updateText)
			{
				int value = (int)MathCommon.Clamp(Math.Abs(Math.Round((double)deltaPercent)), 0.0, 100.0);
				UUIText text = base.GetText(3);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted((deltaPercent >= 0f) ? "+" : "-");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			base.GetText(3).SetUIActive(true);
			BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
			if (tweenPlayer == null)
			{
				return;
			}
			tweenPlayer.PlayTweenAnim(7);
		}

		// Token: 0x0603D6C3 RID: 251587 RVA: 0x00FA09DF File Offset: 0x00F9EBDF
		private void HideTxtProgressTip()
		{
			BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
			if (tweenPlayer != null)
			{
				tweenPlayer.StopTweenAnim(7);
			}
			base.GetText(3).SetUIActive(false);
		}

		// Token: 0x0603D6C4 RID: 251588 RVA: 0x00FA0A00 File Offset: 0x00F9EC00
		private void InitTweenAnim()
		{
			this.TweenPlayer = new BattleUiTweenAnimPlayer();
			this.TweenPlayer.InitTweenAnim(4, base.GetItem(4), false);
			this.TweenPlayer.InitTweenAnim(5, base.GetItem(5), false);
			this.TweenPlayer.InitTweenAnim(6, base.GetItem(6), false);
			this.TweenPlayer.InitTweenAnim(7, base.GetItem(7), false);
		}

		// Token: 0x0603D6C5 RID: 251589 RVA: 0x00FA0A68 File Offset: 0x00F9EC68
		private void ClearTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
			if (tweenPlayer != null)
			{
				tweenPlayer.StopTweenAnim(5);
			}
			BattleUiTweenAnimPlayer tweenPlayer2 = this.TweenPlayer;
			if (tweenPlayer2 != null)
			{
				tweenPlayer2.StopTweenAnim(6);
			}
			BattleUiTweenAnimPlayer tweenPlayer3 = this.TweenPlayer;
			if (tweenPlayer3 != null)
			{
				tweenPlayer3.StopTweenAnim(7);
			}
			BattleUiTweenAnimPlayer tweenPlayer4 = this.TweenPlayer;
			if (tweenPlayer4 != null)
			{
				tweenPlayer4.StopTweenAnim(4);
			}
			BattleUiTweenAnimPlayer tweenPlayer5 = this.TweenPlayer;
			if (tweenPlayer5 != null)
			{
				tweenPlayer5.Clear(false);
			}
			this.TweenPlayer = null;
		}

		// Token: 0x0402283B RID: 141371
		private const float PERCENT_TO_PROGRESS = 0.01f;

		// Token: 0x0402283C RID: 141372
		private const float UI_BAR_MIN_PERCENT = 42f;

		// Token: 0x0402283D RID: 141373
		private const float UI_BAR_MAX_PERCENT = 83f;

		// Token: 0x0402283E RID: 141374
		private int AreaId;

		// Token: 0x0402283F RID: 141375
		private float AlertValue;

		// Token: 0x04022840 RID: 141376
		[Nullable(2)]
		private AlertAreaUpdateMachine UpdateMachine;

		// Token: 0x04022841 RID: 141377
		[Nullable(2)]
		private BattleUiTweenAnimPlayer TweenPlayer;

		// Token: 0x0200BF7E RID: 49022
		private enum EVisibleReason
		{
			// Token: 0x0403AF17 RID: 241431
			Default = 1
		}

		// Token: 0x0200BF7F RID: 49023
		private enum EChildComponent
		{
			// Token: 0x0403AF19 RID: 241433
			BarProgressBuffer,
			// Token: 0x0403AF1A RID: 241434
			BarProgress,
			// Token: 0x0403AF1B RID: 241435
			TxtProgress,
			// Token: 0x0403AF1C RID: 241436
			TxtProgressTip,
			// Token: 0x0403AF1D RID: 241437
			AniDefault,
			// Token: 0x0403AF1E RID: 241438
			AniWarningA,
			// Token: 0x0403AF1F RID: 241439
			AniWarningB,
			// Token: 0x0403AF20 RID: 241440
			AniTxtTip
		}
	}
}
