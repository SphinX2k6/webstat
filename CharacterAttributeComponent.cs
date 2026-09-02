using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02002E91 RID: 11921
[NullableContext(2)]
[Nullable(0)]
public class CharacterAttributeComponent : BaseAttributeComponent
{
	// Token: 0x17002108 RID: 8456
	// (get) Token: 0x0601879A RID: 100250 RVA: 0x006DAC6D File Offset: 0x006D8E6D
	protected new CharacterBuffComponent BuffComponent
	{
		get
		{
			return this.BuffComponent as CharacterBuffComponent;
		}
	}

	// Token: 0x0601879B RID: 100251 RVA: 0x006DAC7C File Offset: 0x006D8E7C
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.InitFromPbData();
		base.AddListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnLifeChanged), null);
		base.AddListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnLifeMaxChanged), null);
		base.AddListeners(CharacterAttributeTypes.energyAttrIds, new Action<EAttributeType, float, float>(this.OnSpecialEnergyChanged), null);
		base.AddGeneralListener(new Action<EAttributeType, float, float>(this.OnAnyCurrentValueChange));
		return true;
	}

	// Token: 0x0601879C RID: 100252 RVA: 0x006DACE2 File Offset: 0x006D8EE2
	protected override void OnActivate()
	{
		this.InitFromPbData();
	}

	// Token: 0x0601879D RID: 100253 RVA: 0x006DACEC File Offset: 0x006D8EEC
	private unsafe void InitFromPbData()
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		EntityComponentPb entityComponentPb;
		RepeatedField<WhiteGreenPropData> repeatedField;
		if (creatureDataComponent == null || !creatureDataComponent.ComponentDataMap.TryGetValue("AttributeComponent", out entityComponentPb))
		{
			repeatedField = null;
		}
		else if (entityComponentPb == null)
		{
			repeatedField = null;
		}
		else
		{
			AttributeComponentPb attributeComponent = entityComponentPb.AttributeComponent;
			repeatedField = ((attributeComponent != null) ? attributeComponent.WhiteGreenProps : null);
		}
		RepeatedField<WhiteGreenPropData> repeatedField2 = repeatedField;
		if (repeatedField2 == null)
		{
			return;
		}
		List<EAttributeType> list = new List<EAttributeType>();
		bool flag = base.Init();
		foreach (WhiteGreenPropData whiteGreenPropData in repeatedField2)
		{
			int attributeType = whiteGreenPropData.AttributeType;
			int whiteValue = whiteGreenPropData.WhiteValue;
			int greenValue = whiteGreenPropData.GreenValue;
			int currentValue = whiteGreenPropData.CurrentValue;
			if (attributeType < 0 || attributeType >= 143)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.ZFJ;
				string message = "[属性初始化]服务端下发越界属性Id，已跳过";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("AttributeType", attributeType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("WhiteValue", whiteValue);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("GreenValue", greenValue);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Max", 143);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
			else
			{
				if (greenValue == 0)
				{
					list.Add((EAttributeType)attributeType);
				}
				this.BaseValues[attributeType] = (float)whiteValue;
				this.CurrentValues[attributeType] = (float)currentValue;
			}
		}
		if (flag)
		{
			foreach (EAttributeType attrId in list)
			{
				this.UpdateCurrentValue(attrId);
			}
		}
	}

	// Token: 0x0601879E RID: 100254 RVA: 0x006DAF44 File Offset: 0x006D9144
	public override void SeamlessTravelingRefresh()
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		EntityComponentPb entityComponentPb;
		RepeatedField<WhiteGreenPropData> repeatedField;
		if (creatureDataComponent == null || !creatureDataComponent.ComponentDataMap.TryGetValue("AttributeComponent", out entityComponentPb))
		{
			repeatedField = null;
		}
		else if (entityComponentPb == null)
		{
			repeatedField = null;
		}
		else
		{
			AttributeComponentPb attributeComponent = entityComponentPb.AttributeComponent;
			repeatedField = ((attributeComponent != null) ? attributeComponent.WhiteGreenProps : null);
		}
		RepeatedField<WhiteGreenPropData> repeatedField2 = repeatedField;
		if (repeatedField2 == null)
		{
			return;
		}
		foreach (WhiteGreenPropData whiteGreenPropData in repeatedField2)
		{
			int whiteValue = whiteGreenPropData.WhiteValue;
			base.SyncValueFromServer((EAttributeType)whiteGreenPropData.AttributeType, (float)whiteValue, (float)whiteGreenPropData.CurrentValue);
		}
	}

	// Token: 0x0601879F RID: 100255 RVA: 0x006DAFE8 File Offset: 0x006D91E8
	private void OnAnyCurrentValueChange(EAttributeType attrId, float newValue, float oldValue)
	{
		bool flag = false;
		using (Dictionary<EAttributeType, EAttributeType>.ValueCollection.Enumerator enumerator = CharacterAttributeTypes.attributeIdsWithMax.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == attrId)
				{
					flag = true;
					break;
				}
			}
		}
		if (CharacterAttributeTypes.stateAttributeIds.Contains(attrId) || flag)
		{
			this.ApplyModToAttributeToAbilitySystem((int)attrId, EGameplayModOp.Override, newValue);
		}
	}

	// Token: 0x060187A0 RID: 100256 RVA: 0x006DB058 File Offset: 0x006D9258
	[CombatListen(ENotifyMessageId.AttributeChangedNotify, true, false)]
	public static void AttributeChangedNotify(Entity entity, [Nullable(1)] AttributeChangedNotify data, CombatCommon combatCommon = null)
	{
		BaseAttributeComponent baseAttributeComponent = (entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		foreach (GameplayAttributeData gameplayAttributeData in data.Attributes)
		{
			if (CharacterAttributeTypes.stateAttributeIds.Contains((EAttributeType)gameplayAttributeData.AttributeType))
			{
				gameplayAttributeData.CurrentValue = gameplayAttributeData.BaseValue;
			}
			if (gameplayAttributeData.AttributeType != 0)
			{
				baseAttributeComponent.SyncValueFromServer((EAttributeType)gameplayAttributeData.AttributeType, (float)gameplayAttributeData.BaseValue, (float)gameplayAttributeData.CurrentValue);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int, AttributeChangedNotify>(EEventName.OnServerAttributeChange, entity.Id, data);
	}

	// Token: 0x060187A1 RID: 100257 RVA: 0x006DB108 File Offset: 0x006D9308
	[CombatListen(ENotifyMessageId.RecoverPropChangedNotify, true, false)]
	public static void RecoverPropChangedNotify(Entity entity, [Nullable(1)] RecoverPropChangedNotify data, CombatCommon combatCommon = null)
	{
		BaseAttributeComponent baseAttributeComponent = (entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		double deltaTime = Singleton<Time>.Instance.ServerCombatStopTime - (double)data.CurTime;
		foreach (RecoverAttr recoverAttr in data.Attributes)
		{
			baseAttributeComponent.SyncRecoverPropFromServer((EAttributeType)recoverAttr.AttrId, (float)recoverAttr.CurrentValue, (float)recoverAttr.MaxValue, (float)recoverAttr.Ratio, deltaTime);
		}
	}

	// Token: 0x060187A2 RID: 100258 RVA: 0x006DB194 File Offset: 0x006D9394
	protected override bool OnInit()
	{
		base.OnInit();
		this.BuffComponent = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		return true;
	}

	// Token: 0x060187A3 RID: 100259 RVA: 0x006DB1B0 File Offset: 0x006D93B0
	protected override bool OnStart()
	{
		this.InitFromPbData();
		BaseActorComponent baseActorComponent = base.Entity.CheckGetComponent<BaseActorComponent>();
		ABaseCharacter abaseCharacter = ((baseActorComponent != null) ? baseActorComponent.Owner : null) as ABaseCharacter;
		if (abaseCharacter != null)
		{
			this.TsAbilitySystemComponent = abaseCharacter.AbilitySystemComponent;
			this.InitializeGASAttributes = abaseCharacter.bInitializeAttributes;
		}
		foreach (EAttributeType eattributeType in CharacterAttributeTypes.attributeIdsWithMax.Values)
		{
			this.ApplyModToAttributeToAbilitySystem((int)eattributeType, EGameplayModOp.Override, base.GetCurrentValue(eattributeType));
		}
		foreach (EAttributeType eattributeType2 in CharacterAttributeTypes.stateAttributeIds)
		{
			this.ApplyModToAttributeToAbilitySystem((int)eattributeType2, EGameplayModOp.Override, base.GetCurrentValue(eattributeType2));
		}
		return true;
	}

	// Token: 0x060187A4 RID: 100260 RVA: 0x006DB29C File Offset: 0x006D949C
	protected override bool OnEnd()
	{
		base.RemoveListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnLifeChanged));
		base.RemoveListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnLifeMaxChanged));
		base.RemoveListeners(CharacterAttributeTypes.energyAttrIds, new Action<EAttributeType, float, float>(this.OnSpecialEnergyChanged));
		base.RemoveGeneralListener(new Action<EAttributeType, float, float>(this.OnAnyCurrentValueChange));
		return true;
	}

	// Token: 0x060187A5 RID: 100261 RVA: 0x006DB2FB File Offset: 0x006D94FB
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x060187A6 RID: 100262 RVA: 0x006DB300 File Offset: 0x006D9500
	public override void ClearSpecialEnergy()
	{
		CharacterBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent != null && buffComponent.HasBuffAuthority())
		{
			foreach (EAttributeType attrId in CharacterAttributeTypes.specialEnergyIds)
			{
				base.SetBaseValue(attrId, 0f);
			}
		}
	}

	// Token: 0x060187A7 RID: 100263 RVA: 0x006DB36C File Offset: 0x006D956C
	public void ApplyModToAttributeToAbilitySystem(int attributeId, EGameplayModOp modifierOp, float modifierMagnitude)
	{
		if (!this.InitializeGASAttributes)
		{
			return;
		}
		UBaseAbilitySystemComponent tsAbilitySystemComponent = this.TsAbilitySystemComponent;
		if (tsAbilitySystemComponent == null)
		{
			return;
		}
		tsAbilitySystemComponent.InternalApplyModToAttribute(attributeId, modifierOp, modifierMagnitude);
	}

	// Token: 0x060187A8 RID: 100264 RVA: 0x006DB38A File Offset: 0x006D958A
	protected override void DispatchCurrentValueEventImplement(EAttributeType attrId, float newValue, float oldValue)
	{
		base.DispatchCurrentValueEventImplement(attrId, newValue, oldValue);
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<EAttributeType, Entity, float, float>(base.Entity, EAbilityEventName.OnAttributeChange, (long)attrId, attrId, base.Entity, newValue, oldValue);
	}

	// Token: 0x060187A9 RID: 100265 RVA: 0x006DB3B1 File Offset: 0x006D95B1
	private void OnLifeChanged(EAttributeType attrId, float newValue, float oldValue)
	{
		Singleton<EventSystem>.Instance.Emit<int, float, float>(EEventName.CharOnHealthChanged, base.Entity.Id, newValue, oldValue);
	}

	// Token: 0x060187AA RID: 100266 RVA: 0x006DB3D0 File Offset: 0x006D95D0
	private void OnLifeMaxChanged(EAttributeType attrId, float newValue, float oldValue)
	{
		Singleton<EventSystem>.Instance.Emit<int, float, float>(EEventName.CharOnHealthMaxChanged, base.Entity.Id, newValue, oldValue);
	}

	// Token: 0x060187AB RID: 100267 RVA: 0x006DB3EF File Offset: 0x006D95EF
	private void OnSpecialEnergyChanged(EAttributeType attribute, float newValue, float oldValue)
	{
		Singleton<EventSystem>.Instance.EmitWithTarget<EAttributeType, float, float>(base.Entity, EEventName.CharOnEnergyChanged, attribute, newValue, oldValue);
	}

	// Token: 0x060187AC RID: 100268 RVA: 0x006DB40C File Offset: 0x006D960C
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterAttributeComponent characterAttributeComponent = (CharacterAttributeComponent)componentTemplate;
		if (base.CanResetComponentProperty("InitializeGASAttributes"))
		{
			this.InitializeGASAttributes = characterAttributeComponent.InitializeGASAttributes;
		}
		if (base.CanResetComponentProperty("TsAbilitySystemComponent"))
		{
			if (characterAttributeComponent.TsAbilitySystemComponent == null)
			{
				this.TsAbilitySystemComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UBaseAbilitySystemComponent>(this.TsAbilitySystemComponent), "TsAbilitySystemComponent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400BCB1 RID: 48305
	protected bool InitializeGASAttributes = true;

	// Token: 0x0400BCB2 RID: 48306
	private UBaseAbilitySystemComponent TsAbilitySystemComponent;
}
