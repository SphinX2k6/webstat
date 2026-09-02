using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001628 RID: 5672
public class VersionPreheatQuestDetailRoleItem : UiPanelBase
{
	// Token: 0x06009FF0 RID: 40944 RVA: 0x0029CF10 File Offset: 0x0029B110
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

	// Token: 0x06009FF1 RID: 40945 RVA: 0x0029CF58 File Offset: 0x0029B158
	[NullableContext(1)]
	public void RefreshExternal(string iconPath)
	{
		base.SetTextureByPath(iconPath, base.GetTexture(0), null, null);
	}

	// Token: 0x020079E4 RID: 31204
	private class ERoleComponent
	{
		// Token: 0x04029D9D RID: 171421
		public const int RoleIconTexture = 0;
	}
}
