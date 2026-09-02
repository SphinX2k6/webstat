using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x02001881 RID: 6273
[NullableContext(1)]
[Nullable(0)]
public class CheckTagNotHaveCondition : BaseCheckCondition
{
	// Token: 0x0600B3E5 RID: 46053 RVA: 0x002FF138 File Offset: 0x002FD338
	public CheckTagNotHaveCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.FailType = EComboTeachingFailCondition.NotHaveTag;
		this.SuccessType = EComboTeachingSuccessCondition.NotHaveTag;
	}

	// Token: 0x17000ED4 RID: 3796
	// (get) Token: 0x0600B3E6 RID: 46054 RVA: 0x002FF16C File Offset: 0x002FD36C
	// (set) Token: 0x0600B3E7 RID: 46055 RVA: 0x002FF174 File Offset: 0x002FD374
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000ED5 RID: 3797
	// (get) Token: 0x0600B3E8 RID: 46056 RVA: 0x002FF17D File Offset: 0x002FD37D
	// (set) Token: 0x0600B3E9 RID: 46057 RVA: 0x002FF185 File Offset: 0x002FD385
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.NotHaveTag;

	// Token: 0x17000ED6 RID: 3798
	// (get) Token: 0x0600B3EA RID: 46058 RVA: 0x002FF18E File Offset: 0x002FD38E
	// (set) Token: 0x0600B3EB RID: 46059 RVA: 0x002FF196 File Offset: 0x002FD396
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.NotHaveTag;

	// Token: 0x0600B3EC RID: 46060 RVA: 0x002FF1A0 File Offset: 0x002FD3A0
	protected override bool CheckFail(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		if (this.ParamsArray == null)
		{
			return false;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		return baseTagComponent == null || !baseTagComponent.HasTag(GameplayTagUtils.GetTagIdByName(this.ParamsArray[0]));
	}

	// Token: 0x0600B3ED RID: 46061 RVA: 0x002FF1FC File Offset: 0x002FD3FC
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
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			if (!baseTagComponent.HasTag(GameplayTagUtils.GetTagIdByName(list[0])))
			{
				return true;
			}
		}
		return false;
	}
}
