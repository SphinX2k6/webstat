using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SlowWater
{
	// Token: 0x02003B71 RID: 15217
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SlowWaterHoriz.BP_SlowWaterHoriz_C")]
	[UnrealStructLayout(1376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1376)]
	public class BP_SlowWaterHoriz_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060217F5 RID: 137205 RVA: 0x0094ADC9 File Offset: 0x00948FC9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SlowWaterHoriz_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SlowWaterHoriz.BP_SlowWaterHoriz_C");
			}
			return BP_SlowWaterHoriz_C._ClassPtr;
		}

		// Token: 0x060217F6 RID: 137206 RVA: 0x0094ADF0 File Offset: 0x00948FF0
		public BP_SlowWaterHoriz_C() : this(BuiltinUtils.AllocNativeUObject(BP_SlowWaterHoriz_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060217F7 RID: 137207 RVA: 0x0094AE18 File Offset: 0x00949018
		[NullableContext(1)]
		public BP_SlowWaterHoriz_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SlowWaterHoriz_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B76 RID: 15222
		// (get) Token: 0x060217F8 RID: 137208 RVA: 0x0094AE4C File Offset: 0x0094904C
		// (set) Token: 0x060217F9 RID: 137209 RVA: 0x0094AE85 File Offset: 0x00949085
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B77 RID: 15223
		// (get) Token: 0x060217FA RID: 137210 RVA: 0x0094AEA6 File Offset: 0x009490A6
		// (set) Token: 0x060217FB RID: 137211 RVA: 0x0094AEBA File Offset: 0x009490BA
		public unsafe UStaticMeshComponent SM_Water_Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B78 RID: 15224
		// (get) Token: 0x060217FC RID: 137212 RVA: 0x0094AECF File Offset: 0x009490CF
		// (set) Token: 0x060217FD RID: 137213 RVA: 0x0094AEE3 File Offset: 0x009490E3
		public unsafe UStaticMeshComponent SM_SlowWater_02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B79 RID: 15225
		// (get) Token: 0x060217FE RID: 137214 RVA: 0x0094AEF8 File Offset: 0x009490F8
		// (set) Token: 0x060217FF RID: 137215 RVA: 0x0094AF0C File Offset: 0x0094910C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B7A RID: 15226
		// (get) Token: 0x06021800 RID: 137216 RVA: 0x0094AF21 File Offset: 0x00949121
		// (set) Token: 0x06021801 RID: 137217 RVA: 0x0094AF31 File Offset: 0x00949131
		public unsafe float NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003B7B RID: 15227
		// (get) Token: 0x06021802 RID: 137218 RVA: 0x0094AF42 File Offset: 0x00949142
		// (set) Token: 0x06021803 RID: 137219 RVA: 0x0094AF52 File Offset: 0x00949152
		public unsafe float NewVar_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003B7C RID: 15228
		// (get) Token: 0x06021804 RID: 137220 RVA: 0x0094AF63 File Offset: 0x00949163
		// (set) Token: 0x06021805 RID: 137221 RVA: 0x0094AF73 File Offset: 0x00949173
		public unsafe bool EnableTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B7D RID: 15229
		// (get) Token: 0x06021806 RID: 137222 RVA: 0x0094AF84 File Offset: 0x00949184
		// (set) Token: 0x06021807 RID: 137223 RVA: 0x0094AF94 File Offset: 0x00949194
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B7E RID: 15230
		// (get) Token: 0x06021808 RID: 137224 RVA: 0x0094AFA5 File Offset: 0x009491A5
		// (set) Token: 0x06021809 RID: 137225 RVA: 0x0094AFB5 File Offset: 0x009491B5
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWaterHoriz_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003B7F RID: 15231
		// (get) Token: 0x0602180A RID: 137226 RVA: 0x0094AFC6 File Offset: 0x009491C6
		// (set) Token: 0x0602180B RID: 137227 RVA: 0x0094AFDA File Offset: 0x009491DA
		public unsafe UMaterialInterface MaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWaterHoriz_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x0602180C RID: 137228 RVA: 0x0094AFEF File Offset: 0x009491EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602180D RID: 137229 RVA: 0x0094B003 File Offset: 0x00949203
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602180E RID: 137230 RVA: 0x0094B018 File Offset: 0x00949218
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SlowWaterHoriz_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SlowWaterHoriz_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWaterHoriz_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWaterHoriz_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602180F RID: 137231 RVA: 0x0094B060 File Offset: 0x00949260
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SlowWaterHoriz_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SlowWaterHoriz_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWaterHoriz_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWaterHoriz_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021810 RID: 137232 RVA: 0x0094B0A8 File Offset: 0x009492A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SlowWaterHoriz_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SlowWaterHoriz_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWaterHoriz_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWaterHoriz_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021811 RID: 137233 RVA: 0x0094B0F0 File Offset: 0x009492F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SlowWaterHoriz_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SlowWaterHoriz_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWaterHoriz_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWaterHoriz_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021812 RID: 137234 RVA: 0x0094B137 File Offset: 0x00949337
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021813 RID: 137235 RVA: 0x0094B14B File Offset: 0x0094934B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021814 RID: 137236 RVA: 0x0094B160 File Offset: 0x00949360
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SlowWaterHoriz(int EntryPoint)
		{
			BP_SlowWaterHoriz_C.__ExecuteUbergraph_BP_SlowWaterHoriz_FunctionParams* ptr = stackalloc BP_SlowWaterHoriz_C.__ExecuteUbergraph_BP_SlowWaterHoriz_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_SlowWaterHoriz_C.__ExecuteUbergraph_BP_SlowWaterHoriz_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWaterHoriz_C.__ExecuteUbergraph_BP_SlowWaterHoriz_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWaterHoriz_C.__ExecuteUbergraph_BP_SlowWaterHoriz_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021815 RID: 137237 RVA: 0x0094B1A7 File Offset: 0x009493A7
		protected BP_SlowWaterHoriz_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010DE8 RID: 69096
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SlowWaterHoriz.BP_SlowWaterHoriz_C";

		// Token: 0x04010DE9 RID: 69097
		private static IntPtr _ClassPtr;

		// Token: 0x04010DEA RID: 69098
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010DEB RID: 69099
		internal static int __PropertyOffset_0;

		// Token: 0x04010DEC RID: 69100
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010DED RID: 69101
		internal static int __PropertyOffset_1;

		// Token: 0x04010DEE RID: 69102
		internal static int __PropertyOffset_2;

		// Token: 0x04010DEF RID: 69103
		internal static int __PropertyOffset_3;

		// Token: 0x04010DF0 RID: 69104
		internal static int __PropertyOffset_4;

		// Token: 0x04010DF1 RID: 69105
		internal static int __PropertyOffset_5;

		// Token: 0x04010DF2 RID: 69106
		internal static int __PropertyOffset_6;

		// Token: 0x04010DF3 RID: 69107
		internal static int __PropertyOffset_7;

		// Token: 0x04010DF4 RID: 69108
		internal static int __PropertyOffset_8;

		// Token: 0x04010DF5 RID: 69109
		internal static int __PropertyOffset_9;

		// Token: 0x04010DF6 RID: 69110
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010DF7 RID: 69111
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010DF8 RID: 69112
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010DF9 RID: 69113
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010DFA RID: 69114
		private static IntPtr __ExecuteUbergraph_BP_SlowWaterHoriz_NativeFunctionPtr;

		// Token: 0x02009AE9 RID: 39657
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032285 RID: 205445
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AEA RID: 39658
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032286 RID: 205446
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AEB RID: 39659
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __ExecuteUbergraph_BP_SlowWaterHoriz_FunctionParams
		{
			// Token: 0x04032287 RID: 205447
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
