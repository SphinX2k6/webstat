using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02002F8D RID: 12173
[NullableContext(1)]
[Nullable(0)]
public class AdjacentBuffStackToEffect : PeriodExecution
{
	// Token: 0x06018D57 RID: 101719 RVA: 0x00707CE0 File Offset: 0x00705EE0
	public AdjacentBuffStackToEffect(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D58 RID: 101720 RVA: 0x00707D20 File Offset: 0x00705F20
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length < 5)
		{
			return;
		}
		this.Distance = float.Parse(extraEffectParameters_[0]);
		if (!string.IsNullOrEmpty(extraEffectParameters_[1]))
		{
			string[] array = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
			this.CampFilter = new EAuraTargetFilter[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.CampFilter[i] = (EAuraTargetFilter)int.Parse(array[i].Trim());
			}
		}
		else
		{
			this.CampFilter = new EAuraTargetFilter[]
			{
				EAuraTargetFilter.EnemyOfOwner
			};
		}
		if (!string.IsNullOrEmpty(extraEffectParameters_[2]))
		{
			string[] array2 = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
			this.BuffIds = new long[array2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				this.BuffIds[j] = long.Parse(array2[j].Trim());
			}
		}
		else
		{
			this.BuffIds = Array.Empty<long>();
		}
		this.AttributeId = int.Parse(extraEffectParameters_[3]);
		this.RatePerTenThousand = float.Parse(extraEffectParameters_[4]);
		if (extraEffectParameters_.Length > 5 && !string.IsNullOrEmpty(extraEffectParameters_[5]) && extraEffectParameters_[5].Trim() != "0")
		{
			string[] array3 = extraEffectParameters_[5].Split('#', StringSplitOptions.None);
			List<long> list = new List<long>();
			for (int k = 0; k < array3.Length; k++)
			{
				long num;
				if (long.TryParse(array3[k].Trim(), out num) && num > 0L)
				{
					list.Add(num);
				}
			}
			this.ConvertedBuffIds = list.ToArray();
		}
		else
		{
			this.ConvertedBuffIds = Array.Empty<long>();
		}
		if (extraEffectParameters_.Length > 6 && !string.IsNullOrEmpty(extraEffectParameters_[6]))
		{
			string[] array4 = extraEffectParameters_[6].Split('#', StringSplitOptions.None);
			List<float> list2 = new List<float>();
			for (int l = 0; l < array4.Length; l++)
			{
				float item;
				if (float.TryParse(array4[l].Trim(), out item))
				{
					list2.Add(item);
				}
			}
			this.ConvertedBuffRatios = list2.ToArray();
		}
		else
		{
			this.ConvertedBuffRatios = Array.Empty<float>();
		}
		this.ConvertedStackCalculateMethod = (EAdjacentBuffConvertedStackCalculateMethod)((extraEffectParameters_.Length > 7) ? int.Parse(extraEffectParameters_[7]) : 0);
		this.NeedInstigator = false;
		for (int m = 0; m < this.CampFilter.Length; m++)
		{
			EAuraTargetFilter eauraTargetFilter = this.CampFilter[m];
			if (eauraTargetFilter == EAuraTargetFilter.Instigator || eauraTargetFilter == EAuraTargetFilter.EnemyOfInstigator || eauraTargetFilter == EAuraTargetFilter.AllyOfInstigator)
			{
				this.NeedInstigator = true;
				return;
			}
		}
	}

	// Token: 0x06018D59 RID: 101721 RVA: 0x00707F65 File Offset: 0x00706165
	protected override bool CheckExecutable()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
		}
		return true;
	}

	// Token: 0x06018D5A RID: 101722 RVA: 0x00707F88 File Offset: 0x00706188
	[return: Nullable(2)]
	public unsafe override object OnExecute(params object[] args)
	{
		Entity ownerEntity = base.OwnerEntity;
		global::Vector vector;
		if (ownerEntity == null)
		{
			vector = null;
		}
		else
		{
			BaseActorComponent component = ownerEntity.GetComponent<BaseActorComponent>();
			vector = ((component != null) ? component.ActorLocationProxy : null);
		}
		global::Vector vector2 = vector;
		CreatureDataComponent creatureDataComponent = (ownerEntity != null) ? ownerEntity.GetComponent<CreatureDataComponent>() : null;
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		BaseAttributeComponent baseAttributeComponent = (ownerBuffComponent != null) ? ownerBuffComponent.GetAttributeComponent() : null;
		if (vector2 == null || creatureDataComponent == null)
		{
			return null;
		}
		EntityHandle instigatorEntity = base.InstigatorEntity;
		WorldEntity worldEntity = (instigatorEntity != null) ? instigatorEntity.Entity : null;
		CreatureDataComponent creatureDataComponent2 = (worldEntity != null) ? worldEntity.CheckGetComponent<CreatureDataComponent>() : null;
		if (this.NeedInstigator && creatureDataComponent2 == null)
		{
			if (!this.HasWarned)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity = ownerEntity;
				string message = "范围buff层数转换效果指定了施加者阵营判断，但施加者不合法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "handle";
				IActiveBuff buff = this.Buff;
				ptr = new ValueTuple<string, object>(item, (buff != null) ? new int?(buff.Handle) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", this.BuffId);
				instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.HasWarned = true;
			}
			return null;
		}
		ECamp? instigatorCamp = (creatureDataComponent2 != null) ? new ECamp?(creatureDataComponent2.GetEntityCamp()) : null;
		ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(vector2, this.Distance, EEntityTypeQuery.Character, this.EntityHandleList, true);
		ECamp entityCamp = creatureDataComponent.GetEntityCamp();
		int num = 0;
		for (int i = 0; i < this.EntityHandleList.Count; i++)
		{
			bool flag2 = false;
			WorldEntity entity2 = this.EntityHandleList[i].Entity;
			if (entity2 != null && entity2.Valid && entity2.IsInit)
			{
				CreatureDataComponent component2 = entity2.GetComponent<CreatureDataComponent>();
				CharacterBuffComponent component3 = entity2.GetComponent<CharacterBuffComponent>();
				if (component2 != null && component3 != null)
				{
					ECamp targetCamp = (component2.GetEntityType() == EEntityType.Player) ? ECamp.Player : component2.GetEntityCamp();
					for (int j = 0; j < this.CampFilter.Length; j++)
					{
						if (this.CheckCamp(this.CampFilter[j], entity2.Id, targetCamp, (worldEntity != null) ? new int?(worldEntity.Id) : null, instigatorCamp, ownerEntity.Id, entityCamp))
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						for (int k = 0; k < this.BuffIds.Length; k++)
						{
							ActiveBuffInternal buffById = component3.GetBuffById(this.BuffIds[k]);
							if (buffById != null)
							{
								num = this.AccumulateConvertedStackCount(num, buffById.StackCount);
							}
						}
					}
				}
			}
		}
		if (num <= 0)
		{
			return null;
		}
		if (this.AttributeId != 0 && baseAttributeComponent != null)
		{
			float value = this.RatePerTenThousand * 0.0001f * (float)num;
			baseAttributeComponent.AddBaseValue((EAttributeType)this.AttributeId, value);
		}
		if (this.ConvertedBuffIds.Length == 0 || this.OwnerBuffComponent == null)
		{
			return null;
		}
		for (int l = 0; l < this.ConvertedBuffIds.Length; l++)
		{
			if (this.ConvertedBuffRatios.Length > l)
			{
				float num2 = this.ConvertedBuffRatios[l];
				if (num2 > 0f)
				{
					int num3 = (int)Math.Floor((double)((float)num * num2 * 0.0001f));
					if (num3 > 0)
					{
						IBuffComponent ownerBuffComponent2 = this.OwnerBuffComponent;
						long buffId = this.ConvertedBuffIds[l];
						IActiveBuff buff2 = this.Buff;
						int? stackCount = new int?(num3);
						bool isIterable = true;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Buff");
						defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
						defaultInterpolatedStringHandler.AppendLiteral("范围Buff层数转换添加Buff");
						ownerBuffComponent2.AddIterativeBuff(buffId, buff2, stackCount, isIterable, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06018D5B RID: 101723 RVA: 0x00708318 File Offset: 0x00706518
	private int AccumulateConvertedStackCount(int currentStackCount, int sourceStackCount)
	{
		EAdjacentBuffConvertedStackCalculateMethod convertedStackCalculateMethod = this.ConvertedStackCalculateMethod;
		if (convertedStackCalculateMethod != EAdjacentBuffConvertedStackCalculateMethod.Add && convertedStackCalculateMethod == EAdjacentBuffConvertedStackCalculateMethod.Max)
		{
			return Math.Max(currentStackCount, sourceStackCount);
		}
		return currentStackCount + sourceStackCount;
	}

	// Token: 0x06018D5C RID: 101724 RVA: 0x00708340 File Offset: 0x00706540
	public bool CheckCamp(EAuraTargetFilter filter, int targetId, ECamp targetCamp, int? instigatorId, ECamp? instigatorCamp, int ownerId, ECamp ownerCamp)
	{
		switch (filter)
		{
		case EAuraTargetFilter.Instigator:
		{
			int? num = instigatorId;
			return targetId == num.GetValueOrDefault() & num != null;
		}
		case EAuraTargetFilter.Owner:
			return targetId == ownerId;
		case EAuraTargetFilter.AllyOfInstigator:
		{
			int? num = instigatorId;
			return !(targetId == num.GetValueOrDefault() & num != null) && instigatorCamp != null && CampUtils.GetCampRelationship(instigatorCamp.Value, targetCamp) == ERelation.Friend;
		}
		case EAuraTargetFilter.EnemyOfInstigator:
			return instigatorCamp != null && CampUtils.GetCampRelationship(instigatorCamp.Value, targetCamp) == ERelation.Enemy;
		case EAuraTargetFilter.AllyOfOwner:
			return targetId != ownerId && CampUtils.GetCampRelationship(ownerCamp, targetCamp) == ERelation.Friend;
		case EAuraTargetFilter.EnemyOfOwner:
			return CampUtils.GetCampRelationship(ownerCamp, targetCamp) == ERelation.Enemy;
		default:
			return false;
		}
	}

	// Token: 0x06018D5D RID: 101725 RVA: 0x007083FC File Offset: 0x007065FC
	public override string GetDebugEffectString()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < this.CampFilter.Length; i++)
		{
			switch (this.CampFilter[i])
			{
			case EAuraTargetFilter.Instigator:
				list.Add("施加者");
				break;
			case EAuraTargetFilter.Owner:
				list.Add("持有者");
				break;
			case EAuraTargetFilter.AllyOfInstigator:
				list.Add("施加者的友方");
				break;
			case EAuraTargetFilter.EnemyOfInstigator:
				list.Add("施加者的敌方");
				break;
			case EAuraTargetFilter.AllyOfOwner:
				list.Add("持有者的友方");
				break;
			case EAuraTargetFilter.EnemyOfOwner:
				list.Add("持有者的敌方");
				break;
			default:
				list.Add("Unknown");
				break;
			}
		}
		string convertedStackCalculateMethodDebugString = this.GetConvertedStackCalculateMethodDebugString();
		string text;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (this.ConvertedBuffIds.Length == 0)
		{
			text = string.Empty;
		}
		else
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 3);
			defaultInterpolatedStringHandler.AppendLiteral("，按");
			defaultInterpolatedStringHandler.AppendFormatted(convertedStackCalculateMethodDebugString);
			defaultInterpolatedStringHandler.AppendLiteral("层数以倍率");
			defaultInterpolatedStringHandler.AppendFormatted(string.Join<float>(",", this.ConvertedBuffRatios));
			defaultInterpolatedStringHandler.AppendLiteral("转换添加Buff");
			defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>(",", this.ConvertedBuffIds));
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		string value = text;
		string text2;
		if (this.AttributeId == 0)
		{
			text2 = string.Empty;
		}
		else
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 2);
			defaultInterpolatedStringHandler.AppendLiteral("，以万分之");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RatePerTenThousand);
			defaultInterpolatedStringHandler.AppendLiteral("比例提升属性");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.AttributeId);
			text2 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		string value2 = text2;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 5);
		defaultInterpolatedStringHandler.AppendLiteral("根据");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Distance / 100f, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("m内的");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join("、", list));
		defaultInterpolatedStringHandler.AppendLiteral("的Buff");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>(",", this.BuffIds));
		defaultInterpolatedStringHandler.AppendLiteral("层数总和");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendFormatted(value);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06018D5E RID: 101726 RVA: 0x0070861C File Offset: 0x0070681C
	private string GetConvertedStackCalculateMethodDebugString()
	{
		EAdjacentBuffConvertedStackCalculateMethod convertedStackCalculateMethod = this.ConvertedStackCalculateMethod;
		if (convertedStackCalculateMethod == EAdjacentBuffConvertedStackCalculateMethod.Add)
		{
			return "加法";
		}
		if (convertedStackCalculateMethod == EAdjacentBuffConvertedStackCalculateMethod.Max)
		{
			return "最大值";
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
		defaultInterpolatedStringHandler.AppendLiteral("未知(");
		defaultInterpolatedStringHandler.AppendFormatted<EAdjacentBuffConvertedStackCalculateMethod>(this.ConvertedStackCalculateMethod);
		defaultInterpolatedStringHandler.AppendLiteral(")");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C1D5 RID: 49621
	private float Distance;

	// Token: 0x0400C1D6 RID: 49622
	private EAuraTargetFilter[] CampFilter = Array.Empty<EAuraTargetFilter>();

	// Token: 0x0400C1D7 RID: 49623
	private long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400C1D8 RID: 49624
	private int AttributeId;

	// Token: 0x0400C1D9 RID: 49625
	private float RatePerTenThousand;

	// Token: 0x0400C1DA RID: 49626
	private long[] ConvertedBuffIds = Array.Empty<long>();

	// Token: 0x0400C1DB RID: 49627
	private float[] ConvertedBuffRatios = Array.Empty<float>();

	// Token: 0x0400C1DC RID: 49628
	private EAdjacentBuffConvertedStackCalculateMethod ConvertedStackCalculateMethod;

	// Token: 0x0400C1DD RID: 49629
	private bool HasWarned;

	// Token: 0x0400C1DE RID: 49630
	private readonly List<EntityHandle> EntityHandleList = new List<EntityHandle>();

	// Token: 0x0400C1DF RID: 49631
	private bool NeedInstigator;
}
