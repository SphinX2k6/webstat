using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterSim.BP
{
	// Token: 0x02003B52 RID: 15186
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation.BP_WaterSimulation_C")]
	[UnrealStructLayout(1712, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1704)]
	public class BP_WaterSimulation_C : AKuroBPActor, IUnrealUObject, IUnrealObject, INiagaraParticleCallbackHandler, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602114E RID: 135502 RVA: 0x0093F3EF File Offset: 0x0093D5EF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterSimulation_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation.BP_WaterSimulation_C");
			}
			return BP_WaterSimulation_C._ClassPtr;
		}

		// Token: 0x0602114F RID: 135503 RVA: 0x0093F413 File Offset: 0x0093D613
		int INiagaraParticleCallbackHandler.InterfaceOffset()
		{
			return BP_WaterSimulation_C.__InterfaceOffset_INiagaraParticleCallbackHandler;
		}

		// Token: 0x06021150 RID: 135504 RVA: 0x0093F41C File Offset: 0x0093D61C
		public BP_WaterSimulation_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021151 RID: 135505 RVA: 0x0093F444 File Offset: 0x0093D644
		[NullableContext(1)]
		public BP_WaterSimulation_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003904 RID: 14596
		// (get) Token: 0x06021152 RID: 135506 RVA: 0x0093F478 File Offset: 0x0093D678
		// (set) Token: 0x06021153 RID: 135507 RVA: 0x0093F4B1 File Offset: 0x0093D6B1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003905 RID: 14597
		// (get) Token: 0x06021154 RID: 135508 RVA: 0x0093F4D2 File Offset: 0x0093D6D2
		// (set) Token: 0x06021155 RID: 135509 RVA: 0x0093F4E6 File Offset: 0x0093D6E6
		public unsafe UBoxComponent WaterInteraction_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003906 RID: 14598
		// (get) Token: 0x06021156 RID: 135510 RVA: 0x0093F4FB File Offset: 0x0093D6FB
		// (set) Token: 0x06021157 RID: 135511 RVA: 0x0093F50F File Offset: 0x0093D70F
		public unsafe UStaticMeshComponent WaterInteractionCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003907 RID: 14599
		// (get) Token: 0x06021158 RID: 135512 RVA: 0x0093F524 File Offset: 0x0093D724
		// (set) Token: 0x06021159 RID: 135513 RVA: 0x0093F538 File Offset: 0x0093D738
		public unsafe UStaticMeshComponent WaterSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003908 RID: 14600
		// (get) Token: 0x0602115A RID: 135514 RVA: 0x0093F54D File Offset: 0x0093D74D
		// (set) Token: 0x0602115B RID: 135515 RVA: 0x0093F561 File Offset: 0x0093D761
		public unsafe UStaticMeshComponent PreView_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003909 RID: 14601
		// (get) Token: 0x0602115C RID: 135516 RVA: 0x0093F576 File Offset: 0x0093D776
		// (set) Token: 0x0602115D RID: 135517 RVA: 0x0093F58A File Offset: 0x0093D78A
		public unsafe UBoxComponent Sim_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700390A RID: 14602
		// (get) Token: 0x0602115E RID: 135518 RVA: 0x0093F59F File Offset: 0x0093D79F
		// (set) Token: 0x0602115F RID: 135519 RVA: 0x0093F5B3 File Offset: 0x0093D7B3
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700390B RID: 14603
		// (get) Token: 0x06021160 RID: 135520 RVA: 0x0093F5C8 File Offset: 0x0093D7C8
		// (set) Token: 0x06021161 RID: 135521 RVA: 0x0093F5D8 File Offset: 0x0093D7D8
		public unsafe bool Sim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700390C RID: 14604
		// (get) Token: 0x06021162 RID: 135522 RVA: 0x0093F5E9 File Offset: 0x0093D7E9
		// (set) Token: 0x06021163 RID: 135523 RVA: 0x0093F5F9 File Offset: 0x0093D7F9
		public unsafe bool SeqControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700390D RID: 14605
		// (get) Token: 0x06021164 RID: 135524 RVA: 0x0093F60A File Offset: 0x0093D80A
		// (set) Token: 0x06021165 RID: 135525 RVA: 0x0093F61A File Offset: 0x0093D81A
		public unsafe bool DAControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700390E RID: 14606
		// (get) Token: 0x06021166 RID: 135526 RVA: 0x0093F62B File Offset: 0x0093D82B
		// (set) Token: 0x06021167 RID: 135527 RVA: 0x0093F63F File Offset: 0x0093D83F
		public unsafe FVector SimBoxOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700390F RID: 14607
		// (get) Token: 0x06021168 RID: 135528 RVA: 0x0093F654 File Offset: 0x0093D854
		// (set) Token: 0x06021169 RID: 135529 RVA: 0x0093F668 File Offset: 0x0093D868
		public unsafe FVector SimBoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003910 RID: 14608
		// (get) Token: 0x0602116A RID: 135530 RVA: 0x0093F67D File Offset: 0x0093D87D
		// (set) Token: 0x0602116B RID: 135531 RVA: 0x0093F68D File Offset: 0x0093D88D
		public unsafe int SimSize_M_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003911 RID: 14609
		// (get) Token: 0x0602116C RID: 135532 RVA: 0x0093F69E File Offset: 0x0093D89E
		// (set) Token: 0x0602116D RID: 135533 RVA: 0x0093F6B2 File Offset: 0x0093D8B2
		public unsafe UMaterial M_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003912 RID: 14610
		// (get) Token: 0x0602116E RID: 135534 RVA: 0x0093F6C7 File Offset: 0x0093D8C7
		// (set) Token: 0x0602116F RID: 135535 RVA: 0x0093F6DB File Offset: 0x0093D8DB
		public unsafe UMaterial M_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003913 RID: 14611
		// (get) Token: 0x06021170 RID: 135536 RVA: 0x0093F6F0 File Offset: 0x0093D8F0
		// (set) Token: 0x06021171 RID: 135537 RVA: 0x0093F704 File Offset: 0x0093D904
		public unsafe UMaterial M_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003914 RID: 14612
		// (get) Token: 0x06021172 RID: 135538 RVA: 0x0093F719 File Offset: 0x0093D919
		// (set) Token: 0x06021173 RID: 135539 RVA: 0x0093F72D File Offset: 0x0093D92D
		public unsafe UMaterial M_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003915 RID: 14613
		// (get) Token: 0x06021174 RID: 135540 RVA: 0x0093F742 File Offset: 0x0093D942
		// (set) Token: 0x06021175 RID: 135541 RVA: 0x0093F756 File Offset: 0x0093D956
		public unsafe UMaterial M_Water_Clear
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003916 RID: 14614
		// (get) Token: 0x06021176 RID: 135542 RVA: 0x0093F76B File Offset: 0x0093D96B
		// (set) Token: 0x06021177 RID: 135543 RVA: 0x0093F77F File Offset: 0x0093D97F
		public unsafe UMaterialInstanceDynamic MI_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003917 RID: 14615
		// (get) Token: 0x06021178 RID: 135544 RVA: 0x0093F794 File Offset: 0x0093D994
		// (set) Token: 0x06021179 RID: 135545 RVA: 0x0093F7A8 File Offset: 0x0093D9A8
		public unsafe UMaterialInstanceDynamic MI_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003918 RID: 14616
		// (get) Token: 0x0602117A RID: 135546 RVA: 0x0093F7BD File Offset: 0x0093D9BD
		// (set) Token: 0x0602117B RID: 135547 RVA: 0x0093F7D1 File Offset: 0x0093D9D1
		public unsafe UMaterialInstanceDynamic MI_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003919 RID: 14617
		// (get) Token: 0x0602117C RID: 135548 RVA: 0x0093F7E6 File Offset: 0x0093D9E6
		// (set) Token: 0x0602117D RID: 135549 RVA: 0x0093F7FA File Offset: 0x0093D9FA
		public unsafe UMaterialInstanceDynamic MI_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x1700391A RID: 14618
		// (get) Token: 0x0602117E RID: 135550 RVA: 0x0093F80F File Offset: 0x0093DA0F
		// (set) Token: 0x0602117F RID: 135551 RVA: 0x0093F823 File Offset: 0x0093DA23
		public unsafe UTexture2D RT_HeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x1700391B RID: 14619
		// (get) Token: 0x06021180 RID: 135552 RVA: 0x0093F838 File Offset: 0x0093DA38
		// (set) Token: 0x06021181 RID: 135553 RVA: 0x0093F84C File Offset: 0x0093DA4C
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x1700391C RID: 14620
		// (get) Token: 0x06021182 RID: 135554 RVA: 0x0093F861 File Offset: 0x0093DA61
		// (set) Token: 0x06021183 RID: 135555 RVA: 0x0093F875 File Offset: 0x0093DA75
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Temp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x1700391D RID: 14621
		// (get) Token: 0x06021184 RID: 135556 RVA: 0x0093F88A File Offset: 0x0093DA8A
		// (set) Token: 0x06021185 RID: 135557 RVA: 0x0093F89E File Offset: 0x0093DA9E
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x1700391E RID: 14622
		// (get) Token: 0x06021186 RID: 135558 RVA: 0x0093F8B3 File Offset: 0x0093DAB3
		// (set) Token: 0x06021187 RID: 135559 RVA: 0x0093F8C7 File Offset: 0x0093DAC7
		public unsafe AStaticMeshActor RenderActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x1700391F RID: 14623
		// (get) Token: 0x06021188 RID: 135560 RVA: 0x0093F8DC File Offset: 0x0093DADC
		// (set) Token: 0x06021189 RID: 135561 RVA: 0x0093F8F0 File Offset: 0x0093DAF0
		public unsafe UMaterialInterface M_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003920 RID: 14624
		// (get) Token: 0x0602118A RID: 135562 RVA: 0x0093F905 File Offset: 0x0093DB05
		// (set) Token: 0x0602118B RID: 135563 RVA: 0x0093F919 File Offset: 0x0093DB19
		public unsafe UMaterialInstanceDynamic MI_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003921 RID: 14625
		// (get) Token: 0x0602118C RID: 135564 RVA: 0x0093F92E File Offset: 0x0093DB2E
		// (set) Token: 0x0602118D RID: 135565 RVA: 0x0093F93E File Offset: 0x0093DB3E
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003922 RID: 14626
		// (get) Token: 0x0602118E RID: 135566 RVA: 0x0093F94F File Offset: 0x0093DB4F
		// (set) Token: 0x0602118F RID: 135567 RVA: 0x0093F95F File Offset: 0x0093DB5F
		public unsafe float DurationTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17003923 RID: 14627
		// (get) Token: 0x06021190 RID: 135568 RVA: 0x0093F970 File Offset: 0x0093DB70
		// (set) Token: 0x06021191 RID: 135569 RVA: 0x0093F984 File Offset: 0x0093DB84
		public unsafe FLinearColor WaterSuorcePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17003924 RID: 14628
		// (get) Token: 0x06021192 RID: 135570 RVA: 0x0093F999 File Offset: 0x0093DB99
		// (set) Token: 0x06021193 RID: 135571 RVA: 0x0093F9AD File Offset: 0x0093DBAD
		public unsafe FLinearColor WaterSuorcePos1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17003925 RID: 14629
		// (get) Token: 0x06021194 RID: 135572 RVA: 0x0093F9C2 File Offset: 0x0093DBC2
		// (set) Token: 0x06021195 RID: 135573 RVA: 0x0093F9D2 File Offset: 0x0093DBD2
		public unsafe float WaterActorHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17003926 RID: 14630
		// (get) Token: 0x06021196 RID: 135574 RVA: 0x0093F9E3 File Offset: 0x0093DBE3
		// (set) Token: 0x06021197 RID: 135575 RVA: 0x0093F9F3 File Offset: 0x0093DBF3
		public unsafe float PlayerWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17003927 RID: 14631
		// (get) Token: 0x06021198 RID: 135576 RVA: 0x0093FA04 File Offset: 0x0093DC04
		// (set) Token: 0x06021199 RID: 135577 RVA: 0x0093FA14 File Offset: 0x0093DC14
		public unsafe float CameraWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17003928 RID: 14632
		// (get) Token: 0x0602119A RID: 135578 RVA: 0x0093FA25 File Offset: 0x0093DC25
		// (set) Token: 0x0602119B RID: 135579 RVA: 0x0093FA39 File Offset: 0x0093DC39
		public unsafe FVector PlayerWaterNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003929 RID: 14633
		// (get) Token: 0x0602119C RID: 135580 RVA: 0x0093FA4E File Offset: 0x0093DC4E
		// (set) Token: 0x0602119D RID: 135581 RVA: 0x0093FA5E File Offset: 0x0093DC5E
		public unsafe float PlayerWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x1700392A RID: 14634
		// (get) Token: 0x0602119E RID: 135582 RVA: 0x0093FA6F File Offset: 0x0093DC6F
		// (set) Token: 0x0602119F RID: 135583 RVA: 0x0093FA7F File Offset: 0x0093DC7F
		public unsafe float CameraWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x1700392B RID: 14635
		// (get) Token: 0x060211A0 RID: 135584 RVA: 0x0093FA90 File Offset: 0x0093DC90
		// (set) Token: 0x060211A1 RID: 135585 RVA: 0x0093FAA4 File Offset: 0x0093DCA4
		public unsafe FVector CameraWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x1700392C RID: 14636
		// (get) Token: 0x060211A2 RID: 135586 RVA: 0x0093FAB9 File Offset: 0x0093DCB9
		// (set) Token: 0x060211A3 RID: 135587 RVA: 0x0093FACD File Offset: 0x0093DCCD
		public unsafe FVector PlayerWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x1700392D RID: 14637
		// (get) Token: 0x060211A4 RID: 135588 RVA: 0x0093FAE2 File Offset: 0x0093DCE2
		// (set) Token: 0x060211A5 RID: 135589 RVA: 0x0093FAF2 File Offset: 0x0093DCF2
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700392E RID: 14638
		// (get) Token: 0x060211A6 RID: 135590 RVA: 0x0093FB03 File Offset: 0x0093DD03
		// (set) Token: 0x060211A7 RID: 135591 RVA: 0x0093FB13 File Offset: 0x0093DD13
		public unsafe float AccelerationClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700392F RID: 14639
		// (get) Token: 0x060211A8 RID: 135592 RVA: 0x0093FB24 File Offset: 0x0093DD24
		// (set) Token: 0x060211A9 RID: 135593 RVA: 0x0093FB34 File Offset: 0x0093DD34
		public unsafe float Friction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17003930 RID: 14640
		// (get) Token: 0x060211AA RID: 135594 RVA: 0x0093FB45 File Offset: 0x0093DD45
		// (set) Token: 0x060211AB RID: 135595 RVA: 0x0093FB55 File Offset: 0x0093DD55
		public unsafe float Damping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17003931 RID: 14641
		// (get) Token: 0x060211AC RID: 135596 RVA: 0x0093FB66 File Offset: 0x0093DD66
		// (set) Token: 0x060211AD RID: 135597 RVA: 0x0093FB76 File Offset: 0x0093DD76
		public unsafe float VelocityClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17003932 RID: 14642
		// (get) Token: 0x060211AE RID: 135598 RVA: 0x0093FB87 File Offset: 0x0093DD87
		// (set) Token: 0x060211AF RID: 135599 RVA: 0x0093FB97 File Offset: 0x0093DD97
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17003933 RID: 14643
		// (get) Token: 0x060211B0 RID: 135600 RVA: 0x0093FBA8 File Offset: 0x0093DDA8
		// (set) Token: 0x060211B1 RID: 135601 RVA: 0x0093FBB8 File Offset: 0x0093DDB8
		public unsafe int LoopNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17003934 RID: 14644
		// (get) Token: 0x060211B2 RID: 135602 RVA: 0x0093FBC9 File Offset: 0x0093DDC9
		// (set) Token: 0x060211B3 RID: 135603 RVA: 0x0093FBDD File Offset: 0x0093DDDD
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x17003935 RID: 14645
		// (get) Token: 0x060211B4 RID: 135604 RVA: 0x0093FBF2 File Offset: 0x0093DDF2
		// (set) Token: 0x060211B5 RID: 135605 RVA: 0x0093FC06 File Offset: 0x0093DE06
		public unsafe BP_HeightmapReadback_C BP_HeightmapReadback
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_HeightmapReadback_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x17003936 RID: 14646
		// (get) Token: 0x060211B6 RID: 135606 RVA: 0x0093FC1B File Offset: 0x0093DE1B
		// (set) Token: 0x060211B7 RID: 135607 RVA: 0x0093FC2B File Offset: 0x0093DE2B
		public unsafe int Readback_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17003937 RID: 14647
		// (get) Token: 0x060211B8 RID: 135608 RVA: 0x0093FC3C File Offset: 0x0093DE3C
		// (set) Token: 0x060211B9 RID: 135609 RVA: 0x0093FC4C File Offset: 0x0093DE4C
		public unsafe int Readback_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17003938 RID: 14648
		// (get) Token: 0x060211BA RID: 135610 RVA: 0x0093FC5D File Offset: 0x0093DE5D
		// (set) Token: 0x060211BB RID: 135611 RVA: 0x0093FC6D File Offset: 0x0093DE6D
		public unsafe float Readback_Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17003939 RID: 14649
		// (get) Token: 0x060211BC RID: 135612 RVA: 0x0093FC7E File Offset: 0x0093DE7E
		// (set) Token: 0x060211BD RID: 135613 RVA: 0x0093FC92 File Offset: 0x0093DE92
		public unsafe FVector4 CaptureRangeMax_Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x1700393A RID: 14650
		// (get) Token: 0x060211BE RID: 135614 RVA: 0x0093FCA7 File Offset: 0x0093DEA7
		// (set) Token: 0x060211BF RID: 135615 RVA: 0x0093FCB7 File Offset: 0x0093DEB7
		public unsafe bool DynamicWaterFlow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700393B RID: 14651
		// (get) Token: 0x060211C0 RID: 135616 RVA: 0x0093FCC8 File Offset: 0x0093DEC8
		// (set) Token: 0x060211C1 RID: 135617 RVA: 0x0093FCD8 File Offset: 0x0093DED8
		public unsafe bool OverlapVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700393C RID: 14652
		// (get) Token: 0x060211C2 RID: 135618 RVA: 0x0093FCE9 File Offset: 0x0093DEE9
		// (set) Token: 0x060211C3 RID: 135619 RVA: 0x0093FCF9 File Offset: 0x0093DEF9
		public unsafe bool Is_Simulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700393D RID: 14653
		// (get) Token: 0x060211C4 RID: 135620 RVA: 0x0093FD0A File Offset: 0x0093DF0A
		// (set) Token: 0x060211C5 RID: 135621 RVA: 0x0093FD1A File Offset: 0x0093DF1A
		public unsafe float CameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x060211C6 RID: 135622 RVA: 0x0093FD2C File Offset: 0x0093DF2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HideRenderWaterMesh(bool HideRenderWater)
		{
			BP_WaterSimulation_C.__HideRenderWaterMesh_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__HideRenderWaterMesh_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WaterSimulation_C.__HideRenderWaterMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HideRenderWater = HideRenderWater;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060211C7 RID: 135623 RVA: 0x0093FD72 File Offset: 0x0093DF72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalcHeightmap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__CalcHeightmap_NativeFunctionPtr, null);
		}

		// Token: 0x060211C8 RID: 135624 RVA: 0x0093FD86 File Offset: 0x0093DF86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMPCParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__SetMPCParameters_NativeFunctionPtr, null);
		}

		// Token: 0x060211C9 RID: 135625 RVA: 0x0093FD9A File Offset: 0x0093DF9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x060211CA RID: 135626 RVA: 0x0093FDAE File Offset: 0x0093DFAE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x060211CB RID: 135627 RVA: 0x0093FDC2 File Offset: 0x0093DFC2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearWater()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__ClearWater_NativeFunctionPtr, null);
		}

		// Token: 0x060211CC RID: 135628 RVA: 0x0093FDD8 File Offset: 0x0093DFD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialParameter(UMaterialInterface Material, UTexture VelocityHeightFoam, ref UMaterialInstanceDynamic MaterialInstance)
		{
			BP_WaterSimulation_C.__SetMaterialParameter_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__SetMaterialParameter_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_WaterSimulation_C.__SetMaterialParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ptr->VelocityHeightFoam = ((VelocityHeightFoam != null) ? VelocityHeightFoam.NativePtr : IntPtr.Zero);
			ref BP_WaterSimulation_C.__SetMaterialParameter_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = MaterialInstance;
			ptr2.MaterialInstance = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr);
			MaterialInstance = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->MaterialInstance);
		}

		// Token: 0x060211CD RID: 135629 RVA: 0x0093FE68 File Offset: 0x0093E068
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060211CE RID: 135630 RVA: 0x0093FE7C File Offset: 0x0093E07C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060211CF RID: 135631 RVA: 0x0093FE94 File Offset: 0x0093E094
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReceiveParticleData([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060211D0 RID: 135632 RVA: 0x0093FF24 File Offset: 0x0093E124
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveParticleData_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060211D1 RID: 135633 RVA: 0x0093FFB3 File Offset: 0x0093E1B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060211D2 RID: 135634 RVA: 0x0093FFC7 File Offset: 0x0093E1C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060211D3 RID: 135635 RVA: 0x0093FFDC File Offset: 0x0093E1DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterSimulation_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060211D4 RID: 135636 RVA: 0x00940024 File Offset: 0x0093E224
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterSimulation_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060211D5 RID: 135637 RVA: 0x0094006B File Offset: 0x0093E26B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060211D6 RID: 135638 RVA: 0x00940080 File Offset: 0x0093E280
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060211D7 RID: 135639 RVA: 0x0094013C File Offset: 0x0093E33C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060211D8 RID: 135640 RVA: 0x009401C8 File Offset: 0x0093E3C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060211D9 RID: 135641 RVA: 0x00940284 File Offset: 0x0093E484
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060211DA RID: 135642 RVA: 0x00940310 File Offset: 0x0093E510
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterSimulation(int EntryPoint)
		{
			BP_WaterSimulation_C.__ExecuteUbergraph_BP_WaterSimulation_FunctionParams* ptr = stackalloc BP_WaterSimulation_C.__ExecuteUbergraph_BP_WaterSimulation_FunctionParams[(UIntPtr)895] + 15L / (long)sizeof(BP_WaterSimulation_C.__ExecuteUbergraph_BP_WaterSimulation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_C.__ExecuteUbergraph_BP_WaterSimulation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_C.__ExecuteUbergraph_BP_WaterSimulation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060211DB RID: 135643 RVA: 0x0094035A File Offset: 0x0093E55A
		protected BP_WaterSimulation_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040109DB RID: 68059
		internal static int __InterfaceOffset_INiagaraParticleCallbackHandler;

		// Token: 0x040109DC RID: 68060
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation.BP_WaterSimulation_C";

		// Token: 0x040109DD RID: 68061
		private static IntPtr _ClassPtr;

		// Token: 0x040109DE RID: 68062
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040109DF RID: 68063
		internal static int __PropertyOffset_0;

		// Token: 0x040109E0 RID: 68064
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040109E1 RID: 68065
		internal static int __PropertyOffset_1;

		// Token: 0x040109E2 RID: 68066
		internal static int __PropertyOffset_2;

		// Token: 0x040109E3 RID: 68067
		internal static int __PropertyOffset_3;

		// Token: 0x040109E4 RID: 68068
		internal static int __PropertyOffset_4;

		// Token: 0x040109E5 RID: 68069
		internal static int __PropertyOffset_5;

		// Token: 0x040109E6 RID: 68070
		internal static int __PropertyOffset_6;

		// Token: 0x040109E7 RID: 68071
		internal static int __PropertyOffset_7;

		// Token: 0x040109E8 RID: 68072
		internal static int __PropertyOffset_8;

		// Token: 0x040109E9 RID: 68073
		internal static int __PropertyOffset_9;

		// Token: 0x040109EA RID: 68074
		internal static int __PropertyOffset_10;

		// Token: 0x040109EB RID: 68075
		internal static int __PropertyOffset_11;

		// Token: 0x040109EC RID: 68076
		internal static int __PropertyOffset_12;

		// Token: 0x040109ED RID: 68077
		internal static int __PropertyOffset_13;

		// Token: 0x040109EE RID: 68078
		internal static int __PropertyOffset_14;

		// Token: 0x040109EF RID: 68079
		internal static int __PropertyOffset_15;

		// Token: 0x040109F0 RID: 68080
		internal static int __PropertyOffset_16;

		// Token: 0x040109F1 RID: 68081
		internal static int __PropertyOffset_17;

		// Token: 0x040109F2 RID: 68082
		internal static int __PropertyOffset_18;

		// Token: 0x040109F3 RID: 68083
		internal static int __PropertyOffset_19;

		// Token: 0x040109F4 RID: 68084
		internal static int __PropertyOffset_20;

		// Token: 0x040109F5 RID: 68085
		internal static int __PropertyOffset_21;

		// Token: 0x040109F6 RID: 68086
		internal static int __PropertyOffset_22;

		// Token: 0x040109F7 RID: 68087
		internal static int __PropertyOffset_23;

		// Token: 0x040109F8 RID: 68088
		internal static int __PropertyOffset_24;

		// Token: 0x040109F9 RID: 68089
		internal static int __PropertyOffset_25;

		// Token: 0x040109FA RID: 68090
		internal static int __PropertyOffset_26;

		// Token: 0x040109FB RID: 68091
		internal static int __PropertyOffset_27;

		// Token: 0x040109FC RID: 68092
		internal static int __PropertyOffset_28;

		// Token: 0x040109FD RID: 68093
		internal static int __PropertyOffset_29;

		// Token: 0x040109FE RID: 68094
		internal static int __PropertyOffset_30;

		// Token: 0x040109FF RID: 68095
		internal static int __PropertyOffset_31;

		// Token: 0x04010A00 RID: 68096
		internal static int __PropertyOffset_32;

		// Token: 0x04010A01 RID: 68097
		internal static int __PropertyOffset_33;

		// Token: 0x04010A02 RID: 68098
		internal static int __PropertyOffset_34;

		// Token: 0x04010A03 RID: 68099
		internal static int __PropertyOffset_35;

		// Token: 0x04010A04 RID: 68100
		internal static int __PropertyOffset_36;

		// Token: 0x04010A05 RID: 68101
		internal static int __PropertyOffset_37;

		// Token: 0x04010A06 RID: 68102
		internal static int __PropertyOffset_38;

		// Token: 0x04010A07 RID: 68103
		internal static int __PropertyOffset_39;

		// Token: 0x04010A08 RID: 68104
		internal static int __PropertyOffset_40;

		// Token: 0x04010A09 RID: 68105
		internal static int __PropertyOffset_41;

		// Token: 0x04010A0A RID: 68106
		internal static int __PropertyOffset_42;

		// Token: 0x04010A0B RID: 68107
		internal static int __PropertyOffset_43;

		// Token: 0x04010A0C RID: 68108
		internal static int __PropertyOffset_44;

		// Token: 0x04010A0D RID: 68109
		internal static int __PropertyOffset_45;

		// Token: 0x04010A0E RID: 68110
		internal static int __PropertyOffset_46;

		// Token: 0x04010A0F RID: 68111
		internal static int __PropertyOffset_47;

		// Token: 0x04010A10 RID: 68112
		internal static int __PropertyOffset_48;

		// Token: 0x04010A11 RID: 68113
		internal static int __PropertyOffset_49;

		// Token: 0x04010A12 RID: 68114
		internal static int __PropertyOffset_50;

		// Token: 0x04010A13 RID: 68115
		internal static int __PropertyOffset_51;

		// Token: 0x04010A14 RID: 68116
		internal static int __PropertyOffset_52;

		// Token: 0x04010A15 RID: 68117
		internal static int __PropertyOffset_53;

		// Token: 0x04010A16 RID: 68118
		internal static int __PropertyOffset_54;

		// Token: 0x04010A17 RID: 68119
		internal static int __PropertyOffset_55;

		// Token: 0x04010A18 RID: 68120
		internal static int __PropertyOffset_56;

		// Token: 0x04010A19 RID: 68121
		internal static int __PropertyOffset_57;

		// Token: 0x04010A1A RID: 68122
		private static IntPtr __HideRenderWaterMesh_NativeFunctionPtr;

		// Token: 0x04010A1B RID: 68123
		private static IntPtr __CalcHeightmap_NativeFunctionPtr;

		// Token: 0x04010A1C RID: 68124
		private static IntPtr __SetMPCParameters_NativeFunctionPtr;

		// Token: 0x04010A1D RID: 68125
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04010A1E RID: 68126
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04010A1F RID: 68127
		private static IntPtr __ClearWater_NativeFunctionPtr;

		// Token: 0x04010A20 RID: 68128
		private static IntPtr __SetMaterialParameter_NativeFunctionPtr;

		// Token: 0x04010A21 RID: 68129
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010A22 RID: 68130
		private static IntPtr __ReceiveParticleData_NativeFunctionPtr;

		// Token: 0x04010A23 RID: 68131
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010A24 RID: 68132
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010A25 RID: 68133
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010A26 RID: 68134
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010A27 RID: 68135
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010A28 RID: 68136
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010A29 RID: 68137
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010A2A RID: 68138
		private static IntPtr __ExecuteUbergraph_BP_WaterSimulation_NativeFunctionPtr;

		// Token: 0x02009A74 RID: 39540
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __HideRenderWaterMesh_FunctionParams
		{
			// Token: 0x040321B0 RID: 205232
			[FieldOffset(0)]
			public bool HideRenderWater;
		}

		// Token: 0x02009A75 RID: 39541
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetMaterialParameter_FunctionParams
		{
			// Token: 0x040321B1 RID: 205233
			[FieldOffset(0)]
			public IntPtr Material;

			// Token: 0x040321B2 RID: 205234
			[FieldOffset(8)]
			public IntPtr VelocityHeightFoam;

			// Token: 0x040321B3 RID: 205235
			[FieldOffset(16)]
			public IntPtr MaterialInstance;
		}

		// Token: 0x02009A76 RID: 39542
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ReceiveParticleData_FunctionParams
		{
			// Token: 0x040321B4 RID: 205236
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x040321B5 RID: 205237
			[FieldOffset(16)]
			public IntPtr NiagaraSystem;
		}

		// Token: 0x02009A77 RID: 39543
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040321B6 RID: 205238
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A78 RID: 39544
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321B7 RID: 205239
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321B8 RID: 205240
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321B9 RID: 205241
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321BA RID: 205242
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040321BB RID: 205243
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040321BC RID: 205244
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A79 RID: 39545
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321BD RID: 205245
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321BE RID: 205246
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321BF RID: 205247
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321C0 RID: 205248
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A7A RID: 39546
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321C1 RID: 205249
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321C2 RID: 205250
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321C3 RID: 205251
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321C4 RID: 205252
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040321C5 RID: 205253
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040321C6 RID: 205254
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A7B RID: 39547
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321C7 RID: 205255
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321C8 RID: 205256
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321C9 RID: 205257
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321CA RID: 205258
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A7C RID: 39548
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 880)]
		protected ref struct __ExecuteUbergraph_BP_WaterSimulation_FunctionParams
		{
			// Token: 0x040321CB RID: 205259
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
