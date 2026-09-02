using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LeavesInteraction
{
	// Token: 0x02003C65 RID: 15461
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesRuntimeDepthCapture.BP_LeavesRuntimeDepthCapture_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1346)]
	public class BP_LeavesRuntimeDepthCapture_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023CE1 RID: 146657 RVA: 0x0098C8DF File Offset: 0x0098AADF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LeavesRuntimeDepthCapture_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesRuntimeDepthCapture.BP_LeavesRuntimeDepthCapture_C");
			}
			return BP_LeavesRuntimeDepthCapture_C._ClassPtr;
		}

		// Token: 0x06023CE2 RID: 146658 RVA: 0x0098C904 File Offset: 0x0098AB04
		public BP_LeavesRuntimeDepthCapture_C() : this(BuiltinUtils.AllocNativeUObject(BP_LeavesRuntimeDepthCapture_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023CE3 RID: 146659 RVA: 0x0098C92C File Offset: 0x0098AB2C
		[NullableContext(1)]
		public BP_LeavesRuntimeDepthCapture_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LeavesRuntimeDepthCapture_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700486F RID: 18543
		// (get) Token: 0x06023CE4 RID: 146660 RVA: 0x0098C960 File Offset: 0x0098AB60
		// (set) Token: 0x06023CE5 RID: 146661 RVA: 0x0098C999 File Offset: 0x0098AB99
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004870 RID: 18544
		// (get) Token: 0x06023CE6 RID: 146662 RVA: 0x0098C9BA File Offset: 0x0098ABBA
		// (set) Token: 0x06023CE7 RID: 146663 RVA: 0x0098C9CE File Offset: 0x0098ABCE
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004871 RID: 18545
		// (get) Token: 0x06023CE8 RID: 146664 RVA: 0x0098C9E3 File Offset: 0x0098ABE3
		// (set) Token: 0x06023CE9 RID: 146665 RVA: 0x0098C9F7 File Offset: 0x0098ABF7
		public unsafe UKuroCustomCaptureVolume KuroCustomCaptureVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCustomCaptureVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004872 RID: 18546
		// (get) Token: 0x06023CEA RID: 146666 RVA: 0x0098CA0C File Offset: 0x0098AC0C
		// (set) Token: 0x06023CEB RID: 146667 RVA: 0x0098CA20 File Offset: 0x0098AC20
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004873 RID: 18547
		// (get) Token: 0x06023CEC RID: 146668 RVA: 0x0098CA35 File Offset: 0x0098AC35
		// (set) Token: 0x06023CED RID: 146669 RVA: 0x0098CA49 File Offset: 0x0098AC49
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004874 RID: 18548
		// (get) Token: 0x06023CEE RID: 146670 RVA: 0x0098CA5E File Offset: 0x0098AC5E
		// (set) Token: 0x06023CEF RID: 146671 RVA: 0x0098CA72 File Offset: 0x0098AC72
		[Nullable(0)]
		public unsafe TEnumAsByte<ECaptureMode> CaptureMode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004875 RID: 18549
		// (get) Token: 0x06023CF0 RID: 146672 RVA: 0x0098CA87 File Offset: 0x0098AC87
		// (set) Token: 0x06023CF1 RID: 146673 RVA: 0x0098CA97 File Offset: 0x0098AC97
		public unsafe bool bCapture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LeavesRuntimeDepthCapture_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023CF2 RID: 146674 RVA: 0x0098CAA8 File Offset: 0x0098ACA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesRuntimeDepthCapture_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023CF3 RID: 146675 RVA: 0x0098CABC File Offset: 0x0098ACBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesRuntimeDepthCapture_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023CF4 RID: 146676 RVA: 0x0098CAD4 File Offset: 0x0098ACD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023CF5 RID: 146677 RVA: 0x0098CB1C File Offset: 0x0098AD1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesRuntimeDepthCapture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023CF6 RID: 146678 RVA: 0x0098CB64 File Offset: 0x0098AD64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LeavesRuntimeDepthCapture(int EntryPoint)
		{
			BP_LeavesRuntimeDepthCapture_C.__ExecuteUbergraph_BP_LeavesRuntimeDepthCapture_FunctionParams* ptr = stackalloc BP_LeavesRuntimeDepthCapture_C.__ExecuteUbergraph_BP_LeavesRuntimeDepthCapture_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_LeavesRuntimeDepthCapture_C.__ExecuteUbergraph_BP_LeavesRuntimeDepthCapture_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LeavesRuntimeDepthCapture_C.__ExecuteUbergraph_BP_LeavesRuntimeDepthCapture_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LeavesRuntimeDepthCapture_C.__ExecuteUbergraph_BP_LeavesRuntimeDepthCapture_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023CF7 RID: 146679 RVA: 0x0098CBAE File Offset: 0x0098ADAE
		protected BP_LeavesRuntimeDepthCapture_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401246F RID: 74863
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_LeavesRuntimeDepthCapture.BP_LeavesRuntimeDepthCapture_C";

		// Token: 0x04012470 RID: 74864
		private static IntPtr _ClassPtr;

		// Token: 0x04012471 RID: 74865
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012472 RID: 74866
		internal static int __PropertyOffset_0;

		// Token: 0x04012473 RID: 74867
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012474 RID: 74868
		internal static int __PropertyOffset_1;

		// Token: 0x04012475 RID: 74869
		internal static int __PropertyOffset_2;

		// Token: 0x04012476 RID: 74870
		internal static int __PropertyOffset_3;

		// Token: 0x04012477 RID: 74871
		internal static int __PropertyOffset_4;

		// Token: 0x04012478 RID: 74872
		internal static int __PropertyOffset_5;

		// Token: 0x04012479 RID: 74873
		internal static int __PropertyOffset_6;

		// Token: 0x0401247A RID: 74874
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401247B RID: 74875
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401247C RID: 74876
		private static IntPtr __ExecuteUbergraph_BP_LeavesRuntimeDepthCapture_NativeFunctionPtr;

		// Token: 0x02009D44 RID: 40260
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032720 RID: 206624
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D45 RID: 40261
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_BP_LeavesRuntimeDepthCapture_FunctionParams
		{
			// Token: 0x04032721 RID: 206625
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
