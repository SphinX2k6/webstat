using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047E4 RID: 18404
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelSequenceFrameEventComponent : EntityComponent
	{
		// Token: 0x0602FBC9 RID: 195529 RVA: 0x00B6E2AC File Offset: 0x00B6C4AC
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			CreateEntityData p = args.GetP1<CreateEntityData>();
			LevelSequenceFrameEventComponent config = p.GetParam<LevelSequenceFrameEventComponent>() as LevelSequenceFrameEventComponent;
			this.Config = config;
			this.CreatureDataId = p.CreatureDataId;
			this.PbDataId = (long)p.PbDataId;
			List<ILevelSequenceSectionInfo> list = new List<ILevelSequenceSectionInfo>(this.Config.ForwardSections);
			list.Sort((ILevelSequenceSectionInfo a, ILevelSequenceSectionInfo b) => a.FrameId - b.FrameId);
			List<ILevelSequenceSectionInfo> list2 = new List<ILevelSequenceSectionInfo>(this.Config.BackWardSections);
			list2.Sort((ILevelSequenceSectionInfo a, ILevelSequenceSectionInfo b) => b.FrameId - a.FrameId);
			foreach (ValueTuple<List<ILevelSequenceSectionInfo>, Dictionary<string, int>> valueTuple in new List<ValueTuple<List<ILevelSequenceSectionInfo>, Dictionary<string, int>>>
			{
				new ValueTuple<List<ILevelSequenceSectionInfo>, Dictionary<string, int>>(list, this.MarkIndexMapFront),
				new ValueTuple<List<ILevelSequenceSectionInfo>, Dictionary<string, int>>(list2, this.MarkIndexMapBack)
			})
			{
				List<ILevelSequenceSectionInfo> item = valueTuple.Item1;
				Dictionary<string, int> item2 = valueTuple.Item2;
				foreach (ILevelSequenceSectionInfo levelSequenceSectionInfo in item)
				{
					if (levelSequenceSectionInfo.Type == ELevelSequenceSectionType.EventMark)
					{
						if (this.FrameMap.ContainsKey(levelSequenceSectionInfo.Key))
						{
							Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.FZX, "[SceneItemReference][EventComp] 场景引用实体帧事件组件key重复", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
						else
						{
							this.FrameMap[levelSequenceSectionInfo.Key] = levelSequenceSectionInfo;
						}
					}
					else if (levelSequenceSectionInfo.Type == ELevelSequenceSectionType.Mark)
					{
						if (item2.ContainsKey(levelSequenceSectionInfo.Key))
						{
							Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.FZX, "[SceneItemReference][EventComp] 场景引用实体帧事件组件key重复", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
						else
						{
							item2[levelSequenceSectionInfo.Key] = item.IndexOf(levelSequenceSectionInfo);
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0602FBCA RID: 195530 RVA: 0x00B6E4B4 File Offset: 0x00B6C6B4
		protected override bool OnClear()
		{
			this.Config = null;
			this.FrameMap.Clear();
			return true;
		}

		// Token: 0x0602FBCB RID: 195531 RVA: 0x00B6E4CC File Offset: 0x00B6C6CC
		public unsafe void ExecuteEvent(string key)
		{
			ILevelSequenceSectionInfo levelSequenceSectionInfo;
			this.FrameMap.TryGetValue(key, out levelSequenceSectionInfo);
			if (levelSequenceSectionInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[SceneItemReference][EventComp] 找不到key";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("id", this.PbDataId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			ILevelSequenceSectionInfo levelSequenceSectionInfo2;
			if (this.EventPendingList.Count <= 0)
			{
				levelSequenceSectionInfo2 = null;
			}
			else
			{
				List<ILevelSequenceSectionInfo> eventPendingList = this.EventPendingList;
				levelSequenceSectionInfo2 = eventPendingList[eventPendingList.Count - 1];
			}
			ILevelSequenceSectionInfo levelSequenceSectionInfo3 = levelSequenceSectionInfo2;
			if (this.EventPendingList.Count > 0)
			{
				this.EventPendingList.RemoveAt(this.EventPendingList.Count - 1);
			}
			if (levelSequenceSectionInfo3 == null || levelSequenceSectionInfo3.Key != key)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelPlay;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "[SceneItemReference][EventComp] 帧事件执行顺序有错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("key", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("id", this.PbDataId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
			if (levelSequenceSectionInfo.ActionList != null)
			{
				EntityContext entityContext = EntityContext.Create(base.Entity.Id, null);
				entityContext.ClientExecuteActions = true;
				entityContext.SequencePath = this.CurrentSequencePath;
				ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(levelSequenceSectionInfo.ActionList, entityContext, null);
				this.RequestAction(key);
			}
		}

		// Token: 0x0602FBCC RID: 195532 RVA: 0x00B6E658 File Offset: 0x00B6C858
		public void OnSequencePlayToMark(string mark, int frame, bool isInit, string sequencePath)
		{
			this.CurrentSequencePath = sequencePath;
			string currentMark = this.CurrentMark;
			this.CurrentMark = mark;
			if (isInit || currentMark == null || currentMark == this.CurrentMark)
			{
				return;
			}
			bool flag = this.MarkIndexMapFront[currentMark] < this.MarkIndexMapFront[this.CurrentMark];
			Dictionary<string, int> dictionary = flag ? this.MarkIndexMapFront : this.MarkIndexMapBack;
			List<ILevelSequenceSectionInfo> list = flag ? this.Config.ForwardSections : this.Config.BackWardSections.ToList<ILevelSequenceSectionInfo>();
			if (!flag)
			{
				list.Reverse();
			}
			ILevelSequenceSectionInfo levelSequenceSectionInfo = null;
			this.EventPendingList = new List<ILevelSequenceSectionInfo>();
			for (int i = dictionary[this.CurrentMark] - 1; i > dictionary[currentMark]; i--)
			{
				if (list[i].Type != ELevelSequenceSectionType.Mark)
				{
					if (flag ? (frame > list[i].FrameId) : (frame < list[i].FrameId))
					{
						levelSequenceSectionInfo = list[i];
						break;
					}
					this.EventPendingList.Add(list[i]);
				}
			}
			if (levelSequenceSectionInfo != null)
			{
				this.RequestAction(levelSequenceSectionInfo.Key);
			}
		}

		// Token: 0x0602FBCD RID: 195533 RVA: 0x00B6E784 File Offset: 0x00B6C984
		public unsafe void OnSequencePaused()
		{
			while (this.EventPendingList.Count > 0)
			{
				List<ILevelSequenceSectionInfo> eventPendingList = this.EventPendingList;
				ILevelSequenceSectionInfo levelSequenceSectionInfo = eventPendingList[eventPendingList.Count - 1];
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[SceneItemReference][EventComp] 补做遗漏的帧事件";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", levelSequenceSectionInfo.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("id", this.PbDataId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				if (this.FrameMap.ContainsKey(levelSequenceSectionInfo.Key))
				{
					this.ExecuteEvent(levelSequenceSectionInfo.Key);
				}
				else
				{
					this.EventPendingList.RemoveAt(this.EventPendingList.Count - 1);
				}
			}
			this.EventPendingList = new List<ILevelSequenceSectionInfo>();
		}

		// Token: 0x0602FBCE RID: 195534 RVA: 0x00B6E864 File Offset: 0x00B6CA64
		private void RequestAction(string key)
		{
			LevelSequenceFrameEventActionRequest levelSequenceFrameEventActionRequest = LevelSequenceFrameEventActionRequest.Create();
			levelSequenceFrameEventActionRequest.HostPlayerId = ModelBase<CreatureModel>.Instance.GetWorldOwner();
			levelSequenceFrameEventActionRequest.EntityId = this.CreatureDataId;
			levelSequenceFrameEventActionRequest.Key = key;
			Singleton<Net>.Instance.Call<LevelSequenceFrameEventActionResponse>(ERequestMessageId.LevelSequenceFrameEventActionRequest, levelSequenceFrameEventActionRequest, null, 0);
		}

		// Token: 0x0602FBCF RID: 195535 RVA: 0x00B6E8AC File Offset: 0x00B6CAAC
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			LevelSequenceFrameEventComponent levelSequenceFrameEventComponent = (LevelSequenceFrameEventComponent)componentTemplate;
			if (base.CanResetComponentProperty("Config"))
			{
				if (levelSequenceFrameEventComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelSequenceFrameEventComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataId"))
			{
				this.CreatureDataId = levelSequenceFrameEventComponent.CreatureDataId;
			}
			if (base.CanResetComponentProperty("PbDataId"))
			{
				this.PbDataId = levelSequenceFrameEventComponent.PbDataId;
			}
			if (base.CanResetComponentProperty("FrameMap") && levelSequenceFrameEventComponent.FrameMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, ILevelSequenceSectionInfo>>(this.FrameMap), "FrameMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CurrentMark"))
			{
				this.CurrentMark = levelSequenceFrameEventComponent.CurrentMark;
			}
			if (base.CanResetComponentProperty("MarkIndexMapFront") && levelSequenceFrameEventComponent.MarkIndexMapFront != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, int>>(this.MarkIndexMapFront), "MarkIndexMapFront"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("MarkIndexMapBack") && levelSequenceFrameEventComponent.MarkIndexMapBack != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, int>>(this.MarkIndexMapBack), "MarkIndexMapBack"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EventPendingList"))
			{
				if (levelSequenceFrameEventComponent.EventPendingList == null)
				{
					this.EventPendingList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<ILevelSequenceSectionInfo>>(this.EventPendingList), "EventPendingList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentSequencePath"))
			{
				this.CurrentSequencePath = levelSequenceFrameEventComponent.CurrentSequencePath;
			}
			return true;
		}

		// Token: 0x0401B5A9 RID: 112041
		[Nullable(2)]
		private LevelSequenceFrameEventComponent Config;

		// Token: 0x0401B5AA RID: 112042
		private long CreatureDataId;

		// Token: 0x0401B5AB RID: 112043
		private long PbDataId;

		// Token: 0x0401B5AC RID: 112044
		private readonly Dictionary<string, ILevelSequenceSectionInfo> FrameMap = new Dictionary<string, ILevelSequenceSectionInfo>();

		// Token: 0x0401B5AD RID: 112045
		[Nullable(2)]
		private string CurrentMark;

		// Token: 0x0401B5AE RID: 112046
		private readonly Dictionary<string, int> MarkIndexMapFront = new Dictionary<string, int>();

		// Token: 0x0401B5AF RID: 112047
		private readonly Dictionary<string, int> MarkIndexMapBack = new Dictionary<string, int>();

		// Token: 0x0401B5B0 RID: 112048
		private List<ILevelSequenceSectionInfo> EventPendingList = new List<ILevelSequenceSectionInfo>();

		// Token: 0x0401B5B1 RID: 112049
		[Nullable(2)]
		private string CurrentSequencePath;
	}
}
