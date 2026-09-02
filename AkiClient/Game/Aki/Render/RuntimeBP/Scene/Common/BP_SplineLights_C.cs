using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003AE0 RID: 15072
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_SplineLights.BP_SplineLights_C")]
	[UnrealStructLayout(1888, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1884)]
	public class BP_SplineLights_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06020474 RID: 132212 RVA: 0x009277EB File Offset: 0x009259EB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplineLights_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_SplineLights.BP_SplineLights_C");
			}
			return BP_SplineLights_C._ClassPtr;
		}

		// Token: 0x06020475 RID: 132213 RVA: 0x0092780F File Offset: 0x00925A0F
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_SplineLights_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x06020476 RID: 132214 RVA: 0x00927818 File Offset: 0x00925A18
		public BP_SplineLights_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplineLights_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020477 RID: 132215 RVA: 0x00927840 File Offset: 0x00925A40
		public BP_SplineLights_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplineLights_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170034C2 RID: 13506
		// (get) Token: 0x06020478 RID: 132216 RVA: 0x00927874 File Offset: 0x00925A74
		// (set) Token: 0x06020479 RID: 132217 RVA: 0x009278AD File Offset: 0x00925AAD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034C3 RID: 13507
		// (get) Token: 0x0602047A RID: 132218 RVA: 0x009278CE File Offset: 0x00925ACE
		// (set) Token: 0x0602047B RID: 132219 RVA: 0x009278E2 File Offset: 0x00925AE2
		[Nullable(2)]
		public unsafe USplineComponent Spline
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineLights_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineLights_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170034C4 RID: 13508
		// (get) Token: 0x0602047C RID: 132220 RVA: 0x009278F7 File Offset: 0x00925AF7
		// (set) Token: 0x0602047D RID: 132221 RVA: 0x0092790B File Offset: 0x00925B0B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineLights_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineLights_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170034C5 RID: 13509
		// (get) Token: 0x0602047E RID: 132222 RVA: 0x00927920 File Offset: 0x00925B20
		// (set) Token: 0x0602047F RID: 132223 RVA: 0x00927930 File Offset: 0x00925B30
		public unsafe float Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170034C6 RID: 13510
		// (get) Token: 0x06020480 RID: 132224 RVA: 0x00927941 File Offset: 0x00925B41
		// (set) Token: 0x06020481 RID: 132225 RVA: 0x00927955 File Offset: 0x00925B55
		public unsafe FLinearColor LightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170034C7 RID: 13511
		// (get) Token: 0x06020482 RID: 132226 RVA: 0x0092796A File Offset: 0x00925B6A
		// (set) Token: 0x06020483 RID: 132227 RVA: 0x0092797A File Offset: 0x00925B7A
		public unsafe float LightFalloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170034C8 RID: 13512
		// (get) Token: 0x06020484 RID: 132228 RVA: 0x0092798B File Offset: 0x00925B8B
		// (set) Token: 0x06020485 RID: 132229 RVA: 0x0092799B File Offset: 0x00925B9B
		public unsafe float 高光度范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170034C9 RID: 13513
		// (get) Token: 0x06020486 RID: 132230 RVA: 0x009279AC File Offset: 0x00925BAC
		// (set) Token: 0x06020487 RID: 132231 RVA: 0x009279BC File Offset: 0x00925BBC
		public unsafe float 源半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170034CA RID: 13514
		// (get) Token: 0x06020488 RID: 132232 RVA: 0x009279CD File Offset: 0x00925BCD
		// (set) Token: 0x06020489 RID: 132233 RVA: 0x009279DD File Offset: 0x00925BDD
		public unsafe float 软源半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170034CB RID: 13515
		// (get) Token: 0x0602048A RID: 132234 RVA: 0x009279EE File Offset: 0x00925BEE
		// (set) Token: 0x0602048B RID: 132235 RVA: 0x009279FE File Offset: 0x00925BFE
		public unsafe float 源长度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170034CC RID: 13516
		// (get) Token: 0x0602048C RID: 132236 RVA: 0x00927A10 File Offset: 0x00925C10
		// (set) Token: 0x0602048D RID: 132237 RVA: 0x00927A49 File Offset: 0x00925C49
		public FKuroCurveFloat LightsIntensityCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._LightsIntensityCurve) == null)
				{
					result = (this._LightsIntensityCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034CD RID: 13517
		// (get) Token: 0x0602048E RID: 132238 RVA: 0x00927A6C File Offset: 0x00925C6C
		// (set) Token: 0x0602048F RID: 132239 RVA: 0x00927AA5 File Offset: 0x00925CA5
		public FKuroCurveFloat LightsRadiusCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._LightsRadiusCurve) == null)
				{
					result = (this._LightsRadiusCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034CE RID: 13518
		// (get) Token: 0x06020490 RID: 132240 RVA: 0x00927AC6 File Offset: 0x00925CC6
		// (set) Token: 0x06020491 RID: 132241 RVA: 0x00927AD6 File Offset: 0x00925CD6
		public unsafe float CurveTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170034CF RID: 13519
		// (get) Token: 0x06020492 RID: 132242 RVA: 0x00927AE7 File Offset: 0x00925CE7
		// (set) Token: 0x06020493 RID: 132243 RVA: 0x00927AF7 File Offset: 0x00925CF7
		public unsafe float RadiusScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170034D0 RID: 13520
		// (get) Token: 0x06020494 RID: 132244 RVA: 0x00927B08 File Offset: 0x00925D08
		// (set) Token: 0x06020495 RID: 132245 RVA: 0x00927B18 File Offset: 0x00925D18
		public unsafe float IntensityScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170034D1 RID: 13521
		// (get) Token: 0x06020496 RID: 132246 RVA: 0x00927B29 File Offset: 0x00925D29
		// (set) Token: 0x06020497 RID: 132247 RVA: 0x00927B39 File Offset: 0x00925D39
		public unsafe float LightGenerateIntervalMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170034D2 RID: 13522
		// (get) Token: 0x06020498 RID: 132248 RVA: 0x00927B4A File Offset: 0x00925D4A
		// (set) Token: 0x06020499 RID: 132249 RVA: 0x00927B5A File Offset: 0x00925D5A
		public unsafe float LightGenerateIntervalMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170034D3 RID: 13523
		// (get) Token: 0x0602049A RID: 132250 RVA: 0x00927B6B File Offset: 0x00925D6B
		// (set) Token: 0x0602049B RID: 132251 RVA: 0x00927B7B File Offset: 0x00925D7B
		public unsafe float LightLifeTimeMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170034D4 RID: 13524
		// (get) Token: 0x0602049C RID: 132252 RVA: 0x00927B8C File Offset: 0x00925D8C
		// (set) Token: 0x0602049D RID: 132253 RVA: 0x00927B9C File Offset: 0x00925D9C
		public unsafe float LightLifeTimeMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170034D5 RID: 13525
		// (get) Token: 0x0602049E RID: 132254 RVA: 0x00927BB0 File Offset: 0x00925DB0
		// (set) Token: 0x0602049F RID: 132255 RVA: 0x00927BE9 File Offset: 0x00925DE9
		public FKuroCurveFloat IntensityMask
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._IntensityMask) == null)
				{
					result = (this._IntensityMask = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034D6 RID: 13526
		// (get) Token: 0x060204A0 RID: 132256 RVA: 0x00927C0A File Offset: 0x00925E0A
		// (set) Token: 0x060204A1 RID: 132257 RVA: 0x00927C1A File Offset: 0x00925E1A
		public unsafe float LightGenerationCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170034D7 RID: 13527
		// (get) Token: 0x060204A2 RID: 132258 RVA: 0x00927C2C File Offset: 0x00925E2C
		// (set) Token: 0x060204A3 RID: 132259 RVA: 0x00927C65 File Offset: 0x00925E65
		public TArray<UPointLightComponent> PointLightsPool
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UPointLightComponent> result;
				if ((result = this._PointLightsPool) == null)
				{
					result = (this._PointLightsPool = new TArray<UPointLightComponent>(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				this.PointLightsPool.CopyAssign(value);
			}
		}

		// Token: 0x170034D8 RID: 13528
		// (get) Token: 0x060204A4 RID: 132260 RVA: 0x00927C74 File Offset: 0x00925E74
		// (set) Token: 0x060204A5 RID: 132261 RVA: 0x00927CAD File Offset: 0x00925EAD
		public TArray<SSpineLightRuntimeData> RuntimeLightsData
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSpineLightRuntimeData> result;
				if ((result = this._RuntimeLightsData) == null)
				{
					result = (this._RuntimeLightsData = new TArray<SSpineLightRuntimeData>(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				this.RuntimeLightsData.CopyAssign(value);
			}
		}

		// Token: 0x170034D9 RID: 13529
		// (get) Token: 0x060204A6 RID: 132262 RVA: 0x00927CBB File Offset: 0x00925EBB
		// (set) Token: 0x060204A7 RID: 132263 RVA: 0x00927CCB File Offset: 0x00925ECB
		public unsafe bool Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034DA RID: 13530
		// (get) Token: 0x060204A8 RID: 132264 RVA: 0x00927CDC File Offset: 0x00925EDC
		// (set) Token: 0x060204A9 RID: 132265 RVA: 0x00927CEC File Offset: 0x00925EEC
		public unsafe bool GenerateAtNightOnly
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034DB RID: 13531
		// (get) Token: 0x060204AA RID: 132266 RVA: 0x00927CFD File Offset: 0x00925EFD
		// (set) Token: 0x060204AB RID: 132267 RVA: 0x00927D0D File Offset: 0x00925F0D
		public unsafe bool OverrideSuperFarActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034DC RID: 13532
		// (get) Token: 0x060204AC RID: 132268 RVA: 0x00927D1E File Offset: 0x00925F1E
		// (set) Token: 0x060204AD RID: 132269 RVA: 0x00927D2E File Offset: 0x00925F2E
		public unsafe bool SpecialBlueprintActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineLights_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x060204AE RID: 132270 RVA: 0x00927D40 File Offset: 0x00925F40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_SplineLights_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_SplineLights_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineLights_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060204AF RID: 132271 RVA: 0x00927D88 File Offset: 0x00925F88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_SplineLights_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_SplineLights_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineLights_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineLights_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x060204B0 RID: 132272 RVA: 0x00927DCE File Offset: 0x00925FCE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__UpdateEffect_NativeFunctionPtr, null);
		}

		// Token: 0x060204B1 RID: 132273 RVA: 0x00927DE4 File Offset: 0x00925FE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RecycleLight(int RemoveIndex)
		{
			BP_SplineLights_C.__RecycleLight_FunctionParams* ptr = stackalloc BP_SplineLights_C.__RecycleLight_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SplineLights_C.__RecycleLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__RecycleLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RemoveIndex = RemoveIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__RecycleLight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060204B2 RID: 132274 RVA: 0x00927E2A File Offset: 0x0092602A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLifeTime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__UpdateLifeTime_NativeFunctionPtr, null);
		}

		// Token: 0x060204B3 RID: 132275 RVA: 0x00927E3E File Offset: 0x0092603E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__GenerateLight_NativeFunctionPtr, null);
		}

		// Token: 0x060204B4 RID: 132276 RVA: 0x00927E52 File Offset: 0x00926052
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateGeneration()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__UpdateGeneration_NativeFunctionPtr, null);
		}

		// Token: 0x060204B5 RID: 132277 RVA: 0x00927E66 File Offset: 0x00926066
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x060204B6 RID: 132278 RVA: 0x00927E7A File Offset: 0x0092607A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060204B7 RID: 132279 RVA: 0x00927E8E File Offset: 0x0092608E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineLights_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060204B8 RID: 132280 RVA: 0x00927EA4 File Offset: 0x009260A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SplineLights_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineLights_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineLights_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060204B9 RID: 132281 RVA: 0x00927EEC File Offset: 0x009260EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SplineLights_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineLights_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineLights_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineLights_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060204BA RID: 132282 RVA: 0x00927F34 File Offset: 0x00926134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SplineLights_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplineLights_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineLights_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060204BB RID: 132283 RVA: 0x00927F7C File Offset: 0x0092617C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SplineLights_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplineLights_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineLights_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineLights_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060204BC RID: 132284 RVA: 0x00927FC3 File Offset: 0x009261C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineLights_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060204BD RID: 132285 RVA: 0x00927FD7 File Offset: 0x009261D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineLights_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060204BE RID: 132286 RVA: 0x00927FEC File Offset: 0x009261EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplineLights(int EntryPoint)
		{
			BP_SplineLights_C.__ExecuteUbergraph_BP_SplineLights_FunctionParams* ptr = stackalloc BP_SplineLights_C.__ExecuteUbergraph_BP_SplineLights_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SplineLights_C.__ExecuteUbergraph_BP_SplineLights_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineLights_C.__ExecuteUbergraph_BP_SplineLights_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineLights_C.__ExecuteUbergraph_BP_SplineLights_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060204BF RID: 132287 RVA: 0x00928033 File Offset: 0x00926233
		protected BP_SplineLights_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040101AF RID: 65967
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x040101B0 RID: 65968
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_SplineLights.BP_SplineLights_C";

		// Token: 0x040101B1 RID: 65969
		private static IntPtr _ClassPtr;

		// Token: 0x040101B2 RID: 65970
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040101B3 RID: 65971
		internal static int __PropertyOffset_0;

		// Token: 0x040101B4 RID: 65972
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040101B5 RID: 65973
		internal static int __PropertyOffset_1;

		// Token: 0x040101B6 RID: 65974
		internal static int __PropertyOffset_2;

		// Token: 0x040101B7 RID: 65975
		internal static int __PropertyOffset_3;

		// Token: 0x040101B8 RID: 65976
		internal static int __PropertyOffset_4;

		// Token: 0x040101B9 RID: 65977
		internal static int __PropertyOffset_5;

		// Token: 0x040101BA RID: 65978
		internal static int __PropertyOffset_6;

		// Token: 0x040101BB RID: 65979
		internal static int __PropertyOffset_7;

		// Token: 0x040101BC RID: 65980
		internal static int __PropertyOffset_8;

		// Token: 0x040101BD RID: 65981
		internal static int __PropertyOffset_9;

		// Token: 0x040101BE RID: 65982
		internal static int __PropertyOffset_10;

		// Token: 0x040101BF RID: 65983
		[Nullable(2)]
		private FKuroCurveFloat _LightsIntensityCurve;

		// Token: 0x040101C0 RID: 65984
		internal static int __PropertyOffset_11;

		// Token: 0x040101C1 RID: 65985
		[Nullable(2)]
		private FKuroCurveFloat _LightsRadiusCurve;

		// Token: 0x040101C2 RID: 65986
		internal static int __PropertyOffset_12;

		// Token: 0x040101C3 RID: 65987
		internal static int __PropertyOffset_13;

		// Token: 0x040101C4 RID: 65988
		internal static int __PropertyOffset_14;

		// Token: 0x040101C5 RID: 65989
		internal static int __PropertyOffset_15;

		// Token: 0x040101C6 RID: 65990
		internal static int __PropertyOffset_16;

		// Token: 0x040101C7 RID: 65991
		internal static int __PropertyOffset_17;

		// Token: 0x040101C8 RID: 65992
		internal static int __PropertyOffset_18;

		// Token: 0x040101C9 RID: 65993
		internal static int __PropertyOffset_19;

		// Token: 0x040101CA RID: 65994
		[Nullable(2)]
		private FKuroCurveFloat _IntensityMask;

		// Token: 0x040101CB RID: 65995
		internal static int __PropertyOffset_20;

		// Token: 0x040101CC RID: 65996
		internal static int __PropertyOffset_21;

		// Token: 0x040101CD RID: 65997
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UPointLightComponent> _PointLightsPool;

		// Token: 0x040101CE RID: 65998
		internal static int __PropertyOffset_22;

		// Token: 0x040101CF RID: 65999
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSpineLightRuntimeData> _RuntimeLightsData;

		// Token: 0x040101D0 RID: 66000
		internal static int __PropertyOffset_23;

		// Token: 0x040101D1 RID: 66001
		internal static int __PropertyOffset_24;

		// Token: 0x040101D2 RID: 66002
		internal static int __PropertyOffset_25;

		// Token: 0x040101D3 RID: 66003
		internal static int __PropertyOffset_26;

		// Token: 0x040101D4 RID: 66004
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x040101D5 RID: 66005
		private static IntPtr __UpdateEffect_NativeFunctionPtr;

		// Token: 0x040101D6 RID: 66006
		private static IntPtr __RecycleLight_NativeFunctionPtr;

		// Token: 0x040101D7 RID: 66007
		private static IntPtr __UpdateLifeTime_NativeFunctionPtr;

		// Token: 0x040101D8 RID: 66008
		private static IntPtr __GenerateLight_NativeFunctionPtr;

		// Token: 0x040101D9 RID: 66009
		private static IntPtr __UpdateGeneration_NativeFunctionPtr;

		// Token: 0x040101DA RID: 66010
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x040101DB RID: 66011
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040101DC RID: 66012
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040101DD RID: 66013
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040101DE RID: 66014
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040101DF RID: 66015
		private static IntPtr __ExecuteUbergraph_BP_SplineLights_NativeFunctionPtr;

		// Token: 0x0200998C RID: 39308
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04032012 RID: 204818
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x0200998D RID: 39309
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __RecycleLight_FunctionParams
		{
			// Token: 0x04032013 RID: 204819
			[FieldOffset(0)]
			public int RemoveIndex;
		}

		// Token: 0x0200998E RID: 39310
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032014 RID: 204820
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200998F RID: 39311
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032015 RID: 204821
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009990 RID: 39312
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SplineLights_FunctionParams
		{
			// Token: 0x04032016 RID: 204822
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
