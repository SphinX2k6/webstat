using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A1E RID: 10782
public class SuccessFinishPanel : UiPanelBase
{
	// Token: 0x06015859 RID: 88153 RVA: 0x005F79AC File Offset: 0x005F5BAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick))
		};
	}

	// Token: 0x0601585A RID: 88154 RVA: 0x005F7A14 File Offset: 0x005F5C14
	private void OnCloseBtnClick()
	{
		string currentGameplayId = ModelBase<SignalDecodeModel>.Instance.CurrentGameplayId;
		ControllerBase<GeneralLogicTreeController>.Instance.RequestFinishUiGameplay(UiGamePlayType.MorseCode, currentGameplayId.ToString());
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SignalDecodeView, null);
	}

	// Token: 0x0601585B RID: 88155 RVA: 0x005F7A4D File Offset: 0x005F5C4D
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0601585C RID: 88156 RVA: 0x005F7A60 File Offset: 0x005F5C60
	public void Open()
	{
		string textTableId = (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.Send) ? "SignalSendSuccess" : "SignalReceiveSuccess";
		if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.DrawSword)
		{
			textTableId = "SignalMusicSucceedTips";
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textTableId, Array.Empty<object>());
		base.SetUiActive(true);
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0601585D RID: 88157 RVA: 0x005F7AD8 File Offset: 0x005F5CD8
	public void Close()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x0400A5BB RID: 42427
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008DA2 RID: 36258
	private static class EChildComponent
	{
		// Token: 0x0402F9FD RID: 195069
		public const int LeaveBtn = 0;

		// Token: 0x0402F9FE RID: 195070
		public const int Text = 1;
	}
}
