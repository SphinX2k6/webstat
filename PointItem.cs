using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C53 RID: 7251
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PointItem : GridProxyAbstract<IProgressItem>
{
	// Token: 0x0600D396 RID: 54166 RVA: 0x00386864 File Offset: 0x00384A64
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D397 RID: 54167 RVA: 0x003868AC File Offset: 0x00384AAC
	public override void Refresh(IProgressItem data, bool isSelected, int gridIndex)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetUIActive(!data.IsPassed);
		}
		if (!this.LastIsPassed && data.IsPassed)
		{
			this.ShowPassAnim();
		}
		this.LastIsPassed = data.IsPassed;
	}

	// Token: 0x0600D398 RID: 54168 RVA: 0x003868EC File Offset: 0x00384AEC
	public void ShowPassAnim()
	{
		if (this.LevelSequencePlayer == null)
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName("DayGone", false, null, false);
	}

	// Token: 0x040064BC RID: 25788
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040064BD RID: 25789
	private bool LastIsPassed;

	// Token: 0x02007F64 RID: 32612
	[NullableContext(0)]
	private class EPointItemComponentDefine
	{
		// Token: 0x0402B5F7 RID: 177655
		public const int ShowSprite = 0;
	}
}
