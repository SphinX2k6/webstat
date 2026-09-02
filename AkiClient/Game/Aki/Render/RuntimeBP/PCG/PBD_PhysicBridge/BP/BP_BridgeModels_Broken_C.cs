using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_PhysicBridge.BP
{
	// Token: 0x02003BB0 RID: 15280
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_Broken.BP_BridgeModels_Broken_C")]
	[UnrealStructLayout(1840, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1840)]
	public class BP_BridgeModels_Broken_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602215A RID: 139610 RVA: 0x0095B90B File Offset: 0x00959B0B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BridgeModels_Broken_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_Broken.BP_BridgeModels_Broken_C");
			}
			return BP_BridgeModels_Broken_C._ClassPtr;
		}

		// Token: 0x0602215B RID: 139611 RVA: 0x0095B930 File Offset: 0x00959B30
		public BP_BridgeModels_Broken_C() : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_Broken_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602215C RID: 139612 RVA: 0x0095B958 File Offset: 0x00959B58
		[NullableContext(1)]
		public BP_BridgeModels_Broken_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BridgeModels_Broken_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003EBD RID: 16061
		// (get) Token: 0x0602215D RID: 139613 RVA: 0x0095B98C File Offset: 0x00959B8C
		// (set) Token: 0x0602215E RID: 139614 RVA: 0x0095B9C5 File Offset: 0x00959BC5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BridgeModels_Broken_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BridgeModels_Broken_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003EBE RID: 16062
		// (get) Token: 0x0602215F RID: 139615 RVA: 0x0095B9E6 File Offset: 0x00959BE6
		// (set) Token: 0x06022160 RID: 139616 RVA: 0x0095B9FA File Offset: 0x00959BFA
		public unsafe UStaticMeshComponent Cube8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003EBF RID: 16063
		// (get) Token: 0x06022161 RID: 139617 RVA: 0x0095BA0F File Offset: 0x00959C0F
		// (set) Token: 0x06022162 RID: 139618 RVA: 0x0095BA23 File Offset: 0x00959C23
		public unsafe UStaticMeshComponent Cube7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003EC0 RID: 16064
		// (get) Token: 0x06022163 RID: 139619 RVA: 0x0095BA38 File Offset: 0x00959C38
		// (set) Token: 0x06022164 RID: 139620 RVA: 0x0095BA4C File Offset: 0x00959C4C
		public unsafe UChildActorComponent _15_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003EC1 RID: 16065
		// (get) Token: 0x06022165 RID: 139621 RVA: 0x0095BA61 File Offset: 0x00959C61
		// (set) Token: 0x06022166 RID: 139622 RVA: 0x0095BA75 File Offset: 0x00959C75
		public unsafe UStaticMeshComponent Cube3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003EC2 RID: 16066
		// (get) Token: 0x06022167 RID: 139623 RVA: 0x0095BA8A File Offset: 0x00959C8A
		// (set) Token: 0x06022168 RID: 139624 RVA: 0x0095BA9E File Offset: 0x00959C9E
		public unsafe UStaticMeshComponent Cube2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003EC3 RID: 16067
		// (get) Token: 0x06022169 RID: 139625 RVA: 0x0095BAB3 File Offset: 0x00959CB3
		// (set) Token: 0x0602216A RID: 139626 RVA: 0x0095BAC7 File Offset: 0x00959CC7
		public unsafe UChildActorComponent _15_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003EC4 RID: 16068
		// (get) Token: 0x0602216B RID: 139627 RVA: 0x0095BADC File Offset: 0x00959CDC
		// (set) Token: 0x0602216C RID: 139628 RVA: 0x0095BAF0 File Offset: 0x00959CF0
		public unsafe UChildActorComponent _15_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003EC5 RID: 16069
		// (get) Token: 0x0602216D RID: 139629 RVA: 0x0095BB05 File Offset: 0x00959D05
		// (set) Token: 0x0602216E RID: 139630 RVA: 0x0095BB19 File Offset: 0x00959D19
		public unsafe UChildActorComponent _15_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003EC6 RID: 16070
		// (get) Token: 0x0602216F RID: 139631 RVA: 0x0095BB2E File Offset: 0x00959D2E
		// (set) Token: 0x06022170 RID: 139632 RVA: 0x0095BB42 File Offset: 0x00959D42
		public unsafe UChildActorComponent _24_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003EC7 RID: 16071
		// (get) Token: 0x06022171 RID: 139633 RVA: 0x0095BB57 File Offset: 0x00959D57
		// (set) Token: 0x06022172 RID: 139634 RVA: 0x0095BB6B File Offset: 0x00959D6B
		public unsafe UChildActorComponent _24_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003EC8 RID: 16072
		// (get) Token: 0x06022173 RID: 139635 RVA: 0x0095BB80 File Offset: 0x00959D80
		// (set) Token: 0x06022174 RID: 139636 RVA: 0x0095BB94 File Offset: 0x00959D94
		public unsafe UChildActorComponent _24_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003EC9 RID: 16073
		// (get) Token: 0x06022175 RID: 139637 RVA: 0x0095BBA9 File Offset: 0x00959DA9
		// (set) Token: 0x06022176 RID: 139638 RVA: 0x0095BBBD File Offset: 0x00959DBD
		public unsafe UChildActorComponent _24_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003ECA RID: 16074
		// (get) Token: 0x06022177 RID: 139639 RVA: 0x0095BBD2 File Offset: 0x00959DD2
		// (set) Token: 0x06022178 RID: 139640 RVA: 0x0095BBE6 File Offset: 0x00959DE6
		public unsafe UStaticMeshComponent Cube6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17003ECB RID: 16075
		// (get) Token: 0x06022179 RID: 139641 RVA: 0x0095BBFB File Offset: 0x00959DFB
		// (set) Token: 0x0602217A RID: 139642 RVA: 0x0095BC0F File Offset: 0x00959E0F
		public unsafe UStaticMeshComponent Cube5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003ECC RID: 16076
		// (get) Token: 0x0602217B RID: 139643 RVA: 0x0095BC24 File Offset: 0x00959E24
		// (set) Token: 0x0602217C RID: 139644 RVA: 0x0095BC38 File Offset: 0x00959E38
		public unsafe UChildActorComponent _50_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003ECD RID: 16077
		// (get) Token: 0x0602217D RID: 139645 RVA: 0x0095BC4D File Offset: 0x00959E4D
		// (set) Token: 0x0602217E RID: 139646 RVA: 0x0095BC61 File Offset: 0x00959E61
		public unsafe UChildActorComponent _50_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003ECE RID: 16078
		// (get) Token: 0x0602217F RID: 139647 RVA: 0x0095BC76 File Offset: 0x00959E76
		// (set) Token: 0x06022180 RID: 139648 RVA: 0x0095BC8A File Offset: 0x00959E8A
		public unsafe UStaticMeshComponent Cube10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003ECF RID: 16079
		// (get) Token: 0x06022181 RID: 139649 RVA: 0x0095BC9F File Offset: 0x00959E9F
		// (set) Token: 0x06022182 RID: 139650 RVA: 0x0095BCB3 File Offset: 0x00959EB3
		public unsafe UStaticMeshComponent Cube9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003ED0 RID: 16080
		// (get) Token: 0x06022183 RID: 139651 RVA: 0x0095BCC8 File Offset: 0x00959EC8
		// (set) Token: 0x06022184 RID: 139652 RVA: 0x0095BCDC File Offset: 0x00959EDC
		public unsafe UChildActorComponent _50_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003ED1 RID: 16081
		// (get) Token: 0x06022185 RID: 139653 RVA: 0x0095BCF1 File Offset: 0x00959EF1
		// (set) Token: 0x06022186 RID: 139654 RVA: 0x0095BD05 File Offset: 0x00959F05
		public unsafe UChildActorComponent _50_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003ED2 RID: 16082
		// (get) Token: 0x06022187 RID: 139655 RVA: 0x0095BD1A File Offset: 0x00959F1A
		// (set) Token: 0x06022188 RID: 139656 RVA: 0x0095BD2E File Offset: 0x00959F2E
		public unsafe UChildActorComponent _10_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003ED3 RID: 16083
		// (get) Token: 0x06022189 RID: 139657 RVA: 0x0095BD43 File Offset: 0x00959F43
		// (set) Token: 0x0602218A RID: 139658 RVA: 0x0095BD57 File Offset: 0x00959F57
		public unsafe UChildActorComponent _10_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003ED4 RID: 16084
		// (get) Token: 0x0602218B RID: 139659 RVA: 0x0095BD6C File Offset: 0x00959F6C
		// (set) Token: 0x0602218C RID: 139660 RVA: 0x0095BD80 File Offset: 0x00959F80
		public unsafe UStaticMeshComponent Cube1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003ED5 RID: 16085
		// (get) Token: 0x0602218D RID: 139661 RVA: 0x0095BD95 File Offset: 0x00959F95
		// (set) Token: 0x0602218E RID: 139662 RVA: 0x0095BDA9 File Offset: 0x00959FA9
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003ED6 RID: 16086
		// (get) Token: 0x0602218F RID: 139663 RVA: 0x0095BDBE File Offset: 0x00959FBE
		// (set) Token: 0x06022190 RID: 139664 RVA: 0x0095BDD2 File Offset: 0x00959FD2
		public unsafe UChildActorComponent _10_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003ED7 RID: 16087
		// (get) Token: 0x06022191 RID: 139665 RVA: 0x0095BDE7 File Offset: 0x00959FE7
		// (set) Token: 0x06022192 RID: 139666 RVA: 0x0095BDFB File Offset: 0x00959FFB
		public unsafe UChildActorComponent _10_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003ED8 RID: 16088
		// (get) Token: 0x06022193 RID: 139667 RVA: 0x0095BE10 File Offset: 0x0095A010
		// (set) Token: 0x06022194 RID: 139668 RVA: 0x0095BE24 File Offset: 0x0095A024
		public unsafe UChildActorComponent _60_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003ED9 RID: 16089
		// (get) Token: 0x06022195 RID: 139669 RVA: 0x0095BE39 File Offset: 0x0095A039
		// (set) Token: 0x06022196 RID: 139670 RVA: 0x0095BE4D File Offset: 0x0095A04D
		public unsafe UChildActorComponent _60_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003EDA RID: 16090
		// (get) Token: 0x06022197 RID: 139671 RVA: 0x0095BE62 File Offset: 0x0095A062
		// (set) Token: 0x06022198 RID: 139672 RVA: 0x0095BE76 File Offset: 0x0095A076
		public unsafe UChildActorComponent _60_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17003EDB RID: 16091
		// (get) Token: 0x06022199 RID: 139673 RVA: 0x0095BE8B File Offset: 0x0095A08B
		// (set) Token: 0x0602219A RID: 139674 RVA: 0x0095BE9F File Offset: 0x0095A09F
		public unsafe UChildActorComponent _60_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17003EDC RID: 16092
		// (get) Token: 0x0602219B RID: 139675 RVA: 0x0095BEB4 File Offset: 0x0095A0B4
		// (set) Token: 0x0602219C RID: 139676 RVA: 0x0095BEC8 File Offset: 0x0095A0C8
		public unsafe UChildActorComponent _00_2_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003EDD RID: 16093
		// (get) Token: 0x0602219D RID: 139677 RVA: 0x0095BEDD File Offset: 0x0095A0DD
		// (set) Token: 0x0602219E RID: 139678 RVA: 0x0095BEF1 File Offset: 0x0095A0F1
		public unsafe UChildActorComponent _00_1_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x17003EDE RID: 16094
		// (get) Token: 0x0602219F RID: 139679 RVA: 0x0095BF06 File Offset: 0x0095A106
		// (set) Token: 0x060221A0 RID: 139680 RVA: 0x0095BF1A File Offset: 0x0095A11A
		public unsafe UChildActorComponent _00_1_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17003EDF RID: 16095
		// (get) Token: 0x060221A1 RID: 139681 RVA: 0x0095BF2F File Offset: 0x0095A12F
		// (set) Token: 0x060221A2 RID: 139682 RVA: 0x0095BF43 File Offset: 0x0095A143
		public unsafe UChildActorComponent _00_2_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_34);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x17003EE0 RID: 16096
		// (get) Token: 0x060221A3 RID: 139683 RVA: 0x0095BF58 File Offset: 0x0095A158
		// (set) Token: 0x060221A4 RID: 139684 RVA: 0x0095BF6C File Offset: 0x0095A16C
		public unsafe UStaticMeshComponent StaticMesh00
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17003EE1 RID: 16097
		// (get) Token: 0x060221A5 RID: 139685 RVA: 0x0095BF81 File Offset: 0x0095A181
		// (set) Token: 0x060221A6 RID: 139686 RVA: 0x0095BF95 File Offset: 0x0095A195
		public unsafe UStaticMeshComponent SM_Gel_Bri_04IL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17003EE2 RID: 16098
		// (get) Token: 0x060221A7 RID: 139687 RVA: 0x0095BFAA File Offset: 0x0095A1AA
		// (set) Token: 0x060221A8 RID: 139688 RVA: 0x0095BFBE File Offset: 0x0095A1BE
		public unsafe UStaticMeshComponent StaticMesh57
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17003EE3 RID: 16099
		// (get) Token: 0x060221A9 RID: 139689 RVA: 0x0095BFD3 File Offset: 0x0095A1D3
		// (set) Token: 0x060221AA RID: 139690 RVA: 0x0095BFE7 File Offset: 0x0095A1E7
		public unsafe UStaticMeshComponent StaticMesh56
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x17003EE4 RID: 16100
		// (get) Token: 0x060221AB RID: 139691 RVA: 0x0095BFFC File Offset: 0x0095A1FC
		// (set) Token: 0x060221AC RID: 139692 RVA: 0x0095C010 File Offset: 0x0095A210
		public unsafe UStaticMeshComponent StaticMesh55
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17003EE5 RID: 16101
		// (get) Token: 0x060221AD RID: 139693 RVA: 0x0095C025 File Offset: 0x0095A225
		// (set) Token: 0x060221AE RID: 139694 RVA: 0x0095C039 File Offset: 0x0095A239
		public unsafe UStaticMeshComponent StaticMesh54
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x17003EE6 RID: 16102
		// (get) Token: 0x060221AF RID: 139695 RVA: 0x0095C04E File Offset: 0x0095A24E
		// (set) Token: 0x060221B0 RID: 139696 RVA: 0x0095C062 File Offset: 0x0095A262
		public unsafe UStaticMeshComponent StaticMesh53
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_41);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_41, value);
			}
		}

		// Token: 0x17003EE7 RID: 16103
		// (get) Token: 0x060221B1 RID: 139697 RVA: 0x0095C077 File Offset: 0x0095A277
		// (set) Token: 0x060221B2 RID: 139698 RVA: 0x0095C08B File Offset: 0x0095A28B
		public unsafe UStaticMeshComponent StaticMesh52
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x17003EE8 RID: 16104
		// (get) Token: 0x060221B3 RID: 139699 RVA: 0x0095C0A0 File Offset: 0x0095A2A0
		// (set) Token: 0x060221B4 RID: 139700 RVA: 0x0095C0B4 File Offset: 0x0095A2B4
		public unsafe UStaticMeshComponent StaticMesh51
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17003EE9 RID: 16105
		// (get) Token: 0x060221B5 RID: 139701 RVA: 0x0095C0C9 File Offset: 0x0095A2C9
		// (set) Token: 0x060221B6 RID: 139702 RVA: 0x0095C0DD File Offset: 0x0095A2DD
		public unsafe UStaticMeshComponent StaticMesh50
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003EEA RID: 16106
		// (get) Token: 0x060221B7 RID: 139703 RVA: 0x0095C0F2 File Offset: 0x0095A2F2
		// (set) Token: 0x060221B8 RID: 139704 RVA: 0x0095C106 File Offset: 0x0095A306
		public unsafe UStaticMeshComponent StaticMesh49
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17003EEB RID: 16107
		// (get) Token: 0x060221B9 RID: 139705 RVA: 0x0095C11B File Offset: 0x0095A31B
		// (set) Token: 0x060221BA RID: 139706 RVA: 0x0095C12F File Offset: 0x0095A32F
		public unsafe UStaticMeshComponent StaticMesh48
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17003EEC RID: 16108
		// (get) Token: 0x060221BB RID: 139707 RVA: 0x0095C144 File Offset: 0x0095A344
		// (set) Token: 0x060221BC RID: 139708 RVA: 0x0095C158 File Offset: 0x0095A358
		public unsafe UStaticMeshComponent StaticMesh47
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x17003EED RID: 16109
		// (get) Token: 0x060221BD RID: 139709 RVA: 0x0095C16D File Offset: 0x0095A36D
		// (set) Token: 0x060221BE RID: 139710 RVA: 0x0095C181 File Offset: 0x0095A381
		public unsafe UStaticMeshComponent StaticMesh46
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x17003EEE RID: 16110
		// (get) Token: 0x060221BF RID: 139711 RVA: 0x0095C196 File Offset: 0x0095A396
		// (set) Token: 0x060221C0 RID: 139712 RVA: 0x0095C1AA File Offset: 0x0095A3AA
		public unsafe UStaticMeshComponent StaticMesh45
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x17003EEF RID: 16111
		// (get) Token: 0x060221C1 RID: 139713 RVA: 0x0095C1BF File Offset: 0x0095A3BF
		// (set) Token: 0x060221C2 RID: 139714 RVA: 0x0095C1D3 File Offset: 0x0095A3D3
		public unsafe UStaticMeshComponent StaticMesh44
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x17003EF0 RID: 16112
		// (get) Token: 0x060221C3 RID: 139715 RVA: 0x0095C1E8 File Offset: 0x0095A3E8
		// (set) Token: 0x060221C4 RID: 139716 RVA: 0x0095C1FC File Offset: 0x0095A3FC
		public unsafe UStaticMeshComponent StaticMesh43
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_51);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_51, value);
			}
		}

		// Token: 0x17003EF1 RID: 16113
		// (get) Token: 0x060221C5 RID: 139717 RVA: 0x0095C211 File Offset: 0x0095A411
		// (set) Token: 0x060221C6 RID: 139718 RVA: 0x0095C225 File Offset: 0x0095A425
		public unsafe UStaticMeshComponent StaticMesh42
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_52);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x17003EF2 RID: 16114
		// (get) Token: 0x060221C7 RID: 139719 RVA: 0x0095C23A File Offset: 0x0095A43A
		// (set) Token: 0x060221C8 RID: 139720 RVA: 0x0095C24E File Offset: 0x0095A44E
		public unsafe UStaticMeshComponent StaticMesh41
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_53);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_53, value);
			}
		}

		// Token: 0x17003EF3 RID: 16115
		// (get) Token: 0x060221C9 RID: 139721 RVA: 0x0095C263 File Offset: 0x0095A463
		// (set) Token: 0x060221CA RID: 139722 RVA: 0x0095C277 File Offset: 0x0095A477
		public unsafe UStaticMeshComponent StaticMesh40
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x17003EF4 RID: 16116
		// (get) Token: 0x060221CB RID: 139723 RVA: 0x0095C28C File Offset: 0x0095A48C
		// (set) Token: 0x060221CC RID: 139724 RVA: 0x0095C2A0 File Offset: 0x0095A4A0
		public unsafe UStaticMeshComponent StaticMesh39
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_55);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x17003EF5 RID: 16117
		// (get) Token: 0x060221CD RID: 139725 RVA: 0x0095C2B5 File Offset: 0x0095A4B5
		// (set) Token: 0x060221CE RID: 139726 RVA: 0x0095C2C9 File Offset: 0x0095A4C9
		public unsafe UStaticMeshComponent StaticMesh38
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x17003EF6 RID: 16118
		// (get) Token: 0x060221CF RID: 139727 RVA: 0x0095C2DE File Offset: 0x0095A4DE
		// (set) Token: 0x060221D0 RID: 139728 RVA: 0x0095C2F2 File Offset: 0x0095A4F2
		public unsafe UStaticMeshComponent StaticMesh37
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x17003EF7 RID: 16119
		// (get) Token: 0x060221D1 RID: 139729 RVA: 0x0095C307 File Offset: 0x0095A507
		// (set) Token: 0x060221D2 RID: 139730 RVA: 0x0095C31B File Offset: 0x0095A51B
		public unsafe UStaticMeshComponent StaticMesh36
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x17003EF8 RID: 16120
		// (get) Token: 0x060221D3 RID: 139731 RVA: 0x0095C330 File Offset: 0x0095A530
		// (set) Token: 0x060221D4 RID: 139732 RVA: 0x0095C344 File Offset: 0x0095A544
		public unsafe UStaticMeshComponent StaticMesh35
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_59);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_59, value);
			}
		}

		// Token: 0x17003EF9 RID: 16121
		// (get) Token: 0x060221D5 RID: 139733 RVA: 0x0095C359 File Offset: 0x0095A559
		// (set) Token: 0x060221D6 RID: 139734 RVA: 0x0095C36D File Offset: 0x0095A56D
		public unsafe UStaticMeshComponent StaticMesh34
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x17003EFA RID: 16122
		// (get) Token: 0x060221D7 RID: 139735 RVA: 0x0095C382 File Offset: 0x0095A582
		// (set) Token: 0x060221D8 RID: 139736 RVA: 0x0095C396 File Offset: 0x0095A596
		public unsafe UStaticMeshComponent StaticMesh33
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_61);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_61, value);
			}
		}

		// Token: 0x17003EFB RID: 16123
		// (get) Token: 0x060221D9 RID: 139737 RVA: 0x0095C3AB File Offset: 0x0095A5AB
		// (set) Token: 0x060221DA RID: 139738 RVA: 0x0095C3BF File Offset: 0x0095A5BF
		public unsafe UStaticMeshComponent StaticMesh32
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_62);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_62, value);
			}
		}

		// Token: 0x17003EFC RID: 16124
		// (get) Token: 0x060221DB RID: 139739 RVA: 0x0095C3D4 File Offset: 0x0095A5D4
		// (set) Token: 0x060221DC RID: 139740 RVA: 0x0095C3E8 File Offset: 0x0095A5E8
		public unsafe UStaticMeshComponent StaticMesh31
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17003EFD RID: 16125
		// (get) Token: 0x060221DD RID: 139741 RVA: 0x0095C3FD File Offset: 0x0095A5FD
		// (set) Token: 0x060221DE RID: 139742 RVA: 0x0095C411 File Offset: 0x0095A611
		public unsafe UStaticMeshComponent StaticMesh30
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x17003EFE RID: 16126
		// (get) Token: 0x060221DF RID: 139743 RVA: 0x0095C426 File Offset: 0x0095A626
		// (set) Token: 0x060221E0 RID: 139744 RVA: 0x0095C43A File Offset: 0x0095A63A
		public unsafe UStaticMeshComponent StaticMesh29
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17003EFF RID: 16127
		// (get) Token: 0x060221E1 RID: 139745 RVA: 0x0095C44F File Offset: 0x0095A64F
		// (set) Token: 0x060221E2 RID: 139746 RVA: 0x0095C463 File Offset: 0x0095A663
		public unsafe UStaticMeshComponent StaticMesh28
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_66);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_66, value);
			}
		}

		// Token: 0x17003F00 RID: 16128
		// (get) Token: 0x060221E3 RID: 139747 RVA: 0x0095C478 File Offset: 0x0095A678
		// (set) Token: 0x060221E4 RID: 139748 RVA: 0x0095C48C File Offset: 0x0095A68C
		public unsafe UStaticMeshComponent StaticMesh27
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_67);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_67, value);
			}
		}

		// Token: 0x17003F01 RID: 16129
		// (get) Token: 0x060221E5 RID: 139749 RVA: 0x0095C4A1 File Offset: 0x0095A6A1
		// (set) Token: 0x060221E6 RID: 139750 RVA: 0x0095C4B5 File Offset: 0x0095A6B5
		public unsafe UStaticMeshComponent StaticMesh26
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_68);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_68, value);
			}
		}

		// Token: 0x17003F02 RID: 16130
		// (get) Token: 0x060221E7 RID: 139751 RVA: 0x0095C4CA File Offset: 0x0095A6CA
		// (set) Token: 0x060221E8 RID: 139752 RVA: 0x0095C4DE File Offset: 0x0095A6DE
		public unsafe UStaticMeshComponent StaticMesh25
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_69);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_69, value);
			}
		}

		// Token: 0x17003F03 RID: 16131
		// (get) Token: 0x060221E9 RID: 139753 RVA: 0x0095C4F3 File Offset: 0x0095A6F3
		// (set) Token: 0x060221EA RID: 139754 RVA: 0x0095C507 File Offset: 0x0095A707
		public unsafe UStaticMeshComponent StaticMesh24
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_70);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_70, value);
			}
		}

		// Token: 0x17003F04 RID: 16132
		// (get) Token: 0x060221EB RID: 139755 RVA: 0x0095C51C File Offset: 0x0095A71C
		// (set) Token: 0x060221EC RID: 139756 RVA: 0x0095C530 File Offset: 0x0095A730
		public unsafe UStaticMeshComponent StaticMesh23
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_71);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_71, value);
			}
		}

		// Token: 0x17003F05 RID: 16133
		// (get) Token: 0x060221ED RID: 139757 RVA: 0x0095C545 File Offset: 0x0095A745
		// (set) Token: 0x060221EE RID: 139758 RVA: 0x0095C559 File Offset: 0x0095A759
		public unsafe UStaticMeshComponent StaticMesh22
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_72);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_72, value);
			}
		}

		// Token: 0x17003F06 RID: 16134
		// (get) Token: 0x060221EF RID: 139759 RVA: 0x0095C56E File Offset: 0x0095A76E
		// (set) Token: 0x060221F0 RID: 139760 RVA: 0x0095C582 File Offset: 0x0095A782
		public unsafe UStaticMeshComponent StaticMesh21
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_73);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_73, value);
			}
		}

		// Token: 0x17003F07 RID: 16135
		// (get) Token: 0x060221F1 RID: 139761 RVA: 0x0095C597 File Offset: 0x0095A797
		// (set) Token: 0x060221F2 RID: 139762 RVA: 0x0095C5AB File Offset: 0x0095A7AB
		public unsafe UStaticMeshComponent StaticMesh20
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_74);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_74, value);
			}
		}

		// Token: 0x17003F08 RID: 16136
		// (get) Token: 0x060221F3 RID: 139763 RVA: 0x0095C5C0 File Offset: 0x0095A7C0
		// (set) Token: 0x060221F4 RID: 139764 RVA: 0x0095C5D4 File Offset: 0x0095A7D4
		public unsafe UStaticMeshComponent StaticMesh19
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_75);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_75, value);
			}
		}

		// Token: 0x17003F09 RID: 16137
		// (get) Token: 0x060221F5 RID: 139765 RVA: 0x0095C5E9 File Offset: 0x0095A7E9
		// (set) Token: 0x060221F6 RID: 139766 RVA: 0x0095C5FD File Offset: 0x0095A7FD
		public unsafe UStaticMeshComponent StaticMesh18
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_76);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_76, value);
			}
		}

		// Token: 0x17003F0A RID: 16138
		// (get) Token: 0x060221F7 RID: 139767 RVA: 0x0095C612 File Offset: 0x0095A812
		// (set) Token: 0x060221F8 RID: 139768 RVA: 0x0095C626 File Offset: 0x0095A826
		public unsafe UStaticMeshComponent StaticMesh17
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_77);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_77, value);
			}
		}

		// Token: 0x17003F0B RID: 16139
		// (get) Token: 0x060221F9 RID: 139769 RVA: 0x0095C63B File Offset: 0x0095A83B
		// (set) Token: 0x060221FA RID: 139770 RVA: 0x0095C64F File Offset: 0x0095A84F
		public unsafe UStaticMeshComponent StaticMesh16
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_78);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_78, value);
			}
		}

		// Token: 0x17003F0C RID: 16140
		// (get) Token: 0x060221FB RID: 139771 RVA: 0x0095C664 File Offset: 0x0095A864
		// (set) Token: 0x060221FC RID: 139772 RVA: 0x0095C678 File Offset: 0x0095A878
		public unsafe UStaticMeshComponent StaticMesh15
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_79);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_79, value);
			}
		}

		// Token: 0x17003F0D RID: 16141
		// (get) Token: 0x060221FD RID: 139773 RVA: 0x0095C68D File Offset: 0x0095A88D
		// (set) Token: 0x060221FE RID: 139774 RVA: 0x0095C6A1 File Offset: 0x0095A8A1
		public unsafe UStaticMeshComponent StaticMesh14
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_80);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_80, value);
			}
		}

		// Token: 0x17003F0E RID: 16142
		// (get) Token: 0x060221FF RID: 139775 RVA: 0x0095C6B6 File Offset: 0x0095A8B6
		// (set) Token: 0x06022200 RID: 139776 RVA: 0x0095C6CA File Offset: 0x0095A8CA
		public unsafe UStaticMeshComponent StaticMesh13
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_81);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_81, value);
			}
		}

		// Token: 0x17003F0F RID: 16143
		// (get) Token: 0x06022201 RID: 139777 RVA: 0x0095C6DF File Offset: 0x0095A8DF
		// (set) Token: 0x06022202 RID: 139778 RVA: 0x0095C6F3 File Offset: 0x0095A8F3
		public unsafe UStaticMeshComponent StaticMesh12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_82);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_82, value);
			}
		}

		// Token: 0x17003F10 RID: 16144
		// (get) Token: 0x06022203 RID: 139779 RVA: 0x0095C708 File Offset: 0x0095A908
		// (set) Token: 0x06022204 RID: 139780 RVA: 0x0095C71C File Offset: 0x0095A91C
		public unsafe UStaticMeshComponent StaticMesh11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_83);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_83, value);
			}
		}

		// Token: 0x17003F11 RID: 16145
		// (get) Token: 0x06022205 RID: 139781 RVA: 0x0095C731 File Offset: 0x0095A931
		// (set) Token: 0x06022206 RID: 139782 RVA: 0x0095C745 File Offset: 0x0095A945
		public unsafe UStaticMeshComponent StaticMesh10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_84);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_84, value);
			}
		}

		// Token: 0x17003F12 RID: 16146
		// (get) Token: 0x06022207 RID: 139783 RVA: 0x0095C75A File Offset: 0x0095A95A
		// (set) Token: 0x06022208 RID: 139784 RVA: 0x0095C76E File Offset: 0x0095A96E
		public unsafe UStaticMeshComponent StaticMesh09
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_85);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_85, value);
			}
		}

		// Token: 0x17003F13 RID: 16147
		// (get) Token: 0x06022209 RID: 139785 RVA: 0x0095C783 File Offset: 0x0095A983
		// (set) Token: 0x0602220A RID: 139786 RVA: 0x0095C797 File Offset: 0x0095A997
		public unsafe UStaticMeshComponent StaticMesh08
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_86);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_86, value);
			}
		}

		// Token: 0x17003F14 RID: 16148
		// (get) Token: 0x0602220B RID: 139787 RVA: 0x0095C7AC File Offset: 0x0095A9AC
		// (set) Token: 0x0602220C RID: 139788 RVA: 0x0095C7C0 File Offset: 0x0095A9C0
		public unsafe UStaticMeshComponent StaticMesh07
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_87);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_87, value);
			}
		}

		// Token: 0x17003F15 RID: 16149
		// (get) Token: 0x0602220D RID: 139789 RVA: 0x0095C7D5 File Offset: 0x0095A9D5
		// (set) Token: 0x0602220E RID: 139790 RVA: 0x0095C7E9 File Offset: 0x0095A9E9
		public unsafe UStaticMeshComponent StaticMesh06
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_88);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_88, value);
			}
		}

		// Token: 0x17003F16 RID: 16150
		// (get) Token: 0x0602220F RID: 139791 RVA: 0x0095C7FE File Offset: 0x0095A9FE
		// (set) Token: 0x06022210 RID: 139792 RVA: 0x0095C812 File Offset: 0x0095AA12
		public unsafe UStaticMeshComponent StaticMesh05
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_89);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_89, value);
			}
		}

		// Token: 0x17003F17 RID: 16151
		// (get) Token: 0x06022211 RID: 139793 RVA: 0x0095C827 File Offset: 0x0095AA27
		// (set) Token: 0x06022212 RID: 139794 RVA: 0x0095C83B File Offset: 0x0095AA3B
		public unsafe UStaticMeshComponent StaticMesh04
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_90);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_90, value);
			}
		}

		// Token: 0x17003F18 RID: 16152
		// (get) Token: 0x06022213 RID: 139795 RVA: 0x0095C850 File Offset: 0x0095AA50
		// (set) Token: 0x06022214 RID: 139796 RVA: 0x0095C864 File Offset: 0x0095AA64
		public unsafe UStaticMeshComponent StaticMesh03
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_91);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_91, value);
			}
		}

		// Token: 0x17003F19 RID: 16153
		// (get) Token: 0x06022215 RID: 139797 RVA: 0x0095C879 File Offset: 0x0095AA79
		// (set) Token: 0x06022216 RID: 139798 RVA: 0x0095C88D File Offset: 0x0095AA8D
		public unsafe UStaticMeshComponent StaticMesh02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_92);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_92, value);
			}
		}

		// Token: 0x17003F1A RID: 16154
		// (get) Token: 0x06022217 RID: 139799 RVA: 0x0095C8A2 File Offset: 0x0095AAA2
		// (set) Token: 0x06022218 RID: 139800 RVA: 0x0095C8B6 File Offset: 0x0095AAB6
		public unsafe UStaticMeshComponent StaticMesh01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_93);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_93, value);
			}
		}

		// Token: 0x17003F1B RID: 16155
		// (get) Token: 0x06022219 RID: 139801 RVA: 0x0095C8CB File Offset: 0x0095AACB
		// (set) Token: 0x0602221A RID: 139802 RVA: 0x0095C8DF File Offset: 0x0095AADF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_94);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BridgeModels_Broken_C.__PropertyOffset_94, value);
			}
		}

		// Token: 0x17003F1C RID: 16156
		// (get) Token: 0x0602221B RID: 139803 RVA: 0x0095C8F4 File Offset: 0x0095AAF4
		// (set) Token: 0x0602221C RID: 139804 RVA: 0x0095C92D File Offset: 0x0095AB2D
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
					result = (this._custom = new custom(base.NativePtr + (IntPtr)BP_BridgeModels_Broken_C.__PropertyOffset_95, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_BridgeModels_Broken_C.__PropertyOffset_95, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17003F1D RID: 16157
		// (get) Token: 0x0602221D RID: 139805 RVA: 0x0095C94E File Offset: 0x0095AB4E
		// (set) Token: 0x0602221E RID: 139806 RVA: 0x0095C962 File Offset: 0x0095AB62
		public unsafe FVector NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BridgeModels_Broken_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BridgeModels_Broken_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x17003F1E RID: 16158
		// (get) Token: 0x0602221F RID: 139807 RVA: 0x0095C978 File Offset: 0x0095AB78
		// (set) Token: 0x06022220 RID: 139808 RVA: 0x0095C9B1 File Offset: 0x0095ABB1
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
					result = (this._BlockList = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_BridgeModels_Broken_C.__PropertyOffset_97, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BlockList.CopyAssign(value);
			}
		}

		// Token: 0x06022221 RID: 139809 RVA: 0x0095C9BF File Offset: 0x0095ABBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RecoverBlock()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__RecoverBlock_NativeFunctionPtr, null);
		}

		// Token: 0x06022222 RID: 139810 RVA: 0x0095C9D4 File Offset: 0x0095ABD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetSideBlockColli(bool IsBreak)
		{
			BP_BridgeModels_Broken_C.__SetSideBlockColli_FunctionParams* ptr = stackalloc BP_BridgeModels_Broken_C.__SetSideBlockColli_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BridgeModels_Broken_C.__SetSideBlockColli_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_Broken_C.__SetSideBlockColli_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsBreak = IsBreak;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__SetSideBlockColli_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022223 RID: 139811 RVA: 0x0095CA1C File Offset: 0x0095AC1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetBridgeLink(int idx, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<UChildActorComponent> tempArray1)
		{
			BP_BridgeModels_Broken_C.__GetBridgeLink_FunctionParams* ptr = stackalloc BP_BridgeModels_Broken_C.__GetBridgeLink_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(BP_BridgeModels_Broken_C.__GetBridgeLink_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_Broken_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
			ptr->idx = idx;
			TArray<UChildActorComponent> tarray = tempArray1;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->tempArray1);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr);
			TArray<UChildActorComponent> tarray2 = tempArray1;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->tempArray1);
			}
			UnrealReflectionUtils.DestroyStruct(BP_BridgeModels_Broken_C.__GetBridgeLink_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06022224 RID: 139812 RVA: 0x0095CA9E File Offset: 0x0095AC9E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022225 RID: 139813 RVA: 0x0095CAB2 File Offset: 0x0095ACB2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022226 RID: 139814 RVA: 0x0095CAC7 File Offset: 0x0095ACC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022227 RID: 139815 RVA: 0x0095CADB File Offset: 0x0095ACDB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022228 RID: 139816 RVA: 0x0095CAF0 File Offset: 0x0095ACF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BridgeModels_Broken(int EntryPoint)
		{
			BP_BridgeModels_Broken_C.__ExecuteUbergraph_BP_BridgeModels_Broken_FunctionParams* ptr = stackalloc BP_BridgeModels_Broken_C.__ExecuteUbergraph_BP_BridgeModels_Broken_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BridgeModels_Broken_C.__ExecuteUbergraph_BP_BridgeModels_Broken_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BridgeModels_Broken_C.__ExecuteUbergraph_BP_BridgeModels_Broken_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BridgeModels_Broken_C.__ExecuteUbergraph_BP_BridgeModels_Broken_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022229 RID: 139817 RVA: 0x0095CB37 File Offset: 0x0095AD37
		protected BP_BridgeModels_Broken_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011387 RID: 70535
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_PhysicBridge/BP/BP_BridgeModels_Broken.BP_BridgeModels_Broken_C";

		// Token: 0x04011388 RID: 70536
		private static IntPtr _ClassPtr;

		// Token: 0x04011389 RID: 70537
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401138A RID: 70538
		public static IntPtr __custom__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401138B RID: 70539
		internal static int __PropertyOffset_0;

		// Token: 0x0401138C RID: 70540
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401138D RID: 70541
		internal static int __PropertyOffset_1;

		// Token: 0x0401138E RID: 70542
		internal static int __PropertyOffset_2;

		// Token: 0x0401138F RID: 70543
		internal static int __PropertyOffset_3;

		// Token: 0x04011390 RID: 70544
		internal static int __PropertyOffset_4;

		// Token: 0x04011391 RID: 70545
		internal static int __PropertyOffset_5;

		// Token: 0x04011392 RID: 70546
		internal static int __PropertyOffset_6;

		// Token: 0x04011393 RID: 70547
		internal static int __PropertyOffset_7;

		// Token: 0x04011394 RID: 70548
		internal static int __PropertyOffset_8;

		// Token: 0x04011395 RID: 70549
		internal static int __PropertyOffset_9;

		// Token: 0x04011396 RID: 70550
		internal static int __PropertyOffset_10;

		// Token: 0x04011397 RID: 70551
		internal static int __PropertyOffset_11;

		// Token: 0x04011398 RID: 70552
		internal static int __PropertyOffset_12;

		// Token: 0x04011399 RID: 70553
		internal static int __PropertyOffset_13;

		// Token: 0x0401139A RID: 70554
		internal static int __PropertyOffset_14;

		// Token: 0x0401139B RID: 70555
		internal static int __PropertyOffset_15;

		// Token: 0x0401139C RID: 70556
		internal static int __PropertyOffset_16;

		// Token: 0x0401139D RID: 70557
		internal static int __PropertyOffset_17;

		// Token: 0x0401139E RID: 70558
		internal static int __PropertyOffset_18;

		// Token: 0x0401139F RID: 70559
		internal static int __PropertyOffset_19;

		// Token: 0x040113A0 RID: 70560
		internal static int __PropertyOffset_20;

		// Token: 0x040113A1 RID: 70561
		internal static int __PropertyOffset_21;

		// Token: 0x040113A2 RID: 70562
		internal static int __PropertyOffset_22;

		// Token: 0x040113A3 RID: 70563
		internal static int __PropertyOffset_23;

		// Token: 0x040113A4 RID: 70564
		internal static int __PropertyOffset_24;

		// Token: 0x040113A5 RID: 70565
		internal static int __PropertyOffset_25;

		// Token: 0x040113A6 RID: 70566
		internal static int __PropertyOffset_26;

		// Token: 0x040113A7 RID: 70567
		internal static int __PropertyOffset_27;

		// Token: 0x040113A8 RID: 70568
		internal static int __PropertyOffset_28;

		// Token: 0x040113A9 RID: 70569
		internal static int __PropertyOffset_29;

		// Token: 0x040113AA RID: 70570
		internal static int __PropertyOffset_30;

		// Token: 0x040113AB RID: 70571
		internal static int __PropertyOffset_31;

		// Token: 0x040113AC RID: 70572
		internal static int __PropertyOffset_32;

		// Token: 0x040113AD RID: 70573
		internal static int __PropertyOffset_33;

		// Token: 0x040113AE RID: 70574
		internal static int __PropertyOffset_34;

		// Token: 0x040113AF RID: 70575
		internal static int __PropertyOffset_35;

		// Token: 0x040113B0 RID: 70576
		internal static int __PropertyOffset_36;

		// Token: 0x040113B1 RID: 70577
		internal static int __PropertyOffset_37;

		// Token: 0x040113B2 RID: 70578
		internal static int __PropertyOffset_38;

		// Token: 0x040113B3 RID: 70579
		internal static int __PropertyOffset_39;

		// Token: 0x040113B4 RID: 70580
		internal static int __PropertyOffset_40;

		// Token: 0x040113B5 RID: 70581
		internal static int __PropertyOffset_41;

		// Token: 0x040113B6 RID: 70582
		internal static int __PropertyOffset_42;

		// Token: 0x040113B7 RID: 70583
		internal static int __PropertyOffset_43;

		// Token: 0x040113B8 RID: 70584
		internal static int __PropertyOffset_44;

		// Token: 0x040113B9 RID: 70585
		internal static int __PropertyOffset_45;

		// Token: 0x040113BA RID: 70586
		internal static int __PropertyOffset_46;

		// Token: 0x040113BB RID: 70587
		internal static int __PropertyOffset_47;

		// Token: 0x040113BC RID: 70588
		internal static int __PropertyOffset_48;

		// Token: 0x040113BD RID: 70589
		internal static int __PropertyOffset_49;

		// Token: 0x040113BE RID: 70590
		internal static int __PropertyOffset_50;

		// Token: 0x040113BF RID: 70591
		internal static int __PropertyOffset_51;

		// Token: 0x040113C0 RID: 70592
		internal static int __PropertyOffset_52;

		// Token: 0x040113C1 RID: 70593
		internal static int __PropertyOffset_53;

		// Token: 0x040113C2 RID: 70594
		internal static int __PropertyOffset_54;

		// Token: 0x040113C3 RID: 70595
		internal static int __PropertyOffset_55;

		// Token: 0x040113C4 RID: 70596
		internal static int __PropertyOffset_56;

		// Token: 0x040113C5 RID: 70597
		internal static int __PropertyOffset_57;

		// Token: 0x040113C6 RID: 70598
		internal static int __PropertyOffset_58;

		// Token: 0x040113C7 RID: 70599
		internal static int __PropertyOffset_59;

		// Token: 0x040113C8 RID: 70600
		internal static int __PropertyOffset_60;

		// Token: 0x040113C9 RID: 70601
		internal static int __PropertyOffset_61;

		// Token: 0x040113CA RID: 70602
		internal static int __PropertyOffset_62;

		// Token: 0x040113CB RID: 70603
		internal static int __PropertyOffset_63;

		// Token: 0x040113CC RID: 70604
		internal static int __PropertyOffset_64;

		// Token: 0x040113CD RID: 70605
		internal static int __PropertyOffset_65;

		// Token: 0x040113CE RID: 70606
		internal static int __PropertyOffset_66;

		// Token: 0x040113CF RID: 70607
		internal static int __PropertyOffset_67;

		// Token: 0x040113D0 RID: 70608
		internal static int __PropertyOffset_68;

		// Token: 0x040113D1 RID: 70609
		internal static int __PropertyOffset_69;

		// Token: 0x040113D2 RID: 70610
		internal static int __PropertyOffset_70;

		// Token: 0x040113D3 RID: 70611
		internal static int __PropertyOffset_71;

		// Token: 0x040113D4 RID: 70612
		internal static int __PropertyOffset_72;

		// Token: 0x040113D5 RID: 70613
		internal static int __PropertyOffset_73;

		// Token: 0x040113D6 RID: 70614
		internal static int __PropertyOffset_74;

		// Token: 0x040113D7 RID: 70615
		internal static int __PropertyOffset_75;

		// Token: 0x040113D8 RID: 70616
		internal static int __PropertyOffset_76;

		// Token: 0x040113D9 RID: 70617
		internal static int __PropertyOffset_77;

		// Token: 0x040113DA RID: 70618
		internal static int __PropertyOffset_78;

		// Token: 0x040113DB RID: 70619
		internal static int __PropertyOffset_79;

		// Token: 0x040113DC RID: 70620
		internal static int __PropertyOffset_80;

		// Token: 0x040113DD RID: 70621
		internal static int __PropertyOffset_81;

		// Token: 0x040113DE RID: 70622
		internal static int __PropertyOffset_82;

		// Token: 0x040113DF RID: 70623
		internal static int __PropertyOffset_83;

		// Token: 0x040113E0 RID: 70624
		internal static int __PropertyOffset_84;

		// Token: 0x040113E1 RID: 70625
		internal static int __PropertyOffset_85;

		// Token: 0x040113E2 RID: 70626
		internal static int __PropertyOffset_86;

		// Token: 0x040113E3 RID: 70627
		internal static int __PropertyOffset_87;

		// Token: 0x040113E4 RID: 70628
		internal static int __PropertyOffset_88;

		// Token: 0x040113E5 RID: 70629
		internal static int __PropertyOffset_89;

		// Token: 0x040113E6 RID: 70630
		internal static int __PropertyOffset_90;

		// Token: 0x040113E7 RID: 70631
		internal static int __PropertyOffset_91;

		// Token: 0x040113E8 RID: 70632
		internal static int __PropertyOffset_92;

		// Token: 0x040113E9 RID: 70633
		internal static int __PropertyOffset_93;

		// Token: 0x040113EA RID: 70634
		internal static int __PropertyOffset_94;

		// Token: 0x040113EB RID: 70635
		internal static int __PropertyOffset_95;

		// Token: 0x040113EC RID: 70636
		private custom _custom;

		// Token: 0x040113ED RID: 70637
		internal static int __PropertyOffset_96;

		// Token: 0x040113EE RID: 70638
		internal static int __PropertyOffset_97;

		// Token: 0x040113EF RID: 70639
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _BlockList;

		// Token: 0x040113F0 RID: 70640
		private static IntPtr __RecoverBlock_NativeFunctionPtr;

		// Token: 0x040113F1 RID: 70641
		private static IntPtr __SetSideBlockColli_NativeFunctionPtr;

		// Token: 0x040113F2 RID: 70642
		private static IntPtr __GetBridgeLink_NativeFunctionPtr;

		// Token: 0x040113F3 RID: 70643
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040113F4 RID: 70644
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040113F5 RID: 70645
		private static IntPtr __ExecuteUbergraph_BP_BridgeModels_Broken_NativeFunctionPtr;

		// Token: 0x02009B90 RID: 39824
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetSideBlockColli_FunctionParams
		{
			// Token: 0x0403239B RID: 205723
			[FieldOffset(0)]
			public bool IsBreak;
		}

		// Token: 0x02009B91 RID: 39825
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __GetBridgeLink_FunctionParams
		{
			// Token: 0x0403239C RID: 205724
			[FieldOffset(0)]
			public int idx;

			// Token: 0x0403239D RID: 205725
			[FieldOffset(8)]
			public byte tempArray1;
		}

		// Token: 0x02009B92 RID: 39826
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_BridgeModels_Broken_FunctionParams
		{
			// Token: 0x0403239E RID: 205726
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
