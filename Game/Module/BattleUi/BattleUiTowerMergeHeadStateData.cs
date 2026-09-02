using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F8C RID: 24460
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiTowerMergeHeadStateData
	{
		// Token: 0x0603D696 RID: 251542 RVA: 0x00F9FC2E File Offset: 0x00F9DE2E
		public void Init()
		{
		}

		// Token: 0x0603D697 RID: 251543 RVA: 0x00F9FC30 File Offset: 0x00F9DE30
		public void OnLeaveLevel()
		{
			this.Clear();
		}

		// Token: 0x0603D698 RID: 251544 RVA: 0x00F9FC38 File Offset: 0x00F9DE38
		public void Clear()
		{
			if (this.Info != null)
			{
				foreach (TowerMergeHeadStateMonsterInfo towerMergeHeadStateMonsterInfo in this.Info.MonsterInfos.Values)
				{
					towerMergeHeadStateMonsterInfo.RemoveListener();
				}
				if (this.Info.IsVisible)
				{
					this.Info.IsVisible = false;
					Singleton<EventSystem>.Instance.Emit<TowerMergeHeadStateInfo>(EEventName.BattleUiTowerMergeHeadStateVisibleChanged, this.Info);
				}
			}
			this.Info = null;
			this.ListenMonsterAddMap.Clear();
			this.ListenMonsterRemoveMap.Clear();
		}

		// Token: 0x0603D699 RID: 251545 RVA: 0x00F9FCE8 File Offset: 0x00F9DEE8
		public void UpdateTowerMonsterHpInfo(NewTowerMonsterHpInfoNotify notify)
		{
			this.UpdateProgress(notify.MonsterHpInfos);
		}

		// Token: 0x0603D69A RID: 251546 RVA: 0x00F9FCF8 File Offset: 0x00F9DEF8
		public void UpdateProgress(IList<NewTowerMonsterHpInfo> param)
		{
			if (param == null || param.Count <= 1)
			{
				this.Clear();
				return;
			}
			int waveConfigId = param[0].WaveConfigId;
			if (this.Info == null)
			{
				this.Info = new TowerMergeHeadStateInfo();
			}
			else if (this.Info.MainMonsterInfoId != waveConfigId)
			{
				this.Clear();
				this.Info = new TowerMergeHeadStateInfo();
			}
			this.Info.MainMonsterInfoId = waveConfigId;
			foreach (NewTowerMonsterHpInfo newTowerMonsterHpInfo in param)
			{
				TowerMergeHeadStateMonsterInfo towerMergeHeadStateMonsterInfo;
				if (!this.Info.MonsterInfos.TryGetValue(newTowerMonsterHpInfo.WaveConfigId, out towerMergeHeadStateMonsterInfo))
				{
					towerMergeHeadStateMonsterInfo = new TowerMergeHeadStateMonsterInfo
					{
						MonsterInfoId = newTowerMonsterHpInfo.WaveConfigId,
						CreatureDataId = newTowerMonsterHpInfo.IncId
					};
					towerMergeHeadStateMonsterInfo.Hp = (float)((towerMergeHeadStateMonsterInfo.CreatureDataId <= 0L) ? 0L : Singleton<MathUtils>.Instance.LongToNumber(newTowerMonsterHpInfo.CurHp));
					towerMergeHeadStateMonsterInfo.HpMax = (float)Singleton<MathUtils>.Instance.LongToNumber(newTowerMonsterHpInfo.MaxHp);
					this.Info.MonsterInfos[towerMergeHeadStateMonsterInfo.MonsterInfoId] = towerMergeHeadStateMonsterInfo;
					this.TryAttachListener(towerMergeHeadStateMonsterInfo);
				}
				else if (towerMergeHeadStateMonsterInfo.CreatureDataId != newTowerMonsterHpInfo.IncId)
				{
					towerMergeHeadStateMonsterInfo.RemoveListener();
					this.ListenMonsterAddMap.Remove(towerMergeHeadStateMonsterInfo.CreatureDataId);
					if (towerMergeHeadStateMonsterInfo.EntityHandle != null && towerMergeHeadStateMonsterInfo.EntityHandle.Id != 0)
					{
						this.ListenMonsterRemoveMap.Remove(towerMergeHeadStateMonsterInfo.EntityHandle.Id);
					}
					towerMergeHeadStateMonsterInfo.EntityHandle = null;
					towerMergeHeadStateMonsterInfo.CreatureDataId = newTowerMonsterHpInfo.IncId;
					towerMergeHeadStateMonsterInfo.Hp = (float)((towerMergeHeadStateMonsterInfo.CreatureDataId <= 0L) ? 0L : Singleton<MathUtils>.Instance.LongToNumber(newTowerMonsterHpInfo.CurHp));
					towerMergeHeadStateMonsterInfo.HpMax = (float)Singleton<MathUtils>.Instance.LongToNumber(newTowerMonsterHpInfo.MaxHp);
					this.TryAttachListener(towerMergeHeadStateMonsterInfo);
				}
				else if (towerMergeHeadStateMonsterInfo.AttributeComponent != null)
				{
					towerMergeHeadStateMonsterInfo.Hp = towerMergeHeadStateMonsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.Life);
					towerMergeHeadStateMonsterInfo.HpMax = towerMergeHeadStateMonsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
				}
				else
				{
					towerMergeHeadStateMonsterInfo.Hp = (float)((towerMergeHeadStateMonsterInfo.CreatureDataId <= 0L) ? 0L : Singleton<MathUtils>.Instance.LongToNumber(newTowerMonsterHpInfo.CurHp));
					towerMergeHeadStateMonsterInfo.HpMax = (float)Singleton<MathUtils>.Instance.LongToNumber(newTowerMonsterHpInfo.MaxHp);
				}
			}
			this.ReCalcTotalHp();
			this.DispatchHpChanged();
		}

		// Token: 0x0603D69B RID: 251547 RVA: 0x00F9FF68 File Offset: 0x00F9E168
		public void OnAddEntity(EntityHandle handle)
		{
			if (this.ListenMonsterAddMap.Count <= 0)
			{
				return;
			}
			long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(handle.Id);
			TowerMergeHeadStateMonsterInfo towerMergeHeadStateMonsterInfo;
			if (!this.ListenMonsterAddMap.TryGetValue(creatureDataId, out towerMergeHeadStateMonsterInfo))
			{
				return;
			}
			this.ListenMonsterAddMap.Remove(creatureDataId);
			towerMergeHeadStateMonsterInfo.EntityHandle = handle;
			this.AttachMonsterListener(towerMergeHeadStateMonsterInfo);
			if (towerMergeHeadStateMonsterInfo.AttributeComponent == null)
			{
				return;
			}
			float currentValue = towerMergeHeadStateMonsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.Life);
			float currentValue2 = towerMergeHeadStateMonsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
			bool flag = currentValue != towerMergeHeadStateMonsterInfo.Hp || currentValue2 != towerMergeHeadStateMonsterInfo.HpMax;
			towerMergeHeadStateMonsterInfo.Hp = currentValue;
			towerMergeHeadStateMonsterInfo.HpMax = currentValue2;
			if (flag)
			{
				this.ReCalcTotalHp();
				this.DispatchHpChanged();
			}
		}

		// Token: 0x0603D69C RID: 251548 RVA: 0x00FA0018 File Offset: 0x00F9E218
		public void OnRemoveEntity(EntityHandle handle)
		{
			if (this.ListenMonsterRemoveMap.Count <= 0)
			{
				return;
			}
			TowerMergeHeadStateMonsterInfo towerMergeHeadStateMonsterInfo;
			if (!this.ListenMonsterRemoveMap.TryGetValue(handle.Id, out towerMergeHeadStateMonsterInfo))
			{
				return;
			}
			this.ListenMonsterRemoveMap.Remove(handle.Id);
			towerMergeHeadStateMonsterInfo.RemoveListener();
			towerMergeHeadStateMonsterInfo.EntityHandle = null;
			if (towerMergeHeadStateMonsterInfo.Hp > 0f)
			{
				this.ListenMonsterAddMap[towerMergeHeadStateMonsterInfo.CreatureDataId] = towerMergeHeadStateMonsterInfo;
			}
		}

		// Token: 0x0603D69D RID: 251549 RVA: 0x00FA0088 File Offset: 0x00F9E288
		public void OnMonsterHpChanged(int monsterInfoId)
		{
			if (this.Info == null)
			{
				return;
			}
			TowerMergeHeadStateMonsterInfo towerMergeHeadStateMonsterInfo;
			if (!this.Info.MonsterInfos.TryGetValue(monsterInfoId, out towerMergeHeadStateMonsterInfo))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "[Tower合并怪物血条]更新血量时MonsterInfoId错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("monsterInfoId", monsterInfoId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ReCalcTotalHp();
			this.DispatchHpChanged();
		}

		// Token: 0x0603D69E RID: 251550 RVA: 0x00FA00EC File Offset: 0x00F9E2EC
		private void TryAttachListener(TowerMergeHeadStateMonsterInfo monsterInfo)
		{
			if (monsterInfo.CreatureDataId <= 0L)
			{
				return;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(monsterInfo.CreatureDataId);
			if (entity != null && entity.Valid)
			{
				monsterInfo.EntityHandle = entity;
				this.AttachMonsterListener(monsterInfo);
				if (monsterInfo.AttributeComponent != null)
				{
					monsterInfo.Hp = monsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.Life);
					monsterInfo.HpMax = monsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
				}
				return;
			}
			if (monsterInfo.Hp > 0f)
			{
				this.ListenMonsterAddMap[monsterInfo.CreatureDataId] = monsterInfo;
			}
		}

		// Token: 0x0603D69F RID: 251551 RVA: 0x00FA017A File Offset: 0x00F9E37A
		private void AttachMonsterListener(TowerMergeHeadStateMonsterInfo monsterInfo)
		{
			if (!monsterInfo.AddListener())
			{
				return;
			}
			this.ListenMonsterRemoveMap[monsterInfo.EntityHandle.Id] = monsterInfo;
		}

		// Token: 0x0603D6A0 RID: 251552 RVA: 0x00FA019C File Offset: 0x00F9E39C
		private void ReCalcTotalHp()
		{
			if (this.Info == null)
			{
				return;
			}
			float num = 0f;
			float num2 = 0f;
			foreach (TowerMergeHeadStateMonsterInfo towerMergeHeadStateMonsterInfo in this.Info.MonsterInfos.Values)
			{
				num += towerMergeHeadStateMonsterInfo.Hp;
				num2 += towerMergeHeadStateMonsterInfo.HpMax;
			}
			bool flag = num > 0f;
			this.Info.TotalHp = num;
			this.Info.TotalHpMax = num2;
			if (this.Info.IsVisible != flag)
			{
				this.Info.IsVisible = flag;
				Singleton<EventSystem>.Instance.Emit<TowerMergeHeadStateInfo>(EEventName.BattleUiTowerMergeHeadStateVisibleChanged, this.Info);
			}
			if (!flag)
			{
				this.Clear();
			}
		}

		// Token: 0x0603D6A1 RID: 251553 RVA: 0x00FA0278 File Offset: 0x00F9E478
		private void DispatchHpChanged()
		{
			if (this.Info == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<TowerMergeHeadStateInfo>(EEventName.BattleUiTowerMergeHeadStateMonsterHpChanged, this.Info);
		}

		// Token: 0x0402282B RID: 141355
		[Nullable(2)]
		public TowerMergeHeadStateInfo Info;

		// Token: 0x0402282C RID: 141356
		private readonly Dictionary<long, TowerMergeHeadStateMonsterInfo> ListenMonsterAddMap = new Dictionary<long, TowerMergeHeadStateMonsterInfo>();

		// Token: 0x0402282D RID: 141357
		private readonly Dictionary<int, TowerMergeHeadStateMonsterInfo> ListenMonsterRemoveMap = new Dictionary<int, TowerMergeHeadStateMonsterInfo>();
	}
}
