using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02003129 RID: 12585
[NullableContext(2)]
[Nullable(0)]
public class Skill
{
	// Token: 0x17002356 RID: 9046
	// (get) Token: 0x0601A0E6 RID: 106726 RVA: 0x007A2379 File Offset: 0x007A0579
	// (set) Token: 0x0601A0E7 RID: 106727 RVA: 0x007A2381 File Offset: 0x007A0581
	public long? CombatMessageId
	{
		get
		{
			return this.CombatMessageIdInternal;
		}
		private set
		{
			this.CombatMessageIdInternal = value;
			AddBattleFlag.ApplyEffects(this.SkillComp.Entity, this);
			if (this.BattleContext != null)
			{
				this.BattleContext.VisionId = this.GetVisionId();
			}
		}
	}

	// Token: 0x17002357 RID: 9047
	// (get) Token: 0x0601A0E8 RID: 106728 RVA: 0x007A23B4 File Offset: 0x007A05B4
	public int SkillId
	{
		get
		{
			return this.SkillIdInternal;
		}
	}

	// Token: 0x17002358 RID: 9048
	// (get) Token: 0x0601A0E9 RID: 106729 RVA: 0x007A23BC File Offset: 0x007A05BC
	public bool Active
	{
		get
		{
			return this.ActiveInternal;
		}
	}

	// Token: 0x17002359 RID: 9049
	// (get) Token: 0x0601A0EA RID: 106730 RVA: 0x007A23C4 File Offset: 0x007A05C4
	public bool IsSimulated
	{
		get
		{
			return this.IsSimulatedInternal;
		}
	}

	// Token: 0x1700235A RID: 9050
	// (get) Token: 0x0601A0EB RID: 106731 RVA: 0x007A23CC File Offset: 0x007A05CC
	public SSkillInfo SkillInfo
	{
		get
		{
			return this.SkillInfoInternal;
		}
	}

	// Token: 0x1700235B RID: 9051
	// (get) Token: 0x0601A0EC RID: 106732 RVA: 0x007A23D4 File Offset: 0x007A05D4
	[Nullable(1)]
	public string SkillName
	{
		[NullableContext(1)]
		get
		{
			SSkillInfo skillInfoInternal = this.SkillInfoInternal;
			return ((skillInfoInternal != null) ? skillInfoInternal.SkillName.ToString() : null) ?? "";
		}
	}

	// Token: 0x1700235C RID: 9052
	// (get) Token: 0x0601A0ED RID: 106733 RVA: 0x007A240A File Offset: 0x007A060A
	[Nullable(1)]
	public IReadOnlyList<int> SkillTagIds
	{
		[NullableContext(1)]
		get
		{
			return this.SkillTagIdsInternal;
		}
	}

	// Token: 0x1700235D RID: 9053
	// (get) Token: 0x0601A0EE RID: 106734 RVA: 0x007A2412 File Offset: 0x007A0612
	public UClass AbilityClass
	{
		get
		{
			return this.AbilityClassInternal;
		}
	}

	// Token: 0x1700235E RID: 9054
	// (get) Token: 0x0601A0EF RID: 106735 RVA: 0x007A241A File Offset: 0x007A061A
	// (set) Token: 0x0601A0F0 RID: 106736 RVA: 0x007A2422 File Offset: 0x007A0622
	public int InterruptLevel
	{
		get
		{
			return this.InterruptLevelInternal;
		}
		set
		{
			this.InterruptLevelInternal = value;
		}
	}

	// Token: 0x0601A0F1 RID: 106737 RVA: 0x007A242B File Offset: 0x007A062B
	public UAnimMontage GetMontageByIndex(int index)
	{
		if (this.LoadedMontagesInternal == null)
		{
			return null;
		}
		if (index < 0 || index >= this.LoadedMontagesInternal.Length)
		{
			return null;
		}
		return this.LoadedMontagesInternal[index];
	}

	// Token: 0x0601A0F2 RID: 106738 RVA: 0x007A2450 File Offset: 0x007A0650
	[NullableContext(1)]
	public void SetMontageByIndex(int index, UAnimMontage montage)
	{
		if (this.LoadedMontagesInternal == null)
		{
			this.LoadedMontagesInternal = new UAnimMontage[this.SkillInfo.MontagePaths.Num()];
		}
		if (index < this.LoadedMontagesInternal.Length)
		{
			this.LoadedMontagesInternal[index] = montage;
		}
	}

	// Token: 0x0601A0F3 RID: 106739 RVA: 0x007A2489 File Offset: 0x007A0689
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public UAnimMontage[] GetLoadedMontages()
	{
		return this.LoadedMontagesInternal;
	}

	// Token: 0x0601A0F4 RID: 106740 RVA: 0x007A2494 File Offset: 0x007A0694
	public int GetPlayingMontageIndex()
	{
		BaseSkillComponent skillComp = this.SkillComp;
		UAnimMontage uanimMontage;
		if (skillComp == null)
		{
			uanimMontage = null;
		}
		else
		{
			UAnimInstance mainAnimInstance = skillComp.GetMainAnimInstance();
			uanimMontage = ((mainAnimInstance != null) ? mainAnimInstance.GetCurrentActiveMontage() : null);
		}
		UAnimMontage uanimMontage2 = uanimMontage;
		if (uanimMontage2 != null && this.LoadedMontagesInternal != null)
		{
			for (int i = 0; i < this.LoadedMontagesInternal.Length; i++)
			{
				if (this.LoadedMontagesInternal[i] == uanimMontage2)
				{
					return i;
				}
			}
		}
		return this.CurrentMontageIndex;
	}

