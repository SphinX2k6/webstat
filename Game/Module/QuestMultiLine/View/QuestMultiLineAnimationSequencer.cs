using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.QuestMultiLine.View
{
	// Token: 0x02005322 RID: 21282
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineAnimationSequencer
	{
		// Token: 0x17008D29 RID: 36137
		// (get) Token: 0x060364EF RID: 222447 RVA: 0x00DB00CD File Offset: 0x00DAE2CD
		public bool IsPlaying
		{
			get
			{
				return this.Playing;
			}
		}

		// Token: 0x060364F0 RID: 222448 RVA: 0x00DB00D5 File Offset: 0x00DAE2D5
		public void Stop()
		{
			if (!this.Playing)
			{
				return;
			}
			this.StopRequested = true;
			CustomPromise stopPromise = this.StopPromise;
			if (stopPromise == null)
			{
				return;
			}
			stopPromise.SetResult();
		}

		// Token: 0x060364F1 RID: 222449 RVA: 0x00DB00F8 File Offset: 0x00DAE2F8
		public UniTask PlayAsync(QuestMultiLineTimePointData timePoint, IAnimationSequencerContext context)
		{
			QuestMultiLineAnimationSequencer.<PlayAsync>d__6 <PlayAsync>d__;
			<PlayAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAsync>d__.<>4__this = this;
			<PlayAsync>d__.timePoint = timePoint;
			<PlayAsync>d__.context = context;
			<PlayAsync>d__.<>1__state = -1;
			<PlayAsync>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<PlayAsync>d__6>(ref <PlayAsync>d__);
			return <PlayAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060364F2 RID: 222450 RVA: 0x00DB014C File Offset: 0x00DAE34C
		public UniTask PlayBranchSelectAsync(IReadOnlyList<QuestMultiLineComponentData> components, IReadOnlyList<int> fightAreas, IAnimationSequencerContext context)
		{
			QuestMultiLineAnimationSequencer.<PlayBranchSelectAsync>d__7 <PlayBranchSelectAsync>d__;
			<PlayBranchSelectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBranchSelectAsync>d__.<>4__this = this;
			<PlayBranchSelectAsync>d__.components = components;
			<PlayBranchSelectAsync>d__.fightAreas = fightAreas;
			<PlayBranchSelectAsync>d__.context = context;
			<PlayBranchSelectAsync>d__.<>1__state = -1;
			<PlayBranchSelectAsync>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<PlayBranchSelectAsync>d__7>(ref <PlayBranchSelectAsync>d__);
			return <PlayBranchSelectAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060364F3 RID: 222451 RVA: 0x00DB01A8 File Offset: 0x00DAE3A8
		private UniTask RunAsync(QuestMultiLineTimePointData timePoint, IAnimationSequencerContext context)
		{
			QuestMultiLineAnimationSequencer.<RunAsync>d__8 <RunAsync>d__;
			<RunAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunAsync>d__.<>4__this = this;
			<RunAsync>d__.timePoint = timePoint;
			<RunAsync>d__.context = context;
			<RunAsync>d__.<>1__state = -1;
			<RunAsync>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<RunAsync>d__8>(ref <RunAsync>d__);
			return <RunAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060364F4 RID: 222452 RVA: 0x00DB01FB File Offset: 0x00DAE3FB
		private List<int> GetSortedUnlockedGroupIds(QuestMultiLineTimePointData timePoint)
		{
			List<int> list = this.ExtractGroupIds(timePoint);
			list.Sort((int a, int b) => a - b);
			return list;
		}

		// Token: 0x060364F5 RID: 222453 RVA: 0x00DB022C File Offset: 0x00DAE42C
		private List<int> ExtractGroupIds(QuestMultiLineTimePointData timePoint)
		{
			List<int> list = new List<int>();
			Dictionary<int, QuestMultiLineComponentData> unlockComponent = timePoint.UnlockComponent;
			foreach (int num in timePoint.ComponentGroup)
			{
				QuestBranchComponentGroup? branchComponentGroupConfig = QuestMultiLineConfig.GetBranchComponentGroupConfig(num);
				if (branchComponentGroupConfig != null)
				{
					bool flag = false;
					foreach (int key in branchComponentGroupConfig.Value.BranchComponents())
					{
						if (unlockComponent.ContainsKey(key))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						list.Add(num);
					}
				}
			}
			return list;
		}

		// Token: 0x060364F6 RID: 222454 RVA: 0x00DB02C0 File Offset: 0x00DAE4C0
		private UniTask RaceEachWithStop<[Nullable(2)] T>(IReadOnlyList<T> items, Func<T, UniTask> run, int index = 0)
		{
			QuestMultiLineAnimationSequencer.<RaceEachWithStop>d__11<T> <RaceEachWithStop>d__;
			<RaceEachWithStop>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RaceEachWithStop>d__.<>4__this = this;
			<RaceEachWithStop>d__.items = items;
			<RaceEachWithStop>d__.run = run;
			<RaceEachWithStop>d__.index = index;
			<RaceEachWithStop>d__.<>1__state = -1;
			<RaceEachWithStop>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<RaceEachWithStop>d__11<T>>(ref <RaceEachWithStop>d__);
			return <RaceEachWithStop>d__.<>t__builder.Task;
		}

		// Token: 0x060364F7 RID: 222455 RVA: 0x00DB031C File Offset: 0x00DAE51C
		private UniTask RunOneGroupAnimations(int groupId, QuestMultiLineTimePointData timePoint, IAnimationSequencerContext context)
		{
			QuestMultiLineAnimationSequencer.<RunOneGroupAnimations>d__12 <RunOneGroupAnimations>d__;
			<RunOneGroupAnimations>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunOneGroupAnimations>d__.<>4__this = this;
			<RunOneGroupAnimations>d__.groupId = groupId;
			<RunOneGroupAnimations>d__.timePoint = timePoint;
			<RunOneGroupAnimations>d__.context = context;
			<RunOneGroupAnimations>d__.<>1__state = -1;
			<RunOneGroupAnimations>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<RunOneGroupAnimations>d__12>(ref <RunOneGroupAnimations>d__);
			return <RunOneGroupAnimations>d__.<>t__builder.Task;
		}

		// Token: 0x060364F8 RID: 222456 RVA: 0x00DB0378 File Offset: 0x00DAE578
		private UniTask RunGroupsSequentially(QuestMultiLineTimePointData timePoint, IAnimationSequencerContext context, IReadOnlyList<int> groupIds, int index)
		{
			QuestMultiLineAnimationSequencer.<RunGroupsSequentially>d__13 <RunGroupsSequentially>d__;
			<RunGroupsSequentially>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunGroupsSequentially>d__.<>4__this = this;
			<RunGroupsSequentially>d__.timePoint = timePoint;
			<RunGroupsSequentially>d__.context = context;
			<RunGroupsSequentially>d__.groupIds = groupIds;
			<RunGroupsSequentially>d__.index = index;
			<RunGroupsSequentially>d__.<>1__state = -1;
			<RunGroupsSequentially>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<RunGroupsSequentially>d__13>(ref <RunGroupsSequentially>d__);
			return <RunGroupsSequentially>d__.<>t__builder.Task;
		}

		// Token: 0x060364F9 RID: 222457 RVA: 0x00DB03DC File Offset: 0x00DAE5DC
		private UniTask RunBranchSelectAsync(IReadOnlyList<QuestMultiLineComponentData> components, IReadOnlyList<int> fightAreas, IAnimationSequencerContext context)
		{
			QuestMultiLineAnimationSequencer.<RunBranchSelectAsync>d__14 <RunBranchSelectAsync>d__;
			<RunBranchSelectAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunBranchSelectAsync>d__.<>4__this = this;
			<RunBranchSelectAsync>d__.components = components;
			<RunBranchSelectAsync>d__.fightAreas = fightAreas;
			<RunBranchSelectAsync>d__.context = context;
			<RunBranchSelectAsync>d__.<>1__state = -1;
			<RunBranchSelectAsync>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<RunBranchSelectAsync>d__14>(ref <RunBranchSelectAsync>d__);
			return <RunBranchSelectAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060364FA RID: 222458 RVA: 0x00DB0438 File Offset: 0x00DAE638
		private List<QuestMultiLineComponentData> BuildComponentsOfGroup(int[] componentIds, Dictionary<int, QuestMultiLineComponentData> unlockMap)
		{
			List<QuestMultiLineComponentData> list = new List<QuestMultiLineComponentData>();
			foreach (int key in componentIds)
			{
				QuestMultiLineComponentData item;
				if (unlockMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x060364FB RID: 222459 RVA: 0x00DB0474 File Offset: 0x00DAE674
		private UniTask RaceWithStop(UniTask p)
		{
			QuestMultiLineAnimationSequencer.<RaceWithStop>d__16 <RaceWithStop>d__;
			<RaceWithStop>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RaceWithStop>d__.<>4__this = this;
			<RaceWithStop>d__.p = p;
			<RaceWithStop>d__.<>1__state = -1;
			<RaceWithStop>d__.<>t__builder.Start<QuestMultiLineAnimationSequencer.<RaceWithStop>d__16>(ref <RaceWithStop>d__);
			return <RaceWithStop>d__.<>t__builder.Task;
		}

		// Token: 0x0401F399 RID: 127897
		private bool Playing;

		// Token: 0x0401F39A RID: 127898
		private bool StopRequested;

		// Token: 0x0401F39B RID: 127899
		[Nullable(2)]
		private CustomPromise StopPromise;
	}
}
