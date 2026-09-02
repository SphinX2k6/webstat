using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200305D RID: 12381
[NullableContext(2)]
[Nullable(0)]
public class CharacterPart
{
	// Token: 0x06019705 RID: 104197 RVA: 0x00759AD8 File Offset: 0x00757CD8
	[NullableContext(1)]
	public CharacterPart(Entity baseEntity, int index, SCharacterPart table)
	{
		this.BaseEntity = baseEntity;
		this.ActorComp = baseEntity.GetComponent<CharacterActorComponent>();
		this.TagComponent = baseEntity.GetComponent<BaseTagComponent>();
		this.AttributeComp = baseEntity.GetComponent<BaseAttributeComponent>();
		this.Index = index;
		FGameplayTag fgameplayTag = table.部位标签;
		this.PartTag = GameplayTagUtils.GetGameplayTagByName(fgameplayTag.TagName.ToString());
		fgameplayTag = table.部位激活标签;
		this.ActiveTag = GameplayTagUtils.GetGameplayTagByName(fgameplayTag.TagName.ToString());
		this.IsWeakness = table.是否弱点;
		this.WeaknessAngle = table.弱点受击角度;
		this.PreciseWeaknessAngle = table.精准弱点受击角度判定;
		this.BoneName = FNameUtil.GetDynamicFName(table.部位名);
		this.SeparateDamage = table.是否独立承伤;
		this.InheritLife = (table.继承生命值比例 > 0f);
		this.WeaknessTypeSet = new HashSet<global::EBulletType>();
		this.PartSocketName = new FName?(table.部位状态条骨骼插槽);
		this.IsPartStateVisible = table.是否在目标创建时显示部位状态条;
		this.HitPartStateVisibleDuration = (this.IsPartStateVisible ? table.受击后血条显示时长 : 0f);
		this.IsShield = table.是否盾牌;
		this.IsTransferDamage = table.是否传递伤害;
		this.BlockAngle = table.格挡判定角度;
		this.AttributeBuffList = new long[0];
		this.ScanEffect = table.被扫描播放特效.AssetPathName.ToString();
		this.ScanEffectSocketName = FNameUtil.GetDynamicFName(table.扫描特效绑定骨骼名);
		this.ScanMaterialEffect = table.扫描材质特效;
		this.CombinePartSocketName = new FName?(table.合体骨骼名);
		for (int i = 0; i < table.弱点攻击类型.Num(); i++)
		{
			this.WeaknessTypeSet.Add((global::EBulletType)table.弱点攻击类型.GetElement(i));
		}
		List<long> list = new List<long>();
		for (int j = 0; j < table.属性快照Buff列表.Num(); j++)
		{
			list.Add(table.属性快照Buff列表.Get(j));
		}
		this.AttributeBuffList = list.ToArray();
		if (this.InheritLife)
		{
			this.LifeMax = this.AttributeComp.GetCurrentValue(EAttributeType.LifeMax) * table.继承生命值比例;
		}
		else
		{
			this.LifeMax = -1f;
		}
		this.Life = this.LifeMax;
	}

	// Token: 0x06019706 RID: 104198 RVA: 0x00759D3B File Offset: 0x00757F3B
	public void SetActive(bool active)
	{
		this.Active = active;
	}

	// Token: 0x06019707 RID: 104199 RVA: 0x00759D44 File Offset: 0x00757F44
	private void HandleSetActive(bool active)
	{
		if (this.Active == active)
		{
			return;
		}
		this.Active = active;
		if (this.Active)
		{
			this.TagComponent.AddTag(new int?((this.ActiveTag != null) ? this.ActiveTag.GetValueOrDefault().TagId() : 0));
			return;
		}
		this.TagComponent.RemoveTag((this.ActiveTag != null) ? new int?(this.ActiveTag.GetValueOrDefault().TagId()) : null);
	}

