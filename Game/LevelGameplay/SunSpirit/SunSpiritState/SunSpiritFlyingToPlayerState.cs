using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState
{
	// Token: 0x02006AAB RID: 27307
	[NullableContext(2)]
	[Nullable(0)]
	public class SunSpiritFlyingToPlayerState : SunSpiritFlyingEffectState
	{
		// Token: 0x06043867 RID: 276583 RVA: 0x011683C3 File Offset: 0x011665C3
		[NullableContext(1)]
		public SunSpiritFlyingToPlayerState(SunSpiritData sunSpiritData, float waitBeforeFlyDuration, float flyingDuration, int gearConfigId, int gearSocketIndex, [Nullable(2)] Action flyingEndCallback) : base(ESunSpiritStateType.FlyingToPlayer, sunSpiritData, waitBeforeFlyDuration, flyingDuration)
		{
			this.GearConfigId = gearConfigId;
			this.GearSocketIndex = gearSocketIndex;
			this.FlyingFinishCallback = flyingEndCallback;
			this.FlyingInterruptCallback = flyingEndCallback;
			this.FlyingTargetGetter = delegate(Vector outPos, Quat outRot)
			{
				if (!this.CheckFlyingTargetCacheNotExpired())
				{
					this.UpdateFlyingTargetCache();
				}
				if (this.FlyingTargetPosCache == null || this.FlyingTargetRotCache == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SunSpirit;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "日灵: SunSpiritFlyingToPlayerState.FlyingTargetGetter缓存的目标位置为空";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				outPos.DeepCopy(this.FlyingTargetPosCache);
				outRot.DeepCopy(this.FlyingTargetRotCache);
				return true;
			};
		}

		// Token: 0x06043868 RID: 276584 RVA: 0x01168404 File Offset: 0x01166604
		private bool CheckFlyingTargetCacheNotExpired()
		{
			if (this.FlyingTargetPosCache == null || this.FlyingTargetRotCache == null)
			{
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null)
			{
				return false;
			}
			if (this.FlyingTargetPosCache.IsZero() || characterActorComponent.ActorLocationProxy.IsZero())
			{
				return false;
			}
			if (Singleton<MathUtils>.Instance.VectorDistanceSquared(this.FlyingTargetPosCache, characterActorComponent.ActorLocationProxy) > (double)this.MaxOffsetSquaredForReQueryTargetLoc)
			{
				return false;
			}
			UKuroCrowdAiSubsystem crowdAiSubsystem = ControllerBase<CrowdAiController>.Instance.CrowdAiSubsystem;
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritConfig sunSpiritConfig = (instance != null) ? instance.GetSunSpiritConfig() : null;
			if (crowdAiSubsystem != null && sunSpiritConfig != null)
			{
				UKuroCrowdAiSubsystem ukuroCrowdAiSubsystem = crowdAiSubsystem;
				FVector fvector = this.FlyingTargetPosCache.ToUeVectorOld();
				if (ukuroCrowdAiSubsystem.QueryUsablePositionForBoid(fvector, 0f, sunSpiritConfig.AroundPlayerPosQueryBoidRadius, 1).IsZero())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06043869 RID: 276585 RVA: 0x011684C8 File Offset: 0x011666C8
		private unsafe void UpdateFlyingTargetCache()
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritConfig sunSpiritConfig = (instance != null) ? instance.GetSunSpiritConfig() : null;
			if (sunSpiritConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: SunSpiritFlyingToPlayerState.UpdateFlyingTargetCache 更新目标位置失败，配置获取失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
				instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.FlyingTargetPosCache = null;
				this.FlyingTargetRotCache = null;
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (characterActorComponent == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SunSpirit;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "日灵: SunSpiritFlyingToPlayerState.UpdateFlyingTargetCache 更新目标位置失败，找不到目标角色";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
				instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.FlyingTargetPosCache = null;
				this.FlyingTargetRotCache = null;
				return;
			}
			UKuroCrowdAiSubsystem crowdAiSubsystem = ControllerBase<CrowdAiController>.Instance.CrowdAiSubsystem;
			if (crowdAiSubsystem != null)
			{
				UKuroCrowdAiSubsystem ukuroCrowdAiSubsystem = crowdAiSubsystem;
				FVector fvector = characterActorComponent.ActorLocationProxy.ToUeVectorOld();
				FVector fvector2 = ukuroCrowdAiSubsystem.QueryUsablePositionForBoid(fvector, sunSpiritConfig.AroundPlayerPosQueryRadius, sunSpiritConfig.AroundPlayerPosQueryBoidRadius, sunSpiritConfig.AroundPlayerPosQueryMaxTryCount);
				if (!fvector2.IsZero())
				{
					if (this.FlyingTargetPosCache == null || this.FlyingTargetRotCache == null)
					{
						this.FlyingTargetPosCache = Vector.Create();
						this.FlyingTargetRotCache = Quat.Create(0f, 0f, 0f, 1f);
					}
					Vector flyingTargetPosCache = this.FlyingTargetPosCache;
					FVectorDouble fvectorDouble = fvector2;
					flyingTargetPosCache.DeepCopy(fvectorDouble);
					this.FlyingTargetRotCache.FromUeQuat(characterActorComponent.ActorQuatProxy);
					return;
				}
			}
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.SunSpirit;
			ELogAuthor author3 = ELogAuthor.ZYL;
			string message3 = "日灵: SunSpiritFlyingToPlayerState.UpdateFlyingTargetCache 查找角色附近的可用位置失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetLocation", characterActorComponent.ActorLocationProxy);
			instance4.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.FlyingTargetPosCache = null;
			this.FlyingTargetRotCache = null;
		}

		// Token: 0x0604386A RID: 276586 RVA: 0x011686AC File Offset: 0x011668AC
		protected override void OnSunSpiritFlyToTargetEnd(bool bKeepEffect = false, bool bIsInterrupt = false)
		{
			base.OnSunSpiritFlyToTargetEnd(bKeepEffect, bIsInterrupt);
			this.SunSpiritData.StopAllAndSetNextSunSpiritState(new SunSpiritOccupiedByPlayerState(this.SunSpiritData), false);
		}

		// Token: 0x0604386B RID: 276587 RVA: 0x011686D0 File Offset: 0x011668D0
		protected override bool OnEnter()
		{
			base.OnEnter();
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			SunSpiritConfig sunSpiritConfig = (instance != null) ? instance.GetSunSpiritConfig() : null;
			if (sunSpiritConfig == null)
			{
				return false;
			}
			this.MaxOffsetSquaredForReQueryTargetLoc = sunSpiritConfig.FlyFromGearToPlayerMaxOffsetForReQueryTargetLoc * sunSpiritConfig.FlyFromGearToPlayerMaxOffsetForReQueryTargetLoc;
			if (this.SunSpiritData.Transform == null || this.SunSpiritData.Transform.GetLocation().IsZero())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SunSpirit;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "日灵: SunSpiritFlyingToPlayerState.OnEnter 找不到已有位置，重设飞行起点";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
				instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Vector vector = Vector.Create();
				Quat quat = Quat.Create(0f, 0f, 0f, 1f);
				CreatureModel instance3 = ModelBase<CreatureModel>.Instance;
				object obj;
				if (instance3 == null)
				{
					obj = null;
				}
				else
				{
					EntityHandle entityByPbDataId = instance3.GetEntityByPbDataId(this.GearConfigId);
					if (entityByPbDataId == null)
					{
						obj = null;
					}
					else
					{
						WorldEntity entity = entityByPbDataId.Entity;
						obj = ((entity != null) ? entity.GetComponent<SceneItemSunSpiritGearComponent>() : null);
					}
				}
				object obj2 = obj;
				if (obj2 == null || !obj2.GetSunSpiritSocketLocAndRot(this.GearSocketIndex, vector, quat))
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.SunSpirit;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "日灵: SunSpiritFlyingToPlayerState.OnEnter 重设飞行起点位置失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("SpiritConfigId", this.SunSpiritData.ConfigId);
					instance4.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return false;
				}
				this.SunSpiritData.SetLocationAndRotation(vector, quat);
			}
			return true;
		}

		// Token: 0x04025BA0 RID: 154528
		private float MaxOffsetSquaredForReQueryTargetLoc;

		// Token: 0x04025BA1 RID: 154529
		public readonly int GearConfigId;

		// Token: 0x04025BA2 RID: 154530
		public readonly int GearSocketIndex;

		// Token: 0x04025BA3 RID: 154531
		private Vector FlyingTargetPosCache;

		// Token: 0x04025BA4 RID: 154532
		private Quat FlyingTargetRotCache;
	}
}
