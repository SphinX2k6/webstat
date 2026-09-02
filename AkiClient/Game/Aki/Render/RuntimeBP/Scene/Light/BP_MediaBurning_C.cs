using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A90 RID: 14992
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_MediaBurning.BP_MediaBurning_C")]
	[UnrealStructLayout(1672, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1672)]
	public class BP_MediaBurning_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F876 RID: 129142 RVA: 0x00913EB0 File Offset: 0x009120B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MediaBurning_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_MediaBurning.BP_MediaBurning_C");
			}
			return BP_MediaBurning_C._ClassPtr;
		}

		// Token: 0x0601F877 RID: 129143 RVA: 0x00913ED4 File Offset: 0x009120D4
		public BP_MediaBurning_C() : this(BuiltinUtils.AllocNativeUObject(BP_MediaBurning_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F878 RID: 129144 RVA: 0x00913EFC File Offset: 0x009120FC
		[NullableContext(1)]
		public BP_MediaBurning_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MediaBurning_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003078 RID: 12408
		// (get) Token: 0x0601F879 RID: 129145 RVA: 0x00913F30 File Offset: 0x00912130
		// (set) Token: 0x0601F87A RID: 129146 RVA: 0x00913F69 File Offset: 0x00912169
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003079 RID: 12409
		// (get) Token: 0x0601F87B RID: 129147 RVA: 0x00913F8A File Offset: 0x0091218A
		// (set) Token: 0x0601F87C RID: 129148 RVA: 0x00913F9E File Offset: 0x0091219E
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700307A RID: 12410
		// (get) Token: 0x0601F87D RID: 129149 RVA: 0x00913FB3 File Offset: 0x009121B3
		// (set) Token: 0x0601F87E RID: 129150 RVA: 0x00913FC7 File Offset: 0x009121C7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700307B RID: 12411
		// (get) Token: 0x0601F87F RID: 129151 RVA: 0x00913FDC File Offset: 0x009121DC
		// (set) Token: 0x0601F880 RID: 129152 RVA: 0x00913FF0 File Offset: 0x009121F0
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700307C RID: 12412
		// (get) Token: 0x0601F881 RID: 129153 RVA: 0x00914008 File Offset: 0x00912208
		// (set) Token: 0x0601F882 RID: 129154 RVA: 0x00914041 File Offset: 0x00912241
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700307D RID: 12413
		// (get) Token: 0x0601F883 RID: 129155 RVA: 0x00914050 File Offset: 0x00912250
		// (set) Token: 0x0601F884 RID: 129156 RVA: 0x00914089 File Offset: 0x00912289
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700307E RID: 12414
		// (get) Token: 0x0601F885 RID: 129157 RVA: 0x00914098 File Offset: 0x00912298
		// (set) Token: 0x0601F886 RID: 129158 RVA: 0x009140D1 File Offset: 0x009122D1
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x1700307F RID: 12415
		// (get) Token: 0x0601F887 RID: 129159 RVA: 0x009140DF File Offset: 0x009122DF
		// (set) Token: 0x0601F888 RID: 129160 RVA: 0x009140F3 File Offset: 0x009122F3
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003080 RID: 12416
		// (get) Token: 0x0601F889 RID: 129161 RVA: 0x00914108 File Offset: 0x00912308
		// (set) Token: 0x0601F88A RID: 129162 RVA: 0x00914118 File Offset: 0x00912318
		public unsafe float FireIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003081 RID: 12417
		// (get) Token: 0x0601F88B RID: 129163 RVA: 0x00914129 File Offset: 0x00912329
		// (set) Token: 0x0601F88C RID: 129164 RVA: 0x00914139 File Offset: 0x00912339
		public unsafe float NumSamples
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003082 RID: 12418
		// (get) Token: 0x0601F88D RID: 129165 RVA: 0x0091414A File Offset: 0x0091234A
		// (set) Token: 0x0601F88E RID: 129166 RVA: 0x0091415E File Offset: 0x0091235E
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003083 RID: 12419
		// (get) Token: 0x0601F88F RID: 129167 RVA: 0x00914173 File Offset: 0x00912373
		// (set) Token: 0x0601F890 RID: 129168 RVA: 0x00914183 File Offset: 0x00912383
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003084 RID: 12420
		// (get) Token: 0x0601F891 RID: 129169 RVA: 0x00914194 File Offset: 0x00912394
		// (set) Token: 0x0601F892 RID: 129170 RVA: 0x009141A4 File Offset: 0x009123A4
		public unsafe float SkyRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003085 RID: 12421
		// (get) Token: 0x0601F893 RID: 129171 RVA: 0x009141B5 File Offset: 0x009123B5
		// (set) Token: 0x0601F894 RID: 129172 RVA: 0x009141C5 File Offset: 0x009123C5
		public unsafe float SkyDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003086 RID: 12422
		// (get) Token: 0x0601F895 RID: 129173 RVA: 0x009141D6 File Offset: 0x009123D6
		// (set) Token: 0x0601F896 RID: 129174 RVA: 0x009141E6 File Offset: 0x009123E6
		public unsafe float TangFreq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003087 RID: 12423
		// (get) Token: 0x0601F897 RID: 129175 RVA: 0x009141F7 File Offset: 0x009123F7
		// (set) Token: 0x0601F898 RID: 129176 RVA: 0x00914207 File Offset: 0x00912407
		public unsafe float NoiseScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003088 RID: 12424
		// (get) Token: 0x0601F899 RID: 129177 RVA: 0x00914218 File Offset: 0x00912418
		// (set) Token: 0x0601F89A RID: 129178 RVA: 0x00914228 File Offset: 0x00912428
		public unsafe bool EnableSimLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003089 RID: 12425
		// (get) Token: 0x0601F89B RID: 129179 RVA: 0x00914239 File Offset: 0x00912439
		// (set) Token: 0x0601F89C RID: 129180 RVA: 0x00914249 File Offset: 0x00912449
		public unsafe float Soft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700308A RID: 12426
		// (get) Token: 0x0601F89D RID: 129181 RVA: 0x0091425A File Offset: 0x0091245A
		// (set) Token: 0x0601F89E RID: 129182 RVA: 0x0091426A File Offset: 0x0091246A
		public unsafe float WarpStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700308B RID: 12427
		// (get) Token: 0x0601F89F RID: 129183 RVA: 0x0091427B File Offset: 0x0091247B
		// (set) Token: 0x0601F8A0 RID: 129184 RVA: 0x0091428B File Offset: 0x0091248B
		public unsafe float ShapeAmount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700308C RID: 12428
		// (get) Token: 0x0601F8A1 RID: 129185 RVA: 0x0091429C File Offset: 0x0091249C
		// (set) Token: 0x0601F8A2 RID: 129186 RVA: 0x009142AC File Offset: 0x009124AC
		public unsafe float ShapeNoiseSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700308D RID: 12429
		// (get) Token: 0x0601F8A3 RID: 129187 RVA: 0x009142BD File Offset: 0x009124BD
		// (set) Token: 0x0601F8A4 RID: 129188 RVA: 0x009142CD File Offset: 0x009124CD
		public unsafe float ShapeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700308E RID: 12430
		// (get) Token: 0x0601F8A5 RID: 129189 RVA: 0x009142DE File Offset: 0x009124DE
		// (set) Token: 0x0601F8A6 RID: 129190 RVA: 0x009142EE File Offset: 0x009124EE
		public unsafe bool Invert
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700308F RID: 12431
		// (get) Token: 0x0601F8A7 RID: 129191 RVA: 0x009142FF File Offset: 0x009124FF
		// (set) Token: 0x0601F8A8 RID: 129192 RVA: 0x0091430F File Offset: 0x0091250F
		public unsafe bool DebugSimLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MediaBurning_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003090 RID: 12432
		// (get) Token: 0x0601F8A9 RID: 129193 RVA: 0x00914320 File Offset: 0x00912520
		// (set) Token: 0x0601F8AA RID: 129194 RVA: 0x00914334 File Offset: 0x00912534
		public unsafe UTexture2D ShapeTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MediaBurning_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x0601F8AB RID: 129195 RVA: 0x00914349 File Offset: 0x00912549
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaBurning_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8AC RID: 129196 RVA: 0x0091435D File Offset: 0x0091255D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaBurning_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8AD RID: 129197 RVA: 0x00914371 File Offset: 0x00912571
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaBurning_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8AE RID: 129198 RVA: 0x00914386 File Offset: 0x00912586
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaBurning_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8AF RID: 129199 RVA: 0x0091439A File Offset: 0x0091259A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaBurning_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8B0 RID: 129200 RVA: 0x009143B0 File Offset: 0x009125B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MediaBurning_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MediaBurning_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaBurning_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaBurning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaBurning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F8B1 RID: 129201 RVA: 0x009143F8 File Offset: 0x009125F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MediaBurning_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MediaBurning_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaBurning_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaBurning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaBurning_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8B2 RID: 129202 RVA: 0x0091443F File Offset: 0x0091263F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaBurning_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F8B3 RID: 129203 RVA: 0x00914453 File Offset: 0x00912653
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaBurning_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F8B4 RID: 129204 RVA: 0x00914468 File Offset: 0x00912668
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MediaBurning_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MediaBurning_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaBurning_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaBurning_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MediaBurning_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F8B5 RID: 129205 RVA: 0x009144B0 File Offset: 0x009126B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MediaBurning_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MediaBurning_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MediaBurning_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaBurning_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaBurning_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8B6 RID: 129206 RVA: 0x009144F8 File Offset: 0x009126F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MediaBurning(int EntryPoint)
		{
			BP_MediaBurning_C.__ExecuteUbergraph_BP_MediaBurning_FunctionParams* ptr = stackalloc BP_MediaBurning_C.__ExecuteUbergraph_BP_MediaBurning_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_MediaBurning_C.__ExecuteUbergraph_BP_MediaBurning_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MediaBurning_C.__ExecuteUbergraph_BP_MediaBurning_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MediaBurning_C.__ExecuteUbergraph_BP_MediaBurning_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F8B7 RID: 129207 RVA: 0x0091453F File Offset: 0x0091273F
		protected BP_MediaBurning_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FAAB RID: 64171
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_MediaBurning.BP_MediaBurning_C";

		// Token: 0x0400FAAC RID: 64172
		private static IntPtr _ClassPtr;

		// Token: 0x0400FAAD RID: 64173
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FAAE RID: 64174
		internal static int __PropertyOffset_0;

		// Token: 0x0400FAAF RID: 64175
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FAB0 RID: 64176
		internal static int __PropertyOffset_1;

		// Token: 0x0400FAB1 RID: 64177
		internal static int __PropertyOffset_2;

		// Token: 0x0400FAB2 RID: 64178
		internal static int __PropertyOffset_3;

		// Token: 0x0400FAB3 RID: 64179
		internal static int __PropertyOffset_4;

		// Token: 0x0400FAB4 RID: 64180
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400FAB5 RID: 64181
		internal static int __PropertyOffset_5;

		// Token: 0x0400FAB6 RID: 64182
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400FAB7 RID: 64183
		internal static int __PropertyOffset_6;

		// Token: 0x0400FAB8 RID: 64184
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400FAB9 RID: 64185
		internal static int __PropertyOffset_7;

		// Token: 0x0400FABA RID: 64186
		internal static int __PropertyOffset_8;

		// Token: 0x0400FABB RID: 64187
		internal static int __PropertyOffset_9;

		// Token: 0x0400FABC RID: 64188
		internal static int __PropertyOffset_10;

		// Token: 0x0400FABD RID: 64189
		internal static int __PropertyOffset_11;

		// Token: 0x0400FABE RID: 64190
		internal static int __PropertyOffset_12;

		// Token: 0x0400FABF RID: 64191
		internal static int __PropertyOffset_13;

		// Token: 0x0400FAC0 RID: 64192
		internal static int __PropertyOffset_14;

		// Token: 0x0400FAC1 RID: 64193
		internal static int __PropertyOffset_15;

		// Token: 0x0400FAC2 RID: 64194
		internal static int __PropertyOffset_16;

		// Token: 0x0400FAC3 RID: 64195
		internal static int __PropertyOffset_17;

		// Token: 0x0400FAC4 RID: 64196
		internal static int __PropertyOffset_18;

		// Token: 0x0400FAC5 RID: 64197
		internal static int __PropertyOffset_19;

		// Token: 0x0400FAC6 RID: 64198
		internal static int __PropertyOffset_20;

		// Token: 0x0400FAC7 RID: 64199
		internal static int __PropertyOffset_21;

		// Token: 0x0400FAC8 RID: 64200
		internal static int __PropertyOffset_22;

		// Token: 0x0400FAC9 RID: 64201
		internal static int __PropertyOffset_23;

		// Token: 0x0400FACA RID: 64202
		internal static int __PropertyOffset_24;

		// Token: 0x0400FACB RID: 64203
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400FACC RID: 64204
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FACD RID: 64205
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FACE RID: 64206
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FACF RID: 64207
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400FAD0 RID: 64208
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FAD1 RID: 64209
		private static IntPtr __ExecuteUbergraph_BP_MediaBurning_NativeFunctionPtr;

		// Token: 0x020098F3 RID: 39155
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F52 RID: 204626
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098F4 RID: 39156
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F53 RID: 204627
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098F5 RID: 39157
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_MediaBurning_FunctionParams
		{
			// Token: 0x04031F54 RID: 204628
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
