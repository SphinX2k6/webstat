using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI
{
	// Token: 0x02003C9F RID: 15519
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/PDA_GIUIData.PDA_GIUIData_C")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 104)]
	public class PDA_GIUIData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602490F RID: 149775 RVA: 0x009A11AC File Offset: 0x0099F3AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_GIUIData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/PDA_GIUIData.PDA_GIUIData_C");
			}
			return PDA_GIUIData_C._ClassPtr;
		}

		// Token: 0x06024910 RID: 149776 RVA: 0x009A11D0 File Offset: 0x0099F3D0
		public PDA_GIUIData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_GIUIData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024911 RID: 149777 RVA: 0x009A11F8 File Offset: 0x0099F3F8
		[NullableContext(1)]
		public PDA_GIUIData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_GIUIData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CC2 RID: 19650
		// (get) Token: 0x06024912 RID: 149778 RVA: 0x009A122B File Offset: 0x0099F42B
		// (set) Token: 0x06024913 RID: 149779 RVA: 0x009A123B File Offset: 0x0099F43B
		public unsafe bool HideSkyBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_GIUIData_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_GIUIData_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004CC3 RID: 19651
		// (get) Token: 0x06024914 RID: 149780 RVA: 0x009A124C File Offset: 0x0099F44C
		// (set) Token: 0x06024915 RID: 149781 RVA: 0x009A1260 File Offset: 0x0099F460
		[Nullable(2)]
		public unsafe UKuroWeatherDataAsset UIGIData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GIUIData_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_GIUIData_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CC4 RID: 19652
		// (get) Token: 0x06024916 RID: 149782 RVA: 0x009A1275 File Offset: 0x0099F475
		// (set) Token: 0x06024917 RID: 149783 RVA: 0x009A1285 File Offset: 0x0099F485
		public unsafe float SunVerticalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_GIUIData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_GIUIData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004CC5 RID: 19653
		// (get) Token: 0x06024918 RID: 149784 RVA: 0x009A1296 File Offset: 0x0099F496
		// (set) Token: 0x06024919 RID: 149785 RVA: 0x009A12A6 File Offset: 0x0099F4A6
		public unsafe float SunHorinzonAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_GIUIData_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_GIUIData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602491A RID: 149786 RVA: 0x009A12B7 File Offset: 0x0099F4B7
		protected PDA_GIUIData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012BDC RID: 76764
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/PDA_GIUIData.PDA_GIUIData_C";

		// Token: 0x04012BDD RID: 76765
		private static IntPtr _ClassPtr;

		// Token: 0x04012BDE RID: 76766
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012BDF RID: 76767
		internal static int __PropertyOffset_0;

		// Token: 0x04012BE0 RID: 76768
		internal static int __PropertyOffset_1;

		// Token: 0x04012BE1 RID: 76769
		internal static int __PropertyOffset_2;

		// Token: 0x04012BE2 RID: 76770
		internal static int __PropertyOffset_3;
	}
}
