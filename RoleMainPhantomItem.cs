using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020028E6 RID: 10470
public class RoleMainPhantomItem : RolePhantomItem
{
	// Token: 0x06014CB1 RID: 85169 RVA: 0x005C2632 File Offset: 0x005C0832
	[NullableContext(1)]
	public RoleMainPhantomItem(UUIItem uiItem, Action<int> onFunction, EPhantomItemIndex index) : base(uiItem, onFunction, index)
	{
	}

	// Token: 0x06014CB2 RID: 85170 RVA: 0x005C2640 File Offset: 0x005C0840
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(base.OnClick))
		};
	}

	// Token: 0x06014CB3 RID: 85171 RVA: 0x005C26FF File Offset: 0x005C08FF
	protected override void OnStart()
	{
		this.SkillButtonCompose = new SkillButtonCompose(base.GetItem(3), new Action(base.OnClickSkillButton));
	}

	// Token: 0x06014CB4 RID: 85172 RVA: 0x005C271F File Offset: 0x005C091F
	public override void UpdateItem(int id)
	{
		base.UpdateItem(id);
		this.SkillButtonCompose.Update(id);
	}

	// Token: 0x0400A019 RID: 40985
	[Nullable(2)]
	private SkillButtonCompose SkillButtonCompose;

	// Token: 0x02008C39 RID: 35897
	private enum EPhantomItemDefine
	{
		// Token: 0x0402F3B6 RID: 193462
		ItemButton,
		// Token: 0x0402F3B7 RID: 193463
		PhantomIconTexture,
		// Token: 0x0402F3B8 RID: 193464
		QualitySprite,
		// Token: 0x0402F3B9 RID: 193465
		EquipSkillItem,
		// Token: 0x0402F3BA RID: 193466
		LevelItem,
		// Token: 0x0402F3BB RID: 193467
		LevelText
	}
}
