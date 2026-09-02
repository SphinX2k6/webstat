using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002249 RID: 8777
[NullableContext(1)]
[Nullable(0)]
public class TeleportAssistant : ControllerAssistantBase
{
	// Token: 0x0601090E RID: 67854 RVA: 0x004876F2 File Offset: 0x004858F2
	protected override void OnDestroy()
	{
		this.CurrentSequenceConfig = null;
		this.CurFlowListName = "";
		this.CurFlowId = 0;
		this.IsGmUnlockAll = false;
		this.IsInPlot = false;
	}

	// Token: 0x0601090F RID: 67855 RVA: 0x00487720 File Offset: 0x00485920
	public override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TeleportUpdateNotify>(ENotifyMessageId.TeleportUpdateNotify, new Action<TeleportUpdateNotify, Net.CallbackStatus>(this.OnTeleportUpdateNotify));
	}

	// Token: 0x06010910 RID: 67856 RVA: 0x0048773E File Offset: 0x0048593E
	public override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeleportUpdateNotify);
	}

	// Token: 0x06010911 RID: 67857 RVA: 0x00487750 File Offset: 0x00485950
	public override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
		Singleton<EventSystem>.Instance.Add(EEventName.OnExecuteServerGm, new Action<string>(this.OnExecuteServerGm));
	}

	// Token: 0x06010912 RID: 67858 RVA: 0x0048778A File Offset: 0x0048598A
	public override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnExecuteServerGm, new Action<string>(this.OnExecuteServerGm));
	}

	// Token: 0x06010913 RID: 67859 RVA: 0x004877C4 File Offset: 0x004859C4
	[NullableContext(2)]
	private void OnTeleportUpdateNotify(TeleportUpdateNotify notify, Net.CallbackStatus status)
	{
		int[] array = notify.Ids.ToArray<int>();
		ModelBase<MapModel>.Instance.UnlockTeleports(array, false);
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int worldOwner = ModelBase<CreatureModel>.Instance.GetWorldOwner();
			if (!(id.GetValueOrDefault() == worldOwner & id != null))
			{
				return;
			}
		}
		this.PlaySequenceOnUnlockNewTeleport(array);
	}

	// Token: 0x06010914 RID: 67860 RVA: 0x00487828 File Offset: 0x00485A28
	private void PlaySequenceOnUnlockNewTeleport(int[] teleportIds)
	{
		if (this.IsGmUnlockAll)
		{
			return;
		}
		if (this.IsInPlot)
		{
			return;
		}
		if (teleportIds.Length == 0)
		{
			return;
		}
		Teleporter? teleportConfigById = ConfigBase<MapConfig>.Instance.GetTeleportConfigById(teleportIds[0]);
		if (teleportConfigById == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(teleportConfigById.Value.Plot))
		{
			string[] array = teleportConfigById.Value.Plot.Split(',', StringSplitOptions.None);
			if (array.Length > 2)
			{
				this.CurFlowListName = array[0];
				this.CurFlowId = int.Parse(array[1]);
				int stateId = int.Parse(array[2]);
				this.CurrentSequenceConfig = teleportConfigById;
				this.IsInPlot = true;
				ControllerBase<FlowController>.Instance.StartFlow(this.CurFlowListName, this.CurFlowId, stateId, null, 0L, false, false, false, null);
			}
		}
	}

	// Token: 0x06010915 RID: 67861 RVA: 0x004878E5 File Offset: 0x00485AE5
	private void OnWorldMapViewOpened()
	{
		ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "BlackScreenFadeOnPlotToWorldMap", delegate
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.BlackScreenFadeOnPlotToWorldMap);
		}, new float?((float)1));
	}

	// Token: 0x06010916 RID: 67862 RVA: 0x00487920 File Offset: 0x00485B20
	private void OnPlotNetworkEnd(PlotResultInfo plotResult)
	{
		if (!(plotResult.FlowListName != this.CurFlowListName))
		{
			int? flowId = plotResult.FlowId;
			int curFlowId = this.CurFlowId;
			if (flowId.GetValueOrDefault() == curFlowId & flowId != null)
			{
				this.IsInPlot = false;
				ETeleportType type = (ETeleportType)this.CurrentSequenceConfig.Value.Type;
				if (type != ETeleportType.BigTeleport)
				{
					if (type != ETeleportType.SmallTeleport)
					{
					}
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("TeleporterUnlock", Array.Empty<object>());
				}
				else
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("TeleporterUnlockBig", Array.Empty<object>());
				}
				WorldMapViewOpenParams data = new WorldMapViewOpenParams
				{
					MarkType = EMarkType.None,
					MarkId = new int?(0),
					OpenFogId = new int?(this.CurrentSequenceConfig.Value.FogId)
				};
				if (this.CurrentSequenceConfig.Value.ShowWorldMap)
				{
					Singleton<EventSystem>.Instance.Once(EEventName.WorldMapViewOpened, new Action(this.OnWorldMapViewOpened));
					ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
				}
				else
				{
					ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "TeleportAssistant_PlotEnd", delegate
					{
					}, new float?((float)1));
				}
				this.CurFlowListName = "";
				this.CurFlowId = 0;
				this.CurrentSequenceConfig = null;
				return;
			}
		}
	}

	// Token: 0x06010917 RID: 67863 RVA: 0x00487A81 File Offset: 0x00485C81
	private void OnExecuteServerGm(string gm)
	{
		if (gm.ToLower() != "activateteleport 0")
		{
			return;
		}
		this.IsGmUnlockAll = true;
	}

	// Token: 0x06010918 RID: 67864 RVA: 0x00487AA0 File Offset: 0x00485CA0
	public UniTask RequestTeleportData()
	{
		TeleportAssistant.<RequestTeleportData>d__16 <RequestTeleportData>d__;
		<RequestTeleportData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestTeleportData>d__.<>1__state = -1;
		<RequestTeleportData>d__.<>t__builder.Start<TeleportAssistant.<RequestTeleportData>d__16>(ref <RequestTeleportData>d__);
		return <RequestTeleportData>d__.<>t__builder.Task;
	}

	// Token: 0x0400825D RID: 33373
	private const string GM_UNLOCK_ALL_TELEPORT = "activateteleport 0";

	// Token: 0x0400825E RID: 33374
	private Teleporter? CurrentSequenceConfig;

	// Token: 0x0400825F RID: 33375
	private string CurFlowListName = "";

	// Token: 0x04008260 RID: 33376
	private int CurFlowId;

	// Token: 0x04008261 RID: 33377
	private bool IsGmUnlockAll;

	// Token: 0x04008262 RID: 33378
	private bool IsInPlot;
}
