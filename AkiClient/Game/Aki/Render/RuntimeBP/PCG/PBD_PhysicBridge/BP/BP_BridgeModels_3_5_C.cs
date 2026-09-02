using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BAE RID: 15278
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_3_5.BP_BridgeModels_3_5_C")]
	[UnrealStructLayout(2312, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2312)]
	public class BP_BridgeModels_3_5_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021FE8 RID: 139240 RVA: 0x00959587 File Offset: 0x00957787
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BridgeModels_3_5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_3_5.BP_BridgeModels_3_5_C");
			}
			return BP_BridgeModels_3_5_C._ClassPtr;
		}

		// Token: 0x06021FE9 RID: 139241 RVA: 0x009595AC File Offset: 0x009577AC
		public BP_BridgeModels_3_5_C() : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_3_5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021FEA RID: 139242 RVA: 0x009595D4 File Offset: 0x009577D4
		[NullableContext(1)]
		public BP_BridgeModels_3_5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_3_5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003E15 RID: 15893
		// (get) Token: 0x06021FEB RID: 139243 RVA: 0x00959608 File Offset: 0x00957808
		// (set) Token: 0x06021FEC RID: 139244 RVA: 0x00959641 File Offset: 0x00957841
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003E16 RID: 15894
		// (get) Token: 0x06021FED RID: 139245 RVA: 0x00959662 File Offset: 0x00957862
		// (set) Token: 0x06021FEE RID: 139246 RVA: 0x00959676 File Offset: 0x00957876
		public unsafe UBoxComponent LODRangeBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003E17 RID: 15895
		// (get) Token: 0x06021FEF RID: 139247 RVA: 0x0095968B File Offset: 0x0095788B
		// (set) Token: 0x06021FF0 RID: 139248 RVA: 0x0095969F File Offset: 0x0095789F
		public unsafe UStaticMeshComponent SM_Gel_Bri_06CL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003E18 RID: 15896
		// (get) Token: 0x06021FF1 RID: 139249 RVA: 0x009596B4 File Offset: 0x009578B4
		// (set) Token: 0x06021FF2 RID: 139250 RVA: 0x009596C8 File Offset: 0x009578C8
		public unsafe UStaticMeshComponent SM_Gel_Bri_06BL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003E19 RID: 15897
		// (get) Token: 0x06021FF3 RID: 139251 RVA: 0x009596DD File Offset: 0x009578DD
		// (set) Token: 0x06021FF4 RID: 139252 RVA: 0x009596F1 File Offset: 0x009578F1
		public unsafe UStaticMeshComponent Cube16
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003E1A RID: 15898
		// (get) Token: 0x06021FF5 RID: 139253 RVA: 0x00959706 File Offset: 0x00957906
		// (set) Token: 0x06021FF6 RID: 139254 RVA: 0x0095971A File Offset: 0x0095791A
		public unsafe UStaticMeshComponent Cube15
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003E1B RID: 15899
		// (get) Token: 0x06021FF7 RID: 139255 RVA: 0x0095972F File Offset: 0x0095792F
		// (set) Token: 0x06021FF8 RID: 139256 RVA: 0x00959743 File Offset: 0x00957943
		public unsafe UStaticMeshComponent Cube14
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003E1C RID: 15900
		// (get) Token: 0x06021FF9 RID: 139257 RVA: 0x00959758 File Offset: 0x00957958
		// (set) Token: 0x06021FFA RID: 139258 RVA: 0x0095976C File Offset: 0x0095796C
		public unsafe UStaticMeshComponent Cube13
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003E1D RID: 15901
		// (get) Token: 0x06021FFB RID: 139259 RVA: 0x00959781 File Offset: 0x00957981
		// (set) Token: 0x06021FFC RID: 139260 RVA: 0x00959795 File Offset: 0x00957995
		public unsafe UStaticMeshComponent Cube12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003E1E RID: 15902
		// (get) Token: 0x06021FFD RID: 139261 RVA: 0x009597AA File Offset: 0x009579AA
		// (set) Token: 0x06021FFE RID: 139262 RVA: 0x009597BE File Offset: 0x009579BE
		public unsafe UStaticMeshComponent Cube11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003E1F RID: 15903
		// (get) Token: 0x06021FFF RID: 139263 RVA: 0x009597D3 File Offset: 0x009579D3
		// (set) Token: 0x06022000 RID: 139264 RVA: 0x009597E7 File Offset: 0x009579E7
		public unsafe UChildActorComponent _94_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003E20 RID: 15904
		// (get) Token: 0x06022001 RID: 139265 RVA: 0x009597FC File Offset: 0x009579FC
		// (set) Token: 0x06022002 RID: 139266 RVA: 0x00959810 File Offset: 0x00957A10
		public unsafe UChildActorComponent _94_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003E21 RID: 15905
		// (get) Token: 0x06022003 RID: 139267 RVA: 0x00959825 File Offset: 0x00957A25
		// (set) Token: 0x06022004 RID: 139268 RVA: 0x00959839 File Offset: 0x00957A39
		public unsafe UChildActorComponent _94_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003E22 RID: 15906
		// (get) Token: 0x06022005 RID: 139269 RVA: 0x0095984E File Offset: 0x00957A4E
		// (set) Token: 0x06022006 RID: 139270 RVA: 0x00959862 File Offset: 0x00957A62
		public unsafe UChildActorComponent _94_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003E23 RID: 15907
		// (get) Token: 0x06022007 RID: 139271 RVA: 0x00959877 File Offset: 0x00957A77
		// (set) Token: 0x06022008 RID: 139272 RVA: 0x0095988B File Offset: 0x00957A8B
		public unsafe UChildActorComponent _83_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003E24 RID: 15908
		// (get) Token: 0x06022009 RID: 139273 RVA: 0x009598A0 File Offset: 0x00957AA0
		// (set) Token: 0x0602200A RID: 139274 RVA: 0x009598B4 File Offset: 0x00957AB4
		public unsafe UChildActorComponent _83_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003E25 RID: 15909
		// (get) Token: 0x0602200B RID: 139275 RVA: 0x009598C9 File Offset: 0x00957AC9
		// (set) Token: 0x0602200C RID: 139276 RVA: 0x009598DD File Offset: 0x00957ADD
		public unsafe UChildActorComponent _83_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003E26 RID: 15910
		// (get) Token: 0x0602200D RID: 139277 RVA: 0x009598F2 File Offset: 0x00957AF2
		// (set) Token: 0x0602200E RID: 139278 RVA: 0x00959906 File Offset: 0x00957B06
		public unsafe UChildActorComponent _83_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003E27 RID: 15911
		// (get) Token: 0x0602200F RID: 139279 RVA: 0x0095991B File Offset: 0x00957B1B
		// (set) Token: 0x06022010 RID: 139280 RVA: 0x0095992F File Offset: 0x00957B2F
		public unsafe UChildActorComponent _60_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003E28 RID: 15912
		// (get) Token: 0x06022011 RID: 139281 RVA: 0x00959944 File Offset: 0x00957B44
		// (set) Token: 0x06022012 RID: 139282 RVA: 0x00959958 File Offset: 0x00957B58
		public unsafe UChildActorComponent _60_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003E29 RID: 15913
		// (get) Token: 0x06022013 RID: 139283 RVA: 0x0095996D File Offset: 0x00957B6D
		// (set) Token: 0x06022014 RID: 139284 RVA: 0x00959981 File Offset: 0x00957B81
		public unsafe UChildActorComponent _60_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003E2A RID: 15914
		// (get) Token: 0x06022015 RID: 139285 RVA: 0x00959996 File Offset: 0x00957B96
		// (set) Token: 0x06022016 RID: 139286 RVA: 0x009599AA File Offset: 0x00957BAA
		public unsafe UChildActorComponent _60_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003E2B RID: 15915
		// (get) Token: 0x06022017 RID: 139287 RVA: 0x009599BF File Offset: 0x00957BBF
		// (set) Token: 0x06022018 RID: 139288 RVA: 0x009599D3 File Offset: 0x00957BD3
		public unsafe UChildActorComponent _72_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003E2C RID: 15916
		// (get) Token: 0x06022019 RID: 139289 RVA: 0x009599E8 File Offset: 0x00957BE8
		// (set) Token: 0x0602201A RID: 139290 RVA: 0x009599FC File Offset: 0x00957BFC
		public unsafe UChildActorComponent _72_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003E2D RID: 15917
		// (get) Token: 0x0602201B RID: 139291 RVA: 0x00959A11 File Offset: 0x00957C11
		// (set) Token: 0x0602201C RID: 139292 RVA: 0x00959A25 File Offset: 0x00957C25
		public unsafe UChildActorComponent _72_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003E2E RID: 15918
		// (get) Token: 0x0602201D RID: 139293 RVA: 0x00959A3A File Offset: 0x00957C3A
		// (set) Token: 0x0602201E RID: 139294 RVA: 0x00959A4E File Offset: 0x00957C4E
		public unsafe UChildActorComponent _72_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003E2F RID: 15919
		// (get) Token: 0x0602201F RID: 139295 RVA: 0x00959A63 File Offset: 0x00957C63
		// (set) Token: 0x06022020 RID: 139296 RVA: 0x00959A77 File Offset: 0x00957C77
		public unsafe UStaticMeshComponent StaticMesh99
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003E30 RID: 15920
		// (get) Token: 0x06022021 RID: 139297 RVA: 0x00959A8C File Offset: 0x00957C8C
		// (set) Token: 0x06022022 RID: 139298 RVA: 0x00959AA0 File Offset: 0x00957CA0
		public unsafe UStaticMeshComponent StaticMesh98
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003E31 RID: 15921
		// (get) Token: 0x06022023 RID: 139299 RVA: 0x00959AB5 File Offset: 0x00957CB5
		// (set) Token: 0x06022024 RID: 139300 RVA: 0x00959AC9 File Offset: 0x00957CC9
		public unsafe UStaticMeshComponent StaticMesh97
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003E32 RID: 15922
		// (get) Token: 0x06022025 RID: 139301 RVA: 0x00959ADE File Offset: 0x00957CDE
		// (set) Token: 0x06022026 RID: 139302 RVA: 0x00959AF2 File Offset: 0x00957CF2
		public unsafe UStaticMeshComponent StaticMesh96
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17003E33 RID: 15923
		// (get) Token: 0x06022027 RID: 139303 RVA: 0x00959B07 File Offset: 0x00957D07
		// (set) Token: 0x06022028 RID: 139304 RVA: 0x00959B1B File Offset: 0x00957D1B
		public unsafe UStaticMeshComponent StaticMesh95
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003E34 RID: 15924
		// (get) Token: 0x06022029 RID: 139305 RVA: 0x00959B30 File Offset: 0x00957D30
		// (set) Token: 0x0602202A RID: 139306 RVA: 0x00959B44 File Offset: 0x00957D44
		public unsafe UStaticMeshComponent StaticMesh94
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003E35 RID: 15925
		// (get) Token: 0x0602202B RID: 139307 RVA: 0x00959B59 File Offset: 0x00957D59
		// (set) Token: 0x0602202C RID: 139308 RVA: 0x00959B6D File Offset: 0x00957D6D
		public unsafe UStaticMeshComponent StaticMesh93
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17003E36 RID: 15926
		// (get) Token: 0x0602202D RID: 139309 RVA: 0x00959B82 File Offset: 0x00957D82
		// (set) Token: 0x0602202E RID: 139310 RVA: 0x00959B96 File Offset: 0x00957D96
		public unsafe UStaticMeshComponent StaticMesh92
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003E37 RID: 15927
		// (get) Token: 0x0602202F RID: 139311 RVA: 0x00959BAB File Offset: 0x00957DAB
		// (set) Token: 0x06022030 RID: 139312 RVA: 0x00959BBF File Offset: 0x00957DBF
		public unsafe UStaticMeshComponent StaticMesh91
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003E38 RID: 15928
		// (get) Token: 0x06022031 RID: 139313 RVA: 0x00959BD4 File Offset: 0x00957DD4
		// (set) Token: 0x06022032 RID: 139314 RVA: 0x00959BE8 File Offset: 0x00957DE8
		public unsafe UStaticMeshComponent StaticMesh90
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003E39 RID: 15929
		// (get) Token: 0x06022033 RID: 139315 RVA: 0x00959BFD File Offset: 0x00957DFD
		// (set) Token: 0x06022034 RID: 139316 RVA: 0x00959C11 File Offset: 0x00957E11
		public unsafe UStaticMeshComponent StaticMesh89
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17003E3A RID: 15930
		// (get) Token: 0x06022035 RID: 139317 RVA: 0x00959C26 File Offset: 0x00957E26
		// (set) Token: 0x06022036 RID: 139318 RVA: 0x00959C3A File Offset: 0x00957E3A
		public unsafe UStaticMeshComponent StaticMesh88
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003E3B RID: 15931
		// (get) Token: 0x06022037 RID: 139319 RVA: 0x00959C4F File Offset: 0x00957E4F
		// (set) Token: 0x06022038 RID: 139320 RVA: 0x00959C63 File Offset: 0x00957E63
		public unsafe UStaticMeshComponent StaticMesh87
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003E3C RID: 15932
		// (get) Token: 0x06022039 RID: 139321 RVA: 0x00959C78 File Offset: 0x00957E78
		// (set) Token: 0x0602203A RID: 139322 RVA: 0x00959C8C File Offset: 0x00957E8C
		public unsafe UStaticMeshComponent StaticMesh86
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17003E3D RID: 15933
		// (get) Token: 0x0602203B RID: 139323 RVA: 0x00959CA1 File Offset: 0x00957EA1
		// (set) Token: 0x0602203C RID: 139324 RVA: 0x00959CB5 File Offset: 0x00957EB5
		public unsafe UStaticMeshComponent StaticMesh85
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x17003E3E RID: 15934
		// (get) Token: 0x0602203D RID: 139325 RVA: 0x00959CCA File Offset: 0x00957ECA
		// (set) Token: 0x0602203E RID: 139326 RVA: 0x00959CDE File Offset: 0x00957EDE
		public unsafe UStaticMeshComponent StaticMesh84
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17003E3F RID: 15935
		// (get) Token: 0x0602203F RID: 139327 RVA: 0x00959CF3 File Offset: 0x00957EF3
		// (set) Token: 0x06022040 RID: 139328 RVA: 0x00959D07 File Offset: 0x00957F07
		public unsafe UStaticMeshComponent StaticMesh83
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17003E40 RID: 15936
		// (get) Token: 0x06022041 RID: 139329 RVA: 0x00959D1C File Offset: 0x00957F1C
		// (set) Token: 0x06022042 RID: 139330 RVA: 0x00959D30 File Offset: 0x00957F30
		public unsafe UStaticMeshComponent StaticMesh82
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17003E41 RID: 15937
		// (get) Token: 0x06022043 RID: 139331 RVA: 0x00959D45 File Offset: 0x00957F45
		// (set) Token: 0x06022044 RID: 139332 RVA: 0x00959D59 File Offset: 0x00957F59
		public unsafe UStaticMeshComponent StaticMesh81
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003E42 RID: 15938
		// (get) Token: 0x06022045 RID: 139333 RVA: 0x00959D6E File Offset: 0x00957F6E
		// (set) Token: 0x06022046 RID: 139334 RVA: 0x00959D82 File Offset: 0x00957F82
		public unsafe UStaticMeshComponent StaticMesh80
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17003E43 RID: 15939
		// (get) Token: 0x06022047 RID: 139335 RVA: 0x00959D97 File Offset: 0x00957F97
		// (set) Token: 0x06022048 RID: 139336 RVA: 0x00959DAB File Offset: 0x00957FAB
		public unsafe UStaticMeshComponent StaticMesh79
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17003E44 RID: 15940
		// (get) Token: 0x06022049 RID: 139337 RVA: 0x00959DC0 File Offset: 0x00957FC0
		// (set) Token: 0x0602204A RID: 139338 RVA: 0x00959DD4 File Offset: 0x00957FD4
		public unsafe UStaticMeshComponent StaticMesh78
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x17003E45 RID: 15941
		// (get) Token: 0x0602204B RID: 139339 RVA: 0x00959DE9 File Offset: 0x00957FE9
		// (set) Token: 0x0602204C RID: 139340 RVA: 0x00959DFD File Offset: 0x00957FFD
		public unsafe UStaticMeshComponent StaticMesh77
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x17003E46 RID: 15942
		// (get) Token: 0x0602204D RID: 139341 RVA: 0x00959E12 File Offset: 0x00958012
		// (set) Token: 0x0602204E RID: 139342 RVA: 0x00959E26 File Offset: 0x00958026
		public unsafe UStaticMeshComponent StaticMesh76
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x17003E47 RID: 15943
		// (get) Token: 0x0602204F RID: 139343 RVA: 0x00959E3B File Offset: 0x0095803B
		// (set) Token: 0x06022050 RID: 139344 RVA: 0x00959E4F File Offset: 0x0095804F
		public unsafe UStaticMeshComponent StaticMesh75
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x17003E48 RID: 15944
		// (get) Token: 0x06022051 RID: 139345 RVA: 0x00959E64 File Offset: 0x00958064
		// (set) Token: 0x06022052 RID: 139346 RVA: 0x00959E78 File Offset: 0x00958078
		public unsafe UStaticMeshComponent StaticMesh74
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_51);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_51, value);
			}
		}

		// Token: 0x17003E49 RID: 15945
		// (get) Token: 0x06022053 RID: 139347 RVA: 0x00959E8D File Offset: 0x0095808D
		// (set) Token: 0x06022054 RID: 139348 RVA: 0x00959EA1 File Offset: 0x009580A1
		public unsafe UStaticMeshComponent StaticMesh73
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_52);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x17003E4A RID: 15946
		// (get) Token: 0x06022055 RID: 139349 RVA: 0x00959EB6 File Offset: 0x009580B6
		// (set) Token: 0x06022056 RID: 139350 RVA: 0x00959ECA File Offset: 0x009580CA
		public unsafe UStaticMeshComponent StaticMesh72
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_53);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_53, value);
			}
		}

		// Token: 0x17003E4B RID: 15947
		// (get) Token: 0x06022057 RID: 139351 RVA: 0x00959EDF File Offset: 0x009580DF
		// (set) Token: 0x06022058 RID: 139352 RVA: 0x00959EF3 File Offset: 0x009580F3
		public unsafe UStaticMeshComponent StaticMesh71
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x17003E4C RID: 15948
		// (get) Token: 0x06022059 RID: 139353 RVA: 0x00959F08 File Offset: 0x00958108
		// (set) Token: 0x0602205A RID: 139354 RVA: 0x00959F1C File Offset: 0x0095811C
		public unsafe UStaticMeshComponent StaticMesh70
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_55);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x17003E4D RID: 15949
		// (get) Token: 0x0602205B RID: 139355 RVA: 0x00959F31 File Offset: 0x00958131
		// (set) Token: 0x0602205C RID: 139356 RVA: 0x00959F45 File Offset: 0x00958145
		public unsafe UStaticMeshComponent StaticMesh69
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x17003E4E RID: 15950
		// (get) Token: 0x0602205D RID: 139357 RVA: 0x00959F5A File Offset: 0x0095815A
		// (set) Token: 0x0602205E RID: 139358 RVA: 0x00959F6E File Offset: 0x0095816E
		public unsafe UStaticMeshComponent StaticMesh68
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x17003E4F RID: 15951
		// (get) Token: 0x0602205F RID: 139359 RVA: 0x00959F83 File Offset: 0x00958183
		// (set) Token: 0x06022060 RID: 139360 RVA: 0x00959F97 File Offset: 0x00958197
		public unsafe UStaticMeshComponent StaticMesh67
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x17003E50 RID: 15952
		// (get) Token: 0x06022061 RID: 139361 RVA: 0x00959FAC File Offset: 0x009581AC
		// (set) Token: 0x06022062 RID: 139362 RVA: 0x00959FC0 File Offset: 0x009581C0
		public unsafe UStaticMeshComponent StaticMesh66
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_59);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_59, value);
			}
		}

		// Token: 0x17003E51 RID: 15953
		// (get) Token: 0x06022063 RID: 139363 RVA: 0x00959FD5 File Offset: 0x009581D5
		// (set) Token: 0x06022064 RID: 139364 RVA: 0x00959FE9 File Offset: 0x009581E9
		public unsafe UStaticMeshComponent StaticMesh65
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x17003E52 RID: 15954
		// (get) Token: 0x06022065 RID: 139365 RVA: 0x00959FFE File Offset: 0x009581FE
		// (set) Token: 0x06022066 RID: 139366 RVA: 0x0095A012 File Offset: 0x00958212
		public unsafe UStaticMeshComponent StaticMesh64
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_61);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_61, value);
			}
		}

		// Token: 0x17003E53 RID: 15955
		// (get) Token: 0x06022067 RID: 139367 RVA: 0x0095A027 File Offset: 0x00958227
		// (set) Token: 0x06022068 RID: 139368 RVA: 0x0095A03B File Offset: 0x0095823B
		public unsafe UStaticMeshComponent StaticMesh63
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_62);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_62, value);
			}
		}

		// Token: 0x17003E54 RID: 15956
		// (get) Token: 0x06022069 RID: 139369 RVA: 0x0095A050 File Offset: 0x00958250
		// (set) Token: 0x0602206A RID: 139370 RVA: 0x0095A064 File Offset: 0x00958264
		public unsafe UStaticMeshComponent StaticMesh62
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17003E55 RID: 15957
		// (get) Token: 0x0602206B RID: 139371 RVA: 0x0095A079 File Offset: 0x00958279
		// (set) Token: 0x0602206C RID: 139372 RVA: 0x0095A08D File Offset: 0x0095828D
		public unsafe UStaticMeshComponent StaticMesh60
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x17003E56 RID: 15958
		// (get) Token: 0x0602206D RID: 139373 RVA: 0x0095A0A2 File Offset: 0x009582A2
		// (set) Token: 0x0602206E RID: 139374 RVA: 0x0095A0B6 File Offset: 0x009582B6
		public unsafe UStaticMeshComponent StaticMesh59
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17003E57 RID: 15959
		// (get) Token: 0x0602206F RID: 139375 RVA: 0x0095A0CB File Offset: 0x009582CB
		// (set) Token: 0x06022070 RID: 139376 RVA: 0x0095A0DF File Offset: 0x009582DF
		public unsafe UStaticMeshComponent StaticMesh58
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_66);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_66, value);
			}
		}

		// Token: 0x17003E58 RID: 15960
		// (get) Token: 0x06022071 RID: 139377 RVA: 0x0095A0F4 File Offset: 0x009582F4
		// (set) Token: 0x06022072 RID: 139378 RVA: 0x0095A108 File Offset: 0x00958308
		public unsafe UStaticMeshComponent StaticMesh57
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_67);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_67, value);
			}
		}

		// Token: 0x17003E59 RID: 15961
		// (get) Token: 0x06022073 RID: 139379 RVA: 0x0095A11D File Offset: 0x0095831D
		// (set) Token: 0x06022074 RID: 139380 RVA: 0x0095A131 File Offset: 0x00958331
		public unsafe UStaticMeshComponent Cube8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_68);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_68, value);
			}
		}

		// Token: 0x17003E5A RID: 15962
		// (get) Token: 0x06022075 RID: 139381 RVA: 0x0095A146 File Offset: 0x00958346
		// (set) Token: 0x06022076 RID: 139382 RVA: 0x0095A15A File Offset: 0x0095835A
		public unsafe UStaticMeshComponent Cube7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_69);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_69, value);
			}
		}

		// Token: 0x17003E5B RID: 15963
		// (get) Token: 0x06022077 RID: 139383 RVA: 0x0095A16F File Offset: 0x0095836F
		// (set) Token: 0x06022078 RID: 139384 RVA: 0x0095A183 File Offset: 0x00958383
		public unsafe UChildActorComponent _15_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_70);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_70, value);
			}
		}

		// Token: 0x17003E5C RID: 15964
		// (get) Token: 0x06022079 RID: 139385 RVA: 0x0095A198 File Offset: 0x00958398
		// (set) Token: 0x0602207A RID: 139386 RVA: 0x0095A1AC File Offset: 0x009583AC
		public unsafe UStaticMeshComponent Cube3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_71);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_71, value);
			}
		}

		// Token: 0x17003E5D RID: 15965
		// (get) Token: 0x0602207B RID: 139387 RVA: 0x0095A1C1 File Offset: 0x009583C1
		// (set) Token: 0x0602207C RID: 139388 RVA: 0x0095A1D5 File Offset: 0x009583D5
		public unsafe UStaticMeshComponent Cube2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_72);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_72, value);
			}
		}

		// Token: 0x17003E5E RID: 15966
		// (get) Token: 0x0602207D RID: 139389 RVA: 0x0095A1EA File Offset: 0x009583EA
		// (set) Token: 0x0602207E RID: 139390 RVA: 0x0095A1FE File Offset: 0x009583FE
		public unsafe UChildActorComponent _15_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_73);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_73, value);
			}
		}

		// Token: 0x17003E5F RID: 15967
		// (get) Token: 0x0602207F RID: 139391 RVA: 0x0095A213 File Offset: 0x00958413
		// (set) Token: 0x06022080 RID: 139392 RVA: 0x0095A227 File Offset: 0x00958427
		public unsafe UChildActorComponent _15_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_74);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_74, value);
			}
		}

		// Token: 0x17003E60 RID: 15968
		// (get) Token: 0x06022081 RID: 139393 RVA: 0x0095A23C File Offset: 0x0095843C
		// (set) Token: 0x06022082 RID: 139394 RVA: 0x0095A250 File Offset: 0x00958450
		public unsafe UChildActorComponent _15_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_75);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_75, value);
			}
		}

		// Token: 0x17003E61 RID: 15969
		// (get) Token: 0x06022083 RID: 139395 RVA: 0x0095A265 File Offset: 0x00958465
		// (set) Token: 0x06022084 RID: 139396 RVA: 0x0095A279 File Offset: 0x00958479
		public unsafe UChildActorComponent _24_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_76);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_76, value);
			}
		}

		// Token: 0x17003E62 RID: 15970
		// (get) Token: 0x06022085 RID: 139397 RVA: 0x0095A28E File Offset: 0x0095848E
		// (set) Token: 0x06022086 RID: 139398 RVA: 0x0095A2A2 File Offset: 0x009584A2
		public unsafe UChildActorComponent _24_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_77);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_77, value);
			}
		}

		// Token: 0x17003E63 RID: 15971
		// (get) Token: 0x06022087 RID: 139399 RVA: 0x0095A2B7 File Offset: 0x009584B7
		// (set) Token: 0x06022088 RID: 139400 RVA: 0x0095A2CB File Offset: 0x009584CB
		public unsafe UChildActorComponent _24_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_78);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_78, value);
			}
		}

		// Token: 0x17003E64 RID: 15972
		// (get) Token: 0x06022089 RID: 139401 RVA: 0x0095A2E0 File Offset: 0x009584E0
		// (set) Token: 0x0602208A RID: 139402 RVA: 0x0095A2F4 File Offset: 0x009584F4
		public unsafe UChildActorComponent _24_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_79);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_79, value);
			}
		}

		// Token: 0x17003E65 RID: 15973
		// (get) Token: 0x0602208B RID: 139403 RVA: 0x0095A309 File Offset: 0x00958509
		// (set) Token: 0x0602208C RID: 139404 RVA: 0x0095A31D File Offset: 0x0095851D
		public unsafe UStaticMeshComponent Cube6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_80);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_80, value);
			}
		}

		// Token: 0x17003E66 RID: 15974
		// (get) Token: 0x0602208D RID: 139405 RVA: 0x0095A332 File Offset: 0x00958532
		// (set) Token: 0x0602208E RID: 139406 RVA: 0x0095A346 File Offset: 0x00958546
		public unsafe UStaticMeshComponent Cube5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_81);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_81, value);
			}
		}

		// Token: 0x17003E67 RID: 15975
		// (get) Token: 0x0602208F RID: 139407 RVA: 0x0095A35B File Offset: 0x0095855B
		// (set) Token: 0x06022090 RID: 139408 RVA: 0x0095A36F File Offset: 0x0095856F
		public unsafe UChildActorComponent _50_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_82);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_82, value);
			}
		}

		// Token: 0x17003E68 RID: 15976
		// (get) Token: 0x06022091 RID: 139409 RVA: 0x0095A384 File Offset: 0x00958584
		// (set) Token: 0x06022092 RID: 139410 RVA: 0x0095A398 File Offset: 0x00958598
		public unsafe UChildActorComponent _50_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_83);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_83, value);
			}
		}

		// Token: 0x17003E69 RID: 15977
		// (get) Token: 0x06022093 RID: 139411 RVA: 0x0095A3AD File Offset: 0x009585AD
		// (set) Token: 0x06022094 RID: 139412 RVA: 0x0095A3C1 File Offset: 0x009585C1
		public unsafe UStaticMeshComponent Cube10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_84);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_84, value);
			}
		}

		// Token: 0x17003E6A RID: 15978
		// (get) Token: 0x06022095 RID: 139413 RVA: 0x0095A3D6 File Offset: 0x009585D6
		// (set) Token: 0x06022096 RID: 139414 RVA: 0x0095A3EA File Offset: 0x009585EA
		public unsafe UStaticMeshComponent Cube9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_85);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_85, value);
			}
		}

		// Token: 0x17003E6B RID: 15979
		// (get) Token: 0x06022097 RID: 139415 RVA: 0x0095A3FF File Offset: 0x009585FF
		// (set) Token: 0x06022098 RID: 139416 RVA: 0x0095A413 File Offset: 0x00958613
		public unsafe UChildActorComponent _50_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_86);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_86, value);
			}
		}

		// Token: 0x17003E6C RID: 15980
		// (get) Token: 0x06022099 RID: 139417 RVA: 0x0095A428 File Offset: 0x00958628
		// (set) Token: 0x0602209A RID: 139418 RVA: 0x0095A43C File Offset: 0x0095863C
		public unsafe UChildActorComponent _50_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_87);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_87, value);
			}
		}

		// Token: 0x17003E6D RID: 15981
		// (get) Token: 0x0602209B RID: 139419 RVA: 0x0095A451 File Offset: 0x00958651
		// (set) Token: 0x0602209C RID: 139420 RVA: 0x0095A465 File Offset: 0x00958665
		public unsafe UChildActorComponent _10_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_88);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_88, value);
			}
		}

		// Token: 0x17003E6E RID: 15982
		// (get) Token: 0x0602209D RID: 139421 RVA: 0x0095A47A File Offset: 0x0095867A
		// (set) Token: 0x0602209E RID: 139422 RVA: 0x0095A48E File Offset: 0x0095868E
		public unsafe UChildActorComponent _10_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_89);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_89, value);
			}
		}

		// Token: 0x17003E6F RID: 15983
		// (get) Token: 0x0602209F RID: 139423 RVA: 0x0095A4A3 File Offset: 0x009586A3
		// (set) Token: 0x060220A0 RID: 139424 RVA: 0x0095A4B7 File Offset: 0x009586B7
		public unsafe UStaticMeshComponent Cube1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_90);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_90, value);
			}
		}

		// Token: 0x17003E70 RID: 15984
		// (get) Token: 0x060220A1 RID: 139425 RVA: 0x0095A4CC File Offset: 0x009586CC
		// (set) Token: 0x060220A2 RID: 139426 RVA: 0x0095A4E0 File Offset: 0x009586E0
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_91);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_91, value);
			}
		}

		// Token: 0x17003E71 RID: 15985
		// (get) Token: 0x060220A3 RID: 139427 RVA: 0x0095A4F5 File Offset: 0x009586F5
		// (set) Token: 0x060220A4 RID: 139428 RVA: 0x0095A509 File Offset: 0x00958709
		public unsafe UChildActorComponent _10_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_92);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_92, value);
			}
		}

		// Token: 0x17003E72 RID: 15986
		// (get) Token: 0x060220A5 RID: 139429 RVA: 0x0095A51E File Offset: 0x0095871E
		// (set) Token: 0x060220A6 RID: 139430 RVA: 0x0095A532 File Offset: 0x00958732
		public unsafe UChildActorComponent _10_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_93);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_93, value);
			}
		}

		// Token: 0x17003E73 RID: 15987
		// (get) Token: 0x060220A7 RID: 139431 RVA: 0x0095A547 File Offset: 0x00958747
		// (set) Token: 0x060220A8 RID: 139432 RVA: 0x0095A55B File Offset: 0x0095875B
		public unsafe UStaticMeshComponent StaticMesh61
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_94);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_94, value);
			}
		}

		// Token: 0x17003E74 RID: 15988
		// (get) Token: 0x060220A9 RID: 139433 RVA: 0x0095A570 File Offset: 0x00958770
		// (set) Token: 0x060220AA RID: 139434 RVA: 0x0095A584 File Offset: 0x00958784
		public unsafe UStaticMeshComponent StaticMesh56
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_95);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_95, value);
			}
		}

		// Token: 0x17003E75 RID: 15989
		// (get) Token: 0x060220AB RID: 139435 RVA: 0x0095A599 File Offset: 0x00958799
		// (set) Token: 0x060220AC RID: 139436 RVA: 0x0095A5AD File Offset: 0x009587AD
		public unsafe UStaticMeshComponent StaticMesh55
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_96);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_96, value);
			}
		}

		// Token: 0x17003E76 RID: 15990
		// (get) Token: 0x060220AD RID: 139437 RVA: 0x0095A5C2 File Offset: 0x009587C2
		// (set) Token: 0x060220AE RID: 139438 RVA: 0x0095A5D6 File Offset: 0x009587D6
		public unsafe UStaticMeshComponent StaticMesh54
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_97);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_97, value);
			}
		}

		// Token: 0x17003E77 RID: 15991
		// (get) Token: 0x060220AF RID: 139439 RVA: 0x0095A5EB File Offset: 0x009587EB
		// (set) Token: 0x060220B0 RID: 139440 RVA: 0x0095A5FF File Offset: 0x009587FF
		public unsafe UStaticMeshComponent StaticMesh53
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_98);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_98, value);
			}
		}

		// Token: 0x17003E78 RID: 15992
		// (get) Token: 0x060220B1 RID: 139441 RVA: 0x0095A614 File Offset: 0x00958814
		// (set) Token: 0x060220B2 RID: 139442 RVA: 0x0095A628 File Offset: 0x00958828
		public unsafe UStaticMeshComponent StaticMesh52
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_99);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_99, value);
			}
		}

		// Token: 0x17003E79 RID: 15993
		// (get) Token: 0x060220B3 RID: 139443 RVA: 0x0095A63D File Offset: 0x0095883D
		// (set) Token: 0x060220B4 RID: 139444 RVA: 0x0095A651 File Offset: 0x00958851
		public unsafe UStaticMeshComponent StaticMesh51
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_100);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_100, value);
			}
		}

		// Token: 0x17003E7A RID: 15994
		// (get) Token: 0x060220B5 RID: 139445 RVA: 0x0095A666 File Offset: 0x00958866
		// (set) Token: 0x060220B6 RID: 139446 RVA: 0x0095A67A File Offset: 0x0095887A
		public unsafe UStaticMeshComponent StaticMesh50
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_101);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_101, value);
			}
		}

		// Token: 0x17003E7B RID: 15995
		// (get) Token: 0x060220B7 RID: 139447 RVA: 0x0095A68F File Offset: 0x0095888F
		// (set) Token: 0x060220B8 RID: 139448 RVA: 0x0095A6A3 File Offset: 0x009588A3
		public unsafe UStaticMeshComponent StaticMesh49
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_102);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_102, value);
			}
		}

		// Token: 0x17003E7C RID: 15996
		// (get) Token: 0x060220B9 RID: 139449 RVA: 0x0095A6B8 File Offset: 0x009588B8
		// (set) Token: 0x060220BA RID: 139450 RVA: 0x0095A6CC File Offset: 0x009588CC
		public unsafe UStaticMeshComponent StaticMesh48
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_103);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_103, value);
			}
		}

		// Token: 0x17003E7D RID: 15997
		// (get) Token: 0x060220BB RID: 139451 RVA: 0x0095A6E1 File Offset: 0x009588E1
		// (set) Token: 0x060220BC RID: 139452 RVA: 0x0095A6F5 File Offset: 0x009588F5
		public unsafe UStaticMeshComponent StaticMesh47
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_104);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_104, value);
			}
		}

		// Token: 0x17003E7E RID: 15998
		// (get) Token: 0x060220BD RID: 139453 RVA: 0x0095A70A File Offset: 0x0095890A
		// (set) Token: 0x060220BE RID: 139454 RVA: 0x0095A71E File Offset: 0x0095891E
		public unsafe UStaticMeshComponent StaticMesh46
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_105);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_105, value);
			}
		}

		// Token: 0x17003E7F RID: 15999
		// (get) Token: 0x060220BF RID: 139455 RVA: 0x0095A733 File Offset: 0x00958933
		// (set) Token: 0x060220C0 RID: 139456 RVA: 0x0095A747 File Offset: 0x00958947
		public unsafe UStaticMeshComponent StaticMesh45
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_106);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_106, value);
			}
		}

		// Token: 0x17003E80 RID: 16000
		// (get) Token: 0x060220C1 RID: 139457 RVA: 0x0095A75C File Offset: 0x0095895C
		// (set) Token: 0x060220C2 RID: 139458 RVA: 0x0095A770 File Offset: 0x00958970
		public unsafe UStaticMeshComponent StaticMesh44
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_107);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_107, value);
			}
		}

		// Token: 0x17003E81 RID: 16001
		// (get) Token: 0x060220C3 RID: 139459 RVA: 0x0095A785 File Offset: 0x00958985
		// (set) Token: 0x060220C4 RID: 139460 RVA: 0x0095A799 File Offset: 0x00958999
		public unsafe UStaticMeshComponent StaticMesh43
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_108);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_108, value);
			}
		}

		// Token: 0x17003E82 RID: 16002
		// (get) Token: 0x060220C5 RID: 139461 RVA: 0x0095A7AE File Offset: 0x009589AE
		// (set) Token: 0x060220C6 RID: 139462 RVA: 0x0095A7C2 File Offset: 0x009589C2
		public unsafe UStaticMeshComponent StaticMesh42
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_109);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_109, value);
			}
		}

		// Token: 0x17003E83 RID: 16003
		// (get) Token: 0x060220C7 RID: 139463 RVA: 0x0095A7D7 File Offset: 0x009589D7
		// (set) Token: 0x060220C8 RID: 139464 RVA: 0x0095A7EB File Offset: 0x009589EB
		public unsafe UStaticMeshComponent StaticMesh41
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_110);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_110, value);
			}
		}

		// Token: 0x17003E84 RID: 16004
		// (get) Token: 0x060220C9 RID: 139465 RVA: 0x0095A800 File Offset: 0x00958A00
		// (set) Token: 0x060220CA RID: 139466 RVA: 0x0095A814 File Offset: 0x00958A14
		public unsafe UStaticMeshComponent StaticMesh40
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_111);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_111, value);
			}
		}

		// Token: 0x17003E85 RID: 16005
		// (get) Token: 0x060220CB RID: 139467 RVA: 0x0095A829 File Offset: 0x00958A29
		// (set) Token: 0x060220CC RID: 139468 RVA: 0x0095A83D File Offset: 0x00958A3D
		public unsafe UStaticMeshComponent StaticMesh39
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_112);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_112, value);
			}
		}

		// Token: 0x17003E86 RID: 16006
		// (get) Token: 0x060220CD RID: 139469 RVA: 0x0095A852 File Offset: 0x00958A52
		// (set) Token: 0x060220CE RID: 139470 RVA: 0x0095A866 File Offset: 0x00958A66
		public unsafe UStaticMeshComponent StaticMesh38
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_113);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_113, value);
			}
		}

		// Token: 0x17003E87 RID: 16007
		// (get) Token: 0x060220CF RID: 139471 RVA: 0x0095A87B File Offset: 0x00958A7B
		// (set) Token: 0x060220D0 RID: 139472 RVA: 0x0095A88F File Offset: 0x00958A8F
		public unsafe UStaticMeshComponent StaticMesh37
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_114);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_114, value);
			}
		}

		// Token: 0x17003E88 RID: 16008
		// (get) Token: 0x060220D1 RID: 139473 RVA: 0x0095A8A4 File Offset: 0x00958AA4
		// (set) Token: 0x060220D2 RID: 139474 RVA: 0x0095A8B8 File Offset: 0x00958AB8
		public unsafe UStaticMeshComponent StaticMesh36
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_115);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_115, value);
			}
		}

		// Token: 0x17003E89 RID: 16009
		// (get) Token: 0x060220D3 RID: 139475 RVA: 0x0095A8CD File Offset: 0x00958ACD
		// (set) Token: 0x060220D4 RID: 139476 RVA: 0x0095A8E1 File Offset: 0x00958AE1
		public unsafe UStaticMeshComponent StaticMesh35
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_116);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_116, value);
			}
		}

		// Token: 0x17003E8A RID: 16010
		// (get) Token: 0x060220D5 RID: 139477 RVA: 0x0095A8F6 File Offset: 0x00958AF6
		// (set) Token: 0x060220D6 RID: 139478 RVA: 0x0095A90A File Offset: 0x00958B0A
		public unsafe UStaticMeshComponent StaticMesh34
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_117);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_117, value);
			}
		}

		// Token: 0x17003E8B RID: 16011
		// (get) Token: 0x060220D7 RID: 139479 RVA: 0x0095A91F File Offset: 0x00958B1F
		// (set) Token: 0x060220D8 RID: 139480 RVA: 0x0095A933 File Offset: 0x00958B33
		public unsafe UStaticMeshComponent StaticMesh33
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_118);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_118, value);
			}
		}

		// Token: 0x17003E8C RID: 16012
		// (get) Token: 0x060220D9 RID: 139481 RVA: 0x0095A948 File Offset: 0x00958B48
		// (set) Token: 0x060220DA RID: 139482 RVA: 0x0095A95C File Offset: 0x00958B5C
		public unsafe UStaticMeshComponent StaticMesh32
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_119);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_119, value);
			}
		}

		// Token: 0x17003E8D RID: 16013
		// (get) Token: 0x060220DB RID: 139483 RVA: 0x0095A971 File Offset: 0x00958B71
		// (set) Token: 0x060220DC RID: 139484 RVA: 0x0095A985 File Offset: 0x00958B85
		public unsafe UStaticMeshComponent StaticMesh31
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_120);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_120, value);
			}
		}

		// Token: 0x17003E8E RID: 16014
		// (get) Token: 0x060220DD RID: 139485 RVA: 0x0095A99A File Offset: 0x00958B9A
		// (set) Token: 0x060220DE RID: 139486 RVA: 0x0095A9AE File Offset: 0x00958BAE
		public unsafe UStaticMeshComponent StaticMesh30
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_121);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_121, value);
			}
		}

		// Token: 0x17003E8F RID: 16015
		// (get) Token: 0x060220DF RID: 139487 RVA: 0x0095A9C3 File Offset: 0x00958BC3
		// (set) Token: 0x060220E0 RID: 139488 RVA: 0x0095A9D7 File Offset: 0x00958BD7
		public unsafe UStaticMeshComponent StaticMesh29
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_122);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_122, value);
			}
		}

		// Token: 0x17003E90 RID: 16016
		// (get) Token: 0x060220E1 RID: 139489 RVA: 0x0095A9EC File Offset: 0x00958BEC
		// (set) Token: 0x060220E2 RID: 139490 RVA: 0x0095AA00 File Offset: 0x00958C00
		public unsafe UStaticMeshComponent StaticMesh28
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_123);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_123, value);
			}
		}

		// Token: 0x17003E91 RID: 16017
		// (get) Token: 0x060220E3 RID: 139491 RVA: 0x0095AA15 File Offset: 0x00958C15
		// (set) Token: 0x060220E4 RID: 139492 RVA: 0x0095AA29 File Offset: 0x00958C29
		public unsafe UStaticMeshComponent StaticMesh27
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_124);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_124, value);
			}
		}

		// Token: 0x17003E92 RID: 16018
		// (get) Token: 0x060220E5 RID: 139493 RVA: 0x0095AA3E File Offset: 0x00958C3E
		// (set) Token: 0x060220E6 RID: 139494 RVA: 0x0095AA52 File Offset: 0x00958C52
		public unsafe UStaticMeshComponent StaticMesh26
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_125);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_125, value);
			}
		}

		// Token: 0x17003E93 RID: 16019
		// (get) Token: 0x060220E7 RID: 139495 RVA: 0x0095AA67 File Offset: 0x00958C67
		// (set) Token: 0x060220E8 RID: 139496 RVA: 0x0095AA7B File Offset: 0x00958C7B
		public unsafe UStaticMeshComponent StaticMesh25
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_126);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_126, value);
			}
		}

		// Token: 0x17003E94 RID: 16020
		// (get) Token: 0x060220E9 RID: 139497 RVA: 0x0095AA90 File Offset: 0x00958C90
		// (set) Token: 0x060220EA RID: 139498 RVA: 0x0095AAA4 File Offset: 0x00958CA4
		public unsafe UStaticMeshComponent StaticMesh24
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_127);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_127, value);
			}
		}

		// Token: 0x17003E95 RID: 16021
		// (get) Token: 0x060220EB RID: 139499 RVA: 0x0095AAB9 File Offset: 0x00958CB9
		// (set) Token: 0x060220EC RID: 139500 RVA: 0x0095AACD File Offset: 0x00958CCD
		public unsafe UStaticMeshComponent StaticMesh23
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_128);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_128, value);
			}
		}

		// Token: 0x17003E96 RID: 16022
		// (get) Token: 0x060220ED RID: 139501 RVA: 0x0095AAE2 File Offset: 0x00958CE2
		// (set) Token: 0x060220EE RID: 139502 RVA: 0x0095AAF6 File Offset: 0x00958CF6
		public unsafe UStaticMeshComponent StaticMesh22
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_129);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_129, value);
			}
		}

		// Token: 0x17003E97 RID: 16023
		// (get) Token: 0x060220EF RID: 139503 RVA: 0x0095AB0B File Offset: 0x00958D0B
		// (set) Token: 0x060220F0 RID: 139504 RVA: 0x0095AB1F File Offset: 0x00958D1F
		public unsafe UStaticMeshComponent StaticMesh21
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_130);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_130, value);
			}
		}

		// Token: 0x17003E98 RID: 16024
		// (get) Token: 0x060220F1 RID: 139505 RVA: 0x0095AB34 File Offset: 0x00958D34
		// (set) Token: 0x060220F2 RID: 139506 RVA: 0x0095AB48 File Offset: 0x00958D48
		public unsafe UStaticMeshComponent StaticMesh20
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_131);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_131, value);
			}
		}

		// Token: 0x17003E99 RID: 16025
		// (get) Token: 0x060220F3 RID: 139507 RVA: 0x0095AB5D File Offset: 0x00958D5D
		// (set) Token: 0x060220F4 RID: 139508 RVA: 0x0095AB71 File Offset: 0x00958D71
		public unsafe UStaticMeshComponent StaticMesh19
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_132);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_132, value);
			}
		}

		// Token: 0x17003E9A RID: 16026
		// (get) Token: 0x060220F5 RID: 139509 RVA: 0x0095AB86 File Offset: 0x00958D86
		// (set) Token: 0x060220F6 RID: 139510 RVA: 0x0095AB9A File Offset: 0x00958D9A
		public unsafe UStaticMeshComponent StaticMesh18
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_133);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_133, value);
			}
		}

		// Token: 0x17003E9B RID: 16027
		// (get) Token: 0x060220F7 RID: 139511 RVA: 0x0095ABAF File Offset: 0x00958DAF
		// (set) Token: 0x060220F8 RID: 139512 RVA: 0x0095ABC3 File Offset: 0x00958DC3
		public unsafe UStaticMeshComponent StaticMesh17
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_134);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_134, value);
			}
		}

		// Token: 0x17003E9C RID: 16028
		// (get) Token: 0x060220F9 RID: 139513 RVA: 0x0095ABD8 File Offset: 0x00958DD8
		// (set) Token: 0x060220FA RID: 139514 RVA: 0x0095ABEC File Offset: 0x00958DEC
		public unsafe UStaticMeshComponent StaticMesh16
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_135);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_135, value);
			}
		}

		// Token: 0x17003E9D RID: 16029
		// (get) Token: 0x060220FB RID: 139515 RVA: 0x0095AC01 File Offset: 0x00958E01
		// (set) Token: 0x060220FC RID: 139516 RVA: 0x0095AC15 File Offset: 0x00958E15
		public unsafe UStaticMeshComponent StaticMesh15
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_136);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_136, value);
			}
		}

		// Token: 0x17003E9E RID: 16030
		// (get) Token: 0x060220FD RID: 139517 RVA: 0x0095AC2A File Offset: 0x00958E2A
		// (set) Token: 0x060220FE RID: 139518 RVA: 0x0095AC3E File Offset: 0x00958E3E
		public unsafe UStaticMeshComponent StaticMesh14
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_137);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_137, value);
			}
		}

		// Token: 0x17003E9F RID: 16031
		// (get) Token: 0x060220FF RID: 139519 RVA: 0x0095AC53 File Offset: 0x00958E53
		// (set) Token: 0x06022100 RID: 139520 RVA: 0x0095AC67 File Offset: 0x00958E67
		public unsafe UStaticMeshComponent StaticMesh13
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_138);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_138, value);
			}
		}

		// Token: 0x17003EA0 RID: 16032
		// (get) Token: 0x06022101 RID: 139521 RVA: 0x0095AC7C File Offset: 0x00958E7C
		// (set) Token: 0x06022102 RID: 139522 RVA: 0x0095AC90 File Offset: 0x00958E90
		public unsafe UStaticMeshComponent StaticMesh12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_139);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_139, value);
			}
		}

		// Token: 0x17003EA1 RID: 16033
		// (get) Token: 0x06022103 RID: 139523 RVA: 0x0095ACA5 File Offset: 0x00958EA5
		// (set) Token: 0x06022104 RID: 139524 RVA: 0x0095ACB9 File Offset: 0x00958EB9
		public unsafe UStaticMeshComponent StaticMesh11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_140);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_140, value);
			}
		}

		// Token: 0x17003EA2 RID: 16034
		// (get) Token: 0x06022105 RID: 139525 RVA: 0x0095ACCE File Offset: 0x00958ECE
		// (set) Token: 0x06022106 RID: 139526 RVA: 0x0095ACE2 File Offset: 0x00958EE2
		public unsafe UStaticMeshComponent StaticMesh10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_141);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_141, value);
			}
		}

		// Token: 0x17003EA3 RID: 16035
		// (get) Token: 0x06022107 RID: 139527 RVA: 0x0095ACF7 File Offset: 0x00958EF7
		// (set) Token: 0x06022108 RID: 139528 RVA: 0x0095AD0B File Offset: 0x00958F0B
		public unsafe UStaticMeshComponent StaticMesh09
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_142);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_142, value);
			}
		}

		// Token: 0x17003EA4 RID: 16036
		// (get) Token: 0x06022109 RID: 139529 RVA: 0x0095AD20 File Offset: 0x00958F20
		// (set) Token: 0x0602210A RID: 139530 RVA: 0x0095AD34 File Offset: 0x00958F34
		public unsafe UStaticMeshComponent StaticMesh08
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_143);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_143, value);
			}
		}

		// Token: 0x17003EA5 RID: 16037
		// (get) Token: 0x0602210B RID: 139531 RVA: 0x0095AD49 File Offset: 0x00958F49
		// (set) Token: 0x0602210C RID: 139532 RVA: 0x0095AD5D File Offset: 0x00958F5D
		public unsafe UStaticMeshComponent StaticMesh07
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_144);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_144, value);
			}
		}

		// Token: 0x17003EA6 RID: 16038
		// (get) Token: 0x0602210D RID: 139533 RVA: 0x0095AD72 File Offset: 0x00958F72
		// (set) Token: 0x0602210E RID: 139534 RVA: 0x0095AD86 File Offset: 0x00958F86
		public unsafe UStaticMeshComponent StaticMesh06
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_145);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_145, value);
			}
		}

		// Token: 0x17003EA7 RID: 16039
		// (get) Token: 0x0602210F RID: 139535 RVA: 0x0095AD9B File Offset: 0x00958F9B
		// (set) Token: 0x06022110 RID: 139536 RVA: 0x0095ADAF File Offset: 0x00958FAF
		public unsafe UStaticMeshComponent StaticMesh05
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_146);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_146, value);
			}
		}

		// Token: 0x17003EA8 RID: 16040
		// (get) Token: 0x06022111 RID: 139537 RVA: 0x0095ADC4 File Offset: 0x00958FC4
		// (set) Token: 0x06022112 RID: 139538 RVA: 0x0095ADD8 File Offset: 0x00958FD8
		public unsafe UStaticMeshComponent StaticMesh04
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_147);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_147, value);
			}
		}

		// Token: 0x17003EA9 RID: 16041
		// (get) Token: 0x06022113 RID: 139539 RVA: 0x0095ADED File Offset: 0x00958FED
		// (set) Token: 0x06022114 RID: 139540 RVA: 0x0095AE01 File Offset: 0x00959001
		public unsafe UStaticMeshComponent StaticMesh03
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_148);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_148, value);
			}
		}

		// Token: 0x17003EAA RID: 16042
		// (get) Token: 0x06022115 RID: 139541 RVA: 0x0095AE16 File Offset: 0x00959016
		// (set) Token: 0x06022116 RID: 139542 RVA: 0x0095AE2A File Offset: 0x0095902A
		public unsafe UStaticMeshComponent StaticMesh02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_149);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_149, value);
			}
		}

		// Token: 0x17003EAB RID: 16043
		// (get) Token: 0x06022117 RID: 139543 RVA: 0x0095AE3F File Offset: 0x0095903F
		// (set) Token: 0x06022118 RID: 139544 RVA: 0x0095AE53 File Offset: 0x00959053
		public unsafe UStaticMeshComponent StaticMesh01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_150);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_150, value);
			}
		}

		// Token: 0x17003EAC RID: 16044
		// (get) Token: 0x06022119 RID: 139545 RVA: 0x0095AE68 File Offset: 0x00959068
		// (set) Token: 0x0602211A RID: 139546 RVA: 0x0095AE7C File Offset: 0x0095907C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_151);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_3_5_C.__PropertyOffset_151, value);
			}
		}

		// Token: 0x17003EAD RID: 16045
		// (get) Token: 0x0602211B RID: 139547 RVA: 0x0095AE94 File Offset: 0x00959094
		// (set) Token: 0x0602211C RID: 139548 RVA: 0x0095AECD File Offset: 0x009590CD
		[Nullable(1)]
		public custom custom
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				custom result;
				if ((result = this._custom) == null)
				{
					result = (this._custom = new custom(base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_152, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_152, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17003EAE RID: 16046
		// (get) Token: 0x0602211D RID: 139549 RVA: 0x0095AEEE File Offset: 0x009590EE
		// (set) Token: 0x0602211E RID: 139550 RVA: 0x0095AF02 File Offset: 0x00959102
		public unsafe FVector NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_153);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_153) = value;
			}
		}

		// Token: 0x17003EAF RID: 16047
		// (get) Token: 0x0602211F RID: 139551 RVA: 0x0095AF18 File Offset: 0x00959118
		// (set) Token: 0x06022120 RID: 139552 RVA: 0x0095AF51 File Offset: 0x00959151
		[Nullable(1)]
		public TArray<UStaticMeshComponent> BlockList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._BlockList) == null)
				{
					result = (this._BlockList = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_154, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BlockList.CopyAssign(value);
			}
		}

		// Token: 0x17003EB0 RID: 16048
		// (get) Token: 0x06022121 RID: 139553 RVA: 0x0095AF60 File Offset: 0x00959160
		// (set) Token: 0x06022122 RID: 139554 RVA: 0x0095AF99 File Offset: 0x00959199
		[Nullable(1)]
		public TArray<UChildActorComponent> PinArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UChildActorComponent> result;
				if ((result = this._PinArray) == null)
				{
					result = (this._PinArray = new TArray<UChildActorComponent>(base.NativePtr + (IntPtr)BP_BridgeModels_3_5_C.__PropertyOffset_155, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.PinArray.CopyAssign(value);
			}
		}

		// Token: 0x06022123 RID: 139555 RVA: 0x0095AFA8 File Offset: 0x009591A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPlankVisible(bool IsInRange)
		{
			BP_BridgeModels_3_5_C.__SetPlankVisible_FunctionParams* ptr = stackalloc BP_BridgeModels_3_5_C.__SetPlankVisible_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_BridgeModels_3_5_C.__SetPlankVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_3_5_C.__SetPlankVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsInRange = IsInRange;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__SetPlankVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022124 RID: 139556 RVA: 0x0095AFEE File Offset: 0x009591EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RecoverBlock()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__RecoverBlock_NativeFunctionPtr, null);
		}

		// Token: 0x06022125 RID: 139557 RVA: 0x0095B004 File Offset: 0x00959204
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSideBlockColli(bool IsBreak)
		{
			BP_BridgeModels_3_5_C.__SetSideBlockColli_FunctionParams* ptr = stackalloc BP_BridgeModels_3_5_C.__SetSideBlockColli_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BridgeModels_3_5_C.__SetSideBlockColli_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_3_5_C.__SetSideBlockColli_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsBreak = IsBreak;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__SetSideBlockColli_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022126 RID: 139558 RVA: 0x0095B04C File Offset: 0x0095924C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBridgeLink(int idx, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UChildActorComponent> tempArray1)
		{
			BP_BridgeModels_3_5_C.__GetBridgeLink_FunctionParams* ptr = stackalloc BP_BridgeModels_3_5_C.__GetBridgeLink_FunctionParams[(UIntPtr)287] + 15L / (long)sizeof(BP_BridgeModels_3_5_C.__GetBridgeLink_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_3_5_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
			ptr->idx = idx;
			TArray<UChildActorComponent> tarray = tempArray1;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->tempArray1);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr);
			TArray<UChildActorComponent> tarray2 = tempArray1;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->tempArray1);
			}
			UnrealReflectionUtils.DestroyStruct(BP_BridgeModels_3_5_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06022127 RID: 139559 RVA: 0x0095B0CE File Offset: 0x009592CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022128 RID: 139560 RVA: 0x0095B0E2 File Offset: 0x009592E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022129 RID: 139561 RVA: 0x0095B0F7 File Offset: 0x009592F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602212A RID: 139562 RVA: 0x0095B10B File Offset: 0x0095930B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602212B RID: 139563 RVA: 0x0095B120 File Offset: 0x00959320
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602212C RID: 139564 RVA: 0x0095B1AC File Offset: 0x009593AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602212D RID: 139565 RVA: 0x0095B268 File Offset: 0x00959468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BridgeModels_3_5(int EntryPoint)
		{
			BP_BridgeModels_3_5_C.__ExecuteUbergraph_BP_BridgeModels_3_5_FunctionParams* ptr = stackalloc BP_BridgeModels_3_5_C.__ExecuteUbergraph_BP_BridgeModels_3_5_FunctionParams[(UIntPtr)351] + 15L / (long)sizeof(BP_BridgeModels_3_5_C.__ExecuteUbergraph_BP_BridgeModels_3_5_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_3_5_C.__ExecuteUbergraph_BP_BridgeModels_3_5_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_3_5_C.__ExecuteUbergraph_BP_BridgeModels_3_5_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602212E RID: 139566 RVA: 0x0095B2B2 File Offset: 0x009594B2
		protected BP_BridgeModels_3_5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040112BC RID: 70332
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_3_5.BP_BridgeModels_3_5_C";

		// Token: 0x040112BD RID: 70333
		private static IntPtr _ClassPtr;

		// Token: 0x040112BE RID: 70334
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040112BF RID: 70335
		public static IntPtr __custom__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040112C0 RID: 70336
		internal static int __PropertyOffset_0;

		// Token: 0x040112C1 RID: 70337
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040112C2 RID: 70338
		internal static int __PropertyOffset_1;

		// Token: 0x040112C3 RID: 70339
		internal static int __PropertyOffset_2;

		// Token: 0x040112C4 RID: 70340
		internal static int __PropertyOffset_3;

		// Token: 0x040112C5 RID: 70341
		internal static int __PropertyOffset_4;

		// Token: 0x040112C6 RID: 70342
		internal static int __PropertyOffset_5;

		// Token: 0x040112C7 RID: 70343
		internal static int __PropertyOffset_6;

		// Token: 0x040112C8 RID: 70344
		internal static int __PropertyOffset_7;

		// Token: 0x040112C9 RID: 70345
		internal static int __PropertyOffset_8;

		// Token: 0x040112CA RID: 70346
		internal static int __PropertyOffset_9;

		// Token: 0x040112CB RID: 70347
		internal static int __PropertyOffset_10;

		// Token: 0x040112CC RID: 70348
		internal static int __PropertyOffset_11;

		// Token: 0x040112CD RID: 70349
		internal static int __PropertyOffset_12;

		// Token: 0x040112CE RID: 70350
		internal static int __PropertyOffset_13;

		// Token: 0x040112CF RID: 70351
		internal static int __PropertyOffset_14;

		// Token: 0x040112D0 RID: 70352
		internal static int __PropertyOffset_15;

		// Token: 0x040112D1 RID: 70353
		internal static int __PropertyOffset_16;

		// Token: 0x040112D2 RID: 70354
		internal static int __PropertyOffset_17;

		// Token: 0x040112D3 RID: 70355
		internal static int __PropertyOffset_18;

		// Token: 0x040112D4 RID: 70356
		internal static int __PropertyOffset_19;

		// Token: 0x040112D5 RID: 70357
		internal static int __PropertyOffset_20;

		// Token: 0x040112D6 RID: 70358
		internal static int __PropertyOffset_21;

		// Token: 0x040112D7 RID: 70359
		internal static int __PropertyOffset_22;

		// Token: 0x040112D8 RID: 70360
		internal static int __PropertyOffset_23;

		// Token: 0x040112D9 RID: 70361
		internal static int __PropertyOffset_24;

		// Token: 0x040112DA RID: 70362
		internal static int __PropertyOffset_25;

		// Token: 0x040112DB RID: 70363
		internal static int __PropertyOffset_26;

		// Token: 0x040112DC RID: 70364
		internal static int __PropertyOffset_27;

		// Token: 0x040112DD RID: 70365
		internal static int __PropertyOffset_28;

		// Token: 0x040112DE RID: 70366
		internal static int __PropertyOffset_29;

		// Token: 0x040112DF RID: 70367
		internal static int __PropertyOffset_30;

		// Token: 0x040112E0 RID: 70368
		internal static int __PropertyOffset_31;

		// Token: 0x040112E1 RID: 70369
		internal static int __PropertyOffset_32;

		// Token: 0x040112E2 RID: 70370
		internal static int __PropertyOffset_33;

		// Token: 0x040112E3 RID: 70371
		internal static int __PropertyOffset_34;

		// Token: 0x040112E4 RID: 70372
		internal static int __PropertyOffset_35;

		// Token: 0x040112E5 RID: 70373
		internal static int __PropertyOffset_36;

		// Token: 0x040112E6 RID: 70374
		internal static int __PropertyOffset_37;

		// Token: 0x040112E7 RID: 70375
		internal static int __PropertyOffset_38;

		// Token: 0x040112E8 RID: 70376
		internal static int __PropertyOffset_39;

		// Token: 0x040112E9 RID: 70377
		internal static int __PropertyOffset_40;

		// Token: 0x040112EA RID: 70378
		internal static int __PropertyOffset_41;

		// Token: 0x040112EB RID: 70379
		internal static int __PropertyOffset_42;

		// Token: 0x040112EC RID: 70380
		internal static int __PropertyOffset_43;

		// Token: 0x040112ED RID: 70381
		internal static int __PropertyOffset_44;

		// Token: 0x040112EE RID: 70382
		internal static int __PropertyOffset_45;

		// Token: 0x040112EF RID: 70383
		internal static int __PropertyOffset_46;

		// Token: 0x040112F0 RID: 70384
		internal static int __PropertyOffset_47;

		// Token: 0x040112F1 RID: 70385
		internal static int __PropertyOffset_48;

		// Token: 0x040112F2 RID: 70386
		internal static int __PropertyOffset_49;

		// Token: 0x040112F3 RID: 70387
		internal static int __PropertyOffset_50;

		// Token: 0x040112F4 RID: 70388
		internal static int __PropertyOffset_51;

		// Token: 0x040112F5 RID: 70389
		internal static int __PropertyOffset_52;

		// Token: 0x040112F6 RID: 70390
		internal static int __PropertyOffset_53;

		// Token: 0x040112F7 RID: 70391
		internal static int __PropertyOffset_54;

		// Token: 0x040112F8 RID: 70392
		internal static int __PropertyOffset_55;

		// Token: 0x040112F9 RID: 70393
		internal static int __PropertyOffset_56;

		// Token: 0x040112FA RID: 70394
		internal static int __PropertyOffset_57;

		// Token: 0x040112FB RID: 70395
		internal static int __PropertyOffset_58;

		// Token: 0x040112FC RID: 70396
		internal static int __PropertyOffset_59;

		// Token: 0x040112FD RID: 70397
		internal static int __PropertyOffset_60;

		// Token: 0x040112FE RID: 70398
		internal static int __PropertyOffset_61;

		// Token: 0x040112FF RID: 70399
		internal static int __PropertyOffset_62;

		// Token: 0x04011300 RID: 70400
		internal static int __PropertyOffset_63;

		// Token: 0x04011301 RID: 70401
		internal static int __PropertyOffset_64;

		// Token: 0x04011302 RID: 70402
		internal static int __PropertyOffset_65;

		// Token: 0x04011303 RID: 70403
		internal static int __PropertyOffset_66;

		// Token: 0x04011304 RID: 70404
		internal static int __PropertyOffset_67;

		// Token: 0x04011305 RID: 70405
		internal static int __PropertyOffset_68;

		// Token: 0x04011306 RID: 70406
		internal static int __PropertyOffset_69;

		// Token: 0x04011307 RID: 70407
		internal static int __PropertyOffset_70;

		// Token: 0x04011308 RID: 70408
		internal static int __PropertyOffset_71;

		// Token: 0x04011309 RID: 70409
		internal static int __PropertyOffset_72;

		// Token: 0x0401130A RID: 70410
		internal static int __PropertyOffset_73;

		// Token: 0x0401130B RID: 70411
		internal static int __PropertyOffset_74;

		// Token: 0x0401130C RID: 70412
		internal static int __PropertyOffset_75;

		// Token: 0x0401130D RID: 70413
		internal static int __PropertyOffset_76;

		// Token: 0x0401130E RID: 70414
		internal static int __PropertyOffset_77;

		// Token: 0x0401130F RID: 70415
		internal static int __PropertyOffset_78;

		// Token: 0x04011310 RID: 70416
		internal static int __PropertyOffset_79;

		// Token: 0x04011311 RID: 70417
		internal static int __PropertyOffset_80;

		// Token: 0x04011312 RID: 70418
		internal static int __PropertyOffset_81;

		// Token: 0x04011313 RID: 70419
		internal static int __PropertyOffset_82;

		// Token: 0x04011314 RID: 70420
		internal static int __PropertyOffset_83;

		// Token: 0x04011315 RID: 70421
		internal static int __PropertyOffset_84;

		// Token: 0x04011316 RID: 70422
		internal static int __PropertyOffset_85;

		// Token: 0x04011317 RID: 70423
		internal static int __PropertyOffset_86;

		// Token: 0x04011318 RID: 70424
		internal static int __PropertyOffset_87;

		// Token: 0x04011319 RID: 70425
		internal static int __PropertyOffset_88;

		// Token: 0x0401131A RID: 70426
		internal static int __PropertyOffset_89;

		// Token: 0x0401131B RID: 70427
		internal static int __PropertyOffset_90;

		// Token: 0x0401131C RID: 70428
		internal static int __PropertyOffset_91;

		// Token: 0x0401131D RID: 70429
		internal static int __PropertyOffset_92;

		// Token: 0x0401131E RID: 70430
		internal static int __PropertyOffset_93;

		// Token: 0x0401131F RID: 70431
		internal static int __PropertyOffset_94;

		// Token: 0x04011320 RID: 70432
		internal static int __PropertyOffset_95;

		// Token: 0x04011321 RID: 70433
		internal static int __PropertyOffset_96;

		// Token: 0x04011322 RID: 70434
		internal static int __PropertyOffset_97;

		// Token: 0x04011323 RID: 70435
		internal static int __PropertyOffset_98;

		// Token: 0x04011324 RID: 70436
		internal static int __PropertyOffset_99;

		// Token: 0x04011325 RID: 70437
		internal static int __PropertyOffset_100;

		// Token: 0x04011326 RID: 70438
		internal static int __PropertyOffset_101;

		// Token: 0x04011327 RID: 70439
		internal static int __PropertyOffset_102;

		// Token: 0x04011328 RID: 70440
		internal static int __PropertyOffset_103;

		// Token: 0x04011329 RID: 70441
		internal static int __PropertyOffset_104;

		// Token: 0x0401132A RID: 70442
		internal static int __PropertyOffset_105;

		// Token: 0x0401132B RID: 70443
		internal static int __PropertyOffset_106;

		// Token: 0x0401132C RID: 70444
		internal static int __PropertyOffset_107;

		// Token: 0x0401132D RID: 70445
		internal static int __PropertyOffset_108;

		// Token: 0x0401132E RID: 70446
		internal static int __PropertyOffset_109;

		// Token: 0x0401132F RID: 70447
		internal static int __PropertyOffset_110;

		// Token: 0x04011330 RID: 70448
		internal static int __PropertyOffset_111;

		// Token: 0x04011331 RID: 70449
		internal static int __PropertyOffset_112;

		// Token: 0x04011332 RID: 70450
		internal static int __PropertyOffset_113;

		// Token: 0x04011333 RID: 70451
		internal static int __PropertyOffset_114;

		// Token: 0x04011334 RID: 70452
		internal static int __PropertyOffset_115;

		// Token: 0x04011335 RID: 70453
		internal static int __PropertyOffset_116;

		// Token: 0x04011336 RID: 70454
		internal static int __PropertyOffset_117;

		// Token: 0x04011337 RID: 70455
		internal static int __PropertyOffset_118;

		// Token: 0x04011338 RID: 70456
		internal static int __PropertyOffset_119;

		// Token: 0x04011339 RID: 70457
		internal static int __PropertyOffset_120;

		// Token: 0x0401133A RID: 70458
		internal static int __PropertyOffset_121;

		// Token: 0x0401133B RID: 70459
		internal static int __PropertyOffset_122;

		// Token: 0x0401133C RID: 70460
		internal static int __PropertyOffset_123;

		// Token: 0x0401133D RID: 70461
		internal static int __PropertyOffset_124;

		// Token: 0x0401133E RID: 70462
		internal static int __PropertyOffset_125;

		// Token: 0x0401133F RID: 70463
		internal static int __PropertyOffset_126;

		// Token: 0x04011340 RID: 70464
		internal static int __PropertyOffset_127;

		// Token: 0x04011341 RID: 70465
		internal static int __PropertyOffset_128;

		// Token: 0x04011342 RID: 70466
		internal static int __PropertyOffset_129;

		// Token: 0x04011343 RID: 70467
		internal static int __PropertyOffset_130;

		// Token: 0x04011344 RID: 70468
		internal static int __PropertyOffset_131;

		// Token: 0x04011345 RID: 70469
		internal static int __PropertyOffset_132;

		// Token: 0x04011346 RID: 70470
		internal static int __PropertyOffset_133;

		// Token: 0x04011347 RID: 70471
		internal static int __PropertyOffset_134;

		// Token: 0x04011348 RID: 70472
		internal static int __PropertyOffset_135;

		// Token: 0x04011349 RID: 70473
		internal static int __PropertyOffset_136;

		// Token: 0x0401134A RID: 70474
		internal static int __PropertyOffset_137;

		// Token: 0x0401134B RID: 70475
		internal static int __PropertyOffset_138;

		// Token: 0x0401134C RID: 70476
		internal static int __PropertyOffset_139;

		// Token: 0x0401134D RID: 70477
		internal static int __PropertyOffset_140;

		// Token: 0x0401134E RID: 70478
		internal static int __PropertyOffset_141;

		// Token: 0x0401134F RID: 70479
		internal static int __PropertyOffset_142;

		// Token: 0x04011350 RID: 70480
		internal static int __PropertyOffset_143;

		// Token: 0x04011351 RID: 70481
		internal static int __PropertyOffset_144;

		// Token: 0x04011352 RID: 70482
		internal static int __PropertyOffset_145;

		// Token: 0x04011353 RID: 70483
		internal static int __PropertyOffset_146;

		// Token: 0x04011354 RID: 70484
		internal static int __PropertyOffset_147;

		// Token: 0x04011355 RID: 70485
		internal static int __PropertyOffset_148;

		// Token: 0x04011356 RID: 70486
		internal static int __PropertyOffset_149;

		// Token: 0x04011357 RID: 70487
		internal static int __PropertyOffset_150;

		// Token: 0x04011358 RID: 70488
		internal static int __PropertyOffset_151;

		// Token: 0x04011359 RID: 70489
		internal static int __PropertyOffset_152;

		// Token: 0x0401135A RID: 70490
		private custom _custom;

		// Token: 0x0401135B RID: 70491
		internal static int __PropertyOffset_153;

		// Token: 0x0401135C RID: 70492
		internal static int __PropertyOffset_154;

		// Token: 0x0401135D RID: 70493
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _BlockList;

		// Token: 0x0401135E RID: 70494
		internal static int __PropertyOffset_155;

		// Token: 0x0401135F RID: 70495
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UChildActorComponent> _PinArray;

		// Token: 0x04011360 RID: 70496
		private static IntPtr __SetPlankVisible_NativeFunctionPtr;

		// Token: 0x04011361 RID: 70497
		private static IntPtr __RecoverBlock_NativeFunctionPtr;

		// Token: 0x04011362 RID: 70498
		private static IntPtr __SetSideBlockColli_NativeFunctionPtr;

		// Token: 0x04011363 RID: 70499
		private static IntPtr __GetBridgeLink_NativeFunctionPtr;

		// Token: 0x04011364 RID: 70500
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011365 RID: 70501
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011366 RID: 70502
		private static IntPtr __BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011367 RID: 70503
		private static IntPtr __BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011368 RID: 70504
		private static IntPtr __ExecuteUbergraph_BP_BridgeModels_3_5_NativeFunctionPtr;

		// Token: 0x02009B84 RID: 39812
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __SetPlankVisible_FunctionParams
		{
			// Token: 0x0403237D RID: 205693
			[FieldOffset(0)]
			public bool IsInRange;
		}

		// Token: 0x02009B85 RID: 39813
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetSideBlockColli_FunctionParams
		{
			// Token: 0x0403237E RID: 205694
			[FieldOffset(0)]
			public bool IsBreak;
		}

		// Token: 0x02009B86 RID: 39814
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 272)]
		protected ref struct __GetBridgeLink_FunctionParams
		{
			// Token: 0x0403237F RID: 205695
			[FieldOffset(0)]
			public int idx;

			// Token: 0x04032380 RID: 205696
			[FieldOffset(8)]
			public byte tempArray1;
		}

		// Token: 0x02009B87 RID: 39815
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_0_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032381 RID: 205697
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032382 RID: 205698
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032383 RID: 205699
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032384 RID: 205700
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B88 RID: 39816
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_BridgeModels_3_5_LODRangeBox_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032385 RID: 205701
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032386 RID: 205702
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032387 RID: 205703
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032388 RID: 205704
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032389 RID: 205705
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403238A RID: 205706
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B89 RID: 39817
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 336)]
		protected ref struct __ExecuteUbergraph_BP_BridgeModels_3_5_FunctionParams
		{
			// Token: 0x0403238B RID: 205707
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
