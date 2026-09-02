using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A17 RID: 10775
public class FailedFinishPanel : UiPanelBase
{
	// Token: 0x060157F1 RID: 88049 RVA: 0x005F598C File Offset: 0x005F3B8C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnStartAgainBtnClick))
		};
	}

	// Token: 0x060157F2 RID: 88050 RVA: 0x005F5A4D File Offset: 0x005F3C4D
	private void OnCloseBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SignalDecodeView, null);
	}

	// Token: 0x060157F3 RID: 88051 RVA: 0x005F5A5F File Offset: 0x005F3C5F
	private void OnStartAgainBtnClick()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalCatchStartAgain);
		this.Close();
	}

	// Token: 0x060157F4 RID: 88052 RVA: 0x005F5A78 File Offset: 0x005F3C78
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.DrawSword)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "SignalMusicFailTips2", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "SignalMusicFailTips", Array.Empty<object>());
		}
	}

	// Token: 0x060157F5 RID: 88053 RVA: 0x005F5AF4 File Offset: 0x005F3CF4
	public void Open()
	{
		base.SetUiActive(true);
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x060157F6 RID: 88054 RVA: 0x005F5B24 File Offset: 0x005F3D24
	public void Close()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x060157F7 RID: 88055 RVA: 0x005F5B4C File Offset: 0x005F3D4C
	[NullableContext(1)]
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Close")
		{
			base.SetUiActive(false);
		}
	}

	// Token: 0x0400A573 RID: 42355
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008D96 RID: 36246
	private static class EChildComponent
	{
		// Token: 0x0402F9BB RID: 195003
		public const int CloseBtn = 0;

		// Token: 0x0402F9BC RID: 195004
		public const int StartAgainBtn = 1;

		// Token: 0x0402F9BD RID: 195005
		public const int CloseBtnText = 2;

		// Token: 0x0402F9BE RID: 195006
		public const int TipsText = 3;

		// Token: 0x0402F9BF RID: 195007
		public const int DecodeFailedText = 4;
	}
}
