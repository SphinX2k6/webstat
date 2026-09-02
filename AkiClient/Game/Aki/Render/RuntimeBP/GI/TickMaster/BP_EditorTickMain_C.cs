using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.TickMaster
{
	// Token: 0x02003CAA RID: 15530
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/TickMaster/BP_EditorTickMain.BP_EditorTickMain_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1348)]
	public class BP_EditorTickMain_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_EditorTickMaster_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x060249F3 RID: 150003 RVA: 0x009A3072 File Offset: 0x009A1272
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EditorTickMain_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/TickMaster/BP_EditorTickMain.BP_EditorTickMain_C");
			}
			return BP_EditorTickMain_C._ClassPtr;
		}

		// Token: 0x060249F4 RID: 150004 RVA: 0x009A3098 File Offset: 0x009A1298
		public BP_EditorTickMain_C() : this(BuiltinUtils.AllocNativeUObject(BP_EditorTickMain_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060249F5 RID: 150005 RVA: 0x009A30C0 File Offset: 0x009A12C0
		[NullableContext(1)]
		public BP_EditorTickMain_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EditorTickMain_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004D04 RID: 19716
		// (get) Token: 0x060249F6 RID: 150006 RVA: 0x009A30F4 File Offset: 0x009A12F4
		// (set) Token: 0x060249F7 RID: 150007 RVA: 0x009A312D File Offset: 0x009A132D
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_EditorTickMain_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_EditorTickMain_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D05 RID: 19717
		// (get) Token: 0x060249F8 RID: 150008 RVA: 0x009A314E File Offset: 0x009A134E
		// (set) Token: 0x060249F9 RID: 150009 RVA: 0x009A3162 File Offset: 0x009A1362
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EditorTickMain_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EditorTickMain_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004D06 RID: 19718
		// (get) Token: 0x060249FA RID: 150010 RVA: 0x009A3178 File Offset: 0x009A1378
		// (set) Token: 0x060249FB RID: 150011 RVA: 0x009A31B1 File Offset: 0x009A13B1
		[Nullable(1)]
		public TArray<AActor> CallingActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._CallingActors) == null)
				{
					result = (this._CallingActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_EditorTickMain_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CallingActors.CopyAssign(value);
			}
		}

		// Token: 0x17004D07 RID: 19719
		// (get) Token: 0x060249FC RID: 150012 RVA: 0x009A31BF File Offset: 0x009A13BF
		// (set) Token: 0x060249FD RID: 150013 RVA: 0x009A31D3 File Offset: 0x009A13D3
		public unsafe FColor Tick_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_EditorTickMain_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_EditorTickMain_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x060249FE RID: 150014 RVA: 0x009A31E8 File Offset: 0x009A13E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EditorTickMain_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060249FF RID: 150015 RVA: 0x009A31FC File Offset: 0x009A13FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EditorTickMain_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024A00 RID: 150016 RVA: 0x009A3214 File Offset: 0x009A1414
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EditorTickMaster(float DeltaTime)
		{
			BP_EditorTickMain_C.__EditorTickMaster_FunctionParams* ptr = stackalloc BP_EditorTickMain_C.__EditorTickMaster_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EditorTickMain_C.__EditorTickMaster_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EditorTickMain_C.__EditorTickMaster_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EditorTickMain_C.__EditorTickMaster_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024A01 RID: 150017 RVA: 0x009A325C File Offset: 0x009A145C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_EditorTickMain_C.__EditorTick_FunctionParams* ptr = stackalloc BP_EditorTickMain_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EditorTickMain_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EditorTickMain_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EditorTickMain_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024A02 RID: 150018 RVA: 0x009A32A4 File Offset: 0x009A14A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_EditorTickMain_C.__EditorTick_FunctionParams* ptr = stackalloc BP_EditorTickMain_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_EditorTickMain_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EditorTickMain_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EditorTickMain_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024A03 RID: 150019 RVA: 0x009A32EC File Offset: 0x009A14EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_EditorTickMain(int EntryPoint)
		{
			BP_EditorTickMain_C.__ExecuteUbergraph_BP_EditorTickMain_FunctionParams* ptr = stackalloc BP_EditorTickMain_C.__ExecuteUbergraph_BP_EditorTickMain_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_EditorTickMain_C.__ExecuteUbergraph_BP_EditorTickMain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EditorTickMain_C.__ExecuteUbergraph_BP_EditorTickMain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_EditorTickMain_C.__ExecuteUbergraph_BP_EditorTickMain_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024A04 RID: 150020 RVA: 0x009A3333 File Offset: 0x009A1533
		protected BP_EditorTickMain_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C70 RID: 76912
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/TickMaster/BP_EditorTickMain.BP_EditorTickMain_C";

		// Token: 0x04012C71 RID: 76913
		private static IntPtr _ClassPtr;

		// Token: 0x04012C72 RID: 76914
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C73 RID: 76915
		internal static int __PropertyOffset_0;

		// Token: 0x04012C74 RID: 76916
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012C75 RID: 76917
		internal static int __PropertyOffset_1;

		// Token: 0x04012C76 RID: 76918
		internal static int __PropertyOffset_2;

		// Token: 0x04012C77 RID: 76919
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _CallingActors;

		// Token: 0x04012C78 RID: 76920
		internal static int __PropertyOffset_3;

		// Token: 0x04012C79 RID: 76921
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012C7A RID: 76922
		private static IntPtr __EditorTickMaster_NativeFunctionPtr;

		// Token: 0x04012C7B RID: 76923
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012C7C RID: 76924
		private static IntPtr __ExecuteUbergraph_BP_EditorTickMain_NativeFunctionPtr;

		// Token: 0x02009E24 RID: 40484
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __EditorTickMaster_FunctionParams
		{
			// Token: 0x04032870 RID: 206960
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009E25 RID: 40485
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032871 RID: 206961
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E26 RID: 40486
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_EditorTickMain_FunctionParams
		{
			// Token: 0x04032872 RID: 206962
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
