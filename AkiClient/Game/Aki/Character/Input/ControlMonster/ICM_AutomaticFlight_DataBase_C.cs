using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.ControlMonster
{
	// Token: 0x020041AF RID: 16815
	[UnrealObjectPath("/Game/Aki/Character/Input/ControlMonster/ICM_AutomaticFlight_DataBase.ICM_AutomaticFlight_DataBase_C")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 120)]
	public class ICM_AutomaticFlight_DataBase_C : UKuroBpDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CA27 RID: 182823 RVA: 0x00AA8884 File Offset: 0x00AA6A84
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ICM_AutomaticFlight_DataBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Input/ControlMonster/ICM_AutomaticFlight_DataBase.ICM_AutomaticFlight_DataBase_C");
			}
			return ICM_AutomaticFlight_DataBase_C._ClassPtr;
		}

		// Token: 0x0602CA28 RID: 182824 RVA: 0x00AA88A8 File Offset: 0x00AA6AA8
		public ICM_AutomaticFlight_DataBase_C() : this(BuiltinUtils.AllocNativeUObject(ICM_AutomaticFlight_DataBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CA29 RID: 182825 RVA: 0x00AA88D0 File Offset: 0x00AA6AD0
		[NullableContext(1)]
		public ICM_AutomaticFlight_DataBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ICM_AutomaticFlight_DataBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700785D RID: 30813
		// (get) Token: 0x0602CA2A RID: 182826 RVA: 0x00AA8903 File Offset: 0x00AA6B03
		// (set) Token: 0x0602CA2B RID: 182827 RVA: 0x00AA8913 File Offset: 0x00AA6B13
		public unsafe float 低飞行速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700785E RID: 30814
		// (get) Token: 0x0602CA2C RID: 182828 RVA: 0x00AA8924 File Offset: 0x00AA6B24
		// (set) Token: 0x0602CA2D RID: 182829 RVA: 0x00AA8934 File Offset: 0x00AA6B34
		public unsafe float 标准飞行速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700785F RID: 30815
		// (get) Token: 0x0602CA2E RID: 182830 RVA: 0x00AA8945 File Offset: 0x00AA6B45
		// (set) Token: 0x0602CA2F RID: 182831 RVA: 0x00AA8955 File Offset: 0x00AA6B55
		public unsafe float 高飞行速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007860 RID: 30816
		// (get) Token: 0x0602CA30 RID: 182832 RVA: 0x00AA8966 File Offset: 0x00AA6B66
		// (set) Token: 0x0602CA31 RID: 182833 RVA: 0x00AA897A File Offset: 0x00AA6B7A
		[Nullable(2)]
		public unsafe UCurveVector 速度过渡曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + ICM_AutomaticFlight_DataBase_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ICM_AutomaticFlight_DataBase_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007861 RID: 30817
		// (get) Token: 0x0602CA32 RID: 182834 RVA: 0x00AA898F File Offset: 0x00AA6B8F
		// (set) Token: 0x0602CA33 RID: 182835 RVA: 0x00AA899F File Offset: 0x00AA6B9F
		public unsafe float 前向轴输入响应比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007862 RID: 30818
		// (get) Token: 0x0602CA34 RID: 182836 RVA: 0x00AA89B0 File Offset: 0x00AA6BB0
		// (set) Token: 0x0602CA35 RID: 182837 RVA: 0x00AA89C0 File Offset: 0x00AA6BC0
		public unsafe int 前向轴输入响应技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007863 RID: 30819
		// (get) Token: 0x0602CA36 RID: 182838 RVA: 0x00AA89D1 File Offset: 0x00AA6BD1
		// (set) Token: 0x0602CA37 RID: 182839 RVA: 0x00AA89E1 File Offset: 0x00AA6BE1
		public unsafe float 后向轴输入响应比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007864 RID: 30820
		// (get) Token: 0x0602CA38 RID: 182840 RVA: 0x00AA89F2 File Offset: 0x00AA6BF2
		// (set) Token: 0x0602CA39 RID: 182841 RVA: 0x00AA8A02 File Offset: 0x00AA6C02
		public unsafe int 后向轴输入响应技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ICM_AutomaticFlight_DataBase_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602CA3A RID: 182842 RVA: 0x00AA8A13 File Offset: 0x00AA6C13
		protected ICM_AutomaticFlight_DataBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018D93 RID: 101779
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Input/ControlMonster/ICM_AutomaticFlight_DataBase.ICM_AutomaticFlight_DataBase_C";

		// Token: 0x04018D94 RID: 101780
		private static IntPtr _ClassPtr;

		// Token: 0x04018D95 RID: 101781
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018D96 RID: 101782
		internal static int __PropertyOffset_0;

		// Token: 0x04018D97 RID: 101783
		internal static int __PropertyOffset_1;

		// Token: 0x04018D98 RID: 101784
		internal static int __PropertyOffset_2;

		// Token: 0x04018D99 RID: 101785
		internal static int __PropertyOffset_3;

		// Token: 0x04018D9A RID: 101786
		internal static int __PropertyOffset_4;

		// Token: 0x04018D9B RID: 101787
		internal static int __PropertyOffset_5;

		// Token: 0x04018D9C RID: 101788
		internal static int __PropertyOffset_6;

		// Token: 0x04018D9D RID: 101789
		internal static int __PropertyOffset_7;
	}
}
