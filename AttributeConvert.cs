using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02002EEC RID: 12012
[NullableContext(1)]
[Nullable(0)]
public class AttributeConvert : BuffEffect
{
	// Token: 0x06018AAE RID: 101038 RVA: 0x006F617C File Offset: 0x006F437C
	public AttributeConvert(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018AAF RID: 101039 RVA: 0x006F61A0 File Offset: 0x006F43A0
	protected unsafe override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		float[] extraEffectGrowParameters = parameters.ExtraEffectGrowParameters1;
		float[] extraEffectGrowParameters2 = parameters.ExtraEffectGrowParameters2;
		int level = this.Level;
		this.ListenAttrId = (EAttributeType)int.Parse(extraEffectParameters_[0]);
		this.TargetAttrId = (EAttributeType)int.Parse(extraEffectParameters_[1]);
		this.IsPerTenThousand = (int.Parse(extraEffectParameters_[2]) == 1);
		if (this.IsPerTenThousand)
		{
			EAttributeType listenAttrMaxId;
			if (CharacterAttributeTypes.attributeIdsWithMax.TryGetValue(this.ListenAttrId, out listenAttrMaxId))
			{
				this.ListenAttrMaxId = listenAttrMaxId;
			}
			else
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity ownerEntity = base.OwnerEntity;
				string message = "属性转换额外效果监听属性为万分比时，监听属性没有对应的最大值属性";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handle", this.ActiveHandleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buff Id", this.BuffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("instigator id", this.InstigatorEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("属性Id", this.ListenAttrId);
				instance.Error(flag, ownerEntity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
		}
		int listenType = 0;
		if (extraEffectParameters_.Length > 3)
		{
			int.TryParse(extraEffectParameters_[3], out listenType);
		}
		this.ListenType = (EAttributeConvertListenType)listenType;
		int num = 0;
		if (extraEffectParameters_.Length > 4)
		{
			int.TryParse(extraEffectParameters_[4], out num);
		}
		this.ListenAbsoluteValue = (num == 1);
		this.Rate = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters, level, -1f) * 0.0001f;
		this.Offset = AbilityUtils.GetLevelValue<float>(extraEffectGrowParameters2, level, -1f);
	}

	// Token: 0x06018AB0 RID: 101040 RVA: 0x006F6338 File Offset: 0x006F4538
	public override void OnCreated()
	{
		if (this.IsPerTenThousand && this.ListenAttrMaxId == EAttributeType.None)
		{
			return;
		}
		BaseBuffComponent baseBuffComponent = base.ExactOwnerEntity.CheckGetComponent<BaseBuffComponent>();
		foreach (BaseAttributeComponent baseAttributeComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseAttributeComponent>(EComponent.BaseAttributeComponent, null) : null) ?? new List<BaseAttributeComponent>()))
		{
			Entity entity = baseAttributeComponent.Entity;
			Action<EAttributeType, float, float> action = delegate(EAttributeType attributeId, float newValue, float oldValue)
			{
				this.OnAttributeChanged(entity, attributeId, newValue, oldValue);
			};
			baseAttributeComponent.AddListener(this.ListenAttrId, action, "ExtraEffectAttributeEvent");
			this.EntityListenerMap[entity] = action;
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018AB1 RID: 101041 RVA: 0x006F6434 File Offset: 0x006F4634
	public override void OnRemoved(bool bPremature)
	{
		BaseBuffComponent baseBuffComponent = base.ExactOwnerEntity.CheckGetComponent<BaseBuffComponent>();
		foreach (BaseAttributeComponent baseAttributeComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseAttributeComponent>(EComponent.BaseAttributeComponent, null) : null) ?? new List<BaseAttributeComponent>()))
		{
			Entity entity = baseAttributeComponent.Entity;
			Action<EAttributeType, float, float> callback;
			if (this.EntityListenerMap.TryGetValue(entity, out callback))
			{
				baseAttributeComponent.RemoveListener(this.ListenAttrId, callback);
				this.EntityListenerMap.Remove(entity);
			}
		}
		if (this.EntityListenerMap.Count > 0)
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Buff, (baseBuffComponent != null) ? baseBuffComponent.Entity : null, "额外效果AttributeConvert有遗留的监听未释放", default(ReadOnlySpan<ValueTuple<string, object>>));
			foreach (KeyValuePair<Entity, Action<EAttributeType, float, float>> keyValuePair in this.EntityListenerMap)
			{
				Entity key = keyValuePair.Key;
				Action<EAttributeType, float, float> value = keyValuePair.Value;
				BaseAttributeComponent baseAttributeComponent2 = key.CheckGetComponent<BaseAttributeComponent>();
				if (baseAttributeComponent2 != null)
				{
					baseAttributeComponent2.RemoveListener(this.ListenAttrId, value);
				}
			}
		}
		this.EntityListenerMap.Clear();
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018AB2 RID: 101042 RVA: 0x006F65B0 File Offset: 0x006F47B0
	[return: Nullable(2)]
	public unsafe override object OnExecute(params object[] parameters)
	{
		if (parameters.Length >= 2)
		{
			Entity entity = parameters[0] as Entity;
			if (entity != null)
			{
				object obj = parameters[1];
				float num2;
				if (obj is float)
				{
					float num = (float)obj;
					num2 = num;
				}
				else if (obj is double)
				{
					double num3 = (double)obj;
					num2 = (float)num3;
				}
				else
				{
					if (!(obj is int))
					{
						return null;
					}
					int num4 = (int)obj;
					num2 = (float)num4;
				}
				BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
				if (component == null)
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
					Entity ownerEntity = base.OwnerEntity;
					string message = "属性转换额外效果没有找到属性组件";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handle", this.ActiveHandleId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buff Id", this.BuffId);
					instance.Error(flag, ownerEntity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return null;
				}
				float num5 = this.ListenAbsoluteValue ? Math.Abs(num2) : num2;
				if (this.IsPerTenThousand)
				{
					num5 = num5 / component.GetCurrentValue(this.ListenAttrMaxId) * 10000f;
				}
				float value = this.Rate * num5 + this.Offset;
				component.AddBaseValue(this.TargetAttrId, value);
				return null;
			}
		}
		return null;
	}

	// Token: 0x06018AB3 RID: 101043 RVA: 0x006F66EC File Offset: 0x006F48EC
	private unsafe void OnAttributeChanged(Entity entity, EAttributeType attributeId, float newValue, float oldValue)
	{
		if (this.OwnerBuffComponent == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity ownerEntity = base.OwnerEntity;
			string message = "属性转换额外效果没有找到buff组件";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handle", this.ActiveHandleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buff Id", this.BuffId);
			instance.Error(flag, ownerEntity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		float num = newValue - oldValue;
		if (this.ListenType == EAttributeConvertListenType.IncreaseOnly && num <= 0f)
		{
			return;
		}
		if (this.ListenType == EAttributeConvertListenType.DecreaseOnly && num >= 0f)
		{
			return;
		}
		base.TryExecute(new Partial_RequirementPayload(), this.OwnerBuffComponent, new object[]
		{
			entity,
			num
		});
	}

	// Token: 0x06018AB4 RID: 101044 RVA: 0x006F67BC File Offset: 0x006F49BC
	private void OnChangeTeam()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<Entity, Action<EAttributeType, float, float>> keyValuePair in this.EntityListenerMap)
		{
			list.Add(keyValuePair.Key.Id);
		}
		foreach (int id in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(list, true))
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			BaseAttributeComponent baseAttributeComponent;
			if (instance == null)
			{
				baseAttributeComponent = null;
			}
			else
			{
				EntityHandle handle = instance.GetHandle(id);
				if (handle == null)
				{
					baseAttributeComponent = null;
				}
				else
				{
					WorldEntity entity4 = handle.Entity;
					baseAttributeComponent = ((entity4 != null) ? entity4.CheckGetComponent<BaseAttributeComponent>() : null);
				}
			}
			BaseAttributeComponent baseAttributeComponent2 = baseAttributeComponent;
			if (baseAttributeComponent2 != null)
			{
				Entity entity = baseAttributeComponent2.Entity;
				Action<EAttributeType, float, float> action = delegate(EAttributeType attributeId, float newValue, float oldValue)
				{
					this.OnAttributeChanged(entity, attributeId, newValue, oldValue);
				};
				baseAttributeComponent2.AddListener(this.ListenAttrId, action, "ExtraEffectAttributeEvent");
				this.EntityListenerMap[entity] = action;
			}
		}
		foreach (int id2 in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(list, false))
		{
			CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
			BaseAttributeComponent baseAttributeComponent3;
			if (instance2 == null)
			{
				baseAttributeComponent3 = null;
			}
			else
			{
				EntityHandle handle2 = instance2.GetHandle(id2);
				if (handle2 == null)
				{
					baseAttributeComponent3 = null;
				}
				else
				{
					WorldEntity entity2 = handle2.Entity;
					baseAttributeComponent3 = ((entity2 != null) ? entity2.CheckGetComponent<BaseAttributeComponent>() : null);
				}
			}
			BaseAttributeComponent baseAttributeComponent4 = baseAttributeComponent3;
			if (baseAttributeComponent4 != null)
			{
				Entity entity3 = baseAttributeComponent4.Entity;
				Action<EAttributeType, float, float> callback;
				if (this.EntityListenerMap.TryGetValue(entity3, out callback))
				{
					baseAttributeComponent4.RemoveListener(this.ListenAttrId, callback);
				}
				this.EntityListenerMap.Remove(entity3);
			}
		}
	}

	// Token: 0x06018AB5 RID: 101045 RVA: 0x006F6990 File Offset: 0x006F4B90
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
		defaultInterpolatedStringHandler.AppendLiteral("属性");
		defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.ListenAttrId);
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		switch (this.ListenType)
		{
		case EAttributeConvertListenType.DecreaseOnly:
			text += "减少的";
			break;
		case EAttributeConvertListenType.IncreaseOnly:
			text += "增加的";
			break;
		case EAttributeConvertListenType.All:
			text += "任何变化的";
			break;
		}
		text = text + (this.ListenAbsoluteValue ? "绝对值" : "") + (this.IsPerTenThousand ? "万分比" : "数值");
		string str = text;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 3);
		defaultInterpolatedStringHandler.AppendLiteral("按照");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Rate * 100f, "F2");
		defaultInterpolatedStringHandler.AppendLiteral("% + ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Offset);
		defaultInterpolatedStringHandler.AppendLiteral("转换为属性");
		defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.TargetAttrId);
		return str + defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400BF45 RID: 48965
	private EAttributeType ListenAttrId;

	// Token: 0x0400BF46 RID: 48966
	private EAttributeType ListenAttrMaxId;

	// Token: 0x0400BF47 RID: 48967
	private EAttributeType TargetAttrId;

	// Token: 0x0400BF48 RID: 48968
	private bool IsPerTenThousand;

	// Token: 0x0400BF49 RID: 48969
	private EAttributeConvertListenType ListenType = EAttributeConvertListenType.All;

	// Token: 0x0400BF4A RID: 48970
	private bool ListenAbsoluteValue;

	// Token: 0x0400BF4B RID: 48971
	private float Rate;

	// Token: 0x0400BF4C RID: 48972
	private float Offset;

	// Token: 0x0400BF4D RID: 48973
	private readonly Dictionary<Entity, Action<EAttributeType, float, float>> EntityListenerMap = new Dictionary<Entity, Action<EAttributeType, float, float>>();
}