	// Token: 0x0601A0F5 RID: 106741 RVA: 0x007A24F4 File Offset: 0x007A06F4
	[NullableContext(1)]
	public void Initialize(int skillId, SSkillInfo skillInfo, BaseSkillComponent skillComponent)
	{
		this.SkillComp = skillComponent;
		this.BuffComp = skillComponent.Entity.GetComponent<CharacterBuffComponent>();
		this.TagComp = skillComponent.Entity.GetComponent<BaseTagComponent>();
		this.ActorComp = skillComponent.Entity.GetComponent<CharacterActorComponent>();
		this.MontageComp = skillComponent.Entity.GetComponent<CharacterMontageComponent>();
		this.TimeScaleComp = skillComponent.Entity.GetComponent<PawnTimeScaleComponent>();
		this.SkillIdInternal = skillId;
		this.SkillInfoInternal = skillInfo;
		this.ActiveInternal = false;
		this.EndSkillInfo = new EndSkillInfo();
		this.InterruptLevelInternal = skillInfo.InterruptLevel;
		this.VisionTagId = 0;
		for (int i = skillInfo.SkillTag.Num() - 1; i >= 0; i--)
		{
			int num = skillInfo.SkillTag.Get(i).TagId();
			if (GameplayTagUtils.IsChildTag(num, VisionTriggerTag.Value))
			{
				this.VisionTagId = num;
			}
			this.SkillTagIdsInternal.Add(num);
		}
		if (skillInfo.SkillMode == ESkillMode.GameplayAbility)
		{
			this.LoadAbility();
		}
		this.LoadMontage();
	}

	// Token: 0x0601A0F6 RID: 106742 RVA: 0x007A25FC File Offset: 0x007A07FC
	public bool Clear()
	{
		if (this.Active)
		{
			this.EndSkill();
		}
		this.ClearBurstLockTimer();
		if (this.AbilityHandle != null)
		{
			this.SkillComp.Entity.GetComponent<BaseAbilityComponent>().ClearAbility(this.AbilityHandle);
			this.AbilityHandle = null;
		}
		this.SkillComp = null;
		this.BuffComp = null;
		this.TagComp = null;
		this.SkillInfoInternal = null;
		this.ActiveAbility = null;
		this.ActiveMontageTask = null;
		this.ActiveInternal = false;
		this.GroupSkillCdInfo = null;
		this.LoadedMontagesInternal = null;
		this.AbilityClassInternal = null;
		this.NeedPlayMontageIndex = -1;
		return true;
	}

