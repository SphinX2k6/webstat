using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Roulette.View;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002947 RID: 10567
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseRouletteMainViewProxy : RouletteMainViewProxyBase
{
	// Token: 0x06014FE1 RID: 85985 RVA: 0x005CED88 File Offset: 0x005CCF88
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseRouletteMainViewProxy.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseRouletteMainViewProxy.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014FE2 RID: 85986 RVA: 0x005CEDCC File Offset: 0x005CCFCC
	protected override void OnBeforeShow()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			string actionName = base.GetActionName();
			if (!ModelBase<InputDistributeModel>.Instance.IsActionInPress(actionName))
			{
				this.View.CloseSelf(true);
			}
		}
	}

	// Token: 0x06014FE3 RID: 85987 RVA: 0x005CEE05 File Offset: 0x005CD005
	protected override bool OnCanOpenView()
	{
		return ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(true) && ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelDataHasShop();
	}

	// Token: 0x06014FE4 RID: 85988 RVA: 0x005CEE20 File Offset: 0x005CD020
	protected override RouletteComponentMain OnGetRouletteComponent()
	{
		if (this.RouletteComponentExplore == null)
		{
			this.RouletteComponentExplore = new RouletteComponentMainExplore();
			this.RouletteComponentExplore.RegisterViewProxy(this);
			this.RouletteComponentExplore.SetRootActor(this.View.RouletteUiItem.GetOwner(), true);
		}
		return this.RouletteComponentExplore;
	}

	// Token: 0x06014FE5 RID: 85989 RVA: 0x005CEE6E File Offset: 0x005CD06E
	protected override ERouletteType OnGetRouletteType()
	{
		return ERouletteType.Explore;
	}

	// Token: 0x06014FE6 RID: 85990 RVA: 0x005CEE71 File Offset: 0x005CD071
	protected override bool OnGetCanSwitchType()
	{
		return false;
	}

	// Token: 0x06014FE7 RID: 85991 RVA: 0x005CEE74 File Offset: 0x005CD074
	protected override bool OnGetPanelSwitchOpen()
	{
		return false;
	}

	// Token: 0x06014FE8 RID: 85992 RVA: 0x005CEE77 File Offset: 0x005CD077
	protected override bool OnGetCanOpenAssembly(ERouletteType rouletteType)
	{
		return false;
	}

	// Token: 0x06014FE9 RID: 85993 RVA: 0x005CEE7A File Offset: 0x005CD07A
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	protected override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> OnGetExploreRouletteDataMap()
	{
		return this.TrapDefenseExploreRouletteMap;
	}

	// Token: 0x06014FEA RID: 85994 RVA: 0x005CEE84 File Offset: 0x005CD084
	protected override int OnGetRouletteGridId(int index, ERouletteGridType gridType)
	{
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(this.RouletteType, out rouletteListDataBase))
		{
			return rouletteListDataBase.GetRouletteGridId(index, gridType, true).GetValueOrDefault();
		}
		return 0;
	}

	// Token: 0x06014FEB RID: 85995 RVA: 0x005CEEBD File Offset: 0x005CD0BD
	protected override string OnGetActionName()
	{
		return "塔防轮盘";
	}

	// Token: 0x06014FEC RID: 85996 RVA: 0x005CEEC4 File Offset: 0x005CD0C4
	protected override void OnRefreshTips()
	{
		RouletteComponentMainExplore rouletteComponentExplore = this.RouletteComponentExplore;
		RouletteGridBase rouletteGridBase = (rouletteComponentExplore != null) ? rouletteComponentExplore.GetCurrentGrid() : null;
		if (rouletteGridBase != null && rouletteGridBase.Data != null && rouletteGridBase.Data.Id > 0)
		{
			int id = rouletteGridBase.Data.Id;
			TrapDefenseItem? trapDefenseItemByExploreToolId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseItemByExploreToolId(id);
			this.ItemTips.RefreshTips((trapDefenseItemByExploreToolId != null) ? trapDefenseItemByExploreToolId.GetValueOrDefault().Desc : null);
			return;
		}
		this.ItemTips.RefreshTips(null);
	}

	// Token: 0x06014FED RID: 85997 RVA: 0x005CEF48 File Offset: 0x005CD148
	protected override void OnDestroy()
	{
		if (this.RouletteComponentExplore != null)
		{
			this.RouletteComponentExplore.Destroy(null);
			this.RouletteComponentExplore = null;
		}
	}

	// Token: 0x0400A1AB RID: 41387
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	private readonly List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> TrapDefenseExploreRouletteMap = new List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>>
	{
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			1
		}, ERouletteComponentNode.RouletteItem1, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			2
		}, ERouletteComponentNode.RouletteItem2, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			3
		}, ERouletteComponentNode.RouletteItem3, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			4
		}, ERouletteComponentNode.RouletteItem4, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			5
		}, ERouletteComponentNode.RouletteItem5, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			6
		}, ERouletteComponentNode.RouletteItem6, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			7
		}, ERouletteComponentNode.RouletteItem7, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			8
		}, ERouletteComponentNode.RouletteItem8, ERouletteGridType.Explore)
	};

	// Token: 0x0400A1AC RID: 41388
	[Nullable(2)]
	private RouletteComponentMainExplore RouletteComponentExplore;

	// Token: 0x0400A1AD RID: 41389
	protected TrapDefenseRouletteItemTips ItemTips;
}
