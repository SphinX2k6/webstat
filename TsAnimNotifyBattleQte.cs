using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DAA RID: 3498
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleQte.TsAnimNotifyBattleQte_C")]
public class TsAnimNotifyBattleQte : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004E9 RID: 1257
	// (get) Token: 0x06004EB4 RID: 20148 RVA: 0x000B3FD7 File Offset: 0x000B21D7
	// (set) Token: 0x06004EB5 RID: 20149 RVA: 0x000B3FE7 File Offset: 0x000B21E7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int BattleQteId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBattleQte.__PropertyOffset_BattleQteId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBattleQte.__PropertyOffset_BattleQteId) = value;
		}
	}

	// Token: 0x170004EA RID: 1258
	// (get) Token: 0x06004EB6 RID: 20150 RVA: 0x000B3FF8 File Offset: 0x000B21F8
	// (set) Token: 0x06004EB7 RID: 20151 RVA: 0x000B4008 File Offset: 0x000B2208
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 当前实体为玩家控制时才触发
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBattleQte.__PropertyOffset_当前实体为玩家控制时才触发) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBattleQte.__PropertyOffset_当前实体为玩家控制时才触发) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004EB RID: 1259
	// (get) Token: 0x06004EB8 RID: 20152 RVA: 0x000B4019 File Offset: 0x000B2219
	// (set) Token: 0x06004EB9 RID: 20153 RVA: 0x000B402D File Offset: 0x000B222D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 存在Tag时才触发
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBattleQte.__PropertyOffset_存在Tag时才触发);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBattleQte.__PropertyOffset_存在Tag时才触发) = value;
		}
	}

	// Token: 0x06004EBA RID: 20154 RVA: 0x000B4044 File Offset: 0x000B2244
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

	// Token: 0x06004EBB RID: 20155 RVA: 0x000B40E4 File Offset: 0x000B22E4
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (this.当前实体为玩家控制时才触发)
		{
			if (characterActorComponent == null || !characterActorComponent.Valid)
			{
				return false;
			}
			if (!characterActorComponent.IsAutonomousProxy)
			{
				return false;
			}
		}
		FGameplayTag 存在Tag时才触发 = this.存在Tag时才触发;
		if (this.存在Tag时才触发.TagName != FName.NAME_None)
		{
			bool flag;
			if (entity == null)
			{
				flag = true;
			}
			else
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				flag = !((component != null) ? new bool?(component.HasTag(this.存在Tag时才触发.TagId())) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return false;
			}
		}
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetHandleByEntity(entity) : null;
		long? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			BaseBuffComponent component2 = entity.GetComponent<BaseBuffComponent>();
			num = ((component2 != null) ? component2.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null);
		}
		long? num2 = num;
		if (entityHandle != null && num2 != null)
		{
			ControllerBase<BattleQteController>.Instance.StartBattleQte(this.BattleQteId, num2.Value, entityHandle, EBattleQteSource.AnimNotify);
		}
		return true;
	}

	// Token: 0x06004EBC RID: 20156 RVA: 0x000B4214 File Offset: 0x000B2414
	[NullableContext(1)]
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

	// Token: 0x06004EBD RID: 20157 RVA: 0x000B428F File Offset: 0x000B248F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "战斗QTE";
	}

	// Token: 0x06004EBE RID: 20158 RVA: 0x000B4296 File Offset: 0x000B2496
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBattleQte._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleQte.TsAnimNotifyBattleQte_C");
		}
		return TsAnimNotifyBattleQte._ClassPtr;
	}

	// Token: 0x06004EBF RID: 20159 RVA: 0x000B42BC File Offset: 0x000B24BC
	public TsAnimNotifyBattleQte() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBattleQte.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004EC0 RID: 20160 RVA: 0x000B42E4 File Offset: 0x000B24E4
	[NullableContext(1)]
	public TsAnimNotifyBattleQte(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBattleQte.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004EC1 RID: 20161 RVA: 0x000B4317 File Offset: 0x000B2517
	protected TsAnimNotifyBattleQte(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004EC2 RID: 20162 RVA: 0x000B4320 File Offset: 0x000B2520
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004EC3 RID: 20163 RVA: 0x000B4353 File Offset: 0x000B2553
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016DA RID: 5850
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleQte.TsAnimNotifyBattleQte_C";

	// Token: 0x040016DB RID: 5851
	private static IntPtr _ClassPtr;

	// Token: 0x040016DC RID: 5852
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016DD RID: 5853
	private static int __PropertyOffset_BattleQteId;

	// Token: 0x040016DE RID: 5854
	private static int __PropertyOffset_当前实体为玩家控制时才触发;

	// Token: 0x040016DF RID: 5855
	private static int __PropertyOffset_存在Tag时才触发;
}
