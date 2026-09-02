using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003148 RID: 12616
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillJiabeilina : SpecialSkillBase
{
	// Token: 0x0601A1FA RID: 107002 RVA: 0x007AA6B4 File Offset: 0x007A88B4
	[NullableContext(1)]
	public SpecialSkillJiabeilina(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A1FB RID: 107003 RVA: 0x007AA6C0 File Offset: 0x007A88C0
	public override void OnStart()
	{
		if (!SpecialSkillJiabeilina.IsOptimizeEnableInitialized)
		{
			SpecialSkillJiabeilina.IsOptimizeEnable = true;
			SpecialSkillJiabeilina.IsOptimizeEnableInitialized = true;
		}
		Entity entity = this.SpecialSkillComponent.Entity;
		this.ActorComp = entity.GetComponent<CharacterActorComponent>();
		this.SkillComp = entity.GetComponent<BaseSkillComponent>();
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsRoleAndCtrlByMe && SpecialSkillJiabeilina.IsOptimizeEnable)
		{
			this.SkillOtherCasesMap = new Dictionary<long, HashSet<string>>();
			this.InitNoUpdateMeshes();
			Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnCharBeforeSkill));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
		}
	}

	// Token: 0x0601A1FC RID: 107004 RVA: 0x007AA764 File Offset: 0x007A8964
	public override void OnEnd()
	{
		HashSet<USkeletalMeshComponent> noUpdateMeshes = this.NoUpdateMeshes;
		if (noUpdateMeshes != null)
		{
			noUpdateMeshes.Clear();
		}
		Entity entity = this.SpecialSkillComponent.Entity;
		if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnCharBeforeSkill)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(entity, EEventName.CharBeforeSkillWithTarget, new Action<int, bool>(this.OnCharBeforeSkill));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget<int, int>(entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int>(entity, EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
		}
	}

	// Token: 0x0601A1FD RID: 107005 RVA: 0x007AA7F8 File Offset: 0x007A89F8
	public override void OnActivate()
	{
		Entity entity = this.SpecialSkillComponent.Entity;
		this.AnimComp = entity.GetComponent<CharacterAnimationComponent>();
		if (this.NoUpdateMeshes != null)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp == null)
			{
				return;
			}
			animComp.SetNoUpdateMeshes(this.NoUpdateMeshes);
		}
	}

	// Token: 0x0601A1FE RID: 107006 RVA: 0x007AA83C File Offset: 0x007A8A3C
	private void InitNoUpdateMeshes()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (((actorComp != null) ? actorComp.Actor : null) == null)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>
		{
			"OtherCase1",
			"OtherCase2",
			"OtherCase3",
			"OtherCase4",
			"OtherCase5",
			"OtherCase6",
			"OtherCase9",
			"OtherCase10"
		};
		if (this.NoUpdateMeshes == null)
		{
			this.NoUpdateMeshes = new HashSet<USkeletalMeshComponent>();
		}
		TArray<UActorComponent> tarray = this.ActorComp.Actor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		for (int i = 0; i < tarray.Num(); i++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
			if (uskeletalMeshComponent != null)
			{
				string name = uskeletalMeshComponent.GetName();
				if (hashSet.Contains(name) && uskeletalMeshComponent.AnimClass != null)
				{
					this.NoUpdateMeshes.Add(uskeletalMeshComponent);
				}
			}
		}
	}

	// Token: 0x0601A1FF RID: 107007 RVA: 0x007AA948 File Offset: 0x007A8B48
	[NullableContext(1)]
	private void RefreshNoUpdateMeshes(HashSet<string> otherCases, bool isAdd)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (((actorComp != null) ? actorComp.Actor : null) == null || this.NoUpdateMeshes == null)
		{
			return;
		}
		TArray<UActorComponent> tarray = this.ActorComp.Actor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
		bool flag = false;
		for (int i = 0; i < tarray.Num(); i++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
			if (uskeletalMeshComponent != null)
			{
				string name = uskeletalMeshComponent.GetName();
				if (otherCases.Contains(name))
				{
					if (isAdd && this.NoUpdateMeshes.Add(uskeletalMeshComponent))
					{
						flag = true;
					}
					else if (!isAdd && this.NoUpdateMeshes.Contains(uskeletalMeshComponent))
					{
						this.NoUpdateMeshes.Remove(uskeletalMeshComponent);
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp == null)
			{
				return;
			}
			animComp.SetNoUpdateMeshes(this.NoUpdateMeshes);
		}
	}

	// Token: 0x0601A200 RID: 107008 RVA: 0x007AAA10 File Offset: 0x007A8C10
	private void OnCharBeforeSkill(int skillId, bool isAutonomousProxy)
	{
		if (this.SkillOtherCasesMap == null)
		{
			this.SkillOtherCasesMap = new Dictionary<long, HashSet<string>>();
		}
		HashSet<string> hashSet;
		if (this.SkillOtherCasesMap.ContainsKey((long)skillId))
		{
			hashSet = this.SkillOtherCasesMap[(long)skillId];
		}
		else
		{
			BaseSkillComponent skillComp = this.SkillComp;
			UAnimMontage[] array;
			if (skillComp == null)
			{
				array = null;
			}
			else
			{
				Skill skill = skillComp.GetSkill(skillId);
				array = ((skill != null) ? skill.GetLoadedMontages() : null);
			}
			UAnimMontage[] array2 = array;
			if (array2 == null)
			{
				this.SkillOtherCasesMap[(long)skillId] = null;
				return;
			}
			hashSet = new HashSet<string>();
			foreach (UAnimMontage uanimMontage in array2)
			{
				if (uanimMontage != null)
				{
					TArray<FAnimNotifyEvent> notifies = uanimMontage.Notifies;
					int num = notifies.Num();
					for (int j = 0; j < num; j++)
					{
						FAnimNotifyEvent fanimNotifyEvent = notifies.Get(j);
						UAnimNotifyState notifyStateClass = fanimNotifyEvent.NotifyStateClass;
						if (notifyStateClass != null && notifyStateClass.IsValid())
						{
							TsAnimNotifyStateHideMesh tsAnimNotifyStateHideMesh = fanimNotifyEvent.NotifyStateClass as TsAnimNotifyStateHideMesh;
							if (tsAnimNotifyStateHideMesh != null)
							{
								string childMeshName = tsAnimNotifyStateHideMesh.ChildMeshName;
								if (!string.IsNullOrEmpty(childMeshName))
								{
									hashSet.Add(childMeshName);
								}
							}
						}
					}
				}
			}
			if (hashSet.Count <= 0)
			{
				this.SkillOtherCasesMap[(long)skillId] = null;
				return;
			}
			this.SkillOtherCasesMap[(long)skillId] = hashSet;
		}
		if (hashSet != null && hashSet.Count > 0)
		{
			this.RefreshNoUpdateMeshes(hashSet, false);
		}
	}

	// Token: 0x0601A201 RID: 107009 RVA: 0x007AAB54 File Offset: 0x007A8D54
	private void OnSkillEnd(int entityId, int skillId)
	{
		Dictionary<long, HashSet<string>> skillOtherCasesMap = this.SkillOtherCasesMap;
		HashSet<string> hashSet = (skillOtherCasesMap != null) ? skillOtherCasesMap.GetValueOrDefault((long)skillId) : null;
		if (hashSet != null && hashSet.Count > 0)
		{
			this.RefreshNoUpdateMeshes(hashSet, true);
		}
	}

	// Token: 0x0601A202 RID: 107010 RVA: 0x007AAB8A File Offset: 0x007A8D8A
	public new static void SetOptimizeEnable(bool enable)
	{
		SpecialSkillJiabeilina.IsOptimizeEnableInitialized = true;
		SpecialSkillJiabeilina.IsOptimizeEnable = enable;
	}

	// Token: 0x0400D1B3 RID: 53683
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D1B4 RID: 53684
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400D1B5 RID: 53685
	private BaseSkillComponent SkillComp;

	// Token: 0x0400D1B6 RID: 53686
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<USkeletalMeshComponent> NoUpdateMeshes;

	// Token: 0x0400D1B7 RID: 53687
	[Nullable(new byte[]
	{
		2,
		2,
		1
	})]
	private Dictionary<long, HashSet<string>> SkillOtherCasesMap;

	// Token: 0x0400D1B8 RID: 53688
	[StaticVariableRuleIgnore]
	private static bool IsOptimizeEnable;

	// Token: 0x0400D1B9 RID: 53689
	[StaticVariableRuleIgnore]
	private static bool IsOptimizeEnableInitialized;
}
