using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Manufacture.Compose;

// Token: 0x02001929 RID: 6441
[NullableContext(1)]
[Nullable(0)]
public class ComposeExchangeSort : CommonSort<EComposeExchangeSortWayType>
{
	// Token: 0x0600B921 RID: 47393 RVA: 0x00313B0C File Offset: 0x00311D0C
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IExchangeData exchangeData = a as IExchangeData;
		if (exchangeData == null)
		{
			return 0;
		}
		IExchangeData exchangeData2 = b as IExchangeData;
		if (exchangeData2 == null)
		{
			return 0;
		}
		if (exchangeData2.IsUnlock != exchangeData.IsUnlock)
		{
			int num = exchangeData2.IsUnlock - exchangeData.IsUnlock;
			if (!isAscending)
			{
				return -num;
			}
			return num;
		}
		else
		{
			if (exchangeData.Quality != exchangeData2.Quality)
			{
				return (exchangeData2.Quality - exchangeData.Quality) * (isAscending ? -1 : 1);
			}
			return exchangeData.ConfigId - exchangeData2.ConfigId;
		}
	}

	// Token: 0x0600B922 RID: 47394 RVA: 0x00313B88 File Offset: 0x00311D88
	private int SortMake(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IExchangeData exchangeData = a as IExchangeData;
		if (exchangeData == null)
		{
			return 0;
		}
		IExchangeData exchangeData2 = b as IExchangeData;
		if (exchangeData2 == null)
		{
			return 0;
		}
		if (exchangeData2.IsUnlock != exchangeData.IsUnlock)
		{
			int num = exchangeData2.IsUnlock - exchangeData.IsUnlock;
			if (!isAscending)
			{
				return -num;
			}
			return num;
		}
		else
		{
			int num2 = (!ModelBase<ComposeModel>.Instance.CheckCanExchange(exchangeData.ConfigId)) ? 1 : 0;
			int num3 = (!ModelBase<ComposeModel>.Instance.CheckCanExchange(exchangeData2.ConfigId)) ? 1 : 0;
			if (num2 != num3)
			{
				return num2 - num3;
			}
			return 0;
		}
	}

	// Token: 0x0600B923 RID: 47395 RVA: 0x00313C05 File Offset: 0x00311E05
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EComposeExchangeSortWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(EComposeExchangeSortWayType.Make, new TSortResult(this.SortMake));
	}
}
