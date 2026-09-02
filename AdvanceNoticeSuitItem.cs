using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001198 RID: 4504
[Nullable(new byte[]
{
	0,
	1
})]
public class AdvanceNoticeSuitItem : GridProxyAbstract<string>
{
	// Token: 0x06007679 RID: 30329 RVA: 0x001F0513 File Offset: 0x001EE713
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x0600767A RID: 30330 RVA: 0x001F054C File Offset: 0x001EE74C
	[NullableContext(1)]
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		base.SetTextureByPath(data, base.GetTexture(1), null, null);
	}

	// Token: 0x020074F7 RID: 29943
	private class ECom
	{
		// Token: 0x04028623 RID: 165411
		public const int ElementBgSprite = 0;

		// Token: 0x04028624 RID: 165412
		public const int ElementIconTexture = 1;
	}
}
