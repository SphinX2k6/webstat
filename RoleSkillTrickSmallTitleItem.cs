using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028D4 RID: 10452
public class RoleSkillTrickSmallTitleItem : UiPanelBase
{
	// Token: 0x06014C45 RID: 85061 RVA: 0x005C1804 File Offset: 0x005BFA04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014C46 RID: 85062 RVA: 0x005C184C File Offset: 0x005BFA4C
	[NullableContext(1)]
	public void SetText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
	}

	// Token: 0x02008C2E RID: 35886
	private enum ETitleComponent
	{
		// Token: 0x0402F38E RID: 193422
		TitleText
	}
}
