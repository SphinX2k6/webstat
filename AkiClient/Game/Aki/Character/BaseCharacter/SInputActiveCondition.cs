using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200426A RID: 17002
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SInputActiveCondition.SInputActiveCondition")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 66)]
	public class SInputActiveCondition : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D141 RID: 184641 RVA: 0x00AB6D60 File Offset: 0x00AB4F60
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputActiveCondition._ScriptStructPtr != 0) ? SInputActiveCondition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SInputActiveCondition.SInputActiveCondition", ref SInputActiveCondition._ScriptStructPtr);
		}

		// Token: 0x17007A70 RID: 31344
		// (get) Token: 0x0602D142 RID: 184642 RVA: 0x00AB6D84 File Offset: 0x00AB4F84
		// (set) Token: 0x0602D143 RID: 184643 RVA: 0x00AB6D98 File Offset: 0x00AB4F98
		public unsafe TEnumAsByte<EInputActiveConditionType> ConditionType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A71 RID: 31345
		// (get) Token: 0x0602D144 RID: 184644 RVA: 0x00AB6DAD File Offset: 0x00AB4FAD
		// (set) Token: 0x0602D145 RID: 184645 RVA: 0x00AB6DC1 File Offset: 0x00AB4FC1
		public unsafe TEnumAsByte<ESkillBehaviorComparisonLogic> ComparisonLogic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A72 RID: 31346
		// (get) Token: 0x0602D146 RID: 184646 RVA: 0x00AB6DD6 File Offset: 0x00AB4FD6
		// (set) Token: 0x0602D147 RID: 184647 RVA: 0x00AB6DE6 File Offset: 0x00AB4FE6
		public unsafe float Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A73 RID: 31347
		// (get) Token: 0x0602D148 RID: 184648 RVA: 0x00AB6DF7 File Offset: 0x00AB4FF7
		// (set) Token: 0x0602D149 RID: 184649 RVA: 0x00AB6E07 File Offset: 0x00AB5007
		public unsafe float RangeL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A74 RID: 31348
		// (get) Token: 0x0602D14A RID: 184650 RVA: 0x00AB6E18 File Offset: 0x00AB5018
		// (set) Token: 0x0602D14B RID: 184651 RVA: 0x00AB6E28 File Offset: 0x00AB5028
		public unsafe float RangeR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007A75 RID: 31349
		// (get) Token: 0x0602D14C RID: 184652 RVA: 0x00AB6E39 File Offset: 0x00AB5039
		// (set) Token: 0x0602D14D RID: 184653 RVA: 0x00AB6E49 File Offset: 0x00AB5049
		public unsafe int AttributeId1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007A76 RID: 31350
		// (get) Token: 0x0602D14E RID: 184654 RVA: 0x00AB6E5A File Offset: 0x00AB505A
		// (set) Token: 0x0602D14F RID: 184655 RVA: 0x00AB6E6A File Offset: 0x00AB506A
		public unsafe int AttributeId2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007A77 RID: 31351
		// (get) Token: 0x0602D150 RID: 184656 RVA: 0x00AB6E7B File Offset: 0x00AB507B
		// (set) Token: 0x0602D151 RID: 184657 RVA: 0x00AB6E8B File Offset: 0x00AB508B
		public unsafe int AttributeRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007A78 RID: 31352
		// (get) Token: 0x0602D152 RID: 184658 RVA: 0x00AB6E9C File Offset: 0x00AB509C
		// (set) Token: 0x0602D153 RID: 184659 RVA: 0x00AB6EDF File Offset: 0x00AB50DF
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
					result = (this._TagToCheck = new FGameplayTagContainer(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A79 RID: 31353
		// (get) Token: 0x0602D154 RID: 184660 RVA: 0x00AB6F00 File Offset: 0x00AB5100
		// (set) Token: 0x0602D155 RID: 184661 RVA: 0x00AB6F10 File Offset: 0x00AB5110
		public unsafe bool AnyTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007A7A RID: 31354
		// (get) Token: 0x0602D156 RID: 184662 RVA: 0x00AB6F21 File Offset: 0x00AB5121
		// (set) Token: 0x0602D157 RID: 184663 RVA: 0x00AB6F31 File Offset: 0x00AB5131
		public unsafe bool Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputActiveCondition.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D158 RID: 184664 RVA: 0x00AB6F42 File Offset: 0x00AB5142
		public SInputActiveCondition()
		{
		}

		// Token: 0x0602D159 RID: 184665 RVA: 0x00AB6F4C File Offset: 0x00AB514C
		public SInputActiveCondition(TEnumAsByte<EInputActiveConditionType> ConditionType, TEnumAsByte<ESkillBehaviorComparisonLogic> ComparisonLogic, float Value, float RangeL, float RangeR, int AttributeId1, int AttributeId2, int AttributeRate, [Nullable(1)] FGameplayTagContainer TagToCheck, bool AnyTag, bool Reverse)
		{
			this.ConditionType = ConditionType;
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

		// Token: 0x0602D15A RID: 184666 RVA: 0x00AB6FB4 File Offset: 0x00AB51B4
		protected override IntPtr GetUStructPtr()
		{
			return SInputActiveCondition.StaticStruct();
		}

		// Token: 0x0602D15B RID: 184667 RVA: 0x00AB6FC0 File Offset: 0x00AB51C0
		[NullableContext(2)]
		public SInputActiveCondition(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D15C RID: 184668 RVA: 0x00AB6FCA File Offset: 0x00AB51CA
		public SInputActiveCondition(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D15D RID: 184669 RVA: 0x00AB6FD5 File Offset: 0x00AB51D5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInputActiveCondition(Pointer, false, true);
		}

		// Token: 0x0602D15E RID: 184670 RVA: 0x00AB6FDF File Offset: 0x00AB51DF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInputActiveCondition(Pointer, MemoryOwner);
		}

		// Token: 0x0401946C RID: 103532
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SInputActiveCondition.SInputActiveCondition";

		// Token: 0x0401946D RID: 103533
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401946E RID: 103534
		internal static int __PropertyOffset_0;

		// Token: 0x0401946F RID: 103535
		internal static int __PropertyOffset_1;

		// Token: 0x04019470 RID: 103536
		internal static int __PropertyOffset_2;

		// Token: 0x04019471 RID: 103537
		internal static int __PropertyOffset_3;

		// Token: 0x04019472 RID: 103538
		internal static int __PropertyOffset_4;

		// Token: 0x04019473 RID: 103539
		internal static int __PropertyOffset_5;

		// Token: 0x04019474 RID: 103540
		internal static int __PropertyOffset_6;

		// Token: 0x04019475 RID: 103541
		internal static int __PropertyOffset_7;

		// Token: 0x04019476 RID: 103542
		internal static int __PropertyOffset_8;

		// Token: 0x04019477 RID: 103543
		[Nullable(2)]
		private FGameplayTagContainer _TagToCheck;

		// Token: 0x04019478 RID: 103544
		internal static int __PropertyOffset_9;

		// Token: 0x04019479 RID: 103545
		internal static int __PropertyOffset_10;
	}
}
