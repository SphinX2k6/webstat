using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004272 RID: 17010
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SMovementSetting_State.SMovementSetting_State")]
	[UnrealStructLayout(1752, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1748)]
	public class SMovementSetting_State : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D1D1 RID: 184785 RVA: 0x00AB79EA File Offset: 0x00AB5BEA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovementSetting_State._ScriptStructPtr != 0) ? SMovementSetting_State._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SMovementSetting_State.SMovementSetting_State", ref SMovementSetting_State._ScriptStructPtr);
		}

		// Token: 0x17007A99 RID: 31385
		// (get) Token: 0x0602D1D2 RID: 184786 RVA: 0x00AB7A10 File Offset: 0x00AB5C10
		// (set) Token: 0x0602D1D3 RID: 184787 RVA: 0x00AB7A53 File Offset: 0x00AB5C53
		public SMovementSetting_Posture FaceDirection
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._FaceDirection) == null)
				{
					result = (this._FaceDirection = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A9A RID: 31386
		// (get) Token: 0x0602D1D4 RID: 184788 RVA: 0x00AB7A74 File Offset: 0x00AB5C74
		// (set) Token: 0x0602D1D5 RID: 184789 RVA: 0x00AB7AB7 File Offset: 0x00AB5CB7
		public SMovementSetting_Posture LockDirection
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._LockDirection) == null)
				{
					result = (this._LockDirection = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A9B RID: 31387
		// (get) Token: 0x0602D1D6 RID: 184790 RVA: 0x00AB7AD8 File Offset: 0x00AB5CD8
		// (set) Token: 0x0602D1D7 RID: 184791 RVA: 0x00AB7B1B File Offset: 0x00AB5D1B
		public SMovementSetting_Posture AimDirection
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._AimDirection) == null)
				{
					result = (this._AimDirection = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A9C RID: 31388
		// (get) Token: 0x0602D1D8 RID: 184792 RVA: 0x00AB7B3C File Offset: 0x00AB5D3C
		// (set) Token: 0x0602D1D9 RID: 184793 RVA: 0x00AB7B7F File Offset: 0x00AB5D7F
		public SMovementSetting_Posture CustomSetting00
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._CustomSetting00) == null)
				{
					result = (this._CustomSetting00 = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A9D RID: 31389
		// (get) Token: 0x0602D1DA RID: 184794 RVA: 0x00AB7BA0 File Offset: 0x00AB5DA0
		// (set) Token: 0x0602D1DB RID: 184795 RVA: 0x00AB7BE3 File Offset: 0x00AB5DE3
		public SMovementSetting_Posture CustomSetting01
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._CustomSetting01) == null)
				{
					result = (this._CustomSetting01 = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A9E RID: 31390
		// (get) Token: 0x0602D1DC RID: 184796 RVA: 0x00AB7C04 File Offset: 0x00AB5E04
		// (set) Token: 0x0602D1DD RID: 184797 RVA: 0x00AB7C47 File Offset: 0x00AB5E47
		public SMovementSetting_Posture CustomSetting02
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._CustomSetting02) == null)
				{
					result = (this._CustomSetting02 = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A9F RID: 31391
		// (get) Token: 0x0602D1DE RID: 184798 RVA: 0x00AB7C68 File Offset: 0x00AB5E68
		// (set) Token: 0x0602D1DF RID: 184799 RVA: 0x00AB7CAB File Offset: 0x00AB5EAB
		public SMovementSetting_Posture CustomSetting03
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._CustomSetting03) == null)
				{
					result = (this._CustomSetting03 = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AA0 RID: 31392
		// (get) Token: 0x0602D1E0 RID: 184800 RVA: 0x00AB7CCC File Offset: 0x00AB5ECC
		// (set) Token: 0x0602D1E1 RID: 184801 RVA: 0x00AB7D0F File Offset: 0x00AB5F0F
		public SMovementSetting_Posture CustomSetting04
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._CustomSetting04) == null)
				{
					result = (this._CustomSetting04 = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AA1 RID: 31393
		// (get) Token: 0x0602D1E2 RID: 184802 RVA: 0x00AB7D30 File Offset: 0x00AB5F30
		// (set) Token: 0x0602D1E3 RID: 184803 RVA: 0x00AB7D73 File Offset: 0x00AB5F73
		public SMovementSetting_Posture CustomSetting05
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting_Posture result;
				if ((result = this._CustomSetting05) == null)
				{
					result = (this._CustomSetting05 = new SMovementSetting_Posture(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_Posture.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AA2 RID: 31394
		// (get) Token: 0x0602D1E4 RID: 184804 RVA: 0x00AB7D94 File Offset: 0x00AB5F94
		// (set) Token: 0x0602D1E5 RID: 184805 RVA: 0x00AB7DA8 File Offset: 0x00AB5FA8
		[Nullable(0)]
		public unsafe TEnumAsByte<EWanderDirectionType> WanderDirection
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_9);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007AA3 RID: 31395
		// (get) Token: 0x0602D1E6 RID: 184806 RVA: 0x00AB7DBD File Offset: 0x00AB5FBD
		// (set) Token: 0x0602D1E7 RID: 184807 RVA: 0x00AB7DD1 File Offset: 0x00AB5FD1
		public unsafe FGameplayTag EnableTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007AA4 RID: 31396
		// (get) Token: 0x0602D1E8 RID: 184808 RVA: 0x00AB7DE6 File Offset: 0x00AB5FE6
		// (set) Token: 0x0602D1E9 RID: 184809 RVA: 0x00AB7DF6 File Offset: 0x00AB5FF6
		public unsafe float WalkableFloorAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMovementSetting_State.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x0602D1EA RID: 184810 RVA: 0x00AB7E07 File Offset: 0x00AB6007
		public SMovementSetting_State()
		{
		}

		// Token: 0x0602D1EB RID: 184811 RVA: 0x00AB7E10 File Offset: 0x00AB6010
		public SMovementSetting_State(SMovementSetting_Posture FaceDirection, SMovementSetting_Posture LockDirection, SMovementSetting_Posture AimDirection, SMovementSetting_Posture CustomSetting00, SMovementSetting_Posture CustomSetting01, SMovementSetting_Posture CustomSetting02, SMovementSetting_Posture CustomSetting03, SMovementSetting_Posture CustomSetting04, SMovementSetting_Posture CustomSetting05, [Nullable(0)] TEnumAsByte<EWanderDirectionType> WanderDirection, FGameplayTag EnableTag, float WalkableFloorAngle)
		{
			this.FaceDirection = FaceDirection;
			this.LockDirection = LockDirection;
			this.AimDirection = AimDirection;
			this.CustomSetting00 = CustomSetting00;
			this.CustomSetting01 = CustomSetting01;
			this.CustomSetting02 = CustomSetting02;
			this.CustomSetting03 = CustomSetting03;
			this.CustomSetting04 = CustomSetting04;
			this.CustomSetting05 = CustomSetting05;
			this.WanderDirection = WanderDirection;
			this.EnableTag = EnableTag;
			this.WalkableFloorAngle = WalkableFloorAngle;
		}

		// Token: 0x0602D1EC RID: 184812 RVA: 0x00AB7E80 File Offset: 0x00AB6080
		protected override IntPtr GetUStructPtr()
		{
			return SMovementSetting_State.StaticStruct();
		}

		// Token: 0x0602D1ED RID: 184813 RVA: 0x00AB7E8C File Offset: 0x00AB608C
		[NullableContext(2)]
		public SMovementSetting_State(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D1EE RID: 184814 RVA: 0x00AB7E96 File Offset: 0x00AB6096
		public SMovementSetting_State(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D1EF RID: 184815 RVA: 0x00AB7EA1 File Offset: 0x00AB60A1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovementSetting_State(Pointer, false, true);
		}

		// Token: 0x0602D1F0 RID: 184816 RVA: 0x00AB7EAB File Offset: 0x00AB60AB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovementSetting_State(Pointer, MemoryOwner);
		}

		// Token: 0x040194B0 RID: 103600
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SMovementSetting_State.SMovementSetting_State";

		// Token: 0x040194B1 RID: 103601
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040194B2 RID: 103602
		internal static int __PropertyOffset_0;

		// Token: 0x040194B3 RID: 103603
		[Nullable(2)]
		private SMovementSetting_Posture _FaceDirection;

		// Token: 0x040194B4 RID: 103604
		internal static int __PropertyOffset_1;

		// Token: 0x040194B5 RID: 103605
		[Nullable(2)]
		private SMovementSetting_Posture _LockDirection;

		// Token: 0x040194B6 RID: 103606
		internal static int __PropertyOffset_2;

		// Token: 0x040194B7 RID: 103607
		[Nullable(2)]
		private SMovementSetting_Posture _AimDirection;

		// Token: 0x040194B8 RID: 103608
		internal static int __PropertyOffset_3;

		// Token: 0x040194B9 RID: 103609
		[Nullable(2)]
		private SMovementSetting_Posture _CustomSetting00;

		// Token: 0x040194BA RID: 103610
		internal static int __PropertyOffset_4;

		// Token: 0x040194BB RID: 103611
		[Nullable(2)]
		private SMovementSetting_Posture _CustomSetting01;

		// Token: 0x040194BC RID: 103612
		internal static int __PropertyOffset_5;

		// Token: 0x040194BD RID: 103613
		[Nullable(2)]
		private SMovementSetting_Posture _CustomSetting02;

		// Token: 0x040194BE RID: 103614
		internal static int __PropertyOffset_6;

		// Token: 0x040194BF RID: 103615
		[Nullable(2)]
		private SMovementSetting_Posture _CustomSetting03;

		// Token: 0x040194C0 RID: 103616
		internal static int __PropertyOffset_7;

		// Token: 0x040194C1 RID: 103617
		[Nullable(2)]
		private SMovementSetting_Posture _CustomSetting04;

		// Token: 0x040194C2 RID: 103618
		internal static int __PropertyOffset_8;

		// Token: 0x040194C3 RID: 103619
		[Nullable(2)]
		private SMovementSetting_Posture _CustomSetting05;

		// Token: 0x040194C4 RID: 103620
		internal static int __PropertyOffset_9;

		// Token: 0x040194C5 RID: 103621
		internal static int __PropertyOffset_10;

		// Token: 0x040194C6 RID: 103622
		internal static int __PropertyOffset_11;
	}
}
