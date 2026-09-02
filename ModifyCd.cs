using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F4E RID: 12110
[NullableContext(1)]
[Nullable(0)]
public class ModifyCd : BuffEffect
{
	// Token: 0x06018C73 RID: 101491 RVA: 0x00701297 File Offset: 0x006FF497
	public ModifyCd(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C74 RID: 101492 RVA: 0x007012B4 File Offset: 0x006FF4B4
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			this.SkillIdOrGenres.Add(long.Parse(array[i]));
		}
		this.SkillType = int.Parse(extraEffectParameters_[1]);
		this.ModifyType = (EModifyCdType)int.Parse(extraEffectParameters_[2]);
		this.ModifyValues = parameters.ExtraEffectGrowParameters1;
	}

	// Token: 0x06018C75 RID: 101493 RVA: 0x00701320 File Offset: 0x006FF520
	public override void OnCreated()
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseSkillCdComponent baseSkillCdComponent = (exactOwnerEntity != null) ? exactOwnerEntity.GetComponent<BaseSkillCdComponent>() : null;
		if (baseSkillCdComponent == null)
		{
			return;
		}
		this.ModifyValue = AbilityUtils.GetLevelValue<float>(this.ModifyValues, this.Level, 0f);
		if (this.ModifyType == EModifyCdType.Multiply || this.ModifyType == EModifyCdType.AddPerTenThousand)
		{
			this.ModifyValue *= 0.0001f;
		}
		baseSkillCdComponent.UpdateModifyCdEffect(true, this);
	}

	// Token: 0x06018C76 RID: 101494 RVA: 0x0070138C File Offset: 0x006FF58C
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C77 RID: 101495 RVA: 0x00701390 File Offset: 0x006FF590
	public override void OnRemoved(bool bPremature)
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseSkillCdComponent baseSkillCdComponent = (exactOwnerEntity != null) ? exactOwnerEntity.GetComponent<BaseSkillCdComponent>() : null;
		if (baseSkillCdComponent == null)
		{
			return;
		}
		baseSkillCdComponent.UpdateModifyCdEffect(false, this);
	}

	// Token: 0x0400C0F3 RID: 49395
	public HashSet<long> SkillIdOrGenres = new HashSet<long>();

	// Token: 0x0400C0F4 RID: 49396
	public int SkillType;

	// Token: 0x0400C0F5 RID: 49397
	public EModifyCdType ModifyType;

	// Token: 0x0400C0F6 RID: 49398
	public float ModifyValue;

	// Token: 0x0400C0F7 RID: 49399
	[Nullable(2)]
	private float[] ModifyValues;
}
