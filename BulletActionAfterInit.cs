using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002D78 RID: 11640
public class BulletActionAfterInit : BulletActionBase
{
	// Token: 0x060177CD RID: 96205 RVA: 0x006823E7 File Offset: 0x006805E7
	public BulletActionAfterInit(EBulletAction type) : base(type)
	{
	}

	// Token: 0x060177CE RID: 96206 RVA: 0x006823F0 File Offset: 0x006805F0
	protected unsafe override void OnExecute()
	{
		BulletInfo bulletInfo = this.BulletInfo;
		BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
		Entity attacker = bulletInfo.Attacker;
		FGameplayTag sendGameplayEventTagToAttackerOnStart = bulletDataMain.Execution.SendGameplayEventTagToAttackerOnStart;
		if (!sendGameplayEventTagToAttackerOnStart.TagName.IsNone())
		{
			BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
			AActor aactor = (attackerActorComp != null) ? attackerActorComp.Owner : null;
			if (aactor != null && aactor.IsValid())
			{
				FGameplayEventData fgameplayEventData = new FGameplayEventData();
				fgameplayEventData.OptionalObject = bulletInfo.Actor;
				UAbilitySystemBlueprintLibrary.SendGameplayEventToActor(aactor, sendGameplayEventTagToAttackerOnStart, fgameplayEventData);
			}
		}
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget<BulletInfo>(attacker, EEventName.BulletCreate, bulletInfo);
		}
		bulletInfo.IsInit = true;
		if (!bulletInfo.BulletInitParams.FromRemote)
		{
			ActiveBulletHandle activeBulletHandle = ActiveBulletHandle.Create();
			activeBulletHandle.HandleId = bulletInfo.BulletEntityId;
			activeBulletHandle.PlayerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			ModelBase<BulletModel>.Instance.RegisterBullet(activeBulletHandle, bulletInfo.BulletEntityId);
			bool flag = bulletInfo.BulletInitParams.SyncType != EBulletSyncType.SyncCreate;
			CreatureDataComponent component = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>(bulletInfo.TargetId);
			long num = (component != null) ? component.GetCreatureDataId() : 0L;
			global::Vector actorLocation = bulletInfo.GetActorLocation();
			global::Rotator beginSpeedRotator = bulletInfo.MoveInfo.BeginSpeedRotator;
			CreateBulletPush createBulletPush = new CreateBulletPush();
			createBulletPush.Handle = activeBulletHandle;
			createBulletPush.BulletId = Singleton<MathUtils>.Instance.NumberToLong(long.Parse(bulletInfo.BulletRowName));
			createBulletPush.SkillId = (long)bulletInfo.BulletInitParams.SkillId;
			createBulletPush.Location = actorLocation.ToProtocolVector();
			createBulletPush.Rotation = beginSpeedRotator.ToProtocolRotator();
			createBulletPush.ParentHandle = ModelBase<BulletModel>.Instance.GetBulletHandleById(bulletInfo.BulletInitParams.ParentId);
			createBulletPush.SpawnEntityId = Singleton<MathUtils>.Instance.NumberToLong(ModelBase<CreatureModel>.Instance.GetCreatureDataId(bulletInfo.BulletInitParams.BaseTransformId));
			createBulletPush.SpawnVelocityEntityId = Singleton<MathUtils>.Instance.NumberToLong(ModelBase<CreatureModel>.Instance.GetCreatureDataId(bulletInfo.BulletInitParams.BaseVelocityId));
			createBulletPush.TargetId = Singleton<MathUtils>.Instance.NumberToLong(num);
			createBulletPush.IsLocal = flag;
			createBulletPush.RandomInitPosOffset = bulletInfo.RandomPosOffset.ToProtocolVector();
			createBulletPush.RandomInitSpeed = bulletInfo.RandomInitSpeedOffset.ToProtocolVector();
			this.CompressData(createBulletPush);
			bulletInfo.ContextIdSubmitted = true;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.CreateBulletPush, attacker, createBulletPush, bulletInfo.PreContextId, bulletInfo.ContextId, null);
			if (Singleton<BulletConstant>.Instance.OpenCreateLog)
			{
				if (!flag)
				{
					bool gasDebug = true;
					ELogAuthor author = ELogAuthor.HCW;
					Entity owner = attacker;
					string message = "创建同步子弹";
					BulletInfo bulletInfo2 = bulletInfo;
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", bulletInfo.BulletInitParams.SkillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Location", actorLocation);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Rotation", beginSpeedRotator);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TargetId", num);
					BulletLog.Debug(gasDebug, author, owner, message, bulletInfo2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				}
				else
				{
					BulletLog.Debug(true, ELogAuthor.HCW, attacker, "创建本地子弹", bulletInfo, default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}
		else
		{
			bulletInfo.ContextIdSubmitted = true;
			if (Singleton<BulletConstant>.Instance.OpenCreateLog)
			{
				BulletLog.Debug(true, ELogAuthor.HCW, attacker, "创建被同步子弹", bulletInfo, default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
		bulletInfo.ActionLogicComponent.OnAfterInit();
	}

	// Token: 0x060177CF RID: 96207 RVA: 0x00682757 File Offset: 0x00680957
	[NullableContext(1)]
	private void CompressData(CreateBulletPush data)
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			data.Location = null;
			data.Rotation = null;
			data.ParentHandle = null;
			data.SpawnVelocityEntityId = 0L;
			data.RandomInitPosOffset = null;
			data.RandomInitSpeed = null;
		}
	}
}
