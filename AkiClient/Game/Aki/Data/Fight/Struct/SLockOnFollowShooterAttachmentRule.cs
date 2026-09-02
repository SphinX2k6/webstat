using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED3 RID: 16083
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SLockOnFollowShooterAttachmentRule.SLockOnFollowShooterAttachmentRule")]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 22)]
	public class SLockOnFollowShooterAttachmentRule : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027FB7 RID: 163767 RVA: 0x009FFA34 File Offset: 0x009FDC34
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLockOnFollowShooterAttachmentRule._ScriptStructPtr != 0) ? SLockOnFollowShooterAttachmentRule._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SLockOnFollowShooterAttachmentRule.SLockOnFollowShooterAttachmentRule", ref SLockOnFollowShooterAttachmentRule._ScriptStructPtr);
		}

		// Token: 0x17005FD4 RID: 24532
		// (get) Token: 0x06027FB8 RID: 163768 RVA: 0x009FFA58 File Offset: 0x009FDC58
		// (set) Token: 0x06027FB9 RID: 163769 RVA: 0x009FFA6C File Offset: 0x009FDC6C
		public unsafe FName Socket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005FD5 RID: 24533
		// (get) Token: 0x06027FBA RID: 163770 RVA: 0x009FFA81 File Offset: 0x009FDC81
		// (set) Token: 0x06027FBB RID: 163771 RVA: 0x009FFA95 File Offset: 0x009FDC95
		public unsafe TEnumAsByte<BPEDetachmentRule> DetachLocationRule
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005FD6 RID: 24534
		// (get) Token: 0x06027FBC RID: 163772 RVA: 0x009FFAAA File Offset: 0x009FDCAA
		// (set) Token: 0x06027FBD RID: 163773 RVA: 0x009FFABE File Offset: 0x009FDCBE
		public unsafe TEnumAsByte<BPEDetachmentRule> DetachRotationRule
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005FD7 RID: 24535
		// (get) Token: 0x06027FBE RID: 163774 RVA: 0x009FFAD3 File Offset: 0x009FDCD3
		// (set) Token: 0x06027FBF RID: 163775 RVA: 0x009FFAE7 File Offset: 0x009FDCE7
		public unsafe TEnumAsByte<BPEDetachmentRule> DetachScaleRule
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005FD8 RID: 24536
		// (get) Token: 0x06027FC0 RID: 163776 RVA: 0x009FFAFC File Offset: 0x009FDCFC
		// (set) Token: 0x06027FC1 RID: 163777 RVA: 0x009FFB10 File Offset: 0x009FDD10
		public unsafe TEnumAsByte<BPEFollowShooterAttachStrategy> AttachStrategy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005FD9 RID: 24537
		// (get) Token: 0x06027FC2 RID: 163778 RVA: 0x009FFB25 File Offset: 0x009FDD25
		// (set) Token: 0x06027FC3 RID: 163779 RVA: 0x009FFB39 File Offset: 0x009FDD39
		public unsafe TEnumAsByte<BPEAttachmentRule> AttachLocationRule
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005FDA RID: 24538
		// (get) Token: 0x06027FC4 RID: 163780 RVA: 0x009FFB4E File Offset: 0x009FDD4E
		// (set) Token: 0x06027FC5 RID: 163781 RVA: 0x009FFB62 File Offset: 0x009FDD62
		public unsafe TEnumAsByte<BPEAttachmentRule> AttachRotationRule
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005FDB RID: 24539
		// (get) Token: 0x06027FC6 RID: 163782 RVA: 0x009FFB77 File Offset: 0x009FDD77
		// (set) Token: 0x06027FC7 RID: 163783 RVA: 0x009FFB8B File Offset: 0x009FDD8B
		public unsafe TEnumAsByte<BPEAttachmentRule> AttachScaleRule
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005FDC RID: 24540
		// (get) Token: 0x06027FC8 RID: 163784 RVA: 0x009FFBA0 File Offset: 0x009FDDA0
		// (set) Token: 0x06027FC9 RID: 163785 RVA: 0x009FFBB0 File Offset: 0x009FDDB0
		public unsafe bool AbsoluteLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FDD RID: 24541
		// (get) Token: 0x06027FCA RID: 163786 RVA: 0x009FFBC1 File Offset: 0x009FDDC1
		// (set) Token: 0x06027FCB RID: 163787 RVA: 0x009FFBD1 File Offset: 0x009FDDD1
		public unsafe bool AbsoluteRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FDE RID: 24542
		// (get) Token: 0x06027FCC RID: 163788 RVA: 0x009FFBE2 File Offset: 0x009FDDE2
		// (set) Token: 0x06027FCD RID: 163789 RVA: 0x009FFBF2 File Offset: 0x009FDDF2
		public unsafe bool AbsoluteScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooterAttachmentRule.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027FCE RID: 163790 RVA: 0x009FFC03 File Offset: 0x009FDE03
		public SLockOnFollowShooterAttachmentRule()
		{
		}

		// Token: 0x06027FCF RID: 163791 RVA: 0x009FFC0C File Offset: 0x009FDE0C
		public SLockOnFollowShooterAttachmentRule(FName Socket, TEnumAsByte<BPEDetachmentRule> DetachLocationRule, TEnumAsByte<BPEDetachmentRule> DetachRotationRule, TEnumAsByte<BPEDetachmentRule> DetachScaleRule, TEnumAsByte<BPEFollowShooterAttachStrategy> AttachStrategy, TEnumAsByte<BPEAttachmentRule> AttachLocationRule, TEnumAsByte<BPEAttachmentRule> AttachRotationRule, TEnumAsByte<BPEAttachmentRule> AttachScaleRule, bool AbsoluteLocation, bool AbsoluteRotation, bool AbsoluteScale)
		{
			this.Socket = Socket;
			this.DetachLocationRule = DetachLocationRule;
			this.DetachRotationRule = DetachRotationRule;
			this.DetachScaleRule = DetachScaleRule;
			this.AttachStrategy = AttachStrategy;
			this.AttachLocationRule = AttachLocationRule;
			this.AttachRotationRule = AttachRotationRule;
			this.AttachScaleRule = AttachScaleRule;
			this.AbsoluteLocation = AbsoluteLocation;
			this.AbsoluteRotation = AbsoluteRotation;
			this.AbsoluteScale = AbsoluteScale;
		}

		// Token: 0x06027FD0 RID: 163792 RVA: 0x009FFC74 File Offset: 0x009FDE74
		protected override IntPtr GetUStructPtr()
		{
			return SLockOnFollowShooterAttachmentRule.StaticStruct();
		}

		// Token: 0x06027FD1 RID: 163793 RVA: 0x009FFC80 File Offset: 0x009FDE80
		[NullableContext(2)]
		public SLockOnFollowShooterAttachmentRule(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027FD2 RID: 163794 RVA: 0x009FFC8A File Offset: 0x009FDE8A
		public SLockOnFollowShooterAttachmentRule(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027FD3 RID: 163795 RVA: 0x009FFC95 File Offset: 0x009FDE95
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLockOnFollowShooterAttachmentRule(Pointer, false, true);
		}

		// Token: 0x06027FD4 RID: 163796 RVA: 0x009FFC9F File Offset: 0x009FDE9F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLockOnFollowShooterAttachmentRule(Pointer, MemoryOwner);
		}

		// Token: 0x04014FDE RID: 85982
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SLockOnFollowShooterAttachmentRule.SLockOnFollowShooterAttachmentRule";

		// Token: 0x04014FDF RID: 85983
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014FE0 RID: 85984
		internal static int __PropertyOffset_0;

		// Token: 0x04014FE1 RID: 85985
		internal static int __PropertyOffset_1;

		// Token: 0x04014FE2 RID: 85986
		internal static int __PropertyOffset_2;

		// Token: 0x04014FE3 RID: 85987
		internal static int __PropertyOffset_3;

		// Token: 0x04014FE4 RID: 85988
		internal static int __PropertyOffset_4;

		// Token: 0x04014FE5 RID: 85989
		internal static int __PropertyOffset_5;

		// Token: 0x04014FE6 RID: 85990
		internal static int __PropertyOffset_6;

		// Token: 0x04014FE7 RID: 85991
		internal static int __PropertyOffset_7;

		// Token: 0x04014FE8 RID: 85992
		internal static int __PropertyOffset_8;

		// Token: 0x04014FE9 RID: 85993
		internal static int __PropertyOffset_9;

		// Token: 0x04014FEA RID: 85994
		internal static int __PropertyOffset_10;
	}
}
