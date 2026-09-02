using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Enum;
using CSharpScript.Game.Render;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003430 RID: 13360
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Scene/Item/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Scene/Item/SceneInteractionDebugActor.SceneInteractionDebugActor_C")]
public class SceneInteractionDebugActor : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002628 RID: 9768
	// (get) Token: 0x0601BFAC RID: 114604 RVA: 0x00857DE0 File Offset: 0x00855FE0
	// (set) Token: 0x0601BFAD RID: 114605 RVA: 0x00857DF0 File Offset: 0x00855FF0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int HandleId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_HandleId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_HandleId) = value;
		}
	}

	// Token: 0x17002629 RID: 9769
	// (get) Token: 0x0601BFAE RID: 114606 RVA: 0x00857E01 File Offset: 0x00856001
	// (set) Token: 0x0601BFAF RID: 114607 RVA: 0x00857E15 File Offset: 0x00856015
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AActor DebugActorRef
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionDebugActor.__PropertyOffset_DebugActorRef);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionDebugActor.__PropertyOffset_DebugActorRef, value);
		}
	}

	// Token: 0x1700262A RID: 9770
	// (get) Token: 0x0601BFB0 RID: 114608 RVA: 0x00857E2A File Offset: 0x0085602A
	// (set) Token: 0x0601BFB1 RID: 114609 RVA: 0x00857E3E File Offset: 0x0085603E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string DebugActorKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SceneInteractionDebugActor.__PropertyOffset_DebugActorKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SceneInteractionDebugActor.__PropertyOffset_DebugActorKey)), value);
		}
	}

	// Token: 0x1700262B RID: 9771
	// (get) Token: 0x0601BFB2 RID: 114610 RVA: 0x00857E53 File Offset: 0x00856053
	// (set) Token: 0x0601BFB3 RID: 114611 RVA: 0x00857E63 File Offset: 0x00856063
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedTransition
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_NeedTransition) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_NeedTransition) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700262C RID: 9772
	// (get) Token: 0x0601BFB4 RID: 114612 RVA: 0x00857E74 File Offset: 0x00856074
	// (set) Token: 0x0601BFB5 RID: 114613 RVA: 0x00857E84 File Offset: 0x00856084
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Force
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_Force) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_Force) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700262D RID: 9773
	// (get) Token: 0x0601BFB6 RID: 114614 RVA: 0x00857E95 File Offset: 0x00856095
	// (set) Token: 0x0601BFB7 RID: 114615 RVA: 0x00857EA9 File Offset: 0x008560A9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string LevelName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SceneInteractionDebugActor.__PropertyOffset_LevelName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SceneInteractionDebugActor.__PropertyOffset_LevelName)), value);
		}
	}

	// Token: 0x1700262E RID: 9774
	// (get) Token: 0x0601BFB8 RID: 114616 RVA: 0x00857EBE File Offset: 0x008560BE
	// (set) Token: 0x0601BFB9 RID: 114617 RVA: 0x00857ECE File Offset: 0x008560CE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CountNumber
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_CountNumber);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_CountNumber) = value;
		}
	}

	// Token: 0x1700262F RID: 9775
	// (get) Token: 0x0601BFBA RID: 114618 RVA: 0x00857EDF File Offset: 0x008560DF
	// (set) Token: 0x0601BFBB RID: 114619 RVA: 0x00857EEF File Offset: 0x008560EF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BaseForce
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_BaseForce);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_BaseForce) = value;
		}
	}

	// Token: 0x17002630 RID: 9776
	// (get) Token: 0x0601BFBC RID: 114620 RVA: 0x00857F00 File Offset: 0x00856100
	// (set) Token: 0x0601BFBD RID: 114621 RVA: 0x00857F14 File Offset: 0x00856114
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector OriginOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_OriginOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_OriginOffset) = value;
		}
	}

	// Token: 0x17002631 RID: 9777
	// (get) Token: 0x0601BFBE RID: 114622 RVA: 0x00857F29 File Offset: 0x00856129
	// (set) Token: 0x0601BFBF RID: 114623 RVA: 0x00857F39 File Offset: 0x00856139
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DamageRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_DamageRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_DamageRadius) = value;
		}
	}

	// Token: 0x17002632 RID: 9778
	// (get) Token: 0x0601BFC0 RID: 114624 RVA: 0x00857F4A File Offset: 0x0085614A
	// (set) Token: 0x0601BFC1 RID: 114625 RVA: 0x00857F5A File Offset: 0x0085615A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ImpluseFactor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_ImpluseFactor);
		}
		set
		{
			*(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_ImpluseFactor) = value;
		}
	}

	// Token: 0x0601BFC2 RID: 114626 RVA: 0x00857F6C File Offset: 0x0085616C
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

	// Token: 0x0601BFC3 RID: 114627 RVA: 0x00857FDC File Offset: 0x008561DC
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.HandleId = -1;
	}

	// Token: 0x0601BFC4 RID: 114628 RVA: 0x00857FE8 File Offset: 0x008561E8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState1()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState1"), out num);
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

	// Token: 0x0601BFC5 RID: 114629 RVA: 0x00858058 File Offset: 0x00856258
	protected void ChangeState1_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state1", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State1, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFC6 RID: 114630 RVA: 0x008580B8 File Offset: 0x008562B8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState2()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState2"), out num);
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

	// Token: 0x0601BFC7 RID: 114631 RVA: 0x00858128 File Offset: 0x00856328
	protected void ChangeState2_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state2", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State2, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFC8 RID: 114632 RVA: 0x00858188 File Offset: 0x00856388
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState3()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState3"), out num);
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

	// Token: 0x0601BFC9 RID: 114633 RVA: 0x008581F8 File Offset: 0x008563F8
	protected void ChangeState3_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state3", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State3, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFCA RID: 114634 RVA: 0x00858258 File Offset: 0x00856458
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState4()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState4"), out num);
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

	// Token: 0x0601BFCB RID: 114635 RVA: 0x008582C8 File Offset: 0x008564C8
	protected void ChangeState4_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state4", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State4, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFCC RID: 114636 RVA: 0x00858328 File Offset: 0x00856528
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState5()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState5"), out num);
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

	// Token: 0x0601BFCD RID: 114637 RVA: 0x00858398 File Offset: 0x00856598
	protected void ChangeState5_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state5", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State5, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFCE RID: 114638 RVA: 0x008583F8 File Offset: 0x008565F8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState6()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState6"), out num);
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

	// Token: 0x0601BFCF RID: 114639 RVA: 0x00858468 File Offset: 0x00856668
	protected void ChangeState6_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state6", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State6, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFD0 RID: 114640 RVA: 0x008584C8 File Offset: 0x008566C8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState7()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState7"), out num);
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

	// Token: 0x0601BFD1 RID: 114641 RVA: 0x00858538 File Offset: 0x00856738
	protected void ChangeState7_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state7", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State7, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFD2 RID: 114642 RVA: 0x00858598 File Offset: 0x00856798
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeState8()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeState8"), out num);
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

	// Token: 0x0601BFD3 RID: 114643 RVA: 0x00858608 File Offset: 0x00856808
	protected void ChangeState8_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "change state8", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().SwitchSceneInteractionToState(this.HandleId, EKuroSceneInteractionState.State8, this.NeedTransition, this.Force, false);
		}
	}

	// Token: 0x0601BFD4 RID: 114644 RVA: 0x00858668 File Offset: 0x00856868
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Create()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Create"), out num);
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

	// Token: 0x0601BFD5 RID: 114645 RVA: 0x008586D8 File Offset: 0x008568D8
	protected void Create_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "create", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			this.Remove();
		}
		string text = this.LevelName;
		if (text.StartsWith("World'"))
		{
			text = this.LevelName.Replace("World'", "");
			text = text.Split('.', StringSplitOptions.None)[0];
		}
		this.HandleId = SceneInteractionManager.Get().CreateSceneInteractionLevel(text, this.InitState, base.D_K2_GetActorLocation(), base.K2_GetActorRotation(), delegate
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "level streaming complete", default(ReadOnlySpan<ValueTuple<string, object>>));
		}, true, false, 0, null);
	}

	// Token: 0x0601BFD6 RID: 114646 RVA: 0x0085879C File Offset: 0x0085699C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Remove()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Remove"), out num);
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

	// Token: 0x0601BFD7 RID: 114647 RVA: 0x0085880C File Offset: 0x00856A0C
	protected void Remove_Implementation()
	{
		if (!ControllerBase<RenderModuleController>.Instance.IsRuntime())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.RenderScene, ELogAuthor.HCS, "remove", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().DestroySceneInteraction(this.HandleId);
			this.HandleId = -1;
			this.DebugActorRef = null;
		}
	}

	// Token: 0x0601BFD8 RID: 114648 RVA: 0x0085886C File Offset: 0x00856A6C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void PrintState()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PrintState"), out num);
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

	// Token: 0x0601BFD9 RID: 114649 RVA: 0x008588DC File Offset: 0x00856ADC
	protected void PrintState_Implementation()
	{
		int handleId = this.HandleId;
	}

	// Token: 0x0601BFDA RID: 114650 RVA: 0x008588E8 File Offset: 0x00856AE8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void PlaySceneEffect()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PlaySceneEffect"), out num);
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

	// Token: 0x0601BFDB RID: 114651 RVA: 0x00858958 File Offset: 0x00856B58
	protected void PlaySceneEffect_Implementation()
	{
		if (this.HandleId >= 0)
		{
			SceneInteractionManager.Get().PlaySceneInteractionEffect(this.HandleId, this.EffectKey.Value);
		}
	}

	// Token: 0x0601BFDC RID: 114652 RVA: 0x00858980 File Offset: 0x00856B80
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ChangeDirection()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ChangeDirection"), out num);
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

	// Token: 0x0601BFDD RID: 114653 RVA: 0x008589F0 File Offset: 0x00856BF0
	protected void ChangeDirection_Implementation()
	{
		if (this.HandleId >= 0)
		{
			this.CountNumber += 1f;
			SceneInteractionManager.Get().ChangeSceneInteractionPlayDirection(this.HandleId, this.CountNumber % 2f == 0f);
		}
	}

	// Token: 0x0601BFDE RID: 114654 RVA: 0x00858A30 File Offset: 0x00856C30
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void GetDebugActorRefByKey()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugActorRefByKey"), out num);
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

	// Token: 0x0601BFDF RID: 114655 RVA: 0x00858AA0 File Offset: 0x00856CA0
	protected void GetDebugActorRefByKey_Implementation()
	{
		if (this.HandleId >= 0)
		{
			AActor sceneInteractionActorByKey = SceneInteractionManager.Get().GetSceneInteractionActorByKey(this.HandleId, this.DebugActorKey);
			this.HandleId = -1;
			this.DebugActorRef = sceneInteractionActorByKey;
		}
	}

	// Token: 0x0601BFE0 RID: 114656 RVA: 0x00858ADB File Offset: 0x00856CDB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (SceneInteractionDebugActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Scene/Item/SceneInteractionDebugActor.SceneInteractionDebugActor_C");
		}
		return SceneInteractionDebugActor._ClassPtr;
	}

	// Token: 0x0601BFE1 RID: 114657 RVA: 0x00858B00 File Offset: 0x00856D00
	public SceneInteractionDebugActor() : this(BuiltinUtils.AllocNativeUObject(SceneInteractionDebugActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BFE2 RID: 114658 RVA: 0x00858B28 File Offset: 0x00856D28
	public SceneInteractionDebugActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneInteractionDebugActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BFE3 RID: 114659 RVA: 0x00858B5B File Offset: 0x00856D5B
	protected SceneInteractionDebugActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x17002633 RID: 9779
	// (get) Token: 0x0601BFE4 RID: 114660 RVA: 0x00858B64 File Offset: 0x00856D64
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		get
		{
			return *(base.NativePtr + (IntPtr)SceneInteractionDebugActor.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x17002634 RID: 9780
	// (get) Token: 0x0601BFE5 RID: 114661 RVA: 0x00858B74 File Offset: 0x00856D74
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + SceneInteractionDebugActor.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x0601BFE6 RID: 114662 RVA: 0x00858B88 File Offset: 0x00856D88
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601BFE7 RID: 114663 RVA: 0x00858B90 File Offset: 0x00856D90
	protected virtual void __CPPCALL_ChangeState1_Implementation()
	{
		this.ChangeState1_Implementation();
	}

	// Token: 0x0601BFE8 RID: 114664 RVA: 0x00858B98 File Offset: 0x00856D98
	protected virtual void __CPPCALL_ChangeState2_Implementation()
	{
		this.ChangeState2_Implementation();
	}

	// Token: 0x0601BFE9 RID: 114665 RVA: 0x00858BA0 File Offset: 0x00856DA0
	protected virtual void __CPPCALL_ChangeState3_Implementation()
	{
		this.ChangeState3_Implementation();
	}

	// Token: 0x0601BFEA RID: 114666 RVA: 0x00858BA8 File Offset: 0x00856DA8
	protected virtual void __CPPCALL_ChangeState4_Implementation()
	{
		this.ChangeState4_Implementation();
	}

	// Token: 0x0601BFEB RID: 114667 RVA: 0x00858BB0 File Offset: 0x00856DB0
	protected virtual void __CPPCALL_ChangeState5_Implementation()
	{
		this.ChangeState5_Implementation();
	}

	// Token: 0x0601BFEC RID: 114668 RVA: 0x00858BB8 File Offset: 0x00856DB8
	protected virtual void __CPPCALL_ChangeState6_Implementation()
	{
		this.ChangeState6_Implementation();
	}

	// Token: 0x0601BFED RID: 114669 RVA: 0x00858BC0 File Offset: 0x00856DC0
	protected virtual void __CPPCALL_ChangeState7_Implementation()
	{
		this.ChangeState7_Implementation();
	}

	// Token: 0x0601BFEE RID: 114670 RVA: 0x00858BC8 File Offset: 0x00856DC8
	protected virtual void __CPPCALL_ChangeState8_Implementation()
	{
		this.ChangeState8_Implementation();
	}

	// Token: 0x0601BFEF RID: 114671 RVA: 0x00858BD0 File Offset: 0x00856DD0
	protected virtual void __CPPCALL_Create_Implementation()
	{
		this.Create_Implementation();
	}

	// Token: 0x0601BFF0 RID: 114672 RVA: 0x00858BD8 File Offset: 0x00856DD8
	protected virtual void __CPPCALL_Remove_Implementation()
	{
		this.Remove_Implementation();
	}

	// Token: 0x0601BFF1 RID: 114673 RVA: 0x00858BE0 File Offset: 0x00856DE0
	protected virtual void __CPPCALL_PrintState_Implementation()
	{
		this.PrintState_Implementation();
	}

	// Token: 0x0601BFF2 RID: 114674 RVA: 0x00858BE8 File Offset: 0x00856DE8
	protected virtual void __CPPCALL_PlaySceneEffect_Implementation()
	{
		this.PlaySceneEffect_Implementation();
	}

	// Token: 0x0601BFF3 RID: 114675 RVA: 0x00858BF0 File Offset: 0x00856DF0
	protected virtual void __CPPCALL_ChangeDirection_Implementation()
	{
		this.ChangeDirection_Implementation();
	}

	// Token: 0x0601BFF4 RID: 114676 RVA: 0x00858BF8 File Offset: 0x00856DF8
	protected virtual void __CPPCALL_GetDebugActorRefByKey_Implementation()
	{
		this.GetDebugActorRefByKey_Implementation();
	}

	// Token: 0x0400E22F RID: 57903
	public ESceneInteractionEffect? EffectKey;

	// Token: 0x0400E230 RID: 57904
	public EKuroSceneInteractionState? InitState;

	// Token: 0x0400E231 RID: 57905
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Scene/Item/SceneInteractionDebugActor.SceneInteractionDebugActor_C";

	// Token: 0x0400E232 RID: 57906
	private static IntPtr _ClassPtr;

	// Token: 0x0400E233 RID: 57907
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E234 RID: 57908
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400E235 RID: 57909
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x0400E236 RID: 57910
	private static int __PropertyOffset_HandleId;

	// Token: 0x0400E237 RID: 57911
	private static int __PropertyOffset_DebugActorRef;

	// Token: 0x0400E238 RID: 57912
	private static int __PropertyOffset_DebugActorKey;

	// Token: 0x0400E239 RID: 57913
	private static int __PropertyOffset_NeedTransition;

	// Token: 0x0400E23A RID: 57914
	private static int __PropertyOffset_Force;

	// Token: 0x0400E23B RID: 57915
	private static int __PropertyOffset_LevelName;

	// Token: 0x0400E23C RID: 57916
	private static int __PropertyOffset_CountNumber;

	// Token: 0x0400E23D RID: 57917
	private static int __PropertyOffset_BaseForce;

	// Token: 0x0400E23E RID: 57918
	private static int __PropertyOffset_OriginOffset;

	// Token: 0x0400E23F RID: 57919
	private static int __PropertyOffset_DamageRadius;

	// Token: 0x0400E240 RID: 57920
	private static int __PropertyOffset_ImpluseFactor;
}
