using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Volumetrics;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SandTrail
{
	// Token: 0x02003B91 RID: 15249
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_NinjaSnow.BP_NinjaSnow_C")]
	[UnrealStructLayout(2104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2104)]
	public class BP_NinjaSnow_C : NinjaLive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021CB7 RID: 138423 RVA: 0x009539C3 File Offset: 0x00951BC3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NinjaSnow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_NinjaSnow.BP_NinjaSnow_C");
			}
			return BP_NinjaSnow_C._ClassPtr;
		}

		// Token: 0x06021CB8 RID: 138424 RVA: 0x009539E8 File Offset: 0x00951BE8
		public BP_NinjaSnow_C() : this(BuiltinUtils.AllocNativeUObject(BP_NinjaSnow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021CB9 RID: 138425 RVA: 0x00953A10 File Offset: 0x00951C10
		[NullableContext(1)]
		public BP_NinjaSnow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NinjaSnow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D12 RID: 15634
		// (get) Token: 0x06021CBA RID: 138426 RVA: 0x00953A44 File Offset: 0x00951C44
		// (set) Token: 0x06021CBB RID: 138427 RVA: 0x00953A7D File Offset: 0x00951C7D
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D13 RID: 15635
		// (get) Token: 0x06021CBC RID: 138428 RVA: 0x00953A9E File Offset: 0x00951C9E
		// (set) Token: 0x06021CBD RID: 138429 RVA: 0x00953AB2 File Offset: 0x00951CB2
		public unsafe UNiagaraComponent SnowParticle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaSnow_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaSnow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D14 RID: 15636
		// (get) Token: 0x06021CBE RID: 138430 RVA: 0x00953AC7 File Offset: 0x00951CC7
		// (set) Token: 0x06021CBF RID: 138431 RVA: 0x00953ADB File Offset: 0x00951CDB
		public unsafe VolumeSmokeComponent_C VolumeSmokeComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<VolumeSmokeComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaSnow_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaSnow_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D15 RID: 15637
		// (get) Token: 0x06021CC0 RID: 138432 RVA: 0x00953AF0 File Offset: 0x00951CF0
		// (set) Token: 0x06021CC1 RID: 138433 RVA: 0x00953B00 File Offset: 0x00951D00
		public unsafe bool bMoto
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D16 RID: 15638
		// (get) Token: 0x06021CC2 RID: 138434 RVA: 0x00953B11 File Offset: 0x00951D11
		// (set) Token: 0x06021CC3 RID: 138435 RVA: 0x00953B21 File Offset: 0x00951D21
		public unsafe float OriginKuroTrailEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003D17 RID: 15639
		// (get) Token: 0x06021CC4 RID: 138436 RVA: 0x00953B32 File Offset: 0x00951D32
		// (set) Token: 0x06021CC5 RID: 138437 RVA: 0x00953B42 File Offset: 0x00951D42
		public unsafe float CharacterVeloMotion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003D18 RID: 15640
		// (get) Token: 0x06021CC6 RID: 138438 RVA: 0x00953B53 File Offset: 0x00951D53
		// (set) Token: 0x06021CC7 RID: 138439 RVA: 0x00953B63 File Offset: 0x00951D63
		public unsafe float CharacterGlobalBrush
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003D19 RID: 15641
		// (get) Token: 0x06021CC8 RID: 138440 RVA: 0x00953B74 File Offset: 0x00951D74
		// (set) Token: 0x06021CC9 RID: 138441 RVA: 0x00953B88 File Offset: 0x00951D88
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaSnow_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NinjaSnow_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003D1A RID: 15642
		// (get) Token: 0x06021CCA RID: 138442 RVA: 0x00953B9D File Offset: 0x00951D9D
		// (set) Token: 0x06021CCB RID: 138443 RVA: 0x00953BAD File Offset: 0x00951DAD
		public unsafe bool bIsVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D1B RID: 15643
		// (get) Token: 0x06021CCC RID: 138444 RVA: 0x00953BC0 File Offset: 0x00951DC0
		// (set) Token: 0x06021CCD RID: 138445 RVA: 0x00953BF9 File Offset: 0x00951DF9
		[Nullable(1)]
		public TSet<string> physicMaterialSet
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TSet<string> result;
				if ((result = this._physicMaterialSet) == null)
				{
					result = (this._physicMaterialSet = new TSet<string>(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.physicMaterialSet.CopyAssign(value);
			}
		}

		// Token: 0x17003D1C RID: 15644
		// (get) Token: 0x06021CCE RID: 138446 RVA: 0x00953C07 File Offset: 0x00951E07
		// (set) Token: 0x06021CCF RID: 138447 RVA: 0x00953C17 File Offset: 0x00951E17
		public unsafe float BrushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003D1D RID: 15645
		// (get) Token: 0x06021CD0 RID: 138448 RVA: 0x00953C28 File Offset: 0x00951E28
		// (set) Token: 0x06021CD1 RID: 138449 RVA: 0x00953C38 File Offset: 0x00951E38
		public unsafe float BrushScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003D1E RID: 15646
		// (get) Token: 0x06021CD2 RID: 138450 RVA: 0x00953C49 File Offset: 0x00951E49
		// (set) Token: 0x06021CD3 RID: 138451 RVA: 0x00953C5D File Offset: 0x00951E5D
		public unsafe FVectorDouble ValidBoxLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NinjaSnow_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x06021CD4 RID: 138452 RVA: 0x00953C74 File Offset: 0x00951E74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool CheckQuality()
		{
			BP_NinjaSnow_C.__CheckQuality_FunctionParams* ptr = stackalloc BP_NinjaSnow_C.__CheckQuality_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_NinjaSnow_C.__CheckQuality_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaSnow_C.__CheckQuality_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaSnow_C.__CheckQuality_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06021CD5 RID: 138453 RVA: 0x00953CBC File Offset: 0x00951EBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_NinjaSnow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NinjaSnow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NinjaSnow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021CD6 RID: 138454 RVA: 0x00953D04 File Offset: 0x00951F04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_NinjaSnow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NinjaSnow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NinjaSnow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CD7 RID: 138455 RVA: 0x00953D4B File Offset: 0x00951F4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaSnow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021CD8 RID: 138456 RVA: 0x00953D5F File Offset: 0x00951F5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaSnow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021CD9 RID: 138457 RVA: 0x00953D74 File Offset: 0x00951F74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_NinjaSnow_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_NinjaSnow_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_NinjaSnow_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NinjaSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021CDA RID: 138458 RVA: 0x00953DC0 File Offset: 0x00951FC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_NinjaSnow_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_NinjaSnow_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_NinjaSnow_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaSnow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CDB RID: 138459 RVA: 0x00953E0C File Offset: 0x0095200C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NinjaSnow(int EntryPoint)
		{
			BP_NinjaSnow_C.__ExecuteUbergraph_BP_NinjaSnow_FunctionParams* ptr = stackalloc BP_NinjaSnow_C.__ExecuteUbergraph_BP_NinjaSnow_FunctionParams[(UIntPtr)1111] + 15L / (long)sizeof(BP_NinjaSnow_C.__ExecuteUbergraph_BP_NinjaSnow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NinjaSnow_C.__ExecuteUbergraph_BP_NinjaSnow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NinjaSnow_C.__ExecuteUbergraph_BP_NinjaSnow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021CDC RID: 138460 RVA: 0x00953E56 File Offset: 0x00952056
		protected BP_NinjaSnow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040110D2 RID: 69842
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SandTrail/BP_NinjaSnow.BP_NinjaSnow_C";

		// Token: 0x040110D3 RID: 69843
		private static IntPtr _ClassPtr;

		// Token: 0x040110D4 RID: 69844
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040110D5 RID: 69845
		internal new static int __PropertyOffset_0;

		// Token: 0x040110D6 RID: 69846
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040110D7 RID: 69847
		internal new static int __PropertyOffset_1;

		// Token: 0x040110D8 RID: 69848
		internal new static int __PropertyOffset_2;

		// Token: 0x040110D9 RID: 69849
		internal new static int __PropertyOffset_3;

		// Token: 0x040110DA RID: 69850
		internal new static int __PropertyOffset_4;

		// Token: 0x040110DB RID: 69851
		internal new static int __PropertyOffset_5;

		// Token: 0x040110DC RID: 69852
		internal new static int __PropertyOffset_6;

		// Token: 0x040110DD RID: 69853
		internal new static int __PropertyOffset_7;

		// Token: 0x040110DE RID: 69854
		internal new static int __PropertyOffset_8;

		// Token: 0x040110DF RID: 69855
		internal new static int __PropertyOffset_9;

		// Token: 0x040110E0 RID: 69856
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<string> _physicMaterialSet;

		// Token: 0x040110E1 RID: 69857
		internal new static int __PropertyOffset_10;

		// Token: 0x040110E2 RID: 69858
		internal new static int __PropertyOffset_11;

		// Token: 0x040110E3 RID: 69859
		internal new static int __PropertyOffset_12;

		// Token: 0x040110E4 RID: 69860
		private static IntPtr __CheckQuality_NativeFunctionPtr;

		// Token: 0x040110E5 RID: 69861
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040110E6 RID: 69862
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040110E7 RID: 69863
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040110E8 RID: 69864
		private static IntPtr __ExecuteUbergraph_BP_NinjaSnow_NativeFunctionPtr;

		// Token: 0x02009B4B RID: 39755
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __CheckQuality_FunctionParams
		{
			// Token: 0x0403232A RID: 205610
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x02009B4C RID: 39756
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403232B RID: 205611
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B4D RID: 39757
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403232C RID: 205612
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009B4E RID: 39758
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1096)]
		protected ref struct __ExecuteUbergraph_BP_NinjaSnow_FunctionParams
		{
			// Token: 0x0403232D RID: 205613
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
