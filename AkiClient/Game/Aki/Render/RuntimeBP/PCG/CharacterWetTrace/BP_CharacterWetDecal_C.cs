using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.CharacterWetTrace
{
	// Token: 0x02003C36 RID: 15414
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/CharacterWetTrace/BP_CharacterWetDecal.BP_CharacterWetDecal_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1502)]
	public class BP_CharacterWetDecal_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023594 RID: 144788 RVA: 0x0097F8FF File Offset: 0x0097DAFF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterWetDecal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/CharacterWetTrace/BP_CharacterWetDecal.BP_CharacterWetDecal_C");
			}
			return BP_CharacterWetDecal_C._ClassPtr;
		}

		// Token: 0x06023595 RID: 144789 RVA: 0x0097F924 File Offset: 0x0097DB24
		public BP_CharacterWetDecal_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterWetDecal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023596 RID: 144790 RVA: 0x0097F94C File Offset: 0x0097DB4C
		[NullableContext(1)]
		public BP_CharacterWetDecal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterWetDecal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045E8 RID: 17896
		// (get) Token: 0x06023597 RID: 144791 RVA: 0x0097F980 File Offset: 0x0097DB80
		// (set) Token: 0x06023598 RID: 144792 RVA: 0x0097F9B9 File Offset: 0x0097DBB9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170045E9 RID: 17897
		// (get) Token: 0x06023599 RID: 144793 RVA: 0x0097F9DA File Offset: 0x0097DBDA
		// (set) Token: 0x0602359A RID: 144794 RVA: 0x0097F9EE File Offset: 0x0097DBEE
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045EA RID: 17898
		// (get) Token: 0x0602359B RID: 144795 RVA: 0x0097FA03 File Offset: 0x0097DC03
		// (set) Token: 0x0602359C RID: 144796 RVA: 0x0097FA17 File Offset: 0x0097DC17
		public unsafe UMaterialInstance WetButtDecalMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045EB RID: 17899
		// (get) Token: 0x0602359D RID: 144797 RVA: 0x0097FA2C File Offset: 0x0097DC2C
		// (set) Token: 0x0602359E RID: 144798 RVA: 0x0097FA40 File Offset: 0x0097DC40
		public unsafe UDecalComponent WetButtDecal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDecalComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170045EC RID: 17900
		// (get) Token: 0x0602359F RID: 144799 RVA: 0x0097FA55 File Offset: 0x0097DC55
		// (set) Token: 0x060235A0 RID: 144800 RVA: 0x0097FA65 File Offset: 0x0097DC65
		public unsafe bool HasDecal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170045ED RID: 17901
		// (get) Token: 0x060235A1 RID: 144801 RVA: 0x0097FA76 File Offset: 0x0097DC76
		// (set) Token: 0x060235A2 RID: 144802 RVA: 0x0097FA86 File Offset: 0x0097DC86
		public unsafe bool Test湿身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170045EE RID: 17902
		// (get) Token: 0x060235A3 RID: 144803 RVA: 0x0097FA97 File Offset: 0x0097DC97
		// (set) Token: 0x060235A4 RID: 144804 RVA: 0x0097FAAB File Offset: 0x0097DCAB
		public unsafe FVector DecalPositionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170045EF RID: 17903
		// (get) Token: 0x060235A5 RID: 144805 RVA: 0x0097FAC0 File Offset: 0x0097DCC0
		// (set) Token: 0x060235A6 RID: 144806 RVA: 0x0097FAD0 File Offset: 0x0097DCD0
		public unsafe float DecalRotationOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170045F0 RID: 17904
		// (get) Token: 0x060235A7 RID: 144807 RVA: 0x0097FAE1 File Offset: 0x0097DCE1
		// (set) Token: 0x060235A8 RID: 144808 RVA: 0x0097FAF5 File Offset: 0x0097DCF5
		public unsafe FVector Decal_Size_Default
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170045F1 RID: 17905
		// (get) Token: 0x060235A9 RID: 144809 RVA: 0x0097FB0A File Offset: 0x0097DD0A
		// (set) Token: 0x060235AA RID: 144810 RVA: 0x0097FB1A File Offset: 0x0097DD1A
		public unsafe float DecalDisapearTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170045F2 RID: 17906
		// (get) Token: 0x060235AB RID: 144811 RVA: 0x0097FB2C File Offset: 0x0097DD2C
		// (set) Token: 0x060235AC RID: 144812 RVA: 0x0097FB65 File Offset: 0x0097DD65
		[Nullable(1)]
		public TMap<string, FVector> BodyType
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<string, FVector> result;
				if ((result = this._BodyType) == null)
				{
					result = (this._BodyType = new TMap<string, FVector>(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BodyType.CopyAssign(value);
			}
		}

		// Token: 0x170045F3 RID: 17907
		// (get) Token: 0x060235AD RID: 144813 RVA: 0x0097FB73 File Offset: 0x0097DD73
		// (set) Token: 0x060235AE RID: 144814 RVA: 0x0097FB83 File Offset: 0x0097DD83
		public unsafe float CharWetProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170045F4 RID: 17908
		// (get) Token: 0x060235AF RID: 144815 RVA: 0x0097FB94 File Offset: 0x0097DD94
		// (set) Token: 0x060235B0 RID: 144816 RVA: 0x0097FBA8 File Offset: 0x0097DDA8
		public unsafe UMaterialInstanceDynamic ButtDecalDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterWetDecal_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170045F5 RID: 17909
		// (get) Token: 0x060235B1 RID: 144817 RVA: 0x0097FBBD File Offset: 0x0097DDBD
		// (set) Token: 0x060235B2 RID: 144818 RVA: 0x0097FBCD File Offset: 0x0097DDCD
		public unsafe float DisappearDecalLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170045F6 RID: 17910
		// (get) Token: 0x060235B3 RID: 144819 RVA: 0x0097FBDE File Offset: 0x0097DDDE
		// (set) Token: 0x060235B4 RID: 144820 RVA: 0x0097FBF2 File Offset: 0x0097DDF2
		public unsafe FVector Decal_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170045F7 RID: 17911
		// (get) Token: 0x060235B5 RID: 144821 RVA: 0x0097FC07 File Offset: 0x0097DE07
		// (set) Token: 0x060235B6 RID: 144822 RVA: 0x0097FC1B File Offset: 0x0097DE1B
		public unsafe FVector DecalScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170045F8 RID: 17912
		// (get) Token: 0x060235B7 RID: 144823 RVA: 0x0097FC30 File Offset: 0x0097DE30
		// (set) Token: 0x060235B8 RID: 144824 RVA: 0x0097FC40 File Offset: 0x0097DE40
		public unsafe bool DecalLocationDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170045F9 RID: 17913
		// (get) Token: 0x060235B9 RID: 144825 RVA: 0x0097FC51 File Offset: 0x0097DE51
		// (set) Token: 0x060235BA RID: 144826 RVA: 0x0097FC61 File Offset: 0x0097DE61
		public unsafe bool DebugWetStat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterWetDecal_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x060235BB RID: 144827 RVA: 0x0097FC72 File Offset: 0x0097DE72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetDecalScale()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterWetDecal_C.__SetDecalScale_NativeFunctionPtr, null);
		}

		// Token: 0x060235BC RID: 144828 RVA: 0x0097FC86 File Offset: 0x0097DE86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterWetDecal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060235BD RID: 144829 RVA: 0x0097FC9A File Offset: 0x0097DE9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterWetDecal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060235BE RID: 144830 RVA: 0x0097FCAF File Offset: 0x0097DEAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterWetDecal_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060235BF RID: 144831 RVA: 0x0097FCC3 File Offset: 0x0097DEC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterWetDecal_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060235C0 RID: 144832 RVA: 0x0097FCD8 File Offset: 0x0097DED8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CharacterWetDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterWetDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterWetDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterWetDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterWetDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060235C1 RID: 144833 RVA: 0x0097FD20 File Offset: 0x0097DF20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CharacterWetDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterWetDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterWetDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterWetDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterWetDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060235C2 RID: 144834 RVA: 0x0097FD68 File Offset: 0x0097DF68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CharacterWetDecal(int EntryPoint)
		{
			BP_CharacterWetDecal_C.__ExecuteUbergraph_BP_CharacterWetDecal_FunctionParams* ptr = stackalloc BP_CharacterWetDecal_C.__ExecuteUbergraph_BP_CharacterWetDecal_FunctionParams[(UIntPtr)671] + 15L / (long)sizeof(BP_CharacterWetDecal_C.__ExecuteUbergraph_BP_CharacterWetDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterWetDecal_C.__ExecuteUbergraph_BP_CharacterWetDecal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterWetDecal_C.__ExecuteUbergraph_BP_CharacterWetDecal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060235C3 RID: 144835 RVA: 0x0097FDB2 File Offset: 0x0097DFB2
		protected BP_CharacterWetDecal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011FC6 RID: 73670
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/CharacterWetTrace/BP_CharacterWetDecal.BP_CharacterWetDecal_C";

		// Token: 0x04011FC7 RID: 73671
		private static IntPtr _ClassPtr;

		// Token: 0x04011FC8 RID: 73672
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011FC9 RID: 73673
		internal static int __PropertyOffset_0;

		// Token: 0x04011FCA RID: 73674
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011FCB RID: 73675
		internal static int __PropertyOffset_1;

		// Token: 0x04011FCC RID: 73676
		internal static int __PropertyOffset_2;

		// Token: 0x04011FCD RID: 73677
		internal static int __PropertyOffset_3;

		// Token: 0x04011FCE RID: 73678
		internal static int __PropertyOffset_4;

		// Token: 0x04011FCF RID: 73679
		internal static int __PropertyOffset_5;

		// Token: 0x04011FD0 RID: 73680
		internal static int __PropertyOffset_6;

		// Token: 0x04011FD1 RID: 73681
		internal static int __PropertyOffset_7;

		// Token: 0x04011FD2 RID: 73682
		internal static int __PropertyOffset_8;

		// Token: 0x04011FD3 RID: 73683
		internal static int __PropertyOffset_9;

		// Token: 0x04011FD4 RID: 73684
		internal static int __PropertyOffset_10;

		// Token: 0x04011FD5 RID: 73685
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FVector> _BodyType;

		// Token: 0x04011FD6 RID: 73686
		internal static int __PropertyOffset_11;

		// Token: 0x04011FD7 RID: 73687
		internal static int __PropertyOffset_12;

		// Token: 0x04011FD8 RID: 73688
		internal static int __PropertyOffset_13;

		// Token: 0x04011FD9 RID: 73689
		internal static int __PropertyOffset_14;

		// Token: 0x04011FDA RID: 73690
		internal static int __PropertyOffset_15;

		// Token: 0x04011FDB RID: 73691
		internal static int __PropertyOffset_16;

		// Token: 0x04011FDC RID: 73692
		internal static int __PropertyOffset_17;

		// Token: 0x04011FDD RID: 73693
		private static IntPtr __SetDecalScale_NativeFunctionPtr;

		// Token: 0x04011FDE RID: 73694
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011FDF RID: 73695
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011FE0 RID: 73696
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011FE1 RID: 73697
		private static IntPtr __ExecuteUbergraph_BP_CharacterWetDecal_NativeFunctionPtr;

		// Token: 0x02009CC7 RID: 40135
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032632 RID: 206386
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CC8 RID: 40136
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 656)]
		protected ref struct __ExecuteUbergraph_BP_CharacterWetDecal_FunctionParams
		{
			// Token: 0x04032633 RID: 206387
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
