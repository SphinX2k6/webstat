using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006042 RID: 24642
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class HonamiStoryViewBase : BattleVisibleChildView
	{
		// Token: 0x0603E273 RID: 254579 RVA: 0x00FDDB0C File Offset: 0x00FDBD0C
		protected override void OnStart()
		{
			this.OnInitData();
			base.InitChildType(EBattleUiChild.Ignore);
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.DangerPercent = ConfigCommonParamById.GetFloatConfig(this.DangerPercentConfigId).GetValueOrDefault();
			this.NormalPercent = 1f - this.DangerPercent;
			UUIText text = base.GetText(this.HpTextType);
			text.SetRichText(true);
			text.SetGameRichText(true);
			this.TweenPlayer = new BattleUiTweenAnimPlayer();
			this.TweenPlayer.InitTweenAnim(this.InTweenType, base.GetItem(this.InTweenType), false);
			this.TweenPlayer.InitTweenAnim(this.OutTweenType, base.GetItem(this.OutTweenType), false);
			object obj = this.ShowFunctionType == null || ModelBase<FunctionModel>.Instance.IsOpen((int)this.ShowFunctionType.Value);
			bool flag = this.HideFunctionType == null || ModelBase<FunctionModel>.Instance.IsOpen((int)this.HideFunctionType.Value);
			object obj2 = obj;
			if (obj2 == null || (this.HideFunctionType != null && flag))
			{
				base.SetVisible(1, false);
			}
			if (obj2 == null || !flag)
			{
				Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
				Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			}
		}

		// Token: 0x0603E274 RID: 254580 RVA: 0x00FDDC68 File Offset: 0x00FDBE68
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
			if (tweenPlayer != null)
			{
				tweenPlayer.Clear(false);
			}
			this.TweenPlayer = null;
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			}
		}

		// Token: 0x0603E275 RID: 254581 RVA: 0x00FDDD18 File Offset: 0x00FDBF18
		protected override void OnBeforeShow()
		{
			UUIItem rootItem = this.RootItem;
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PlotViewHUD);
			rootItem.SetAlpha((viewByName != null && viewByName.IsShow) ? 0.2f : 1f);
			Singleton<EventSystem>.Instance.Add(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotViewChange));
			ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.HonamiStoryLifeSupport, new TValueListener(this.OnAttributeChanged), null);
			ControllerBase<FormationAttributeController>.Instance.AddMaxListener(EFormationAttributeId.HonamiStoryLifeSupport, new TValueListener(this.OnAttributeChanged), null);
			this.RefreshAttribute(true);
		}

		// Token: 0x0603E276 RID: 254582 RVA: 0x00FDDDB0 File Offset: 0x00FDBFB0
		protected override void OnAfterHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotViewChange));
			ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.HonamiStoryLifeSupport, new TValueListener(this.OnAttributeChanged));
			ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(EFormationAttributeId.HonamiStoryLifeSupport, new TValueListener(this.OnAttributeChanged));
		}

		// Token: 0x0603E277 RID: 254583 RVA: 0x00FDDE0C File Offset: 0x00FDC00C
		private void OnPlotViewChange(EUiViewName viewName, bool isShow)
		{
			if (viewName != EUiViewName.PlotViewHUD)
			{
				return;
			}
			if (isShow)
			{
				this.TweenPlayer.StopTweenAnim(this.InTweenType);
				this.TweenPlayer.PlayTweenAnim(this.OutTweenType);
				return;
			}
			this.TweenPlayer.StopTweenAnim(this.OutTweenType);
			this.TweenPlayer.PlayTweenAnim(this.InTweenType);
		}

		// Token: 0x0603E278 RID: 254584 RVA: 0x00FDDE6F File Offset: 0x00FDC06F
		private void OnAttributeChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
		{
			this.RefreshAttribute(false);
		}

		// Token: 0x0603E279 RID: 254585 RVA: 0x00FDDE78 File Offset: 0x00FDC078
		private void RefreshAttribute(bool isInit = false)
		{
			float value = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.HonamiStoryLifeSupport);
			float max = ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.HonamiStoryLifeSupport);
			float num = value / max;
			EHpStateType ehpStateType = EHpStateType.Normal;
			if (num == 0f)
			{
				ehpStateType = EHpStateType.Dead;
			}
			else if (num <= this.DangerPercent)
			{
				ehpStateType = EHpStateType.Danger;
			}
			if (isInit || ehpStateType != this.StateType)
			{
				this.OnRefreshState(ehpStateType);
				string sequenceName = "Start";
				switch (ehpStateType)
				{
				case EHpStateType.Normal:
					sequenceName = (isInit ? "Start" : "Recover");
					break;
				case EHpStateType.Danger:
					sequenceName = "Red";
					break;
				case EHpStateType.Dead:
					sequenceName = "Ovr";
					break;
				}
				this.PlaySequence(sequenceName);
			}
			this.StateType = ehpStateType;
			this.OnRefreshAttribute(num, ehpStateType);
			base.GetText(this.HpTextType).SetText(this.GetHpText(ehpStateType, value, max), true);
		}

		// Token: 0x0603E27A RID: 254586 RVA: 0x00FDDF40 File Offset: 0x00FDC140
		private string GetHpText(EHpStateType state, float curValue, float maxValue)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (state == EHpStateType.Danger)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ec5a7aff>");
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)curValue));
				defaultInterpolatedStringHandler.AppendLiteral("</color><color=#ffffff>/");
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)maxValue));
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (state != EHpStateType.Dead)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)curValue));
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)maxValue));
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#ec5a7aff>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)curValue));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)maxValue));
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603E27B RID: 254587 RVA: 0x00FDE050 File Offset: 0x00FDC250
		private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
		{
			EFunctionType? efunctionType = this.ShowFunctionType;
			if (!(functionType == efunctionType.GetValueOrDefault() & efunctionType != null))
			{
				efunctionType = this.HideFunctionType;
				if (!(functionType == efunctionType.GetValueOrDefault() & efunctionType != null))
				{
					return;
				}
			}
			bool flag = this.ShowFunctionType == null || ModelBase<FunctionModel>.Instance.IsOpen((int)this.ShowFunctionType.Value);
			bool flag2 = this.HideFunctionType == null || ModelBase<FunctionModel>.Instance.IsOpen((int)this.HideFunctionType.Value);
			bool flag3 = !flag || (this.HideFunctionType != null && flag2);
			base.SetVisible(1, !flag3);
		}

		// Token: 0x0603E27C RID: 254588 RVA: 0x00FDE0FD File Offset: 0x00FDC2FD
		private void PlaySequence(string sequenceName)
		{
			this.SequencePlayer.StopPrevSequence(false, true);
			this.SequencePlayer.PlaySequencePurely(sequenceName, false, false);
		}

		// Token: 0x0603E27D RID: 254589 RVA: 0x00FDE11A File Offset: 0x00FDC31A
		protected virtual void OnInitData()
		{
		}

		// Token: 0x0603E27E RID: 254590 RVA: 0x00FDE11C File Offset: 0x00FDC31C
		protected virtual void OnRefreshState(EHpStateType state)
		{
		}

		// Token: 0x0603E27F RID: 254591 RVA: 0x00FDE11E File Offset: 0x00FDC31E
		protected virtual void OnRefreshAttribute(float percent, EHpStateType state)
		{
		}

		// Token: 0x04022D74 RID: 142708
		protected const EFormationAttributeId AttributeId = EFormationAttributeId.HonamiStoryLifeSupport;

		// Token: 0x04022D75 RID: 142709
		private const float ROOT_TRANSLUCENT_ALPHA = 0.2f;

		// Token: 0x04022D76 RID: 142710
		protected float DangerPercent;

		// Token: 0x04022D77 RID: 142711
		protected float NormalPercent;

		// Token: 0x04022D78 RID: 142712
		private EHpStateType StateType;

		// Token: 0x04022D79 RID: 142713
		protected int HpTextType;

		// Token: 0x04022D7A RID: 142714
		protected int InTweenType;

		// Token: 0x04022D7B RID: 142715
		protected int OutTweenType;

		// Token: 0x04022D7C RID: 142716
		protected string DangerPercentConfigId = string.Empty;

		// Token: 0x04022D7D RID: 142717
		protected EFunctionType? ShowFunctionType;

		// Token: 0x04022D7E RID: 142718
		protected EFunctionType? HideFunctionType;

		// Token: 0x04022D7F RID: 142719
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04022D80 RID: 142720
		[Nullable(2)]
		private BattleUiTweenAnimPlayer TweenPlayer;
	}
}
