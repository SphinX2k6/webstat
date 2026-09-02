using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004271 RID: 17009
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SMovementSetting_Posture.SMovementSetting_Posture")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 192)]
	public class SMovementSetting_Posture : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D1C5 RID: 184773 RVA: 0x00AB78AC File Offset: 0x00AB5AAC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMovementSetting_Posture._ScriptStructPtr != 0) ? SMovementSetting_Posture._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SMovementSetting_Posture.SMovementSetting_Posture", ref SMovementSetting_Posture._ScriptStructPtr);
		}

		// Token: 0x17007A97 RID: 31383
		// (get) Token: 0x0602D1C6 RID: 184774 RVA: 0x00AB78D0 File Offset: 0x00AB5AD0
		// (set) Token: 0x0602D1C7 RID: 184775 RVA: 0x00AB7913 File Offset: 0x00AB5B13
		public SMovementSetting Standing
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting result;
				if ((result = this._Standing) == null)
				{
					result = (this._Standing = new SMovementSetting(base.NativePtr + (IntPtr)SMovementSetting_Posture.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_Posture.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A98 RID: 31384
		// (get) Token: 0x0602D1C8 RID: 184776 RVA: 0x00AB7934 File Offset: 0x00AB5B34
		// (set) Token: 0x0602D1C9 RID: 184777 RVA: 0x00AB7977 File Offset: 0x00AB5B77
		public SMovementSetting Crouching
		{
			get
			{
				base.FastCheckIsValid();
				SMovementSetting result;
				if ((result = this._Crouching) == null)
				{
					result = (this._Crouching = new SMovementSetting(base.NativePtr + (IntPtr)SMovementSetting_Posture.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting.StaticStruct(), base.NativePtr + (IntPtr)SMovementSetting_Posture.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D1CA RID: 184778 RVA: 0x00AB7998 File Offset: 0x00AB5B98
		public SMovementSetting_Posture()
		{
		}

		// Token: 0x0602D1CB RID: 184779 RVA: 0x00AB79A0 File Offset: 0x00AB5BA0
		public SMovementSetting_Posture(SMovementSetting Standing, SMovementSetting Crouching)
		{
			this.Standing = Standing;
			this.Crouching = Crouching;
		}

		// Token: 0x0602D1CC RID: 184780 RVA: 0x00AB79B6 File Offset: 0x00AB5BB6
		protected override IntPtr GetUStructPtr()
		{
			return SMovementSetting_Posture.StaticStruct();
		}

		// Token: 0x0602D1CD RID: 184781 RVA: 0x00AB79C2 File Offset: 0x00AB5BC2
		[NullableContext(2)]
		public SMovementSetting_Posture(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D1CE RID: 184782 RVA: 0x00AB79CC File Offset: 0x00AB5BCC
		public SMovementSetting_Posture(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D1CF RID: 184783 RVA: 0x00AB79D7 File Offset: 0x00AB5BD7
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMovementSetting_Posture(Pointer, false, true);
		}

		// Token: 0x0602D1D0 RID: 184784 RVA: 0x00AB79E1 File Offset: 0x00AB5BE1
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMovementSetting_Posture(Pointer, MemoryOwner);
		}

		// Token: 0x040194AA RID: 103594
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SMovementSetting_Posture.SMovementSetting_Posture";

		// Token: 0x040194AB RID: 103595
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040194AC RID: 103596
		internal static int __PropertyOffset_0;

		// Token: 0x040194AD RID: 103597
		[Nullable(2)]
		private SMovementSetting _Standing;

		// Token: 0x040194AE RID: 103598
		internal static int __PropertyOffset_1;

		// Token: 0x040194AF RID: 103599
		[Nullable(2)]
		private SMovementSetting _Crouching;
	}
}
