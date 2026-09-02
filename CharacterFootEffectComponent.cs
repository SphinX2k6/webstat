using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Season;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x0200303D RID: 12349
[NullableContext(1)]
[Nullable(0)]
public class CharacterFootEffectComponent : EntityComponent, IComponentDependency
{
	// Token: 0x17002211 RID: 8721
	// (get) Token: 0x06019448 RID: 103496 RVA: 0x0073FAD4 File Offset: 0x0073DCD4
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterAudioComponent),
				typeof(CharacterAnimationComponent),
				typeof(CharacterUnifiedStateComponent),
				typeof(CreatureDataComponent)
			};
		}
	}

	// Token: 0x06019449 RID: 103497 RVA: 0x0073FB28 File Offset: 0x0073DD28
	protected override bool OnInit()
	{
		base.OnInit();
		return true;
	}

	// Token: 0x0601944A RID: 103498 RVA: 0x0073FB34 File Offset: 0x0073DD34
	protected override bool OnStart()
	{
		base.OnStart();
		CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		CharacterAnimationComponent component2 = base.Entity.GetComponent<CharacterAnimationComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		CharacterAudioComponent component3 = base.Entity.GetComponent<CharacterAudioComponent>();
		if (component3 == null || !component3.Valid)
		{
			return false;
		}
		CreatureDataComponent component4 = base.Entity.GetComponent<CreatureDataComponent>();
		if (component4 == null || !component4.Valid)
		{
			return false;
		}
		CharacterUnifiedStateComponent component5 = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		if (component5 == null || !component5.Valid)
		{
			return false;
		}
		this.ActorComp = component;
		this.UnifiedStateComp = component5;
		TsBaseCharacter actor = this.ActorComp.Actor;
		if (actor.IsValid())
		{
			this.EnviInteractionComp = (actor.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) as UKuroEnviInteractionComponent);
		}
		this.FootTraceElement = UE.NewObject<UTraceSphereElement>(GlobalData.World, null, EObjectFlags.RF_NoFlags);
		this.FootTraceElement.bIsSingle = true;
		this.FootTraceElement.bTraceComplex = true;
		this.FootTraceElement.bIgnoreSelf = true;
		this.FootTraceElement.WorldContextObject = this.ActorComp.Actor;
		this.FootTraceElement.Radius = 10f;
		this.FootTraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		foreach (SFootprint sfootprint in DataTableUtil.GetDataTableAllRow<SFootprint>(EDataTable.Footprint))
		{
			CharacterFootEffectComponent.CharacterFootEffectConfig characterFootEffectConfig = new CharacterFootEffectComponent.CharacterFootEffectConfig();
			characterFootEffectConfig.EffectPath = sfootprint.Effect;
			characterFootEffectConfig.PriorToGlobal = sfootprint.PriorToGlobal;
			this.FootprintMap.Add(sfootprint.SurfaceType, characterFootEffectConfig);
		}
		List<SCharacterFootprint> dataTableAllRow = DataTableUtil.GetDataTableAllRow<SCharacterFootprint>(EDataTable.SCharacterFootPrint);
		for (int i = 0; i < dataTableAllRow.Count; i++)
		{
			SCharacterFootprint scharacterFootprint = dataTableAllRow[i];
			CharacterFootEffectComponent.CharacterSpecialFootEffectConfig characterSpecialFootEffectConfig = new CharacterFootEffectComponent.CharacterSpecialFootEffectConfig();
			characterSpecialFootEffectConfig.Tag = scharacterFootprint.Tag;
			characterSpecialFootEffectConfig.EffectPath = scharacterFootprint.Effect;
			characterSpecialFootEffectConfig.SortId = scharacterFootprint.SortID;
			characterSpecialFootEffectConfig.OverrideGlobalFootEffect = scharacterFootprint.OverrideGlobalFootEffect;
			characterSpecialFootEffectConfig.OverrideOtherCharacterFootEffect = scharacterFootprint.OverrideOtherCharacterFootEffect;
			int key = scharacterFootprint.Tag.TagId();
			this.CharacterFootprintMap.TryAdd(key, new List<CharacterFootEffectComponent.CharacterSpecialFootEffectConfig>());
			this.CharacterFootprintMap[key].Add(characterSpecialFootEffectConfig);
		}
		this.LeftFootprintDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAsyncTraceDelegate>(new Action<bool, UTraceBaseElement, double, double>(this.LeftFootprintHandle));
		this.RightFootprintDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAsyncTraceDelegate>(new Action<bool, UTraceBaseElement, double, double>(this.RightFootprintHandle));
		this.FootVoiceDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAsyncTraceDelegate>(new Action<bool, UTraceBaseElement, double, double>(this.FootVoiceHandle));
		this.SeasonFootstepDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAsyncTraceDelegate>(new Action<bool, UTraceBaseElement, double, double>(this.SeasonFootstepHandle));
		this.SeasonTraceElement = new UTraceLineElement();
		this.SeasonTraceElement.bIsSingle = true;
		this.SeasonTraceElement.bTraceComplex = false;
		this.SeasonTraceElement.bIgnoreSelf = true;
		this.SeasonTraceElement.WorldContextObject = this.ActorComp.Actor;
		this.SeasonTraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		return true;
	}

	// Token: 0x0601944B RID: 103499 RVA: 0x0073FE68 File Offset: 0x0073E068
	protected override bool OnEnd()
	{
		this.ActorComp = null;
		UTraceSphereElement footTraceElement = this.FootTraceElement;
		if (footTraceElement != null)
		{
			footTraceElement.Dispose();
		}
		this.FootTraceElement = null;
		this.FootprintMap.Clear();
		this.CharacterFootprintMap.Clear();
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, UTraceBaseElement, double, double>(this.LeftFootprintHandle));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, UTraceBaseElement, double, double>(this.RightFootprintHandle));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, UTraceBaseElement, double, double>(this.FootVoiceHandle));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, UTraceBaseElement, double, double>(this.SeasonFootstepHandle));
		this.LeftFootprintDelegate = null;
		this.RightFootprintDelegate = null;
		this.FootVoiceDelegate = null;
		this.SeasonFootstepDelegate = null;
		UTraceLineElement seasonTraceElement = this.SeasonTraceElement;
		if (seasonTraceElement != null)
		{
			seasonTraceElement.Dispose();
		}
		this.SeasonTraceElement = null;
		return true;
	}

	// Token: 0x0601944C RID: 103500 RVA: 0x0073FF23 File Offset: 0x0073E123
	protected override void OnTick(float delta)
	{
		this.UpdateEnvironmentInfoAtFootLocation();
	}

	// Token: 0x0601944D RID: 103501 RVA: 0x0073FF2C File Offset: 0x0073E12C
	public TraceHandle DetectFootGround(FName boneName, FAsyncTraceDelegate delg)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		bool flag;
		if (actorComp == null)
		{
			flag = (null != null);
		}
		else
		{
			TsBaseCharacter actor = actorComp.Actor;
			flag = (((actor != null) ? actor.Mesh : null) != null);
		}
		if (!flag)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Character, ELogAuthor.LRX, "CharacterFootEffectComponent's ActorComp or ActorComp.Actor or ActorComp.Actor.Mesh is null!", default(ReadOnlySpan<ValueTuple<string, object>>));
			throw new ArgumentNullException();
		}
		if (this.UnifiedStateComp == null)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Character, ELogAuthor.LRX, "CharacterFootEffectComponent's UnifiedStateComp is null!", default(ReadOnlySpan<ValueTuple<string, object>>));
			throw new ArgumentNullException();
		}
		this.LastDetectFootstepTime = Singleton<Time>.Instance.Now;
		Vector startLocation = this.StartLocation;
		FVectorDouble fvectorDouble = this.ActorComp.Actor.Mesh.D_GetSocketLocation(boneName);
		startLocation.FromUeVector(fvectorDouble);
		this.ActorComp.ActorUpProxy.Multiply((double)((this.UnifiedStateComp.MoveState == ECharMoveState.Sprint) ? -50 : -15), this.EndLocation);
		this.EndLocation.AdditionEqual(this.StartLocation);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.FootTraceElement, this.StartLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.FootTraceElement, this.EndLocation);
		return Singleton<TraceElementCommon>.Instance.AsyncSphereTrace(this.FootTraceElement, "CharacterFootEffectComponent_FootTrace", delg);
	}

	// Token: 0x0601944E RID: 103502 RVA: 0x0074005C File Offset: 0x0073E25C
	private ESeason? GetPlayerInsideSeason()
	{
		SeasonController instance = ControllerBase<SeasonController>.Instance;
		SeasonModel instance2 = ModelBase<SeasonModel>.Instance;
		if (instance2 != null && instance != null)
		{
			foreach (int areaId in instance2.ActiveAreaIds)
			{
				if (instance2.IsAreaActive(areaId))
				{
					return instance.GetSeasonByAreaId(areaId);
				}
			}
		}
		return null;
	}

	// Token: 0x0601944F RID: 103503 RVA: 0x007400DC File Offset: 0x0073E2DC
	public CharacterFootEffectComponent.EFootstepTexture GetFootstepTexture()
	{
		if (this.FootTraceElement == null)
		{
			throw new ArgumentNullException("FootTraceElement");
		}
		UTraceSphereElement footTraceElement = this.FootTraceElement;
		UKuroHitResult ukuroHitResult = (footTraceElement != null) ? footTraceElement.HitResult : null;
		if (ukuroHitResult == null || !ukuroHitResult.IsValid())
		{
			return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		TsBaseCharacter tsBaseCharacter = (actorComp != null) ? actorComp.Actor : null;
		if (tsBaseCharacter == null || !tsBaseCharacter.IsValid())
		{
			return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		}
		Vector tmpHitLocation = this.TmpHitLocation;
		bool flag = false;
		TWeakObjectPtr<UPhysicalMaterial>? tweakObjectPtr = (ukuroHitResult.PhysMaterials.Num() > 0) ? new TWeakObjectPtr<UPhysicalMaterial>?(ukuroHitResult.PhysMaterials.Get(0)) : null;
		CharRenderingComponent charRenderingComponent = tsBaseCharacter.CharRenderingComponent;
		if (charRenderingComponent != null && charRenderingComponent.GetInWater(2f))
		{
			flag = ((double)tsBaseCharacter.CharRenderingComponent.GetWaterHitLocationZ() > tmpHitLocation.Z - (double)this.FootTraceElement.Radius);
		}
		else
		{
			UPhysicalMaterial componentPhysicalMaterial = UKuroRenderingRuntimeBPPluginBPLibrary.GetComponentPhysicalMaterial(ukuroHitResult.Components.Get(0));
			if (componentPhysicalMaterial != null && componentPhysicalMaterial.IsValid() && componentPhysicalMaterial.GetName() == "WaterLightLand")
			{
				flag = true;
			}
		}
		if (flag)
		{
			return this.CheckWaterSurfaceType();
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(ukuroHitResult, 0, tmpHitLocation);
		FoliageAudioInfo foliageAudioInfo = Singleton<AudioUtils>.Instance.QueryFoliageAudioPhysicalMaterial(tmpHitLocation.ToUeVector(false), base.Entity);
		bool flag2 = false;
		CharacterFootEffectComponent.EFootstepTexture result = CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		if (foliageAudioInfo.IsHitFoliage && foliageAudioInfo.PhysicalMaterial != null)
		{
			tweakObjectPtr = new TWeakObjectPtr<UPhysicalMaterial>?(new TWeakObjectPtr<UPhysicalMaterial>(foliageAudioInfo.PhysicalMaterial));
		}
		if (this.GetPlayerInsideSeason().GetValueOrDefault() == ESeason.Winter && this.IsOnExposedSurface)
		{
			flag2 = true;
			result = CharacterFootEffectComponent.EFootstepTexture.SnowSurface;
		}
		else if (tweakObjectPtr != null && tweakObjectPtr.GetValueOrDefault().IsValid(false, false))
		{
			TEnumAsByte<EPhysicalSurface> surfaceType = tweakObjectPtr.Value.Get().SurfaceType;
			if (surfaceType == EPhysicalSurface.SurfaceType6 || surfaceType == EPhysicalSurface.SurfaceType14)
			{
				flag2 = true;
				result = CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
			}
			else
			{
				flag2 = Enum.TryParse<CharacterFootEffectComponent.EFootstepTexture>(UKuroAudioMaterialSettings.GetFootstepTextureName(surfaceType).ToString(), out result);
				if (!flag2)
				{
					result = CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
				}
			}
		}
		if (!flag2)
		{
			result = CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		}
		return result;
	}

	// Token: 0x06019450 RID: 103504 RVA: 0x00740308 File Offset: 0x0073E508
	public void PostFootstepVoice()
	{
		if (Singleton<Time>.Instance.Now - this.LastDetectFootstepTime < 150.0)
		{
			this.PostFootstepAudio();
			return;
		}
		this.LastDetectFootstepTime = Singleton<Time>.Instance.Now;
		if (this.ActorComp == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Character, ELogAuthor.LRX, "CharacterFootEffectComponent's ActorComp is null!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.StartLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.ActorComp.ActorUpProxy.Multiply((double)(-15f - this.ActorComp.ScaledHalfHeight), this.EndLocation);
		this.EndLocation.AdditionEqual(this.StartLocation);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.FootTraceElement, this.StartLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.FootTraceElement, this.EndLocation);
		this.TraceHandleFootVoice = Singleton<TraceElementCommon>.Instance.AsyncSphereTrace(this.FootTraceElement, "CharacterFootEffectComponent_FootTrace", this.FootVoiceDelegate);
		if (this.GetPlayerInsideSeason().GetValueOrDefault() == ESeason.Winter)
		{
			this.ActorComp.ActorUpProxy.Multiply(5000.0, this.TmpVector);
			this.TmpVector.AdditionEqual(this.ActorComp.ActorLocationProxy);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SeasonTraceElement, this.TmpVector);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SeasonTraceElement, this.EndLocation);
			this.TraceHandleSnowFootprint = Singleton<TraceElementCommon>.Instance.AsyncLineTrace(this.SeasonTraceElement, "CharacterFootEffectComponent_FootTrace", this.SeasonFootstepDelegate);
			return;
		}
		this.IsOnExposedSurface = false;
	}

	// Token: 0x06019451 RID: 103505 RVA: 0x007404B4 File Offset: 0x0073E6B4
	[return: Nullable(2)]
	private string GetFootprintEffectPath(UPhysicalMaterial localPhysMaterial)
	{
		UPhysicalMaterial getPhysMaterial = ModelBase<SceneTeamModel>.Instance.GetPhysMaterial;
		CharacterFootEffectComponent.CharacterFootEffectConfig characterFootEffectConfig;
		this.FootprintMap.TryGetValue(localPhysMaterial.SurfaceType, out characterFootEffectConfig);
		string text = null;
		if (getPhysMaterial != null)
		{
			CharacterFootEffectComponent.CharacterFootEffectConfig characterFootEffectConfig2;
			this.FootprintMap.TryGetValue(getPhysMaterial.SurfaceType, out characterFootEffectConfig2);
			if (characterFootEffectConfig2 != null && (characterFootEffectConfig == null || !characterFootEffectConfig.PriorToGlobal))
			{
				TSoftObjectPtr<UEffectModelBase> effectPath = characterFootEffectConfig2.EffectPath;
				text = ((effectPath != null) ? effectPath.ToAssetPathName() : null);
			}
		}
		if (string.IsNullOrEmpty(text) && characterFootEffectConfig != null)
		{
			TSoftObjectPtr<UEffectModelBase> effectPath2 = characterFootEffectConfig.EffectPath;
			text = ((effectPath2 != null) ? effectPath2.ToAssetPathName() : null);
		}
		return text;
	}

	// Token: 0x06019452 RID: 103506 RVA: 0x00740544 File Offset: 0x0073E744
	private unsafe List<string> GetFootprintEffectPaths(UPhysicalMaterial localPhysMaterial)
	{
		string footprintEffectPath = this.GetFootprintEffectPath(localPhysMaterial);
		CharacterFootEffectComponent.CharacterSpecialFootEffectConfig bestCharacterFootEffectConfig = this.GetBestCharacterFootEffectConfig();
		if (bestCharacterFootEffectConfig != null)
		{
			return this.ApplyCharacterEffectStrategy(bestCharacterFootEffectConfig, footprintEffectPath);
		}
		if (string.IsNullOrEmpty(footprintEffectPath))
		{
			return new List<string>();
		}
		int num = 1;
		List<string> list = new List<string>(num);
		CollectionsMarshal.SetCount<string>(list, num);
		Span<string> span = CollectionsMarshal.AsSpan<string>(list);
		int index = 0;
		*span[index] = footprintEffectPath;
		return list;
	}

	// Token: 0x06019453 RID: 103507 RVA: 0x007405A0 File Offset: 0x0073E7A0
	[NullableContext(2)]
	private CharacterFootEffectComponent.CharacterSpecialFootEffectConfig GetBestCharacterFootEffectConfig()
	{
		Entity entity = base.Entity;
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent == null)
		{
			return null;
		}
		CharacterFootEffectComponent.CharacterSpecialFootEffectConfig result = null;
		int num = int.MinValue;
		foreach (KeyValuePair<int, List<CharacterFootEffectComponent.CharacterSpecialFootEffectConfig>> keyValuePair in this.CharacterFootprintMap)
		{
			if (baseTagComponent.HasTag(keyValuePair.Key))
			{
				foreach (CharacterFootEffectComponent.CharacterSpecialFootEffectConfig characterSpecialFootEffectConfig in keyValuePair.Value)
				{
					if (characterSpecialFootEffectConfig.SortId > num)
					{
						num = characterSpecialFootEffectConfig.SortId;
						result = characterSpecialFootEffectConfig;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06019454 RID: 103508 RVA: 0x00740670 File Offset: 0x0073E870
	private List<string> ApplyCharacterEffectStrategy(CharacterFootEffectComponent.CharacterSpecialFootEffectConfig characterConfig, [Nullable(2)] string baseEffectPath)
	{
		TSoftObjectPtr<UEffectModelBase> effectPath = characterConfig.EffectPath;
		string text = (effectPath != null) ? effectPath.ToAssetPathName() : null;
		List<string> list = new List<string>();
		int overrideGlobalFootEffect = characterConfig.OverrideGlobalFootEffect;
		if (overrideGlobalFootEffect != 1)
		{
			if (overrideGlobalFootEffect == 2)
			{
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			else if (!string.IsNullOrEmpty(baseEffectPath))
			{
				list.Add(baseEffectPath);
			}
		}
		else
		{
			if (!string.IsNullOrEmpty(text))
			{
				list.Add(text);
			}
			if (!string.IsNullOrEmpty(baseEffectPath))
			{
				list.Add(baseEffectPath);
			}
		}
		return list;
	}

	// Token: 0x06019455 RID: 103509 RVA: 0x007406E8 File Offset: 0x0073E8E8
	private void CalculateFootprintTransform(UKuroHitResult hitResult, Vector baseLocation, Vector outLocation, Rotator outRotation)
	{
		if (this.ActorComp == null)
		{
			throw new ArgumentNullException("ActorComp");
		}
		this.ActorComp.ActorForwardProxy.Multiply(5.0, this.TmpVector);
		Singleton<TraceElementCommon>.Instance.GetImpactNormal(hitResult, 0, this.TmpVector2);
		Vector.VectorPlaneProject(this.TmpVector, this.TmpVector2, this.TmpVector3);
		this.TmpVector3.AdditionEqual(baseLocation);
		outLocation.DeepCopy(this.TmpVector3);
		Singleton<MathUtils>.Instance.LookRotationUpFirst(this.ActorComp.ActorForwardProxy, this.TmpVector2, outRotation);
	}

	// Token: 0x06019456 RID: 103510 RVA: 0x00740788 File Offset: 0x0073E988
	private void SpawnRainFootEffect(Vector location, Rotator rotation, [Nullable(2)] UPhysicalMaterial localPhysmaterial)
	{
		if (localPhysmaterial == null || this.EnviInteractionComp == null || this.ActorComp == null || !this.EnviInteractionComp.bUpdateRainOcclusion)
		{
			return;
		}
		if (localPhysmaterial.SurfaceType != EPhysicalSurface.SurfaceType10 && this.EnviInteractionComp.GetRainWalkOcclusionParam() < 0.9f && !this.EnviInteractionComp.GetEnviInteractionData().bInWater)
		{
			Vector tmpVector = this.TmpVector3;
			TsBaseCharacter tsBaseCharacter = this.ActorComp.Owner as TsBaseCharacter;
			if (tsBaseCharacter != null && tsBaseCharacter != null && tsBaseCharacter.Mesh != null)
			{
				tmpVector.Z = tsBaseCharacter.Mesh.D_K2_GetComponentLocation().Z;
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FRotator frotator = this.TmpRotator.ToUeRotator();
			FVectorDouble fvectorDouble = this.TmpVector3.ToUeVector(false);
			FVectorDouble fvectorDouble2 = Vector.OneVectorProxy.ToUeVector(false);
			FVector fvector = fvectorDouble2;
			FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector));
			instance.SpawnUnloopedEffect(world, ftransformDouble, "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_FX_SI3_Water_Step01.DA_FX_SI3_Water_Step01", "[SceneCharacterFootprintEffect.SpawnRainFootEffect]", null, global::EEffectType.Scene, null, null, null, false, false);
		}
	}

	// Token: 0x06019457 RID: 103511 RVA: 0x00740898 File Offset: 0x0073EA98
	[NullableContext(2)]
	private void TriggerFootprintEffectInternal(UKuroHitResult hitResult)
	{
		if (hitResult == null || !hitResult.bBlockingHit)
		{
			return;
		}
		if (Singleton<Time>.Instance.Now - this.LastSpawnFootprintTime < 200.0)
		{
			return;
		}
		Vector tmpHitLocation = this.TmpHitLocation;
		Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, tmpHitLocation);
		if (Vector.DistSquared(tmpHitLocation, this.LastSpawnFootprintLocation) < 500.0)
		{
			return;
		}
		if (hitResult.PhysMaterials == null || hitResult.PhysMaterials.Num() <= 0)
		{
			return;
		}
		TWeakObjectPtr<UPhysicalMaterial> weak = hitResult.PhysMaterials.Get(0);
		this.CalculateFootprintTransform(hitResult, tmpHitLocation, this.TmpVector3, this.TmpRotator);
		this.SpawnRainFootEffect(this.TmpVector3, this.TmpRotator, weak);
		this.LastSpawnFootprintTime = Singleton<Time>.Instance.Now;
		this.LastSpawnFootprintLocation.DeepCopy(tmpHitLocation);
	}

	// Token: 0x06019458 RID: 103512 RVA: 0x0074096C File Offset: 0x0073EB6C
	public void TriggerFootprint(bool isLeftFoot)
	{
		if (this.FootTraceElement == null || this.FootTraceElement.HitResult == null || !this.FootTraceElement.HitResult.bBlockingHit || this.FootTraceElement.HitResult.GetHitCount() == 0)
		{
			return;
		}
		if (Singleton<Time>.Instance.Now - this.LastSpawnFootprintTime < 200.0)
		{
			return;
		}
		if (this.ActorComp == null)
		{
			throw new ArgumentNullException("ActorComp");
		}
		TsBaseCharacter actor = this.ActorComp.Actor;
		if (actor == null)
		{
			throw new ArgumentNullException("ActorComp.Actor");
		}
		USkeletalMeshComponent mesh = actor.Mesh;
		if (mesh == null)
		{
			throw new ArgumentNullException("ActorComp.Actor.Mesh");
		}
		if (isLeftFoot)
		{
			Vector footLocation = this.FootLocation;
			FVectorDouble fvectorDouble = mesh.D_GetSocketLocation(CharacterFootEffectComponent.LeftFootSocketName);
			footLocation.FromUeVector(fvectorDouble);
		}
		else
		{
			Vector footLocation2 = this.FootLocation;
			FVectorDouble fvectorDouble = mesh.D_GetSocketLocation(CharacterFootEffectComponent.RightFootSocketName);
			footLocation2.FromUeVector(fvectorDouble);
		}
		if (Vector.DistSquared(this.FootLocation, this.LastSpawnFootprintLocation) < 500.0)
		{
			return;
		}
		UPhysicalMaterial componentPhysicalMaterial = UKuroRenderingRuntimeBPPluginBPLibrary.GetComponentPhysicalMaterial(this.FootTraceElement.HitResult.Components.Get(0));
		TArray<TWeakObjectPtr<UPhysicalMaterial>> physMaterials = this.FootTraceElement.HitResult.PhysMaterials;
		TWeakObjectPtr<UPhysicalMaterial>? tweakObjectPtr = (physMaterials != null) ? new TWeakObjectPtr<UPhysicalMaterial>?(physMaterials.Get(0)) : null;
		List<string> list = new List<string>();
		if (componentPhysicalMaterial != null)
		{
			list = this.GetFootprintEffectPaths(componentPhysicalMaterial);
		}
		if (tweakObjectPtr != null)
		{
			TWeakObjectPtr<UPhysicalMaterial>? tweakObjectPtr2 = tweakObjectPtr;
			foreach (string item in this.GetFootprintEffectPaths((tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null))
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		this.CalculateFootprintTransform(this.FootTraceElement.HitResult, this.FootLocation, this.TmpVector3, this.TmpRotator);
		for (int i = 0; i < list.Count; i++)
		{
			string text = list[i];
			if (!string.IsNullOrEmpty(text))
			{
				string text2;
				if (list.Count != 1)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(45, 1);
					defaultInterpolatedStringHandler.AppendLiteral("[SceneCharacterFootprintEffect.SpawnEffect.$");
					defaultInterpolatedStringHandler.AppendFormatted<int>(i);
					defaultInterpolatedStringHandler.AppendLiteral("]");
					text2 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					text2 = "[SceneCharacterFootprintEffect.SpawnEffect]";
				}
				string reason = text2;
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FRotator frotator = this.TmpRotator.ToUeRotator();
				FVectorDouble fvectorDouble = this.TmpVector3.ToUeVector(false);
				FVectorDouble fvectorDouble2 = Vector.OneVectorProxy.ToUeVector(false);
				FVector fvector = fvectorDouble2;
				FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector));
				instance.SpawnUnloopedEffect(world, ftransformDouble, text, reason, null, global::EEffectType.Scene, null, null, null, false, false);
			}
		}
		if (isLeftFoot)
		{
			if (this.LeftFootprintDelegate == null)
			{
				throw new ArgumentNullException("LeftFootprintDelegate");
			}
			this.TraceHandleLeftFootprint = this.DetectFootGround(CharacterFootEffectComponent.LeftFootSocketName, this.LeftFootprintDelegate);
			return;
		}
		else
		{
			if (this.RightFootprintDelegate == null)
			{
				throw new ArgumentNullException("RightFootprintDelegate");
			}
			this.TraceHandleRightFootprint = this.DetectFootGround(CharacterFootEffectComponent.RightFootSocketName, this.RightFootprintDelegate);
			return;
		}
	}

	// Token: 0x06019459 RID: 103513 RVA: 0x00740C8C File Offset: 0x0073EE8C
	private unsafe void LeftFootprintHandle(bool hitResult, UTraceBaseElement element, double frame, double index)
	{
		if (this.TraceHandleLeftFootprint != null && frame < (double)this.TraceHandleLeftFootprint.Frame)
		{
			return;
		}
		if (this.TraceHandleLeftFootprint != null && frame == (double)this.TraceHandleLeftFootprint.Frame && index < (double)this.TraceHandleLeftFootprint.Index)
		{
			return;
		}
		if (!hitResult)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Detect Footprint Failed";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "location";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? actorComp.ActorLocationProxy : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("start", this.StartLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("end", this.EndLocation);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(element.HitResult, 0, this.TmpHitLocation);
		this.TriggerFootprintEffectInternal(element.HitResult);
		if (hitResult)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.OnCharFootOnTheGround, true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnCharFootOnTheGround, true);
		}
		else
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "Detect TriggerEffect Failed";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item2 = "location";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ptr2 = new ValueTuple<string, object>(item2, (actorComp2 != null) ? actorComp2.ActorLocationProxy : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("start", this.StartLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("end", this.EndLocation);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		ControllerBase<WorldController>.Instance.EnvironmentInfoUpdate(this.TmpHitLocation.ToUeVector(false), this.ActorComp.IsRoleAndCtrlByMe, false);
	}

	// Token: 0x0601945A RID: 103514 RVA: 0x00740E60 File Offset: 0x0073F060
	private unsafe void RightFootprintHandle(bool hitResult, UTraceBaseElement element, double frame, double index)
	{
		if (this.TraceHandleRightFootprint != null && frame < (double)this.TraceHandleRightFootprint.Frame)
		{
			return;
		}
		if (this.TraceHandleRightFootprint != null && frame == (double)this.TraceHandleRightFootprint.Frame && index < (double)this.TraceHandleRightFootprint.Index)
		{
			return;
		}
		if (!hitResult)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Detect Footprint Failed";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "location";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? actorComp.ActorLocationProxy : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("start", this.StartLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("end", this.EndLocation);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(element.HitResult, 0, this.TmpHitLocation);
		this.TriggerFootprintEffectInternal(element.HitResult);
		if (hitResult)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.OnCharFootOnTheGround, false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnCharFootOnTheGround, false);
		}
		else
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "Detect TriggerEffect Failed";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item2 = "location";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ptr2 = new ValueTuple<string, object>(item2, (actorComp2 != null) ? actorComp2.ActorLocationProxy : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("start", this.StartLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("end", this.EndLocation);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		if (this.ActorComp == null)
		{
			throw new ArgumentNullException("ActorComp");
		}
		ControllerBase<WorldController>.Instance.EnvironmentInfoUpdate(this.TmpHitLocation.ToUeVector(false), this.ActorComp.IsRoleAndCtrlByMe, false);
	}

	// Token: 0x0601945B RID: 103515 RVA: 0x00741048 File Offset: 0x0073F248
	private unsafe void FootVoiceHandle(bool hitResult, UTraceBaseElement element, double frame, double index)
	{
		if (this.TraceHandleFootVoice != null && frame < (double)this.TraceHandleFootVoice.Frame)
		{
			this.PostFootstepAudio();
			return;
		}
		if (this.TraceHandleFootVoice != null && frame == (double)this.TraceHandleFootVoice.Frame && index < (double)this.TraceHandleFootVoice.Index)
		{
			this.PostFootstepAudio();
			return;
		}
		if (!hitResult)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Detect Footprint Failed";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "location";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? actorComp.ActorLocationProxy : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("start", this.StartLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("end", this.EndLocation);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (((element != null) ? element.HitResult : null) != null)
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(element.HitResult, 0, this.TmpHitLocation);
		}
		this.FootVoiceHitLocation.DeepCopy(this.TmpHitLocation);
		this.PostFootstepAudio();
	}

	// Token: 0x0601945C RID: 103516 RVA: 0x0074116C File Offset: 0x0073F36C
	private void SeasonFootstepHandle(bool hitResult, UTraceBaseElement element, double frame, double index)
	{
		if (this.TraceHandleSnowFootprint != null && frame < (double)this.TraceHandleSnowFootprint.Frame)
		{
			return;
		}
		if (this.TraceHandleSnowFootprint != null && frame == (double)this.TraceHandleSnowFootprint.Frame && index < (double)this.TraceHandleSnowFootprint.Index)
		{
			return;
		}
		if (hitResult)
		{
			bool flag;
			if (element == null)
			{
				flag = true;
			}
			else
			{
				UKuroHitResult hitResult2 = element.HitResult;
				flag = !((hitResult2 != null) ? new bool?(hitResult2.bBlockingHit) : null).GetValueOrDefault();
			}
			if (!flag)
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(element.HitResult, 0, this.SnowHitLocation);
				bool flag2 = false;
				if (element.HitResult.Actors.Num() > 0)
				{
					TWeakObjectPtr<AActor> tweakObjectPtr = element.HitResult.Actors.Get(0);
					ULevel ulevel = tweakObjectPtr.IsValid(false, false) ? tweakObjectPtr.Get().GetLevel() : null;
					if (ulevel != null && !ulevel.bIsPartitioned)
					{
						flag2 = true;
					}
				}
				double num = Math.Abs(this.SnowHitLocation.Z - this.FootVoiceHitLocation.Z);
				this.IsOnExposedSurface = (num <= 50.0 && !flag2);
				return;
			}
		}
		this.IsOnExposedSurface = true;
	}

	// Token: 0x0601945D RID: 103517 RVA: 0x00741298 File Offset: 0x0073F498
	private void PostFootstepAudio()
	{
		CharacterFootEffectComponent.EFootstepTexture footstepTexture = this.GetFootstepTexture();
		RoleAudioComponent component = base.Entity.GetComponent<RoleAudioComponent>();
		if (component == null)
		{
			return;
		}
		component.PostFootstepAudio(footstepTexture);
	}

	// Token: 0x0601945E RID: 103518 RVA: 0x007412C4 File Offset: 0x0073F4C4
	private void UpdateEnvironmentInfoAtFootLocation()
	{
		if (ModelBase<TeleportModel>.Instance.IsTeleport || !this.ActorComp.EnableVoxelDetection)
		{
			return;
		}
		if (this.ActorComp == null || this.UnifiedStateComp == null)
		{
			return;
		}
		if (this.UnifiedStateComp.MoveState == ECharMoveState.Stand)
		{
			return;
		}
		ControllerBase<WorldController>.Instance.EnvironmentInfoUpdate(this.ActorComp.ActorLocation, this.ActorComp.IsRoleAndCtrlByMe, false);
	}

	// Token: 0x0601945F RID: 103519 RVA: 0x00741330 File Offset: 0x0073F530
	private CharacterFootEffectComponent.EFootstepTexture CheckWaterSurfaceType()
	{
		if (this.ActorComp == null)
		{
			return CharacterFootEffectComponent.EFootstepTexture.WaterSurface;
		}
		AActor owner = this.ActorComp.Owner;
		UKuroEnviInteractionComponent ukuroEnviInteractionComponent = ((owner != null) ? owner.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) : null) as UKuroEnviInteractionComponent;
		if (ukuroEnviInteractionComponent != null && this.ActorComp.Owner != null)
		{
			UKuroInteractionEffectSystem kuroInteractionEffectSystem = UKuroInteractionEffectSystem.GetKuroInteractionEffectSystem(this.ActorComp.Owner.GetWorld());
			if (kuroInteractionEffectSystem != null)
			{
				TWeakObjectPtr<UKuroEnviInteractionComponent> key = new TWeakObjectPtr<UKuroEnviInteractionComponent>(ukuroEnviInteractionComponent);
				FKuroEnviInteractionData fkuroEnviInteractionData = kuroInteractionEffectSystem.EnviInteractionCollections.Get(key);
				if (fkuroEnviInteractionData != null && fkuroEnviInteractionData.WaterType == 1)
				{
					return CharacterFootEffectComponent.EFootstepTexture.VoicelessSurface;
				}
			}
		}
		return CharacterFootEffectComponent.EFootstepTexture.WaterSurface;
	}

	// Token: 0x06019460 RID: 103520 RVA: 0x007413C0 File Offset: 0x0073F5C0
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterFootEffectComponent characterFootEffectComponent = (CharacterFootEffectComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterFootEffectComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComp"))
		{
			if (characterFootEffectComponent.UnifiedStateComp == null)
			{
				this.UnifiedStateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComp), "UnifiedStateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EnviInteractionComp"))
		{
			if (characterFootEffectComponent.EnviInteractionComp == null)
			{
				this.EnviInteractionComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroEnviInteractionComponent>(this.EnviInteractionComp), "EnviInteractionComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FootTraceElement"))
		{
			if (characterFootEffectComponent.FootTraceElement == null)
			{
				this.FootTraceElement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.FootTraceElement), "FootTraceElement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StartLocation") && characterFootEffectComponent.StartLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.StartLocation), "StartLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("EndLocation") && characterFootEffectComponent.EndLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.EndLocation), "EndLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpHitLocation") && characterFootEffectComponent.TmpHitLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpHitLocation), "TmpHitLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector") && characterFootEffectComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector), "TmpVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector2") && characterFootEffectComponent.TmpVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector2), "TmpVector2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector3") && characterFootEffectComponent.TmpVector3 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector3), "TmpVector3"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpRotator") && characterFootEffectComponent.TmpRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TmpRotator), "TmpRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("FootLocation") && characterFootEffectComponent.FootLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.FootLocation), "FootLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("StatTraceDelegate"))
		{
			if (characterFootEffectComponent.StatTraceDelegate == null)
			{
				this.StatTraceDelegate = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatTraceDelegate), "StatTraceDelegate"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StatGetFootTexture"))
		{
			if (characterFootEffectComponent.StatGetFootTexture == null)
			{
				this.StatGetFootTexture = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatGetFootTexture), "StatGetFootTexture"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StatPostFootsteupAudio"))
		{
			if (characterFootEffectComponent.StatPostFootsteupAudio == null)
			{
				this.StatPostFootsteupAudio = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatPostFootsteupAudio), "StatPostFootsteupAudio"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FootprintMap") && characterFootEffectComponent.FootprintMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EPhysicalSurface, CharacterFootEffectComponent.CharacterFootEffectConfig>>(this.FootprintMap), "FootprintMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CharacterFootprintMap") && characterFootEffectComponent.CharacterFootprintMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, List<CharacterFootEffectComponent.CharacterSpecialFootEffectConfig>>>(this.CharacterFootprintMap), "CharacterFootprintMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LastSpawnFootprintTime"))
		{
			this.LastSpawnFootprintTime = characterFootEffectComponent.LastSpawnFootprintTime;
		}
		if (base.CanResetComponentProperty("LastDetectFootstepTime"))
		{
			this.LastDetectFootstepTime = characterFootEffectComponent.LastDetectFootstepTime;
		}
		if (base.CanResetComponentProperty("LastSpawnFootprintLocation") && characterFootEffectComponent.LastSpawnFootprintLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastSpawnFootprintLocation), "LastSpawnFootprintLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LeftHitLocation") && characterFootEffectComponent.LeftHitLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LeftHitLocation), "LeftHitLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("RightHitLocation") && characterFootEffectComponent.RightHitLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.RightHitLocation), "RightHitLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LeftFootprintDelegate"))
		{
			if (characterFootEffectComponent.LeftFootprintDelegate == null)
			{
				this.LeftFootprintDelegate = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FAsyncTraceDelegate>(this.LeftFootprintDelegate), "LeftFootprintDelegate"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RightFootprintDelegate"))
		{
			if (characterFootEffectComponent.RightFootprintDelegate == null)
			{
				this.RightFootprintDelegate = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FAsyncTraceDelegate>(this.RightFootprintDelegate), "RightFootprintDelegate"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FootVoiceDelegate"))
		{
			if (characterFootEffectComponent.FootVoiceDelegate == null)
			{
				this.FootVoiceDelegate = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FAsyncTraceDelegate>(this.FootVoiceDelegate), "FootVoiceDelegate"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SeasonFootstepDelegate"))
		{
			if (characterFootEffectComponent.SeasonFootstepDelegate == null)
			{
				this.SeasonFootstepDelegate = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FAsyncTraceDelegate>(this.SeasonFootstepDelegate), "SeasonFootstepDelegate"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SeasonTraceElement"))
		{
			if (characterFootEffectComponent.SeasonTraceElement == null)
			{
				this.SeasonTraceElement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceLineElement>(this.SeasonTraceElement), "SeasonTraceElement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsOnExposedSurface"))
		{
			this.IsOnExposedSurface = characterFootEffectComponent.IsOnExposedSurface;
		}
		if (base.CanResetComponentProperty("SnowHitLocation") && characterFootEffectComponent.SnowHitLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.SnowHitLocation), "SnowHitLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("FootVoiceHitLocation") && characterFootEffectComponent.FootVoiceHitLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.FootVoiceHitLocation), "FootVoiceHitLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterFootEffectComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsLeftFootOnGround"))
		{
			this.IsLeftFootOnGround = characterFootEffectComponent.IsLeftFootOnGround;
		}
		if (base.CanResetComponentProperty("IsRightFootOnGround"))
		{
			this.IsRightFootOnGround = characterFootEffectComponent.IsRightFootOnGround;
		}
		if (base.CanResetComponentProperty("IsTriggerEffect"))
		{
			this.IsTriggerEffect = characterFootEffectComponent.IsTriggerEffect;
		}
		if (base.CanResetComponentProperty("IsLeftFootHit"))
		{
			this.IsLeftFootHit = characterFootEffectComponent.IsLeftFootHit;
		}
		if (base.CanResetComponentProperty("IsRightFootHit"))
		{
			this.IsRightFootHit = characterFootEffectComponent.IsRightFootHit;
		}
		if (base.CanResetComponentProperty("TraceHandleLeftFootprint"))
		{
			if (characterFootEffectComponent.TraceHandleLeftFootprint == null)
			{
				this.TraceHandleLeftFootprint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TraceHandle>(this.TraceHandleLeftFootprint), "TraceHandleLeftFootprint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TraceHandleRightFootprint"))
		{
			if (characterFootEffectComponent.TraceHandleRightFootprint == null)
			{
				this.TraceHandleRightFootprint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TraceHandle>(this.TraceHandleRightFootprint), "TraceHandleRightFootprint"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TraceHandleFootVoice"))
		{
			if (characterFootEffectComponent.TraceHandleFootVoice == null)
			{
				this.TraceHandleFootVoice = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TraceHandle>(this.TraceHandleFootVoice), "TraceHandleFootVoice"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TraceHandleSnowFootprint"))
		{
			if (characterFootEffectComponent.TraceHandleSnowFootprint == null)
			{
				this.TraceHandleSnowFootprint = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TraceHandle>(this.TraceHandleSnowFootprint), "TraceHandleSnowFootprint"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C6E9 RID: 50921
	private const string PROFILE_KEY = "CharacterFootEffectComponent_FootTrace";

	// Token: 0x0400C6EA RID: 50922
	private const int FOOTPRINT_DETECT_DURATION = 150;

	// Token: 0x0400C6EB RID: 50923
	private const int FOOTPRINT_SPAWN_DURATION = 200;

	// Token: 0x0400C6EC RID: 50924
	private const int FOOTPRINT_SPAWN_MIN_DISTANCE_SQUARED = 500;

	// Token: 0x0400C6ED RID: 50925
	private const int SPRINT_FOOTEFFECT_DETECT_HEIGHT = 50;

	// Token: 0x0400C6EE RID: 50926
	private const int NORMAL_FOOTEFFECT_DETECT_HEIGHT = 15;

	// Token: 0x0400C6EF RID: 50927
	private const int MATERIAL_ID_WAT = 6;

	// Token: 0x0400C6F0 RID: 50928
	private const int MATERIAL_ID_SHR = 14;

	// Token: 0x0400C6F1 RID: 50929
	private const int FOOTPRINT_FORWARD_OFFSET = 5;

	// Token: 0x0400C6F2 RID: 50930
	private const int SNOW_DETECT_SKY_HEIGHT = 5000;

	// Token: 0x0400C6F3 RID: 50931
	private const int SNOW_FOOTPRINT_EPSILON = 50;

	// Token: 0x0400C6F4 RID: 50932
	private const string RAIN_FOOT_EFFCT = "/Game/Aki/Effect/DataAsset/Niagara/Common/Water/DA_FX_SI3_Water_Step01.DA_FX_SI3_Water_Step01";

	// Token: 0x0400C6F5 RID: 50933
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C6F6 RID: 50934
	[Nullable(2)]
	private CharacterUnifiedStateComponent UnifiedStateComp;

	// Token: 0x0400C6F7 RID: 50935
	[Nullable(2)]
	private UKuroEnviInteractionComponent EnviInteractionComp;

	// Token: 0x0400C6F8 RID: 50936
	[Nullable(2)]
	private UTraceSphereElement FootTraceElement;

	// Token: 0x0400C6F9 RID: 50937
	private readonly Vector StartLocation = Vector.Create();

	// Token: 0x0400C6FA RID: 50938
	private readonly Vector EndLocation = Vector.Create();

	// Token: 0x0400C6FB RID: 50939
	private readonly Vector TmpHitLocation = Vector.Create();

	// Token: 0x0400C6FC RID: 50940
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400C6FD RID: 50941
	private readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400C6FE RID: 50942
	private readonly Vector TmpVector3 = Vector.Create();

	// Token: 0x0400C6FF RID: 50943
	private readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x0400C700 RID: 50944
	private readonly Vector FootLocation = Vector.Create();

	// Token: 0x0400C701 RID: 50945
	private Stat StatTraceDelegate = Stat.Create("CharacterFootEffectComponent.AsyncTraceDelegate", "", "");

	// Token: 0x0400C702 RID: 50946
	private Stat StatGetFootTexture = Stat.Create("CharacterFootEffectComponent.GetFootTexture", "", "");

	// Token: 0x0400C703 RID: 50947
	private Stat StatPostFootsteupAudio = Stat.Create("CharacterFootEffectComponent.PostFootStepAudio", "", "");

	// Token: 0x0400C704 RID: 50948
	private readonly Dictionary<EPhysicalSurface, CharacterFootEffectComponent.CharacterFootEffectConfig> FootprintMap = new Dictionary<EPhysicalSurface, CharacterFootEffectComponent.CharacterFootEffectConfig>();

	// Token: 0x0400C705 RID: 50949
	private readonly Dictionary<int, List<CharacterFootEffectComponent.CharacterSpecialFootEffectConfig>> CharacterFootprintMap = new Dictionary<int, List<CharacterFootEffectComponent.CharacterSpecialFootEffectConfig>>();

	// Token: 0x0400C706 RID: 50950
	private double LastSpawnFootprintTime;

	// Token: 0x0400C707 RID: 50951
	private double LastDetectFootstepTime;

	// Token: 0x0400C708 RID: 50952
	private readonly Vector LastSpawnFootprintLocation = Vector.Create();

	// Token: 0x0400C709 RID: 50953
	private readonly Vector LeftHitLocation = Vector.Create();

	// Token: 0x0400C70A RID: 50954
	private readonly Vector RightHitLocation = Vector.Create();

	// Token: 0x0400C70B RID: 50955
	public static readonly FName LeftFootSocketName = new FName("Bip001LFoot");

	// Token: 0x0400C70C RID: 50956
	public static readonly FName RightFootSocketName = new FName("Bip001RFoot");

	// Token: 0x0400C70D RID: 50957
	[Nullable(2)]
	private FAsyncTraceDelegate LeftFootprintDelegate;

	// Token: 0x0400C70E RID: 50958
	[Nullable(2)]
	private FAsyncTraceDelegate RightFootprintDelegate;

	// Token: 0x0400C70F RID: 50959
	[Nullable(2)]
	private FAsyncTraceDelegate FootVoiceDelegate;

	// Token: 0x0400C710 RID: 50960
	[Nullable(2)]
	private FAsyncTraceDelegate SeasonFootstepDelegate;

	// Token: 0x0400C711 RID: 50961
	[Nullable(2)]
	private UTraceLineElement SeasonTraceElement;

	// Token: 0x0400C712 RID: 50962
	public bool IsOnExposedSurface = true;

	// Token: 0x0400C713 RID: 50963
	private readonly Vector SnowHitLocation = Vector.Create();

	// Token: 0x0400C714 RID: 50964
	private readonly Vector FootVoiceHitLocation = Vector.Create();

	// Token: 0x0400C715 RID: 50965
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400C716 RID: 50966
	private bool IsLeftFootOnGround;

	// Token: 0x0400C717 RID: 50967
	private bool IsRightFootOnGround;

	// Token: 0x0400C718 RID: 50968
	private bool IsTriggerEffect;

	// Token: 0x0400C719 RID: 50969
	private bool IsLeftFootHit;

	// Token: 0x0400C71A RID: 50970
	private bool IsRightFootHit;

	// Token: 0x0400C71B RID: 50971
	public static readonly FName FootstepCurveName = new FName("Foot_voice");

	// Token: 0x0400C71C RID: 50972
	[Nullable(2)]
	private TraceHandle TraceHandleLeftFootprint;

	// Token: 0x0400C71D RID: 50973
	[Nullable(2)]
	private TraceHandle TraceHandleRightFootprint;

	// Token: 0x0400C71E RID: 50974
	[Nullable(2)]
	private TraceHandle TraceHandleFootVoice;

	// Token: 0x0400C71F RID: 50975
	[Nullable(2)]
	private TraceHandle TraceHandleSnowFootprint;

	// Token: 0x0200936D RID: 37741
	[NullableContext(0)]
	[EnumExtensions]
	public enum EFootstepTexture
	{
		// Token: 0x04031115 RID: 200981
		[EnumStringMember("DirtSurface")]
		DirtSurface,
		// Token: 0x04031116 RID: 200982
		[EnumStringMember("ConcreteSurface")]
		ConcreteSurface,
		// Token: 0x04031117 RID: 200983
		[EnumStringMember("GrassSurface")]
		GrassSurface,
		// Token: 0x04031118 RID: 200984
		[EnumStringMember("MetalSheetSurface")]
		MetalSheetSurface,
		// Token: 0x04031119 RID: 200985
		[EnumStringMember("MetalHardSurface")]
		MetalHardSurface,
		// Token: 0x0403111A RID: 200986
		[EnumStringMember("WoodFloorSurface")]
		WoodFloorSurface,
		// Token: 0x0403111B RID: 200987
		[EnumStringMember("WaterSurface")]
		WaterSurface,
		// Token: 0x0403111C RID: 200988
		[EnumStringMember("FabricSurface")]
		FabricSurface,
		// Token: 0x0403111D RID: 200989
		[EnumStringMember("SandSurface")]
		SandSurface,
		// Token: 0x0403111E RID: 200990
		[EnumStringMember("IceSurface")]
		IceSurface,
		// Token: 0x0403111F RID: 200991
		[EnumStringMember("SnowSurface")]
		SnowSurface,
		// Token: 0x04031120 RID: 200992
		[EnumStringMember("VoicelessSurface")]
		VoicelessSurface
	}

	// Token: 0x0200936E RID: 37742
	[NullableContext(0)]
	public class CharacterFootEffectConfig
	{
		// Token: 0x04031121 RID: 200993
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TSoftObjectPtr<UEffectModelBase> EffectPath;

		// Token: 0x04031122 RID: 200994
		public bool PriorToGlobal;
	}

	// Token: 0x0200936F RID: 37743
	[NullableContext(0)]
	public class CharacterSpecialFootEffectConfig
	{
		// Token: 0x04031123 RID: 200995
		public FGameplayTag Tag;

		// Token: 0x04031124 RID: 200996
		public int SortId;

		// Token: 0x04031125 RID: 200997
		public int OverrideGlobalFootEffect;

		// Token: 0x04031126 RID: 200998
		public int OverrideOtherCharacterFootEffect;

		// Token: 0x04031127 RID: 200999
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TSoftObjectPtr<UEffectModelBase> EffectPath;
	}
}
