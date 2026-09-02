using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x02001880 RID: 6272
[NullableContext(1)]
[Nullable(0)]
public class CheckBuffNotHaveCondition : BaseCheckCondition
{
	// Token: 0x0600B3DC RID: 46044 RVA: 0x002FEFC8 File Offset: 0x002FD1C8
	public CheckBuffNotHaveCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.FailType = EComboTeachingFailCondition.NotHaveBuff;
		this.SuccessType = EComboTeachingSuccessCondition.NotHaveBuff;
	}

	// Token: 0x17000ED1 RID: 3793
	// (get) Token: 0x0600B3DD RID: 46045 RVA: 0x002FEFFC File Offset: 0x002FD1FC
	// (set) Token: 0x0600B3DE RID: 46046 RVA: 0x002FF004 File Offset: 0x002FD204
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000ED2 RID: 3794
	// (get) Token: 0x0600B3DF RID: 46047 RVA: 0x002FF00D File Offset: 0x002FD20D
	// (set) Token: 0x0600B3E0 RID: 46048 RVA: 0x002FF015 File Offset: 0x002FD215
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.NotHaveBuff;

	// Token: 0x17000ED3 RID: 3795
	// (get) Token: 0x0600B3E1 RID: 46049 RVA: 0x002FF01E File Offset: 0x002FD21E
	// (set) Token: 0x0600B3E2 RID: 46050 RVA: 0x002FF026 File Offset: 0x002FD226
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.NotHaveBuff;

	// Token: 0x0600B3E3 RID: 46051 RVA: 0x002FF030 File Offset: 0x002FD230
	protected override bool CheckFail(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		if (this.ParamsArray == null)
		{
			return false;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		return characterBuffComponent == null || characterBuffComponent.GetBuffTotalStackById(long.Parse(this.ParamsArray[0]), false) <= 0;
	}

	// Token: 0x0600B3E4 RID: 46052 RVA: 0x002FF090 File Offset: 0x002FD290
	protected override bool CheckSuccess(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo paramex = null)
	{
		if (this.SuccessParamsArray == null)
		{
			return false;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		if (entity == null)
		{
			return false;
		}
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			if (characterBuffComponent != null && characterBuffComponent.GetBuffTotalStackById(long.Parse(list[0]), false) == 0)
			{
				return true;
			}
		}
		return false;
	}
}
