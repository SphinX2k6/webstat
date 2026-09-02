using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C13 RID: 27667
	public class LevelEventSwitchDataLayers : LevelEventBase
	{
		// Token: 0x06044182 RID: 278914 RVA: 0x011AE55B File Offset: 0x011AC75B
		public LevelEventSwitchDataLayers(int id) : base(id)
		{
		}

		// Token: 0x06044183 RID: 278915 RVA: 0x011AE564 File Offset: 0x011AC764
		[NullableContext(1)]
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SwitchDataLayers switchDataLayers = inParams as SwitchDataLayers;
			if (switchDataLayers == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventSwitchDataLayers失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			List<string> unloads = new List<string>();
			List<string> newLoads = new List<string>();
			foreach (int p0Id in switchDataLayers.UnloadDataLayers)
			{
				DataLayerConfig? config = ConfigDataLayerConfigById.GetConfig(p0Id, true);
				unloads.Add(config.Value.DataLayer);
			}
			foreach (int p0Id2 in switchDataLayers.LoadDataLayers)
			{
				DataLayerConfig? config2 = ConfigDataLayerConfigById.GetConfig(p0Id2, true);
				newLoads.Add(config2.Value.DataLayer);
			}
			GameModeController instance = ControllerBase<GameModeController>.Instance;
			IList<string> unloadDataLayers = unloads.ToArray();
			IList<string> activateDataLayers = newLoads.ToArray();
			Action<bool> callback = delegate(bool result)
			{
				if (!result)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.InstanceDungeon;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "切换DataLayer失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("unloads", string.Join(",", unloads));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newLoads", string.Join(",", newLoads));
					instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			};
			ISwitchDataLayersTransitionWithSequence transitionOption = switchDataLayers.TransitionOption;
			string sequencePath = (transitionOption != null) ? transitionOption.SequencePath : null;
			ISwitchDataLayersTransitionWithSequence transitionOption2 = switchDataLayers.TransitionOption;
			instance.SwitchDataLayer(unloadDataLayers, activateDataLayers, callback, sequencePath, (transitionOption2 != null) ? transitionOption2.SeqMarkBeforeModifyMat : null, switchDataLayers.MaterialDataForLoadedLayers, switchDataLayers.MaterialDataForUnloadLayers);
		}
	}
}
