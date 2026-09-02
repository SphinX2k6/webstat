using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools.RippleSwim;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Water
{
	// Token: 0x02003CFD RID: 15613
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Water/BP_WaterRipple.BP_WaterRipple_C")]
	[UnrealStructLayout(1520, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1513)]
	public class BP_WaterRipple_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025988 RID: 153992 RVA: 0x009BE814 File Offset: 0x009BCA14
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterRipple_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Water/BP_WaterRipple.BP_WaterRipple_C");
			}
			return BP_WaterRipple_C._ClassPtr;
		}

		// Token: 0x06025989 RID: 153993 RVA: 0x009BE838 File Offset: 0x009BCA38
		public BP_WaterRipple_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterRipple_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602598A RID: 153994 RVA: 0x009BE860 File Offset: 0x009BCA60
		[NullableContext(1)]
		public BP_WaterRipple_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterRipple_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170052BE RID: 21182
		// (get) Token: 0x0602598B RID: 153995 RVA: 0x009BE894 File Offset: 0x009BCA94
		// (set) Token: 0x0602598C RID: 153996 RVA: 0x009BE8CD File Offset: 0x009BCACD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170052BF RID: 21183
		// (get) Token: 0x0602598D RID: 153997 RVA: 0x009BE8EE File Offset: 0x009BCAEE
		// (set) Token: 0x0602598E RID: 153998 RVA: 0x009BE902 File Offset: 0x009BCB02
		public unsafe UKuroCustomCaptureVolume KuroCustomCaptureVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCustomCaptureVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170052C0 RID: 21184
		// (get) Token: 0x0602598F RID: 153999 RVA: 0x009BE917 File Offset: 0x009BCB17
		// (set) Token: 0x06025990 RID: 154000 RVA: 0x009BE92B File Offset: 0x009BCB2B
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170052C1 RID: 21185
		// (get) Token: 0x06025991 RID: 154001 RVA: 0x009BE940 File Offset: 0x009BCB40
		// (set) Token: 0x06025992 RID: 154002 RVA: 0x009BE954 File Offset: 0x009BCB54
		public unsafe NinjaLive_C Ninja
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLive_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170052C2 RID: 21186
		// (get) Token: 0x06025993 RID: 154003 RVA: 0x009BE969 File Offset: 0x009BCB69
		// (set) Token: 0x06025994 RID: 154004 RVA: 0x009BE97D File Offset: 0x009BCB7D
		public unsafe ASceneCapture2D SceneCapture2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASceneCapture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170052C3 RID: 21187
		// (get) Token: 0x06025995 RID: 154005 RVA: 0x009BE992 File Offset: 0x009BCB92
		// (set) Token: 0x06025996 RID: 154006 RVA: 0x009BE9A2 File Offset: 0x009BCBA2
		public unsafe bool Trace
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052C4 RID: 21188
		// (get) Token: 0x06025997 RID: 154007 RVA: 0x009BE9B3 File Offset: 0x009BCBB3
		// (set) Token: 0x06025998 RID: 154008 RVA: 0x009BE9C3 File Offset: 0x009BCBC3
		public unsafe bool bCapture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052C5 RID: 21189
		// (get) Token: 0x06025999 RID: 154009 RVA: 0x009BE9D4 File Offset: 0x009BCBD4
		// (set) Token: 0x0602599A RID: 154010 RVA: 0x009BE9E8 File Offset: 0x009BCBE8
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170052C6 RID: 21190
		// (get) Token: 0x0602599B RID: 154011 RVA: 0x009BE9FD File Offset: 0x009BCBFD
		// (set) Token: 0x0602599C RID: 154012 RVA: 0x009BEA11 File Offset: 0x009BCC11
		[Nullable(0)]
		public unsafe TEnumAsByte<ECaptureMode> CaptureMode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_8);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170052C7 RID: 21191
		// (get) Token: 0x0602599D RID: 154013 RVA: 0x009BEA26 File Offset: 0x009BCC26
		// (set) Token: 0x0602599E RID: 154014 RVA: 0x009BEA3A File Offset: 0x009BCC3A
		public unsafe FVector CaptureVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170052C8 RID: 21192
		// (get) Token: 0x0602599F RID: 154015 RVA: 0x009BEA4F File Offset: 0x009BCC4F
		// (set) Token: 0x060259A0 RID: 154016 RVA: 0x009BEA5F File Offset: 0x009BCC5F
		public unsafe float Z
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170052C9 RID: 21193
		// (get) Token: 0x060259A1 RID: 154017 RVA: 0x009BEA70 File Offset: 0x009BCC70
		// (set) Token: 0x060259A2 RID: 154018 RVA: 0x009BEA80 File Offset: 0x009BCC80
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170052CA RID: 21194
		// (get) Token: 0x060259A3 RID: 154019 RVA: 0x009BEA91 File Offset: 0x009BCC91
		// (set) Token: 0x060259A4 RID: 154020 RVA: 0x009BEAA5 File Offset: 0x009BCCA5
		public unsafe UTextureRenderTarget2D RT_PressureBuffer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170052CB RID: 21195
		// (get) Token: 0x060259A5 RID: 154021 RVA: 0x009BEABA File Offset: 0x009BCCBA
		// (set) Token: 0x060259A6 RID: 154022 RVA: 0x009BEACE File Offset: 0x009BCCCE
		public unsafe UTextureRenderTarget2D RT_VelocityDensityBuffer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170052CC RID: 21196
		// (get) Token: 0x060259A7 RID: 154023 RVA: 0x009BEAE3 File Offset: 0x009BCCE3
		// (set) Token: 0x060259A8 RID: 154024 RVA: 0x009BEAF3 File Offset: 0x009BCCF3
		public unsafe int State
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170052CD RID: 21197
		// (get) Token: 0x060259A9 RID: 154025 RVA: 0x009BEB04 File Offset: 0x009BCD04
		// (set) Token: 0x060259AA RID: 154026 RVA: 0x009BEB18 File Offset: 0x009BCD18
		public unsafe FLinearColor HeiHaiAnRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170052CE RID: 21198
		// (get) Token: 0x060259AB RID: 154027 RVA: 0x009BEB2D File Offset: 0x009BCD2D
		// (set) Token: 0x060259AC RID: 154028 RVA: 0x009BEB3D File Offset: 0x009BCD3D
		public unsafe bool InsideHeiHaiAnRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052CF RID: 21199
		// (get) Token: 0x060259AD RID: 154029 RVA: 0x009BEB4E File Offset: 0x009BCD4E
		// (set) Token: 0x060259AE RID: 154030 RVA: 0x009BEB5E File Offset: 0x009BCD5E
		public unsafe int PreState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170052D0 RID: 21200
		// (get) Token: 0x060259AF RID: 154031 RVA: 0x009BEB6F File Offset: 0x009BCD6F
		// (set) Token: 0x060259B0 RID: 154032 RVA: 0x009BEB83 File Offset: 0x009BCD83
		public unsafe BP_RippleSwim_C OldRippleSwim
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RippleSwim_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170052D1 RID: 21201
		// (get) Token: 0x060259B1 RID: 154033 RVA: 0x009BEB98 File Offset: 0x009BCD98
		// (set) Token: 0x060259B2 RID: 154034 RVA: 0x009BEBAC File Offset: 0x009BCDAC
		public unsafe FVectorDouble StartOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170052D2 RID: 21202
		// (get) Token: 0x060259B3 RID: 154035 RVA: 0x009BEBC1 File Offset: 0x009BCDC1
		// (set) Token: 0x060259B4 RID: 154036 RVA: 0x009BEBD5 File Offset: 0x009BCDD5
		public unsafe FVectorDouble EndOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170052D3 RID: 21203
		// (get) Token: 0x060259B5 RID: 154037 RVA: 0x009BEBEA File Offset: 0x009BCDEA
		// (set) Token: 0x060259B6 RID: 154038 RVA: 0x009BEBFE File Offset: 0x009BCDFE
		public unsafe UTextureRenderTarget2D RT_InputVelocityDensityBuffer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170052D4 RID: 21204
		// (get) Token: 0x060259B7 RID: 154039 RVA: 0x009BEC13 File Offset: 0x009BCE13
		// (set) Token: 0x060259B8 RID: 154040 RVA: 0x009BEC27 File Offset: 0x009BCE27
		public unsafe UTextureRenderTarget2D RT_CaptureVelocityDensityBuffer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170052D5 RID: 21205
		// (get) Token: 0x060259B9 RID: 154041 RVA: 0x009BEC3C File Offset: 0x009BCE3C
		// (set) Token: 0x060259BA RID: 154042 RVA: 0x009BEC50 File Offset: 0x009BCE50
		public unsafe UMaterialInterface CombinMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterRipple_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x170052D6 RID: 21206
		// (get) Token: 0x060259BB RID: 154043 RVA: 0x009BEC65 File Offset: 0x009BCE65
		// (set) Token: 0x060259BC RID: 154044 RVA: 0x009BEC75 File Offset: 0x009BCE75
		public unsafe bool UseNewFluidRipple
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterRipple_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x060259BD RID: 154045 RVA: 0x009BEC88 File Offset: 0x009BCE88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetNewWaterRippleEnable(bool Condition)
		{
			BP_WaterRipple_C.__SetNewWaterRippleEnable_FunctionParams* ptr = stackalloc BP_WaterRipple_C.__SetNewWaterRippleEnable_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WaterRipple_C.__SetNewWaterRippleEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRipple_C.__SetNewWaterRippleEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Condition = Condition;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRipple_C.__SetNewWaterRippleEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060259BE RID: 154046 RVA: 0x009BECCE File Offset: 0x009BCECE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRipple_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060259BF RID: 154047 RVA: 0x009BECE2 File Offset: 0x009BCEE2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRipple_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060259C0 RID: 154048 RVA: 0x009BECF8 File Offset: 0x009BCEF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterRipple_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterRipple_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterRipple_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060259C1 RID: 154049 RVA: 0x009BED40 File Offset: 0x009BCF40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterRipple_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterRipple_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterRipple_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRipple_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060259C2 RID: 154050 RVA: 0x009BED88 File Offset: 0x009BCF88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterRipple(int EntryPoint)
		{
			BP_WaterRipple_C.__ExecuteUbergraph_BP_WaterRipple_FunctionParams* ptr = stackalloc BP_WaterRipple_C.__ExecuteUbergraph_BP_WaterRipple_FunctionParams[(UIntPtr)591] + 15L / (long)sizeof(BP_WaterRipple_C.__ExecuteUbergraph_BP_WaterRipple_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterRipple_C.__ExecuteUbergraph_BP_WaterRipple_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterRipple_C.__ExecuteUbergraph_BP_WaterRipple_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060259C3 RID: 154051 RVA: 0x009BEDD2 File Offset: 0x009BCFD2
		protected BP_WaterRipple_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013653 RID: 79443
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Water/BP_WaterRipple.BP_WaterRipple_C";

		// Token: 0x04013654 RID: 79444
		private static IntPtr _ClassPtr;

		// Token: 0x04013655 RID: 79445
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013656 RID: 79446
		internal static int __PropertyOffset_0;

		// Token: 0x04013657 RID: 79447
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013658 RID: 79448
		internal static int __PropertyOffset_1;

		// Token: 0x04013659 RID: 79449
		internal static int __PropertyOffset_2;

		// Token: 0x0401365A RID: 79450
		internal static int __PropertyOffset_3;

		// Token: 0x0401365B RID: 79451
		internal static int __PropertyOffset_4;

		// Token: 0x0401365C RID: 79452
		internal static int __PropertyOffset_5;

		// Token: 0x0401365D RID: 79453
		internal static int __PropertyOffset_6;

		// Token: 0x0401365E RID: 79454
		internal static int __PropertyOffset_7;

		// Token: 0x0401365F RID: 79455
		internal static int __PropertyOffset_8;

		// Token: 0x04013660 RID: 79456
		internal static int __PropertyOffset_9;

		// Token: 0x04013661 RID: 79457
		internal static int __PropertyOffset_10;

		// Token: 0x04013662 RID: 79458
		internal static int __PropertyOffset_11;

		// Token: 0x04013663 RID: 79459
		internal static int __PropertyOffset_12;

		// Token: 0x04013664 RID: 79460
		internal static int __PropertyOffset_13;

		// Token: 0x04013665 RID: 79461
		internal static int __PropertyOffset_14;

		// Token: 0x04013666 RID: 79462
		internal static int __PropertyOffset_15;

		// Token: 0x04013667 RID: 79463
		internal static int __PropertyOffset_16;

		// Token: 0x04013668 RID: 79464
		internal static int __PropertyOffset_17;

		// Token: 0x04013669 RID: 79465
		internal static int __PropertyOffset_18;

		// Token: 0x0401366A RID: 79466
		internal static int __PropertyOffset_19;

		// Token: 0x0401366B RID: 79467
		internal static int __PropertyOffset_20;

		// Token: 0x0401366C RID: 79468
		internal static int __PropertyOffset_21;

		// Token: 0x0401366D RID: 79469
		internal static int __PropertyOffset_22;

		// Token: 0x0401366E RID: 79470
		internal static int __PropertyOffset_23;

		// Token: 0x0401366F RID: 79471
		internal static int __PropertyOffset_24;

		// Token: 0x04013670 RID: 79472
		private static IntPtr __SetNewWaterRippleEnable_NativeFunctionPtr;

		// Token: 0x04013671 RID: 79473
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013672 RID: 79474
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013673 RID: 79475
		private static IntPtr __ExecuteUbergraph_BP_WaterRipple_NativeFunctionPtr;

		// Token: 0x02009F37 RID: 40759
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetNewWaterRippleEnable_FunctionParams
		{
			// Token: 0x04032A68 RID: 207464
			[FieldOffset(0)]
			public bool Condition;
		}

		// Token: 0x02009F38 RID: 40760
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A69 RID: 207465
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F39 RID: 40761
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 576)]
		protected ref struct __ExecuteUbergraph_BP_WaterRipple_FunctionParams
		{
			// Token: 0x04032A6A RID: 207466
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
