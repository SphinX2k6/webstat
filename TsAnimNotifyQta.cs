using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuickTimeAction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DDC RID: 3548
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyQta.TsAnimNotifyQta_C")]
public class TsAnimNotifyQta : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000545 RID: 1349
	// (get) Token: 0x06005158 RID: 20824 RVA: 0x000BCED3 File Offset: 0x000BB0D3
	// (set) Token: 0x06005159 RID: 20825 RVA: 0x000BCEE3 File Offset: 0x000BB0E3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int QtaId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_QtaId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_QtaId) = value;
		}
	}

	// Token: 0x17000546 RID: 1350
	// (get) Token: 0x0600515A RID: 20826 RVA: 0x000BCEF4 File Offset: 0x000BB0F4
	// (set) Token: 0x0600515B RID: 20827 RVA: 0x000BCF04 File Offset: 0x000BB104
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 当前实体为玩家控制时才触发
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_当前实体为玩家控制时才触发) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_当前实体为玩家控制时才触发) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000547 RID: 1351
	// (get) Token: 0x0600515C RID: 20828 RVA: 0x000BCF15 File Offset: 0x000BB115
	// (set) Token: 0x0600515D RID: 20829 RVA: 0x000BCF29 File Offset: 0x000BB129
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 存在Tag时才触发
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_存在Tag时才触发);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_存在Tag时才触发) = value;
		}
	}

	// Token: 0x17000548 RID: 1352
	// (get) Token: 0x0600515E RID: 20830 RVA: 0x000BCF3E File Offset: 0x000BB13E
	// (set) Token: 0x0600515F RID: 20831 RVA: 0x000BCF4E File Offset: 0x000BB14E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 开始时直接结束其它Qta
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_开始时直接结束其它Qta) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyQta.__PropertyOffset_开始时直接结束其它Qta) = (value ? 1 : 0);
		}
	}

	// Token: 0x06005160 RID: 20832 RVA: 0x000BCF60 File Offset: 0x000BB160
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

	// Token: 0x06005161 RID: 20833 RVA: 0x000BD000 File Offset: 0x000BB200
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (this.当前实体为玩家控制时才触发 && (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(this.存在Tag时才触发.TagName.ToString()) && this.存在Tag时才触发.TagName != "None")
		{
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent == null || !baseTagComponent.HasTag(this.存在Tag时才触发.TagId()))
			{
				return false;
			}
		}
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity);
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long? num = (baseBuffComponent != null) ? baseBuffComponent.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		if (handleByEntity != null && num != null)
		{
			if (this.开始时直接结束其它Qta)
			{
				ControllerBase<QtaController>.Instance.StopCurrentQta();
			}
			ControllerBase<QtaController>.Instance.StartQta(this.QtaId, null, EQtaSource.AnimNotify, new IQtaExtraParams
			{
				MessageId = new long?(num.Value),
				EntityHandle = handleByEntity
			});
		}
		return true;
	}

	// Token: 0x06005162 RID: 20834 RVA: 0x000BD148 File Offset: 0x000BB348
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

	// Token: 0x06005163 RID: 20835 RVA: 0x000BD1C3 File Offset: 0x000BB3C3
	protected override string GetNotifyName_Implementation()
	{
		return "特殊交互QTA";
	}

	// Token: 0x06005164 RID: 20836 RVA: 0x000BD1CA File Offset: 0x000BB3CA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyQta._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyQta.TsAnimNotifyQta_C");
		}
		return TsAnimNotifyQta._ClassPtr;
	}

	// Token: 0x06005165 RID: 20837 RVA: 0x000BD1F0 File Offset: 0x000BB3F0
	public TsAnimNotifyQta() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyQta.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005166 RID: 20838 RVA: 0x000BD218 File Offset: 0x000BB418
	public TsAnimNotifyQta(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyQta.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005167 RID: 20839 RVA: 0x000BD24B File Offset: 0x000BB44B
	protected TsAnimNotifyQta(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005168 RID: 20840 RVA: 0x000BD254 File Offset: 0x000BB454
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005169 RID: 20841 RVA: 0x000BD287 File Offset: 0x000BB487
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017DB RID: 6107
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyQta.TsAnimNotifyQta_C";

	// Token: 0x040017DC RID: 6108
	private static IntPtr _ClassPtr;

	// Token: 0x040017DD RID: 6109
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017DE RID: 6110
	private static int __PropertyOffset_QtaId;

	// Token: 0x040017DF RID: 6111
	private static int __PropertyOffset_当前实体为玩家控制时才触发;

	// Token: 0x040017E0 RID: 6112
	private static int __PropertyOffset_存在Tag时才触发;

	// Token: 0x040017E1 RID: 6113
	private static int __PropertyOffset_开始时直接结束其它Qta;
}
