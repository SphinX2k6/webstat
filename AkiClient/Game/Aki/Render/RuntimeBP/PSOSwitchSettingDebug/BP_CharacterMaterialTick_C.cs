using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.TickMaster;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PSOSwitchSettingDebug
{
	// Token: 0x02003B45 RID: 15173
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/BP_CharacterMaterialTick.BP_CharacterMaterialTick_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1073)]
	public class BP_CharacterMaterialTick_C : AActor, IUnrealUObject, IUnrealObject, IBPI_EditorTickMaster_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06020E2B RID: 134699 RVA: 0x00939CAB File Offset: 0x00937EAB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterMaterialTick_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/BP_CharacterMaterialTick.BP_CharacterMaterialTick_C");
			}
			return BP_CharacterMaterialTick_C._ClassPtr;
		}

		// Token: 0x06020E2C RID: 134700 RVA: 0x00939CD0 File Offset: 0x00937ED0
		public BP_CharacterMaterialTick_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterMaterialTick_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020E2D RID: 134701 RVA: 0x00939CF8 File Offset: 0x00937EF8
		[NullableContext(1)]
		public BP_CharacterMaterialTick_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterMaterialTick_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170037D2 RID: 14290
		// (get) Token: 0x06020E2E RID: 134702 RVA: 0x00939D2C File Offset: 0x00937F2C
		// (set) Token: 0x06020E2F RID: 134703 RVA: 0x00939D65 File Offset: 0x00937F65
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037D3 RID: 14291
		// (get) Token: 0x06020E30 RID: 134704 RVA: 0x00939D86 File Offset: 0x00937F86
		// (set) Token: 0x06020E31 RID: 134705 RVA: 0x00939D9A File Offset: 0x00937F9A
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterMaterialTick_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterMaterialTick_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170037D4 RID: 14292
		// (get) Token: 0x06020E32 RID: 134706 RVA: 0x00939DAF File Offset: 0x00937FAF
		// (set) Token: 0x06020E33 RID: 134707 RVA: 0x00939DC3 File Offset: 0x00937FC3
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterMaterialTick_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterMaterialTick_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170037D5 RID: 14293
		// (get) Token: 0x06020E34 RID: 134708 RVA: 0x00939DD8 File Offset: 0x00937FD8
		// (set) Token: 0x06020E35 RID: 134709 RVA: 0x00939DEC File Offset: 0x00937FEC
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterMaterialTick_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterMaterialTick_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170037D6 RID: 14294
		// (get) Token: 0x06020E36 RID: 134710 RVA: 0x00939E01 File Offset: 0x00938001
		// (set) Token: 0x06020E37 RID: 134711 RVA: 0x00939E11 File Offset: 0x00938011
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170037D7 RID: 14295
		// (get) Token: 0x06020E38 RID: 134712 RVA: 0x00939E22 File Offset: 0x00938022
		// (set) Token: 0x06020E39 RID: 134713 RVA: 0x00939E32 File Offset: 0x00938032
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170037D8 RID: 14296
		// (get) Token: 0x06020E3A RID: 134714 RVA: 0x00939E43 File Offset: 0x00938043
		// (set) Token: 0x06020E3B RID: 134715 RVA: 0x00939E53 File Offset: 0x00938053
		public unsafe bool UseWithSkeletalMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterMaterialTick_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020E3C RID: 134716 RVA: 0x00939E64 File Offset: 0x00938064
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CharacterMaterialTick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterMaterialTick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterMaterialTick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterMaterialTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterMaterialTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020E3D RID: 134717 RVA: 0x00939EAC File Offset: 0x009380AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CharacterMaterialTick_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterMaterialTick_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterMaterialTick_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterMaterialTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterMaterialTick_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020E3E RID: 134718 RVA: 0x00939EF4 File Offset: 0x009380F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EditorTickMaster(float DeltaTime)
		{
			BP_CharacterMaterialTick_C.__EditorTickMaster_FunctionParams* ptr = stackalloc BP_CharacterMaterialTick_C.__EditorTickMaster_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterMaterialTick_C.__EditorTickMaster_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterMaterialTick_C.__EditorTickMaster_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterMaterialTick_C.__EditorTickMaster_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020E3F RID: 134719 RVA: 0x00939F3C File Offset: 0x0093813C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CharacterMaterialTick(int EntryPoint)
		{
			BP_CharacterMaterialTick_C.__ExecuteUbergraph_BP_CharacterMaterialTick_FunctionParams* ptr = stackalloc BP_CharacterMaterialTick_C.__ExecuteUbergraph_BP_CharacterMaterialTick_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_CharacterMaterialTick_C.__ExecuteUbergraph_BP_CharacterMaterialTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterMaterialTick_C.__ExecuteUbergraph_BP_CharacterMaterialTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterMaterialTick_C.__ExecuteUbergraph_BP_CharacterMaterialTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020E40 RID: 134720 RVA: 0x00939F83 File Offset: 0x00938183
		protected BP_CharacterMaterialTick_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010804 RID: 67588
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/BP_CharacterMaterialTick.BP_CharacterMaterialTick_C";

		// Token: 0x04010805 RID: 67589
		private static IntPtr _ClassPtr;

		// Token: 0x04010806 RID: 67590
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010807 RID: 67591
		internal static int __PropertyOffset_0;

		// Token: 0x04010808 RID: 67592
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010809 RID: 67593
		internal static int __PropertyOffset_1;

		// Token: 0x0401080A RID: 67594
		internal static int __PropertyOffset_2;

		// Token: 0x0401080B RID: 67595
		internal static int __PropertyOffset_3;

		// Token: 0x0401080C RID: 67596
		internal static int __PropertyOffset_4;

		// Token: 0x0401080D RID: 67597
		internal static int __PropertyOffset_5;

		// Token: 0x0401080E RID: 67598
		internal static int __PropertyOffset_6;

		// Token: 0x0401080F RID: 67599
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010810 RID: 67600
		private static IntPtr __EditorTickMaster_NativeFunctionPtr;

		// Token: 0x04010811 RID: 67601
		private static IntPtr __ExecuteUbergraph_BP_CharacterMaterialTick_NativeFunctionPtr;

		// Token: 0x02009A40 RID: 39488
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032140 RID: 205120
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A41 RID: 39489
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __EditorTickMaster_FunctionParams
		{
			// Token: 0x04032141 RID: 205121
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009A42 RID: 39490
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_CharacterMaterialTick_FunctionParams
		{
			// Token: 0x04032142 RID: 205122
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
