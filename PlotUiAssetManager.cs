using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020032BF RID: 12991
[NullableContext(1)]
[Nullable(0)]
public class PlotUiAssetManager
{
	// Token: 0x0601B39E RID: 111518 RVA: 0x0082E047 File Offset: 0x0082C247
	public void Init()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RestartHangingPreloadTask, new Action(this.RestartHangingPreloadTask));
	}

	// Token: 0x0601B39F RID: 111519 RVA: 0x0082E068 File Offset: 0x0082C268
	[return: Nullable(2)]
	public PlotUiAsset GetPlotUiAsset(string plotId)
	{
		PlotUiAsset result;
		if (this.PlotIdUiAssetMap.TryGetValue(plotId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0601B3A0 RID: 111520 RVA: 0x0082E088 File Offset: 0x0082C288
	public void Clear()
	{
		this.PlotIdUiAssetMap.Clear();
		this.HangingPlotIdSet.Clear();
		Singleton<EventSystem>.Instance.Remove(EEventName.RestartHangingPreloadTask, new Action(this.RestartHangingPreloadTask));
	}

	// Token: 0x0601B3A1 RID: 111521 RVA: 0x0082E0BC File Offset: 0x0082C2BC
	public UniTask PreloadPlotUiAssetAsync(string flowListName, int flowId, int stateId)
	{
		PlotUiAssetManager.<PreloadPlotUiAssetAsync>d__5 <PreloadPlotUiAssetAsync>d__;
		<PreloadPlotUiAssetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadPlotUiAssetAsync>d__.<>4__this = this;
		<PreloadPlotUiAssetAsync>d__.flowListName = flowListName;
		<PreloadPlotUiAssetAsync>d__.flowId = flowId;
		<PreloadPlotUiAssetAsync>d__.stateId = stateId;
		<PreloadPlotUiAssetAsync>d__.<>1__state = -1;
		<PreloadPlotUiAssetAsync>d__.<>t__builder.Start<PlotUiAssetManager.<PreloadPlotUiAssetAsync>d__5>(ref <PreloadPlotUiAssetAsync>d__);
		return <PreloadPlotUiAssetAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601B3A2 RID: 111522 RVA: 0x0082E118 File Offset: 0x0082C318
	public void RemovePlotUiAsset(string plotId)
	{
		foreach (KeyValuePair<string, PlotUiAsset> keyValuePair in this.PlotIdUiAssetMap)
		{
			string text;
			PlotUiAsset plotUiAsset;
			keyValuePair.Deconstruct(out text, out plotUiAsset);
			string a = text;
			PlotUiAsset plotUiAsset2 = plotUiAsset;
			if (a == plotId)
			{
				if (plotUiAsset2.IsLoading())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Preload;
					ELogAuthor author = ELogAuthor.HYF;
					string message = "[预加载][Plot] PlotUiAsset被移除时尚未加载完毕";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlotId", plotId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				plotUiAsset2.Clear();
				break;
			}
		}
		this.PlotIdUiAssetMap.Remove(plotId);
		ControllerBase<CommonQteController>.Instance.ClearPreloadQteRes();
	}

	// Token: 0x0601B3A3 RID: 111523 RVA: 0x0082E1CC File Offset: 0x0082C3CC
	public UniTask WaitForPlotUiAsset(string plotId)
	{
		PlotUiAssetManager.<WaitForPlotUiAsset>d__7 <WaitForPlotUiAsset>d__;
		<WaitForPlotUiAsset>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitForPlotUiAsset>d__.<>4__this = this;
		<WaitForPlotUiAsset>d__.plotId = plotId;
		<WaitForPlotUiAsset>d__.<>1__state = -1;
		<WaitForPlotUiAsset>d__.<>t__builder.Start<PlotUiAssetManager.<WaitForPlotUiAsset>d__7>(ref <WaitForPlotUiAsset>d__);
		return <WaitForPlotUiAsset>d__.<>t__builder.Task;
	}

	// Token: 0x0601B3A4 RID: 111524 RVA: 0x0082E218 File Offset: 0x0082C418
	public bool IsLoading(string plotId)
	{
		PlotUiAsset plotUiAsset;
		return this.PlotIdUiAssetMap.TryGetValue(plotId, out plotUiAsset) && plotUiAsset.IsLoading();
	}

	// Token: 0x0601B3A5 RID: 111525 RVA: 0x0082E23D File Offset: 0x0082C43D
	public bool IsHanging(string plotId)
	{
		return this.HangingPlotIdSet.Contains(plotId);
	}

	// Token: 0x0601B3A6 RID: 111526 RVA: 0x0082E24C File Offset: 0x0082C44C
	public bool HasPreloadQte(List<int> qteIds)
	{
		using (Dictionary<string, PlotUiAsset>.ValueCollection.Enumerator enumerator = this.PlotIdUiAssetMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasPreloadQte(qteIds))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0601B3A7 RID: 111527 RVA: 0x0082E2AC File Offset: 0x0082C4AC
	public void CancelHangingTask(string plotId)
	{
		if (this.IsHanging(plotId))
		{
			this.HangingPlotIdSet.Remove(plotId);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[预加载][Plot] 挂起的剧情预加载任务取消";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlotId", plotId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601B3A8 RID: 111528 RVA: 0x0082E2F8 File Offset: 0x0082C4F8
	private void RestartHangingPreloadTask()
	{
		List<UniTask> list = new List<UniTask>();
		foreach (string text in this.HangingPlotIdSet)
		{
			string[] array = text.Split(',', StringSplitOptions.None);
			list.Add(this.PreloadPlotUiAssetAsync(array[0], int.Parse(array[1]), int.Parse(array[2])));
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[预加载][Plot] 场景加载完成，重启挂起的剧情预加载任务";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlotId", text);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.HangingPlotIdSet.Clear();
		UniTask.WhenAll(list).Forget();
	}

	// Token: 0x0400DDF2 RID: 56818
	private readonly Dictionary<string, PlotUiAsset> PlotIdUiAssetMap = new Dictionary<string, PlotUiAsset>();

	// Token: 0x0400DDF3 RID: 56819
	private readonly HashSet<string> HangingPlotIdSet = new HashSet<string>();
}
