using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200427C RID: 17020
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillBehaviorUpdateCustomValue.SSkillBehaviorUpdateCustomValue")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SSkillBehaviorUpdateCustomValue : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D2DF RID: 185055 RVA: 0x00AB953C File Offset: 0x00AB773C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillBehaviorUpdateCustomValue._ScriptStructPtr != 0) ? SSkillBehaviorUpdateCustomValue._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillBehaviorUpdateCustomValue.SSkillBehaviorUpdateCustomValue", ref SSkillBehaviorUpdateCustomValue._ScriptStructPtr);
		}

		// Token: 0x17007AF9 RID: 31481
		// (get) Token: 0x0602D2E0 RID: 185056 RVA: 0x00AB9560 File Offset: 0x00AB7760
		// (set) Token: 0x0602D2E1 RID: 185057 RVA: 0x00AB95A3 File Offset: 0x00AB77A3
		public TArray<string> ValueName
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._ValueName) == null)
				{
					result = (this._ValueName = new TArray<string>(base.NativePtr + (IntPtr)SSkillBehaviorUpdateCustomValue.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ValueName.CopyAssign(value);
			}
		}

		// Token: 0x0602D2E2 RID: 185058 RVA: 0x00AB95B1 File Offset: 0x00AB77B1
		public SSkillBehaviorUpdateCustomValue()
		{
		}

		// Token: 0x0602D2E3 RID: 185059 RVA: 0x00AB95B9 File Offset: 0x00AB77B9
		public SSkillBehaviorUpdateCustomValue(TArray<string> ValueName)
		{
			this.ValueName = ValueName;
		}

		// Token: 0x0602D2E4 RID: 185060 RVA: 0x00AB95C8 File Offset: 0x00AB77C8
		protected override IntPtr GetUStructPtr()
		{
			return SSkillBehaviorUpdateCustomValue.StaticStruct();
		}

		// Token: 0x0602D2E5 RID: 185061 RVA: 0x00AB95D4 File Offset: 0x00AB77D4
		[NullableContext(2)]
		public SSkillBehaviorUpdateCustomValue(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D2E6 RID: 185062 RVA: 0x00AB95DE File Offset: 0x00AB77DE
		public SSkillBehaviorUpdateCustomValue(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D2E7 RID: 185063 RVA: 0x00AB95E9 File Offset: 0x00AB77E9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillBehaviorUpdateCustomValue(Pointer, false, true);
		}

		// Token: 0x0602D2E8 RID: 185064 RVA: 0x00AB95F3 File Offset: 0x00AB77F3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillBehaviorUpdateCustomValue(Pointer, MemoryOwner);
		}

		// Token: 0x04019541 RID: 103745
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillBehaviorUpdateCustomValue.SSkillBehaviorUpdateCustomValue";

		// Token: 0x04019542 RID: 103746
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019543 RID: 103747
		internal static int __PropertyOffset_0;

		// Token: 0x04019544 RID: 103748
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _ValueName;
	}
}
