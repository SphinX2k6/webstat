using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime;
using AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers;
using AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Sensors;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C97 RID: 15511
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_GlobalTrailTesslation.BP_GlobalTrailTesslation_C")]
	[UnrealStructLayout(256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 256)]
	public class BP_GlobalTrailTesslation_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024774 RID: 149364 RVA: 0x0099E574 File Offset: 0x0099C774
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GlobalTrailTesslation_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalTrailTesslation.BP_GlobalTrailTesslation_C");
			}
			return BP_GlobalTrailTesslation_C._ClassPtr;
		}

		// Token: 0x06024775 RID: 149365 RVA: 0x0099E598 File Offset: 0x0099C798
		public BP_GlobalTrailTesslation_C() : this(BuiltinUtils.AllocNativeUObject(BP_GlobalTrailTesslation_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024776 RID: 149366 RVA: 0x0099E5C0 File Offset: 0x0099C7C0
		[NullableContext(1)]
		public BP_GlobalTrailTesslation_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GlobalTrailTesslation_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004C3D RID: 19517
		// (get) Token: 0x06024777 RID: 149367 RVA: 0x0099E5F4 File Offset: 0x0099C7F4
		// (set) Token: 0x06024778 RID: 149368 RVA: 0x0099E62D File Offset: 0x0099C82D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GlobalTrailTesslation_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GlobalTrailTesslation_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004C3E RID: 19518
		// (get) Token: 0x06024779 RID: 149369 RVA: 0x0099E64E File Offset: 0x0099C84E
		// (set) Token: 0x0602477A RID: 149370 RVA: 0x0099E65E File Offset: 0x0099C85E
		public unsafe bool GenerateTesslation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalTrailTesslation_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalTrailTesslation_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C3F RID: 19519
		// (get) Token: 0x0602477B RID: 149371 RVA: 0x0099E66F File Offset: 0x0099C86F
		// (set) Token: 0x0602477C RID: 149372 RVA: 0x0099E683 File Offset: 0x0099C883
		public unsafe BP_TrailDrawActor_Capture_C TrailDrawCapture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailDrawActor_Capture_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004C40 RID: 19520
		// (get) Token: 0x0602477D RID: 149373 RVA: 0x0099E698 File Offset: 0x0099C898
		// (set) Token: 0x0602477E RID: 149374 RVA: 0x0099E6AC File Offset: 0x0099C8AC
		public unsafe BP_TrailSensor_Snow_C TrailSensor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailSensor_Snow_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004C41 RID: 19521
		// (get) Token: 0x0602477F RID: 149375 RVA: 0x0099E6C1 File Offset: 0x0099C8C1
		// (set) Token: 0x06024780 RID: 149376 RVA: 0x0099E6D5 File Offset: 0x0099C8D5
		public unsafe BP_TrailsManager_C Trailmanager
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailsManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004C42 RID: 19522
		// (get) Token: 0x06024781 RID: 149377 RVA: 0x0099E6EA File Offset: 0x0099C8EA
		// (set) Token: 0x06024782 RID: 149378 RVA: 0x0099E6FE File Offset: 0x0099C8FE
		public unsafe BP_GlobalGI_C BP_GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalTrailTesslation_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06024783 RID: 149379 RVA: 0x0099E713 File Offset: 0x0099C913
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalTrailTesslation_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024784 RID: 149380 RVA: 0x0099E727 File Offset: 0x0099C927
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalTrailTesslation_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024785 RID: 149381 RVA: 0x0099E73C File Offset: 0x0099C93C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_GlobalTrailTesslation_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_GlobalTrailTesslation_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GlobalTrailTesslation_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalTrailTesslation_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalTrailTesslation_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024786 RID: 149382 RVA: 0x0099E788 File Offset: 0x0099C988
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_GlobalTrailTesslation_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_GlobalTrailTesslation_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GlobalTrailTesslation_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalTrailTesslation_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalTrailTesslation_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024787 RID: 149383 RVA: 0x0099E7D4 File Offset: 0x0099C9D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GlobalTrailTesslation(int EntryPoint)
		{
			BP_GlobalTrailTesslation_C.__ExecuteUbergraph_BP_GlobalTrailTesslation_FunctionParams* ptr = stackalloc BP_GlobalTrailTesslation_C.__ExecuteUbergraph_BP_GlobalTrailTesslation_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_GlobalTrailTesslation_C.__ExecuteUbergraph_BP_GlobalTrailTesslation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalTrailTesslation_C.__ExecuteUbergraph_BP_GlobalTrailTesslation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalTrailTesslation_C.__ExecuteUbergraph_BP_GlobalTrailTesslation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024788 RID: 149384 RVA: 0x0099E81E File Offset: 0x0099CA1E
		protected BP_GlobalTrailTesslation_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012AE0 RID: 76512
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalTrailTesslation.BP_GlobalTrailTesslation_C";

		// Token: 0x04012AE1 RID: 76513
		private static IntPtr _ClassPtr;

		// Token: 0x04012AE2 RID: 76514
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012AE3 RID: 76515
		internal static int __PropertyOffset_0;

		// Token: 0x04012AE4 RID: 76516
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012AE5 RID: 76517
		internal static int __PropertyOffset_1;

		// Token: 0x04012AE6 RID: 76518
		internal static int __PropertyOffset_2;

		// Token: 0x04012AE7 RID: 76519
		internal static int __PropertyOffset_3;

		// Token: 0x04012AE8 RID: 76520
		internal static int __PropertyOffset_4;

		// Token: 0x04012AE9 RID: 76521
		internal static int __PropertyOffset_5;

		// Token: 0x04012AEA RID: 76522
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012AEB RID: 76523
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04012AEC RID: 76524
		private static IntPtr __ExecuteUbergraph_BP_GlobalTrailTesslation_NativeFunctionPtr;

		// Token: 0x02009DEE RID: 40430
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403282E RID: 206894
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009DEF RID: 40431
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __ExecuteUbergraph_BP_GlobalTrailTesslation_FunctionParams
		{
			// Token: 0x0403282F RID: 206895
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
