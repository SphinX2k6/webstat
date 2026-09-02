using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024BD RID: 9405
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractEditGridViewModel : IPhantomInteractGridViewModel, IPhantomInteractGridData
{
	// Token: 0x06012405 RID: 74757 RVA: 0x00505C33 File Offset: 0x00503E33
	public PhantomInteractEditGridViewModel(IPhantomInteractGridData data)
	{
	}

	// Token: 0x1700171D RID: 5917
	// (get) Token: 0x06012406 RID: 74758 RVA: 0x00505C49 File Offset: 0x00503E49
	public int MonsterId
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.MonsterId;
		}
	}

	// Token: 0x1700171E RID: 5918
	// (get) Token: 0x06012407 RID: 74759 RVA: 0x00505C5C File Offset: 0x00503E5C
	public int MonsterInfoId
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.MonsterInfoId;
		}
	}

	// Token: 0x1700171F RID: 5919
	// (get) Token: 0x06012408 RID: 74760 RVA: 0x00505C6F File Offset: 0x00503E6F
	public List<int> SkinIds
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			return ((data != null) ? data.SkinIds : null) ?? new List<int>();
		}
	}

	// Token: 0x17001720 RID: 5920
	// (get) Token: 0x06012409 RID: 74761 RVA: 0x00505C8C File Offset: 0x00503E8C
	public int EquippedSkin
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.EquippedSkin;
		}
	}

	// Token: 0x17001721 RID: 5921
	// (get) Token: 0x0601240A RID: 74762 RVA: 0x00505C9F File Offset: 0x00503E9F
	public bool IsSpecial
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			return data != null && data.IsSpecial;
		}
	}

	// Token: 0x17001722 RID: 5922
	// (get) Token: 0x0601240B RID: 74763 RVA: 0x00505CB2 File Offset: 0x00503EB2
	[Nullable(2)]
	public string Name
	{
		[NullableContext(2)]
		get
		{
			IPhantomInteractGridData data = this.Data;
			return ((data != null) ? data.Name : null) ?? null;
		}
	}

	// Token: 0x17001723 RID: 5923
	// (get) Token: 0x0601240C RID: 74764 RVA: 0x00505CCB File Offset: 0x00503ECB
	public int Cost
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.Cost;
		}
	}

	// Token: 0x17001724 RID: 5924
	// (get) Token: 0x0601240D RID: 74765 RVA: 0x00505CDE File Offset: 0x00503EDE
	public bool IsUnlocked
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			return data != null && data.IsUnlocked;
		}
	}

	// Token: 0x17001725 RID: 5925
	// (get) Token: 0x0601240E RID: 74766 RVA: 0x00505CF1 File Offset: 0x00503EF1
	public List<int> InteractAreaList
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			return ((data != null) ? data.InteractAreaList : null) ?? new List<int>();
		}
	}

	// Token: 0x17001726 RID: 5926
	// (get) Token: 0x0601240F RID: 74767 RVA: 0x00505D0E File Offset: 0x00503F0E
	public int InSlotIndex
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			if (data == null)
			{
				return -1;
			}
			return data.InSlotIndex;
		}
	}

	// Token: 0x17001727 RID: 5927
	// (get) Token: 0x06012410 RID: 74768 RVA: 0x00505D21 File Offset: 0x00503F21
	[Nullable(2)]
	public string IconPath
	{
		[NullableContext(2)]
		get
		{
			IPhantomInteractGridData data = this.Data;
			return ((data != null) ? data.IconPath : null) ?? null;
		}
	}

	// Token: 0x17001728 RID: 5928
	// (get) Token: 0x06012411 RID: 74769 RVA: 0x00505D3A File Offset: 0x00503F3A
	public bool HasSkin
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			return data != null && data.HasSkin;
		}
	}

	// Token: 0x17001729 RID: 5929
	// (get) Token: 0x06012412 RID: 74770 RVA: 0x00505D4D File Offset: 0x00503F4D
	public int GetWayConfigId
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.GetWayConfigId;
		}
	}

	// Token: 0x1700172A RID: 5930
	// (get) Token: 0x06012413 RID: 74771 RVA: 0x00505D60 File Offset: 0x00503F60
	public int SortId
	{
		get
		{
			IPhantomInteractGridData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.SortId;
		}
	}

	// Token: 0x1700172B RID: 5931
	// (get) Token: 0x06012414 RID: 74772 RVA: 0x00505D73 File Offset: 0x00503F73
	// (set) Token: 0x06012415 RID: 74773 RVA: 0x00505D7B File Offset: 0x00503F7B
	public bool IsSelected { get; set; }

	// Token: 0x1700172C RID: 5932
	// (get) Token: 0x06012416 RID: 74774 RVA: 0x00505D84 File Offset: 0x00503F84
	// (set) Token: 0x06012417 RID: 74775 RVA: 0x00505D8C File Offset: 0x00503F8C
	public int GridIndex { get; set; } = -1;

	// Token: 0x1700172D RID: 5933
	// (get) Token: 0x06012418 RID: 74776 RVA: 0x00505D95 File Offset: 0x00503F95
	// (set) Token: 0x06012419 RID: 74777 RVA: 0x00505D9D File Offset: 0x00503F9D
	public bool IsInArea { get; set; }

	// Token: 0x04008E68 RID: 36456
	[Nullable(2)]
	private readonly IPhantomInteractGridData Data = data;
}
