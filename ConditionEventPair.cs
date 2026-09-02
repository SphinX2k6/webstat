using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Monster.Common;
using AkiClient.Game.Aki.Data.Condition.Enum;
using UnrealEngine;

// Token: 0x02000CF3 RID: 3315
[NullableContext(1)]
[Nullable(0)]
public class ConditionEventPair
{
	// Token: 0x06004201 RID: 16897 RVA: 0x00071A88 File Offset: 0x0006FC88
	private BaseTagComponent.TTagChangedCallback GetTagChangedClosure(int tagId)
	{
		return delegate(int newCount, int changedTagId, int exactTagId, int oldCount)
		{
			if (this.Conditions.Tags[tagId].InRange((float)newCount))
			{
				if (!this.TagTrueSet.Contains(tagId))
				{
					this.TagTrueSet.Add(tagId);
					this.IncreaseCount();
					return;
				}
			}
			else if (this.TagTrueSet.Contains(tagId))
			{
				this.TagTrueSet.Remove(tagId);
				this.DecreaseCount();
			}
		};
	}

	// Token: 0x06004202 RID: 16898 RVA: 0x00071AA8 File Offset: 0x0006FCA8
	private void OnAttrChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		if (this.Conditions.Attributes[attributeId].InRange(newValue))
		{
			if (!this.AttributeTrueSet.Contains(attributeId))
			{
				this.AttributeTrueSet.Add(attributeId);
				this.IncreaseCount();
				return;
			}
		}
		else if (this.AttributeTrueSet.Contains(attributeId))
		{
			this.AttributeTrueSet.Remove(attributeId);
			this.DecreaseCount();
		}
	}

	// Token: 0x06004203 RID: 16899 RVA: 0x00071B14 File Offset: 0x0006FD14
	private void OnAttrRateChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		if (this.AttributeComponent == null)
		{
			return;
		}
		List<int> list;
		if (this.Conditions.AttributeRateNumeratorMap.TryGetValue(attributeId, out list))
		{
			foreach (int num in list)
			{
				AiAttributeRate aiAttributeRate = this.Conditions.AttributeRates[num];
				float currentValue = this.AttributeComponent.GetCurrentValue(aiAttributeRate.Denominator);
				if (currentValue != 0f)
				{
					if (aiAttributeRate.Range.InRange(newValue / currentValue))
					{
						if (!this.AttributeRateTrueSet.Contains(num))
						{
							this.AttributeRateTrueSet.Add(num);
							this.IncreaseCount();
						}
					}
					else if (this.AttributeRateTrueSet.Contains(num))
					{
						this.AttributeRateTrueSet.Remove(num);
						this.DecreaseCount();
					}
				}
			}
		}
		List<int> list2;
		if (this.Conditions.AttributeRateDenominatorMap.TryGetValue(attributeId, out list2))
		{
			if (newValue == 0f)
			{
				return;
			}
			foreach (int num2 in list2)
			{
				AiAttributeRate aiAttributeRate2 = this.Conditions.AttributeRates[num2];
				float currentValue2 = this.AttributeComponent.GetCurrentValue(aiAttributeRate2.Numerator);
				if (aiAttributeRate2.Range.InRange(currentValue2 / newValue))
				{
					if (!this.AttributeRateTrueSet.Contains(num2))
					{
						this.AttributeRateTrueSet.Add(num2);
						this.IncreaseCount();
					}
				}
				else if (this.AttributeRateTrueSet.Contains(num2))
				{
					this.AttributeRateTrueSet.Remove(num2);
					this.DecreaseCount();
				}
			}
		}
	}

	// Token: 0x06004204 RID: 16900 RVA: 0x00071CE8 File Offset: 0x0006FEE8
	public void InitConditions(SAiConditions conditions, UKuroBooleanEventBinder eventBinder, CharacterActorComponent actorComp)
	{
		this.Clear();
		this.Conditions = new AiConditions(conditions);
		this.EventBinder = eventBinder;
		this.TagComponent = actorComp.Entity.GetComponent<BaseTagComponent>();
		this.AttributeComponent = actorComp.Entity.GetComponent<BaseAttributeComponent>();
		this.SumCount = this.Conditions.Tags.Count + this.Conditions.Attributes.Count + this.Conditions.AttributeRates.Count;
		BaseTagComponent component = actorComp.Entity.GetComponent<BaseTagComponent>();
		if (component != null)
		{
			foreach (KeyValuePair<int, TsFloatRange> keyValuePair in this.Conditions.Tags)
			{
				int key = keyValuePair.Key;
				ITagTask tagTask = component.ListenForTagAnyCountChanged(key, this.GetTagChangedClosure(key));
				if (tagTask != null)
				{
					this.AsyncTagTasks.Add(tagTask);
				}
			}
		}
		if (this.AttributeComponent != null)
		{
			HashSet<EAttributeType> hashSet = new HashSet<EAttributeType>();
			foreach (KeyValuePair<EAttributeType, TsFloatRange> keyValuePair2 in this.Conditions.Attributes)
			{
				EAttributeType key2 = keyValuePair2.Key;
				hashSet.Add(key2);
			}
			if (this.Conditions.Attributes.Count > 0 && this.AttributeComponent != null)
			{
				this.ListenAttributeIds = new EAttributeType[hashSet.Count];
				hashSet.CopyTo(this.ListenAttributeIds);
				this.AttributeComponent.AddListeners(this.ListenAttributeIds, new Action<EAttributeType, float, float>(this.OnAttrChanged), "AiConditionEvent");
			}
			hashSet.Clear();
			foreach (AiAttributeRate aiAttributeRate in this.Conditions.AttributeRates)
			{
				hashSet.Add(aiAttributeRate.Numerator);
				hashSet.Add(aiAttributeRate.Denominator);
			}
			if (this.Conditions.AttributeRates.Count > 0 && this.AttributeComponent != null)
			{
				this.ListenAttributeRateIds = new EAttributeType[hashSet.Count];
				hashSet.CopyTo(this.ListenAttributeRateIds);
				this.AttributeComponent.AddListeners(this.ListenAttributeRateIds, new Action<EAttributeType, float, float>(this.OnAttrRateChanged), "AiConditionEvent2");
			}
		}
		this.ResetConditions(true);
	}

	// Token: 0x06004205 RID: 16901 RVA: 0x00071F74 File Offset: 0x00070174
	public void Clear()
	{
		if (this.ListenAttributeIds != null)
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent != null)
			{
				attributeComponent.RemoveListeners(this.ListenAttributeIds, new Action<EAttributeType, float, float>(this.OnAttrChanged));
			}
			this.ListenAttributeIds = null;
		}
		if (this.ListenAttributeRateIds != null)
		{
			BaseAttributeComponent attributeComponent2 = this.AttributeComponent;
			if (attributeComponent2 != null)
			{
				attributeComponent2.RemoveListeners(this.ListenAttributeRateIds, new Action<EAttributeType, float, float>(this.OnAttrRateChanged));
			}
			this.ListenAttributeRateIds = null;
		}
		this.Conditions = null;
		if (this.EventBinder != null)
		{
			this.EventBinder.Callback.Clear();
			this.EventBinder = null;
		}
		this.TagComponent = null;
		this.AttributeComponent = null;
		this.TagTrueSet.Clear();
		this.AttributeTrueSet.Clear();
		this.AttributeRateTrueSet.Clear();
		this.TrueCount = 0;
		this.SumCount = 0;
		foreach (ITagTask tagTask in this.AsyncTagTasks)
		{
			tagTask.EndTask();
		}
		this.AsyncTagTasks.Clear();
	}

	// Token: 0x06004206 RID: 16902 RVA: 0x00072098 File Offset: 0x00070298
	private void IncreaseCount()
	{
		this.TrueCount++;
		if (this.Conditions.Logic == SConditionGroupType.AND)
		{
			if (this.TrueCount == this.SumCount)
			{
				this.EventBinder.Callback.Broadcast(true);
				return;
			}
		}
		else if (this.TrueCount == 1)
		{
			this.EventBinder.Callback.Broadcast(true);
		}
	}

	// Token: 0x06004207 RID: 16903 RVA: 0x000720FC File Offset: 0x000702FC
	private void DecreaseCount()
	{
		this.TrueCount--;
		if (this.Conditions.Logic == SConditionGroupType.AND)
		{
			if (this.TrueCount == this.SumCount - 1)
			{
				this.EventBinder.Callback.Broadcast(false);
				return;
			}
		}
		else if (this.TrueCount == 0)
		{
			this.EventBinder.Callback.Broadcast(false);
		}
	}

	// Token: 0x06004208 RID: 16904 RVA: 0x00072160 File Offset: 0x00070360
	public void ResetConditions(bool onlyTrue = false)
	{
		this.TrueCount = 0;
		if (this.TagComponent != null)
		{
			foreach (KeyValuePair<int, TsFloatRange> keyValuePair in this.Conditions.Tags)
			{
				int key = keyValuePair.Key;
				if (keyValuePair.Value.InRange((float)this.TagComponent.GetTagCount(key)))
				{
					this.TagTrueSet.Add(key);
					this.TrueCount++;
				}
			}
		}
		if (this.AttributeComponent != null)
		{
			foreach (KeyValuePair<EAttributeType, TsFloatRange> keyValuePair2 in this.Conditions.Attributes)
			{
				EAttributeType key2 = keyValuePair2.Key;
				TsFloatRange value = keyValuePair2.Value;
				float currentValue = this.AttributeComponent.GetCurrentValue(key2);
				if (value.InRange(currentValue))
				{
					this.AttributeTrueSet.Add(key2);
					this.TrueCount++;
				}
			}
			int num = 0;
			foreach (AiAttributeRate aiAttributeRate in this.Conditions.AttributeRates)
			{
				float currentValue2 = this.AttributeComponent.GetCurrentValue(aiAttributeRate.Numerator);
				float currentValue3 = this.AttributeComponent.GetCurrentValue(aiAttributeRate.Denominator);
				if (currentValue3 != 0f && aiAttributeRate.Range.InRange(currentValue2 / currentValue3))
				{
					this.AttributeRateTrueSet.Add(num);
					this.TrueCount++;
				}
				num++;
			}
		}
		if (this.Conditions.Logic == SConditionGroupType.AND)
		{
			if (this.TrueCount == this.SumCount)
			{
				this.EventBinder.Callback.Broadcast(true);
				return;
			}
		}
		else if (this.TrueCount > 0)
		{
			this.EventBinder.Callback.Broadcast(true);
			return;
		}
		if (onlyTrue)
		{
			return;
		}
		this.EventBinder.Callback.Broadcast(false);
	}

	// Token: 0x04001050 RID: 4176
	[Nullable(2)]
	private AiConditions Conditions;

	// Token: 0x04001051 RID: 4177
	[Nullable(2)]
	public UKuroBooleanEventBinder EventBinder;

	// Token: 0x04001052 RID: 4178
	[Nullable(2)]
	private BaseTagComponent TagComponent;

	// Token: 0x04001053 RID: 4179
	[Nullable(2)]
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x04001054 RID: 4180
	private readonly HashSet<int> TagTrueSet = new HashSet<int>();

	// Token: 0x04001055 RID: 4181
	private readonly HashSet<EAttributeType> AttributeTrueSet = new HashSet<EAttributeType>();

	// Token: 0x04001056 RID: 4182
	private readonly HashSet<int> AttributeRateTrueSet = new HashSet<int>();

	// Token: 0x04001057 RID: 4183
	private int TrueCount;

	// Token: 0x04001058 RID: 4184
	private int SumCount;

	// Token: 0x04001059 RID: 4185
	private readonly List<ITagTask> AsyncTagTasks = new List<ITagTask>();

	// Token: 0x0400105A RID: 4186
	[Nullable(2)]
	private EAttributeType[] ListenAttributeIds;

	// Token: 0x0400105B RID: 4187
	[Nullable(2)]
	private EAttributeType[] ListenAttributeRateIds;
}
