using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010CC RID: 4300
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GolemHackingCodeInputItem : GridProxyAbstract<GolemHackingInputInfo>
{
	// Token: 0x06006FEC RID: 28652 RVA: 0x001D2760 File Offset: 0x001D0960
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FED RID: 28653 RVA: 0x001D284D File Offset: 0x001D0A4D
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEnded), false);
	}

	// Token: 0x06006FEE RID: 28654 RVA: 0x001D2878 File Offset: 0x001D0A78
	[NullableContext(1)]
	public override void Refresh(GolemHackingInputInfo data, bool isSelected, int gridIndex)
	{
		GolemHackingInputInfo inputData = this.InputData;
		EGolemHackingInputState? oldState = (inputData != null) ? new EGolemHackingInputState?(inputData.State) : null;
		this.InputData = data;
		if (this.TimerHandle != null)
		{
			if (this.TimerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
			this.TimerHandle = null;
		}
		this.PlayAnim(oldState);
		this.UpdateInfo();
	}

	// Token: 0x06006FEF RID: 28655 RVA: 0x001D28E8 File Offset: 0x001D0AE8
	protected void PlayAnim(EGolemHackingInputState? oldState)
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null && sequencePlayer.IsPlayingSequence("Sle"))
		{
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null)
			{
				sequencePlayer2.StopSequenceByKey("Sle", false, true);
			}
		}
		LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
		if (sequencePlayer3 != null && sequencePlayer3.IsPlayingSequence("Reset"))
		{
			LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
			if (sequencePlayer4 != null)
			{
				sequencePlayer4.StopSequenceByKey("Reset", false, true);
			}
		}
		LevelSequencePlayer sequencePlayer5 = this.SequencePlayer;
		if (sequencePlayer5 != null && sequencePlayer5.IsPlayingSequence("Success"))
		{
			LevelSequencePlayer sequencePlayer6 = this.SequencePlayer;
			if (sequencePlayer6 != null)
			{
				sequencePlayer6.StopSequenceByKey("Success", false, true);
			}
		}
		LevelSequencePlayer sequencePlayer7 = this.SequencePlayer;
		if (sequencePlayer7 != null && sequencePlayer7.IsPlayingSequence("Fail"))
		{
			LevelSequencePlayer sequencePlayer8 = this.SequencePlayer;
			if (sequencePlayer8 != null)
			{
				sequencePlayer8.StopSequenceByKey("Fail", false, true);
			}
		}
		if (this.InputData.AnimIndex <= 0)
		{
			if (!(oldState != EGolemHackingInputState.Enterring) && this.InputData.State == EGolemHackingInputState.Occupy)
			{
				LevelSequencePlayer sequencePlayer9 = this.SequencePlayer;
				if (sequencePlayer9 == null)
				{
					return;
				}
				sequencePlayer9.PlayOrReplaySequenceByName("Sle", false, null);
			}
			return;
		}
		int num = 80 * (this.InputData.AnimIndex - 1);
		if (num != 0)
		{
			this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				LevelSequencePlayer sequencePlayer11 = this.SequencePlayer;
				if (sequencePlayer11 == null)
				{
					return;
				}
				sequencePlayer11.PlayOrReplaySequenceByName(this.InputData.AnimName, false, null);
			}, (float)num, null, null, true, 1f);
			return;
		}
		LevelSequencePlayer sequencePlayer10 = this.SequencePlayer;
		if (sequencePlayer10 == null)
		{
			return;
		}
		sequencePlayer10.PlayOrReplaySequenceByName(this.InputData.AnimName, false, null);
	}

	// Token: 0x06006FF0 RID: 28656 RVA: 0x001D2A68 File Offset: 0x001D0C68
	public void UpdateInfo()
	{
		EGolemHackingInputState state = this.InputData.State;
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(state == EGolemHackingInputState.Empty);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 != null)
		{
			item2.SetUIActive(state == EGolemHackingInputState.Enterring);
		}
		UUIItem item3 = base.GetItem(1);
		if (item3 != null)
		{
			item3.SetUIActive(state == EGolemHackingInputState.Occupy);
		}
		UUIItem item4 = base.GetItem(5);
		if (item4 != null)
		{
			item4.SetUIActive(state == EGolemHackingInputState.Block);
		}
		if (state == EGolemHackingInputState.Empty || state == EGolemHackingInputState.Block)
		{
			return;
		}
		if (state == EGolemHackingInputState.Occupy)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(this.InputData.Code, true);
			return;
		}
		else
		{
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(this.InputData.Code, true);
			return;
		}
	}

	// Token: 0x06006FF1 RID: 28657 RVA: 0x001D2B20 File Offset: 0x001D0D20
	[NullableContext(1)]
	public void EnterInputCode(string code)
	{
		if (this.InputData.State == EGolemHackingInputState.Enterring)
		{
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.SetText(code, true);
		}
	}

	// Token: 0x06006FF2 RID: 28658 RVA: 0x001D2B43 File Offset: 0x001D0D43
	public void ClearInputCode()
	{
		if (this.InputData.State == EGolemHackingInputState.Enterring)
		{
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.SetText("", true);
		}
	}

	// Token: 0x06006FF3 RID: 28659 RVA: 0x001D2B6A File Offset: 0x001D0D6A
	[NullableContext(1)]
	private void OnSequenceEnded(string sequenceName)
	{
		if (sequenceName == "Success" || sequenceName == "Fail")
		{
			Action onBarAnimEnd = this.OnBarAnimEnd;
			if (onBarAnimEnd == null)
			{
				return;
			}
			onBarAnimEnd();
		}
	}

	// Token: 0x040035DD RID: 13789
	private const int INTERVAL_TIME = 80;

	// Token: 0x040035DE RID: 13790
	public Action OnBarAnimEnd;

	// Token: 0x040035DF RID: 13791
	protected GolemHackingInputInfo InputData;

	// Token: 0x040035E0 RID: 13792
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x040035E1 RID: 13793
	protected TimerHandle TimerHandle;

	// Token: 0x0200745B RID: 29787
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x04028385 RID: 164741
		PanelEmpty,
		// Token: 0x04028386 RID: 164742
		PanelEnterCode,
		// Token: 0x04028387 RID: 164743
		TxtEnter,
		// Token: 0x04028388 RID: 164744
		PanelReadyEnter,
		// Token: 0x04028389 RID: 164745
		TxtReadyCode,
		// Token: 0x0402838A RID: 164746
		PanelLockState
	}
}
