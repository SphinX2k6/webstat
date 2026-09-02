using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020B6 RID: 8374
public class GameplayEnterView : UiViewBase
{
	// Token: 0x0600FFC2 RID: 65474 RVA: 0x0046377E File Offset: 0x0046197E
	[NullableContext(1)]
	public GameplayEnterView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FFC3 RID: 65475 RVA: 0x00463787 File Offset: 0x00461987
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600FFC4 RID: 65476 RVA: 0x004637C0 File Offset: 0x004619C0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
	}

	// Token: 0x0600FFC5 RID: 65477 RVA: 0x004637DE File Offset: 0x004619DE
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnTextLanguageChange));
	}

	// Token: 0x0600FFC6 RID: 65478 RVA: 0x004637FC File Offset: 0x004619FC
	protected override void OnStart()
	{
		this.InitMain();
	}

	// Token: 0x0600FFC7 RID: 65479 RVA: 0x00463804 File Offset: 0x00461A04
	[NullableContext(1)]
	private void OnTextLanguageChange(string oldLang, string newLang)
	{
		this.InitMain();
	}

	// Token: 0x0600FFC8 RID: 65480 RVA: 0x0046380C File Offset: 0x00461A0C
	private void InitMain()
	{
		GameplayEnterViewData gameplayEnterViewData = this.OpenParam as GameplayEnterViewData;
		if (gameplayEnterViewData == null)
		{
			return;
		}
		string textById = ConfigBase<TextConfig>.Instance.GetTextById(gameplayEnterViewData.InfoId ?? "");
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(gameplayEnterViewData.TitleId ?? "");
		base.GetText(0).SetText(textById ?? "", true);
		base.GetText(1).SetText(configTextByKey, true);
	}

	// Token: 0x0600FFC9 RID: 65481 RVA: 0x00463882 File Offset: 0x00461A82
	protected override void OnAfterPlayStartSequence()
	{
		this.DelayClose();
	}

	// Token: 0x0600FFCA RID: 65482 RVA: 0x0046388A File Offset: 0x00461A8A
	private void DelayClose()
	{
		this.TimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.CloseView();
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x0600FFCB RID: 65483 RVA: 0x004638B5 File Offset: 0x00461AB5
	private void CloseView()
	{
		this.TimerId = null;
		base.CloseMe(null);
	}

	// Token: 0x0600FFCC RID: 65484 RVA: 0x004638C5 File Offset: 0x00461AC5
	protected override void OnBeforeDestroy()
	{
		if (this.TimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			this.TimerId = null;
		}
	}

	// Token: 0x04007A9B RID: 31387
	[Nullable(2)]
	protected TimerHandle TimerId;

	// Token: 0x02008440 RID: 33856
	private class EGameplayEnterViewCom
	{
		// Token: 0x0402CD2F RID: 183599
		public const int InfoText = 0;

		// Token: 0x0402CD30 RID: 183600
		public const int TitleText = 1;
	}
}
