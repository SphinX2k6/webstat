using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AAB RID: 15019
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_WaterRadius.BP_WaterRadius_C")]
	[UnrealStructLayout(1640, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1636)]
	public class BP_WaterRadius_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FFC2 RID: 131010 RVA: 0x0091F020 File Offset: 0x0091D220
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterRadius_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_WaterRadius.BP_WaterRadius_C");
			}
			return BP_WaterRadius_C._ClassPtr;
		}

		// Token: 0x0601FFC3 RID: 131011 RVA: 0x0091F044 File Offset: 0x0091D244
		public BP_WaterRadius_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterRadius_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FFC4 RID: 131012 RVA: 0x0091F06C File Offset: 0x0091D26C
		[NullableContext(1)]
		public BP_WaterRadius_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterRadius_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003358 RID: 13144
		// (get) Token: 0x0601FFC5 RID: 131013 RVA: 0x0091F0A0 File Offset: 0x0091D2A0
		// (set) Token: 0x0601FFC6 RID: 131014 RVA: 0x0091F0D9 File Offset: 0x0091D2D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003359 RID: 13145
		// (get) Token: 0x0601FFC7 RID: 131015 RVA: 0x0091F0FA File Offset: 0x0091D2FA
		// (set) Token: 0x0601FFC8 RID: 131016 RVA: 0x0091F10E File Offset: 0x0091D30E
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700335A RID: 13146
		// (get) Token: 0x0601FFC9 RID: 131017 RVA: 0x0091F123 File Offset: 0x0091D323
		// (set) Token: 0x0601FFCA RID: 131018 RVA: 0x0091F137 File Offset: 0x0091D337
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700335B RID: 13147
		// (get) Token: 0x0601FFCB RID: 131019 RVA: 0x0091F14C File Offset: 0x0091D34C
		// (set) Token: 0x0601FFCC RID: 131020 RVA: 0x0091F160 File Offset: 0x0091D360
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700335C RID: 13148
		// (get) Token: 0x0601FFCD RID: 131021 RVA: 0x0091F175 File Offset: 0x0091D375
		// (set) Token: 0x0601FFCE RID: 131022 RVA: 0x0091F189 File Offset: 0x0091D389
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700335D RID: 13149
		// (get) Token: 0x0601FFCF RID: 131023 RVA: 0x0091F1A0 File Offset: 0x0091D3A0
		// (set) Token: 0x0601FFD0 RID: 131024 RVA: 0x0091F1D9 File Offset: 0x0091D3D9
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700335E RID: 13150
		// (get) Token: 0x0601FFD1 RID: 131025 RVA: 0x0091F1E8 File Offset: 0x0091D3E8
		// (set) Token: 0x0601FFD2 RID: 131026 RVA: 0x0091F221 File Offset: 0x0091D421
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700335F RID: 13151
		// (get) Token: 0x0601FFD3 RID: 131027 RVA: 0x0091F230 File Offset: 0x0091D430
		// (set) Token: 0x0601FFD4 RID: 131028 RVA: 0x0091F269 File Offset: 0x0091D469
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17003360 RID: 13152
		// (get) Token: 0x0601FFD5 RID: 131029 RVA: 0x0091F277 File Offset: 0x0091D477
		// (set) Token: 0x0601FFD6 RID: 131030 RVA: 0x0091F28B File Offset: 0x0091D48B
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRadius_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003361 RID: 13153
		// (get) Token: 0x0601FFD7 RID: 131031 RVA: 0x0091F2A0 File Offset: 0x0091D4A0
		// (set) Token: 0x0601FFD8 RID: 131032 RVA: 0x0091F2B0 File Offset: 0x0091D4B0
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003362 RID: 13154
		// (get) Token: 0x0601FFD9 RID: 131033 RVA: 0x0091F2C1 File Offset: 0x0091D4C1
		// (set) Token: 0x0601FFDA RID: 131034 RVA: 0x0091F2D5 File Offset: 0x0091D4D5
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003363 RID: 13155
		// (get) Token: 0x0601FFDB RID: 131035 RVA: 0x0091F2EA File Offset: 0x0091D4EA
		// (set) Token: 0x0601FFDC RID: 131036 RVA: 0x0091F2FA File Offset: 0x0091D4FA
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003364 RID: 13156
		// (get) Token: 0x0601FFDD RID: 131037 RVA: 0x0091F30B File Offset: 0x0091D50B
		// (set) Token: 0x0601FFDE RID: 131038 RVA: 0x0091F31B File Offset: 0x0091D51B
		public unsafe float Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003365 RID: 13157
		// (get) Token: 0x0601FFDF RID: 131039 RVA: 0x0091F32C File Offset: 0x0091D52C
		// (set) Token: 0x0601FFE0 RID: 131040 RVA: 0x0091F33C File Offset: 0x0091D53C
		public unsafe float Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003366 RID: 13158
		// (get) Token: 0x0601FFE1 RID: 131041 RVA: 0x0091F34D File Offset: 0x0091D54D
		// (set) Token: 0x0601FFE2 RID: 131042 RVA: 0x0091F35D File Offset: 0x0091D55D
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRadius_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x0601FFE3 RID: 131043 RVA: 0x0091F36E File Offset: 0x0091D56E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRadius_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601FFE4 RID: 131044 RVA: 0x0091F382 File Offset: 0x0091D582
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRadius_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FFE5 RID: 131045 RVA: 0x0091F396 File Offset: 0x0091D596
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRadius_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FFE6 RID: 131046 RVA: 0x0091F3AB File Offset: 0x0091D5AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRadius_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FFE7 RID: 131047 RVA: 0x0091F3BF File Offset: 0x0091D5BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRadius_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FFE8 RID: 131048 RVA: 0x0091F3D4 File Offset: 0x0091D5D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterRadius_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterRadius_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterRadius_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRadius_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRadius_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FFE9 RID: 131049 RVA: 0x0091F41C File Offset: 0x0091D61C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterRadius_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterRadius_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterRadius_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRadius_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRadius_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FFEA RID: 131050 RVA: 0x0091F463 File Offset: 0x0091D663
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRadius_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601FFEB RID: 131051 RVA: 0x0091F477 File Offset: 0x0091D677
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRadius_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FFEC RID: 131052 RVA: 0x0091F48C File Offset: 0x0091D68C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_WaterRadius_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WaterRadius_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterRadius_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRadius_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRadius_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FFED RID: 131053 RVA: 0x0091F4D4 File Offset: 0x0091D6D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_WaterRadius_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WaterRadius_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterRadius_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRadius_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRadius_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FFEE RID: 131054 RVA: 0x0091F51C File Offset: 0x0091D71C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterRadius(int EntryPoint)
		{
			BP_WaterRadius_C.__ExecuteUbergraph_BP_WaterRadius_FunctionParams* ptr = stackalloc BP_WaterRadius_C.__ExecuteUbergraph_BP_WaterRadius_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_WaterRadius_C.__ExecuteUbergraph_BP_WaterRadius_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRadius_C.__ExecuteUbergraph_BP_WaterRadius_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRadius_C.__ExecuteUbergraph_BP_WaterRadius_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FFEF RID: 131055 RVA: 0x0091F563 File Offset: 0x0091D763
		protected BP_WaterRadius_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FECC RID: 65228
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_WaterRadius.BP_WaterRadius_C";

		// Token: 0x0400FECD RID: 65229
		private static IntPtr _ClassPtr;

		// Token: 0x0400FECE RID: 65230
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FECF RID: 65231
		internal static int __PropertyOffset_0;

		// Token: 0x0400FED0 RID: 65232
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FED1 RID: 65233
		internal static int __PropertyOffset_1;

		// Token: 0x0400FED2 RID: 65234
		internal static int __PropertyOffset_2;

		// Token: 0x0400FED3 RID: 65235
		internal static int __PropertyOffset_3;

		// Token: 0x0400FED4 RID: 65236
		internal static int __PropertyOffset_4;

		// Token: 0x0400FED5 RID: 65237
		internal static int __PropertyOffset_5;

		// Token: 0x0400FED6 RID: 65238
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FED7 RID: 65239
		internal static int __PropertyOffset_6;

		// Token: 0x0400FED8 RID: 65240
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FED9 RID: 65241
		internal static int __PropertyOffset_7;

		// Token: 0x0400FEDA RID: 65242
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FEDB RID: 65243
		internal static int __PropertyOffset_8;

		// Token: 0x0400FEDC RID: 65244
		internal static int __PropertyOffset_9;

		// Token: 0x0400FEDD RID: 65245
		internal static int __PropertyOffset_10;

		// Token: 0x0400FEDE RID: 65246
		internal static int __PropertyOffset_11;

		// Token: 0x0400FEDF RID: 65247
		internal static int __PropertyOffset_12;

		// Token: 0x0400FEE0 RID: 65248
		internal static int __PropertyOffset_13;

		// Token: 0x0400FEE1 RID: 65249
		internal static int __PropertyOffset_14;

		// Token: 0x0400FEE2 RID: 65250
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400FEE3 RID: 65251
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FEE4 RID: 65252
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FEE5 RID: 65253
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FEE6 RID: 65254
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FEE7 RID: 65255
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FEE8 RID: 65256
		private static IntPtr __ExecuteUbergraph_BP_WaterRadius_NativeFunctionPtr;

		// Token: 0x02009940 RID: 39232
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F9F RID: 204703
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009941 RID: 39233
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031FA0 RID: 204704
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009942 RID: 39234
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_WaterRadius_FunctionParams
		{
			// Token: 0x04031FA1 RID: 204705
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
