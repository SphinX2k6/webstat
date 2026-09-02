using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D1B RID: 3355
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddGameplayCue.TsAnimNotifyStateAddGameplayCue_C")]
public class TsAnimNotifyStateAddGameplayCue : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004444 RID: 17476 RVA: 0x00084D23 File Offset: 0x00082F23
	static TsAnimNotifyStateAddGameplayCue()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateAddGameplayCue.CreateStaticDefaultValue), new Action(TsAnimNotifyStateAddGameplayCue.ResetStaticDefaultValue));
	}

	// Token: 0x06004445 RID: 17477 RVA: 0x00084D42 File Offset: 0x00082F42
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateAddGameplayCue.entityCueMap = new Dictionary<int, Dictionary<long, int>>();
	}

	// Token: 0x06004446 RID: 17478 RVA: 0x00084D4E File Offset: 0x00082F4E
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateAddGameplayCue.entityCueMap = null;
	}

	// Token: 0x17000331 RID: 817
	// (get) Token: 0x06004447 RID: 17479 RVA: 0x00084D58 File Offset: 0x00082F58
	// (set) Token: 0x06004448 RID: 17480 RVA: 0x00084D91 File Offset: 0x00082F91
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<long> Buff特效Id列表
	{
		get
		{
			base.FastCheckIsValid();
			TArray<long> result;
			if ((result = this._Buff特效Id列表) == null)
			{
				result = (this._Buff特效Id列表 = new TArray<long>(base.NativePtr + (IntPtr)TsAnimNotifyStateAddGameplayCue.__PropertyOffset_Buff特效Id列表, this));
			}
			return result;
		}
		set
		{
			this.Buff特效Id列表.CopyAssign(value);
		}
	}

	// Token: 0x06004449 RID: 17481 RVA: 0x00084DA0 File Offset: 0x00082FA0
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

	// Token: 0x0600444A RID: 17482 RVA: 0x00084E48 File Offset: 0x00083048
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		CharacterActorComponent characterActorComponent = (tsBaseCharacter != null) ? tsBaseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		Entity entity = characterActorComponent.Entity;
		CharacterGameplayCueComponent characterGameplayCueComponent = (entity != null) ? entity.GetComponent<CharacterGameplayCueComponent>() : null;
		if (characterGameplayCueComponent == null)
		{
			return false;
		}
		if (this.Buff特效Id列表 != null)
		{
			Dictionary<long, int> dictionary;
			if (!TsAnimNotifyStateAddGameplayCue.entityCueMap.TryGetValue(entity.Id, out dictionary))
			{
				dictionary = new Dictionary<long, int>();
				TsAnimNotifyStateAddGameplayCue.entityCueMap.Add(entity.Id, dictionary);
			}
			for (int i = 0; i < this.Buff特效Id列表.Num(); i++)
			{
				long num = this.Buff特效Id列表.Get(i);
				int num2 = characterGameplayCueComponent.AddCue(num, null);
				if (num2 != 0)
				{
					int num3;
					if (dictionary.TryGetValue(num, out num3))
					{
						characterGameplayCueComponent.RemoveCueByHandle((long)num3);
					}
					dictionary[num] = num2;
				}
			}
		}
		return true;
	}

	// Token: 0x0600444B RID: 17483 RVA: 0x00084F30 File Offset: 0x00083130
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

	// Token: 0x0600444C RID: 17484 RVA: 0x00084FD0 File Offset: 0x000831D0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		CharacterActorComponent characterActorComponent = (tsBaseCharacter != null) ? tsBaseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		Entity entity = characterActorComponent.Entity;
		CharacterGameplayCueComponent characterGameplayCueComponent = (entity != null) ? entity.GetComponent<CharacterGameplayCueComponent>() : null;
		if (characterGameplayCueComponent == null)
		{
			return false;
		}
		Dictionary<long, int> dictionary;
		if (this.Buff特效Id列表 != null && TsAnimNotifyStateAddGameplayCue.entityCueMap.TryGetValue(entity.Id, out dictionary))
		{
			for (int i = 0; i < this.Buff特效Id列表.Num(); i++)
			{
				long key = this.Buff特效Id列表.Get(i);
				int num;
				if (dictionary.TryGetValue(key, out num))
				{
					characterGameplayCueComponent.RemoveCueByHandle((long)num);
					dictionary.Remove(key);
				}
			}
			if (dictionary.Count == 0)
			{
				TsAnimNotifyStateAddGameplayCue.entityCueMap.Remove(entity.Id);
			}
		}
		return true;
	}

	// Token: 0x0600444D RID: 17485 RVA: 0x000850A0 File Offset: 0x000832A0
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

	// Token: 0x0600444E RID: 17486 RVA: 0x0008511B File Offset: 0x0008331B
	protected override string GetNotifyName_Implementation()
	{
		return "播放Buff特效";
	}

	// Token: 0x0600444F RID: 17487 RVA: 0x00085122 File Offset: 0x00083322
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAddGameplayCue._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddGameplayCue.TsAnimNotifyStateAddGameplayCue_C");
		}
		return TsAnimNotifyStateAddGameplayCue._ClassPtr;
	}

	// Token: 0x06004450 RID: 17488 RVA: 0x00085148 File Offset: 0x00083348
	public TsAnimNotifyStateAddGameplayCue() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddGameplayCue.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004451 RID: 17489 RVA: 0x00085170 File Offset: 0x00083370
	public TsAnimNotifyStateAddGameplayCue(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddGameplayCue.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004452 RID: 17490 RVA: 0x000851A3 File Offset: 0x000833A3
	protected TsAnimNotifyStateAddGameplayCue(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004453 RID: 17491 RVA: 0x000851AC File Offset: 0x000833AC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004454 RID: 17492 RVA: 0x000851E8 File Offset: 0x000833E8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004455 RID: 17493 RVA: 0x0008521B File Offset: 0x0008341B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001207 RID: 4615
	private static Dictionary<int, Dictionary<long, int>> entityCueMap;

	// Token: 0x04001208 RID: 4616
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddGameplayCue.TsAnimNotifyStateAddGameplayCue_C";

	// Token: 0x04001209 RID: 4617
	private static IntPtr _ClassPtr;

	// Token: 0x0400120A RID: 4618
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400120B RID: 4619
	private static int __PropertyOffset_Buff特效Id列表;

	// Token: 0x0400120C RID: 4620
	[Nullable(2)]
	private TArray<long> _Buff特效Id列表;
}
