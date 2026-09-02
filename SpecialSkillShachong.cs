using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003151 RID: 12625
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillShachong : SpecialSkillBase
{
	// Token: 0x0601A25C RID: 107100 RVA: 0x007ACC16 File Offset: 0x007AAE16
	[NullableContext(1)]
	public SpecialSkillShachong(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A25D RID: 107101 RVA: 0x007ACC20 File Offset: 0x007AAE20
	public override void OnStart()
	{
		FName? dynamicFName = FNameUtil.GetDynamicFName("Grid_Navigation");
		if (dynamicFName != null)
		{
			this.ActorStreamingSource = GameModeModel.CreateIndependentStreamingSource(new FName[]
			{
				dynamicFName.Value
			}, 10000f, EStreamingSourcePriority.Highest);
		}
		this.ActorComp = this.SpecialSkillComponent.Entity.GetComponent<CharacterActorComponent>();
		FName? dynamicFName2 = FNameUtil.GetDynamicFName("Root");
		AActor actorStreamingSource = this.ActorStreamingSource;
		if (actorStreamingSource != null && actorStreamingSource.IsValid() && this.ActorComp != null && dynamicFName2 != null)
		{
			this.ActorStreamingSource.D_K2_SetActorLocation(this.ActorComp.GetSocketLocation(dynamicFName2.Value), false, ref WorldGlobal.SweepHitResult, true);
		}
		this.AbilityComp = this.SpecialSkillComponent.Entity.GetComponent<CharacterAbilityComponent>();
		this.TagId = GameplayTagUtils.GetTagIdByName("怪物.ML1WeiZuoShenWangMd00601.功能标签.变招点");
		CharacterAbilityComponent abilityComp = this.AbilityComp;
		if (abilityComp == null)
		{
			return;
		}
		abilityComp.AddGameplayEventListener(this.TagId, new TGameplayEventCallback(this.OnEvent));
	}

	// Token: 0x0601A25E RID: 107102 RVA: 0x007ACD1C File Offset: 0x007AAF1C
	[NullableContext(1)]
	private void OnEvent(int tagId, FGameplayEventData payload)
	{
		if (this.ActorComp != null)
		{
			AActor actorStreamingSource = this.ActorStreamingSource;
			if (actorStreamingSource != null && actorStreamingSource.IsValid())
			{
				FName? dynamicFName = FNameUtil.GetDynamicFName("Root");
				if (dynamicFName == null)
				{
					return;
				}
				this.ActorStreamingSource.D_K2_SetActorLocation(this.ActorComp.GetSocketLocation(dynamicFName.Value), false, ref WorldGlobal.SweepHitResult, true);
				return;
			}
		}
	}

	// Token: 0x0601A25F RID: 107103 RVA: 0x007ACD84 File Offset: 0x007AAF84
	public override void OnEnd()
	{
		AActor actorStreamingSource = this.ActorStreamingSource;
		if (actorStreamingSource != null && actorStreamingSource.IsValid())
		{
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = this.ActorStreamingSource.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) as UWorldPartitionStreamingSourceComponent;
			if (uworldPartitionStreamingSourceComponent != null && uworldPartitionStreamingSourceComponent.IsValid())
			{
				uworldPartitionStreamingSourceComponent.DisableStreamingSource();
			}
			Singleton<ActorSystem>.Instance.Put("SpecialSkillShachong.OnEnd", this.ActorStreamingSource, null);
			this.ActorStreamingSource = null;
		}
		this.ActorComp = null;
		CharacterAbilityComponent abilityComp = this.AbilityComp;
		if (abilityComp != null)
		{
			abilityComp.RemoveGameplayEventListener(this.TagId, new TGameplayEventCallback(this.OnEvent));
		}
		this.AbilityComp = null;
	}

	// Token: 0x0400D205 RID: 53765
	private const float LOADINGRANGE = 10000f;

	// Token: 0x0400D206 RID: 53766
	private AActor ActorStreamingSource;

	// Token: 0x0400D207 RID: 53767
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D208 RID: 53768
	private CharacterAbilityComponent AbilityComp;

	// Token: 0x0400D209 RID: 53769
	private int TagId;
}
