using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020017C7 RID: 6087
[NullableContext(1)]
[Nullable(0)]
public class UseBuffItemRoleData
{
	// Token: 0x0600AC8A RID: 44170 RVA: 0x002E02FC File Offset: 0x002DE4FC
	public UseBuffItemRoleData(string roleName, int position, int roleConfigId, int roleLevel, float currentAttribute, float maxAttribute, int useItemConfigId, Entity entity)
	{
		this.RoleName = roleName;
		this.Position = position;
		this.RoleConfigId = roleConfigId;
		this.RoleLevel = roleLevel;
		this.CurrentAttribute = currentAttribute;
		this.MaxAttribute = maxAttribute;
		this.UseItemConfigId = useItemConfigId;
		this.Entity = entity;
	}

	// Token: 0x0600AC8B RID: 44171 RVA: 0x002E034C File Offset: 0x002DE54C
	public void SetCurrentAttribute(float currentAttribute)
	{
		this.CurrentAttribute = currentAttribute;
	}

	// Token: 0x0600AC8C RID: 44172 RVA: 0x002E0355 File Offset: 0x002DE555
	public void SetUseItemCount(int useItemCount)
	{
		this.UseItemCountInternal = useItemCount;
	}

	// Token: 0x0600AC8D RID: 44173 RVA: 0x002E035E File Offset: 0x002DE55E
	public void AddUseItemCount()
	{
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.UseItemConfigId, 0) <= this.UseItemCountInternal)
		{
			return;
		}
		this.UseItemCountInternal++;
	}

	// Token: 0x0600AC8E RID: 44174 RVA: 0x002E0388 File Offset: 0x002DE588
	public void ReduceUseItemCount()
	{
		if (this.UseItemCountInternal <= 1)
		{
			return;
		}
		this.UseItemCountInternal--;
	}

	// Token: 0x17000DEF RID: 3567
	// (get) Token: 0x0600AC8F RID: 44175 RVA: 0x002E03A2 File Offset: 0x002DE5A2
	public int UseItemCount
	{
		get
		{
			return this.UseItemCountInternal;
		}
	}

	// Token: 0x0600AC90 RID: 44176 RVA: 0x002E03AC File Offset: 0x002DE5AC
	public int GetUseItemMaxCount()
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		int itemCountByConfigId = instance.GetItemCountByConfigId(this.UseItemConfigId, 0);
		int useCountLimit = instance.GetItemDataBaseByConfigId(this.UseItemConfigId)[0].GetUseCountLimit();
		if (useCountLimit > 0)
		{
			return Math.Min(itemCountByConfigId, useCountLimit);
		}
		return itemCountByConfigId;
	}

	// Token: 0x0600AC91 RID: 44177 RVA: 0x002E03F0 File Offset: 0x002DE5F0
	public bool IsMaxItemCount()
	{
		return this.UseItemCountInternal >= this.GetUseItemMaxCount();
	}

	// Token: 0x0600AC92 RID: 44178 RVA: 0x002E0403 File Offset: 0x002DE603
	public bool IsMinItemCount()
	{
		return this.UseItemCountInternal <= 1;
	}

	// Token: 0x0600AC93 RID: 44179 RVA: 0x002E0411 File Offset: 0x002DE611
	public float GetPreviewAttribute()
	{
		return Math.Min(this.GetAddAttribute() + this.CurrentAttribute, this.MaxAttribute);
	}

	// Token: 0x0600AC94 RID: 44180 RVA: 0x002E042C File Offset: 0x002DE62C
	public float GetPreviewAttributeNoLimit()
	{
		return this.GetAddAttribute() + this.CurrentAttribute;
	}

	// Token: 0x0600AC95 RID: 44181 RVA: 0x002E043C File Offset: 0x002DE63C
	public float GetAddAttribute()
	{
		return (float)Math.Floor((this.GetBuffItemCureHealth(this.UseItemConfigId, this.Entity) * (double)this.UseItemCountInternal).Value);
	}

	// Token: 0x0600AC96 RID: 44182 RVA: 0x002E0494 File Offset: 0x002DE694
	public int GetEntityId()
	{
		if (this.Entity == null)
		{
			return -1;
		}
		return this.Entity.Id;
	}

	// Token: 0x0600AC97 RID: 44183 RVA: 0x002E04AC File Offset: 0x002DE6AC
	private double? GetBuffItemCureHealth(int itemConfigId, Entity entity)
	{
		Buff[] buffItemBuffConfig = ConfigBase<BuffItemConfig>.Instance.GetBuffItemBuffConfig(itemConfigId);
		if (buffItemBuffConfig == null)
		{
			return null;
		}
		double num = 0.0;
		foreach (Buff buffConfig in buffItemBuffConfig)
		{
			num += this.GetBuffCureHealth(buffConfig, entity);
		}
		return new double?(num);
	}

	// Token: 0x0600AC98 RID: 44184 RVA: 0x002E050C File Offset: 0x002DE70C
	private unsafe double GetBuffCureHealth(Buff buffConfig, Entity entity)
	{
		double num = 0.0;
		BuffItemConfig instance = ConfigBase<BuffItemConfig>.Instance;
		string[] array = buffConfig.ExtraEffectParameters();
		int extraEffectID = buffConfig.ExtraEffectID;
		if (extraEffectID == 0)
		{
			foreach (long buffId in buffConfig.RoutineExpirationEffects())
			{
				num += this.GetBuffCureHealth(instance.GetBuffConfig(entity.Id, buffId).Value, entity);
			}
			return num;
		}
		if (extraEffectID == 4)
		{
			foreach (string text in array)
			{
				Damage? damageConfig = instance.GetDamageConfig(entity.Id, int.Parse(text));
				if (damageConfig == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.BuffItem;
					ELogAuthor author = ELogAuthor.YYZ;
					string message = "计算Buff道具治疗生命数值时，找不到结算表对应配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("结算表Id", text);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Buff配置", buffConfig);
					instance2.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					float attributeByRelatedProperty = this.GetAttributeByRelatedProperty(entity, damageConfig.Value.RelatedProperty);
					int num2 = damageConfig.Value.CureBaseValue()[0];
					int num3 = damageConfig.Value.RateLv()[0];
					int num4 = num3 / 10000;
					float num5 = (float)num2 + attributeByRelatedProperty * (float)num4;
					num += (double)num5;
				}
			}
			return num;
		}
		if (extraEffectID == 101)
		{
			if (array.Length < 2)
			{
				return num;
			}
			BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
			int num6 = int.Parse(array[0]) / 10000;
			float currentValue = component.GetCurrentValue(EAttributeType.LifeMax);
			num += (double)((float)num6 * currentValue + (float)int.Parse(array[1]));
		}
		return num;
	}

	// Token: 0x0600AC99 RID: 44185 RVA: 0x002E06C4 File Offset: 0x002DE8C4
	private float GetAttributeByRelatedProperty(Entity entity, int relatedProperty)
	{
		return entity.GetComponent<BaseAttributeComponent>().GetCurrentValue((EAttributeType)relatedProperty);
	}

	// Token: 0x040051BA RID: 20922
	private const int TEN_THOUSANDTH_RATIO = 10000;

	// Token: 0x040051BB RID: 20923
	public readonly string RoleName;

	// Token: 0x040051BC RID: 20924
	public readonly int Position;

	// Token: 0x040051BD RID: 20925
	public readonly int RoleConfigId;

	// Token: 0x040051BE RID: 20926
	public float CurrentAttribute;

	// Token: 0x040051BF RID: 20927
	public readonly float MaxAttribute;

	// Token: 0x040051C0 RID: 20928
	public readonly int UseItemConfigId;

	// Token: 0x040051C1 RID: 20929
	public readonly int RoleLevel;

	// Token: 0x040051C2 RID: 20930
	private int UseItemCountInternal;

	// Token: 0x040051C3 RID: 20931
	public readonly Entity Entity;
}
