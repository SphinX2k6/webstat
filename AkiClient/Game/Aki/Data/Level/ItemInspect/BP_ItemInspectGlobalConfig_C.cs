using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.ItemInspect
{
	// Token: 0x02003E7D RID: 15997
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/ItemInspect/BP_ItemInspectGlobalConfig.BP_ItemInspectGlobalConfig_C")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 208)]
	public class BP_ItemInspectGlobalConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060279E8 RID: 162280 RVA: 0x009F6538 File Offset: 0x009F4738
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ItemInspectGlobalConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/ItemInspect/BP_ItemInspectGlobalConfig.BP_ItemInspectGlobalConfig_C");
			}
			return BP_ItemInspectGlobalConfig_C._ClassPtr;
		}

		// Token: 0x060279E9 RID: 162281 RVA: 0x009F655C File Offset: 0x009F475C
		public BP_ItemInspectGlobalConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_ItemInspectGlobalConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060279EA RID: 162282 RVA: 0x009F6584 File Offset: 0x009F4784
		public BP_ItemInspectGlobalConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ItemInspectGlobalConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005DEF RID: 24047
		// (get) Token: 0x060279EB RID: 162283 RVA: 0x009F65B7 File Offset: 0x009F47B7
		// (set) Token: 0x060279EC RID: 162284 RVA: 0x009F65C7 File Offset: 0x009F47C7
		public unsafe float 输入速度限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005DF0 RID: 24048
		// (get) Token: 0x060279ED RID: 162285 RVA: 0x009F65D8 File Offset: 0x009F47D8
		// (set) Token: 0x060279EE RID: 162286 RVA: 0x009F65E8 File Offset: 0x009F47E8
		public unsafe float 平滑插值旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005DF1 RID: 24049
		// (get) Token: 0x060279EF RID: 162287 RVA: 0x009F65F9 File Offset: 0x009F47F9
		// (set) Token: 0x060279F0 RID: 162288 RVA: 0x009F6609 File Offset: 0x009F4809
		public unsafe float 重置旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005DF2 RID: 24050
		// (get) Token: 0x060279F1 RID: 162289 RVA: 0x009F661A File Offset: 0x009F481A
		// (set) Token: 0x060279F2 RID: 162290 RVA: 0x009F662F File Offset: 0x009F482F
		public TSoftObjectPtr<UStaticMesh> 压暗网格体
		{
			get
			{
				return new TSoftObjectPtr<UStaticMesh>(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_3, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005DF3 RID: 24051
		// (get) Token: 0x060279F3 RID: 162291 RVA: 0x009F6654 File Offset: 0x009F4854
		// (set) Token: 0x060279F4 RID: 162292 RVA: 0x009F6669 File Offset: 0x009F4869
		public TSoftObjectPtr<UMaterialInstance> 压暗材质
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_4, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005DF4 RID: 24052
		// (get) Token: 0x060279F5 RID: 162293 RVA: 0x009F668E File Offset: 0x009F488E
		// (set) Token: 0x060279F6 RID: 162294 RVA: 0x009F669E File Offset: 0x009F489E
		public unsafe float 压暗不透明度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005DF5 RID: 24053
		// (get) Token: 0x060279F7 RID: 162295 RVA: 0x009F66AF File Offset: 0x009F48AF
		// (set) Token: 0x060279F8 RID: 162296 RVA: 0x009F66BF File Offset: 0x009F48BF
		public unsafe float 压暗过渡时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005DF6 RID: 24054
		// (get) Token: 0x060279F9 RID: 162297 RVA: 0x009F66D0 File Offset: 0x009F48D0
		// (set) Token: 0x060279FA RID: 162298 RVA: 0x009F66E0 File Offset: 0x009F48E0
		public unsafe float 压暗过渡间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005DF7 RID: 24055
		// (get) Token: 0x060279FB RID: 162299 RVA: 0x009F66F1 File Offset: 0x009F48F1
		// (set) Token: 0x060279FC RID: 162300 RVA: 0x009F6701 File Offset: 0x009F4901
		public unsafe float 压暗屏幕深度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ItemInspectGlobalConfig_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x060279FD RID: 162301 RVA: 0x009F6712 File Offset: 0x009F4912
		protected BP_ItemInspectGlobalConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014C4B RID: 85067
		public new const string __ObjectPath = "/Game/Aki/Data/Level/ItemInspect/BP_ItemInspectGlobalConfig.BP_ItemInspectGlobalConfig_C";

		// Token: 0x04014C4C RID: 85068
		private static IntPtr _ClassPtr;

		// Token: 0x04014C4D RID: 85069
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014C4E RID: 85070
		internal static int __PropertyOffset_0;

		// Token: 0x04014C4F RID: 85071
		internal static int __PropertyOffset_1;

		// Token: 0x04014C50 RID: 85072
		internal static int __PropertyOffset_2;

		// Token: 0x04014C51 RID: 85073
		internal static int __PropertyOffset_3;

		// Token: 0x04014C52 RID: 85074
		internal static int __PropertyOffset_4;

		// Token: 0x04014C53 RID: 85075
		internal static int __PropertyOffset_5;

		// Token: 0x04014C54 RID: 85076
		internal static int __PropertyOffset_6;

		// Token: 0x04014C55 RID: 85077
		internal static int __PropertyOffset_7;

		// Token: 0x04014C56 RID: 85078
		internal static int __PropertyOffset_8;
	}
}
