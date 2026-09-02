using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.Blueprints
{
	// Token: 0x020041B1 RID: 16817
	[UnrealObjectPath("/Game/Aki/Character/Input/Blueprints/BP_CameraDrivenAutoFlightData.BP_CameraDrivenAutoFlightData_C")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 108)]
	public class BP_CameraDrivenAutoFlightData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CA41 RID: 182849 RVA: 0x00AA8B89 File Offset: 0x00AA6D89
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CameraDrivenAutoFlightData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Input/Blueprints/BP_CameraDrivenAutoFlightData.BP_CameraDrivenAutoFlightData_C");
			}
			return BP_CameraDrivenAutoFlightData_C._ClassPtr;
		}

		// Token: 0x0602CA42 RID: 182850 RVA: 0x00AA8BB0 File Offset: 0x00AA6DB0
		public BP_CameraDrivenAutoFlightData_C() : this(BuiltinUtils.AllocNativeUObject(BP_CameraDrivenAutoFlightData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CA43 RID: 182851 RVA: 0x00AA8BD8 File Offset: 0x00AA6DD8
		[NullableContext(1)]
		public BP_CameraDrivenAutoFlightData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CameraDrivenAutoFlightData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007865 RID: 30821
		// (get) Token: 0x0602CA44 RID: 182852 RVA: 0x00AA8C0B File Offset: 0x00AA6E0B
		// (set) Token: 0x0602CA45 RID: 182853 RVA: 0x00AA8C1B File Offset: 0x00AA6E1B
		public unsafe float 自动驾驶开始时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007866 RID: 30822
		// (get) Token: 0x0602CA46 RID: 182854 RVA: 0x00AA8C2C File Offset: 0x00AA6E2C
		// (set) Token: 0x0602CA47 RID: 182855 RVA: 0x00AA8C3C File Offset: 0x00AA6E3C
		public unsafe float 自动驾驶启动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007867 RID: 30823
		// (get) Token: 0x0602CA48 RID: 182856 RVA: 0x00AA8C4D File Offset: 0x00AA6E4D
		// (set) Token: 0x0602CA49 RID: 182857 RVA: 0x00AA8C5D File Offset: 0x00AA6E5D
		public unsafe float 自动驾驶完成角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007868 RID: 30824
		// (get) Token: 0x0602CA4A RID: 182858 RVA: 0x00AA8C6E File Offset: 0x00AA6E6E
		// (set) Token: 0x0602CA4B RID: 182859 RVA: 0x00AA8C7E File Offset: 0x00AA6E7E
		public unsafe float 自动驾驶归正角度Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007869 RID: 30825
		// (get) Token: 0x0602CA4C RID: 182860 RVA: 0x00AA8C8F File Offset: 0x00AA6E8F
		// (set) Token: 0x0602CA4D RID: 182861 RVA: 0x00AA8C9F File Offset: 0x00AA6E9F
		public unsafe float 自动驾驶归正角度Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700786A RID: 30826
		// (get) Token: 0x0602CA4E RID: 182862 RVA: 0x00AA8CB0 File Offset: 0x00AA6EB0
		// (set) Token: 0x0602CA4F RID: 182863 RVA: 0x00AA8CC0 File Offset: 0x00AA6EC0
		public unsafe float 自动驾驶归正角度模拟输入Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700786B RID: 30827
		// (get) Token: 0x0602CA50 RID: 182864 RVA: 0x00AA8CD1 File Offset: 0x00AA6ED1
		// (set) Token: 0x0602CA51 RID: 182865 RVA: 0x00AA8CE1 File Offset: 0x00AA6EE1
		public unsafe float 自动驾驶归正角度模拟输入Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CameraDrivenAutoFlightData_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602CA52 RID: 182866 RVA: 0x00AA8CF2 File Offset: 0x00AA6EF2
		protected BP_CameraDrivenAutoFlightData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018DA3 RID: 101795
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Input/Blueprints/BP_CameraDrivenAutoFlightData.BP_CameraDrivenAutoFlightData_C";

		// Token: 0x04018DA4 RID: 101796
		private static IntPtr _ClassPtr;

		// Token: 0x04018DA5 RID: 101797
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018DA6 RID: 101798
		internal static int __PropertyOffset_0;

		// Token: 0x04018DA7 RID: 101799
		internal static int __PropertyOffset_1;

		// Token: 0x04018DA8 RID: 101800
		internal static int __PropertyOffset_2;

		// Token: 0x04018DA9 RID: 101801
		internal static int __PropertyOffset_3;

		// Token: 0x04018DAA RID: 101802
		internal static int __PropertyOffset_4;

		// Token: 0x04018DAB RID: 101803
		internal static int __PropertyOffset_5;

		// Token: 0x04018DAC RID: 101804
		internal static int __PropertyOffset_6;
	}
}