	// Token: 0x0601A0F7 RID: 106743 RVA: 0x007A269C File Offset: 0x007A089C
	private unsafe void LoadAbility()
	{
		string text = this.SkillInfo.SkillGA.AssetPathName.ToString();
		if (!string.IsNullOrEmpty(text) && text != "None")
		{
			CharacterActorComponent actorComp = this.ActorComp;
			text = (((actorComp != null) ? actorComp.GetReplaceEffect(text) : null) ?? text);
			this.AbilityClassInternal = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UBlueprintGeneratedClass>(text);
			if (this.AbilityClassInternal == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
				Entity entity = this.SkillComp.Entity;
				string message = "加载技能GA失败，GA未加载";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", this.SkillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名", this.SkillName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("GA", this.SkillInfo.SkillGA);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("GA Path", text);
				instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return;
			}
			GA_Base_C ga_Base_C = UKuroStaticLibrary.GetDefaultObject(this.AbilityClassInternal.ClassStackOnlyPtr) as GA_Base_C;
			if (this.AbilityClassInternal.IsChildOf(Ga_Passive_C.StaticClass()))
			{
				this.SkillComp.SetGaPassiveClassToSkillMap(this.AbilityClassInternal, this.SkillId);
				this.CombatMessageId = this.GetGaPassiveSkillMessage();
			}
			else if (ga_Base_C.AbilityTriggers != null && ga_Base_C.AbilityTriggers.Num() > 0)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Skill;
				Entity entity2 = this.SkillComp.Entity;
				string message2 = "被动技能未继承自Ga_Passive";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("技能Id", this.SkillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("技能名", this.SkillName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("GA", this.SkillInfo.SkillGA);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("GA Path", text);
				instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			}
			this.GiveAbility();
			if (ga_Base_C.StartOnGiven)
			{
				this.SkillComp.StartOnGivenList.Add(this.SkillId);
				return;
			}
		}
		else
		{
			CombatLog instance3 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Skill;
			Entity entity3 = this.SkillComp.Entity;
			string message3 = "加载技能GA失败，GA路径为空";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("技能Id", this.SkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("技能名", this.SkillName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("GA", this.SkillInfo.SkillGA);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("GA Path", text);
			instance3.Error(flag3, entity3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
		}
	}

	// Token: 0x0601A0F8 RID: 106744 RVA: 0x007A29A0 File Offset: 0x007A0BA0
	private void GiveAbility()
	{
		if (this.AbilityClassInternal != null)
		{
			BaseAbilityComponent component = this.SkillComp.Entity.GetComponent<BaseAbilityComponent>();
			this.AbilityHandle = component.GetAbility(this.AbilityClassInternal.ClassStackOnlyPtr);
		}
	}

	// Token: 0x0601A0F9 RID: 106745 RVA: 0x007A29E0 File Offset: 0x007A0BE0
	private unsafe void LoadMontage()
	{
		if (this.SkillInfo.Animations.Num() > 0)
		{
			this.LoadedMontagesInternal = new UAnimMontage[this.SkillInfo.Animations.Num()];
			BaseSkillComponent skillComp = this.SkillComp;
			CharacterActorComponent characterActorComponent = (skillComp != null) ? skillComp.Entity.GetComponent<CharacterActorComponent>() : null;
			for (int i = 0; i < this.SkillInfo.Animations.Num(); i++)
			{
				FSoftObjectPath montageSoftObjectPath = this.SkillInfo.Animations.Get(i);
				if (!ObjectUtils.SoftObjectPathIsValid(montageSoftObjectPath))
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
					Entity entity = this.SkillComp.Entity;
					string message = "蒙太奇软路径对象无效，请设置Animations蒙太奇软路径对象";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", this.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名", this.SkillName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("索引", i);
					instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				else
				{
					int index = i;
					string text = montageSoftObjectPath.AssetPathName.ToString();
					if (characterActorComponent != null)
					{
						text = (characterActorComponent.GetReplaceMontage(text) ?? text);
					}
					UAnimMontage loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UAnimMontage>(text);
					if (loadedAsset == null || !loadedAsset.IsValid())
					{
						Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(text, delegate([Nullable(2)] UAnimMontage montage, string _)
						{
							if (montage == null || !montage.IsValid())
							{
								CombatLog instance4 = Singleton<CombatLog>.Instance;
								CombatLog.EDebugModule flag5 = CombatLog.EDebugModule.Skill;
								Entity entity4 = this.SkillComp.Entity;
								string message4 = "蒙太奇加载失败，请检查Animations蒙太奇软路径对象";
								<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray4<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("技能Id", this.SkillId);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("技能名", this.SkillName);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("索引", index);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("AssetNamePath", montageSoftObjectPath.AssetPathName);
								instance4.Warn(flag5, entity4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 4));
								return;
							}
							if (this.LoadedMontagesInternal == null)
							{
								return;
							}
							this.LoadedMontagesInternal[index] = montage;
						}, 100, "js_undefined");
					}
					else
					{
						this.LoadedMontagesInternal[index] = loadedAsset;
					}
				}
			}
			return;
		}
		TArray<string> montagePaths = this.SkillInfo.MontagePaths;
		if (montagePaths.Num() > 0)
		{
			bool flag2 = false;
			this.LoadedMontagesInternal = new UAnimMontage[montagePaths.Num()];
			for (int j = 0; j < montagePaths.Num(); j++)
			{
				string text2 = montagePaths.Get(j);
				if (string.IsNullOrEmpty(text2))
				{
					flag2 = true;
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Skill;
					Entity entity2 = this.SkillComp.Entity;
					string message2 = "蒙太奇路径为空，请设置MontagePaths蒙太奇路径";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("技能Id", this.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("技能名", this.SkillName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("索引", j);
					instance2.Error(flag3, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
				if (flag2)
				{
					return;
				}
				CharacterMontageComponent montageComp = this.MontageComp;
				UAnimMontage uanimMontage = (montageComp != null) ? montageComp.GetMontageByName(text2, true, true) : null;
				if (uanimMontage != null)
				{
					this.LoadedMontagesInternal[j] = uanimMontage;
				}
				else
				{
					CombatLog instance3 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag4 = CombatLog.EDebugModule.Skill;
					Entity entity3 = this.SkillComp.Entity;
					string message3 = "蒙太奇未加载";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("技能Id", this.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("技能名", this.SkillName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("索引", j);
					instance3.Warn(flag4, entity3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				}
			}
		}
	}

	// Token: 0x0601A0FA RID: 106746 RVA: 0x007A2D54 File Offset: 0x007A0F54
	public void AttachEffect(int effect, Skill.ESkillEffectType type, FName boneName, float whenSkillEndEnableTime)
	{
		List<Skill.ISkillEffect> list;
		if (!this.EffectsAttached.TryGetValue(type, out list))
		{
			list = new List<Skill.ISkillEffect>();
			this.EffectsAttached[type] = list;
		}
		Skill.SkillEffect item = new Skill.SkillEffect
		{
			BoneName = boneName,
			EffectHandle = effect,
			WhenSkillEndEnableTime = whenSkillEndEnableTime
		};
		list.Add(item);
	}

	// Token: 0x0601A0FB RID: 106747 RVA: 0x007A2DA8 File Offset: 0x007A0FA8
	private void CloseEffect(Skill.ESkillEffectType type, int handleId, float whenSkillEndEnableTime)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(handleId))
		{
			return;
		}
		Singleton<EffectSystem>.Instance.SetTimeScale(handleId, 1f, false);
		if (whenSkillEndEnableTime > 0f && Singleton<EffectSystem>.Instance.GetTotalPassTime(handleId) > whenSkillEndEnableTime)
		{
			return;
		}
		AActor sureEffectActor = Singleton<EffectSystem>.Instance.GetSureEffectActor(handleId);
		EDetachmentRule edetachmentRule = EDetachmentRule.KeepWorld;
		switch (type)
		{
		case Skill.ESkillEffectType.Detach:
			if (sureEffectActor != null)
			{
				sureEffectActor.K2_DetachFromActor(edetachmentRule, edetachmentRule, edetachmentRule);
			}
			EffectUtil.ListenForeverTimeScale(handleId, this.TimeScaleComp);
			Singleton<EffectSystem>.Instance.StopEffectById(handleId, "[Skill.EffectsProcess] Detach", false, null);
			return;
		case Skill.ESkillEffectType.DetachEnd:
			if (sureEffectActor != null)
			{
				sureEffectActor.K2_DetachFromActor(edetachmentRule, edetachmentRule, edetachmentRule);
				EffectUtil.ListenForeverTimeScale(handleId, this.TimeScaleComp);
				Singleton<EffectSystem>.Instance.StopEffectById(handleId, "[Skill.EffectsProcess] DetachEnd", false, null);
				return;
			}
			break;
		case Skill.ESkillEffectType.DetachDestroy:
			if (sureEffectActor != null)
			{
				sureEffectActor.K2_DetachFromActor(edetachmentRule, edetachmentRule, edetachmentRule);
				Singleton<EffectSystem>.Instance.StopEffectById(handleId, "[Skill.EffectsProcess] DetachDestroy", true, null);
				return;
			}
			break;
		case Skill.ESkillEffectType.UnDetachEnd:
			EffectUtil.ListenForeverTimeScale(handleId, this.TimeScaleComp);
			Singleton<EffectSystem>.Instance.StopEffectById(handleId, "[Skill.EffectsProcess] UnDetachEnd", false, null);
			break;
		case Skill.ESkillEffectType.UnDetachDestroy:
			Singleton<EffectSystem>.Instance.StopEffectById(handleId, "[Skill.EffectsProcess] UnDetachDestroy", true, null);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601A0FC RID: 106748 RVA: 0x007A2EEC File Offset: 0x007A10EC
	private void ClearEffects()
	{
		if (this.EffectsAttached == null)
		{
			return;
		}
		foreach (KeyValuePair<Skill.ESkillEffectType, List<Skill.ISkillEffect>> keyValuePair in this.EffectsAttached)
		{
			List<Skill.ISkillEffect> value = keyValuePair.Value;
			for (int i = value.Count - 1; i >= 0; i--)
			{
				Skill.ISkillEffect skillEffect = value[i];
				value.RemoveAt(i);
				int effectHandle = skillEffect.EffectHandle;
				this.CloseEffect(keyValuePair.Key, effectHandle, skillEffect.WhenSkillEndEnableTime);
			}
		}
		this.EffectsAttached.Clear();
	}

	// Token: 0x0601A0FD RID: 106749 RVA: 0x007A2F98 File Offset: 0x007A1198
	public bool BeginSkill()
	{
		if (this.Active)
		{
			return false;
		}
		this.CurrentMontageIndex = -1;
		this.ActiveInternal = true;
		this.IsSimulatedInternal = false;
		this.CombatMessageId = new long?(ModelBase<CombatMessageModel>.Instance.GenMessageId());
		this.MontageContextId = null;
		EndSkillInfo endSkillInfo = this.EndSkillInfo;
		if (endSkillInfo != null)
		{
			endSkillInfo.Reset();
		}
		return true;
	}

	// Token: 0x0601A0FE RID: 106750 RVA: 0x007A2FF8 File Offset: 0x007A11F8
	public void BeginSkillBuffAndTag(int skillLevel)
	{
		this.SkillLevel = skillLevel;
		if (!this.IsSimulated)
		{
			this.StartBurstLockTimer();
		}
		if (this.BuffComp != null)
		{
			int item = this.BuffComp.AddTagWithReturnHandle(this.SkillTagIds, -1f);
			this.ActiveBuffHandles.Add(item);
		}
		if (this.TagComp != null && this.SkillInfo.GroupId == 1)
		{
			if (this.SkillInfo.IsFullBodySkill)
			{
				this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"]));
			}
			else
			{
				this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.部分动作"]));
			}
		}
		if (this.BuffComp != null && !this.IsSimulated)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (this.SkillComp.IsStrengthCostEffective(this.SkillInfo.StrengthCost))
			{
				BaseBuffComponent buffComp = this.BuffComp;
				long buffId = 3015L;
				AddBuffParam addBuffParam = new AddBuffParam();
				addBuffParam.InstigatorId = this.BuffComp.CreatureDataId;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
				defaultInterpolatedStringHandler.AppendLiteral("存在体力消耗");
				addBuffParam.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				addBuffParam.PreMessageId = this.CombatMessageId;
				int item2 = buffComp.AddBuffLocal(buffId, addBuffParam);
				this.ActiveBuffHandles.Add(item2);
			}
			CharacterBuffComponent buffComp2 = this.BuffComp;
			EAttributeType attributeId = EAttributeType.SkillToughRatio;
			float rate = this.SkillInfo.ToughRatio - 1f;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("技能");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
			defaultInterpolatedStringHandler.AppendLiteral("技能状态韧性系数");
			int item3 = buffComp2.AddAttributeRateModifierLocal(attributeId, rate, defaultInterpolatedStringHandler.ToStringAndClear());
			this.ActiveBuffHandles.Add(item3);
			if (this.SkillInfo.GroupId == 1 && this.SkillInfo.ImmuneFallDamageTime > 0f)
			{
				BaseBuffComponent buffComp3 = this.BuffComp;
				long buffId2 = 3098L;
				AddBuffParam addBuffParam2 = new AddBuffParam();
				addBuffParam2.InstigatorId = this.BuffComp.CreatureDataId;
				addBuffParam2.Duration = new float?(this.SkillInfo.ImmuneFallDamageTime);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
				defaultInterpolatedStringHandler.AppendLiteral("跌落伤害保护");
				addBuffParam2.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				addBuffParam2.PreMessageId = this.CombatMessageId;
				int item4 = buffComp3.AddBuffLocal(buffId2, addBuffParam2);
				this.ActiveBuffHandles.Add(item4);
			}
			for (int i = 0; i < this.SkillInfo.SkillBuff.Num(); i++)
			{
				BaseBuffComponent buffComp4 = this.BuffComp;
				long buffId3 = this.SkillInfo.SkillBuff.Get(i);
				AddBuffParam addBuffParam3 = new AddBuffParam();
				addBuffParam3.InstigatorId = this.BuffComp.CreatureDataId;
				addBuffParam3.Level = new int?(skillLevel);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
				defaultInterpolatedStringHandler.AppendLiteral("通过技能期间生效的GE添加");
				addBuffParam3.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				addBuffParam3.PreMessageId = this.CombatMessageId;
				int item5 = buffComp4.AddBuffLocal(buffId3, addBuffParam3);
				this.ActiveBuffHandles.Add(item5);
			}
			for (int j = 0; j < this.SkillInfo.SkillStartBuff.Num(); j++)
			{
				BaseBuffComponent buffComp5 = this.BuffComp;
				long buffId4 = this.SkillInfo.SkillStartBuff.Get(j);
				AddBuffParam addBuffParam4 = new AddBuffParam();
				addBuffParam4.InstigatorId = this.BuffComp.CreatureDataId;
				addBuffParam4.Level = new int?(skillLevel);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
				defaultInterpolatedStringHandler.AppendLiteral("开始时添加");
				addBuffParam4.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				addBuffParam4.PreMessageId = this.CombatMessageId;
				buffComp5.AddBuff(buffId4, addBuffParam4);
			}
			for (int k = 0; k < this.SkillInfo.StartRemoveBuffIds.Num(); k++)
			{
				BaseBuffComponent buffComp6 = this.BuffComp;
				long buffId5 = this.SkillInfo.StartRemoveBuffIds.Get(k);
				int stackCount = -1;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
				defaultInterpolatedStringHandler.AppendLiteral("开始时移除");
				buffComp6.RemoveBuff(buffId5, stackCount, defaultInterpolatedStringHandler.ToStringAndClear(), this.CombatMessageId, null, null);
			}
		}
	}

	// Token: 0x0601A0FF RID: 106751 RVA: 0x007A3460 File Offset: 0x007A1660
	public bool EndSkill()
	{
		if (!this.Active)
		{
			return false;
		}
		this.ClearBurstLockTimer();
		this.InterruptLevel = this.SkillInfo.InterruptLevel;
		this.ActiveInternal = false;
		this.ActiveAbility = null;
		CharacterFightStateComponent fightStateComp = this.SkillComp.FightStateComp;
		if (fightStateComp != null)
		{
			fightStateComp.ExitState(this.FightStateHandle);
		}
		this.ClearMontage();
		this.ClearEffects();
		foreach (int handle in this.ActiveBuffHandles)
		{
			CharacterBuffComponent buffComp = this.BuffComp;
			if (buffComp != null)
			{
				buffComp.RemoveBuffByHandle(handle, -1, "技能结束移除", null, null, null);
			}
		}
		this.ActiveBuffHandles.Clear();
		if (this.TagComp != null && this.SkillInfo.GroupId == 1)
		{
			if (this.SkillInfo.IsFullBodySkill)
			{
				this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"]));
			}
			else
			{
				this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.部分动作"]));
			}
		}
		this.SkillBehaviorAnimNotifyMessageId = null;
		if (this.BuffComp != null && !this.IsSimulated)
		{
			for (int i = 0; i < this.SkillInfo.SkillEndBuff.Num(); i++)
			{
				BaseBuffComponent buffComp2 = this.BuffComp;
				long buffId = this.SkillInfo.SkillEndBuff.Get(i);
				AddBuffParam addBuffParam = new AddBuffParam();
				addBuffParam.InstigatorId = this.BuffComp.CreatureDataId;
				addBuffParam.Level = new int?(this.SkillLevel);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
				defaultInterpolatedStringHandler.AppendLiteral("结束时添加");
				addBuffParam.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				addBuffParam.PreMessageId = this.CombatMessageId;
				buffComp2.AddBuff(buffId, addBuffParam);
			}
			for (int j = 0; j < this.SkillInfo.EndRemoveBuffIds.Num(); j++)
			{
				BaseBuffComponent buffComp3 = this.BuffComp;
				long buffId2 = this.SkillInfo.EndRemoveBuffIds.Get(j);
				int stackCount = -1;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
				defaultInterpolatedStringHandler.AppendLiteral("技能");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
				defaultInterpolatedStringHandler.AppendLiteral("结束时移除");
				buffComp3.RemoveBuff(buffId2, stackCount, defaultInterpolatedStringHandler.ToStringAndClear(), this.CombatMessageId, null, null);
			}
		}
		this.NeedPlayMontageIndex = -1;
		return true;
	}

	// Token: 0x0601A100 RID: 106752 RVA: 0x007A3710 File Offset: 0x007A1910
	public bool SimulatedBeginSkill(long messageId)
	{
		if (this.Active)
		{
			return false;
		}
		this.ActiveInternal = true;
		this.IsSimulatedInternal = true;
		this.CombatMessageId = new long?(messageId);
		this.NeedPlayMontageIndex = -1;
		this.BeginSkillBuffAndTag(0);
		return true;
	}

	// Token: 0x0601A101 RID: 106753 RVA: 0x007A3748 File Offset: 0x007A1948
	[NullableContext(1)]
	public void SetTimeDilation(PawnTimeScaleComponent timeScaleComp, float timeDilation)
	{
		foreach (List<Skill.ISkillEffect> list in this.EffectsAttached.Values)
		{
			if (list != null)
			{
				foreach (Skill.ISkillEffect skillEffect in list)
				{
					if (Singleton<EffectSystem>.Instance.IsValid(skillEffect.EffectHandle))
					{
						EffectUtil.SetEffectTimeScale(skillEffect.EffectHandle, timeScaleComp, timeDilation, ETimeScaleType.FollowEntity);
					}
				}
			}
		}
	}

	// Token: 0x0601A102 RID: 106754 RVA: 0x007A37F4 File Offset: 0x007A19F4
	[NullableContext(1)]
	public unsafe bool PlayMontage(int index, float rate, string startSection, float startTime, [Nullable(2)] Action<bool> onCompleted = null, long? messageId = null)
	{
		UAnimMontage montageByIndex = this.GetMontageByIndex(index);
		if (montageByIndex == null || !montageByIndex.IsValid())
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = this.SkillComp.Entity;
			string message = "PlaySkillMontage 播放的蒙太奇索引不存在";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能id:", this.SkillId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("技能名:", this.SkillName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MontageIndex", index);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		this.CurrentMontageIndex = index;
		TArray<FCompositeSection> compositeSections = montageByIndex.CompositeSections;
		bool flag2 = false;
		for (int i = 0; i < compositeSections.Num(); i++)
		{
			if (compositeSections.Get(i).SectionName.Equals(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION))
			{
				flag2 = true;
				break;
			}
		}
		float num = startTime;
		float sequenceLength = montageByIndex.SequenceLength;
		if (sequenceLength > 0f && num > sequenceLength && flag2)
		{
			num = 0f;
		}
		FName startingSection = FNameUtil.GetDynamicFName(startSection) ?? FNameUtil.EMPTY;
		this.ActiveMontageTask = UAsyncTaskPlayMontageAndWait.ListenForPlayMontage(this.SkillComp.GetMainAnimInstance(), montageByIndex, rate, num, startingSection);
		if (this.ActiveMontageTask.MontageLength <= 0f)
		{
			Action<bool> onCompleted2 = onCompleted;
			if (onCompleted2 != null)
			{
				onCompleted2(true);
			}
			return false;
		}
		this.ActiveMontageTask.EndCallback.Add(delegate(bool isInterrupted)
		{
			Action<bool> onCompleted3 = onCompleted;
			if (onCompleted3 == null)
			{
				return;
			}
			onCompleted3(isInterrupted);
		});
		this.MontageCallback = onCompleted;
		this.MontageContextId = new long?(messageId ?? ModelBase<CombatMessageModel>.Instance.GenMessageId());
		BaseMontageComponent montageComp = this.SkillComp.MontageComp;
		if (montageComp != null)
		{
			montageComp.PushMontageInfo(new MontageInfo
			{
				MontageNames = new List<string>(),
				SkillId = new int?(this.SkillId),
				MontageIndex = new int?(index),
				MontageTaskMessageId = this.MontageContextId
			}, montageByIndex);
		}
		return true;
	}

	// Token: 0x0601A103 RID: 106755 RVA: 0x007A3A30 File Offset: 0x007A1C30
	private void ClearMontage()
	{
		if (this.ActiveMontageTask != null)
		{
			UAnimMontage montageToPlay = this.ActiveMontageTask.MontageToPlay;
			this.ActiveMontageTask.EndTask();
			this.ActiveMontageTask = null;
			this.SkillComp.GetMainAnimInstance().Montage_Stop(0.2f, montageToPlay);
		}
		this.MontageCallback = null;
	}

	// Token: 0x0601A104 RID: 106756 RVA: 0x007A3A80 File Offset: 0x007A1C80
	public void RequestStopMontage(bool isInterrupted)
	{
		if (this.MontageCallback != null)
		{
			Action<bool> montageCallback = this.MontageCallback;
			this.MontageCallback = null;
			if (montageCallback == null)
			{
				return;
			}
			montageCallback(isInterrupted);
		}
	}

	// Token: 0x0601A105 RID: 106757 RVA: 0x007A3AA4 File Offset: 0x007A1CA4
	public void SetEffectHidden(bool hidden)
	{
		foreach (List<Skill.ISkillEffect> list in this.EffectsAttached.Values)
		{
			foreach (Skill.ISkillEffect skillEffect in list)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(skillEffect.EffectHandle))
				{
					Singleton<EffectSystem>.Instance.SetEffectHidden(skillEffect.EffectHandle, hidden, "Skill", false);
				}
			}
		}
	}

	// Token: 0x0601A106 RID: 106758 RVA: 0x007A3B54 File Offset: 0x007A1D54
	private void StartBurstLockTimer()
	{
		this.ClearBurstLockTimer();
		float burstLockTime = this.SkillInfo.BurstLockTime;
		PawnTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		if (burstLockTime <= 0f || timeScaleComp == null)
		{
			return;
		}
		TimerHandle timerHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.BurstLockTimer = null;
			timeScaleComp.RemoveNormalizeTimeScaleLock("Skill.BurstLock", false);
		}, burstLockTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		if (timerHandle == null)
		{
			return;
		}
		this.BurstLockTimer = timerHandle;
		timeScaleComp.AddNormalizeTimeScaleLock("Skill.BurstLock", true);
	}

	// Token: 0x0601A107 RID: 106759 RVA: 0x007A3BE5 File Offset: 0x007A1DE5
	private void ClearBurstLockTimer()
	{
		if (this.BurstLockTimer != null)
		{
			TimerSystem.Instance.Remove(this.BurstLockTimer);
			this.BurstLockTimer = null;
		}
		PawnTimeScaleComponent timeScaleComp = this.TimeScaleComp;
		if (timeScaleComp == null)
		{
			return;
		}
		timeScaleComp.RemoveNormalizeTimeScaleLock("Skill.BurstLock", false);
	}

	// Token: 0x0601A108 RID: 106760 RVA: 0x007A3C20 File Offset: 0x007A1E20
	private long? GetGaPassiveSkillMessage()
	{
		EntityComponentPb entityComponentPb;
		SkillComponentPb skillComponentPb = this.SkillComp.Entity.GetComponent<CreatureDataComponent>().ComponentDataMap.TryGetValue("SkillComponentPb", out entityComponentPb) ? entityComponentPb.SkillComponentPb : null;
		if (skillComponentPb != null && skillComponentPb.GaPassiveSkills != null)
		{
			foreach (GaPassiveSkill gaPassiveSkill in skillComponentPb.GaPassiveSkills)
			{
				if (this.SkillId == (int)gaPassiveSkill.SkillId)
				{
					return new long?(gaPassiveSkill.ContextId);
				}
			}
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
		Entity entity = this.SkillComp.Entity;
		string message = "未找到服务器对应被动ga技能的上下文，检查该技能是否有导出给服务器";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("技能Id", this.SkillId);
		instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0601A109 RID: 106761 RVA: 0x007A3D08 File Offset: 0x007A1F08
	private int GetVisionId()
	{
		if (this.VisionTagId != 0)
		{
			return this.VisionTagId;
		}
		CreatureDataComponent component = this.SkillComp.Entity.GetComponent<CreatureDataComponent>();
		long? num = (component != null) ? new long?(component.GetSummonerId()) : null;
		if (num != null)
		{
			long? num2 = num;
			long num3 = 0L;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num.Value);
				WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
				CreatureDataComponent creatureDataComponent = (worldEntity != null) ? worldEntity.GetComponent<CreatureDataComponent>() : null;
				if (((creatureDataComponent != null) ? creatureDataComponent.VisionServerEntityIds : null) != null && creatureDataComponent.VisionServerEntityIds.Contains(component.GetCreatureDataId()))
				{
					int? num4;
					if (worldEntity == null)
					{
						num4 = null;
					}
					else
					{
						CharacterVisionComponent component2 = worldEntity.GetComponent<CharacterVisionComponent>();
						num4 = ((component2 != null) ? new int?(component2.GetVisionId(new int?(0))) : null);
					}
					int? num5 = num4;
					return num5.GetValueOrDefault();
				}
			}
		}
		return 0;
	}

	// Token: 0x0400D0F9 RID: 53497
	[Nullable(1)]
	private readonly Stat StatAddSpecTag = Stat.Create("Add Spec Tag", "", "");

	// Token: 0x0400D0FA RID: 53498
	[Nullable(1)]
	private readonly Stat StatAddInSkillTag = Stat.Create("Add InSkill Tag", "", "");

	// Token: 0x0400D0FB RID: 53499
	[Nullable(1)]
	private readonly Stat StatAddSpecBuff = Stat.Create("Add Spec Buff", "", "");

	// Token: 0x0400D0FC RID: 53500
	[Nullable(1)]
	private readonly Stat StatRemoveSpecBuff = Stat.Create("Remove Spec Buff", "", "");

	// Token: 0x0400D0FD RID: 53501
	[Nullable(1)]
	private readonly Stat StatRemoveSpecBuffTag = Stat.Create("Remove Spec Buff&Tag", "", "");

	// Token: 0x0400D0FE RID: 53502
	[Nullable(1)]
	private readonly Stat StatRemoveInSkillTag = Stat.Create("Remove InSkill Tag", "", "");

	// Token: 0x0400D0FF RID: 53503
	[Nullable(1)]
	private readonly Stat StatAddSpecEndBuff = Stat.Create("Add Spec EndBuff", "", "");

	// Token: 0x0400D100 RID: 53504
	[Nullable(1)]
	private readonly Stat StatRemoveSpecEndBuff = Stat.Create("Remove Spec EndBuff", "", "");

	// Token: 0x0400D101 RID: 53505
	public UGameplayAbility ActiveAbility;

	// Token: 0x0400D102 RID: 53506
	private UAsyncTaskPlayMontageAndWait ActiveMontageTask;

	// Token: 0x0400D103 RID: 53507
	private Action<bool> MontageCallback;

	// Token: 0x0400D104 RID: 53508
	public long? MontageContextId;

	// Token: 0x0400D105 RID: 53509
	public long? PreContextId;

	// Token: 0x0400D106 RID: 53510
	private long? CombatMessageIdInternal;

	// Token: 0x0400D107 RID: 53511
	public ISkillBattleContext BattleContext;

	// Token: 0x0400D108 RID: 53512
	public long? SkillBehaviorAnimNotifyMessageId;

	// Token: 0x0400D109 RID: 53513
	public int FightStateHandle;

	// Token: 0x0400D10A RID: 53514
	private int SkillIdInternal;

	// Token: 0x0400D10B RID: 53515
	private bool ActiveInternal;

	// Token: 0x0400D10C RID: 53516
	private bool IsSimulatedInternal;

	// Token: 0x0400D10D RID: 53517
	private SSkillInfo SkillInfoInternal;

	// Token: 0x0400D10E RID: 53518
	public GroupSkillCdInfo GroupSkillCdInfo;

	// Token: 0x0400D10F RID: 53519
	[Nullable(1)]
	private readonly List<int> SkillTagIdsInternal = new List<int>();

	// Token: 0x0400D110 RID: 53520
	private int VisionTagId;

	// Token: 0x0400D111 RID: 53521
	private UClass AbilityClassInternal;

	// Token: 0x0400D112 RID: 53522
	private FGameplayAbilitySpecHandle AbilityHandle;

	// Token: 0x0400D113 RID: 53523
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private UAnimMontage[] LoadedMontagesInternal;

	// Token: 0x0400D114 RID: 53524
	public const int MONTAGE_INVALID_INDEX = -1;

	// Token: 0x0400D115 RID: 53525
	public const int MONTAGE_DEFAULT_INDEX = 0;

	// Token: 0x0400D116 RID: 53526
	private const float MONTAGE_BLEND_TIME = 0.2f;

	// Token: 0x0400D117 RID: 53527
	[Nullable(1)]
	private const string BURST_LOCK_KEY = "Skill.BurstLock";

	// Token: 0x0400D118 RID: 53528
	public int CurrentMontageIndex = -1;

	// Token: 0x0400D119 RID: 53529
	public int NeedPlayMontageIndex = -1;

	// Token: 0x0400D11A RID: 53530
	[Nullable(1)]
	private readonly List<int> ActiveBuffHandles = new List<int>();

	// Token: 0x0400D11B RID: 53531
	[Nullable(1)]
	private readonly Dictionary<Skill.ESkillEffectType, List<Skill.ISkillEffect>> EffectsAttached = new Dictionary<Skill.ESkillEffectType, List<Skill.ISkillEffect>>();

	// Token: 0x0400D11C RID: 53532
	private TimerHandle BurstLockTimer;

	// Token: 0x0400D11D RID: 53533
	private int InterruptLevelInternal;

	// Token: 0x0400D11E RID: 53534
	public FVectorDouble? ExtraTargetLocation;

	// Token: 0x0400D11F RID: 53535
	private int SkillLevel;

	// Token: 0x0400D120 RID: 53536
	public EndSkillInfo EndSkillInfo;

	// Token: 0x0400D121 RID: 53537
	private BaseSkillComponent SkillComp;

	// Token: 0x0400D122 RID: 53538
	private CharacterBuffComponent BuffComp;

	// Token: 0x0400D123 RID: 53539
	private BaseTagComponent TagComp;

	// Token: 0x0400D124 RID: 53540
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D125 RID: 53541
	private CharacterMontageComponent MontageComp;

	// Token: 0x0400D126 RID: 53542
	private PawnTimeScaleComponent TimeScaleComp;

	// Token: 0x020093C4 RID: 37828
	[NullableContext(0)]
	public enum ESkillEffectType
	{
		// Token: 0x0403124E RID: 201294
		None,
		// Token: 0x0403124F RID: 201295
		UnDetach,
		// Token: 0x04031250 RID: 201296
		Detach,
		// Token: 0x04031251 RID: 201297
		DetachEnd,
		// Token: 0x04031252 RID: 201298
		DetachDestroy,
		// Token: 0x04031253 RID: 201299
		UnDetachEnd,
		// Token: 0x04031254 RID: 201300
		UnDetachDestroy
	}

	// Token: 0x020093C5 RID: 37829
	private interface ISkillEffect
	{
		// Token: 0x1700A8EF RID: 43247
		// (get) Token: 0x0604A1F5 RID: 303605
		// (set) Token: 0x0604A1F6 RID: 303606
		int EffectHandle { get; set; }

		// Token: 0x1700A8F0 RID: 43248
		// (get) Token: 0x0604A1F7 RID: 303607
		// (set) Token: 0x0604A1F8 RID: 303608
		FName BoneName { get; set; }

		// Token: 0x1700A8F1 RID: 43249
		// (get) Token: 0x0604A1F9 RID: 303609
		// (set) Token: 0x0604A1FA RID: 303610
		float WhenSkillEndEnableTime { get; set; }
	}

	// Token: 0x020093C6 RID: 37830
	[NullableContext(0)]
	private class SkillEffect : Skill.ISkillEffect
	{
		// Token: 0x1700A8F2 RID: 43250
		// (get) Token: 0x0604A1FB RID: 303611 RVA: 0x014164A3 File Offset: 0x014146A3
		// (set) Token: 0x0604A1FC RID: 303612 RVA: 0x014164AB File Offset: 0x014146AB
		public int EffectHandle { get; set; }

		// Token: 0x1700A8F3 RID: 43251
		// (get) Token: 0x0604A1FD RID: 303613 RVA: 0x014164B4 File Offset: 0x014146B4
		// (set) Token: 0x0604A1FE RID: 303614 RVA: 0x014164BC File Offset: 0x014146BC
		public FName BoneName { get; set; }

		// Token: 0x1700A8F4 RID: 43252
		// (get) Token: 0x0604A1FF RID: 303615 RVA: 0x014164C5 File Offset: 0x014146C5
		// (set) Token: 0x0604A200 RID: 303616 RVA: 0x014164CD File Offset: 0x014146CD
		public float WhenSkillEndEnableTime { get; set; }
	}
}
