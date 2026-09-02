using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042E9 RID: 17129
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/BP_CineCamera.BP_CineCamera_C")]
	[UnrealStructLayout(3920, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3908)]
	public class BP_CineCamera_C : ACineCameraActor, IUnrealUObject, IUnrealObject, ISeqAutoTransformInterface, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602D6E2 RID: 186082 RVA: 0x00ABFED8 File Offset: 0x00ABE0D8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CineCamera_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Camera/BP_CineCamera.BP_CineCamera_C");
			}
			return BP_CineCamera_C._ClassPtr;
		}

		// Token: 0x0602D6E3 RID: 186083 RVA: 0x00ABFEFC File Offset: 0x00ABE0FC
		int ISeqAutoTransformInterface.InterfaceOffset()
		{
			return BP_CineCamera_C.__InterfaceOffset_ISeqAutoTransformInterface;
		}

		// Token: 0x0602D6E4 RID: 186084 RVA: 0x00ABFF04 File Offset: 0x00ABE104
		public BP_CineCamera_C() : this(BuiltinUtils.AllocNativeUObject(BP_CineCamera_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D6E5 RID: 186085 RVA: 0x00ABFF2C File Offset: 0x00ABE12C
		public BP_CineCamera_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CineCamera_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BFB RID: 31739
		// (get) Token: 0x0602D6E6 RID: 186086 RVA: 0x00ABFF60 File Offset: 0x00ABE160
		// (set) Token: 0x0602D6E7 RID: 186087 RVA: 0x00ABFF99 File Offset: 0x00ABE199
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007BFC RID: 31740
		// (get) Token: 0x0602D6E8 RID: 186088 RVA: 0x00ABFFBA File Offset: 0x00ABE1BA
		// (set) Token: 0x0602D6E9 RID: 186089 RVA: 0x00ABFFCA File Offset: 0x00ABE1CA
		public unsafe float ResolutionAdaptFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BFD RID: 31741
		// (get) Token: 0x0602D6EA RID: 186090 RVA: 0x00ABFFDC File Offset: 0x00ABE1DC
		// (set) Token: 0x0602D6EB RID: 186091 RVA: 0x00AC0015 File Offset: 0x00ABE215
		public FDataTableRowHandle UiCameraAnimationRow
		{
			get
			{
				base.FastCheckIsValid();
				FDataTableRowHandle result;
				if ((result = this._UiCameraAnimationRow) == null)
				{
					result = (this._UiCameraAnimationRow = new FDataTableRowHandle(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FDataTableRowHandle.StaticStruct(), base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007BFE RID: 31742
		// (get) Token: 0x0602D6EC RID: 186092 RVA: 0x00AC0036 File Offset: 0x00ABE236
		// (set) Token: 0x0602D6ED RID: 186093 RVA: 0x00AC0046 File Offset: 0x00ABE246
		public unsafe bool IsAutoTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BFF RID: 31743
		// (get) Token: 0x0602D6EE RID: 186094 RVA: 0x00AC0057 File Offset: 0x00ABE257
		// (set) Token: 0x0602D6EF RID: 186095 RVA: 0x00AC0067 File Offset: 0x00ABE267
		public unsafe float OffsetTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007C00 RID: 31744
		// (get) Token: 0x0602D6F0 RID: 186096 RVA: 0x00AC0078 File Offset: 0x00ABE278
		// (set) Token: 0x0602D6F1 RID: 186097 RVA: 0x00AC0088 File Offset: 0x00ABE288
		public unsafe float MaxOffsetTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007C01 RID: 31745
		// (get) Token: 0x0602D6F2 RID: 186098 RVA: 0x00AC009C File Offset: 0x00ABE29C
		// (set) Token: 0x0602D6F3 RID: 186099 RVA: 0x00AC00D5 File Offset: 0x00ABE2D5
		public FCameraFilmbackSettings Filmback
		{
			get
			{
				base.FastCheckIsValid();
				FCameraFilmbackSettings result;
				if ((result = this._Filmback) == null)
				{
					result = (this._Filmback = new FCameraFilmbackSettings(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FCameraFilmbackSettings.StaticStruct(), base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C02 RID: 31746
		// (get) Token: 0x0602D6F4 RID: 186100 RVA: 0x00AC00F6 File Offset: 0x00ABE2F6
		// (set) Token: 0x0602D6F5 RID: 186101 RVA: 0x00AC0106 File Offset: 0x00ABE306
		public unsafe bool Constrain_Aspect_Ratio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C03 RID: 31747
		// (get) Token: 0x0602D6F6 RID: 186102 RVA: 0x00AC0117 File Offset: 0x00ABE317
		// (set) Token: 0x0602D6F7 RID: 186103 RVA: 0x00AC0127 File Offset: 0x00ABE327
		public unsafe float Current_Focal_Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007C04 RID: 31748
		// (get) Token: 0x0602D6F8 RID: 186104 RVA: 0x00AC0138 File Offset: 0x00ABE338
		// (set) Token: 0x0602D6F9 RID: 186105 RVA: 0x00AC0148 File Offset: 0x00ABE348
		public unsafe float Current_Aperture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007C05 RID: 31749
		// (get) Token: 0x0602D6FA RID: 186106 RVA: 0x00AC015C File Offset: 0x00ABE35C
		// (set) Token: 0x0602D6FB RID: 186107 RVA: 0x00AC0195 File Offset: 0x00ABE395
		public FCameraFocusSettings Focus_Settings
		{
			get
			{
				base.FastCheckIsValid();
				FCameraFocusSettings result;
				if ((result = this._Focus_Settings) == null)
				{
					result = (this._Focus_Settings = new FCameraFocusSettings(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FCameraFocusSettings.StaticStruct(), base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C06 RID: 31750
		// (get) Token: 0x0602D6FC RID: 186108 RVA: 0x00AC01B8 File Offset: 0x00ABE3B8
		// (set) Token: 0x0602D6FD RID: 186109 RVA: 0x00AC01F1 File Offset: 0x00ABE3F1
		public FCameraLensSettings Lens_Settings
		{
			get
			{
				base.FastCheckIsValid();
				FCameraLensSettings result;
				if ((result = this._Lens_Settings) == null)
				{
					result = (this._Lens_Settings = new FCameraLensSettings(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FCameraLensSettings.StaticStruct(), base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C07 RID: 31751
		// (get) Token: 0x0602D6FE RID: 186110 RVA: 0x00AC0212 File Offset: 0x00ABE412
		// (set) Token: 0x0602D6FF RID: 186111 RVA: 0x00AC0222 File Offset: 0x00ABE422
		public unsafe float FocalRegion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CineCamera_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x0602D700 RID: 186112 RVA: 0x00AC0233 File Offset: 0x00ABE433
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetSeqCineCamSetting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CineCamera_C.__ResetSeqCineCamSetting_NativeFunctionPtr, null);
		}

		// Token: 0x0602D701 RID: 186113 RVA: 0x00AC0247 File Offset: 0x00ABE447
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ApplyUiCameraSettings()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CineCamera_C.__ApplyUiCameraSettings_NativeFunctionPtr, null);
		}

		// Token: 0x0602D702 RID: 186114 RVA: 0x00AC025C File Offset: 0x00ABE45C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BeginAutoTransform(float TimeLength)
		{
			BP_CineCamera_C.__BeginAutoTransform_FunctionParams* ptr = stackalloc BP_CineCamera_C.__BeginAutoTransform_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CineCamera_C.__BeginAutoTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CineCamera_C.__BeginAutoTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TimeLength = TimeLength;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CineCamera_C.__BeginAutoTransform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602D703 RID: 186115 RVA: 0x00AC02A4 File Offset: 0x00ABE4A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BeginAutoTransform_Implementation(float TimeLength)
		{
			BP_CineCamera_C.__BeginAutoTransform_FunctionParams* ptr = stackalloc BP_CineCamera_C.__BeginAutoTransform_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CineCamera_C.__BeginAutoTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CineCamera_C.__BeginAutoTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TimeLength = TimeLength;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CineCamera_C.__BeginAutoTransform_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602D704 RID: 186116 RVA: 0x00AC02EB File Offset: 0x00ABE4EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndAutoTransform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CineCamera_C.__EndAutoTransform_NativeFunctionPtr, null);
		}

		// Token: 0x0602D705 RID: 186117 RVA: 0x00AC02FF File Offset: 0x00ABE4FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EndAutoTransform_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CineCamera_C.__EndAutoTransform_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602D706 RID: 186118 RVA: 0x00AC0314 File Offset: 0x00ABE514
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CineCamera_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CineCamera_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CineCamera_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CineCamera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CineCamera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602D707 RID: 186119 RVA: 0x00AC035C File Offset: 0x00ABE55C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CineCamera_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CineCamera_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CineCamera_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CineCamera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CineCamera_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602D708 RID: 186120 RVA: 0x00AC03A4 File Offset: 0x00ABE5A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CineCamera(int EntryPoint)
		{
			BP_CineCamera_C.__ExecuteUbergraph_BP_CineCamera_FunctionParams* ptr = stackalloc BP_CineCamera_C.__ExecuteUbergraph_BP_CineCamera_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_CineCamera_C.__ExecuteUbergraph_BP_CineCamera_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CineCamera_C.__ExecuteUbergraph_BP_CineCamera_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CineCamera_C.__ExecuteUbergraph_BP_CineCamera_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602D709 RID: 186121 RVA: 0x00AC03EE File Offset: 0x00ABE5EE
		protected BP_CineCamera_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040197BF RID: 104383
		internal static int __InterfaceOffset_ISeqAutoTransformInterface;

		// Token: 0x040197C0 RID: 104384
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/BP_CineCamera.BP_CineCamera_C";

		// Token: 0x040197C1 RID: 104385
		private static IntPtr _ClassPtr;

		// Token: 0x040197C2 RID: 104386
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040197C3 RID: 104387
		internal static int __PropertyOffset_0;

		// Token: 0x040197C4 RID: 104388
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040197C5 RID: 104389
		internal static int __PropertyOffset_1;

		// Token: 0x040197C6 RID: 104390
		internal static int __PropertyOffset_2;

		// Token: 0x040197C7 RID: 104391
		[Nullable(2)]
		private FDataTableRowHandle _UiCameraAnimationRow;

		// Token: 0x040197C8 RID: 104392
		internal static int __PropertyOffset_3;

		// Token: 0x040197C9 RID: 104393
		internal static int __PropertyOffset_4;

		// Token: 0x040197CA RID: 104394
		internal static int __PropertyOffset_5;

		// Token: 0x040197CB RID: 104395
		internal static int __PropertyOffset_6;

		// Token: 0x040197CC RID: 104396
		[Nullable(2)]
		private FCameraFilmbackSettings _Filmback;

		// Token: 0x040197CD RID: 104397
		internal static int __PropertyOffset_7;

		// Token: 0x040197CE RID: 104398
		internal static int __PropertyOffset_8;

		// Token: 0x040197CF RID: 104399
		internal static int __PropertyOffset_9;

		// Token: 0x040197D0 RID: 104400
		internal static int __PropertyOffset_10;

		// Token: 0x040197D1 RID: 104401
		[Nullable(2)]
		private FCameraFocusSettings _Focus_Settings;

		// Token: 0x040197D2 RID: 104402
		internal static int __PropertyOffset_11;

		// Token: 0x040197D3 RID: 104403
		[Nullable(2)]
		private FCameraLensSettings _Lens_Settings;

		// Token: 0x040197D4 RID: 104404
		internal static int __PropertyOffset_12;

		// Token: 0x040197D5 RID: 104405
		private static IntPtr __ResetSeqCineCamSetting_NativeFunctionPtr;

		// Token: 0x040197D6 RID: 104406
		private static IntPtr __ApplyUiCameraSettings_NativeFunctionPtr;

		// Token: 0x040197D7 RID: 104407
		private static IntPtr __BeginAutoTransform_NativeFunctionPtr;

		// Token: 0x040197D8 RID: 104408
		private static IntPtr __EndAutoTransform_NativeFunctionPtr;

		// Token: 0x040197D9 RID: 104409
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040197DA RID: 104410
		private static IntPtr __ExecuteUbergraph_BP_CineCamera_NativeFunctionPtr;

		// Token: 0x0200A52A RID: 42282
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __BeginAutoTransform_FunctionParams
		{
			// Token: 0x040333DA RID: 209882
			[FieldOffset(0)]
			public float TimeLength;
		}

		// Token: 0x0200A52B RID: 42283
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040333DB RID: 209883
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A52C RID: 42284
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __ExecuteUbergraph_BP_CineCamera_FunctionParams
		{
			// Token: 0x040333DC RID: 209884
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
