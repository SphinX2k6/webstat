using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200425E RID: 16990
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SFloatingMovementState.SFloatingMovementState")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 136)]
	public class SFloatingMovementState : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D04C RID: 184396 RVA: 0x00AB5810 File Offset: 0x00AB3A10
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFloatingMovementState._ScriptStructPtr != 0) ? SFloatingMovementState._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SFloatingMovementState.SFloatingMovementState", ref SFloatingMovementState._ScriptStructPtr);
		}

		// Token: 0x17007A25 RID: 31269
		// (get) Token: 0x0602D04D RID: 184397 RVA: 0x00AB5834 File Offset: 0x00AB3A34
		// (set) Token: 0x0602D04E RID: 184398 RVA: 0x00AB5848 File Offset: 0x00AB3A48
		[Nullable(0)]
		public unsafe TEnumAsByte<EFloatingMovementType> Mode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A26 RID: 31270
		// (get) Token: 0x0602D04F RID: 184399 RVA: 0x00AB5860 File Offset: 0x00AB3A60
		// (set) Token: 0x0602D050 RID: 184400 RVA: 0x00AB58A3 File Offset: 0x00AB3AA3
		public FGameplayTagContainer MovementTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._MovementTagList) == null)
				{
					result = (this._MovementTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A27 RID: 31271
		// (get) Token: 0x0602D051 RID: 184401 RVA: 0x00AB58C4 File Offset: 0x00AB3AC4
		// (set) Token: 0x0602D052 RID: 184402 RVA: 0x00AB5907 File Offset: 0x00AB3B07
		public FGameplayTagContainer BannedMovementTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._BannedMovementTagList) == null)
				{
					result = (this._BannedMovementTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A28 RID: 31272
		// (get) Token: 0x0602D053 RID: 184403 RVA: 0x00AB5928 File Offset: 0x00AB3B28
		// (set) Token: 0x0602D054 RID: 184404 RVA: 0x00AB596B File Offset: 0x00AB3B6B
		public FGameplayTagContainer MoveTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._MoveTagList) == null)
				{
					result = (this._MoveTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A29 RID: 31273
		// (get) Token: 0x0602D055 RID: 184405 RVA: 0x00AB598C File Offset: 0x00AB3B8C
		// (set) Token: 0x0602D056 RID: 184406 RVA: 0x00AB59CF File Offset: 0x00AB3BCF
		public FGameplayTagContainer StandTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._StandTagList) == null)
				{
					result = (this._StandTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SFloatingMovementState.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D057 RID: 184407 RVA: 0x00AB59F0 File Offset: 0x00AB3BF0
		public SFloatingMovementState()
		{
		}

		// Token: 0x0602D058 RID: 184408 RVA: 0x00AB59F8 File Offset: 0x00AB3BF8
		public SFloatingMovementState([Nullable(0)] TEnumAsByte<EFloatingMovementType> Mode, FGameplayTagContainer MovementTagList, FGameplayTagContainer BannedMovementTagList, FGameplayTagContainer MoveTagList, FGameplayTagContainer StandTagList)
		{
			this.Mode = Mode;
			this.MovementTagList = MovementTagList;
			this.BannedMovementTagList = BannedMovementTagList;
			this.MoveTagList = MoveTagList;
			this.StandTagList = StandTagList;
		}

		// Token: 0x0602D059 RID: 184409 RVA: 0x00AB5A25 File Offset: 0x00AB3C25
		protected override IntPtr GetUStructPtr()
		{
			return SFloatingMovementState.StaticStruct();
		}

		// Token: 0x0602D05A RID: 184410 RVA: 0x00AB5A31 File Offset: 0x00AB3C31
		[NullableContext(2)]
		public SFloatingMovementState(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D05B RID: 184411 RVA: 0x00AB5A3B File Offset: 0x00AB3C3B
		public SFloatingMovementState(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D05C RID: 184412 RVA: 0x00AB5A46 File Offset: 0x00AB3C46
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFloatingMovementState(Pointer, false, true);
		}

		// Token: 0x0602D05D RID: 184413 RVA: 0x00AB5A50 File Offset: 0x00AB3C50
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFloatingMovementState(Pointer, MemoryOwner);
		}

		// Token: 0x040193F9 RID: 103417
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SFloatingMovementState.SFloatingMovementState";

		// Token: 0x040193FA RID: 103418
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193FB RID: 103419
		internal static int __PropertyOffset_0;

		// Token: 0x040193FC RID: 103420
		internal static int __PropertyOffset_1;

		// Token: 0x040193FD RID: 103421
		[Nullable(2)]
		private FGameplayTagContainer _MovementTagList;

		// Token: 0x040193FE RID: 103422
		internal static int __PropertyOffset_2;

		// Token: 0x040193FF RID: 103423
		[Nullable(2)]
		private FGameplayTagContainer _BannedMovementTagList;

		// Token: 0x04019400 RID: 103424
		internal static int __PropertyOffset_3;

		// Token: 0x04019401 RID: 103425
		[Nullable(2)]
		private FGameplayTagContainer _MoveTagList;

		// Token: 0x04019402 RID: 103426
		internal static int __PropertyOffset_4;

		// Token: 0x04019403 RID: 103427
		[Nullable(2)]
		private FGameplayTagContainer _StandTagList;
	}
}
