using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.DecalShadow;
using AkiClient.Game.Aki.Render.RuntimeBP.RenderData;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.LensFlare;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Weather;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004768 RID: 18280
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RenderDataManager : Singleton<RenderDataManager>
	{
		// Token: 0x0602F6E5 RID: 194277 RVA: 0x00B45DE0 File Offset: 0x00B43FE0
		private void OnGlobalFootstepMaterialChange(UPhysicalMaterial material)
		{
			this.GlobalFootstepMaterial = material;
			Singleton<EventSystem>.Instance.Emit<UPhysicalMaterial>(EEventName.OnGlobalFootstepMaterialChange, material);
		}

		// Token: 0x0602F6E6 RID: 194278 RVA: 0x00B45DFC File Offset: 0x00B43FFC
		private void OnForbidWeatherStateChange(bool bForbidWeather)
		{
			this.ForbidWeather = bForbidWeather;
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().SetWeatherForbidden(bForbidWeather);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnForbidWeatherStateChange, bForbidWeather);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "随机天气状态变化";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("状态", bForbidWeather ? "禁用" : "启用");
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602F6E7 RID: 194279 RVA: 0x00B45E66 File Offset: 0x00B44066
		protected override bool OnInit()
		{
			this.Init();
			return true;
		}

		// Token: 0x0602F6E8 RID: 194280 RVA: 0x00B45E70 File Offset: 0x00B44070
		private void Init()
		{
			this.Valid = false;
			this.LoadAssets();
			this.PreviousCharacterPosition = global::Vector.Create();
			this.CurrentCharacterPosition = global::Vector.Create();
			this.PreviousCharacterPositionWithOffset = global::Vector.Create();
			this.CurrentCharacterPositionWithOffset = global::Vector.Create();
			this.CurrentCharacterWeaponPositionWithOffset = global::Vector.Create();
			this.CurrentCharacterForward = global::Vector.Create();
			this.CurrentCameraPosition = global::Vector.Create();
			this.CurrentCameraPositionWithOffset = global::Vector.Create();
			this.CurrentCameraForward = global::Vector.Create();
			this.TempColor = new FLinearColor?(new FLinearColor());
			this.WriteTimeToCollection = true;
			AKuroGlobalGI.BindEventGlobalFootstepMaterialUpdate(global::DelegateUtils.ToManualReleaseDelegate<FOnGlobalFootstepMaterialUpdateDelegate>(new Action<UPhysicalMaterial>(this.OnGlobalFootstepMaterialChange)));
			AKuroGlobalGI.BindEventForbidWeatherStateChanged(global::DelegateUtils.ToManualReleaseDelegate<FOnForbidWeatherStateChangedDelegate>(new Action<bool>(this.OnForbidWeatherStateChange)));
		}

		// Token: 0x0602F6E9 RID: 194281 RVA: 0x00B45F30 File Offset: 0x00B44130
		public float GetRainIntensity()
		{
			if (GlobalData.World != null && this.GlobalShaderParameters != null)
			{
				return UKismetMaterialLibrary.GetScalarParameterValue(GlobalData.World, this.GlobalShaderParameters, RenderConfig.GlobalRainIntensity);
			}
			return 0f;
		}

		// Token: 0x0602F6EA RID: 194282 RVA: 0x00B45F5C File Offset: 0x00B4415C
		public float GetSnowIntensity()
		{
			if (GlobalData.World != null && this.GlobalShaderParameters != null)
			{
				return UKismetMaterialLibrary.GetScalarParameterValue(GlobalData.World, this.GlobalShaderParameters, RenderConfig.GlobalSnowIntensity);
			}
			return 0f;
		}

		// Token: 0x0602F6EB RID: 194283 RVA: 0x00B45F88 File Offset: 0x00B44188
		public float GetWindIntensity()
		{
			if (GlobalData.World != null && this.GlobalShaderParameters != null)
			{
				return UKismetMaterialLibrary.GetScalarParameterValue(GlobalData.World, this.GlobalShaderParameters, RenderConfig.GlobalWindSpeed);
			}
			return 0f;
		}

		// Token: 0x0602F6EC RID: 194284 RVA: 0x00B45FB4 File Offset: 0x00B441B4
		public void SetGrassAo(float strength)
		{
			if (GlobalData.World != null && this.GlobalShaderParameters != null)
			{
				UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.GlobalShaderParameters, RenderConfig.GlobalGrassAO, strength);
			}
		}

		// Token: 0x0602F6ED RID: 194285 RVA: 0x00B45FDC File Offset: 0x00B441DC
		public global::Vector GetMainLightVector(UObject worldContextObject = null)
		{
			UObject uobject = worldContextObject ?? GlobalData.World;
			if (uobject != null && this.GlobalShaderParameters != null)
			{
				FLinearColor vectorParameterValue = UKismetMaterialLibrary.GetVectorParameterValue(uobject, this.GlobalShaderParameters, RenderConfig.GlobalMainLightVector);
				return global::Vector.Create((double)vectorParameterValue.R, (double)vectorParameterValue.G, (double)vectorParameterValue.B);
			}
			return null;
		}

		// Token: 0x0602F6EE RID: 194286 RVA: 0x00B4602D File Offset: 0x00B4422D
		public PDA_ModelLensFlareConfig_C GetGlobalLensFlareConfig()
		{
			if (!this.Valid)
			{
				return null;
			}
			return this.GlobalLensFlareConfig;
		}

		// Token: 0x0602F6EF RID: 194287 RVA: 0x00B4603F File Offset: 0x00B4423F
		public PDA_DecalShadowConfig_C GetGlobalDecalShadowConfig()
		{
			if (!this.Valid)
			{
				return null;
			}
			return this.GlobalDecalShadowConfig;
		}

		// Token: 0x0602F6F0 RID: 194288 RVA: 0x00B46051 File Offset: 0x00B44251
		public global::Vector GetCurrentCharacterPosition()
		{
			return this.CurrentCharacterPosition;
		}

		// Token: 0x0602F6F1 RID: 194289 RVA: 0x00B46059 File Offset: 0x00B44259
		public global::Vector GetPreviousCharacterPosition()
		{
			return this.PreviousCharacterPosition;
		}

		// Token: 0x0602F6F2 RID: 194290 RVA: 0x00B46061 File Offset: 0x00B44261
		public global::Vector GetCurrentCharacterPositionWithOffset()
		{
			return this.CurrentCharacterPositionWithOffset;
		}

		// Token: 0x0602F6F3 RID: 194291 RVA: 0x00B46069 File Offset: 0x00B44269
		public global::Vector GetCurrentCharacterWeaponPositionWithOffset()
		{
			return this.CurrentCharacterWeaponPositionWithOffset;
		}

		// Token: 0x0602F6F4 RID: 194292 RVA: 0x00B46071 File Offset: 0x00B44271
		public global::Vector GetPreviousCharacterPositionWithOffset()
		{
			return this.PreviousCharacterPositionWithOffset;
		}

		// Token: 0x0602F6F5 RID: 194293 RVA: 0x00B46079 File Offset: 0x00B44279
		public global::Vector GetCurrentCharacterForward()
		{
			return this.CurrentCharacterForward;
		}

		// Token: 0x0602F6F6 RID: 194294 RVA: 0x00B46081 File Offset: 0x00B44281
		public global::Vector GetCurrentCameraPosition()
		{
			return this.CurrentCameraPosition;
		}

		// Token: 0x0602F6F7 RID: 194295 RVA: 0x00B46089 File Offset: 0x00B44289
		public global::Vector GetCurrentCameraPositionWithOffset()
		{
			return this.CurrentCameraPosition;
		}

		// Token: 0x0602F6F8 RID: 194296 RVA: 0x00B46091 File Offset: 0x00B44291
		public global::Vector GetCurrentCameraForward()
		{
			return this.CurrentCameraForward;
		}

		// Token: 0x0602F6F9 RID: 194297 RVA: 0x00B46099 File Offset: 0x00B44299
		public UMaterialParameterCollection GetGlobalShaderParameters()
		{
			return this.GlobalShaderParameters;
		}

		// Token: 0x0602F6FA RID: 194298 RVA: 0x00B460A1 File Offset: 0x00B442A1
		public UMaterialParameterCollection GetSceneInteractionMaterialParameterCollection()
		{
			return this.SceneInteractionMaterialParameterCollection;
		}

		// Token: 0x0602F6FB RID: 194299 RVA: 0x00B460A9 File Offset: 0x00B442A9
		public UMaterialParameterCollection GetUiShowBrightnessMaterialParameterCollection()
		{
			return this.UiShowBrightnessMaterialParameterCollection;
		}

		// Token: 0x0602F6FC RID: 194300 RVA: 0x00B460B1 File Offset: 0x00B442B1
		public UMaterialParameterCollection GetUiShowColorSettingMaterialParameterCollection()
		{
			return this.UiShowColorSettingMaterialParameterCollection;
		}

		// Token: 0x0602F6FD RID: 194301 RVA: 0x00B460B9 File Offset: 0x00B442B9
		public UMaterialParameterCollection GetEyesParameterMaterialParameterCollection()
		{
			return this.EyesParameterMaterialParameterCollection;
		}

		// Token: 0x0602F6FE RID: 194302 RVA: 0x00B460C1 File Offset: 0x00B442C1
		public UMaterialParameterCollection GetGroundFogMaskMaterialParameterCollection()
		{
			return this.GroundFogMaskMaterialParameterCollection;
		}

		// Token: 0x0602F6FF RID: 194303 RVA: 0x00B460C9 File Offset: 0x00B442C9
		public UMaterialParameterCollection GetSceneCaptureParameterCollection()
		{
			return this.SceneCaptureParameterCollection;
		}

		// Token: 0x0602F700 RID: 194304 RVA: 0x00B460D1 File Offset: 0x00B442D1
		public UMaterialParameterCollection GetMpcForGameplayParameterCollection()
		{
			return this.MpcForGameplayParameterCollection;
		}

		// Token: 0x0602F701 RID: 194305 RVA: 0x00B460D9 File Offset: 0x00B442D9
		public bool GetPlayerInGrass()
		{
			this.UpdateVoxelState();
			return this.PlayerInGrass;
		}

		// Token: 0x0602F702 RID: 194306 RVA: 0x00B460E7 File Offset: 0x00B442E7
		public bool GetPlayerInCave()
		{
			this.UpdateVoxelState();
			return this.PlayerInCave;
		}

		// Token: 0x0602F703 RID: 194307 RVA: 0x00B460F8 File Offset: 0x00B442F8
		private void UpdateVoxelState()
		{
			if (this.PlayerVoxelStateDirty)
			{
				AKuroGlobalGI akuroGlobalGI = UKuroRenderingRuntimeBPPluginBPLibrary.GetGlobalGIActor(GlobalData.World) as AKuroGlobalGI;
				if (akuroGlobalGI != null)
				{
					this.PlayerInGrass = akuroGlobalGI.bPlayerInGrass;
					this.PlayerInCave = akuroGlobalGI.bPlayerInCave;
					this.PlayerVoxelStateDirty = false;
				}
			}
		}

		// Token: 0x0602F704 RID: 194308 RVA: 0x00B4613F File Offset: 0x00B4433F
		public double GetSceneTime()
		{
			return this.SceneTime;
		}

		// Token: 0x0602F705 RID: 194309 RVA: 0x00B46147 File Offset: 0x00B44347
		public UPhysicalMaterial GetGlobalFootstepMaterial()
		{
			return this.GlobalFootstepMaterial;
		}

		// Token: 0x0602F706 RID: 194310 RVA: 0x00B4614F File Offset: 0x00B4434F
		public UMaterialInterface GetEmptyMaterial()
		{
			return this.EmptyMaterial;
		}

		// Token: 0x0602F707 RID: 194311 RVA: 0x00B46157 File Offset: 0x00B44357
		public void SetWriteTime(bool enable)
		{
			this.WriteTimeToCollection = enable;
		}

		// Token: 0x0602F708 RID: 194312 RVA: 0x00B46160 File Offset: 0x00B44360
		public void SetIsPlayerMale(bool isMale)
		{
			if (this.SceneInteractionMaterialParameterCollection != null && GlobalData.World != null)
			{
				UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.SceneInteractionMaterialParameterCollection, RenderConfig.IsPlayerMale, isMale ? 1f : 0f);
			}
		}

		// Token: 0x0602F709 RID: 194313 RVA: 0x00B46198 File Offset: 0x00B44398
		public void TickForce(float delta)
		{
			if (!this.Valid)
			{
				return;
			}
			this.PlayerVoxelStateDirty = true;
			UWorld world = GlobalData.World;
			APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
			if (!UKismetSystemLibrary.IsValid(characterCameraManager))
			{
				return;
			}
			FVectorDouble fvectorDouble = characterCameraManager.D_K2_GetActorLocation();
			FVector fvector = characterCameraManager.K2_GetActorLocation();
			FVector actorForwardVector = characterCameraManager.GetActorForwardVector();
			global::Vector currentCameraPosition = this.CurrentCameraPosition;
			if (currentCameraPosition != null)
			{
				currentCameraPosition.FromUeVector(fvectorDouble);
			}
			global::Vector currentCameraPositionWithOffset = this.CurrentCameraPositionWithOffset;
			if (currentCameraPositionWithOffset != null)
			{
				currentCameraPositionWithOffset.FromUeVector(fvector);
			}
			global::Vector currentCameraForward = this.CurrentCameraForward;
			if (currentCameraForward != null)
			{
				currentCameraForward.FromUeVector(actorForwardVector);
			}
			if (world != null && this.GlobalShaderParameters != null)
			{
				UObject worldContextObject = world;
				UMaterialParameterCollection globalShaderParameters = this.GlobalShaderParameters;
				FName globalCameraPosAndRadius = RenderConfig.GlobalCameraPosAndRadius;
				FLinearColor flinearColor = new FLinearColor(fvector.X, fvector.Y, fvector.Z, 0f);
				UKismetMaterialLibrary.SetVectorParameterValue(worldContextObject, globalShaderParameters, globalCameraPosAndRadius, flinearColor);
			}
			bool flag = Singleton<Info>.Instance.IsGameRunning() && (GlobalData.IsUiSceneOpen || GlobalData.IsUiSceneLoading);
			if (flag != this.IsInUiScene)
			{
				this.IsInUiScene = flag;
				this.OnUiSceneStateChange();
			}
		}

		// Token: 0x0602F70A RID: 194314 RVA: 0x00B46290 File Offset: 0x00B44490
		public void Tick(float delta)
		{
			if (!this.Valid)
			{
				return;
			}
			double audioParameters = (double)delta * Singleton<TimeUtil>.Instance.Millisecond;
			UWorld world = GlobalData.World;
			APawn pawnOrSpectator = Global.PawnOrSpectator;
			if (pawnOrSpectator == null || !pawnOrSpectator.IsValid())
			{
				return;
			}
			FVectorDouble fvectorDouble = pawnOrSpectator.D_K2_GetActorLocation();
			FVector fvector = pawnOrSpectator.K2_GetActorLocation();
			FVector actorForwardVector = pawnOrSpectator.GetActorForwardVector();
			TArray<UActorComponent> tarray = pawnOrSpectator.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			if (tarray.Num() > 0)
			{
				USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(0) as USkeletalMeshComponent;
				if (uskeletalMeshComponent == null || !UKismetSystemLibrary.IsValid(uskeletalMeshComponent))
				{
					goto IL_D3;
				}
				try
				{
					FName inSocketName = new FName("WeaponProp05");
					FVector socketLocation = uskeletalMeshComponent.GetSocketLocation(inSocketName);
					global::Vector currentCharacterWeaponPositionWithOffset = this.CurrentCharacterWeaponPositionWithOffset;
					if (currentCharacterWeaponPositionWithOffset != null)
					{
						currentCharacterWeaponPositionWithOffset.FromUeVector(socketLocation);
					}
					goto IL_D3;
				}
				catch
				{
					global::Vector currentCharacterWeaponPositionWithOffset2 = this.CurrentCharacterWeaponPositionWithOffset;
					if (currentCharacterWeaponPositionWithOffset2 != null)
					{
						currentCharacterWeaponPositionWithOffset2.FromUeVector(fvector);
					}
					goto IL_D3;
				}
			}
			global::Vector currentCharacterWeaponPositionWithOffset3 = this.CurrentCharacterWeaponPositionWithOffset;
			if (currentCharacterWeaponPositionWithOffset3 != null)
			{
				currentCharacterWeaponPositionWithOffset3.FromUeVector(fvector);
			}
			IL_D3:
			global::Vector previousCharacterPosition = this.PreviousCharacterPosition;
			if (previousCharacterPosition != null)
			{
				global::Vector currentCharacterPosition = this.CurrentCharacterPosition;
				double inX = (currentCharacterPosition != null) ? currentCharacterPosition.X : 0.0;
				global::Vector currentCharacterPosition2 = this.CurrentCharacterPosition;
				double inY = (currentCharacterPosition2 != null) ? currentCharacterPosition2.Y : 0.0;
				global::Vector currentCharacterPosition3 = this.CurrentCharacterPosition;
				previousCharacterPosition.Set(inX, inY, (currentCharacterPosition3 != null) ? currentCharacterPosition3.Z : 0.0);
			}
			global::Vector previousCharacterPositionWithOffset = this.PreviousCharacterPositionWithOffset;
			if (previousCharacterPositionWithOffset != null)
			{
				global::Vector currentCharacterPositionWithOffset = this.CurrentCharacterPositionWithOffset;
				double inX2 = (currentCharacterPositionWithOffset != null) ? currentCharacterPositionWithOffset.X : 0.0;
				global::Vector currentCharacterPositionWithOffset2 = this.CurrentCharacterPositionWithOffset;
				double inY2 = (currentCharacterPositionWithOffset2 != null) ? currentCharacterPositionWithOffset2.Y : 0.0;
				global::Vector currentCharacterPositionWithOffset3 = this.CurrentCharacterPositionWithOffset;
				previousCharacterPositionWithOffset.Set(inX2, inY2, (currentCharacterPositionWithOffset3 != null) ? currentCharacterPositionWithOffset3.Z : 0.0);
			}
			global::Vector currentCharacterPosition4 = this.CurrentCharacterPosition;
			if (currentCharacterPosition4 != null)
			{
				currentCharacterPosition4.FromUeVector(fvectorDouble);
			}
			global::Vector currentCharacterPositionWithOffset4 = this.CurrentCharacterPositionWithOffset;
			if (currentCharacterPositionWithOffset4 != null)
			{
				currentCharacterPositionWithOffset4.FromUeVector(fvector);
			}
			global::Vector currentCharacterForward = this.CurrentCharacterForward;
			if (currentCharacterForward != null)
			{
				currentCharacterForward.FromUeVector(actorForwardVector);
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterUnifiedStateComponent characterUnifiedStateComponent;
			if (baseCharacter == null)
			{
				characterUnifiedStateComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					characterUnifiedStateComponent = null;
				}
				else
				{
					Entity entity = characterActorComponent.Entity;
					characterUnifiedStateComponent = ((entity != null) ? entity.GetComponent<CharacterUnifiedStateComponent>() : null);
				}
			}
			CharacterUnifiedStateComponent characterUnifiedStateComponent2 = characterUnifiedStateComponent;
			this.CurrentPlayerMoveState = ((characterUnifiedStateComponent2 != null) ? new global::ECharMoveState?(characterUnifiedStateComponent2.MoveState) : null);
			bool flag;
			if (this.CurrentPlayerMoveState != null)
			{
				global::ECharMoveState? currentPlayerMoveState = this.CurrentPlayerMoveState;
				global::ECharMoveState echarMoveState = global::ECharMoveState.NormalClimb;
				flag = (currentPlayerMoveState.GetValueOrDefault() < echarMoveState & currentPlayerMoveState != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (world != null && this.GlobalShaderParameters != null)
			{
				UKismetMaterialLibrary.SetScalarParameterValue(world, this.GlobalShaderParameters, RenderConfig.GlobalCharacterOnGround, flag2 ? 1f : 0f);
			}
			this.SetTempColor(this.PreviousCharacterPositionWithOffset);
			if (world != null && this.GlobalShaderParameters != null && this.TempColor != null)
			{
				UObject worldContextObject = world;
				UMaterialParameterCollection globalShaderParameters = this.GlobalShaderParameters;
				FName globalCharacterPreviousWP = RenderConfig.GlobalCharacterPreviousWP;
				FLinearColor value = this.TempColor.Value;
				UKismetMaterialLibrary.SetVectorParameterValue(worldContextObject, globalShaderParameters, globalCharacterPreviousWP, value);
			}
			this.SetTempColor(this.CurrentCharacterForward);
			if (world != null && this.GlobalShaderParameters != null && this.TempColor != null)
			{
				UObject worldContextObject2 = world;
				UMaterialParameterCollection globalShaderParameters2 = this.GlobalShaderParameters;
				FName globalCharacterWorldForwardDirection = RenderConfig.GlobalCharacterWorldForwardDirection;
				FLinearColor value = this.TempColor.Value;
				UKismetMaterialLibrary.SetVectorParameterValue(worldContextObject2, globalShaderParameters2, globalCharacterWorldForwardDirection, value);
			}
			this.SetTempColor(this.CurrentCharacterWeaponPositionWithOffset);
			if (world != null && this.GlobalShaderParameters != null && this.TempColor != null)
			{
				UObject worldContextObject3 = world;
				UMaterialParameterCollection globalShaderParameters3 = this.GlobalShaderParameters;
				FName globalCharacterWeaponPosition = RenderConfig.GlobalCharacterWeaponPosition;
				FLinearColor value = this.TempColor.Value;
				UKismetMaterialLibrary.SetVectorParameterValue(worldContextObject3, globalShaderParameters3, globalCharacterWeaponPosition, value);
			}
			if (ModelBase<GameModeModel>.Instance.InstanceType == InstanceType.BigWorldInstance)
			{
				this.SceneTime = ModelBase<TimeOfDayModel>.Instance.GameTime.Minute;
			}
			if (this.WriteTimeToCollection)
			{
				int num = (int)Math.Floor(this.SceneTime / 60.0);
				if (world != null && this.GlobalShaderParameters != null)
				{
					UKismetMaterialLibrary.SetScalarParameterValue(world, this.GlobalShaderParameters, RenderConfig.GlobalTimeHour, (float)num);
					UKismetMaterialLibrary.SetScalarParameterValue(world, this.GlobalShaderParameters, RenderConfig.GlobalTimeMinutes, (float)this.SceneTime - (float)(num * 60));
				}
			}
			TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
			BaseMoveComponent baseMoveComponent;
			if (baseCharacter2 == null)
			{
				baseMoveComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent2 = baseCharacter2.CharacterActorComponent;
				if (characterActorComponent2 == null)
				{
					baseMoveComponent = null;
				}
				else
				{
					Entity entity2 = characterActorComponent2.Entity;
					baseMoveComponent = ((entity2 != null) ? entity2.GetComponent<BaseMoveComponent>() : null);
				}
			}
			BaseMoveComponent baseMoveComponent2 = baseMoveComponent;
			if (baseMoveComponent2 != null)
			{
				global::Vector gravityDirect = baseMoveComponent2.GravityDirect;
				if (!gravityDirect.Equals(this.CachedGravityDirect, 9.999999747378752E-05))
				{
					this.SetTempColor(gravityDirect);
					if (world != null && this.GlobalShaderParameters != null && this.TempColor != null)
					{
						UObject worldContextObject4 = world;
						UMaterialParameterCollection globalShaderParameters4 = this.GlobalShaderParameters;
						FName gravityDirection = RenderConfig.GravityDirection;
						FLinearColor value = this.TempColor.Value;
						UKismetMaterialLibrary.SetVectorParameterValue(worldContextObject4, globalShaderParameters4, gravityDirection, value);
					}
					this.CachedGravityDirect.DeepCopy(gravityDirect);
				}
			}
			this.SetAudioParameters(audioParameters);
		}

		// Token: 0x0602F70B RID: 194315 RVA: 0x00B46714 File Offset: 0x00B44914
		protected void LoadAssets()
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<PDA_GlobalRenderDataReference_C>("/Game/Aki/Render/Data/DA_GlobalRenderDataReference.DA_GlobalRenderDataReference", delegate([Nullable(2)] PDA_GlobalRenderDataReference_C result, string _)
			{
				if (!UKismetSystemLibrary.IsValid(result))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "RenderDataManager缺失全局配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.Valid = true;
				this.GlobalShaderParameters = result.GlobalShaderParameters;
				if (!UKismetSystemLibrary.IsValid(this.GlobalShaderParameters))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LJY, "缺失全局材质参数文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.SceneInteractionMaterialParameterCollection = result.SceneInteractionShaderParameters;
				if (!UKismetSystemLibrary.IsValid(this.SceneInteractionMaterialParameterCollection))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LJY, "缺失交互物着色器参数文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.GlobalLensFlareConfig = result.GlobalLensFlareConfig;
				if (!UKismetSystemLibrary.IsValid(this.GlobalLensFlareConfig))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LJY, "缺失LensFlare配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.UiShowBrightnessMaterialParameterCollection = result.MPC_ShowBrightness;
				if (!UKismetSystemLibrary.IsValid(this.UiShowBrightnessMaterialParameterCollection))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LJY, "缺失UI_ShowBrightness配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.UiShowColorSettingMaterialParameterCollection = result.MPC_ShowColorSetting;
				if (!UKismetSystemLibrary.IsValid(this.UiShowColorSettingMaterialParameterCollection))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.HYF, "缺失UI_ShowColorSetting配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.GlobalDecalShadowConfig = result.DefaultDecalShadow;
				if (!UKismetSystemLibrary.IsValid(this.GlobalDecalShadowConfig))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "缺失DecalShadow配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.EyesParameterMaterialParameterCollection = result.EyesParameters;
				if (!UKismetSystemLibrary.IsValid(this.EyesParameterMaterialParameterCollection))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "缺失EyesParameters配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.GroundFogMaskMaterialParameterCollection = result.MPC_GroundFogMask;
				if (!UKismetSystemLibrary.IsValid(this.GroundFogMaskMaterialParameterCollection))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.ZYL, "缺失GroundFogMask配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.EmptyMaterial = result.EmptyMaterial;
				if (!UKismetSystemLibrary.IsValid(this.EmptyMaterial))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "缺失EmptyMaterial", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.SceneCaptureParameterCollection = result.MPC_SceneCaptureParameter;
				if (!UKismetSystemLibrary.IsValid(this.SceneCaptureParameterCollection))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "缺失SceneCaptureParameter配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.MpcForGameplayParameterCollection = result.MPC_ForGameplayParameter;
				if (!UKismetSystemLibrary.IsValid(this.MpcForGameplayParameterCollection))
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.WRY, "缺失MPC_ForGameplayParameter配置文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}, 100, "js_undefined");
		}

		// Token: 0x0602F70C RID: 194316 RVA: 0x00B46739 File Offset: 0x00B44939
		public void Destroy()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<UPhysicalMaterial>(this.OnGlobalFootstepMaterialChange));
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool>(this.OnForbidWeatherStateChange));
		}

		// Token: 0x0602F70D RID: 194317 RVA: 0x00B46760 File Offset: 0x00B44960
		protected void SetAudioParameters(double deltaSeconds)
		{
			this.AudioParameterUpdateCounter -= deltaSeconds;
			if (this.AudioParameterUpdateCounter > 0.0)
			{
				return;
			}
			this.AudioParameterUpdateCounter = 1.0;
			float rainIntensity = this.GetRainIntensity();
			float snowIntensity = this.GetSnowIntensity();
			float windIntensity = this.GetWindIntensity();
			if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CachedAudioParameterRainIntensity, (double)rainIntensity, null))
			{
				Singleton<AudioSystem>.Instance.SetRtpcValue("amb_rain_intensity", rainIntensity / 5f, null);
				this.CachedAudioParameterRainIntensity = rainIntensity;
			}
			if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CachedAudioParameterSnowIntensity, (double)snowIntensity, null))
			{
				Singleton<AudioSystem>.Instance.SetRtpcValue("amb_snow_intensity", snowIntensity / 5f, null);
				this.CachedAudioParameterSnowIntensity = snowIntensity;
			}
			if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CachedAudioParameterWindIntensity, (double)windIntensity, null))
			{
				Singleton<AudioSystem>.Instance.SetRtpcValue("amb_wind_intensity", windIntensity / 10f, null);
				this.CachedAudioParameterWindIntensity = windIntensity;
			}
		}

		// Token: 0x0602F70E RID: 194318 RVA: 0x00B46880 File Offset: 0x00B44A80
		private void SetTempColor(global::Vector vector)
		{
			if (this.TempColor == null || vector == null)
			{
				return;
			}
			this.TempColor = new FLinearColor?(new FLinearColor((float)vector.X, (float)vector.Y, (float)vector.Z, this.TempColor.Value.A));
		}

		// Token: 0x0602F70F RID: 194319 RVA: 0x00B468D3 File Offset: 0x00B44AD3
		private void OnUiSceneStateChange()
		{
			UKuroRenderingRuntimeBPPluginBPLibrary.SetClusteredStuffVisible(GlobalData.World, !this.IsInUiScene);
		}

		// Token: 0x0401B14F RID: 110927
		public bool Valid;

		// Token: 0x0401B150 RID: 110928
		protected UMaterialParameterCollection GlobalShaderParameters;

		// Token: 0x0401B151 RID: 110929
		protected UMaterialParameterCollection SceneInteractionMaterialParameterCollection;

		// Token: 0x0401B152 RID: 110930
		protected UMaterialParameterCollection UiShowBrightnessMaterialParameterCollection;

		// Token: 0x0401B153 RID: 110931
		protected UMaterialParameterCollection UiShowColorSettingMaterialParameterCollection;

		// Token: 0x0401B154 RID: 110932
		protected UMaterialParameterCollection EyesParameterMaterialParameterCollection;

		// Token: 0x0401B155 RID: 110933
		protected UMaterialParameterCollection GroundFogMaskMaterialParameterCollection;

		// Token: 0x0401B156 RID: 110934
		protected UMaterialParameterCollection SceneCaptureParameterCollection;

		// Token: 0x0401B157 RID: 110935
		protected UMaterialParameterCollection MpcForGameplayParameterCollection;

		// Token: 0x0401B158 RID: 110936
		protected PDA_ModelLensFlareConfig_C GlobalLensFlareConfig;

		// Token: 0x0401B159 RID: 110937
		protected PDA_DecalShadowConfig_C GlobalDecalShadowConfig;

		// Token: 0x0401B15A RID: 110938
		protected global::Vector PreviousCharacterPosition;

		// Token: 0x0401B15B RID: 110939
		protected global::Vector CurrentCharacterPosition;

		// Token: 0x0401B15C RID: 110940
		protected global::Vector PreviousCharacterPositionWithOffset;

		// Token: 0x0401B15D RID: 110941
		protected global::Vector CurrentCharacterPositionWithOffset;

		// Token: 0x0401B15E RID: 110942
		protected global::Vector CurrentCharacterWeaponPositionWithOffset;

		// Token: 0x0401B15F RID: 110943
		protected global::Vector CurrentCharacterForward;

		// Token: 0x0401B160 RID: 110944
		protected global::Vector CurrentCameraPosition;

		// Token: 0x0401B161 RID: 110945
		protected global::Vector CurrentCameraPositionWithOffset;

		// Token: 0x0401B162 RID: 110946
		protected global::Vector CurrentCameraForward;

		// Token: 0x0401B163 RID: 110947
		protected global::ECharMoveState? CurrentPlayerMoveState;

		// Token: 0x0401B164 RID: 110948
		protected double SceneTime;

		// Token: 0x0401B165 RID: 110949
		protected FLinearColor? TempColor;

		// Token: 0x0401B166 RID: 110950
		protected bool WriteTimeToCollection = true;

		// Token: 0x0401B167 RID: 110951
		protected bool IsInUiScene;

		// Token: 0x0401B168 RID: 110952
		protected UPhysicalMaterial GlobalFootstepMaterial;

		// Token: 0x0401B169 RID: 110953
		protected bool PlayerInGrass;

		// Token: 0x0401B16A RID: 110954
		protected UMaterialInterface EmptyMaterial;

		// Token: 0x0401B16B RID: 110955
		protected bool PlayerInCave;

		// Token: 0x0401B16C RID: 110956
		protected bool PlayerVoxelStateDirty = true;

		// Token: 0x0401B16D RID: 110957
		protected bool ForbidWeather;

		// Token: 0x0401B16E RID: 110958
		[Nullable(1)]
		protected global::Vector CachedGravityDirect = global::Vector.Create(0.0, 0.0, -1.0);

		// Token: 0x0401B16F RID: 110959
		private const int MinutesInHour = 60;

		// Token: 0x0401B170 RID: 110960
		private const float AudioParameterUpdateInterval = 1f;

		// Token: 0x0401B171 RID: 110961
		private double AudioParameterUpdateCounter;

		// Token: 0x0401B172 RID: 110962
		private float CachedAudioParameterRainIntensity;

		// Token: 0x0401B173 RID: 110963
		private float CachedAudioParameterSnowIntensity;

		// Token: 0x0401B174 RID: 110964
		private float CachedAudioParameterWindIntensity;
	}
}
