using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200427A RID: 17018
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillBehaviorCondition.SSkillBehaviorCondition")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 66)]
	public class SSkillBehaviorCondition : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D2B6 RID: 185014 RVA: 0x00AB91B7 File Offset: 0x00AB73B7
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillBehaviorCondition._ScriptStructPtr != 0) ? SSkillBehaviorCondition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillBehaviorCondition.SSkillBehaviorCondition", ref SSkillBehaviorCondition._ScriptStructPtr);
		}

		// Token: 0x17007AEC RID: 31468
		// (get) Token: 0x0602D2B7 RID: 185015 RVA: 0x00AB91DB File Offset: 0x00AB73DB
		// (set) Token: 0x0602D2B8 RID: 185016 RVA: 0x00AB91EF File Offset: 0x00AB73EF
		public unsafe TEnumAsByte<ESkillBehaviorConditionType> ConditionType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007AED RID: 31469
		// (get) Token: 0x0602D2B9 RID: 185017 RVA: 0x00AB9204 File Offset: 0x00AB7404
		// (set) Token: 0x0602D2BA RID: 185018 RVA: 0x00AB9214 File Offset: 0x00AB7414
		public unsafe bool IgnoreZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AEE RID: 31470
		// (get) Token: 0x0602D2BB RID: 185019 RVA: 0x00AB9225 File Offset: 0x00AB7425
		// (set) Token: 0x0602D2BC RID: 185020 RVA: 0x00AB9235 File Offset: 0x00AB7435
		public unsafe bool Sign
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AEF RID: 31471
		// (get) Token: 0x0602D2BD RID: 185021 RVA: 0x00AB9246 File Offset: 0x00AB7446
		// (set) Token: 0x0602D2BE RID: 185022 RVA: 0x00AB925A File Offset: 0x00AB745A
		public unsafe TEnumAsByte<ESkillBehaviorComparisonLogic> ComparisonLogic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007AF0 RID: 31472
		// (get) Token: 0x0602D2BF RID: 185023 RVA: 0x00AB926F File Offset: 0x00AB746F
		// (set) Token: 0x0602D2C0 RID: 185024 RVA: 0x00AB927F File Offset: 0x00AB747F
		public unsafe float Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007AF1 RID: 31473
		// (get) Token: 0x0602D2C1 RID: 185025 RVA: 0x00AB9290 File Offset: 0x00AB7490
		// (set) Token: 0x0602D2C2 RID: 185026 RVA: 0x00AB92A0 File Offset: 0x00AB74A0
		public unsafe float RangeL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007AF2 RID: 31474
		// (get) Token: 0x0602D2C3 RID: 185027 RVA: 0x00AB92B1 File Offset: 0x00AB74B1
		// (set) Token: 0x0602D2C4 RID: 185028 RVA: 0x00AB92C1 File Offset: 0x00AB74C1
		public unsafe float RangeR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007AF3 RID: 31475
		// (get) Token: 0x0602D2C5 RID: 185029 RVA: 0x00AB92D2 File Offset: 0x00AB74D2
		// (set) Token: 0x0602D2C6 RID: 185030 RVA: 0x00AB92E2 File Offset: 0x00AB74E2
		public unsafe int AttributeId1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007AF4 RID: 31476
		// (get) Token: 0x0602D2C7 RID: 185031 RVA: 0x00AB92F3 File Offset: 0x00AB74F3
		// (set) Token: 0x0602D2C8 RID: 185032 RVA: 0x00AB9303 File Offset: 0x00AB7503
		public unsafe int AttributeId2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007AF5 RID: 31477
		// (get) Token: 0x0602D2C9 RID: 185033 RVA: 0x00AB9314 File Offset: 0x00AB7514
		// (set) Token: 0x0602D2CA RID: 185034 RVA: 0x00AB9324 File Offset: 0x00AB7524
		public unsafe int AttributeRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007AF6 RID: 31478
		// (get) Token: 0x0602D2CB RID: 185035 RVA: 0x00AB9338 File Offset: 0x00AB7538
		// (set) Token: 0x0602D2CC RID: 185036 RVA: 0x00AB937B File Offset: 0x00AB757B
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
					result = (this._TagToCheck = new FGameplayTagContainer(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AF7 RID: 31479
		// (get) Token: 0x0602D2CD RID: 185037 RVA: 0x00AB939C File Offset: 0x00AB759C
		// (set) Token: 0x0602D2CE RID: 185038 RVA: 0x00AB93AC File Offset: 0x00AB75AC
		public unsafe bool AnyTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AF8 RID: 31480
		// (get) Token: 0x0602D2CF RID: 185039 RVA: 0x00AB93BD File Offset: 0x00AB75BD
		// (set) Token: 0x0602D2D0 RID: 185040 RVA: 0x00AB93CD File Offset: 0x00AB75CD
		public unsafe bool Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorCondition.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D2D1 RID: 185041 RVA: 0x00AB93DE File Offset: 0x00AB75DE
		public SSkillBehaviorCondition()
		{
		}

		// Token: 0x0602D2D2 RID: 185042 RVA: 0x00AB93E8 File Offset: 0x00AB75E8
		public SSkillBehaviorCondition(TEnumAsByte<ESkillBehaviorConditionType> ConditionType, bool IgnoreZ, bool Sign, TEnumAsByte<ESkillBehaviorComparisonLogic> ComparisonLogic, float Value, float RangeL, float RangeR, int AttributeId1, int AttributeId2, int AttributeRate, [Nullable(1)] FGameplayTagContainer TagToCheck, bool AnyTag, bool Reverse)
		{
			this.ConditionType = ConditionType;
			this.IgnoreZ = IgnoreZ;
			this.Sign = Sign;
			this.ComparisonLogic = ComparisonLogic;
			this.Value = Value;
			this.RangeL = RangeL;
			this.RangeR = RangeR;
			this.AttributeId1 = AttributeId1;
			this.AttributeId2 = AttributeId2;
			this.AttributeRate = AttributeRate;
			this.TagToCheck = TagToCheck;
			this.AnyTag = AnyTag;
			this.Reverse = Reverse;
		}

		// Token: 0x0602D2D3 RID: 185043 RVA: 0x00AB9460 File Offset: 0x00AB7660
		protected override IntPtr GetUStructPtr()
		{
			return SSkillBehaviorCondition.StaticStruct();
		}

		// Token: 0x0602D2D4 RID: 185044 RVA: 0x00AB946C File Offset: 0x00AB766C
		[NullableContext(2)]
		public SSkillBehaviorCondition(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D2D5 RID: 185045 RVA: 0x00AB9476 File Offset: 0x00AB7676
		public SSkillBehaviorCondition(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D2D6 RID: 185046 RVA: 0x00AB9481 File Offset: 0x00AB7681
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillBehaviorCondition(Pointer, false, true);
		}

		// Token: 0x0602D2D7 RID: 185047 RVA: 0x00AB948B File Offset: 0x00AB768B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillBehaviorCondition(Pointer, MemoryOwner);
		}

		// Token: 0x0401952D RID: 103725
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillBehaviorCondition.SSkillBehaviorCondition";

		// Token: 0x0401952E RID: 103726
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401952F RID: 103727
		internal static int __PropertyOffset_0;

		// Token: 0x04019530 RID: 103728
		internal static int __PropertyOffset_1;

		// Token: 0x04019531 RID: 103729
		internal static int __PropertyOffset_2;

		// Token: 0x04019532 RID: 103730
		internal static int __PropertyOffset_3;

		// Token: 0x04019533 RID: 103731
		internal static int __PropertyOffset_4;

		// Token: 0x04019534 RID: 103732
		internal static int __PropertyOffset_5;

		// Token: 0x04019535 RID: 103733
		internal static int __PropertyOffset_6;

		// Token: 0x04019536 RID: 103734
		internal static int __PropertyOffset_7;

		// Token: 0x04019537 RID: 103735
		internal static int __PropertyOffset_8;

		// Token: 0x04019538 RID: 103736
		internal static int __PropertyOffset_9;

		// Token: 0x04019539 RID: 103737
		internal static int __PropertyOffset_10;

		// Token: 0x0401953A RID: 103738
		[Nullable(2)]
		private FGameplayTagContainer _TagToCheck;

		// Token: 0x0401953B RID: 103739
		internal static int __PropertyOffset_11;

		// Token: 0x0401953C RID: 103740
		internal static int __PropertyOffset_12;
	}
}
