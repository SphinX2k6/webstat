using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x02004899 RID: 18585
	[NullableContext(1)]
	[Nullable(0)]
	public class BulletCasterStationary : BulletCasterCommon
	{
		// Token: 0x060306F1 RID: 198385 RVA: 0x00BDF2B7 File Offset: 0x00BDD4B7
		public BulletCasterStationary(BulletCasterInitParam bulletCasterInitParam) : base(bulletCasterInitParam)
		{
		}

		// Token: 0x060306F2 RID: 198386 RVA: 0x00BDF2C0 File Offset: 0x00BDD4C0
		protected override void OnStart()
		{
		}

		// Token: 0x060306F3 RID: 198387 RVA: 0x00BDF2C4 File Offset: 0x00BDD4C4
		protected unsafe override void SetEffectParam(int effectHandleId)
		{
			EffectParameterNiagara effectParameterNiagara = new EffectParameterNiagara();
			int num = 1;
			List<ValueTuple<FName, float>> list = new List<ValueTuple<FName, float>>(num);
			CollectionsMarshal.SetCount<ValueTuple<FName, float>>(list, num);
			Span<ValueTuple<FName, float>> span = CollectionsMarshal.AsSpan<ValueTuple<FName, float>>(list);
			int index = 0;
			*span[index] = new ValueTuple<FName, float>(FNameUtil.GetDynamicFName("radius").Value, (float)this.CasterConfig.WarningWidth);
			effectParameterNiagara.UserParameterFloat = list;
			EffectParameterNiagara parameter = effectParameterNiagara;
			Singleton<EffectSystem>.Instance.SetEffectParameterNiagara(effectHandleId, parameter);
		}

		// Token: 0x060306F4 RID: 198388 RVA: 0x00BDF334 File Offset: 0x00BDD534
		protected override void StartImmediately()
		{
			int warningEffectHandle = base.PlayWarningEffect();
			if (Singleton<EffectSystem>.Instance.IsValid(warningEffectHandle))
			{
				this.WarningEffectHandles.Add(warningEffectHandle);
			}
			TimerHandle waitWarningTimer = null;
			waitWarningTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(warningEffectHandle))
				{
					Singleton<EffectSystem>.Instance.StopEffectById(warningEffectHandle, "[BulletCaster] WarnEnd", false, null);
				}
				this.WarningEffectHandles.Remove(warningEffectHandle);
				this.BulletWaitWarningTimers.Remove(waitWarningTimer);
				this.FireBullet();
			}, (float)this.CasterConfig.WarningTime, null, null, true, 1f);
			if (waitWarningTimer != null)
			{
				this.BulletWaitWarningTimers.Add(waitWarningTimer);
			}
			this.SetTimeDilationRespectOwnerEntity();
		}

		// Token: 0x060306F5 RID: 198389 RVA: 0x00BDF3D8 File Offset: 0x00BDD5D8
		private unsafe int FireBullet()
		{
			FTransformDouble actorTransform = this.OwnerEntity.GetComponent<BaseActorComponent>().ActorTransform;
			FTransformDouble ftransformDouble = this.CasterRelTransform.ToUeTransform();
			FTransformDouble value = ftransformDouble * actorTransform;
			EntityHandle sceneBulletOwner = ControllerBase<BulletController>.Instance.GetSceneBulletOwner();
			if (sceneBulletOwner == null || !sceneBulletOwner.IsInit)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "Bullet生成错误, 找场景子弹owner还未初始化";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OwnerEntityId", this.OwnerEntity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("sceneBulletOwner", sceneBulletOwner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MovementType", EBatchBulletMovementType.Stationary);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return -1;
			}
			BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(sceneBulletOwner.Entity, this.CasterConfig.BulletType.ToString(), new FTransformDouble?(value), new BulletController.BulletCreateParams
			{
				InitTargetLocation = new FVectorDouble?(value.GetLocation())
			}, new long?(this.BulletContextId), EBulletCreateSource.Others);
			if (bulletEntity == null || !bulletEntity.Valid)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.XDW;
				string message2 = "Bullet生成错误";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("OwnerEntityId", this.OwnerEntity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("BulletContextId", this.BulletContextId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("MovementType", EBatchBulletMovementType.Stationary);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return -1;
			}
			int bulletId = bulletEntity.Id;
			ControllerBase<BulletController>.Instance.SetBulletSpeedRatio(bulletId, 0f);
			TimerHandle timerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.DestroyBulletTimers.Remove(bulletId);
				ControllerBase<BulletController>.Instance.DestroyBullet(bulletId, false, EBulletDestroyReason.Normal, false);
			}, (float)this.CasterConfig.FlyTime, null, null, true, 1f);
			if (timerHandle != null)
			{
				this.DestroyBulletTimers[bulletId] = timerHandle;
			}
			return bulletId;
		}

		// Token: 0x0401BD0D RID: 113933
		private const string WARNING_EFFECT_USER_PARAM_NAME = "radius";
	}
}
