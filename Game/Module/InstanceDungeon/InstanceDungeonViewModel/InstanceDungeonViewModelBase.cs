using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonComponentModel;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel
{
	// Token: 0x02005BD9 RID: 23513
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class InstanceDungeonViewModelBase
	{
		// Token: 0x1700979C RID: 38812
		// (get) Token: 0x0603B878 RID: 243832 RVA: 0x00F175B3 File Offset: 0x00F157B3
		// (set) Token: 0x0603B879 RID: 243833 RVA: 0x00F175BB File Offset: 0x00F157BB
		[Nullable(2)]
		public virtual RankTimeItemModelBase RankItemModel { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x0603B87A RID: 243834 RVA: 0x00F175C4 File Offset: 0x00F157C4
		public InstanceDungeonViewModelBase()
		{
			this.EntranceId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId;
			this.InitInstanceData();
			this.InitGetterData();
		}

		// Token: 0x0603B87B RID: 243835 RVA: 0x00F17600 File Offset: 0x00F15800
		private void InitInstanceData()
		{
			this.InstanceByTitleMap = this.GetInstanceByTitleMap();
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.InstanceByTitleMap)
			{
				int num;
				List<int> list;
				keyValuePair.Deconstruct(out num, out list);
				List<int> list2 = list;
				int[] instanceIdList = this.InstanceIdList;
				list = list2;
				num = 0;
				int[] array = new int[instanceIdList.Length + list.Count];
				ReadOnlySpan<int> readOnlySpan = new ReadOnlySpan<int>(instanceIdList);
				readOnlySpan.CopyTo(new Span<int>(array).Slice(num, readOnlySpan.Length));
				num += readOnlySpan.Length;
				Span<int> span = CollectionsMarshal.AsSpan<int>(list);
				span.CopyTo(new Span<int>(array).Slice(num, span.Length));
				num += span.Length;
				this.InstanceIdList = array;
			}
		}

		// Token: 0x0603B87C RID: 243836 RVA: 0x00F176F8 File Offset: 0x00F158F8
		private void InitGetterData()
		{
			EInstanceEntranceFlowType flowId = (EInstanceEntranceFlowType)ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(this.EntranceId).Value.FlowId;
			InstanceDungeonMapDefine.InstanceDungeonEntranceViewGetterDataMap.TryGetValue(flowId, out this.GetterData);
		}

		// Token: 0x0603B87D RID: 243837 RVA: 0x00F17738 File Offset: 0x00F15938
		public void RegisterView(InstanceDungeonEntranceView view)
		{
			this.View = view;
		}

		// Token: 0x0603B87E RID: 243838 RVA: 0x00F17741 File Offset: 0x00F15941
		public virtual UniTask OnBeforeStartAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603B87F RID: 243839 RVA: 0x00F17748 File Offset: 0x00F15948
		public virtual void OnBeforeHide()
		{
		}

		// Token: 0x0603B880 RID: 243840 RVA: 0x00F1774A File Offset: 0x00F1594A
		public virtual void OnBeforeDestroy()
		{
		}

		// Token: 0x0603B881 RID: 243841 RVA: 0x00F1774C File Offset: 0x00F1594C
		public UniTask RequestServerData()
		{
			InstanceDungeonViewModelBase.<RequestServerData>d__16 <RequestServerData>d__;
			<RequestServerData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestServerData>d__.<>4__this = this;
			<RequestServerData>d__.<>1__state = -1;
			<RequestServerData>d__.<>t__builder.Start<InstanceDungeonViewModelBase.<RequestServerData>d__16>(ref <RequestServerData>d__);
			return <RequestServerData>d__.<>t__builder.Task;
		}

		// Token: 0x0603B882 RID: 243842 RVA: 0x00F1778F File Offset: 0x00F1598F
		public void SortInstanceArray(List<int> instanceArray)
		{
			this.OnSortInstanceArray(instanceArray);
		}

		// Token: 0x0603B883 RID: 243843 RVA: 0x00F17798 File Offset: 0x00F15998
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public virtual ValueTuple<InstanceDetectionDynamicData[], int> GetDiyInstanceDetectionDynamicData(int currentSeriesId, int currentInstanceId)
		{
			return new ValueTuple<InstanceDetectionDynamicData[], int>(Array.Empty<InstanceDetectionDynamicData>(), 0);
		}

		// Token: 0x0603B884 RID: 243844 RVA: 0x00F177A5 File Offset: 0x00F159A5
		public string GetInstanceItemTextureBg(int instanceId)
		{
			return this.OnGetInstanceItemTextureBg(instanceId);
		}

		// Token: 0x0603B885 RID: 243845 RVA: 0x00F177AE File Offset: 0x00F159AE
		public bool CheckInstanceUnlock(int instanceId)
		{
			return this.OnCheckInstanceUnlock(instanceId);
		}

		// Token: 0x0603B886 RID: 243846 RVA: 0x00F177B7 File Offset: 0x00F159B7
		[NullableContext(2)]
		public TableTextArgNew GetUnlockConditionTextId(int instanceId)
		{
			return this.OnGetUnlockConditionTextId(instanceId);
		}

		// Token: 0x0603B887 RID: 243847 RVA: 0x00F177C0 File Offset: 0x00F159C0
		public bool IsFinishInstance(int instanceId)
		{
			return this.OnIsFinishInstance(instanceId);
		}

		// Token: 0x0603B888 RID: 243848 RVA: 0x00F177C9 File Offset: 0x00F159C9
		public string GetInstanceDetectItemIcon(int instanceId)
		{
			return this.OnGetInstanceDetectItemIcon(instanceId);
		}

		// Token: 0x0603B889 RID: 243849 RVA: 0x00F177D2 File Offset: 0x00F159D2
		[NullableContext(2)]
		public InstanceDungeonEntranceViewSelectData GetDefaultSelectData()
		{
			return this.OnGetDefaultSelectData();
		}

		// Token: 0x0603B88A RID: 243850 RVA: 0x00F177DA File Offset: 0x00F159DA
		public bool CheckNeedOnTimer(int instanceId)
		{
			return this.OnCheckNeedOnTimer(instanceId);
		}

		// Token: 0x0603B88B RID: 243851 RVA: 0x00F177E3 File Offset: 0x00F159E3
		public void TimerRefreshFunction(float delta)
		{
			this.OnTimerRefreshFunction(delta);
		}

		// Token: 0x0603B88C RID: 243852 RVA: 0x00F177EC File Offset: 0x00F159EC
		public bool CheckInstanceItemHasRedDot(int instanceId)
		{
			return this.OnCheckInstanceHasRedDot(instanceId);
		}

		// Token: 0x0603B88D RID: 243853 RVA: 0x00F177F5 File Offset: 0x00F159F5
		protected virtual void OnSortInstanceArray(List<int> instanceArray)
		{
		}

		// Token: 0x0603B88E RID: 243854 RVA: 0x00F177F7 File Offset: 0x00F159F7
		protected virtual string OnGetInstanceItemTextureBg(int instanceId)
		{
			return "T_TogListNor";
		}

		// Token: 0x0603B88F RID: 243855 RVA: 0x00F17800 File Offset: 0x00F15A00
		protected virtual Dictionary<int, List<int>> GetInstanceByTitleMap()
		{
			Dictionary<int, int> sortedByTitleEntranceInstanceIdList = ModelBase<InstanceDungeonEntranceModel>.Instance.GetSortedByTitleEntranceInstanceIdList(this.EntranceId);
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			foreach (KeyValuePair<int, int> keyValuePair in sortedByTitleEntranceInstanceIdList)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int item = num;
				int key = num2;
				List<int> list;
				if (!dictionary.TryGetValue(key, out list))
				{
					list = new List<int>();
					dictionary[key] = list;
				}
				list.Add(item);
			}
			return dictionary;
		}

		// Token: 0x0603B890 RID: 243856 RVA: 0x00F17894 File Offset: 0x00F15A94
		protected virtual bool OnCheckInstanceUnlock(int instanceId)
		{
			return ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(instanceId);
		}

		// Token: 0x0603B891 RID: 243857 RVA: 0x00F178A4 File Offset: 0x00F15AA4
		[NullableContext(2)]
		protected virtual TableTextArgNew OnGetUnlockConditionTextId(int instanceId)
		{
			string unlockConditionGroupHintText = ConfigBase<InstanceDungeonConfig>.Instance.GetUnlockConditionGroupHintText(instanceId);
			if (!string.IsNullOrEmpty(unlockConditionGroupHintText))
			{
				return new TableTextArgNew(unlockConditionGroupHintText, Array.Empty<object>());
			}
			return null;
		}

		// Token: 0x0603B892 RID: 243858 RVA: 0x00F178D2 File Offset: 0x00F15AD2
		protected virtual bool OnIsFinishInstance(int instanceId)
		{
			return ModelBase<ExchangeRewardModel>.Instance.IsFinishInstance(instanceId);
		}

		// Token: 0x0603B893 RID: 243859 RVA: 0x00F178E0 File Offset: 0x00F15AE0
		protected virtual string OnGetInstanceDetectItemIcon(int instanceId)
		{
			return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.DifficultyIcon;
		}

		// Token: 0x0603B894 RID: 243860 RVA: 0x00F17908 File Offset: 0x00F15B08
		[NullableContext(2)]
		protected virtual InstanceDungeonEntranceViewSelectData OnGetDefaultSelectData()
		{
			InstanceDungeonEntranceViewGetterData getterData = this.GetterData;
			if (((getterData != null) ? getterData.DefaultSelectDataGetter : null) == null)
			{
				return null;
			}
			return this.GetterData.DefaultSelectDataGetter(this.InstanceByTitleMap) as InstanceDungeonEntranceViewSelectData;
		}

		// Token: 0x0603B895 RID: 243861 RVA: 0x00F1793B File Offset: 0x00F15B3B
		protected virtual bool OnCheckNeedOnTimer(int instanceId)
		{
			return false;
		}

		// Token: 0x0603B896 RID: 243862 RVA: 0x00F1793E File Offset: 0x00F15B3E
		protected virtual void OnTimerRefreshFunction(float delta)
		{
		}

		// Token: 0x0603B897 RID: 243863 RVA: 0x00F17940 File Offset: 0x00F15B40
		protected virtual bool OnCheckInstanceHasRedDot(int instanceId)
		{
			return false;
		}

		// Token: 0x0603B898 RID: 243864 RVA: 0x00F17943 File Offset: 0x00F15B43
		protected virtual UniTask OnRequestServerData()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0402185D RID: 137309
		protected InstanceDungeonEntranceView View;

		// Token: 0x0402185E RID: 137310
		public int EntranceId;

		// Token: 0x0402185F RID: 137311
		public int[] InstanceIdList = Array.Empty<int>();

		// Token: 0x04021860 RID: 137312
		public Dictionary<int, List<int>> InstanceByTitleMap = new Dictionary<int, List<int>>();

		// Token: 0x04021861 RID: 137313
		[Nullable(2)]
		private InstanceDungeonEntranceViewGetterData GetterData;
	}
}
