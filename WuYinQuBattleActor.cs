using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Manager;
using CSharpScript.Game.Render;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033F5 RID: 13301
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Battle/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Battle/WuYinQuBattleActor.WuYinQuBattleActor_C")]
public class WuYinQuBattleActor : AKuroWuYinQuActorBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700253D RID: 9533
	// (get) Token: 0x0601BA3F RID: 113215 RVA: 0x0083E96A File Offset: 0x0083CB6A
	// (set) Token: 0x0601BA40 RID: 113216 RVA: 0x0083E97E File Offset: 0x0083CB7E
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string 当前状态
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)WuYinQuBattleActor.__PropertyOffset_当前状态)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)WuYinQuBattleActor.__PropertyOffset_当前状态)), value);
		}
	}

	// Token: 0x1700253E RID: 9534
	// (get) Token: 0x0601BA41 RID: 113217 RVA: 0x0083E993 File Offset: 0x0083CB93
	// (set) Token: 0x0601BA42 RID: 113218 RVA: 0x0083E9A7 File Offset: 0x0083CBA7
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string 是否已经初始化
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)WuYinQuBattleActor.__PropertyOffset_是否已经初始化)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)WuYinQuBattleActor.__PropertyOffset_是否已经初始化)), value);
		}
	}

	// Token: 0x1700253F RID: 9535
	// (get) Token: 0x0601BA43 RID: 113219 RVA: 0x0083E9BC File Offset: 0x0083CBBC
	// (set) Token: 0x0601BA44 RID: 113220 RVA: 0x0083E9D0 File Offset: 0x0083CBD0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe AKuroLevelSequenceActor ReferenceKuroLevelSequence
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AKuroLevelSequenceActor>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_ReferenceKuroLevelSequence);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_ReferenceKuroLevelSequence, value);
		}
	}

	// Token: 0x17002540 RID: 9536
	// (get) Token: 0x0601BA45 RID: 113221 RVA: 0x0083E9E5 File Offset: 0x0083CBE5
	// (set) Token: 0x0601BA46 RID: 113222 RVA: 0x0083E9F9 File Offset: 0x0083CBF9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe USceneComponent Root
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_Root);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_Root, value);
		}
	}

	// Token: 0x17002541 RID: 9537
	// (get) Token: 0x0601BA47 RID: 113223 RVA: 0x0083EA0E File Offset: 0x0083CC0E
	// (set) Token: 0x0601BA48 RID: 113224 RVA: 0x0083EA22 File Offset: 0x0083CC22
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent IdleInnerBox1
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleInnerBox1);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleInnerBox1, value);
		}
	}

	// Token: 0x17002542 RID: 9538
	// (get) Token: 0x0601BA49 RID: 113225 RVA: 0x0083EA37 File Offset: 0x0083CC37
	// (set) Token: 0x0601BA4A RID: 113226 RVA: 0x0083EA4B File Offset: 0x0083CC4B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent IdleInnerBox2
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleInnerBox2);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleInnerBox2, value);
		}
	}

	// Token: 0x17002543 RID: 9539
	// (get) Token: 0x0601BA4B RID: 113227 RVA: 0x0083EA60 File Offset: 0x0083CC60
	// (set) Token: 0x0601BA4C RID: 113228 RVA: 0x0083EA74 File Offset: 0x0083CC74
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroPostProcessComponent IdleInnerPostProcess
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleInnerPostProcess);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleInnerPostProcess, value);
		}
	}

	// Token: 0x17002544 RID: 9540
	// (get) Token: 0x0601BA4D RID: 113229 RVA: 0x0083EA89 File Offset: 0x0083CC89
	// (set) Token: 0x0601BA4E RID: 113230 RVA: 0x0083EA9D File Offset: 0x0083CC9D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent IdleOuterBox1
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleOuterBox1);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleOuterBox1, value);
		}
	}

	// Token: 0x17002545 RID: 9541
	// (get) Token: 0x0601BA4F RID: 113231 RVA: 0x0083EAB2 File Offset: 0x0083CCB2
	// (set) Token: 0x0601BA50 RID: 113232 RVA: 0x0083EAC6 File Offset: 0x0083CCC6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent IdleOuterBox2
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleOuterBox2);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleOuterBox2, value);
		}
	}

	// Token: 0x17002546 RID: 9542
	// (get) Token: 0x0601BA51 RID: 113233 RVA: 0x0083EADB File Offset: 0x0083CCDB
	// (set) Token: 0x0601BA52 RID: 113234 RVA: 0x0083EAEF File Offset: 0x0083CCEF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroPostProcessComponent IdleOuterPostProcess
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleOuterPostProcess);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_IdleOuterPostProcess, value);
		}
	}

	// Token: 0x17002547 RID: 9543
	// (get) Token: 0x0601BA53 RID: 113235 RVA: 0x0083EB04 File Offset: 0x0083CD04
	// (set) Token: 0x0601BA54 RID: 113236 RVA: 0x0083EB18 File Offset: 0x0083CD18
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent FightingPhase1Box1
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase1Box1);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase1Box1, value);
		}
	}

	// Token: 0x17002548 RID: 9544
	// (get) Token: 0x0601BA55 RID: 113237 RVA: 0x0083EB2D File Offset: 0x0083CD2D
	// (set) Token: 0x0601BA56 RID: 113238 RVA: 0x0083EB41 File Offset: 0x0083CD41
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent FightingPhase1Box2
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase1Box2);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase1Box2, value);
		}
	}

	// Token: 0x17002549 RID: 9545
	// (get) Token: 0x0601BA57 RID: 113239 RVA: 0x0083EB56 File Offset: 0x0083CD56
	// (set) Token: 0x0601BA58 RID: 113240 RVA: 0x0083EB6A File Offset: 0x0083CD6A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroPostProcessComponent FightingPhase1PostProcess
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase1PostProcess);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase1PostProcess, value);
		}
	}

	// Token: 0x1700254A RID: 9546
	// (get) Token: 0x0601BA59 RID: 113241 RVA: 0x0083EB7F File Offset: 0x0083CD7F
	// (set) Token: 0x0601BA5A RID: 113242 RVA: 0x0083EB93 File Offset: 0x0083CD93
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent FightingPhase2Box1
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase2Box1);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase2Box1, value);
		}
	}

	// Token: 0x1700254B RID: 9547
	// (get) Token: 0x0601BA5B RID: 113243 RVA: 0x0083EBA8 File Offset: 0x0083CDA8
	// (set) Token: 0x0601BA5C RID: 113244 RVA: 0x0083EBBC File Offset: 0x0083CDBC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent FightingPhase2Box2
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase2Box2);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase2Box2, value);
		}
	}

	// Token: 0x1700254C RID: 9548
	// (get) Token: 0x0601BA5D RID: 113245 RVA: 0x0083EBD1 File Offset: 0x0083CDD1
	// (set) Token: 0x0601BA5E RID: 113246 RVA: 0x0083EBE5 File Offset: 0x0083CDE5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroPostProcessComponent FightingPhase2PostProcess
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase2PostProcess);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase2PostProcess, value);
		}
	}

	// Token: 0x1700254D RID: 9549
	// (get) Token: 0x0601BA5F RID: 113247 RVA: 0x0083EBFA File Offset: 0x0083CDFA
	// (set) Token: 0x0601BA60 RID: 113248 RVA: 0x0083EC0E File Offset: 0x0083CE0E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent FightingPhase3Box1
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase3Box1);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase3Box1, value);
		}
	}

	// Token: 0x1700254E RID: 9550
	// (get) Token: 0x0601BA61 RID: 113249 RVA: 0x0083EC23 File Offset: 0x0083CE23
	// (set) Token: 0x0601BA62 RID: 113250 RVA: 0x0083EC37 File Offset: 0x0083CE37
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent FightingPhase3Box2
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase3Box2);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase3Box2, value);
		}
	}

	// Token: 0x1700254F RID: 9551
	// (get) Token: 0x0601BA63 RID: 113251 RVA: 0x0083EC4C File Offset: 0x0083CE4C
	// (set) Token: 0x0601BA64 RID: 113252 RVA: 0x0083EC60 File Offset: 0x0083CE60
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroPostProcessComponent FightingPhase3PostProcess
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase3PostProcess);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_FightingPhase3PostProcess, value);
		}
	}

	// Token: 0x17002550 RID: 9552
	// (get) Token: 0x0601BA65 RID: 113253 RVA: 0x0083EC75 File Offset: 0x0083CE75
	// (set) Token: 0x0601BA66 RID: 113254 RVA: 0x0083EC89 File Offset: 0x0083CE89
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PDA_WuYinQuBattleData_C WuYinQuFightingData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PDA_WuYinQuBattleData_C>(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_WuYinQuFightingData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WuYinQuBattleActor.__PropertyOffset_WuYinQuFightingData, value);
		}
	}

	// Token: 0x0601BA67 RID: 113255 RVA: 0x0083ECA0 File Offset: 0x0083CEA0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 手动初始化()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("手动初始化"), out num);
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

	// Token: 0x0601BA68 RID: 113256 RVA: 0x0083ED10 File Offset: 0x0083CF10
	protected void 手动初始化_Implementation()
	{
		ControllerBase<RenderModuleController>.Instance.AddWuYinQuBattleActor(this);
	}

	// Token: 0x0601BA69 RID: 113257 RVA: 0x0083ED20 File Offset: 0x0083CF20
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 显示Debug线框()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("显示Debug线框"), out num);
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

	// Token: 0x0601BA6A RID: 113258 RVA: 0x0083ED90 File Offset: 0x0083CF90
	protected void 显示Debug线框_Implementation()
	{
		ControllerBase<RoleTriggerController>.Instance.DebugTestWorldDone();
		this.IdleOuterBox1.LineThickness = 20f;
		this.IdleOuterBox1.ShapeColor = new FColor(0, 223, 83, byte.MaxValue);
		this.IdleOuterBox1.SetHiddenInGame(false, false);
		this.IdleOuterBox2.LineThickness = 10f;
		this.IdleOuterBox2.ShapeColor = new FColor(0, 223, 83, byte.MaxValue);
		this.IdleOuterBox2.SetHiddenInGame(false, false);
		this.IdleInnerBox1.LineThickness = 20f;
		this.IdleInnerBox1.ShapeColor = new FColor(0, 223, 83, byte.MaxValue);
		this.IdleInnerBox1.SetHiddenInGame(false, false);
		this.IdleInnerBox2.LineThickness = 10f;
		this.IdleInnerBox2.ShapeColor = new FColor(0, 223, 83, byte.MaxValue);
		this.IdleInnerBox2.SetHiddenInGame(false, false);
	}

	// Token: 0x0601BA6B RID: 113259 RVA: 0x0083EE90 File Offset: 0x0083D090
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 切换到清空状态()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("切换到清空状态"), out num);
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

	// Token: 0x0601BA6C RID: 113260 RVA: 0x0083EF00 File Offset: 0x0083D100
	protected void 切换到清空状态_Implementation()
	{
		ControllerBase<RenderModuleController>.Instance.SetBattleState(this.GetKey(), EWuYinQuState.Nothing, false);
	}

	// Token: 0x0601BA6D RID: 113261 RVA: 0x0083EF14 File Offset: 0x0083D114
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 切换到静止状态()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("切换到静止状态"), out num);
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

	// Token: 0x0601BA6E RID: 113262 RVA: 0x0083EF84 File Offset: 0x0083D184
	protected void 切换到静止状态_Implementation()
	{
		ControllerBase<RenderModuleController>.Instance.SetBattleState(this.GetKey(), EWuYinQuState.StateIdle, false);
	}

	// Token: 0x0601BA6F RID: 113263 RVA: 0x0083EF98 File Offset: 0x0083D198
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 切换到战斗阶段1()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("切换到战斗阶段1"), out num);
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

	// Token: 0x0601BA70 RID: 113264 RVA: 0x0083F008 File Offset: 0x0083D208
	protected void 切换到战斗阶段1_Implementation()
	{
		ControllerBase<RenderModuleController>.Instance.SetBattleState(this.GetKey(), EWuYinQuState.StateFighting1, false);
	}

	// Token: 0x0601BA71 RID: 113265 RVA: 0x0083F01C File Offset: 0x0083D21C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 切换到战斗阶段2()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("切换到战斗阶段2"), out num);
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

	// Token: 0x0601BA72 RID: 113266 RVA: 0x0083F08C File Offset: 0x0083D28C
	protected void 切换到战斗阶段2_Implementation()
	{
		ControllerBase<RenderModuleController>.Instance.SetBattleState(this.GetKey(), EWuYinQuState.StateFighting2, false);
	}

	// Token: 0x0601BA73 RID: 113267 RVA: 0x0083F0A0 File Offset: 0x0083D2A0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void 切换到战斗阶段3()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("切换到战斗阶段3"), out num);
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

	// Token: 0x0601BA74 RID: 113268 RVA: 0x0083F110 File Offset: 0x0083D310
	protected void 切换到战斗阶段3_Implementation()
	{
		ControllerBase<RenderModuleController>.Instance.SetBattleState(this.GetKey(), EWuYinQuState.StateFighting3, false);
	}

	// Token: 0x0601BA75 RID: 113269 RVA: 0x0083F124 File Offset: 0x0083D324
	public unsafe void ChangeState(EWuYinQuState state, bool instantTransition = false)
	{
		if (!this.IsInit)
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderBattle, ELogAuthor.HCS, "没有初始化WuYinQuBattle: key:" + base.Key.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CurrentBattleState != state)
		{
			this.LastBattleState = this.CurrentBattleState;
			this.CurrentBattleState = state;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderBattle;
			ELogAuthor author = ELogAuthor.HCS;
			string message = "BOSS战切换状态 from:";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("fromState", this.LastBattleState);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("toState", this.CurrentBattleState);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (state == EWuYinQuState.StateIdle)
			{
				if (instantTransition)
				{
					this.StateMachine.Switch(EWuYinQuBattleState.Idle);
				}
				else
				{
					this.StateMachine.Switch(EWuYinQuBattleState.FightingToIdle);
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderBattle;
				ELogAuthor author2 = ELogAuthor.HCS;
				string message2 = "切换Fighting to Idle:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Key", base.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Instant", instantTransition);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			if (state == EWuYinQuState.StateFighting1)
			{
				if (instantTransition)
				{
					this.StateMachine.Switch(EWuYinQuBattleState.Fighting1);
				}
				else
				{
					this.StateMachine.Switch(EWuYinQuBattleState.IdleToFighting);
				}
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.RenderBattle;
				ELogAuthor author3 = ELogAuthor.HCS;
				string message3 = "切换Idle To Fighting1:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Key", base.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Instant", instantTransition);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				return;
			}
			if (state == EWuYinQuState.StateFighting2)
			{
				if (instantTransition)
				{
					this.StateMachine.Switch(EWuYinQuBattleState.Fighting2);
				}
				else
				{
					this.StateMachine.Switch(EWuYinQuBattleState.FightingToFighting);
				}
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.RenderBattle;
				ELogAuthor author4 = ELogAuthor.HCS;
				string message4 = "切换Fighting1 to Fighting2:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Key", base.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Instant", instantTransition);
				instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
				return;
			}
			if (state == EWuYinQuState.StateFighting3)
			{
				if (instantTransition)
				{
					this.StateMachine.Switch(EWuYinQuBattleState.Fighting3);
				}
				else
				{
					this.StateMachine.Switch(EWuYinQuBattleState.FightingToFighting);
				}
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.RenderBattle;
				ELogAuthor author5 = ELogAuthor.HCS;
				string message5 = "切换Fighting2 to Fighting3:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("Key", base.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("Instant", instantTransition);
				instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
			}
		}
	}

	// Token: 0x0601BA76 RID: 113270 RVA: 0x0083F41C File Offset: 0x0083D61C
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

	// Token: 0x0601BA77 RID: 113271 RVA: 0x0083F48C File Offset: 0x0083D68C
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		if (ModelManagerBase<ModelManager>.Instance.IsInit)
		{
			ControllerBase<RenderModuleController>.Instance.AddWuYinQuBattleActor(this);
			return;
		}
		ControllerBase<RenderModuleController>.Instance.AddWuYinQuBattleActorWaiting(this);
	}

	// Token: 0x0601BA78 RID: 113272 RVA: 0x0083F4B4 File Offset: 0x0083D6B4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BA79 RID: 113273 RVA: 0x0083F530 File Offset: 0x0083D730
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RenderBattle;
		ELogAuthor author = ELogAuthor.HCS;
		string message = "Receive End Play Battle Actor:";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Key", base.Key);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<RenderModuleController>.Instance.RemoveWuYinQuBattleActor(this);
		this.IsInit = false;
		this.是否已经初始化 = "无";
		this.CurrentBattleState = EWuYinQuState.StateIdle;
		this.LastBattleState = EWuYinQuState.StateIdle;
		if (this.IdleInnerPostProcessTrigger != null)
		{
			this.IdleInnerPostProcessTrigger.Dispose();
		}
		if (this.IdleOuterPostProcessTrigger != null)
		{
			this.IdleOuterPostProcessTrigger.Dispose();
		}
		if (this.FightingPhase1PostProcessTrigger != null)
		{
			this.FightingPhase1PostProcessTrigger.Dispose();
		}
		if (this.FightingPhase2PostProcessTrigger != null)
		{
			this.FightingPhase2PostProcessTrigger.Dispose();
		}
		if (this.FightingPhase3PostProcessTrigger != null)
		{
			this.FightingPhase3PostProcessTrigger.Dispose();
		}
	}

	// Token: 0x0601BA7A RID: 113274 RVA: 0x0083F5F9 File Offset: 0x0083D7F9
	public AKuroLevelSequenceActor GetKuroLevelSequenceActor()
	{
		if (UKismetSystemLibrary.IsValid(this.ReferenceKuroLevelSequence))
		{
			return this.ReferenceKuroLevelSequence;
		}
		return null;
	}

	// Token: 0x0601BA7B RID: 113275 RVA: 0x0083F610 File Offset: 0x0083D810
	public EWuYinQuState GetCurrentBattleState()
	{
		return this.CurrentBattleState;
	}

	// Token: 0x0601BA7C RID: 113276 RVA: 0x0083F618 File Offset: 0x0083D818
	public EWuYinQuState GetLastBattleState()
	{
		return this.LastBattleState;
	}

	// Token: 0x0601BA7D RID: 113277 RVA: 0x0083F620 File Offset: 0x0083D820
	public bool IsInitialize()
	{
		return this.IsInit;
	}

	// Token: 0x0601BA7E RID: 113278 RVA: 0x0083F628 File Offset: 0x0083D828
	[NullableContext(1)]
	public string GetKey()
	{
		if (this.StringKey == null)
		{
			this.StringKey = base.Key.ToString();
		}
		return this.StringKey;
	}

	// Token: 0x0601BA7F RID: 113279 RVA: 0x0083F660 File Offset: 0x0083D860
	public void Tick(float delta)
	{
		if (!this.IsInit)
		{
			return;
		}
		this.StateMachine.Update(delta);
		if (this.IdleInnerPostProcessTrigger != null)
		{
			this.IdleInnerPostProcessTrigger.Tick(delta);
		}
		if (this.IdleOuterPostProcessTrigger != null)
		{
			this.IdleOuterPostProcessTrigger.Tick(delta);
		}
		if (this.FightingPhase1PostProcessTrigger != null)
		{
			this.FightingPhase1PostProcessTrigger.Tick(delta);
		}
		if (this.FightingPhase2PostProcessTrigger != null)
		{
			this.FightingPhase2PostProcessTrigger.Tick(delta);
		}
		if (this.FightingPhase3PostProcessTrigger != null)
		{
			this.FightingPhase3PostProcessTrigger.Tick(delta);
		}
	}

	// Token: 0x0601BA80 RID: 113280 RVA: 0x0083F6E8 File Offset: 0x0083D8E8
	public bool Init()
	{
		if (this.IsInit)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderBattle;
			ELogAuthor author = ELogAuthor.HCS;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
			defaultInterpolatedStringHandler.AppendLiteral("已经初始化过了 handleId: Key:");
			defaultInterpolatedStringHandler.AppendFormatted<FName>(base.Key);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (!UKismetSystemLibrary.IsValid(this.WuYinQuFightingData))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderBattle;
			ELogAuthor author2 = ELogAuthor.HCS;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("无音区战斗数据无效 handleId: Key:");
			defaultInterpolatedStringHandler.AppendFormatted<FName>(base.Key);
			instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.CurrentBattleState = EWuYinQuState.StateIdle;
		this.LastBattleState = EWuYinQuState.StateIdle;
		this.StateMachine = new StateMachine<WuYinQuBattleActor, EWuYinQuBattleState>(this, null);
		this.StateMachine.AddState<WuYinQuBattleStateIdle>(EWuYinQuBattleState.Idle, null);
		this.StateMachine.AddState<WuYinQuBattleStateFighting1>(EWuYinQuBattleState.Fighting1, null);
		this.StateMachine.AddState<WuYinQuBattleStateFighting2>(EWuYinQuBattleState.Fighting2, null);
		this.StateMachine.AddState<WuYinQuBattleStateFighting3>(EWuYinQuBattleState.Fighting3, null);
		this.StateMachine.AddState<WuYinQuBattleStateIdleToFighting>(EWuYinQuBattleState.IdleToFighting, null);
		this.StateMachine.AddState<WuYinQuBattleStateFightingToFighting>(EWuYinQuBattleState.FightingToFighting, null);
		this.StateMachine.AddState<WuYinQuBattleStateFightingToIdle>(EWuYinQuBattleState.FightingToIdle, null);
		this.InitComponents();
		this.StateMachine.Start(EWuYinQuBattleState.Idle);
		this.IsInit = true;
		this.是否已经初始化 = "已经初始化";
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.RenderBattle;
		ELogAuthor author3 = ELogAuthor.HCS;
		string message = "初始化无音区状态成功:";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Key", this.GetKey());
		instance3.Info(module3, author3, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return true;
	}

	// Token: 0x0601BA81 RID: 113281 RVA: 0x0083F858 File Offset: 0x0083DA58
	private void InitComponents()
	{
		this.IdleInnerPostProcess.BlendWeight = 0f;
		this.IdleInnerPostProcess.bUnbound = true;
		this.IdleOuterPostProcess.BlendWeight = 0f;
		this.IdleOuterPostProcess.bUnbound = true;
		this.FightingPhase1PostProcess.BlendWeight = 0f;
		this.FightingPhase1PostProcess.bUnbound = true;
		this.FightingPhase2PostProcess.BlendWeight = 0f;
		this.FightingPhase2PostProcess.bUnbound = true;
		this.FightingPhase3PostProcess.BlendWeight = 0f;
		this.FightingPhase3PostProcess.bUnbound = true;
		PDA_WuYinQuBattleData_C wuYinQuFightingData = this.WuYinQuFightingData;
		bool flag;
		if (wuYinQuFightingData == null)
		{
			flag = false;
		}
		else
		{
			PDA_WuYinQuBattleIdleData_C wuYinQuIdleData = wuYinQuFightingData.WuYinQuIdleData;
			flag = ((wuYinQuIdleData != null) ? new bool?(wuYinQuIdleData.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			this.IdleInnerPostProcess.WeatherDataAsset = this.WuYinQuFightingData.WuYinQuIdleData.AtmosInnerData;
			UKuroWeatherDataAsset weatherDataAsset = this.IdleInnerPostProcess.WeatherDataAsset;
			if (weatherDataAsset != null && weatherDataAsset.IsValid())
			{
				float triggerInnerSize = this.WuYinQuFightingData.TriggerInnerSize;
				FVectorDouble newScale3D = new FVectorDouble((double)(triggerInnerSize + WuYinQuBattleConfig.TriggerThreshold.X), (double)(triggerInnerSize + WuYinQuBattleConfig.TriggerThreshold.Y), (double)(triggerInnerSize + WuYinQuBattleConfig.TriggerThreshold.Z));
				this.IdleInnerBox1.D_SetRelativeScale3D(new FVectorDouble((double)triggerInnerSize, (double)triggerInnerSize, (double)triggerInnerSize));
				this.IdleInnerBox2.D_SetRelativeScale3D(newScale3D);
				this.IdleInnerPostProcessTrigger = new PostProcessTrigger();
				this.IdleInnerPostProcessTrigger.Init(this.IdleInnerBox1, this.IdleInnerBox2, this.IdleInnerPostProcess, 3.5, EWuYinQuState.StateIdle, this.GetKey());
			}
			this.IdleOuterPostProcess.WeatherDataAsset = this.WuYinQuFightingData.WuYinQuIdleData.AtmosOuterData;
			UKuroWeatherDataAsset weatherDataAsset2 = this.IdleOuterPostProcess.WeatherDataAsset;
			if (weatherDataAsset2 != null && weatherDataAsset2.IsValid())
			{
				float triggerOuterSize = this.WuYinQuFightingData.TriggerOuterSize;
				FVectorDouble newScale3D2 = new FVectorDouble((double)(triggerOuterSize + WuYinQuBattleConfig.TriggerThreshold.X), (double)(triggerOuterSize + WuYinQuBattleConfig.TriggerThreshold.Y), (double)(triggerOuterSize + WuYinQuBattleConfig.TriggerThreshold.Z));
				this.IdleOuterBox1.D_SetRelativeScale3D(new FVectorDouble((double)triggerOuterSize, (double)triggerOuterSize, (double)triggerOuterSize));
				this.IdleOuterBox2.D_SetRelativeScale3D(newScale3D2);
				this.IdleOuterPostProcessTrigger = new PostProcessTrigger();
				this.IdleOuterPostProcessTrigger.Init(this.IdleOuterBox1, this.IdleOuterBox2, this.IdleOuterPostProcess, 3.5, EWuYinQuState.StateIdle, this.GetKey());
			}
		}
		PDA_WuYinQuBattleData_C wuYinQuFightingData2 = this.WuYinQuFightingData;
		bool flag2;
		if (wuYinQuFightingData2 == null)
		{
			flag2 = false;
		}
		else
		{
			PDA_WuYinQuBattleFightingData_C wuYinQuFightingData3 = wuYinQuFightingData2.WuYinQuFightingData1;
			flag2 = ((wuYinQuFightingData3 != null) ? new bool?(wuYinQuFightingData3.IsValid()) : null).GetValueOrDefault();
		}
		if (flag2)
		{
			this.FightingPhase1PostProcess.WeatherDataAsset = this.WuYinQuFightingData.WuYinQuFightingData1.AtmosFightingData;
			UKuroWeatherDataAsset weatherDataAsset3 = this.FightingPhase1PostProcess.WeatherDataAsset;
			if (weatherDataAsset3 != null && weatherDataAsset3.IsValid())
			{
				float triggerOuterSize2 = this.WuYinQuFightingData.TriggerOuterSize;
				FVectorDouble newScale3D3 = new FVectorDouble((double)(triggerOuterSize2 + WuYinQuBattleConfig.TriggerThreshold.X), (double)(triggerOuterSize2 + WuYinQuBattleConfig.TriggerThreshold.Y), (double)(triggerOuterSize2 + WuYinQuBattleConfig.TriggerThreshold.Z));
				this.FightingPhase1Box1.D_SetRelativeScale3D(new FVectorDouble((double)triggerOuterSize2, (double)triggerOuterSize2, (double)triggerOuterSize2));
				this.FightingPhase1Box2.D_SetRelativeScale3D(newScale3D3);
				this.FightingPhase1PostProcessTrigger = new PostProcessTrigger();
				this.FightingPhase1PostProcessTrigger.Init(this.FightingPhase1Box1, this.FightingPhase1Box2, this.FightingPhase1PostProcess, 3.5, EWuYinQuState.StateFighting1, this.GetKey());
			}
		}
		PDA_WuYinQuBattleData_C wuYinQuFightingData4 = this.WuYinQuFightingData;
		bool flag3;
		if (wuYinQuFightingData4 == null)
		{
			flag3 = false;
		}
		else
		{
			PDA_WuYinQuBattleFightingData_C wuYinQuFightingData5 = wuYinQuFightingData4.WuYinQuFightingData2;
			flag3 = ((wuYinQuFightingData5 != null) ? new bool?(wuYinQuFightingData5.IsValid()) : null).GetValueOrDefault();
		}
		if (flag3)
		{
			this.FightingPhase2PostProcess.WeatherDataAsset = this.WuYinQuFightingData.WuYinQuFightingData2.AtmosFightingData;
			UKuroWeatherDataAsset weatherDataAsset4 = this.FightingPhase2PostProcess.WeatherDataAsset;
			if (weatherDataAsset4 != null && weatherDataAsset4.IsValid())
			{
				float triggerOuterSize3 = this.WuYinQuFightingData.TriggerOuterSize;
				FVectorDouble newScale3D4 = new FVectorDouble((double)(triggerOuterSize3 + WuYinQuBattleConfig.TriggerThreshold.X), (double)(triggerOuterSize3 + WuYinQuBattleConfig.TriggerThreshold.Y), (double)(triggerOuterSize3 + WuYinQuBattleConfig.TriggerThreshold.Z));
				this.FightingPhase2Box1.D_SetRelativeScale3D(new FVectorDouble((double)triggerOuterSize3, (double)triggerOuterSize3, (double)triggerOuterSize3));
				this.FightingPhase2Box2.D_SetRelativeScale3D(newScale3D4);
				this.FightingPhase2PostProcessTrigger = new PostProcessTrigger();
				this.FightingPhase2PostProcessTrigger.Init(this.FightingPhase2Box1, this.FightingPhase2Box2, this.FightingPhase2PostProcess, 3.5, EWuYinQuState.StateFighting2, this.GetKey());
			}
		}
		PDA_WuYinQuBattleData_C wuYinQuFightingData6 = this.WuYinQuFightingData;
		bool flag4;
		if (wuYinQuFightingData6 == null)
		{
			flag4 = false;
		}
		else
		{
			PDA_WuYinQuBattleFightingData_C wuYinQuFightingData7 = wuYinQuFightingData6.WuYinQuFightingData3;
			flag4 = ((wuYinQuFightingData7 != null) ? new bool?(wuYinQuFightingData7.IsValid()) : null).GetValueOrDefault();
		}
		if (flag4)
		{
			this.FightingPhase3PostProcess.WeatherDataAsset = this.WuYinQuFightingData.WuYinQuFightingData3.AtmosFightingData;
			UKuroWeatherDataAsset weatherDataAsset5 = this.FightingPhase3PostProcess.WeatherDataAsset;
			if (weatherDataAsset5 != null && weatherDataAsset5.IsValid())
			{
				float triggerOuterSize4 = this.WuYinQuFightingData.TriggerOuterSize;
				FVectorDouble newScale3D5 = new FVectorDouble((double)(triggerOuterSize4 + WuYinQuBattleConfig.TriggerThreshold.X), (double)(triggerOuterSize4 + WuYinQuBattleConfig.TriggerThreshold.Y), (double)(triggerOuterSize4 + WuYinQuBattleConfig.TriggerThreshold.Z));
				this.FightingPhase3Box1.D_SetRelativeScale3D(new FVectorDouble((double)triggerOuterSize4, (double)triggerOuterSize4, (double)triggerOuterSize4));
				this.FightingPhase3Box2.D_SetRelativeScale3D(newScale3D5);
				this.FightingPhase3PostProcessTrigger = new PostProcessTrigger();
				this.FightingPhase3PostProcessTrigger.Init(this.FightingPhase3Box1, this.FightingPhase3Box2, this.FightingPhase3PostProcess, 3.5, EWuYinQuState.StateFighting3, this.GetKey());
			}
		}
	}

	// Token: 0x0601BA82 RID: 113282 RVA: 0x0083FDE1 File Offset: 0x0083DFE1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (WuYinQuBattleActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Battle/WuYinQuBattleActor.WuYinQuBattleActor_C");
		}
		return WuYinQuBattleActor._ClassPtr;
	}

	// Token: 0x0601BA83 RID: 113283 RVA: 0x0083FE08 File Offset: 0x0083E008
	public WuYinQuBattleActor() : this(BuiltinUtils.AllocNativeUObject(WuYinQuBattleActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BA84 RID: 113284 RVA: 0x0083FE30 File Offset: 0x0083E030
	[NullableContext(1)]
	public WuYinQuBattleActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WuYinQuBattleActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BA85 RID: 113285 RVA: 0x0083FE63 File Offset: 0x0083E063
	protected WuYinQuBattleActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BA86 RID: 113286 RVA: 0x0083FE7A File Offset: 0x0083E07A
	protected virtual void __CPPCALL_手动初始化_Implementation()
	{
		this.手动初始化_Implementation();
	}

	// Token: 0x0601BA87 RID: 113287 RVA: 0x0083FE82 File Offset: 0x0083E082
	protected virtual void __CPPCALL_显示Debug线框_Implementation()
	{
		this.显示Debug线框_Implementation();
	}

	// Token: 0x0601BA88 RID: 113288 RVA: 0x0083FE8A File Offset: 0x0083E08A
	protected virtual void __CPPCALL_切换到清空状态_Implementation()
	{
		this.切换到清空状态_Implementation();
	}

	// Token: 0x0601BA89 RID: 113289 RVA: 0x0083FE92 File Offset: 0x0083E092
	protected virtual void __CPPCALL_切换到静止状态_Implementation()
	{
		this.切换到静止状态_Implementation();
	}

	// Token: 0x0601BA8A RID: 113290 RVA: 0x0083FE9A File Offset: 0x0083E09A
	protected virtual void __CPPCALL_切换到战斗阶段1_Implementation()
	{
		this.切换到战斗阶段1_Implementation();
	}

	// Token: 0x0601BA8B RID: 113291 RVA: 0x0083FEA2 File Offset: 0x0083E0A2
	protected virtual void __CPPCALL_切换到战斗阶段2_Implementation()
	{
		this.切换到战斗阶段2_Implementation();
	}

	// Token: 0x0601BA8C RID: 113292 RVA: 0x0083FEAA File Offset: 0x0083E0AA
	protected virtual void __CPPCALL_切换到战斗阶段3_Implementation()
	{
		this.切换到战斗阶段3_Implementation();
	}

	// Token: 0x0601BA8D RID: 113293 RVA: 0x0083FEB2 File Offset: 0x0083E0B2
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601BA8E RID: 113294 RVA: 0x0083FEBC File Offset: 0x0083E0BC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0400DF99 RID: 57241
	private EWuYinQuState CurrentBattleState = EWuYinQuState.Nothing;

	// Token: 0x0400DF9A RID: 57242
	private EWuYinQuState LastBattleState = EWuYinQuState.Nothing;

	// Token: 0x0400DF9B RID: 57243
	private bool IsInit;

	// Token: 0x0400DF9C RID: 57244
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private StateMachine<WuYinQuBattleActor, EWuYinQuBattleState> StateMachine;

	// Token: 0x0400DF9D RID: 57245
	private PostProcessTrigger IdleInnerPostProcessTrigger;

	// Token: 0x0400DF9E RID: 57246
	private PostProcessTrigger IdleOuterPostProcessTrigger;

	// Token: 0x0400DF9F RID: 57247
	private PostProcessTrigger FightingPhase1PostProcessTrigger;

	// Token: 0x0400DFA0 RID: 57248
	private PostProcessTrigger FightingPhase2PostProcessTrigger;

	// Token: 0x0400DFA1 RID: 57249
	private PostProcessTrigger FightingPhase3PostProcessTrigger;

	// Token: 0x0400DFA2 RID: 57250
	private string StringKey;

	// Token: 0x0400DFA3 RID: 57251
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Battle/WuYinQuBattleActor.WuYinQuBattleActor_C";

	// Token: 0x0400DFA4 RID: 57252
	private static IntPtr _ClassPtr;

	// Token: 0x0400DFA5 RID: 57253
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DFA6 RID: 57254
	private static int __PropertyOffset_当前状态;

	// Token: 0x0400DFA7 RID: 57255
	private static int __PropertyOffset_是否已经初始化;

	// Token: 0x0400DFA8 RID: 57256
	private static int __PropertyOffset_ReferenceKuroLevelSequence;

	// Token: 0x0400DFA9 RID: 57257
	private static int __PropertyOffset_Root;

	// Token: 0x0400DFAA RID: 57258
	private static int __PropertyOffset_IdleInnerBox1;

	// Token: 0x0400DFAB RID: 57259
	private static int __PropertyOffset_IdleInnerBox2;

	// Token: 0x0400DFAC RID: 57260
	private static int __PropertyOffset_IdleInnerPostProcess;

	// Token: 0x0400DFAD RID: 57261
	private static int __PropertyOffset_IdleOuterBox1;

	// Token: 0x0400DFAE RID: 57262
	private static int __PropertyOffset_IdleOuterBox2;

	// Token: 0x0400DFAF RID: 57263
	private static int __PropertyOffset_IdleOuterPostProcess;

	// Token: 0x0400DFB0 RID: 57264
	private static int __PropertyOffset_FightingPhase1Box1;

	// Token: 0x0400DFB1 RID: 57265
	private static int __PropertyOffset_FightingPhase1Box2;

	// Token: 0x0400DFB2 RID: 57266
	private static int __PropertyOffset_FightingPhase1PostProcess;

	// Token: 0x0400DFB3 RID: 57267
	private static int __PropertyOffset_FightingPhase2Box1;

	// Token: 0x0400DFB4 RID: 57268
	private static int __PropertyOffset_FightingPhase2Box2;

	// Token: 0x0400DFB5 RID: 57269
	private static int __PropertyOffset_FightingPhase2PostProcess;

	// Token: 0x0400DFB6 RID: 57270
	private static int __PropertyOffset_FightingPhase3Box1;

	// Token: 0x0400DFB7 RID: 57271
	private static int __PropertyOffset_FightingPhase3Box2;

	// Token: 0x0400DFB8 RID: 57272
	private static int __PropertyOffset_FightingPhase3PostProcess;

	// Token: 0x0400DFB9 RID: 57273
	private static int __PropertyOffset_WuYinQuFightingData;
}
