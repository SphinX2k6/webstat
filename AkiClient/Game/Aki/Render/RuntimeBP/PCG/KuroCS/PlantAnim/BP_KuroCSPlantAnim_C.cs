using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.PlantAnim
{
	// Token: 0x02003BF8 RID: 15352
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/PlantAnim/BP_KuroCSPlantAnim.BP_KuroCSPlantAnim_C")]
	[UnrealStructLayout(1256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1256)]
	public class BP_KuroCSPlantAnim_C : AKuroCSPlantAnim, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022B7A RID: 142202 RVA: 0x0096CE1F File Offset: 0x0096B01F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCSPlantAnim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/PlantAnim/BP_KuroCSPlantAnim.BP_KuroCSPlantAnim_C");
			}
			return BP_KuroCSPlantAnim_C._ClassPtr;
		}

		// Token: 0x06022B7B RID: 142203 RVA: 0x0096CE44 File Offset: 0x0096B044
		public BP_KuroCSPlantAnim_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSPlantAnim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022B7C RID: 142204 RVA: 0x0096CE6C File Offset: 0x0096B06C
		[NullableContext(1)]
		public BP_KuroCSPlantAnim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSPlantAnim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004264 RID: 16996
		// (get) Token: 0x06022B7D RID: 142205 RVA: 0x0096CEA0 File Offset: 0x0096B0A0
		// (set) Token: 0x06022B7E RID: 142206 RVA: 0x0096CED9 File Offset: 0x0096B0D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCSPlantAnim_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSPlantAnim_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004265 RID: 16997
		// (get) Token: 0x06022B7F RID: 142207 RVA: 0x0096CEFA File Offset: 0x0096B0FA
		// (set) Token: 0x06022B80 RID: 142208 RVA: 0x0096CF0E File Offset: 0x0096B10E
		public unsafe UStaticMeshComponent Leaf
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004266 RID: 16998
		// (get) Token: 0x06022B81 RID: 142209 RVA: 0x0096CF23 File Offset: 0x0096B123
		// (set) Token: 0x06022B82 RID: 142210 RVA: 0x0096CF37 File Offset: 0x0096B137
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004267 RID: 16999
		// (get) Token: 0x06022B83 RID: 142211 RVA: 0x0096CF4C File Offset: 0x0096B14C
		// (set) Token: 0x06022B84 RID: 142212 RVA: 0x0096CF60 File Offset: 0x0096B160
		public unsafe UStaticMeshComponent SM_VAT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004268 RID: 17000
		// (get) Token: 0x06022B85 RID: 142213 RVA: 0x0096CF75 File Offset: 0x0096B175
		// (set) Token: 0x06022B86 RID: 142214 RVA: 0x0096CF89 File Offset: 0x0096B189
		public unsafe UStaticMeshComponent FoliageRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004269 RID: 17001
		// (get) Token: 0x06022B87 RID: 142215 RVA: 0x0096CF9E File Offset: 0x0096B19E
		// (set) Token: 0x06022B88 RID: 142216 RVA: 0x0096CFB2 File Offset: 0x0096B1B2
		public unsafe UMaterialInterface Dynamic_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700426A RID: 17002
		// (get) Token: 0x06022B89 RID: 142217 RVA: 0x0096CFC7 File Offset: 0x0096B1C7
		// (set) Token: 0x06022B8A RID: 142218 RVA: 0x0096CFDB File Offset: 0x0096B1DB
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlantAnim_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x06022B8B RID: 142219 RVA: 0x0096CFF0 File Offset: 0x0096B1F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugDraw()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__DebugDraw_NativeFunctionPtr, null);
		}

		// Token: 0x06022B8C RID: 142220 RVA: 0x0096D004 File Offset: 0x0096B204
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022B8D RID: 142221 RVA: 0x0096D018 File Offset: 0x0096B218
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022B8E RID: 142222 RVA: 0x0096D02D File Offset: 0x0096B22D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022B8F RID: 142223 RVA: 0x0096D041 File Offset: 0x0096B241
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022B90 RID: 142224 RVA: 0x0096D058 File Offset: 0x0096B258
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCSPlantAnim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSPlantAnim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSPlantAnim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlantAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B91 RID: 142225 RVA: 0x0096D0A0 File Offset: 0x0096B2A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCSPlantAnim_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSPlantAnim_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSPlantAnim_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlantAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B92 RID: 142226 RVA: 0x0096D0E8 File Offset: 0x0096B2E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCSPlantAnim(int EntryPoint)
		{
			BP_KuroCSPlantAnim_C.__ExecuteUbergraph_BP_KuroCSPlantAnim_FunctionParams* ptr = stackalloc BP_KuroCSPlantAnim_C.__ExecuteUbergraph_BP_KuroCSPlantAnim_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_KuroCSPlantAnim_C.__ExecuteUbergraph_BP_KuroCSPlantAnim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlantAnim_C.__ExecuteUbergraph_BP_KuroCSPlantAnim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlantAnim_C.__ExecuteUbergraph_BP_KuroCSPlantAnim_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B93 RID: 142227 RVA: 0x0096D132 File Offset: 0x0096B332
		protected BP_KuroCSPlantAnim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401199B RID: 72091
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/PlantAnim/BP_KuroCSPlantAnim.BP_KuroCSPlantAnim_C";

		// Token: 0x0401199C RID: 72092
		private static IntPtr _ClassPtr;

		// Token: 0x0401199D RID: 72093
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401199E RID: 72094
		internal static int __PropertyOffset_0;

		// Token: 0x0401199F RID: 72095
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040119A0 RID: 72096
		internal static int __PropertyOffset_1;

		// Token: 0x040119A1 RID: 72097
		internal static int __PropertyOffset_2;

		// Token: 0x040119A2 RID: 72098
		internal static int __PropertyOffset_3;

		// Token: 0x040119A3 RID: 72099
		internal static int __PropertyOffset_4;

		// Token: 0x040119A4 RID: 72100
		internal static int __PropertyOffset_5;

		// Token: 0x040119A5 RID: 72101
		internal static int __PropertyOffset_6;

		// Token: 0x040119A6 RID: 72102
		private static IntPtr __DebugDraw_NativeFunctionPtr;

		// Token: 0x040119A7 RID: 72103
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040119A8 RID: 72104
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040119A9 RID: 72105
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040119AA RID: 72106
		private static IntPtr __ExecuteUbergraph_BP_KuroCSPlantAnim_NativeFunctionPtr;

		// Token: 0x02009C19 RID: 39961
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032484 RID: 205956
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C1A RID: 39962
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __ExecuteUbergraph_BP_KuroCSPlantAnim_FunctionParams
		{
			// Token: 0x04032485 RID: 205957
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
