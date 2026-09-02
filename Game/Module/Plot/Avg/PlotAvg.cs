using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Avg
{
	// Token: 0x02005443 RID: 21571
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotAvg
	{
		// Token: 0x06036FD9 RID: 225241 RVA: 0x00DF5A4C File Offset: 0x00DF3C4C
		[NullableContext(0)]
		public UniTask<bool> AvgCharacterEnterAsync([Nullable(1)] AvgTalkerEnterActionContext context)
		{
			PlotAvg.<AvgCharacterEnterAsync>d__2 <AvgCharacterEnterAsync>d__;
			<AvgCharacterEnterAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<AvgCharacterEnterAsync>d__.<>4__this = this;
			<AvgCharacterEnterAsync>d__.context = context;
			<AvgCharacterEnterAsync>d__.<>1__state = -1;
			<AvgCharacterEnterAsync>d__.<>t__builder.Start<PlotAvg.<AvgCharacterEnterAsync>d__2>(ref <AvgCharacterEnterAsync>d__);
			return <AvgCharacterEnterAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FDA RID: 225242 RVA: 0x00DF5A98 File Offset: 0x00DF3C98
		private UniTask PlayCharacterEnterPerformAsync(AvgTalkerEnterActionContext context)
		{
			PlotAvg.<PlayCharacterEnterPerformAsync>d__3 <PlayCharacterEnterPerformAsync>d__;
			<PlayCharacterEnterPerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCharacterEnterPerformAsync>d__.<>4__this = this;
			<PlayCharacterEnterPerformAsync>d__.context = context;
			<PlayCharacterEnterPerformAsync>d__.<>1__state = -1;
			<PlayCharacterEnterPerformAsync>d__.<>t__builder.Start<PlotAvg.<PlayCharacterEnterPerformAsync>d__3>(ref <PlayCharacterEnterPerformAsync>d__);
			return <PlayCharacterEnterPerformAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FDB RID: 225243 RVA: 0x00DF5AE3 File Offset: 0x00DF3CE3
		public void SetPerformHandler(IPlotAvgPerformHandler handler)
		{
			this.PerformHandler = handler;
		}

		// Token: 0x06036FDC RID: 225244 RVA: 0x00DF5AEC File Offset: 0x00DF3CEC
		public void ClearPerformHandler()
		{
			this.PerformHandler = null;
		}

		// Token: 0x06036FDD RID: 225245 RVA: 0x00DF5AF8 File Offset: 0x00DF3CF8
		[NullableContext(0)]
		public UniTask<bool> AvgCharacterExitAsync(int characterId)
		{
			PlotAvg.<AvgCharacterExitAsync>d__6 <AvgCharacterExitAsync>d__;
			<AvgCharacterExitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<AvgCharacterExitAsync>d__.<>4__this = this;
			<AvgCharacterExitAsync>d__.characterId = characterId;
			<AvgCharacterExitAsync>d__.<>1__state = -1;
			<AvgCharacterExitAsync>d__.<>t__builder.Start<PlotAvg.<AvgCharacterExitAsync>d__6>(ref <AvgCharacterExitAsync>d__);
			return <AvgCharacterExitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FDE RID: 225246 RVA: 0x00DF5B44 File Offset: 0x00DF3D44
		private UniTask PlayCharacterExitPerformAsync(int characterId)
		{
			PlotAvg.<PlayCharacterExitPerformAsync>d__7 <PlayCharacterExitPerformAsync>d__;
			<PlayCharacterExitPerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCharacterExitPerformAsync>d__.<>4__this = this;
			<PlayCharacterExitPerformAsync>d__.characterId = characterId;
			<PlayCharacterExitPerformAsync>d__.<>1__state = -1;
			<PlayCharacterExitPerformAsync>d__.<>t__builder.Start<PlotAvg.<PlayCharacterExitPerformAsync>d__7>(ref <PlayCharacterExitPerformAsync>d__);
			return <PlayCharacterExitPerformAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FDF RID: 225247 RVA: 0x00DF5B90 File Offset: 0x00DF3D90
		public UniTask AvgCharacterMoveAsync(AvgTalkerMoveActionContext context)
		{
			PlotAvg.<AvgCharacterMoveAsync>d__8 <AvgCharacterMoveAsync>d__;
			<AvgCharacterMoveAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AvgCharacterMoveAsync>d__.<>4__this = this;
			<AvgCharacterMoveAsync>d__.context = context;
			<AvgCharacterMoveAsync>d__.<>1__state = -1;
			<AvgCharacterMoveAsync>d__.<>t__builder.Start<PlotAvg.<AvgCharacterMoveAsync>d__8>(ref <AvgCharacterMoveAsync>d__);
			return <AvgCharacterMoveAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FE0 RID: 225248 RVA: 0x00DF5BDC File Offset: 0x00DF3DDC
		private UniTask PlayCharacterMovePerformAsync(AvgTalkerMoveActionContext context)
		{
			PlotAvg.<PlayCharacterMovePerformAsync>d__9 <PlayCharacterMovePerformAsync>d__;
			<PlayCharacterMovePerformAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCharacterMovePerformAsync>d__.<>4__this = this;
			<PlayCharacterMovePerformAsync>d__.context = context;
			<PlayCharacterMovePerformAsync>d__.<>1__state = -1;
			<PlayCharacterMovePerformAsync>d__.<>t__builder.Start<PlotAvg.<PlayCharacterMovePerformAsync>d__9>(ref <PlayCharacterMovePerformAsync>d__);
			return <PlayCharacterMovePerformAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036FE1 RID: 225249 RVA: 0x00DF5C28 File Offset: 0x00DF3E28
		public void ChangeCharacterAnim(int characterId, EAvgRoleAnimationType animationType, bool isLoop)
		{
			PlotAvgCharacter plotAvgCharacter;
			if (!this.CharacterMap.TryGetValue(characterId, out plotAvgCharacter))
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.LZK, "[PlotAvg] 角色动画失败，角色不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (plotAvgCharacter.AnimationType == animationType)
			{
				return;
			}
			plotAvgCharacter.AnimationType = animationType;
			if (this.PerformHandler == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.LZK, "[PlotAvg] PerformHandler 未设置，跳过角色动画表现", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.PerformHandler.ChangeCharacterAnim(characterId, animationType, isLoop);
		}

		// Token: 0x06036FE2 RID: 225250 RVA: 0x00DF5CA8 File Offset: 0x00DF3EA8
		public UniTask AvgCharacterEnterOrChangeAnim(AvgTalkerEnterActionContext context)
		{
			PlotAvg.<AvgCharacterEnterOrChangeAnim>d__11 <AvgCharacterEnterOrChangeAnim>d__;
			<AvgCharacterEnterOrChangeAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AvgCharacterEnterOrChangeAnim>d__.<>4__this = this;
			<AvgCharacterEnterOrChangeAnim>d__.context = context;
			<AvgCharacterEnterOrChangeAnim>d__.<>1__state = -1;
			<AvgCharacterEnterOrChangeAnim>d__.<>t__builder.Start<PlotAvg.<AvgCharacterEnterOrChangeAnim>d__11>(ref <AvgCharacterEnterOrChangeAnim>d__);
			return <AvgCharacterEnterOrChangeAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06036FE3 RID: 225251 RVA: 0x00DF5CF3 File Offset: 0x00DF3EF3
		public void OnPlotEnd()
		{
			this.ClearPerformHandler();
			this.CharacterMap.Clear();
		}

		// Token: 0x06036FE4 RID: 225252 RVA: 0x00DF5D06 File Offset: 0x00DF3F06
		[NullableContext(2)]
		public PlotAvgCharacter GetCharacter(int characterId)
		{
			return this.CharacterMap.GetValueOrDefault(characterId);
		}

		// Token: 0x06036FE5 RID: 225253 RVA: 0x00DF5D14 File Offset: 0x00DF3F14
		[NullableContext(2)]
		public PlotAvgCharacter GetCharacterByPosition(EAvgRolePosition position)
		{
			foreach (PlotAvgCharacter plotAvgCharacter in this.CharacterMap.Values)
			{
				if (plotAvgCharacter.Position == position)
				{
					return plotAvgCharacter;
				}
			}
			return null;
		}

		// Token: 0x06036FE6 RID: 225254 RVA: 0x00DF5D78 File Offset: 0x00DF3F78
		public HashSet<int> CollectCharacters(string flowListName, int flowId, int stateId)
		{
			HashSet<int> hashSet = new HashSet<int>();
			List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(flowListName, flowId, stateId);
			if (flowStateActions == null)
			{
				return hashSet;
			}
			ShowTalk showTalk = null;
			foreach (ActionInfo actionInfo in flowStateActions)
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					showTalk = (actionInfo.Params as ShowTalk);
					break;
				}
			}
			if (showTalk == null)
			{
				return hashSet;
			}
			List<ITalkItem> talkItems = showTalk.TalkItems;
			if (talkItems == null)
			{
				return hashSet;
			}
			foreach (ITalkItem talkItem in talkItems)
			{
				this.CollectCharactersFromAvgTalk(talkItem, hashSet);
				this.CollectCharactersFromActions(talkItem, hashSet);
			}
			return hashSet;
		}

		// Token: 0x06036FE7 RID: 225255 RVA: 0x00DF5E54 File Offset: 0x00DF4054
		public void CollectCharactersFromAvgTalk(ITalkItem talkItem, HashSet<int> characterIdSet)
		{
			if (talkItem.Type.GetValueOrDefault() != ETalkItemType.AvgTalk)
			{
				return;
			}
			ITalkItemAvgTalk talkItemAvgTalk = talkItem as ITalkItemAvgTalk;
			if (talkItemAvgTalk == null || talkItemAvgTalk.WhoId == null || talkItemAvgTalk.WhoId.Value == 0)
			{
				return;
			}
			characterIdSet.Add(talkItemAvgTalk.WhoId.Value);
		}

		// Token: 0x06036FE8 RID: 225256 RVA: 0x00DF5EB4 File Offset: 0x00DF40B4
		public void CollectCharactersFromActions(ITalkItem talkItem, HashSet<int> characterIdSet)
		{
			if (talkItem.IntroActions != null)
			{
				foreach (ActionInfo actionInfo in talkItem.IntroActions)
				{
					this.CollectCharactersFromAction(actionInfo, characterIdSet);
				}
			}
			if (talkItem.Actions != null)
			{
				foreach (ActionInfo actionInfo2 in talkItem.Actions)
				{
					this.CollectCharactersFromAction(actionInfo2, characterIdSet);
				}
			}
		}

		// Token: 0x06036FE9 RID: 225257 RVA: 0x00DF5F5C File Offset: 0x00DF415C
		public void CollectCharactersFromAction(ActionInfo actionInfo, HashSet<int> characterIdSet)
		{
			if (actionInfo.Name != EAction.AvgPlayRoleAction)
			{
				return;
			}
			AvgPlayRoleAction avgPlayRoleAction = (AvgPlayRoleAction)actionInfo.Params;
			this.CollectCharactersFromRoleActions(avgPlayRoleAction, characterIdSet);
		}

		// Token: 0x06036FEA RID: 225258 RVA: 0x00DF5F8C File Offset: 0x00DF418C
		public void CollectCharactersFromRoleActions(AvgPlayRoleAction avgPlayRoleAction, HashSet<int> characterIdSet)
		{
			foreach (IAvgPlayRoleActionItem avgPlayRoleActionItem in avgPlayRoleAction.RoleActionList)
			{
				if (avgPlayRoleActionItem.PositionConfig != null)
				{
					characterIdSet.Add(avgPlayRoleActionItem.RoleId);
				}
			}
		}

		// Token: 0x0401FA12 RID: 129554
		private readonly Dictionary<int, PlotAvgCharacter> CharacterMap = new Dictionary<int, PlotAvgCharacter>();

		// Token: 0x0401FA13 RID: 129555
		[Nullable(2)]
		private IPlotAvgPerformHandler PerformHandler;
	}
}