	// Token: 0x06019708 RID: 104200 RVA: 0x00759DCC File Offset: 0x00757FCC
	[NullableContext(1)]
	public unsafe void UpdatePartInfo(PartInformation data, bool triggerEvent = true)
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Part;
		Entity baseEntity = this.BaseEntity;
		string message = "UpdatePartInfo";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TagName", (this.PartTag != null) ? new FName?(this.PartTag.GetValueOrDefault().TagName) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Activated", data.Activated);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("LifeValue", data.LifeValue);
		instance.Info(flag, baseEntity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		this.HandleSetActive(data.Activated);
		this.LifeMax = data.LifeMax;
		this.HandleChangeLife(data.LifeValue, triggerEvent);
	}

	// Token: 0x06019709 RID: 104201 RVA: 0x00759EB0 File Offset: 0x007580B0
	[NullableContext(1)]
	public bool OnDamage(float damage, bool hitWeakness, Entity attacker, bool deductLife = true)
	{
		bool result = false;
		TsBaseCharacter actor = this.ActorComp.Actor;
		float num = this.RemainedLifeRate();
		if (deductLife)
		{
			this.Life -= damage;
			float num2 = this.RemainedLifeRate();
			GlobalData.BpEventManager.角色部位血量变化时.Broadcast(actor, this.PartTag.Value, num, num2);
			Singleton<EventSystem>.Instance.EmitWithTarget<float, CharacterPart>(this.BaseEntity, EEventName.CharPartDamage, damage, this);
			if (num > 0f && num2 <= 0f)
			{
				result = true;
			}
		}
		if (hitWeakness)
		{
			TsBaseCharacter actor2 = attacker.GetComponent<CharacterActorComponent>().Actor;
			GlobalData.BpEventManager.角色部位弱点打击时.Broadcast(actor, this.PartTag.Value, actor2);
		}
		return result;
	}

	// Token: 0x0601970A RID: 104202 RVA: 0x00759F60 File Offset: 0x00758160
	public void HandleChangeLife(float value, bool triggerEvent = true)
	{
		float num = this.Life - value;
		if (num == 0f)
		{
			return;
		}
		float num2 = this.RemainedLifeRate();
		this.Life = value;
		if (triggerEvent)
		{
			float num3 = this.RemainedLifeRate();
			if (num2 != num3)
			{
				TsBaseCharacter actor = this.ActorComp.Actor;
				GlobalData.BpEventManager.角色部位血量变化时.Broadcast(actor, this.PartTag.Value, num2, num3);
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<float, CharacterPart>(this.BaseEntity, EEventName.CharPartDamage, num, this);
		}
	}

	// Token: 0x0601970B RID: 104203 RVA: 0x00759FD9 File Offset: 0x007581D9
	public float RemainedLife()
	{
		if (!this.InheritLife)
		{
			return -1f;
		}
		if (this.Life < 0f)
		{
			return 0f;
		}
		return this.Life;
	}

	// Token: 0x0601970C RID: 104204 RVA: 0x0075A002 File Offset: 0x00758202
	public float RemainedLifeRate()
	{
		if (!this.InheritLife)
		{
			return -1f;
		}
		return this.RemainedLife() / this.LifeMax;
	}

	// Token: 0x0601970D RID: 104205 RVA: 0x0075A01F File Offset: 0x0075821F
	public void ResetLife()
	{
	}

	// Token: 0x0400C95E RID: 51550
	public Entity BaseEntity;

	// Token: 0x0400C95F RID: 51551
	public CharacterActorComponent ActorComp;

	// Token: 0x0400C960 RID: 51552
	public BaseTagComponent TagComponent;

	// Token: 0x0400C961 RID: 51553
	public BaseAttributeComponent AttributeComp;

	// Token: 0x0400C962 RID: 51554
	public int Index;

	// Token: 0x0400C963 RID: 51555
	public FGameplayTag? PartTag;

	// Token: 0x0400C964 RID: 51556
	public FGameplayTag? ActiveTag;

	// Token: 0x0400C965 RID: 51557
	public FName? BoneName;

	// Token: 0x0400C966 RID: 51558
	public bool SeparateDamage;

	// Token: 0x0400C967 RID: 51559
	public bool IsWeakness;

	// Token: 0x0400C968 RID: 51560
	public HashSet<global::EBulletType> WeaknessTypeSet;

	// Token: 0x0400C969 RID: 51561
	public float WeaknessAngle;

	// Token: 0x0400C96A RID: 51562
	public bool PreciseWeaknessAngle;

	// Token: 0x0400C96B RID: 51563
	public bool InheritLife;

	// Token: 0x0400C96C RID: 51564
	public float LifeMax;

	// Token: 0x0400C96D RID: 51565
	public float Life;

	// Token: 0x0400C96E RID: 51566
	public bool Active;

	// Token: 0x0400C96F RID: 51567
	public FName? PartSocketName;

	// Token: 0x0400C970 RID: 51568
	public bool IsPartStateVisible;

	// Token: 0x0400C971 RID: 51569
	public float HitPartStateVisibleDuration;

	// Token: 0x0400C972 RID: 51570
	public bool IsShield;

	// Token: 0x0400C973 RID: 51571
	public bool IsTransferDamage;

	// Token: 0x0400C974 RID: 51572
	public float BlockAngle;

	// Token: 0x0400C975 RID: 51573
	public long[] AttributeBuffList;

	// Token: 0x0400C976 RID: 51574
	[Nullable(1)]
	public string ScanEffect = "";

	// Token: 0x0400C977 RID: 51575
	public FName? ScanEffectSocketName;

	// Token: 0x0400C978 RID: 51576
	public PD_CharacterControllerData_C ScanMaterialEffect;

	// Token: 0x0400C979 RID: 51577
	public FName? CombinePartSocketName;

	// Token: 0x0400C97A RID: 51578
	public bool IsWeaknessHit;

	// Token: 0x0400C97B RID: 51579
	[Nullable(1)]
	public string HitBoneName = "";
}
