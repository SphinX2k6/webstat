using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED0 RID: 16080
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SInputCommandTransform.SInputCommandTransform")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 84)]
	public class SInputCommandTransform : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027F67 RID: 163687 RVA: 0x009FF25C File Offset: 0x009FD45C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputCommandTransform._ScriptStructPtr != 0) ? SInputCommandTransform._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SInputCommandTransform.SInputCommandTransform", ref SInputCommandTransform._ScriptStructPtr);
		}

		// Token: 0x17005FB8 RID: 24504
		// (get) Token: 0x06027F68 RID: 163688 RVA: 0x009FF280 File Offset: 0x009FD480
		// (set) Token: 0x06027F69 RID: 163689 RVA: 0x009FF294 File Offset: 0x009FD494
		public unsafe string Desc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SInputCommandTransform.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SInputCommandTransform.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005FB9 RID: 24505
		// (get) Token: 0x06027F6A RID: 163690 RVA: 0x009FF2A9 File Offset: 0x009FD4A9
		// (set) Token: 0x06027F6B RID: 163691 RVA: 0x009FF2BD File Offset: 0x009FD4BD
		[Nullable(0)]
		public unsafe TEnumAsByte<EInputAction> Action
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005FBA RID: 24506
		// (get) Token: 0x06027F6C RID: 163692 RVA: 0x009FF2D2 File Offset: 0x009FD4D2
		// (set) Token: 0x06027F6D RID: 163693 RVA: 0x009FF2E6 File Offset: 0x009FD4E6
		[Nullable(0)]
		public unsafe TEnumAsByte<EInputState> State
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_2);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005FBB RID: 24507
		// (get) Token: 0x06027F6E RID: 163694 RVA: 0x009FF2FB File Offset: 0x009FD4FB
		// (set) Token: 0x06027F6F RID: 163695 RVA: 0x009FF30F File Offset: 0x009FD50F
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005FBC RID: 24508
		// (get) Token: 0x06027F70 RID: 163696 RVA: 0x009FF324 File Offset: 0x009FD524
		// (set) Token: 0x06027F71 RID: 163697 RVA: 0x009FF367 File Offset: 0x009FD567
		public TArray<SSkillBehaviorCondition> BehaviorConditionGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSkillBehaviorCondition> result;
				if ((result = this._BehaviorConditionGroup) == null)
				{
					result = (this._BehaviorConditionGroup = new TArray<SSkillBehaviorCondition>(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BehaviorConditionGroup.CopyAssign(value);
			}
		}

		// Token: 0x17005FBD RID: 24509
		// (get) Token: 0x06027F72 RID: 163698 RVA: 0x009FF375 File Offset: 0x009FD575
		// (set) Token: 0x06027F73 RID: 163699 RVA: 0x009FF389 File Offset: 0x009FD589
		public unsafe string BehaviorConditionFormula
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SInputCommandTransform.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SInputCommandTransform.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17005FBE RID: 24510
		// (get) Token: 0x06027F74 RID: 163700 RVA: 0x009FF3A0 File Offset: 0x009FD5A0
		// (set) Token: 0x06027F75 RID: 163701 RVA: 0x009FF3E3 File Offset: 0x009FD5E3
		public SInputCommand Command
		{
			get
			{
				base.FastCheckIsValid();
				SInputCommand result;
				if ((result = this._Command) == null)
				{
					result = (this._Command = new SInputCommand(base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SInputCommand.StaticStruct(), base.NativePtr + (IntPtr)SInputCommandTransform.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027F76 RID: 163702 RVA: 0x009FF404 File Offset: 0x009FD604
		public SInputCommandTransform()
		{
		}

		// Token: 0x06027F77 RID: 163703 RVA: 0x009FF40C File Offset: 0x009FD60C
		public SInputCommandTransform(string Desc, [Nullable(0)] TEnumAsByte<EInputAction> Action, [Nullable(0)] TEnumAsByte<EInputState> State, FGameplayTag Tag, TArray<SSkillBehaviorCondition> BehaviorConditionGroup, string BehaviorConditionFormula, SInputCommand Command)
		{
			this.Desc = Desc;
			this.Action = Action;
			this.State = State;
			this.Tag = Tag;
			this.BehaviorConditionGroup = BehaviorConditionGroup;
			this.BehaviorConditionFormula = BehaviorConditionFormula;
			this.Command = Command;
		}

		// Token: 0x06027F78 RID: 163704 RVA: 0x009FF449 File Offset: 0x009FD649
		protected override IntPtr GetUStructPtr()
		{
			return SInputCommandTransform.StaticStruct();
		}

		// Token: 0x06027F79 RID: 163705 RVA: 0x009FF455 File Offset: 0x009FD655
		[NullableContext(2)]
		public SInputCommandTransform(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027F7A RID: 163706 RVA: 0x009FF45F File Offset: 0x009FD65F
		public SInputCommandTransform(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027F7B RID: 163707 RVA: 0x009FF46A File Offset: 0x009FD66A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInputCommandTransform(Pointer, false, true);
		}

		// Token: 0x06027F7C RID: 163708 RVA: 0x009FF474 File Offset: 0x009FD674
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInputCommandTransform(Pointer, MemoryOwner);
		}

		// Token: 0x04014FB4 RID: 85940
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SInputCommandTransform.SInputCommandTransform";

		// Token: 0x04014FB5 RID: 85941
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014FB6 RID: 85942
		internal static int __PropertyOffset_0;

		// Token: 0x04014FB7 RID: 85943
		internal static int __PropertyOffset_1;

		// Token: 0x04014FB8 RID: 85944
		internal static int __PropertyOffset_2;

		// Token: 0x04014FB9 RID: 85945
		internal static int __PropertyOffset_3;

		// Token: 0x04014FBA RID: 85946
		internal static int __PropertyOffset_4;

		// Token: 0x04014FBB RID: 85947
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSkillBehaviorCondition> _BehaviorConditionGroup;

		// Token: 0x04014FBC RID: 85948
		internal static int __PropertyOffset_5;

		// Token: 0x04014FBD RID: 85949
		internal static int __PropertyOffset_6;

		// Token: 0x04014FBE RID: 85950
		[Nullable(2)]
		private SInputCommand _Command;
	}
}
