using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x0200187D RID: 6269
[NullableContext(1)]
[Nullable(0)]
public class CheckIsJumpCondition : BaseCheckCondition
{
	// Token: 0x0600B3CA RID: 46026 RVA: 0x002FED78 File Offset: 0x002FCF78
	public CheckIsJumpCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.SuccessType = EComboTeachingSuccessCondition.Jump;
	}

	// Token: 0x17000ECB RID: 3787
	// (get) Token: 0x0600B3CB RID: 46027 RVA: 0x002FED9E File Offset: 0x002FCF9E
	// (set) Token: 0x0600B3CC RID: 46028 RVA: 0x002FEDA6 File Offset: 0x002FCFA6
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000ECC RID: 3788
	// (get) Token: 0x0600B3CD RID: 46029 RVA: 0x002FEDAF File Offset: 0x002FCFAF
	// (set) Token: 0x0600B3CE RID: 46030 RVA: 0x002FEDB7 File Offset: 0x002FCFB7
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.Jump;

	// Token: 0x0600B3CF RID: 46031 RVA: 0x002FEDC0 File Offset: 0x002FCFC0
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		CharacterMoveComponent characterMoveComponent = (entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null;
		return characterMoveComponent != null && characterMoveComponent.IsJump;
	}
}
