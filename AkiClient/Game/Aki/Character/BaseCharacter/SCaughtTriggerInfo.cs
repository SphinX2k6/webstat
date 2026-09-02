using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200424B RID: 16971
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCaughtTriggerInfo.SCaughtTriggerInfo")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SCaughtTriggerInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CEED RID: 184045 RVA: 0x00AB381A File Offset: 0x00AB1A1A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCaughtTriggerInfo._ScriptStructPtr != 0) ? SCaughtTriggerInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCaughtTriggerInfo.SCaughtTriggerInfo", ref SCaughtTriggerInfo._ScriptStructPtr);
		}

		// Token: 0x170079BF RID: 31167
		// (get) Token: 0x0602CEEE RID: 184046 RVA: 0x00AB383E File Offset: 0x00AB1A3E
		// (set) Token: 0x0602CEEF RID: 184047 RVA: 0x00AB3852 File Offset: 0x00AB1A52
		public unsafe string BulletId
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtTriggerInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtTriggerInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170079C0 RID: 31168
		// (get) Token: 0x0602CEF0 RID: 184048 RVA: 0x00AB3867 File Offset: 0x00AB1A67
		// (set) Token: 0x0602CEF1 RID: 184049 RVA: 0x00AB3877 File Offset: 0x00AB1A77
		public unsafe int CaughtMxNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCaughtTriggerInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCaughtTriggerInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170079C1 RID: 31169
		// (get) Token: 0x0602CEF2 RID: 184050 RVA: 0x00AB3888 File Offset: 0x00AB1A88
		// (set) Token: 0x0602CEF3 RID: 184051 RVA: 0x00AB3898 File Offset: 0x00AB1A98
		public unsafe int CaughtLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCaughtTriggerInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCaughtTriggerInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170079C2 RID: 31170
		// (get) Token: 0x0602CEF4 RID: 184052 RVA: 0x00AB38A9 File Offset: 0x00AB1AA9
		// (set) Token: 0x0602CEF5 RID: 184053 RVA: 0x00AB38B9 File Offset: 0x00AB1AB9
		public unsafe bool CaughtAimTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCaughtTriggerInfo.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCaughtTriggerInfo.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079C3 RID: 31171
		// (get) Token: 0x0602CEF6 RID: 184054 RVA: 0x00AB38CC File Offset: 0x00AB1ACC
		// (set) Token: 0x0602CEF7 RID: 184055 RVA: 0x00AB390F File Offset: 0x00AB1B0F
		public TArray<FGameplayTag> CaughtTargetTag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._CaughtTargetTag) == null)
				{
					result = (this._CaughtTargetTag = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SCaughtTriggerInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CaughtTargetTag.CopyAssign(value);
			}
		}

		// Token: 0x0602CEF8 RID: 184056 RVA: 0x00AB391D File Offset: 0x00AB1B1D
		public SCaughtTriggerInfo()
		{
		}

		// Token: 0x0602CEF9 RID: 184057 RVA: 0x00AB3925 File Offset: 0x00AB1B25
		public SCaughtTriggerInfo(string BulletId, int CaughtMxNumber, int CaughtLevel, bool CaughtAimTarget, TArray<FGameplayTag> CaughtTargetTag)
		{
			this.BulletId = BulletId;
			this.CaughtMxNumber = CaughtMxNumber;
			this.CaughtLevel = CaughtLevel;
			this.CaughtAimTarget = CaughtAimTarget;
			this.CaughtTargetTag = CaughtTargetTag;
		}

		// Token: 0x0602CEFA RID: 184058 RVA: 0x00AB3952 File Offset: 0x00AB1B52
		protected override IntPtr GetUStructPtr()
		{
			return SCaughtTriggerInfo.StaticStruct();
		}

		// Token: 0x0602CEFB RID: 184059 RVA: 0x00AB395E File Offset: 0x00AB1B5E
		[NullableContext(2)]
		public SCaughtTriggerInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CEFC RID: 184060 RVA: 0x00AB3968 File Offset: 0x00AB1B68
		public SCaughtTriggerInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CEFD RID: 184061 RVA: 0x00AB3973 File Offset: 0x00AB1B73
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCaughtTriggerInfo(Pointer, false, true);
		}

		// Token: 0x0602CEFE RID: 184062 RVA: 0x00AB397D File Offset: 0x00AB1B7D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCaughtTriggerInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401934A RID: 103242
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCaughtTriggerInfo.SCaughtTriggerInfo";

		// Token: 0x0401934B RID: 103243
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401934C RID: 103244
		internal static int __PropertyOffset_0;

		// Token: 0x0401934D RID: 103245
		internal static int __PropertyOffset_1;

		// Token: 0x0401934E RID: 103246
		internal static int __PropertyOffset_2;

		// Token: 0x0401934F RID: 103247
		internal static int __PropertyOffset_3;

		// Token: 0x04019350 RID: 103248
		internal static int __PropertyOffset_4;

		// Token: 0x04019351 RID: 103249
		[Nullable(2)]
		private TArray<FGameplayTag> _CaughtTargetTag;
	}
}
