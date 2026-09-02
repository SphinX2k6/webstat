using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D20 RID: 3360
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddTag.TsAnimNotifyStateAddTag_C")]
public class TsAnimNotifyStateAddTag : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700033B RID: 827
	// (get) Token: 0x06004494 RID: 17556 RVA: 0x00086557 File Offset: 0x00084757
	// (set) Token: 0x06004495 RID: 17557 RVA: 0x0008656B File Offset: 0x0008476B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddTag.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddTag.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x1700033C RID: 828
	// (get) Token: 0x06004496 RID: 17558 RVA: 0x00086580 File Offset: 0x00084780
	// (set) Token: 0x06004497 RID: 17559 RVA: 0x00086590 File Offset: 0x00084790
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 给召唤者添加
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddTag.__PropertyOffset_给召唤者添加) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddTag.__PropertyOffset_给召唤者添加) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004498 RID: 17560 RVA: 0x000865A4 File Offset: 0x000847A4
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

	// Token: 0x06004499 RID: 17561 RVA: 0x0008664C File Offset: 0x0008484C
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (meshComp == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		int num = this.Tag.TagId();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null && num != 0)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (this.给召唤者添加)
			{
				long? num2;
				if (entity == null)
				{
					num2 = null;
				}
				else
				{
					CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
					num2 = ((component != null) ? new long?(component.GetSummonerId()) : null);
				}
				long? num3 = num2;
				long valueOrDefault = num3.GetValueOrDefault();
				EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(valueOrDefault);
				entity = ((entity2 != null) ? entity2.Entity : null);
			}
			if (entity != null)
			{
				BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
				if (component2 != null)
				{
					component2.TagContainer.UpdateExactTag(ETagChannel.Anim, num, 1);
					return true;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "No Entity for TsBaseCharacter";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		else if (num != 0)
		{
			TsUiSceneRoleActor tsUiSceneRoleActor = owner as TsUiSceneRoleActor;
			if (tsUiSceneRoleActor != null)
			{
				this.UiTagAnsContext = new UiTagAnsContext(num);
				UiModelBase model = tsUiSceneRoleActor.Model;
				if (model != null)
				{
					model.CheckGetComponent<UiModelAnsControllerComponent>().AddAns<UiTagAnsContext>("UiTagAnsContext", this.UiTagAnsContext);
				}
			}
		}
		return false;
	}

	// Token: 0x0600449A RID: 17562 RVA: 0x000867B8 File Offset: 0x000849B8
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

	// Token: 0x0600449B RID: 17563 RVA: 0x00086858 File Offset: 0x00084A58
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		int num = this.Tag.TagId();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null && num != 0)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (this.给召唤者添加)
			{
				long? num2;
				if (entity == null)
				{
					num2 = null;
				}
				else
				{
					CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
					num2 = ((component != null) ? new long?(component.GetSummonerId()) : null);
				}
				long? num3 = num2;
				long valueOrDefault = num3.GetValueOrDefault();
				EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(valueOrDefault);
				entity = ((entity2 != null) ? entity2.Entity : null);
			}
			if (entity != null)
			{
				BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
				if (component2 != null)
				{
					component2.TagContainer.UpdateExactTag(ETagChannel.Anim, num, -1);
					return true;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "No Entity for TsBaseCharacter";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		else if (this.UiTagAnsContext != null)
		{
			TsUiSceneRoleActor tsUiSceneRoleActor = owner as TsUiSceneRoleActor;
			if (tsUiSceneRoleActor != null)
			{
				UiModelBase model = tsUiSceneRoleActor.Model;
				if (model != null)
				{
					model.CheckGetComponent<UiModelAnsControllerComponent>().ReduceAns<UiTagAnsContext>("UiTagAnsContext", this.UiTagAnsContext);
				}
			}
		}
		return false;
	}

	// Token: 0x0600449C RID: 17564 RVA: 0x000869BC File Offset: 0x00084BBC
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

	// Token: 0x0600449D RID: 17565 RVA: 0x00086A37 File Offset: 0x00084C37
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "添加TAG";
	}

	// Token: 0x0600449E RID: 17566 RVA: 0x00086A3E File Offset: 0x00084C3E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAddTag._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddTag.TsAnimNotifyStateAddTag_C");
		}
		return TsAnimNotifyStateAddTag._ClassPtr;
	}

	// Token: 0x0600449F RID: 17567 RVA: 0x00086A64 File Offset: 0x00084C64
	public TsAnimNotifyStateAddTag() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddTag.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060044A0 RID: 17568 RVA: 0x00086A8C File Offset: 0x00084C8C
	[NullableContext(1)]
	public TsAnimNotifyStateAddTag(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060044A1 RID: 17569 RVA: 0x00086ABF File Offset: 0x00084CBF
	protected TsAnimNotifyStateAddTag(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060044A2 RID: 17570 RVA: 0x00086AC8 File Offset: 0x00084CC8
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060044A3 RID: 17571 RVA: 0x00086B04 File Offset: 0x00084D04
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060044A4 RID: 17572 RVA: 0x00086B37 File Offset: 0x00084D37
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400122E RID: 4654
	[Nullable(2)]
	private UiTagAnsContext UiTagAnsContext;

	// Token: 0x0400122F RID: 4655
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddTag.TsAnimNotifyStateAddTag_C";

	// Token: 0x04001230 RID: 4656
	private static IntPtr _ClassPtr;

	// Token: 0x04001231 RID: 4657
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001232 RID: 4658
	private static int __PropertyOffset_Tag;

	// Token: 0x04001233 RID: 4659
	private static int __PropertyOffset_给召唤者添加;
}
