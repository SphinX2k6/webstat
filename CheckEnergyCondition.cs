using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x0200187C RID: 6268
[NullableContext(1)]
[Nullable(0)]
public class CheckEnergyCondition : BaseCheckCondition
{
	// Token: 0x0600B3C1 RID: 46017 RVA: 0x002FEC18 File Offset: 0x002FCE18
	public CheckEnergyCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.SuccessType = EComboTeachingSuccessCondition.EnergyCheck;
		this.FailType = EComboTeachingFailCondition.EnergyCheck;
	}

	// Token: 0x17000EC8 RID: 3784
	// (get) Token: 0x0600B3C2 RID: 46018 RVA: 0x002FEC4C File Offset: 0x002FCE4C
	// (set) Token: 0x0600B3C3 RID: 46019 RVA: 0x002FEC54 File Offset: 0x002FCE54
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000EC9 RID: 3785
	// (get) Token: 0x0600B3C4 RID: 46020 RVA: 0x002FEC5D File Offset: 0x002FCE5D
	// (set) Token: 0x0600B3C5 RID: 46021 RVA: 0x002FEC65 File Offset: 0x002FCE65
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.EnergyCheck;

	// Token: 0x17000ECA RID: 3786
	// (get) Token: 0x0600B3C6 RID: 46022 RVA: 0x002FEC6E File Offset: 0x002FCE6E
	// (set) Token: 0x0600B3C7 RID: 46023 RVA: 0x002FEC76 File Offset: 0x002FCE76
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.EnergyCheck;

	// Token: 0x0600B3C8 RID: 46024 RVA: 0x002FEC80 File Offset: 0x002FCE80
	protected override bool CheckSuccess(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		if (this.SuccessParamsArray == null)
		{
			return false;
		}
		List<string> list = this.SuccessParamsArray[0];
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		float currentValue = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint).GetComponent<BaseAttributeComponent>().GetCurrentValue(CharacterAttributeTypes.energyAttrIds[int.Parse(list[0])]);
		return currentValue >= float.Parse(list[1]) && currentValue <= float.Parse(list[2]);
	}

	// Token: 0x0600B3C9 RID: 46025 RVA: 0x002FECFC File Offset: 0x002FCEFC
	protected override bool CheckFail(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		if (this.ParamsArray == null)
		{
			return false;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		float currentValue = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint).GetComponent<BaseAttributeComponent>().GetCurrentValue(CharacterAttributeTypes.energyAttrIds[int.Parse(this.ParamsArray[0])]);
		return currentValue >= float.Parse(this.ParamsArray[1]) && currentValue <= float.Parse(this.ParamsArray[2]);
	}
}
