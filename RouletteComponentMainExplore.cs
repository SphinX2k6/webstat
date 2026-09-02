using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

// Token: 0x02002929 RID: 10537
public class RouletteComponentMainExplore : RouletteComponentMain
{
	// Token: 0x06014EB3 RID: 85683 RVA: 0x005CA089 File Offset: 0x005C8289
	[return: Nullable(new byte[]
	{
		2,
		0,
		1
	})]
	protected override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteInfoMap()
	{
		return this.ViewProxy.GetExploreRouletteDataMap();
	}

	// Token: 0x06014EB4 RID: 85684 RVA: 0x005CA098 File Offset: 0x005C8298
	protected override EGridBehavior JudgeGridStateByData(int id, ERouletteGridType gridType)
	{
		bool flag = id != 0;
		bool flag2 = gridType == ERouletteGridType.EquipItem;
		EGridBehavior? egridBehavior = RouletteGridForbiddenSettings.CheckGridSpecialState(ERouletteViewType.Main, gridType, id);
		if (!flag && !flag2)
		{
			return EGridBehavior.Empty;
		}
		if (egridBehavior != null)
		{
			return egridBehavior.Value;
		}
		return EGridBehavior.Normal;
	}

	// Token: 0x06014EB5 RID: 85685 RVA: 0x005CA0D0 File Offset: 0x005C82D0
	protected override void RefreshRouletteItem()
	{
		base.SetTipsActive(false);
	}

	// Token: 0x06014EB6 RID: 85686 RVA: 0x005CA0DC File Offset: 0x005C82DC
	[NullableContext(2)]
	protected override string GetRefreshTips(bool isEmpty)
	{
		string text = null;
		if (Singleton<Info>.Instance.IsInTouch())
		{
			text = (isEmpty ? "Text_ProbeToolFunctionNotice3_Text" : "Text_ExploreToolsSwitchMobile_Text");
		}
		else if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			if (isEmpty)
			{
				text = null;
			}
			else
			{
				RouletteGridBase currentGrid = base.GetCurrentGrid();
				text = ((currentGrid != null && currentGrid.Data.UseType == EGridUseType.SwitchOnly) ? "Text_ExploreToolsSwitchPC_Text" : "Text_ExploreToolsSwitchPC_Text02");
			}
		}
		else if (Singleton<Info>.Instance.IsInGamepad())
		{
			RouletteGridBase currentGrid2 = base.GetCurrentGrid();
			bool flag = currentGrid2 == null || currentGrid2.Data.State != EGridBehavior.Normal;
			if (this.CurrentGridIndex != -1 && !flag)
			{
				RouletteGridBase currentGrid3 = base.GetCurrentGrid();
				text = ((currentGrid3 != null && currentGrid3.Data.UseType == EGridUseType.SwitchOnly) ? "Text_ExploreToolsSwitchPC_Text" : "Text_ExploreToolsSwitchPC_Text02");
			}
		}
		base.SetTipsActive(text != null);
		return text;
	}
}
