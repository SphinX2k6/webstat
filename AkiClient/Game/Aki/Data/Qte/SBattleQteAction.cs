using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E40 RID: 15936
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SBattleQteAction.SBattleQteAction")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 136)]
	public class SBattleQteAction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602742C RID: 160812 RVA: 0x009ED86E File Offset: 0x009EBA6E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBattleQteAction._ScriptStructPtr != 0) ? SBattleQteAction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SBattleQteAction.SBattleQteAction", ref SBattleQteAction._ScriptStructPtr);
		}

		// Token: 0x17005BDE RID: 23518
		// (get) Token: 0x0602742D RID: 160813 RVA: 0x009ED892 File Offset: 0x009EBA92
		// (set) Token: 0x0602742E RID: 160814 RVA: 0x009ED8A2 File Offset: 0x009EBAA2
		public unsafe int Target
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BDF RID: 23519
		// (get) Token: 0x0602742F RID: 160815 RVA: 0x009ED8B4 File Offset: 0x009EBAB4
		// (set) Token: 0x06027430 RID: 160816 RVA: 0x009ED8F7 File Offset: 0x009EBAF7
		public TArray<FGameplayTag> TagConditions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._TagConditions) == null)
				{
					result = (this._TagConditions = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TagConditions.CopyAssign(value);
			}
		}

		// Token: 0x17005BE0 RID: 23520
		// (get) Token: 0x06027431 RID: 160817 RVA: 0x009ED908 File Offset: 0x009EBB08
		// (set) Token: 0x06027432 RID: 160818 RVA: 0x009ED94B File Offset: 0x009EBB4B
		public TArray<FGameplayTag> AddTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._AddTags) == null)
				{
					result = (this._AddTags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AddTags.CopyAssign(value);
			}
		}

		// Token: 0x17005BE1 RID: 23521
		// (get) Token: 0x06027433 RID: 160819 RVA: 0x009ED95C File Offset: 0x009EBB5C
		// (set) Token: 0x06027434 RID: 160820 RVA: 0x009ED99F File Offset: 0x009EBB9F
		public TArray<FGameplayTag> RemoveTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._RemoveTags) == null)
				{
					result = (this._RemoveTags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RemoveTags.CopyAssign(value);
			}
		}

		// Token: 0x17005BE2 RID: 23522
		// (get) Token: 0x06027435 RID: 160821 RVA: 0x009ED9B0 File Offset: 0x009EBBB0
		// (set) Token: 0x06027436 RID: 160822 RVA: 0x009ED9F3 File Offset: 0x009EBBF3
		public TArray<long> AddBuffs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._AddBuffs) == null)
				{
					result = (this._AddBuffs = new TArray<long>(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AddBuffs.CopyAssign(value);
			}
		}

		// Token: 0x17005BE3 RID: 23523
		// (get) Token: 0x06027437 RID: 160823 RVA: 0x009EDA04 File Offset: 0x009EBC04
		// (set) Token: 0x06027438 RID: 160824 RVA: 0x009EDA47 File Offset: 0x009EBC47
		public TArray<long> RemoveBuffs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._RemoveBuffs) == null)
				{
					result = (this._RemoveBuffs = new TArray<long>(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RemoveBuffs.CopyAssign(value);
			}
		}

		// Token: 0x17005BE4 RID: 23524
		// (get) Token: 0x06027439 RID: 160825 RVA: 0x009EDA58 File Offset: 0x009EBC58
		// (set) Token: 0x0602743A RID: 160826 RVA: 0x009EDA9B File Offset: 0x009EBC9B
		public TArray<long> AddBullets
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._AddBullets) == null)
				{
					result = (this._AddBullets = new TArray<long>(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AddBullets.CopyAssign(value);
			}
		}

		// Token: 0x17005BE5 RID: 23525
		// (get) Token: 0x0602743B RID: 160827 RVA: 0x009EDAA9 File Offset: 0x009EBCA9
		// (set) Token: 0x0602743C RID: 160828 RVA: 0x009EDAB9 File Offset: 0x009EBCB9
		public unsafe int UseSkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005BE6 RID: 23526
		// (get) Token: 0x0602743D RID: 160829 RVA: 0x009EDACA File Offset: 0x009EBCCA
		// (set) Token: 0x0602743E RID: 160830 RVA: 0x009EDADA File Offset: 0x009EBCDA
		public unsafe int ChangeMainSkillPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005BE7 RID: 23527
		// (get) Token: 0x0602743F RID: 160831 RVA: 0x009EDAEB File Offset: 0x009EBCEB
		// (set) Token: 0x06027440 RID: 160832 RVA: 0x009EDAFF File Offset: 0x009EBCFF
		[Nullable(0)]
		public unsafe TEnumAsByte<EBattleQteCustomAction> CustomAction
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_9);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SBattleQteAction.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005BE8 RID: 23528
		// (get) Token: 0x06027441 RID: 160833 RVA: 0x009EDB14 File Offset: 0x009EBD14
		// (set) Token: 0x06027442 RID: 160834 RVA: 0x009EDB28 File Offset: 0x009EBD28
		public unsafe string CustomActionParam
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBattleQteAction.__PropertyOffset_10)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBattleQteAction.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x06027443 RID: 160835 RVA: 0x009EDB3D File Offset: 0x009EBD3D
		public SBattleQteAction()
		{
		}

		// Token: 0x06027444 RID: 160836 RVA: 0x009EDB48 File Offset: 0x009EBD48
		public SBattleQteAction(int Target, TArray<FGameplayTag> TagConditions, TArray<FGameplayTag> AddTags, TArray<FGameplayTag> RemoveTags, TArray<long> AddBuffs, TArray<long> RemoveBuffs, TArray<long> AddBullets, int UseSkillId, int ChangeMainSkillPriority, [Nullable(0)] TEnumAsByte<EBattleQteCustomAction> CustomAction, string CustomActionParam)
		{
			this.Target = Target;
			this.TagConditions = TagConditions;
			this.AddTags = AddTags;
			this.RemoveTags = RemoveTags;
			this.AddBuffs = AddBuffs;
			this.RemoveBuffs = RemoveBuffs;
			this.AddBullets = AddBullets;
			this.UseSkillId = UseSkillId;
			this.ChangeMainSkillPriority = ChangeMainSkillPriority;
			this.CustomAction = CustomAction;
			this.CustomActionParam = CustomActionParam;
		}

		// Token: 0x06027445 RID: 160837 RVA: 0x009EDBB0 File Offset: 0x009EBDB0
		protected override IntPtr GetUStructPtr()
		{
			return SBattleQteAction.StaticStruct();
		}

		// Token: 0x06027446 RID: 160838 RVA: 0x009EDBBC File Offset: 0x009EBDBC
		[NullableContext(2)]
		public SBattleQteAction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027447 RID: 160839 RVA: 0x009EDBC6 File Offset: 0x009EBDC6
		public SBattleQteAction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027448 RID: 160840 RVA: 0x009EDBD1 File Offset: 0x009EBDD1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBattleQteAction(Pointer, false, true);
		}

		// Token: 0x06027449 RID: 160841 RVA: 0x009EDBDB File Offset: 0x009EBDDB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBattleQteAction(Pointer, MemoryOwner);
		}

		// Token: 0x040148E2 RID: 84194
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SBattleQteAction.SBattleQteAction";

		// Token: 0x040148E3 RID: 84195
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040148E4 RID: 84196
		internal static int __PropertyOffset_0;

		// Token: 0x040148E5 RID: 84197
		internal static int __PropertyOffset_1;

		// Token: 0x040148E6 RID: 84198
		[Nullable(2)]
		private TArray<FGameplayTag> _TagConditions;

		// Token: 0x040148E7 RID: 84199
		internal static int __PropertyOffset_2;

		// Token: 0x040148E8 RID: 84200
		[Nullable(2)]
		private TArray<FGameplayTag> _AddTags;

		// Token: 0x040148E9 RID: 84201
		internal static int __PropertyOffset_3;

		// Token: 0x040148EA RID: 84202
		[Nullable(2)]
		private TArray<FGameplayTag> _RemoveTags;

		// Token: 0x040148EB RID: 84203
		internal static int __PropertyOffset_4;

		// Token: 0x040148EC RID: 84204
		[Nullable(2)]
		private TArray<long> _AddBuffs;

		// Token: 0x040148ED RID: 84205
		internal static int __PropertyOffset_5;

		// Token: 0x040148EE RID: 84206
		[Nullable(2)]
		private TArray<long> _RemoveBuffs;

		// Token: 0x040148EF RID: 84207
		internal static int __PropertyOffset_6;

		// Token: 0x040148F0 RID: 84208
		[Nullable(2)]
		private TArray<long> _AddBullets;

		// Token: 0x040148F1 RID: 84209
		internal static int __PropertyOffset_7;

		// Token: 0x040148F2 RID: 84210
		internal static int __PropertyOffset_8;

		// Token: 0x040148F3 RID: 84211
		internal static int __PropertyOffset_9;

		// Token: 0x040148F4 RID: 84212
		internal static int __PropertyOffset_10;
	}
}
