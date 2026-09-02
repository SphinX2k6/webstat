using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader._3_5_BurnTree
{
	// Token: 0x02003B83 RID: 15235
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_5_BurnTree/BP_BurnTree.BP_BurnTree_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_BurnTree_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021AC4 RID: 137924 RVA: 0x0094FAA8 File Offset: 0x0094DCA8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BurnTree_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_5_BurnTree/BP_BurnTree.BP_BurnTree_C");
			}
			return BP_BurnTree_C._ClassPtr;
		}

		// Token: 0x06021AC5 RID: 137925 RVA: 0x0094FACC File Offset: 0x0094DCCC
		public BP_BurnTree_C() : this(BuiltinUtils.AllocNativeUObject(BP_BurnTree_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021AC6 RID: 137926 RVA: 0x0094FAF4 File Offset: 0x0094DCF4
		[NullableContext(1)]
		public BP_BurnTree_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BurnTree_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003C6E RID: 15470
		// (get) Token: 0x06021AC7 RID: 137927 RVA: 0x0094FB28 File Offset: 0x0094DD28
		// (set) Token: 0x06021AC8 RID: 137928 RVA: 0x0094FB61 File Offset: 0x0094DD61
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003C6F RID: 15471
		// (get) Token: 0x06021AC9 RID: 137929 RVA: 0x0094FB82 File Offset: 0x0094DD82
		// (set) Token: 0x06021ACA RID: 137930 RVA: 0x0094FB96 File Offset: 0x0094DD96
		public unsafe UNiagaraComponent NS_Tree_Ash
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003C70 RID: 15472
		// (get) Token: 0x06021ACB RID: 137931 RVA: 0x0094FBAB File Offset: 0x0094DDAB
		// (set) Token: 0x06021ACC RID: 137932 RVA: 0x0094FBBF File Offset: 0x0094DDBF
		public unsafe UNiagaraComponent NS_TreeFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003C71 RID: 15473
		// (get) Token: 0x06021ACD RID: 137933 RVA: 0x0094FBD4 File Offset: 0x0094DDD4
		// (set) Token: 0x06021ACE RID: 137934 RVA: 0x0094FBE8 File Offset: 0x0094DDE8
		public unsafe USphereComponent CollisionBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003C72 RID: 15474
		// (get) Token: 0x06021ACF RID: 137935 RVA: 0x0094FBFD File Offset: 0x0094DDFD
		// (set) Token: 0x06021AD0 RID: 137936 RVA: 0x0094FC11 File Offset: 0x0094DE11
		public unsafe UStaticMeshComponent Tree
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003C73 RID: 15475
		// (get) Token: 0x06021AD1 RID: 137937 RVA: 0x0094FC26 File Offset: 0x0094DE26
		// (set) Token: 0x06021AD2 RID: 137938 RVA: 0x0094FC3A File Offset: 0x0094DE3A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003C74 RID: 15476
		// (get) Token: 0x06021AD3 RID: 137939 RVA: 0x0094FC4F File Offset: 0x0094DE4F
		// (set) Token: 0x06021AD4 RID: 137940 RVA: 0x0094FC63 File Offset: 0x0094DE63
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003C75 RID: 15477
		// (get) Token: 0x06021AD5 RID: 137941 RVA: 0x0094FC78 File Offset: 0x0094DE78
		// (set) Token: 0x06021AD6 RID: 137942 RVA: 0x0094FC8C File Offset: 0x0094DE8C
		public unsafe BP_WeatherController_C WeatherController
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WeatherController_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003C76 RID: 15478
		// (get) Token: 0x06021AD7 RID: 137943 RVA: 0x0094FCA1 File Offset: 0x0094DEA1
		// (set) Token: 0x06021AD8 RID: 137944 RVA: 0x0094FCB5 File Offset: 0x0094DEB5
		public unsafe UMaterialInstance Element_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003C77 RID: 15479
		// (get) Token: 0x06021AD9 RID: 137945 RVA: 0x0094FCCA File Offset: 0x0094DECA
		// (set) Token: 0x06021ADA RID: 137946 RVA: 0x0094FCDE File Offset: 0x0094DEDE
		public unsafe UMaterialInstance Element_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003C78 RID: 15480
		// (get) Token: 0x06021ADB RID: 137947 RVA: 0x0094FCF3 File Offset: 0x0094DEF3
		// (set) Token: 0x06021ADC RID: 137948 RVA: 0x0094FD07 File Offset: 0x0094DF07
		public unsafe UMaterialInstance Element_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003C79 RID: 15481
		// (get) Token: 0x06021ADD RID: 137949 RVA: 0x0094FD1C File Offset: 0x0094DF1C
		// (set) Token: 0x06021ADE RID: 137950 RVA: 0x0094FD30 File Offset: 0x0094DF30
		public unsafe UMaterialInstance Element_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003C7A RID: 15482
		// (get) Token: 0x06021ADF RID: 137951 RVA: 0x0094FD45 File Offset: 0x0094DF45
		// (set) Token: 0x06021AE0 RID: 137952 RVA: 0x0094FD59 File Offset: 0x0094DF59
		public unsafe UMaterialInstanceDynamic DMI_Element_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003C7B RID: 15483
		// (get) Token: 0x06021AE1 RID: 137953 RVA: 0x0094FD6E File Offset: 0x0094DF6E
		// (set) Token: 0x06021AE2 RID: 137954 RVA: 0x0094FD82 File Offset: 0x0094DF82
		public unsafe UMaterialInstanceDynamic DMI_Element_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003C7C RID: 15484
		// (get) Token: 0x06021AE3 RID: 137955 RVA: 0x0094FD97 File Offset: 0x0094DF97
		// (set) Token: 0x06021AE4 RID: 137956 RVA: 0x0094FDA7 File Offset: 0x0094DFA7
		public unsafe bool Debug__BurnState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C7D RID: 15485
		// (get) Token: 0x06021AE5 RID: 137957 RVA: 0x0094FDB8 File Offset: 0x0094DFB8
		// (set) Token: 0x06021AE6 RID: 137958 RVA: 0x0094FDC8 File Offset: 0x0094DFC8
		public unsafe float Delta_Scond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003C7E RID: 15486
		// (get) Token: 0x06021AE7 RID: 137959 RVA: 0x0094FDD9 File Offset: 0x0094DFD9
		// (set) Token: 0x06021AE8 RID: 137960 RVA: 0x0094FDE9 File Offset: 0x0094DFE9
		public unsafe float SpreadTime_Niagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003C7F RID: 15487
		// (get) Token: 0x06021AE9 RID: 137961 RVA: 0x0094FDFA File Offset: 0x0094DFFA
		// (set) Token: 0x06021AEA RID: 137962 RVA: 0x0094FE0A File Offset: 0x0094E00A
		public unsafe float SpreadSpeed_Niagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003C80 RID: 15488
		// (get) Token: 0x06021AEB RID: 137963 RVA: 0x0094FE1B File Offset: 0x0094E01B
		// (set) Token: 0x06021AEC RID: 137964 RVA: 0x0094FE2B File Offset: 0x0094E02B
		public unsafe float SpeedTimeLinear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17003C81 RID: 15489
		// (get) Token: 0x06021AED RID: 137965 RVA: 0x0094FE3C File Offset: 0x0094E03C
		// (set) Token: 0x06021AEE RID: 137966 RVA: 0x0094FE4C File Offset: 0x0094E04C
		public unsafe float SpeedTimeLinear_Delay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003C82 RID: 15490
		// (get) Token: 0x06021AEF RID: 137967 RVA: 0x0094FE5D File Offset: 0x0094E05D
		// (set) Token: 0x06021AF0 RID: 137968 RVA: 0x0094FE71 File Offset: 0x0094E071
		[Nullable(0)]
		public unsafe TEnumAsByte<E_EBurnState> EBurnState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_20);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003C83 RID: 15491
		// (get) Token: 0x06021AF1 RID: 137969 RVA: 0x0094FE86 File Offset: 0x0094E086
		// (set) Token: 0x06021AF2 RID: 137970 RVA: 0x0094FE96 File Offset: 0x0094E096
		public unsafe float BurnTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003C84 RID: 15492
		// (get) Token: 0x06021AF3 RID: 137971 RVA: 0x0094FEA7 File Offset: 0x0094E0A7
		// (set) Token: 0x06021AF4 RID: 137972 RVA: 0x0094FEB7 File Offset: 0x0094E0B7
		public unsafe float BurnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003C85 RID: 15493
		// (get) Token: 0x06021AF5 RID: 137973 RVA: 0x0094FEC8 File Offset: 0x0094E0C8
		// (set) Token: 0x06021AF6 RID: 137974 RVA: 0x0094FED8 File Offset: 0x0094E0D8
		public unsafe float BurnDelayThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003C86 RID: 15494
		// (get) Token: 0x06021AF7 RID: 137975 RVA: 0x0094FEE9 File Offset: 0x0094E0E9
		// (set) Token: 0x06021AF8 RID: 137976 RVA: 0x0094FEF9 File Offset: 0x0094E0F9
		public unsafe float Get_Rain_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003C87 RID: 15495
		// (get) Token: 0x06021AF9 RID: 137977 RVA: 0x0094FF0A File Offset: 0x0094E10A
		// (set) Token: 0x06021AFA RID: 137978 RVA: 0x0094FF1A File Offset: 0x0094E11A
		public unsafe float MaterialBurnDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17003C88 RID: 15496
		// (get) Token: 0x06021AFB RID: 137979 RVA: 0x0094FF2B File Offset: 0x0094E12B
		// (set) Token: 0x06021AFC RID: 137980 RVA: 0x0094FF3B File Offset: 0x0094E13B
		public unsafe float ParticleFadeValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003C89 RID: 15497
		// (get) Token: 0x06021AFD RID: 137981 RVA: 0x0094FF4C File Offset: 0x0094E14C
		// (set) Token: 0x06021AFE RID: 137982 RVA: 0x0094FF5C File Offset: 0x0094E15C
		public unsafe float ParticleFadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17003C8A RID: 15498
		// (get) Token: 0x06021AFF RID: 137983 RVA: 0x0094FF6D File Offset: 0x0094E16D
		// (set) Token: 0x06021B00 RID: 137984 RVA: 0x0094FF7D File Offset: 0x0094E17D
		public unsafe float ParticleFadeVale_Ash
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003C8B RID: 15499
		// (get) Token: 0x06021B01 RID: 137985 RVA: 0x0094FF8E File Offset: 0x0094E18E
		// (set) Token: 0x06021B02 RID: 137986 RVA: 0x0094FF9E File Offset: 0x0094E19E
		public unsafe float ParticleFadeSpeed_Ash
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003C8C RID: 15500
		// (get) Token: 0x06021B03 RID: 137987 RVA: 0x0094FFAF File Offset: 0x0094E1AF
		// (set) Token: 0x06021B04 RID: 137988 RVA: 0x0094FFBF File Offset: 0x0094E1BF
		public unsafe bool bAshActivated
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C8D RID: 15501
		// (get) Token: 0x06021B05 RID: 137989 RVA: 0x0094FFD0 File Offset: 0x0094E1D0
		// (set) Token: 0x06021B06 RID: 137990 RVA: 0x0094FFE0 File Offset: 0x0094E1E0
		public unsafe float EmberFadeValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17003C8E RID: 15502
		// (get) Token: 0x06021B07 RID: 137991 RVA: 0x0094FFF1 File Offset: 0x0094E1F1
		// (set) Token: 0x06021B08 RID: 137992 RVA: 0x00950001 File Offset: 0x0094E201
		public unsafe float EmberFadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BurnTree_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17003C8F RID: 15503
		// (get) Token: 0x06021B09 RID: 137993 RVA: 0x00950012 File Offset: 0x0094E212
		// (set) Token: 0x06021B0A RID: 137994 RVA: 0x00950026 File Offset: 0x0094E226
		public unsafe UMaterialInstanceDynamic DMI_Element_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003C90 RID: 15504
		// (get) Token: 0x06021B0B RID: 137995 RVA: 0x0095003B File Offset: 0x0094E23B
		// (set) Token: 0x06021B0C RID: 137996 RVA: 0x0095004F File Offset: 0x0094E24F
		public unsafe UMaterialInstanceDynamic DMI_Element_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003C91 RID: 15505
		// (get) Token: 0x06021B0D RID: 137997 RVA: 0x00950064 File Offset: 0x0094E264
		// (set) Token: 0x06021B0E RID: 137998 RVA: 0x00950078 File Offset: 0x0094E278
		public unsafe UAkAudioEvent Audio_Event
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BurnTree_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x06021B0F RID: 137999 RVA: 0x0095008D File Offset: 0x0094E28D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEmberFadeValue()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__UpdateEmberFadeValue_NativeFunctionPtr, null);
		}

		// Token: 0x06021B10 RID: 138000 RVA: 0x009500A1 File Offset: 0x0094E2A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParticleFadeParam_Ash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__UpdateParticleFadeParam_Ash_NativeFunctionPtr, null);
		}

		// Token: 0x06021B11 RID: 138001 RVA: 0x009500B5 File Offset: 0x0094E2B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParticleFadeParam_Fire()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__UpdateParticleFadeParam_Fire_NativeFunctionPtr, null);
		}

		// Token: 0x06021B12 RID: 138002 RVA: 0x009500C9 File Offset: 0x0094E2C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLeafBurnThreshold()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__UpdateLeafBurnThreshold_NativeFunctionPtr, null);
		}

		// Token: 0x06021B13 RID: 138003 RVA: 0x009500DD File Offset: 0x0094E2DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLeafBurnParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__UpdateLeafBurnParam_NativeFunctionPtr, null);
		}

		// Token: 0x06021B14 RID: 138004 RVA: 0x009500F1 File Offset: 0x0094E2F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFireNiagaraParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__UpdateFireNiagaraParam_NativeFunctionPtr, null);
		}

		// Token: 0x06021B15 RID: 138005 RVA: 0x00950105 File Offset: 0x0094E305
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetBurnState()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__ResetBurnState_NativeFunctionPtr, null);
		}

		// Token: 0x06021B16 RID: 138006 RVA: 0x00950119 File Offset: 0x0094E319
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_StaticMeshAndDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__Set_StaticMeshAndDMI_NativeFunctionPtr, null);
		}

		// Token: 0x06021B17 RID: 138007 RVA: 0x0095012D File Offset: 0x0094E32D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021B18 RID: 138008 RVA: 0x00950141 File Offset: 0x0094E341
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BurnTree_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B19 RID: 138009 RVA: 0x00950156 File Offset: 0x0094E356
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021B1A RID: 138010 RVA: 0x0095016A File Offset: 0x0094E36A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BurnTree_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B1B RID: 138011 RVA: 0x00950180 File Offset: 0x0094E380
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BurnTree_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BurnTree_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BurnTree_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BurnTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B1C RID: 138012 RVA: 0x009501C8 File Offset: 0x0094E3C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BurnTree_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BurnTree_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BurnTree_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BurnTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BurnTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B1D RID: 138013 RVA: 0x00950210 File Offset: 0x0094E410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_BurnTree_C.__EditorTick_FunctionParams* ptr = stackalloc BP_BurnTree_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BurnTree_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BurnTree_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B1E RID: 138014 RVA: 0x00950258 File Offset: 0x0094E458
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_BurnTree_C.__EditorTick_FunctionParams* ptr = stackalloc BP_BurnTree_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BurnTree_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BurnTree_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BurnTree_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B1F RID: 138015 RVA: 0x009502A0 File Offset: 0x0094E4A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B20 RID: 138016 RVA: 0x0095035C File Offset: 0x0094E55C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BurnTree_C.__BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B21 RID: 138017 RVA: 0x009503E8 File Offset: 0x0094E5E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BurnTree(int EntryPoint)
		{
			BP_BurnTree_C.__ExecuteUbergraph_BP_BurnTree_FunctionParams* ptr = stackalloc BP_BurnTree_C.__ExecuteUbergraph_BP_BurnTree_FunctionParams[(UIntPtr)343] + 15L / (long)sizeof(BP_BurnTree_C.__ExecuteUbergraph_BP_BurnTree_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BurnTree_C.__ExecuteUbergraph_BP_BurnTree_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BurnTree_C.__ExecuteUbergraph_BP_BurnTree_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021B22 RID: 138018 RVA: 0x00950432 File Offset: 0x0094E632
		protected BP_BurnTree_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010F91 RID: 69521
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/3_5_BurnTree/BP_BurnTree.BP_BurnTree_C";

		// Token: 0x04010F92 RID: 69522
		private static IntPtr _ClassPtr;

		// Token: 0x04010F93 RID: 69523
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010F94 RID: 69524
		internal static int __PropertyOffset_0;

		// Token: 0x04010F95 RID: 69525
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010F96 RID: 69526
		internal static int __PropertyOffset_1;

		// Token: 0x04010F97 RID: 69527
		internal static int __PropertyOffset_2;

		// Token: 0x04010F98 RID: 69528
		internal static int __PropertyOffset_3;

		// Token: 0x04010F99 RID: 69529
		internal static int __PropertyOffset_4;

		// Token: 0x04010F9A RID: 69530
		internal static int __PropertyOffset_5;

		// Token: 0x04010F9B RID: 69531
		internal static int __PropertyOffset_6;

		// Token: 0x04010F9C RID: 69532
		internal static int __PropertyOffset_7;

		// Token: 0x04010F9D RID: 69533
		internal static int __PropertyOffset_8;

		// Token: 0x04010F9E RID: 69534
		internal static int __PropertyOffset_9;

		// Token: 0x04010F9F RID: 69535
		internal static int __PropertyOffset_10;

		// Token: 0x04010FA0 RID: 69536
		internal static int __PropertyOffset_11;

		// Token: 0x04010FA1 RID: 69537
		internal static int __PropertyOffset_12;

		// Token: 0x04010FA2 RID: 69538
		internal static int __PropertyOffset_13;

		// Token: 0x04010FA3 RID: 69539
		internal static int __PropertyOffset_14;

		// Token: 0x04010FA4 RID: 69540
		internal static int __PropertyOffset_15;

		// Token: 0x04010FA5 RID: 69541
		internal static int __PropertyOffset_16;

		// Token: 0x04010FA6 RID: 69542
		internal static int __PropertyOffset_17;

		// Token: 0x04010FA7 RID: 69543
		internal static int __PropertyOffset_18;

		// Token: 0x04010FA8 RID: 69544
		internal static int __PropertyOffset_19;

		// Token: 0x04010FA9 RID: 69545
		internal static int __PropertyOffset_20;

		// Token: 0x04010FAA RID: 69546
		internal static int __PropertyOffset_21;

		// Token: 0x04010FAB RID: 69547
		internal static int __PropertyOffset_22;

		// Token: 0x04010FAC RID: 69548
		internal static int __PropertyOffset_23;

		// Token: 0x04010FAD RID: 69549
		internal static int __PropertyOffset_24;

		// Token: 0x04010FAE RID: 69550
		internal static int __PropertyOffset_25;

		// Token: 0x04010FAF RID: 69551
		internal static int __PropertyOffset_26;

		// Token: 0x04010FB0 RID: 69552
		internal static int __PropertyOffset_27;

		// Token: 0x04010FB1 RID: 69553
		internal static int __PropertyOffset_28;

		// Token: 0x04010FB2 RID: 69554
		internal static int __PropertyOffset_29;

		// Token: 0x04010FB3 RID: 69555
		internal static int __PropertyOffset_30;

		// Token: 0x04010FB4 RID: 69556
		internal static int __PropertyOffset_31;

		// Token: 0x04010FB5 RID: 69557
		internal static int __PropertyOffset_32;

		// Token: 0x04010FB6 RID: 69558
		internal static int __PropertyOffset_33;

		// Token: 0x04010FB7 RID: 69559
		internal static int __PropertyOffset_34;

		// Token: 0x04010FB8 RID: 69560
		internal static int __PropertyOffset_35;

		// Token: 0x04010FB9 RID: 69561
		private static IntPtr __UpdateEmberFadeValue_NativeFunctionPtr;

		// Token: 0x04010FBA RID: 69562
		private static IntPtr __UpdateParticleFadeParam_Ash_NativeFunctionPtr;

		// Token: 0x04010FBB RID: 69563
		private static IntPtr __UpdateParticleFadeParam_Fire_NativeFunctionPtr;

		// Token: 0x04010FBC RID: 69564
		private static IntPtr __UpdateLeafBurnThreshold_NativeFunctionPtr;

		// Token: 0x04010FBD RID: 69565
		private static IntPtr __UpdateLeafBurnParam_NativeFunctionPtr;

		// Token: 0x04010FBE RID: 69566
		private static IntPtr __UpdateFireNiagaraParam_NativeFunctionPtr;

		// Token: 0x04010FBF RID: 69567
		private static IntPtr __ResetBurnState_NativeFunctionPtr;

		// Token: 0x04010FC0 RID: 69568
		private static IntPtr __Set_StaticMeshAndDMI_NativeFunctionPtr;

		// Token: 0x04010FC1 RID: 69569
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010FC2 RID: 69570
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010FC3 RID: 69571
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010FC4 RID: 69572
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010FC5 RID: 69573
		private static IntPtr __BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010FC6 RID: 69574
		private static IntPtr __BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010FC7 RID: 69575
		private static IntPtr __ExecuteUbergraph_BP_BurnTree_NativeFunctionPtr;

		// Token: 0x02009B15 RID: 39701
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322C5 RID: 205509
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B16 RID: 39702
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040322C6 RID: 205510
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B17 RID: 39703
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322C7 RID: 205511
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322C8 RID: 205512
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322C9 RID: 205513
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322CA RID: 205514
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040322CB RID: 205515
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040322CC RID: 205516
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B18 RID: 39704
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_BurnTree_Collision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322CD RID: 205517
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322CE RID: 205518
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322CF RID: 205519
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322D0 RID: 205520
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B19 RID: 39705
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 328)]
		protected ref struct __ExecuteUbergraph_BP_BurnTree_FunctionParams
		{
			// Token: 0x040322D1 RID: 205521
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
