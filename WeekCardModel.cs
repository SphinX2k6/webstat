using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02002402 RID: 9218
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WeekCardModel : ModelBase<WeekCardModel>
{
	// Token: 0x06011D53 RID: 73043 RVA: 0x004E79B0 File Offset: 0x004E5BB0
	public void SetWeekCardInfos(IEnumerable<WeekCardInfo> infos)
	{
		foreach (WeekCardInfo weekCardInfo in infos)
		{
			this.Cards[weekCardInfo.WeekCardId] = new WeekCardData(weekCardInfo);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveWeekCardDataEvent);
	}

	// Token: 0x06011D54 RID: 73044 RVA: 0x004E7A18 File Offset: 0x004E5C18
	[NullableContext(2)]
	public WeekCardData GetById(int weekCardId)
	{
		return this.Cards.GetValueOrDefault(weekCardId);
	}

	// Token: 0x06011D55 RID: 73045 RVA: 0x004E7A26 File Offset: 0x004E5C26
	public IReadOnlyDictionary<int, WeekCardData> GetAll()
	{
		return this.Cards;
	}

	// Token: 0x06011D56 RID: 73046 RVA: 0x004E7A30 File Offset: 0x004E5C30
	public bool AnyOpen()
	{
		using (Dictionary<int, WeekCardData>.ValueCollection.Enumerator enumerator = this.Cards.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetWeekCardIsOpen())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06011D57 RID: 73047 RVA: 0x004E7A90 File Offset: 0x004E5C90
	public EWeekCardKind Classify(int weekCardId)
	{
		WeekCard? weekCard;
		if (((ConfigBase<WeekCardConfig>.Instance.GetConfig(weekCardId) != null) ? new int?(weekCard.GetValueOrDefault().ShowType) : null).GetValueOrDefault() != 2)
		{
			return EWeekCardKind.Normal;
		}
		return EWeekCardKind.NewPlayer;
	}

	// Token: 0x06011D58 RID: 73048 RVA: 0x004E7AE0 File Offset: 0x004E5CE0
	[NullableContext(2)]
	public WeekCardData GetDefaultByKind(EWeekCardKind kind)
	{
		foreach (WeekCardData weekCardData in this.Cards.Values)
		{
			if (this.Classify(weekCardData.WeekCardId) == kind)
			{
				return weekCardData;
			}
		}
		return null;
	}

	// Token: 0x06011D59 RID: 73049 RVA: 0x004E7B48 File Offset: 0x004E5D48
	public WeekCardViewModel GetViewModel(EWeekCardKind kind)
	{
		WeekCardViewModel weekCardViewModel;
		if (!this.ViewModels.TryGetValue(kind, out weekCardViewModel))
		{
			weekCardViewModel = new WeekCardViewModel(kind);
			this.ViewModels[kind] = weekCardViewModel;
		}
		return weekCardViewModel;
	}

	// Token: 0x04008B82 RID: 35714
	private readonly Dictionary<int, WeekCardData> Cards = new Dictionary<int, WeekCardData>();

	// Token: 0x04008B83 RID: 35715
	private readonly Dictionary<EWeekCardKind, WeekCardViewModel> ViewModels = new Dictionary<EWeekCardKind, WeekCardViewModel>();
}
