using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.UI.View.Morale
{
	// Token: 0x02003DF2 RID: 15858
	[UnrealObjectPath("/Game/Aki/Data/UI/View/Morale/BP_MoraleEffectConfig.BP_MoraleEffectConfig_C")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 104)]
	public class BP_MoraleEffectConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027025 RID: 159781 RVA: 0x009E7BC8 File Offset: 0x009E5DC8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MoraleEffectConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/UI/View/Morale/BP_MoraleEffectConfig.BP_MoraleEffectConfig_C");
			}
			return BP_MoraleEffectConfig_C._ClassPtr;
		}

		// Token: 0x06027026 RID: 159782 RVA: 0x009E7BEC File Offset: 0x009E5DEC
		public BP_MoraleEffectConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_MoraleEffectConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027027 RID: 159783 RVA: 0x009E7C14 File Offset: 0x009E5E14
		[NullableContext(1)]
		public BP_MoraleEffectConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MoraleEffectConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005A83 RID: 23171
		// (get) Token: 0x06027028 RID: 159784 RVA: 0x009E7C47 File Offset: 0x009E5E47
		// (set) Token: 0x06027029 RID: 159785 RVA: 0x009E7C57 File Offset: 0x009E5E57
		public unsafe int 格子入场批次
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005A84 RID: 23172
		// (get) Token: 0x0602702A RID: 159786 RVA: 0x009E7C68 File Offset: 0x009E5E68
		// (set) Token: 0x0602702B RID: 159787 RVA: 0x009E7C78 File Offset: 0x009E5E78
		public unsafe int 格子入场批次间隔时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005A85 RID: 23173
		// (get) Token: 0x0602702C RID: 159788 RVA: 0x009E7C89 File Offset: 0x009E5E89
		// (set) Token: 0x0602702D RID: 159789 RVA: 0x009E7C9D File Offset: 0x009E5E9D
		[Nullable(2)]
		public unsafe UCurveFloat 格子入场曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoraleEffectConfig_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MoraleEffectConfig_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005A86 RID: 23174
		// (get) Token: 0x0602702E RID: 159790 RVA: 0x009E7CB2 File Offset: 0x009E5EB2
		// (set) Token: 0x0602702F RID: 159791 RVA: 0x009E7CC2 File Offset: 0x009E5EC2
		public unsafe int 解锁新格子播放前间隔时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005A87 RID: 23175
		// (get) Token: 0x06027030 RID: 159792 RVA: 0x009E7CD3 File Offset: 0x009E5ED3
		// (set) Token: 0x06027031 RID: 159793 RVA: 0x009E7CE3 File Offset: 0x009E5EE3
		public unsafe int 解锁新格子播放所需时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MoraleEffectConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x06027032 RID: 159794 RVA: 0x009E7CF4 File Offset: 0x009E5EF4
		protected BP_MoraleEffectConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040145F1 RID: 83441
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/UI/View/Morale/BP_MoraleEffectConfig.BP_MoraleEffectConfig_C";

		// Token: 0x040145F2 RID: 83442
		private static IntPtr _ClassPtr;

		// Token: 0x040145F3 RID: 83443
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040145F4 RID: 83444
		internal static int __PropertyOffset_0;

		// Token: 0x040145F5 RID: 83445
		internal static int __PropertyOffset_1;

		// Token: 0x040145F6 RID: 83446
		internal static int __PropertyOffset_2;

		// Token: 0x040145F7 RID: 83447
		internal static int __PropertyOffset_3;

		// Token: 0x040145F8 RID: 83448
		internal static int __PropertyOffset_4;
	}
}
