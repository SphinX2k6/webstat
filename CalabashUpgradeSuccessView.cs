using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200182A RID: 6186
public class CalabashUpgradeSuccessView : UiViewBase
{
	// Token: 0x0600B09B RID: 45211 RVA: 0x002F2588 File Offset: 0x002F0788
	[NullableContext(1)]
	public CalabashUpgradeSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B09C RID: 45212 RVA: 0x002F25CC File Offset: 0x002F07CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x0600B09D RID: 45213 RVA: 0x002F2694 File Offset: 0x002F0894
	protected override void OnStart()
	{
		ICalabashUpgradeSuccessViedData calabashUpgradeSuccessViedData = this.OpenParam as ICalabashUpgradeSuccessViedData;
		this.IsLevelUp = (calabashUpgradeSuccessViedData.CurLevel > calabashUpgradeSuccessViedData.PreLevel);
		this.IsExpUp = calabashUpgradeSuccessViedData.AddExp;
		this.IsOverLevel = false;
		base.GetItem(6).SetUIActive(!this.IsExpUp);
		base.GetItem(5).SetUIActive(this.IsExpUp);
		if (this.IsLevelUp)
		{
			base.GetText(3).SetText(calabashUpgradeSuccessViedData.CurLevel.ToString(), true);
			CalabashLevel? calabashConfigByLevel = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(calabashUpgradeSuccessViedData.CurLevel);
			if (calabashConfigByLevel != null && !StringUtils.IsEmpty(calabashConfigByLevel.Value.LevelUpDescription))
			{
				base.GetItem(7).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), calabashConfigByLevel.Value.LevelUpDescription, Array.Empty<object>());
			}
			else
			{
				base.GetItem(7).SetUIActive(false);
			}
		}
		if (this.IsExpUp)
		{
			base.GetText(0).SetText(calabashUpgradeSuccessViedData.PreLevel.ToString(), true);
			this.ShowingExp = (float)calabashUpgradeSuccessViedData.PreExp;
			this.PreMaxExp = (float)ModelBase<CalabashModel>.Instance.GetMaxExpByLevel(calabashUpgradeSuccessViedData.PreLevel);
			this.CurMaxExp = (float)ModelBase<CalabashModel>.Instance.GetMaxExpByLevel(calabashUpgradeSuccessViedData.CurLevel);
			this.TargetExp = (this.IsLevelUp ? ((float)calabashUpgradeSuccessViedData.CurExp + this.PreMaxExp) : ((float)calabashUpgradeSuccessViedData.CurExp));
			this.AddExp = (this.TargetExp - this.ShowingExp) / (float)this.AnimeTime;
			this.RefreshExp();
		}
		this.UiViewSequence.AddSequenceFinishEvent("LevelUp", delegate(string _)
		{
			this.RemoveTimer();
			base.CloseMe(null);
		}, false);
	}

	// Token: 0x17000E60 RID: 3680
	// (get) Token: 0x0600B09E RID: 45214 RVA: 0x002F2856 File Offset: 0x002F0A56
	private bool IsOverLoop
	{
		get
		{
			return this.IsLevelUp && this.ShowingExp >= this.PreMaxExp;
		}
	}

	// Token: 0x0600B09F RID: 45215 RVA: 0x002F2874 File Offset: 0x002F0A74
	private void RefreshExp()
	{
		float num = this.IsOverLoop ? (this.ShowingExp - this.PreMaxExp) : this.ShowingExp;
		float num2 = this.IsOverLoop ? this.CurMaxExp : this.PreMaxExp;
		UUIText text = base.GetText(1);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Round((double)num));
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<float>(num2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetSprite(2).SetFillAmount(num / num2);
		if (this.AnimTimer != null && num > num2 && !this.IsOverLevel)
		{
			this.IsOverLevel = true;
			this.UiViewSequence.PlaySequence("Stuck", false, null);
		}
	}

	// Token: 0x0600B0A0 RID: 45216 RVA: 0x002F293A File Offset: 0x002F0B3A
	private void RemoveTimer()
	{
		if (this.AnimTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AnimTimer);
			this.AnimTimer = null;
		}
	}

	// Token: 0x0600B0A1 RID: 45217 RVA: 0x002F295C File Offset: 0x002F0B5C
	protected override void OnAfterPlayStartSequence()
	{
		if (this.IsExpUp)
		{
			this.AnimTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.BarExpAnime), 20f, 1f, null, null, true);
			return;
		}
		this.AnimTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.RemoveTimer();
			base.CloseMe(null);
		}, (float)this.CloseTime, null, null, true, 1f);
	}

	// Token: 0x0600B0A2 RID: 45218 RVA: 0x002F29C8 File Offset: 0x002F0BC8
	private void BarExpAnime(float delta)
	{
		this.ShowingExp += this.AddExp * delta;
		if (this.ShowingExp >= this.TargetExp)
		{
			this.ShowingExp = this.TargetExp;
			this.RemoveTimer();
			if (this.IsLevelUp)
			{
				base.GetItem(6).SetUIActive(true);
				base.GetItem(5).SetUIActive(false);
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequence("LevelUp", false, null);
				}
			}
			else
			{
				base.CloseMe(null);
			}
		}
		this.RefreshExp();
	}

	// Token: 0x0400539C RID: 21404
	private bool IsLevelUp;

	// Token: 0x0400539D RID: 21405
	private bool IsExpUp;

	// Token: 0x0400539E RID: 21406
	private bool IsOverLevel;

	// Token: 0x0400539F RID: 21407
	private float ShowingExp;

	// Token: 0x040053A0 RID: 21408
	private float PreMaxExp;

	// Token: 0x040053A1 RID: 21409
	private float TargetExp;

	// Token: 0x040053A2 RID: 21410
	private float CurMaxExp;

	// Token: 0x040053A3 RID: 21411
	private float AddExp;

	// Token: 0x040053A4 RID: 21412
	[Nullable(2)]
	private TimerHandle AnimTimer;

	// Token: 0x040053A5 RID: 21413
	private readonly int AnimeTime = ConfigCommonParamById.GetIntConfig("ExpDisplayTime").Value;

	// Token: 0x040053A6 RID: 21414
	private readonly int CloseTime = ConfigCommonParamById.GetIntConfig("ExpDisplayCloseTime").Value;

	// Token: 0x02007BC2 RID: 31682
	private enum ECalabashUpgradeSuccessDefine
	{
		// Token: 0x0402A4C8 RID: 173256
		PreLevelTxt,
		// Token: 0x0402A4C9 RID: 173257
		TxtExp,
		// Token: 0x0402A4CA RID: 173258
		BarExp,
		// Token: 0x0402A4CB RID: 173259
		CurLevelTxt,
		// Token: 0x0402A4CC RID: 173260
		LevelDesc,
		// Token: 0x0402A4CD RID: 173261
		PanelExp,
		// Token: 0x0402A4CE RID: 173262
		PanelLevel,
		// Token: 0x0402A4CF RID: 173263
		LevelUpItem
	}
}
