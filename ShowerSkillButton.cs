using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002A0E RID: 10766
[NullableContext(2)]
[Nullable(0)]
public class ShowerSkillButton : UiPanelBase
{
	// Token: 0x060157B7 RID: 87991 RVA: 0x005F4908 File Offset: 0x005F2B08
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick))
		};
	}

	// Token: 0x060157B8 RID: 87992 RVA: 0x005F49B1 File Offset: 0x005F2BB1
	protected override void OnStart()
	{
		this.CoolDownUiItem = base.GetItem(1);
		this.CoolDownBarUiSprite = base.GetSprite(2);
		this.CoolDownUiText = base.GetText(3);
		this.SetSkillButtonEnable(true);
	}

	// Token: 0x060157B9 RID: 87993 RVA: 0x005F49E1 File Offset: 0x005F2BE1
	private void SetSkillButtonEnable(bool bEnable)
	{
		this.Enable = bEnable;
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(bEnable);
	}

	// Token: 0x060157BA RID: 87994 RVA: 0x005F49FC File Offset: 0x005F2BFC
	public void TickSkillCoolDown(float delta)
	{
		if (this.CurrentCoolDownTime <= 0f || this.TotalCoolDownTime <= 0f || this.CoolDownBarUiSprite == null)
		{
			return;
		}
		double num = (Singleton<Time>.Instance.WorldTimeSeconds - this.CoolDownStartTime) / (double)this.TotalCoolDownTime;
		this.CoolDownBarUiSprite.SetFillAmount((float)num);
		UUIText coolDownUiText = this.CoolDownUiText;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("F");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CdFixedPoint);
		coolDownUiText.SetText(this.CurrentCoolDownTime.ToString(defaultInterpolatedStringHandler.ToStringAndClear()), true);
	}

	// Token: 0x060157BB RID: 87995 RVA: 0x005F4A93 File Offset: 0x005F2C93
	public void ResetSkillCoolDown()
	{
		this.SetSkillButtonEnable(true);
		UUIItem coolDownUiItem = this.CoolDownUiItem;
		if (coolDownUiItem != null)
		{
			coolDownUiItem.SetUIActive(false);
		}
		this.ResetCoolDownTimer();
		this.CurrentCoolDownTime = 0f;
	}

	// Token: 0x060157BC RID: 87996 RVA: 0x005F4AC0 File Offset: 0x005F2CC0
	private void ResetCoolDownTimer()
	{
		if (this.ChangeCoolDownRefreshTimerId != null && TimerSystem.Instance.Has(this.ChangeCoolDownRefreshTimerId))
		{
			TimerSystem.Instance.Remove(this.ChangeCoolDownRefreshTimerId);
		}
		if (this.HideCdTimerId != null && TimerSystem.Instance.Has(this.HideCdTimerId))
		{
			TimerSystem.Instance.Remove(this.HideCdTimerId);
		}
	}

	// Token: 0x060157BD RID: 87997 RVA: 0x005F4B24 File Offset: 0x005F2D24
	public void PlaySwitchCd()
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("ShowerVisionChangeCoolDown");
		if (intConfig != null && intConfig.GetValueOrDefault() != 0)
		{
			float num = (float)Singleton<TimeUtil>.Instance.SetTimeSecond((double)intConfig.Value);
			this.PlaySkillTimeDown(num, num);
		}
	}

	// Token: 0x060157BE RID: 87998 RVA: 0x005F4B6C File Offset: 0x005F2D6C
	private void PlaySkillTimeDown(float coolDownTime, float totalCoolDown)
	{
		this.ResetCoolDownTimer();
		this.CurrentCoolDownTime = 0f;
		if (coolDownTime <= 0f)
		{
			this.CoolDownUiItem.SetUIActive(false);
			this.SetSkillButtonEnable(true);
			return;
		}
		this.CurrentCoolDownTime = coolDownTime;
		this.TotalCoolDownTime = totalCoolDown;
		this.CoolDownStartTime = Singleton<Time>.Instance.WorldTimeSeconds - (double)(totalCoolDown - coolDownTime);
		UUIText coolDownUiText = this.CoolDownUiText;
		if (coolDownUiText != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("F");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CdFixedPoint);
			coolDownUiText.SetText(this.CurrentCoolDownTime.ToString(defaultInterpolatedStringHandler.ToStringAndClear()), true);
		}
		this.ChangeCoolDownRefreshTimerId = TimerSystem.Instance.Forever(new TTimerAction(this.OnSkillCoolDownRefresh), 100f, 1f, null, null, true);
		this.RefreshTimeDilationAtTimerCreate(this.ChangeCoolDownRefreshTimerId);
		this.CoolDownUiItem.SetUIActive(true);
		this.SetSkillButtonEnable(false);
	}

	// Token: 0x060157BF RID: 87999 RVA: 0x005F4C58 File Offset: 0x005F2E58
	private void OnSkillCoolDownRefresh(float delta)
	{
		this.CurrentCoolDownTime -= 0.1f;
		this.CurrentCoolDownTime = (float)(Math.Round((double)(this.CurrentCoolDownTime * 10f)) / 10.0);
		if (this.CurrentCoolDownTime > 0f)
		{
			UUIText coolDownUiText = this.CoolDownUiText;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("F");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CdFixedPoint);
			coolDownUiText.SetText(this.CurrentCoolDownTime.ToString(defaultInterpolatedStringHandler.ToStringAndClear()), true);
			return;
		}
		this.FinishSkillCoolDown();
	}

	// Token: 0x060157C0 RID: 88000 RVA: 0x005F4CEE File Offset: 0x005F2EEE
	protected void FinishSkillCoolDown()
	{
		this.ResetSkillCoolDown();
	}

	// Token: 0x060157C1 RID: 88001 RVA: 0x005F4CF8 File Offset: 0x005F2EF8
	[NullableContext(1)]
	private void RefreshTimeDilationAtTimerCreate(TimerHandle timerId)
	{
		float timeDilation = this.GetTimeDilation();
		if (timeDilation != 1f)
		{
			if (timeDilation > 0f)
			{
				TimerSystem.Instance.ChangeDilation(timerId, timeDilation, null);
				return;
			}
			TimerSystem.Instance.Pause(timerId, null);
		}
	}

	// Token: 0x060157C2 RID: 88002 RVA: 0x005F4D38 File Offset: 0x005F2F38
	private float GetTimeDilation()
	{
		return Singleton<Time>.Instance.TimeDilation;
	}

	// Token: 0x060157C3 RID: 88003 RVA: 0x005F4D44 File Offset: 0x005F2F44
	[NullableContext(1)]
	public void SetPressCallback(Action onPressCallback)
	{
		this.OnPressCallback = onPressCallback;
	}

	// Token: 0x060157C4 RID: 88004 RVA: 0x005F4D4D File Offset: 0x005F2F4D
	private void OnButtonClick()
	{
		if (!this.Enable)
		{
			return;
		}
		if (this.DisabledHintCallback != null)
		{
			this.DisabledHintCallback();
			return;
		}
		Action onPressCallback = this.OnPressCallback;
		if (onPressCallback == null)
		{
			return;
		}
		onPressCallback();
	}

	// Token: 0x060157C5 RID: 88005 RVA: 0x005F4D7C File Offset: 0x005F2F7C
	[NullableContext(1)]
	public void SetSkillIconSprite(string path)
	{
		UUISprite sprite = base.GetSprite(4);
		this.SetSpriteByPath(path, sprite, true, null, null);
		UUISpriteTransition uiSpriteTransition = sprite.GetOwner().GetComponentByClass(UUISpriteTransition.StaticClass()) as UUISpriteTransition;
		base.SetSpriteTransitionByPath(path, uiSpriteTransition, EUISelectableSelectionState.EUISelectableSelectionState_MAX).Forget();
	}

	// Token: 0x060157C6 RID: 88006 RVA: 0x005F4DCD File Offset: 0x005F2FCD
	public void SetButtonInteractive(bool value)
	{
		base.GetButton(0).SetSelfInteractive(value);
	}

	// Token: 0x060157C7 RID: 88007 RVA: 0x005F4DDC File Offset: 0x005F2FDC
	public void SetDisabledHint(Action callback)
	{
		this.DisabledHintCallback = callback;
	}

	// Token: 0x0400A547 RID: 42311
	private const int SKILL_COOLDOWN_INTERVAL = 100;

	// Token: 0x0400A548 RID: 42312
	private const float SKILL_COOLDOWN_LOOP_INTERVAL = 0.1f;

	// Token: 0x0400A549 RID: 42313
	private Action OnPressCallback;

	// Token: 0x0400A54A RID: 42314
	private bool Enable;

	// Token: 0x0400A54B RID: 42315
	private Action DisabledHintCallback;

	// Token: 0x0400A54C RID: 42316
	private UUIItem CoolDownUiItem;

	// Token: 0x0400A54D RID: 42317
	private UUIText CoolDownUiText;

	// Token: 0x0400A54E RID: 42318
	private UUISprite CoolDownBarUiSprite;

	// Token: 0x0400A54F RID: 42319
	private float CurrentCoolDownTime;

	// Token: 0x0400A550 RID: 42320
	private float TotalCoolDownTime;

	// Token: 0x0400A551 RID: 42321
	private double CoolDownStartTime;

	// Token: 0x0400A552 RID: 42322
	private TimerHandle ChangeCoolDownRefreshTimerId;

	// Token: 0x0400A553 RID: 42323
	private readonly TimerHandle HideCdTimerId;

	// Token: 0x0400A554 RID: 42324
	private readonly int CdFixedPoint = 1;

	// Token: 0x02008D8D RID: 36237
	[NullableContext(0)]
	private class EShowerSkillButtonDefine
	{
		// Token: 0x0402F98B RID: 194955
		public const int Button = 0;

		// Token: 0x0402F98C RID: 194956
		public const int CoolDownItem = 1;

		// Token: 0x0402F98D RID: 194957
		public const int CoolDownBarSprite = 2;

		// Token: 0x0402F98E RID: 194958
		public const int CoolDownText = 3;

		// Token: 0x0402F98F RID: 194959
		public const int SkillIconSprite = 4;
	}
}
