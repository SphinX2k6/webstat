using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003163 RID: 12643
[NullableContext(2)]
[Nullable(0)]
public class GameplayAbilityVisionSummon : GameplayAbilityVisionBase
{
	// Token: 0x0601A356 RID: 107350 RVA: 0x007B36D5 File Offset: 0x007B18D5
	[NullableContext(1)]
	public GameplayAbilityVisionSummon(CharacterVisionComponent visionComponent) : base(visionComponent)
	{
	}

	// Token: 0x0601A357 RID: 107351 RVA: 0x007B36E0 File Offset: 0x007B18E0
	protected override void OnCreate()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.BulletDestroy, new Action<BulletInfo>(this.OnBulletDestroy));
		Singleton<EventSystem>.Instance.Add(EEventName.CharStopAllSkills, new Action<int, string>(this.OnStopSkills));
		Singleton<EventSystem>.Instance.Add(EEventName.CharStopGroup1Skill, new Action<int, string>(this.OnStopSkills));
	}

	// Token: 0x0601A358 RID: 107352 RVA: 0x007B3744 File Offset: 0x007B1944
	protected override void OnDestroy()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.BulletDestroy, new Action<BulletInfo>(this.OnBulletDestroy));
		Singleton<EventSystem>.Instance.Remove(EEventName.CharStopAllSkills, new Action<int, string>(this.OnStopSkills));
		Singleton<EventSystem>.Instance.Remove(EEventName.CharStopGroup1Skill, new Action<int, string>(this.OnStopSkills));
		this.EndAllTask();
	}

	// Token: 0x0601A359 RID: 107353 RVA: 0x007B37AC File Offset: 0x007B19AC
	protected override bool OnActivateAbility()
	{
		if (!this.PreSummon())
		{
			return false;
		}
		if (!this.IsAirSkill())
		{
			base.BuffComponent.AddBuff(1900000014L, new AddBuffParam
			{
				InstigatorId = base.BuffComponent.CreatureDataId,
				Reason = "幻象召唤时触发子弹、镜头和特效"
			});
		}
		long? contextId = null;
		CharacterSkillComponent component = base.Entity.GetComponent<CharacterSkillComponent>();
		if (component != null && component.Valid)
		{
			foreach (Skill skill in component.GetAllActivatedSkill())
			{
				SSkillInfo skillInfo = skill.SkillInfo;
				if (((skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null) == ESkillGenre.战斗幻象技9)
				{
					contextId = skill.CombatMessageId;
					break;
				}
			}
		}
		for (int i = 0; i < this.VisionData.葫芦轨迹子弹列表.Num(); i++)
		{
			string bulletRowName = this.VisionData.葫芦轨迹子弹列表.Get(i).ToString();
			BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(base.Entity, bulletRowName, new FTransformDouble?(base.ActorComponent.ActorTransform), new BulletController.BulletCreateParams(), contextId, EBulletCreateSource.Others);
			if (bulletEntity != null)
			{
				this.SummonBulletId = bulletEntity.Id;
				break;
			}
		}
		return true;
	}

	// Token: 0x0601A35A RID: 107354 RVA: 0x007B3924 File Offset: 0x007B1B24
	private bool PreSummon()
	{
		this.VisionEntity = PhantomUtil.GetSummonedEntity(this.VisionComponent.Entity, ESummonType.ConcomitantVision, 1);
		EntityHandle visionEntity = this.VisionEntity;
		if (visionEntity == null || !visionEntity.Valid || !this.VisionEntity.IsInit || this.VisionEntity.Entity == null)
		{
			return false;
		}
		if (this.VisionEntity.Entity.Active)
		{
			return false;
		}
		this.VisionData = PhantomUtil.GetVisionData(this.VisionComponent.GetVisionId(null));
		if (this.VisionData == null)
		{
			return false;
		}
		this.VisionActorComponent = this.VisionEntity.Entity.GetComponent<CharacterActorComponent>();
		this.VisionSkillComponent = this.VisionEntity.Entity.GetComponent<CharacterSkillComponent>();
		this.VisionGameplayTagComponent = this.VisionEntity.Entity.GetComponent<BaseTagComponent>();
		this.VisionBuffComponent = this.VisionEntity.Entity.GetComponent<CharacterBuffComponent>();
		this.VisionCueComponent = this.VisionEntity.Entity.GetComponent<CharacterGameplayCueComponent>();
		return true;
	}

	// Token: 0x0601A35B RID: 107355 RVA: 0x007B3A2E File Offset: 0x007B1C2E
	private bool IsAirSkill()
	{
		return this.VisionData.空中能否释放 && base.GameplayTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]);
	}

	// Token: 0x0601A35C RID: 107356 RVA: 0x007B3A59 File Offset: 0x007B1C59
	[NullableContext(1)]
	private void OnBulletDestroy(BulletInfo bulletInfo)
	{
		if (bulletInfo.BulletEntityId == this.SummonBulletId)
		{
			this.SummonBegin(bulletInfo.MoveInfo.LastFramePosition.ToUeVector(false));
		}
	}

	// Token: 0x0601A35D RID: 107357 RVA: 0x007B3A80 File Offset: 0x007B1C80
	private void SummonBegin(FVectorDouble location)
	{
		Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		base.MoveComponent.GravityUp.Multiply((double)this.VisionActorComponent.ScaledHalfHeight, commonTempVector);
		BaseActorComponent visionActorComponent = this.VisionActorComponent;
		FVectorDouble fvectorDouble = commonTempVector.ToUeVector(false);
		visionActorComponent.SetActorLocationAndRotation(location + fvectorDouble, base.ActorComponent.ActorRotation, "召唤幻象生成位置", false, null);
		this.IsActivating = true;
		this.SetVisionEnable(true);
		base.GameplayTagComponent.AddTag(new int?(GameplayAbilityVisionMisc.summonTag));
		if (this.WaitSummonTagRemoveTask == null)
		{
			this.WaitSummonTagRemoveTask = base.GameplayTagComponent.ListenForTagAddOrRemove(new int?(GameplayAbilityVisionMisc.summonTag), delegate(int tagId, bool tagExist)
			{
				if (!tagExist)
				{
					Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.HXY, "召唤幻象正常结束", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.SummonEnd();
				}
			}, null);
		}
		this.VisionGameplayTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["幻象.Common.现身中"]));
		this.VisionBuffComponent.AddBuff(1900000015L, new AddBuffParam
		{
			InstigatorId = this.VisionBuffComponent.CreatureDataId,
			Reason = "召唤系幻象的出生特效"
		});
		this.VisionSkillComponent.SetSkillAcceptInput(true);
		int 技能ID = this.VisionData.技能ID;
		if (技能ID > 0)
		{
			BaseSkillComponent visionSkillComponent = this.VisionSkillComponent;
			int skillId = 技能ID;
			SkillParam skillParam = new SkillParam();
			EntityHandle skillTarget = base.SkillComponent.SkillTarget;
			skillParam.Target = ((skillTarget != null) ? skillTarget.Entity : null);
			skillParam.SocketName = base.SkillComponent.SkillTargetSocket;
			skillParam.Reason = "GameplayAbilityVisionSummon.BeginSkill";
			visionSkillComponent.BeginSkill(skillId, skillParam);
		}
		ControllerBase<RoleAudioController>.Instance.PlayRoleAudio(base.Entity, ERoleAudioType.VisionSummon, null);
	}

	// Token: 0x0601A35E RID: 107358 RVA: 0x007B3C0F File Offset: 0x007B1E0F
	private void SummonEnd()
	{
		this.EndAllTask();
		this.PlayEndEffect();
	}

	// Token: 0x0601A35F RID: 107359 RVA: 0x007B3C1D File Offset: 0x007B1E1D
	private void EndAllTask()
	{
		if (this.WaitSummonTagRemoveTask != null)
		{
			this.WaitSummonTagRemoveTask.EndTask();
			this.WaitSummonTagRemoveTask = null;
		}
	}

	// Token: 0x0601A360 RID: 107360 RVA: 0x007B3C3C File Offset: 0x007B1E3C
	private void PlayEndEffect()
	{
		TimerHandle capturedVisionHiddenTimer = null;
		CharacterGameplayCueComponent visionCueComponent = this.VisionCueComponent;
		if (visionCueComponent != null)
		{
			visionCueComponent.AddCue(19000000162L, new GameplayCueParam?(new GameplayCueParam
			{
				Sync = new bool?(true),
				Instant = true
			}));
		}
		this.CueHandle = this.VisionCueComponent.AddCue(19000000181L, new GameplayCueParam?(new GameplayCueParam
		{
			EndCallback = delegate()
			{
				if (capturedVisionHiddenTimer != null && TimerSystem.Instance.Has(capturedVisionHiddenTimer))
				{
					TimerSystem.Instance.Remove(capturedVisionHiddenTimer);
					capturedVisionHiddenTimer = null;
					this.VisionDisable();
				}
			},
			Sync = new bool?(true)
		}));
		capturedVisionHiddenTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.HXY, "幻象消失材质没有正常结束，被保底", default(ReadOnlySpan<ValueTuple<string, object>>));
			capturedVisionHiddenTimer = null;
			this.VisionDisable();
		}, 1000f, null, null, true, 1f);
	}

	// Token: 0x0601A361 RID: 107361 RVA: 0x007B3D0C File Offset: 0x007B1F0C
	private void VisionDisable()
	{
		EntityHandle visionEntity = this.VisionEntity;
		if (visionEntity != null && visionEntity.Valid)
		{
			ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(this.VisionEntity.Entity, "210000004", null, null, null, EBulletCreateSource.Others);
			this.IsActivating = false;
			this.SetVisionEnable(false);
			CharacterGameplayCueComponent visionCueComponent = this.VisionCueComponent;
			if (visionCueComponent != null)
			{
				visionCueComponent.RemoveCueByHandle((long)this.CueHandle);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.EndVisionSkill, this.VisionComponent.GetVisionId(null));
	}

	// Token: 0x0601A362 RID: 107362 RVA: 0x007B3DA8 File Offset: 0x007B1FA8
	[NullableContext(1)]
	private void OnStopSkills(int entityId, string reason)
	{
		if (this.IsActivating)
		{
			EntityHandle visionEntity = this.VisionEntity;
			if (visionEntity != null && visionEntity.Valid && entityId == this.VisionEntity.Id)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.HXY;
				string message = "技能被全部打断，结束召唤幻象技能";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.SummonEnd();
				return;
			}
		}
	}

	// Token: 0x0601A363 RID: 107363 RVA: 0x007B3E10 File Offset: 0x007B2010
	protected void SetVisionEnable(bool enable)
	{
		ControllerBase<CreatureController>.Instance.SetEntityEnable(this.VisionEntity.Entity, enable, "GameplayAbilityVisionSummon.SetVisionEnable", true);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomEnableStateChange, enable);
	}

	// Token: 0x0400D2CA RID: 53962
	private EntityHandle VisionEntity;

	// Token: 0x0400D2CB RID: 53963
	private SVisionData VisionData;

	// Token: 0x0400D2CC RID: 53964
	private int SummonBulletId;

	// Token: 0x0400D2CD RID: 53965
	private CharacterActorComponent VisionActorComponent;

	// Token: 0x0400D2CE RID: 53966
	private CharacterSkillComponent VisionSkillComponent;

	// Token: 0x0400D2CF RID: 53967
	private BaseTagComponent VisionGameplayTagComponent;

	// Token: 0x0400D2D0 RID: 53968
	private CharacterBuffComponent VisionBuffComponent;

	// Token: 0x0400D2D1 RID: 53969
	private CharacterGameplayCueComponent VisionCueComponent;

	// Token: 0x0400D2D2 RID: 53970
	private ITagTask WaitSummonTagRemoveTask;

	// Token: 0x0400D2D3 RID: 53971
	private int CueHandle;

	// Token: 0x0400D2D4 RID: 53972
	private bool IsActivating;
}
