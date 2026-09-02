using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BB1 RID: 15281
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels.BP_BridgeModels_C")]
	[UnrealStructLayout(1576, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1576)]
	public class BP_BridgeModels_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602222A RID: 139818 RVA: 0x0095CB40 File Offset: 0x0095AD40
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BridgeModels_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels.BP_BridgeModels_C");
			}
			return BP_BridgeModels_C._ClassPtr;
		}

		// Token: 0x0602222B RID: 139819 RVA: 0x0095CB64 File Offset: 0x0095AD64
		public BP_BridgeModels_C() : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602222C RID: 139820 RVA: 0x0095CB8C File Offset: 0x0095AD8C
		[NullableContext(1)]
		public BP_BridgeModels_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003F1F RID: 16159
		// (get) Token: 0x0602222D RID: 139821 RVA: 0x0095CBBF File Offset: 0x0095ADBF
		// (set) Token: 0x0602222E RID: 139822 RVA: 0x0095CBD3 File Offset: 0x0095ADD3
		public unsafe UStaticMeshComponent Cube1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003F20 RID: 16160
		// (get) Token: 0x0602222F RID: 139823 RVA: 0x0095CBE8 File Offset: 0x0095ADE8
		// (set) Token: 0x06022230 RID: 139824 RVA: 0x0095CBFC File Offset: 0x0095ADFC
		public unsafe UStaticMeshComponent Cube3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003F21 RID: 16161
		// (get) Token: 0x06022231 RID: 139825 RVA: 0x0095CC11 File Offset: 0x0095AE11
		// (set) Token: 0x06022232 RID: 139826 RVA: 0x0095CC25 File Offset: 0x0095AE25
		public unsafe UStaticMeshComponent Cube6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003F22 RID: 16162
		// (get) Token: 0x06022233 RID: 139827 RVA: 0x0095CC3A File Offset: 0x0095AE3A
		// (set) Token: 0x06022234 RID: 139828 RVA: 0x0095CC4E File Offset: 0x0095AE4E
		public unsafe UStaticMeshComponent Cube8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003F23 RID: 16163
		// (get) Token: 0x06022235 RID: 139829 RVA: 0x0095CC63 File Offset: 0x0095AE63
		// (set) Token: 0x06022236 RID: 139830 RVA: 0x0095CC77 File Offset: 0x0095AE77
		public unsafe UStaticMeshComponent Cube7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003F24 RID: 16164
		// (get) Token: 0x06022237 RID: 139831 RVA: 0x0095CC8C File Offset: 0x0095AE8C
		// (set) Token: 0x06022238 RID: 139832 RVA: 0x0095CCA0 File Offset: 0x0095AEA0
		public unsafe UStaticMeshComponent Cube5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003F25 RID: 16165
		// (get) Token: 0x06022239 RID: 139833 RVA: 0x0095CCB5 File Offset: 0x0095AEB5
		// (set) Token: 0x0602223A RID: 139834 RVA: 0x0095CCC9 File Offset: 0x0095AEC9
		public unsafe UStaticMeshComponent Cube2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003F26 RID: 16166
		// (get) Token: 0x0602223B RID: 139835 RVA: 0x0095CCDE File Offset: 0x0095AEDE
		// (set) Token: 0x0602223C RID: 139836 RVA: 0x0095CCF2 File Offset: 0x0095AEF2
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003F27 RID: 16167
		// (get) Token: 0x0602223D RID: 139837 RVA: 0x0095CD07 File Offset: 0x0095AF07
		// (set) Token: 0x0602223E RID: 139838 RVA: 0x0095CD1B File Offset: 0x0095AF1B
		public unsafe UChildActorComponent _05_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003F28 RID: 16168
		// (get) Token: 0x0602223F RID: 139839 RVA: 0x0095CD30 File Offset: 0x0095AF30
		// (set) Token: 0x06022240 RID: 139840 RVA: 0x0095CD44 File Offset: 0x0095AF44
		public unsafe UChildActorComponent _05_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003F29 RID: 16169
		// (get) Token: 0x06022241 RID: 139841 RVA: 0x0095CD59 File Offset: 0x0095AF59
		// (set) Token: 0x06022242 RID: 139842 RVA: 0x0095CD6D File Offset: 0x0095AF6D
		public unsafe UChildActorComponent _05_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003F2A RID: 16170
		// (get) Token: 0x06022243 RID: 139843 RVA: 0x0095CD82 File Offset: 0x0095AF82
		// (set) Token: 0x06022244 RID: 139844 RVA: 0x0095CD96 File Offset: 0x0095AF96
		public unsafe UChildActorComponent _05_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003F2B RID: 16171
		// (get) Token: 0x06022245 RID: 139845 RVA: 0x0095CDAB File Offset: 0x0095AFAB
		// (set) Token: 0x06022246 RID: 139846 RVA: 0x0095CDBF File Offset: 0x0095AFBF
		public unsafe UChildActorComponent _37_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003F2C RID: 16172
		// (get) Token: 0x06022247 RID: 139847 RVA: 0x0095CDD4 File Offset: 0x0095AFD4
		// (set) Token: 0x06022248 RID: 139848 RVA: 0x0095CDE8 File Offset: 0x0095AFE8
		public unsafe UChildActorComponent _37_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003F2D RID: 16173
		// (get) Token: 0x06022249 RID: 139849 RVA: 0x0095CDFD File Offset: 0x0095AFFD
		// (set) Token: 0x0602224A RID: 139850 RVA: 0x0095CE11 File Offset: 0x0095B011
		public unsafe UChildActorComponent _27_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003F2E RID: 16174
		// (get) Token: 0x0602224B RID: 139851 RVA: 0x0095CE26 File Offset: 0x0095B026
		// (set) Token: 0x0602224C RID: 139852 RVA: 0x0095CE3A File Offset: 0x0095B03A
		public unsafe UChildActorComponent _27_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003F2F RID: 16175
		// (get) Token: 0x0602224D RID: 139853 RVA: 0x0095CE4F File Offset: 0x0095B04F
		// (set) Token: 0x0602224E RID: 139854 RVA: 0x0095CE63 File Offset: 0x0095B063
		public unsafe UChildActorComponent _15_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003F30 RID: 16176
		// (get) Token: 0x0602224F RID: 139855 RVA: 0x0095CE78 File Offset: 0x0095B078
		// (set) Token: 0x06022250 RID: 139856 RVA: 0x0095CE8C File Offset: 0x0095B08C
		public unsafe UChildActorComponent _15_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003F31 RID: 16177
		// (get) Token: 0x06022251 RID: 139857 RVA: 0x0095CEA1 File Offset: 0x0095B0A1
		// (set) Token: 0x06022252 RID: 139858 RVA: 0x0095CEB5 File Offset: 0x0095B0B5
		public unsafe UChildActorComponent _15_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003F32 RID: 16178
		// (get) Token: 0x06022253 RID: 139859 RVA: 0x0095CECA File Offset: 0x0095B0CA
		// (set) Token: 0x06022254 RID: 139860 RVA: 0x0095CEDE File Offset: 0x0095B0DE
		public unsafe UChildActorComponent _15_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003F33 RID: 16179
		// (get) Token: 0x06022255 RID: 139861 RVA: 0x0095CEF3 File Offset: 0x0095B0F3
		// (set) Token: 0x06022256 RID: 139862 RVA: 0x0095CF07 File Offset: 0x0095B107
		public unsafe UChildActorComponent _37_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003F34 RID: 16180
		// (get) Token: 0x06022257 RID: 139863 RVA: 0x0095CF1C File Offset: 0x0095B11C
		// (set) Token: 0x06022258 RID: 139864 RVA: 0x0095CF30 File Offset: 0x0095B130
		public unsafe UChildActorComponent _37_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003F35 RID: 16181
		// (get) Token: 0x06022259 RID: 139865 RVA: 0x0095CF45 File Offset: 0x0095B145
		// (set) Token: 0x0602225A RID: 139866 RVA: 0x0095CF59 File Offset: 0x0095B159
		public unsafe UChildActorComponent _27_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003F36 RID: 16182
		// (get) Token: 0x0602225B RID: 139867 RVA: 0x0095CF6E File Offset: 0x0095B16E
		// (set) Token: 0x0602225C RID: 139868 RVA: 0x0095CF82 File Offset: 0x0095B182
		public unsafe UChildActorComponent _27_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003F37 RID: 16183
		// (get) Token: 0x0602225D RID: 139869 RVA: 0x0095CF97 File Offset: 0x0095B197
		// (set) Token: 0x0602225E RID: 139870 RVA: 0x0095CFAB File Offset: 0x0095B1AB
		public unsafe UStaticMeshComponent StaticMesh42
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003F38 RID: 16184
		// (get) Token: 0x0602225F RID: 139871 RVA: 0x0095CFC0 File Offset: 0x0095B1C0
		// (set) Token: 0x06022260 RID: 139872 RVA: 0x0095CFD4 File Offset: 0x0095B1D4
		public unsafe UStaticMeshComponent StaticMesh41
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003F39 RID: 16185
		// (get) Token: 0x06022261 RID: 139873 RVA: 0x0095CFE9 File Offset: 0x0095B1E9
		// (set) Token: 0x06022262 RID: 139874 RVA: 0x0095CFFD File Offset: 0x0095B1FD
		public unsafe UStaticMeshComponent StaticMesh40
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003F3A RID: 16186
		// (get) Token: 0x06022263 RID: 139875 RVA: 0x0095D012 File Offset: 0x0095B212
		// (set) Token: 0x06022264 RID: 139876 RVA: 0x0095D026 File Offset: 0x0095B226
		public unsafe UStaticMeshComponent StaticMesh39
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003F3B RID: 16187
		// (get) Token: 0x06022265 RID: 139877 RVA: 0x0095D03B File Offset: 0x0095B23B
		// (set) Token: 0x06022266 RID: 139878 RVA: 0x0095D04F File Offset: 0x0095B24F
		public unsafe UStaticMeshComponent StaticMesh38
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003F3C RID: 16188
		// (get) Token: 0x06022267 RID: 139879 RVA: 0x0095D064 File Offset: 0x0095B264
		// (set) Token: 0x06022268 RID: 139880 RVA: 0x0095D078 File Offset: 0x0095B278
		public unsafe UStaticMeshComponent StaticMesh37
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17003F3D RID: 16189
		// (get) Token: 0x06022269 RID: 139881 RVA: 0x0095D08D File Offset: 0x0095B28D
		// (set) Token: 0x0602226A RID: 139882 RVA: 0x0095D0A1 File Offset: 0x0095B2A1
		public unsafe UStaticMeshComponent StaticMesh36
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003F3E RID: 16190
		// (get) Token: 0x0602226B RID: 139883 RVA: 0x0095D0B6 File Offset: 0x0095B2B6
		// (set) Token: 0x0602226C RID: 139884 RVA: 0x0095D0CA File Offset: 0x0095B2CA
		public unsafe UStaticMeshComponent StaticMesh35
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003F3F RID: 16191
		// (get) Token: 0x0602226D RID: 139885 RVA: 0x0095D0DF File Offset: 0x0095B2DF
		// (set) Token: 0x0602226E RID: 139886 RVA: 0x0095D0F3 File Offset: 0x0095B2F3
		public unsafe UStaticMeshComponent StaticMesh34
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17003F40 RID: 16192
		// (get) Token: 0x0602226F RID: 139887 RVA: 0x0095D108 File Offset: 0x0095B308
		// (set) Token: 0x06022270 RID: 139888 RVA: 0x0095D11C File Offset: 0x0095B31C
		public unsafe UStaticMeshComponent StaticMesh33
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003F41 RID: 16193
		// (get) Token: 0x06022271 RID: 139889 RVA: 0x0095D131 File Offset: 0x0095B331
		// (set) Token: 0x06022272 RID: 139890 RVA: 0x0095D145 File Offset: 0x0095B345
		public unsafe UStaticMeshComponent StaticMesh32
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003F42 RID: 16194
		// (get) Token: 0x06022273 RID: 139891 RVA: 0x0095D15A File Offset: 0x0095B35A
		// (set) Token: 0x06022274 RID: 139892 RVA: 0x0095D16E File Offset: 0x0095B36E
		public unsafe UStaticMeshComponent StaticMesh31
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003F43 RID: 16195
		// (get) Token: 0x06022275 RID: 139893 RVA: 0x0095D183 File Offset: 0x0095B383
		// (set) Token: 0x06022276 RID: 139894 RVA: 0x0095D197 File Offset: 0x0095B397
		public unsafe UStaticMeshComponent StaticMesh30
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17003F44 RID: 16196
		// (get) Token: 0x06022277 RID: 139895 RVA: 0x0095D1AC File Offset: 0x0095B3AC
		// (set) Token: 0x06022278 RID: 139896 RVA: 0x0095D1C0 File Offset: 0x0095B3C0
		public unsafe UStaticMeshComponent StaticMesh29
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003F45 RID: 16197
		// (get) Token: 0x06022279 RID: 139897 RVA: 0x0095D1D5 File Offset: 0x0095B3D5
		// (set) Token: 0x0602227A RID: 139898 RVA: 0x0095D1E9 File Offset: 0x0095B3E9
		public unsafe UStaticMeshComponent StaticMesh28
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003F46 RID: 16198
		// (get) Token: 0x0602227B RID: 139899 RVA: 0x0095D1FE File Offset: 0x0095B3FE
		// (set) Token: 0x0602227C RID: 139900 RVA: 0x0095D212 File Offset: 0x0095B412
		public unsafe UStaticMeshComponent StaticMesh27
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17003F47 RID: 16199
		// (get) Token: 0x0602227D RID: 139901 RVA: 0x0095D227 File Offset: 0x0095B427
		// (set) Token: 0x0602227E RID: 139902 RVA: 0x0095D23B File Offset: 0x0095B43B
		public unsafe UStaticMeshComponent StaticMesh26
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x17003F48 RID: 16200
		// (get) Token: 0x0602227F RID: 139903 RVA: 0x0095D250 File Offset: 0x0095B450
		// (set) Token: 0x06022280 RID: 139904 RVA: 0x0095D264 File Offset: 0x0095B464
		public unsafe UStaticMeshComponent StaticMesh25
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17003F49 RID: 16201
		// (get) Token: 0x06022281 RID: 139905 RVA: 0x0095D279 File Offset: 0x0095B479
		// (set) Token: 0x06022282 RID: 139906 RVA: 0x0095D28D File Offset: 0x0095B48D
		public unsafe UStaticMeshComponent StaticMesh24
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17003F4A RID: 16202
		// (get) Token: 0x06022283 RID: 139907 RVA: 0x0095D2A2 File Offset: 0x0095B4A2
		// (set) Token: 0x06022284 RID: 139908 RVA: 0x0095D2B6 File Offset: 0x0095B4B6
		public unsafe UStaticMeshComponent StaticMesh23
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17003F4B RID: 16203
		// (get) Token: 0x06022285 RID: 139909 RVA: 0x0095D2CB File Offset: 0x0095B4CB
		// (set) Token: 0x06022286 RID: 139910 RVA: 0x0095D2DF File Offset: 0x0095B4DF
		public unsafe UStaticMeshComponent StaticMesh22
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003F4C RID: 16204
		// (get) Token: 0x06022287 RID: 139911 RVA: 0x0095D2F4 File Offset: 0x0095B4F4
		// (set) Token: 0x06022288 RID: 139912 RVA: 0x0095D308 File Offset: 0x0095B508
		public unsafe UStaticMeshComponent StaticMesh21
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17003F4D RID: 16205
		// (get) Token: 0x06022289 RID: 139913 RVA: 0x0095D31D File Offset: 0x0095B51D
		// (set) Token: 0x0602228A RID: 139914 RVA: 0x0095D331 File Offset: 0x0095B531
		public unsafe UStaticMeshComponent StaticMesh20
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17003F4E RID: 16206
		// (get) Token: 0x0602228B RID: 139915 RVA: 0x0095D346 File Offset: 0x0095B546
		// (set) Token: 0x0602228C RID: 139916 RVA: 0x0095D35A File Offset: 0x0095B55A
		public unsafe UStaticMeshComponent StaticMesh19
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x17003F4F RID: 16207
		// (get) Token: 0x0602228D RID: 139917 RVA: 0x0095D36F File Offset: 0x0095B56F
		// (set) Token: 0x0602228E RID: 139918 RVA: 0x0095D383 File Offset: 0x0095B583
		public unsafe UStaticMeshComponent StaticMesh18
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x17003F50 RID: 16208
		// (get) Token: 0x0602228F RID: 139919 RVA: 0x0095D398 File Offset: 0x0095B598
		// (set) Token: 0x06022290 RID: 139920 RVA: 0x0095D3AC File Offset: 0x0095B5AC
		public unsafe UStaticMeshComponent StaticMesh17
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x17003F51 RID: 16209
		// (get) Token: 0x06022291 RID: 139921 RVA: 0x0095D3C1 File Offset: 0x0095B5C1
		// (set) Token: 0x06022292 RID: 139922 RVA: 0x0095D3D5 File Offset: 0x0095B5D5
		public unsafe UStaticMeshComponent StaticMesh16
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x17003F52 RID: 16210
		// (get) Token: 0x06022293 RID: 139923 RVA: 0x0095D3EA File Offset: 0x0095B5EA
		// (set) Token: 0x06022294 RID: 139924 RVA: 0x0095D3FE File Offset: 0x0095B5FE
		public unsafe UStaticMeshComponent StaticMesh15
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_51);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_51, value);
			}
		}

		// Token: 0x17003F53 RID: 16211
		// (get) Token: 0x06022295 RID: 139925 RVA: 0x0095D413 File Offset: 0x0095B613
		// (set) Token: 0x06022296 RID: 139926 RVA: 0x0095D427 File Offset: 0x0095B627
		public unsafe UStaticMeshComponent StaticMesh14
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_52);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x17003F54 RID: 16212
		// (get) Token: 0x06022297 RID: 139927 RVA: 0x0095D43C File Offset: 0x0095B63C
		// (set) Token: 0x06022298 RID: 139928 RVA: 0x0095D450 File Offset: 0x0095B650
		public unsafe UStaticMeshComponent StaticMesh13
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_53);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_53, value);
			}
		}

		// Token: 0x17003F55 RID: 16213
		// (get) Token: 0x06022299 RID: 139929 RVA: 0x0095D465 File Offset: 0x0095B665
		// (set) Token: 0x0602229A RID: 139930 RVA: 0x0095D479 File Offset: 0x0095B679
		public unsafe UStaticMeshComponent StaticMesh12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x17003F56 RID: 16214
		// (get) Token: 0x0602229B RID: 139931 RVA: 0x0095D48E File Offset: 0x0095B68E
		// (set) Token: 0x0602229C RID: 139932 RVA: 0x0095D4A2 File Offset: 0x0095B6A2
		public unsafe UStaticMeshComponent StaticMesh11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_55);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x17003F57 RID: 16215
		// (get) Token: 0x0602229D RID: 139933 RVA: 0x0095D4B7 File Offset: 0x0095B6B7
		// (set) Token: 0x0602229E RID: 139934 RVA: 0x0095D4CB File Offset: 0x0095B6CB
		public unsafe UStaticMeshComponent StaticMesh10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x17003F58 RID: 16216
		// (get) Token: 0x0602229F RID: 139935 RVA: 0x0095D4E0 File Offset: 0x0095B6E0
		// (set) Token: 0x060222A0 RID: 139936 RVA: 0x0095D4F4 File Offset: 0x0095B6F4
		public unsafe UStaticMeshComponent StaticMesh09
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x17003F59 RID: 16217
		// (get) Token: 0x060222A1 RID: 139937 RVA: 0x0095D509 File Offset: 0x0095B709
		// (set) Token: 0x060222A2 RID: 139938 RVA: 0x0095D51D File Offset: 0x0095B71D
		public unsafe UStaticMeshComponent StaticMesh08
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x17003F5A RID: 16218
		// (get) Token: 0x060222A3 RID: 139939 RVA: 0x0095D532 File Offset: 0x0095B732
		// (set) Token: 0x060222A4 RID: 139940 RVA: 0x0095D546 File Offset: 0x0095B746
		public unsafe UStaticMeshComponent StaticMesh07
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_59);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_59, value);
			}
		}

		// Token: 0x17003F5B RID: 16219
		// (get) Token: 0x060222A5 RID: 139941 RVA: 0x0095D55B File Offset: 0x0095B75B
		// (set) Token: 0x060222A6 RID: 139942 RVA: 0x0095D56F File Offset: 0x0095B76F
		public unsafe UStaticMeshComponent StaticMesh06
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x17003F5C RID: 16220
		// (get) Token: 0x060222A7 RID: 139943 RVA: 0x0095D584 File Offset: 0x0095B784
		// (set) Token: 0x060222A8 RID: 139944 RVA: 0x0095D598 File Offset: 0x0095B798
		public unsafe UStaticMeshComponent StaticMesh05
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_61);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_61, value);
			}
		}

		// Token: 0x17003F5D RID: 16221
		// (get) Token: 0x060222A9 RID: 139945 RVA: 0x0095D5AD File Offset: 0x0095B7AD
		// (set) Token: 0x060222AA RID: 139946 RVA: 0x0095D5C1 File Offset: 0x0095B7C1
		public unsafe UStaticMeshComponent StaticMesh04
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_62);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_62, value);
			}
		}

		// Token: 0x17003F5E RID: 16222
		// (get) Token: 0x060222AB RID: 139947 RVA: 0x0095D5D6 File Offset: 0x0095B7D6
		// (set) Token: 0x060222AC RID: 139948 RVA: 0x0095D5EA File Offset: 0x0095B7EA
		public unsafe UStaticMeshComponent StaticMesh03
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17003F5F RID: 16223
		// (get) Token: 0x060222AD RID: 139949 RVA: 0x0095D5FF File Offset: 0x0095B7FF
		// (set) Token: 0x060222AE RID: 139950 RVA: 0x0095D613 File Offset: 0x0095B813
		public unsafe UStaticMeshComponent StaticMesh02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x17003F60 RID: 16224
		// (get) Token: 0x060222AF RID: 139951 RVA: 0x0095D628 File Offset: 0x0095B828
		// (set) Token: 0x060222B0 RID: 139952 RVA: 0x0095D63C File Offset: 0x0095B83C
		public unsafe UStaticMeshComponent StaticMesh01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17003F61 RID: 16225
		// (get) Token: 0x060222B1 RID: 139953 RVA: 0x0095D651 File Offset: 0x0095B851
		// (set) Token: 0x060222B2 RID: 139954 RVA: 0x0095D665 File Offset: 0x0095B865
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_66);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_C.__PropertyOffset_66, value);
			}
		}

		// Token: 0x17003F62 RID: 16226
		// (get) Token: 0x060222B3 RID: 139955 RVA: 0x0095D67C File Offset: 0x0095B87C
		// (set) Token: 0x060222B4 RID: 139956 RVA: 0x0095D6B5 File Offset: 0x0095B8B5
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
					result = (this._custom = new custom(base.NativePtr + (IntPtr)BP_BridgeModels_C.__PropertyOffset_67, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_BridgeModels_C.__PropertyOffset_67, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x060222B5 RID: 139957 RVA: 0x0095D6D8 File Offset: 0x0095B8D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBridgeLink(int idx, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UChildActorComponent> tempArray1)
		{
			BP_BridgeModels_C.__GetBridgeLink_FunctionParams* ptr = stackalloc BP_BridgeModels_C.__GetBridgeLink_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_BridgeModels_C.__GetBridgeLink_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
			ptr->idx = idx;
			TArray<UChildActorComponent> tarray = tempArray1;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->tempArray1);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr);
			TArray<UChildActorComponent> tarray2 = tempArray1;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->tempArray1);
			}
			UnrealReflectionUtils.DestroyStruct(BP_BridgeModels_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060222B6 RID: 139958 RVA: 0x0095D75A File Offset: 0x0095B95A
		protected BP_BridgeModels_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040113F6 RID: 70646
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels.BP_BridgeModels_C";

		// Token: 0x040113F7 RID: 70647
		private static IntPtr _ClassPtr;

		// Token: 0x040113F8 RID: 70648
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040113F9 RID: 70649
		public static IntPtr __custom__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040113FA RID: 70650
		internal static int __PropertyOffset_0;

		// Token: 0x040113FB RID: 70651
		internal static int __PropertyOffset_1;

		// Token: 0x040113FC RID: 70652
		internal static int __PropertyOffset_2;

		// Token: 0x040113FD RID: 70653
		internal static int __PropertyOffset_3;

		// Token: 0x040113FE RID: 70654
		internal static int __PropertyOffset_4;

		// Token: 0x040113FF RID: 70655
		internal static int __PropertyOffset_5;

		// Token: 0x04011400 RID: 70656
		internal static int __PropertyOffset_6;

		// Token: 0x04011401 RID: 70657
		internal static int __PropertyOffset_7;

		// Token: 0x04011402 RID: 70658
		internal static int __PropertyOffset_8;

		// Token: 0x04011403 RID: 70659
		internal static int __PropertyOffset_9;

		// Token: 0x04011404 RID: 70660
		internal static int __PropertyOffset_10;

		// Token: 0x04011405 RID: 70661
		internal static int __PropertyOffset_11;

		// Token: 0x04011406 RID: 70662
		internal static int __PropertyOffset_12;

		// Token: 0x04011407 RID: 70663
		internal static int __PropertyOffset_13;

		// Token: 0x04011408 RID: 70664
		internal static int __PropertyOffset_14;

		// Token: 0x04011409 RID: 70665
		internal static int __PropertyOffset_15;

		// Token: 0x0401140A RID: 70666
		internal static int __PropertyOffset_16;

		// Token: 0x0401140B RID: 70667
		internal static int __PropertyOffset_17;

		// Token: 0x0401140C RID: 70668
		internal static int __PropertyOffset_18;

		// Token: 0x0401140D RID: 70669
		internal static int __PropertyOffset_19;

		// Token: 0x0401140E RID: 70670
		internal static int __PropertyOffset_20;

		// Token: 0x0401140F RID: 70671
		internal static int __PropertyOffset_21;

		// Token: 0x04011410 RID: 70672
		internal static int __PropertyOffset_22;

		// Token: 0x04011411 RID: 70673
		internal static int __PropertyOffset_23;

		// Token: 0x04011412 RID: 70674
		internal static int __PropertyOffset_24;

		// Token: 0x04011413 RID: 70675
		internal static int __PropertyOffset_25;

		// Token: 0x04011414 RID: 70676
		internal static int __PropertyOffset_26;

		// Token: 0x04011415 RID: 70677
		internal static int __PropertyOffset_27;

		// Token: 0x04011416 RID: 70678
		internal static int __PropertyOffset_28;

		// Token: 0x04011417 RID: 70679
		internal static int __PropertyOffset_29;

		// Token: 0x04011418 RID: 70680
		internal static int __PropertyOffset_30;

		// Token: 0x04011419 RID: 70681
		internal static int __PropertyOffset_31;

		// Token: 0x0401141A RID: 70682
		internal static int __PropertyOffset_32;

		// Token: 0x0401141B RID: 70683
		internal static int __PropertyOffset_33;

		// Token: 0x0401141C RID: 70684
		internal static int __PropertyOffset_34;

		// Token: 0x0401141D RID: 70685
		internal static int __PropertyOffset_35;

		// Token: 0x0401141E RID: 70686
		internal static int __PropertyOffset_36;

		// Token: 0x0401141F RID: 70687
		internal static int __PropertyOffset_37;

		// Token: 0x04011420 RID: 70688
		internal static int __PropertyOffset_38;

		// Token: 0x04011421 RID: 70689
		internal static int __PropertyOffset_39;

		// Token: 0x04011422 RID: 70690
		internal static int __PropertyOffset_40;

		// Token: 0x04011423 RID: 70691
		internal static int __PropertyOffset_41;

		// Token: 0x04011424 RID: 70692
		internal static int __PropertyOffset_42;

		// Token: 0x04011425 RID: 70693
		internal static int __PropertyOffset_43;

		// Token: 0x04011426 RID: 70694
		internal static int __PropertyOffset_44;

		// Token: 0x04011427 RID: 70695
		internal static int __PropertyOffset_45;

		// Token: 0x04011428 RID: 70696
		internal static int __PropertyOffset_46;

		// Token: 0x04011429 RID: 70697
		internal static int __PropertyOffset_47;

		// Token: 0x0401142A RID: 70698
		internal static int __PropertyOffset_48;

		// Token: 0x0401142B RID: 70699
		internal static int __PropertyOffset_49;

		// Token: 0x0401142C RID: 70700
		internal static int __PropertyOffset_50;

		// Token: 0x0401142D RID: 70701
		internal static int __PropertyOffset_51;

		// Token: 0x0401142E RID: 70702
		internal static int __PropertyOffset_52;

		// Token: 0x0401142F RID: 70703
		internal static int __PropertyOffset_53;

		// Token: 0x04011430 RID: 70704
		internal static int __PropertyOffset_54;

		// Token: 0x04011431 RID: 70705
		internal static int __PropertyOffset_55;

		// Token: 0x04011432 RID: 70706
		internal static int __PropertyOffset_56;

		// Token: 0x04011433 RID: 70707
		internal static int __PropertyOffset_57;

		// Token: 0x04011434 RID: 70708
		internal static int __PropertyOffset_58;

		// Token: 0x04011435 RID: 70709
		internal static int __PropertyOffset_59;

		// Token: 0x04011436 RID: 70710
		internal static int __PropertyOffset_60;

		// Token: 0x04011437 RID: 70711
		internal static int __PropertyOffset_61;

		// Token: 0x04011438 RID: 70712
		internal static int __PropertyOffset_62;

		// Token: 0x04011439 RID: 70713
		internal static int __PropertyOffset_63;

		// Token: 0x0401143A RID: 70714
		internal static int __PropertyOffset_64;

		// Token: 0x0401143B RID: 70715
		internal static int __PropertyOffset_65;

		// Token: 0x0401143C RID: 70716
		internal static int __PropertyOffset_66;

		// Token: 0x0401143D RID: 70717
		internal static int __PropertyOffset_67;

		// Token: 0x0401143E RID: 70718
		private custom _custom;

		// Token: 0x0401143F RID: 70719
		private static IntPtr __GetBridgeLink_NativeFunctionPtr;

		// Token: 0x02009B93 RID: 39827
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __GetBridgeLink_FunctionParams
		{
			// Token: 0x0403239F RID: 205727
			[FieldOffset(0)]
			public int idx;

			// Token: 0x040323A0 RID: 205728
			[FieldOffset(8)]
			public byte tempArray1;
		}
	}
}
