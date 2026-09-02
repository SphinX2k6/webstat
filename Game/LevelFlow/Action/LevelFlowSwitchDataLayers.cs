using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FAE RID: 28590
	public class LevelFlowSwitchDataLayers : LevelFlowActionBase
	{
		// Token: 0x06045236 RID: 283190 RVA: 0x0120A45F File Offset: 0x0120865F
		[NullableContext(1)]
		public LevelFlowSwitchDataLayers Init(SwitchDataLayers params_)
		{
			this.Params = params_;
			return this;
		}

		// Token: 0x06045237 RID: 283191 RVA: 0x0120A46C File Offset: 0x0120866C
		protected unsafe override void OnExecute()
		{
			if (this.Params == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.YSQ, "执行行为LevelFlowSwitchDataLayers失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			List<string> unloads = new List<string>();
			List<string> newLoads = new List<string>();
			foreach (int p0Id in this.Params.UnloadDataLayers)
			{
				DataLayerConfig? config = ConfigDataLayerConfigById.GetConfig(p0Id, true);
				unloads.Add(config.Value.DataLayer);
			}
			foreach (int p0Id2 in this.Params.LoadDataLayers)
			{
				DataLayerConfig? config2 = ConfigDataLayerConfigById.GetConfig(p0Id2, true);
				newLoads.Add(config2.Value.DataLayer);
			}
			ISwitchDataLayersTransitionWithSequence transitionOption = this.Params.TransitionOption;
			ControllerBase<GameModeController>.Instance.SwitchDataLayer(unloads, newLoads, delegate(bool result)
			{
				if (!result)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.InstanceDungeon;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "切换DataLayer失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("unloads", string.Join(",", unloads));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newLoads", string.Join(",", newLoads));
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}, (transitionOption != null) ? transitionOption.SequencePath : null, (transitionOption != null) ? transitionOption.SeqMarkBeforeModifyMat : null, this.Params.MaterialDataForLoadedLayers, this.Params.MaterialDataForUnloadLayers);
			base.FinishExecute(true);
		}

		// Token: 0x04026934 RID: 158004
		[Nullable(2)]
		private SwitchDataLayers Params;
	}
}
