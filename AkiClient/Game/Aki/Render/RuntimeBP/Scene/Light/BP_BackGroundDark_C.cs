using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A76 RID: 14966
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_BackGroundDark.BP_BackGroundDark_C")]
	[UnrealStructLayout(1632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1625)]
	public class BP_BackGroundDark_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F363 RID: 127843 RVA: 0x0090BAEF File Offset: 0x00909CEF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BackGroundDark_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_BackGroundDark.BP_BackGroundDark_C");
			}
			return BP_BackGroundDark_C._ClassPtr;
		}

		// Token: 0x0601F364 RID: 127844 RVA: 0x0090BB14 File Offset: 0x00909D14
		public BP_BackGroundDark_C() : this(BuiltinUtils.AllocNativeUObject(BP_BackGroundDark_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F365 RID: 127845 RVA: 0x0090BB3C File Offset: 0x00909D3C
		[NullableContext(1)]
		public BP_BackGroundDark_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BackGroundDark_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E90 RID: 11920
		// (get) Token: 0x0601F366 RID: 127846 RVA: 0x0090BB70 File Offset: 0x00909D70
		// (set) Token: 0x0601F367 RID: 127847 RVA: 0x0090BBA9 File Offset: 0x00909DA9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E91 RID: 11921
		// (get) Token: 0x0601F368 RID: 127848 RVA: 0x0090BBCA File Offset: 0x00909DCA
		// (set) Token: 0x0601F369 RID: 127849 RVA: 0x0090BBDE File Offset: 0x00909DDE
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E92 RID: 11922
		// (get) Token: 0x0601F36A RID: 127850 RVA: 0x0090BBF3 File Offset: 0x00909DF3
		// (set) Token: 0x0601F36B RID: 127851 RVA: 0x0090BC07 File Offset: 0x00909E07
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002E93 RID: 11923
		// (get) Token: 0x0601F36C RID: 127852 RVA: 0x0090BC1C File Offset: 0x00909E1C
		// (set) Token: 0x0601F36D RID: 127853 RVA: 0x0090BC30 File Offset: 0x00909E30
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002E94 RID: 11924
		// (get) Token: 0x0601F36E RID: 127854 RVA: 0x0090BC48 File Offset: 0x00909E48
		// (set) Token: 0x0601F36F RID: 127855 RVA: 0x0090BC81 File Offset: 0x00909E81
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002E95 RID: 11925
		// (get) Token: 0x0601F370 RID: 127856 RVA: 0x0090BC90 File Offset: 0x00909E90
		// (set) Token: 0x0601F371 RID: 127857 RVA: 0x0090BCC9 File Offset: 0x00909EC9
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002E96 RID: 11926
		// (get) Token: 0x0601F372 RID: 127858 RVA: 0x0090BCD8 File Offset: 0x00909ED8
		// (set) Token: 0x0601F373 RID: 127859 RVA: 0x0090BD11 File Offset: 0x00909F11
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002E97 RID: 11927
		// (get) Token: 0x0601F374 RID: 127860 RVA: 0x0090BD1F File Offset: 0x00909F1F
		// (set) Token: 0x0601F375 RID: 127861 RVA: 0x0090BD33 File Offset: 0x00909F33
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BackGroundDark_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002E98 RID: 11928
		// (get) Token: 0x0601F376 RID: 127862 RVA: 0x0090BD48 File Offset: 0x00909F48
		// (set) Token: 0x0601F377 RID: 127863 RVA: 0x0090BD58 File Offset: 0x00909F58
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002E99 RID: 11929
		// (get) Token: 0x0601F378 RID: 127864 RVA: 0x0090BD69 File Offset: 0x00909F69
		// (set) Token: 0x0601F379 RID: 127865 RVA: 0x0090BD7D File Offset: 0x00909F7D
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002E9A RID: 11930
		// (get) Token: 0x0601F37A RID: 127866 RVA: 0x0090BD92 File Offset: 0x00909F92
		// (set) Token: 0x0601F37B RID: 127867 RVA: 0x0090BDA2 File Offset: 0x00909FA2
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002E9B RID: 11931
		// (get) Token: 0x0601F37C RID: 127868 RVA: 0x0090BDB3 File Offset: 0x00909FB3
		// (set) Token: 0x0601F37D RID: 127869 RVA: 0x0090BDC3 File Offset: 0x00909FC3
		public unsafe float Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002E9C RID: 11932
		// (get) Token: 0x0601F37E RID: 127870 RVA: 0x0090BDD4 File Offset: 0x00909FD4
		// (set) Token: 0x0601F37F RID: 127871 RVA: 0x0090BDE4 File Offset: 0x00909FE4
		public unsafe float Depth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002E9D RID: 11933
		// (get) Token: 0x0601F380 RID: 127872 RVA: 0x0090BDF5 File Offset: 0x00909FF5
		// (set) Token: 0x0601F381 RID: 127873 RVA: 0x0090BE05 File Offset: 0x0090A005
		public unsafe bool AfterTranslucent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BackGroundDark_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F382 RID: 127874 RVA: 0x0090BE16 File Offset: 0x0090A016
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BackGroundDark_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F383 RID: 127875 RVA: 0x0090BE2A File Offset: 0x0090A02A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BackGroundDark_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F384 RID: 127876 RVA: 0x0090BE3E File Offset: 0x0090A03E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BackGroundDark_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F385 RID: 127877 RVA: 0x0090BE53 File Offset: 0x0090A053
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BackGroundDark_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F386 RID: 127878 RVA: 0x0090BE67 File Offset: 0x0090A067
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BackGroundDark_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F387 RID: 127879 RVA: 0x0090BE7C File Offset: 0x0090A07C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BackGroundDark_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BackGroundDark_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BackGroundDark_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BackGroundDark_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BackGroundDark_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F388 RID: 127880 RVA: 0x0090BEC4 File Offset: 0x0090A0C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BackGroundDark_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BackGroundDark_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BackGroundDark_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BackGroundDark_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BackGroundDark_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F389 RID: 127881 RVA: 0x0090BF0B File Offset: 0x0090A10B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BackGroundDark_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F38A RID: 127882 RVA: 0x0090BF1F File Offset: 0x0090A11F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BackGroundDark_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F38B RID: 127883 RVA: 0x0090BF34 File Offset: 0x0090A134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_BackGroundDark_C.__EditorTick_FunctionParams* ptr = stackalloc BP_BackGroundDark_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BackGroundDark_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BackGroundDark_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BackGroundDark_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F38C RID: 127884 RVA: 0x0090BF7C File Offset: 0x0090A17C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_BackGroundDark_C.__EditorTick_FunctionParams* ptr = stackalloc BP_BackGroundDark_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BackGroundDark_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BackGroundDark_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BackGroundDark_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F38D RID: 127885 RVA: 0x0090BFC4 File Offset: 0x0090A1C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BackGroundDark(int EntryPoint)
		{
			BP_BackGroundDark_C.__ExecuteUbergraph_BP_BackGroundDark_FunctionParams* ptr = stackalloc BP_BackGroundDark_C.__ExecuteUbergraph_BP_BackGroundDark_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_BackGroundDark_C.__ExecuteUbergraph_BP_BackGroundDark_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BackGroundDark_C.__ExecuteUbergraph_BP_BackGroundDark_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BackGroundDark_C.__ExecuteUbergraph_BP_BackGroundDark_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F38E RID: 127886 RVA: 0x0090C00E File Offset: 0x0090A20E
		protected BP_BackGroundDark_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F7AC RID: 63404
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_BackGroundDark.BP_BackGroundDark_C";

		// Token: 0x0400F7AD RID: 63405
		private static IntPtr _ClassPtr;

		// Token: 0x0400F7AE RID: 63406
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F7AF RID: 63407
		internal static int __PropertyOffset_0;

		// Token: 0x0400F7B0 RID: 63408
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F7B1 RID: 63409
		internal static int __PropertyOffset_1;

		// Token: 0x0400F7B2 RID: 63410
		internal static int __PropertyOffset_2;

		// Token: 0x0400F7B3 RID: 63411
		internal static int __PropertyOffset_3;

		// Token: 0x0400F7B4 RID: 63412
		internal static int __PropertyOffset_4;

		// Token: 0x0400F7B5 RID: 63413
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F7B6 RID: 63414
		internal static int __PropertyOffset_5;

		// Token: 0x0400F7B7 RID: 63415
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F7B8 RID: 63416
		internal static int __PropertyOffset_6;

		// Token: 0x0400F7B9 RID: 63417
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F7BA RID: 63418
		internal static int __PropertyOffset_7;

		// Token: 0x0400F7BB RID: 63419
		internal static int __PropertyOffset_8;

		// Token: 0x0400F7BC RID: 63420
		internal static int __PropertyOffset_9;

		// Token: 0x0400F7BD RID: 63421
		internal static int __PropertyOffset_10;

		// Token: 0x0400F7BE RID: 63422
		internal static int __PropertyOffset_11;

		// Token: 0x0400F7BF RID: 63423
		internal static int __PropertyOffset_12;

		// Token: 0x0400F7C0 RID: 63424
		internal static int __PropertyOffset_13;

		// Token: 0x0400F7C1 RID: 63425
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400F7C2 RID: 63426
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F7C3 RID: 63427
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F7C4 RID: 63428
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F7C5 RID: 63429
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F7C6 RID: 63430
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F7C7 RID: 63431
		private static IntPtr __ExecuteUbergraph_BP_BackGroundDark_NativeFunctionPtr;

		// Token: 0x020098AD RID: 39085
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031EFE RID: 204542
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098AE RID: 39086
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031EFF RID: 204543
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098AF RID: 39087
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_BP_BackGroundDark_FunctionParams
		{
			// Token: 0x04031F00 RID: 204544
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
