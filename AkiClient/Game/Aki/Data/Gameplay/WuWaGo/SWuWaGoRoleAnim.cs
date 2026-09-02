using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.WuWaGo
{
	// Token: 0x02003E99 RID: 16025
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/WuWaGo/SWuWaGoRoleAnim.SWuWaGoRoleAnim")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 128)]
	public class SWuWaGoRoleAnim : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027BAE RID: 162734 RVA: 0x009F9260 File Offset: 0x009F7460
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWuWaGoRoleAnim._ScriptStructPtr != 0) ? SWuWaGoRoleAnim._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/WuWaGo/SWuWaGoRoleAnim.SWuWaGoRoleAnim", ref SWuWaGoRoleAnim._ScriptStructPtr);
		}

		// Token: 0x17005E90 RID: 24208
		// (get) Token: 0x06027BAF RID: 162735 RVA: 0x009F9284 File Offset: 0x009F7484
		// (set) Token: 0x06027BB0 RID: 162736 RVA: 0x009F92C7 File Offset: 0x009F74C7
		public TArray<TSoftObjectPtr<UAnimMontage>> Attack
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UAnimMontage>> result;
				if ((result = this._Attack) == null)
				{
					result = (this._Attack = new TArray<TSoftObjectPtr<UAnimMontage>>(base.NativePtr + (IntPtr)SWuWaGoRoleAnim.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Attack.CopyAssign(value);
			}
		}

		// Token: 0x17005E91 RID: 24209
		// (get) Token: 0x06027BB1 RID: 162737 RVA: 0x009F92D8 File Offset: 0x009F74D8
		// (set) Token: 0x06027BB2 RID: 162738 RVA: 0x009F931B File Offset: 0x009F751B
		public TArray<TSoftObjectPtr<UAnimMontage>> Death
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UAnimMontage>> result;
				if ((result = this._Death) == null)
				{
					result = (this._Death = new TArray<TSoftObjectPtr<UAnimMontage>>(base.NativePtr + (IntPtr)SWuWaGoRoleAnim.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Death.CopyAssign(value);
			}
		}

		// Token: 0x17005E92 RID: 24210
		// (get) Token: 0x06027BB3 RID: 162739 RVA: 0x009F932C File Offset: 0x009F752C
		// (set) Token: 0x06027BB4 RID: 162740 RVA: 0x009F936F File Offset: 0x009F756F
		public TArray<TSoftObjectPtr<UAnimMontage>> BeHit
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UAnimMontage>> result;
				if ((result = this._BeHit) == null)
				{
					result = (this._BeHit = new TArray<TSoftObjectPtr<UAnimMontage>>(base.NativePtr + (IntPtr)SWuWaGoRoleAnim.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BeHit.CopyAssign(value);
			}
		}

		// Token: 0x17005E93 RID: 24211
		// (get) Token: 0x06027BB5 RID: 162741 RVA: 0x009F9380 File Offset: 0x009F7580
		// (set) Token: 0x06027BB6 RID: 162742 RVA: 0x009F93C3 File Offset: 0x009F75C3
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<EWuWaGoClimbMontage>, TSoftObjectPtr<UAnimMontage>> Climb
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EWuWaGoClimbMontage>, TSoftObjectPtr<UAnimMontage>> result;
				if ((result = this._Climb) == null)
				{
					result = (this._Climb = new TMap<TEnumAsByte<EWuWaGoClimbMontage>, TSoftObjectPtr<UAnimMontage>>(base.NativePtr + (IntPtr)SWuWaGoRoleAnim.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.Climb.CopyAssign(value);
			}
		}

		// Token: 0x06027BB7 RID: 162743 RVA: 0x009F93D1 File Offset: 0x009F75D1
		public SWuWaGoRoleAnim()
		{
		}

		// Token: 0x06027BB8 RID: 162744 RVA: 0x009F93D9 File Offset: 0x009F75D9
		public SWuWaGoRoleAnim(TArray<TSoftObjectPtr<UAnimMontage>> Attack, TArray<TSoftObjectPtr<UAnimMontage>> Death, TArray<TSoftObjectPtr<UAnimMontage>> BeHit, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] TMap<TEnumAsByte<EWuWaGoClimbMontage>, TSoftObjectPtr<UAnimMontage>> Climb)
		{
			this.Attack = Attack;
			this.Death = Death;
			this.BeHit = BeHit;
			this.Climb = Climb;
		}

		// Token: 0x06027BB9 RID: 162745 RVA: 0x009F93FE File Offset: 0x009F75FE
		protected override IntPtr GetUStructPtr()
		{
			return SWuWaGoRoleAnim.StaticStruct();
		}

		// Token: 0x06027BBA RID: 162746 RVA: 0x009F940A File Offset: 0x009F760A
		[NullableContext(2)]
		public SWuWaGoRoleAnim(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027BBB RID: 162747 RVA: 0x009F9414 File Offset: 0x009F7614
		public SWuWaGoRoleAnim(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027BBC RID: 162748 RVA: 0x009F941F File Offset: 0x009F761F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWuWaGoRoleAnim(Pointer, false, true);
		}

		// Token: 0x06027BBD RID: 162749 RVA: 0x009F9429 File Offset: 0x009F7629
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWuWaGoRoleAnim(Pointer, MemoryOwner);
		}

		// Token: 0x04014D79 RID: 85369
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/WuWaGo/SWuWaGoRoleAnim.SWuWaGoRoleAnim";

		// Token: 0x04014D7A RID: 85370
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014D7B RID: 85371
		internal static int __PropertyOffset_0;

		// Token: 0x04014D7C RID: 85372
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UAnimMontage>> _Attack;

		// Token: 0x04014D7D RID: 85373
		internal static int __PropertyOffset_1;

		// Token: 0x04014D7E RID: 85374
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UAnimMontage>> _Death;

		// Token: 0x04014D7F RID: 85375
		internal static int __PropertyOffset_2;

		// Token: 0x04014D80 RID: 85376
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UAnimMontage>> _BeHit;

		// Token: 0x04014D81 RID: 85377
		internal static int __PropertyOffset_3;

		// Token: 0x04014D82 RID: 85378
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<EWuWaGoClimbMontage>, TSoftObjectPtr<UAnimMontage>> _Climb;
	}
}
