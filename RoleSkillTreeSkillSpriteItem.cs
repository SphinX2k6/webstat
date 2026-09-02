using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028D0 RID: 10448
public class RoleSkillTreeSkillSpriteItem : UiPanelBase
{
	// Token: 0x06014C1B RID: 85019 RVA: 0x005C0DAB File Offset: 0x005BEFAB
	[NullableContext(1)]
	public RoleSkillTreeSkillSpriteItem(AActor actor)
	{
		base.CreateThenShowByActor(actor, null);
	}

	// Token: 0x06014C1C RID: 85020 RVA: 0x005C0DBC File Offset: 0x005BEFBC
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

	// Token: 0x06014C1D RID: 85021 RVA: 0x005C0E04 File Offset: 0x005BF004
	public void Update(int skillId)
	{
		this.SetSpriteByPath(ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId).Value.Icon, base.GetSprite(0), false, null, null);
	}

	// Token: 0x02008C27 RID: 35879
	private enum EComponents
	{
		// Token: 0x0402F376 RID: 193398
		IconSprite
	}
}
