using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Audio;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DFC RID: 3580
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyFootstepAudioEvent.TsSeqAnimNotifyFootstepAudioEvent_C")]
public class TsSeqAnimNotifyFootstepAudioEvent : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170005A3 RID: 1443
	// (get) Token: 0x0600534D RID: 21325 RVA: 0x000C3B7B File Offset: 0x000C1D7B
	// (set) Token: 0x0600534E RID: 21326 RVA: 0x000C3B8B File Offset: 0x000C1D8B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe E_FootstepVariant Variant
	{
		get
		{
			return (E_FootstepVariant)(*(base.NativePtr + (IntPtr)TsSeqAnimNotifyFootstepAudioEvent.__PropertyOffset_Variant));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSeqAnimNotifyFootstepAudioEvent.__PropertyOffset_Variant) = (byte)value;
		}
	}

	// Token: 0x170005A4 RID: 1444
	// (get) Token: 0x0600534F RID: 21327 RVA: 0x000C3B9C File Offset: 0x000C1D9C
	// (set) Token: 0x06005350 RID: 21328 RVA: 0x000C3BD5 File Offset: 0x000C1DD5
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAkAudioEvent> FootstepEvent
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAkAudioEvent> result;
			if ((result = this._FootstepEvent) == null)
			{
				result = (this._FootstepEvent = new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)TsSeqAnimNotifyFootstepAudioEvent.__PropertyOffset_FootstepEvent, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsSeqAnimNotifyFootstepAudioEvent.__PropertyOffset_FootstepEvent, 1);
		}
	}

	// Token: 0x170005A5 RID: 1445
	// (get) Token: 0x06005351 RID: 21329 RVA: 0x000C3BFA File Offset: 0x000C1DFA
	// (set) Token: 0x06005352 RID: 21330 RVA: 0x000C3C0E File Offset: 0x000C1E0E
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe UTraceLineElement FootTraceElement
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UTraceLineElement>(base.NativePtr / (IntPtr)sizeof(void*) + TsSeqAnimNotifyFootstepAudioEvent.__PropertyOffset_FootTraceElement);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsSeqAnimNotifyFootstepAudioEvent.__PropertyOffset_FootTraceElement, value);
		}
	}

	// Token: 0x170005A6 RID: 1446
	// (get) Token: 0x06005353 RID: 21331 RVA: 0x000C3C24 File Offset: 0x000C1E24
	[UProperty(EPropertyFlags.CPF_None)]
	private TMap<E_FootstepVariant, string> FootstepVariantMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<E_FootstepVariant, string> result;
			if ((result = this._FootstepVariantMap) == null)
			{
				result = (this._FootstepVariantMap = new TMap<E_FootstepVariant, string>(base.NativePtr + (IntPtr)TsSeqAnimNotifyFootstepAudioEvent.__PropertyOffset_FootstepVariantMap, this));
			}
			return result;
		}
	}

	// Token: 0x06005354 RID: 21332 RVA: 0x000C3C60 File Offset: 0x000C1E60
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06005355 RID: 21333 RVA: 0x000C3D00 File Offset: 0x000C1F00
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp == null)
		{
			return false;
		}
		if (meshComp.bHiddenInGame)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		if (owner.bHidden)
		{
			return false;
		}
		bool flag = false;
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(owner);
		if (worldType != BP_EWorldType.Game && worldType != BP_EWorldType.PIE)
		{
			ULevelSequence selectedSequenceInEditor = SequenceUtils.GetSelectedSequenceInEditor();
			if (selectedSequenceInEditor != null)
			{
				flag = selectedSequenceInEditor.GetAnimAudio();
				if (flag)
				{
					Singleton<AudioSystem>.Instance.SetSwitch("footstep_texture", CharacterFootEffectComponent.EFootstepTexture.DirtSurface.ToEnumString(), owner);
					string text = (this.FootstepEvent != null) ? Singleton<AudioSystem>.Instance.parseAudioEventPath(this.FootstepEvent) : null;
					if (text == null)
					{
						return false;
					}
					if (!SequenceUtils.CheckIfUseAudioSeq(owner))
					{
						return false;
					}
					UAkComponent akComponent = Singleton<AudioSystem>.Instance.GetAkComponent(owner, null, null);
					Singleton<AudioSystem>.Instance.PostEvent(text.ToString(), akComponent, null);
					return true;
				}
			}
		}
		else
		{
			ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
			bool? flag2;
			if (curLevelSeqActor == null)
			{
				flag2 = null;
			}
			else
			{
				ULevelSequence sequence = curLevelSeqActor.GetSequence();
				flag2 = ((sequence != null) ? new bool?(sequence.GetAnimAudio()) : null);
			}
			bool? flag3 = flag2;
			flag = flag3.GetValueOrDefault();
		}
		if (!flag)
		{
			return false;
		}
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.land, "land");
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.run, "run");
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.runstop, "runstop");
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.sprint, "sprint");
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.sprintstop, "sprintstop");
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.walk, "walk");
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.walkstop, "walkstop");
		this.FootstepVariantMap.TryAdd(E_FootstepVariant.turnback, "turnback");
		FVectorDouble fvectorDouble = owner.D_K2_GetActorLocation();
		this.FootTraceElement = new UTraceLineElement();
		this.FootTraceElement.bIsProfile = true;
		this.FootTraceElement.bIsSingle = true;
		this.FootTraceElement.bTraceComplex = true;
		this.FootTraceElement.bIgnoreSelf = true;
		this.FootTraceElement.WorldContextObject = owner;
		this.FootTraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		this.FootTraceElement.SetStartLocation(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z);
		this.FootTraceElement.SetEndLocation(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z - 400.0);
		UKuroTraceLibrary.LineTrace(this.FootTraceElement, "");
		UAkComponent akComponent2 = Singleton<AudioSystem>.Instance.GetAkComponent(owner, null, null);
		Singleton<AudioSystem>.Instance.SetSwitch("footstep_variant", this.FootstepVariantMap[this.Variant], owner);
		CharacterFootEffectComponent.EFootstepTexture footstepTexture = this.GetFootstepTexture();
		this.FootTraceElement.Dispose();
		string text2 = (this.FootstepEvent != null) ? Singleton<AudioSystem>.Instance.parseAudioEventPath(this.FootstepEvent) : null;
		if (text2 == null)
		{
			return false;
		}
		if (!SequenceUtils.CheckIfUseAudioSeq(owner))
		{
			return false;
		}
		Singleton<AudioSystem>.Instance.SetSwitch("footstep_texture", footstepTexture.ToEnumString(), owner);
		Singleton<AudioSystem>.Instance.PostEvent(text2.ToString(), akComponent2, null);
		return true;
	}

	// Token: 0x06005356 RID: 21334 RVA: 0x000C4020 File Offset: 0x000C2220
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06005357 RID: 21335 RVA: 0x000C409B File Offset: 0x000C229B
	protected override string GetNotifyName_Implementation()
	{
		return "SeqAnimNotifyFootstepAudioEvent";
	}

	// Token: 0x06005358 RID: 21336 RVA: 0x000C40A4 File Offset: 0x000C22A4
	public CharacterFootEffectComponent.EFootstepTexture GetFootstepTexture()
	{
		UTraceLineElement footTraceElement = this.FootTraceElement;
		UKuroHitResult ukuroHitResult = (footTraceElement != null) ? footTraceElement.HitResult : null;
		if (ukuroHitResult == null || !ukuroHitResult.IsValid())
		{
			return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		}
		bool flag = false;
		UPhysicalMaterial uphysicalMaterial = UKuroRenderingRuntimeBPPluginBPLibrary.GetComponentPhysicalMaterial(ukuroHitResult.Components.Get(0));
		if (uphysicalMaterial != null && uphysicalMaterial.IsValid() && uphysicalMaterial.GetName() == "WaterLightLand")
		{
			flag = true;
		}
		if (flag)
		{
			return this.CheckWaterSurfaceType(ukuroHitResult);
		}
		Vector vector = Vector.Create();
		Singleton<TraceElementCommon>.Instance.GetHitLocation(ukuroHitResult, 0, vector);
		CharacterFootEffectComponent.EFootstepTexture? efootstepTexture = null;
		FoliageAudioInfo foliageAudioInfo = Singleton<AudioUtils>.Instance.QueryFoliageAudioPhysicalMaterial(vector.ToUeVector(false), null);
		if (foliageAudioInfo.IsHitFoliage && foliageAudioInfo.PhysicalMaterial != null)
		{
			uphysicalMaterial = foliageAudioInfo.PhysicalMaterial;
		}
		if (uphysicalMaterial != null && uphysicalMaterial.IsValid())
		{
			if (uphysicalMaterial.SurfaceType == EPhysicalSurface.SurfaceType6 || uphysicalMaterial.SurfaceType == EPhysicalSurface.SurfaceType14)
			{
				efootstepTexture = new CharacterFootEffectComponent.EFootstepTexture?(CharacterFootEffectComponent.EFootstepTexture.DirtSurface);
			}
			else
			{
				efootstepTexture = new CharacterFootEffectComponent.EFootstepTexture?(CharacterFootEffectComponent_EFootstepTextureExtensions.FromString(UKuroAudioMaterialSettings.GetFootstepTextureName(uphysicalMaterial.SurfaceType).ToString()));
			}
		}
		if (efootstepTexture == null)
		{
			efootstepTexture = new CharacterFootEffectComponent.EFootstepTexture?(CharacterFootEffectComponent.EFootstepTexture.DirtSurface);
		}
		return efootstepTexture.Value;
	}

	// Token: 0x06005359 RID: 21337 RVA: 0x000C41E4 File Offset: 0x000C23E4
	[NullableContext(2)]
	private CharacterFootEffectComponent.EFootstepTexture CheckWaterSurfaceType(UKuroHitResult hitResult)
	{
		if (hitResult == null)
		{
			return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		}
		int hitCount = hitResult.GetHitCount();
		for (int i = 0; i < hitCount; i++)
		{
			if (UKuroCollisionLibrary.GetBodyInstance(hitResult, i).CollisionResponses.ResponseToChannels.GameTraceChannel2 == ECollisionResponse.ECR_Block)
			{
				return CharacterFootEffectComponent.EFootstepTexture.WaterSurface;
			}
		}
		return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
	}

	// Token: 0x0600535A RID: 21338 RVA: 0x000C422F File Offset: 0x000C242F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSeqAnimNotifyFootstepAudioEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyFootstepAudioEvent.TsSeqAnimNotifyFootstepAudioEvent_C");
		}
		return TsSeqAnimNotifyFootstepAudioEvent._ClassPtr;
	}

	// Token: 0x0600535B RID: 21339 RVA: 0x000C4254 File Offset: 0x000C2454
	public TsSeqAnimNotifyFootstepAudioEvent() : this(BuiltinUtils.AllocNativeUObject(TsSeqAnimNotifyFootstepAudioEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600535C RID: 21340 RVA: 0x000C427C File Offset: 0x000C247C
	public TsSeqAnimNotifyFootstepAudioEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSeqAnimNotifyFootstepAudioEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600535D RID: 21341 RVA: 0x000C42AF File Offset: 0x000C24AF
	protected TsSeqAnimNotifyFootstepAudioEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600535E RID: 21342 RVA: 0x000C42B8 File Offset: 0x000C24B8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600535F RID: 21343 RVA: 0x000C42EB File Offset: 0x000C24EB
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040018AF RID: 6319
	private const int MATERIAL_ID_WAT = 6;

	// Token: 0x040018B0 RID: 6320
	private const int MATERIAL_ID_SHR = 14;

	// Token: 0x040018B1 RID: 6321
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyFootstepAudioEvent.TsSeqAnimNotifyFootstepAudioEvent_C";

	// Token: 0x040018B2 RID: 6322
	private static IntPtr _ClassPtr;

	// Token: 0x040018B3 RID: 6323
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040018B4 RID: 6324
	private static int __PropertyOffset_Variant;

	// Token: 0x040018B5 RID: 6325
	private static int __PropertyOffset_FootstepEvent;

	// Token: 0x040018B6 RID: 6326
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAkAudioEvent> _FootstepEvent;

	// Token: 0x040018B7 RID: 6327
	private static int __PropertyOffset_FootTraceElement;

	// Token: 0x040018B8 RID: 6328
	private static int __PropertyOffset_FootstepVariantMap;

	// Token: 0x040018B9 RID: 6329
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TMap<E_FootstepVariant, string> _FootstepVariantMap;
}
