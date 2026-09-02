using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.AssestStruct
{
	// Token: 0x02003EED RID: 16109
	[UnrealObjectPath("/Game/Aki/Data/Fight/AssestStruct/BP_KiteConfig.BP_KiteConfig_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class BP_KiteConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060281AF RID: 164271 RVA: 0x00A02740 File Offset: 0x00A00940
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KiteConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Fight/AssestStruct/BP_KiteConfig.BP_KiteConfig_C");
			}
			return BP_KiteConfig_C._ClassPtr;
		}

		// Token: 0x060281B0 RID: 164272 RVA: 0x00A02764 File Offset: 0x00A00964
		public BP_KiteConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_KiteConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060281B1 RID: 164273 RVA: 0x00A0278C File Offset: 0x00A0098C
		[NullableContext(1)]
		public BP_KiteConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KiteConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006086 RID: 24710
		// (get) Token: 0x060281B2 RID: 164274 RVA: 0x00A027BF File Offset: 0x00A009BF
		// (set) Token: 0x060281B3 RID: 164275 RVA: 0x00A027CF File Offset: 0x00A009CF
		public unsafe float 收缩速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006087 RID: 24711
		// (get) Token: 0x060281B4 RID: 164276 RVA: 0x00A027E0 File Offset: 0x00A009E0
		// (set) Token: 0x060281B5 RID: 164277 RVA: 0x00A027F0 File Offset: 0x00A009F0
		public unsafe float 最短收缩距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006088 RID: 24712
		// (get) Token: 0x060281B6 RID: 164278 RVA: 0x00A02801 File Offset: 0x00A00A01
		// (set) Token: 0x060281B7 RID: 164279 RVA: 0x00A02811 File Offset: 0x00A00A11
		public unsafe float 重力强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006089 RID: 24713
		// (get) Token: 0x060281B8 RID: 164280 RVA: 0x00A02822 File Offset: 0x00A00A22
		// (set) Token: 0x060281B9 RID: 164281 RVA: 0x00A02832 File Offset: 0x00A00A32
		public unsafe float 速度衰减系数_每秒保留比例_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KiteConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x060281BA RID: 164282 RVA: 0x00A02843 File Offset: 0x00A00A43
		protected BP_KiteConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040150F8 RID: 86264
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Fight/AssestStruct/BP_KiteConfig.BP_KiteConfig_C";

		// Token: 0x040150F9 RID: 86265
		private static IntPtr _ClassPtr;

		// Token: 0x040150FA RID: 86266
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040150FB RID: 86267
		internal static int __PropertyOffset_0;

		// Token: 0x040150FC RID: 86268
		internal static int __PropertyOffset_1;

		// Token: 0x040150FD RID: 86269
		internal static int __PropertyOffset_2;

		// Token: 0x040150FE RID: 86270
		internal static int __PropertyOffset_3;
	}
}
