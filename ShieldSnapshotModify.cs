using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F64 RID: 12132
[NullableContext(1)]
[Nullable(0)]
public class ShieldSnapshotModify : SnapModifyBuffEffect
{
	// Token: 0x06018CB6 RID: 101558 RVA: 0x00702BBA File Offset: 0x00700DBA
	public ShieldSnapshotModify(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CB7 RID: 101559 RVA: 0x00702BCC File Offset: 0x00700DCC
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		float[] extraEffectGrowParameters = parameters.ExtraEffectGrowParameters1;
		float[] extraEffectGrowParameters2 = parameters.ExtraEffectGrowParameters2;
		this.TargetType = new ESnapTargetType?((ESnapTargetType)int.Parse(extraEffectParameters_[0]));
		this.BuffHolderType = new int?(int.Parse(extraEffectParameters_[1]));
		this.ShieldId = int.Parse(extraEffectParameters_[2]);
		this.AttributeId = (EAttributeType)int.Parse(extraEffectParameters_[3]);
		this.CompareFactor = int.Parse(extraEffectParameters_[4]);
		this.ConvertThreshold = float.Parse(extraEffectParameters_[5]);
		this.ConvertLimit = float.Parse(extraEffectParameters_[6]);
		this.ConvertMagnitude = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters, this.Level, 0f);
		this.ConvertRatio = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters2, this.Level, 0f);
		this.NeedCheckCritical = this.RequireAndLimits.Requirements.Any((IRequirement require) => require.Type == EExtraEffectRequire.ShouldCritical);
	}

	// Token: 0x06018CB8 RID: 101560 RVA: 0x00702CBD File Offset: 0x00700EBD
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		if (parameters.Length < 2)
		{
			return false;
		}
		this.OnExecuteSnap((Dictionary<EAttributeType, float>)parameters[0], (SnapshotPayload)parameters[1]);
		return true;
	}

	// Token: 0x06018CB9 RID: 101561 RVA: 0x00702CE8 File Offset: 0x00700EE8
	protected override void OnExecuteSnap(Dictionary<EAttributeType, float> resultMap, SnapshotPayload snapshots)
	{
		float num2;
		float num = resultMap.TryGetValue(this.AttributeId, out num2) ? num2 : 0f;
		int? buffHolderType = this.BuffHolderType;
		int num3 = 0;
		Entity entity;
		if (buffHolderType.GetValueOrDefault() == num3 & buffHolderType != null)
		{
			entity = base.OwnerEntity;
		}
		else
		{
			EntityHandle instigatorEntity = base.InstigatorEntity;
			entity = ((instigatorEntity != null) ? instigatorEntity.Entity : null);
		}
		Entity entity2 = entity;
		if (entity2 != null)
		{
			CharacterShieldComponent component = entity2.GetComponent<CharacterShieldComponent>();
			float num4 = (component != null) ? component.GetShieldValue(this.ShieldId) : 0f;
			bool flag = num4 >= this.ConvertThreshold;
			float num5 = num4;
			if (this.ConvertLimit > 0f)
			{
				num5 = Math.Min(num5, this.ConvertLimit);
			}
			if (this.CompareFactor > 0)
			{
				buffHolderType = this.BuffHolderType;
				num3 = 0;
				ESnapAttributeSourceType targetType = (buffHolderType.GetValueOrDefault() == num3 & buffHolderType != null) ? ESnapAttributeSourceType.BuffHolder : ESnapAttributeSourceType.BuffMaker;
				float attrValue = base.GetAttrValue(snapshots, (EAttributeType)this.CompareFactor, EAttributeRefType.CurrentValue, targetType);
				flag = (num4 >= attrValue * this.ConvertThreshold * 0.0001f);
				if (this.ConvertLimit > 0f)
				{
					num5 = Math.Min(num4, attrValue * this.ConvertLimit * 0.0001f);
				}
			}
			if (flag)
			{
				float num6 = num5 * this.ConvertRatio * 0.0001f + this.ConvertMagnitude;
				resultMap[this.AttributeId] = num + num6;
			}
		}
	}

	// Token: 0x0400C15A RID: 49498
	public int? BuffHolderType;

	// Token: 0x0400C15B RID: 49499
	public int ShieldId;

	// Token: 0x0400C15C RID: 49500
	public EAttributeType AttributeId;

	// Token: 0x0400C15D RID: 49501
	public int CompareFactor;

	// Token: 0x0400C15E RID: 49502
	public float ConvertThreshold;

	// Token: 0x0400C15F RID: 49503
	public float ConvertLimit;

	// Token: 0x0400C160 RID: 49504
	public float ConvertMagnitude;

	// Token: 0x0400C161 RID: 49505
	public float ConvertRatio;
}
