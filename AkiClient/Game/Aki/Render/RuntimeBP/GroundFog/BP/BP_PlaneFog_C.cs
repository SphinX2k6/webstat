using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GroundFog.BP
{
	// Token: 0x02003C91 RID: 15505
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_PlaneFog.BP_PlaneFog_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1116)]
	public class BP_PlaneFog_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024307 RID: 148231 RVA: 0x00997120 File Offset: 0x00995320
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PlaneFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_PlaneFog.BP_PlaneFog_C");
			}
			return BP_PlaneFog_C._ClassPtr;
		}

		// Token: 0x06024308 RID: 148232 RVA: 0x00997144 File Offset: 0x00995344
		public BP_PlaneFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_PlaneFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024309 RID: 148233 RVA: 0x0099716C File Offset: 0x0099536C
		[NullableContext(1)]
		public BP_PlaneFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PlaneFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A8F RID: 19087
		// (get) Token: 0x0602430A RID: 148234 RVA: 0x009971A0 File Offset: 0x009953A0
		// (set) Token: 0x0602430B RID: 148235 RVA: 0x009971D9 File Offset: 0x009953D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004A90 RID: 19088
		// (get) Token: 0x0602430C RID: 148236 RVA: 0x009971FA File Offset: 0x009953FA
		// (set) Token: 0x0602430D RID: 148237 RVA: 0x0099720E File Offset: 0x0099540E
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlaneFog_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlaneFog_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004A91 RID: 19089
		// (get) Token: 0x0602430E RID: 148238 RVA: 0x00997223 File Offset: 0x00995423
		// (set) Token: 0x0602430F RID: 148239 RVA: 0x00997237 File Offset: 0x00995437
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlaneFog_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlaneFog_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004A92 RID: 19090
		// (get) Token: 0x06024310 RID: 148240 RVA: 0x0099724C File Offset: 0x0099544C
		// (set) Token: 0x06024311 RID: 148241 RVA: 0x00997260 File Offset: 0x00995460
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlaneFog_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PlaneFog_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004A93 RID: 19091
		// (get) Token: 0x06024312 RID: 148242 RVA: 0x00997275 File Offset: 0x00995475
		// (set) Token: 0x06024313 RID: 148243 RVA: 0x00997285 File Offset: 0x00995485
		public unsafe float DepthFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004A94 RID: 19092
		// (get) Token: 0x06024314 RID: 148244 RVA: 0x00997296 File Offset: 0x00995496
		// (set) Token: 0x06024315 RID: 148245 RVA: 0x009972A6 File Offset: 0x009954A6
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004A95 RID: 19093
		// (get) Token: 0x06024316 RID: 148246 RVA: 0x009972B7 File Offset: 0x009954B7
		// (set) Token: 0x06024317 RID: 148247 RVA: 0x009972C7 File Offset: 0x009954C7
		public unsafe float Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004A96 RID: 19094
		// (get) Token: 0x06024318 RID: 148248 RVA: 0x009972D8 File Offset: 0x009954D8
		// (set) Token: 0x06024319 RID: 148249 RVA: 0x009972E8 File Offset: 0x009954E8
		public unsafe float XYRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004A97 RID: 19095
		// (get) Token: 0x0602431A RID: 148250 RVA: 0x009972F9 File Offset: 0x009954F9
		// (set) Token: 0x0602431B RID: 148251 RVA: 0x00997309 File Offset: 0x00995509
		public unsafe float TexID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004A98 RID: 19096
		// (get) Token: 0x0602431C RID: 148252 RVA: 0x0099731A File Offset: 0x0099551A
		// (set) Token: 0x0602431D RID: 148253 RVA: 0x0099732E File Offset: 0x0099552E
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004A99 RID: 19097
		// (get) Token: 0x0602431E RID: 148254 RVA: 0x00997343 File Offset: 0x00995543
		// (set) Token: 0x0602431F RID: 148255 RVA: 0x00997357 File Offset: 0x00995557
		public unsafe FLinearColor DarkColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PlaneFog_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06024320 RID: 148256 RVA: 0x0099736C File Offset: 0x0099556C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlaneFog_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024321 RID: 148257 RVA: 0x00997380 File Offset: 0x00995580
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlaneFog_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024322 RID: 148258 RVA: 0x00997395 File Offset: 0x00995595
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlaneFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024323 RID: 148259 RVA: 0x009973A9 File Offset: 0x009955A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlaneFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024324 RID: 148260 RVA: 0x009973C0 File Offset: 0x009955C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PlaneFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlaneFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlaneFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlaneFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PlaneFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024325 RID: 148261 RVA: 0x00997408 File Offset: 0x00995608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PlaneFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PlaneFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PlaneFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlaneFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlaneFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024326 RID: 148262 RVA: 0x00997450 File Offset: 0x00995650
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PlaneFog(int EntryPoint)
		{
			BP_PlaneFog_C.__ExecuteUbergraph_BP_PlaneFog_FunctionParams* ptr = stackalloc BP_PlaneFog_C.__ExecuteUbergraph_BP_PlaneFog_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PlaneFog_C.__ExecuteUbergraph_BP_PlaneFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PlaneFog_C.__ExecuteUbergraph_BP_PlaneFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PlaneFog_C.__ExecuteUbergraph_BP_PlaneFog_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024327 RID: 148263 RVA: 0x00997497 File Offset: 0x00995697
		protected BP_PlaneFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012832 RID: 75826
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GroundFog/BP/BP_PlaneFog.BP_PlaneFog_C";

		// Token: 0x04012833 RID: 75827
		private static IntPtr _ClassPtr;

		// Token: 0x04012834 RID: 75828
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012835 RID: 75829
		internal static int __PropertyOffset_0;

		// Token: 0x04012836 RID: 75830
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012837 RID: 75831
		internal static int __PropertyOffset_1;

		// Token: 0x04012838 RID: 75832
		internal static int __PropertyOffset_2;

		// Token: 0x04012839 RID: 75833
		internal static int __PropertyOffset_3;

		// Token: 0x0401283A RID: 75834
		internal static int __PropertyOffset_4;

		// Token: 0x0401283B RID: 75835
		internal static int __PropertyOffset_5;

		// Token: 0x0401283C RID: 75836
		internal static int __PropertyOffset_6;

		// Token: 0x0401283D RID: 75837
		internal static int __PropertyOffset_7;

		// Token: 0x0401283E RID: 75838
		internal static int __PropertyOffset_8;

		// Token: 0x0401283F RID: 75839
		internal static int __PropertyOffset_9;

		// Token: 0x04012840 RID: 75840
		internal static int __PropertyOffset_10;

		// Token: 0x04012841 RID: 75841
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012842 RID: 75842
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012843 RID: 75843
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012844 RID: 75844
		private static IntPtr __ExecuteUbergraph_BP_PlaneFog_NativeFunctionPtr;

		// Token: 0x02009D9B RID: 40347
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032792 RID: 206738
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D9C RID: 40348
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PlaneFog_FunctionParams
		{
			// Token: 0x04032793 RID: 206739
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
