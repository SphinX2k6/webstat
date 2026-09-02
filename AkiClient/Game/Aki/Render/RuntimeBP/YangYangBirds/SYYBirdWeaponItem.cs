using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.YangYangBirds
{
	// Token: 0x020039F9 RID: 14841
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/YangYangBirds/SYYBirdWeaponItem.SYYBirdWeaponItem")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SYYBirdWeaponItem : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601E2EC RID: 123628 RVA: 0x008EED93 File Offset: 0x008ECF93
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SYYBirdWeaponItem._ScriptStructPtr != 0) ? SYYBirdWeaponItem._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/YangYangBirds/SYYBirdWeaponItem.SYYBirdWeaponItem", ref SYYBirdWeaponItem._ScriptStructPtr);
		}

		// Token: 0x170028D9 RID: 10457
		// (get) Token: 0x0601E2ED RID: 123629 RVA: 0x008EEDB7 File Offset: 0x008ECFB7
		// (set) Token: 0x0601E2EE RID: 123630 RVA: 0x008EEDCB File Offset: 0x008ECFCB
		public unsafe FVectorDouble Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SYYBirdWeaponItem.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SYYBirdWeaponItem.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170028DA RID: 10458
		// (get) Token: 0x0601E2EF RID: 123631 RVA: 0x008EEDE0 File Offset: 0x008ECFE0
		// (set) Token: 0x0601E2F0 RID: 123632 RVA: 0x008EEDF0 File Offset: 0x008ECFF0
		public unsafe float LastRecordTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SYYBirdWeaponItem.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SYYBirdWeaponItem.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170028DB RID: 10459
		// (get) Token: 0x0601E2F1 RID: 123633 RVA: 0x008EEE01 File Offset: 0x008ED001
		// (set) Token: 0x0601E2F2 RID: 123634 RVA: 0x008EEE11 File Offset: 0x008ED011
		public unsafe float Impaction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SYYBirdWeaponItem.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SYYBirdWeaponItem.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0601E2F3 RID: 123635 RVA: 0x008EEE22 File Offset: 0x008ED022
		public SYYBirdWeaponItem()
		{
		}

		// Token: 0x0601E2F4 RID: 123636 RVA: 0x008EEE2A File Offset: 0x008ED02A
		public SYYBirdWeaponItem(FVectorDouble Position, float LastRecordTime, float Impaction)
		{
			this.Position = Position;
			this.LastRecordTime = LastRecordTime;
			this.Impaction = Impaction;
		}

		// Token: 0x0601E2F5 RID: 123637 RVA: 0x008EEE47 File Offset: 0x008ED047
		protected override IntPtr GetUStructPtr()
		{
			return SYYBirdWeaponItem.StaticStruct();
		}

		// Token: 0x0601E2F6 RID: 123638 RVA: 0x008EEE53 File Offset: 0x008ED053
		[NullableContext(2)]
		public SYYBirdWeaponItem(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E2F7 RID: 123639 RVA: 0x008EEE5D File Offset: 0x008ED05D
		public SYYBirdWeaponItem(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E2F8 RID: 123640 RVA: 0x008EEE68 File Offset: 0x008ED068
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SYYBirdWeaponItem(Pointer, false, true);
		}

		// Token: 0x0601E2F9 RID: 123641 RVA: 0x008EEE72 File Offset: 0x008ED072
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SYYBirdWeaponItem(Pointer, MemoryOwner);
		}

		// Token: 0x0400ED4B RID: 60747
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/YangYangBirds/SYYBirdWeaponItem.SYYBirdWeaponItem";

		// Token: 0x0400ED4C RID: 60748
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400ED4D RID: 60749
		internal static int __PropertyOffset_0;

		// Token: 0x0400ED4E RID: 60750
		internal static int __PropertyOffset_1;

		// Token: 0x0400ED4F RID: 60751
		internal static int __PropertyOffset_2;
	}
}
