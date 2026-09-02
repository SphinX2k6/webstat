using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Roulette.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002946 RID: 10566
[NullableContext(1)]
[Nullable(0)]
public abstract class RouletteMainViewProxyBase
{
	// Token: 0x06014FB7 RID: 85943 RVA: 0x005CEC38 File Offset: 0x005CCE38
	public void RegisterView(RouletteMainView view)
	{
		this.View = view;
	}

	// Token: 0x06014FB8 RID: 85944 RVA: 0x005CEC44 File Offset: 0x005CCE44
	public UniTask BeforeStartAsync()
	{
		RouletteMainViewProxyBase.<BeforeStartAsync>d__6 <BeforeStartAsync>d__;
		<BeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeforeStartAsync>d__.<>4__this = this;
		<BeforeStartAsync>d__.<>1__state = -1;
		<BeforeStartAsync>d__.<>t__builder.Start<RouletteMainViewProxyBase.<BeforeStartAsync>d__6>(ref <BeforeStartAsync>d__);
		return <BeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014FB9 RID: 85945 RVA: 0x005CEC87 File Offset: 0x005CCE87
	public void Start()
	{
		this.RouletteType = this.GetRouletteType();
		this.CanSwitchType = this.GetCanSwitchType();
		this.OnStart();
	}

	// Token: 0x06014FBA RID: 85946 RVA: 0x005CECA7 File Offset: 0x005CCEA7
	public void BeforeShow()
	{
		this.OnBeforeShow();
	}

	// Token: 0x06014FBB RID: 85947 RVA: 0x005CECAF File Offset: 0x005CCEAF
	public void AddEventListenerByStart()
	{
		this.OnAddEventListenerByStart();
	}

	// Token: 0x06014FBC RID: 85948 RVA: 0x005CECB7 File Offset: 0x005CCEB7
	public void RemoveEventListenerByStart()
	{
		this.OnRemoveEventListenerByStart();
	}

	// Token: 0x06014FBD RID: 85949 RVA: 0x005CECBF File Offset: 0x005CCEBF
	public void AddEventListener()
	{
		this.OnAddEventListener();
	}

	// Token: 0x06014FBE RID: 85950 RVA: 0x005CECC7 File Offset: 0x005CCEC7
	public void RemoveEventListener()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x06014FBF RID: 85951 RVA: 0x005CECCF File Offset: 0x005CCECF
	public bool CanOpenView()
	{
		return this.OnCanOpenView();
	}

	// Token: 0x06014FC0 RID: 85952 RVA: 0x005CECD7 File Offset: 0x005CCED7
	public RouletteComponentMain GetRouletteComponent()
	{
		return this.OnGetRouletteComponent();
	}

	// Token: 0x06014FC1 RID: 85953 RVA: 0x005CECDF File Offset: 0x005CCEDF
	public ERouletteType GetRouletteType()
	{
		return this.OnGetRouletteType();
	}

	// Token: 0x06014FC2 RID: 85954 RVA: 0x005CECE7 File Offset: 0x005CCEE7
	public bool GetCanSwitchType()
	{
		return this.OnGetCanSwitchType();
	}

	// Token: 0x06014FC3 RID: 85955 RVA: 0x005CECEF File Offset: 0x005CCEEF
	public bool GetPanelSwitchOpen()
	{
		return this.OnGetPanelSwitchOpen();
	}

	// Token: 0x06014FC4 RID: 85956 RVA: 0x005CECF7 File Offset: 0x005CCEF7
	public void RouletteTypeSwitch()
	{
		this.OnRouletteTypeSwitch();
	}

	// Token: 0x06014FC5 RID: 85957 RVA: 0x005CED00 File Offset: 0x005CCF00
	public virtual EToggleState? GetToggle1State()
	{
		return null;
	}

	// Token: 0x06014FC6 RID: 85958 RVA: 0x005CED18 File Offset: 0x005CCF18
	public virtual EToggleState? GetToggle2State()
	{
		return null;
	}

	// Token: 0x06014FC7 RID: 85959 RVA: 0x005CED2E File Offset: 0x005CCF2E
	public bool GetCanOpenAssembly(ERouletteType rouletteType)
	{
		return this.OnGetCanOpenAssembly(rouletteType);
	}

	// Token: 0x06014FC8 RID: 85960 RVA: 0x005CED37 File Offset: 0x005CCF37
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetExploreRouletteDataMap()
	{
		return this.OnGetExploreRouletteDataMap();
	}

	// Token: 0x06014FC9 RID: 85961 RVA: 0x005CED3F File Offset: 0x005CCF3F
	public int GetRouletteGridId(int index, ERouletteGridType gridType)
	{
		return this.OnGetRouletteGridId(index, gridType);
	}

	// Token: 0x06014FCA RID: 85962 RVA: 0x005CED49 File Offset: 0x005CCF49
	public string GetActionName()
	{
		return this.OnGetActionName();
	}

	// Token: 0x06014FCB RID: 85963 RVA: 0x005CED51 File Offset: 0x005CCF51
	public void RefreshTips()
	{
		this.OnRefreshTips();
	}

	// Token: 0x06014FCC RID: 85964 RVA: 0x005CED59 File Offset: 0x005CCF59
	public void Destroy()
	{
		this.OnDestroy();
	}

	// Token: 0x06014FCD RID: 85965 RVA: 0x005CED61 File Offset: 0x005CCF61
	protected virtual UniTask OnBeforeStartAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x06014FCE RID: 85966 RVA: 0x005CED68 File Offset: 0x005CCF68
	protected virtual void OnStart()
	{
	}

	// Token: 0x06014FCF RID: 85967 RVA: 0x005CED6A File Offset: 0x005CCF6A
	protected virtual void OnBeforeShow()
	{
	}

	// Token: 0x06014FD0 RID: 85968 RVA: 0x005CED6C File Offset: 0x005CCF6C
	protected virtual void OnAddEventListenerByStart()
	{
	}

	// Token: 0x06014FD1 RID: 85969 RVA: 0x005CED6E File Offset: 0x005CCF6E
	protected virtual void OnRemoveEventListenerByStart()
	{
	}

	// Token: 0x06014FD2 RID: 85970 RVA: 0x005CED70 File Offset: 0x005CCF70
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x06014FD3 RID: 85971 RVA: 0x005CED72 File Offset: 0x005CCF72
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x06014FD4 RID: 85972
	protected abstract bool OnCanOpenView();

	// Token: 0x06014FD5 RID: 85973
	protected abstract RouletteComponentMain OnGetRouletteComponent();

	// Token: 0x06014FD6 RID: 85974
	protected abstract ERouletteType OnGetRouletteType();

	// Token: 0x06014FD7 RID: 85975
	protected abstract bool OnGetCanSwitchType();

	// Token: 0x06014FD8 RID: 85976
	protected abstract bool OnGetPanelSwitchOpen();

	// Token: 0x06014FD9 RID: 85977 RVA: 0x005CED74 File Offset: 0x005CCF74
	protected virtual void OnRouletteTypeSwitch()
	{
	}

	// Token: 0x06014FDA RID: 85978
	protected abstract bool OnGetCanOpenAssembly(ERouletteType rouletteType);

	// Token: 0x06014FDB RID: 85979
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	protected abstract List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> OnGetExploreRouletteDataMap();

	// Token: 0x06014FDC RID: 85980
	protected abstract int OnGetRouletteGridId(int index, ERouletteGridType gridType);

	// Token: 0x06014FDD RID: 85981
	protected abstract string OnGetActionName();

	// Token: 0x06014FDE RID: 85982 RVA: 0x005CED76 File Offset: 0x005CCF76
	protected virtual void OnRefreshTips()
	{
	}

	// Token: 0x06014FDF RID: 85983
	protected abstract void OnDestroy();

	// Token: 0x0400A1A6 RID: 41382
	public ERouletteType RouletteType;

	// Token: 0x0400A1A7 RID: 41383
	public bool CanSwitchType;

	// Token: 0x0400A1A8 RID: 41384
	public ERouletteActionType ActionType = ERouletteActionType.Action1;

	// Token: 0x0400A1A9 RID: 41385
	public int? TouchId;

	// Token: 0x0400A1AA RID: 41386
	public RouletteMainView View;
}
