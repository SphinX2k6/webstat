using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED4 RID: 16084
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SLockOnFollowShooterAutoAim.SLockOnFollowShooterAutoAim")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 192)]
	public class SLockOnFollowShooterAutoAim : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027FD5 RID: 163797 RVA: 0x009FFCA8 File Offset: 0x009FDEA8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLockOnFollowShooterAutoAim._ScriptStructPtr != 0) ? SLockOnFollowShooterAutoAim._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SLockOnFollowShooterAutoAim.SLockOnFollowShooterAutoAim", ref SLockOnFollowShooterAutoAim._ScriptStructPtr);
		}

		// Token: 0x17005FDF RID: 24543
		// (get) Token: 0x06027FD6 RID: 163798 RVA: 0x009FFCCC File Offset: 0x009FDECC
		// (set) Token: 0x06027FD7 RID: 163799 RVA: 0x009FFCE0 File Offset: 0x009FDEE0
		public unsafe FName ShouldAimAtLockOnTargetName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005FE0 RID: 24544
		// (get) Token: 0x06027FD8 RID: 163800 RVA: 0x009FFCF5 File Offset: 0x009FDEF5
		// (set) Token: 0x06027FD9 RID: 163801 RVA: 0x009FFD05 File Offset: 0x009FDF05
		public unsafe float RotationInterpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005FE1 RID: 24545
		// (get) Token: 0x06027FDA RID: 163802 RVA: 0x009FFD16 File Offset: 0x009FDF16
		// (set) Token: 0x06027FDB RID: 163803 RVA: 0x009FFD26 File Offset: 0x009FDF26
		public unsafe float AutoShootAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005FE2 RID: 24546
		// (get) Token: 0x06027FDC RID: 163804 RVA: 0x009FFD37 File Offset: 0x009FDF37
		// (set) Token: 0x06027FDD RID: 163805 RVA: 0x009FFD47 File Offset: 0x009FDF47
		public unsafe float AutoShootGapTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005FE3 RID: 24547
		// (get) Token: 0x06027FDE RID: 163806 RVA: 0x009FFD58 File Offset: 0x009FDF58
		// (set) Token: 0x06027FDF RID: 163807 RVA: 0x009FFD6C File Offset: 0x009FDF6C
		public unsafe FRotator RotateOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005FE4 RID: 24548
		// (get) Token: 0x06027FE0 RID: 163808 RVA: 0x009FFD84 File Offset: 0x009FDF84
		// (set) Token: 0x06027FE1 RID: 163809 RVA: 0x009FFDC7 File Offset: 0x009FDFC7
		public TMap<FGameplayTag, SLockOnFollowShooterAttachmentRule> MapAttachToFollowingWhileHasTag
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, SLockOnFollowShooterAttachmentRule> result;
				if ((result = this._MapAttachToFollowingWhileHasTag) == null)
				{
					result = (this._MapAttachToFollowingWhileHasTag = new TMap<FGameplayTag, SLockOnFollowShooterAttachmentRule>(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MapAttachToFollowingWhileHasTag.CopyAssign(value);
			}
		}

		// Token: 0x17005FE5 RID: 24549
		// (get) Token: 0x06027FE2 RID: 163810 RVA: 0x009FFDD8 File Offset: 0x009FDFD8
		// (set) Token: 0x06027FE3 RID: 163811 RVA: 0x009FFE1B File Offset: 0x009FE01B
		public FGameplayTagContainer StopUpdateRotationWhileHasTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._StopUpdateRotationWhileHasTags) == null)
				{
					result = (this._StopUpdateRotationWhileHasTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FE6 RID: 24550
		// (get) Token: 0x06027FE4 RID: 163812 RVA: 0x009FFE3C File Offset: 0x009FE03C
		// (set) Token: 0x06027FE5 RID: 163813 RVA: 0x009FFE4C File Offset: 0x009FE04C
		public unsafe int AutoShootSkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005FE7 RID: 24551
		// (get) Token: 0x06027FE6 RID: 163814 RVA: 0x009FFE60 File Offset: 0x009FE060
		// (set) Token: 0x06027FE7 RID: 163815 RVA: 0x009FFEA3 File Offset: 0x009FE0A3
		public FGameplayTagContainer HideWhileHasTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._HideWhileHasTags) == null)
				{
					result = (this._HideWhileHasTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SLockOnFollowShooterAutoAim.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027FE8 RID: 163816 RVA: 0x009FFEC4 File Offset: 0x009FE0C4
		public SLockOnFollowShooterAutoAim()
		{
		}

		// Token: 0x06027FE9 RID: 163817 RVA: 0x009FFECC File Offset: 0x009FE0CC
		public SLockOnFollowShooterAutoAim(FName ShouldAimAtLockOnTargetName, float RotationInterpSpeed, float AutoShootAngle, float AutoShootGapTime, FRotator RotateOffset, TMap<FGameplayTag, SLockOnFollowShooterAttachmentRule> MapAttachToFollowingWhileHasTag, FGameplayTagContainer StopUpdateRotationWhileHasTags, int AutoShootSkillId, FGameplayTagContainer HideWhileHasTags)
		{
			this.ShouldAimAtLockOnTargetName = ShouldAimAtLockOnTargetName;
			this.RotationInterpSpeed = RotationInterpSpeed;
			this.AutoShootAngle = AutoShootAngle;
			this.AutoShootGapTime = AutoShootGapTime;
			this.RotateOffset = RotateOffset;
			this.MapAttachToFollowingWhileHasTag = MapAttachToFollowingWhileHasTag;
			this.StopUpdateRotationWhileHasTags = StopUpdateRotationWhileHasTags;
			this.AutoShootSkillId = AutoShootSkillId;
			this.HideWhileHasTags = HideWhileHasTags;
		}

		// Token: 0x06027FEA RID: 163818 RVA: 0x009FFF24 File Offset: 0x009FE124
		protected override IntPtr GetUStructPtr()
		{
			return SLockOnFollowShooterAutoAim.StaticStruct();
		}

		// Token: 0x06027FEB RID: 163819 RVA: 0x009FFF30 File Offset: 0x009FE130
		[NullableContext(2)]
		public SLockOnFollowShooterAutoAim(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027FEC RID: 163820 RVA: 0x009FFF3A File Offset: 0x009FE13A
		public SLockOnFollowShooterAutoAim(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027FED RID: 163821 RVA: 0x009FFF45 File Offset: 0x009FE145
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLockOnFollowShooterAutoAim(Pointer, false, true);
		}

		// Token: 0x06027FEE RID: 163822 RVA: 0x009FFF4F File Offset: 0x009FE14F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLockOnFollowShooterAutoAim(Pointer, MemoryOwner);
		}

		// Token: 0x04014FEB RID: 85995
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SLockOnFollowShooterAutoAim.SLockOnFollowShooterAutoAim";

		// Token: 0x04014FEC RID: 85996
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014FED RID: 85997
		internal static int __PropertyOffset_0;

		// Token: 0x04014FEE RID: 85998
		internal static int __PropertyOffset_1;

		// Token: 0x04014FEF RID: 85999
		internal static int __PropertyOffset_2;

		// Token: 0x04014FF0 RID: 86000
		internal static int __PropertyOffset_3;

		// Token: 0x04014FF1 RID: 86001
		internal static int __PropertyOffset_4;

		// Token: 0x04014FF2 RID: 86002
		internal static int __PropertyOffset_5;

		// Token: 0x04014FF3 RID: 86003
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, SLockOnFollowShooterAttachmentRule> _MapAttachToFollowingWhileHasTag;

		// Token: 0x04014FF4 RID: 86004
		internal static int __PropertyOffset_6;

		// Token: 0x04014FF5 RID: 86005
		[Nullable(2)]
		private FGameplayTagContainer _StopUpdateRotationWhileHasTags;

		// Token: 0x04014FF6 RID: 86006
		internal static int __PropertyOffset_7;

		// Token: 0x04014FF7 RID: 86007
		internal static int __PropertyOffset_8;

		// Token: 0x04014FF8 RID: 86008
		[Nullable(2)]
		private FGameplayTagContainer _HideWhileHasTags;
	}
}
