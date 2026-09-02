using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D3F RID: 3391
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDetectSphere.TsAnimNotifyStateDetectSphere_C")]
public class TsAnimNotifyStateDetectSphere : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600471F RID: 18207 RVA: 0x00093493 File Offset: 0x00091693
	static TsAnimNotifyStateDetectSphere()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateDetectSphere.CreateStaticDefaultValue), new Action(TsAnimNotifyStateDetectSphere.ResetStaticDefaultValue));
	}

	// Token: 0x06004720 RID: 18208 RVA: 0x000934B2 File Offset: 0x000916B2
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateDetectSphere.detectStateMap = new Dictionary<int, DetectStateSphere>();
	}

	// Token: 0x06004721 RID: 18209 RVA: 0x000934BE File Offset: 0x000916BE
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateDetectSphere.detectStateMap = null;
	}

	// Token: 0x170003B6 RID: 950
	// (get) Token: 0x06004722 RID: 18210 RVA: 0x000934C6 File Offset: 0x000916C6
	// (set) Token: 0x06004723 RID: 18211 RVA: 0x000934D6 File Offset: 0x000916D6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Radius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_Radius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_Radius) = value;
		}
	}

	// Token: 0x170003B7 RID: 951
	// (get) Token: 0x06004724 RID: 18212 RVA: 0x000934E7 File Offset: 0x000916E7
	// (set) Token: 0x06004725 RID: 18213 RVA: 0x000934F7 File Offset: 0x000916F7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OffsetX
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_OffsetX);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_OffsetX) = value;
		}
	}

	// Token: 0x170003B8 RID: 952
	// (get) Token: 0x06004726 RID: 18214 RVA: 0x00093508 File Offset: 0x00091708
	// (set) Token: 0x06004727 RID: 18215 RVA: 0x00093518 File Offset: 0x00091718
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OffsetY
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_OffsetY);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_OffsetY) = value;
		}
	}

	// Token: 0x170003B9 RID: 953
	// (get) Token: 0x06004728 RID: 18216 RVA: 0x00093529 File Offset: 0x00091729
	// (set) Token: 0x06004729 RID: 18217 RVA: 0x00093539 File Offset: 0x00091739
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OffsetZ
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_OffsetZ);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_OffsetZ) = value;
		}
	}

	// Token: 0x170003BA RID: 954
	// (get) Token: 0x0600472A RID: 18218 RVA: 0x0009354C File Offset: 0x0009174C
	// (set) Token: 0x0600472B RID: 18219 RVA: 0x00093585 File Offset: 0x00091785
	[Nullable(new byte[]
	{
		1,
		0
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<TEnumAsByte<EObjectTypeQuery>> ObjectTypes
	{
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		get
		{
			base.FastCheckIsValid();
			TArray<TEnumAsByte<EObjectTypeQuery>> result;
			if ((result = this._ObjectTypes) == null)
			{
				result = (this._ObjectTypes = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_ObjectTypes, this));
			}
			return result;
		}
		[param: Nullable(new byte[]
		{
			1,
			0
		})]
		set
		{
			this.ObjectTypes.CopyAssign(value);
		}
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x0600472C RID: 18220 RVA: 0x00093593 File Offset: 0x00091793
	// (set) Token: 0x0600472D RID: 18221 RVA: 0x000935A7 File Offset: 0x000917A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag TagOnHit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_TagOnHit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_TagOnHit) = value;
		}
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x0600472E RID: 18222 RVA: 0x000935BC File Offset: 0x000917BC
	// (set) Token: 0x0600472F RID: 18223 RVA: 0x000935CC File Offset: 0x000917CC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SendGamePlayEvent
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_SendGamePlayEvent) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_SendGamePlayEvent) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003BD RID: 957
	// (get) Token: 0x06004730 RID: 18224 RVA: 0x000935DD File Offset: 0x000917DD
	// (set) Token: 0x06004731 RID: 18225 RVA: 0x000935ED File Offset: 0x000917ED
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_DebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectSphere.__PropertyOffset_DebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004732 RID: 18226 RVA: 0x00093600 File Offset: 0x00091800
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004733 RID: 18227 RVA: 0x000936A8 File Offset: 0x000918A8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter && (owner as TsBaseCharacter).CharacterActorComponent != null)
		{
			int entityIdNoBlueprint = (owner as TsBaseCharacter).GetEntityIdNoBlueprint();
			DetectStateSphere detectStateSphere;
			if (!TsAnimNotifyStateDetectSphere.detectStateMap.TryGetValue(entityIdNoBlueprint, out detectStateSphere))
			{
				detectStateSphere = new DetectStateSphere(new UTraceSphereElement());
				TsAnimNotifyStateDetectSphere.detectStateMap[entityIdNoBlueprint] = detectStateSphere;
			}
			detectStateSphere.LastFramePosition.FromUeVector((owner as TsBaseCharacter).CharacterActorComponent.ActorLocationProxy);
			detectStateSphere.SphereElement.WorldContextObject = owner.GetWorld();
			TArray<TEnumAsByte<EObjectTypeQuery>> objectTypes = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			detectStateSphere.SphereElement.SetObjectTypesQuery(ref objectTypes);
			this.ObjectTypes = objectTypes;
			detectStateSphere.SphereElement.Radius = this.Radius;
			detectStateSphere.SphereElement.bIsSingle = true;
			if (this.DebugDraw)
			{
				detectStateSphere.SphereElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
				detectStateSphere.SphereElement.DrawTime = 1f;
			}
			detectStateSphere.Offset.Set((double)this.OffsetX, (double)this.OffsetY, (double)this.OffsetZ);
		}
		return true;
	}

	// Token: 0x06004734 RID: 18228 RVA: 0x000937B4 File Offset: 0x000919B4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004735 RID: 18229 RVA: 0x0009385C File Offset: 0x00091A5C
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null && tsBaseCharacter.CharacterActorComponent != null)
		{
			DetectStateSphere valueOrDefault = TsAnimNotifyStateDetectSphere.detectStateMap.GetValueOrDefault(tsBaseCharacter.GetEntityIdNoBlueprint());
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			if (valueOrDefault == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AnimNotify;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "获取不到状态";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Owner", characterActorComponent.Owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("蒙太奇路径", UKismetSystemLibrary.GetPathName(animation));
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			valueOrDefault.SphereElement.SetStartLocation(valueOrDefault.LastFramePosition.X, valueOrDefault.LastFramePosition.Y, valueOrDefault.LastFramePosition.Z);
			Singleton<MathUtils>.Instance.TransformPosition(characterActorComponent.ActorLocationProxy, characterActorComponent.ActorRotationProxy, characterActorComponent.ActorScaleProxy, valueOrDefault.Offset, valueOrDefault.CurrentPosition);
			valueOrDefault.SphereElement.SetEndLocation(valueOrDefault.CurrentPosition.X, valueOrDefault.CurrentPosition.Y, valueOrDefault.CurrentPosition.Z);
			valueOrDefault.LastFramePosition.FromUeVector(valueOrDefault.CurrentPosition);
			if (Singleton<TraceElementCommon>.Instance.SphereTrace(valueOrDefault.SphereElement, "ANS_DetectSphere"))
			{
				if (this.SendGamePlayEvent)
				{
					BaseAbilityComponent component = characterActorComponent.Entity.GetComponent<BaseAbilityComponent>();
					if (component == null)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.AnimNotify;
						ELogAuthor author2 = ELogAuthor.HCW;
						string message2 = "使用DetectSphereANS的角色没有AbilityComponent";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Owner", characterActorComponent.Owner);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("蒙太奇路径", UKismetSystemLibrary.GetPathName(animation));
						instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						return false;
					}
					component.SendGameplayEventToActor(this.TagOnHit, null);
				}
				else
				{
					BaseTagComponent component2 = characterActorComponent.Entity.GetComponent<BaseTagComponent>();
					if (component2 == null)
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.AnimNotify;
						ELogAuthor author3 = ELogAuthor.HCW;
						string message3 = "使用DetectSphereANS的角色没有BaseTagComponent";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Owner", characterActorComponent.Owner);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("蒙太奇路径", UKismetSystemLibrary.GetPathName(animation));
						instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
						return false;
					}
					component2.AddTag(new int?(this.TagOnHit.TagId()));
				}
			}
		}
		return true;
	}

	// Token: 0x06004736 RID: 18230 RVA: 0x00093AE4 File Offset: 0x00091CE4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
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

	// Token: 0x06004737 RID: 18231 RVA: 0x00093B84 File Offset: 0x00091D84
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null || tsBaseCharacter.CharacterActorComponent == null)
		{
			return true;
		}
		int entityIdNoBlueprint = tsBaseCharacter.GetEntityIdNoBlueprint();
		DetectStateSphere valueOrDefault = TsAnimNotifyStateDetectSphere.detectStateMap.GetValueOrDefault(entityIdNoBlueprint);
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (valueOrDefault == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AnimNotify;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "获取不到状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Owner", characterActorComponent.Owner);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("蒙太奇路径", UKismetSystemLibrary.GetPathName(animation));
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		valueOrDefault.SphereElement.Dispose();
		TsAnimNotifyStateDetectSphere.detectStateMap.Remove(entityIdNoBlueprint);
		if (characterActorComponent != null && !this.SendGamePlayEvent)
		{
			BaseTagComponent component = characterActorComponent.Entity.GetComponent<BaseTagComponent>();
			if (component == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.AnimNotify;
				ELogAuthor author2 = ELogAuthor.HCW;
				string message2 = "使用DetectSphereANS的角色没有BaseTagComponent";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Owner", characterActorComponent.Owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("蒙太奇路径", UKismetSystemLibrary.GetPathName(animation));
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			component.RemoveTag(new int?(this.TagOnHit.TagId()));
		}
		return true;
	}

	// Token: 0x06004738 RID: 18232 RVA: 0x00093CE0 File Offset: 0x00091EE0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004739 RID: 18233 RVA: 0x00093D5B File Offset: 0x00091F5B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "球形检测碰撞";
	}

	// Token: 0x0600473A RID: 18234 RVA: 0x00093D62 File Offset: 0x00091F62
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateDetectSphere._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDetectSphere.TsAnimNotifyStateDetectSphere_C");
		}
		return TsAnimNotifyStateDetectSphere._ClassPtr;
	}

	// Token: 0x0600473B RID: 18235 RVA: 0x00093D88 File Offset: 0x00091F88
	public TsAnimNotifyStateDetectSphere() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateDetectSphere.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600473C RID: 18236 RVA: 0x00093DB0 File Offset: 0x00091FB0
	[NullableContext(1)]
	public TsAnimNotifyStateDetectSphere(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateDetectSphere.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600473D RID: 18237 RVA: 0x00093DE3 File Offset: 0x00091FE3
	protected TsAnimNotifyStateDetectSphere(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600473E RID: 18238 RVA: 0x00093DEC File Offset: 0x00091FEC
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600473F RID: 18239 RVA: 0x00093E28 File Offset: 0x00092028
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004740 RID: 18240 RVA: 0x00093E64 File Offset: 0x00092064
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004741 RID: 18241 RVA: 0x00093E97 File Offset: 0x00092097
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001392 RID: 5010
	[Nullable(1)]
	private static Dictionary<int, DetectStateSphere> detectStateMap;

	// Token: 0x04001393 RID: 5011
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDetectSphere.TsAnimNotifyStateDetectSphere_C";

	// Token: 0x04001394 RID: 5012
	private static IntPtr _ClassPtr;

	// Token: 0x04001395 RID: 5013
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001396 RID: 5014
	private static int __PropertyOffset_Radius;

	// Token: 0x04001397 RID: 5015
	private static int __PropertyOffset_OffsetX;

	// Token: 0x04001398 RID: 5016
	private static int __PropertyOffset_OffsetY;

	// Token: 0x04001399 RID: 5017
	private static int __PropertyOffset_OffsetZ;

	// Token: 0x0400139A RID: 5018
	private static int __PropertyOffset_ObjectTypes;

	// Token: 0x0400139B RID: 5019
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private TArray<TEnumAsByte<EObjectTypeQuery>> _ObjectTypes;

	// Token: 0x0400139C RID: 5020
	private static int __PropertyOffset_TagOnHit;

	// Token: 0x0400139D RID: 5021
	private static int __PropertyOffset_SendGamePlayEvent;

	// Token: 0x0400139E RID: 5022
	private static int __PropertyOffset_DebugDraw;
}
