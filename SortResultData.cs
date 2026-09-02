using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;

// Token: 0x02001955 RID: 6485
[NullableContext(1)]
[Nullable(0)]
public class SortResultData : IStaticVariableResetter
{
	// Token: 0x0600B9F0 RID: 47600 RVA: 0x0031895F File Offset: 0x00316B5F
	static SortResultData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SortResultData.CreateStaticDefaultValue), new Action(SortResultData.ResetStaticDefaultValue));
	}

	// Token: 0x0600B9F1 RID: 47601 RVA: 0x0031897E File Offset: 0x00316B7E
	public static void CreateStaticDefaultValue()
	{
		SortResultData.IncrementId = 0;
	}

	// Token: 0x0600B9F2 RID: 47602 RVA: 0x00318986 File Offset: 0x00316B86
	public static void ResetStaticDefaultValue()
	{
		SortResultData.IncrementId = 0;
	}

	// Token: 0x17000F18 RID: 3864
	// (get) Token: 0x0600B9F3 RID: 47603 RVA: 0x0031898E File Offset: 0x00316B8E
	public int ConfigId
	{
		get
		{
			return this.ConfigIdInternal;
		}
	}

	// Token: 0x0600B9F4 RID: 47604 RVA: 0x00318996 File Offset: 0x00316B96
	public SortResultData()
	{
		this.UniqueId = ++SortResultData.IncrementId;
	}

	// Token: 0x0600B9F5 RID: 47605 RVA: 0x003189B1 File Offset: 0x00316BB1
	public void SetConfigId(int configId)
	{
		this.ConfigIdInternal = configId;
	}

	// Token: 0x0600B9F6 RID: 47606 RVA: 0x003189BA File Offset: 0x00316BBA
	public void SetSelectBaseSort(SortViewBaseSort baseSort)
	{
		this.SelectBaseSort = baseSort;
	}

	// Token: 0x0600B9F7 RID: 47607 RVA: 0x003189C3 File Offset: 0x00316BC3
	public void SetSelectAttributeSort(Dictionary<int, string> attributeSort)
	{
		this.SelectAttributeSort = attributeSort;
	}

	// Token: 0x0600B9F8 RID: 47608 RVA: 0x003189CC File Offset: 0x00316BCC
	[NullableContext(2)]
	public SortViewBaseSort GetSelectBaseSort()
	{
		return this.SelectBaseSort;
	}

	// Token: 0x0600B9F9 RID: 47609 RVA: 0x003189D4 File Offset: 0x00316BD4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, string> GetSelectAttributeSort()
	{
		return this.SelectAttributeSort;
	}

	// Token: 0x0600B9FA RID: 47610 RVA: 0x003189DC File Offset: 0x00316BDC
	public void SetIsAscending(bool value)
	{
		this.IsAscending = value;
	}

	// Token: 0x0600B9FB RID: 47611 RVA: 0x003189E5 File Offset: 0x00316BE5
	public bool GetIsAscending()
	{
		return this.IsAscending;
	}

	// Token: 0x0600B9FC RID: 47612 RVA: 0x003189F0 File Offset: 0x00316BF0
	public HashSet<int> GetAllSelectRuleSet()
	{
		HashSet<int> hashSet = new HashSet<int>();
		Sort? sortConfig = ConfigBase<SortConfig>.Instance.GetSortConfig(this.ConfigId);
		foreach (int item in sortConfig.Value.FrontSortList())
		{
			hashSet.Add(item);
		}
		hashSet.Add(this.SelectBaseSort.RuleId);
		if (this.SelectAttributeSort != null)
		{
			foreach (int item2 in this.SelectAttributeSort.Keys)
			{
				hashSet.Add(item2);
			}
		}
		foreach (int item3 in sortConfig.Value.LastSortList())
		{
			hashSet.Add(item3);
		}
		return hashSet;
	}

	// Token: 0x0600B9FD RID: 47613 RVA: 0x00318AD8 File Offset: 0x00316CD8
	public string ShowAllSortContent()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(this.SelectBaseSort.RuleName);
		stringBuilder.Append(',');
		if (this.SelectAttributeSort != null)
		{
			foreach (string value in this.SelectAttributeSort.Values)
			{
				stringBuilder.Append(value);
				stringBuilder.Append(',');
			}
		}
		stringBuilder.Length = ((stringBuilder.Length > 0) ? (stringBuilder.Length - 1) : 0);
		return stringBuilder.ToString();
	}

	// Token: 0x0600B9FE RID: 47614 RVA: 0x00318B84 File Offset: 0x00316D84
	public SortStorageData ConvertToStorageData()
	{
		SortStorageData sortStorageData = new SortStorageData
		{
			ConfigId = this.ConfigId,
			IsAscending = this.IsAscending
		};
		SortViewBaseSort selectBaseSort = this.GetSelectBaseSort();
		if (selectBaseSort != null)
		{
			sortStorageData.SelectBaseSort = new int?(selectBaseSort.RuleId);
		}
		Dictionary<int, string> selectAttributeSort = this.GetSelectAttributeSort();
		if (selectAttributeSort != null)
		{
			List<int> selectAttributeSort2 = new List<int>(selectAttributeSort.Keys);
			sortStorageData.SelectAttributeSort = selectAttributeSort2;
		}
		return sortStorageData;
	}

	// Token: 0x040057E1 RID: 22497
	private int ConfigIdInternal;

	// Token: 0x040057E2 RID: 22498
	[Nullable(2)]
	private SortViewBaseSort SelectBaseSort;

	// Token: 0x040057E3 RID: 22499
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> SelectAttributeSort;

	// Token: 0x040057E4 RID: 22500
	private bool IsAscending;

	// Token: 0x040057E5 RID: 22501
	private static int IncrementId;

	// Token: 0x040057E6 RID: 22502
	public readonly int UniqueId;
}
