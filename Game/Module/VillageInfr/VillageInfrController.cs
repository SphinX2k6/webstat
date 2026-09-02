using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C27 RID: 19495
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class VillageInfrController : ActivityControllerBase<VillageInfrController>
	{
		// Token: 0x06032D65 RID: 208229 RVA: 0x00CBCE20 File Offset: 0x00CBB020
		protected override void OnOpenView(ActivityBaseData data)
		{
			List<int> list = ((data != null) ? data.GetPreGuideQuestIds() : null) ?? new List<int>();
			if (list.Count <= 0)
			{
				this.OpenVillageInfrMainView(null).Forget<int?>();
				return;
			}
			int num = list[0];
			if (ModelBase<QuestNewModel>.Instance.CheckQuestFinished(num))
			{
				this.OpenVillageInfrMainView(null).Forget<int?>();
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, num, null);
		}

		// Token: 0x06032D66 RID: 208230 RVA: 0x00CBCE91 File Offset: 0x00CBB091
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_VillageInfrActivityMain";
		}

		// Token: 0x06032D67 RID: 208231 RVA: 0x00CBCE98 File Offset: 0x00CBB098
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new VillageInfrActivityMainView();
		}

		// Token: 0x06032D68 RID: 208232 RVA: 0x00CBCE9F File Offset: 0x00CBB09F
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06032D69 RID: 208233 RVA: 0x00CBCEA4 File Offset: 0x00CBB0A4
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			VillageInfrActivityData villageInfrActivityData = new VillageInfrActivityData();
			ModelBase<VillageInfrModel>.Instance.SetActivityData(villageInfrActivityData);
			return villageInfrActivityData;
		}

		// Token: 0x06032D6A RID: 208234 RVA: 0x00CBCEC4 File Offset: 0x00CBB0C4
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<InfrV2TaskDataUpdateNotify>(ENotifyMessageId.InfrV2TaskDataUpdateNotify, new Action<InfrV2TaskDataUpdateNotify, Net.CallbackStatus>(this.OnTaskUpdate));
			Singleton<Net>.Instance.Register<InfrV2TreeUpdateNotify>(ENotifyMessageId.InfrV2TreeUpdateNotify, new Action<InfrV2TreeUpdateNotify, Net.CallbackStatus>(this.OnTreeUpdate));
			Singleton<Net>.Instance.Register<InfrV2FireUpdateNotify>(ENotifyMessageId.InfrV2FireUpdateNotify, new Action<InfrV2FireUpdateNotify, Net.CallbackStatus>(this.OnVillageUpdate));
			Singleton<Net>.Instance.Register<InfrV2TreeFinishCondUpdateNotify>(ENotifyMessageId.InfrV2TreeFinishCondUpdateNotify, new Action<InfrV2TreeFinishCondUpdateNotify, Net.CallbackStatus>(this.OnFinishConditionUpdateNotify));
			Singleton<Net>.Instance.Register<InfrV2InfoNotify>(ENotifyMessageId.InfrV2InfoNotify, new Action<InfrV2InfoNotify, Net.CallbackStatus>(this.OnInfrV2InfoNotify));
		}

		// Token: 0x06032D6B RID: 208235 RVA: 0x00CBCF60 File Offset: 0x00CBB160
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrV2TaskDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrV2TreeUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrV2FireUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrV2TreeFinishCondUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrV2InfoNotify);
		}

		// Token: 0x06032D6C RID: 208236 RVA: 0x00CBCFBD File Offset: 0x00CBB1BD
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, bool>(EEventName.OnAddCommonItem, new Action<IProto_NormalItem, bool>(this.OnAddCommonItem));
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06032D6D RID: 208237 RVA: 0x00CBCFF7 File Offset: 0x00CBB1F7
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItem, new Action<IProto_NormalItem, bool>(this.OnAddCommonItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x06032D6E RID: 208238 RVA: 0x00CBD034 File Offset: 0x00CBB234
		[NullableContext(0)]
		public UniTask<bool> RequestInfrV2Info()
		{
			VillageInfrController.<RequestInfrV2Info>d__9 <RequestInfrV2Info>d__;
			<RequestInfrV2Info>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2Info>d__.<>1__state = -1;
			<RequestInfrV2Info>d__.<>t__builder.Start<VillageInfrController.<RequestInfrV2Info>d__9>(ref <RequestInfrV2Info>d__);
			return <RequestInfrV2Info>d__.<>t__builder.Task;
		}

		// Token: 0x06032D6F RID: 208239 RVA: 0x00CBD070 File Offset: 0x00CBB270
		[NullableContext(0)]
		public UniTask<bool> RequestInfrV2LevelUp()
		{
			VillageInfrController.<RequestInfrV2LevelUp>d__10 <RequestInfrV2LevelUp>d__;
			<RequestInfrV2LevelUp>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2LevelUp>d__.<>1__state = -1;
			<RequestInfrV2LevelUp>d__.<>t__builder.Start<VillageInfrController.<RequestInfrV2LevelUp>d__10>(ref <RequestInfrV2LevelUp>d__);
			return <RequestInfrV2LevelUp>d__.<>t__builder.Task;
		}

		// Token: 0x06032D70 RID: 208240 RVA: 0x00CBD0AC File Offset: 0x00CBB2AC
		[NullableContext(0)]
		public UniTask<bool> RequestInfrV2TreeBuild(int treeId)
		{
			VillageInfrController.<RequestInfrV2TreeBuild>d__11 <RequestInfrV2TreeBuild>d__;
			<RequestInfrV2TreeBuild>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2TreeBuild>d__.treeId = treeId;
			<RequestInfrV2TreeBuild>d__.<>1__state = -1;
			<RequestInfrV2TreeBuild>d__.<>t__builder.Start<VillageInfrController.<RequestInfrV2TreeBuild>d__11>(ref <RequestInfrV2TreeBuild>d__);
			return <RequestInfrV2TreeBuild>d__.<>t__builder.Task;
		}

		// Token: 0x06032D71 RID: 208241 RVA: 0x00CBD0F0 File Offset: 0x00CBB2F0
		[NullableContext(0)]
		public UniTask<bool> RequestInfrV2ManualSwitchTraceTree(int treeId)
		{
			VillageInfrController.<RequestInfrV2ManualSwitchTraceTree>d__12 <RequestInfrV2ManualSwitchTraceTree>d__;
			<RequestInfrV2ManualSwitchTraceTree>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2ManualSwitchTraceTree>d__.treeId = treeId;
			<RequestInfrV2ManualSwitchTraceTree>d__.<>1__state = -1;
			<RequestInfrV2ManualSwitchTraceTree>d__.<>t__builder.Start<VillageInfrController.<RequestInfrV2ManualSwitchTraceTree>d__12>(ref <RequestInfrV2ManualSwitchTraceTree>d__);
			return <RequestInfrV2ManualSwitchTraceTree>d__.<>t__builder.Task;
		}

		// Token: 0x06032D72 RID: 208242 RVA: 0x00CBD134 File Offset: 0x00CBB334
		[NullableContext(0)]
		public UniTask<bool> RequestInfrV2ManualCancelTraceTree()
		{
			VillageInfrController.<RequestInfrV2ManualCancelTraceTree>d__13 <RequestInfrV2ManualCancelTraceTree>d__;
			<RequestInfrV2ManualCancelTraceTree>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2ManualCancelTraceTree>d__.<>1__state = -1;
			<RequestInfrV2ManualCancelTraceTree>d__.<>t__builder.Start<VillageInfrController.<RequestInfrV2ManualCancelTraceTree>d__13>(ref <RequestInfrV2ManualCancelTraceTree>d__);
			return <RequestInfrV2ManualCancelTraceTree>d__.<>t__builder.Task;
		}

		// Token: 0x06032D73 RID: 208243 RVA: 0x00CBD170 File Offset: 0x00CBB370
		[NullableContext(0)]
		public UniTask<bool> RequestInfrV2ScoreReward()
		{
			VillageInfrController.<RequestInfrV2ScoreReward>d__14 <RequestInfrV2ScoreReward>d__;
			<RequestInfrV2ScoreReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2ScoreReward>d__.<>1__state = -1;
			<RequestInfrV2ScoreReward>d__.<>t__builder.Start<VillageInfrController.<RequestInfrV2ScoreReward>d__14>(ref <RequestInfrV2ScoreReward>d__);
			return <RequestInfrV2ScoreReward>d__.<>t__builder.Task;
		}

		// Token: 0x06032D74 RID: 208244 RVA: 0x00CBD1AC File Offset: 0x00CBB3AC
		[NullableContext(0)]
		public UniTask<bool> RequestInfrV2TaskReward([Nullable(1)] List<int> taskIds)
		{
			VillageInfrController.<RequestInfrV2TaskReward>d__15 <RequestInfrV2TaskReward>d__;
			<RequestInfrV2TaskReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrV2TaskReward>d__.taskIds = taskIds;
			<RequestInfrV2TaskReward>d__.<>1__state = -1;
			<RequestInfrV2TaskReward>d__.<>t__builder.Start<VillageInfrController.<RequestInfrV2TaskReward>d__15>(ref <RequestInfrV2TaskReward>d__);
			return <RequestInfrV2TaskReward>d__.<>t__builder.Task;
		}

		// Token: 0x06032D75 RID: 208245 RVA: 0x00CBD1EF File Offset: 0x00CBB3EF
		private void OnInfrV2InfoNotify(InfrV2InfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<VillageInfrModel>.Instance.SetData(notify.InfrInfo);
		}

		// Token: 0x06032D76 RID: 208246 RVA: 0x00CBD201 File Offset: 0x00CBB401
		private void OnTaskUpdate(InfrV2TaskDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<VillageInfrModel>.Instance.UpdateActivityTask(notify.Task);
		}

		// Token: 0x06032D77 RID: 208247 RVA: 0x00CBD213 File Offset: 0x00CBB413
		private void OnTreeUpdate(InfrV2TreeUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<VillageInfrModel>.Instance.SetAllTreeData(notify.TreeInfo);
		}

		// Token: 0x06032D78 RID: 208248 RVA: 0x00CBD225 File Offset: 0x00CBB425
		private void OnVillageUpdate(InfrV2FireUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<VillageInfrModel>.Instance.SetVillageData(notify.FireInfo);
		}

		// Token: 0x06032D79 RID: 208249 RVA: 0x00CBD237 File Offset: 0x00CBB437
		private void OnFinishConditionUpdateNotify(InfrV2TreeFinishCondUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<VillageInfrModel>.Instance.SetAllTreeFinishConditionData(notify.Cond);
		}

		// Token: 0x06032D7A RID: 208250 RVA: 0x00CBD24C File Offset: 0x00CBB44C
		private void OnAddCommonItem(IProto_NormalItem normalItem, bool isShowNewTips)
		{
			if (ModelBase<VillageInfrModel>.Instance.CanShowNewTip(normalItem.Id, normalItem.Count))
			{
				int value = ConfigBase<VillageInfrConfig>.Instance.GetTreeIdByItemId(normalItem.Id).Value;
				ModelBase<ItemModel>.Instance.PushWaitVillageInfrTree(value);
			}
		}

		// Token: 0x06032D7B RID: 208251 RVA: 0x00CBD298 File Offset: 0x00CBB498
		private void OnCommonItemCountAnyChange(IProto_NormalItem normalItem, int count, int lastCount)
		{
			if (ModelBase<VillageInfrModel>.Instance.CanShowNewTip(normalItem.Id, count - lastCount))
			{
				int value = ConfigBase<VillageInfrConfig>.Instance.GetTreeIdByItemId(normalItem.Id).Value;
				ModelBase<ItemModel>.Instance.PushWaitVillageInfrTree(value);
			}
		}

		// Token: 0x06032D7C RID: 208252 RVA: 0x00CBD2E0 File Offset: 0x00CBB4E0
		[NullableContext(0)]
		public UniTask<int?> OpenVillageInfrMainView([Nullable(2)] IVillageInfrMainParam param = null)
		{
			VillageInfrController.<OpenVillageInfrMainView>d__23 <OpenVillageInfrMainView>d__;
			<OpenVillageInfrMainView>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
			<OpenVillageInfrMainView>d__.param = param;
			<OpenVillageInfrMainView>d__.<>1__state = -1;
			<OpenVillageInfrMainView>d__.<>t__builder.Start<VillageInfrController.<OpenVillageInfrMainView>d__23>(ref <OpenVillageInfrMainView>d__);
			return <OpenVillageInfrMainView>d__.<>t__builder.Task;
		}

		// Token: 0x06032D7D RID: 208253 RVA: 0x00CBD324 File Offset: 0x00CBB524
		[NullableContext(0)]
		public UniTask<int?> OpenVillageInfrWorldBuildViewAsync(EVillageInfrSelectType selectType, int selectId, [Nullable(1)] string uiCameraName)
		{
			VillageInfrController.<OpenVillageInfrWorldBuildViewAsync>d__24 <OpenVillageInfrWorldBuildViewAsync>d__;
			<OpenVillageInfrWorldBuildViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
			<OpenVillageInfrWorldBuildViewAsync>d__.selectType = selectType;
			<OpenVillageInfrWorldBuildViewAsync>d__.selectId = selectId;
			<OpenVillageInfrWorldBuildViewAsync>d__.uiCameraName = uiCameraName;
			<OpenVillageInfrWorldBuildViewAsync>d__.<>1__state = -1;
			<OpenVillageInfrWorldBuildViewAsync>d__.<>t__builder.Start<VillageInfrController.<OpenVillageInfrWorldBuildViewAsync>d__24>(ref <OpenVillageInfrWorldBuildViewAsync>d__);
			return <OpenVillageInfrWorldBuildViewAsync>d__.<>t__builder.Task;
		}
	}
}
