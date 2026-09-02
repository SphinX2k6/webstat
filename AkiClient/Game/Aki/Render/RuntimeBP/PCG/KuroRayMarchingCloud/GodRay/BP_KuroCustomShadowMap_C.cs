using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.GodRay
{
	// Token: 0x02003BF1 RID: 15345
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroCustomShadowMap.BP_KuroCustomShadowMap_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1538)]
	public class BP_KuroCustomShadowMap_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022A21 RID: 141857 RVA: 0x0096A620 File Offset: 0x00968820
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCustomShadowMap_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroCustomShadowMap.BP_KuroCustomShadowMap_C");
			}
			return BP_KuroCustomShadowMap_C._ClassPtr;
		}

		// Token: 0x06022A22 RID: 141858 RVA: 0x0096A644 File Offset: 0x00968844
		public BP_KuroCustomShadowMap_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCustomShadowMap_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022A23 RID: 141859 RVA: 0x0096A66C File Offset: 0x0096886C
		[NullableContext(1)]
		public BP_KuroCustomShadowMap_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCustomShadowMap_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170041EC RID: 16876
		// (get) Token: 0x06022A24 RID: 141860 RVA: 0x0096A6A0 File Offset: 0x009688A0
		// (set) Token: 0x06022A25 RID: 141861 RVA: 0x0096A6D9 File Offset: 0x009688D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170041ED RID: 16877
		// (get) Token: 0x06022A26 RID: 141862 RVA: 0x0096A6FA File Offset: 0x009688FA
		// (set) Token: 0x06022A27 RID: 141863 RVA: 0x0096A70E File Offset: 0x0096890E
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170041EE RID: 16878
		// (get) Token: 0x06022A28 RID: 141864 RVA: 0x0096A723 File Offset: 0x00968923
		// (set) Token: 0x06022A29 RID: 141865 RVA: 0x0096A737 File Offset: 0x00968937
		public unsafe USceneComponent RangeRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170041EF RID: 16879
		// (get) Token: 0x06022A2A RID: 141866 RVA: 0x0096A74C File Offset: 0x0096894C
		// (set) Token: 0x06022A2B RID: 141867 RVA: 0x0096A760 File Offset: 0x00968960
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170041F0 RID: 16880
		// (get) Token: 0x06022A2C RID: 141868 RVA: 0x0096A775 File Offset: 0x00968975
		// (set) Token: 0x06022A2D RID: 141869 RVA: 0x0096A789 File Offset: 0x00968989
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170041F1 RID: 16881
		// (get) Token: 0x06022A2E RID: 141870 RVA: 0x0096A7A0 File Offset: 0x009689A0
		// (set) Token: 0x06022A2F RID: 141871 RVA: 0x0096A7D9 File Offset: 0x009689D9
		[Nullable(1)]
		public TSet<AActor> ActorList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TSet<AActor> result;
				if ((result = this._ActorList) == null)
				{
					result = (this._ActorList = new TSet<AActor>(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ActorList.CopyAssign(value);
			}
		}

		// Token: 0x170041F2 RID: 16882
		// (get) Token: 0x06022A30 RID: 141872 RVA: 0x0096A7E7 File Offset: 0x009689E7
		// (set) Token: 0x06022A31 RID: 141873 RVA: 0x0096A7F7 File Offset: 0x009689F7
		public unsafe int X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170041F3 RID: 16883
		// (get) Token: 0x06022A32 RID: 141874 RVA: 0x0096A808 File Offset: 0x00968A08
		// (set) Token: 0x06022A33 RID: 141875 RVA: 0x0096A818 File Offset: 0x00968A18
		public unsafe int Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170041F4 RID: 16884
		// (get) Token: 0x06022A34 RID: 141876 RVA: 0x0096A829 File Offset: 0x00968A29
		// (set) Token: 0x06022A35 RID: 141877 RVA: 0x0096A839 File Offset: 0x00968A39
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170041F5 RID: 16885
		// (get) Token: 0x06022A36 RID: 141878 RVA: 0x0096A84A File Offset: 0x00968A4A
		// (set) Token: 0x06022A37 RID: 141879 RVA: 0x0096A85A File Offset: 0x00968A5A
		public unsafe float Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170041F6 RID: 16886
		// (get) Token: 0x06022A38 RID: 141880 RVA: 0x0096A86B File Offset: 0x00968A6B
		// (set) Token: 0x06022A39 RID: 141881 RVA: 0x0096A87B File Offset: 0x00968A7B
		public unsafe float Far_Plane
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170041F7 RID: 16887
		// (get) Token: 0x06022A3A RID: 141882 RVA: 0x0096A88C File Offset: 0x00968A8C
		// (set) Token: 0x06022A3B RID: 141883 RVA: 0x0096A8A0 File Offset: 0x00968AA0
		public unsafe UTextureRenderTarget2D RenderTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170041F8 RID: 16888
		// (get) Token: 0x06022A3C RID: 141884 RVA: 0x0096A8B8 File Offset: 0x00968AB8
		// (set) Token: 0x06022A3D RID: 141885 RVA: 0x0096A8F1 File Offset: 0x00968AF1
		[Nullable(1)]
		public TArray<AStaticMeshActor> VolumeLightMesh
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._VolumeLightMesh) == null)
				{
					result = (this._VolumeLightMesh = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.VolumeLightMesh.CopyAssign(value);
			}
		}

		// Token: 0x170041F9 RID: 16889
		// (get) Token: 0x06022A3E RID: 141886 RVA: 0x0096A8FF File Offset: 0x00968AFF
		// (set) Token: 0x06022A3F RID: 141887 RVA: 0x0096A913 File Offset: 0x00968B13
		public unsafe UMaterialInstance SourceMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170041FA RID: 16890
		// (get) Token: 0x06022A40 RID: 141888 RVA: 0x0096A928 File Offset: 0x00968B28
		// (set) Token: 0x06022A41 RID: 141889 RVA: 0x0096A93C File Offset: 0x00968B3C
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170041FB RID: 16891
		// (get) Token: 0x06022A42 RID: 141890 RVA: 0x0096A951 File Offset: 0x00968B51
		// (set) Token: 0x06022A43 RID: 141891 RVA: 0x0096A965 File Offset: 0x00968B65
		public unsafe UTexture2D StaticShadowMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170041FC RID: 16892
		// (get) Token: 0x06022A44 RID: 141892 RVA: 0x0096A97A File Offset: 0x00968B7A
		// (set) Token: 0x06022A45 RID: 141893 RVA: 0x0096A98E File Offset: 0x00968B8E
		public unsafe UTextureRenderTarget2D RenderTargetPost
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170041FD RID: 16893
		// (get) Token: 0x06022A46 RID: 141894 RVA: 0x0096A9A3 File Offset: 0x00968BA3
		// (set) Token: 0x06022A47 RID: 141895 RVA: 0x0096A9B7 File Offset: 0x00968BB7
		public unsafe UMaterialInterface PostMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170041FE RID: 16894
		// (get) Token: 0x06022A48 RID: 141896 RVA: 0x0096A9CC File Offset: 0x00968BCC
		// (set) Token: 0x06022A49 RID: 141897 RVA: 0x0096A9E0 File Offset: 0x00968BE0
		public unsafe UMaterialInstanceDynamic PostMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCustomShadowMap_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170041FF RID: 16895
		// (get) Token: 0x06022A4A RID: 141898 RVA: 0x0096A9F5 File Offset: 0x00968BF5
		// (set) Token: 0x06022A4B RID: 141899 RVA: 0x0096AA05 File Offset: 0x00968C05
		public unsafe bool bUseMPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004200 RID: 16896
		// (get) Token: 0x06022A4C RID: 141900 RVA: 0x0096AA16 File Offset: 0x00968C16
		// (set) Token: 0x06022A4D RID: 141901 RVA: 0x0096AA26 File Offset: 0x00968C26
		public unsafe bool bVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCustomShadowMap_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022A4E RID: 141902 RVA: 0x0096AA38 File Offset: 0x00968C38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVolumeMeshVisibility(bool bNewVisibility)
		{
			BP_KuroCustomShadowMap_C.__SetVolumeMeshVisibility_FunctionParams* ptr = stackalloc BP_KuroCustomShadowMap_C.__SetVolumeMeshVisibility_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroCustomShadowMap_C.__SetVolumeMeshVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCustomShadowMap_C.__SetVolumeMeshVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bNewVisibility = bNewVisibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__SetVolumeMeshVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022A4F RID: 141903 RVA: 0x0096AA7E File Offset: 0x00968C7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PostProcessShadowTex()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__PostProcessShadowTex_NativeFunctionPtr, null);
		}

		// Token: 0x06022A50 RID: 141904 RVA: 0x0096AA92 File Offset: 0x00968C92
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__UpdateMat_NativeFunctionPtr, null);
		}

		// Token: 0x06022A51 RID: 141905 RVA: 0x0096AAA6 File Offset: 0x00968CA6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Render()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__Render_NativeFunctionPtr, null);
		}

		// Token: 0x06022A52 RID: 141906 RVA: 0x0096AABA File Offset: 0x00968CBA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022A53 RID: 141907 RVA: 0x0096AACE File Offset: 0x00968CCE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A54 RID: 141908 RVA: 0x0096AAE3 File Offset: 0x00968CE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022A55 RID: 141909 RVA: 0x0096AAF7 File Offset: 0x00968CF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022A56 RID: 141910 RVA: 0x0096AB0C File Offset: 0x00968D0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCustomShadowMap_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCustomShadowMap_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCustomShadowMap_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCustomShadowMap_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022A57 RID: 141911 RVA: 0x0096AB54 File Offset: 0x00968D54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCustomShadowMap_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCustomShadowMap_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCustomShadowMap_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCustomShadowMap_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022A58 RID: 141912 RVA: 0x0096AB9C File Offset: 0x00968D9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_KuroCustomShadowMap_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroCustomShadowMap_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCustomShadowMap_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCustomShadowMap_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022A59 RID: 141913 RVA: 0x0096ABE4 File Offset: 0x00968DE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCustomShadowMap_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroCustomShadowMap_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCustomShadowMap_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCustomShadowMap_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022A5A RID: 141914 RVA: 0x0096AC2C File Offset: 0x00968E2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCustomShadowMap(int EntryPoint)
		{
			BP_KuroCustomShadowMap_C.__ExecuteUbergraph_BP_KuroCustomShadowMap_FunctionParams* ptr = stackalloc BP_KuroCustomShadowMap_C.__ExecuteUbergraph_BP_KuroCustomShadowMap_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_KuroCustomShadowMap_C.__ExecuteUbergraph_BP_KuroCustomShadowMap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCustomShadowMap_C.__ExecuteUbergraph_BP_KuroCustomShadowMap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCustomShadowMap_C.__ExecuteUbergraph_BP_KuroCustomShadowMap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022A5B RID: 141915 RVA: 0x0096AC73 File Offset: 0x00968E73
		protected BP_KuroCustomShadowMap_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040118C3 RID: 71875
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroCustomShadowMap.BP_KuroCustomShadowMap_C";

		// Token: 0x040118C4 RID: 71876
		private static IntPtr _ClassPtr;

		// Token: 0x040118C5 RID: 71877
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040118C6 RID: 71878
		internal static int __PropertyOffset_0;

		// Token: 0x040118C7 RID: 71879
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040118C8 RID: 71880
		internal static int __PropertyOffset_1;

		// Token: 0x040118C9 RID: 71881
		internal static int __PropertyOffset_2;

		// Token: 0x040118CA RID: 71882
		internal static int __PropertyOffset_3;

		// Token: 0x040118CB RID: 71883
		internal static int __PropertyOffset_4;

		// Token: 0x040118CC RID: 71884
		internal static int __PropertyOffset_5;

		// Token: 0x040118CD RID: 71885
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<AActor> _ActorList;

		// Token: 0x040118CE RID: 71886
		internal static int __PropertyOffset_6;

		// Token: 0x040118CF RID: 71887
		internal static int __PropertyOffset_7;

		// Token: 0x040118D0 RID: 71888
		internal static int __PropertyOffset_8;

		// Token: 0x040118D1 RID: 71889
		internal static int __PropertyOffset_9;

		// Token: 0x040118D2 RID: 71890
		internal static int __PropertyOffset_10;

		// Token: 0x040118D3 RID: 71891
		internal static int __PropertyOffset_11;

		// Token: 0x040118D4 RID: 71892
		internal static int __PropertyOffset_12;

		// Token: 0x040118D5 RID: 71893
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _VolumeLightMesh;

		// Token: 0x040118D6 RID: 71894
		internal static int __PropertyOffset_13;

		// Token: 0x040118D7 RID: 71895
		internal static int __PropertyOffset_14;

		// Token: 0x040118D8 RID: 71896
		internal static int __PropertyOffset_15;

		// Token: 0x040118D9 RID: 71897
		internal static int __PropertyOffset_16;

		// Token: 0x040118DA RID: 71898
		internal static int __PropertyOffset_17;

		// Token: 0x040118DB RID: 71899
		internal static int __PropertyOffset_18;

		// Token: 0x040118DC RID: 71900
		internal static int __PropertyOffset_19;

		// Token: 0x040118DD RID: 71901
		internal static int __PropertyOffset_20;

		// Token: 0x040118DE RID: 71902
		private static IntPtr __SetVolumeMeshVisibility_NativeFunctionPtr;

		// Token: 0x040118DF RID: 71903
		private static IntPtr __PostProcessShadowTex_NativeFunctionPtr;

		// Token: 0x040118E0 RID: 71904
		private static IntPtr __UpdateMat_NativeFunctionPtr;

		// Token: 0x040118E1 RID: 71905
		private static IntPtr __Render_NativeFunctionPtr;

		// Token: 0x040118E2 RID: 71906
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040118E3 RID: 71907
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040118E4 RID: 71908
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040118E5 RID: 71909
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040118E6 RID: 71910
		private static IntPtr __ExecuteUbergraph_BP_KuroCustomShadowMap_NativeFunctionPtr;

		// Token: 0x02009BFE RID: 39934
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetVolumeMeshVisibility_FunctionParams
		{
			// Token: 0x04032458 RID: 205912
			[FieldOffset(0)]
			public bool bNewVisibility;
		}

		// Token: 0x02009BFF RID: 39935
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032459 RID: 205913
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C00 RID: 39936
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403245A RID: 205914
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C01 RID: 39937
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_KuroCustomShadowMap_FunctionParams
		{
			// Token: 0x0403245B RID: 205915
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
