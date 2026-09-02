using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004276 RID: 17014
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillBehavior.SSkillBehavior")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 49)]
	public class SSkillBehavior : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D210 RID: 184848 RVA: 0x00AB81B6 File Offset: 0x00AB63B6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillBehavior._ScriptStructPtr != 0) ? SSkillBehavior._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillBehavior.SSkillBehavior", ref SSkillBehavior._ScriptStructPtr);
		}

		// Token: 0x17007AA9 RID: 31401
		// (get) Token: 0x0602D211 RID: 184849 RVA: 0x00AB81DC File Offset: 0x00AB63DC
		// (set) Token: 0x0602D212 RID: 184850 RVA: 0x00AB821F File Offset: 0x00AB641F
		public TArray<SSkillBehaviorCondition> SkillBehaviorConditionGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSkillBehaviorCondition> result;
				if ((result = this._SkillBehaviorConditionGroup) == null)
				{
					result = (this._SkillBehaviorConditionGroup = new TArray<SSkillBehaviorCondition>(base.NativePtr + (IntPtr)SSkillBehavior.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillBehaviorConditionGroup.CopyAssign(value);
			}
		}

		// Token: 0x17007AAA RID: 31402
		// (get) Token: 0x0602D213 RID: 184851 RVA: 0x00AB822D File Offset: 0x00AB642D
		// (set) Token: 0x0602D214 RID: 184852 RVA: 0x00AB8241 File Offset: 0x00AB6441
		public unsafe string SkillBehaviorConditionFormula
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehavior.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehavior.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007AAB RID: 31403
		// (get) Token: 0x0602D215 RID: 184853 RVA: 0x00AB8258 File Offset: 0x00AB6458
		// (set) Token: 0x0602D216 RID: 184854 RVA: 0x00AB829B File Offset: 0x00AB649B
		public TArray<SSkillBehaviorAction> SkillBehaviorActionGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSkillBehaviorAction> result;
				if ((result = this._SkillBehaviorActionGroup) == null)
				{
					result = (this._SkillBehaviorActionGroup = new TArray<SSkillBehaviorAction>(base.NativePtr + (IntPtr)SSkillBehavior.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillBehaviorActionGroup.CopyAssign(value);
			}
		}

		// Token: 0x17007AAC RID: 31404
		// (get) Token: 0x0602D217 RID: 184855 RVA: 0x00AB82A9 File Offset: 0x00AB64A9
		// (set) Token: 0x0602D218 RID: 184856 RVA: 0x00AB82B9 File Offset: 0x00AB64B9
		public unsafe bool SkillBehaviorContinue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehavior.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehavior.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D219 RID: 184857 RVA: 0x00AB82CA File Offset: 0x00AB64CA
		public SSkillBehavior()
		{
		}

		// Token: 0x0602D21A RID: 184858 RVA: 0x00AB82D2 File Offset: 0x00AB64D2
		public SSkillBehavior(TArray<SSkillBehaviorCondition> SkillBehaviorConditionGroup, string SkillBehaviorConditionFormula, TArray<SSkillBehaviorAction> SkillBehaviorActionGroup, bool SkillBehaviorContinue)
		{
			this.SkillBehaviorConditionGroup = SkillBehaviorConditionGroup;
			this.SkillBehaviorConditionFormula = SkillBehaviorConditionFormula;
			this.SkillBehaviorActionGroup = SkillBehaviorActionGroup;
			this.SkillBehaviorContinue = SkillBehaviorContinue;
		}

		// Token: 0x0602D21B RID: 184859 RVA: 0x00AB82F7 File Offset: 0x00AB64F7
		protected override IntPtr GetUStructPtr()
		{
			return SSkillBehavior.StaticStruct();
		}

		// Token: 0x0602D21C RID: 184860 RVA: 0x00AB8303 File Offset: 0x00AB6503
		[NullableContext(2)]
		public SSkillBehavior(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D21D RID: 184861 RVA: 0x00AB830D File Offset: 0x00AB650D
		public SSkillBehavior(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D21E RID: 184862 RVA: 0x00AB8318 File Offset: 0x00AB6518
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillBehavior(Pointer, false, true);
		}

		// Token: 0x0602D21F RID: 184863 RVA: 0x00AB8322 File Offset: 0x00AB6522
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillBehavior(Pointer, MemoryOwner);
		}

		// Token: 0x040194D6 RID: 103638
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillBehavior.SSkillBehavior";

		// Token: 0x040194D7 RID: 103639
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040194D8 RID: 103640
		internal static int __PropertyOffset_0;

		// Token: 0x040194D9 RID: 103641
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSkillBehaviorCondition> _SkillBehaviorConditionGroup;

		// Token: 0x040194DA RID: 103642
		internal static int __PropertyOffset_1;

		// Token: 0x040194DB RID: 103643
		internal static int __PropertyOffset_2;

		// Token: 0x040194DC RID: 103644
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSkillBehaviorAction> _SkillBehaviorActionGroup;

		// Token: 0x040194DD RID: 103645
		internal static int __PropertyOffset_3;
	}
}
