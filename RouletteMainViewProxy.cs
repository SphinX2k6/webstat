using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02002945 RID: 10565
[NullableContext(1)]
[Nullable(0)]
public class RouletteMainViewProxy : RouletteMainViewProxyBase
{
	// Token: 0x06014FA9 RID: 85929 RVA: 0x005CE8C8 File Offset: 0x005CCAC8
	protected override RouletteComponentMain OnGetRouletteComponent()
	{
		if (this.RouletteType == ERouletteType.Explore)
		{
			if (this.RouletteComponentExplore == null)
			{
				this.RouletteComponentExplore = new RouletteComponentMainExplore();
				this.RouletteComponentExplore.RegisterViewProxy(this);
				this.RouletteComponentExplore.SetRootActor(this.View.RouletteUiItem.GetOwner(), true);
			}
			return this.RouletteComponentExplore;
		}
		if (this.RouletteComponentFunction == null)
		{
			this.RouletteComponentFunction = new RouletteComponentMainFunction();
			this.RouletteComponentFunction.RegisterViewProxy(this);
			this.RouletteComponentFunction.SetRootActor(this.View.RouletteUiItem.GetOwner(), true);
		}
		return this.RouletteComponentFunction;
	}

	// Token: 0x06014FAA RID: 85930 RVA: 0x005CE960 File Offset: 0x005CCB60
	protected override bool OnCanOpenView()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(true) || ModelBase<RouletteModel>.Instance.IsFunctionRouletteOpen();
		}
		ERouletteType rouletteActionOpenConfig = ModelBase<RouletteModel>.Instance.GetRouletteActionOpenConfig(this.ActionType);
		if (rouletteActionOpenConfig == ERouletteType.Explore)
		{
			return ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(true);
		}
		return rouletteActionOpenConfig != ERouletteType.Function || ModelBase<RouletteModel>.Instance.IsFunctionRouletteOpen();
	}

	// Token: 0x06014FAB RID: 85931 RVA: 0x005CE9C4 File Offset: 0x005CCBC4
	protected override ERouletteType OnGetRouletteType()
	{
		ERouletteType rouletteActionOpenConfig = ModelBase<RouletteModel>.Instance.GetRouletteActionOpenConfig(this.ActionType);
		bool flag = ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false);
		bool flag2 = ModelBase<RouletteModel>.Instance.IsFunctionRouletteOpen();
		if (rouletteActionOpenConfig == ERouletteType.Function && !flag2)
		{
			return ERouletteType.Explore;
		}
		if (rouletteActionOpenConfig == ERouletteType.Explore && !flag)
		{
			return ERouletteType.Function;
		}
		return rouletteActionOpenConfig;
	}

	// Token: 0x06014FAC RID: 85932 RVA: 0x005CEA0C File Offset: 0x005CCC0C
	protected override bool OnGetCanSwitchType()
	{
		bool flag = ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false);
		bool flag2 = ModelBase<RouletteModel>.Instance.IsFunctionRouletteOpen();
		return Singleton<Info>.Instance.IsInGamepad() && flag && flag2;
	}

	// Token: 0x06014FAD RID: 85933 RVA: 0x005CEA40 File Offset: 0x005CCC40
	protected override bool OnGetPanelSwitchOpen()
	{
		bool flag = ModelBase<RouletteModel>.Instance.IsFunctionRouletteOpen();
		bool flag2 = ModelBase<FunctionModel>.Instance.IsOpen(10026);
		return Singleton<Info>.Instance.IsInGamepad() && flag2 && flag;
	}

	// Token: 0x06014FAE RID: 85934 RVA: 0x005CEA78 File Offset: 0x005CCC78
	protected override void OnRouletteTypeSwitch()
	{
		this.RouletteType = ((this.RouletteType == ERouletteType.Explore) ? ERouletteType.Function : ERouletteType.Explore);
		ModelBase<RouletteModel>.Instance.SaveRouletteActionOpenConfig(this.ActionType, this.RouletteType);
	}

	// Token: 0x06014FAF RID: 85935 RVA: 0x005CEAB4 File Offset: 0x005CCCB4
	public override EToggleState? GetToggle1State()
	{
		bool flag = this.RouletteType == ERouletteType.Explore;
		if (ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false))
		{
			return new EToggleState?(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
		}
		return new EToggleState?(EToggleState.ETT_UnDetermined);
	}

	// Token: 0x06014FB0 RID: 85936 RVA: 0x005CEAEB File Offset: 0x005CCCEB
	public override EToggleState? GetToggle2State()
	{
		return new EToggleState?((this.RouletteType == ERouletteType.Function) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
	}

	// Token: 0x06014FB1 RID: 85937 RVA: 0x005CEB04 File Offset: 0x005CCD04
	protected override bool OnGetCanOpenAssembly(ERouletteType rouletteType)
	{
		bool result = true;
		RouletteListDataBase rouletteListDataBase;
		RouletteListDataBase rouletteListDataBase2;
		if (rouletteType == ERouletteType.Explore && ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Explore, out rouletteListDataBase) && rouletteListDataBase.IsRouletteReplace())
		{
			result = false;
		}
		else if (rouletteType == ERouletteType.Function && ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Function, out rouletteListDataBase2) && rouletteListDataBase2.IsRouletteReplace())
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06014FB2 RID: 85938 RVA: 0x005CEB5C File Offset: 0x005CCD5C
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	protected override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> OnGetExploreRouletteDataMap()
	{
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Explore, out rouletteListDataBase))
		{
			return rouletteListDataBase.GetRouletteDataMap();
		}
		return new List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>>();
	}

	// Token: 0x06014FB3 RID: 85939 RVA: 0x005CEB8C File Offset: 0x005CCD8C
	protected override int OnGetRouletteGridId(int index, ERouletteGridType gridType)
	{
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(this.RouletteType, out rouletteListDataBase))
		{
			return rouletteListDataBase.GetRouletteGridId(index, gridType, true).GetValueOrDefault();
		}
		return 0;
	}

	// Token: 0x06014FB4 RID: 85940 RVA: 0x005CEBC8 File Offset: 0x005CCDC8
	protected override string OnGetActionName()
	{
		string actionName = ModelBase<RouletteModel>.Instance.GetRouletteActionName[this.ActionType];
		return ModelBase<RouletteModel>.Instance.GetRouletteMainAction(actionName);
	}

	// Token: 0x06014FB5 RID: 85941 RVA: 0x005CEBF8 File Offset: 0x005CCDF8
	protected override void OnDestroy()
	{
		if (this.RouletteComponentExplore != null)
		{
			this.RouletteComponentExplore.Destroy(null);
			this.RouletteComponentExplore = null;
		}
		if (this.RouletteComponentFunction != null)
		{
			this.RouletteComponentFunction.Destroy(null);
			this.RouletteComponentFunction = null;
		}
	}

	// Token: 0x0400A1A4 RID: 41380
	[Nullable(2)]
	private RouletteComponentMainExplore RouletteComponentExplore;

	// Token: 0x0400A1A5 RID: 41381
	[Nullable(2)]
	private RouletteComponentMainFunction RouletteComponentFunction;
}
