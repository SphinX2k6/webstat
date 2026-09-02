using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x02004314 RID: 17172
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Settings_ArmLengthDynamicValue.SCameraModifier_Settings_ArmLengthDynamicValue")]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 12)]
	public class SCameraModifier_Settings_ArmLengthDynamicValue : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D857 RID: 186455 RVA: 0x00AC2870 File Offset: 0x00AC0A70
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCameraModifier_Settings_ArmLengthDynamicValue._ScriptStructPtr != 0) ? SCameraModifier_Settings_ArmLengthDynamicValue._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Settings_ArmLengthDynamicValue.SCameraModifier_Settings_ArmLengthDynamicValue", ref SCameraModifier_Settings_ArmLengthDynamicValue._ScriptStructPtr);
		}

		// Token: 0x17007C91 RID: 31889
		// (get) Token: 0x0602D858 RID: 186456 RVA: 0x00AC2894 File Offset: 0x00AC0A94
		// (set) Token: 0x0602D859 RID: 186457 RVA: 0x00AC28A8 File Offset: 0x00AC0AA8
		public unsafe TEnumAsByte<ECameraModifier_Settings_ArmLengthDynamicValueType> ArmLengthDynamicValueType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings_ArmLengthDynamicValue.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings_ArmLengthDynamicValue.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007C92 RID: 31890
		// (get) Token: 0x0602D85A RID: 186458 RVA: 0x00AC28BD File Offset: 0x00AC0ABD
		// (set) Token: 0x0602D85B RID: 186459 RVA: 0x00AC28CD File Offset: 0x00AC0ACD
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings_ArmLengthDynamicValue.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings_ArmLengthDynamicValue.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007C93 RID: 31891
		// (get) Token: 0x0602D85C RID: 186460 RVA: 0x00AC28DE File Offset: 0x00AC0ADE
		// (set) Token: 0x0602D85D RID: 186461 RVA: 0x00AC28EE File Offset: 0x00AC0AEE
		public unsafe int ArmLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCameraModifier_Settings_ArmLengthDynamicValue.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCameraModifier_Settings_ArmLengthDynamicValue.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D85E RID: 186462 RVA: 0x00AC28FF File Offset: 0x00AC0AFF
		public SCameraModifier_Settings_ArmLengthDynamicValue()
		{
		}

		// Token: 0x0602D85F RID: 186463 RVA: 0x00AC2907 File Offset: 0x00AC0B07
		public SCameraModifier_Settings_ArmLengthDynamicValue(TEnumAsByte<ECameraModifier_Settings_ArmLengthDynamicValueType> ArmLengthDynamicValueType, int SkillId, int ArmLength)
		{
			this.ArmLengthDynamicValueType = ArmLengthDynamicValueType;
			this.SkillId = SkillId;
			this.ArmLength = ArmLength;
		}

		// Token: 0x0602D860 RID: 186464 RVA: 0x00AC2924 File Offset: 0x00AC0B24
		protected override IntPtr GetUStructPtr()
		{
			return SCameraModifier_Settings_ArmLengthDynamicValue.StaticStruct();
		}

		// Token: 0x0602D861 RID: 186465 RVA: 0x00AC2930 File Offset: 0x00AC0B30
		[NullableContext(2)]
		public SCameraModifier_Settings_ArmLengthDynamicValue(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D862 RID: 186466 RVA: 0x00AC293A File Offset: 0x00AC0B3A
		public SCameraModifier_Settings_ArmLengthDynamicValue(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D863 RID: 186467 RVA: 0x00AC2945 File Offset: 0x00AC0B45
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCameraModifier_Settings_ArmLengthDynamicValue(Pointer, false, true);
		}

		// Token: 0x0602D864 RID: 186468 RVA: 0x00AC294F File Offset: 0x00AC0B4F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCameraModifier_Settings_ArmLengthDynamicValue(Pointer, MemoryOwner);
		}

		// Token: 0x04019AAE RID: 105134
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/SCameraModifier_Settings_ArmLengthDynamicValue.SCameraModifier_Settings_ArmLengthDynamicValue";

		// Token: 0x04019AAF RID: 105135
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019AB0 RID: 105136
		internal static int __PropertyOffset_0;

		// Token: 0x04019AB1 RID: 105137
		internal static int __PropertyOffset_1;

		// Token: 0x04019AB2 RID: 105138
		internal static int __PropertyOffset_2;
	}
}
