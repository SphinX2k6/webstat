using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Character.Role.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02005004 RID: 20484
	[NullableContext(1)]
	[Nullable(0)]
	public class SeamlessTravelKeepKite
	{
		// Token: 0x17008ABB RID: 35515
		// (get) Token: 0x06034CC3 RID: 216259 RVA: 0x00D3FBE9 File Offset: 0x00D3DDE9
		public bool IsInit
		{
			get
			{
				return this.IsInitInternal;
			}
		}

		// Token: 0x17008ABC RID: 35516
		// (get) Token: 0x06034CC4 RID: 216260 RVA: 0x00D3FBF1 File Offset: 0x00D3DDF1
		public bool IsActive
		{
			get
			{
				return this.IsActiveInternal;
			}
		}

		// Token: 0x06034CC5 RID: 216261 RVA: 0x00D3FBFC File Offset: 0x00D3DDFC
		public void Init(SeamlessTravelContext context, [Nullable(2)] Action<bool> callback = null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepKite] 初始化KeepKite(开始)", default(ReadOnlySpan<ValueTuple<string, object>>));
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			this.ActorComp = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			if (this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Teleport;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[无缝传送KeepKite] 初始化失败，无效的ActorComp";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (this.IsInit)
			{
				if (callback != null)
				{
					callback(true);
				}
				return;
			}
			this.Context = context;
			if (this.Context == null)
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			this.BeamEffectPath = "/Game/Aki/Effect/Niagara/NI_Common/NS_Fx_Hook_Beam1.NS_Fx_Hook_Beam1";
			this.BallEffectPath = "/Game/Aki/Effect/Niagara/NI_Common/NS_Fx_Hook_Maodian.NS_Fx_Hook_Maodian";
			this.BeamOwnerSocketName = "Bip001LHand";
			this.InitCallback = callback;
			USkeletalMesh kiteMeshAsset = this.KiteMeshAsset;
			if (kiteMeshAsset == null || !kiteMeshAsset.IsValid())
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<USkeletalMesh>("/Game/Aki/Character/NPC/AlienNPC/Level_C/SC1Fengzheng/Model/SC1Fengzheng.SC1Fengzheng", delegate([Nullable(2)] USkeletalMesh asset, string _)
				{
					if (asset == null || !asset.IsValid())
					{
						this.FailInit();
						return;
					}
					this.KiteMeshAsset = asset;
					this.CheckInitLoadFinish();
				}, 100, "SeamlessTravel");
			}
			UAnimationAsset kiteAnimAsset = this.KiteAnimAsset;
			if (kiteAnimAsset == null || !kiteAnimAsset.IsValid())
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>("/Game/Aki/Character/NPC/AlienNPC/Level_C/SC1Fengzheng/CommonAnim/SC1Fengzheng_State03_Montage.SC1Fengzheng_State03_Montage", delegate([Nullable(2)] UAnimationAsset asset, string _)
				{
					if (asset == null || !asset.IsValid())
					{
						this.FailInit();
						return;
					}
					this.KiteAnimAsset = asset;
					this.CheckInitLoadFinish();
				}, 100, "SeamlessTravel");
			}
			UNiagaraSystem beamEffectAsset = this.BeamEffectAsset;
			if (beamEffectAsset == null || !beamEffectAsset.IsValid())
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(this.BeamEffectPath, delegate([Nullable(2)] UNiagaraSystem asset, string _)
				{
					if (asset == null || !asset.IsValid())
					{
						this.FailInit();
						return;
					}
					this.BeamEffectAsset = asset;
					this.CheckInitLoadFinish();
				}, 100, "SeamlessTravel");
			}
			UNiagaraSystem ballEffectAsset = this.BallEffectAsset;
			if (ballEffectAsset == null || !ballEffectAsset.IsValid())
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(this.BallEffectPath, delegate([Nullable(2)] UNiagaraSystem asset, string _)
				{
					if (asset == null || !asset.IsValid())
					{
						this.FailInit();
						return;
					}
					this.BallEffectAsset = asset;
					this.CheckInitLoadFinish();
				}, 100, "SeamlessTravel");
			}
			this.CheckInitLoadFinish();
		}

		// Token: 0x06034CC6 RID: 216262 RVA: 0x00D3FDC5 File Offset: 0x00D3DFC5
		private void FailInit()
		{
			Action<bool> initCallback = this.InitCallback;
			this.InitCallback = null;
			if (initCallback == null)
			{
				return;
			}
			initCallback(false);
		}

		// Token: 0x06034CC7 RID: 216263 RVA: 0x00D3FDDF File Offset: 0x00D3DFDF
		private void SuccessInit()
		{
			Action<bool> initCallback = this.InitCallback;
			this.InitCallback = null;
			if (initCallback == null)
			{
				return;
			}
			initCallback(true);
		}

		// Token: 0x06034CC8 RID: 216264 RVA: 0x00D3FDFC File Offset: 0x00D3DFFC
		private void CheckInitLoadFinish()
		{
			if (this.IsInit)
			{
				return;
			}
			USkeletalMesh kiteMeshAsset = this.KiteMeshAsset;
			if (kiteMeshAsset != null && kiteMeshAsset.IsValid())
			{
				UAnimationAsset kiteAnimAsset = this.KiteAnimAsset;
				if (kiteAnimAsset != null && kiteAnimAsset.IsValid())
				{
					UNiagaraSystem beamEffectAsset = this.BeamEffectAsset;
					if (beamEffectAsset != null && beamEffectAsset.IsValid())
					{
						UNiagaraSystem ballEffectAsset = this.BallEffectAsset;
						if (ballEffectAsset != null && ballEffectAsset.IsValid())
						{
							this.OnInitLoadFinish();
							return;
						}
					}
				}
			}
		}

		// Token: 0x06034CC9 RID: 216265 RVA: 0x00D3FE78 File Offset: 0x00D3E078
		private void OnInitLoadFinish()
		{
			CharacterActorComponent actorComp = this.ActorComp;
			bool flag;
			if (actorComp == null)
			{
				flag = true;
			}
			else
			{
				TsBaseCharacter actor = actorComp.Actor;
				flag = !((actor != null) ? new bool?(actor.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				this.FailInit();
				return;
			}
			this.KiteActor = (Singleton<ActorSystem>.Instance.Get(ASkeletalMeshActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as ASkeletalMeshActor);
			this.BeamActor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
			this.BallActor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
			ASkeletalMeshActor kiteActor = this.KiteActor;
			if (kiteActor != null && kiteActor.IsValid())
			{
				AActor beamActor = this.BeamActor;
				if (beamActor != null && beamActor.IsValid())
				{
					AActor ballActor = this.BallActor;
					if (ballActor != null && ballActor.IsValid())
					{
						USkeletalMeshComponent skeletalMeshComponent = this.KiteActor.GetSkeletalMeshComponent();
						if (skeletalMeshComponent == null || !skeletalMeshComponent.IsValid())
						{
							this.FailInit();
							return;
						}
						skeletalMeshComponent.SetSkeletalMesh(this.KiteMeshAsset, true);
						skeletalMeshComponent.PlayAnimation(this.KiteAnimAsset, true);
						if (this.KiteAnimStartPos != 0f)
						{
							skeletalMeshComponent.SetPosition(this.KiteAnimStartPos, true);
						}
						skeletalMeshComponent.VisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.AlwaysTickPoseAndRefreshBones;
						this.KiteActor.SetActorHiddenInGame(true);
						this.BeamEffectNiagaraComp = (this.BeamActor.AddComponentByClass(UNiagaraComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UNiagaraComponent);
						this.BeamEffectNiagaraComp.SetAsset(this.BeamEffectAsset, true);
						TimerSystem.Instance.Next(delegate(float _)
						{
							UKuroEffectLibrary.SetNiagaraSimulationMinDeltaTime(this.BeamEffectNiagaraComp, -1f);
						}, null, null);
						this.BeamActor.K2_AttachToComponent(this.ActorComp.Actor.Mesh, FNameUtil.GetDynamicFName(this.BeamOwnerSocketName) ?? FNameUtil.NONE, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
						this.BeamActor.SetActorHiddenInGame(true);
						this.BallEffectNiagaraComp = (this.BallActor.AddComponentByClass(UNiagaraComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UNiagaraComponent);
						this.BallEffectNiagaraComp.SetAsset(this.BallEffectAsset, true);
						TimerSystem.Instance.Next(delegate(float _)
						{
							UKuroEffectLibrary.SetNiagaraSimulationMinDeltaTime(this.BallEffectNiagaraComp, -1f);
							UKuroEffectLibrary.SetNiagaraFrameDeltaTime(this.BallEffectNiagaraComp, 1f);
						}, null, null);
						this.BallActor.SetActorHiddenInGame(true);
						this.UpdateKeepKite();
						this.IsInitInternal = true;
						Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepKite] 初始化KeepKite(完成)", default(ReadOnlySpan<ValueTuple<string, object>>));
						this.SuccessInit();
						return;
					}
				}
			}
			this.FailInit();
		}

		// Token: 0x06034CCA RID: 216266 RVA: 0x00D40131 File Offset: 0x00D3E331
		public void Tick(float delta)
		{
			if (!this.IsInit || !this.IsActive)
			{
				return;
			}
			this.UpdateKeepKite();
		}

		// Token: 0x06034CCB RID: 216267 RVA: 0x00D4014C File Offset: 0x00D3E34C
		public void UpdateKeepKite()
		{
			ASkeletalMeshActor kiteActor = this.KiteActor;
			if (kiteActor != null && kiteActor.IsValid())
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null && actorComp.Actor.IsValid())
				{
					AActor kiteActor2 = this.KiteActor;
					FTransformDouble ftransformDouble = this.GetKiteTransform(this.KiteTransformCache).ToUeTransform();
					kiteActor2.D_K2_SetActorTransform(ftransformDouble, false, ref WorldGlobal.SweepHitResult, true);
				}
				Vector kiteHookLocation = this.GetKiteHookLocation(this.KiteHookLocationCache);
				UNiagaraComponent beamEffectNiagaraComp = this.BeamEffectNiagaraComp;
				if (beamEffectNiagaraComp != null && beamEffectNiagaraComp.IsValid())
				{
					FVector inValue = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, kiteHookLocation.ToUeVector(false));
					this.BeamEffectNiagaraComp.SetNiagaraVariableVec3("end", inValue);
				}
				AActor ballActor = this.BallActor;
				if (ballActor != null && ballActor.IsValid())
				{
					this.BallActor.D_K2_SetActorLocation(kiteHookLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, true);
				}
			}
		}

		// Token: 0x06034CCC RID: 216268 RVA: 0x00D40224 File Offset: 0x00D3E424
		public void Destroy()
		{
			Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepKite] 清理KeepKite", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsInitInternal = false;
			this.BeamEffectAsset = null;
			this.BeamEffectNiagaraComp = null;
			Singleton<ActorSystem>.Instance.Put("SeamlessTravelKeepKite.Destroy", this.BeamActor, null);
			this.BeamActor = null;
			this.BallEffectAsset = null;
			this.BallEffectNiagaraComp = null;
			Singleton<ActorSystem>.Instance.Put("SeamlessTravelKeepKite.Destroy", this.BallActor, null);
			this.BallActor = null;
			this.KiteMeshAsset = null;
			this.KiteAnimAsset = null;
			this.KiteAnimStartPos = 0f;
			Singleton<ActorSystem>.Instance.Put("SeamlessTravelKeepKite.Destroy", this.KiteActor, null);
			this.KiteActor = null;
			this.ActorComp = null;
			this.Context = null;
		}

		// Token: 0x06034CCD RID: 216269 RVA: 0x00D402F4 File Offset: 0x00D3E4F4
		[NullableContext(2)]
		public void AppearEffect(Action<bool> callback = null)
		{
			if (!this.IsInit)
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (this.IsActive)
			{
				if (callback != null)
				{
					callback(true);
				}
				return;
			}
			ASkeletalMeshActor kiteActor = this.KiteActor;
			if (kiteActor != null && kiteActor.IsValid())
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null && actorComp.Actor.IsValid())
				{
					Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepKite] 显示效果", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.IsActiveInternal = true;
					RoleSceneInteractComponent component = this.ActorComp.Entity.GetComponent<RoleSceneInteractComponent>();
					if (component != null && component.GetIsHooking())
					{
						GrapplingHookPointComponent currentTarget = component.GetCurrentTarget();
						if (currentTarget != null && currentTarget.GetHookInteractType().GetValueOrDefault() == EHookInteractType.KiteHook)
						{
							WorldEntity entity = component.GetCurrentTargetEntity().Entity;
							if (entity != null)
							{
								entity.Disable("[无缝传送KeepKite] 隐藏风筝声骸");
							}
							component.SetIsHookEndByInterrupt(true);
							CharacterSkillComponent component2 = this.ActorComp.Entity.GetComponent<CharacterSkillComponent>();
							if (component2 != null)
							{
								component2.EndSkill(210130, "[无缝传送KeepKite] 停止勾风筝技能");
							}
						}
					}
					this.KiteActor.SetActorHiddenInGame(false);
					AActor beamActor = this.BeamActor;
					if (beamActor != null)
					{
						beamActor.SetActorHiddenInGame(false);
					}
					AActor ballActor = this.BallActor;
					if (ballActor != null)
					{
						ballActor.SetActorHiddenInGame(false);
					}
					USkeletalMeshComponent skeletalMesh = this.ActorComp.SkeletalMesh;
					CharacterWeaponComponent component3 = this.ActorComp.Entity.GetComponent<CharacterWeaponComponent>();
					USkeletalMeshComponent uskeletalMeshComponent = (component3 != null) ? component3.Hulu : null;
					USkeletalMeshComponent skeletalMeshComponent = this.KiteActor.SkeletalMeshComponent;
					if (skeletalMesh != null && skeletalMesh.IsValid())
					{
						this.CharaMainMeshCastHiddenShadowBeforeTravel = new bool?(skeletalMesh.bCastHiddenShadow);
						skeletalMesh.bCastHiddenShadow = true;
					}
					if (uskeletalMeshComponent != null && uskeletalMeshComponent.IsValid())
					{
						this.CharaHuluMeshCastHiddenShadowBeforeTravel = new bool?(uskeletalMeshComponent.bCastHiddenShadow);
						uskeletalMeshComponent.bCastHiddenShadow = true;
					}
					if (skeletalMeshComponent != null && skeletalMeshComponent.IsValid())
					{
						skeletalMeshComponent.bCastHiddenShadow = true;
					}
					UNiagaraComponent beamEffectNiagaraComp = this.BeamEffectNiagaraComp;
					if (beamEffectNiagaraComp != null && beamEffectNiagaraComp.IsValid())
					{
						this.BeamEffectNiagaraComp.bCastHiddenShadow = true;
					}
					UNiagaraComponent ballEffectNiagaraComp = this.BallEffectNiagaraComp;
					if (ballEffectNiagaraComp != null && ballEffectNiagaraComp.IsValid())
					{
						this.BallEffectNiagaraComp.bCastHiddenShadow = true;
					}
					if (callback != null)
					{
						callback(true);
					}
					return;
				}
			}
			if (callback != null)
			{
				callback(false);
			}
		}

		// Token: 0x06034CCE RID: 216270 RVA: 0x00D40518 File Offset: 0x00D3E718
		[NullableContext(2)]
		public void DisappearEffect(Action<bool> callback = null)
		{
			if (!this.IsInit)
			{
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			if (!this.IsActive)
			{
				if (callback != null)
				{
					callback(true);
				}
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Teleport, ELogAuthor.ZYL, "[无缝传送KeepKite] 隐藏效果", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsActiveInternal = false;
			ASkeletalMeshActor kiteActor = this.KiteActor;
			if (kiteActor != null)
			{
				kiteActor.SetActorHiddenInGame(true);
			}
			AActor beamActor = this.BeamActor;
			if (beamActor != null)
			{
				beamActor.SetActorHiddenInGame(true);
			}
			AActor ballActor = this.BallActor;
			if (ballActor != null)
			{
				ballActor.SetActorHiddenInGame(true);
			}
			CharacterActorComponent actorComp = this.ActorComp;
			USkeletalMeshComponent uskeletalMeshComponent = (actorComp != null) ? actorComp.SkeletalMesh : null;
			CharacterActorComponent actorComp2 = this.ActorComp;
			USkeletalMeshComponent uskeletalMeshComponent2;
			if (actorComp2 == null)
			{
				uskeletalMeshComponent2 = null;
			}
			else
			{
				CharacterWeaponComponent component = actorComp2.Entity.GetComponent<CharacterWeaponComponent>();
				uskeletalMeshComponent2 = ((component != null) ? component.Hulu : null);
			}
			USkeletalMeshComponent uskeletalMeshComponent3 = uskeletalMeshComponent2;
			ASkeletalMeshActor kiteActor2 = this.KiteActor;
			USkeletalMeshComponent uskeletalMeshComponent4 = (kiteActor2 != null) ? kiteActor2.SkeletalMeshComponent : null;
			if (uskeletalMeshComponent != null && uskeletalMeshComponent.IsValid() && this.CharaMainMeshCastHiddenShadowBeforeTravel != null)
			{
				uskeletalMeshComponent.bCastHiddenShadow = this.CharaMainMeshCastHiddenShadowBeforeTravel.Value;
			}
			if (uskeletalMeshComponent3 != null && uskeletalMeshComponent3.IsValid() && this.CharaHuluMeshCastHiddenShadowBeforeTravel != null)
			{
				uskeletalMeshComponent3.bCastHiddenShadow = this.CharaHuluMeshCastHiddenShadowBeforeTravel.Value;
			}
			if (uskeletalMeshComponent4 != null && uskeletalMeshComponent4.IsValid())
			{
				uskeletalMeshComponent4.bCastHiddenShadow = false;
			}
			UNiagaraComponent beamEffectNiagaraComp = this.BeamEffectNiagaraComp;
			if (beamEffectNiagaraComp != null && beamEffectNiagaraComp.IsValid())
			{
				this.BeamEffectNiagaraComp.bCastHiddenShadow = false;
			}
			UNiagaraComponent ballEffectNiagaraComp = this.BallEffectNiagaraComp;
			if (ballEffectNiagaraComp != null && ballEffectNiagaraComp.IsValid())
			{
				this.BallEffectNiagaraComp.bCastHiddenShadow = false;
			}
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x06034CCF RID: 216271 RVA: 0x00D406A0 File Offset: 0x00D3E8A0
		public void SetInitData(Entity kiteEntity, Entity instigatorEntity)
		{
			SceneItemActorComponent component = kiteEntity.GetComponent<SceneItemActorComponent>();
			AActor actorInSceneInteraction = component.GetActorInSceneInteraction("Fengzheng");
			AActor owner = component.Owner;
			FTransformDouble ftransformDouble = (owner != null) ? owner.D_GetTransform() : component.ActorTransform;
			FTransformDouble ftransformDouble2 = (actorInSceneInteraction != null) ? actorInSceneInteraction.D_GetTransform() : ftransformDouble;
			BaseActorComponent component2 = instigatorEntity.GetComponent<BaseActorComponent>();
			FTransformDouble actorTransform = component2.ActorTransform;
			Transform relativeTransform = this.RelativeTransform;
			FTransformDouble relativeTransform2 = ftransformDouble2.GetRelativeTransform(actorTransform);
			relativeTransform.FromUeTransform(relativeTransform2);
			this.GravityDirect.DeepCopy(component2.ActorGravityDirectProxy);
			Transform hookPointRelativeTransformToKite = this.HookPointRelativeTransformToKite;
			relativeTransform2 = ftransformDouble.GetRelativeTransform(ftransformDouble2);
			hookPointRelativeTransformToKite.FromUeTransform(relativeTransform2);
			ASkeletalMeshActor askeletalMeshActor = actorInSceneInteraction as ASkeletalMeshActor;
			if (askeletalMeshActor != null)
			{
				USkeletalMeshComponent skeletalMeshComponent = askeletalMeshActor.SkeletalMeshComponent;
				this.KiteMeshAsset = ((skeletalMeshComponent != null) ? skeletalMeshComponent.SkeletalMesh : null);
				UAnimInstance uanimInstance = (skeletalMeshComponent != null) ? skeletalMeshComponent.GetAnimInstance() : null;
				this.KiteAnimAsset = ((uanimInstance != null) ? uanimInstance.GetCurrentActiveMontage() : null);
				this.KiteAnimStartPos = ((uanimInstance != null) ? uanimInstance.Montage_GetPosition(null) : 0f);
			}
		}

		// Token: 0x06034CD0 RID: 216272 RVA: 0x00D4079C File Offset: 0x00D3E99C
		private Vector GetKiteHookLocation(Vector outLocation)
		{
			ASkeletalMeshActor kiteActor = this.KiteActor;
			if (kiteActor == null || !kiteActor.IsValid())
			{
				return outLocation;
			}
			FTransformDouble ftransformDouble = this.HookPointRelativeTransformToKite.ToUeTransform();
			FTransformDouble ftransformDouble2 = this.KiteActor.D_GetTransform();
			FVectorDouble location = (ftransformDouble * ftransformDouble2).GetLocation();
			outLocation.DeepCopy(location);
			return outLocation;
		}

		// Token: 0x06034CD1 RID: 216273 RVA: 0x00D407F8 File Offset: 0x00D3E9F8
		private Transform GetKiteTransform(Transform outTransform)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.Actor.IsValid())
			{
				return outTransform;
			}
			FTransformDouble ftransformDouble = this.RelativeTransform.ToUeTransform();
			FTransformDouble ftransformDouble2 = this.ActorComp.Actor.D_GetTransform();
			FTransformDouble ftransformDouble3 = ftransformDouble * ftransformDouble2;
			outTransform.FromUeTransform(ftransformDouble3);
			return outTransform;
		}

		// Token: 0x06034CD2 RID: 216274 RVA: 0x00D40853 File Offset: 0x00D3EA53
		public TArray<AActor> GetSeamlessTravelActors(TArray<AActor> arr)
		{
			if (this.KiteActor != null)
			{
				arr.Add(this.KiteActor);
			}
			if (this.BeamActor != null)
			{
				arr.Add(this.BeamActor);
			}
			if (this.BallActor != null)
			{
				arr.Add(this.BallActor);
			}
			return arr;
		}

		// Token: 0x0401E69C RID: 124572
		private const string DEFAULT_KITE_SKELETAL_MESH_PATH = "/Game/Aki/Character/NPC/AlienNPC/Level_C/SC1Fengzheng/Model/SC1Fengzheng.SC1Fengzheng";

		// Token: 0x0401E69D RID: 124573
		private const string DEFAULT_KITE_ANIM_PATH = "/Game/Aki/Character/NPC/AlienNPC/Level_C/SC1Fengzheng/CommonAnim/SC1Fengzheng_State03_Montage.SC1Fengzheng_State03_Montage";

		// Token: 0x0401E69E RID: 124574
		private const string KITE_HOOK_BEAM_EFFECT_PATH = "/Game/Aki/Effect/Niagara/NI_Common/NS_Fx_Hook_Beam1.NS_Fx_Hook_Beam1";

		// Token: 0x0401E69F RID: 124575
		private const string KITE_HOOK_BALL_EFFECT_PATH = "/Game/Aki/Effect/Niagara/NI_Common/NS_Fx_Hook_Maodian.NS_Fx_Hook_Maodian";

		// Token: 0x0401E6A0 RID: 124576
		private const string KITE_HOOK_BEAM_OWNER_SOCKET = "Bip001LHand";

		// Token: 0x0401E6A1 RID: 124577
		private const string KITE_HOOK_BEAM_NIAGARA_ENDPOS_VAR = "end";

		// Token: 0x0401E6A2 RID: 124578
		private const string KITE_ACTOR_REF_NAME = "Fengzheng";

		// Token: 0x0401E6A3 RID: 124579
		private const int SKILL_ID_XA_KITE = 210130;

		// Token: 0x0401E6A4 RID: 124580
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401E6A5 RID: 124581
		[Nullable(2)]
		private SeamlessTravelContext Context;

		// Token: 0x0401E6A6 RID: 124582
		private bool IsInitInternal;

		// Token: 0x0401E6A7 RID: 124583
		private bool IsActiveInternal;

		// Token: 0x0401E6A8 RID: 124584
		[Nullable(2)]
		private USkeletalMesh KiteMeshAsset;

		// Token: 0x0401E6A9 RID: 124585
		[Nullable(2)]
		private UAnimationAsset KiteAnimAsset;

		// Token: 0x0401E6AA RID: 124586
		private float KiteAnimStartPos;

		// Token: 0x0401E6AB RID: 124587
		[Nullable(2)]
		private ASkeletalMeshActor KiteActor;

		// Token: 0x0401E6AC RID: 124588
		[Nullable(2)]
		private UNiagaraSystem BeamEffectAsset;

		// Token: 0x0401E6AD RID: 124589
		[Nullable(2)]
		private UNiagaraSystem BallEffectAsset;

		// Token: 0x0401E6AE RID: 124590
		[Nullable(2)]
		private AActor BeamActor;

		// Token: 0x0401E6AF RID: 124591
		[Nullable(2)]
		private AActor BallActor;

		// Token: 0x0401E6B0 RID: 124592
		[Nullable(2)]
		private UNiagaraComponent BeamEffectNiagaraComp;

		// Token: 0x0401E6B1 RID: 124593
		[Nullable(2)]
		private UNiagaraComponent BallEffectNiagaraComp;

		// Token: 0x0401E6B2 RID: 124594
		private readonly Transform RelativeTransform = Transform.Create();

		// Token: 0x0401E6B3 RID: 124595
		private readonly Vector GravityDirect = Vector.Create();

		// Token: 0x0401E6B4 RID: 124596
		private string BeamEffectPath = "";

		// Token: 0x0401E6B5 RID: 124597
		private string BallEffectPath = "";

		// Token: 0x0401E6B6 RID: 124598
		private string BeamOwnerSocketName = "";

		// Token: 0x0401E6B7 RID: 124599
		private readonly Transform HookPointRelativeTransformToKite = Transform.Create();

		// Token: 0x0401E6B8 RID: 124600
		private readonly Transform KiteTransformCache = Transform.Create();

		// Token: 0x0401E6B9 RID: 124601
		private readonly Vector KiteHookLocationCache = Vector.Create();

		// Token: 0x0401E6BA RID: 124602
		private bool? CharaMainMeshCastHiddenShadowBeforeTravel;

		// Token: 0x0401E6BB RID: 124603
		private bool? CharaHuluMeshCastHiddenShadowBeforeTravel;

		// Token: 0x0401E6BC RID: 124604
		[Nullable(2)]
		private Action<bool> InitCallback;
	}
}
