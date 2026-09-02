using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002948 RID: 10568
[UClass("/Game/Aki/TypeScript/Game/Module/Scene3DUI/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/Scene3DUI/TsSceneDecorativeUiActor.TsSceneDecorativeUiActor_C")]
public class TsSceneDecorativeUiActor : TsSceneUiTag, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001B84 RID: 7044
	// (get) Token: 0x06014FEF RID: 85999 RVA: 0x005CF051 File Offset: 0x005CD251
	// (set) Token: 0x06014FF0 RID: 86000 RVA: 0x005CF061 File Offset: 0x005CD261
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ShowDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSceneDecorativeUiActor.__PropertyOffset_ShowDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSceneDecorativeUiActor.__PropertyOffset_ShowDistance) = value;
		}
	}

	// Token: 0x17001B85 RID: 7045
	// (get) Token: 0x06014FF1 RID: 86001 RVA: 0x005CF072 File Offset: 0x005CD272
	// (set) Token: 0x06014FF2 RID: 86002 RVA: 0x005CF082 File Offset: 0x005CD282
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsFaceToCharacter
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsSceneDecorativeUiActor.__PropertyOffset_IsFaceToCharacter) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsSceneDecorativeUiActor.__PropertyOffset_IsFaceToCharacter) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001B86 RID: 7046
	// (get) Token: 0x06014FF3 RID: 86003 RVA: 0x005CF093 File Offset: 0x005CD293
	// (set) Token: 0x06014FF4 RID: 86004 RVA: 0x005CF09B File Offset: 0x005CD29B
	public bool IsControlled
	{
		get
		{
			return this.IsControlledInternal;
		}
		set
		{
			this.IsControlledInternal = value;
		}
	}

	// Token: 0x17001B87 RID: 7047
	// (get) Token: 0x06014FF5 RID: 86005 RVA: 0x005CF0A4 File Offset: 0x005CD2A4
	// (set) Token: 0x06014FF6 RID: 86006 RVA: 0x005CF0AC File Offset: 0x005CD2AC
	public bool InShow
	{
		get
		{
			return this.InShowInternal;
		}
		set
		{
			this.InShowInternal = value;
		}
	}

	// Token: 0x06014FF7 RID: 86007 RVA: 0x005CF0B8 File Offset: 0x005CD2B8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Create3dUi()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Create3dUi"), out num);
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

	// Token: 0x06014FF8 RID: 86008 RVA: 0x005CF128 File Offset: 0x005CD328
	protected void Create3dUi_Implementation()
	{
	}

	// Token: 0x06014FF9 RID: 86009 RVA: 0x005CF12C File Offset: 0x005CD32C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Destroy3dUi()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Destroy3dUi"), out num);
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

	// Token: 0x06014FFA RID: 86010 RVA: 0x005CF19C File Offset: 0x005CD39C
	protected void Destroy3dUi_Implementation()
	{
		if (this.EditorUiActor != null)
		{
			Singleton<ActorSystem>.Instance.Put("TsSceneDecorativeUiActor.Destroy3dUi", this.EditorUiActor, null);
			this.EditorUiActor = null;
		}
	}

	// Token: 0x06014FFB RID: 86011 RVA: 0x005CF1C4 File Offset: 0x005CD3C4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void DrawDistance()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DrawDistance"), out num);
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

	// Token: 0x06014FFC RID: 86012 RVA: 0x005CF234 File Offset: 0x005CD434
	protected void DrawDistance_Implementation()
	{
		int segments = 12;
		int num = 5;
		UKismetSystemLibrary.D_DrawDebugSphere(this, base.D_K2_GetActorLocation(), this.ShowDistance, segments, new FLinearColor?(ColorUtils.LinearRed), (float)num, 0f);
	}

	// Token: 0x06014FFD RID: 86013 RVA: 0x005CF26A File Offset: 0x005CD46A
	protected override bool OnCanTick()
	{
		return !this.IsControlled && base.CalculateSquaredDistance() <= (double)(this.ShowDistance * this.ShowDistance);
	}

	// Token: 0x06014FFE RID: 86014 RVA: 0x005CF28F File Offset: 0x005CD48F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSceneDecorativeUiActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/Scene3DUI/TsSceneDecorativeUiActor.TsSceneDecorativeUiActor_C");
		}
		return TsSceneDecorativeUiActor._ClassPtr;
	}

	// Token: 0x06014FFF RID: 86015 RVA: 0x005CF2B4 File Offset: 0x005CD4B4
	public TsSceneDecorativeUiActor() : this(BuiltinUtils.AllocNativeUObject(TsSceneDecorativeUiActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06015000 RID: 86016 RVA: 0x005CF2DC File Offset: 0x005CD4DC
	[NullableContext(1)]
	public TsSceneDecorativeUiActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSceneDecorativeUiActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06015001 RID: 86017 RVA: 0x005CF30F File Offset: 0x005CD50F
	protected TsSceneDecorativeUiActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06015002 RID: 86018 RVA: 0x005CF318 File Offset: 0x005CD518
	protected virtual void __CPPCALL_Create3dUi_Implementation()
	{
		this.Create3dUi_Implementation();
	}

	// Token: 0x06015003 RID: 86019 RVA: 0x005CF320 File Offset: 0x005CD520
	protected virtual void __CPPCALL_Destroy3dUi_Implementation()
	{
		this.Destroy3dUi_Implementation();
	}

	// Token: 0x06015004 RID: 86020 RVA: 0x005CF328 File Offset: 0x005CD528
	protected virtual void __CPPCALL_DrawDistance_Implementation()
	{
		this.DrawDistance_Implementation();
	}

	// Token: 0x0400A1AE RID: 41390
	private bool IsControlledInternal;

	// Token: 0x0400A1AF RID: 41391
	private bool InShowInternal;

	// Token: 0x0400A1B0 RID: 41392
	[Nullable(2)]
	private AActor EditorUiActor;

	// Token: 0x0400A1B1 RID: 41393
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/Scene3DUI/TsSceneDecorativeUiActor.TsSceneDecorativeUiActor_C";

	// Token: 0x0400A1B2 RID: 41394
	private static IntPtr _ClassPtr;

	// Token: 0x0400A1B3 RID: 41395
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400A1B4 RID: 41396
	private static int __PropertyOffset_ShowDistance;

	// Token: 0x0400A1B5 RID: 41397
	private static int __PropertyOffset_IsFaceToCharacter;
}
