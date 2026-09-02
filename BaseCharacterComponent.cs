using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x0200300B RID: 12299
[NullableContext(1)]
[Nullable(0)]
public class BaseCharacterComponent : BaseActorComponent
{
	// Token: 0x170021C7 RID: 8647
	// (get) Token: 0x0601910C RID: 102668 RVA: 0x0071E5B6 File Offset: 0x0071C7B6
	public TsBaseCharacter Actor
	{
		get
		{
			return this.ActorInternal as TsBaseCharacter;
		}
	}

	// Token: 0x170021C8 RID: 8648
	// (get) Token: 0x0601910D RID: 102669 RVA: 0x0071E5C3 File Offset: 0x0071C7C3
	[Nullable(2)]
	public override USkeletalMeshComponent SkeletalMesh
	{
		[NullableContext(2)]
		get
		{
			return this.Actor.Mesh;
		}
	}

	// Token: 0x0601910E RID: 102670 RVA: 0x0071E5D0 File Offset: 0x0071C7D0
	protected void SetCamp(TsBaseCharacter actor)
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if ((component == null || component.GetEntityType() != EEntityType.Npc) && (component == null || component.GetEntityType() != EEntityType.Monster) && (component == null || component.GetEntityType() != EEntityType.Vision) && (component == null || component.GetEntityType() != EEntityType.Animal))
		{
			return;
		}
		ECamp? ecamp = (component != null) ? new ECamp?(component.GetEntityCamp()) : null;
		if (ecamp == null)
		{
			ECamp? ecamp2 = ecamp;
			ECamp ecamp3 = ECamp.Player;
			if (!(ecamp2.GetValueOrDefault() == ecamp3 & ecamp2 != null))
			{
				return;
			}
		}
		if (actor != null)
		{
			actor.Camp = ecamp.Value;
		}
	}

	// Token: 0x0601910F RID: 102671 RVA: 0x0071E688 File Offset: 0x0071C888
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public unsafe ValueTuple<bool, global::Vector> FixActorLocation(float offset, bool showLog = true, [Nullable(2)] global::Vector target = null, string context = "unknown.FixActorLocation", bool bTryTwice = true, bool ignoreHalfHeight = false)
	{
		UCapsuleComponent capsuleComponent = this.Actor.CapsuleComponent;
		if (capsuleComponent == null || !capsuleComponent.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[CharacterActorComponent.FixBornLocation] capsule为空。";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Context", context);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return new ValueTuple<bool, global::Vector>(false, null);
		}
		global::Vector vector = target ?? this.ActorLocationProxy;
		global::Vector commonStartLocation = ModelBase<TraceElementModel>.Instance.CommonStartLocation;
		global::Vector commonEndLocation = ModelBase<TraceElementModel>.Instance.CommonEndLocation;
		if (ignoreHalfHeight)
		{
			base.ActorUpProxy.Multiply((double)base.ScaledRadius, commonStartLocation);
			base.ActorUpProxy.Multiply((double)(-(double)base.ScaledRadius + offset), commonEndLocation);
		}
		else
		{
			base.ActorUpProxy.Multiply((double)(base.ScaledHalfHeight - base.ScaledRadius), commonStartLocation);
			base.ActorUpProxy.Multiply((double)(-(double)base.ScaledHalfHeight + offset), commonEndLocation);
		}
		commonStartLocation.AdditionEqual(vector);
		commonEndLocation.AdditionEqual(vector);
		ValueTuple<bool, global::Vector> valueTuple = this.FixBornLocationInternal(vector, commonStartLocation, commonEndLocation, false, showLog, context);
		if (!valueTuple.Item1 && bTryTwice)
		{
			base.ActorUpProxy.Multiply((double)base.ScaledRadius, Singleton<MathUtils>.Instance.CommonTempVector);
			commonStartLocation.AdditionEqual(Singleton<MathUtils>.Instance.CommonTempVector);
			valueTuple = this.FixBornLocationInternal(vector, commonStartLocation, commonEndLocation, true, showLog, context);
		}
		return valueTuple;
	}

	// Token: 0x06019110 RID: 102672 RVA: 0x0071E834 File Offset: 0x0071CA34
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	protected unsafe ValueTuple<bool, global::Vector> FixBornLocationInternal(global::Vector position, global::Vector start, global::Vector end, bool allowStartPenetrating, bool showLog = true, string context = "unknown.FixBornLocationInternal")
	{
		bool flag = ControllerBase<CreatureController>.Instance.CheckEnableEntityLog(new OneOf<EEntityType, EntityHandle>?(this.CreatureDataInternal.GetEntityType())) && showLog;
		if (flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[CharacterActorComponent.FixBornLocation] 实体地面修正:前";
			<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray8<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("K2_GetActorLocation", this.Actor.D_K2_GetActorLocation());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ActorLocationProxy", position);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("InitLocation", this.CreatureDataInternal.GetInitLocation());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("射线开始位置", start);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("射线结束位置", end);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("Context", context);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 8));
		}
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.Actor;
		actorTrace.Radius = base.ScaledRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, end);
		actorTrace.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		bool flag2 = Singleton<TraceElementCommon>.Instance.ShapeTrace(this.Actor.CapsuleComponent, actorTrace, "CharacterActorComponent_FixBornLocation", "CharacterActorComponent_FixBornLocation");
		UKuroHitResult hitResult = actorTrace.HitResult;
		if (flag)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[CharacterActorComponent.FixBornLocation] 实体地面修正:检测地面结果";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("isHit", flag2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("hitResult.bBlockingHit", hitResult.bBlockingHit);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("allowStartPenetrating", allowStartPenetrating);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("hitResult.bStartPenetrating", hitResult.bStartPenetrating);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 6) = new ValueTuple<string, object>("Context", context);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 7));
		}
		if (!flag2 || !hitResult.bBlockingHit)
		{
			ModelBase<TraceElementModel>.Instance.ClearActorTrace();
			return new ValueTuple<bool, global::Vector>(false, null);
		}
		if (!allowStartPenetrating && hitResult.bStartPenetrating)
		{
			return new ValueTuple<bool, global::Vector>(false, null);
		}
		global::Vector commonHitLocation = ModelBase<TraceElementModel>.Instance.CommonHitLocation;
		StringBuilder stringBuilder = new StringBuilder();
		int num = hitResult.Actors.Num();
		int num2 = -1;
		string item = "";
		Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, commonHitLocation);
		for (int i = 0; i < num; i++)
		{
			TWeakObjectPtr<AActor> tweakObjectPtr = hitResult.Actors.Get(i);
			AActor aactor = tweakObjectPtr.Get();
			if (aactor != null && aactor.IsValid())
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder2);
				appendInterpolatedStringHandler.AppendFormatted(tweakObjectPtr.GetName());
				appendInterpolatedStringHandler.AppendLiteral(", ");
				stringBuilder3.Append(ref appendInterpolatedStringHandler);
				if (!(tweakObjectPtr.Get() is ACharacter))
				{
					if (!allowStartPenetrating && (double)hitResult.TimeArray.Get(i) < 1E-08)
					{
						if (flag)
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.Entity;
							ELogAuthor author3 = ELogAuthor.LFJW;
							string message3 = "[CharacterActorComponent.FixBornLocation] 实体地面修正:起始碰撞";
							<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray8<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("isHit", flag2);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("hitResult.bBlockingHit", hitResult.bBlockingHit);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("allowStartPenetrating", allowStartPenetrating);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 5) = new ValueTuple<string, object>("hitResult.bStartPenetrating", hitResult.bStartPenetrating);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 6) = new ValueTuple<string, object>("hitResult.time", hitResult.TimeArray.Get(i));
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 7) = new ValueTuple<string, object>("Context", context);
							instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 8));
						}
						return new ValueTuple<bool, global::Vector>(false, null);
					}
					num2 = i;
					item = tweakObjectPtr.GetName();
					Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, i, commonHitLocation);
					break;
				}
			}
		}
		base.ActorUpProxy.Multiply((double)(base.ScaledHalfHeight - base.ScaledRadius + 2f), Singleton<MathUtils>.Instance.CommonTempVector);
		commonHitLocation.AdditionEqual(Singleton<MathUtils>.Instance.CommonTempVector);
		if (flag)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "[CharacterActorComponent.FixBornLocation] 实体地面修正:射线碰到地面";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("Actors", stringBuilder);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("HitLocationIndex", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("HitLocationName", item);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 5) = new ValueTuple<string, object>("经过修正的位置", commonHitLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 6) = new ValueTuple<string, object>("Context", context);
			instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 7));
		}
		if (!this.WasFixBornMeshLocation && this.CreatureDataInternal.IsNpc())
		{
			this.WasFixBornMeshLocation = true;
			CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
			if (component != null)
			{
				TsBaseCharacter actor = component.Actor;
				if (((actor != null) ? actor.Mesh : null) != null)
				{
					FVectorDouble location = component.GetMeshTransform().GetLocation();
					Singleton<MathUtils>.Instance.CommonTempVector.Set(0.0, 0.0, -2.0);
					component.AddModelLocation(Singleton<MathUtils>.Instance.CommonTempVector);
					if (flag)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.Entity;
						ELogAuthor author5 = ELogAuthor.YJX;
						string message5 = "[CharacterActorComponent.FixBornLocation] 实体地面修正:模型位置修正";
						<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray5<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("OrigMeshLocation", location);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("FixMeshLocation", component.GetMeshTransform().GetLocation());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 4) = new ValueTuple<string, object>("Context", context);
						instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 5));
					}
				}
			}
		}
		ModelBase<TraceElementModel>.Instance.ClearActorTrace();
		return new ValueTuple<bool, global::Vector>(true, commonHitLocation);
	}

	// Token: 0x06019111 RID: 102673 RVA: 0x0071F084 File Offset: 0x0071D284
	[NullableContext(2)]
	protected unsafe AActor InitActorNew(int modelId)
	{
		CreatureDataComponent creatureDataInternal = this.CreatureDataInternal;
		FTransformDouble transform = creatureDataInternal.D_GetTransform();
		AActor aactor = null;
		this.CreatureDataInternal.SetModelConfig(modelId);
		this.UpdateModelResPath();
		SModelConfig modelConfig = this.CreatureDataInternal.GetModelConfig();
		if (modelConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[CharacterActorComponent.OnInit] 缺少ModelConfig配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ModelId", modelId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return aactor;
		}
		aactor = ActorUtils.LoadActorByModelConfig(modelConfig, transform);
		if (aactor == null || !aactor.IsValid())
		{
			return null;
		}
		UClass loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UClass>(modelConfig.蓝图.ToAssetPathName());
		this.ClassDefaultObject = (UKuroStaticLibrary.GetDefaultObject(loadedAsset.GetClass()) as ABaseCharacter);
		if (ObjectUtils.SoftObjectPathIsValid(modelConfig.DA))
		{
			string text = modelConfig.DA.AssetPathName.ToString();
			if (text != null && text.Length > 0 && text != "None")
			{
				PD_NpcSetupData_C loadedAsset2 = Singleton<ResourceSystem>.Instance.GetLoadedAsset<PD_NpcSetupData_C>(modelConfig.DA.AssetPathName.ToString());
				if (loadedAsset2 != null && loadedAsset2.IsValid())
				{
					TsBaseCharacter tsBaseCharacter = aactor as TsBaseCharacter;
					if (tsBaseCharacter != null)
					{
						FTransform relativeTransform = tsBaseCharacter.Mesh.GetRelativeTransform();
						CombineMeshTool.LoadDaConfig(aactor, relativeTransform, tsBaseCharacter.Mesh, loadedAsset2);
						if (tsBaseCharacter.RenderType == ECharacterRenderingType.Npc)
						{
							tsBaseCharacter.CharRenderingComponent.UpdateNpcDitherComponent();
						}
					}
				}
			}
			if (modelConfig.动画蓝图.IsValid())
			{
				UClassStackOnlyPtr uclassStackOnlyPtr = modelConfig.动画蓝图.Get();
				TsBaseCharacter tsBaseCharacter2 = aactor as TsBaseCharacter;
				if (tsBaseCharacter2 != null)
				{
					tsBaseCharacter2.Mesh.SetAnimClass(new UClassStackOnlyPtr(uclassStackOnlyPtr._NativePtr));
				}
			}
		}
		else
		{
			TsBaseCharacter tsBaseCharacter3 = aactor as TsBaseCharacter;
			if (tsBaseCharacter3 != null)
			{
				TSoftClassPtr<UAnimInstance> animBlueprintClass = modelConfig.动画蓝图.As<UAnimInstance>();
				ActorUtils.LoadAndChangeMeshAnim(tsBaseCharacter3.Mesh, modelConfig.网格体, animBlueprintClass);
			}
		}
		if (GlobalData.IsPlayInEditor)
		{
			int pbDataId = this.CreatureDataInternal.GetPbDataId();
			TArray<FName> tags = aactor.Tags;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("PbDataId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(pbDataId);
			tags.Add(new FName(defaultInterpolatedStringHandler.ToStringAndClear()));
		}
		return aactor;
	}

	// Token: 0x06019112 RID: 102674 RVA: 0x0071F2F0 File Offset: 0x0071D4F0
	protected override void InitSizeInternal()
	{
		this.RadiusInternal = this.Actor.CapsuleComponent.CapsuleRadius;
		this.HalfHeightInternal = this.Actor.CapsuleComponent.CapsuleHalfHeight;
		this.DefaultRadiusInternal = this.RadiusInternal;
		this.DefaultHalfHeightInternal = this.HalfHeightInternal;
	}

	// Token: 0x06019113 RID: 102675 RVA: 0x0071F344 File Offset: 0x0071D544
	public void UpdateModelResPath()
	{
		if (this.CreatureDataInternal.GetEntityType() != EEntityType.Npc)
		{
			return;
		}
		SModelConfig modelConfig = this.CreatureDataInternal.GetModelConfig();
		if (modelConfig == null)
		{
			return;
		}
		string pathName = UKismetSystemLibrary.GetPathName(modelConfig.蓝图.Get().ToClass());
		if (string.IsNullOrEmpty(pathName) || pathName == "None")
		{
			return;
		}
		string text = pathName.Substring(0, pathName.LastIndexOf("/"));
		text = text.Substring(0, text.LastIndexOf("/"));
		this.ModelResPath = string.Join("", new List<string>
		{
			text,
			"/Montage"
		});
	}

	// Token: 0x06019114 RID: 102676 RVA: 0x0071F3F4 File Offset: 0x0071D5F4
	[NullableContext(2)]
	public void SwitchFace(bool isSeqFace, USkeletalMesh seqFace = null)
	{
		if (this.CreatureDataInternal.GetEntityType() != EEntityType.Npc)
		{
			return;
		}
		SModelConfig modelConfig = this.CreatureDataInternal.GetModelConfig();
		if (!ObjectUtils.SoftObjectPathIsValid(modelConfig.DA))
		{
			return;
		}
		if (isSeqFace)
		{
			if (seqFace != null && seqFace.IsValid())
			{
				TsBaseCharacter tsBaseCharacter = this.ActorInternal as TsBaseCharacter;
				if (tsBaseCharacter != null)
				{
					CombineMeshTool.SetFace(tsBaseCharacter, seqFace);
					return;
				}
			}
		}
		else
		{
			string text = modelConfig.DA.AssetPathName.ToString();
			if (text != null && text.Length > 0 && text != "None")
			{
				PD_NpcSetupData_C loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<PD_NpcSetupData_C>(modelConfig.DA.AssetPathName.ToString());
				if (loadedAsset != null && loadedAsset.IsValid())
				{
					TsBaseCharacter tsBaseCharacter2 = this.ActorInternal as TsBaseCharacter;
					if (tsBaseCharacter2 != null)
					{
						USkeletalMesh skel_Face = loadedAsset.Skel_Face;
						if (skel_Face != null && skel_Face.IsValid())
						{
							CombineMeshTool.SetFace(tsBaseCharacter2, loadedAsset.Skel_Face);
						}
					}
				}
			}
		}
	}

	// Token: 0x06019115 RID: 102677 RVA: 0x0071F4F4 File Offset: 0x0071D6F4
	public override global::Vector GetWatchedPoint()
	{
		BaseMoveComponent moveComp = this.MoveComp;
		if (((moveComp != null) ? moveComp.GravityUp : null) == null)
		{
			return this.ActorLocationProxy;
		}
		this.MoveComp.GravityUp.Multiply((double)base.ScaledHalfHeight, this.TopLocation);
		this.TopLocation.AdditionEqual(this.ActorLocationProxy);
		return this.TopLocation;
	}

	// Token: 0x06019116 RID: 102678 RVA: 0x0071F552 File Offset: 0x0071D752
	protected override bool OnClear()
	{
		return base.OnClear();
	}

	// Token: 0x06019117 RID: 102679 RVA: 0x0071F55C File Offset: 0x0071D75C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseCharacterComponent baseCharacterComponent = (BaseCharacterComponent)componentTemplate;
		if (base.CanResetComponentProperty("SubEntityType"))
		{
			this.SubEntityType = baseCharacterComponent.SubEntityType;
		}
		if (base.CanResetComponentProperty("EntityType"))
		{
			this.EntityType = baseCharacterComponent.EntityType;
		}
		if (base.CanResetComponentProperty("ModelResPath"))
		{
			this.ModelResPath = baseCharacterComponent.ModelResPath;
		}
		if (base.CanResetComponentProperty("ClassDefaultObject"))
		{
			if (baseCharacterComponent.ClassDefaultObject == null)
			{
				this.ClassDefaultObject = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ABaseCharacter>(this.ClassDefaultObject), "ClassDefaultObject"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WasFixBornMeshLocation"))
		{
			this.WasFixBornMeshLocation = baseCharacterComponent.WasFixBornMeshLocation;
		}
		return !base.CanResetComponentProperty("TopLocation") || baseCharacterComponent.TopLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TopLocation), "TopLocation");
	}

	// Token: 0x0400C452 RID: 50258
	private const string PROFILE_KEY = "CharacterActorComponent_FixBornLocation";

	// Token: 0x0400C453 RID: 50259
	private const int FIX_LOCATION_TOLERANCE = 2;

	// Token: 0x0400C454 RID: 50260
	protected int SubEntityType;

	// Token: 0x0400C455 RID: 50261
	protected EEntityType EntityType = EEntityType.Npc;

	// Token: 0x0400C456 RID: 50262
	public string ModelResPath = "";

	// Token: 0x0400C457 RID: 50263
	[Nullable(2)]
	protected ABaseCharacter ClassDefaultObject;

	// Token: 0x0400C458 RID: 50264
	private bool WasFixBornMeshLocation;

	// Token: 0x0400C459 RID: 50265
	private readonly global::Vector TopLocation = global::Vector.Create();
}
