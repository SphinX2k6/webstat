using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools.RippleSwim;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A0E RID: 14862
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterInteractObjectRipple_Component.BP_WaterInteractObjectRipple_Component_C")]
	[UnrealStructLayout(312, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 305)]
	public class BP_WaterInteractObjectRipple_Component_C : UKuroBPActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E5EE RID: 124398 RVA: 0x008F406B File Offset: 0x008F226B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterInteractObjectRipple_Component_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterInteractObjectRipple_Component.BP_WaterInteractObjectRipple_Component_C");
			}
			return BP_WaterInteractObjectRipple_Component_C._ClassPtr;
		}

		// Token: 0x0601E5EF RID: 124399 RVA: 0x008F4090 File Offset: 0x008F2290
		public BP_WaterInteractObjectRipple_Component_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterInteractObjectRipple_Component_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E5F0 RID: 124400 RVA: 0x008F40B8 File Offset: 0x008F22B8
		[NullableContext(1)]
		public BP_WaterInteractObjectRipple_Component_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterInteractObjectRipple_Component_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170029E4 RID: 10724
		// (get) Token: 0x0601E5F1 RID: 124401 RVA: 0x008F40EC File Offset: 0x008F22EC
		// (set) Token: 0x0601E5F2 RID: 124402 RVA: 0x008F4125 File Offset: 0x008F2325
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170029E5 RID: 10725
		// (get) Token: 0x0601E5F3 RID: 124403 RVA: 0x008F4148 File Offset: 0x008F2348
		// (set) Token: 0x0601E5F4 RID: 124404 RVA: 0x008F4181 File Offset: 0x008F2381
		[Nullable(1)]
		public TArray<FVector> SphereList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._SphereList) == null)
				{
					result = (this._SphereList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SphereList.CopyAssign(value);
			}
		}

		// Token: 0x170029E6 RID: 10726
		// (get) Token: 0x0601E5F5 RID: 124405 RVA: 0x008F418F File Offset: 0x008F238F
		// (set) Token: 0x0601E5F6 RID: 124406 RVA: 0x008F41A3 File Offset: 0x008F23A3
		public unsafe BP_RippleSwim_C BP_RippleSwim
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleSwim_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170029E7 RID: 10727
		// (get) Token: 0x0601E5F7 RID: 124407 RVA: 0x008F41B8 File Offset: 0x008F23B8
		// (set) Token: 0x0601E5F8 RID: 124408 RVA: 0x008F41CC File Offset: 0x008F23CC
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170029E8 RID: 10728
		// (get) Token: 0x0601E5F9 RID: 124409 RVA: 0x008F41E1 File Offset: 0x008F23E1
		// (set) Token: 0x0601E5FA RID: 124410 RVA: 0x008F41F1 File Offset: 0x008F23F1
		public unsafe float CaptureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170029E9 RID: 10729
		// (get) Token: 0x0601E5FB RID: 124411 RVA: 0x008F4202 File Offset: 0x008F2402
		// (set) Token: 0x0601E5FC RID: 124412 RVA: 0x008F4216 File Offset: 0x008F2416
		public unsafe UMaterialInstanceDynamic Add_Points_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170029EA RID: 10730
		// (get) Token: 0x0601E5FD RID: 124413 RVA: 0x008F422B File Offset: 0x008F242B
		// (set) Token: 0x0601E5FE RID: 124414 RVA: 0x008F423F File Offset: 0x008F243F
		public unsafe UTextureRenderTarget2D PointRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170029EB RID: 10731
		// (get) Token: 0x0601E5FF RID: 124415 RVA: 0x008F4254 File Offset: 0x008F2454
		// (set) Token: 0x0601E600 RID: 124416 RVA: 0x008F428D File Offset: 0x008F248D
		[Nullable(1)]
		public TArray<bool> SphereListVaildList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._SphereListVaildList) == null)
				{
					result = (this._SphereListVaildList = new TArray<bool>(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SphereListVaildList.CopyAssign(value);
			}
		}

		// Token: 0x170029EC RID: 10732
		// (get) Token: 0x0601E601 RID: 124417 RVA: 0x008F429B File Offset: 0x008F249B
		// (set) Token: 0x0601E602 RID: 124418 RVA: 0x008F42AB File Offset: 0x008F24AB
		public unsafe float BuoyancyInteractRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170029ED RID: 10733
		// (get) Token: 0x0601E603 RID: 124419 RVA: 0x008F42BC File Offset: 0x008F24BC
		// (set) Token: 0x0601E604 RID: 124420 RVA: 0x008F42CC File Offset: 0x008F24CC
		public unsafe float BuoyancyInteractIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170029EE RID: 10734
		// (get) Token: 0x0601E605 RID: 124421 RVA: 0x008F42DD File Offset: 0x008F24DD
		// (set) Token: 0x0601E606 RID: 124422 RVA: 0x008F42ED File Offset: 0x008F24ED
		public unsafe bool HasValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterInteractObjectRipple_Component_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E607 RID: 124423 RVA: 0x008F4300 File Offset: 0x008F2500
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLocationWithVaildition(int Index, FVector SphereLocation, bool bVaild)
		{
			BP_WaterInteractObjectRipple_Component_C.__SetLocationWithVaildition_FunctionParams* ptr = stackalloc BP_WaterInteractObjectRipple_Component_C.__SetLocationWithVaildition_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_WaterInteractObjectRipple_Component_C.__SetLocationWithVaildition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterInteractObjectRipple_Component_C.__SetLocationWithVaildition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Index = Index;
			ptr->SphereLocation = SphereLocation;
			ptr->bVaild = bVaild;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__SetLocationWithVaildition_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E608 RID: 124424 RVA: 0x008F4354 File Offset: 0x008F2554
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetSphere()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__SetSphere_NativeFunctionPtr, null);
		}

		// Token: 0x0601E609 RID: 124425 RVA: 0x008F4368 File Offset: 0x008F2568
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalcTexCoord2D(FVectorDouble RippleCenter, FVector2D RipplePointLocation, float CaptureSize, ref FVector2D TexCoord)
		{
			BP_WaterInteractObjectRipple_Component_C.__CalcTexCoord2D_FunctionParams* ptr = stackalloc BP_WaterInteractObjectRipple_Component_C.__CalcTexCoord2D_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_WaterInteractObjectRipple_Component_C.__CalcTexCoord2D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterInteractObjectRipple_Component_C.__CalcTexCoord2D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RippleCenter = RippleCenter;
			ptr->RipplePointLocation = RipplePointLocation;
			ptr->CaptureSize = CaptureSize;
			ptr->TexCoord = TexCoord;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__CalcTexCoord2D_NativeFunctionPtr, (void*)ptr);
			TexCoord = ptr->TexCoord;
		}

		// Token: 0x0601E60A RID: 124426 RVA: 0x008F43D9 File Offset: 0x008F25D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E60B RID: 124427 RVA: 0x008F43ED File Offset: 0x008F25ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E60C RID: 124428 RVA: 0x008F4404 File Offset: 0x008F2604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E60D RID: 124429 RVA: 0x008F444C File Offset: 0x008F264C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E60E RID: 124430 RVA: 0x008F4494 File Offset: 0x008F2694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterInteractObjectRipple_Component(int EntryPoint)
		{
			BP_WaterInteractObjectRipple_Component_C.__ExecuteUbergraph_BP_WaterInteractObjectRipple_Component_FunctionParams* ptr = stackalloc BP_WaterInteractObjectRipple_Component_C.__ExecuteUbergraph_BP_WaterInteractObjectRipple_Component_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_WaterInteractObjectRipple_Component_C.__ExecuteUbergraph_BP_WaterInteractObjectRipple_Component_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterInteractObjectRipple_Component_C.__ExecuteUbergraph_BP_WaterInteractObjectRipple_Component_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterInteractObjectRipple_Component_C.__ExecuteUbergraph_BP_WaterInteractObjectRipple_Component_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E60F RID: 124431 RVA: 0x008F44DE File Offset: 0x008F26DE
		protected BP_WaterInteractObjectRipple_Component_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EF1C RID: 61212
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterInteractObjectRipple_Component.BP_WaterInteractObjectRipple_Component_C";

		// Token: 0x0400EF1D RID: 61213
		private static IntPtr _ClassPtr;

		// Token: 0x0400EF1E RID: 61214
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EF1F RID: 61215
		internal static int __PropertyOffset_0;

		// Token: 0x0400EF20 RID: 61216
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EF21 RID: 61217
		internal static int __PropertyOffset_1;

		// Token: 0x0400EF22 RID: 61218
		private TArray<FVector> _SphereList;

		// Token: 0x0400EF23 RID: 61219
		internal static int __PropertyOffset_2;

		// Token: 0x0400EF24 RID: 61220
		internal static int __PropertyOffset_3;

		// Token: 0x0400EF25 RID: 61221
		internal static int __PropertyOffset_4;

		// Token: 0x0400EF26 RID: 61222
		internal static int __PropertyOffset_5;

		// Token: 0x0400EF27 RID: 61223
		internal static int __PropertyOffset_6;

		// Token: 0x0400EF28 RID: 61224
		internal static int __PropertyOffset_7;

		// Token: 0x0400EF29 RID: 61225
		private TArray<bool> _SphereListVaildList;

		// Token: 0x0400EF2A RID: 61226
		internal static int __PropertyOffset_8;

		// Token: 0x0400EF2B RID: 61227
		internal static int __PropertyOffset_9;

		// Token: 0x0400EF2C RID: 61228
		internal static int __PropertyOffset_10;

		// Token: 0x0400EF2D RID: 61229
		private static IntPtr __SetLocationWithVaildition_NativeFunctionPtr;

		// Token: 0x0400EF2E RID: 61230
		private static IntPtr __SetSphere_NativeFunctionPtr;

		// Token: 0x0400EF2F RID: 61231
		private static IntPtr __CalcTexCoord2D_NativeFunctionPtr;

		// Token: 0x0400EF30 RID: 61232
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EF31 RID: 61233
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EF32 RID: 61234
		private static IntPtr __ExecuteUbergraph_BP_WaterInteractObjectRipple_Component_NativeFunctionPtr;

		// Token: 0x020097AE RID: 38830
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __SetLocationWithVaildition_FunctionParams
		{
			// Token: 0x04031D82 RID: 204162
			[FieldOffset(0)]
			public int Index;

			// Token: 0x04031D83 RID: 204163
			[FieldOffset(4)]
			public FVector SphereLocation;

			// Token: 0x04031D84 RID: 204164
			[FieldOffset(16)]
			public bool bVaild;
		}

		// Token: 0x020097AF RID: 38831
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __CalcTexCoord2D_FunctionParams
		{
			// Token: 0x04031D85 RID: 204165
			[FieldOffset(0)]
			public FVectorDouble RippleCenter;

			// Token: 0x04031D86 RID: 204166
			[FieldOffset(24)]
			public FVector2D RipplePointLocation;

			// Token: 0x04031D87 RID: 204167
			[FieldOffset(32)]
			public float CaptureSize;

			// Token: 0x04031D88 RID: 204168
			[FieldOffset(36)]
			public FVector2D TexCoord;
		}

		// Token: 0x020097B0 RID: 38832
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D89 RID: 204169
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097B1 RID: 38833
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __ExecuteUbergraph_BP_WaterInteractObjectRipple_Component_FunctionParams
		{
			// Token: 0x04031D8A RID: 204170
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
