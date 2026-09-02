using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SlowWater
{
	// Token: 0x02003B72 RID: 15218
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SlowWater.BP_SlowWater_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1360)]
	public class BP_SlowWater_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021816 RID: 137238 RVA: 0x0094B1B0 File Offset: 0x009493B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SlowWater_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SlowWater.BP_SlowWater_C");
			}
			return BP_SlowWater_C._ClassPtr;
		}

		// Token: 0x06021817 RID: 137239 RVA: 0x0094B1D4 File Offset: 0x009493D4
		public BP_SlowWater_C() : this(BuiltinUtils.AllocNativeUObject(BP_SlowWater_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021818 RID: 137240 RVA: 0x0094B1FC File Offset: 0x009493FC
		[NullableContext(1)]
		public BP_SlowWater_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SlowWater_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B80 RID: 15232
		// (get) Token: 0x06021819 RID: 137241 RVA: 0x0094B230 File Offset: 0x00949430
		// (set) Token: 0x0602181A RID: 137242 RVA: 0x0094B269 File Offset: 0x00949469
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B81 RID: 15233
		// (get) Token: 0x0602181B RID: 137243 RVA: 0x0094B28A File Offset: 0x0094948A
		// (set) Token: 0x0602181C RID: 137244 RVA: 0x0094B29E File Offset: 0x0094949E
		public unsafe UNiagaraComponent NS_SlowWater
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWater_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWater_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B82 RID: 15234
		// (get) Token: 0x0602181D RID: 137245 RVA: 0x0094B2B3 File Offset: 0x009494B3
		// (set) Token: 0x0602181E RID: 137246 RVA: 0x0094B2C7 File Offset: 0x009494C7
		public unsafe UStaticMeshComponent SM_SlowWater
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWater_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWater_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B83 RID: 15235
		// (get) Token: 0x0602181F RID: 137247 RVA: 0x0094B2DC File Offset: 0x009494DC
		// (set) Token: 0x06021820 RID: 137248 RVA: 0x0094B2F0 File Offset: 0x009494F0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWater_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SlowWater_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B84 RID: 15236
		// (get) Token: 0x06021821 RID: 137249 RVA: 0x0094B305 File Offset: 0x00949505
		// (set) Token: 0x06021822 RID: 137250 RVA: 0x0094B315 File Offset: 0x00949515
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003B85 RID: 15237
		// (get) Token: 0x06021823 RID: 137251 RVA: 0x0094B326 File Offset: 0x00949526
		// (set) Token: 0x06021824 RID: 137252 RVA: 0x0094B336 File Offset: 0x00949536
		public unsafe bool AutoTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B86 RID: 15238
		// (get) Token: 0x06021825 RID: 137253 RVA: 0x0094B347 File Offset: 0x00949547
		// (set) Token: 0x06021826 RID: 137254 RVA: 0x0094B357 File Offset: 0x00949557
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003B87 RID: 15239
		// (get) Token: 0x06021827 RID: 137255 RVA: 0x0094B368 File Offset: 0x00949568
		// (set) Token: 0x06021828 RID: 137256 RVA: 0x0094B378 File Offset: 0x00949578
		public unsafe float RollSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SlowWater_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06021829 RID: 137257 RVA: 0x0094B38C File Offset: 0x0094958C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SlowWater_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SlowWater_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWater_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SlowWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602182A RID: 137258 RVA: 0x0094B3D4 File Offset: 0x009495D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SlowWater_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SlowWater_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWater_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602182B RID: 137259 RVA: 0x0094B41C File Offset: 0x0094961C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SlowWater_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SlowWater_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWater_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SlowWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602182C RID: 137260 RVA: 0x0094B464 File Offset: 0x00949664
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SlowWater_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SlowWater_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SlowWater_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602182D RID: 137261 RVA: 0x0094B4AC File Offset: 0x009496AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SlowWater(int EntryPoint)
		{
			BP_SlowWater_C.__ExecuteUbergraph_BP_SlowWater_FunctionParams* ptr = stackalloc BP_SlowWater_C.__ExecuteUbergraph_BP_SlowWater_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_SlowWater_C.__ExecuteUbergraph_BP_SlowWater_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SlowWater_C.__ExecuteUbergraph_BP_SlowWater_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SlowWater_C.__ExecuteUbergraph_BP_SlowWater_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602182E RID: 137262 RVA: 0x0094B4F3 File Offset: 0x009496F3
		protected BP_SlowWater_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010DFB RID: 69115
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SlowWater/BP_SlowWater.BP_SlowWater_C";

		// Token: 0x04010DFC RID: 69116
		private static IntPtr _ClassPtr;

		// Token: 0x04010DFD RID: 69117
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010DFE RID: 69118
		internal static int __PropertyOffset_0;

		// Token: 0x04010DFF RID: 69119
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010E00 RID: 69120
		internal static int __PropertyOffset_1;

		// Token: 0x04010E01 RID: 69121
		internal static int __PropertyOffset_2;

		// Token: 0x04010E02 RID: 69122
		internal static int __PropertyOffset_3;

		// Token: 0x04010E03 RID: 69123
		internal static int __PropertyOffset_4;

		// Token: 0x04010E04 RID: 69124
		internal static int __PropertyOffset_5;

		// Token: 0x04010E05 RID: 69125
		internal static int __PropertyOffset_6;

		// Token: 0x04010E06 RID: 69126
		internal static int __PropertyOffset_7;

		// Token: 0x04010E07 RID: 69127
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010E08 RID: 69128
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010E09 RID: 69129
		private static IntPtr __ExecuteUbergraph_BP_SlowWater_NativeFunctionPtr;

		// Token: 0x02009AEC RID: 39660
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032288 RID: 205448
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AED RID: 39661
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032289 RID: 205449
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AEE RID: 39662
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_SlowWater_FunctionParams
		{
			// Token: 0x0403228A RID: 205450
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
