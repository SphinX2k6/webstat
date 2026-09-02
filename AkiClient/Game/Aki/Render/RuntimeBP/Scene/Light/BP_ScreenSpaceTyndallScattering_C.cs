using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A92 RID: 14994
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ScreenSpaceTyndallScattering.BP_ScreenSpaceTyndallScattering_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1069)]
	public class BP_ScreenSpaceTyndallScattering_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F8DA RID: 129242 RVA: 0x00914938 File Offset: 0x00912B38
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ScreenSpaceTyndallScattering_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ScreenSpaceTyndallScattering.BP_ScreenSpaceTyndallScattering_C");
			}
			return BP_ScreenSpaceTyndallScattering_C._ClassPtr;
		}

		// Token: 0x0601F8DB RID: 129243 RVA: 0x0091495C File Offset: 0x00912B5C
		public BP_ScreenSpaceTyndallScattering_C() : this(BuiltinUtils.AllocNativeUObject(BP_ScreenSpaceTyndallScattering_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F8DC RID: 129244 RVA: 0x00914984 File Offset: 0x00912B84
		[NullableContext(1)]
		public BP_ScreenSpaceTyndallScattering_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ScreenSpaceTyndallScattering_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003099 RID: 12441
		// (get) Token: 0x0601F8DD RID: 129245 RVA: 0x009149B8 File Offset: 0x00912BB8
		// (set) Token: 0x0601F8DE RID: 129246 RVA: 0x009149F1 File Offset: 0x00912BF1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700309A RID: 12442
		// (get) Token: 0x0601F8DF RID: 129247 RVA: 0x00914A12 File Offset: 0x00912C12
		// (set) Token: 0x0601F8E0 RID: 129248 RVA: 0x00914A26 File Offset: 0x00912C26
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700309B RID: 12443
		// (get) Token: 0x0601F8E1 RID: 129249 RVA: 0x00914A3B File Offset: 0x00912C3B
		// (set) Token: 0x0601F8E2 RID: 129250 RVA: 0x00914A4F File Offset: 0x00912C4F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700309C RID: 12444
		// (get) Token: 0x0601F8E3 RID: 129251 RVA: 0x00914A64 File Offset: 0x00912C64
		// (set) Token: 0x0601F8E4 RID: 129252 RVA: 0x00914A74 File Offset: 0x00912C74
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700309D RID: 12445
		// (get) Token: 0x0601F8E5 RID: 129253 RVA: 0x00914A85 File Offset: 0x00912C85
		// (set) Token: 0x0601F8E6 RID: 129254 RVA: 0x00914A95 File Offset: 0x00912C95
		public unsafe float Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700309E RID: 12446
		// (get) Token: 0x0601F8E7 RID: 129255 RVA: 0x00914AA6 File Offset: 0x00912CA6
		// (set) Token: 0x0601F8E8 RID: 129256 RVA: 0x00914AB6 File Offset: 0x00912CB6
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700309F RID: 12447
		// (get) Token: 0x0601F8E9 RID: 129257 RVA: 0x00914AC7 File Offset: 0x00912CC7
		// (set) Token: 0x0601F8EA RID: 129258 RVA: 0x00914AD7 File Offset: 0x00912CD7
		public unsafe bool EnableCustomPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenSpaceTyndallScattering_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F8EB RID: 129259 RVA: 0x00914AE8 File Offset: 0x00912CE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void tick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__tick_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8EC RID: 129260 RVA: 0x00914AFC File Offset: 0x00912CFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8ED RID: 129261 RVA: 0x00914B10 File Offset: 0x00912D10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8EE RID: 129262 RVA: 0x00914B25 File Offset: 0x00912D25
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8EF RID: 129263 RVA: 0x00914B39 File Offset: 0x00912D39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8F0 RID: 129264 RVA: 0x00914B50 File Offset: 0x00912D50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F8F1 RID: 129265 RVA: 0x00914B98 File Offset: 0x00912D98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8F2 RID: 129266 RVA: 0x00914BE0 File Offset: 0x00912DE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F8F3 RID: 129267 RVA: 0x00914C2C File Offset: 0x00912E2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8F4 RID: 129268 RVA: 0x00914C78 File Offset: 0x00912E78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8F5 RID: 129269 RVA: 0x00914C8C File Offset: 0x00912E8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8F6 RID: 129270 RVA: 0x00914CA4 File Offset: 0x00912EA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ScreenSpaceTyndallScattering(int EntryPoint)
		{
			BP_ScreenSpaceTyndallScattering_C.__ExecuteUbergraph_BP_ScreenSpaceTyndallScattering_FunctionParams* ptr = stackalloc BP_ScreenSpaceTyndallScattering_C.__ExecuteUbergraph_BP_ScreenSpaceTyndallScattering_FunctionParams[(UIntPtr)327] + 15L / (long)sizeof(BP_ScreenSpaceTyndallScattering_C.__ExecuteUbergraph_BP_ScreenSpaceTyndallScattering_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenSpaceTyndallScattering_C.__ExecuteUbergraph_BP_ScreenSpaceTyndallScattering_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenSpaceTyndallScattering_C.__ExecuteUbergraph_BP_ScreenSpaceTyndallScattering_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8F7 RID: 129271 RVA: 0x00914CEE File Offset: 0x00912EEE
		protected BP_ScreenSpaceTyndallScattering_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FAE7 RID: 64231
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ScreenSpaceTyndallScattering.BP_ScreenSpaceTyndallScattering_C";

		// Token: 0x0400FAE8 RID: 64232
		private static IntPtr _ClassPtr;

		// Token: 0x0400FAE9 RID: 64233
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FAEA RID: 64234
		internal static int __PropertyOffset_0;

		// Token: 0x0400FAEB RID: 64235
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FAEC RID: 64236
		internal static int __PropertyOffset_1;

		// Token: 0x0400FAED RID: 64237
		internal static int __PropertyOffset_2;

		// Token: 0x0400FAEE RID: 64238
		internal static int __PropertyOffset_3;

		// Token: 0x0400FAEF RID: 64239
		internal static int __PropertyOffset_4;

		// Token: 0x0400FAF0 RID: 64240
		internal static int __PropertyOffset_5;

		// Token: 0x0400FAF1 RID: 64241
		internal static int __PropertyOffset_6;

		// Token: 0x0400FAF2 RID: 64242
		private static IntPtr __tick_NativeFunctionPtr;

		// Token: 0x0400FAF3 RID: 64243
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FAF4 RID: 64244
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FAF5 RID: 64245
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FAF6 RID: 64246
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400FAF7 RID: 64247
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FAF8 RID: 64248
		private static IntPtr __ExecuteUbergraph_BP_ScreenSpaceTyndallScattering_NativeFunctionPtr;

		// Token: 0x020098F9 RID: 39161
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F58 RID: 204632
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098FA RID: 39162
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031F59 RID: 204633
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020098FB RID: 39163
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 312)]
		protected ref struct __ExecuteUbergraph_BP_ScreenSpaceTyndallScattering_FunctionParams
		{
			// Token: 0x04031F5A RID: 204634
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
