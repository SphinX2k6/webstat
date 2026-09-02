using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004315 RID: 17173
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCamera_ChangeGravity.SCamera_ChangeGravity")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 37)]
	public class SCamera_ChangeGravity : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D865 RID: 186469 RVA: 0x00AC2958 File Offset: 0x00AC0B58
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCamera_ChangeGravity._ScriptStructPtr != 0) ? SCamera_ChangeGravity._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCamera_ChangeGravity.SCamera_ChangeGravity", ref SCamera_ChangeGravity._ScriptStructPtr);
		}

		// Token: 0x17007C94 RID: 31892
		// (get) Token: 0x0602D866 RID: 186470 RVA: 0x00AC297C File Offset: 0x00AC0B7C
		// (set) Token: 0x0602D867 RID: 186471 RVA: 0x00AC2990 File Offset: 0x00AC0B90
		public unsafe TEnumAsByte<ECameraGravityMode> GravityMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C95 RID: 31893
		// (get) Token: 0x0602D868 RID: 186472 RVA: 0x00AC29A5 File Offset: 0x00AC0BA5
		// (set) Token: 0x0602D869 RID: 186473 RVA: 0x00AC29B9 File Offset: 0x00AC0BB9
		public unsafe FVector TargetGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007C96 RID: 31894
		// (get) Token: 0x0602D86A RID: 186474 RVA: 0x00AC29CE File Offset: 0x00AC0BCE
		// (set) Token: 0x0602D86B RID: 186475 RVA: 0x00AC29E2 File Offset: 0x00AC0BE2
		public unsafe TEnumAsByte<ECameraGravityLerpMode> LerpMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007C97 RID: 31895
		// (get) Token: 0x0602D86C RID: 186476 RVA: 0x00AC29F7 File Offset: 0x00AC0BF7
		// (set) Token: 0x0602D86D RID: 186477 RVA: 0x00AC2A07 File Offset: 0x00AC0C07
		public unsafe float LerpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007C98 RID: 31896
		// (get) Token: 0x0602D86E RID: 186478 RVA: 0x00AC2A18 File Offset: 0x00AC0C18
		// (set) Token: 0x0602D86F RID: 186479 RVA: 0x00AC2A2C File Offset: 0x00AC0C2C
		[Nullable(2)]
		public unsafe UCurveFloat LerpTimeCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SCamera_ChangeGravity.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCamera_ChangeGravity.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007C99 RID: 31897
		// (get) Token: 0x0602D870 RID: 186480 RVA: 0x00AC2A41 File Offset: 0x00AC0C41
		// (set) Token: 0x0602D871 RID: 186481 RVA: 0x00AC2A51 File Offset: 0x00AC0C51
		public unsafe float LerpAngleVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007C9A RID: 31898
		// (get) Token: 0x0602D872 RID: 186482 RVA: 0x00AC2A62 File Offset: 0x00AC0C62
		// (set) Token: 0x0602D873 RID: 186483 RVA: 0x00AC2A72 File Offset: 0x00AC0C72
		public unsafe bool LerpAngleWhenFinish
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCamera_ChangeGravity.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D874 RID: 186484 RVA: 0x00AC2A83 File Offset: 0x00AC0C83
		public SCamera_ChangeGravity()
		{
		}

		// Token: 0x0602D875 RID: 186485 RVA: 0x00AC2A8B File Offset: 0x00AC0C8B
		public SCamera_ChangeGravity(TEnumAsByte<ECameraGravityMode> GravityMode, FVector TargetGravity, TEnumAsByte<ECameraGravityLerpMode> LerpMode, float LerpTime, [Nullable(1)] UCurveFloat LerpTimeCurve, float LerpAngleVelocity, bool LerpAngleWhenFinish)
		{
			this.GravityMode = GravityMode;
			this.TargetGravity = TargetGravity;
			this.LerpMode = LerpMode;
			this.LerpTime = LerpTime;
			this.LerpTimeCurve = LerpTimeCurve;
			this.LerpAngleVelocity = LerpAngleVelocity;
			this.LerpAngleWhenFinish = LerpAngleWhenFinish;
		}

		// Token: 0x0602D876 RID: 186486 RVA: 0x00AC2AC8 File Offset: 0x00AC0CC8
		protected override IntPtr GetUStructPtr()
		{
			return SCamera_ChangeGravity.StaticStruct();
		}

		// Token: 0x0602D877 RID: 186487 RVA: 0x00AC2AD4 File Offset: 0x00AC0CD4
		[NullableContext(2)]
		public SCamera_ChangeGravity(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D878 RID: 186488 RVA: 0x00AC2ADE File Offset: 0x00AC0CDE
		public SCamera_ChangeGravity(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D879 RID: 186489 RVA: 0x00AC2AE9 File Offset: 0x00AC0CE9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCamera_ChangeGravity(Pointer, false, true);
		}

		// Token: 0x0602D87A RID: 186490 RVA: 0x00AC2AF3 File Offset: 0x00AC0CF3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCamera_ChangeGravity(Pointer, MemoryOwner);
		}

		// Token: 0x04019AB3 RID: 105139
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCamera_ChangeGravity.SCamera_ChangeGravity";

		// Token: 0x04019AB4 RID: 105140
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019AB5 RID: 105141
		internal static int __PropertyOffset_0;

		// Token: 0x04019AB6 RID: 105142
		internal static int __PropertyOffset_1;

		// Token: 0x04019AB7 RID: 105143
		internal static int __PropertyOffset_2;

		// Token: 0x04019AB8 RID: 105144
		internal static int __PropertyOffset_3;

		// Token: 0x04019AB9 RID: 105145
		internal static int __PropertyOffset_4;

		// Token: 0x04019ABA RID: 105146
		internal static int __PropertyOffset_5;

		// Token: 0x04019ABB RID: 105147
		internal static int __PropertyOffset_6;
	}
}
