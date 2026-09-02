using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneInteraction.FruitTree
{
	// Token: 0x02003B2E RID: 15150
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneInteraction/FruitTree/BP_FruitTreeInteraction.BP_FruitTreeInteraction_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1344)]
	public class BP_FruitTreeInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020ABD RID: 133821 RVA: 0x009338AB File Offset: 0x00931AAB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FruitTreeInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneInteraction/FruitTree/BP_FruitTreeInteraction.BP_FruitTreeInteraction_C");
			}
			return BP_FruitTreeInteraction_C._ClassPtr;
		}

		// Token: 0x06020ABE RID: 133822 RVA: 0x009338D0 File Offset: 0x00931AD0
		public BP_FruitTreeInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_FruitTreeInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020ABF RID: 133823 RVA: 0x009338F8 File Offset: 0x00931AF8
		[NullableContext(1)]
		public BP_FruitTreeInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FruitTreeInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036A6 RID: 13990
		// (get) Token: 0x06020AC0 RID: 133824 RVA: 0x0093392C File Offset: 0x00931B2C
		// (set) Token: 0x06020AC1 RID: 133825 RVA: 0x00933965 File Offset: 0x00931B65
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FruitTreeInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FruitTreeInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036A7 RID: 13991
		// (get) Token: 0x06020AC2 RID: 133826 RVA: 0x00933986 File Offset: 0x00931B86
		// (set) Token: 0x06020AC3 RID: 133827 RVA: 0x0093399A File Offset: 0x00931B9A
		public unsafe UStaticMeshComponent TrunkMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036A8 RID: 13992
		// (get) Token: 0x06020AC4 RID: 133828 RVA: 0x009339AF File Offset: 0x00931BAF
		// (set) Token: 0x06020AC5 RID: 133829 RVA: 0x009339C3 File Offset: 0x00931BC3
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036A9 RID: 13993
		// (get) Token: 0x06020AC6 RID: 133830 RVA: 0x009339D8 File Offset: 0x00931BD8
		// (set) Token: 0x06020AC7 RID: 133831 RVA: 0x009339EC File Offset: 0x00931BEC
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170036AA RID: 13994
		// (get) Token: 0x06020AC8 RID: 133832 RVA: 0x00933A01 File Offset: 0x00931C01
		// (set) Token: 0x06020AC9 RID: 133833 RVA: 0x00933A15 File Offset: 0x00931C15
		public unsafe UHoudiniPointCache HPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FruitTreeInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x06020ACA RID: 133834 RVA: 0x00933A2A File Offset: 0x00931C2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020ACB RID: 133835 RVA: 0x00933A3E File Offset: 0x00931C3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FruitTreeInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020ACC RID: 133836 RVA: 0x00933A54 File Offset: 0x00931C54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnApplyWorldOffset(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_FruitTreeInteraction_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_FruitTreeInteraction_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_FruitTreeInteraction_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteraction_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FruitTreeInteraction_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020ACD RID: 133837 RVA: 0x00933AA8 File Offset: 0x00931CA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnApplyWorldOffset_Implementation(in FVector InWorldOffset, bool bWorldShift)
		{
			BP_FruitTreeInteraction_C.__OnApplyWorldOffset_FunctionParams* ptr = stackalloc BP_FruitTreeInteraction_C.__OnApplyWorldOffset_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_FruitTreeInteraction_C.__OnApplyWorldOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteraction_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InWorldOffset = InWorldOffset;
			ptr->bWorldShift = bWorldShift;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FruitTreeInteraction_C.__OnApplyWorldOffset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020ACE RID: 133838 RVA: 0x00933AFC File Offset: 0x00931CFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FruitTreeInteraction(int EntryPoint)
		{
			BP_FruitTreeInteraction_C.__ExecuteUbergraph_BP_FruitTreeInteraction_FunctionParams* ptr = stackalloc BP_FruitTreeInteraction_C.__ExecuteUbergraph_BP_FruitTreeInteraction_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_FruitTreeInteraction_C.__ExecuteUbergraph_BP_FruitTreeInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FruitTreeInteraction_C.__ExecuteUbergraph_BP_FruitTreeInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FruitTreeInteraction_C.__ExecuteUbergraph_BP_FruitTreeInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020ACF RID: 133839 RVA: 0x00933B43 File Offset: 0x00931D43
		protected BP_FruitTreeInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105CE RID: 67022
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneInteraction/FruitTree/BP_FruitTreeInteraction.BP_FruitTreeInteraction_C";

		// Token: 0x040105CF RID: 67023
		private static IntPtr _ClassPtr;

		// Token: 0x040105D0 RID: 67024
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105D1 RID: 67025
		internal static int __PropertyOffset_0;

		// Token: 0x040105D2 RID: 67026
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040105D3 RID: 67027
		internal static int __PropertyOffset_1;

		// Token: 0x040105D4 RID: 67028
		internal static int __PropertyOffset_2;

		// Token: 0x040105D5 RID: 67029
		internal static int __PropertyOffset_3;

		// Token: 0x040105D6 RID: 67030
		internal static int __PropertyOffset_4;

		// Token: 0x040105D7 RID: 67031
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040105D8 RID: 67032
		private static IntPtr __OnApplyWorldOffset_NativeFunctionPtr;

		// Token: 0x040105D9 RID: 67033
		private static IntPtr __ExecuteUbergraph_BP_FruitTreeInteraction_NativeFunctionPtr;

		// Token: 0x02009A0E RID: 39438
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected new ref struct __OnApplyWorldOffset_FunctionParams
		{
			// Token: 0x040320FB RID: 205051
			[FieldOffset(0)]
			public FVector InWorldOffset;

			// Token: 0x040320FC RID: 205052
			[FieldOffset(12)]
			public bool bWorldShift;
		}

		// Token: 0x02009A0F RID: 39439
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __ExecuteUbergraph_BP_FruitTreeInteraction_FunctionParams
		{
			// Token: 0x040320FD RID: 205053
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
