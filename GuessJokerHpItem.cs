using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001130 RID: 4400
public class GuessJokerHpItem : GridProxyAbstract<bool>
{
	// Token: 0x06007333 RID: 29491 RVA: 0x001E211E File Offset: 0x001E031E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06007334 RID: 29492 RVA: 0x001E2157 File Offset: 0x001E0357
	protected override void OnStart()
	{
		base.GetSprite(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
		this.LastIsShow = true;
	}

	// Token: 0x06007335 RID: 29493 RVA: 0x001E217A File Offset: 0x001E037A
	public override void Refresh(bool isShow, bool isSelected, int gridIndex)
	{
		if (this.LastIsShow && !isShow)
		{
			this.ShowBrokenAnim();
		}
		base.GetSprite(0).SetUIActive(isShow);
		base.GetItem(1).SetUIActive(!isShow);
		this.LastIsShow = isShow;
	}

	// Token: 0x06007336 RID: 29494 RVA: 0x001E21B4 File Offset: 0x001E03B4
	public void ShowBrokenAnim()
	{
		if (this.LevelSequencePlayer == null)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName("Damage", false, null, false);
	}

	// Token: 0x040037A2 RID: 14242
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040037A3 RID: 14243
	private bool LastIsShow = true;

	// Token: 0x020074BB RID: 29883
	private static class EComponentDefine
	{
		// Token: 0x040284FC RID: 165116
		public const int LightSprite = 0;

		// Token: 0x040284FD RID: 165117
		public const int BrokenItem = 1;
	}
}
