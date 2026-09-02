using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.Define;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BB7 RID: 23479
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceDungeonEntranceConfig : ConfigBase<InstanceDungeonEntranceConfig>
	{
		// Token: 0x17009774 RID: 38772
		// (get) Token: 0x0603B665 RID: 243301 RVA: 0x00F0C9A8 File Offset: 0x00F0ABA8
		private unsafe Dictionary<int, InstanceDungeonEntrance> InstanceId2EntranceCfg
		{
			get
			{
				if (this.InstanceId2EntranceCfgInternal == null)
				{
					this.InstanceId2EntranceCfgInternal = new Dictionary<int, InstanceDungeonEntrance>();
					foreach (InstanceDungeonEntrance value in ConfigInstanceDungeonEntranceAll.GetConfigList(true))
					{
						Span<int> instanceDungeonListBytes = value.GetInstanceDungeonListBytes();
						for (int i = 0; i < instanceDungeonListBytes.Length; i++)
						{
							int key = *instanceDungeonListBytes[i];
							this.InstanceId2EntranceCfgInternal[key] = value;
						}
					}
				}
				return this.InstanceId2EntranceCfgInternal;
			}
		}

		// Token: 0x0603B666 RID: 243302 RVA: 0x00F0CA3C File Offset: 0x00F0AC3C
		protected override bool OnInit()
		{
			this.FlowMap[EInstanceEntranceFlowType.Normal] = new InstanceDungeonEntranceFlowNormal();
			this.FlowMap[EInstanceEntranceFlowType.SkipEditFormation] = new InstanceDungeonEntranceFlowSkipEditFormation();
			this.FlowMap[EInstanceEntranceFlowType.Roguelike] = new InstanceDungeonEntranceFlowRoguelike();
			this.FlowMap[EInstanceEntranceFlowType.TowerDefense] = new InstanceDungeonEntranceFlowTowerDefense();
			this.FlowMap[EInstanceEntranceFlowType.Attached] = new InstanceDungeonEntranceFlowAttached();
			this.FlowMap[EInstanceEntranceFlowType.FarmGold] = new InstanceDungeonEntranceFlowFarmGold();
			this.FlowMap[EInstanceEntranceFlowType.MowingRisk] = new InstanceDungeonEntranceFlowMowingRisk();
			this.FlowMap[EInstanceEntranceFlowType.Abyss] = new InstanceDungeonEntranceFlowAbyss();
			this.FlowMap[EInstanceEntranceFlowType.TrapDefense] = new InstanceDungeonEntranceFlowTrapDefense();
			this.FlowMap[EInstanceEntranceFlowType.LordGym] = new InstanceDungeonEntranceFlowLordGym();
			this.FlowMap[EInstanceEntranceFlowType.AdamSmasher] = new InstanceDungeonEntranceFlowAdamSmasher();
			this.FlowMap[EInstanceEntranceFlowType.LordGymFirst] = new InstanceDungeonEntranceFlowLordGymFirst();
			this.FlowMap[EInstanceEntranceFlowType.LordGymSecond] = new InstanceDungeonEntranceFlowLordGymSecond();
			this.FlowMap[EInstanceEntranceFlowType.LordGymThird5] = new InstanceDungeonEntranceFlowLordGymThird5();
			return true;
		}

		// Token: 0x0603B667 RID: 243303 RVA: 0x00F0CB44 File Offset: 0x00F0AD44
		public InstanceDungeonEntrance? GetConfig(int id)
		{
			InstanceDungeonEntrance? config = ConfigInstanceDungeonEntranceById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InstanceDungeon;
				ELogAuthor author = ELogAuthor.TL;
				string message = "获取副本入口配置错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x0603B668 RID: 243304 RVA: 0x00F0CB9C File Offset: 0x00F0AD9C
		[NullableContext(2)]
		public string GetConfigValueByParam(int id, string param, [Nullable(1)] string tag)
		{
			InstanceDungeonEntrance? config = this.GetConfig(id);
			if (config == null || param == null)
			{
				return null;
			}
			if (param == "MapBgPath")
			{
				return config.Value.MapBgPath;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "配置的表格字段查询到的资源路径不是字符串类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置的表格字段", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603B669 RID: 243305 RVA: 0x00F0CC08 File Offset: 0x00F0AE08
		public int GetInstanceDungeonEntranceFlowId(int id)
		{
			InstanceDungeonEntrance? config = this.GetConfig(id);
			int? num = (config != null) ? new int?(config.GetValueOrDefault().FlowId) : null;
			bool flag = (num ?? 0) == 0;
			if (flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InstanceDungeon;
				ELogAuthor author = ELogAuthor.TL;
				string message = "获取副本入口流程错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("flowId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				num = new int?(1);
			}
			return num.Value;
		}

		// Token: 0x0603B66A RID: 243306 RVA: 0x00F0CCA0 File Offset: 0x00F0AEA0
		[NullableContext(2)]
		public InstanceDungeonEntranceFlowBase GetInstanceDungeonEntranceFlow(int id)
		{
			InstanceDungeonEntrance? config = this.GetConfig(id);
			int? num = (config != null) ? new int?(config.GetValueOrDefault().FlowId) : null;
			bool flag = (num ?? 0) == 0;
			if (flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InstanceDungeon;
				ELogAuthor author = ELogAuthor.TL;
				string message = "获取副本入口流程错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("flowId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				num = new int?(1);
			}
			return this.FlowMap.GetValueOrDefault((EInstanceEntranceFlowType)num.Value);
		}

		// Token: 0x0603B66B RID: 243307 RVA: 0x00F0CD44 File Offset: 0x00F0AF44
		public void OnEditBattleViewClose()
		{
			foreach (InstanceDungeonEntranceFlowBase instanceDungeonEntranceFlowBase in this.FlowMap.Values)
			{
				instanceDungeonEntranceFlowBase.OnEditBattleViewClose();
			}
		}

		// Token: 0x0603B66C RID: 243308 RVA: 0x00F0CD9C File Offset: 0x00F0AF9C
		public int GetEntranceIdByMarkId(int markId)
		{
			int result;
			if (!this.GetEntranceMarkIdMap().TryGetValue(markId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603B66D RID: 243309 RVA: 0x00F0CDBC File Offset: 0x00F0AFBC
		public bool CheckMarkIdLinkDungeonEntrance(int markId)
		{
			return this.GetEntranceIdByMarkId(markId) > 0;
		}

		// Token: 0x0603B66E RID: 243310 RVA: 0x00F0CDC8 File Offset: 0x00F0AFC8
		public bool CheckMarkIdIsTowerEntrance(int markId)
		{
			int id;
			if (!this.GetEntranceMarkIdMap().TryGetValue(markId, out id))
			{
				return false;
			}
			InstanceDungeonEntrance? config = this.GetConfig(id);
			return (config != null && config.GetValueOrDefault().FlowId == 4) || (config != null && config.GetValueOrDefault().FlowId == 3) || (config != null && config.GetValueOrDefault().FlowId == 5);
		}

		// Token: 0x0603B66F RID: 243311 RVA: 0x00F0CE50 File Offset: 0x00F0B050
		public bool CheckMarkIdIsShipTowerEntrance(int markId)
		{
			int id;
			if (!this.GetEntranceMarkIdMap().TryGetValue(markId, out id))
			{
				return false;
			}
			InstanceDungeonEntrance? config = this.GetConfig(id);
			return config != null && config.GetValueOrDefault().FlowId == 11;
		}

		// Token: 0x0603B670 RID: 243312 RVA: 0x00F0CE98 File Offset: 0x00F0B098
		public bool CheckMarkIdIsRoguelike(int markId)
		{
			int id;
			if (!this.GetEntranceMarkIdMap().TryGetValue(markId, out id))
			{
				return false;
			}
			InstanceDungeonEntrance? config = this.GetConfig(id);
			return config != null && config.GetValueOrDefault().FlowId == 6;
		}

		// Token: 0x0603B671 RID: 243313 RVA: 0x00F0CEDC File Offset: 0x00F0B0DC
		public bool CheckMarkIdIsRogueRes(int markId)
		{
			int id;
			if (!this.GetEntranceMarkIdMap().TryGetValue(markId, out id))
			{
				return false;
			}
			InstanceDungeonEntrance? config = this.GetConfig(id);
			return config != null && config.GetValueOrDefault().FlowId == 14;
		}

		// Token: 0x0603B672 RID: 243314 RVA: 0x00F0CF24 File Offset: 0x00F0B124
		public bool CheckInstanceIdIsTowerDefense(int instanceId)
		{
			InstanceDungeonEntrance instanceDungeonEntrance;
			return this.InstanceId2EntranceCfg.TryGetValue(instanceId, out instanceDungeonEntrance) && instanceDungeonEntrance.FlowId == 8;
		}

		// Token: 0x0603B673 RID: 243315 RVA: 0x00F0CF50 File Offset: 0x00F0B150
		public bool CheckMarkIdIsWheelTower(int markId)
		{
			int id;
			if (!this.GetEntranceMarkIdMap().TryGetValue(markId, out id))
			{
				return false;
			}
			InstanceDungeonEntrance? config = this.GetConfig(id);
			return config != null && config.GetValueOrDefault().FlowId == 17;
		}

		// Token: 0x0603B674 RID: 243316 RVA: 0x00F0CF98 File Offset: 0x00F0B198
		public int GetEntranceIdByInstanceId(int instanceId)
		{
			InstanceDungeonEntrance instanceDungeonEntrance;
			if (!this.InstanceId2EntranceCfg.TryGetValue(instanceId, out instanceDungeonEntrance))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InstanceDungeon;
				ELogAuthor author = ELogAuthor.WZ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
				defaultInterpolatedStringHandler.AppendLiteral("未找到副本入口，请检查副本表配置，instanceId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(instanceId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return 0;
			}
			return instanceDungeonEntrance.Id;
		}

		// Token: 0x0603B675 RID: 243317 RVA: 0x00F0CFFC File Offset: 0x00F0B1FC
		public Dictionary<int, int> GetEntranceMarkIdMap()
		{
			if (this.EntranceMarkIdMap == null)
			{
				this.EntranceMarkIdMap = new Dictionary<int, int>();
				foreach (InstanceDungeonEntrance instanceDungeonEntrance in ConfigInstanceDungeonEntranceAll.GetConfigList(true))
				{
					if (instanceDungeonEntrance.MarkId != 0)
					{
						this.EntranceMarkIdMap[instanceDungeonEntrance.MarkId] = instanceDungeonEntrance.Id;
					}
				}
			}
			return this.EntranceMarkIdMap;
		}

		// Token: 0x040217BA RID: 137146
		private readonly Dictionary<EInstanceEntranceFlowType, InstanceDungeonEntranceFlowBase> FlowMap = new Dictionary<EInstanceEntranceFlowType, InstanceDungeonEntranceFlowBase>();

		// Token: 0x040217BB RID: 137147
		[Nullable(2)]
		private Dictionary<int, int> EntranceMarkIdMap;

		// Token: 0x040217BC RID: 137148
		[Nullable(2)]
		private Dictionary<int, InstanceDungeonEntrance> InstanceId2EntranceCfgInternal;
	}
}
