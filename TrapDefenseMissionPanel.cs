using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001DA0 RID: 7584
public class TrapDefenseMissionPanel : BattleChildViewPanel
{
	// Token: 0x0600DFB0 RID: 57264 RVA: 0x003C333B File Offset: 0x003C153B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600DFB1 RID: 57265 RVA: 0x003C3360 File Offset: 0x003C1560
	public override UniTask InitializeAsync()
	{
		TrapDefenseMissionPanel.<InitializeAsync>d__3 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<TrapDefenseMissionPanel.<InitializeAsync>d__3>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFB2 RID: 57266 RVA: 0x003C33A3 File Offset: 0x003C15A3
	protected override void OnShowBattleChildViewPanel(bool isFirst)
	{
		this.MissionPanel.ShowBattleChildViewPanel();
	}

	// Token: 0x0600DFB3 RID: 57267 RVA: 0x003C33B0 File Offset: 0x003C15B0
	protected override void OnHideBattleChildViewPanel()
	{
		this.MissionPanel.HideBattleChildViewPanel();
	}

	// Token: 0x0600DFB4 RID: 57268 RVA: 0x003C33BD File Offset: 0x003C15BD
	public override void OnTickBattleChildViewPanel(float delta)
	{
		this.MissionPanel.OnTickBattleChildViewPanel(delta);
	}

	// Token: 0x0600DFB5 RID: 57269 RVA: 0x003C33CB File Offset: 0x003C15CB
	public override void Reset()
	{
		this.MissionPanel.Reset();
	}

	// Token: 0x04006B7C RID: 27516
	[Nullable(1)]
	protected MissionPanel MissionPanel;

	// Token: 0x02008141 RID: 33089
	private static class EComponentDefine
	{
		// Token: 0x0402BEDD RID: 179933
		public const int MissionItem = 0;
	}
}
