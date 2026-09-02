using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EDD RID: 16093
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SSkillMontage.SSkillMontage")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 128)]
	public class SSkillMontage : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060280E5 RID: 164069 RVA: 0x00A016EC File Offset: 0x009FF8EC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillMontage._ScriptStructPtr != 0) ? SSkillMontage._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SSkillMontage.SSkillMontage", ref SSkillMontage._ScriptStructPtr);
		}

		// Token: 0x17006043 RID: 24643
		// (get) Token: 0x060280E6 RID: 164070 RVA: 0x00A01710 File Offset: 0x009FF910
		// (set) Token: 0x060280E7 RID: 164071 RVA: 0x00A01724 File Offset: 0x009FF924
		public unsafe string CharacterPath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillMontage.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillMontage.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17006044 RID: 24644
		// (get) Token: 0x060280E8 RID: 164072 RVA: 0x00A01739 File Offset: 0x009FF939
		// (set) Token: 0x060280E9 RID: 164073 RVA: 0x00A0174D File Offset: 0x009FF94D
		public unsafe string MontageName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillMontage.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillMontage.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17006045 RID: 24645
		// (get) Token: 0x060280EA RID: 164074 RVA: 0x00A01762 File Offset: 0x009FF962
		// (set) Token: 0x060280EB RID: 164075 RVA: 0x00A01781 File Offset: 0x009FF981
		public TSoftObjectPtr<UAnimMontage> CommonAnim
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)SSkillMontage.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SSkillMontage.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17006046 RID: 24646
		// (get) Token: 0x060280EC RID: 164076 RVA: 0x00A017A6 File Offset: 0x009FF9A6
		// (set) Token: 0x060280ED RID: 164077 RVA: 0x00A017C5 File Offset: 0x009FF9C5
		public TSoftObjectPtr<UAnimMontage> BaseAnim
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)SSkillMontage.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SSkillMontage.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060280EE RID: 164078 RVA: 0x00A017EA File Offset: 0x009FF9EA
		public SSkillMontage()
		{
		}

		// Token: 0x060280EF RID: 164079 RVA: 0x00A017F2 File Offset: 0x009FF9F2
		public SSkillMontage(string CharacterPath, string MontageName, TSoftObjectPtr<UAnimMontage> CommonAnim, TSoftObjectPtr<UAnimMontage> BaseAnim)
		{
			this.CharacterPath = CharacterPath;
			this.MontageName = MontageName;
			this.CommonAnim = CommonAnim;
			this.BaseAnim = BaseAnim;
		}

		// Token: 0x060280F0 RID: 164080 RVA: 0x00A01817 File Offset: 0x009FFA17
		protected override IntPtr GetUStructPtr()
		{
			return SSkillMontage.StaticStruct();
		}

		// Token: 0x060280F1 RID: 164081 RVA: 0x00A01823 File Offset: 0x009FFA23
		[NullableContext(2)]
		public SSkillMontage(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060280F2 RID: 164082 RVA: 0x00A0182D File Offset: 0x009FFA2D
		public SSkillMontage(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060280F3 RID: 164083 RVA: 0x00A01838 File Offset: 0x009FFA38
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillMontage(Pointer, false, true);
		}

		// Token: 0x060280F4 RID: 164084 RVA: 0x00A01842 File Offset: 0x009FFA42
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillMontage(Pointer, MemoryOwner);
		}

		// Token: 0x04015074 RID: 86132
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SSkillMontage.SSkillMontage";

		// Token: 0x04015075 RID: 86133
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015076 RID: 86134
		internal static int __PropertyOffset_0;

		// Token: 0x04015077 RID: 86135
		internal static int __PropertyOffset_1;

		// Token: 0x04015078 RID: 86136
		internal static int __PropertyOffset_2;

		// Token: 0x04015079 RID: 86137
		internal static int __PropertyOffset_3;
	}
}
