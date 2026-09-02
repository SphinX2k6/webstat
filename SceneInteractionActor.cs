using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Fight.Enum;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction;
using AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect;
using AkiClient.Game.Aki.Scene.Assets.Levels.LiNaXiTa.QiQiu.ZhuCheng.SkinMesh.SK_Sev_Mon_01AL.CommonAnim.Montage;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.Module.MechanismTimeline;
using CSharpScript.Game.Render;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200342F RID: 13359
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Item/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Item/SceneInteractionActor.SceneInteractionActor_C")]
public class SceneInteractionActor : AKuroSceneInteractionActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700260B RID: 9739
	// (get) Token: 0x0601BEA5 RID: 114341 RVA: 0x00850BCE File Offset: 0x0084EDCE
	// (set) Token: 0x0601BEA6 RID: 114342 RVA: 0x00850BE2 File Offset: 0x0084EDE2
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe string LevelName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SceneInteractionActor.__PropertyOffset_LevelName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SceneInteractionActor.__PropertyOffset_LevelName)), value);
		}
	}

	// Token: 0x1700260C RID: 9740
	// (get) Token: 0x0601BEA7 RID: 114343 RVA: 0x00850BF7 File Offset: 0x0084EDF7
	// (set) Token: 0x0601BEA8 RID: 114344 RVA: 0x00850C07 File Offset: 0x0084EE07
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe float HandleId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_HandleId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_HandleId) = value;
		}
	}

	// Token: 0x1700260D RID: 9741
	// (get) Token: 0x0601BEA9 RID: 114345 RVA: 0x00850C18 File Offset: 0x0084EE18
	[Nullable(new byte[]
	{
		1,
		2
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<EKuroSceneInteractionState, SSceneInteractionitem> States
	{
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		get
		{
			base.FastCheckIsValid();
			TMap<EKuroSceneInteractionState, SSceneInteractionitem> result;
			if ((result = this._States) == null)
			{
				result = (this._States = new TMap<EKuroSceneInteractionState, SSceneInteractionitem>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_States, this));
			}
			return result;
		}
	}

	// Token: 0x1700260E RID: 9742
	// (get) Token: 0x0601BEAA RID: 114346 RVA: 0x00850C54 File Offset: 0x0084EE54
	[Nullable(new byte[]
	{
		1,
		2
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<ESceneInteractionEffect, SScenePropertyEffect> Effects
	{
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		get
		{
			base.FastCheckIsValid();
			TMap<ESceneInteractionEffect, SScenePropertyEffect> result;
			if ((result = this._Effects) == null)
			{
				result = (this._Effects = new TMap<ESceneInteractionEffect, SScenePropertyEffect>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_Effects, this));
			}
			return result;
		}
	}

	// Token: 0x1700260F RID: 9743
	// (get) Token: 0x0601BEAB RID: 114347 RVA: 0x00850C90 File Offset: 0x0084EE90
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<BP_EffectActor_C> EffectsInheritTimeDilation
	{
		get
		{
			base.FastCheckIsValid();
			TArray<BP_EffectActor_C> result;
			if ((result = this._EffectsInheritTimeDilation) == null)
			{
				result = (this._EffectsInheritTimeDilation = new TArray<BP_EffectActor_C>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_EffectsInheritTimeDilation, this));
			}
			return result;
		}
	}

	// Token: 0x17002610 RID: 9744
	// (get) Token: 0x0601BEAC RID: 114348 RVA: 0x00850CCC File Offset: 0x0084EECC
	[Nullable(new byte[]
	{
		1,
		2
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<ESceneInteractionEffect, BP_EffectActor_C> EndEffects
	{
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		get
		{
			base.FastCheckIsValid();
			TMap<ESceneInteractionEffect, BP_EffectActor_C> result;
			if ((result = this._EndEffects) == null)
			{
				result = (this._EndEffects = new TMap<ESceneInteractionEffect, BP_EffectActor_C>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_EndEffects, this));
			}
			return result;
		}
	}

	// Token: 0x17002611 RID: 9745
	// (get) Token: 0x0601BEAD RID: 114349 RVA: 0x00850D08 File Offset: 0x0084EF08
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<string, AActor> ReferenceActors
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, AActor> result;
			if ((result = this._ReferenceActors) == null)
			{
				result = (this._ReferenceActors = new TMap<string, AActor>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_ReferenceActors, this));
			}
			return result;
		}
	}

	// Token: 0x17002612 RID: 9746
	// (get) Token: 0x0601BEAE RID: 114350 RVA: 0x00850D44 File Offset: 0x0084EF44
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<FGameplayTag, SSceneInteractionTags> TagsAndCorrespondingEffects
	{
		get
		{
			base.FastCheckIsValid();
			TMap<FGameplayTag, SSceneInteractionTags> result;
			if ((result = this._TagsAndCorrespondingEffects) == null)
			{
				result = (this._TagsAndCorrespondingEffects = new TMap<FGameplayTag, SSceneInteractionTags>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_TagsAndCorrespondingEffects, this));
			}
			return result;
		}
	}

	// Token: 0x17002613 RID: 9747
	// (get) Token: 0x0601BEAF RID: 114351 RVA: 0x00850D80 File Offset: 0x0084EF80
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<AActor> CollisionActors
	{
		get
		{
			base.FastCheckIsValid();
			TArray<AActor> result;
			if ((result = this._CollisionActors) == null)
			{
				result = (this._CollisionActors = new TArray<AActor>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_CollisionActors, this));
			}
			return result;
		}
	}

	// Token: 0x17002614 RID: 9748
	// (get) Token: 0x0601BEB0 RID: 114352 RVA: 0x00850DBC File Offset: 0x0084EFBC
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<AActor, FGameplayTag> PartCollisionActorsAndCorrespondingTags
	{
		get
		{
			base.FastCheckIsValid();
			TMap<AActor, FGameplayTag> result;
			if ((result = this._PartCollisionActorsAndCorrespondingTags) == null)
			{
				result = (this._PartCollisionActorsAndCorrespondingTags = new TMap<AActor, FGameplayTag>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_PartCollisionActorsAndCorrespondingTags, this));
			}
			return result;
		}
	}

	// Token: 0x17002615 RID: 9749
	// (get) Token: 0x0601BEB1 RID: 114353 RVA: 0x00850DF8 File Offset: 0x0084EFF8
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<AActor> InteractionEffectHookActors
	{
		get
		{
			base.FastCheckIsValid();
			TArray<AActor> result;
			if ((result = this._InteractionEffectHookActors) == null)
			{
				result = (this._InteractionEffectHookActors = new TArray<AActor>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_InteractionEffectHookActors, this));
			}
			return result;
		}
	}

	// Token: 0x17002616 RID: 9750
	// (get) Token: 0x0601BEB2 RID: 114354 RVA: 0x00850E31 File Offset: 0x0084F031
	// (set) Token: 0x0601BEB3 RID: 114355 RVA: 0x00850E45 File Offset: 0x0084F045
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TsBaseCharacter CharacterForOrgan
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_CharacterForOrgan);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_CharacterForOrgan, value);
		}
	}

	// Token: 0x17002617 RID: 9751
	// (get) Token: 0x0601BEB4 RID: 114356 RVA: 0x00850E5C File Offset: 0x0084F05C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<AActor> ActorsForProjection
	{
		get
		{
			base.FastCheckIsValid();
			TArray<AActor> result;
			if ((result = this._ActorsForProjection) == null)
			{
				result = (this._ActorsForProjection = new TArray<AActor>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_ActorsForProjection, this));
			}
			return result;
		}
	}

	// Token: 0x17002618 RID: 9752
	// (get) Token: 0x0601BEB5 RID: 114357 RVA: 0x00850E95 File Offset: 0x0084F095
	// (set) Token: 0x0601BEB6 RID: 114358 RVA: 0x00850EA9 File Offset: 0x0084F0A9
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UMaterialInstance MaterialForProjection
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_MaterialForProjection);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_MaterialForProjection, value);
		}
	}

	// Token: 0x17002619 RID: 9753
	// (get) Token: 0x0601BEB7 RID: 114359 RVA: 0x00850EC0 File Offset: 0x0084F0C0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<AActor> ReceivingDecalsActors
	{
		get
		{
			base.FastCheckIsValid();
			TArray<AActor> result;
			if ((result = this._ReceivingDecalsActors) == null)
			{
				result = (this._ReceivingDecalsActors = new TArray<AActor>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_ReceivingDecalsActors, this));
			}
			return result;
		}
	}

	// Token: 0x1700261A RID: 9754
	// (get) Token: 0x0601BEB8 RID: 114360 RVA: 0x00850EFC File Offset: 0x0084F0FC
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<UStaticMesh> StaticMeshList
	{
		get
		{
			base.FastCheckIsValid();
			TArray<UStaticMesh> result;
			if ((result = this._StaticMeshList) == null)
			{
				result = (this._StaticMeshList = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_StaticMeshList, this));
			}
			return result;
		}
	}

	// Token: 0x1700261B RID: 9755
	// (get) Token: 0x0601BEB9 RID: 114361 RVA: 0x00850F35 File Offset: 0x0084F135
	// (set) Token: 0x0601BEBA RID: 114362 RVA: 0x00850F45 File Offset: 0x0084F145
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe BPELevelPrefabDestructibleOverlapSource RangeOtherActorVelocitySource
	{
		get
		{
			return (BPELevelPrefabDestructibleOverlapSource)(*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_RangeOtherActorVelocitySource));
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_RangeOtherActorVelocitySource) = (byte)value;
		}
	}

	// Token: 0x1700261C RID: 9756
	// (get) Token: 0x0601BEBB RID: 114363 RVA: 0x00850F58 File Offset: 0x0084F158
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<ASkeletalMeshActor> SkeletalMeshActors
	{
		get
		{
			base.FastCheckIsValid();
			TArray<ASkeletalMeshActor> result;
			if ((result = this._SkeletalMeshActors) == null)
			{
				result = (this._SkeletalMeshActors = new TArray<ASkeletalMeshActor>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_SkeletalMeshActors, this));
			}
			return result;
		}
	}

	// Token: 0x1700261D RID: 9757
	// (get) Token: 0x0601BEBC RID: 114364 RVA: 0x00850F94 File Offset: 0x0084F194
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<ASkeletalMeshActor> AllSkeletalMeshActors
	{
		get
		{
			base.FastCheckIsValid();
			TArray<ASkeletalMeshActor> result;
			if ((result = this._AllSkeletalMeshActors) == null)
			{
				result = (this._AllSkeletalMeshActors = new TArray<ASkeletalMeshActor>(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_AllSkeletalMeshActors, this));
			}
			return result;
		}
	}

	// Token: 0x1700261E RID: 9758
	// (get) Token: 0x0601BEBD RID: 114365 RVA: 0x00850FCD File Offset: 0x0084F1CD
	// (set) Token: 0x0601BEBE RID: 114366 RVA: 0x00850FE1 File Offset: 0x0084F1E1
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe BP_InteractionMaterialController_C InteractionMaterialController
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<BP_InteractionMaterialController_C>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_InteractionMaterialController);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_InteractionMaterialController, value);
		}
	}

	// Token: 0x1700261F RID: 9759
	// (get) Token: 0x0601BEBF RID: 114367 RVA: 0x00850FF6 File Offset: 0x0084F1F6
	// (set) Token: 0x0601BEC0 RID: 114368 RVA: 0x0085100A File Offset: 0x0084F20A
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe BP_BasePlatform_C BasePlatformInternal
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<BP_BasePlatform_C>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_BasePlatformInternal);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_BasePlatformInternal, value);
		}
	}

	// Token: 0x17002620 RID: 9760
	// (get) Token: 0x0601BEC1 RID: 114369 RVA: 0x0085101F File Offset: 0x0084F21F
	// (set) Token: 0x0601BEC2 RID: 114370 RVA: 0x0085102F File Offset: 0x0084F22F
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe float CurrentStateAkEventHandle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_CurrentStateAkEventHandle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_CurrentStateAkEventHandle) = value;
		}
	}

	// Token: 0x17002621 RID: 9761
	// (get) Token: 0x0601BEC3 RID: 114371 RVA: 0x00851040 File Offset: 0x0084F240
	private HashSet<AKuroDestructibleActor> SkeletalMeshDestructibleActors
	{
		get
		{
			if (this.SkeletalMeshDestructibleActorsInternal == null)
			{
				this.SkeletalMeshDestructibleActorsInternal = new HashSet<AKuroDestructibleActor>();
			}
			return this.SkeletalMeshDestructibleActorsInternal;
		}
	}

	// Token: 0x17002622 RID: 9762
	// (get) Token: 0x0601BEC4 RID: 114372 RVA: 0x0085105B File Offset: 0x0084F25B
	// (set) Token: 0x0601BEC5 RID: 114373 RVA: 0x0085106F File Offset: 0x0084F26F
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor OverrideEffectActor
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_OverrideEffectActor);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionActor.__PropertyOffset_OverrideEffectActor, value);
		}
	}

	// Token: 0x0601BEC6 RID: 114374 RVA: 0x00851084 File Offset: 0x0084F284
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetOverrideSeqBindActor(AActor actorToBind, [Nullable(2)] string bindingName = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetOverrideSeqBindActor"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__SetOverrideSeqBindActor_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__SetOverrideSeqBindActor_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__SetOverrideSeqBindActor_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->actorToBind) = ((actorToBind != null) ? actorToBind.NativePtr : ((IntPtr)0));
			FString.CopyFrom((void*)(&ptr2->bindingName), bindingName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BEC7 RID: 114375 RVA: 0x00851118 File Offset: 0x0084F318
	protected unsafe void SetOverrideSeqBindActor_Implementation(AActor actorToBind, [Nullable(2)] string bindingName = null)
	{
		if (this.OverrideSeqBindActors == null)
		{
			this.OverrideSeqBindActors = new Dictionary<string, AActor>();
		}
		if (actorToBind == null || !actorToBind.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SetOverrideSeqBindActor] 传入的Actor无效";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LevelName", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BindingName", bindingName);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		string key = bindingName ?? UKismetSystemLibrary.GetDisplayName(actorToBind);
		string.IsNullOrEmpty(bindingName);
		if (this.OverrideSeqBindActors.ContainsKey(key) && this.OverrideSeqBindActors[key] == actorToBind)
		{
			return;
		}
		this.OverrideSeqBindActors[key] = actorToBind;
	}

	// Token: 0x0601BEC8 RID: 114376 RVA: 0x00851208 File Offset: 0x0084F408
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void UnsetOverrideSeqBindActor(AActor actorToUnbind, [Nullable(2)] string bindingName = null)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("UnsetOverrideSeqBindActor"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__UnsetOverrideSeqBindActor_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__UnsetOverrideSeqBindActor_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__UnsetOverrideSeqBindActor_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->actorToUnbind) = ((actorToUnbind != null) ? actorToUnbind.NativePtr : ((IntPtr)0));
			FString.CopyFrom((void*)(&ptr2->bindingName), bindingName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BEC9 RID: 114377 RVA: 0x0085129C File Offset: 0x0084F49C
	protected void UnsetOverrideSeqBindActor_Implementation(AActor actorToUnbind, [Nullable(2)] string bindingName = null)
	{
		if (this.OverrideSeqBindActors == null)
		{
			return;
		}
		string key = bindingName ?? UKismetSystemLibrary.GetDisplayName(actorToUnbind);
		string.IsNullOrEmpty(bindingName);
		if (!this.OverrideSeqBindActors.ContainsKey(key))
		{
			return;
		}
		if (this.OverrideSeqBindActors[key] != actorToUnbind)
		{
			return;
		}
		this.OverrideSeqBindActors.Remove(key);
	}

	// Token: 0x17002623 RID: 9763
	// (get) Token: 0x0601BECA RID: 114378 RVA: 0x008512F4 File Offset: 0x0084F4F4
	[Nullable(2)]
	public BP_BasePlatform_C BasePlatform
	{
		[NullableContext(2)]
		get
		{
			if (this.BasePlatformInternal == null)
			{
				AActor attachParentActor = base.GetAttachParentActor();
				if (attachParentActor == null)
				{
					return null;
				}
				this.BasePlatformInternal = (Singleton<ActorSystem>.Instance.Get(BP_BasePlatform_C.StaticClass(), base.D_GetTransform(), attachParentActor, true) as BP_BasePlatform_C);
				ControllerBase<AttachToActorController>.Instance.AttachToActor(this.BasePlatformInternal, attachParentActor, EDetachType.EntityDestroy, "SceneInteractionActor.BasePlatform", null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true, false, false, false);
				AActor aactor = null;
				if (this.CollisionActors.Num() > 0)
				{
					aactor = this.CollisionActors.Get(0);
				}
				if (aactor == null)
				{
					aactor = attachParentActor;
				}
				FVector fvector = new FVector();
				FVectorDouble fvectorDouble = new FVectorDouble();
				aactor.D_GetActorBounds(true, ref fvectorDouble, ref fvector, true);
				FVector fvector2 = fvector;
				float num = Math.Max(fvector2.X, Math.Max(fvector2.Y, fvector2.Z));
				num += 50f;
				this.BasePlatformInternal.LeaveSphereRadius = num;
				this.BasePlatformInternal.LeaveSphereCenter = new FVector(0f, 0f, 0f);
			}
			return this.BasePlatformInternal;
		}
	}

	// Token: 0x0601BECB RID: 114379 RVA: 0x00851400 File Offset: 0x0084F600
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BECC RID: 114380 RVA: 0x00851470 File Offset: 0x0084F670
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.PlayingTagAkEventHandle = new Dictionary<FGameplayTag, int>();
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			ULevel level = base.GetLevel();
			UWorld uworld = (level != null) ? level.OwningWorld : null;
			if (UKismetSystemLibrary.GetPathName((uworld != null) ? uworld.PersistentLevel : null).Contains("/Game/Aki/Scene/InteractionLevel/Prefab"))
			{
				Singleton<ResourceSystem>.Instance.LoadTypeAsync(EBpTypeName.BP_GlobalGI_C.ToEnumString(), delegate
				{
					this.GlobalGi = (Singleton<ActorSystem>.Instance.Get(BP_GlobalGI_C.StaticClass(), base.D_GetTransform(), null, true) as BP_GlobalGI_C);
					this.GlobalGi.夜晚();
				}, "js_undefined");
				Singleton<Info>.Instance.SetInCg(true);
				this.Init(0, -1, base.GetName(), null);
				Ticker ticker = Singleton<TickSystem>.Instance.Add(delegate(float delayTime)
				{
					this.Update(delayTime / 1000f);
				}, "Game", ETickingGroup.TG_PrePhysics, true, 0, false);
				if (ticker != null)
				{
					this.DebugTickId = ticker.Id;
				}
			}
		}
	}

	// Token: 0x0601BECD RID: 114381 RVA: 0x00851530 File Offset: 0x0084F730
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)EndPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BECE RID: 114382 RVA: 0x008515AC File Offset: 0x0084F7AC
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
	{
		if (this.BasePlatformInternal != null)
		{
			Singleton<ActorSystem>.Instance.Put("SceneInteractionActor.ReceiveEndPlay1", this.BasePlatformInternal, null);
		}
		if (this.GlobalGi != null)
		{
			Singleton<ActorSystem>.Instance.Put("SceneInteractionActor.ReceiveEndPlay2", this.GlobalGi, null);
		}
		this.StopCurrentStateAkEvent("清除状态及tag相关音效");
		if (this.PlayingTagAkEventHandle != null && this.PlayingTagAkEventHandle.Count > 0)
		{
			foreach (int handle in this.PlayingTagAkEventHandle.Values)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, null);
			}
			this.PlayingTagAkEventHandle.Clear();
		}
		this.RemoveDebugTicker();
		this.RemovePendingStateEffectTick();
		this.RemovePendingCrossStateEffectTick();
		this.RemovePendingTagEffectTick();
	}

	// Token: 0x0601BECF RID: 114383 RVA: 0x00851694 File Offset: 0x0084F894
	private void RemoveDebugTicker()
	{
		if (this.DebugTickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.DebugTickId);
			this.DebugTickId = -1;
		}
	}

	// Token: 0x0601BED0 RID: 114384 RVA: 0x008516B8 File Offset: 0x0084F8B8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddNewState()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddNewState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BED1 RID: 114385 RVA: 0x00851728 File Offset: 0x0084F928
	protected void AddNewState_Implementation()
	{
		this.States.Add((EKuroSceneInteractionState)this.States.Num(), null);
	}

	// Token: 0x0601BED2 RID: 114386 RVA: 0x00851744 File Offset: 0x0084F944
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddNewEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddNewEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BED3 RID: 114387 RVA: 0x008517B4 File Offset: 0x0084F9B4
	protected void AddNewEffect_Implementation()
	{
		this.Effects.Add((ESceneInteractionEffect)this.Effects.Num(), null);
	}

	// Token: 0x0601BED4 RID: 114388 RVA: 0x008517D0 File Offset: 0x0084F9D0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddNewEndEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddNewEndEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BED5 RID: 114389 RVA: 0x00851840 File Offset: 0x0084FA40
	protected void AddNewEndEffect_Implementation()
	{
		this.EndEffects.Add((ESceneInteractionEffect)this.EndEffects.Num(), null);
	}

	// Token: 0x0601BED6 RID: 114390 RVA: 0x0085185C File Offset: 0x0084FA5C
	public void ChangeDirection(bool bPlayBack)
	{
		if ((bPlayBack && !this.IsPlayBack) || (!bPlayBack && this.IsPlayBack))
		{
			if (this.ActiveSequencePlayer != null)
			{
				this.ActiveSequencePlayer.ChangePlaybackDirection();
			}
			if (this.CurrentState.AnimMontage.Montage != null && this.CurrentState.AnimMontage.SkeletalMesh != null)
			{
				this.CurrentState.AnimMontage.SkeletalMesh.SkeletalMeshComponent.SetPlayRate(-this.CurrentState.AnimMontage.SkeletalMesh.SkeletalMeshComponent.GetPlayRate());
			}
			this.IsPlayBack = !this.IsPlayBack;
		}
	}

	// Token: 0x0601BED7 RID: 114391 RVA: 0x008518FD File Offset: 0x0084FAFD
	public void PlayStateBpMaterialRuntimeParUpdate(SSceneInteractionitem state)
	{
		if (state.BP_MaterialRuntimeParUpdate != null)
		{
			state.BP_MaterialRuntimeParUpdate.IsPlay = true;
			state.BP_MaterialRuntimeParUpdate.Set_Initialize();
		}
	}

	// Token: 0x0601BED8 RID: 114392 RVA: 0x00851920 File Offset: 0x0084FB20
	public void PlayIndependentEffect(ESceneInteractionEffect effectKey)
	{
		SScenePropertyEffect valueOrDefault = this.Effects.GetValueOrDefault(effectKey);
		if (valueOrDefault == null)
		{
			return;
		}
		if (valueOrDefault.Effect != null)
		{
			this.PlayEffect(valueOrDefault.Effect, "[SceneInteractionActor.PlayIndependentEffect]");
		}
		if (valueOrDefault.Material != null)
		{
			for (int i = 0; i < valueOrDefault.Material.Actors.Num(); i++)
			{
				if (valueOrDefault.Material.Actors.Get(i) != null && valueOrDefault.Material.Data != null)
				{
					valueOrDefault.Material.TailIndex = (float)Singleton<ItemMaterialManager>.Instance.AddMaterialData(valueOrDefault.Material.Actors.Get(i), valueOrDefault.Material.Data);
				}
			}
			this.Effects[effectKey] = valueOrDefault;
		}
	}

	// Token: 0x0601BED9 RID: 114393 RVA: 0x008519E8 File Offset: 0x0084FBE8
	public void EndIndependentEffect(ESceneInteractionEffect effectKey)
	{
		SScenePropertyEffect valueOrDefault = this.Effects.GetValueOrDefault(effectKey);
		if (valueOrDefault == null)
		{
			return;
		}
		if (valueOrDefault.Effect != null)
		{
			this.StopEffect(valueOrDefault.Effect, "[SceneInteractionActor.EndIndependentEffect]", false);
		}
		if (Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap != null)
		{
			for (int i = 0; i < valueOrDefault.Material.Actors.Num(); i++)
			{
				int handle = (int)valueOrDefault.Material.TailIndex - i;
				Singleton<ItemMaterialManager>.Instance.DisableActorData(handle);
			}
		}
	}

	// Token: 0x0601BEDA RID: 114394 RVA: 0x00851A68 File Offset: 0x0084FC68
	public void PlayIndependentEndEffect(ESceneInteractionEffect effectKey)
	{
		BP_EffectActor_C valueOrDefault = this.EndEffects.GetValueOrDefault(effectKey);
		if (valueOrDefault == null)
		{
			return;
		}
		this.PlayEffect(valueOrDefault, "[SceneInteractionActor.PlayIndependentEndEffect]");
	}

	// Token: 0x0601BEDB RID: 114395 RVA: 0x00851A94 File Offset: 0x0084FC94
	public void Update(float deltaSeconds)
	{
		if (deltaSeconds > 0f && this.SkeletalMontageConfigMap != null)
		{
			foreach (KeyValuePair<ASkeletalMeshActor, SkeletalMontageConfig> keyValuePair in this.SkeletalMontageConfigMap)
			{
				ASkeletalMeshActor key = keyValuePair.Key;
				SkeletalMontageConfig value = keyValuePair.Value;
				if (value.IsPendingApplyProps())
				{
					value.PendingFrameCount--;
					if (value.PendingFrameCount <= 0 && key.SkeletalMeshComponent != null)
					{
						key.SkeletalMeshComponent.SetHiddenInGame(value.PendingCompHiddenInGame, false);
						key.SkeletalMeshComponent.VisibilityBasedAnimTickOption = value.PendingCompVisibilityBasedAnimTickOption;
					}
				}
			}
		}
		if ((this.InTransition || this.InWaitingForPlayableFinished) && !this.CheckPlaying(deltaSeconds, this.CurrentState))
		{
			this.DoSwitchState(false);
		}
	}

	// Token: 0x0601BEDC RID: 114396 RVA: 0x00851B78 File Offset: 0x0084FD78
	public void SetTimeDilation(float customTimeDilation)
	{
		if (base.CustomTimeDilation != customTimeDilation)
		{
			base.CustomTimeDilation = customTimeDilation;
			this.UpdateTimeDilation();
		}
	}

	// Token: 0x0601BEDD RID: 114397 RVA: 0x00851B90 File Offset: 0x0084FD90
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void UpdateTimeDilation()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("UpdateTimeDilation"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BEDE RID: 114398 RVA: 0x00851C00 File Offset: 0x0084FE00
	protected void UpdateTimeDilation_Implementation()
	{
		if (this.CurrentState == null)
		{
			return;
		}
		float customTimeDilation = base.CustomTimeDilation;
		SSceneInteractionMontage animMontage = this.CurrentState.AnimMontage;
		if (animMontage.SkeletalMesh != null)
		{
			USkeletalMeshComponent skeletalMeshComponent = animMontage.SkeletalMesh.SkeletalMeshComponent;
			if (skeletalMeshComponent.GetAnimationMode() == EAnimationMode.AnimationBlueprint)
			{
				UAnimInstance animInstance = skeletalMeshComponent.GetAnimInstance();
				if (animInstance != null)
				{
					ABP_LevelPrefabDaiyu_C abp_LevelPrefabDaiyu_C = animInstance as ABP_LevelPrefabDaiyu_C;
					if (abp_LevelPrefabDaiyu_C != null)
					{
						abp_LevelPrefabDaiyu_C.SetPlayRate(base.CustomTimeDilation);
					}
					else
					{
						skeletalMeshComponent.SetPlayRate(animMontage.PlayRate * customTimeDilation);
					}
				}
			}
			else
			{
				skeletalMeshComponent.SetPlayRate(animMontage.PlayRate * customTimeDilation);
			}
		}
		if (this.ActiveSequenceDirectorMap != null && this.DirectorConfigMap != null)
		{
			foreach (ALevelSequenceActor alevelSequenceActor in this.ActiveSequenceDirectorMap.Values)
			{
				ULevelSequencePlayer sequencePlayer = alevelSequenceActor.SequencePlayer;
				SequenceDirectorConfig sequenceDirectorConfig;
				if (this.DirectorConfigMap.TryGetValue(alevelSequenceActor, out sequenceDirectorConfig) && sequencePlayer != null && sequencePlayer.IsValid())
				{
					sequencePlayer.SetPlayRate(sequenceDirectorConfig.PlayRate * customTimeDilation);
				}
			}
		}
		if (this.ActiveEffectInfoMap != null && this.ActiveEffectInfoMap.Count > 0)
		{
			foreach (EffectInfo effectInfo in this.ActiveEffectInfoMap.Values)
			{
				if (effectInfo.IsInheritTimeDilation && Singleton<EffectSystem>.Instance.IsValid(effectInfo.EffectId))
				{
					Singleton<EffectSystem>.Instance.SetTimeScale(effectInfo.EffectId, customTimeDilation, false);
				}
			}
		}
	}

	// Token: 0x0601BEDF RID: 114399 RVA: 0x00851DB4 File Offset: 0x0084FFB4
	public void Init(int pbDataId, int handleId, string levelName, [Nullable(2)] Action onInit)
	{
		this.PbDataId = pbDataId;
		this.HandleId = (float)handleId;
		this.LevelName = levelName;
		this.OnInitCallback = onInit;
		this.CurrentStateKey = new EKuroSceneInteractionState?(EKuroSceneInteractionState.Error);
		this.NextState = null;
		this.CurrentState = null;
		this.InTransition = false;
		this.IsPlayBack = false;
		this.Active = true;
		TsBaseCharacter characterForOrgan = this.CharacterForOrgan;
		if (characterForOrgan != null && characterForOrgan.IsValid())
		{
			AActor characterForOrgan2 = this.CharacterForOrgan;
			TSubclassOf<UActorComponent> @class = CharRenderingComponent.StaticClass();
			bool bManualAttachment = false;
			FTransformDouble ftransformDouble = base.D_GetTransform();
			this.CharRenderingComponent = (characterForOrgan2.D_AddComponentByClass(@class, bManualAttachment, ftransformDouble, false, default(FName)) as CharRenderingComponent);
			this.CharRenderingComponent.Init(this.CharacterForOrgan.RenderType);
			this.CharRenderingKey = 0;
		}
		this.CharRenderingComponents = new Dictionary<CharRenderingComponent, int>();
		if (this.SkeletalMeshActors != null)
		{
			for (int i = 0; i < this.SkeletalMeshActors.Num(); i++)
			{
				ASkeletalMeshActor askeletalMeshActor = this.SkeletalMeshActors.Get(i);
				if (askeletalMeshActor != null)
				{
					CharRenderingComponent charRenderingComponent = askeletalMeshActor.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as CharRenderingComponent;
					this.CharRenderingComponents.Add(charRenderingComponent, i);
					charRenderingComponent.Init(ECharacterRenderingType.Monster);
					if (askeletalMeshActor.SkeletalMeshComponent != null)
					{
						charRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, askeletalMeshActor.SkeletalMeshComponent);
					}
				}
			}
		}
		this.OnEffectFinishCallback = delegate(int handle)
		{
			Dictionary<int, EffectInfo> activeEffectInfoMap = this.ActiveEffectInfoMap;
			if (activeEffectInfoMap == null)
			{
				return;
			}
			activeEffectInfoMap.Remove(handle);
		};
		this.OnEffectPlayingCallback = delegate(ELoadEffectResult _, int handle)
		{
			EffectInfo effectInfo;
			if (this.ActiveEffectInfoMap != null && this.ActiveEffectInfoMap.TryGetValue(handle, out effectInfo))
			{
				effectInfo.IsPlaying = true;
			}
			if (this.CheckAllEffectPlaying())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSceneInteractionAllEffectPlaying, (int)this.HandleId);
			}
		};
		if (this.States != null)
		{
			for (int j = 0; j < this.States.Num(); j++)
			{
				if (this.States.IsValidIndex(j))
				{
					EKuroSceneInteractionState key = this.States.GetKey(j);
					SSceneInteractionitem valueOrDefault = this.States.GetValueOrDefault(key);
					if (!(valueOrDefault == null) && valueOrDefault.CrossStateEffects != null)
					{
						for (int k = 0; k < valueOrDefault.CrossStateEffects.Num(); k++)
						{
							SSceneInteractionCrossStateEffect ssceneInteractionCrossStateEffect = valueOrDefault.CrossStateEffects.Get(k);
							if (!(ssceneInteractionCrossStateEffect == null) && ssceneInteractionCrossStateEffect.Effect != null)
							{
								if (this.CrossStateEffectActors == null)
								{
									this.CrossStateEffectActors = new HashSet<BP_EffectActor_C>();
								}
								this.CrossStateEffectActors.Add(ssceneInteractionCrossStateEffect.Effect);
							}
						}
					}
				}
			}
		}
		if (this.ReferenceActors != null && this.ReferenceActors.Num() > 0)
		{
			this.ActorsOriginalRelTransform = new Dictionary<AActor, FTransformDouble>();
			for (int l = 0; l < this.ReferenceActors.Num(); l++)
			{
				string key2 = this.ReferenceActors.GetKey(l);
				AActor valueOrDefault2 = this.ReferenceActors.GetValueOrDefault(key2);
				if (valueOrDefault2 != null)
				{
					FTransformDouble ftransformDouble = valueOrDefault2.D_GetTransform();
					FTransformDouble ftransformDouble2 = base.D_GetTransform();
					FTransformDouble relativeTransform = ftransformDouble.GetRelativeTransform(ftransformDouble2);
					this.ActorsOriginalRelTransform[valueOrDefault2] = relativeTransform;
				}
			}
		}
		this.RevertMaterialComponentsMaps = new Dictionary<UStaticMeshComponent, Dictionary<int, UMaterialInterface>>();
		if (this.States != null)
		{
			int m = 0;
			int num = this.States.Num();
			while (m < num)
			{
				EKuroSceneInteractionState key3 = this.States.GetKey(m);
				SSceneInteractionitem valueOrDefault3 = this.States.GetValueOrDefault(key3);
				foreach (TArray<AKuroDestructibleActor> tarray in new List<TArray<AKuroDestructibleActor>>
				{
					valueOrDefault3.SkeletalMeshDestructible.PlayDestructionAllImmediately,
					valueOrDefault3.SkeletalMeshDestructible.CanPlayDestructionWhenHit
				})
				{
					int n = 0;
					int num2 = tarray.Num();
					while (n < num2)
					{
						AKuroDestructibleActor akuroDestructibleActor = tarray.Get(n);
						if (akuroDestructibleActor != null && akuroDestructibleActor.IsValid())
						{
							this.SkeletalMeshDestructibleActors.Add(akuroDestructibleActor);
						}
						n++;
					}
				}
				m++;
			}
		}
		if (this.TagsAndCorrespondingEffects != null)
		{
			int num3 = 0;
			int num4 = this.TagsAndCorrespondingEffects.Num();
			while (num3 < num4)
			{
				FGameplayTag key4 = this.TagsAndCorrespondingEffects.GetKey(num3);
				SSceneInteractionTags valueOrDefault4 = this.TagsAndCorrespondingEffects.GetValueOrDefault(key4);
				int num5 = 0;
				int num6 = valueOrDefault4.SkeletalMeshDestructibleActors.Num();
				while (num5 < num6)
				{
					AKuroDestructibleActor akuroDestructibleActor2 = valueOrDefault4.SkeletalMeshDestructibleActors.Get(num5);
					if (akuroDestructibleActor2 != null && akuroDestructibleActor2.IsValid())
					{
						this.SkeletalMeshDestructibleActors.Add(akuroDestructibleActor2);
					}
					num5++;
				}
				num3++;
			}
		}
		if (this.SkeletalMeshDestructibleActors != null && this.SkeletalMeshDestructibleActors.Count > 0)
		{
			this.SkeletalMeshDestructibleActorInitCount = 0;
			using (HashSet<AKuroDestructibleActor>.Enumerator enumerator2 = this.SkeletalMeshDestructibleActors.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					AKuroDestructibleActor akuroDestructibleActor3 = enumerator2.Current;
					akuroDestructibleActor3.TrunksInitializedDelegate.Bind(new Action(this.OnTrunksInitialized));
				}
				goto IL_4BD;
			}
		}
		Action onInitCallback = this.OnInitCallback;
		if (onInitCallback != null)
		{
			onInitCallback();
		}
		IL_4BD:
		if (!ModelBase<LevelPrefabConfigModel>.Instance.IsCloseUroPrefab(this.LevelName))
		{
			this.ApplyAnimOptimizationParams(true);
		}
	}

	// Token: 0x0601BEE0 RID: 114400 RVA: 0x008522B4 File Offset: 0x008504B4
	public void Clear()
	{
		this.SkeletalMeshDestructibleActorsInternal = null;
		if (this.ActiveSequenceDirectorMap == null)
		{
			return;
		}
		foreach (ULevelSequence sequence in this.ActiveSequenceDirectorMap.Keys)
		{
			this.StopSequence(sequence);
		}
	}

	// Token: 0x0601BEE1 RID: 114401 RVA: 0x0085231C File Offset: 0x0085051C
	private void OnTrunksInitialized()
	{
		if (this.SkeletalMeshDestructibleActors != null)
		{
			this.SkeletalMeshDestructibleActorInitCount++;
			if (this.SkeletalMeshDestructibleActorInitCount >= this.SkeletalMeshDestructibleActors.Count)
			{
				foreach (AKuroDestructibleActor akuroDestructibleActor in this.SkeletalMeshDestructibleActors)
				{
					akuroDestructibleActor.TrunksInitializedDelegate.Unbind();
				}
				Action onInitCallback = this.OnInitCallback;
				if (onInitCallback == null)
				{
					return;
				}
				onInitCallback();
			}
		}
	}

	// Token: 0x0601BEE2 RID: 114402 RVA: 0x008523AC File Offset: 0x008505AC
	[return: Nullable(2)]
	public AActor GetActorByKey(string key)
	{
		if (this.ReferenceActors == null)
		{
			return null;
		}
		AActor result;
		if (!this.ReferenceActors.TryGetValue(key, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0601BEE3 RID: 114403 RVA: 0x008523D8 File Offset: 0x008505D8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public TArray<AActor> GetRefActorsByTag(FGameplayTag tag)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (this.TagsAndCorrespondingEffects == null || !this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return null;
		}
		if (ssceneInteractionTags == null)
		{
			return null;
		}
		return ssceneInteractionTags.Actors;
	}

	// Token: 0x0601BEE4 RID: 114404 RVA: 0x0085240A File Offset: 0x0085060A
	[return: Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public TMap<string, AActor> GetAllActor()
	{
		if (this.ReferenceActors != null)
		{
			return this.ReferenceActors;
		}
		return null;
	}

	// Token: 0x0601BEE5 RID: 114405 RVA: 0x0085241C File Offset: 0x0085061C
	public FTransformDouble? GetActorOriginalRelTransform(AActor actor)
	{
		if (this.ActorsOriginalRelTransform == null || (actor == null || !actor.IsValid()))
		{
			return null;
		}
		FTransformDouble value;
		if (this.ActorsOriginalRelTransform.TryGetValue(actor, out value))
		{
			return new FTransformDouble?(value);
		}
		return null;
	}

	// Token: 0x0601BEE6 RID: 114406 RVA: 0x0085246C File Offset: 0x0085066C
	public EKuroSceneInteractionState GetCurrentState()
	{
		return this.CurrentStateKey.Value;
	}

	// Token: 0x0601BEE7 RID: 114407 RVA: 0x0085247C File Offset: 0x0085067C
	private void PlayEffect(BP_EffectActor_C effectActor, string reason)
	{
		if (effectActor == null || !effectActor.IsValid())
		{
			return;
		}
		TArray<BP_EffectActor_C> effectsInheritTimeDilation = this.EffectsInheritTimeDilation;
		bool isInheritTimeDilation = effectsInheritTimeDilation != null && effectsInheritTimeDilation.Contains(effectActor);
		effectActor.Play(reason);
		int num = 0;
		effectActor.GetHandle(ref num);
		int num2 = num;
		if (Singleton<EffectSystem>.Instance.IsValid(num2))
		{
			if (this.ActiveEffectInfoMap == null)
			{
				this.ActiveEffectInfoMap = new Dictionary<int, EffectInfo>();
			}
			EffectInfo effectInfo;
			if (!this.ActiveEffectInfoMap.TryGetValue(num2, out effectInfo))
			{
				effectInfo = new EffectInfo(effectActor, isInheritTimeDilation);
				effectInfo.EffectId = num2;
				this.ActiveEffectInfoMap.Add(num2, effectInfo);
			}
			if (Singleton<EffectSystem>.Instance.IsPlaying(num2))
			{
				effectInfo.IsPlaying = true;
			}
			else
			{
				effectInfo.IsPlaying = false;
				Singleton<EffectSystem>.Instance.DynamicRegisterSpawnCallback(num2, this.OnEffectPlayingCallback);
			}
			if (effectInfo.IsInheritTimeDilation)
			{
				Singleton<EffectSystem>.Instance.SetTimeScale(num2, base.CustomTimeDilation, false);
			}
			Singleton<EffectSystem>.Instance.AddFinishCallback(num2, this.OnEffectFinishCallback);
			if (this.OverrideEffectParmaFunc != null && effectActor == this.OverrideEffectActor)
			{
				this.OverrideEffectParmaFunc();
			}
		}
	}

	// Token: 0x0601BEE8 RID: 114408 RVA: 0x00852588 File Offset: 0x00850788
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual bool CheckAllEffectPlaying()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("CheckAllEffectPlaying"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__CheckAllEffectPlaying_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__CheckAllEffectPlaying_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__CheckAllEffectPlaying_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BEE9 RID: 114409 RVA: 0x00852600 File Offset: 0x00850800
	protected bool CheckAllEffectPlaying_Implementation()
	{
		if (this.ActiveEffectInfoMap == null)
		{
			return false;
		}
		using (Dictionary<int, EffectInfo>.ValueCollection.Enumerator enumerator = this.ActiveEffectInfoMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsPlaying)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0601BEEA RID: 114410 RVA: 0x00852668 File Offset: 0x00850868
	private void StopEffect(BP_EffectActor_C effectActor, string reason, bool immediately)
	{
		if (effectActor == null || !effectActor.IsValid())
		{
			return;
		}
		effectActor.Stop(reason, immediately);
	}

	// Token: 0x0601BEEB RID: 114411 RVA: 0x00852688 File Offset: 0x00850888
	private unsafe void PlaySequence(ALevelSequenceActor director, SSceneInteractionSequence config, TArray<AActor> bindActors, bool jumpToEnd)
	{
		if (!this.Active)
		{
			return;
		}
		ULevelSequence sequence = config.Sequence;
		if (sequence == null || !sequence.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "[PlaySequence] 配置的Sequence已失效(可能已被GC或所在关卡已卸载), 跳过播放";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LevelName", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HandleID", this.HandleId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (!this.IsValid())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Interaction;
			ELogAuthor author2 = ELogAuthor.XDW;
			string message2 = "[PlaySequence] SceneInteractionActor自身已失效, 跳过播放";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("LevelName", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("HandleID", this.HandleId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		if (this.DirectorConfigMap == null)
		{
			this.DirectorConfigMap = new Dictionary<ALevelSequenceActor, SequenceDirectorConfig>();
		}
		this.DirectorConfigMap[director] = new SequenceDirectorConfig(config, false, 0f, false);
		director.SetActorTickEnabled(true);
		UActorComponent uactorComponent = (director != null) ? director.GetComponentByClass(UAkComponent.StaticClass()) : null;
		if (uactorComponent != null && uactorComponent.IsValid())
		{
			uactorComponent.SetComponentTickEnabled(true);
		}
		this.GetKuroSceneInteractionActorSystem().SetSequenceWithTargetLevelActor(director, config.Sequence, this);
		for (int i = 0; i < bindActors.Num(); i++)
		{
			AActor aactor = bindActors.Get(i);
			if (aactor != null)
			{
				this.GetKuroSceneInteractionActorSystem().BindActorToLevelSequenceActor(aactor, director, UKismetSystemLibrary.GetDisplayName(aactor));
			}
		}
		if (this.OverrideSeqBindActors != null && this.OverrideSeqBindActors.Count > 0)
		{
			foreach (KeyValuePair<string, AActor> keyValuePair in this.OverrideSeqBindActors)
			{
				string key = keyValuePair.Key;
				AActor value = keyValuePair.Value;
				if (value.IsValid())
				{
					this.GetKuroSceneInteractionActorSystem().BindActorToLevelSequenceActor(value, director, key);
				}
			}
		}
		if (director.SequencePlayer != null)
		{
			ModelBase<MechanismTimelineModel>.Instance.RegisterSequenceContext(director.SequencePlayer, new MechanismEventLevelPrefabContext(this.PbDataId, (int)this.HandleId));
			this.IsPlayBack = false;
			if (config.IsLoop)
			{
				if (config.Reverse)
				{
					director.SequencePlayer.PlayReverseLooping(-1);
				}
				else
				{
					director.SequencePlayer.PlayLooping(-1);
				}
			}
			else if (config.Reverse)
			{
				director.SequencePlayer.PlayReverse();
			}
			else
			{
				director.SequencePlayer.Play();
			}
			if (jumpToEnd)
			{
				FMovieSceneSequencePlaybackParams playbackPosition = new FMovieSceneSequencePlaybackParams(config.Reverse ? director.SequencePlayer.GetStartTime().Time : director.SequencePlayer.GetEndTime().Time, 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Play);
				director.SequencePlayer.SetPlaybackPosition(playbackPosition);
			}
			director.SequencePlayer.SetPlayRate(config.PlayRate * base.CustomTimeDilation);
		}
	}

	// Token: 0x0601BEEC RID: 114412 RVA: 0x008529E0 File Offset: 0x00850BE0
	private void StopSequence(ULevelSequence sequence)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		if (directorBySequence != null)
		{
			directorBySequence.SequencePlayer.Stop();
			directorBySequence.SetActorTickEnabled(false);
			UActorComponent uactorComponent = (directorBySequence != null) ? directorBySequence.GetComponentByClass(UAkComponent.StaticClass()) : null;
			if (uactorComponent != null && uactorComponent.IsValid())
			{
				uactorComponent.SetComponentTickEnabled(false);
			}
		}
	}

	// Token: 0x0601BEED RID: 114413 RVA: 0x00852A34 File Offset: 0x00850C34
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void PlayKuroSkeletalMeshDestruction(AActor actor, bool isJumpToEnd)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PlayKuroSkeletalMeshDestruction"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__PlayKuroSkeletalMeshDestruction_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__PlayKuroSkeletalMeshDestruction_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__PlayKuroSkeletalMeshDestruction_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->actor) = ((actor != null) ? actor.NativePtr : ((IntPtr)0));
			ptr2->isJumpToEnd = isJumpToEnd;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BEEE RID: 114414 RVA: 0x00852AC0 File Offset: 0x00850CC0
	protected void PlayKuroSkeletalMeshDestruction_Implementation(AActor actor, bool isJumpToEnd)
	{
		SSceneInteractionitem currentState = this.CurrentState;
		SSceneInteractionActorSkeletalMeshDestructible ssceneInteractionActorSkeletalMeshDestructible = (currentState != null) ? currentState.SkeletalMeshDestructible : null;
		if (((ssceneInteractionActorSkeletalMeshDestructible != null) ? ssceneInteractionActorSkeletalMeshDestructible.CanPlayDestructionWhenHit : null) != null)
		{
			AKuroDestructibleActor akuroDestructibleActor = actor as AKuroDestructibleActor;
			if (akuroDestructibleActor != null)
			{
				if (ssceneInteractionActorSkeletalMeshDestructible.CanPlayDestructionWhenHit.FindIndex(akuroDestructibleActor) != -1)
				{
					this.PlaySkeletalMeshDestruction(akuroDestructibleActor, isJumpToEnd, ssceneInteractionActorSkeletalMeshDestructible.HitInfo);
				}
				return;
			}
		}
	}

	// Token: 0x0601BEEF RID: 114415 RVA: 0x00852B18 File Offset: 0x00850D18
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OverrideKuroDestructibleActorPhysicsVelocity(AKuroDestructibleActor skeletalMeshDestruction)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OverrideKuroDestructibleActorPhysicsVelocity"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__OverrideKuroDestructibleActorPhysicsVelocity_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__OverrideKuroDestructibleActorPhysicsVelocity_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__OverrideKuroDestructibleActorPhysicsVelocity_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->skeletalMeshDestruction) = ((skeletalMeshDestruction != null) ? skeletalMeshDestruction.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BEF0 RID: 114416 RVA: 0x00852B9C File Offset: 0x00850D9C
	protected void OverrideKuroDestructibleActorPhysicsVelocity_Implementation(AKuroDestructibleActor skeletalMeshDestruction)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.PbDataId);
		UKuroDestructibleDestructionAsset kuroDestructibleDestructionAsset = skeletalMeshDestruction.KuroDestructibleDestructionAsset;
		if (kuroDestructibleDestructionAsset == null || !kuroDestructibleDestructionAsset.bTrunksKeepLinearVelocity)
		{
			UKuroDestructibleDestructionAsset kuroDestructibleDestructionAsset2 = skeletalMeshDestruction.KuroDestructibleDestructionAsset;
			if (kuroDestructibleDestructionAsset2 == null || !kuroDestructibleDestructionAsset2.bTrunksKeepAngularVelocity)
			{
				return;
			}
		}
		if (entityByPbDataId != null && entityByPbDataId.Valid)
		{
			WorldEntity entity = entityByPbDataId.Entity;
			if (entity != null && entity.Valid)
			{
				BaseActorComponent baseActorComponent = entityByPbDataId.Entity.CheckGetComponent<BaseActorComponent>();
				UStaticMeshComponent proxyMeshComponent = skeletalMeshDestruction.GetProxyMeshComponent();
				if (baseActorComponent != null)
				{
					AActor owner = baseActorComponent.Owner;
					UPrimitiveComponent uprimitiveComponent = ((owner != null) ? owner.GetComponentByClass(UPrimitiveComponent.StaticClass()) : null) as UPrimitiveComponent;
					if (uprimitiveComponent != null && uprimitiveComponent.IsValid() && uprimitiveComponent.IsSimulatingPhysics(default(FName)) && proxyMeshComponent != null && proxyMeshComponent.IsValid())
					{
						UKuroDestructibleDestructionAsset kuroDestructibleDestructionAsset3 = skeletalMeshDestruction.KuroDestructibleDestructionAsset;
						if (kuroDestructibleDestructionAsset3 != null && kuroDestructibleDestructionAsset3.bTrunksKeepLinearVelocity)
						{
							proxyMeshComponent.SetPhysicsLinearVelocity(uprimitiveComponent.GetPhysicsLinearVelocity(default(FName)), false, default(FName));
						}
						UKuroDestructibleDestructionAsset kuroDestructibleDestructionAsset4 = skeletalMeshDestruction.KuroDestructibleDestructionAsset;
						if (kuroDestructibleDestructionAsset4 != null && kuroDestructibleDestructionAsset4.bTrunksKeepAngularVelocity)
						{
							proxyMeshComponent.SetPhysicsAngularVelocityInDegrees(uprimitiveComponent.GetPhysicsAngularVelocityInDegrees(default(FName)), false, default(FName));
						}
					}
				}
			}
		}
	}

	// Token: 0x0601BEF1 RID: 114417 RVA: 0x00852CE0 File Offset: 0x00850EE0
	private unsafe void PlaySkeletalMeshDestruction(AKuroDestructibleActor skeletalMeshDestruction, bool isJumpToEnd, [Nullable(2)] SSceneInteractionDestructibleInfo skeletalMeshDestructionConfig)
	{
		if (skeletalMeshDestruction == null || !skeletalMeshDestruction.IsValid())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Interaction;
			ELogAuthor author = ELogAuthor.XDW;
			string message = "可破坏物SceneInteractionActor配置有错";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LevelName", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentState", this.CurrentState);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (isJumpToEnd)
		{
			skeletalMeshDestruction.SetActorHiddenInGame(true);
			skeletalMeshDestruction.SetActorEnableCollision(false);
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.SceneGameplay;
		ELogAuthor author2 = ELogAuthor.LJM;
		string message2 = "[SceneInteractionActor]PlaySkeletalMeshDestruction";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("DestructActor:", skeletalMeshDestruction);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Location:", skeletalMeshDestruction.K2_GetActorLocation());
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		this.OverrideKuroDestructibleActorPhysicsVelocity(skeletalMeshDestruction);
		FVectorDouble? fvectorDouble = null;
		FVectorDouble? fvectorDouble2 = null;
		float impulseStrength = 1f;
		FVectorDouble value;
		switch ((skeletalMeshDestructionConfig != null) ? skeletalMeshDestructionConfig.HitType : BPELevelPrefabDestructibleHitInfo.BPELevelPrefabDestructibleHitInfo_MAX)
		{
		case BPELevelPrefabDestructibleHitInfo.子弹_受击点和地面受击速度_:
			if (this.HitLocation != null)
			{
				fvectorDouble = this.HitLocation;
			}
			fvectorDouble2 = new FVectorDouble?(this.HitDirection);
			value = fvectorDouble2.Value;
			impulseStrength = (float)value.Size();
			break;
		case BPELevelPrefabDestructibleHitInfo.和实体Range组件Overlap的Actor的位置:
			if (this.RangeOtherActorLocation != null)
			{
				fvectorDouble = this.RangeOtherActorLocation;
			}
			break;
		case BPELevelPrefabDestructibleHitInfo.和实体Range组件Overlap的Actor的位置和Actor的速度_前提有速度_:
			if (this.RangeOtherActorLocation != null)
			{
				fvectorDouble = this.RangeOtherActorLocation;
			}
			if (this.RangeOtherActorVelocityProxy != null)
			{
				fvectorDouble2 = new FVectorDouble?(this.RangeOtherActorVelocityProxy.ToUeVector(false));
				impulseStrength = (float)this.RangeOtherActorVelocityProxy.Size();
			}
			break;
		case BPELevelPrefabDestructibleHitInfo.和实体Range组件Overlap的Actor的位置和Actor的速度_曲线_:
			if (this.RangeOtherActorLocation != null)
			{
				fvectorDouble = this.RangeOtherActorLocation;
			}
			if (this.RangeOtherActorVelocityProxy != null)
			{
				impulseStrength = LevelGamePlayUtils.GetValueInCurveFloatRange(skeletalMeshDestructionConfig.ImpulseStrengthFloatRange, (float)this.RangeOtherActorVelocityProxy.Size());
				fvectorDouble2 = new FVectorDouble?(this.RangeOtherActorVelocityProxy.ToUeVector(false));
			}
			break;
		}
		if (fvectorDouble == null)
		{
			fvectorDouble = new FVectorDouble?(this.HitLocation ?? skeletalMeshDestruction.D_K2_GetActorLocation());
		}
		if (fvectorDouble2 == null)
		{
			fvectorDouble2 = new FVectorDouble?(this.HitDirection);
			value = fvectorDouble2.Value;
			impulseStrength = (float)value.Size();
		}
		float damageAmount = 1f;
		value = fvectorDouble.Value;
		FVectorDouble value2 = fvectorDouble2.Value;
		skeletalMeshDestruction.D_ApplyDamage(damageAmount, value, value2, impulseStrength);
	}

	// Token: 0x0601BEF2 RID: 114418 RVA: 0x00852F74 File Offset: 0x00851174
	private float? GetActiveSequencePlaybackProgress(ULevelSequence sequence)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return null;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return null;
		}
		if (sequenceDirectorConfig == null)
		{
			return null;
		}
		FFrameTime time = ulevelSequencePlayer.GetDuration().Time;
		float num = (float)time.FrameNumber.Value + time.SubFrame;
		if (num < 1f)
		{
			return null;
		}
		FFrameTime time2 = ulevelSequencePlayer.GetStartTime().Time;
		FFrameTime time3 = ulevelSequencePlayer.GetEndTime().Time;
		float num2 = (float)time2.FrameNumber.Value + time2.SubFrame;
		float num3 = (float)time3.FrameNumber.Value + time3.SubFrame;
		if (num2 > num3)
		{
			return null;
		}
		FFrameTime time4 = ulevelSequencePlayer.GetCurrentTime().Time;
		float num4 = (float)time4.FrameNumber.Value + time4.SubFrame;
		float num5;
		if (!sequenceDirectorConfig.Reverse)
		{
			num5 = num4 - num2;
		}
		else
		{
			num5 = num3 - num4;
		}
		num5 = Singleton<MathUtils>.Instance.Clamp(num5, num2, num3);
		return new float?(Singleton<MathUtils>.Instance.Clamp(num5 / num, 0f, 1f));
	}

	// Token: 0x0601BEF3 RID: 114419 RVA: 0x008530E0 File Offset: 0x008512E0
	private void SetActiveSequencePlaybackProgress(ULevelSequence sequence, float progress)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return;
		}
		if (sequenceDirectorConfig == null)
		{
			return;
		}
		FFrameTime time = ulevelSequencePlayer.GetDuration().Time;
		float num = (float)time.FrameNumber.Value + time.SubFrame;
		float num2 = num * Singleton<MathUtils>.Instance.Clamp(progress, 0f, 1f);
		if (num < 1f || num2 > num)
		{
			return;
		}
		FFrameTime time2 = ulevelSequencePlayer.GetStartTime().Time;
		FFrameTime time3 = ulevelSequencePlayer.GetEndTime().Time;
		float num3 = (float)time2.FrameNumber.Value + time2.SubFrame;
		float num4 = (float)time3.FrameNumber.Value + time3.SubFrame;
		if (num3 > num4)
		{
			return;
		}
		float num5;
		if (!sequenceDirectorConfig.Reverse)
		{
			num5 = num3 + num2;
		}
		else
		{
			num5 = num4 - num2;
		}
		num5 = Singleton<MathUtils>.Instance.Clamp(num5, num3, num4);
		int num6 = (int)Math.Floor((double)num5);
		float subFrame = num5 - (float)num6;
		FFrameTime frame = new FFrameTime(new FFrameNumber(num6), subFrame);
		FFrameTime time4 = ulevelSequencePlayer.GetCurrentTime().Time;
		float num7 = (float)time4.FrameNumber.Value + time4.SubFrame;
		if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num7, (double)num5, new double?(0.0001)))
		{
			return;
		}
		FMovieSceneSequencePlaybackParams playbackPosition = new FMovieSceneSequencePlaybackParams(frame, 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Play);
		ulevelSequencePlayer.SetPlaybackPosition(playbackPosition);
	}

	// Token: 0x0601BEF4 RID: 114420 RVA: 0x0085327C File Offset: 0x0085147C
	private unsafe void SetActorCollisionProfile(TMap<AActor, FCollisionProfileName> profileMap)
	{
		if (profileMap == null)
		{
			return;
		}
		for (int i = 0; i < profileMap.Num(); i++)
		{
			AActor key = profileMap.GetKey(i);
			FCollisionProfileName valueOrDefault = profileMap.GetValueOrDefault(key);
			if (key == null || valueOrDefault == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.CK;
				string message = "场景交互物状态机碰撞预设配置不合法, 检查配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("交互物Actor", this.LevelName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("碰撞Actor", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("碰撞Profile", valueOrDefault);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			else
			{
				UStaticMeshComponent ustaticMeshComponent = key.GetComponentByClass(UStaticMeshComponent.StaticClass()) as UStaticMeshComponent;
				UPrimitiveComponent uprimitiveComponent;
				if (ustaticMeshComponent == null)
				{
					uprimitiveComponent = (key.GetComponentByClass(UShapeComponent.StaticClass()) as UShapeComponent);
					if (uprimitiveComponent == null)
					{
						goto IL_101;
					}
				}
				else
				{
					uprimitiveComponent = ustaticMeshComponent;
				}
				if (uprimitiveComponent.GetCollisionProfileName() == valueOrDefault.Name)
				{
					return;
				}
				uprimitiveComponent.SetCollisionProfileName(valueOrDefault.Name, true);
			}
			IL_101:;
		}
	}

	// Token: 0x0601BEF5 RID: 114421 RVA: 0x0085339C File Offset: 0x0085159C
	public float? GetActiveTagSequencePlaybackProgress(FGameplayTag tag)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return null;
		}
		SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
		ULevelSequence ulevelSequence = (sequence != null) ? sequence.Sequence : null;
		if (ulevelSequence == null)
		{
			return null;
		}
		return this.GetActiveSequencePlaybackProgress(ulevelSequence);
	}

	// Token: 0x0601BEF6 RID: 114422 RVA: 0x008533EC File Offset: 0x008515EC
	public void SetActiveTagSequencePlaybackProgress(FGameplayTag tag, float progress)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return;
		}
		ULevelSequence ulevelSequence;
		if (ssceneInteractionTags == null)
		{
			ulevelSequence = null;
		}
		else
		{
			SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
			ulevelSequence = ((sequence != null) ? sequence.Sequence : null);
		}
		ULevelSequence ulevelSequence2 = ulevelSequence;
		if (ulevelSequence2 == null)
		{
			return;
		}
		this.SetActiveSequencePlaybackProgress(ulevelSequence2, progress);
	}

	// Token: 0x0601BEF7 RID: 114423 RVA: 0x00853430 File Offset: 0x00851630
	public float? GetActiveSequenceDurationTime(ULevelSequence sequence)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return null;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return null;
		}
		if (sequenceDirectorConfig == null)
		{
			return null;
		}
		FQualifiedFrameTime duration = ulevelSequencePlayer.GetDuration();
		float num = (float)duration.Time.FrameNumber.Value + duration.Time.SubFrame;
		if (num < 1f)
		{
			return null;
		}
		float num2 = (float)duration.Rate.Denominator / (float)duration.Rate.Numerator;
		return new float?(num * num2);
	}

	// Token: 0x0601BEF8 RID: 114424 RVA: 0x008534FC File Offset: 0x008516FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float GetActiveSequenceRemainTime(ULevelSequence sequence)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetActiveSequenceRemainTime"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__GetActiveSequenceRemainTime_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__GetActiveSequenceRemainTime_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__GetActiveSequenceRemainTime_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->sequence) = ((sequence != null) ? sequence.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BEF9 RID: 114425 RVA: 0x00853588 File Offset: 0x00851788
	protected float GetActiveSequenceRemainTime_Implementation(ULevelSequence sequence)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return 0f;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return 0f;
		}
		float num;
		float num2;
		if (!ulevelSequencePlayer.IsReversed())
		{
			FQualifiedFrameTime endTime = ulevelSequencePlayer.GetEndTime();
			FQualifiedFrameTime currentTime = ulevelSequencePlayer.GetCurrentTime();
			num = (float)endTime.Time.FrameNumber.Value + endTime.Time.SubFrame - (float)currentTime.Time.FrameNumber.Value - currentTime.Time.SubFrame;
			num2 = (float)currentTime.Rate.Denominator / (float)currentTime.Rate.Numerator;
		}
		else
		{
			FQualifiedFrameTime startTime = ulevelSequencePlayer.GetStartTime();
			FQualifiedFrameTime currentTime2 = ulevelSequencePlayer.GetCurrentTime();
			num = (float)currentTime2.Time.FrameNumber.Value + currentTime2.Time.SubFrame - (float)startTime.Time.FrameNumber.Value - startTime.Time.SubFrame;
			num2 = (float)currentTime2.Rate.Denominator / (float)currentTime2.Rate.Numerator;
		}
		if (num < 1f)
		{
			return 0f;
		}
		return num * num2;
	}

	// Token: 0x0601BEFA RID: 114426 RVA: 0x008536E0 File Offset: 0x008518E0
	public float? GetActiveTagSequenceDurationTime(FGameplayTag tag)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return null;
		}
		ULevelSequence ulevelSequence;
		if (ssceneInteractionTags == null)
		{
			ulevelSequence = null;
		}
		else
		{
			SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
			ulevelSequence = ((sequence != null) ? sequence.Sequence : null);
		}
		ULevelSequence ulevelSequence2 = ulevelSequence;
		if (ulevelSequence2 == null)
		{
			return null;
		}
		return this.GetActiveSequenceDurationTime(ulevelSequence2);
	}

	// Token: 0x0601BEFB RID: 114427 RVA: 0x00853734 File Offset: 0x00851934
	public void SetActiveSequenceDurationTime(ULevelSequence sequence, float durationSecond)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return;
		}
		if (sequenceDirectorConfig == null)
		{
			return;
		}
		FQualifiedFrameTime duration = ulevelSequencePlayer.GetDuration();
		float num = (float)duration.Time.FrameNumber.Value + duration.Time.SubFrame;
		if (num < 1f)
		{
			return;
		}
		float num2 = (float)duration.Rate.Denominator / (float)duration.Rate.Numerator;
		float num3 = num * num2 / durationSecond;
		if (num3 == 0f || !float.IsFinite(num3) || float.IsNaN(num3) || Singleton<MathUtils>.Instance.IsNearlyZero((double)num3, null))
		{
			return;
		}
		sequenceDirectorConfig.PlayRateOverride = num3;
		ulevelSequencePlayer.SetPlayRate(num3 * base.CustomTimeDilation);
	}

	// Token: 0x0601BEFC RID: 114428 RVA: 0x00853820 File Offset: 0x00851A20
	public void SetActiveTagSequenceDurationTime(FGameplayTag tag, float durationSecond)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return;
		}
		ULevelSequence ulevelSequence;
		if (ssceneInteractionTags == null)
		{
			ulevelSequence = null;
		}
		else
		{
			SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
			ulevelSequence = ((sequence != null) ? sequence.Sequence : null);
		}
		ULevelSequence ulevelSequence2 = ulevelSequence;
		if (ulevelSequence2 == null)
		{
			return;
		}
		this.SetActiveSequenceDurationTime(ulevelSequence2, durationSecond);
	}

	// Token: 0x0601BEFD RID: 114429 RVA: 0x00853864 File Offset: 0x00851A64
	private void PauseActiveSequence(ULevelSequence sequence)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return;
		}
		if (ulevelSequencePlayer.IsPaused())
		{
			return;
		}
		ulevelSequencePlayer.Pause();
	}

	// Token: 0x0601BEFE RID: 114430 RVA: 0x008538AC File Offset: 0x00851AAC
	public void PauseActiveTagSequence(FGameplayTag tag)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return;
		}
		ULevelSequence ulevelSequence;
		if (ssceneInteractionTags == null)
		{
			ulevelSequence = null;
		}
		else
		{
			SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
			ulevelSequence = ((sequence != null) ? sequence.Sequence : null);
		}
		ULevelSequence ulevelSequence2 = ulevelSequence;
		if (ulevelSequence2 == null)
		{
			return;
		}
		this.PauseActiveSequence(ulevelSequence2);
	}

	// Token: 0x0601BEFF RID: 114431 RVA: 0x008538F0 File Offset: 0x00851AF0
	private void ResumeActiveSequence(ULevelSequence sequence, bool bReverseFromConfig = false)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return;
		}
		if (sequenceDirectorConfig == null)
		{
			return;
		}
		if (ulevelSequencePlayer.IsPlaying())
		{
			ulevelSequencePlayer.Pause();
		}
		sequenceDirectorConfig.ReverseOverride = (bReverseFromConfig ? (!sequenceDirectorConfig.UeConfig.Reverse) : sequenceDirectorConfig.UeConfig.Reverse);
		if (sequenceDirectorConfig.Reverse)
		{
			if (sequenceDirectorConfig.IsLoop)
			{
				ulevelSequencePlayer.PlayReverseLooping(-1);
				return;
			}
			ulevelSequencePlayer.PlayReverse();
			return;
		}
		else
		{
			if (sequenceDirectorConfig.IsLoop)
			{
				ulevelSequencePlayer.PlayLooping(-1);
				return;
			}
			ulevelSequencePlayer.Play();
			return;
		}
	}

	// Token: 0x0601BF00 RID: 114432 RVA: 0x008539A4 File Offset: 0x00851BA4
	public void ResumeActiveTagSequence(FGameplayTag tag, bool bReverseFromConfig = false)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return;
		}
		ULevelSequence ulevelSequence;
		if (ssceneInteractionTags == null)
		{
			ulevelSequence = null;
		}
		else
		{
			SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
			ulevelSequence = ((sequence != null) ? sequence.Sequence : null);
		}
		ULevelSequence ulevelSequence2 = ulevelSequence;
		if (ulevelSequence2 == null)
		{
			return;
		}
		this.ResumeActiveSequence(ulevelSequence2, bReverseFromConfig);
	}

	// Token: 0x0601BF01 RID: 114433 RVA: 0x008539E8 File Offset: 0x00851BE8
	public bool? GetIsActiveSequencePlayReverseFromConfig(ULevelSequence sequence)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return null;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return null;
		}
		if (sequenceDirectorConfig == null)
		{
			return null;
		}
		return new bool?(sequenceDirectorConfig.Reverse != sequenceDirectorConfig.UeConfig.Reverse);
	}

	// Token: 0x0601BF02 RID: 114434 RVA: 0x00853A6C File Offset: 0x00851C6C
	public bool? GetIsActiveTagSequencePlayReverseFromConfig(FGameplayTag tag)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return null;
		}
		ULevelSequence ulevelSequence;
		if (ssceneInteractionTags == null)
		{
			ulevelSequence = null;
		}
		else
		{
			SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
			ulevelSequence = ((sequence != null) ? sequence.Sequence : null);
		}
		ULevelSequence ulevelSequence2 = ulevelSequence;
		if (ulevelSequence2 == null)
		{
			return null;
		}
		return this.GetIsActiveSequencePlayReverseFromConfig(ulevelSequence2);
	}

	// Token: 0x0601BF03 RID: 114435 RVA: 0x00853AC0 File Offset: 0x00851CC0
	private void PlayActiveSequenceTo(ULevelSequence sequence, float progress, bool bReverseFromConfig = false)
	{
		ALevelSequenceActor directorBySequence = this.GetDirectorBySequence(sequence);
		ULevelSequencePlayer ulevelSequencePlayer = (directorBySequence != null) ? directorBySequence.SequencePlayer : null;
		if (directorBySequence == null || (ulevelSequencePlayer == null || !ulevelSequencePlayer.IsValid()))
		{
			return;
		}
		SequenceDirectorConfig sequenceDirectorConfig;
		if (!this.DirectorConfigMap.TryGetValue(directorBySequence, out sequenceDirectorConfig))
		{
			return;
		}
		if (sequenceDirectorConfig == null)
		{
			return;
		}
		FFrameTime time = ulevelSequencePlayer.GetDuration().Time;
		float num = (float)time.FrameNumber.Value + time.SubFrame;
		float num2 = num * Singleton<MathUtils>.Instance.Clamp(progress, 0f, 1f);
		if (num < 1f || num2 > num)
		{
			return;
		}
		FFrameTime time2 = ulevelSequencePlayer.GetStartTime().Time;
		FFrameTime time3 = ulevelSequencePlayer.GetEndTime().Time;
		float num3 = (float)time2.FrameNumber.Value + time2.SubFrame;
		float num4 = (float)time3.FrameNumber.Value + time3.SubFrame;
		if (num3 > num4)
		{
			return;
		}
		sequenceDirectorConfig.ReverseOverride = (bReverseFromConfig ? (!sequenceDirectorConfig.UeConfig.Reverse) : sequenceDirectorConfig.UeConfig.Reverse);
		float num5;
		if (!sequenceDirectorConfig.Reverse)
		{
			num5 = num3 + num2;
		}
		else
		{
			num5 = num4 - num2;
		}
		num5 = Singleton<MathUtils>.Instance.Clamp(num5, num3, num4);
		int num6 = (int)Math.Floor((double)num5);
		float subFrame = num5 - (float)num6;
		FFrameTime frame = new FFrameTime(new FFrameNumber(num6), subFrame);
		FFrameTime time4 = ulevelSequencePlayer.GetCurrentTime().Time;
		float num7 = (float)time4.FrameNumber.Value + time4.SubFrame;
		if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num7, (double)num5, new double?(0.0001)))
		{
			return;
		}
		FMovieSceneSequencePlaybackParams inPlaybackParams = new FMovieSceneSequencePlaybackParams(frame, 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Play);
		ulevelSequencePlayer.PlayTo_Circle(inPlaybackParams, false, !sequenceDirectorConfig.Reverse);
	}

	// Token: 0x0601BF04 RID: 114436 RVA: 0x00853C8C File Offset: 0x00851E8C
	public void PlayActiveTagSequenceTo(FGameplayTag tag, float progress, bool bReverseFromConfig = false)
	{
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return;
		}
		ULevelSequence ulevelSequence;
		if (ssceneInteractionTags == null)
		{
			ulevelSequence = null;
		}
		else
		{
			SSceneInteractionSequence sequence = ssceneInteractionTags.Sequence;
			ulevelSequence = ((sequence != null) ? sequence.Sequence : null);
		}
		ULevelSequence ulevelSequence2 = ulevelSequence;
		if (ulevelSequence2 == null)
		{
			return;
		}
		this.PlayActiveSequenceTo(ulevelSequence2, progress, bReverseFromConfig);
	}

	// Token: 0x0601BF05 RID: 114437 RVA: 0x00853CD0 File Offset: 0x00851ED0
	public void PlayState(SSceneInteractionitem state, [Nullable(2)] SSceneInteractionitem lastState, bool jumpToEnd, EKuroSceneInteractionState targetState)
	{
		if (state != null)
		{
			this.PlayStateSequence(state, jumpToEnd);
			this.PlayStateMontage(state, lastState);
			this.PlayStateEffect(state);
			this.PlayStateMaterialController(state, jumpToEnd);
			this.PlayStateCharMaterialControllerNew(state);
			this.PlayStateCrossStateEffects(state);
			this.PostStateAkEvent(state, jumpToEnd);
			this.SetStateActorShow(state);
			this.SetStateActorHide(state);
			this.PlayStateBasedEffect(state, targetState);
			this.PlayStateSkeletalMeshDestruction(state, jumpToEnd);
			this.PlayStateBpMaterialRuntimeParUpdate(state);
			this.SetStateActorCollisionProfile(state, lastState);
			this.CurrentState = state;
			this.IsAbpAnimPlayEnd = false;
		}
	}

	// Token: 0x0601BF06 RID: 114438 RVA: 0x00853D58 File Offset: 0x00851F58
	private void PlayStateSequence(SSceneInteractionitem state, bool jumpToEnd)
	{
		if (state.Sequence.Sequence == null)
		{
			return;
		}
		ULevelSequencePlayer activeSequencePlayer = this.ActiveSequencePlayer;
		ULevelSequence ulevelSequence = ((activeSequencePlayer != null) ? activeSequencePlayer.Sequence : null) as ULevelSequence;
		if (ulevelSequence != null && ulevelSequence != state.Sequence.Sequence)
		{
			this.StopSequence(ulevelSequence);
		}
		ALevelSequenceActor alevelSequenceActor = this.CreateDirectorBySequence(state.Sequence.Sequence);
		if (alevelSequenceActor != null)
		{
			this.ActiveSequencePlayer = alevelSequenceActor.SequencePlayer;
			this.PlaySequence(alevelSequenceActor, state.Sequence, state.Actors, jumpToEnd);
		}
	}

	// Token: 0x0601BF07 RID: 114439 RVA: 0x00853DD8 File Offset: 0x00851FD8
	private void PlayStateMontage(SSceneInteractionitem state, [Nullable(2)] SSceneInteractionitem lastState)
	{
		if (state.AnimMontage.SkeletalMesh == null || state.AnimMontage.Montage == null)
		{
			return;
		}
		if (((lastState != null) ? lastState.AnimMontage.Montage : null) != null && lastState.AnimMontage.Montage == state.AnimMontage.Montage)
		{
			return;
		}
		if (this.SkeletalMontageConfigMap == null)
		{
			this.SkeletalMontageConfigMap = new Dictionary<ASkeletalMeshActor, SkeletalMontageConfig>();
		}
		SkeletalMontageConfig skeletalMontageConfig;
		if (!this.SkeletalMontageConfigMap.TryGetValue(state.AnimMontage.SkeletalMesh, out skeletalMontageConfig))
		{
			skeletalMontageConfig = new SkeletalMontageConfig(state.AnimMontage, 0, false, EVisibilityBasedAnimTickOption.OnlyTickPoseWhenRendered);
			this.SkeletalMontageConfigMap[state.AnimMontage.SkeletalMesh] = skeletalMontageConfig;
		}
		USkeletalMeshComponent skeletalMeshComponent = state.AnimMontage.SkeletalMesh.SkeletalMeshComponent;
		if (lastState == null || state.AnimMontage.SkeletalMesh.bHidden || skeletalMeshComponent.bHiddenInGame)
		{
			if (!skeletalMontageConfig.IsPendingApplyProps())
			{
				skeletalMontageConfig.PendingCompHiddenInGame = skeletalMeshComponent.bHiddenInGame;
				skeletalMontageConfig.PendingCompVisibilityBasedAnimTickOption = skeletalMeshComponent.VisibilityBasedAnimTickOption;
			}
			skeletalMontageConfig.PendingFrameCount = 2;
			skeletalMeshComponent.VisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.AlwaysTickPoseAndRefreshBones;
			skeletalMeshComponent.SetHiddenInGame(true, false);
		}
		if (!(skeletalMeshComponent.GetAnimationMode() == EAnimationMode.AnimationBlueprint))
		{
			skeletalMeshComponent.PlayAnimation(state.AnimMontage.Montage, state.AnimMontage.Loop);
			skeletalMeshComponent.SetPlayRate(state.AnimMontage.PlayRate * base.CustomTimeDilation);
			return;
		}
		UAnimInstance animInstance = skeletalMeshComponent.GetAnimInstance();
		if (animInstance == null)
		{
			skeletalMeshComponent.PlayAnimation(state.AnimMontage.Montage, state.AnimMontage.Loop);
			skeletalMeshComponent.SetPlayRate(state.AnimMontage.PlayRate * base.CustomTimeDilation);
			return;
		}
		ABP_LevelPrefabDaiyu_C abp_LevelPrefabDaiyu_C = animInstance as ABP_LevelPrefabDaiyu_C;
		if (abp_LevelPrefabDaiyu_C != null)
		{
			abp_LevelPrefabDaiyu_C.SetState(state.Name);
			abp_LevelPrefabDaiyu_C.SetPlayRate(base.CustomTimeDilation);
			return;
		}
		animInstance.Montage_Play(state.AnimMontage.Montage, state.AnimMontage.PlayRate * base.CustomTimeDilation, EMontagePlayReturnType.MontageLength, 0f, true);
	}

	// Token: 0x0601BF08 RID: 114440 RVA: 0x00853FC4 File Offset: 0x008521C4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void ApplyAnimOptimizationParams(bool bUseDistanceMap = true)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ApplyAnimOptimizationParams"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__ApplyAnimOptimizationParams_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__ApplyAnimOptimizationParams_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__ApplyAnimOptimizationParams_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->bUseDistanceMap = bUseDistanceMap;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF09 RID: 114441 RVA: 0x0085403C File Offset: 0x0085223C
	protected void ApplyAnimOptimizationParams_Implementation(bool bUseDistanceMap = true)
	{
		if (this.AllSkeletalMeshActors == null)
		{
			return;
		}
		bool flag = Singleton<Info>.Instance.IsMobilePlatform();
		FAnimUpdateRateParameters fanimUpdateRateParameters = new FAnimUpdateRateParameters();
		for (int i = 0; i < this.AllSkeletalMeshActors.Num(); i++)
		{
			ASkeletalMeshActor askeletalMeshActor = this.AllSkeletalMeshActors.Get(i);
			if (askeletalMeshActor == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Interaction;
				ELogAuthor author = ELogAuthor.CH;
				string message = "AllSkeletalMeshActors中有空的值，请找对应策划进行修改";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelName", this.LevelName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				USkeletalMeshComponent skeletalMeshComponent = askeletalMeshActor.SkeletalMeshComponent;
				if (skeletalMeshComponent != null)
				{
					int num = skeletalMeshComponent.LODInfo.Num();
					if (bUseDistanceMap)
					{
						fanimUpdateRateParameters.bShouldUseDistanceMap = true;
						fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Empty(true);
						fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 500 : 800));
						fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 1000 : 1500));
						fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 1500 : 4000));
						fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 2000 : 5000));
						fanimUpdateRateParameters.BaseVisibleDistanceThresholds.Add((float)(flag ? 3000 : 8000));
					}
					else
					{
						fanimUpdateRateParameters.bShouldUseLodMap = true;
						fanimUpdateRateParameters.LODToFrameSkipMap.Empty(0);
						for (int j = 0; j < num; j++)
						{
							int value = (j < 2) ? 0 : (j - 1);
							fanimUpdateRateParameters.LODToFrameSkipMap.Add(j, value);
						}
					}
					fanimUpdateRateParameters.BaseNonRenderedUpdateRate = (flag ? 15 : 8);
					fanimUpdateRateParameters.MaxEvalRateForInterpolation = 8;
					skeletalMeshComponent.SetAnimUpdateRateParameters(ref fanimUpdateRateParameters);
					skeletalMeshComponent.bEnableUpdateRateOptimizations = true;
					skeletalMeshComponent.VisibilityBasedAnimTickOption = EVisibilityBasedAnimTickOption.OnlyTickPoseWhenRendered;
					skeletalMeshComponent.bUpdateOverlapsOnAnimationFinalize = false;
				}
			}
		}
	}

	// Token: 0x0601BF0A RID: 114442 RVA: 0x00854200 File Offset: 0x00852400
	private void PlayStateEffect(SSceneInteractionitem state)
	{
		if (state.Effects == null)
		{
			return;
		}
		for (int i = 0; i < state.Effects.Num(); i++)
		{
			this.PendingStateEffects.Add(state.Effects.Get(i));
		}
		Ticker ticker = Singleton<TickSystem>.Instance.Add(delegate(float delay)
		{
			if (this.IsValid())
			{
				this.PendingPlayStateEffect();
			}
		}, "SceneInteractionActor.PendingStateEffectTick", ETickingGroup.TG_PrePhysics, true, 0, false);
		if (ticker != null)
		{
			this.PendingStateEffectTickId = ticker.Id;
		}
	}

	// Token: 0x0601BF0B RID: 114443 RVA: 0x00854274 File Offset: 0x00852474
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void PendingPlayStateEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PendingPlayStateEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF0C RID: 114444 RVA: 0x008542E4 File Offset: 0x008524E4
	protected void PendingPlayStateEffect_Implementation()
	{
		if (this.PendingStateEffects.Count == 0)
		{
			this.RemovePendingStateEffectTick();
			if (this.CheckAllEffectPlaying())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSceneInteractionAllEffectPlaying, (int)this.HandleId);
			}
			return;
		}
		BP_EffectActor_C bp_EffectActor_C = this.PendingStateEffects[0];
		this.PendingStateEffects.RemoveAt(0);
		if (bp_EffectActor_C != null)
		{
			this.PlayEffect(bp_EffectActor_C, "[SceneInteractionActor.PendingPlayStateEffect]");
		}
	}

	// Token: 0x0601BF0D RID: 114445 RVA: 0x0085434C File Offset: 0x0085254C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void RemovePendingStateEffectTick()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemovePendingStateEffectTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF0E RID: 114446 RVA: 0x008543BC File Offset: 0x008525BC
	protected void RemovePendingStateEffectTick_Implementation()
	{
		if (this.PendingStateEffectTickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.PendingStateEffectTickId);
			this.PendingStateEffectTickId = -1;
		}
	}

	// Token: 0x0601BF0F RID: 114447 RVA: 0x008543E0 File Offset: 0x008525E0
	private void PlayStateMaterialController(SSceneInteractionitem state, bool jumpToEnd)
	{
		TArray<SSceneInteractionMaterialController> materialControllers = state.MaterialControllers;
		if (materialControllers == null)
		{
			return;
		}
		for (int i = 0; i < materialControllers.Num(); i++)
		{
			if (materialControllers.Get(i).Materials != null)
			{
				UMaterialInstance materials = materialControllers.Get(i).Materials;
				TArray<AActor> actors = materialControllers.Get(i).Actors;
				for (int j = 0; j < actors.Num(); j++)
				{
					TArray<UActorComponent> tarray = actors.Get(j).K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
					for (int k = 0; k < tarray.Num(); k++)
					{
						UStaticMeshComponent ustaticMeshComponent = tarray.Get(k) as UStaticMeshComponent;
						if (!materialControllers.Get(i).IsRevertMaterial)
						{
							if (this.RevertMaterialComponentsMaps == null)
							{
								this.RevertMaterialComponentsMaps = new Dictionary<UStaticMeshComponent, Dictionary<int, UMaterialInterface>>();
							}
							if (!this.RevertMaterialComponentsMaps.ContainsKey(ustaticMeshComponent))
							{
								this.RevertMaterialComponentsMaps[ustaticMeshComponent] = new Dictionary<int, UMaterialInterface>();
							}
						}
						int numMaterials = ustaticMeshComponent.GetNumMaterials();
						TArray<UMaterialInterface> materials2 = ustaticMeshComponent.GetMaterials();
						for (int l = 0; l < numMaterials; l++)
						{
							if (!materialControllers.Get(i).IsRevertMaterial && this.RevertMaterialComponentsMaps != null)
							{
								this.RevertMaterialComponentsMaps[ustaticMeshComponent][l] = materials2.Get(l);
							}
							ustaticMeshComponent.SetMaterial(l, materials);
						}
					}
				}
			}
			SSceneInteractionMaterialController ssceneInteractionMaterialController = materialControllers.Get(i);
			for (int m = 0; m < ssceneInteractionMaterialController.Actors.Num(); m++)
			{
				if (ssceneInteractionMaterialController.Actors.Get(m) != null && ssceneInteractionMaterialController.Data != null)
				{
					ssceneInteractionMaterialController.TailIndex = (float)Singleton<ItemMaterialManager>.Instance.AddMaterialData(ssceneInteractionMaterialController.Actors.Get(m), ssceneInteractionMaterialController.Data);
					materialControllers.Set(i, ssceneInteractionMaterialController);
					ItemMaterialActorController itemMaterialActorController;
					if (Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap != null && Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap.TryGetValue((int)ssceneInteractionMaterialController.TailIndex, out itemMaterialActorController))
					{
						EffectLifeTimeController effectLifeTimeController = (itemMaterialActorController != null) ? itemMaterialActorController.GetLifeTimeController() : null;
						if (jumpToEnd && effectLifeTimeController != null)
						{
							effectLifeTimeController.JumpToEnd();
						}
					}
				}
			}
		}
	}

	// Token: 0x0601BF10 RID: 114448 RVA: 0x008545F0 File Offset: 0x008527F0
	private void PlayStateCharMaterialControllerNew(SSceneInteractionitem state)
	{
		PD_CharacterControllerDataGroup_C characterDataGroupForOrgan = state.CharacterDataGroupForOrgan;
		if (characterDataGroupForOrgan == null || !characterDataGroupForOrgan.IsValid())
		{
			return;
		}
		if (this.CharRenderingComponents != null)
		{
			List<CharRenderingComponent> list = new List<CharRenderingComponent>(this.CharRenderingComponents.Keys);
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				int value = list[i].AddMaterialControllerDataGroup(state.CharacterDataGroupForOrgan);
				this.CharRenderingComponents[list[i]] = value;
			}
		}
	}

	// Token: 0x0601BF11 RID: 114449 RVA: 0x00854668 File Offset: 0x00852868
	private void PlayTagCharMaterialControllerNew(SSceneInteractionTags interactionTags)
	{
		PD_CharacterControllerDataGroup_C characterDataGroupForOrgan = interactionTags.CharacterDataGroupForOrgan;
		if (characterDataGroupForOrgan == null || !characterDataGroupForOrgan.IsValid())
		{
			return;
		}
		if (this.CharRenderingComponents != null)
		{
			List<CharRenderingComponent> list = new List<CharRenderingComponent>(this.CharRenderingComponents.Keys);
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				int num = list[i].AddMaterialControllerDataGroup(characterDataGroupForOrgan);
				this.CharRenderingComponents[list[i]] = num;
				if (this.TagCharDaHandleList == null)
				{
					this.TagCharDaHandleList = new List<int>();
				}
				this.TagCharDaHandleList.Add(num);
			}
		}
	}

	// Token: 0x0601BF12 RID: 114450 RVA: 0x00854700 File Offset: 0x00852900
	private void PlayStateCrossStateEffects(SSceneInteractionitem state)
	{
		if (state.CrossStateEffects == null)
		{
			return;
		}
		HashSet<BP_EffectActor_C> hashSet = new HashSet<BP_EffectActor_C>();
		for (int i = 0; i < state.CrossStateEffects.Num(); i++)
		{
			SSceneInteractionCrossStateEffect ssceneInteractionCrossStateEffect = state.CrossStateEffects.Get(i);
			if (!(ssceneInteractionCrossStateEffect == null))
			{
				BP_EffectActor_C effect = ssceneInteractionCrossStateEffect.Effect;
				if (effect != null && effect.IsValid())
				{
					BP_EffectActor_C effect2 = ssceneInteractionCrossStateEffect.Effect;
					hashSet.Add(effect2);
					int num = 0;
					effect2.GetHandle(ref num);
					int num2 = num;
					if (!Singleton<EffectSystem>.Instance.IsValid(num2))
					{
						this.PendingCrossStateEffects[effect2] = ssceneInteractionCrossStateEffect.EffectExtraState;
					}
					else
					{
						int effectExtraState = ssceneInteractionCrossStateEffect.EffectExtraState;
						Singleton<EffectSystem>.Instance.SetEffectExtraState(num2, effectExtraState);
					}
				}
			}
		}
		if (this.CrossStateEffectActors != null)
		{
			foreach (BP_EffectActor_C bp_EffectActor_C in this.CrossStateEffectActors)
			{
				if (!hashSet.Contains(bp_EffectActor_C))
				{
					if (this.PendingCrossStateEffects.ContainsKey(bp_EffectActor_C))
					{
						this.PendingCrossStateEffects.Remove(bp_EffectActor_C);
					}
					this.StopEffect(bp_EffectActor_C, "[SceneInteractionActor.PlayStateCrossStateEffects]", false);
				}
			}
		}
		if (this.PendingCrossStateEffects.Count > 0 && this.PendingCrossStateEffectTickId == -1)
		{
			Ticker ticker = Singleton<TickSystem>.Instance.Add(delegate(float delayTime)
			{
				if (this.IsValid())
				{
					this.PendingPlayCrossStateEffect();
				}
			}, "SceneInteractionActor.PendingCrossStateEffectTick", ETickingGroup.TG_PrePhysics, true, 0, false);
			if (ticker != null)
			{
				this.PendingCrossStateEffectTickId = ticker.Id;
			}
		}
	}

	// Token: 0x0601BF13 RID: 114451 RVA: 0x00854884 File Offset: 0x00852A84
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void PendingPlayCrossStateEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PendingPlayCrossStateEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF14 RID: 114452 RVA: 0x008548F4 File Offset: 0x00852AF4
	protected void PendingPlayCrossStateEffect_Implementation()
	{
		if (this.PendingCrossStateEffects.Count == 0)
		{
			this.RemovePendingCrossStateEffectTick();
			if (this.CheckAllEffectPlaying())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSceneInteractionAllEffectPlaying, (int)this.HandleId);
			}
			return;
		}
		Dictionary<BP_EffectActor_C, int>.Enumerator enumerator = this.PendingCrossStateEffects.GetEnumerator();
		if (enumerator.MoveNext())
		{
			KeyValuePair<BP_EffectActor_C, int> keyValuePair = enumerator.Current;
			BP_EffectActor_C key = keyValuePair.Key;
			int value = keyValuePair.Value;
			this.PendingCrossStateEffects.Remove(key);
			this.PlayEffect(key, "[SceneInteractionActor.PendingPlayCrossStateEffect]");
			int num = 0;
			key.GetHandle(ref num);
			int effectId = num;
			Singleton<EffectSystem>.Instance.SetEffectExtraState(effectId, value);
		}
	}

	// Token: 0x0601BF15 RID: 114453 RVA: 0x00854998 File Offset: 0x00852B98
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void RemovePendingCrossStateEffectTick()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemovePendingCrossStateEffectTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF16 RID: 114454 RVA: 0x00854A08 File Offset: 0x00852C08
	protected void RemovePendingCrossStateEffectTick_Implementation()
	{
		if (this.PendingCrossStateEffectTickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.PendingCrossStateEffectTickId);
			this.PendingCrossStateEffectTickId = -1;
		}
	}

	// Token: 0x0601BF17 RID: 114455 RVA: 0x00854A2C File Offset: 0x00852C2C
	private void PlayStateSkeletalMeshDestruction(SSceneInteractionitem state, bool isJumpToEnd)
	{
		int num = state.SkeletalMeshDestructible.PlayDestructionAllImmediately.Num();
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			AKuroDestructibleActor skeletalMeshDestruction = state.SkeletalMeshDestructible.PlayDestructionAllImmediately.Get(i);
			this.PlaySkeletalMeshDestruction(skeletalMeshDestruction, isJumpToEnd, state.SkeletalMeshDestructible.HitInfo);
		}
	}

	// Token: 0x0601BF18 RID: 114456 RVA: 0x00854A80 File Offset: 0x00852C80
	private void PlayTagSkeletalMeshDestruction(SSceneInteractionTags interactionTags, bool isJumpToEnd)
	{
		TArray<AKuroDestructibleActor> skeletalMeshDestructibleActors = interactionTags.SkeletalMeshDestructibleActors;
		if (skeletalMeshDestructibleActors == null)
		{
			return;
		}
		int i = 0;
		int num = skeletalMeshDestructibleActors.Num();
		while (i < num)
		{
			AKuroDestructibleActor skeletalMeshDestruction = skeletalMeshDestructibleActors.Get(i);
			this.PlaySkeletalMeshDestruction(skeletalMeshDestruction, isJumpToEnd, interactionTags.HitInfo);
			i++;
		}
	}

	// Token: 0x0601BF19 RID: 114457 RVA: 0x00854AC4 File Offset: 0x00852CC4
	private void PlayTagSequence(SSceneInteractionTags interactionTags, bool jumpToEnd)
	{
		SSceneInteractionSequence sequence = interactionTags.Sequence;
		if (sequence == null)
		{
			return;
		}
		ULevelSequence sequence2 = sequence.Sequence;
		if (sequence2 == null)
		{
			return;
		}
		ALevelSequenceActor alevelSequenceActor = this.CreateDirectorBySequence(sequence2);
		if (alevelSequenceActor != null)
		{
			this.PlaySequence(alevelSequenceActor, sequence, interactionTags.Actors, jumpToEnd);
		}
	}

	// Token: 0x0601BF1A RID: 114458 RVA: 0x00854B08 File Offset: 0x00852D08
	private void StopTagSequence(SSceneInteractionTags interactionTags)
	{
		SSceneInteractionSequence sequence = interactionTags.Sequence;
		ULevelSequence ulevelSequence = (sequence != null) ? sequence.Sequence : null;
		if (ulevelSequence == null)
		{
			return;
		}
		this.StopSequence(ulevelSequence);
	}

	// Token: 0x0601BF1B RID: 114459 RVA: 0x00854B34 File Offset: 0x00852D34
	public void PlayTagEffect(FGameplayTag tag, SSceneInteractionTags interactionTags)
	{
		TArray<BP_EffectActor_C> effects = interactionTags.Effects;
		if (effects == null)
		{
			return;
		}
		List<BP_EffectActor_C> list = new List<BP_EffectActor_C>();
		int num = effects.Num();
		for (int i = 0; i < num; i++)
		{
			list.Add(effects.Get(i));
		}
		this.PendingTagEffects[tag] = list;
		if (this.PendingTagEffectTickId != -1 && Singleton<TickSystem>.Instance.Has(this.PendingTagEffectTickId))
		{
			Singleton<TickSystem>.Instance.Remove(this.PendingTagEffectTickId);
			this.PendingTagEffectTickId = -1;
		}
		Ticker ticker = Singleton<TickSystem>.Instance.Add(delegate(float _)
		{
			if (this.IsValid())
			{
				this.PendingPlayTagEffect();
			}
		}, "SceneInteractionActor.PendingTagEffectTick", ETickingGroup.TG_PrePhysics, true, 0, false);
		if (ticker != null)
		{
			this.PendingTagEffectTickId = ticker.Id;
		}
	}

	// Token: 0x0601BF1C RID: 114460 RVA: 0x00854BE8 File Offset: 0x00852DE8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void PendingPlayTagEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PendingPlayTagEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF1D RID: 114461 RVA: 0x00854C58 File Offset: 0x00852E58
	protected void PendingPlayTagEffect_Implementation()
	{
		if (this.PendingTagEffects.Count == 0)
		{
			this.RemovePendingTagEffectTick();
			if (this.CheckAllEffectPlaying() && this.IsValid())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSceneInteractionAllEffectPlaying, (int)this.HandleId);
			}
			return;
		}
		List<FGameplayTag> list = new List<FGameplayTag>();
		List<BP_EffectActor_C> list2 = null;
		foreach (KeyValuePair<FGameplayTag, List<BP_EffectActor_C>> keyValuePair in this.PendingTagEffects)
		{
			FGameplayTag key = keyValuePair.Key;
			List<BP_EffectActor_C> value = keyValuePair.Value;
			if (value.Count != 0)
			{
				list2 = value;
				break;
			}
			list.Add(key);
		}
		foreach (FGameplayTag key2 in list)
		{
			this.PendingTagEffects.Remove(key2);
		}
		if (list2 == null || list2.Count == 0)
		{
			this.RemovePendingTagEffectTick();
			return;
		}
		BP_EffectActor_C bp_EffectActor_C = list2[0];
		list2.RemoveAt(0);
		if (bp_EffectActor_C != null)
		{
			this.PlayEffect(bp_EffectActor_C, "[SceneInteractionActor.PendingPlayTagEffect]");
		}
	}

	// Token: 0x0601BF1E RID: 114462 RVA: 0x00854D88 File Offset: 0x00852F88
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void RemovePendingTagEffectTick()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemovePendingTagEffectTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF1F RID: 114463 RVA: 0x00854DF8 File Offset: 0x00852FF8
	protected void RemovePendingTagEffectTick_Implementation()
	{
		if (this.PendingTagEffectTickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.PendingTagEffectTickId);
			this.PendingTagEffectTickId = -1;
		}
	}

	// Token: 0x0601BF20 RID: 114464 RVA: 0x00854E1C File Offset: 0x0085301C
	[NullableContext(2)]
	public void StopTagEffect(FGameplayTag tag, SSceneInteractionTags interactionTags)
	{
		this.PendingTagEffects.Remove(tag);
		TArray<BP_EffectActor_C> tarray = (interactionTags != null) ? interactionTags.Effects : null;
		if (tarray != null)
		{
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				this.StopEffect(tarray.Get(i), "[SceneInteractionActor.StopTagEffect]", false);
			}
		}
		TArray<BP_EffectActor_C> tarray2 = (interactionTags != null) ? interactionTags.EndEffects : null;
		if (tarray2 != null)
		{
			int num2 = tarray2.Num();
			for (int j = 0; j < num2; j++)
			{
				this.PlayEffect(tarray2.Get(j), "[SceneInteractionActor.StopTagEffect:PlayingEndEffects]");
			}
		}
	}

	// Token: 0x0601BF21 RID: 114465 RVA: 0x00854EA8 File Offset: 0x008530A8
	public void PlayTagMaterialController(SSceneInteractionTags interactionTags)
	{
		TArray<SSceneInteractionMaterialController> materialControllers = interactionTags.MaterialControllers;
		if (materialControllers == null)
		{
			return;
		}
		int num = materialControllers.Num();
		for (int i = 0; i < num; i++)
		{
			SSceneInteractionMaterialController ssceneInteractionMaterialController = materialControllers.Get(i);
			UMaterialInstance materials = ssceneInteractionMaterialController.Materials;
			TArray<AActor> actors = ssceneInteractionMaterialController.Actors;
			int num2 = actors.Num();
			if (materials != null)
			{
				for (int j = 0; j < num2; j++)
				{
					AActor aactor = actors.Get(j);
					TArray<AActor> tarray = new TArray<AActor>();
					aactor.GetAttachedActors(ref tarray, true);
					for (int k = 0; k < tarray.Num(); k++)
					{
						TArray<UActorComponent> tarray2 = tarray.Get(k).K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
						int num3 = tarray2.Num();
						for (int l = 0; l < num3; l++)
						{
							UStaticMeshComponent ustaticMeshComponent = tarray2.Get(l) as UStaticMeshComponent;
							if (!ssceneInteractionMaterialController.IsRevertMaterial)
							{
								if (this.RevertMaterialComponentsMaps == null)
								{
									this.RevertMaterialComponentsMaps = new Dictionary<UStaticMeshComponent, Dictionary<int, UMaterialInterface>>();
								}
								if (!this.RevertMaterialComponentsMaps.ContainsKey(ustaticMeshComponent))
								{
									this.RevertMaterialComponentsMaps[ustaticMeshComponent] = new Dictionary<int, UMaterialInterface>();
								}
							}
							int numMaterials = ustaticMeshComponent.GetNumMaterials();
							TArray<UMaterialInterface> materials2 = ustaticMeshComponent.GetMaterials();
							for (int m = 0; m < numMaterials; m++)
							{
								if (!ssceneInteractionMaterialController.IsRevertMaterial && this.RevertMaterialComponentsMaps != null)
								{
									this.RevertMaterialComponentsMaps[ustaticMeshComponent][m] = materials2.Get(m);
								}
								ustaticMeshComponent.SetMaterial(m, materials);
							}
						}
					}
					TArray<UActorComponent> tarray3 = aactor.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
					int num4 = tarray3.Num();
					for (int n = 0; n < num4; n++)
					{
						UStaticMeshComponent ustaticMeshComponent2 = tarray3.Get(n) as UStaticMeshComponent;
						if (!ssceneInteractionMaterialController.IsRevertMaterial)
						{
							if (this.RevertMaterialComponentsMaps == null)
							{
								this.RevertMaterialComponentsMaps = new Dictionary<UStaticMeshComponent, Dictionary<int, UMaterialInterface>>();
							}
							if (!this.RevertMaterialComponentsMaps.ContainsKey(ustaticMeshComponent2))
							{
								this.RevertMaterialComponentsMaps[ustaticMeshComponent2] = new Dictionary<int, UMaterialInterface>();
							}
						}
						int numMaterials2 = ustaticMeshComponent2.GetNumMaterials();
						TArray<UMaterialInterface> materials3 = ustaticMeshComponent2.GetMaterials();
						for (int num5 = 0; num5 < numMaterials2; num5++)
						{
							if (!ssceneInteractionMaterialController.IsRevertMaterial && this.RevertMaterialComponentsMaps != null)
							{
								this.RevertMaterialComponentsMaps[ustaticMeshComponent2][num5] = materials3.Get(num5);
							}
							ustaticMeshComponent2.SetMaterial(num5, materials);
						}
					}
				}
			}
			for (int num6 = 0; num6 < num2; num6++)
			{
				AActor aactor2 = actors.Get(num6);
				ItemMaterialControllerActorData data = ssceneInteractionMaterialController.Data;
				if (aactor2 != null && data != null)
				{
					ssceneInteractionMaterialController.TailIndex = (float)Singleton<ItemMaterialManager>.Instance.AddMaterialData(aactor2, data);
					materialControllers.Set(i, ssceneInteractionMaterialController);
				}
			}
		}
	}

	// Token: 0x0601BF22 RID: 114466 RVA: 0x00855158 File Offset: 0x00853358
	public void StopTagMaterialController(SSceneInteractionTags interactionTags)
	{
		TArray<SSceneInteractionMaterialController> materialControllers = interactionTags.MaterialControllers;
		if (materialControllers == null)
		{
			return;
		}
		int num = materialControllers.Num();
		for (int i = 0; i < num; i++)
		{
			SSceneInteractionMaterialController ssceneInteractionMaterialController = materialControllers.Get(i);
			if (ssceneInteractionMaterialController.IsRevertMaterial)
			{
				if (ssceneInteractionMaterialController.Materials != null)
				{
					TArray<AActor> actors = ssceneInteractionMaterialController.Actors;
					int num2 = actors.Num();
					for (int j = 0; j < num2; j++)
					{
						TArray<UActorComponent> tarray = actors.Get(j).K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
						int num3 = tarray.Num();
						for (int k = 0; k < num3; k++)
						{
							UStaticMeshComponent ustaticMeshComponent = tarray.Get(k) as UStaticMeshComponent;
							int numMaterials = ustaticMeshComponent.GetNumMaterials();
							for (int l = 0; l < numMaterials; l++)
							{
								UMaterialInterface material = null;
								Dictionary<int, UMaterialInterface> dictionary;
								if (this.RevertMaterialComponentsMaps != null && this.RevertMaterialComponentsMaps.TryGetValue(ustaticMeshComponent, out dictionary) && dictionary != null)
								{
									dictionary.TryGetValue(l, out material);
								}
								ustaticMeshComponent.SetMaterial(l, material);
							}
						}
					}
				}
				if (this.CurrentState != null)
				{
					this.PlayStateMaterialController(this.CurrentState, true);
				}
			}
			if (ssceneInteractionMaterialController.Actors != null)
			{
				int num4 = ssceneInteractionMaterialController.Actors.Num();
				for (int m = 0; m < num4; m++)
				{
					int num5 = (int)ssceneInteractionMaterialController.TailIndex - m;
					if (Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap != null && Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap.ContainsKey(num5))
					{
						Singleton<ItemMaterialManager>.Instance.DisableActorData(num5);
					}
				}
			}
		}
	}

	// Token: 0x0601BF23 RID: 114467 RVA: 0x008552E0 File Offset: 0x008534E0
	private void PostTagAkEvent(FGameplayTag tag, SSceneInteractionTags interactionTags, bool jumpToEnd)
	{
		if (this.PlayingTagAkEventHandle == null)
		{
			this.PlayingTagAkEventHandle = new Dictionary<FGameplayTag, int>();
		}
		SSceneInteractionAudio akEvent = interactionTags.AkEvent;
		UAkAudioEvent akEvent2 = akEvent.AkEvent;
		if (akEvent2 == null)
		{
			return;
		}
		if (!akEvent2.IsInfinite && jumpToEnd)
		{
			return;
		}
		if (akEvent.AutoMerge)
		{
			this.PostAutoMergeEvent(akEvent2.GetName(), (float)tag.TagId(), akEvent.IsFollow);
			return;
		}
		this.PostTagEvent(akEvent2.GetName(), tag, akEvent.IsFollow);
	}

	// Token: 0x0601BF24 RID: 114468 RVA: 0x00855358 File Offset: 0x00853558
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void PostAutoMergeEvent(string eventName, float tagId, bool follow)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PostAutoMergeEvent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__PostAutoMergeEvent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__PostAutoMergeEvent_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__PostAutoMergeEvent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->eventName), eventName);
			ptr2->tagId = tagId;
			ptr2->follow = follow;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF25 RID: 114469 RVA: 0x008553E4 File Offset: 0x008535E4
	protected void PostAutoMergeEvent_Implementation(string eventName, float tagId, bool follow)
	{
		if (this.AkEventPostHandle.ContainsKey((int)tagId))
		{
			return;
		}
		int num = ControllerBase<EffectAudioController>.Instance.AddPlayEffectAudio(eventName, follow ? this : base.D_GetTransform(), null, null, delegate
		{
			this.AkEventPostHandle.Remove((int)tagId);
		}, new bool?(!follow));
		if (num != 0)
		{
			this.AkEventPostHandle[(int)tagId] = num;
		}
	}

	// Token: 0x0601BF26 RID: 114470 RVA: 0x00855480 File Offset: 0x00853680
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void PostTagEvent(string eventName, FGameplayTag tag, bool follow)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PostTagEvent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__PostTagEvent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__PostTagEvent_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__PostTagEvent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->eventName), eventName);
			ptr2->tag = tag;
			ptr2->follow = follow;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF27 RID: 114471 RVA: 0x0085550C File Offset: 0x0085370C
	protected void PostTagEvent_Implementation(string eventName, FGameplayTag tag, bool follow)
	{
		if (this.PlayingTagAkEventHandle == null || this.PlayingTagAkEventHandle.ContainsKey(tag))
		{
			return;
		}
		int num = follow ? Singleton<AudioSystem>.Instance.PostEvent(eventName, this, null) : Singleton<AudioSystem>.Instance.PostEvent(eventName, new FTransformDouble?(base.D_GetTransform()), null);
		if (num != 0)
		{
			this.PlayingTagAkEventHandle[tag] = num;
		}
	}

	// Token: 0x0601BF28 RID: 114472 RVA: 0x0085557C File Offset: 0x0085377C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void StopTagAkEvent(FGameplayTag tag)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StopTagAkEvent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__StopTagAkEvent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__StopTagAkEvent_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__StopTagAkEvent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->tag = tag;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF29 RID: 114473 RVA: 0x008555F4 File Offset: 0x008537F4
	protected void StopTagAkEvent_Implementation(FGameplayTag tag)
	{
		SSceneInteractionTags interactionTags;
		if (this.TagsAndCorrespondingEffects.TryGetValue(tag, out interactionTags))
		{
			this.StopTagAkEventNoBlueprint(tag, interactionTags);
		}
	}

	// Token: 0x0601BF2A RID: 114474 RVA: 0x0085561C File Offset: 0x0085381C
	private void StopTagAkEventNoBlueprint(FGameplayTag tag, SSceneInteractionTags interactionTags)
	{
		if (this.PlayingTagAkEventHandle == null)
		{
			return;
		}
		SSceneInteractionAudio akEvent = interactionTags.AkEvent;
		if (akEvent.AkEvent == null)
		{
			return;
		}
		if (akEvent.AutoMerge)
		{
			int uid;
			if (!this.AkEventPostHandle.TryGetValue(tag.TagId(), out uid))
			{
				return;
			}
			ControllerBase<EffectAudioController>.Instance.OnStopEffectAudio(uid, "SceneInteractionActor.StopTagAkEvent", false);
			this.AkEventPostHandle.Remove(tag.TagId());
			return;
		}
		else
		{
			int handle;
			if (!this.PlayingTagAkEventHandle.TryGetValue(tag, out handle))
			{
				return;
			}
			Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, null);
			this.PlayingTagAkEventHandle.Remove(tag);
			return;
		}
	}

	// Token: 0x0601BF2B RID: 114475 RVA: 0x008556B8 File Offset: 0x008538B8
	private void PlayStateBasedEffect(SSceneInteractionitem state, EKuroSceneInteractionState targetState)
	{
		TArray<SStateBasedEffect> stateBasedEffect = state.StateBasedEffect;
		for (int i = 0; i < stateBasedEffect.Num(); i++)
		{
			BP_StateMachineEffectBase_C stateBasedEffect2 = stateBasedEffect.GetRef_Unsafe(i).StateBasedEffect;
			if (stateBasedEffect2 != null && stateBasedEffect2.IsValid())
			{
				if (targetState == EKuroSceneInteractionState.State1)
				{
					stateBasedEffect2.SetState(EEffectState.State1);
				}
				else if (targetState == EKuroSceneInteractionState.State2)
				{
					stateBasedEffect2.SetState(EEffectState.State2);
				}
				else if (targetState == EKuroSceneInteractionState.State3)
				{
					stateBasedEffect2.SetState(EEffectState.State3);
				}
				else if (targetState == EKuroSceneInteractionState.State4)
				{
					stateBasedEffect2.SetState(EEffectState.State4);
				}
				else if (targetState == EKuroSceneInteractionState.State5)
				{
					stateBasedEffect2.SetState(EEffectState.State5);
				}
			}
		}
	}

	// Token: 0x0601BF2C RID: 114476 RVA: 0x00855734 File Offset: 0x00853934
	private void PostStateAkEvent(SSceneInteractionitem state, bool jumpToEnd)
	{
		SSceneInteractionAudio akEvent = state.AkEvent;
		UAkAudioEvent akEvent2 = akEvent.AkEvent;
		if (akEvent2 == null)
		{
			return;
		}
		if (!akEvent2.IsInfinite && jumpToEnd)
		{
			return;
		}
		this.StopCurrentStateAkEvent("PostStateAkEvent");
		int num;
		if (akEvent.AutoMerge)
		{
			num = ControllerBase<EffectAudioController>.Instance.AddPlayEffectAudio(akEvent2.GetName(), akEvent.IsFollow ? this : base.D_GetTransform(), null, null, delegate
			{
				this.CurrentStateAkEventHandle = 0f;
			}, new bool?(!akEvent.IsFollow));
		}
		else
		{
			string name = akEvent2.GetName();
			num = (akEvent.IsFollow ? Singleton<AudioSystem>.Instance.PostEvent(name, this, null) : Singleton<AudioSystem>.Instance.PostEvent(name, new FTransformDouble?(base.D_GetTransform()), null));
		}
		if (num != 0)
		{
			this.MergeCurrentStateAkEvent = akEvent.AutoMerge;
			this.CurrentStateAkEventHandle = (float)num;
		}
	}

	// Token: 0x0601BF2D RID: 114477 RVA: 0x00855838 File Offset: 0x00853A38
	private void SetStateActorHide(SSceneInteractionitem state)
	{
		TArray<AActor> hideActors = state.HideActors;
		int i = 0;
		int num = hideActors.Num();
		while (i < num)
		{
			AActor aactor = hideActors.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(true);
				aactor.SetActorEnableCollision(false);
			}
			BP_EffectActor_C bp_EffectActor_C = aactor as BP_EffectActor_C;
			if (bp_EffectActor_C != null)
			{
				this.PendingStateEffects.Remove(bp_EffectActor_C);
				foreach (List<BP_EffectActor_C> list in this.PendingTagEffects.Values)
				{
					list.Remove(bp_EffectActor_C);
				}
				this.PendingCrossStateEffects.Remove(bp_EffectActor_C);
			}
			i++;
		}
	}

	// Token: 0x0601BF2E RID: 114478 RVA: 0x008558F4 File Offset: 0x00853AF4
	private void SetStateActorShow(SSceneInteractionitem state)
	{
		TArray<AActor> actors = state.Actors;
		if (actors == null)
		{
			return;
		}
		int i = 0;
		int num = actors.Num();
		while (i < num)
		{
			AActor aactor = actors.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(false);
				aactor.SetActorEnableCollision(true);
			}
			i++;
		}
	}

	// Token: 0x0601BF2F RID: 114479 RVA: 0x00855938 File Offset: 0x00853B38
	private void SetStateActorCollisionProfile(SSceneInteractionitem state, [Nullable(2)] SSceneInteractionitem lastState)
	{
		if (lastState != null)
		{
			TMap<AActor, FCollisionProfileName> exitStateActorCollisionProfile = lastState.ExitStateActorCollisionProfile;
			this.SetActorCollisionProfile(exitStateActorCollisionProfile);
		}
		TMap<AActor, FCollisionProfileName> enterStateActorCollisionProfile = state.EnterStateActorCollisionProfile;
		this.SetActorCollisionProfile(enterStateActorCollisionProfile);
	}

	// Token: 0x0601BF30 RID: 114480 RVA: 0x0085596C File Offset: 0x00853B6C
	[NullableContext(2)]
	public void MakeActorProjection(FTransformDouble transform, ItemMaterialControllerActorData data = null)
	{
		if (this.IsProjecting)
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.CH, "当前已经在投影中，重复调用投影接口", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		TArray<AActor> actorsForProjection = this.ActorsForProjection;
		AActor projectionRootActor = this.ProjectionRootActor;
		if (projectionRootActor == null || !projectionRootActor.IsValid())
		{
			UObject world = GlobalData.World;
			TSubclassOf<AActor> actorClass = AStaticMeshActor.StaticClass();
			FTransformDouble ftransformDouble = base.D_GetTransform();
			this.ProjectionRootActor = UKuroActorManager.D_SpawnActor(world, actorClass, ftransformDouble, ESpawnActorCollisionHandlingMethod.Undefined, null, null, false);
			this.ProjectionRootActor.RootComponent.SetMobility(EComponentMobility.Movable);
		}
		if (actorsForProjection.Num() == 0)
		{
			return;
		}
		this.IsProjecting = true;
		for (int i = 0; i < actorsForProjection.Num(); i++)
		{
			AActor aactor = UKuroStaticLibrary.SpawnActorFromAnother(actorsForProjection.Get(i), null);
			if (aactor != null && aactor.IsValid())
			{
				aactor.K2_AttachToActor(this.ProjectionRootActor, null, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, true, true);
				if (this.MaterialForProjection != null)
				{
					TArray<AActor> tarray = new TArray<AActor>();
					aactor.GetAttachedActors(ref tarray, true);
					for (int j = 0; j < tarray.Num(); j++)
					{
						TArray<UActorComponent> tarray2 = tarray.Get(j).K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
						for (int k = 0; k < tarray2.Num(); k++)
						{
							UStaticMeshComponent ustaticMeshComponent = tarray2.Get(k) as UStaticMeshComponent;
							int numMaterials = ustaticMeshComponent.GetNumMaterials();
							for (int l = 0; l < numMaterials; l++)
							{
								ustaticMeshComponent.SetMaterial(l, this.MaterialForProjection);
							}
						}
					}
					TArray<UActorComponent> tarray3 = aactor.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
					for (int m = 0; m < tarray3.Num(); m++)
					{
						UStaticMeshComponent ustaticMeshComponent2 = tarray3.Get(m) as UStaticMeshComponent;
						int numMaterials2 = ustaticMeshComponent2.GetNumMaterials();
						for (int n = 0; n < numMaterials2; n++)
						{
							ustaticMeshComponent2.SetMaterial(n, this.MaterialForProjection);
						}
					}
				}
				if (data != null)
				{
					this.AddMatrialDataForChildrenActor(aactor, data);
				}
			}
		}
		this.ProjectionRootActor.D_K2_SetActorTransform(transform, false, null, false);
	}

	// Token: 0x0601BF31 RID: 114481 RVA: 0x00855B74 File Offset: 0x00853D74
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void UpdateProjectionActorTransform(FTransformDouble transform)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("UpdateProjectionActorTransform"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__UpdateProjectionActorTransform_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__UpdateProjectionActorTransform_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__UpdateProjectionActorTransform_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->transform = transform;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF32 RID: 114482 RVA: 0x00855BEC File Offset: 0x00853DEC
	protected void UpdateProjectionActorTransform_Implementation(FTransformDouble transform)
	{
		if (!this.IsProjecting)
		{
			this.MakeActorProjection(transform, null);
			return;
		}
		AActor projectionRootActor = this.ProjectionRootActor;
		if (projectionRootActor == null || !projectionRootActor.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.CH, "找不到投影的Root Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.ProjectionRootActor.D_K2_SetActorTransform(transform, false, null, false);
	}

	// Token: 0x0601BF33 RID: 114483 RVA: 0x00855C50 File Offset: 0x00853E50
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void AddMatrialDataForChildrenActor(AActor actor, ItemMaterialControllerActorData materialData)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMatrialDataForChildrenActor"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__AddMatrialDataForChildrenActor_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__AddMatrialDataForChildrenActor_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__AddMatrialDataForChildrenActor_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->actor) = ((actor != null) ? actor.NativePtr : ((IntPtr)0));
			*(&ptr2->materialData) = ((materialData != null) ? materialData.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF34 RID: 114484 RVA: 0x00855CEC File Offset: 0x00853EEC
	protected void AddMatrialDataForChildrenActor_Implementation(AActor actor, ItemMaterialControllerActorData materialData)
	{
		if (!actor.IsValid())
		{
			return;
		}
		TArray<AActor> tarray = new TArray<AActor>();
		actor.GetAttachedActors(ref tarray, true);
		for (int i = 0; i < tarray.Num(); i++)
		{
			AActor aactor = tarray.Get(i);
			if (aactor.IsValid())
			{
				Singleton<ItemMaterialManager>.Instance.AddMaterialData(aactor, materialData);
			}
		}
		Singleton<ItemMaterialManager>.Instance.AddMaterialData(actor, materialData);
	}

	// Token: 0x0601BF35 RID: 114485 RVA: 0x00855D4C File Offset: 0x00853F4C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveActorProjection()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveActorProjection"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF36 RID: 114486 RVA: 0x00855DBC File Offset: 0x00853FBC
	protected void RemoveActorProjection_Implementation()
	{
		if (!this.IsProjecting)
		{
			return;
		}
		AActor projectionRootActor = this.ProjectionRootActor;
		if (projectionRootActor == null || !projectionRootActor.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.CH, "找不到投影的Root Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.IsProjecting = false;
		this.DestroyActor(this.ProjectionRootActor);
	}

	// Token: 0x0601BF37 RID: 114487 RVA: 0x00855E1C File Offset: 0x0085401C
	private void DestroyActor(AActor actor)
	{
		TArray<AActor> tarray = new TArray<AActor>();
		actor.GetAttachedActors(ref tarray, true);
		for (int i = 0; i < tarray.Num(); i++)
		{
			this.DestroyActor(tarray.Get(i));
		}
		BP_EffectActor_C bp_EffectActor_C = actor as BP_EffectActor_C;
		if (bp_EffectActor_C != null)
		{
			bp_EffectActor_C.StopEffect();
			bp_EffectActor_C.RemoveHandle();
		}
		actor.K2_DestroyActor();
	}

	// Token: 0x0601BF38 RID: 114488 RVA: 0x00855E74 File Offset: 0x00854074
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DestroySelf()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DestroySelf"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF39 RID: 114489 RVA: 0x00855EE4 File Offset: 0x008540E4
	protected void DestroySelf_Implementation()
	{
		this.SkeletalMeshDestructibleActorsInternal = null;
		this.DestroyActor(this);
	}

	// Token: 0x0601BF3A RID: 114490 RVA: 0x00855EF4 File Offset: 0x008540F4
	public void SetTagActorHide(SSceneInteractionTags interactionTags)
	{
		TArray<AActor> hideActors = interactionTags.HideActors;
		if (hideActors == null)
		{
			return;
		}
		int i = 0;
		int num = hideActors.Num();
		while (i < num)
		{
			AActor aactor = hideActors.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(true);
				aactor.SetActorEnableCollision(false);
			}
			BP_EffectActor_C bp_EffectActor_C = aactor as BP_EffectActor_C;
			if (bp_EffectActor_C != null)
			{
				if (this.PendingStateEffects.Contains(bp_EffectActor_C))
				{
					this.PendingStateEffects.Remove(bp_EffectActor_C);
				}
				foreach (List<BP_EffectActor_C> list in this.PendingTagEffects.Values)
				{
					if (list.Contains(bp_EffectActor_C))
					{
						list.Remove(bp_EffectActor_C);
					}
				}
				if (this.PendingCrossStateEffects.ContainsKey(bp_EffectActor_C))
				{
					this.PendingCrossStateEffects.Remove(bp_EffectActor_C);
				}
			}
			i++;
		}
	}

	// Token: 0x0601BF3B RID: 114491 RVA: 0x00855FE4 File Offset: 0x008541E4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ResetTagActorHide(FGameplayTag tag)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ResetTagActorHide"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__ResetTagActorHide_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__ResetTagActorHide_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__ResetTagActorHide_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->tag = tag;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF3C RID: 114492 RVA: 0x0085605C File Offset: 0x0085425C
	protected void ResetTagActorHide_Implementation(FGameplayTag tag)
	{
		SSceneInteractionTags interactionTags;
		if (this.TagsAndCorrespondingEffects != null && this.TagsAndCorrespondingEffects.TryGetValue(tag, out interactionTags))
		{
			this.ResetTagActorHideNoBlueprint(interactionTags);
		}
	}

	// Token: 0x0601BF3D RID: 114493 RVA: 0x00856088 File Offset: 0x00854288
	private void ResetTagActorHideNoBlueprint(SSceneInteractionTags interactionTags)
	{
		TArray<AActor> hideActors = interactionTags.HideActors;
		if (hideActors == null)
		{
			return;
		}
		int i = 0;
		int num = hideActors.Num();
		while (i < num)
		{
			AActor aactor = hideActors.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(false);
				aactor.SetActorEnableCollision(true);
			}
			i++;
		}
	}

	// Token: 0x0601BF3E RID: 114494 RVA: 0x008560CC File Offset: 0x008542CC
	public void SetTagActorShow(SSceneInteractionTags interactionTags)
	{
		TArray<AActor> actors = interactionTags.Actors;
		if (actors == null)
		{
			return;
		}
		int i = 0;
		int num = actors.Num();
		while (i < num)
		{
			AActor aactor = actors.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(false);
				aactor.SetActorEnableCollision(true);
			}
			i++;
		}
	}

	// Token: 0x0601BF3F RID: 114495 RVA: 0x00856110 File Offset: 0x00854310
	public void ResetTagActorShow(SSceneInteractionTags interactionTags)
	{
		TArray<AActor> actors = interactionTags.Actors;
		if (actors == null)
		{
			return;
		}
		int i = 0;
		int num = actors.Num();
		while (i < num)
		{
			AActor aactor = actors.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(true);
				aactor.SetActorEnableCollision(false);
			}
			i++;
		}
	}

	// Token: 0x0601BF40 RID: 114496 RVA: 0x00856154 File Offset: 0x00854354
	public void SetTagStaticMehActorCollisionProfile(SSceneInteractionTags interactionTags)
	{
		TMap<AActor, FCollisionProfileName> addTagActorCollisionProfile = interactionTags.AddTagActorCollisionProfile;
		if (addTagActorCollisionProfile != null)
		{
			this.SetActorCollisionProfile(addTagActorCollisionProfile);
		}
	}

	// Token: 0x0601BF41 RID: 114497 RVA: 0x00856174 File Offset: 0x00854374
	public void ResetTagStaticMehActorCollisionProfile(SSceneInteractionTags interactionTags)
	{
		TMap<AActor, FCollisionProfileName> removeTagActorCollisionProfile = interactionTags.RemoveTagActorCollisionProfile;
		if (removeTagActorCollisionProfile != null)
		{
			this.SetActorCollisionProfile(removeTagActorCollisionProfile);
		}
	}

	// Token: 0x0601BF42 RID: 114498 RVA: 0x00856194 File Offset: 0x00854394
	private void DoSwitchState(bool bWaitForCurrentFinished)
	{
		if (bWaitForCurrentFinished)
		{
			bool flag = false;
			ULevelSequencePlayer activeSequencePlayer = this.ActiveSequencePlayer;
			ULevelSequence ulevelSequence = ((activeSequencePlayer != null) ? activeSequencePlayer.Sequence : null) as ULevelSequence;
			if (activeSequencePlayer != null && ulevelSequence != null && activeSequencePlayer.IsPlaying())
			{
				if (activeSequencePlayer.IsReversed())
				{
					activeSequencePlayer.PlayReverseLooping(0);
				}
				else
				{
					activeSequencePlayer.PlayLooping(0);
				}
				flag = true;
			}
			if (this.CurrentState != null)
			{
				ASkeletalMeshActor skeletalMesh = this.CurrentState.AnimMontage.SkeletalMesh;
				USkeletalMeshComponent uskeletalMeshComponent = (skeletalMesh != null) ? skeletalMesh.SkeletalMeshComponent : null;
				if (uskeletalMeshComponent != null)
				{
					UAnimInstance animInstance = uskeletalMeshComponent.GetAnimInstance();
					UAnimMontage montage = this.CurrentState.AnimMontage.Montage;
					if (montage != null && animInstance != null && animInstance.Montage_IsPlaying(montage))
					{
						UAnimSingleNodeInstance uanimSingleNodeInstance = animInstance as UAnimSingleNodeInstance;
						if (uanimSingleNodeInstance != null)
						{
							uanimSingleNodeInstance.SetLooping(false);
							flag = true;
							goto IL_C8;
						}
					}
					if (animInstance is ABP_LevelPrefabDaiyu_C)
					{
						flag = true;
					}
				}
			}
			IL_C8:
			if (flag)
			{
				this.InWaitingForPlayableFinished = true;
				return;
			}
		}
		this.InWaitingForPlayableFinished = false;
		if (this.TransitionState != null)
		{
			this.InTransition = true;
			if (this.CurrentState != null)
			{
				this.StopState(this.CurrentState, this.TransitionState);
			}
			this.CurrentStateKey = this.TransitionStateKey;
			this.PlayState(this.TransitionState, this.CurrentState, this.TransitionStateJumpToEnd, this.TransitionStateKey.Value);
			this.SwitchingStateRemainTime = this.TransitionState.TransitionTime;
			this.IsUseTransitionTime = !this.CheckActivePlayable();
			this.TransitionState = null;
			this.TransitionStateKey = null;
			return;
		}
		if (this.NextState != null)
		{
			this.SwitchingStateRemainTime = 0f;
			this.InTransition = false;
			if (this.CurrentState != null)
			{
				this.StopState(this.CurrentState, this.NextState);
			}
			this.CurrentStateKey = this.NextStateKey;
			this.PlayState(this.NextState, this.CurrentState, this.TransitionStateJumpToEnd, this.NextStateKey.Value);
			this.NextState = null;
			this.NextStateKey = null;
			return;
		}
		this.TransitionState = null;
		this.TransitionStateKey = null;
		this.NextState = null;
		this.NextStateKey = null;
		this.InTransition = false;
		this.SwitchingStateRemainTime = 0f;
		Singleton<Log>.Instance.Error(ELogModule.Level, ELogAuthor.LWH, "Nothing to Switch, should not happened!", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601BF43 RID: 114499 RVA: 0x008563F0 File Offset: 0x008545F0
	private void DetermineState(SSceneInteractionitem targetState, EKuroSceneInteractionState targetStateKey, bool needTransition, bool jumpToEnd)
	{
		this.NextState = targetState;
		this.NextStateKey = new EKuroSceneInteractionState?(targetStateKey);
		bool transitionStateJumpToEnd = jumpToEnd && !targetState.NeedExpressionAnyway;
		EKuroSceneInteractionState ekuroSceneInteractionState;
		SSceneInteractionitem transitionState;
		if (needTransition && this.CurrentState != null && this.CurrentState.TransitionMap.TryGetValue(targetStateKey, out ekuroSceneInteractionState) && this.States.TryGetValue(ekuroSceneInteractionState, out transitionState))
		{
			this.TransitionState = transitionState;
			this.TransitionStateKey = new EKuroSceneInteractionState?(ekuroSceneInteractionState);
			this.TransitionStateJumpToEnd = transitionStateJumpToEnd;
			return;
		}
		this.TransitionStateJumpToEnd = transitionStateJumpToEnd;
		this.TransitionState = null;
		this.TransitionStateKey = null;
	}

	// Token: 0x0601BF44 RID: 114500 RVA: 0x0085648C File Offset: 0x0085468C
	public unsafe void SetState(EKuroSceneInteractionState state, bool needTransition, bool jumpToEnd)
	{
		if (this.States == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderScene;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "状态为Undefined";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HandleID", this.HandleId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		SSceneInteractionitem valueOrDefault = this.States.GetValueOrDefault(state);
		if (valueOrDefault == null)
		{
			if (state != EKuroSceneInteractionState.ConcealedState)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderScene;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "状态未配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("未配置状态", state + 1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Actor", this.LevelName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("HandleID", this.HandleId);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			}
			return;
		}
		if (this.InTransition && !valueOrDefault.IsForceSetState)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.RenderScene;
			ELogAuthor author3 = ELogAuthor.MY;
			string message3 = "正在过渡状态, 不可设置其他状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Actor", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("HandleID", this.HandleId);
			instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return;
		}
		if (this.NextState != null && !valueOrDefault.IsForceSetState)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.RenderScene;
			ELogAuthor author4 = ELogAuthor.MY;
			string message4 = "正在过渡状态, 不可设置其他状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Actor", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("HandleID", this.HandleId);
			instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
			return;
		}
		EKuroSceneInteractionState? currentStateKey = this.CurrentStateKey;
		if (state == currentStateKey.GetValueOrDefault() & currentStateKey != null)
		{
			return;
		}
		SSceneInteractionitem currentState = this.CurrentState;
		if (currentState != null && currentState.WaitForPlayableFinished && this.InWaitingForPlayableFinished)
		{
			return;
		}
		this.DetermineState(valueOrDefault, state, needTransition, jumpToEnd);
		SSceneInteractionitem currentState2 = this.CurrentState;
		bool bWaitForCurrentFinished = currentState2 != null && currentState2.WaitForPlayableFinished;
		this.DoSwitchState(bWaitForCurrentFinished);
	}

	// Token: 0x0601BF45 RID: 114501 RVA: 0x008566F4 File Offset: 0x008548F4
	public void StopState(SSceneInteractionitem stateToStop, [Nullable(2)] SSceneInteractionitem stateToPlay)
	{
		if (stateToStop == null)
		{
			return;
		}
		this.RemovePendingStateEffectTick();
		this.PendingStateEffects.Clear();
		ULevelSequencePlayer activeSequencePlayer = this.ActiveSequencePlayer;
		ULevelSequence ulevelSequence = ((activeSequencePlayer != null) ? activeSequencePlayer.Sequence : null) as ULevelSequence;
		if (ulevelSequence != null && ulevelSequence == stateToStop.Sequence.Sequence && stateToStop.Sequence.Sequence != ((stateToPlay != null) ? stateToPlay.Sequence.Sequence : null))
		{
			this.StopSequence(ulevelSequence);
		}
		for (int i = 0; i < stateToStop.HideActors.Num(); i++)
		{
			AActor aactor = stateToStop.HideActors.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(false);
				aactor.SetActorEnableCollision(true);
			}
		}
		for (int j = 0; j < stateToStop.Effects.Num(); j++)
		{
			BP_EffectActor_C bp_EffectActor_C = stateToStop.Effects.Get(j);
			if (bp_EffectActor_C != null)
			{
				bp_EffectActor_C.Stop("[SceneInteractionActor.StopState]", false);
			}
		}
		TArray<SSceneInteractionMaterialController> materialControllers = stateToStop.MaterialControllers;
		if (Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap != null && materialControllers != null)
		{
			for (int k = 0; k < materialControllers.Num(); k++)
			{
				if (materialControllers.Get(k).IsRevertMaterial && materialControllers.Get(k).Materials != null)
				{
					TArray<AActor> actors = materialControllers.Get(k).Actors;
					for (int l = 0; l < actors.Num(); l++)
					{
						TArray<UActorComponent> tarray = actors.Get(l).K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
						for (int m = 0; m < tarray.Num(); m++)
						{
							UStaticMeshComponent ustaticMeshComponent = tarray.Get(m) as UStaticMeshComponent;
							int numMaterials = ustaticMeshComponent.GetNumMaterials();
							for (int n = 0; n < numMaterials; n++)
							{
								UMaterialInterface material = null;
								Dictionary<int, UMaterialInterface> dictionary;
								if (this.RevertMaterialComponentsMaps != null && this.RevertMaterialComponentsMaps.TryGetValue(ustaticMeshComponent, out dictionary) && dictionary != null)
								{
									dictionary.TryGetValue(n, out material);
								}
								ustaticMeshComponent.SetMaterial(n, material);
							}
						}
					}
				}
			}
			if (Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap != null)
			{
				for (int num = 0; num < materialControllers.Num(); num++)
				{
					for (int num2 = 0; num2 < materialControllers.Get(num).Actors.Num(); num2++)
					{
						int num3 = (int)stateToStop.MaterialControllers.Get(num).TailIndex - num2;
						if (Singleton<ItemMaterialManager>.Instance.AllActorControllerInfoMap.ContainsKey(num3))
						{
							Singleton<ItemMaterialManager>.Instance.DisableActorData(num3);
						}
					}
				}
			}
		}
		if (this.CharRenderingComponents != null)
		{
			List<CharRenderingComponent> list = new List<CharRenderingComponent>(this.CharRenderingComponents.Keys);
			int count = list.Count;
			for (int num4 = 0; num4 < count; num4++)
			{
				int num5;
				if (this.CharRenderingComponents.TryGetValue(list[num4], out num5) && num5 != 0 && (this.TagCharDaHandleList == null || !this.TagCharDaHandleList.Contains(num5)))
				{
					list[num4].RemoveMaterialControllerDataGroupWithEnding(num5);
				}
			}
		}
		this.StopCurrentStateAkEvent("停止状态Ak事件");
	}

	// Token: 0x0601BF46 RID: 114502 RVA: 0x008569EC File Offset: 0x00854BEC
	public void StopCurrentStateAkEvent(string context)
	{
		float currentStateAkEventHandle = this.CurrentStateAkEventHandle;
		if (this.MergeCurrentStateAkEvent)
		{
			ControllerBase<EffectAudioController>.Instance.OnStopEffectAudio((int)this.CurrentStateAkEventHandle, "SceneInteractionActor." + context, false);
			this.CurrentStateAkEventHandle = 0f;
			return;
		}
		Singleton<AudioSystem>.Instance.ExecuteAction((int)this.CurrentStateAkEventHandle, EAudioActionType.Stop, null);
		this.CurrentStateAkEventHandle = 0f;
	}

	// Token: 0x0601BF47 RID: 114503 RVA: 0x00856A57 File Offset: 0x00854C57
	public void OnAnimPlayEnd(string animName)
	{
		this.IsAbpAnimPlayEnd = true;
	}

	// Token: 0x0601BF48 RID: 114504 RVA: 0x00856A60 File Offset: 0x00854C60
	private bool CheckActivePlayable()
	{
		bool flag = false;
		if (this.ActiveSequencePlayer != null)
		{
			flag = (flag || this.ActiveSequencePlayer.IsPlaying());
		}
		SSceneInteractionitem currentState = this.CurrentState;
		SSceneInteractionMontage ssceneInteractionMontage = (currentState != null) ? currentState.AnimMontage : null;
		if (((ssceneInteractionMontage != null) ? ssceneInteractionMontage.SkeletalMesh : null) != null)
		{
			ASkeletalMeshActor skeletalMesh = ssceneInteractionMontage.SkeletalMesh;
			USkeletalMeshComponent uskeletalMeshComponent = (skeletalMesh != null) ? skeletalMesh.SkeletalMeshComponent : null;
			if (uskeletalMeshComponent != null)
			{
				UAnimInstance animInstance = uskeletalMeshComponent.GetAnimInstance();
				if (animInstance != null)
				{
					UAnimMontage montage = ssceneInteractionMontage.Montage;
					if (animInstance is ABP_LevelPrefabDaiyu_C)
					{
						flag = (flag || !this.IsAbpAnimPlayEnd);
					}
					else if (montage != null)
					{
						flag = (flag || animInstance.Montage_IsPlaying(montage));
					}
				}
			}
		}
		return flag;
	}

	// Token: 0x0601BF49 RID: 114505 RVA: 0x00856B00 File Offset: 0x00854D00
	private bool CheckPlaying(float deltaSeconds, SSceneInteractionitem state)
	{
		if (this.CheckActivePlayable())
		{
			return true;
		}
		if (!this.IsUseTransitionTime || this.SwitchingStateRemainTime == 0f)
		{
			return false;
		}
		this.SwitchingStateRemainTime -= deltaSeconds;
		return this.SwitchingStateRemainTime >= 0f;
	}

	// Token: 0x0601BF4A RID: 114506 RVA: 0x00856B4C File Offset: 0x00854D4C
	private UKuroSceneInteractionActorSystem GetKuroSceneInteractionActorSystem()
	{
		if (this.KuroSceneInteractionActorSystem == null)
		{
			this.KuroSceneInteractionActorSystem = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroSceneInteractionActorSystem.StaticClass()) as UKuroSceneInteractionActorSystem);
		}
		return this.KuroSceneInteractionActorSystem;
	}

	// Token: 0x0601BF4B RID: 114507 RVA: 0x00856B7C File Offset: 0x00854D7C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	[return: Nullable(2)]
	protected unsafe virtual ALevelSequenceActor GetDirectorBySequence(ULevelSequence sequence)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDirectorBySequence"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__GetDirectorBySequence_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__GetDirectorBySequence_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__GetDirectorBySequence_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->sequence) = ((sequence != null) ? sequence.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		ALevelSequenceActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ALevelSequenceActor>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601BF4C RID: 114508 RVA: 0x00856C0C File Offset: 0x00854E0C
	[return: Nullable(2)]
	protected ALevelSequenceActor GetDirectorBySequence_Implementation(ULevelSequence sequence)
	{
		ALevelSequenceActor result;
		if (this.ActiveSequenceDirectorMap != null && this.ActiveSequenceDirectorMap.TryGetValue(sequence, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0601BF4D RID: 114509 RVA: 0x00856C34 File Offset: 0x00854E34
	[return: Nullable(2)]
	private unsafe ALevelSequenceActor CreateDirectorBySequence(ULevelSequence sequence)
	{
		if (this.ActiveSequenceDirectorMap == null)
		{
			this.ActiveSequenceDirectorMap = new Dictionary<ULevelSequence, ALevelSequenceActor>();
		}
		if (this.GetDirectorBySequence(sequence) != null)
		{
			this.StopSequence(sequence);
		}
		ALevelSequenceActor newDirector = Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), base.D_GetTransform(), null, false) as ALevelSequenceActor;
		ALevelSequenceActor newDirector2 = newDirector;
		ULevelSequencePlayer ulevelSequencePlayer = (newDirector2 != null) ? newDirector2.SequencePlayer : null;
		if (ulevelSequencePlayer == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderScene;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "LevelSequenceActor.SequencePlayer invalid";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.LevelName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HandleID", this.HandleId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		newDirector.bOverrideInstanceData = true;
		(newDirector.DefaultInstanceData as UDefaultLevelSequenceInstanceData).TransformOriginActor = this;
		this.ActiveSequenceDirectorMap[sequence] = newDirector;
		Action sendPlaySequenceEvent = delegate()
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.PbDataId);
			bool flag;
			if (entityByPbDataId == null)
			{
				flag = true;
			}
			else
			{
				WorldEntity entity = entityByPbDataId.Entity;
				flag = !((entity != null) ? new bool?(entity.Valid) : null).GetValueOrDefault();
			}
			if (flag || newDirector.SequencePlayer == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<int, UMovieSceneSequencePlayer>(entityByPbDataId.Entity, EEventName.OnSceneInteractionSequencePlay, (int)this.HandleId, newDirector.SequencePlayer);
		};
		Action removeDirector = null;
		TTimerAction <>9__2;
		removeDirector = delegate()
		{
			ULevelSequencePlayer sequencePlayer = newDirector.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.OnStop.Remove(removeDirector);
				sequencePlayer.OnFinished.Remove(removeDirector);
				sequencePlayer.OnPlay.Remove(sendPlaySequenceEvent);
				sequencePlayer.OnPlayReverse.Remove(sendPlaySequenceEvent);
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.PbDataId);
				if (entityByPbDataId != null)
				{
					WorldEntity entity = entityByPbDataId.Entity;
					if (((entity != null) ? new bool?(entity.Valid) : null).GetValueOrDefault())
					{
						Singleton<EventSystem>.Instance.EmitWithTarget<int, UMovieSceneSequencePlayer>(entityByPbDataId.Entity, EEventName.OnSceneInteractionSequenceOver, (int)this.HandleId, sequencePlayer);
					}
				}
				ModelBase<MechanismTimelineModel>.Instance.UnRegisterSequenceContext(sequencePlayer);
			}
			ALevelSequenceActor alevelSequenceActor;
			if (this.ActiveSequenceDirectorMap != null && this.ActiveSequenceDirectorMap.TryGetValue(sequence, out alevelSequenceActor) && alevelSequenceActor == newDirector)
			{
				this.ActiveSequenceDirectorMap.Remove(sequence);
			}
			Dictionary<ALevelSequenceActor, SequenceDirectorConfig> directorConfigMap = this.DirectorConfigMap;
			if (directorConfigMap != null)
			{
				directorConfigMap.Remove(newDirector);
			}
			if (this.ActiveSequencePlayer == sequencePlayer)
			{
				this.ActiveSequencePlayer = null;
			}
			if (newDirector.IsValid())
			{
				TimerSystemInstance instance2 = TimerSystem.Instance;
				TTimerAction action;
				if ((action = <>9__2) == null)
				{
					action = (<>9__2 = delegate(float _)
					{
						Singleton<ActorSystem>.Instance.Put("SceneInteractionActor.CreateDirectorBySequence", newDirector, null);
					});
				}
				instance2.Next(action, null, null);
			}
		};
		ulevelSequencePlayer.OnPlay.Add(sendPlaySequenceEvent);
		ulevelSequencePlayer.OnPlayReverse.Add(sendPlaySequenceEvent);
		ulevelSequencePlayer.OnStop.Add(removeDirector);
		ulevelSequencePlayer.OnFinished.Add(removeDirector);
		return newDirector;
	}

	// Token: 0x0601BF4E RID: 114510 RVA: 0x00856DCC File Offset: 0x00854FCC
	public void PlayExtraEffectOnTagsChange(FGameplayTag tag, bool jumpToEnd = false)
	{
		if (this.TagsAndCorrespondingEffects == null)
		{
			return;
		}
		SSceneInteractionTags ssceneInteractionTags;
		if (!this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags))
		{
			return;
		}
		this.PlayTagEffect(tag, ssceneInteractionTags);
		this.PlayTagCharMaterialControllerNew(ssceneInteractionTags);
		this.PlayTagMaterialController(ssceneInteractionTags);
		this.TagsAndCorrespondingEffects[tag] = ssceneInteractionTags;
		this.PostTagAkEvent(tag, ssceneInteractionTags, jumpToEnd);
		this.SetTagActorShow(ssceneInteractionTags);
		this.SetTagActorHide(ssceneInteractionTags);
		this.PlayTagSequence(ssceneInteractionTags, jumpToEnd);
		this.PlayTagSkeletalMeshDestruction(ssceneInteractionTags, jumpToEnd);
		this.SetTagStaticMehActorCollisionProfile(ssceneInteractionTags);
	}

	// Token: 0x0601BF4F RID: 114511 RVA: 0x00856E44 File Offset: 0x00855044
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void StopExtraEffectOnTagsChange(FGameplayTag tag)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("StopExtraEffectOnTagsChange"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		SceneInteractionActor.__StopExtraEffectOnTagsChange_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((SceneInteractionActor.__StopExtraEffectOnTagsChange_FunctionParams*)ptr + 15L / (long)sizeof(SceneInteractionActor.__StopExtraEffectOnTagsChange_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->tag = tag;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BF50 RID: 114512 RVA: 0x00856EBC File Offset: 0x008550BC
	protected void StopExtraEffectOnTagsChange_Implementation(FGameplayTag tag)
	{
		if (this.TagsAndCorrespondingEffects == null)
		{
			return;
		}
		SSceneInteractionTags ssceneInteractionTags;
		this.TagsAndCorrespondingEffects.TryGetValue(tag, out ssceneInteractionTags);
		this.StopTagEffect(tag, ssceneInteractionTags);
		if (ssceneInteractionTags == null)
		{
			return;
		}
		this.StopTagMaterialController(ssceneInteractionTags);
		this.StopTagAkEventNoBlueprint(tag, ssceneInteractionTags);
		this.ResetTagActorShow(ssceneInteractionTags);
		this.ResetTagActorHideNoBlueprint(ssceneInteractionTags);
		this.StopTagSequence(ssceneInteractionTags);
		this.ResetTagStaticMehActorCollisionProfile(ssceneInteractionTags);
	}

	// Token: 0x0601BF51 RID: 114513 RVA: 0x00856F1E File Offset: 0x0085511E
	public void UpdateHitInfo(FVectorDouble pos, FVector dir)
	{
		this.HitLocation = new FVectorDouble?(pos);
		this.HitDirection.Set((double)dir.X, (double)dir.Y, (double)dir.Z);
	}

	// Token: 0x0601BF52 RID: 114514 RVA: 0x00856F4C File Offset: 0x0085514C
	public void UpdateRangeOverlapInfo(bool isEnter, AActor otherActor)
	{
		if (!isEnter)
		{
			this.RangeOtherActorLocation = null;
			this.RangeOtherActorVelocityProxy = null;
			return;
		}
		if (otherActor == null || !otherActor.IsValid())
		{
			return;
		}
		this.RangeOtherActorLocation = new FVectorDouble?(otherActor.D_K2_GetActorLocation());
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(otherActor, false);
		if (entityByActor != null)
		{
			BPELevelPrefabDestructibleOverlapSource rangeOtherActorVelocitySource = this.RangeOtherActorVelocitySource;
			if (rangeOtherActorVelocitySource != BPELevelPrefabDestructibleOverlapSource.角色)
			{
				if (rangeOtherActorVelocitySource != BPELevelPrefabDestructibleOverlapSource.载具)
				{
					return;
				}
				WorldEntity entity = entityByActor.Entity;
				VehicleActorComponent vehicleActorComponent = (entity != null) ? entity.GetComponent<VehicleActorComponent>() : null;
				if (vehicleActorComponent != null)
				{
					this.RangeOtherActorVelocityProxy = vehicleActorComponent.ActorVelocityProxy;
					return;
				}
			}
			else
			{
				WorldEntity entity2 = entityByActor.Entity;
				CharacterActorComponent characterActorComponent = (entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null;
				if (characterActorComponent != null)
				{
					this.RangeOtherActorVelocityProxy = characterActorComponent.ActorVelocityProxy;
					return;
				}
			}
		}
		else
		{
			UCharacterMovementComponent ucharacterMovementComponent = otherActor.GetComponentByClass(UCharacterMovementComponent.StaticClass()) as UCharacterMovementComponent;
			if (ucharacterMovementComponent != null)
			{
				this.RangeOtherActorVelocityProxy = Vector.Create(ucharacterMovementComponent.Velocity);
			}
		}
	}

	// Token: 0x0601BF53 RID: 114515 RVA: 0x00857028 File Offset: 0x00855228
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void TryStopCurrentState()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TryStopCurrentState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF54 RID: 114516 RVA: 0x00857098 File Offset: 0x00855298
	protected void TryStopCurrentState_Implementation()
	{
		if (this.CurrentState != null)
		{
			this.StopState(this.CurrentState, null);
		}
	}

	// Token: 0x17002624 RID: 9764
	// (get) Token: 0x0601BF55 RID: 114517 RVA: 0x008570B5 File Offset: 0x008552B5
	// (set) Token: 0x0601BF56 RID: 114518 RVA: 0x008570C5 File Offset: 0x008552C5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 需要过渡状态
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_需要过渡状态) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_需要过渡状态) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002625 RID: 9765
	// (get) Token: 0x0601BF57 RID: 114519 RVA: 0x008570D6 File Offset: 0x008552D6
	// (set) Token: 0x0601BF58 RID: 114520 RVA: 0x008570E6 File Offset: 0x008552E6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 跳过表现过程
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_跳过表现过程) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_跳过表现过程) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002626 RID: 9766
	// (get) Token: 0x0601BF59 RID: 114521 RVA: 0x008570F7 File Offset: 0x008552F7
	// (set) Token: 0x0601BF5A RID: 114522 RVA: 0x00857107 File Offset: 0x00855307
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EKuroSceneInteractionState 模拟状态
	{
		get
		{
			return (EKuroSceneInteractionState)(*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_模拟状态));
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_模拟状态) = (byte)value;
		}
	}

	// Token: 0x17002627 RID: 9767
	// (get) Token: 0x0601BF5B RID: 114523 RVA: 0x00857118 File Offset: 0x00855318
	// (set) Token: 0x0601BF5C RID: 114524 RVA: 0x0085712C File Offset: 0x0085532C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 模拟Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_模拟Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionActor.__PropertyOffset_模拟Tag) = value;
		}
	}

	// Token: 0x0601BF5D RID: 114525 RVA: 0x00857144 File Offset: 0x00855344
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 使用字段值切换状态()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("使用字段值切换状态"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF5E RID: 114526 RVA: 0x008571B4 File Offset: 0x008553B4
	protected void 使用字段值切换状态_Implementation()
	{
		this.ChangeStateInternal(this.模拟状态);
	}

	// Token: 0x0601BF5F RID: 114527 RVA: 0x008571C4 File Offset: 0x008553C4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState1()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState1"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF60 RID: 114528 RVA: 0x00857234 File Offset: 0x00855434
	protected void ChangeState1_Implementation()
	{
		string sequencePath = "/Game/Aki/GamePlay/Mechanism/Test.Test";
		MechanismUtils.GetAllAnimNotifyEventsByPath(sequencePath, delegate([Nullable(new byte[]
		{
			2,
			1
		})] List<IEventData> eventData)
		{
			if (eventData != null)
			{
				foreach (IEventData eventData2 in eventData)
				{
				}
			}
		});
		MechanismUtils.GetAllAnimNotifyStateEventsByPath(sequencePath, delegate([Nullable(new byte[]
		{
			2,
			1
		})] List<IEventData> eventData)
		{
			if (eventData != null)
			{
				foreach (IEventData eventData2 in eventData)
				{
				}
			}
		});
	}

	// Token: 0x0601BF61 RID: 114529 RVA: 0x00857290 File Offset: 0x00855490
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState2()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF62 RID: 114530 RVA: 0x00857300 File Offset: 0x00855500
	protected void ChangeState2_Implementation()
	{
		this.ChangeStateInternal(EKuroSceneInteractionState.State2);
	}

	// Token: 0x0601BF63 RID: 114531 RVA: 0x0085730C File Offset: 0x0085550C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState3()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState3"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF64 RID: 114532 RVA: 0x0085737C File Offset: 0x0085557C
	protected void ChangeState3_Implementation()
	{
		this.ChangeStateInternal(EKuroSceneInteractionState.State3);
	}

	// Token: 0x0601BF65 RID: 114533 RVA: 0x00857388 File Offset: 0x00855588
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState4()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState4"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF66 RID: 114534 RVA: 0x008573F8 File Offset: 0x008555F8
	protected void ChangeState4_Implementation()
	{
		this.ChangeStateInternal(EKuroSceneInteractionState.State4);
	}

	// Token: 0x0601BF67 RID: 114535 RVA: 0x00857404 File Offset: 0x00855604
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState5()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState5"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF68 RID: 114536 RVA: 0x00857474 File Offset: 0x00855674
	protected void ChangeState5_Implementation()
	{
		this.ChangeStateInternal(EKuroSceneInteractionState.State5);
	}

	// Token: 0x0601BF69 RID: 114537 RVA: 0x00857480 File Offset: 0x00855680
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState6()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState6"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF6A RID: 114538 RVA: 0x008574F0 File Offset: 0x008556F0
	protected void ChangeState6_Implementation()
	{
		this.ChangeStateInternal(EKuroSceneInteractionState.State6);
	}

	// Token: 0x0601BF6B RID: 114539 RVA: 0x008574FC File Offset: 0x008556FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState7()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState7"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF6C RID: 114540 RVA: 0x0085756C File Offset: 0x0085576C
	protected void ChangeState7_Implementation()
	{
		this.ChangeStateInternal(EKuroSceneInteractionState.State7);
	}

	// Token: 0x0601BF6D RID: 114541 RVA: 0x00857578 File Offset: 0x00855778
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState8()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState8"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF6E RID: 114542 RVA: 0x008575E8 File Offset: 0x008557E8
	protected void ChangeState8_Implementation()
	{
		this.ChangeStateInternal(EKuroSceneInteractionState.State8);
	}

	// Token: 0x0601BF6F RID: 114543 RVA: 0x008575F4 File Offset: 0x008557F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 模拟Tag添加()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("模拟Tag添加"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF70 RID: 114544 RVA: 0x00857664 File Offset: 0x00855864
	protected void 模拟Tag添加_Implementation()
	{
		FGameplayTag 模拟Tag = this.模拟Tag;
		this.PlayExtraEffectOnTagsChange(this.模拟Tag, this.跳过表现过程);
	}

	// Token: 0x0601BF71 RID: 114545 RVA: 0x0085768C File Offset: 0x0085588C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 模拟Tag移除()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("模拟Tag移除"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF72 RID: 114546 RVA: 0x008576FC File Offset: 0x008558FC
	protected void 模拟Tag移除_Implementation()
	{
		FGameplayTag 模拟Tag = this.模拟Tag;
		this.StopExtraEffectOnTagsChange(this.模拟Tag);
		SSceneInteractionTags ssceneInteractionTags;
		if (this.TagsAndCorrespondingEffects != null && this.TagsAndCorrespondingEffects.TryGetValue(this.模拟Tag, out ssceneInteractionTags))
		{
			SSceneInteractionSequence ssceneInteractionSequence = (ssceneInteractionTags != null) ? ssceneInteractionTags.Sequence : null;
			if (ssceneInteractionSequence != null)
			{
				SSceneInteractionSequence ssceneInteractionSequence2 = new SSceneInteractionSequence(ssceneInteractionSequence.Sequence, ssceneInteractionSequence.IsLoop, !ssceneInteractionSequence.Reverse, ssceneInteractionSequence.PlayRate);
				ULevelSequence sequence = ssceneInteractionSequence2.Sequence;
				if (sequence != null)
				{
					ALevelSequenceActor alevelSequenceActor = this.CreateDirectorBySequence(sequence);
					if (alevelSequenceActor != null)
					{
						this.PlaySequence(alevelSequenceActor, ssceneInteractionSequence2, ssceneInteractionTags.Actors, true);
					}
				}
			}
		}
	}

	// Token: 0x0601BF73 RID: 114547 RVA: 0x0085779C File Offset: 0x0085599C
	private void ChangeStateInternal(EKuroSceneInteractionState stateId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneGameplay;
		ELogAuthor author = ELogAuthor.YSQ;
		string message = "change state";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stateId", stateId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.Active = true;
		this.SetState(stateId, this.需要过渡状态, this.跳过表现过程);
	}

	// Token: 0x0601BF74 RID: 114548 RVA: 0x008577F0 File Offset: 0x008559F0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 重置()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("重置"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601BF75 RID: 114549 RVA: 0x00857860 File Offset: 0x00855A60
	protected void 重置_Implementation()
	{
		string[] array = UKismetSystemLibrary.GetPathName(base.GetLevel()).Split('/', StringSplitOptions.None);
		string text = "";
		for (int i = 1; i < array.Length - 1; i++)
		{
			string str = array[i];
			text = text + "/" + str;
		}
		string[] array2 = array[array.Length - 1].Split(':', StringSplitOptions.None)[0].Split('.', StringSplitOptions.None);
		string str2 = array2[array2.Length - 1];
		text = text + "/" + str2;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneGameplay;
		ELogAuthor author = ELogAuthor.YSQ;
		string message = "ResetState";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelName", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		TsCharacterController characterController = Global.CharacterController;
		if (characterController == null)
		{
			return;
		}
		characterController.ClientTravel(text, ETravelType.TRAVEL_Absolute, true, default(FGuid));
	}

	// Token: 0x0601BF76 RID: 114550 RVA: 0x0085791F File Offset: 0x00855B1F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (SceneInteractionActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Item/SceneInteractionActor.SceneInteractionActor_C");
		}
		return SceneInteractionActor._ClassPtr;
	}

	// Token: 0x0601BF77 RID: 114551 RVA: 0x00857944 File Offset: 0x00855B44
	public SceneInteractionActor() : this(BuiltinUtils.AllocNativeUObject(SceneInteractionActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BF78 RID: 114552 RVA: 0x0085796C File Offset: 0x00855B6C
	public SceneInteractionActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneInteractionActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BF79 RID: 114553 RVA: 0x008579A0 File Offset: 0x00855BA0
	protected SceneInteractionActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BF7A RID: 114554 RVA: 0x00857A2C File Offset: 0x00855C2C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetOverrideSeqBindActor_Implementation(SceneInteractionActor.__SetOverrideSeqBindActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actorToBind);
		string bindingName = FString.ToString((void*)(&__Params->bindingName));
		this.SetOverrideSeqBindActor_Implementation(orCreateUObjectByNativePointer, bindingName);
	}

	// Token: 0x0601BF7B RID: 114555 RVA: 0x00857A5C File Offset: 0x00855C5C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_UnsetOverrideSeqBindActor_Implementation(SceneInteractionActor.__UnsetOverrideSeqBindActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actorToUnbind);
		string bindingName = FString.ToString((void*)(&__Params->bindingName));
		this.UnsetOverrideSeqBindActor_Implementation(orCreateUObjectByNativePointer, bindingName);
	}

	// Token: 0x0601BF7C RID: 114556 RVA: 0x00857A8A File Offset: 0x00855C8A
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601BF7D RID: 114557 RVA: 0x00857A94 File Offset: 0x00855C94
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601BF7E RID: 114558 RVA: 0x00857AB4 File Offset: 0x00855CB4
	protected virtual void __CPPCALL_AddNewState_Implementation()
	{
		this.AddNewState_Implementation();
	}

	// Token: 0x0601BF7F RID: 114559 RVA: 0x00857ABC File Offset: 0x00855CBC
	protected virtual void __CPPCALL_AddNewEffect_Implementation()
	{
		this.AddNewEffect_Implementation();
	}

	// Token: 0x0601BF80 RID: 114560 RVA: 0x00857AC4 File Offset: 0x00855CC4
	protected virtual void __CPPCALL_AddNewEndEffect_Implementation()
	{
		this.AddNewEndEffect_Implementation();
	}

	// Token: 0x0601BF81 RID: 114561 RVA: 0x00857ACC File Offset: 0x00855CCC
	protected virtual void __CPPCALL_UpdateTimeDilation_Implementation()
	{
		this.UpdateTimeDilation_Implementation();
	}

	// Token: 0x0601BF82 RID: 114562 RVA: 0x00857AD4 File Offset: 0x00855CD4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_CheckAllEffectPlaying_Implementation(SceneInteractionActor.__CheckAllEffectPlaying_FunctionParams* __Params)
	{
		__Params->__Result = this.CheckAllEffectPlaying_Implementation();
	}

	// Token: 0x0601BF83 RID: 114563 RVA: 0x00857AE4 File Offset: 0x00855CE4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PlayKuroSkeletalMeshDestruction_Implementation(SceneInteractionActor.__PlayKuroSkeletalMeshDestruction_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		this.PlayKuroSkeletalMeshDestruction_Implementation(orCreateUObjectByNativePointer, __Params->isJumpToEnd);
	}

	// Token: 0x0601BF84 RID: 114564 RVA: 0x00857B0C File Offset: 0x00855D0C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OverrideKuroDestructibleActorPhysicsVelocity_Implementation(SceneInteractionActor.__OverrideKuroDestructibleActorPhysicsVelocity_FunctionParams* __Params)
	{
		AKuroDestructibleActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AKuroDestructibleActor>(__Params->skeletalMeshDestruction);
		this.OverrideKuroDestructibleActorPhysicsVelocity_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BF85 RID: 114565 RVA: 0x00857B2C File Offset: 0x00855D2C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetActiveSequenceRemainTime_Implementation(SceneInteractionActor.__GetActiveSequenceRemainTime_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->sequence);
		__Params->__Result = this.GetActiveSequenceRemainTime_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601BF86 RID: 114566 RVA: 0x00857B52 File Offset: 0x00855D52
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ApplyAnimOptimizationParams_Implementation(SceneInteractionActor.__ApplyAnimOptimizationParams_FunctionParams* __Params)
	{
		this.ApplyAnimOptimizationParams_Implementation(__Params->bUseDistanceMap);
	}

	// Token: 0x0601BF87 RID: 114567 RVA: 0x00857B60 File Offset: 0x00855D60
	protected virtual void __CPPCALL_PendingPlayStateEffect_Implementation()
	{
		this.PendingPlayStateEffect_Implementation();
	}

	// Token: 0x0601BF88 RID: 114568 RVA: 0x00857B68 File Offset: 0x00855D68
	protected virtual void __CPPCALL_RemovePendingStateEffectTick_Implementation()
	{
		this.RemovePendingStateEffectTick_Implementation();
	}

	// Token: 0x0601BF89 RID: 114569 RVA: 0x00857B70 File Offset: 0x00855D70
	protected virtual void __CPPCALL_PendingPlayCrossStateEffect_Implementation()
	{
		this.PendingPlayCrossStateEffect_Implementation();
	}

	// Token: 0x0601BF8A RID: 114570 RVA: 0x00857B78 File Offset: 0x00855D78
	protected virtual void __CPPCALL_RemovePendingCrossStateEffectTick_Implementation()
	{
		this.RemovePendingCrossStateEffectTick_Implementation();
	}

	// Token: 0x0601BF8B RID: 114571 RVA: 0x00857B80 File Offset: 0x00855D80
	protected virtual void __CPPCALL_PendingPlayTagEffect_Implementation()
	{
		this.PendingPlayTagEffect_Implementation();
	}

	// Token: 0x0601BF8C RID: 114572 RVA: 0x00857B88 File Offset: 0x00855D88
	protected virtual void __CPPCALL_RemovePendingTagEffectTick_Implementation()
	{
		this.RemovePendingTagEffectTick_Implementation();
	}

	// Token: 0x0601BF8D RID: 114573 RVA: 0x00857B90 File Offset: 0x00855D90
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PostAutoMergeEvent_Implementation(SceneInteractionActor.__PostAutoMergeEvent_FunctionParams* __Params)
	{
		string eventName = FString.ToString((void*)(&__Params->eventName));
		this.PostAutoMergeEvent_Implementation(eventName, __Params->tagId, __Params->follow);
	}

	// Token: 0x0601BF8E RID: 114574 RVA: 0x00857BC0 File Offset: 0x00855DC0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PostTagEvent_Implementation(SceneInteractionActor.__PostTagEvent_FunctionParams* __Params)
	{
		string eventName = FString.ToString((void*)(&__Params->eventName));
		this.PostTagEvent_Implementation(eventName, __Params->tag, __Params->follow);
	}

	// Token: 0x0601BF8F RID: 114575 RVA: 0x00857BED File Offset: 0x00855DED
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_StopTagAkEvent_Implementation(SceneInteractionActor.__StopTagAkEvent_FunctionParams* __Params)
	{
		this.StopTagAkEvent_Implementation(__Params->tag);
	}

	// Token: 0x0601BF90 RID: 114576 RVA: 0x00857BFB File Offset: 0x00855DFB
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_UpdateProjectionActorTransform_Implementation(SceneInteractionActor.__UpdateProjectionActorTransform_FunctionParams* __Params)
	{
		this.UpdateProjectionActorTransform_Implementation(__Params->transform);
	}

	// Token: 0x0601BF91 RID: 114577 RVA: 0x00857C0C File Offset: 0x00855E0C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_AddMatrialDataForChildrenActor_Implementation(SceneInteractionActor.__AddMatrialDataForChildrenActor_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		ItemMaterialControllerActorData orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<ItemMaterialControllerActorData>(__Params->materialData);
		this.AddMatrialDataForChildrenActor_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BF92 RID: 114578 RVA: 0x00857C39 File Offset: 0x00855E39
	protected virtual void __CPPCALL_RemoveActorProjection_Implementation()
	{
		this.RemoveActorProjection_Implementation();
	}

	// Token: 0x0601BF93 RID: 114579 RVA: 0x00857C41 File Offset: 0x00855E41
	protected virtual void __CPPCALL_DestroySelf_Implementation()
	{
		this.DestroySelf_Implementation();
	}

	// Token: 0x0601BF94 RID: 114580 RVA: 0x00857C49 File Offset: 0x00855E49
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ResetTagActorHide_Implementation(SceneInteractionActor.__ResetTagActorHide_FunctionParams* __Params)
	{
		this.ResetTagActorHide_Implementation(__Params->tag);
	}

	// Token: 0x0601BF95 RID: 114581 RVA: 0x00857C58 File Offset: 0x00855E58
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetDirectorBySequence_Implementation(SceneInteractionActor.__GetDirectorBySequence_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->sequence);
		ref IntPtr ptr = ref *(&__Params->__Result);
		ALevelSequenceActor directorBySequence_Implementation = this.GetDirectorBySequence_Implementation(orCreateUObjectByNativePointer);
		ptr = ((directorBySequence_Implementation != null) ? directorBySequence_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601BF96 RID: 114582 RVA: 0x00857C8D File Offset: 0x00855E8D
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_StopExtraEffectOnTagsChange_Implementation(SceneInteractionActor.__StopExtraEffectOnTagsChange_FunctionParams* __Params)
	{
		this.StopExtraEffectOnTagsChange_Implementation(__Params->tag);
	}

	// Token: 0x0601BF97 RID: 114583 RVA: 0x00857C9B File Offset: 0x00855E9B
	protected virtual void __CPPCALL_TryStopCurrentState_Implementation()
	{
		this.TryStopCurrentState_Implementation();
	}

	// Token: 0x0601BF98 RID: 114584 RVA: 0x00857CA3 File Offset: 0x00855EA3
	protected virtual void __CPPCALL_使用字段值切换状态_Implementation()
	{
		this.使用字段值切换状态_Implementation();
	}

	// Token: 0x0601BF99 RID: 114585 RVA: 0x00857CAB File Offset: 0x00855EAB
	protected virtual void __CPPCALL_ChangeState1_Implementation()
	{
		this.ChangeState1_Implementation();
	}

	// Token: 0x0601BF9A RID: 114586 RVA: 0x00857CB3 File Offset: 0x00855EB3
	protected virtual void __CPPCALL_ChangeState2_Implementation()
	{
		this.ChangeState2_Implementation();
	}

	// Token: 0x0601BF9B RID: 114587 RVA: 0x00857CBB File Offset: 0x00855EBB
	protected virtual void __CPPCALL_ChangeState3_Implementation()
	{
		this.ChangeState3_Implementation();
	}

	// Token: 0x0601BF9C RID: 114588 RVA: 0x00857CC3 File Offset: 0x00855EC3
	protected virtual void __CPPCALL_ChangeState4_Implementation()
	{
		this.ChangeState4_Implementation();
	}

	// Token: 0x0601BF9D RID: 114589 RVA: 0x00857CCB File Offset: 0x00855ECB
	protected virtual void __CPPCALL_ChangeState5_Implementation()
	{
		this.ChangeState5_Implementation();
	}

	// Token: 0x0601BF9E RID: 114590 RVA: 0x00857CD3 File Offset: 0x00855ED3
	protected virtual void __CPPCALL_ChangeState6_Implementation()
	{
		this.ChangeState6_Implementation();
	}

	// Token: 0x0601BF9F RID: 114591 RVA: 0x00857CDB File Offset: 0x00855EDB
	protected virtual void __CPPCALL_ChangeState7_Implementation()
	{
		this.ChangeState7_Implementation();
	}

	// Token: 0x0601BFA0 RID: 114592 RVA: 0x00857CE3 File Offset: 0x00855EE3
	protected virtual void __CPPCALL_ChangeState8_Implementation()
	{
		this.ChangeState8_Implementation();
	}

	// Token: 0x0601BFA1 RID: 114593 RVA: 0x00857CEB File Offset: 0x00855EEB
	protected virtual void __CPPCALL_模拟Tag添加_Implementation()
	{
		this.模拟Tag添加_Implementation();
	}

	// Token: 0x0601BFA2 RID: 114594 RVA: 0x00857CF3 File Offset: 0x00855EF3
	protected virtual void __CPPCALL_模拟Tag移除_Implementation()
	{
		this.模拟Tag移除_Implementation();
	}

	// Token: 0x0601BFA3 RID: 114595 RVA: 0x00857CFB File Offset: 0x00855EFB
	protected virtual void __CPPCALL_重置_Implementation()
	{
		this.重置_Implementation();
	}

	// Token: 0x0400E1CE RID: 57806
	private const float DEFAULT_DAMAGE_AMOUNT = 1f;

	// Token: 0x0400E1CF RID: 57807
	public int PbDataId;

	// Token: 0x0400E1D0 RID: 57808
	[Nullable(2)]
	private Action OnInitCallback;

	// Token: 0x0400E1D1 RID: 57809
	public bool Active = true;

	// Token: 0x0400E1D2 RID: 57810
	[Nullable(2)]
	private ULevelSequencePlayer ActiveSequencePlayer;

	// Token: 0x0400E1D3 RID: 57811
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<ULevelSequence, ALevelSequenceActor> ActiveSequenceDirectorMap;

	// Token: 0x0400E1D4 RID: 57812
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<ALevelSequenceActor, SequenceDirectorConfig> DirectorConfigMap;

	// Token: 0x0400E1D5 RID: 57813
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, EffectInfo> ActiveEffectInfoMap;

	// Token: 0x0400E1D6 RID: 57814
	private EKuroSceneInteractionState? CurrentStateKey;

	// Token: 0x0400E1D7 RID: 57815
	[Nullable(2)]
	private SSceneInteractionitem CurrentState;

	// Token: 0x0400E1D8 RID: 57816
	[Nullable(2)]
	private SSceneInteractionitem TransitionState;

	// Token: 0x0400E1D9 RID: 57817
	private EKuroSceneInteractionState? TransitionStateKey;

	// Token: 0x0400E1DA RID: 57818
	[Nullable(2)]
	private SSceneInteractionitem NextState;

	// Token: 0x0400E1DB RID: 57819
	private EKuroSceneInteractionState? NextStateKey;

	// Token: 0x0400E1DC RID: 57820
	private bool InTransition;

	// Token: 0x0400E1DD RID: 57821
	private bool InWaitingForPlayableFinished;

	// Token: 0x0400E1DE RID: 57822
	private bool TransitionStateJumpToEnd;

	// Token: 0x0400E1DF RID: 57823
	private bool IsUseTransitionTime;

	// Token: 0x0400E1E0 RID: 57824
	private float SwitchingStateRemainTime;

	// Token: 0x0400E1E1 RID: 57825
	private bool IsPlayBack;

	// Token: 0x0400E1E2 RID: 57826
	[Nullable(2)]
	private UKuroSceneInteractionActorSystem KuroSceneInteractionActorSystem;

	// Token: 0x0400E1E3 RID: 57827
	[Nullable(2)]
	private AActor ProjectionRootActor;

	// Token: 0x0400E1E4 RID: 57828
	private bool IsProjecting;

	// Token: 0x0400E1E5 RID: 57829
	[Nullable(2)]
	public CharRenderingComponent CharRenderingComponent;

	// Token: 0x0400E1E6 RID: 57830
	public int CharRenderingKey;

	// Token: 0x0400E1E7 RID: 57831
	public FVectorDouble? HitLocation;

	// Token: 0x0400E1E8 RID: 57832
	public FVectorDouble HitDirection = new FVectorDouble(0.0, 0.0, 1.0);

	// Token: 0x0400E1E9 RID: 57833
	public FVectorDouble? RangeOtherActorLocation;

	// Token: 0x0400E1EA RID: 57834
	[Nullable(2)]
	public Vector RangeOtherActorVelocityProxy;

	// Token: 0x0400E1EB RID: 57835
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<CharRenderingComponent, int> CharRenderingComponents;

	// Token: 0x0400E1EC RID: 57836
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<BP_EffectActor_C> CrossStateEffectActors;

	// Token: 0x0400E1ED RID: 57837
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<AActor, FTransformDouble> ActorsOriginalRelTransform;

	// Token: 0x0400E1EE RID: 57838
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<UStaticMeshComponent, Dictionary<int, UMaterialInterface>> RevertMaterialComponentsMaps;

	// Token: 0x0400E1EF RID: 57839
	private bool MergeCurrentStateAkEvent;

	// Token: 0x0400E1F0 RID: 57840
	[Nullable(2)]
	private Dictionary<FGameplayTag, int> PlayingTagAkEventHandle;

	// Token: 0x0400E1F1 RID: 57841
	[Nullable(2)]
	private BP_GlobalGI_C GlobalGi;

	// Token: 0x0400E1F2 RID: 57842
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<ASkeletalMeshActor, SkeletalMontageConfig> SkeletalMontageConfigMap;

	// Token: 0x0400E1F3 RID: 57843
	private int SkeletalMeshDestructibleActorInitCount;

	// Token: 0x0400E1F4 RID: 57844
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<AKuroDestructibleActor> SkeletalMeshDestructibleActorsInternal;

	// Token: 0x0400E1F5 RID: 57845
	private int DebugTickId = -1;

	// Token: 0x0400E1F6 RID: 57846
	private List<BP_EffectActor_C> PendingStateEffects = new List<BP_EffectActor_C>();

	// Token: 0x0400E1F7 RID: 57847
	private int PendingStateEffectTickId = -1;

	// Token: 0x0400E1F8 RID: 57848
	private readonly Dictionary<FGameplayTag, List<BP_EffectActor_C>> PendingTagEffects = new Dictionary<FGameplayTag, List<BP_EffectActor_C>>();

	// Token: 0x0400E1F9 RID: 57849
	private int PendingTagEffectTickId = -1;

	// Token: 0x0400E1FA RID: 57850
	private readonly Dictionary<BP_EffectActor_C, int> PendingCrossStateEffects = new Dictionary<BP_EffectActor_C, int>();

	// Token: 0x0400E1FB RID: 57851
	private int PendingCrossStateEffectTickId = -1;

	// Token: 0x0400E1FC RID: 57852
	public Dictionary<int, int> AkEventPostHandle = new Dictionary<int, int>();

	// Token: 0x0400E1FD RID: 57853
	[Nullable(2)]
	public Action OverrideEffectParmaFunc;

	// Token: 0x0400E1FE RID: 57854
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, AActor> OverrideSeqBindActors;

	// Token: 0x0400E1FF RID: 57855
	private bool IsAbpAnimPlayEnd;

	// Token: 0x0400E200 RID: 57856
	[Nullable(2)]
	private List<int> TagCharDaHandleList;

	// Token: 0x0400E201 RID: 57857
	[Nullable(2)]
	private Action<int> OnEffectFinishCallback;

	// Token: 0x0400E202 RID: 57858
	[Nullable(2)]
	private Action<ELoadEffectResult, int> OnEffectPlayingCallback;

	// Token: 0x0400E203 RID: 57859
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Item/SceneInteractionActor.SceneInteractionActor_C";

	// Token: 0x0400E204 RID: 57860
	private static IntPtr _ClassPtr;

	// Token: 0x0400E205 RID: 57861
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E206 RID: 57862
	private static int __PropertyOffset_LevelName;

	// Token: 0x0400E207 RID: 57863
	private static int __PropertyOffset_HandleId;

	// Token: 0x0400E208 RID: 57864
	private static int __PropertyOffset_States;

	// Token: 0x0400E209 RID: 57865
	[Nullable(2)]
	private TMap<EKuroSceneInteractionState, SSceneInteractionitem> _States;

	// Token: 0x0400E20A RID: 57866
	private static int __PropertyOffset_Effects;

	// Token: 0x0400E20B RID: 57867
	[Nullable(2)]
	private TMap<ESceneInteractionEffect, SScenePropertyEffect> _Effects;

	// Token: 0x0400E20C RID: 57868
	private static int __PropertyOffset_EffectsInheritTimeDilation;

	// Token: 0x0400E20D RID: 57869
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<BP_EffectActor_C> _EffectsInheritTimeDilation;

	// Token: 0x0400E20E RID: 57870
	private static int __PropertyOffset_EndEffects;

	// Token: 0x0400E20F RID: 57871
	[Nullable(2)]
	private TMap<ESceneInteractionEffect, BP_EffectActor_C> _EndEffects;

	// Token: 0x0400E210 RID: 57872
	private static int __PropertyOffset_ReferenceActors;

	// Token: 0x0400E211 RID: 57873
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<string, AActor> _ReferenceActors;

	// Token: 0x0400E212 RID: 57874
	private static int __PropertyOffset_TagsAndCorrespondingEffects;

	// Token: 0x0400E213 RID: 57875
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<FGameplayTag, SSceneInteractionTags> _TagsAndCorrespondingEffects;

	// Token: 0x0400E214 RID: 57876
	private static int __PropertyOffset_CollisionActors;

	// Token: 0x0400E215 RID: 57877
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<AActor> _CollisionActors;

	// Token: 0x0400E216 RID: 57878
	private static int __PropertyOffset_PartCollisionActorsAndCorrespondingTags;

	// Token: 0x0400E217 RID: 57879
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<AActor, FGameplayTag> _PartCollisionActorsAndCorrespondingTags;

	// Token: 0x0400E218 RID: 57880
	private static int __PropertyOffset_InteractionEffectHookActors;

	// Token: 0x0400E219 RID: 57881
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<AActor> _InteractionEffectHookActors;

	// Token: 0x0400E21A RID: 57882
	private static int __PropertyOffset_CharacterForOrgan;

	// Token: 0x0400E21B RID: 57883
	private static int __PropertyOffset_ActorsForProjection;

	// Token: 0x0400E21C RID: 57884
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<AActor> _ActorsForProjection;

	// Token: 0x0400E21D RID: 57885
	private static int __PropertyOffset_MaterialForProjection;

	// Token: 0x0400E21E RID: 57886
	private static int __PropertyOffset_ReceivingDecalsActors;

	// Token: 0x0400E21F RID: 57887
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<AActor> _ReceivingDecalsActors;

	// Token: 0x0400E220 RID: 57888
	private static int __PropertyOffset_StaticMeshList;

	// Token: 0x0400E221 RID: 57889
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<UStaticMesh> _StaticMeshList;

	// Token: 0x0400E222 RID: 57890
	private static int __PropertyOffset_RangeOtherActorVelocitySource;

	// Token: 0x0400E223 RID: 57891
	private static int __PropertyOffset_SkeletalMeshActors;

	// Token: 0x0400E224 RID: 57892
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<ASkeletalMeshActor> _SkeletalMeshActors;

	// Token: 0x0400E225 RID: 57893
	private static int __PropertyOffset_AllSkeletalMeshActors;

	// Token: 0x0400E226 RID: 57894
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<ASkeletalMeshActor> _AllSkeletalMeshActors;

	// Token: 0x0400E227 RID: 57895
	private static int __PropertyOffset_InteractionMaterialController;

	// Token: 0x0400E228 RID: 57896
	private static int __PropertyOffset_BasePlatformInternal;

	// Token: 0x0400E229 RID: 57897
	private static int __PropertyOffset_CurrentStateAkEventHandle;

	// Token: 0x0400E22A RID: 57898
	private static int __PropertyOffset_OverrideEffectActor;

	// Token: 0x0400E22B RID: 57899
	private static int __PropertyOffset_需要过渡状态;

	// Token: 0x0400E22C RID: 57900
	private static int __PropertyOffset_跳过表现过程;

	// Token: 0x0400E22D RID: 57901
	private static int __PropertyOffset_模拟状态;

	// Token: 0x0400E22E RID: 57902
	private static int __PropertyOffset_模拟Tag;

	// Token: 0x020094EC RID: 38124
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetOverrideSeqBindActor_FunctionParams
	{
		// Token: 0x040314F0 RID: 201968
		[FieldOffset(0)]
		public IntPtr actorToBind;

		// Token: 0x040314F1 RID: 201969
		[FieldOffset(8)]
		public FString bindingName;
	}

	// Token: 0x020094ED RID: 38125
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UnsetOverrideSeqBindActor_FunctionParams
	{
		// Token: 0x040314F2 RID: 201970
		[FieldOffset(0)]
		public IntPtr actorToUnbind;

		// Token: 0x040314F3 RID: 201971
		[FieldOffset(8)]
		public FString bindingName;
	}

	// Token: 0x020094EE RID: 38126
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __CheckAllEffectPlaying_FunctionParams
	{
		// Token: 0x040314F4 RID: 201972
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x020094EF RID: 38127
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __PlayKuroSkeletalMeshDestruction_FunctionParams
	{
		// Token: 0x040314F5 RID: 201973
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x040314F6 RID: 201974
		[FieldOffset(8)]
		public bool isJumpToEnd;
	}

	// Token: 0x020094F0 RID: 38128
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __OverrideKuroDestructibleActorPhysicsVelocity_FunctionParams
	{
		// Token: 0x040314F7 RID: 201975
		[FieldOffset(0)]
		public IntPtr skeletalMeshDestruction;
	}

	// Token: 0x020094F1 RID: 38129
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetActiveSequenceRemainTime_FunctionParams
	{
		// Token: 0x040314F8 RID: 201976
		[FieldOffset(0)]
		public IntPtr sequence;

		// Token: 0x040314F9 RID: 201977
		[FieldOffset(8)]
		public float __Result;
	}

	// Token: 0x020094F2 RID: 38130
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __ApplyAnimOptimizationParams_FunctionParams
	{
		// Token: 0x040314FA RID: 201978
		[FieldOffset(0)]
		public bool bUseDistanceMap;
	}

	// Token: 0x020094F3 RID: 38131
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __PostAutoMergeEvent_FunctionParams
	{
		// Token: 0x040314FB RID: 201979
		[FieldOffset(0)]
		public FString eventName;

		// Token: 0x040314FC RID: 201980
		[FieldOffset(16)]
		public float tagId;

		// Token: 0x040314FD RID: 201981
		[FieldOffset(20)]
		public bool follow;
	}

	// Token: 0x020094F4 RID: 38132
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __PostTagEvent_FunctionParams
	{
		// Token: 0x040314FE RID: 201982
		[FieldOffset(0)]
		public FString eventName;

		// Token: 0x040314FF RID: 201983
		[FieldOffset(16)]
		public FGameplayTag tag;

		// Token: 0x04031500 RID: 201984
		[FieldOffset(28)]
		public bool follow;
	}

	// Token: 0x020094F5 RID: 38133
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __StopTagAkEvent_FunctionParams
	{
		// Token: 0x04031501 RID: 201985
		[FieldOffset(0)]
		public FGameplayTag tag;
	}

	// Token: 0x020094F6 RID: 38134
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __UpdateProjectionActorTransform_FunctionParams
	{
		// Token: 0x04031502 RID: 201986
		[FieldOffset(0)]
		public FTransformDouble transform;
	}

	// Token: 0x020094F7 RID: 38135
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AddMatrialDataForChildrenActor_FunctionParams
	{
		// Token: 0x04031503 RID: 201987
		[FieldOffset(0)]
		public IntPtr actor;

		// Token: 0x04031504 RID: 201988
		[FieldOffset(8)]
		public IntPtr materialData;
	}

	// Token: 0x020094F8 RID: 38136
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __ResetTagActorHide_FunctionParams
	{
		// Token: 0x04031505 RID: 201989
		[FieldOffset(0)]
		public FGameplayTag tag;
	}

	// Token: 0x020094F9 RID: 38137
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetDirectorBySequence_FunctionParams
	{
		// Token: 0x04031506 RID: 201990
		[FieldOffset(0)]
		public IntPtr sequence;

		// Token: 0x04031507 RID: 201991
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x020094FA RID: 38138
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 12)]
	protected ref struct __StopExtraEffectOnTagsChange_FunctionParams
	{
		// Token: 0x04031508 RID: 201992
		[FieldOffset(0)]
		public FGameplayTag tag;
	}
}
