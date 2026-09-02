using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200292A RID: 10538
public class RouletteComponentMainFunction : RouletteComponentMain
{
	// Token: 0x06014EB8 RID: 85688 RVA: 0x005CA1C8 File Offset: 0x005C83C8
	[return: Nullable(new byte[]
	{
		2,
		0,
		1
	})]
	protected override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteInfoMap()
	{
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Function, out rouletteListDataBase))
		{
			return rouletteListDataBase.GetRouletteDataMap();
		}
		return null;
	}

	// Token: 0x06014EB9 RID: 85689 RVA: 0x005CA1F4 File Offset: 0x005C83F4
	protected override EGridBehavior JudgeGridStateByData(int id, ERouletteGridType gridType)
	{
		bool flag = id != 0;
		EGridBehavior? egridBehavior = RouletteGridForbiddenSettings.CheckGridSpecialState(ERouletteViewType.Main, gridType, id);
		if (!flag)
		{
			return EGridBehavior.Empty;
		}
		if (egridBehavior != null)
		{
			return egridBehavior.Value;
		}
		return EGridBehavior.Normal;
	}

	// Token: 0x06014EBA RID: 85690 RVA: 0x005CA224 File Offset: 0x005C8424
	protected override void RefreshRouletteItem()
	{
		base.SetTipsActive(true);
	}

	// Token: 0x06014EBB RID: 85691 RVA: 0x005CA230 File Offset: 0x005C8430
	[NullableContext(2)]
	protected override string GetRefreshTips(bool isEmpty)
	{
		string text = null;
		if (!isEmpty)
		{
			text = "Text_FuncToolsSwitchPC_Text";
		}
		base.SetTipsActive(text != null);
		return text;
	}
}
