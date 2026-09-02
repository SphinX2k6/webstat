using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004270 RID: 17008
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SMovementSetting.SMovementSetting")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SMovementSetting : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D1A3 RID: 184739 RVA: 0x00AB75D1 File Offset: 0x00AB57D1
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovementSetting._ScriptStructPtr != 0) ? SMovementSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SMovementSetting.SMovementSetting", ref SMovementSetting._ScriptStructPtr);
		}

		// Token: 0x17007A8A RID: 31370
		// (get) Token: 0x0602D1A4 RID: 184740 RVA: 0x00AB75F5 File Offset: 0x00AB57F5
		// (set) Token: 0x0602D1A5 RID: 184741 RVA: 0x00AB7605 File Offset: 0x00AB5805
		public unsafe float WalkSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A8B RID: 31371
		// (get) Token: 0x0602D1A6 RID: 184742 RVA: 0x00AB7616 File Offset: 0x00AB5816
		// (set) Token: 0x0602D1A7 RID: 184743 RVA: 0x00AB7626 File Offset: 0x00AB5826
		public unsafe float RunSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A8C RID: 31372
		// (get) Token: 0x0602D1A8 RID: 184744 RVA: 0x00AB7637 File Offset: 0x00AB5837
		// (set) Token: 0x0602D1A9 RID: 184745 RVA: 0x00AB7647 File Offset: 0x00AB5847
		public unsafe float SprintSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A8D RID: 31373
		// (get) Token: 0x0602D1AA RID: 184746 RVA: 0x00AB7658 File Offset: 0x00AB5858
		// (set) Token: 0x0602D1AB RID: 184747 RVA: 0x00AB7668 File Offset: 0x00AB5868
		public unsafe float SwingSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A8E RID: 31374
		// (get) Token: 0x0602D1AC RID: 184748 RVA: 0x00AB7679 File Offset: 0x00AB5879
		// (set) Token: 0x0602D1AD RID: 184749 RVA: 0x00AB7689 File Offset: 0x00AB5889
		public unsafe float Acceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007A8F RID: 31375
		// (get) Token: 0x0602D1AE RID: 184750 RVA: 0x00AB769A File Offset: 0x00AB589A
		// (set) Token: 0x0602D1AF RID: 184751 RVA: 0x00AB76AA File Offset: 0x00AB58AA
		public unsafe float SwingAcceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007A90 RID: 31376
		// (get) Token: 0x0602D1B0 RID: 184752 RVA: 0x00AB76BB File Offset: 0x00AB58BB
		// (set) Token: 0x0602D1B1 RID: 184753 RVA: 0x00AB76CB File Offset: 0x00AB58CB
		public unsafe float GroundFriction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007A91 RID: 31377
		// (get) Token: 0x0602D1B2 RID: 184754 RVA: 0x00AB76DC File Offset: 0x00AB58DC
		// (set) Token: 0x0602D1B3 RID: 184755 RVA: 0x00AB76F0 File Offset: 0x00AB58F0
		public unsafe UCurveVector MovementCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SMovementSetting.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMovementSetting.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17007A92 RID: 31378
		// (get) Token: 0x0602D1B4 RID: 184756 RVA: 0x00AB7705 File Offset: 0x00AB5905
		// (set) Token: 0x0602D1B5 RID: 184757 RVA: 0x00AB7719 File Offset: 0x00AB5919
		public unsafe UCurveFloat RotationRateCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SMovementSetting.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMovementSetting.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17007A93 RID: 31379
		// (get) Token: 0x0602D1B6 RID: 184758 RVA: 0x00AB772E File Offset: 0x00AB592E
		// (set) Token: 0x0602D1B7 RID: 184759 RVA: 0x00AB773E File Offset: 0x00AB593E
		public unsafe float NormalSwimSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007A94 RID: 31380
		// (get) Token: 0x0602D1B8 RID: 184760 RVA: 0x00AB774F File Offset: 0x00AB594F
		// (set) Token: 0x0602D1B9 RID: 184761 RVA: 0x00AB775F File Offset: 0x00AB595F
		public unsafe float FastSwimSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007A95 RID: 31381
		// (get) Token: 0x0602D1BA RID: 184762 RVA: 0x00AB7770 File Offset: 0x00AB5970
		// (set) Token: 0x0602D1BB RID: 184763 RVA: 0x00AB7780 File Offset: 0x00AB5980
		public unsafe float ControllerRotationSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007A96 RID: 31382
		// (get) Token: 0x0602D1BC RID: 184764 RVA: 0x00AB7794 File Offset: 0x00AB5994
		// (set) Token: 0x0602D1BD RID: 184765 RVA: 0x00AB77D7 File Offset: 0x00AB59D7
		[Nullable(1)]
		public SMovementRotationSetting ControllerRotationSpeedSetting
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SMovementRotationSetting result;
				if ((result = this._ControllerRotationSpeedSetting) == null)
				{
					result = (this._ControllerRotationSpeedSetting = new SMovementRotationSetting(base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementRotationSetting.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D1BE RID: 184766 RVA: 0x00AB77F8 File Offset: 0x00AB59F8
		public SMovementSetting()
		{
		}

		// Token: 0x0602D1BF RID: 184767 RVA: 0x00AB7800 File Offset: 0x00AB5A00
		[NullableContext(1)]
		public SMovementSetting(float WalkSpeed, float RunSpeed, float SprintSpeed, float SwingSpeed, float Acceleration, float SwingAcceleration, float GroundFriction, UCurveVector MovementCurve, UCurveFloat RotationRateCurve, float NormalSwimSpeed, float FastSwimSpeed, float ControllerRotationSpeed, SMovementRotationSetting ControllerRotationSpeedSetting)
		{
			this.WalkSpeed = WalkSpeed;
			this.RunSpeed = RunSpeed;
			this.SprintSpeed = SprintSpeed;
			this.SwingSpeed = SwingSpeed;
			this.Acceleration = Acceleration;
			this.SwingAcceleration = SwingAcceleration;
			this.GroundFriction = GroundFriction;
			this.MovementCurve = MovementCurve;
			this.RotationRateCurve = RotationRateCurve;
			this.NormalSwimSpeed = NormalSwimSpeed;
			this.FastSwimSpeed = FastSwimSpeed;
			this.ControllerRotationSpeed = ControllerRotationSpeed;
			this.ControllerRotationSpeedSetting = ControllerRotationSpeedSetting;
		}

		// Token: 0x0602D1C0 RID: 184768 RVA: 0x00AB7878 File Offset: 0x00AB5A78
		protected override IntPtr GetUStructPtr()
		{
			return SMovementSetting.StaticStruct();
		}

		// Token: 0x0602D1C1 RID: 184769 RVA: 0x00AB7884 File Offset: 0x00AB5A84
		public SMovementSetting(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D1C2 RID: 184770 RVA: 0x00AB788E File Offset: 0x00AB5A8E
		public SMovementSetting(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D1C3 RID: 184771 RVA: 0x00AB7899 File Offset: 0x00AB5A99
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovementSetting(Pointer, false, true);
		}

		// Token: 0x0602D1C4 RID: 184772 RVA: 0x00AB78A3 File Offset: 0x00AB5AA3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovementSetting(Pointer, MemoryOwner);
		}

		// Token: 0x0401949A RID: 103578
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SMovementSetting.SMovementSetting";

		// Token: 0x0401949B RID: 103579
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401949C RID: 103580
		internal static int __PropertyOffset_0;

		// Token: 0x0401949D RID: 103581
		internal static int __PropertyOffset_1;

		// Token: 0x0401949E RID: 103582
		internal static int __PropertyOffset_2;

		// Token: 0x0401949F RID: 103583
		internal static int __PropertyOffset_3;

		// Token: 0x040194A0 RID: 103584
		internal static int __PropertyOffset_4;

		// Token: 0x040194A1 RID: 103585
		internal static int __PropertyOffset_5;

		// Token: 0x040194A2 RID: 103586
		internal static int __PropertyOffset_6;

		// Token: 0x040194A3 RID: 103587
		internal static int __PropertyOffset_7;

		// Token: 0x040194A4 RID: 103588
		internal static int __PropertyOffset_8;

		// Token: 0x040194A5 RID: 103589
		internal static int __PropertyOffset_9;

		// Token: 0x040194A6 RID: 103590
		internal static int __PropertyOffset_10;

		// Token: 0x040194A7 RID: 103591
		internal static int __PropertyOffset_11;

		// Token: 0x040194A8 RID: 103592
		internal static int __PropertyOffset_12;

		// Token: 0x040194A9 RID: 103593
		private SMovementRotationSetting _ControllerRotationSpeedSetting;
	}
}
