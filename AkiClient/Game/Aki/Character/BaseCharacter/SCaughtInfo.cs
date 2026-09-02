using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200424A RID: 16970
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCaughtInfo.SCaughtInfo")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 240)]
	public class SCaughtInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CEE1 RID: 184033 RVA: 0x00AB36DC File Offset: 0x00AB18DC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCaughtInfo._ScriptStructPtr != 0) ? SCaughtInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCaughtInfo.SCaughtInfo", ref SCaughtInfo._ScriptStructPtr);
		}

		// Token: 0x170079BD RID: 31165
		// (get) Token: 0x0602CEE2 RID: 184034 RVA: 0x00AB3700 File Offset: 0x00AB1900
		// (set) Token: 0x0602CEE3 RID: 184035 RVA: 0x00AB3743 File Offset: 0x00AB1943
		public SCaughtTriggerInfo TriggerInfo
		{
			get
			{
				base.FastCheckIsValid();
				SCaughtTriggerInfo result;
				if ((result = this._TriggerInfo) == null)
				{
					result = (this._TriggerInfo = new SCaughtTriggerInfo(base.NativePtr + (IntPtr)SCaughtInfo.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCaughtTriggerInfo.StaticStruct(), base.NativePtr + (IntPtr)SCaughtInfo.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079BE RID: 31166
		// (get) Token: 0x0602CEE4 RID: 184036 RVA: 0x00AB3764 File Offset: 0x00AB1964
		// (set) Token: 0x0602CEE5 RID: 184037 RVA: 0x00AB37A7 File Offset: 0x00AB19A7
		public SCaughtBindingInfo BindingInfo
		{
			get
			{
				base.FastCheckIsValid();
				SCaughtBindingInfo result;
				if ((result = this._BindingInfo) == null)
				{
					result = (this._BindingInfo = new SCaughtBindingInfo(base.NativePtr + (IntPtr)SCaughtInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCaughtBindingInfo.StaticStruct(), base.NativePtr + (IntPtr)SCaughtInfo.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CEE6 RID: 184038 RVA: 0x00AB37C8 File Offset: 0x00AB19C8
		public SCaughtInfo()
		{
		}

		// Token: 0x0602CEE7 RID: 184039 RVA: 0x00AB37D0 File Offset: 0x00AB19D0
		public SCaughtInfo(SCaughtTriggerInfo TriggerInfo, SCaughtBindingInfo BindingInfo)
		{
			this.TriggerInfo = TriggerInfo;
			this.BindingInfo = BindingInfo;
		}

		// Token: 0x0602CEE8 RID: 184040 RVA: 0x00AB37E6 File Offset: 0x00AB19E6
		protected override IntPtr GetUStructPtr()
		{
			return SCaughtInfo.StaticStruct();
		}

		// Token: 0x0602CEE9 RID: 184041 RVA: 0x00AB37F2 File Offset: 0x00AB19F2
		[NullableContext(2)]
		public SCaughtInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CEEA RID: 184042 RVA: 0x00AB37FC File Offset: 0x00AB19FC
		public SCaughtInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CEEB RID: 184043 RVA: 0x00AB3807 File Offset: 0x00AB1A07
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCaughtInfo(Pointer, false, true);
		}

		// Token: 0x0602CEEC RID: 184044 RVA: 0x00AB3811 File Offset: 0x00AB1A11
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCaughtInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019344 RID: 103236
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCaughtInfo.SCaughtInfo";

		// Token: 0x04019345 RID: 103237
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019346 RID: 103238
		internal static int __PropertyOffset_0;

		// Token: 0x04019347 RID: 103239
		[Nullable(2)]
		private SCaughtTriggerInfo _TriggerInfo;

		// Token: 0x04019348 RID: 103240
		internal static int __PropertyOffset_1;

		// Token: 0x04019349 RID: 103241
		[Nullable(2)]
		private SCaughtBindingInfo _BindingInfo;
	}
}
