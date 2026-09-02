using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.MagneticStorm.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.MagneticStorm
{
	// Token: 0x02003C57 RID: 15447
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm_3_0.BP_MagneticStorm_3_0_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1416)]
	public class BP_MagneticStorm_3_0_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023AB2 RID: 146098 RVA: 0x00988C6C File Offset: 0x00986E6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MagneticStorm_3_0_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm_3_0.BP_MagneticStorm_3_0_C");
			}
			return BP_MagneticStorm_3_0_C._ClassPtr;
		}

		// Token: 0x06023AB3 RID: 146099 RVA: 0x00988C90 File Offset: 0x00986E90
		public BP_MagneticStorm_3_0_C() : this(BuiltinUtils.AllocNativeUObject(BP_MagneticStorm_3_0_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023AB4 RID: 146100 RVA: 0x00988CB8 File Offset: 0x00986EB8
		[NullableContext(1)]
		public BP_MagneticStorm_3_0_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MagneticStorm_3_0_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170047B9 RID: 18361
		// (get) Token: 0x06023AB5 RID: 146101 RVA: 0x00988CEC File Offset: 0x00986EEC
		// (set) Token: 0x06023AB6 RID: 146102 RVA: 0x00988D25 File Offset: 0x00986F25
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170047BA RID: 18362
		// (get) Token: 0x06023AB7 RID: 146103 RVA: 0x00988D46 File Offset: 0x00986F46
		// (set) Token: 0x06023AB8 RID: 146104 RVA: 0x00988D5A File Offset: 0x00986F5A
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170047BB RID: 18363
		// (get) Token: 0x06023AB9 RID: 146105 RVA: 0x00988D6F File Offset: 0x00986F6F
		// (set) Token: 0x06023ABA RID: 146106 RVA: 0x00988D83 File Offset: 0x00986F83
		public unsafe UNiagaraComponent NS_Fx_SC3_MagneticStorm_Mobile_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170047BC RID: 18364
		// (get) Token: 0x06023ABB RID: 146107 RVA: 0x00988D98 File Offset: 0x00986F98
		// (set) Token: 0x06023ABC RID: 146108 RVA: 0x00988DAC File Offset: 0x00986FAC
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170047BD RID: 18365
		// (get) Token: 0x06023ABD RID: 146109 RVA: 0x00988DC1 File Offset: 0x00986FC1
		// (set) Token: 0x06023ABE RID: 146110 RVA: 0x00988DD5 File Offset: 0x00986FD5
		public unsafe UNiagaraComponent NS_Fx_MagneticStorm
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170047BE RID: 18366
		// (get) Token: 0x06023ABF RID: 146111 RVA: 0x00988DEA File Offset: 0x00986FEA
		// (set) Token: 0x06023AC0 RID: 146112 RVA: 0x00988DFE File Offset: 0x00986FFE
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_3_0_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170047BF RID: 18367
		// (get) Token: 0x06023AC1 RID: 146113 RVA: 0x00988E13 File Offset: 0x00987013
		// (set) Token: 0x06023AC2 RID: 146114 RVA: 0x00988E27 File Offset: 0x00987027
		public unsafe FVector WroldOriginLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170047C0 RID: 18368
		// (get) Token: 0x06023AC3 RID: 146115 RVA: 0x00988E3C File Offset: 0x0098703C
		// (set) Token: 0x06023AC4 RID: 146116 RVA: 0x00988E4C File Offset: 0x0098704C
		public unsafe bool DisplayShockwave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047C1 RID: 18369
		// (get) Token: 0x06023AC5 RID: 146117 RVA: 0x00988E5D File Offset: 0x0098705D
		// (set) Token: 0x06023AC6 RID: 146118 RVA: 0x00988E6D File Offset: 0x0098706D
		public unsafe bool DisplayParticle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047C2 RID: 18370
		// (get) Token: 0x06023AC7 RID: 146119 RVA: 0x00988E7E File Offset: 0x0098707E
		// (set) Token: 0x06023AC8 RID: 146120 RVA: 0x00988E8E File Offset: 0x0098708E
		public unsafe bool DisplayPointLattice
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047C3 RID: 18371
		// (get) Token: 0x06023AC9 RID: 146121 RVA: 0x00988E9F File Offset: 0x0098709F
		// (set) Token: 0x06023ACA RID: 146122 RVA: 0x00988EAF File Offset: 0x009870AF
		public unsafe bool bInTheArea
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047C4 RID: 18372
		// (get) Token: 0x06023ACB RID: 146123 RVA: 0x00988EC0 File Offset: 0x009870C0
		// (set) Token: 0x06023ACC RID: 146124 RVA: 0x00988ED4 File Offset: 0x009870D4
		[Nullable(0)]
		public unsafe TEnumAsByte<E_MagneticStorm_RegionType> RegionType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170047C5 RID: 18373
		// (get) Token: 0x06023ACD RID: 146125 RVA: 0x00988EE9 File Offset: 0x009870E9
		// (set) Token: 0x06023ACE RID: 146126 RVA: 0x00988EF9 File Offset: 0x009870F9
		public unsafe bool DisplaySphereMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047C6 RID: 18374
		// (get) Token: 0x06023ACF RID: 146127 RVA: 0x00988F0A File Offset: 0x0098710A
		// (set) Token: 0x06023AD0 RID: 146128 RVA: 0x00988F1A File Offset: 0x0098711A
		public unsafe float AttenuationDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170047C7 RID: 18375
		// (get) Token: 0x06023AD1 RID: 146129 RVA: 0x00988F2B File Offset: 0x0098712B
		// (set) Token: 0x06023AD2 RID: 146130 RVA: 0x00988F3B File Offset: 0x0098713B
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170047C8 RID: 18376
		// (get) Token: 0x06023AD3 RID: 146131 RVA: 0x00988F4C File Offset: 0x0098714C
		// (set) Token: 0x06023AD4 RID: 146132 RVA: 0x00988F5C File Offset: 0x0098715C
		public unsafe bool DisplayPrint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047C9 RID: 18377
		// (get) Token: 0x06023AD5 RID: 146133 RVA: 0x00988F6D File Offset: 0x0098716D
		// (set) Token: 0x06023AD6 RID: 146134 RVA: 0x00988F7D File Offset: 0x0098717D
		public unsafe float PointLatticeOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170047CA RID: 18378
		// (get) Token: 0x06023AD7 RID: 146135 RVA: 0x00988F8E File Offset: 0x0098718E
		// (set) Token: 0x06023AD8 RID: 146136 RVA: 0x00988F9E File Offset: 0x0098719E
		public unsafe float ShockwaveIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170047CB RID: 18379
		// (get) Token: 0x06023AD9 RID: 146137 RVA: 0x00988FAF File Offset: 0x009871AF
		// (set) Token: 0x06023ADA RID: 146138 RVA: 0x00988FBF File Offset: 0x009871BF
		public unsafe float ParticleOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170047CC RID: 18380
		// (get) Token: 0x06023ADB RID: 146139 RVA: 0x00988FD0 File Offset: 0x009871D0
		// (set) Token: 0x06023ADC RID: 146140 RVA: 0x00988FE0 File Offset: 0x009871E0
		public unsafe float InTheAreaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170047CD RID: 18381
		// (get) Token: 0x06023ADD RID: 146141 RVA: 0x00988FF1 File Offset: 0x009871F1
		// (set) Token: 0x06023ADE RID: 146142 RVA: 0x00989001 File Offset: 0x00987201
		public unsafe bool bSetParamFromSeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047CE RID: 18382
		// (get) Token: 0x06023ADF RID: 146143 RVA: 0x00989012 File Offset: 0x00987212
		// (set) Token: 0x06023AE0 RID: 146144 RVA: 0x00989026 File Offset: 0x00987226
		public unsafe FVector OriginLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_3_0_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x06023AE1 RID: 146145 RVA: 0x0098903B File Offset: 0x0098723B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FadeIn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__FadeIn_NativeFunctionPtr, null);
		}

		// Token: 0x06023AE2 RID: 146146 RVA: 0x0098904F File Offset: 0x0098724F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023AE3 RID: 146147 RVA: 0x00989063 File Offset: 0x00987263
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateNS()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__UpdateNS_NativeFunctionPtr, null);
		}

		// Token: 0x06023AE4 RID: 146148 RVA: 0x00989077 File Offset: 0x00987277
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__RemoveParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023AE5 RID: 146149 RVA: 0x0098908B File Offset: 0x0098728B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseAllMagneticStorm()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__CloseAllMagneticStorm_NativeFunctionPtr, null);
		}

		// Token: 0x06023AE6 RID: 146150 RVA: 0x009890A0 File Offset: 0x009872A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InTheBox(FVector pos, ref bool IntheBox)
		{
			BP_MagneticStorm_3_0_C.__InTheBox_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_0_C.__InTheBox_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_MagneticStorm_3_0_C.__InTheBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_0_C.__InTheBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->pos = pos;
			ptr->IntheBox = IntheBox;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__InTheBox_NativeFunctionPtr, (void*)ptr);
			IntheBox = ptr->IntheBox;
		}

		// Token: 0x06023AE7 RID: 146151 RVA: 0x009890F6 File Offset: 0x009872F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenMagneticStorm()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__OpenMagneticStorm_NativeFunctionPtr, null);
		}

		// Token: 0x06023AE8 RID: 146152 RVA: 0x0098910A File Offset: 0x0098730A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__UpdateParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023AE9 RID: 146153 RVA: 0x0098911E File Offset: 0x0098731E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__InitParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023AEA RID: 146154 RVA: 0x00989132 File Offset: 0x00987332
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023AEB RID: 146155 RVA: 0x00989146 File Offset: 0x00987346
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023AEC RID: 146156 RVA: 0x0098915B File Offset: 0x0098735B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023AED RID: 146157 RVA: 0x0098916F File Offset: 0x0098736F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023AEE RID: 146158 RVA: 0x00989184 File Offset: 0x00987384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MagneticStorm_3_0_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_0_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MagneticStorm_3_0_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_0_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023AEF RID: 146159 RVA: 0x009891CC File Offset: 0x009873CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MagneticStorm_3_0_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_0_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MagneticStorm_3_0_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_0_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023AF0 RID: 146160 RVA: 0x00989213 File Offset: 0x00987413
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__CustomTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023AF1 RID: 146161 RVA: 0x00989227 File Offset: 0x00987427
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06023AF2 RID: 146162 RVA: 0x0098923B File Offset: 0x0098743B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023AF3 RID: 146163 RVA: 0x00989250 File Offset: 0x00987450
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_MagneticStorm_3_0_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_0_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MagneticStorm_3_0_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_0_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023AF4 RID: 146164 RVA: 0x0098929C File Offset: 0x0098749C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_MagneticStorm_3_0_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_0_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MagneticStorm_3_0_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_0_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023AF5 RID: 146165 RVA: 0x009892E8 File Offset: 0x009874E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParamFromSeq()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__SetParamFromSeq_NativeFunctionPtr, null);
		}

		// Token: 0x06023AF6 RID: 146166 RVA: 0x009892FC File Offset: 0x009874FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MagneticStorm_3_0(int EntryPoint)
		{
			BP_MagneticStorm_3_0_C.__ExecuteUbergraph_BP_MagneticStorm_3_0_FunctionParams* ptr = stackalloc BP_MagneticStorm_3_0_C.__ExecuteUbergraph_BP_MagneticStorm_3_0_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_MagneticStorm_3_0_C.__ExecuteUbergraph_BP_MagneticStorm_3_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_3_0_C.__ExecuteUbergraph_BP_MagneticStorm_3_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_3_0_C.__ExecuteUbergraph_BP_MagneticStorm_3_0_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023AF7 RID: 146167 RVA: 0x00989343 File Offset: 0x00987543
		protected BP_MagneticStorm_3_0_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040122F7 RID: 74487
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm_3_0.BP_MagneticStorm_3_0_C";

		// Token: 0x040122F8 RID: 74488
		private static IntPtr _ClassPtr;

		// Token: 0x040122F9 RID: 74489
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040122FA RID: 74490
		internal static int __PropertyOffset_0;

		// Token: 0x040122FB RID: 74491
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040122FC RID: 74492
		internal static int __PropertyOffset_1;

		// Token: 0x040122FD RID: 74493
		internal static int __PropertyOffset_2;

		// Token: 0x040122FE RID: 74494
		internal static int __PropertyOffset_3;

		// Token: 0x040122FF RID: 74495
		internal static int __PropertyOffset_4;

		// Token: 0x04012300 RID: 74496
		internal static int __PropertyOffset_5;

		// Token: 0x04012301 RID: 74497
		internal static int __PropertyOffset_6;

		// Token: 0x04012302 RID: 74498
		internal static int __PropertyOffset_7;

		// Token: 0x04012303 RID: 74499
		internal static int __PropertyOffset_8;

		// Token: 0x04012304 RID: 74500
		internal static int __PropertyOffset_9;

		// Token: 0x04012305 RID: 74501
		internal static int __PropertyOffset_10;

		// Token: 0x04012306 RID: 74502
		internal static int __PropertyOffset_11;

		// Token: 0x04012307 RID: 74503
		internal static int __PropertyOffset_12;

		// Token: 0x04012308 RID: 74504
		internal static int __PropertyOffset_13;

		// Token: 0x04012309 RID: 74505
		internal static int __PropertyOffset_14;

		// Token: 0x0401230A RID: 74506
		internal static int __PropertyOffset_15;

		// Token: 0x0401230B RID: 74507
		internal static int __PropertyOffset_16;

		// Token: 0x0401230C RID: 74508
		internal static int __PropertyOffset_17;

		// Token: 0x0401230D RID: 74509
		internal static int __PropertyOffset_18;

		// Token: 0x0401230E RID: 74510
		internal static int __PropertyOffset_19;

		// Token: 0x0401230F RID: 74511
		internal static int __PropertyOffset_20;

		// Token: 0x04012310 RID: 74512
		internal static int __PropertyOffset_21;

		// Token: 0x04012311 RID: 74513
		private static IntPtr __FadeIn_NativeFunctionPtr;

		// Token: 0x04012312 RID: 74514
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x04012313 RID: 74515
		private static IntPtr __UpdateNS_NativeFunctionPtr;

		// Token: 0x04012314 RID: 74516
		private static IntPtr __RemoveParam_NativeFunctionPtr;

		// Token: 0x04012315 RID: 74517
		private static IntPtr __CloseAllMagneticStorm_NativeFunctionPtr;

		// Token: 0x04012316 RID: 74518
		private static IntPtr __InTheBox_NativeFunctionPtr;

		// Token: 0x04012317 RID: 74519
		private static IntPtr __OpenMagneticStorm_NativeFunctionPtr;

		// Token: 0x04012318 RID: 74520
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x04012319 RID: 74521
		private static IntPtr __InitParam_NativeFunctionPtr;

		// Token: 0x0401231A RID: 74522
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401231B RID: 74523
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401231C RID: 74524
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401231D RID: 74525
		private static IntPtr __CustomTick_NativeFunctionPtr;

		// Token: 0x0401231E RID: 74526
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0401231F RID: 74527
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04012320 RID: 74528
		private static IntPtr __SetParamFromSeq_NativeFunctionPtr;

		// Token: 0x04012321 RID: 74529
		private static IntPtr __ExecuteUbergraph_BP_MagneticStorm_3_0_NativeFunctionPtr;

		// Token: 0x02009D19 RID: 40217
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __InTheBox_FunctionParams
		{
			// Token: 0x040326D3 RID: 206547
			[FieldOffset(0)]
			public FVector pos;

			// Token: 0x040326D4 RID: 206548
			[FieldOffset(12)]
			public bool IntheBox;
		}

		// Token: 0x02009D1A RID: 40218
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326D5 RID: 206549
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D1B RID: 40219
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040326D6 RID: 206550
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D1C RID: 40220
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_MagneticStorm_3_0_FunctionParams
		{
			// Token: 0x040326D7 RID: 206551
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
