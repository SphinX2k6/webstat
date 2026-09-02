using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x020053FB RID: 21499
	public class FlowListData : IStaticVariableResetter
	{
		// Token: 0x06036E41 RID: 224833 RVA: 0x00DEC0C2 File Offset: 0x00DEA2C2
		static FlowListData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FlowListData.CreateStaticDefaultValue), new Action(FlowListData.ResetStaticDefaultValue));
		}

		// Token: 0x06036E42 RID: 224834 RVA: 0x00DEC0E4 File Offset: 0x00DEA2E4
		[NullableContext(1)]
		public void Init(IFlowListInfo flowList)
		{
			this.IdsMap = new Dictionary<int, IFlowInfo>();
			if (flowList.Flows != null)
			{
				foreach (IFlowInfo flowInfo in flowList.Flows)
				{
					foreach (IStateInfo stateInfo in flowInfo.States)
					{
						foreach (ActionInfo actionInfo in stateInfo.Actions)
						{
							if (actionInfo.Name == EAction.ShowTalk)
							{
								ShowTalk showTalk = actionInfo.Params as ShowTalk;
								if (((showTalk != null) ? showTalk.TalkItems : null) != null)
								{
									foreach (ITalkItem talkItem in showTalk.TalkItems)
									{
										if (FlowListData.AudioCache.Contains(talkItem.TidTalk))
										{
											talkItem.PlayVoice = new bool?(true);
										}
									}
								}
							}
						}
					}
					this.IdsMap[flowInfo.Id] = flowInfo;
				}
			}
		}

		// Token: 0x06036E43 RID: 224835 RVA: 0x00DEC298 File Offset: 0x00DEA498
		[NullableContext(2)]
		public IFlowInfo GetFlowInfo(int key)
		{
			if (this.IdsMap == null)
			{
				return null;
			}
			IFlowInfo result;
			this.IdsMap.TryGetValue(key, out result);
			return result;
		}

		// Token: 0x06036E44 RID: 224836 RVA: 0x00DEC2BF File Offset: 0x00DEA4BF
		public void UpdateTime()
		{
		}

		// Token: 0x06036E45 RID: 224837 RVA: 0x00DEC2C1 File Offset: 0x00DEA4C1
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06036E46 RID: 224838 RVA: 0x00DEC2C3 File Offset: 0x00DEA4C3
		public static void ResetStaticDefaultValue()
		{
			FlowListData.AudioCache = null;
		}

		// Token: 0x0401F984 RID: 129412
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, IFlowInfo> IdsMap;

		// Token: 0x0401F985 RID: 129413
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static HashSet<string> AudioCache;
	}
}
