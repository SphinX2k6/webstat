using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroVolumeFog
{
	// Token: 0x02003BE5 RID: 15333
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroVolumeFog/BP_KuroVolumeFog.BP_KuroVolumeFog_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1216)]
	public class BP_KuroVolumeFog_C : AActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06022755 RID: 141141 RVA: 0x0096611F File Offset: 0x0096431F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroVolumeFog_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroVolumeFog/BP_KuroVolumeFog.BP_KuroVolumeFog_C");
			}
			return BP_KuroVolumeFog_C._ClassPtr;
		}

		// Token: 0x06022756 RID: 141142 RVA: 0x00966143 File Offset: 0x00964343
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_KuroVolumeFog_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x06022757 RID: 141143 RVA: 0x0096614C File Offset: 0x0096434C
		public BP_KuroVolumeFog_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeFog_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022758 RID: 141144 RVA: 0x00966174 File Offset: 0x00964374
		[NullableContext(1)]
		public BP_KuroVolumeFog_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeFog_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170040DD RID: 16605
		// (get) Token: 0x06022759 RID: 141145 RVA: 0x009661A8 File Offset: 0x009643A8
		// (set) Token: 0x0602275A RID: 141146 RVA: 0x009661E1 File Offset: 0x009643E1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170040DE RID: 16606
		// (get) Token: 0x0602275B RID: 141147 RVA: 0x00966202 File Offset: 0x00964402
		// (set) Token: 0x0602275C RID: 141148 RVA: 0x00966216 File Offset: 0x00964416
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170040DF RID: 16607
		// (get) Token: 0x0602275D RID: 141149 RVA: 0x0096622B File Offset: 0x0096442B
		// (set) Token: 0x0602275E RID: 141150 RVA: 0x0096623F File Offset: 0x0096443F
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170040E0 RID: 16608
		// (get) Token: 0x0602275F RID: 141151 RVA: 0x00966254 File Offset: 0x00964454
		// (set) Token: 0x06022760 RID: 141152 RVA: 0x00966268 File Offset: 0x00964468
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170040E1 RID: 16609
		// (get) Token: 0x06022761 RID: 141153 RVA: 0x0096627D File Offset: 0x0096447D
		// (set) Token: 0x06022762 RID: 141154 RVA: 0x00966291 File Offset: 0x00964491
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170040E2 RID: 16610
		// (get) Token: 0x06022763 RID: 141155 RVA: 0x009662A6 File Offset: 0x009644A6
		// (set) Token: 0x06022764 RID: 141156 RVA: 0x009662BA File Offset: 0x009644BA
		public unsafe UTextureRenderTarget2D OriginRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170040E3 RID: 16611
		// (get) Token: 0x06022765 RID: 141157 RVA: 0x009662CF File Offset: 0x009644CF
		// (set) Token: 0x06022766 RID: 141158 RVA: 0x009662E3 File Offset: 0x009644E3
		public unsafe UTexture HeightTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170040E4 RID: 16612
		// (get) Token: 0x06022767 RID: 141159 RVA: 0x009662F8 File Offset: 0x009644F8
		// (set) Token: 0x06022768 RID: 141160 RVA: 0x0096630C File Offset: 0x0096450C
		public unsafe UTextureRenderTarget2D NewRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170040E5 RID: 16613
		// (get) Token: 0x06022769 RID: 141161 RVA: 0x00966321 File Offset: 0x00964521
		// (set) Token: 0x0602276A RID: 141162 RVA: 0x00966331 File Offset: 0x00964531
		public unsafe float 颜色强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170040E6 RID: 16614
		// (get) Token: 0x0602276B RID: 141163 RVA: 0x00966342 File Offset: 0x00964542
		// (set) Token: 0x0602276C RID: 141164 RVA: 0x00966352 File Offset: 0x00964552
		public unsafe float 阴影强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170040E7 RID: 16615
		// (get) Token: 0x0602276D RID: 141165 RVA: 0x00966363 File Offset: 0x00964563
		// (set) Token: 0x0602276E RID: 141166 RVA: 0x00966373 File Offset: 0x00964573
		public unsafe float 偏移距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170040E8 RID: 16616
		// (get) Token: 0x0602276F RID: 141167 RVA: 0x00966384 File Offset: 0x00964584
		// (set) Token: 0x06022770 RID: 141168 RVA: 0x00966398 File Offset: 0x00964598
		public unsafe FLinearColor 偏色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170040E9 RID: 16617
		// (get) Token: 0x06022771 RID: 141169 RVA: 0x009663AD File Offset: 0x009645AD
		// (set) Token: 0x06022772 RID: 141170 RVA: 0x009663BD File Offset: 0x009645BD
		public unsafe float 最大坡度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170040EA RID: 16618
		// (get) Token: 0x06022773 RID: 141171 RVA: 0x009663CE File Offset: 0x009645CE
		// (set) Token: 0x06022774 RID: 141172 RVA: 0x009663DE File Offset: 0x009645DE
		public unsafe float 基础浓度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170040EB RID: 16619
		// (get) Token: 0x06022775 RID: 141173 RVA: 0x009663EF File Offset: 0x009645EF
		// (set) Token: 0x06022776 RID: 141174 RVA: 0x009663FF File Offset: 0x009645FF
		public unsafe float 浓度强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170040EC RID: 16620
		// (get) Token: 0x06022777 RID: 141175 RVA: 0x00966410 File Offset: 0x00964610
		// (set) Token: 0x06022778 RID: 141176 RVA: 0x00966420 File Offset: 0x00964620
		public unsafe float 流动速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170040ED RID: 16621
		// (get) Token: 0x06022779 RID: 141177 RVA: 0x00966431 File Offset: 0x00964631
		// (set) Token: 0x0602277A RID: 141178 RVA: 0x00966445 File Offset: 0x00964645
		public unsafe FVector 流动方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170040EE RID: 16622
		// (get) Token: 0x0602277B RID: 141179 RVA: 0x0096645A File Offset: 0x0096465A
		// (set) Token: 0x0602277C RID: 141180 RVA: 0x0096646A File Offset: 0x0096466A
		public unsafe float Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170040EF RID: 16623
		// (get) Token: 0x0602277D RID: 141181 RVA: 0x0096647B File Offset: 0x0096467B
		// (set) Token: 0x0602277E RID: 141182 RVA: 0x0096648B File Offset: 0x0096468B
		public unsafe float 底部暗度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170040F0 RID: 16624
		// (get) Token: 0x0602277F RID: 141183 RVA: 0x0096649C File Offset: 0x0096469C
		// (set) Token: 0x06022780 RID: 141184 RVA: 0x009664AC File Offset: 0x009646AC
		public unsafe float 雾气统一厚度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170040F1 RID: 16625
		// (get) Token: 0x06022781 RID: 141185 RVA: 0x009664BD File Offset: 0x009646BD
		// (set) Token: 0x06022782 RID: 141186 RVA: 0x009664CD File Offset: 0x009646CD
		public unsafe float 雾气噪波厚度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170040F2 RID: 16626
		// (get) Token: 0x06022783 RID: 141187 RVA: 0x009664DE File Offset: 0x009646DE
		// (set) Token: 0x06022784 RID: 141188 RVA: 0x009664EE File Offset: 0x009646EE
		public unsafe bool 双采样噪声
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040F3 RID: 16627
		// (get) Token: 0x06022785 RID: 141189 RVA: 0x009664FF File Offset: 0x009646FF
		// (set) Token: 0x06022786 RID: 141190 RVA: 0x0096650F File Offset: 0x0096470F
		public unsafe float 噪波UV平铺
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170040F4 RID: 16628
		// (get) Token: 0x06022787 RID: 141191 RVA: 0x00966520 File Offset: 0x00964720
		// (set) Token: 0x06022788 RID: 141192 RVA: 0x00966534 File Offset: 0x00964734
		public unsafe FLinearColor 噪波强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170040F5 RID: 16629
		// (get) Token: 0x06022789 RID: 141193 RVA: 0x00966549 File Offset: 0x00964749
		// (set) Token: 0x0602278A RID: 141194 RVA: 0x0096655D File Offset: 0x0096475D
		public unsafe UVolumeTexture 噪波贴图
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UVolumeTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeFog_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170040F6 RID: 16630
		// (get) Token: 0x0602278B RID: 141195 RVA: 0x00966572 File Offset: 0x00964772
		// (set) Token: 0x0602278C RID: 141196 RVA: 0x00966582 File Offset: 0x00964782
		public unsafe float 开始消隐的距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170040F7 RID: 16631
		// (get) Token: 0x0602278D RID: 141197 RVA: 0x00966593 File Offset: 0x00964793
		// (set) Token: 0x0602278E RID: 141198 RVA: 0x009665A3 File Offset: 0x009647A3
		public unsafe float 消隐的距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170040F8 RID: 16632
		// (get) Token: 0x0602278F RID: 141199 RVA: 0x009665B4 File Offset: 0x009647B4
		// (set) Token: 0x06022790 RID: 141200 RVA: 0x009665C4 File Offset: 0x009647C4
		public unsafe bool 技能交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040F9 RID: 16633
		// (get) Token: 0x06022791 RID: 141201 RVA: 0x009665D5 File Offset: 0x009647D5
		// (set) Token: 0x06022792 RID: 141202 RVA: 0x009665E5 File Offset: 0x009647E5
		public unsafe float 技能交互强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeFog_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x06022793 RID: 141203 RVA: 0x009665F8 File Offset: 0x009647F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_KuroVolumeFog_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroVolumeFog_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeFog_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeFog_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeFog_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06022794 RID: 141204 RVA: 0x00966640 File Offset: 0x00964840
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_KuroVolumeFog_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_KuroVolumeFog_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeFog_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeFog_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeFog_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06022795 RID: 141205 RVA: 0x00966686 File Offset: 0x00964886
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CaptureHeight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeFog_C.__CaptureHeight_NativeFunctionPtr, null);
		}

		// Token: 0x06022796 RID: 141206 RVA: 0x0096669A File Offset: 0x0096489A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeFog_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022797 RID: 141207 RVA: 0x009666AE File Offset: 0x009648AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeFog_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022798 RID: 141208 RVA: 0x009666C3 File Offset: 0x009648C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022799 RID: 141209 RVA: 0x009666D7 File Offset: 0x009648D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeFog_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602279A RID: 141210 RVA: 0x009666EC File Offset: 0x009648EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroVolumeFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602279B RID: 141211 RVA: 0x00966734 File Offset: 0x00964934
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroVolumeFog_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeFog_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeFog_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeFog_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602279C RID: 141212 RVA: 0x0096677C File Offset: 0x0096497C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroVolumeFog(int EntryPoint)
		{
			BP_KuroVolumeFog_C.__ExecuteUbergraph_BP_KuroVolumeFog_FunctionParams* ptr = stackalloc BP_KuroVolumeFog_C.__ExecuteUbergraph_BP_KuroVolumeFog_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_KuroVolumeFog_C.__ExecuteUbergraph_BP_KuroVolumeFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeFog_C.__ExecuteUbergraph_BP_KuroVolumeFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeFog_C.__ExecuteUbergraph_BP_KuroVolumeFog_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602279D RID: 141213 RVA: 0x009667C3 File Offset: 0x009649C3
		protected BP_KuroVolumeFog_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011725 RID: 71461
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x04011726 RID: 71462
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroVolumeFog/BP_KuroVolumeFog.BP_KuroVolumeFog_C";

		// Token: 0x04011727 RID: 71463
		private static IntPtr _ClassPtr;

		// Token: 0x04011728 RID: 71464
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011729 RID: 71465
		internal static int __PropertyOffset_0;

		// Token: 0x0401172A RID: 71466
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401172B RID: 71467
		internal static int __PropertyOffset_1;

		// Token: 0x0401172C RID: 71468
		internal static int __PropertyOffset_2;

		// Token: 0x0401172D RID: 71469
		internal static int __PropertyOffset_3;

		// Token: 0x0401172E RID: 71470
		internal static int __PropertyOffset_4;

		// Token: 0x0401172F RID: 71471
		internal static int __PropertyOffset_5;

		// Token: 0x04011730 RID: 71472
		internal static int __PropertyOffset_6;

		// Token: 0x04011731 RID: 71473
		internal static int __PropertyOffset_7;

		// Token: 0x04011732 RID: 71474
		internal static int __PropertyOffset_8;

		// Token: 0x04011733 RID: 71475
		internal static int __PropertyOffset_9;

		// Token: 0x04011734 RID: 71476
		internal static int __PropertyOffset_10;

		// Token: 0x04011735 RID: 71477
		internal static int __PropertyOffset_11;

		// Token: 0x04011736 RID: 71478
		internal static int __PropertyOffset_12;

		// Token: 0x04011737 RID: 71479
		internal static int __PropertyOffset_13;

		// Token: 0x04011738 RID: 71480
		internal static int __PropertyOffset_14;

		// Token: 0x04011739 RID: 71481
		internal static int __PropertyOffset_15;

		// Token: 0x0401173A RID: 71482
		internal static int __PropertyOffset_16;

		// Token: 0x0401173B RID: 71483
		internal static int __PropertyOffset_17;

		// Token: 0x0401173C RID: 71484
		internal static int __PropertyOffset_18;

		// Token: 0x0401173D RID: 71485
		internal static int __PropertyOffset_19;

		// Token: 0x0401173E RID: 71486
		internal static int __PropertyOffset_20;

		// Token: 0x0401173F RID: 71487
		internal static int __PropertyOffset_21;

		// Token: 0x04011740 RID: 71488
		internal static int __PropertyOffset_22;

		// Token: 0x04011741 RID: 71489
		internal static int __PropertyOffset_23;

		// Token: 0x04011742 RID: 71490
		internal static int __PropertyOffset_24;

		// Token: 0x04011743 RID: 71491
		internal static int __PropertyOffset_25;

		// Token: 0x04011744 RID: 71492
		internal static int __PropertyOffset_26;

		// Token: 0x04011745 RID: 71493
		internal static int __PropertyOffset_27;

		// Token: 0x04011746 RID: 71494
		internal static int __PropertyOffset_28;

		// Token: 0x04011747 RID: 71495
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x04011748 RID: 71496
		private static IntPtr __CaptureHeight_NativeFunctionPtr;

		// Token: 0x04011749 RID: 71497
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401174A RID: 71498
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401174B RID: 71499
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401174C RID: 71500
		private static IntPtr __ExecuteUbergraph_BP_KuroVolumeFog_NativeFunctionPtr;

		// Token: 0x02009BDF RID: 39903
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x0403242D RID: 205869
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009BE0 RID: 39904
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403242E RID: 205870
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BE1 RID: 39905
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_BP_KuroVolumeFog_FunctionParams
		{
			// Token: 0x0403242F RID: 205871
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
