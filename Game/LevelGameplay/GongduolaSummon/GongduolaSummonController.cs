using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.SummonGongduola;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.GongduolaSummon
{
	// Token: 0x02006E81 RID: 28289
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class GongduolaSummonController : ControllerBase<GongduolaSummonController>
	{
		// Token: 0x060449C1 RID: 281025 RVA: 0x011D6404 File Offset: 0x011D4604
		[NullableContext(1)]
		public void PlaySummonAnim(Entity entity)
		{
			ModelBase<GongduolaSummonModel>.Instance.SummonedActorComp = entity.GetComponent<BaseActorComponent>();
			TTimerAction <>9__1;
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(ModelBase<GongduolaSummonModel>.Instance.SummonAmPath, delegate([Nullable(2)] UAnimMontage am, string _)
			{
				if (am == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Item;
					ELogAuthor author = ELogAuthor.CH;
					string message = "[GongduolaSummonController.PlaySummonAnim] 加载召唤动画失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", ModelBase<GongduolaSummonModel>.Instance.SummonAmPath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.StartLookAtGongduola();
				this.CacheSummonAm = am;
				this.CacheVehicleAnimationComponent = entity.GetComponent<VehicleAnimationComponent>();
				if (this.CacheVehicleAnimationComponent == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到VehicleAnimationComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheVehicleMoveComponent = entity.GetComponent<VehicleMoveComponent>();
				if (this.CacheVehicleMoveComponent == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到VehicleMoveComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheUeSkeletalTickManagerComp = entity.GetComponent<UeSkeletalTickManageComponent>();
				if (this.CacheUeSkeletalTickManagerComp == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到UeSkeletalTickManageComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheVehicleTagComp = entity.GetComponent<BaseTagComponent>();
				if (this.CacheVehicleTagComp == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到BaseTagComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheVehicleAnimationComponent.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.SpecialAction, false);
				this.CacheUeSkeletalTickManagerComp.StartForceDisableAnimDelay(EForceDisableAnimDelayReason.GongduolaSummon);
				this.CacheVehicleAnimationComponent.Play(this.CacheSummonAm, new Action<UAnimMontage, bool>(this.OnSummonAnimEnd));
				Singleton<Log>.Instance.Info(ELogModule.SummonGongduola, ELogAuthor.CH, "[CHTest] PlaySummonAnim", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (!this.CacheVehicleTagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.贡多拉.逻辑.禁止交互"]))
				{
					this.CacheVehicleTagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.贡多拉.逻辑.禁止交互"]));
				}
				TimerSystemInstance instance2 = TimerSystem.Instance;
				TTimerAction action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(float _)
					{
						ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, true, "GongduolaSummonController.PlaySummonAnim", true);
						this.CacheVehicleMoveComponent.IsSummoningPerform = true;
						VehicleMoveComponent cacheVehicleMoveComponent = this.CacheVehicleMoveComponent;
						if (cacheVehicleMoveComponent == null)
						{
							return;
						}
						cacheVehicleMoveComponent.EnableUeMovementTick("GongduolaSummonController.PlaySummonAnim");
					});
				}
				instance2.Delay(action, 100f, null, null, true, 1f);
			}, 100, "js_undefined");
		}

		// Token: 0x060449C2 RID: 281026 RVA: 0x011D6464 File Offset: 0x011D4664
		[NullableContext(1)]
		public void PlayCancelSummonAnim(Entity entity, Vector newLoc, Rotator newRot, Vector newGravityDir)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(ModelBase<GongduolaSummonModel>.Instance.CancelSummonAmPath, delegate([Nullable(2)] UAnimMontage am, string _)
			{
				if (am == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Item;
					ELogAuthor author = ELogAuthor.CH;
					string message = "[GongduolaSummonController.PlaySummonAnim] 加载召唤动画失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", ModelBase<GongduolaSummonModel>.Instance.SummonAmPath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.CacheCancelSummonAm = am;
				ModelBase<GongduolaSummonModel>.Instance.SummonLocation = newLoc;
				ModelBase<GongduolaSummonModel>.Instance.SummonRotation = newRot;
				ModelBase<GongduolaSummonModel>.Instance.SummonGravityDir = newGravityDir;
				this.CacheVehicleAnimationComponent = entity.GetComponent<VehicleAnimationComponent>();
				if (this.CacheVehicleAnimationComponent == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到VehicleAnimationComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheVehicleMoveComponent = entity.GetComponent<VehicleMoveComponent>();
				if (this.CacheVehicleMoveComponent == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到VehicleMoveComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheActorComponent = entity.GetComponent<BaseActorComponent>();
				if (this.CacheActorComponent == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到BaseActorComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheUeSkeletalTickManagerComp = entity.GetComponent<UeSkeletalTickManageComponent>();
				if (this.CacheUeSkeletalTickManagerComp == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到UeSkeletalTickManageComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheVehicleTagComp = entity.GetComponent<BaseTagComponent>();
				if (this.CacheVehicleTagComp == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到BaseTagComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.CacheVehicleMoveComponent.IsSummoningPerform = true;
				this.CacheUeSkeletalTickManagerComp.StartForceDisableAnimDelay(EForceDisableAnimDelayReason.GongduolaSummon);
				this.CacheVehicleAnimationComponent.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.SpecialAction, false);
				VehicleMoveComponent cacheVehicleMoveComponent = this.CacheVehicleMoveComponent;
				if (cacheVehicleMoveComponent != null)
				{
					cacheVehicleMoveComponent.EnableUeMovementTick("GongduolaSummonController.PlaySummonAnim");
				}
				this.CacheVehicleAnimationComponent.Play(this.CacheCancelSummonAm, new Action<UAnimMontage, bool>(this.OnCancelSummonAnimEnd));
				if (!this.CacheVehicleTagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.贡多拉.逻辑.禁止交互"]))
				{
					this.CacheVehicleTagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.贡多拉.逻辑.禁止交互"]));
				}
				Singleton<Log>.Instance.Info(ELogModule.SummonGongduola, ELogAuthor.CH, "[CHTest] PlayCancelSummonAnim", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, 100, "js_undefined");
		}

		// Token: 0x060449C3 RID: 281027 RVA: 0x011D64C4 File Offset: 0x011D46C4
		[NullableContext(1)]
		public void StopCancelSummonAnim(Entity entity)
		{
			VehicleAnimationComponent component = entity.GetComponent<VehicleAnimationComponent>();
			if (component == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Item, ELogAuthor.CH, "[GongduolaSummonController.PlaySummonAnim] 未找到VehicleAnimationComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			component.StopMontage(0f);
			component.StopModelBuffer();
		}

		// Token: 0x060449C4 RID: 281028 RVA: 0x011D650C File Offset: 0x011D470C
		private unsafe void OnSummonAnimEnd(UAnimMontage montage, bool interrupted)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[ChTest]OnSummonAnimEnd";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Montage", montage);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("interrupted", interrupted);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (montage != this.CacheSummonAm)
			{
				return;
			}
			this.CacheVehicleAnimationComponent.RemoveOnMontageEnded(new Action<UAnimMontage, bool>(this.OnSummonAnimEnd));
			BaseTagComponent cacheVehicleTagComp = this.CacheVehicleTagComp;
			if (cacheVehicleTagComp != null && cacheVehicleTagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.贡多拉.逻辑.禁止交互"]))
			{
				BaseTagComponent cacheVehicleTagComp2 = this.CacheVehicleTagComp;
				if (cacheVehicleTagComp2 != null)
				{
					cacheVehicleTagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.贡多拉.逻辑.禁止交互"]));
				}
			}
			this.OnAnimEnd();
		}

		// Token: 0x060449C5 RID: 281029 RVA: 0x011D65E0 File Offset: 0x011D47E0
		private unsafe void OnCancelSummonAnimEnd(UAnimMontage montage, bool interrupted)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[ChTest]OnCancelSummonAnimEnd";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Montage", montage);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("interrupted", interrupted);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (montage != this.CacheCancelSummonAm)
			{
				return;
			}
			this.CacheVehicleAnimationComponent.RemoveOnMontageEnded(new Action<UAnimMontage, bool>(this.OnCancelSummonAnimEnd));
			this.OnAnimEnd();
		}

		// Token: 0x060449C6 RID: 281030 RVA: 0x011D666B File Offset: 0x011D486B
		private void OnAnimEnd()
		{
			this.CacheVehicleMoveComponent.IsSummoningPerform = false;
			UeSkeletalTickManageComponent cacheUeSkeletalTickManagerComp = this.CacheUeSkeletalTickManagerComp;
			if (cacheUeSkeletalTickManagerComp != null)
			{
				cacheUeSkeletalTickManagerComp.CancelForceDisableAnimDelay(EForceDisableAnimDelayReason.GongduolaSummon);
			}
			VehicleAnimationComponent cacheVehicleAnimationComponent = this.CacheVehicleAnimationComponent;
			if (cacheVehicleAnimationComponent == null)
			{
				return;
			}
			cacheVehicleAnimationComponent.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.SpecialAction);
		}

		// Token: 0x060449C7 RID: 281031 RVA: 0x011D669C File Offset: 0x011D489C
		private void StartLookAtGongduola()
		{
			BP_SummonGongduolaConfig_C config = ModelBase<GongduolaSummonModel>.Instance.SummonConfig;
			if (config == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SummonGongduola, ELogAuthor.CH, "[GongduolaSummonController.StartLookAtGongduola] 未找到召唤配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			BaseActorComponent summonedActorComp = ModelBase<GongduolaSummonModel>.Instance.SummonedActorComp;
			if (summonedActorComp == null || !summonedActorComp.Valid)
			{
				Singleton<Log>.Instance.Error(ELogModule.SummonGongduola, ELogAuthor.CH, "[GongduolaSummonController.StartLookAtGongduola] 未找到GongduolaActorComp", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (config.BanInput)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.DisableInput = true;
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, ModelBase<GongduolaSummonModel>.Instance.BanInputReason);
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				Singleton<Log>.Instance.Info(ELogModule.SummonGongduola, ELogAuthor.CH, "[StartLookAtGongduola] StartLookAtGongduola BanInput", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			Vector vector = Vector.Create(summonedActorComp.ActorLocationProxy);
			vector.Set(vector.X, vector.Y, vector.Z + (double)config.OffsetZ);
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ApplyCameraGuide(vector, config.FadeInTime, config.StayTime, config.FadeOutTime, config.LockCamera, null, null, false, false, 0f, false, null, false);
			float num = config.FadeInTime + config.StayTime + config.FadeOutTime;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				if (config.BanInput)
				{
					ModelBase<GeneralLogicTreeModel>.Instance.DisableInput = false;
					ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
					Singleton<Log>.Instance.Info(ELogModule.SummonGongduola, ELogAuthor.CH, "[StartLookAtGongduola] StartLookAtGongduola StopBanInput", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}, (float)((int)(num * 1000f)), null, null, true, 1f);
		}

		// Token: 0x0402630C RID: 156428
		private UAnimMontage CacheSummonAm;

		// Token: 0x0402630D RID: 156429
		private UAnimMontage CacheCancelSummonAm;

		// Token: 0x0402630E RID: 156430
		private BaseActorComponent CacheActorComponent;

		// Token: 0x0402630F RID: 156431
		private VehicleAnimationComponent CacheVehicleAnimationComponent;

		// Token: 0x04026310 RID: 156432
		private VehicleMoveComponent CacheVehicleMoveComponent;

		// Token: 0x04026311 RID: 156433
		private UeSkeletalTickManageComponent CacheUeSkeletalTickManagerComp;

		// Token: 0x04026312 RID: 156434
		private BaseTagComponent CacheVehicleTagComp;
	}
}
