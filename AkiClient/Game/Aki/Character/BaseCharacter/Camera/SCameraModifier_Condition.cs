using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004310 RID: 17168
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Condition.SCameraModifier_Condition")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 120)]
	public class SCameraModifier_Condition : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D798 RID: 186264 RVA: 0x00AC1589 File Offset: 0x00ABF789
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraModifier_Condition._ScriptStructPtr != 0) ? SCameraModifier_Condition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Condition.SCameraModifier_Condition", ref SCameraModifier_Condition._ScriptStructPtr);
		}

		// Token: 0x17007C41 RID: 31809
		// (get) Token: 0x0602D799 RID: 186265 RVA: 0x00AC15AD File Offset: 0x00ABF7AD
		// (set) Token: 0x0602D79A RID: 186266 RVA: 0x00AC15C1 File Offset: 0x00ABF7C1
		public unsafe TEnumAsByte<ECameraModifyConditionType> ConditionType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C42 RID: 31810
		// (get) Token: 0x0602D79B RID: 186267 RVA: 0x00AC15D6 File Offset: 0x00ABF7D6
		// (set) Token: 0x0602D79C RID: 186268 RVA: 0x00AC15E6 File Offset: 0x00ABF7E6
		public unsafe bool AnyTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C43 RID: 31811
		// (get) Token: 0x0602D79D RID: 186269 RVA: 0x00AC15F8 File Offset: 0x00ABF7F8
		// (set) Token: 0x0602D79E RID: 186270 RVA: 0x00AC163B File Offset: 0x00ABF83B
		[Nullable(1)]
		public FGameplayTagContainer TagToCheck
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._TagToCheck) == null)
				{
					result = (this._TagToCheck = new FGameplayTagContainer(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007C44 RID: 31812
		// (get) Token: 0x0602D79F RID: 186271 RVA: 0x00AC165C File Offset: 0x00ABF85C
		// (set) Token: 0x0602D7A0 RID: 186272 RVA: 0x00AC166C File Offset: 0x00ABF86C
		public unsafe float ArmLengthMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007C45 RID: 31813
		// (get) Token: 0x0602D7A1 RID: 186273 RVA: 0x00AC167D File Offset: 0x00ABF87D
		// (set) Token: 0x0602D7A2 RID: 186274 RVA: 0x00AC168D File Offset: 0x00ABF88D
		public unsafe float ArmLengthMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007C46 RID: 31814
		// (get) Token: 0x0602D7A3 RID: 186275 RVA: 0x00AC169E File Offset: 0x00ABF89E
		// (set) Token: 0x0602D7A4 RID: 186276 RVA: 0x00AC16AE File Offset: 0x00ABF8AE
		public unsafe float LockTargetDeltaZMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007C47 RID: 31815
		// (get) Token: 0x0602D7A5 RID: 186277 RVA: 0x00AC16BF File Offset: 0x00ABF8BF
		// (set) Token: 0x0602D7A6 RID: 186278 RVA: 0x00AC16CF File Offset: 0x00ABF8CF
		public unsafe float LockTargetDeltaZMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007C48 RID: 31816
		// (get) Token: 0x0602D7A7 RID: 186279 RVA: 0x00AC16E0 File Offset: 0x00ABF8E0
		// (set) Token: 0x0602D7A8 RID: 186280 RVA: 0x00AC16F0 File Offset: 0x00ABF8F0
		public unsafe float LockTargetDeltaYawMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007C49 RID: 31817
		// (get) Token: 0x0602D7A9 RID: 186281 RVA: 0x00AC1701 File Offset: 0x00ABF901
		// (set) Token: 0x0602D7AA RID: 186282 RVA: 0x00AC1711 File Offset: 0x00ABF911
		public unsafe float LockTargetDeltaYawMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007C4A RID: 31818
		// (get) Token: 0x0602D7AB RID: 186283 RVA: 0x00AC1722 File Offset: 0x00ABF922
		// (set) Token: 0x0602D7AC RID: 186284 RVA: 0x00AC1732 File Offset: 0x00ABF932
		public unsafe float LockTargetDeltaPitchMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007C4B RID: 31819
		// (get) Token: 0x0602D7AD RID: 186285 RVA: 0x00AC1743 File Offset: 0x00ABF943
		// (set) Token: 0x0602D7AE RID: 186286 RVA: 0x00AC1753 File Offset: 0x00ABF953
		public unsafe float LockTargetDeltaPitchMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007C4C RID: 31820
		// (get) Token: 0x0602D7AF RID: 186287 RVA: 0x00AC1764 File Offset: 0x00ABF964
		// (set) Token: 0x0602D7B0 RID: 186288 RVA: 0x00AC1774 File Offset: 0x00ABF974
		public unsafe bool Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007C4D RID: 31821
		// (get) Token: 0x0602D7B1 RID: 186289 RVA: 0x00AC1785 File Offset: 0x00ABF985
		// (set) Token: 0x0602D7B2 RID: 186290 RVA: 0x00AC1795 File Offset: 0x00ABF995
		public unsafe float MinLockDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007C4E RID: 31822
		// (get) Token: 0x0602D7B3 RID: 186291 RVA: 0x00AC17A6 File Offset: 0x00ABF9A6
		// (set) Token: 0x0602D7B4 RID: 186292 RVA: 0x00AC17B6 File Offset: 0x00ABF9B6
		public unsafe float MaxLockDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007C4F RID: 31823
		// (get) Token: 0x0602D7B5 RID: 186293 RVA: 0x00AC17C7 File Offset: 0x00ABF9C7
		// (set) Token: 0x0602D7B6 RID: 186294 RVA: 0x00AC17DB File Offset: 0x00ABF9DB
		public unsafe FName CameraTraceSocket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007C50 RID: 31824
		// (get) Token: 0x0602D7B7 RID: 186295 RVA: 0x00AC17F0 File Offset: 0x00ABF9F0
		// (set) Token: 0x0602D7B8 RID: 186296 RVA: 0x00AC1800 File Offset: 0x00ABFA00
		public unsafe float CameraTraceRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007C51 RID: 31825
		// (get) Token: 0x0602D7B9 RID: 186297 RVA: 0x00AC1811 File Offset: 0x00ABFA11
		// (set) Token: 0x0602D7BA RID: 186298 RVA: 0x00AC1825 File Offset: 0x00ABFA25
		public unsafe FVector CameraTraceOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007C52 RID: 31826
		// (get) Token: 0x0602D7BB RID: 186299 RVA: 0x00AC183A File Offset: 0x00ABFA3A
		// (set) Token: 0x0602D7BC RID: 186300 RVA: 0x00AC184A File Offset: 0x00ABFA4A
		public unsafe float CharacterDeltaYawMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007C53 RID: 31827
		// (get) Token: 0x0602D7BD RID: 186301 RVA: 0x00AC185B File Offset: 0x00ABFA5B
		// (set) Token: 0x0602D7BE RID: 186302 RVA: 0x00AC186B File Offset: 0x00ABFA6B
		public unsafe float CharacterDeltaYawMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Condition.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x0602D7BF RID: 186303 RVA: 0x00AC187C File Offset: 0x00ABFA7C
		public SCameraModifier_Condition()
		{
		}

		// Token: 0x0602D7C0 RID: 186304 RVA: 0x00AC1884 File Offset: 0x00ABFA84
		public SCameraModifier_Condition(TEnumAsByte<ECameraModifyConditionType> ConditionType, bool AnyTag, [Nullable(1)] FGameplayTagContainer TagToCheck, float ArmLengthMin, float ArmLengthMax, float LockTargetDeltaZMin, float LockTargetDeltaZMax, float LockTargetDeltaYawMin, float LockTargetDeltaYawMax, float LockTargetDeltaPitchMin, float LockTargetDeltaPitchMax, bool Reverse, float MinLockDistance, float MaxLockDistance, FName CameraTraceSocket, float CameraTraceRadius, FVector CameraTraceOffset, float CharacterDeltaYawMin, float CharacterDeltaYawMax)
		{
			this.ConditionType = ConditionType;
			this.AnyTag = AnyTag;
			this.TagToCheck = TagToCheck;
			this.ArmLengthMin = ArmLengthMin;
			this.ArmLengthMax = ArmLengthMax;
			this.LockTargetDeltaZMin = LockTargetDeltaZMin;
			this.LockTargetDeltaZMax = LockTargetDeltaZMax;
			this.LockTargetDeltaYawMin = LockTargetDeltaYawMin;
			this.LockTargetDeltaYawMax = LockTargetDeltaYawMax;
			this.LockTargetDeltaPitchMin = LockTargetDeltaPitchMin;
			this.LockTargetDeltaPitchMax = LockTargetDeltaPitchMax;
			this.Reverse = Reverse;
			this.MinLockDistance = MinLockDistance;
			this.MaxLockDistance = MaxLockDistance;
			this.CameraTraceSocket = CameraTraceSocket;
			this.CameraTraceRadius = CameraTraceRadius;
			this.CameraTraceOffset = CameraTraceOffset;
			this.CharacterDeltaYawMin = CharacterDeltaYawMin;
			this.CharacterDeltaYawMax = CharacterDeltaYawMax;
		}

		// Token: 0x0602D7C1 RID: 186305 RVA: 0x00AC192C File Offset: 0x00ABFB2C
		protected override IntPtr GetUStructPtr()
		{
			return SCameraModifier_Condition.StaticStruct();
		}

		// Token: 0x0602D7C2 RID: 186306 RVA: 0x00AC1938 File Offset: 0x00ABFB38
		[NullableContext(2)]
		public SCameraModifier_Condition(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D7C3 RID: 186307 RVA: 0x00AC1942 File Offset: 0x00ABFB42
		public SCameraModifier_Condition(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D7C4 RID: 186308 RVA: 0x00AC194D File Offset: 0x00ABFB4D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraModifier_Condition(Pointer, false, true);
		}

		// Token: 0x0602D7C5 RID: 186309 RVA: 0x00AC1957 File Offset: 0x00ABFB57
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraModifier_Condition(Pointer, MemoryOwner);
		}

		// Token: 0x04019A44 RID: 105028
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Condition.SCameraModifier_Condition";

		// Token: 0x04019A45 RID: 105029
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019A46 RID: 105030
		internal static int __PropertyOffset_0;

		// Token: 0x04019A47 RID: 105031
		internal static int __PropertyOffset_1;

		// Token: 0x04019A48 RID: 105032
		internal static int __PropertyOffset_2;

		// Token: 0x04019A49 RID: 105033
		[Nullable(2)]
		private FGameplayTagContainer _TagToCheck;

		// Token: 0x04019A4A RID: 105034
		internal static int __PropertyOffset_3;

		// Token: 0x04019A4B RID: 105035
		internal static int __PropertyOffset_4;

		// Token: 0x04019A4C RID: 105036
		internal static int __PropertyOffset_5;

		// Token: 0x04019A4D RID: 105037
		internal static int __PropertyOffset_6;

		// Token: 0x04019A4E RID: 105038
		internal static int __PropertyOffset_7;

		// Token: 0x04019A4F RID: 105039
		internal static int __PropertyOffset_8;

		// Token: 0x04019A50 RID: 105040
		internal static int __PropertyOffset_9;

		// Token: 0x04019A51 RID: 105041
		internal static int __PropertyOffset_10;

		// Token: 0x04019A52 RID: 105042
		internal static int __PropertyOffset_11;

		// Token: 0x04019A53 RID: 105043
		internal static int __PropertyOffset_12;

		// Token: 0x04019A54 RID: 105044
		internal static int __PropertyOffset_13;

		// Token: 0x04019A55 RID: 105045
		internal static int __PropertyOffset_14;

		// Token: 0x04019A56 RID: 105046
		internal static int __PropertyOffset_15;

		// Token: 0x04019A57 RID: 105047
		internal static int __PropertyOffset_16;

		// Token: 0x04019A58 RID: 105048
		internal static int __PropertyOffset_17;

		// Token: 0x04019A59 RID: 105049
		internal static int __PropertyOffset_18;
	}
}
