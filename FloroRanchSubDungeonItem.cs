using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C6C RID: 7276
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchSubDungeonItem : GridProxyAbstract<FloroRanchSubDungeonData>
{
	// Token: 0x0600D45F RID: 54367 RVA: 0x0038AAD0 File Offset: 0x00388CD0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D460 RID: 54368 RVA: 0x0038AB7C File Offset: 0x00388D7C
	[NullableContext(1)]
	public override void Refresh(FloroRanchSubDungeonData data, bool isSelected, int gridIndex)
	{
		UUISprite sprite = base.GetSprite(3);
		if (sprite != null)
		{
			sprite.SetUIActive(gridIndex != 0);
		}
		UUISprite sprite2 = base.GetSprite(0);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(data.IsFinished);
		}
		UUISprite sprite3 = base.GetSprite(2);
		if (sprite3 != null)
		{
			sprite3.SetUIActive(data.IsFinished && gridIndex != 0);
		}
		UUISprite sprite4 = base.GetSprite(1);
		if (sprite4 == null)
		{
			return;
		}
		sprite4.SetUIActive(!data.IsUnLock);
	}

	// Token: 0x02007F94 RID: 32660
	private class EComponents
	{
		// Token: 0x0402B6F7 RID: 177911
		public const int SpriteFinished = 0;

		// Token: 0x0402B6F8 RID: 177912
		public const int SpriteLock = 1;

		// Token: 0x0402B6F9 RID: 177913
		public const int SpriteFinishedLine = 2;

		// Token: 0x0402B6FA RID: 177914
		public const int SpriteOriginalLine = 3;
	}
}
