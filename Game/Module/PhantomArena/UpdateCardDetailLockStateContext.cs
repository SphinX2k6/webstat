using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005499 RID: 21657
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class UpdateCardDetailLockStateContext
	{
		// Token: 0x060371B5 RID: 225717 RVA: 0x00DFD96A File Offset: 0x00DFBB6A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public UpdateCardDetailLockStateContext()
		{
		}

		// Token: 0x0401FBA6 RID: 129958
		[RequiredMember]
		public int CardId;

		// Token: 0x0401FBA7 RID: 129959
		[RequiredMember]
		public bool IsUnLocked;

		// Token: 0x0401FBA8 RID: 129960
		[RequiredMember]
		public UUIItem LockTipItem;

		// Token: 0x0401FBA9 RID: 129961
		[RequiredMember]
		public UUIText LockTipText;

		// Token: 0x0401FBAA RID: 129962
		[RequiredMember]
		public UUIText TipText;

		// Token: 0x0401FBAB RID: 129963
		[RequiredMember]
		public ButtonItem UnlockBtnItem;

		// Token: 0x0401FBAC RID: 129964
		[RequiredMember]
		public bool ShowUnlockRedDotWhenCanUnlock;
	}
}
