using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D3D RID: 3389
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDetectBox.TsAnimNotifyStateDetectBox_C")]
public class TsAnimNotifyStateDetectBox : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060046F7 RID: 18167 RVA: 0x000929CB File Offset: 0x00090BCB
	static TsAnimNotifyStateDetectBox()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateDetectBox.CreateStaticDefaultValue), new Action(TsAnimNotifyStateDetectBox.ResetStaticDefaultValue));
	}

	// Token: 0x060046F8 RID: 18168 RVA: 0x000929EA File Offset: 0x00090BEA
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateDetectBox.detectStateMap = new Dictionary<int, DetectStateBox>();
	}

	// Token: 0x060046F9 RID: 18169 RVA: 0x000929F6 File Offset: 0x00090BF6
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateDetectBox.detectStateMap = null;
	}

	// Token: 0x170003AC RID: 940
	// (get) Token: 0x060046FA RID: 18170 RVA: 0x000929FE File Offset: 0x00090BFE
	// (set) Token: 0x060046FB RID: 18171 RVA: 0x00092A0E File Offset: 0x00090C0E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BoxHalfSizeX
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_BoxHalfSizeX);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_BoxHalfSizeX) = value;
		}
	}

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x060046FC RID: 18172 RVA: 0x00092A1F File Offset: 0x00090C1F
	// (set) Token: 0x060046FD RID: 18173 RVA: 0x00092A2F File Offset: 0x00090C2F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BoxHalfSizeY
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_BoxHalfSizeY);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_BoxHalfSizeY) = value;
		}
	}

	// Token: 0x170003AE RID: 942
	// (get) Token: 0x060046FE RID: 18174 RVA: 0x00092A40 File Offset: 0x00090C40
	// (set) Token: 0x060046FF RID: 18175 RVA: 0x00092A50 File Offset: 0x00090C50
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BoxHalfSizeZ
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_BoxHalfSizeZ);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_BoxHalfSizeZ) = value;
		}
	}

	// Token: 0x170003AF RID: 943
	// (get) Token: 0x06004700 RID: 18176 RVA: 0x00092A61 File Offset: 0x00090C61
	// (set) Token: 0x06004701 RID: 18177 RVA: 0x00092A71 File Offset: 0x00090C71
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OffsetX
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_OffsetX);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_OffsetX) = value;
		}
	}

	// Token: 0x170003B0 RID: 944
	// (get) Token: 0x06004702 RID: 18178 RVA: 0x00092A82 File Offset: 0x00090C82
	// (set) Token: 0x06004703 RID: 18179 RVA: 0x00092A92 File Offset: 0x00090C92
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OffsetY
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_OffsetY);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_OffsetY) = value;
		}
	}

	// Token: 0x170003B1 RID: 945
	// (get) Token: 0x06004704 RID: 18180 RVA: 0x00092AA3 File Offset: 0x00090CA3
	// (set) Token: 0x06004705 RID: 18181 RVA: 0x00092AB3 File Offset: 0x00090CB3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OffsetZ
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_OffsetZ);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_OffsetZ) = value;
		}
	}

	// Token: 0x170003B2 RID: 946
	// (get) Token: 0x06004706 RID: 18182 RVA: 0x00092AC4 File Offset: 0x00090CC4
	// (set) Token: 0x06004707 RID: 18183 RVA: 0x00092AFD File Offset: 0x00090CFD
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
				result = (this._ObjectTypes = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_ObjectTypes, this));
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

	// Token: 0x170003B3 RID: 947
	// (get) Token: 0x06004708 RID: 18184 RVA: 0x00092B0B File Offset: 0x00090D0B
	// (set) Token: 0x06004709 RID: 18185 RVA: 0x00092B1F File Offset: 0x00090D1F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag TagOnHit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_TagOnHit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_TagOnHit) = value;
		}
	}

	// Token: 0x170003B4 RID: 948
	// (get) Token: 0x0600470A RID: 18186 RVA: 0x00092B34 File Offset: 0x00090D34
	// (set) Token: 0x0600470B RID: 18187 RVA: 0x00092B44 File Offset: 0x00090D44
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SendGamePlayEvent
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_SendGamePlayEvent) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_SendGamePlayEvent) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003B5 RID: 949
	// (get) Token: 0x0600470C RID: 18188 RVA: 0x00092B55 File Offset: 0x00090D55
	// (set) Token: 0x0600470D RID: 18189 RVA: 0x00092B65 File Offset: 0x00090D65
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_DebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateDetectBox.__PropertyOffset_DebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600470E RID: 18190 RVA: 0x00092B78 File Offset: 0x00090D78
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

	// Token: 0x0600470F RID: 18191 RVA: 0x00092BF3 File Offset: 0x00090DF3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "盒体检测碰撞";
	}

	// Token: 0x06004710 RID: 18192 RVA: 0x00092BFC File Offset: 0x00090DFC
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

	// Token: 0x06004711 RID: 18193 RVA: 0x00092CA4 File Offset: 0x00090EA4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter && (owner as TsBaseCharacter).CharacterActorComponent != null)
		{
			int entityIdNoBlueprint = (owner as TsBaseCharacter).GetEntityIdNoBlueprint();
			DetectStateBox detectStateBox;
			if (!TsAnimNotifyStateDetectBox.detectStateMap.TryGetValue(entityIdNoBlueprint, out detectStateBox))
			{
				detectStateBox = new DetectStateBox(new UTraceBoxElement());
				TsAnimNotifyStateDetectBox.detectStateMap[entityIdNoBlueprint] = detectStateBox;
			}
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			detectStateBox.LastFramePosition.FromUeVector(characterActorComponent.ActorLocationProxy);
			detectStateBox.BoxElement.WorldContextObject = owner.GetWorld();
			TArray<TEnumAsByte<EObjectTypeQuery>> objectTypes = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			detectStateBox.BoxElement.SetObjectTypesQuery(ref objectTypes);
			this.ObjectTypes = objectTypes;
			detectStateBox.BoxElement.SetBoxHalfSize(this.BoxHalfSizeX, this.BoxHalfSizeY, this.BoxHalfSizeZ);
			if (this.DebugDraw)
			{
				detectStateBox.BoxElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
				detectStateBox.BoxElement.DrawTime = 1f;
			}
			detectStateBox.BoxElement.bIsSingle = true;
			detectStateBox.Offset.Set((double)this.OffsetX, (double)this.OffsetY, (double)this.OffsetZ);
		}
		return true;
	}

	// Token: 0x06004712 RID: 18194 RVA: 0x00092DC0 File Offset: 0x00090FC0
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

	// Token: 0x06004713 RID: 18195 RVA: 0x00092E68 File Offset: 0x00091068
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null && tsBaseCharacter.CharacterActorComponent != null)
		{
			DetectStateBox valueOrDefault = TsAnimNotifyStateDetectBox.detectStateMap.GetValueOrDefault(tsBaseCharacter.GetEntityIdNoBlueprint());
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
			valueOrDefault.BoxElement.SetBoxOrientation(characterActorComponent.ActorRotationProxy.Pitch, characterActorComponent.ActorRotationProxy.Yaw, characterActorComponent.ActorRotationProxy.Roll);
			valueOrDefault.BoxElement.SetStartLocation(valueOrDefault.LastFramePosition.X, valueOrDefault.LastFramePosition.Y, valueOrDefault.LastFramePosition.Z);
			Singleton<MathUtils>.Instance.TransformPosition(characterActorComponent.ActorLocationProxy, characterActorComponent.ActorRotationProxy, characterActorComponent.ActorScaleProxy, valueOrDefault.Offset, valueOrDefault.CurrentPosition);
			valueOrDefault.BoxElement.SetEndLocation(valueOrDefault.CurrentPosition.X, valueOrDefault.CurrentPosition.Y, valueOrDefault.CurrentPosition.Z);
			valueOrDefault.LastFramePosition.FromUeVector(valueOrDefault.CurrentPosition);
			if (Singleton<TraceElementCommon>.Instance.BoxTrace(valueOrDefault.BoxElement, "ANS_DetectBox"))
			{
				if (this.SendGamePlayEvent)
				{
					BaseAbilityComponent component = characterActorComponent.Entity.GetComponent<BaseAbilityComponent>();
					if (component == null)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.AnimNotify;
						ELogAuthor author2 = ELogAuthor.HCW;
						string message2 = "使用DetectBoxANS的角色没有AbilityComponent";
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
						string message3 = "使用DetectBoxANS的角色没有BaseTagComponent";
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

	// Token: 0x06004714 RID: 18196 RVA: 0x00093120 File Offset: 0x00091320
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

	// Token: 0x06004715 RID: 18197 RVA: 0x000931C0 File Offset: 0x000913C0
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null || tsBaseCharacter.CharacterActorComponent == null)
		{
			return true;
		}
		int entityIdNoBlueprint = tsBaseCharacter.GetEntityIdNoBlueprint();
		DetectStateBox valueOrDefault = TsAnimNotifyStateDetectBox.detectStateMap.GetValueOrDefault(entityIdNoBlueprint);
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
		valueOrDefault.BoxElement.Dispose();
		TsAnimNotifyStateDetectBox.detectStateMap.Remove(entityIdNoBlueprint);
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

	// Token: 0x06004716 RID: 18198 RVA: 0x00093319 File Offset: 0x00091519
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateDetectBox._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDetectBox.TsAnimNotifyStateDetectBox_C");
		}
		return TsAnimNotifyStateDetectBox._ClassPtr;
	}

	// Token: 0x06004717 RID: 18199 RVA: 0x00093340 File Offset: 0x00091540
	public TsAnimNotifyStateDetectBox() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateDetectBox.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004718 RID: 18200 RVA: 0x00093368 File Offset: 0x00091568
	[NullableContext(1)]
	public TsAnimNotifyStateDetectBox(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateDetectBox.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004719 RID: 18201 RVA: 0x0009339B File Offset: 0x0009159B
	protected TsAnimNotifyStateDetectBox(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600471A RID: 18202 RVA: 0x000933A4 File Offset: 0x000915A4
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0600471B RID: 18203 RVA: 0x000933B8 File Offset: 0x000915B8
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600471C RID: 18204 RVA: 0x000933F4 File Offset: 0x000915F4
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x0600471D RID: 18205 RVA: 0x00093430 File Offset: 0x00091630
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400137F RID: 4991
	[Nullable(1)]
	private static Dictionary<int, DetectStateBox> detectStateMap;

	// Token: 0x04001380 RID: 4992
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateDetectBox.TsAnimNotifyStateDetectBox_C";

	// Token: 0x04001381 RID: 4993
	private static IntPtr _ClassPtr;

	// Token: 0x04001382 RID: 4994
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001383 RID: 4995
	private static int __PropertyOffset_BoxHalfSizeX;

	// Token: 0x04001384 RID: 4996
	private static int __PropertyOffset_BoxHalfSizeY;

	// Token: 0x04001385 RID: 4997
	private static int __PropertyOffset_BoxHalfSizeZ;

	// Token: 0x04001386 RID: 4998
	private static int __PropertyOffset_OffsetX;

	// Token: 0x04001387 RID: 4999
	private static int __PropertyOffset_OffsetY;

	// Token: 0x04001388 RID: 5000
	private static int __PropertyOffset_OffsetZ;

	// Token: 0x04001389 RID: 5001
	private static int __PropertyOffset_ObjectTypes;

	// Token: 0x0400138A RID: 5002
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private TArray<TEnumAsByte<EObjectTypeQuery>> _ObjectTypes;

	// Token: 0x0400138B RID: 5003
	private static int __PropertyOffset_TagOnHit;

	// Token: 0x0400138C RID: 5004
	private static int __PropertyOffset_SendGamePlayEvent;

	// Token: 0x0400138D RID: 5005
	private static int __PropertyOffset_DebugDraw;
}
