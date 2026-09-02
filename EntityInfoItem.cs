using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025D9 RID: 9689
public class EntityInfoItem : UiPanelBase
{
	// Token: 0x06012F16 RID: 77590 RVA: 0x0053D2D4 File Offset: 0x0053B4D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06012F17 RID: 77591 RVA: 0x0053D330 File Offset: 0x0053B530
	public void InitSpr()
	{
		if (this.UiSequencePlayer == null)
		{
			this.UiSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}
		this.UiSequencePlayer.StopCurrentSequence(false, true);
		this.UiSequencePlayer.PlayLevelSequenceByName("Fail", false, null, false);
		this.Finished = false;
	}

	// Token: 0x06012F18 RID: 77592 RVA: 0x0053D388 File Offset: 0x0053B588
	[NullableContext(1)]
	public void Refresh(IInfoData info)
	{
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(info.Text);
		if (string.IsNullOrEmpty(configTextByKey))
		{
			this.RefreshFinishState(info.IsFinish);
			return;
		}
		if (info.IsOptionFinished)
		{
			this.SetTextLine(info.Text);
			return;
		}
		base.GetText(2).SetText(configTextByKey, true);
	}

	// Token: 0x06012F19 RID: 77593 RVA: 0x0053D3E0 File Offset: 0x0053B5E0
	public void RefreshFinishState(bool bFinished)
	{
		if (bFinished && !this.Finished)
		{
			this.UiSequencePlayer.StopCurrentSequence(false, true);
			this.UiSequencePlayer.PlayLevelSequenceByName("Complete", false, null, false);
			this.Finished = true;
			return;
		}
		if (!bFinished && this.Finished)
		{
			this.UiSequencePlayer.StopCurrentSequence(false, true);
			this.UiSequencePlayer.PlayLevelSequenceByName("Fail", false, null, false);
			this.Finished = false;
		}
	}

	// Token: 0x06012F1A RID: 77594 RVA: 0x0053D464 File Offset: 0x0053B664
	[NullableContext(1)]
	public void SetTextLine(string description)
	{
		string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(description);
		if (!string.IsNullOrEmpty(configTextByKey))
		{
			base.GetText(2).SetText("<s>" + configTextByKey + "</s>", true);
			this.UiSequencePlayer.StopCurrentSequence(false, true);
			this.UiSequencePlayer.PlayLevelSequenceByName("Complete", false, null, false);
			this.UiSequencePlayer.StopCurrentSequence(false, true);
			this.Finished = true;
		}
	}

	// Token: 0x040093E3 RID: 37859
	[Nullable(2)]
	protected LevelSequencePlayer UiSequencePlayer;

	// Token: 0x040093E4 RID: 37860
	private bool Finished;

	// Token: 0x02008942 RID: 35138
	private enum EItemChildType
	{
		// Token: 0x0402E502 RID: 189698
		TitleBg,
		// Token: 0x0402E503 RID: 189699
		SpriteTick,
		// Token: 0x0402E504 RID: 189700
		Text
	}
}
