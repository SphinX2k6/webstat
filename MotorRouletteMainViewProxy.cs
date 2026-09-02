using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02002941 RID: 10561
[NullableContext(1)]
[Nullable(0)]
public class MotorRouletteMainViewProxy : RouletteMainViewProxyBase
{
	// Token: 0x06014F85 RID: 85893 RVA: 0x005CE0A0 File Offset: 0x005CC2A0
	protected override RouletteComponentMain OnGetRouletteComponent()
	{
		if (this.RouletteType == ERouletteType.Motor)
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

	// Token: 0x06014F86 RID: 85894 RVA: 0x005CE13C File Offset: 0x005CC33C
	protected override bool OnCanOpenView()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			foreach (ERouletteType key in this.RouletteTypeList)
			{
				RouletteListDataBase rouletteListDataBase;
				if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(key, out rouletteListDataBase) && rouletteListDataBase.IsMainRouletteCanOpenView(true))
				{
					return true;
				}
			}
			return false;
		}
		ERouletteType erouletteType = ModelBase<RouletteModel>.Instance.GetRouletteActionOpenConfig(this.ActionType);
		if (erouletteType == ERouletteType.Explore)
		{
			erouletteType = ERouletteType.Motor;
		}
		RouletteListDataBase rouletteListDataBase2;
		return ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(erouletteType, out rouletteListDataBase2) && rouletteListDataBase2.IsMainRouletteCanOpenView(true);
	}

	// Token: 0x06014F87 RID: 85895 RVA: 0x005CE1F0 File Offset: 0x005CC3F0
	protected override ERouletteType OnGetRouletteType()
	{
		ERouletteType erouletteType = ModelBase<RouletteModel>.Instance.GetRouletteActionOpenConfig(this.ActionType);
		if (erouletteType == ERouletteType.Explore)
		{
			erouletteType = ERouletteType.Motor;
		}
		bool flag = false;
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Motor, out rouletteListDataBase))
		{
			flag = rouletteListDataBase.IsMainRouletteCanOpenView(false);
		}
		bool flag2 = ModelBase<RouletteModel>.Instance.IsFunctionRouletteOpen();
		if (erouletteType == ERouletteType.Function && !flag2)
		{
			return ERouletteType.Motor;
		}
		if (erouletteType == ERouletteType.Motor && !flag)
		{
			return ERouletteType.Function;
		}
		return erouletteType;
	}

	// Token: 0x06014F88 RID: 85896 RVA: 0x005CE250 File Offset: 0x005CC450
	protected override bool OnGetCanSwitchType()
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return false;
		}
		foreach (ERouletteType key in this.RouletteTypeList)
		{
			RouletteListDataBase rouletteListDataBase;
			if (!ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(key, out rouletteListDataBase))
			{
				return false;
			}
			if (!rouletteListDataBase.IsMainRouletteCanOpenView(false))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06014F89 RID: 85897 RVA: 0x005CE2D4 File Offset: 0x005CC4D4
	protected override bool OnGetPanelSwitchOpen()
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return false;
		}
		foreach (ERouletteType key in this.RouletteTypeList)
		{
			RouletteListDataBase rouletteListDataBase;
			if (!ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(key, out rouletteListDataBase))
			{
				return false;
			}
			if (!rouletteListDataBase.IsRouletteOpen())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06014F8A RID: 85898 RVA: 0x005CE358 File Offset: 0x005CC558
	protected override void OnRouletteTypeSwitch()
	{
		bool flag = this.RouletteType == ERouletteType.Motor;
		this.RouletteType = (flag ? ERouletteType.Function : ERouletteType.Motor);
		ERouletteType type = flag ? ERouletteType.Function : ERouletteType.Explore;
		ModelBase<RouletteModel>.Instance.SaveRouletteActionOpenConfig(this.ActionType, type);
	}

	// Token: 0x06014F8B RID: 85899 RVA: 0x005CE398 File Offset: 0x005CC598
	public override EToggleState? GetToggle1State()
	{
		bool flag = this.RouletteType == ERouletteType.Motor;
		bool flag2 = false;
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Motor, out rouletteListDataBase))
		{
			flag2 = rouletteListDataBase.IsMainRouletteCanOpenView(false);
		}
		if (flag2)
		{
			return new EToggleState?(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
		}
		return new EToggleState?(EToggleState.ETT_UnDetermined);
	}

	// Token: 0x06014F8C RID: 85900 RVA: 0x005CE3E3 File Offset: 0x005CC5E3
	public override EToggleState? GetToggle2State()
	{
		return new EToggleState?((this.RouletteType == ERouletteType.Function) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
	}

	// Token: 0x06014F8D RID: 85901 RVA: 0x005CE3FC File Offset: 0x005CC5FC
	protected override bool OnGetCanOpenAssembly(ERouletteType rouletteType)
	{
		RouletteListDataBase rouletteListDataBase;
		return rouletteType != ERouletteType.Function || !ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Function, out rouletteListDataBase) || !rouletteListDataBase.IsRouletteReplace();
	}

	// Token: 0x06014F8E RID: 85902 RVA: 0x005CE42C File Offset: 0x005CC62C
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	protected override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> OnGetExploreRouletteDataMap()
	{
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Motor, out rouletteListDataBase))
		{
			return rouletteListDataBase.GetRouletteDataMap();
		}
		return new List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>>();
	}

	// Token: 0x06014F8F RID: 85903 RVA: 0x005CE45C File Offset: 0x005CC65C
	protected override int OnGetRouletteGridId(int index, ERouletteGridType gridType)
	{
		RouletteListDataBase rouletteListDataBase;
		if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(this.RouletteType, out rouletteListDataBase))
		{
			return rouletteListDataBase.GetRouletteGridId(index, gridType, true).GetValueOrDefault();
		}
		return 0;
	}

	// Token: 0x06014F90 RID: 85904 RVA: 0x005CE498 File Offset: 0x005CC698
	protected override string OnGetActionName()
	{
		string actionName = ModelBase<RouletteModel>.Instance.GetRouletteActionName[this.ActionType];
		return ModelBase<RouletteModel>.Instance.GetRouletteMainAction(actionName);
	}

	// Token: 0x06014F91 RID: 85905 RVA: 0x005CE4C8 File Offset: 0x005CC6C8
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

	// Token: 0x0400A197 RID: 41367
	[Nullable(2)]
	private RouletteComponentMainExplore RouletteComponentExplore;

	// Token: 0x0400A198 RID: 41368
	[Nullable(2)]
	private RouletteComponentMainFunction RouletteComponentFunction;

	// Token: 0x0400A199 RID: 41369
	private readonly List<ERouletteType> RouletteTypeList = new List<ERouletteType>
	{
		ERouletteType.Motor,
		ERouletteType.Function
	};
}
