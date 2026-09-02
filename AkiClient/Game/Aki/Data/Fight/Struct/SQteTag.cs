using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED9 RID: 16089
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SQteTag.SQteTag")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 91)]
	public class SQteTag : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602803D RID: 163901 RVA: 0x00A0055C File Offset: 0x009FE75C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQteTag._ScriptStructPtr != 0) ? SQteTag._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SQteTag.SQteTag", ref SQteTag._ScriptStructPtr);
		}

		// Token: 0x17005FFF RID: 24575
		// (get) Token: 0x0602803E RID: 163902 RVA: 0x00A00580 File Offset: 0x009FE780
		// (set) Token: 0x0602803F RID: 163903 RVA: 0x00A00594 File Offset: 0x009FE794
		public unsafe FGameplayTag QteTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006000 RID: 24576
		// (get) Token: 0x06028040 RID: 163904 RVA: 0x00A005A9 File Offset: 0x009FE7A9
		// (set) Token: 0x06028041 RID: 163905 RVA: 0x00A005BD File Offset: 0x009FE7BD
		public unsafe FGameplayTag NoTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006001 RID: 24577
		// (get) Token: 0x06028042 RID: 163906 RVA: 0x00A005D2 File Offset: 0x009FE7D2
		// (set) Token: 0x06028043 RID: 163907 RVA: 0x00A005E6 File Offset: 0x009FE7E6
		public unsafe FGameplayTag QteTrigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006002 RID: 24578
		// (get) Token: 0x06028044 RID: 163908 RVA: 0x00A005FB File Offset: 0x009FE7FB
		// (set) Token: 0x06028045 RID: 163909 RVA: 0x00A0060F File Offset: 0x009FE80F
		public unsafe FGameplayTag ExitSkillTrigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006003 RID: 24579
		// (get) Token: 0x06028046 RID: 163910 RVA: 0x00A00624 File Offset: 0x009FE824
		// (set) Token: 0x06028047 RID: 163911 RVA: 0x00A00634 File Offset: 0x009FE834
		public unsafe int Energy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006004 RID: 24580
		// (get) Token: 0x06028048 RID: 163912 RVA: 0x00A00648 File Offset: 0x009FE848
		// (set) Token: 0x06028049 RID: 163913 RVA: 0x00A0068B File Offset: 0x009FE88B
		public TArray<long> QteBuffs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._QteBuffs) == null)
				{
					result = (this._QteBuffs = new TArray<long>(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.QteBuffs.CopyAssign(value);
			}
		}

		// Token: 0x17006005 RID: 24581
		// (get) Token: 0x0602804A RID: 163914 RVA: 0x00A0069C File Offset: 0x009FE89C
		// (set) Token: 0x0602804B RID: 163915 RVA: 0x00A006DF File Offset: 0x009FE8DF
		public TArray<long> ConsumeBuffs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._ConsumeBuffs) == null)
				{
					result = (this._ConsumeBuffs = new TArray<long>(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ConsumeBuffs.CopyAssign(value);
			}
		}

		// Token: 0x17006006 RID: 24582
		// (get) Token: 0x0602804C RID: 163916 RVA: 0x00A006ED File Offset: 0x009FE8ED
		// (set) Token: 0x0602804D RID: 163917 RVA: 0x00A006FD File Offset: 0x009FE8FD
		public unsafe bool ChangeRoleOnQte
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006007 RID: 24583
		// (get) Token: 0x0602804E RID: 163918 RVA: 0x00A0070E File Offset: 0x009FE90E
		// (set) Token: 0x0602804F RID: 163919 RVA: 0x00A0071E File Offset: 0x009FE91E
		public unsafe bool ChangeRole
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006008 RID: 24584
		// (get) Token: 0x06028050 RID: 163920 RVA: 0x00A0072F File Offset: 0x009FE92F
		// (set) Token: 0x06028051 RID: 163921 RVA: 0x00A0073F File Offset: 0x009FE93F
		public unsafe byte Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQteTag.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x06028052 RID: 163922 RVA: 0x00A00750 File Offset: 0x009FE950
		public SQteTag()
		{
		}

		// Token: 0x06028053 RID: 163923 RVA: 0x00A00758 File Offset: 0x009FE958
		public SQteTag(FGameplayTag QteTag, FGameplayTag NoTag, FGameplayTag QteTrigger, FGameplayTag ExitSkillTrigger, int Energy, TArray<long> QteBuffs, TArray<long> ConsumeBuffs, bool ChangeRoleOnQte, bool ChangeRole, byte Priority)
		{
			this.QteTag = QteTag;
			this.NoTag = NoTag;
			this.QteTrigger = QteTrigger;
			this.ExitSkillTrigger = ExitSkillTrigger;
			this.Energy = Energy;
			this.QteBuffs = QteBuffs;
			this.ConsumeBuffs = ConsumeBuffs;
			this.ChangeRoleOnQte = ChangeRoleOnQte;
			this.ChangeRole = ChangeRole;
			this.Priority = Priority;
		}

		// Token: 0x06028054 RID: 163924 RVA: 0x00A007B8 File Offset: 0x009FE9B8
		protected override IntPtr GetUStructPtr()
		{
			return SQteTag.StaticStruct();
		}

		// Token: 0x06028055 RID: 163925 RVA: 0x00A007C4 File Offset: 0x009FE9C4
		[NullableContext(2)]
		public SQteTag(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028056 RID: 163926 RVA: 0x00A007CE File Offset: 0x009FE9CE
		public SQteTag(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028057 RID: 163927 RVA: 0x00A007D9 File Offset: 0x009FE9D9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQteTag(Pointer, false, true);
		}

		// Token: 0x06028058 RID: 163928 RVA: 0x00A007E3 File Offset: 0x009FE9E3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQteTag(Pointer, MemoryOwner);
		}

		// Token: 0x04015018 RID: 86040
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SQteTag.SQteTag";

		// Token: 0x04015019 RID: 86041
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401501A RID: 86042
		internal static int __PropertyOffset_0;

		// Token: 0x0401501B RID: 86043
		internal static int __PropertyOffset_1;

		// Token: 0x0401501C RID: 86044
		internal static int __PropertyOffset_2;

		// Token: 0x0401501D RID: 86045
		internal static int __PropertyOffset_3;

		// Token: 0x0401501E RID: 86046
		internal static int __PropertyOffset_4;

		// Token: 0x0401501F RID: 86047
		internal static int __PropertyOffset_5;

		// Token: 0x04015020 RID: 86048
		[Nullable(2)]
		private TArray<long> _QteBuffs;

		// Token: 0x04015021 RID: 86049
		internal static int __PropertyOffset_6;

		// Token: 0x04015022 RID: 86050
		[Nullable(2)]
		private TArray<long> _ConsumeBuffs;

		// Token: 0x04015023 RID: 86051
		internal static int __PropertyOffset_7;

		// Token: 0x04015024 RID: 86052
		internal static int __PropertyOffset_8;

		// Token: 0x04015025 RID: 86053
		internal static int __PropertyOffset_9;
	}
}
