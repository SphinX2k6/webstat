using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010CD RID: 4301
public class GolemHackingCodeKeyBarItem : GridProxyAbstract<EGolemHackingBarState>
{
	// Token: 0x06006FF6 RID: 28662 RVA: 0x001D2BD4 File Offset: 0x001D0DD4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FF7 RID: 28663 RVA: 0x001D2C3D File Offset: 0x001D0E3D
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
	}

	// Token: 0x06006FF8 RID: 28664 RVA: 0x001D2C68 File Offset: 0x001D0E68
	public override void Refresh(EGolemHackingBarState data, bool isSelected, int gridIndex)
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null && sequencePlayer.IsPlayingSequence("Success"))
		{
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null)
			{
				sequencePlayer2.StopSequenceByKey("Success", false, false);
			}
		}
		LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
		if (sequencePlayer3 != null && sequencePlayer3.IsPlayingSequence("Fail"))
		{
			LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
			if (sequencePlayer4 != null)
			{
				sequencePlayer4.StopSequenceByKey("Fail", false, false);
			}
		}
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetUIActive(data == EGolemHackingBarState.Success);
		}
		UUISprite sprite2 = base.GetSprite(1);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(data == EGolemHackingBarState.Fail);
		}
		if (this.CurState != data && this.CurState == EGolemHackingBarState.Default)
		{
			string sequenceName = (data == EGolemHackingBarState.Success) ? "Success" : "Fail";
			LevelSequencePlayer sequencePlayer5 = this.SequencePlayer;
			if (sequencePlayer5 != null)
			{
				sequencePlayer5.PlayOrReplaySequenceByName(sequenceName, false, null);
			}
		}
		else if (data != EGolemHackingBarState.Default)
		{
			this.OnSequenceClose("");
		}
		this.CurState = data;
	}

	// Token: 0x06006FF9 RID: 28665 RVA: 0x001D2D58 File Offset: 0x001D0F58
	[NullableContext(1)]
	private void OnSequenceClose(string _)
	{
		Action onAnimEndCallback = this.OnAnimEndCallback;
		if (onAnimEndCallback == null)
		{
			return;
		}
		onAnimEndCallback();
	}

	// Token: 0x040035E2 RID: 13794
	[Nullable(2)]
	public Action OnAnimEndCallback;

	// Token: 0x040035E3 RID: 13795
	[Nullable(2)]
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x040035E4 RID: 13796
	protected EGolemHackingBarState CurState;

	// Token: 0x0200745C RID: 29788
	private enum EDefine
	{
		// Token: 0x0402838C RID: 164748
		Success,
		// Token: 0x0402838D RID: 164749
		Fail
	}
}
