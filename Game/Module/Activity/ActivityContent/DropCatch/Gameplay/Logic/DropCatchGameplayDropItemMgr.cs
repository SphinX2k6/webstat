using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006936 RID: 26934
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayDropItemMgr : DropCatchGameplayBaseMgr
	{
		// Token: 0x06042D7E RID: 273790 RVA: 0x011281EC File Offset: 0x011263EC
		public DropCatchGameplayDropItemMgr(IGameplayLogicContext context) : base(context)
		{
		}

		// Token: 0x06042D7F RID: 273791 RVA: 0x01128254 File Offset: 0x01126454
		public override void Init()
		{
			DropCatchGameplay? gameplayConfig = this.Context.GetProxy().GetGameplayConfig();
			if (gameplayConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "DropCatchGameplayDropItemMgr init failed, gameplayConfig is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.DropPools.Clear();
			this.NextInstanceId = 1;
			foreach (int instanceId in new List<int>(this.ActiveDropItems.Keys))
			{
				this.RecycleDropItem(instanceId);
			}
			this.ConvertRules.Clear();
			this.RuleIdToRemove.Clear();
			this.ConvertRuleId = 0;
			foreach (int num in gameplayConfig.Value.DropPoolListIter())
			{
				DropCatchDropPool? dropCatchDropPoolById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchDropPoolById(num);
				if (dropCatchDropPoolById != null)
				{
					DropCatchGameplayAttribute spawnTimeInterval = new DropCatchGameplayAttribute("SpawnTimeInterval", dropCatchDropPoolById.Value.DropTimeInterval);
					IDropPoolRuntime dropPoolRuntime = new IDropPoolRuntime
					{
						PoolId = num,
						LastSpawnTime = -1.0,
						SpawnTimeInterval = spawnTimeInterval,
						LastSpawnPosX = 0.0,
						SpawnPosInterval = (double)dropCatchDropPoolById.Value.DropPosInterval,
						AliasTable = DropCatchGameplayHelper.BuildAliasTable(dropCatchDropPoolById.Value.DropItemList())
					};
					dropPoolRuntime.TimeRange.Add((double)(dropCatchDropPoolById.Value.TimeRange(0) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
					if (dropCatchDropPoolById.Value.TimeRange().Length > 1)
					{
						dropPoolRuntime.TimeRange.Add(dropPoolRuntime.TimeRange[0] + (double)(dropCatchDropPoolById.Value.TimeRange(1) * (float)Singleton<TimeUtil>.Instance.InverseMillisecond));
					}
					this.DropPools.Add(num, dropPoolRuntime);
				}
			}
		}

		// Token: 0x06042D80 RID: 273792 RVA: 0x011284A0 File Offset: 0x011266A0
		public override void OnTick(float deltaTime)
		{
			this.UpdateConvertRules(deltaTime);
			this.UpdateDropPools();
			this.UpdateDropItems(deltaTime);
		}

		// Token: 0x06042D81 RID: 273793 RVA: 0x011284B8 File Offset: 0x011266B8
		private void UpdateDropPools()
		{
			this.ExpiredPoolIds.Clear();
			float time = this.Context.GetGameplayTimeMgr().GetTime();
			foreach (KeyValuePair<int, IDropPoolRuntime> keyValuePair in this.DropPools)
			{
				int key = keyValuePair.Key;
				IDropPoolRuntime value = keyValuePair.Value;
				if ((double)time >= value.TimeRange[0])
				{
					if (value.TimeRange.Count > 1 && (double)time > value.TimeRange[1])
					{
						this.ExpiredPoolIds.Add(key);
					}
					else if (value.LastSpawnTime == -1.0)
					{
						this.SpawnFromPool(value, true);
						value.LastSpawnTime = (double)time;
					}
					else if ((double)time - value.LastSpawnTime >= (double)(value.SpawnTimeInterval.GetFinalValue() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond))
					{
						this.SpawnFromPool(value, false);
						value.LastSpawnTime = (double)time;
					}
				}
			}
			foreach (int key2 in this.ExpiredPoolIds)
			{
				this.DropPools.Remove(key2);
			}
		}

		// Token: 0x06042D82 RID: 273794 RVA: 0x01128624 File Offset: 0x01126824
		private void SpawnFromPool(IDropPoolRuntime pool, bool isFirstTime)
		{
			int num = DropCatchGameplayHelper.SampleFromAliasTable(pool.AliasTable);
			if (num == -1)
			{
				return;
			}
			num = this.ConvertItem(num);
			DropCatchDropItem? dropCatchDropItemById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchDropItemById(num);
			if (dropCatchDropItemById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(49, 1);
				defaultInterpolatedStringHandler.AppendLiteral("SpawnFromPool failed, itemId ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral(" not found in config");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			float num2 = dropCatchDropItemById.Value.Size(0) / 2f;
			double num3 = isFirstTime ? this.GetInitSpawnPosX(pool, (double)num2) : this.GetRandomSpawnPosX(pool.SpawnPosInterval, pool.LastSpawnPosX, (double)num2);
			this.SpawnDropItem(num, num3, null);
			pool.LastSpawnPosX = num3;
		}

		// Token: 0x06042D83 RID: 273795 RVA: 0x01128704 File Offset: 0x01126904
		private double GetInitSpawnPosX(IDropPoolRuntime pool, double itemHalfWidth)
		{
			DropCatchDropPool? dropCatchDropPoolById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchDropPoolById(pool.PoolId);
			if (dropCatchDropPoolById == null || dropCatchDropPoolById.Value.DropInitPosX == this.INVALID_SPAWN_POS_X)
			{
				return Singleton<MathUtils>.Instance.GetRandomRange(this.Context.GetGameplayArea().MinX + itemHalfWidth, this.Context.GetGameplayArea().MaxX - itemHalfWidth);
			}
			return (double)dropCatchDropPoolById.Value.DropInitPosX;
		}

		// Token: 0x06042D84 RID: 273796 RVA: 0x01128784 File Offset: 0x01126984
		private double GetRandomSpawnPosX(double posInterval, double lastPosX, double itemHalfWidth)
		{
			double num = this.Context.GetGameplayArea().MinX + itemHalfWidth;
			double num2 = this.Context.GetGameplayArea().MaxX - itemHalfWidth - num;
			double randomRange = Singleton<MathUtils>.Instance.GetRandomRange(-posInterval, posInterval);
			return ((lastPosX + randomRange - num) % num2 + num2) % num2 + num;
		}

		// Token: 0x06042D85 RID: 273797 RVA: 0x011287D4 File Offset: 0x011269D4
		public UniTask SpawnDropItem(int itemId, double posX, double? posY = null)
		{
			DropCatchGameplayDropItemMgr.<SpawnDropItem>d__16 <SpawnDropItem>d__;
			<SpawnDropItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SpawnDropItem>d__.<>4__this = this;
			<SpawnDropItem>d__.itemId = itemId;
			<SpawnDropItem>d__.posX = posX;
			<SpawnDropItem>d__.posY = posY;
			<SpawnDropItem>d__.<>1__state = -1;
			<SpawnDropItem>d__.<>t__builder.Start<DropCatchGameplayDropItemMgr.<SpawnDropItem>d__16>(ref <SpawnDropItem>d__);
			return <SpawnDropItem>d__.<>t__builder.Task;
		}

		// Token: 0x06042D86 RID: 273798 RVA: 0x01128830 File Offset: 0x01126A30
		private void UpdateDropItems(float deltaTime)
		{
			foreach (IDropItemInstance dropItemInstance in this.ActiveDropItems.Values)
			{
				dropItemInstance.OnTick(deltaTime);
			}
		}

		// Token: 0x06042D87 RID: 273799 RVA: 0x01128888 File Offset: 0x01126A88
		public void RecycleDropItem(int instanceId)
		{
			this.Context.GetGameplayCollisionMgr().RemoveCheckCollisionDropItemInstanceId(instanceId);
			IDropItemInstance dropItemInstance;
			if (!this.ActiveDropItems.TryGetValue(instanceId, out dropItemInstance))
			{
				return;
			}
			dropItemInstance.OnRecycle();
			this.DropItemPool.Add(dropItemInstance);
			this.ActiveDropItems.Remove(instanceId);
		}

		// Token: 0x06042D88 RID: 273800 RVA: 0x011288D8 File Offset: 0x01126AD8
		[NullableContext(2)]
		public IDropItemInstance GetDropItem(int instanceId)
		{
			IDropItemInstance result;
			this.ActiveDropItems.TryGetValue(instanceId, out result);
			return result;
		}

		// Token: 0x06042D89 RID: 273801 RVA: 0x011288F8 File Offset: 0x01126AF8
		[NullableContext(2)]
		public DropCatchGameplayAttribute GetSpawnTimeIntervalAttrByPoolId(int poolId)
		{
			IDropPoolRuntime dropPoolRuntime;
			this.DropPools.TryGetValue(poolId, out dropPoolRuntime);
			if (dropPoolRuntime == null)
			{
				return null;
			}
			return dropPoolRuntime.SpawnTimeInterval;
		}

		// Token: 0x06042D8A RID: 273802 RVA: 0x01128920 File Offset: 0x01126B20
		public void ConvertDropItem(int[] sourceItemId, int targetItemId, float duration = 0f)
		{
			Dictionary<int, IConvertRule> convertRules = this.ConvertRules;
			int convertRuleId = this.ConvertRuleId;
			this.ConvertRuleId = convertRuleId + 1;
			convertRules.Add(convertRuleId, new IConvertRule
			{
				SourceItemIds = new HashSet<int>(sourceItemId),
				TargetItemId = targetItemId,
				Duration = (double)(duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)
			});
		}

		// Token: 0x06042D8B RID: 273803 RVA: 0x01128978 File Offset: 0x01126B78
		private void UpdateConvertRules(float deltaTime)
		{
			if (this.ConvertRules.Count == 0)
			{
				return;
			}
			this.RuleIdToRemove.Clear();
			foreach (KeyValuePair<int, IConvertRule> keyValuePair in this.ConvertRules)
			{
				int key = keyValuePair.Key;
				IConvertRule value = keyValuePair.Value;
				if (value.Duration > 0.0)
				{
					value.Duration -= (double)deltaTime;
					if (value.Duration <= 0.0)
					{
						this.RuleIdToRemove.Add(key);
					}
				}
			}
			foreach (int key2 in this.RuleIdToRemove)
			{
				this.ConvertRules.Remove(key2);
			}
		}

		// Token: 0x06042D8C RID: 273804 RVA: 0x01128A78 File Offset: 0x01126C78
		private int ConvertItem(int itemId)
		{
			if (this.ConvertRules.Count == 0)
			{
				return itemId;
			}
			foreach (IConvertRule convertRule in this.ConvertRules.Values)
			{
				if (convertRule.SourceItemIds.Contains(itemId))
				{
					return convertRule.TargetItemId;
				}
			}
			return itemId;
		}

		// Token: 0x06042D8D RID: 273805 RVA: 0x01128AF4 File Offset: 0x01126CF4
		public Dictionary<int, IDropPoolRuntime> GetDropPools()
		{
			return this.DropPools;
		}

		// Token: 0x06042D8E RID: 273806 RVA: 0x01128AFC File Offset: 0x01126CFC
		public override void Destroy()
		{
			foreach (IDropItemInstance dropItemInstance in this.ActiveDropItems.Values)
			{
				dropItemInstance.Destroy();
			}
			foreach (IDropItemInstance dropItemInstance2 in this.DropItemPool)
			{
				dropItemInstance2.Destroy();
			}
			this.ActiveDropItems.Clear();
			this.DropItemPool.Clear();
			this.ConvertRules.Clear();
		}

		// Token: 0x040253FA RID: 152570
		private readonly float INVALID_SPAWN_POS_X = 9999f;

		// Token: 0x040253FB RID: 152571
		private readonly Dictionary<int, IDropPoolRuntime> DropPools = new Dictionary<int, IDropPoolRuntime>();

		// Token: 0x040253FC RID: 152572
		private int NextInstanceId = 1;

		// Token: 0x040253FD RID: 152573
		private readonly Dictionary<int, IDropItemInstance> ActiveDropItems = new Dictionary<int, IDropItemInstance>();

		// Token: 0x040253FE RID: 152574
		private readonly List<IDropItemInstance> DropItemPool = new List<IDropItemInstance>();

		// Token: 0x040253FF RID: 152575
		private int ConvertRuleId;

		// Token: 0x04025400 RID: 152576
		private readonly List<int> RuleIdToRemove = new List<int>();

		// Token: 0x04025401 RID: 152577
		private readonly Dictionary<int, IConvertRule> ConvertRules = new Dictionary<int, IConvertRule>();

		// Token: 0x04025402 RID: 152578
		private readonly List<int> ExpiredPoolIds = new List<int>();
	}
}
