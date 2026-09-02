using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.Lensflare;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.VolumetricConeLight;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc
{
	// Token: 0x02003D68 RID: 15720
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Npc/PD_MotorExtraComponentData.PD_MotorExtraComponentData_C")]
	[UnrealStructLayout(352, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 344)]
	public class PD_MotorExtraComponentData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060263E3 RID: 156643 RVA: 0x009D29F4 File Offset: 0x009D0BF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_MotorExtraComponentData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Npc/PD_MotorExtraComponentData.PD_MotorExtraComponentData_C");
			}
			return PD_MotorExtraComponentData_C._ClassPtr;
		}

		// Token: 0x060263E4 RID: 156644 RVA: 0x009D2A18 File Offset: 0x009D0C18
		public PD_MotorExtraComponentData_C() : this(BuiltinUtils.AllocNativeUObject(PD_MotorExtraComponentData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060263E5 RID: 156645 RVA: 0x009D2A40 File Offset: 0x009D0C40
		[NullableContext(1)]
		public PD_MotorExtraComponentData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_MotorExtraComponentData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700562A RID: 22058
		// (get) Token: 0x060263E6 RID: 156646 RVA: 0x009D2A73 File Offset: 0x009D0C73
		// (set) Token: 0x060263E7 RID: 156647 RVA: 0x009D2A87 File Offset: 0x009D0C87
		public unsafe USkeletalMesh MotorMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_MotorExtraComponentData_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_MotorExtraComponentData_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700562B RID: 22059
		// (get) Token: 0x060263E8 RID: 156648 RVA: 0x009D2A9C File Offset: 0x009D0C9C
		// (set) Token: 0x060263E9 RID: 156649 RVA: 0x009D2AB0 File Offset: 0x009D0CB0
		public unsafe FName AO贴花插槽名
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700562C RID: 22060
		// (get) Token: 0x060263EA RID: 156650 RVA: 0x009D2AC5 File Offset: 0x009D0CC5
		// (set) Token: 0x060263EB RID: 156651 RVA: 0x009D2AD9 File Offset: 0x009D0CD9
		public unsafe FTransform AO贴花位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700562D RID: 22061
		// (get) Token: 0x060263EC RID: 156652 RVA: 0x009D2AEE File Offset: 0x009D0CEE
		// (set) Token: 0x060263ED RID: 156653 RVA: 0x009D2B02 File Offset: 0x009D0D02
		public unsafe UMaterialInstance AO_Decal_Mat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_MotorExtraComponentData_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_MotorExtraComponentData_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700562E RID: 22062
		// (get) Token: 0x060263EE RID: 156654 RVA: 0x009D2B18 File Offset: 0x009D0D18
		// (set) Token: 0x060263EF RID: 156655 RVA: 0x009D2B51 File Offset: 0x009D0D51
		[Nullable(1)]
		public TArray<PD_CharacterControllerData_C> FX_DA
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<PD_CharacterControllerData_C> result;
				if ((result = this._FX_DA) == null)
				{
					result = (this._FX_DA = new TArray<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.FX_DA.CopyAssign(value);
			}
		}

		// Token: 0x1700562F RID: 22063
		// (get) Token: 0x060263F0 RID: 156656 RVA: 0x009D2B5F File Offset: 0x009D0D5F
		// (set) Token: 0x060263F1 RID: 156657 RVA: 0x009D2B73 File Offset: 0x009D0D73
		public unsafe FName 车灯插槽名
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005630 RID: 22064
		// (get) Token: 0x060263F2 RID: 156658 RVA: 0x009D2B88 File Offset: 0x009D0D88
		// (set) Token: 0x060263F3 RID: 156659 RVA: 0x009D2B9C File Offset: 0x009D0D9C
		public unsafe FTransform 车灯位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005631 RID: 22065
		// (get) Token: 0x060263F4 RID: 156660 RVA: 0x009D2BB1 File Offset: 0x009D0DB1
		// (set) Token: 0x060263F5 RID: 156661 RVA: 0x009D2BC5 File Offset: 0x009D0DC5
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_VolumetricConeLightShaft_InMotor_C> 车灯蓝图
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_7);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005632 RID: 22066
		// (get) Token: 0x060263F6 RID: 156662 RVA: 0x009D2BDA File Offset: 0x009D0DDA
		// (set) Token: 0x060263F7 RID: 156663 RVA: 0x009D2BEE File Offset: 0x009D0DEE
		public unsafe FName 炫光插槽名
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005633 RID: 22067
		// (get) Token: 0x060263F8 RID: 156664 RVA: 0x009D2C03 File Offset: 0x009D0E03
		// (set) Token: 0x060263F9 RID: 156665 RVA: 0x009D2C17 File Offset: 0x009D0E17
		public unsafe FTransform 炫光位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005634 RID: 22068
		// (get) Token: 0x060263FA RID: 156666 RVA: 0x009D2C2C File Offset: 0x009D0E2C
		// (set) Token: 0x060263FB RID: 156667 RVA: 0x009D2C40 File Offset: 0x009D0E40
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_SceneLensflare_Motor_C> 炫光蓝图
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_10);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)PD_MotorExtraComponentData_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x060263FC RID: 156668 RVA: 0x009D2C55 File Offset: 0x009D0E55
		protected PD_MotorExtraComponentData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013D45 RID: 81221
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Npc/PD_MotorExtraComponentData.PD_MotorExtraComponentData_C";

		// Token: 0x04013D46 RID: 81222
		private static IntPtr _ClassPtr;

		// Token: 0x04013D47 RID: 81223
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013D48 RID: 81224
		internal static int __PropertyOffset_0;

		// Token: 0x04013D49 RID: 81225
		internal static int __PropertyOffset_1;

		// Token: 0x04013D4A RID: 81226
		internal static int __PropertyOffset_2;

		// Token: 0x04013D4B RID: 81227
		internal static int __PropertyOffset_3;

		// Token: 0x04013D4C RID: 81228
		internal static int __PropertyOffset_4;

		// Token: 0x04013D4D RID: 81229
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<PD_CharacterControllerData_C> _FX_DA;

		// Token: 0x04013D4E RID: 81230
		internal static int __PropertyOffset_5;

		// Token: 0x04013D4F RID: 81231
		internal static int __PropertyOffset_6;

		// Token: 0x04013D50 RID: 81232
		internal static int __PropertyOffset_7;

		// Token: 0x04013D51 RID: 81233
		internal static int __PropertyOffset_8;

		// Token: 0x04013D52 RID: 81234
		internal static int __PropertyOffset_9;

		// Token: 0x04013D53 RID: 81235
		internal static int __PropertyOffset_10;
	}
}
