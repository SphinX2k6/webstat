using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x02001886 RID: 6278
[NullableContext(1)]
[Nullable(0)]
public class CheckIsInJumpCondition : BaseCheckCondition
{
	// Token: 0x0600B406 RID: 46086 RVA: 0x002FF509 File Offset: 0x002FD709
	public CheckIsInJumpCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.FailType = EComboTeachingFailCondition.NotInJump;
	}

	// Token: 0x17000EDF RID: 3807
	// (get) Token: 0x0600B407 RID: 46087 RVA: 0x002FF52F File Offset: 0x002FD72F
	// (set) Token: 0x0600B408 RID: 46088 RVA: 0x002FF537 File Offset: 0x002FD737
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000EE0 RID: 3808
	// (get) Token: 0x0600B409 RID: 46089 RVA: 0x002FF540 File Offset: 0x002FD740
	// (set) Token: 0x0600B40A RID: 46090 RVA: 0x002FF548 File Offset: 0x002FD748
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.NotInJump;

	// Token: 0x0600B40B RID: 46091 RVA: 0x002FF554 File Offset: 0x002FD754
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		object obj = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		bool flag = ModelBase<ComboTeachingModel>.Instance.BeforeJumpTime > 0f;
		object obj2 = obj;
		bool? flag2 = (obj2 != null) ? new bool?(obj2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.地面"])) : null;
		return !flag && flag2.GetValueOrDefault();
	}
}
