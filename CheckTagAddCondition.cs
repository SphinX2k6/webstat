using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x0200187F RID: 6271
[NullableContext(1)]
[Nullable(0)]
public class CheckTagAddCondition : BaseCheckCondition
{
	// Token: 0x0600B3D6 RID: 46038 RVA: 0x002FEEE4 File Offset: 0x002FD0E4
	public CheckTagAddCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.SuccessType = EComboTeachingSuccessCondition.AddTag;
	}

	// Token: 0x17000ECF RID: 3791
	// (get) Token: 0x0600B3D7 RID: 46039 RVA: 0x002FEF0A File Offset: 0x002FD10A
	// (set) Token: 0x0600B3D8 RID: 46040 RVA: 0x002FEF12 File Offset: 0x002FD112
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000ED0 RID: 3792
	// (get) Token: 0x0600B3D9 RID: 46041 RVA: 0x002FEF1B File Offset: 0x002FD11B
	// (set) Token: 0x0600B3DA RID: 46042 RVA: 0x002FEF23 File Offset: 0x002FD123
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.AddTag;

	// Token: 0x0600B3DB RID: 46043 RVA: 0x002FEF2C File Offset: 0x002FD12C
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo paramex = null)
	{
		if (this.SuccessParamsArray == null)
		{
			return false;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(list[0]);
			if (baseTagComponent.HasTag(tagIdByName))
			{
				return true;
			}
		}
		return false;
	}
}
