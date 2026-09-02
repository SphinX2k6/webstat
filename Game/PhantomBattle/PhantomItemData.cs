using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.PhantomBattle
{
	// Token: 0x02004A70 RID: 19056
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomItemData : IPhantomItemData
	{
		// Token: 0x1700848F RID: 33935
		// (get) Token: 0x06031C00 RID: 203776 RVA: 0x00C75550 File Offset: 0x00C73750
		// (set) Token: 0x06031C01 RID: 203777 RVA: 0x00C75558 File Offset: 0x00C73758
		public bool IsPhantomData { get; set; }

		// Token: 0x17008490 RID: 33936
		// (get) Token: 0x06031C02 RID: 203778 RVA: 0x00C75561 File Offset: 0x00C73761
		// (set) Token: 0x06031C03 RID: 203779 RVA: 0x00C75569 File Offset: 0x00C73769
		public int Id { get; set; }

		// Token: 0x17008491 RID: 33937
		// (get) Token: 0x06031C04 RID: 203780 RVA: 0x00C75572 File Offset: 0x00C73772
		// (set) Token: 0x06031C05 RID: 203781 RVA: 0x00C7557A File Offset: 0x00C7377A
		public int Quality { get; set; }

		// Token: 0x17008492 RID: 33938
		// (get) Token: 0x06031C06 RID: 203782 RVA: 0x00C75583 File Offset: 0x00C73783
		// (set) Token: 0x06031C07 RID: 203783 RVA: 0x00C7558B File Offset: 0x00C7378B
		public bool IsEquip { get; set; }

		// Token: 0x17008493 RID: 33939
		// (get) Token: 0x06031C08 RID: 203784 RVA: 0x00C75594 File Offset: 0x00C73794
		// (set) Token: 0x06031C09 RID: 203785 RVA: 0x00C7559C File Offset: 0x00C7379C
		public int Role { get; set; }

		// Token: 0x17008494 RID: 33940
		// (get) Token: 0x06031C0A RID: 203786 RVA: 0x00C755A5 File Offset: 0x00C737A5
		// (set) Token: 0x06031C0B RID: 203787 RVA: 0x00C755AD File Offset: 0x00C737AD
		public int Level { get; set; }

		// Token: 0x17008495 RID: 33941
		// (get) Token: 0x06031C0C RID: 203788 RVA: 0x00C755B6 File Offset: 0x00C737B6
		// (set) Token: 0x06031C0D RID: 203789 RVA: 0x00C755BE File Offset: 0x00C737BE
		public bool IsBreach { get; set; }

		// Token: 0x17008496 RID: 33942
		// (get) Token: 0x06031C0E RID: 203790 RVA: 0x00C755C7 File Offset: 0x00C737C7
		// (set) Token: 0x06031C0F RID: 203791 RVA: 0x00C755CF File Offset: 0x00C737CF
		public int MonsterId { get; set; }

		// Token: 0x17008497 RID: 33943
		// (get) Token: 0x06031C10 RID: 203792 RVA: 0x00C755D8 File Offset: 0x00C737D8
		// (set) Token: 0x06031C11 RID: 203793 RVA: 0x00C755E0 File Offset: 0x00C737E0
		public List<PhantomSortStruct> MainPropMap { get; set; }

		// Token: 0x17008498 RID: 33944
		// (get) Token: 0x06031C12 RID: 203794 RVA: 0x00C755E9 File Offset: 0x00C737E9
		// (set) Token: 0x06031C13 RID: 203795 RVA: 0x00C755F1 File Offset: 0x00C737F1
		public List<PhantomSortStruct> SubPropMap { get; set; }

		// Token: 0x17008499 RID: 33945
		// (get) Token: 0x06031C14 RID: 203796 RVA: 0x00C755FA File Offset: 0x00C737FA
		// (set) Token: 0x06031C15 RID: 203797 RVA: 0x00C75602 File Offset: 0x00C73802
		public bool IsLock { get; set; }

		// Token: 0x1700849A RID: 33946
		// (get) Token: 0x06031C16 RID: 203798 RVA: 0x00C7560B File Offset: 0x00C7380B
		// (set) Token: 0x06031C17 RID: 203799 RVA: 0x00C75613 File Offset: 0x00C73813
		public bool IsDeprecate { get; set; }

		// Token: 0x1700849B RID: 33947
		// (get) Token: 0x06031C18 RID: 203800 RVA: 0x00C7561C File Offset: 0x00C7381C
		// (set) Token: 0x06031C19 RID: 203801 RVA: 0x00C75624 File Offset: 0x00C73824
		public int ConfigId { get; set; }

		// Token: 0x1700849C RID: 33948
		// (get) Token: 0x06031C1A RID: 203802 RVA: 0x00C7562D File Offset: 0x00C7382D
		// (set) Token: 0x06031C1B RID: 203803 RVA: 0x00C75635 File Offset: 0x00C73835
		public int Rarity { get; set; }
	}
}
