using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Volumetrics
{
	// Token: 0x02003CFF RID: 15615
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Volumetrics/VolumeSmokeComponent.VolumeSmokeComponent_C")]
	[UnrealStructLayout(384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 377)]
	public class VolumeSmokeComponent_C : UKuroBPActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025A17 RID: 154135 RVA: 0x009BF543 File Offset: 0x009BD743
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (VolumeSmokeComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Volumetrics/VolumeSmokeComponent.VolumeSmokeComponent_C");
			}
			return VolumeSmokeComponent_C._ClassPtr;
		}

		// Token: 0x06025A18 RID: 154136 RVA: 0x009BF568 File Offset: 0x009BD768
		public VolumeSmokeComponent_C() : this(BuiltinUtils.AllocNativeUObject(VolumeSmokeComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025A19 RID: 154137 RVA: 0x009BF590 File Offset: 0x009BD790
		[NullableContext(1)]
		public VolumeSmokeComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(VolumeSmokeComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170052FA RID: 21242
		// (get) Token: 0x06025A1A RID: 154138 RVA: 0x009BF5C4 File Offset: 0x009BD7C4
		// (set) Token: 0x06025A1B RID: 154139 RVA: 0x009BF5FD File Offset: 0x009BD7FD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170052FB RID: 21243
		// (get) Token: 0x06025A1C RID: 154140 RVA: 0x009BF61E File Offset: 0x009BD81E
		// (set) Token: 0x06025A1D RID: 154141 RVA: 0x009BF632 File Offset: 0x009BD832
		public unsafe UStaticMeshComponent DepthSlicerComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170052FC RID: 21244
		// (get) Token: 0x06025A1E RID: 154142 RVA: 0x009BF647 File Offset: 0x009BD847
		// (set) Token: 0x06025A1F RID: 154143 RVA: 0x009BF657 File Offset: 0x009BD857
		public unsafe bool Disable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052FD RID: 21245
		// (get) Token: 0x06025A20 RID: 154144 RVA: 0x009BF668 File Offset: 0x009BD868
		// (set) Token: 0x06025A21 RID: 154145 RVA: 0x009BF678 File Offset: 0x009BD878
		public unsafe bool DirectlySetMaterialByNinja
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052FE RID: 21246
		// (get) Token: 0x06025A22 RID: 154146 RVA: 0x009BF689 File Offset: 0x009BD889
		// (set) Token: 0x06025A23 RID: 154147 RVA: 0x009BF699 File Offset: 0x009BD899
		public unsafe bool DirectlySetPositionAnd_ScaleByNinja
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052FF RID: 21247
		// (get) Token: 0x06025A24 RID: 154148 RVA: 0x009BF6AA File Offset: 0x009BD8AA
		// (set) Token: 0x06025A25 RID: 154149 RVA: 0x009BF6BA File Offset: 0x009BD8BA
		public unsafe bool AnchorVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005300 RID: 21248
		// (get) Token: 0x06025A26 RID: 154150 RVA: 0x009BF6CB File Offset: 0x009BD8CB
		// (set) Token: 0x06025A27 RID: 154151 RVA: 0x009BF6DF File Offset: 0x009BD8DF
		public unsafe FName ComponentTagToGetDirectlyIdentifiedByNinja
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005301 RID: 21249
		// (get) Token: 0x06025A28 RID: 154152 RVA: 0x009BF6F4 File Offset: 0x009BD8F4
		// (set) Token: 0x06025A29 RID: 154153 RVA: 0x009BF708 File Offset: 0x009BD908
		public unsafe FName NullTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005302 RID: 21250
		// (get) Token: 0x06025A2A RID: 154154 RVA: 0x009BF71D File Offset: 0x009BD91D
		// (set) Token: 0x06025A2B RID: 154155 RVA: 0x009BF731 File Offset: 0x009BD931
		public unsafe UTextureRenderTarget2D InputRenderTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005303 RID: 21251
		// (get) Token: 0x06025A2C RID: 154156 RVA: 0x009BF746 File Offset: 0x009BD946
		// (set) Token: 0x06025A2D RID: 154157 RVA: 0x009BF75A File Offset: 0x009BD95A
		public unsafe UMaterialInterface VolumeSmokeMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17005304 RID: 21252
		// (get) Token: 0x06025A2E RID: 154158 RVA: 0x009BF76F File Offset: 0x009BD96F
		// (set) Token: 0x06025A2F RID: 154159 RVA: 0x009BF783 File Offset: 0x009BD983
		public unsafe AActor TrackThisActorAsPointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17005305 RID: 21253
		// (get) Token: 0x06025A30 RID: 154160 RVA: 0x009BF798 File Offset: 0x009BD998
		// (set) Token: 0x06025A31 RID: 154161 RVA: 0x009BF7A8 File Offset: 0x009BD9A8
		public unsafe bool LockRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005306 RID: 21254
		// (get) Token: 0x06025A32 RID: 154162 RVA: 0x009BF7B9 File Offset: 0x009BD9B9
		// (set) Token: 0x06025A33 RID: 154163 RVA: 0x009BF7C9 File Offset: 0x009BD9C9
		public unsafe bool CameraFacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005307 RID: 21255
		// (get) Token: 0x06025A34 RID: 154164 RVA: 0x009BF7DA File Offset: 0x009BD9DA
		// (set) Token: 0x06025A35 RID: 154165 RVA: 0x009BF7EA File Offset: 0x009BD9EA
		public unsafe bool CameraFacingLockY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005308 RID: 21256
		// (get) Token: 0x06025A36 RID: 154166 RVA: 0x009BF7FB File Offset: 0x009BD9FB
		// (set) Token: 0x06025A37 RID: 154167 RVA: 0x009BF80B File Offset: 0x009BDA0B
		public unsafe bool UseLegacyCameraFacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005309 RID: 21257
		// (get) Token: 0x06025A38 RID: 154168 RVA: 0x009BF81C File Offset: 0x009BDA1C
		// (set) Token: 0x06025A39 RID: 154169 RVA: 0x009BF830 File Offset: 0x009BDA30
		public unsafe FVector PositionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700530A RID: 21258
		// (get) Token: 0x06025A3A RID: 154170 RVA: 0x009BF845 File Offset: 0x009BDA45
		// (set) Token: 0x06025A3B RID: 154171 RVA: 0x009BF859 File Offset: 0x009BDA59
		public unsafe FVector PointLightPositionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700530B RID: 21259
		// (get) Token: 0x06025A3C RID: 154172 RVA: 0x009BF86E File Offset: 0x009BDA6E
		// (set) Token: 0x06025A3D RID: 154173 RVA: 0x009BF87E File Offset: 0x009BDA7E
		public unsafe float VolumeSizeMultiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700530C RID: 21260
		// (get) Token: 0x06025A3E RID: 154174 RVA: 0x009BF88F File Offset: 0x009BDA8F
		// (set) Token: 0x06025A3F RID: 154175 RVA: 0x009BF89F File Offset: 0x009BDA9F
		public unsafe float VolumeSideRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700530D RID: 21261
		// (get) Token: 0x06025A40 RID: 154176 RVA: 0x009BF8B0 File Offset: 0x009BDAB0
		// (set) Token: 0x06025A41 RID: 154177 RVA: 0x009BF8C4 File Offset: 0x009BDAC4
		public unsafe UMaterialInstanceDynamic DynamicMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700530E RID: 21262
		// (get) Token: 0x06025A42 RID: 154178 RVA: 0x009BF8D9 File Offset: 0x009BDAD9
		// (set) Token: 0x06025A43 RID: 154179 RVA: 0x009BF8ED File Offset: 0x009BDAED
		public unsafe FRotator InitialRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700530F RID: 21263
		// (get) Token: 0x06025A44 RID: 154180 RVA: 0x009BF902 File Offset: 0x009BDB02
		// (set) Token: 0x06025A45 RID: 154181 RVA: 0x009BF916 File Offset: 0x009BDB16
		public unsafe UMaterialInterface PreviousMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17005310 RID: 21264
		// (get) Token: 0x06025A46 RID: 154182 RVA: 0x009BF92B File Offset: 0x009BDB2B
		// (set) Token: 0x06025A47 RID: 154183 RVA: 0x009BF93F File Offset: 0x009BDB3F
		public unsafe UStaticMesh DepthSlicer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17005311 RID: 21265
		// (get) Token: 0x06025A48 RID: 154184 RVA: 0x009BF954 File Offset: 0x009BDB54
		// (set) Token: 0x06025A49 RID: 154185 RVA: 0x009BF968 File Offset: 0x009BDB68
		public unsafe UBoxComponent Volume_Visualize_Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + VolumeSmokeComponent_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17005312 RID: 21266
		// (get) Token: 0x06025A4A RID: 154186 RVA: 0x009BF97D File Offset: 0x009BDB7D
		// (set) Token: 0x06025A4B RID: 154187 RVA: 0x009BF98D File Offset: 0x009BDB8D
		public unsafe bool OwnerIsVolumeSmokeActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)VolumeSmokeComponent_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025A4C RID: 154188 RVA: 0x009BF99E File Offset: 0x009BDB9E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeRemotelySetMaterial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, VolumeSmokeComponent_C.__InitializeRemotelySetMaterial_NativeFunctionPtr, null);
		}

		// Token: 0x06025A4D RID: 154189 RVA: 0x009BF9B2 File Offset: 0x009BDBB2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeLocallySetMaterial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, VolumeSmokeComponent_C.__InitializeLocallySetMaterial_NativeFunctionPtr, null);
		}

		// Token: 0x06025A4E RID: 154190 RVA: 0x009BF9C6 File Offset: 0x009BDBC6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Refresh_Lighting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, VolumeSmokeComponent_C.__Refresh_Lighting_NativeFunctionPtr, null);
		}

		// Token: 0x06025A4F RID: 154191 RVA: 0x009BF9DA File Offset: 0x009BDBDA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, VolumeSmokeComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025A50 RID: 154192 RVA: 0x009BF9EE File Offset: 0x009BDBEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, VolumeSmokeComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025A51 RID: 154193 RVA: 0x009BFA04 File Offset: 0x009BDC04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			VolumeSmokeComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc VolumeSmokeComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(VolumeSmokeComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(VolumeSmokeComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, VolumeSmokeComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025A52 RID: 154194 RVA: 0x009BFA4C File Offset: 0x009BDC4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			VolumeSmokeComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc VolumeSmokeComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(VolumeSmokeComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(VolumeSmokeComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, VolumeSmokeComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025A53 RID: 154195 RVA: 0x009BFA94 File Offset: 0x009BDC94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_VolumeSmokeComponent(int EntryPoint)
		{
			VolumeSmokeComponent_C.__ExecuteUbergraph_VolumeSmokeComponent_FunctionParams* ptr = stackalloc VolumeSmokeComponent_C.__ExecuteUbergraph_VolumeSmokeComponent_FunctionParams[(UIntPtr)559] + 15L / (long)sizeof(VolumeSmokeComponent_C.__ExecuteUbergraph_VolumeSmokeComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(VolumeSmokeComponent_C.__ExecuteUbergraph_VolumeSmokeComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, VolumeSmokeComponent_C.__ExecuteUbergraph_VolumeSmokeComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025A54 RID: 154196 RVA: 0x009BFADE File Offset: 0x009BDCDE
		protected VolumeSmokeComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040136A1 RID: 79521
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Volumetrics/VolumeSmokeComponent.VolumeSmokeComponent_C";

		// Token: 0x040136A2 RID: 79522
		private static IntPtr _ClassPtr;

		// Token: 0x040136A3 RID: 79523
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040136A4 RID: 79524
		internal static int __PropertyOffset_0;

		// Token: 0x040136A5 RID: 79525
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040136A6 RID: 79526
		internal static int __PropertyOffset_1;

		// Token: 0x040136A7 RID: 79527
		internal static int __PropertyOffset_2;

		// Token: 0x040136A8 RID: 79528
		internal static int __PropertyOffset_3;

		// Token: 0x040136A9 RID: 79529
		internal static int __PropertyOffset_4;

		// Token: 0x040136AA RID: 79530
		internal static int __PropertyOffset_5;

		// Token: 0x040136AB RID: 79531
		internal static int __PropertyOffset_6;

		// Token: 0x040136AC RID: 79532
		internal static int __PropertyOffset_7;

		// Token: 0x040136AD RID: 79533
		internal static int __PropertyOffset_8;

		// Token: 0x040136AE RID: 79534
		internal static int __PropertyOffset_9;

		// Token: 0x040136AF RID: 79535
		internal static int __PropertyOffset_10;

		// Token: 0x040136B0 RID: 79536
		internal static int __PropertyOffset_11;

		// Token: 0x040136B1 RID: 79537
		internal static int __PropertyOffset_12;

		// Token: 0x040136B2 RID: 79538
		internal static int __PropertyOffset_13;

		// Token: 0x040136B3 RID: 79539
		internal static int __PropertyOffset_14;

		// Token: 0x040136B4 RID: 79540
		internal static int __PropertyOffset_15;

		// Token: 0x040136B5 RID: 79541
		internal static int __PropertyOffset_16;

		// Token: 0x040136B6 RID: 79542
		internal static int __PropertyOffset_17;

		// Token: 0x040136B7 RID: 79543
		internal static int __PropertyOffset_18;

		// Token: 0x040136B8 RID: 79544
		internal static int __PropertyOffset_19;

		// Token: 0x040136B9 RID: 79545
		internal static int __PropertyOffset_20;

		// Token: 0x040136BA RID: 79546
		internal static int __PropertyOffset_21;

		// Token: 0x040136BB RID: 79547
		internal static int __PropertyOffset_22;

		// Token: 0x040136BC RID: 79548
		internal static int __PropertyOffset_23;

		// Token: 0x040136BD RID: 79549
		internal static int __PropertyOffset_24;

		// Token: 0x040136BE RID: 79550
		private static IntPtr __InitializeRemotelySetMaterial_NativeFunctionPtr;

		// Token: 0x040136BF RID: 79551
		private static IntPtr __InitializeLocallySetMaterial_NativeFunctionPtr;

		// Token: 0x040136C0 RID: 79552
		private static IntPtr __Refresh_Lighting_NativeFunctionPtr;

		// Token: 0x040136C1 RID: 79553
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040136C2 RID: 79554
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040136C3 RID: 79555
		private static IntPtr __ExecuteUbergraph_VolumeSmokeComponent_NativeFunctionPtr;

		// Token: 0x02009F3D RID: 40765
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032A6E RID: 207470
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F3E RID: 40766
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 544)]
		protected ref struct __ExecuteUbergraph_VolumeSmokeComponent_FunctionParams
		{
			// Token: 0x04032A6F RID: 207471
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
