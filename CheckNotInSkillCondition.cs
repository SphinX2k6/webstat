using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x02001885 RID: 6277
[NullableContext(1)]
[Nullable(0)]
public class CheckNotInSkillCondition : BaseCheckCondition
{
	// Token: 0x0600B400 RID: 46080 RVA: 0x002FF474 File Offset: 0x002FD674
	public CheckNotInSkillCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.FailType = EComboTeachingFailCondition.InSkillChecker;
	}

	// Token: 0x17000EDD RID: 3805
	// (get) Token: 0x0600B401 RID: 46081 RVA: 0x002FF49A File Offset: 0x002FD69A
	// (set) Token: 0x0600B402 RID: 46082 RVA: 0x002FF4A2 File Offset: 0x002FD6A2
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000EDE RID: 3806
	// (get) Token: 0x0600B403 RID: 46083 RVA: 0x002FF4AB File Offset: 0x002FD6AB
	// (set) Token: 0x0600B404 RID: 46084 RVA: 0x002FF4B3 File Offset: 0x002FD6B3
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.InSkillChecker;

	// Token: 0x0600B405 RID: 46085 RVA: 0x002FF4BC File Offset: 0x002FD6BC
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		return baseTagComponent == null || !baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]);
	}
}
