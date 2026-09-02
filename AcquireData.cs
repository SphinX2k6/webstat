using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02000FF2 RID: 4082
[NullableContext(2)]
[Nullable(0)]
public class AcquireData : UiPopViewData
{
	// Token: 0x06006977 RID: 26999 RVA: 0x001B7AB4 File Offset: 0x001B5CB4
	public void SetAcquireViewType(EAcquireViewType acquireViewType)
	{
		this.AcquireViewType = acquireViewType;
	}

	// Token: 0x06006978 RID: 27000 RVA: 0x001B7ABD File Offset: 0x001B5CBD
	public EAcquireViewType GetAcquireViewType()
	{
		return this.AcquireViewType;
	}

	// Token: 0x06006979 RID: 27001 RVA: 0x001B7AC5 File Offset: 0x001B5CC5
	public void SetAmount(int amount)
	{
		this.Amount = amount;
	}

	// Token: 0x0600697A RID: 27002 RVA: 0x001B7ACE File Offset: 0x001B5CCE
	public int GetAmount()
	{
		return this.Amount;
	}

	// Token: 0x0600697B RID: 27003 RVA: 0x001B7AD6 File Offset: 0x001B5CD6
	public void SetMaxAmount(int maxAmount)
	{
		this.MaxAmount = maxAmount;
	}

	// Token: 0x0600697C RID: 27004 RVA: 0x001B7ADF File Offset: 0x001B5CDF
	public void SetConfigId(int id)
	{
		this.ConfigId = id;
	}

	// Token: 0x0600697D RID: 27005 RVA: 0x001B7AE8 File Offset: 0x001B5CE8
	public int GetMaxAmount()
	{
		return this.MaxAmount;
	}

	// Token: 0x0600697E RID: 27006 RVA: 0x001B7AF0 File Offset: 0x001B5CF0
	[NullableContext(1)]
	public void SetLeftButtonFunction(Func<UniTask> leftButtonFunction)
	{
		this.LeftButtonFunction = leftButtonFunction;
	}

	// Token: 0x0600697F RID: 27007 RVA: 0x001B7AF9 File Offset: 0x001B5CF9
	[NullableContext(1)]
	public void SetRightButtonFunction(Func<UniTask> rightButtonFunction)
	{
		this.RightButtonFunction = rightButtonFunction;
	}

	// Token: 0x06006980 RID: 27008 RVA: 0x001B7B02 File Offset: 0x001B5D02
	[NullableContext(1)]
	public void SetMidButtonFunction(Func<UniTask> midButtonFunction)
	{
		this.MidButtonFunction = midButtonFunction;
	}

	// Token: 0x06006981 RID: 27009 RVA: 0x001B7B0B File Offset: 0x001B5D0B
	public Func<UniTask> GetLeftButtonFunction()
	{
		return this.LeftButtonFunction;
	}

	// Token: 0x06006982 RID: 27010 RVA: 0x001B7B13 File Offset: 0x001B5D13
	public Func<UniTask> GetRightButtonFunction()
	{
		return this.RightButtonFunction;
	}

	// Token: 0x06006983 RID: 27011 RVA: 0x001B7B1B File Offset: 0x001B5D1B
	public Func<UniTask> GetMidButtonFunction()
	{
		return this.MidButtonFunction;
	}

	// Token: 0x06006984 RID: 27012 RVA: 0x001B7B23 File Offset: 0x001B5D23
	[NullableContext(1)]
	public void SetItemData(List<TItem> itemDataList)
	{
		this.ItemDataList = itemDataList;
	}

	// Token: 0x06006985 RID: 27013 RVA: 0x001B7B2C File Offset: 0x001B5D2C
	public List<TItem> GetItemData()
	{
		return this.ItemDataList;
	}

	// Token: 0x06006986 RID: 27014 RVA: 0x001B7B34 File Offset: 0x001B5D34
	[NullableContext(1)]
	public void SetLeftButtonTextTableId(string id)
	{
		this.LeftButtonTextTableId = id;
	}

	// Token: 0x06006987 RID: 27015 RVA: 0x001B7B3D File Offset: 0x001B5D3D
	[NullableContext(1)]
	public string GetLeftButtonTextTableId()
	{
		return this.LeftButtonTextTableId;
	}

	// Token: 0x06006988 RID: 27016 RVA: 0x001B7B45 File Offset: 0x001B5D45
	[NullableContext(1)]
	public void SetRightButtonTextTableId(string id)
	{
		this.RightButtonTextTableId = id;
	}

	// Token: 0x06006989 RID: 27017 RVA: 0x001B7B4E File Offset: 0x001B5D4E
	[NullableContext(1)]
	public string GetRightButtonTextTableId()
	{
		return this.RightButtonTextTableId;
	}

	// Token: 0x0600698A RID: 27018 RVA: 0x001B7B56 File Offset: 0x001B5D56
	public void SetRemainItemCount(int count)
	{
		this.RemainItemCount = count;
	}

	// Token: 0x0600698B RID: 27019 RVA: 0x001B7B5F File Offset: 0x001B5D5F
	public int GetRemainItemCount()
	{
		return this.RemainItemCount;
	}

	// Token: 0x0600698C RID: 27020 RVA: 0x001B7B67 File Offset: 0x001B5D67
	[NullableContext(1)]
	public void SetNameText(string name)
	{
		this.NameText = name;
	}

	// Token: 0x0600698D RID: 27021 RVA: 0x001B7B70 File Offset: 0x001B5D70
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600698E RID: 27022 RVA: 0x001B7B78 File Offset: 0x001B5D78
	[NullableContext(1)]
	public string GetNameText()
	{
		return this.NameText;
	}

	// Token: 0x04003217 RID: 12823
	private EAcquireViewType AcquireViewType;

	// Token: 0x04003218 RID: 12824
	private int Amount;

	// Token: 0x04003219 RID: 12825
	private int MaxAmount;

	// Token: 0x0400321A RID: 12826
	private Func<UniTask> LeftButtonFunction;

	// Token: 0x0400321B RID: 12827
	private Func<UniTask> RightButtonFunction;

	// Token: 0x0400321C RID: 12828
	private Func<UniTask> MidButtonFunction;

	// Token: 0x0400321D RID: 12829
	private string LeftButtonTextTableId;

	// Token: 0x0400321E RID: 12830
	private string RightButtonTextTableId;

	// Token: 0x0400321F RID: 12831
	private List<TItem> ItemDataList;

	// Token: 0x04003220 RID: 12832
	private int RemainItemCount;

	// Token: 0x04003221 RID: 12833
	private string NameText;

	// Token: 0x04003222 RID: 12834
	private int ConfigId;
}
