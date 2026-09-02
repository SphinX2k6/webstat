using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x020053FA RID: 21498
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlowConfig : ConfigBase<FlowConfig>
	{
		// Token: 0x06036E31 RID: 224817 RVA: 0x00DEB946 File Offset: 0x00DE9B46
		protected override bool OnInit()
		{
			this.CacheFlowListMap = new Dictionary<string, FlowListData>();
			if (!Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				FlowListData.AudioCache = new HashSet<string>();
				this.ReadAudioConfig();
			}
			return true;
		}

		// Token: 0x06036E32 RID: 224818 RVA: 0x00DEB970 File Offset: 0x00DE9B70
		protected override bool OnClear()
		{
			this.CacheFlowListMap = null;
			FlowListData.AudioCache = null;
			return true;
		}

		// Token: 0x06036E33 RID: 224819 RVA: 0x00DEB980 File Offset: 0x00DE9B80
		[NullableContext(2)]
		public unsafe ShowTalk GetRandomFlow([Nullable(1)] string flowListName, int flowId, string ownerName, int? flowState = null)
		{
			List<ActionInfo> list = null;
			if (flowState != null)
			{
				int? num = flowState;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					list = this.GetFlowStateActions(flowListName, flowId, flowState.Value);
				}
			}
			if (list == null)
			{
				list = this.GetRandomStateActions(flowListName, flowId, ownerName);
			}
			if (list == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "找不到剧情配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("flowListName", flowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("flowId", flowId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return null;
			}
			ActionInfo actionInfo = list.Find((ActionInfo action) => action.Name == EAction.ShowTalk);
			return ((actionInfo != null) ? actionInfo.Params : null) as ShowTalk;
		}

		// Token: 0x06036E34 RID: 224820 RVA: 0x00DEBA64 File Offset: 0x00DE9C64
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> GetFlowStateActions(string flowListName, int flowId, int stateId)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				FlowState? dbStateInfo = this.GetDbStateInfo(flowListName, flowId, stateId);
				if (dbStateInfo == null)
				{
					return null;
				}
				return Json.Parse<List<ActionInfo>>(dbStateInfo.Value.Actions, null);
			}
			else
			{
				IStateInfo jsonStateInfo = this.GetJsonStateInfo(flowListName, flowId, stateId, null);
				if (jsonStateInfo == null)
				{
					return null;
				}
				return jsonStateInfo.Actions;
			}
		}

		// Token: 0x06036E35 RID: 224821 RVA: 0x00DEBAC0 File Offset: 0x00DE9CC0
		public bool? GetFlowNeedLoad(string flowListName, int flowId, int stateId)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				return new bool?(this.GetDbStateInfo(flowListName, flowId, stateId).Value.IsPreloadFlow);
			}
			IStateInfo jsonStateInfo = this.GetJsonStateInfo(flowListName, flowId, stateId, null);
			if (jsonStateInfo == null)
			{
				return null;
			}
			return jsonStateInfo.IsPreloadFlow;
		}

		// Token: 0x06036E36 RID: 224822 RVA: 0x00DEBB18 File Offset: 0x00DE9D18
		public bool? GetFlowStateKeepMusic(string flowListName, int flowId, int stateId)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				FlowState? dbStateInfo = this.GetDbStateInfo(flowListName, flowId, stateId);
				if (dbStateInfo == null)
				{
					return new bool?(false);
				}
				return new bool?(dbStateInfo.Value.KeepBgm);
			}
			else
			{
				IStateInfo jsonStateInfo = this.GetJsonStateInfo(flowListName, flowId, stateId, null);
				if (jsonStateInfo == null)
				{
					return new bool?(false);
				}
				return jsonStateInfo.KeepBgm;
			}
		}

		// Token: 0x06036E37 RID: 224823 RVA: 0x00DEBB7C File Offset: 0x00DE9D7C
		public bool GetFlowIsClientFlow(string flowListName, int flowId, int stateId)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				FlowState? dbStateInfo = this.GetDbStateInfo(flowListName, flowId, stateId);
				return dbStateInfo != null && dbStateInfo.GetValueOrDefault().IsClientFlow;
			}
			IStateInfo jsonStateInfo = this.GetJsonStateInfo(flowListName, flowId, stateId, null);
			return ((jsonStateInfo != null) ? jsonStateInfo.IsClientFlow : null).GetValueOrDefault();
		}

		// Token: 0x06036E38 RID: 224824 RVA: 0x00DEBBE0 File Offset: 0x00DE9DE0
		[return: Nullable(2)]
		public IStateProgramSpecialProcessChangeTeamOptimization GetFlowProgramSpecialProcess(string flowListName, int flowId, int stateId)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				FlowState? dbStateInfo = this.GetDbStateInfo(flowListName, flowId, stateId);
				string text = (dbStateInfo != null) ? dbStateInfo.GetValueOrDefault().ProgramSpecialProcess : null;
				if (string.IsNullOrEmpty(text))
				{
					return null;
				}
				return Json.Parse<IStateProgramSpecialProcessChangeTeamOptimization>(text, null);
			}
			else
			{
				IStateInfo jsonStateInfo = this.GetJsonStateInfo(flowListName, flowId, stateId, null);
				if (jsonStateInfo == null)
				{
					return null;
				}
				return jsonStateInfo.ProgramSpecialProcess;
			}
		}

		// Token: 0x06036E39 RID: 224825 RVA: 0x00DEBC48 File Offset: 0x00DE9E48
		private FlowState? GetDbStateInfo(string flowListName, int flowId, int stateId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(flowListName);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(flowId);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(stateId);
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			FlowState? config = ConfigFlowStateByStateKey.GetConfig(text, true);
			if (config == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "无法找到对应剧情配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stateKey", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06036E3A RID: 224826 RVA: 0x00DEBCD0 File Offset: 0x00DE9ED0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private unsafe List<ActionInfo> GetRandomStateActions(string flowListName, int flowId, [Nullable(2)] string ownerName)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted(flowListName);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(flowId);
				Flow? config = ConfigFlowById.GetConfig(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				if (config == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "找不到剧情配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("flowListName", flowListName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("flowId", flowId);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return null;
				}
				int? randomStructArrayItem = ObjectUtils.GetRandomStructArrayItem<int>(config.Value.GetStatesArray());
				if (randomStructArrayItem == null)
				{
					return null;
				}
				return this.GetFlowStateActions(flowListName, flowId, randomStructArrayItem.Value);
			}
			else
			{
				IFlowInfo flowInfo = this.GetFlowInfo(flowListName, flowId, ownerName);
				if (flowInfo == null || flowInfo.States == null || flowInfo.States.Count == 0)
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Level;
					ELogAuthor author2 = ELogAuthor.CJH;
					string message2 = "找不到剧情配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("flowListName", flowListName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("flowId", flowId);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					return null;
				}
				IStateInfo randomArrayItem = ObjectUtils.GetRandomArrayItem<IStateInfo>(flowInfo.States);
				if (randomArrayItem == null)
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.Plot;
					ELogAuthor author3 = ELogAuthor.YSQ;
					string message3 = "剧情状态为空";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("flowListName", flowListName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("flowId", flowId);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
					return null;
				}
				return randomArrayItem.Actions;
			}
		}

		// Token: 0x06036E3B RID: 224827 RVA: 0x00DEBEA0 File Offset: 0x00DEA0A0
		[NullableContext(2)]
		private unsafe IStateInfo GetJsonStateInfo([Nullable(1)] string flowListName, int flowId, int stateId, string ownerName = null)
		{
			IFlowInfo flowInfo = this.GetFlowInfo(flowListName, flowId, ownerName);
			if (flowInfo == null)
			{
				return null;
			}
			IStateInfo stateInfo = null;
			if (flowInfo.States != null)
			{
				foreach (IStateInfo stateInfo2 in flowInfo.States)
				{
					if (stateInfo2.Id == stateId)
					{
						stateInfo = stateInfo2;
						break;
					}
				}
			}
			if (stateInfo == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "[StartFlow] 无法找到对应剧情的状态";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowId", flowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StateId", stateId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return stateInfo;
		}

		// Token: 0x06036E3C RID: 224828 RVA: 0x00DEBF78 File Offset: 0x00DEA178
		[NullableContext(2)]
		private unsafe FlowListData GetFlowListData([Nullable(1)] string flowListName, string ownerName = null)
		{
			if (this.CacheFlowListMap == null)
			{
				this.CacheFlowListMap = new Dictionary<string, FlowListData>();
			}
			FlowListData flowListData;
			if (!this.CacheFlowListMap.TryGetValue(flowListName, out flowListData))
			{
				IFlowListInfo flowListInfo = Singleton<PublicUtil>.Instance.GetFlowListInfo(flowListName);
				if (flowListInfo == null || flowListInfo.Flows == null || flowListInfo.Flows.Count == 0)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Level;
					ELogAuthor author = ELogAuthor.CJH;
					string message = "FlowListName配置错误";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Value", flowListName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Name", ownerName);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return null;
				}
				flowListData = new FlowListData();
				flowListData.Init(flowListInfo);
				this.CacheFlowListMap[flowListName] = flowListData;
				Singleton<PublicUtil>.Instance.RegisterFlowTextLocalConfig(flowListName);
			}
			flowListData.UpdateTime();
			return flowListData;
		}

		// Token: 0x06036E3D RID: 224829 RVA: 0x00DEC050 File Offset: 0x00DEA250
		[NullableContext(2)]
		private IFlowInfo GetFlowInfo([Nullable(1)] string flowListName, int flowId, string ownerName = null)
		{
			FlowListData flowListData = this.GetFlowListData(flowListName, ownerName);
			if (flowListData == null)
			{
				return null;
			}
			IFlowInfo flowInfo = flowListData.GetFlowInfo(flowId);
			if (flowInfo == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[PlotController.StartPlotNetwork] 无法找到对应剧情";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlotName", flowId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return flowInfo;
		}

		// Token: 0x06036E3E RID: 224830 RVA: 0x00DEC0A0 File Offset: 0x00DEA2A0
		private void ReadAudioConfig()
		{
			bool isPlayInEditor = GlobalData.IsPlayInEditor;
		}

		// Token: 0x06036E3F RID: 224831 RVA: 0x00DEC0A8 File Offset: 0x00DEA2A8
		public void ResetLocalFlowConfig()
		{
			Dictionary<string, FlowListData> cacheFlowListMap = this.CacheFlowListMap;
			if (cacheFlowListMap == null)
			{
				return;
			}
			cacheFlowListMap.Clear();
		}

		// Token: 0x0401F983 RID: 129411
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, FlowListData> CacheFlowListMap;
	}
}
