using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE2 RID: 3554
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyResetSkillTarget.TsAnimNotifyResetSkillTarget_C")]
public class TsAnimNotifyResetSkillTarget : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000552 RID: 1362
	// (get) Token: 0x060051AD RID: 20909 RVA: 0x000BDFF8 File Offset: 0x000BC1F8
	// (set) Token: 0x060051AE RID: 20910 RVA: 0x000BE031 File Offset: 0x000BC231
	[UProperty(EPropertyFlags.CPF_None)]
	public SSkillTarget 技能目标配置
	{
		get
		{
			base.FastCheckIsValid();
			SSkillTarget result;
			if ((result = this._技能目标配置) == null)
			{
				result = (this._技能目标配置 = new SSkillTarget(base.NativePtr + (IntPtr)TsAnimNotifyResetSkillTarget.__PropertyOffset_技能目标配置, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SSkillTarget.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyResetSkillTarget.__PropertyOffset_技能目标配置, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x060051AF RID: 20911 RVA: 0x000BE05C File Offset: 0x000BC25C
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

	// Token: 0x060051B0 RID: 20912 RVA: 0x000BE0FC File Offset: 0x000BC2FC
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterSkillComponent component = (owner as TsBaseCharacter).CharacterActorComponent.Entity.GetComponent<CharacterSkillComponent>();
		if (component == null)
		{
			return false;
		}
		component.LockOnTargetAndSetShow(this.技能目标配置, true);
		return true;
	}

	// Token: 0x060051B1 RID: 20913 RVA: 0x000BE144 File Offset: 0x000BC344
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

	// Token: 0x060051B2 RID: 20914 RVA: 0x000BE1BF File Offset: 0x000BC3BF
	protected override string GetNotifyName_Implementation()
	{
		return "重置技能目标";
	}

	// Token: 0x060051B3 RID: 20915 RVA: 0x000BE1C6 File Offset: 0x000BC3C6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyResetSkillTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyResetSkillTarget.TsAnimNotifyResetSkillTarget_C");
		}
		return TsAnimNotifyResetSkillTarget._ClassPtr;
	}

	// Token: 0x060051B4 RID: 20916 RVA: 0x000BE1EC File Offset: 0x000BC3EC
	public TsAnimNotifyResetSkillTarget() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyResetSkillTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060051B5 RID: 20917 RVA: 0x000BE214 File Offset: 0x000BC414
	public TsAnimNotifyResetSkillTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyResetSkillTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060051B6 RID: 20918 RVA: 0x000BE247 File Offset: 0x000BC447
	protected TsAnimNotifyResetSkillTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060051B7 RID: 20919 RVA: 0x000BE250 File Offset: 0x000BC450
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060051B8 RID: 20920 RVA: 0x000BE283 File Offset: 0x000BC483
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017FA RID: 6138
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyResetSkillTarget.TsAnimNotifyResetSkillTarget_C";

	// Token: 0x040017FB RID: 6139
	private static IntPtr _ClassPtr;

	// Token: 0x040017FC RID: 6140
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017FD RID: 6141
	private static int __PropertyOffset_技能目标配置;

	// Token: 0x040017FE RID: 6142
	[Nullable(2)]
	private SSkillTarget _技能目标配置;
}
