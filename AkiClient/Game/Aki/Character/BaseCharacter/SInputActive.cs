using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004269 RID: 17001
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SInputActive.SInputActive")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SInputActive : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D135 RID: 184629 RVA: 0x00AB6C6D File Offset: 0x00AB4E6D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputActive._ScriptStructPtr != 0) ? SInputActive._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SInputActive.SInputActive", ref SInputActive._ScriptStructPtr);
		}

		// Token: 0x17007A6E RID: 31342
		// (get) Token: 0x0602D136 RID: 184630 RVA: 0x00AB6C94 File Offset: 0x00AB4E94
		// (set) Token: 0x0602D137 RID: 184631 RVA: 0x00AB6CD7 File Offset: 0x00AB4ED7
		public TArray<SInputActiveCondition> InputActiveConditionGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SInputActiveCondition> result;
				if ((result = this._InputActiveConditionGroup) == null)
				{
					result = (this._InputActiveConditionGroup = new TArray<SInputActiveCondition>(base.NativePtr + (IntPtr)SInputActive.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.InputActiveConditionGroup.CopyAssign(value);
			}
		}

		// Token: 0x17007A6F RID: 31343
		// (get) Token: 0x0602D138 RID: 184632 RVA: 0x00AB6CE5 File Offset: 0x00AB4EE5
		// (set) Token: 0x0602D139 RID: 184633 RVA: 0x00AB6CF9 File Offset: 0x00AB4EF9
		public unsafe string InputActiveConditionFormula
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SInputActive.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SInputActive.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x0602D13A RID: 184634 RVA: 0x00AB6D0E File Offset: 0x00AB4F0E
		public SInputActive()
		{
		}

		// Token: 0x0602D13B RID: 184635 RVA: 0x00AB6D16 File Offset: 0x00AB4F16
		public SInputActive(TArray<SInputActiveCondition> InputActiveConditionGroup, string InputActiveConditionFormula)
		{
			this.InputActiveConditionGroup = InputActiveConditionGroup;
			this.InputActiveConditionFormula = InputActiveConditionFormula;
		}

		// Token: 0x0602D13C RID: 184636 RVA: 0x00AB6D2C File Offset: 0x00AB4F2C
		protected override IntPtr GetUStructPtr()
		{
			return SInputActive.StaticStruct();
		}

		// Token: 0x0602D13D RID: 184637 RVA: 0x00AB6D38 File Offset: 0x00AB4F38
		[NullableContext(2)]
		public SInputActive(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D13E RID: 184638 RVA: 0x00AB6D42 File Offset: 0x00AB4F42
		public SInputActive(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D13F RID: 184639 RVA: 0x00AB6D4D File Offset: 0x00AB4F4D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInputActive(Pointer, false, true);
		}

		// Token: 0x0602D140 RID: 184640 RVA: 0x00AB6D57 File Offset: 0x00AB4F57
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInputActive(Pointer, MemoryOwner);
		}

		// Token: 0x04019467 RID: 103527
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SInputActive.SInputActive";

		// Token: 0x04019468 RID: 103528
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019469 RID: 103529
		internal static int __PropertyOffset_0;

		// Token: 0x0401946A RID: 103530
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SInputActiveCondition> _InputActiveConditionGroup;

		// Token: 0x0401946B RID: 103531
		internal static int __PropertyOffset_1;
	}
}
