using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E51 RID: 11857
[NullableContext(1)]
[Nullable(0)]
public class BaseAttributeComponent : EntityComponent, IAttributeSet, IStaticVariableResetter
{
	// Token: 0x060184AD RID: 99501 RVA: 0x006C8DA4 File Offset: 0x006C6FA4
	static BaseAttributeComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseAttributeComponent.CreateStaticDefaultValue), new Action(BaseAttributeComponent.ResetStaticDefaultValue));
	}

	// Token: 0x060184AE RID: 99502 RVA: 0x006C8E87 File Offset: 0x006C7087
	public static void CreateStaticDefaultValue()
	{
		BaseAttributeComponent.ModifierHandleGenerator = 100;
	}

	// Token: 0x060184AF RID: 99503 RVA: 0x006C8E90 File Offset: 0x006C7090
	public static void ResetStaticDefaultValue()
	{
		BaseAttributeComponent.ModifierHandleGenerator = 100;
	}

	// Token: 0x060184B0 RID: 99504 RVA: 0x006C8E99 File Offset: 0x006C7099
	protected override bool OnInit()
	{
		base.OnInit();
		this.CreatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.BuffComponent = base.Entity.GetComponent<BaseBuffComponent>();
		return true;
	}

	// Token: 0x060184B1 RID: 99505 RVA: 0x006C8EC8 File Offset: 0x006C70C8
	[NullableContext(2)]
	protected override bool OnCreate(IEntityArgs args = null)
	{
		for (int i = 0; i < 143; i++)
		{
			this.BaseValues[i] = 0f;
		}
		for (int j = 0; j < 143; j++)
		{
			this.CurrentValues[j] = 0f;
		}
		for (int k = 0; k < 143; k++)
		{
			this.ModifierLists[k] = new Dictionary<int, CharacterAttributeTypes.IModifier>();
		}
		return true;
	}

	// Token: 0x060184B2 RID: 99506 RVA: 0x006C8F2D File Offset: 0x006C712D
	protected override void OnTick(float delta)
	{
		this.AutoRecoverAttr(delta);
	}

	// Token: 0x060184B3 RID: 99507 RVA: 0x006C8F38 File Offset: 0x006C7138
	public bool IsWritableAttribute(EAttributeType attrId)
	{
		return CharacterAttributeTypes.attrsAutoRecoverSpeedMap.ContainsKey(attrId) || CharacterAttributeTypes.attrsAutoRecoverMaxMap.ContainsKey(attrId) || (attrId == EAttributeType.Tough || attrId == EAttributeType.Jump) || (CharacterAttributeTypes.specialEnergyIds.Contains(attrId) && (this.BuffComponent == null || this.BuffComponent.HasBuffAuthority()));
	}

	// Token: 0x060184B4 RID: 99508 RVA: 0x006C8F94 File Offset: 0x006C7194
	public bool IsLocalAttribute(EAttributeType attrId)
	{
		return attrId == EAttributeType.Jump || (CharacterAttributeTypes.specialEnergyIds.Contains(attrId) && (this.BuffComponent == null || this.BuffComponent.HasBuffAuthority()));
	}

	// Token: 0x060184B5 RID: 99509 RVA: 0x006C8FC4 File Offset: 0x006C71C4
	public void SetBaseValue(EAttributeType attrId, float value)
	{
		if (!this.IsWritableAttribute(attrId))
		{
			return;
		}
		float num = value;
		float? maxValue = this.GetMaxValue(attrId);
		if (maxValue != null)
		{
			num = this.RefreshBounds(attrId, num, maxValue.Value);
		}
		if (!CharacterAttributeTypes.attrsNotClampZero.Contains(attrId))
		{
			num = Math.Max(num, 0f);
		}
		num = (float)Math.Floor((double)num);
		if (this.BaseValues[(int)attrId] == num)
		{
			return;
		}
		this.BaseValues[(int)attrId] = num;
		float oldValue = this.CurrentValues[(int)attrId];
		this.UpdateCurrentValue(attrId);
		float newValue = this.CurrentValues[(int)attrId];
		this.DispatchCurrentValueEvent(attrId, newValue, oldValue);
	}

	// Token: 0x060184B6 RID: 99510 RVA: 0x006C905B File Offset: 0x006C725B
	public void AddBaseValue(EAttributeType attrId, float value)
	{
		this.SetBaseValue(attrId, this.BaseValues[(int)attrId] + value);
	}

	// Token: 0x060184B7 RID: 99511 RVA: 0x006C906E File Offset: 0x006C726E
	public float GetBaseValue(EAttributeType attrId)
	{
		return this.BaseValues[(int)attrId];
	}

	// Token: 0x060184B8 RID: 99512 RVA: 0x006C9078 File Offset: 0x006C7278
	public float GetCurrentValue(EAttributeType attrId)
	{
		return this.CurrentValues[(int)attrId];
	}

	// Token: 0x060184B9 RID: 99513 RVA: 0x006C9082 File Offset: 0x006C7282
	public virtual void SeamlessTravelingRefresh()
	{
	}

	// Token: 0x060184BA RID: 99514 RVA: 0x006C9084 File Offset: 0x006C7284
	public virtual void ClearSpecialEnergy()
	{
	}

	// Token: 0x060184BB RID: 99515 RVA: 0x006C9088 File Offset: 0x006C7288
	private float? GetMaxValue(EAttributeType attrId)
	{
		EAttributeType attrId2;
		if (CharacterAttributeTypes.attributeIdsWithMax.TryGetValue(attrId, out attrId2))
		{
			return new float?(this.GetCurrentValue(attrId2));
		}
		return null;
	}

	// Token: 0x060184BC RID: 99516 RVA: 0x006C90BC File Offset: 0x006C72BC
	public unsafe void SyncValueFromServer(EAttributeType attrId, float baseValue, float currentValue)
	{
		if (this.IsLocalAttribute(attrId))
		{
			return;
		}
		if (attrId < EAttributeType.None || attrId >= EAttributeType.Max)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "[属性同步]服务端下发越界属性Id，已跳过";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "CreatureDataId";
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			ptr = new ValueTuple<string, object>(item, (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureDataComponent2 = this.CreatureDataComponent;
			ptr2 = new ValueTuple<string, object>(item2, (creatureDataComponent2 != null) ? new int?(creatureDataComponent2.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("AttributeType", (int)attrId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("BaseValue", baseValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("CurrentValue", currentValue);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Max", 143);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			return;
		}
		if (this.BaseValues[(int)attrId] != baseValue)
		{
			this.BaseValues[(int)attrId] = baseValue;
		}
		float oldValue = this.CurrentValues[(int)attrId];
		this.CurrentValues[(int)attrId] = currentValue;
		this.DispatchCurrentValueEvent(attrId, currentValue, oldValue);
		EAttributeType eattributeType;
		if (CharacterAttributeTypes.AttributeIdsMaxToAttrId.TryGetValue(attrId, out eattributeType))
		{
			this.SetBaseValue(eattributeType, this.BaseValues[(int)eattributeType]);
		}
	}

	// Token: 0x060184BD RID: 99517 RVA: 0x006C9248 File Offset: 0x006C7448
	public virtual void UpdateCurrentValue(EAttributeType attrId)
	{
		if (!this.IsWritableAttribute(attrId))
		{
			return;
		}
		float num = this.EvaluateModifiers(attrId);
		num = this.RefreshNonStateBounds(attrId, num);
		int num2;
		if (CharacterAttributeTypes.attrsCurrentValueClamp.TryGetValue(attrId, out num2))
		{
			num = Math.Min(num, (float)num2);
		}
		if (!CharacterAttributeTypes.attrsNotClampZero.Contains(attrId))
		{
			num = Math.Max(num, 0f);
		}
		if (this.CurrentValues[(int)attrId] == num)
		{
			return;
		}
		this.CurrentValues[(int)attrId] = num;
	}

	// Token: 0x060184BE RID: 99518 RVA: 0x006C92B8 File Offset: 0x006C74B8
	public AttributeSnapshot TakeSnapshot()
	{
		AttributeSnapshot attributeSnapshot = new AttributeSnapshot();
		Array.Copy(this.BaseValues, attributeSnapshot.BaseValues, 143);
		Array.Copy(this.CurrentValues, attributeSnapshot.CurrentValues, 143);
		return attributeSnapshot;
	}

	// Token: 0x060184BF RID: 99519 RVA: 0x006C92F8 File Offset: 0x006C74F8
	public int AddModifier(EAttributeType attrId, CharacterAttributeTypes.IModifier modifier)
	{
		if (!this.IsWritableAttribute(attrId))
		{
			return -1;
		}
		if (attrId <= EAttributeType.None || attrId >= EAttributeType.Max)
		{
			return -1;
		}
		int num = BaseAttributeComponent.ModifierHandleGenerator++;
		this.ModifierLists[(int)attrId] = (this.ModifierLists[(int)attrId] ?? new Dictionary<int, CharacterAttributeTypes.IModifier>());
		this.ModifierLists[(int)attrId][num] = modifier;
		float oldValue = this.CurrentValues[(int)attrId];
		this.UpdateCurrentValue(attrId);
		float newValue = this.CurrentValues[(int)attrId];
		this.DispatchCurrentValueEvent(attrId, newValue, oldValue);
		return num;
	}

	// Token: 0x060184C0 RID: 99520 RVA: 0x006C937C File Offset: 0x006C757C
	public void RemoveModifier(EAttributeType attrId, int handle)
	{
		if (this.ModifierLists[(int)attrId] == null || !this.ModifierLists[(int)attrId].Remove(handle))
		{
			return;
		}
		float oldValue = this.CurrentValues[(int)attrId];
		this.UpdateCurrentValue(attrId);
		float newValue = this.CurrentValues[(int)attrId];
		this.DispatchCurrentValueEvent(attrId, newValue, oldValue);
	}

	// Token: 0x060184C1 RID: 99521 RVA: 0x006C93C8 File Offset: 0x006C75C8
	public virtual void CollectModifiers(EAttributeType attrId, List<CharacterAttributeTypes.IModifier> output)
	{
		Dictionary<int, CharacterAttributeTypes.IModifier> dictionary = this.ModifierLists[(int)attrId];
		if (dictionary == null)
		{
			return;
		}
		foreach (CharacterAttributeTypes.IModifier item in dictionary.Values)
		{
			output.Add(item);
		}
	}

	// Token: 0x060184C2 RID: 99522 RVA: 0x006C9428 File Offset: 0x006C7628
	private float EvaluateModifiers(EAttributeType attrId)
	{
		float num = this.BaseValues[(int)attrId];
		if (this.ModifierLists[(int)attrId] == null)
		{
			return num;
		}
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 1f;
		bool flag = this.CheckIfNeedAdvanceMultiply(attrId);
		this.ModifierScratch.Clear();
		this.CollectModifiers(attrId, this.ModifierScratch);
		foreach (CharacterAttributeTypes.IModifier modifier in this.ModifierScratch)
		{
			CharacterAttributeTypes.AttributeModifier attributeModifier = modifier as CharacterAttributeTypes.AttributeModifier;
			if (attributeModifier != null)
			{
				float num5 = 0f;
				switch (attributeModifier.Type)
				{
				case ECalculationPolicyType.AdvancedMultiplyMagnitude1:
					num4 *= attributeModifier.Value1 * 0.0001f;
					break;
				case ECalculationPolicyType.AddValue:
					num5 = attributeModifier.Value1;
					break;
				case ECalculationPolicyType.AddRate:
					num3 += attributeModifier.Value1;
					break;
				case ECalculationPolicyType.AddFromAttr:
				case ECalculationPolicyType.OverrideFromAttr:
				case ECalculationPolicyType.AddFromAttrRate:
				{
					float num6 = attributeModifier.SnapshotSource.GetValueOrDefault();
					if (num6 == 0f)
					{
						IAttributeSet attrSet;
						if (attributeModifier.SourceEntity != 0L)
						{
							EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(attributeModifier.SourceEntity);
							if (entity == null)
							{
								attrSet = null;
							}
							else
							{
								WorldEntity entity2 = entity.Entity;
								attrSet = ((entity2 != null) ? entity2.GetComponent<BaseAttributeComponent>() : null);
							}
						}
						else
						{
							attrSet = this;
						}
						num6 = AbilityUtils.GetAttrValue(attrSet, attributeModifier.SourceAttributeId, attributeModifier.SourceCalculationType);
					}
					float valueOrDefault = attributeModifier.Min.GetValueOrDefault();
					if (valueOrDefault != 0f)
					{
						num6 -= valueOrDefault;
						if (num6 <= 0f)
						{
							break;
						}
					}
					float valueOrDefault2 = attributeModifier.Ratio.GetValueOrDefault();
					if (valueOrDefault2 != 0f)
					{
						num6 /= valueOrDefault2;
						if (attributeModifier.FloorAfterRatio)
						{
							num6 = (float)Math.Floor((double)num6);
						}
					}
					if (attributeModifier.Type == ECalculationPolicyType.AddFromAttrRate)
					{
						num3 += num6 * attributeModifier.Value1 * 0.0001f;
					}
					else
					{
						num5 = num6 * attributeModifier.Value1 * 0.0001f + attributeModifier.Value2;
						float valueOrDefault3 = attributeModifier.Max.GetValueOrDefault();
						if (valueOrDefault3 != 0f && num5 > valueOrDefault3)
						{
							num5 = valueOrDefault3;
						}
						if (attributeModifier.Type == ECalculationPolicyType.OverrideFromAttr)
						{
							return num5;
						}
					}
					break;
				}
				case ECalculationPolicyType.OverrideValue:
					return attributeModifier.Value1;
				}
				if (num5 != 0f)
				{
					if (!flag)
					{
						num2 += num5;
					}
					else
					{
						num4 *= num5 * 0.0001f + 1f;
					}
				}
			}
		}
		return (float)Math.Floor((double)((num * (num3 * 0.0001f + 1f) + num2) * num4));
	}

	// Token: 0x060184C3 RID: 99523 RVA: 0x006C96E0 File Offset: 0x006C78E0
	public void SyncRecoverPropFromServer(EAttributeType attrId, float currentValue, float maxValue, float speed, double deltaTime)
	{
		EAttributeType attrId2;
		EAttributeType attrId3;
		if (!CharacterAttributeTypes.attrsAutoRecoverSpeedMap.TryGetValue(attrId, out attrId2) || !CharacterAttributeTypes.attrsAutoRecoverMaxMap.TryGetValue(attrId, out attrId3))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "自动属性未注册";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("属性", attrId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SyncValueFromServer(attrId2, speed, speed);
		this.SyncValueFromServer(attrId3, maxValue, maxValue);
		float num = (float)((double)currentValue + (double)speed * deltaTime * 0.0010000000474974513);
		this.SyncValueFromServer(attrId, num, num);
	}

	// Token: 0x060184C4 RID: 99524 RVA: 0x006C976C File Offset: 0x006C796C
	public void AutoRecoverAttr(float deltaTime)
	{
		float flowTimeDilation = Singleton<Time>.Instance.FlowTimeDilation;
		float num = deltaTime * flowTimeDilation * 0.001f;
		foreach (KeyValuePair<EAttributeType, EAttributeType> keyValuePair in CharacterAttributeTypes.attrsAutoRecoverSpeedMap)
		{
			EAttributeType key = keyValuePair.Key;
			EAttributeType value = keyValuePair.Value;
			float currentValue = this.GetCurrentValue(value);
			if (currentValue != 0f)
			{
				this.AddBaseValue(key, currentValue * num);
			}
		}
	}

	// Token: 0x060184C5 RID: 99525 RVA: 0x006C9800 File Offset: 0x006C7A00
	public unsafe int AddBoundsLocker(EAttributeType attrId, IBoundsLocker locker, int lockerHandle)
	{
		if (!this.IsWritableAttribute(attrId))
		{
			return -1;
		}
		Dictionary<int, IBoundsLocker> dictionary;
		if (!this.BoundsLockerMap.TryGetValue(attrId, out dictionary))
		{
			dictionary = new Dictionary<int, IBoundsLocker>();
			this.BoundsLockerMap[attrId] = dictionary;
		}
		if (dictionary.ContainsKey(lockerHandle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZQ;
			string message = "重复添加属性BoundsLock";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("attrId", attrId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", lockerHandle);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return lockerHandle;
		}
		dictionary[lockerHandle] = locker;
		this.SetBaseValue(attrId, this.BaseValues[(int)attrId]);
		return lockerHandle;
	}

	// Token: 0x060184C6 RID: 99526 RVA: 0x006C98BC File Offset: 0x006C7ABC
	public bool RemoveBoundsLocker(EAttributeType attrId, int lockerHandle)
	{
		Dictionary<int, IBoundsLocker> dictionary;
		if (!this.BoundsLockerMap.TryGetValue(attrId, out dictionary))
		{
			return false;
		}
		if (dictionary.Remove(lockerHandle))
		{
			this.SetBaseValue(attrId, this.BaseValues[(int)attrId]);
			return true;
		}
		return false;
	}

	// Token: 0x060184C7 RID: 99527 RVA: 0x006C98F8 File Offset: 0x006C7AF8
	public bool UpdateBoundsLocker(EAttributeIntervalLockType lockType, int lockerHandle, EAttributeType attrId, float percent, float offset)
	{
		Dictionary<int, IBoundsLocker> dictionary;
		if (!this.BoundsLockerMap.TryGetValue(attrId, out dictionary))
		{
			return false;
		}
		IBoundsLocker boundsLocker;
		if (!dictionary.TryGetValue(lockerHandle, out boundsLocker))
		{
			return false;
		}
		if (lockType == EAttributeIntervalLockType.UpperBoundLock)
		{
			boundsLocker.LockUpperBounds = true;
			boundsLocker.LockLowerBounds = false;
			boundsLocker.UpperPercent = percent * 0.0001f;
			boundsLocker.UpperOffset = offset;
			boundsLocker.LowerPercent = 0f;
			boundsLocker.LowerOffset = 0f;
		}
		else
		{
			boundsLocker.LockUpperBounds = false;
			boundsLocker.LockLowerBounds = true;
			boundsLocker.UpperPercent = 1f;
			boundsLocker.UpperOffset = 0f;
			boundsLocker.LowerPercent = percent * 0.0001f;
			boundsLocker.LowerOffset = offset;
		}
		this.SetBaseValue(attrId, this.BaseValues[(int)attrId]);
		return true;
	}

	// Token: 0x060184C8 RID: 99528 RVA: 0x006C99B0 File Offset: 0x006C7BB0
	public virtual void CollectBoundsLockers(EAttributeType attrId, List<IBoundsLocker> output)
	{
		Dictionary<int, IBoundsLocker> dictionary;
		if (!this.BoundsLockerMap.TryGetValue(attrId, out dictionary))
		{
			return;
		}
		foreach (IBoundsLocker item in dictionary.Values)
		{
			output.Add(item);
		}
	}

	// Token: 0x060184C9 RID: 99529 RVA: 0x006C9A14 File Offset: 0x006C7C14
	private float RefreshBounds(EAttributeType attrId, float baseValue, float maxValue)
	{
		float num = baseValue;
		float? num2 = null;
		float val = maxValue;
		this.BoundsLockerScratch.Clear();
		this.CollectBoundsLockers(attrId, this.BoundsLockerScratch);
		foreach (IBoundsLocker boundsLocker in this.BoundsLockerScratch)
		{
			if (boundsLocker.LockLowerBounds)
			{
				float num3 = boundsLocker.LowerPercent * maxValue + boundsLocker.LowerOffset;
				num2 = new float?(Math.Max(num2.GetValueOrDefault(num3), num3));
			}
			if (boundsLocker.LockUpperBounds)
			{
				float val2 = boundsLocker.UpperPercent * maxValue + boundsLocker.UpperOffset;
				val = Math.Min(val, val2);
			}
		}
		num = Math.Min(val, num);
		if (num2 != null)
		{
			num = Math.Max(num2.Value, num);
		}
		return num;
	}

	// Token: 0x060184CA RID: 99530 RVA: 0x006C9AFC File Offset: 0x006C7CFC
	public void AddIntervalLock(EAttributeIntervalLockType lockType, int handleId, EAttributeType attributeId, float percent, float offset)
	{
		if (attributeId == EAttributeType.Life)
		{
			return;
		}
		BoundsLocker boundsLocker = new BoundsLocker
		{
			LockUpperBounds = true,
			LockLowerBounds = false,
			UpperPercent = percent * 0.0001f,
			UpperOffset = offset,
			LowerPercent = 0f,
			LowerOffset = 0f
		};
		BoundsLocker boundsLocker2 = new BoundsLocker
		{
			LockUpperBounds = false,
			LockLowerBounds = true,
			UpperPercent = 1f,
			UpperOffset = 0f,
			LowerPercent = percent * 0.0001f,
			LowerOffset = offset
		};
		BoundsLocker locker = (lockType == EAttributeIntervalLockType.UpperBoundLock) ? boundsLocker : boundsLocker2;
		this.AddBoundsLocker(attributeId, locker, handleId);
	}

	// Token: 0x060184CB RID: 99531 RVA: 0x006C9BA0 File Offset: 0x006C7DA0
	public void RemoveIntervalLock(EAttributeIntervalLockType lockType, int handleId, EAttributeType attributeId)
	{
		this.RemoveBoundsLocker(attributeId, handleId);
	}

	// Token: 0x060184CC RID: 99532 RVA: 0x006C9BAC File Offset: 0x006C7DAC
	public unsafe void AddStateAttributeLock(int handleId, EAttributeType attributeId, float percent, float offset)
	{
		if (!CharacterAttributeTypes.stateAttributeIds.Contains(attributeId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "状态属性锁定的属性不是状态属性";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("attrId", attributeId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", handleId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		BoundsLocker locker = new BoundsLocker
		{
			LockUpperBounds = true,
			LockLowerBounds = true,
			UpperPercent = percent * 0.0001f,
			UpperOffset = offset,
			LowerPercent = percent * 0.0001f,
			LowerOffset = offset
		};
		this.AddBoundsLocker(attributeId, locker, handleId);
	}

	// Token: 0x060184CD RID: 99533 RVA: 0x006C9C6C File Offset: 0x006C7E6C
	public void RemoveStateAttributeLock(int handleId, EAttributeType attributeId)
	{
		this.RemoveBoundsLocker(attributeId, handleId);
	}

	// Token: 0x060184CE RID: 99534 RVA: 0x006C9C77 File Offset: 0x006C7E77
	public virtual IEnumerable<IBoundsLocker> GetAllNonStateBoundsLocker(EAttributeType attrId)
	{
		BaseAttributeComponent.<GetAllNonStateBoundsLocker>d__48 <GetAllNonStateBoundsLocker>d__ = new BaseAttributeComponent.<GetAllNonStateBoundsLocker>d__48(-2);
		<GetAllNonStateBoundsLocker>d__.<>4__this = this;
		<GetAllNonStateBoundsLocker>d__.<>3__attrId = attrId;
		return <GetAllNonStateBoundsLocker>d__;
	}

	// Token: 0x060184CF RID: 99535 RVA: 0x006C9C90 File Offset: 0x006C7E90
	private float RefreshNonStateBounds(EAttributeType attrId, float originValue)
	{
		Dictionary<int, IBoundsLocker> dictionary;
		if (!this.NonStateBoundsLockerMap.TryGetValue(attrId, out dictionary) || dictionary.Count == 0)
		{
			return originValue;
		}
		float num = originValue;
		float? num2 = null;
		float? num3 = null;
		foreach (IBoundsLocker boundsLocker in this.GetAllNonStateBoundsLocker(attrId))
		{
			if (boundsLocker.LockLowerBounds)
			{
				float lowerOffset = boundsLocker.LowerOffset;
				num2 = new float?(Math.Max(num2.GetValueOrDefault(lowerOffset), lowerOffset));
			}
			if (boundsLocker.LockUpperBounds)
			{
				float upperOffset = boundsLocker.UpperOffset;
				num3 = new float?(Math.Min(num3.GetValueOrDefault(upperOffset), upperOffset));
			}
		}
		if (num2 != null)
		{
			num = Math.Max(num2.Value, num);
		}
		if (num3 != null)
		{
			num = Math.Min(num3.Value, num);
		}
		return num;
	}

	// Token: 0x060184D0 RID: 99536 RVA: 0x006C9D88 File Offset: 0x006C7F88
	public unsafe int AddNonStateBoundsLocker(EAttributeType attrId, IBoundsLocker locker, int lockerHandle)
	{
		if (!this.IsWritableAttribute(attrId))
		{
			return -1;
		}
		Dictionary<int, IBoundsLocker> dictionary;
		if (!this.NonStateBoundsLockerMap.TryGetValue(attrId, out dictionary))
		{
			dictionary = new Dictionary<int, IBoundsLocker>();
			this.NonStateBoundsLockerMap[attrId] = dictionary;
		}
		if (dictionary.ContainsKey(lockerHandle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "重复添加非状态属性BoundsLock";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("attrId", attrId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", lockerHandle);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return lockerHandle;
		}
		dictionary[lockerHandle] = locker;
		float oldValue = this.CurrentValues[(int)attrId];
		this.UpdateCurrentValue(attrId);
		this.DispatchCurrentValueEvent(attrId, this.CurrentValues[(int)attrId], oldValue);
		return lockerHandle;
	}

	// Token: 0x060184D1 RID: 99537 RVA: 0x006C9E54 File Offset: 0x006C8054
	public bool RemoveNonStateBoundsLocker(EAttributeType attrId, int lockerHandle)
	{
		Dictionary<int, IBoundsLocker> dictionary;
		if (!this.NonStateBoundsLockerMap.TryGetValue(attrId, out dictionary))
		{
			return false;
		}
		if (dictionary.Remove(lockerHandle))
		{
			float oldValue = this.CurrentValues[(int)attrId];
			this.UpdateCurrentValue(attrId);
			this.DispatchCurrentValueEvent(attrId, this.CurrentValues[(int)attrId], oldValue);
			return true;
		}
		return false;
	}

	// Token: 0x060184D2 RID: 99538 RVA: 0x006C9EA0 File Offset: 0x006C80A0
	public unsafe void AddNonStateAttributeLock(int handleId, EAttributeType attributeId, float offset)
	{
		if (CharacterAttributeTypes.stateAttributeIds.Contains(attributeId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.GHY;
			string message = "非状态属性锁定的属性不是非状态属性";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("attrId", attributeId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", handleId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		BoundsLocker locker = new BoundsLocker
		{
			LockUpperBounds = true,
			LockLowerBounds = true,
			UpperPercent = 0f,
			UpperOffset = offset,
			LowerPercent = 0f,
			LowerOffset = offset
		};
		this.AddNonStateBoundsLocker(attributeId, locker, handleId);
	}

	// Token: 0x060184D3 RID: 99539 RVA: 0x006C9F5A File Offset: 0x006C815A
	public void RemoveNonStateAttributeLock(int handleId, EAttributeType attributeId)
	{
		this.RemoveNonStateBoundsLocker(attributeId, handleId);
	}

	// Token: 0x060184D4 RID: 99540 RVA: 0x006C9F68 File Offset: 0x006C8168
	public void AddListener(EAttributeType attrId, Action<EAttributeType, float, float> callback, [Nullable(2)] string profileLabel = null)
	{
		HashSet<Action<EAttributeType, float, float>> hashSet;
		if (!this.CurrentValueListenerMap.TryGetValue(attrId, out hashSet))
		{
			hashSet = new HashSet<Action<EAttributeType, float, float>>();
			this.CurrentValueListenerMap[attrId] = hashSet;
		}
		hashSet.Add(callback);
	}

	// Token: 0x060184D5 RID: 99541 RVA: 0x006C9FA0 File Offset: 0x006C81A0
	public void AddListeners(EAttributeType[] attrIds, Action<EAttributeType, float, float> callback, [Nullable(2)] string profileLabel = null)
	{
		foreach (EAttributeType attrId in attrIds)
		{
			this.AddListener(attrId, callback, profileLabel);
		}
	}

	// Token: 0x060184D6 RID: 99542 RVA: 0x006C9FCC File Offset: 0x006C81CC
	public bool RemoveListener(EAttributeType attrId, Action<EAttributeType, float, float> callback)
	{
		HashSet<Action<EAttributeType, float, float>> hashSet;
		if (!this.CurrentValueListenerMap.TryGetValue(attrId, out hashSet))
		{
			return false;
		}
		hashSet.Remove(callback);
		return true;
	}

	// Token: 0x060184D7 RID: 99543 RVA: 0x006C9FF4 File Offset: 0x006C81F4
	public void RemoveListeners(EAttributeType[] attrIds, Action<EAttributeType, float, float> callback)
	{
		foreach (EAttributeType attrId in attrIds)
		{
			this.RemoveListener(attrId, callback);
		}
	}

	// Token: 0x060184D8 RID: 99544 RVA: 0x006CA01E File Offset: 0x006C821E
	public void AddGeneralListener(Action<EAttributeType, float, float> listener)
	{
		this.AnyCurrentValueListenerSet.Add(listener);
	}

	// Token: 0x060184D9 RID: 99545 RVA: 0x006CA02D File Offset: 0x006C822D
	public void RemoveGeneralListener(Action<EAttributeType, float, float> listener)
	{
		this.AnyCurrentValueListenerSet.Remove(listener);
	}

	// Token: 0x060184DA RID: 99546 RVA: 0x006CA03C File Offset: 0x006C823C
	public void DispatchCurrentValueEvent(EAttributeType attrId, float newValue, float oldValue)
	{
		if (oldValue == newValue)
		{
			return;
		}
		this.DispatchCurrentValueEventImplement(attrId, newValue, oldValue);
	}

	// Token: 0x060184DB RID: 99547 RVA: 0x006CA04C File Offset: 0x006C824C
	protected virtual void DispatchCurrentValueEventImplement(EAttributeType attrId, float newValue, float oldValue)
	{
		HashSet<Action<EAttributeType, float, float>> hashSet;
		if (this.CurrentValueListenerMap.TryGetValue(attrId, out hashSet))
		{
			Stat value;
			if (!BaseAttributeComponent.StatCurrentAttrEventMap.TryGetValue(attrId, out value))
			{
				value = null;
				BaseAttributeComponent.StatCurrentAttrEventMap[attrId] = value;
			}
			Action<EAttributeType, float, float>[] array = new Action<EAttributeType, float, float>[hashSet.Count];
			hashSet.CopyTo(array);
			foreach (Action<EAttributeType, float, float> action in array)
			{
				if (hashSet.Contains(action))
				{
					try
					{
						action(attrId, newValue, oldValue);
					}
					catch (Exception ex)
					{
						CombatLog instance = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag = CombatLog.EDebugModule.Attribute;
						Entity entity = base.Entity;
						string message = "属性回调异常";
						Exception e = ex;
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("属性", attrId);
						instance.ErrorWithStack(flag, entity, message, e, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
			}
		}
		Action<EAttributeType, float, float>[] array3 = new Action<EAttributeType, float, float>[this.AnyCurrentValueListenerSet.Count];
		this.AnyCurrentValueListenerSet.CopyTo(array3);
		foreach (Action<EAttributeType, float, float> action2 in array3)
		{
			if (this.AnyCurrentValueListenerSet.Contains(action2))
			{
				try
				{
					action2(attrId, newValue, oldValue);
				}
				catch (Exception ex2)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Attribute;
					Entity entity2 = base.Entity;
					string message2 = "全局属性回调异常";
					Exception e2 = ex2;
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("属性", attrId);
					instance2.ErrorWithStack(flag2, entity2, message2, e2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
		}
	}

	// Token: 0x060184DC RID: 99548 RVA: 0x006CA1B4 File Offset: 0x006C83B4
	public bool CheckIfNeedAdvanceMultiply(EAttributeType attributeId)
	{
		if (attributeId <= EAttributeType.ToughChange)
		{
			if (attributeId != EAttributeType.CdReduse && attributeId != EAttributeType.ToughChange)
			{
				return false;
			}
		}
		else if (attributeId != EAttributeType.SkillToughRatio && attributeId != EAttributeType.SpeedRatio && attributeId - EAttributeType.AutoAttackSpeed > 1)
		{
			return false;
		}
		return true;
	}

	// Token: 0x060184DD RID: 99549 RVA: 0x006CA1DC File Offset: 0x006C83DC
	public string GetDebugString()
	{
		List<string> list = new List<string>();
		for (int i = 1; i < 143; i++)
		{
			EAttributeType value = (EAttributeType)i;
			if (this.BaseValues[i] != 0f || this.CurrentValues[i] != 0f)
			{
				List<string> list2 = list;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
				defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(value);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.BaseValues[i]);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.CurrentValues[i]);
				list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}
		return string.Join("|", list);
	}

	// Token: 0x060184DE RID: 99550 RVA: 0x006CA280 File Offset: 0x006C8480
	public string GetLockDebugString(string[] filters)
	{
		string text = "";
		foreach (KeyValuePair<EAttributeType, Dictionary<int, IBoundsLocker>> keyValuePair in this.BoundsLockerMap)
		{
			EAttributeType key = keyValuePair.Key;
			foreach (KeyValuePair<int, IBoundsLocker> keyValuePair2 in keyValuePair.Value)
			{
				int key2 = keyValuePair2.Key;
				IBoundsLocker value = keyValuePair2.Value;
				if (filters.Length != 0)
				{
					bool flag = false;
					foreach (string value2 in filters)
					{
						int num = (int)key;
						if (num.ToString().StartsWith(value2))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
				}
				if (value.LockLowerBounds)
				{
					string str = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 4);
					defaultInterpolatedStringHandler.AppendLiteral("属性:");
					defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(key);
					defaultInterpolatedStringHandler.AppendLiteral(" 下限:");
					defaultInterpolatedStringHandler.AppendFormatted<float>(value.LowerPercent * 100f);
					defaultInterpolatedStringHandler.AppendLiteral("%+");
					defaultInterpolatedStringHandler.AppendFormatted<float>(value.LowerOffset);
					defaultInterpolatedStringHandler.AppendLiteral(" handle:");
					defaultInterpolatedStringHandler.AppendFormatted<int>(key2);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str + defaultInterpolatedStringHandler.ToStringAndClear();
				}
				if (value.LockUpperBounds)
				{
					string str2 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 4);
					defaultInterpolatedStringHandler.AppendLiteral("属性:");
					defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(key);
					defaultInterpolatedStringHandler.AppendLiteral(" 上限:");
					defaultInterpolatedStringHandler.AppendFormatted<float>(value.UpperPercent * 100f);
					defaultInterpolatedStringHandler.AppendLiteral("%+");
					defaultInterpolatedStringHandler.AppendFormatted<float>(value.UpperOffset);
					defaultInterpolatedStringHandler.AppendLiteral(" handle:");
					defaultInterpolatedStringHandler.AppendFormatted<int>(key2);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
		}
		foreach (KeyValuePair<EAttributeType, Dictionary<int, IBoundsLocker>> keyValuePair3 in this.NonStateBoundsLockerMap)
		{
			EAttributeType key3 = keyValuePair3.Key;
			foreach (KeyValuePair<int, IBoundsLocker> keyValuePair4 in keyValuePair3.Value)
			{
				int key4 = keyValuePair4.Key;
				IBoundsLocker value3 = keyValuePair4.Value;
				if (filters.Length != 0)
				{
					bool flag2 = false;
					foreach (string value4 in filters)
					{
						int num = (int)key3;
						if (num.ToString().StartsWith(value4))
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						continue;
					}
				}
				if (value3.LockLowerBounds)
				{
					string str3 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 3);
					defaultInterpolatedStringHandler.AppendLiteral("[非状态]属性:");
					defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(key3);
					defaultInterpolatedStringHandler.AppendLiteral(" 下限固定值:");
					defaultInterpolatedStringHandler.AppendFormatted<float>(value3.LowerOffset);
					defaultInterpolatedStringHandler.AppendLiteral(" handle:");
					defaultInterpolatedStringHandler.AppendFormatted<int>(key4);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
				}
				if (value3.LockUpperBounds)
				{
					string str4 = text;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 3);
					defaultInterpolatedStringHandler.AppendLiteral("[非状态]属性:");
					defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(key3);
					defaultInterpolatedStringHandler.AppendLiteral(" 上限固定值:");
					defaultInterpolatedStringHandler.AppendFormatted<float>(value3.UpperOffset);
					defaultInterpolatedStringHandler.AppendLiteral(" handle:");
					defaultInterpolatedStringHandler.AppendFormatted<int>(key4);
					defaultInterpolatedStringHandler.AppendLiteral("\n");
					text = str4 + defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
		}
		return text;
	}

	// Token: 0x060184DF RID: 99551 RVA: 0x006CA698 File Offset: 0x006C8898
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseAttributeComponent baseAttributeComponent = (BaseAttributeComponent)componentTemplate;
		if (base.CanResetComponentProperty("ModifierScratch") && baseAttributeComponent.ModifierScratch != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<CharacterAttributeTypes.IModifier>>(this.ModifierScratch), "ModifierScratch"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BoundsLockerScratch") && baseAttributeComponent.BoundsLockerScratch != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<IBoundsLocker>>(this.BoundsLockerScratch), "BoundsLockerScratch"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("NonStateBoundsLockerMap") && baseAttributeComponent.NonStateBoundsLockerMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EAttributeType, Dictionary<int, IBoundsLocker>>>(this.NonStateBoundsLockerMap), "NonStateBoundsLockerMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BoundsLockerMap") && baseAttributeComponent.BoundsLockerMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EAttributeType, Dictionary<int, IBoundsLocker>>>(this.BoundsLockerMap), "BoundsLockerMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (baseAttributeComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (baseAttributeComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		return (!base.CanResetComponentProperty("CurrentValueListenerMap") || baseAttributeComponent.CurrentValueListenerMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EAttributeType, HashSet<Action<EAttributeType, float, float>>>>(this.CurrentValueListenerMap), "CurrentValueListenerMap")) && (!base.CanResetComponentProperty("AnyCurrentValueListenerSet") || baseAttributeComponent.AnyCurrentValueListenerSet == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Action<EAttributeType, float, float>>(this.AnyCurrentValueListenerSet), "AnyCurrentValueListenerSet"));
	}

	// Token: 0x0400BAAF RID: 47791
	protected readonly float[] BaseValues = new float[143];

	// Token: 0x0400BAB0 RID: 47792
	protected readonly float[] CurrentValues = new float[143];

	// Token: 0x0400BAB1 RID: 47793
	protected readonly Dictionary<int, CharacterAttributeTypes.IModifier>[] ModifierLists = new Dictionary<int, CharacterAttributeTypes.IModifier>[143];

	// Token: 0x0400BAB2 RID: 47794
	private readonly List<CharacterAttributeTypes.IModifier> ModifierScratch = new List<CharacterAttributeTypes.IModifier>();

	// Token: 0x0400BAB3 RID: 47795
	private readonly List<IBoundsLocker> BoundsLockerScratch = new List<IBoundsLocker>();

	// Token: 0x0400BAB4 RID: 47796
	protected readonly Dictionary<EAttributeType, Dictionary<int, IBoundsLocker>> NonStateBoundsLockerMap = new Dictionary<EAttributeType, Dictionary<int, IBoundsLocker>>();

	// Token: 0x0400BAB5 RID: 47797
	protected readonly Dictionary<EAttributeType, Dictionary<int, IBoundsLocker>> BoundsLockerMap = new Dictionary<EAttributeType, Dictionary<int, IBoundsLocker>>();

	// Token: 0x0400BAB6 RID: 47798
	[Nullable(2)]
	protected CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400BAB7 RID: 47799
	[Nullable(2)]
	protected BaseBuffComponent BuffComponent;

	// Token: 0x0400BAB8 RID: 47800
	public static int ModifierHandleGenerator;

	// Token: 0x0400BAB9 RID: 47801
	[StaticVariableRuleIgnore]
	private static readonly Stat UpdateCurrentValueStat = Stat.Create("BaseAttributeComponent.UpdateCurrentValue", "STATGROUP_KuroBattle", "");

	// Token: 0x0400BABA RID: 47802
	[StaticVariableRuleIgnore]
	private static readonly Stat AddModifierStat = Stat.Create("BaseAttributeComponent.AddModifier", "STATGROUP_KuroBattle", "");

	// Token: 0x0400BABB RID: 47803
	[StaticVariableRuleIgnore]
	private static readonly Stat RemoveModifierStat = Stat.Create("BaseAttributeComponent.RemoveModifier", "STATGROUP_KuroBattle", "");

	// Token: 0x0400BABC RID: 47804
	[StaticVariableRuleIgnore]
	private static readonly Stat EvaluateModifiersStat = Stat.Create("BaseAttributeComponent.EvaluateModifiers", "STATGROUP_KuroBattle", "");

	// Token: 0x0400BABD RID: 47805
	[StaticVariableRuleIgnore]
	private static readonly Stat AutoRecoverAttrStat = Stat.Create("BaseAttributeComponent.AutoRecoverAttr", "STATGROUP_KuroBattle", "");

	// Token: 0x0400BABE RID: 47806
	protected readonly Dictionary<EAttributeType, HashSet<Action<EAttributeType, float, float>>> CurrentValueListenerMap = new Dictionary<EAttributeType, HashSet<Action<EAttributeType, float, float>>>();

	// Token: 0x0400BABF RID: 47807
	protected readonly HashSet<Action<EAttributeType, float, float>> AnyCurrentValueListenerSet = new HashSet<Action<EAttributeType, float, float>>();

	// Token: 0x0400BAC0 RID: 47808
	[StaticVariableRuleIgnore]
	private static readonly Stat DispatchCurrentValueEventStat = Stat.Create("BaseAttributeComponent.DispatchCurrentValueEvent", "STATGROUP_KuroBattle", "");

	// Token: 0x0400BAC1 RID: 47809
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EAttributeType, Stat> StatCurrentAttrEventMap = new Dictionary<EAttributeType, Stat>();

	// Token: 0x0400BAC2 RID: 47810
	[StaticVariableRuleIgnore]
	private static readonly Stat StatAnyCurrentAttrEvent = Stat.Create("AnyCurrentAttr event", "STATGROUP_KuroBattle", "");
}
