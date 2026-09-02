using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020022D4 RID: 8916
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyPresetIconItem : GridProxyAbstract<string>
{
	// Token: 0x06010DF7 RID: 69111 RVA: 0x0049F0F8 File Offset: 0x0049D2F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010DF8 RID: 69112 RVA: 0x0049F140 File Offset: 0x0049D340
	[NullableContext(1)]
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		base.SetTextureByPath(data, base.GetTexture(0), null, null);
	}

	// Token: 0x020085B0 RID: 34224
	private class EMotorDiyPresetIconComponent
	{
		// Token: 0x0402D3AF RID: 185263
		public const int TexIcon = 0;
	}
}
