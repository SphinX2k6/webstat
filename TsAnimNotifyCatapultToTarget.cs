using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB6 RID: 3510
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCatapultToTarget.TsAnimNotifyCatapultToTarget_C")]
public class TsAnimNotifyCatapultToTarget : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000507 RID: 1287
	// (get) Token: 0x06004F67 RID: 20327 RVA: 0x000B648B File Offset: 0x000B468B
	// (set) Token: 0x06004F68 RID: 20328 RVA: 0x000B649F File Offset: 0x000B469F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector LocationOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCatapultToTarget.__PropertyOffset_LocationOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCatapultToTarget.__PropertyOffset_LocationOffset) = value;
		}
	}

	// Token: 0x17000508 RID: 1288
	// (get) Token: 0x06004F69 RID: 20329 RVA: 0x000B64B4 File Offset: 0x000B46B4
	// (set) Token: 0x06004F6A RID: 20330 RVA: 0x000B64C4 File Offset: 0x000B46C4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Time
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyCatapultToTarget.__PropertyOffset_Time);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyCatapultToTarget.__PropertyOffset_Time) = value;
		}
	}

	// Token: 0x06004F6B RID: 20331 RVA: 0x000B64D8 File Offset: 0x000B46D8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		CharacterActionComponent characterActionComponent = (entity != null) ? entity.GetComponent<CharacterActionComponent>() : null;
		if (characterActionComponent == null)
		{
			return false;
		}
		CharacterExploreComponent characterExploreComponent = (entity != null) ? entity.GetComponent<CharacterExploreComponent>() : null;
		Vector vector = (characterExploreComponent != null) ? characterExploreComponent.GetInteractingTargetLocation() : null;
		if (vector == null)
		{
			return false;
		}
		Vector tmpPos = TsAnimNotifyCatapultToTarget.TmpPos;
		tmpPos.DeepCopy(vector);
		Vector tmpOffset = TsAnimNotifyCatapultToTarget.TmpOffset;
		Vector vector2 = tmpOffset;
		FVector locationOffset = this.LocationOffset;
		vector2.FromUeVector(locationOffset);
		characterActionComponent.StartCatapultToTargetByTime(tmpPos, tmpOffset, this.Time, 0).Forget<bool>();
		return true;
	}

	// Token: 0x06004F6C RID: 20332 RVA: 0x000B6577 File Offset: 0x000B4777
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "角色弹射到目标";
	}

	// Token: 0x06004F6D RID: 20333 RVA: 0x000B657E File Offset: 0x000B477E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyCatapultToTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCatapultToTarget.TsAnimNotifyCatapultToTarget_C");
		}
		return TsAnimNotifyCatapultToTarget._ClassPtr;
	}

	// Token: 0x06004F6E RID: 20334 RVA: 0x000B65A4 File Offset: 0x000B47A4
	public TsAnimNotifyCatapultToTarget() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCatapultToTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F6F RID: 20335 RVA: 0x000B65CC File Offset: 0x000B47CC
	[NullableContext(1)]
	public TsAnimNotifyCatapultToTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyCatapultToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F70 RID: 20336 RVA: 0x000B65FF File Offset: 0x000B47FF
	protected TsAnimNotifyCatapultToTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F71 RID: 20337 RVA: 0x000B6608 File Offset: 0x000B4808
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F72 RID: 20338 RVA: 0x000B663B File Offset: 0x000B483B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x04001722 RID: 5922
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpPos = Vector.Create();

	// Token: 0x04001723 RID: 5923
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpOffset = Vector.Create();

	// Token: 0x04001724 RID: 5924
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyCatapultToTarget.TsAnimNotifyCatapultToTarget_C";

	// Token: 0x04001725 RID: 5925
	private static IntPtr _ClassPtr;

	// Token: 0x04001726 RID: 5926
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001727 RID: 5927
	private static int __PropertyOffset_LocationOffset;

	// Token: 0x04001728 RID: 5928
	private static int __PropertyOffset_Time;
}
