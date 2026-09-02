using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001EE0 RID: 7904
[NullableContext(1)]
[Nullable(0)]
public class HonamiSortOrderListClass
{
	// Token: 0x0600EA39 RID: 59961 RVA: 0x003F7FF0 File Offset: 0x003F61F0
	public List<List<int>> GetSortOrderList(int length)
	{
		if (length == this.CurCacheLength)
		{
			return this.OutputResult;
		}
		this.OutputResult.Clear();
		this.TempOrderRes.Clear();
		this.OccupyList.Clear();
		for (int i = 0; i < length; i++)
		{
			this.OccupyList.Add(false);
		}
		this.CreateSortOrder();
		this.CurCacheLength = length;
		return this.OutputResult;
	}

	// Token: 0x0600EA3A RID: 59962 RVA: 0x003F805C File Offset: 0x003F625C
	private void CreateSortOrder()
	{
		if (this.TempOrderRes.Count == this.OccupyList.Count)
		{
			this.OutputResult.Add(new List<int>(this.TempOrderRes));
			return;
		}
		for (int i = 0; i < this.OccupyList.Count; i++)
		{
			if (!this.OccupyList[i])
			{
				this.OccupyList[i] = true;
				this.TempOrderRes.Add(i);
				this.CreateSortOrder();
				this.TempOrderRes.RemoveAt(this.TempOrderRes.Count - 1);
				this.OccupyList[i] = false;
			}
		}
	}

	// Token: 0x040070E7 RID: 28903
	private readonly List<int> TempOrderRes = new List<int>();

	// Token: 0x040070E8 RID: 28904
	private readonly List<bool> OccupyList = new List<bool>();

	// Token: 0x040070E9 RID: 28905
	private readonly List<List<int>> OutputResult = new List<List<int>>();

	// Token: 0x040070EA RID: 28906
	private int CurCacheLength;
}
