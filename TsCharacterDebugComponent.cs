using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E29 RID: 11817
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Component/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Component/TsCharacterDebugComponent.TsCharacterDebugComponent_C")]
public class TsCharacterDebugComponent : UActorComponent, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002064 RID: 8292
	// (get) Token: 0x06017EAB RID: 97963 RVA: 0x006B3BD4 File Offset: 0x006B1DD4
	// (set) Token: 0x06017EAC RID: 97964 RVA: 0x006B3BE4 File Offset: 0x006B1DE4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxFixSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_MaxFixSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_MaxFixSpeed) = value;
		}
	}

	// Token: 0x17002065 RID: 8293
	// (get) Token: 0x06017EAD RID: 97965 RVA: 0x006B3BF5 File Offset: 0x006B1DF5
	// (set) Token: 0x06017EAE RID: 97966 RVA: 0x006B3C05 File Offset: 0x006B1E05
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool StaticInit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_StaticInit) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_StaticInit) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002066 RID: 8294
	// (get) Token: 0x06017EAF RID: 97967 RVA: 0x006B3C16 File Offset: 0x006B1E16
	// (set) Token: 0x06017EB0 RID: 97968 RVA: 0x006B3C26 File Offset: 0x006B1E26
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int StaticAttrId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_StaticAttrId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_StaticAttrId) = value;
		}
	}

	// Token: 0x17002067 RID: 8295
	// (get) Token: 0x06017EB1 RID: 97969 RVA: 0x006B3C37 File Offset: 0x006B1E37
	// (set) Token: 0x06017EB2 RID: 97970 RVA: 0x006B3C4B File Offset: 0x006B1E4B
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string StaticAiId
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsCharacterDebugComponent.__PropertyOffset_StaticAiId)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsCharacterDebugComponent.__PropertyOffset_StaticAiId)), value);
		}
	}

	// Token: 0x17002068 RID: 8296
	// (get) Token: 0x06017EB3 RID: 97971 RVA: 0x006B3C60 File Offset: 0x006B1E60
	// (set) Token: 0x06017EB4 RID: 97972 RVA: 0x006B3C70 File Offset: 0x006B1E70
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long DebugCreatureId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_DebugCreatureId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_DebugCreatureId) = value;
		}
	}

	// Token: 0x17002069 RID: 8297
	// (get) Token: 0x06017EB5 RID: 97973 RVA: 0x006B3C81 File Offset: 0x006B1E81
	// (set) Token: 0x06017EB6 RID: 97974 RVA: 0x006B3C91 File Offset: 0x006B1E91
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int DebugEntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_DebugEntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_DebugEntityId) = value;
		}
	}

	// Token: 0x1700206A RID: 8298
	// (get) Token: 0x06017EB7 RID: 97975 RVA: 0x006B3CA2 File Offset: 0x006B1EA2
	// (set) Token: 0x06017EB8 RID: 97976 RVA: 0x006B3CB2 File Offset: 0x006B1EB2
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe float TestRiseSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_TestRiseSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_TestRiseSpeed) = value;
		}
	}

	// Token: 0x1700206B RID: 8299
	// (get) Token: 0x06017EB9 RID: 97977 RVA: 0x006B3CC3 File Offset: 0x006B1EC3
	// (set) Token: 0x06017EBA RID: 97978 RVA: 0x006B3CD3 File Offset: 0x006B1ED3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int DebugInteractCount
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_DebugInteractCount);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_DebugInteractCount) = value;
		}
	}

	// Token: 0x1700206C RID: 8300
	// (get) Token: 0x06017EBB RID: 97979 RVA: 0x006B3CE4 File Offset: 0x006B1EE4
	// (set) Token: 0x06017EBC RID: 97980 RVA: 0x006B3CF8 File Offset: 0x006B1EF8
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBehaviorTree BehaviorTree
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBehaviorTree>(base.NativePtr / (IntPtr)sizeof(void*) + TsCharacterDebugComponent.__PropertyOffset_BehaviorTree);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsCharacterDebugComponent.__PropertyOffset_BehaviorTree, value);
		}
	}

	// Token: 0x1700206D RID: 8301
	// (get) Token: 0x06017EBD RID: 97981 RVA: 0x006B3D0D File Offset: 0x006B1F0D
	// (set) Token: 0x06017EBE RID: 97982 RVA: 0x006B3D21 File Offset: 0x006B1F21
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor PatrolSpline
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + TsCharacterDebugComponent.__PropertyOffset_PatrolSpline);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsCharacterDebugComponent.__PropertyOffset_PatrolSpline, value);
		}
	}

	// Token: 0x1700206E RID: 8302
	// (get) Token: 0x06017EBF RID: 97983 RVA: 0x006B3D36 File Offset: 0x006B1F36
	// (set) Token: 0x06017EC0 RID: 97984 RVA: 0x006B3D4A File Offset: 0x006B1F4A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EDrawDebugTrace> EnterClimbTrace
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_EnterClimbTrace);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_EnterClimbTrace) = value;
		}
	}

	// Token: 0x06017EC1 RID: 97985 RVA: 0x006B3D5F File Offset: 0x006B1F5F
	public void Destroy()
	{
		this.BaseChar = null;
	}

	// Token: 0x06017EC2 RID: 97986 RVA: 0x006B3D68 File Offset: 0x006B1F68
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMovementDebug(bool newDebug)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMovementDebug"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsCharacterDebugComponent.__SetMovementDebug_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsCharacterDebugComponent.__SetMovementDebug_FunctionParams*)ptr + 15L / (long)sizeof(TsCharacterDebugComponent.__SetMovementDebug_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->newDebug = newDebug;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06017EC3 RID: 97987 RVA: 0x006B3DDE File Offset: 0x006B1FDE
	protected void SetMovementDebug_Implementation(bool newDebug)
	{
		this.BaseChar.CharacterActorComponent.Entity.GetComponent<ActorDebugMovementComponent>().SetDebug(newDebug);
	}

	// Token: 0x06017EC4 RID: 97988 RVA: 0x006B3DFC File Offset: 0x006B1FFC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeEnterClimbTrace()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeEnterClimbTrace"), out num);
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

	// Token: 0x06017EC5 RID: 97989 RVA: 0x006B3E6C File Offset: 0x006B206C
	protected void ChangeEnterClimbTrace_Implementation()
	{
		EDrawDebugTrace edrawDebugTrace = this.EnterClimbTrace;
		if (edrawDebugTrace != EDrawDebugTrace.None)
		{
			if (edrawDebugTrace != EDrawDebugTrace.ForOneFrame)
			{
				this.EnterClimbTrace = EDrawDebugTrace.None;
			}
			else
			{
				this.EnterClimbTrace = EDrawDebugTrace.ForDuration;
			}
		}
		else
		{
			this.EnterClimbTrace = EDrawDebugTrace.ForOneFrame;
		}
		this.BaseChar.CharacterActorComponent.Entity.GetComponent<CharacterClimbComponent>().UpdateClimbDebug();
	}

	// Token: 0x1700206F RID: 8303
	// (get) Token: 0x06017EC6 RID: 97990 RVA: 0x006B3ED0 File Offset: 0x006B20D0
	// (set) Token: 0x06017EC7 RID: 97991 RVA: 0x006B3EE4 File Offset: 0x006B20E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EDrawDebugTrace> VaultClimbTrace
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_VaultClimbTrace);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_VaultClimbTrace) = value;
		}
	}

	// Token: 0x06017EC8 RID: 97992 RVA: 0x006B3EFC File Offset: 0x006B20FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeVaultClimbTrace()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeVaultClimbTrace"), out num);
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

	// Token: 0x06017EC9 RID: 97993 RVA: 0x006B3F6C File Offset: 0x006B216C
	protected void ChangeVaultClimbTrace_Implementation()
	{
		EDrawDebugTrace edrawDebugTrace = this.VaultClimbTrace;
		if (edrawDebugTrace != EDrawDebugTrace.None)
		{
			if (edrawDebugTrace != EDrawDebugTrace.ForOneFrame)
			{
				this.VaultClimbTrace = EDrawDebugTrace.None;
			}
			else
			{
				this.VaultClimbTrace = EDrawDebugTrace.ForDuration;
			}
		}
		else
		{
			this.VaultClimbTrace = EDrawDebugTrace.ForOneFrame;
		}
		this.BaseChar.CharacterActorComponent.Entity.GetComponent<CharacterClimbComponent>().UpdateClimbDebug();
	}

	// Token: 0x17002070 RID: 8304
	// (get) Token: 0x06017ECA RID: 97994 RVA: 0x006B3FD0 File Offset: 0x006B21D0
	// (set) Token: 0x06017ECB RID: 97995 RVA: 0x006B3FE4 File Offset: 0x006B21E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EDrawDebugTrace> UpArriveClimbTrace
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_UpArriveClimbTrace);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_UpArriveClimbTrace) = value;
		}
	}

	// Token: 0x06017ECC RID: 97996 RVA: 0x006B3FFC File Offset: 0x006B21FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeUpArriveClimbTrace()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeUpArriveClimbTrace"), out num);
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

	// Token: 0x06017ECD RID: 97997 RVA: 0x006B406C File Offset: 0x006B226C
	protected void ChangeUpArriveClimbTrace_Implementation()
	{
		EDrawDebugTrace edrawDebugTrace = this.UpArriveClimbTrace;
		if (edrawDebugTrace != EDrawDebugTrace.None)
		{
			if (edrawDebugTrace != EDrawDebugTrace.ForOneFrame)
			{
				this.UpArriveClimbTrace = EDrawDebugTrace.None;
			}
			else
			{
				this.UpArriveClimbTrace = EDrawDebugTrace.ForDuration;
			}
		}
		else
		{
			this.UpArriveClimbTrace = EDrawDebugTrace.ForOneFrame;
		}
		this.BaseChar.CharacterActorComponent.Entity.GetComponent<CharacterClimbComponent>().UpdateClimbDebug();
	}

	// Token: 0x17002071 RID: 8305
	// (get) Token: 0x06017ECE RID: 97998 RVA: 0x006B40D0 File Offset: 0x006B22D0
	// (set) Token: 0x06017ECF RID: 97999 RVA: 0x006B40E4 File Offset: 0x006B22E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EDrawDebugTrace> ClimbingTrace
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_ClimbingTrace);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCharacterDebugComponent.__PropertyOffset_ClimbingTrace) = value;
		}
	}

	// Token: 0x06017ED0 RID: 98000 RVA: 0x006B40FC File Offset: 0x006B22FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeClimbingTrace()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeClimbingTrace"), out num);
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

	// Token: 0x06017ED1 RID: 98001 RVA: 0x006B416C File Offset: 0x006B236C
	protected void ChangeClimbingTrace_Implementation()
	{
		if (this.ClimbingTrace == EDrawDebugTrace.None)
		{
			this.ClimbingTrace = EDrawDebugTrace.ForOneFrame;
		}
		else
		{
			this.ClimbingTrace = EDrawDebugTrace.None;
		}
		this.BaseChar.CharacterActorComponent.Entity.GetComponent<CharacterClimbComponent>().UpdateClimbDebug();
	}

	// Token: 0x06017ED2 RID: 98002 RVA: 0x006B41BC File Offset: 0x006B23BC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeNoTop()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeNoTop"), out num);
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

	// Token: 0x06017ED3 RID: 98003 RVA: 0x006B422C File Offset: 0x006B242C
	protected void ChangeNoTop_Implementation()
	{
		this.NoTop = !this.NoTop;
		this.BaseChar.CharacterActorComponent.Entity.GetComponent<CharacterClimbComponent>().UpdateClimbDebug();
	}

	// Token: 0x06017ED4 RID: 98004 RVA: 0x006B4258 File Offset: 0x006B2458
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

	// Token: 0x06017ED5 RID: 98005 RVA: 0x006B42C8 File Offset: 0x006B24C8
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		AActor owner = base.GetOwner();
		this.BaseChar = (owner as TsBaseCharacter);
		if (this.BaseChar == null)
		{
			return;
		}
		this.OriginWalkableAngle = this.BaseChar.CharacterMovement.K2_GetWalkableFloorAngle();
		this.DebugRiseModeOn = false;
		base.SetComponentTickEnabled(this.DebugRiseModeOn);
	}

	// Token: 0x06017ED6 RID: 98006 RVA: 0x006B431C File Offset: 0x006B251C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UActorComponent.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UActorComponent.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(UActorComponent.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06017ED7 RID: 98007 RVA: 0x006B4392 File Offset: 0x006B2592
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		this.DebugRising(deltaSeconds);
	}

	// Token: 0x06017ED8 RID: 98008 RVA: 0x006B439C File Offset: 0x006B259C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ActivateDebugSpeed(bool activate)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ActivateDebugSpeed"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsCharacterDebugComponent.__ActivateDebugSpeed_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsCharacterDebugComponent.__ActivateDebugSpeed_FunctionParams*)ptr + 15L / (long)sizeof(TsCharacterDebugComponent.__ActivateDebugSpeed_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->activate = activate;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06017ED9 RID: 98009 RVA: 0x006B4414 File Offset: 0x006B2614
	protected void ActivateDebugSpeed_Implementation(bool activate)
	{
		if (activate)
		{
			this.BaseChar.CharacterMovement.SetWalkableFloorAngle(90f);
			if (this.MaxFixSpeed == 0f)
			{
				this.MaxFixSpeed = 5000f;
				return;
			}
		}
		else
		{
			this.BaseChar.CharacterMovement.SetWalkableFloorAngle(this.OriginWalkableAngle);
			if (this.MaxFixSpeed != 0f)
			{
				this.MaxFixSpeed = 0f;
			}
		}
	}

	// Token: 0x06017EDA RID: 98010 RVA: 0x006B4480 File Offset: 0x006B2680
	protected void DebugRising(float deltaSeconds)
	{
		if (this.DebugRiseModeOn)
		{
			TsCharacterDebugComponent.tmpVector.Reset();
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.BaseChar.CharacterActorComponent, TsCharacterDebugComponent.tmpVector, (double)(this.TestRiseSpeed * deltaSeconds));
			this.BaseChar.CharacterActorComponent.AddActorWorldOffset(TsCharacterDebugComponent.tmpVector.ToUeVector(false), "DebugRising", false);
			this.BaseChar.CharacterActorComponent.MoveComp.SetForceSpeed(Vector.ZeroVectorProxy);
		}
	}

	// Token: 0x06017EDB RID: 98011 RVA: 0x006B4500 File Offset: 0x006B2700
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DebugDrawActivateArea()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DebugDrawActivateArea"), out num);
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

	// Token: 0x06017EDC RID: 98012 RVA: 0x006B4570 File Offset: 0x006B2770
	protected void DebugDrawActivateArea_Implementation()
	{
		FVectorDouble actorLocation = this.BaseChar.CharacterActorComponent.ActorLocation;
		FVector fvector = actorLocation;
		FVectorDouble end = new FVectorDouble(ref fvector);
		end.Z += 100.0;
		UKismetSystemLibrary.D_DrawDebugCylinder(this, actorLocation, end, 5000f, 12, null, 0f, 0f);
	}

	// Token: 0x06017EDD RID: 98013 RVA: 0x006B45D4 File Offset: 0x006B27D4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetDebugRiseEnable(bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDebugRiseEnable"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsCharacterDebugComponent.__SetDebugRiseEnable_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsCharacterDebugComponent.__SetDebugRiseEnable_FunctionParams*)ptr + 15L / (long)sizeof(TsCharacterDebugComponent.__SetDebugRiseEnable_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06017EDE RID: 98014 RVA: 0x006B464A File Offset: 0x006B284A
	protected void SetDebugRiseEnable_Implementation(bool enable)
	{
		if (this.DebugRiseModeOn == enable)
		{
			return;
		}
		this.DebugRiseModeOn = enable;
		base.SetComponentTickEnabled(enable);
	}

	// Token: 0x06017EDF RID: 98015 RVA: 0x006B4664 File Offset: 0x006B2864
	public void SaveDebugPatrolPoint(FVector point)
	{
		this.SaveDebugPatrolPoint(Vector.Create(point));
	}

	// Token: 0x06017EE0 RID: 98016 RVA: 0x006B4677 File Offset: 0x006B2877
	[NullableContext(1)]
	public void SaveDebugPatrolPoint(Vector point)
	{
		if (this.DebugPatrolPoints == null)
		{
			this.DebugPatrolPoints = new List<Vector>();
		}
		this.DebugPatrolPoints.Add(point);
	}

	// Token: 0x06017EE1 RID: 98017 RVA: 0x006B4698 File Offset: 0x006B2898
	public void ClearDebugPatrolPoints()
	{
		List<Vector> debugPatrolPoints = this.DebugPatrolPoints;
		if (debugPatrolPoints == null)
		{
			return;
		}
		debugPatrolPoints.Clear();
	}

	// Token: 0x06017EE2 RID: 98018 RVA: 0x006B46AC File Offset: 0x006B28AC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DrawDebugPatrolPoints()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DrawDebugPatrolPoints"), out num);
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

	// Token: 0x06017EE3 RID: 98019 RVA: 0x006B471C File Offset: 0x006B291C
	protected void DrawDebugPatrolPoints_Implementation()
	{
		if (this.DebugPatrolPoints == null || this.DebugPatrolPoints.Count == 0)
		{
			return;
		}
		Vector vector = this.DebugPatrolPoints[0];
		UKismetSystemLibrary.D_DrawDebugSphere(this, vector.ToUeVector(false), 18f, 12, new FLinearColor?(ColorUtils.LinearCyan), 60f, 0f);
		int num = this.DebugPatrolPoints.Count - 1;
		for (int i = 1; i < num; i++)
		{
			Vector vector2 = this.DebugPatrolPoints[i];
			UKismetSystemLibrary.D_DrawDebugSphere(this, vector2.ToUeVector(false), 6f, 4, new FLinearColor?(ColorUtils.LinearGreen), 60f, 0f);
		}
		if (num > 0)
		{
			Vector vector3 = this.DebugPatrolPoints[num];
			UKismetSystemLibrary.D_DrawDebugSphere(this, vector3.ToUeVector(false), 18f, 12, new FLinearColor?(ColorUtils.LinearYellow), 60f, 0f);
		}
	}

	// Token: 0x06017EE4 RID: 98020 RVA: 0x006B4800 File Offset: 0x006B2A00
	[NullableContext(1)]
	public void SaveErrorNavigationPath(Vector start, Vector end, FVector[] results)
	{
		if (this.DebugNavigationErrorPaths == null)
		{
			this.DebugNavigationErrorPaths = new List<TsCharacterDebugComponent.NavigationErrorData>();
		}
		TsCharacterDebugComponent.NavigationErrorData navigationErrorData = new TsCharacterDebugComponent.NavigationErrorData();
		navigationErrorData.Start = Vector.Create(start);
		navigationErrorData.End = Vector.Create(end);
		navigationErrorData.Results = new List<FVectorDouble>();
		foreach (FVector fvector in results)
		{
			FVectorDouble item = new FVectorDouble();
			item.Set((double)fvector.X, (double)fvector.Y, (double)fvector.Z);
			navigationErrorData.Results.Add(item);
		}
		this.DebugNavigationErrorPaths.Add(navigationErrorData);
	}

	// Token: 0x06017EE5 RID: 98021 RVA: 0x006B489C File Offset: 0x006B2A9C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DrawErrorNavigationPaths()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DrawErrorNavigationPaths"), out num);
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

	// Token: 0x06017EE6 RID: 98022 RVA: 0x006B490C File Offset: 0x006B2B0C
	protected void DrawErrorNavigationPaths_Implementation()
	{
		if (this.DebugNavigationErrorPaths == null)
		{
			return;
		}
		for (int i = 0; i < this.DebugNavigationErrorPaths.Count; i++)
		{
			TsCharacterDebugComponent.NavigationErrorData navigationErrorData = this.DebugNavigationErrorPaths[i];
			UKismetSystemLibrary.D_DrawDebugSphere(this, navigationErrorData.Start.ToUeVector(false), 18f, 12, new FLinearColor?(ColorUtils.LinearCyan), 60f, 0f);
			if (navigationErrorData.Results != null)
			{
				for (int j = 0; j < navigationErrorData.Results.Count; j++)
				{
					FVectorDouble center = navigationErrorData.Results[j];
					UKismetSystemLibrary.D_DrawDebugSphere(this, center, 6f, 4, new FLinearColor?(ColorUtils.LinearRed), 60f, 0f);
				}
			}
			UKismetSystemLibrary.D_DrawDebugSphere(this, navigationErrorData.End.ToUeVector(false), 18f, 12, new FLinearColor?(ColorUtils.LinearYellow), 60f, 0f);
		}
	}

	// Token: 0x06017EE7 RID: 98023 RVA: 0x006B49F1 File Offset: 0x006B2BF1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsCharacterDebugComponent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Component/TsCharacterDebugComponent.TsCharacterDebugComponent_C");
		}
		return TsCharacterDebugComponent._ClassPtr;
	}

	// Token: 0x06017EE8 RID: 98024 RVA: 0x006B4A18 File Offset: 0x006B2C18
	public TsCharacterDebugComponent() : this(BuiltinUtils.AllocNativeUObject(TsCharacterDebugComponent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017EE9 RID: 98025 RVA: 0x006B4A40 File Offset: 0x006B2C40
	[NullableContext(1)]
	public TsCharacterDebugComponent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCharacterDebugComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017EEA RID: 98026 RVA: 0x006B4A73 File Offset: 0x006B2C73
	protected TsCharacterDebugComponent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06017EEB RID: 98027 RVA: 0x006B4A7C File Offset: 0x006B2C7C
	protected unsafe virtual void __CPPCALL_SetMovementDebug_Implementation(TsCharacterDebugComponent.__SetMovementDebug_FunctionParams* __Params)
	{
		this.SetMovementDebug_Implementation(__Params->newDebug);
	}

	// Token: 0x06017EEC RID: 98028 RVA: 0x006B4A8A File Offset: 0x006B2C8A
	protected virtual void __CPPCALL_ChangeEnterClimbTrace_Implementation()
	{
		this.ChangeEnterClimbTrace_Implementation();
	}

	// Token: 0x06017EED RID: 98029 RVA: 0x006B4A92 File Offset: 0x006B2C92
	protected virtual void __CPPCALL_ChangeVaultClimbTrace_Implementation()
	{
		this.ChangeVaultClimbTrace_Implementation();
	}

	// Token: 0x06017EEE RID: 98030 RVA: 0x006B4A9A File Offset: 0x006B2C9A
	protected virtual void __CPPCALL_ChangeUpArriveClimbTrace_Implementation()
	{
		this.ChangeUpArriveClimbTrace_Implementation();
	}

	// Token: 0x06017EEF RID: 98031 RVA: 0x006B4AA2 File Offset: 0x006B2CA2
	protected virtual void __CPPCALL_ChangeClimbingTrace_Implementation()
	{
		this.ChangeClimbingTrace_Implementation();
	}

	// Token: 0x06017EF0 RID: 98032 RVA: 0x006B4AAA File Offset: 0x006B2CAA
	protected virtual void __CPPCALL_ChangeNoTop_Implementation()
	{
		this.ChangeNoTop_Implementation();
	}

	// Token: 0x06017EF1 RID: 98033 RVA: 0x006B4AB2 File Offset: 0x006B2CB2
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x06017EF2 RID: 98034 RVA: 0x006B4ABA File Offset: 0x006B2CBA
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(UActorComponent.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x06017EF3 RID: 98035 RVA: 0x006B4AC8 File Offset: 0x006B2CC8
	protected unsafe virtual void __CPPCALL_ActivateDebugSpeed_Implementation(TsCharacterDebugComponent.__ActivateDebugSpeed_FunctionParams* __Params)
	{
		this.ActivateDebugSpeed_Implementation(__Params->activate);
	}

	// Token: 0x06017EF4 RID: 98036 RVA: 0x006B4AD6 File Offset: 0x006B2CD6
	protected virtual void __CPPCALL_DebugDrawActivateArea_Implementation()
	{
		this.DebugDrawActivateArea_Implementation();
	}

	// Token: 0x06017EF5 RID: 98037 RVA: 0x006B4ADE File Offset: 0x006B2CDE
	protected unsafe virtual void __CPPCALL_SetDebugRiseEnable_Implementation(TsCharacterDebugComponent.__SetDebugRiseEnable_FunctionParams* __Params)
	{
		this.SetDebugRiseEnable_Implementation(__Params->enable);
	}

	// Token: 0x06017EF6 RID: 98038 RVA: 0x006B4AEC File Offset: 0x006B2CEC
	protected virtual void __CPPCALL_DrawDebugPatrolPoints_Implementation()
	{
		this.DrawDebugPatrolPoints_Implementation();
	}

	// Token: 0x06017EF7 RID: 98039 RVA: 0x006B4AF4 File Offset: 0x006B2CF4
	protected virtual void __CPPCALL_DrawErrorNavigationPaths_Implementation()
	{
		this.DrawErrorNavigationPaths_Implementation();
	}

	// Token: 0x0400B98D RID: 47501
	private const int JUMPED_TURN_SPEED_THREADHOLD = 100;

	// Token: 0x0400B98E RID: 47502
	private const int ACTIVE_DISTANCE = 5000;

	// Token: 0x0400B98F RID: 47503
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static Vector tmpVector = Vector.Create();

	// Token: 0x0400B990 RID: 47504
	[Nullable(2)]
	public TsBaseCharacter BaseChar;

	// Token: 0x0400B991 RID: 47505
	protected float OriginWalkableAngle;

	// Token: 0x0400B992 RID: 47506
	private bool DebugRiseModeOn;

	// Token: 0x0400B993 RID: 47507
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Vector> DebugPatrolPoints;

	// Token: 0x0400B994 RID: 47508
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<TsCharacterDebugComponent.NavigationErrorData> DebugNavigationErrorPaths;

	// Token: 0x0400B995 RID: 47509
	public bool NoTop;

	// Token: 0x0400B996 RID: 47510
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Component/TsCharacterDebugComponent.TsCharacterDebugComponent_C";

	// Token: 0x0400B997 RID: 47511
	private static IntPtr _ClassPtr;

	// Token: 0x0400B998 RID: 47512
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B999 RID: 47513
	private static int __PropertyOffset_MaxFixSpeed;

	// Token: 0x0400B99A RID: 47514
	private static int __PropertyOffset_StaticInit;

	// Token: 0x0400B99B RID: 47515
	private static int __PropertyOffset_StaticAttrId;

	// Token: 0x0400B99C RID: 47516
	private static int __PropertyOffset_StaticAiId;

	// Token: 0x0400B99D RID: 47517
	private static int __PropertyOffset_DebugCreatureId;

	// Token: 0x0400B99E RID: 47518
	private static int __PropertyOffset_DebugEntityId;

	// Token: 0x0400B99F RID: 47519
	private static int __PropertyOffset_TestRiseSpeed;

	// Token: 0x0400B9A0 RID: 47520
	private static int __PropertyOffset_DebugInteractCount;

	// Token: 0x0400B9A1 RID: 47521
	private static int __PropertyOffset_BehaviorTree;

	// Token: 0x0400B9A2 RID: 47522
	private static int __PropertyOffset_PatrolSpline;

	// Token: 0x0400B9A3 RID: 47523
	private static int __PropertyOffset_EnterClimbTrace;

	// Token: 0x0400B9A4 RID: 47524
	private static int __PropertyOffset_VaultClimbTrace;

	// Token: 0x0400B9A5 RID: 47525
	private static int __PropertyOffset_UpArriveClimbTrace;

	// Token: 0x0400B9A6 RID: 47526
	private static int __PropertyOffset_ClimbingTrace;

	// Token: 0x02009082 RID: 36994
	[NullableContext(2)]
	[Nullable(0)]
	public class NavigationErrorData
	{
		// Token: 0x04030718 RID: 198424
		public Vector Start;

		// Token: 0x04030719 RID: 198425
		public Vector End;

		// Token: 0x0403071A RID: 198426
		public List<FVectorDouble> Results;
	}

	// Token: 0x02009083 RID: 36995
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetMovementDebug_FunctionParams
	{
		// Token: 0x0403071B RID: 198427
		[FieldOffset(0)]
		public bool newDebug;
	}

	// Token: 0x02009084 RID: 36996
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __ActivateDebugSpeed_FunctionParams
	{
		// Token: 0x0403071C RID: 198428
		[FieldOffset(0)]
		public bool activate;
	}

	// Token: 0x02009085 RID: 36997
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetDebugRiseEnable_FunctionParams
	{
		// Token: 0x0403071D RID: 198429
		[FieldOffset(0)]
		public bool enable;
	}
}
