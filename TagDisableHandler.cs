using System;
using System.Runtime.CompilerServices;

// Token: 0x02003099 RID: 12441
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TagDisableHandler : DisableHandler<InputFunctionContext>
{
	// Token: 0x06019A39 RID: 105017 RVA: 0x00773A0C File Offset: 0x00771C0C
	protected override bool ShouldStop(InputFunctionContext context)
	{
		BaseTagComponent component = context.Entity.GetComponent<BaseTagComponent>();
		if (component == null)
		{
			return false;
		}
		switch (context.SkillId)
		{
		case 800001:
			return component.HasAnyTag(TagDisableHandler.MotorcycleConstraintTags);
		case 800002:
			return component.HasAnyTag(TagDisableHandler.MotorcycleParkConstraintTags);
		case 800003:
			return component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
		default:
			return false;
		}
	}

	// Token: 0x06019A3B RID: 105019 RVA: 0x00773A84 File Offset: 0x00771C84
	// Note: this type is marked as 'beforefieldinit'.
	static TagDisableHandler()
	{
		int[] motorcycleConstraintTags = TagDisableHandler.MotorcycleConstraintTags;
		int num = 0;
		int[] array = new int[5 + motorcycleConstraintTags.Length];
		ReadOnlySpan<int> readOnlySpan = new ReadOnlySpan<int>(motorcycleConstraintTags);
		readOnlySpan.CopyTo(new Span<int>(array).Slice(num, readOnlySpan.Length));
		num += readOnlySpan.Length;
		array[num] = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.控物.空中控物通用"];
		num++;
		array[num] = GameplayTagDefine.EGameplayTagId["战斗状态.技能限制.禁止探索幻象技能"];
		num++;
		array[num] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏探索幻象按键"];
		num++;
		array[num] = GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态.水面"];
		num++;
		array[num] = GameplayTagDefine.EGameplayTagId["行为状态.位置状态.次状态.空中行走"];
		TagDisableHandler.MotorcycleParkConstraintTags = array;
	}

	// Token: 0x0400CC36 RID: 52278
	[StaticVariableRuleIgnore]
	private static readonly int[] MotorcycleConstraintTags = new int[]
	{
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"],
		GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托.下车"]
	};

	// Token: 0x0400CC37 RID: 52279
	[StaticVariableRuleIgnore]
	private static readonly int[] MotorcycleParkConstraintTags;
}
