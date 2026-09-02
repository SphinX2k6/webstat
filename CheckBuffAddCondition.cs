using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x0200187E RID: 6270
[NullableContext(1)]
[Nullable(0)]
public class CheckBuffAddCondition : BaseCheckCondition
{
	// Token: 0x0600B3D0 RID: 46032 RVA: 0x002FEDFA File Offset: 0x002FCFFA
	public CheckBuffAddCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.SuccessType = EComboTeachingSuccessCondition.AddBuff;
	}

	// Token: 0x17000ECD RID: 3789
	// (get) Token: 0x0600B3D1 RID: 46033 RVA: 0x002FEE20 File Offset: 0x002FD020
	// (set) Token: 0x0600B3D2 RID: 46034 RVA: 0x002FEE28 File Offset: 0x002FD028
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000ECE RID: 3790
	// (get) Token: 0x0600B3D3 RID: 46035 RVA: 0x002FEE31 File Offset: 0x002FD031
	// (set) Token: 0x0600B3D4 RID: 46036 RVA: 0x002FEE39 File Offset: 0x002FD039
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.AddBuff;

	// Token: 0x0600B3D5 RID: 46037 RVA: 0x002FEE44 File Offset: 0x002FD044
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo paramex = null)
	{
		if (this.SuccessParamsArray == null)
		{
			return false;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			if (characterBuffComponent.GetBuffTotalStackById(long.Parse(list[0]), false) > 0)
			{
				return true;
			}
		}
		return false;
	}
}
