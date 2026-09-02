using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F7B RID: 24443
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiMergeHeadStateData
	{
		// Token: 0x0603D594 RID: 251284 RVA: 0x00F9A348 File Offset: 0x00F98548
		public void Init()
		{
		}

		// Token: 0x0603D595 RID: 251285 RVA: 0x00F9A34C File Offset: 0x00F9854C
		public void OnLeaveLevel()
		{
			if (this.ListenMonsterRemoveMap.Count <= 0)
			{
				return;
			}
			foreach (MergeHeadStateMonsterInfo mergeHeadStateMonsterInfo in this.ListenMonsterRemoveMap.Values)
			{
				mergeHeadStateMonsterInfo.EntityHandle = null;
				this.RemoveMonsterListener(mergeHeadStateMonsterInfo);
				MergeHeadStateInfo valueOrDefault = this.InfoMap.GetValueOrDefault(mergeHeadStateMonsterInfo.Id);
				if (valueOrDefault == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.CFT;
					string message = "合并怪物血条移除实体时InfoId错误";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", mergeHeadStateMonsterInfo.Id);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				if (mergeHeadStateMonsterInfo.HasFightTag)
				{
					mergeHeadStateMonsterInfo.HasFightTag = false;
					valueOrDefault.IsVisible = false;
				}
			}
			this.ListenMonsterRemoveMap.Clear();
		}

		// Token: 0x0603D596 RID: 251286 RVA: 0x00F9A424 File Offset: 0x00F98624
		public void Clear()
		{
			foreach (MergeHeadStateInfo info in this.InfoMap.Values)
			{
				this.DeleteMergeHeadStateInfo(info);
			}
			this.InfoMap.Clear();
			this.ListenMonsterAddMap.Clear();
			this.ListenMonsterRemoveMap.Clear();
		}

		// Token: 0x0603D597 RID: 251287 RVA: 0x00F9A4A0 File Offset: 0x00F986A0
		[NullableContext(2)]
		public void UpdateProgress(long treeId, int nodeId, MonsterCreatorProgress monsterCreator, string monsterGroupName, IMonsterMergedHpBarSettings monsterMergedHpBarSettings = null)
		{
			if (monsterCreator == null)
			{
				return;
			}
			foreach (MergeHeadStateInfo mergeHeadStateInfo in this.InfoMap.Values)
			{
				long? treeId2 = mergeHeadStateInfo.TreeId;
				if ((treeId2.GetValueOrDefault() == treeId & treeId2 != null) && mergeHeadStateInfo.NodeId == nodeId)
				{
					this.UpdateMergeHeadStateInfo(mergeHeadStateInfo, monsterCreator);
					return;
				}
			}
			this.CreateMergeHeadStateInfo(treeId, nodeId, monsterCreator, monsterGroupName, monsterMergedHpBarSettings);
		}

		// Token: 0x0603D598 RID: 251288 RVA: 0x00F9A534 File Offset: 0x00F98734
		public void RemoveTree(long treeId)
		{
			foreach (MergeHeadStateInfo mergeHeadStateInfo in this.InfoMap.Values)
			{
				long? treeId2 = mergeHeadStateInfo.TreeId;
				if (treeId2.GetValueOrDefault() == treeId & treeId2 != null)
				{
					this.DeleteMergeHeadStateInfo(mergeHeadStateInfo);
				}
			}
		}

		// Token: 0x0603D599 RID: 251289 RVA: 0x00F9A5AC File Offset: 0x00F987AC
		public void RemoveNode(long treeId, int nodeId)
		{
			foreach (MergeHeadStateInfo mergeHeadStateInfo in this.InfoMap.Values)
			{
				long? treeId2 = mergeHeadStateInfo.TreeId;
				if ((treeId2.GetValueOrDefault() == treeId & treeId2 != null) && mergeHeadStateInfo.NodeId == nodeId)
				{
					this.DeleteMergeHeadStateInfo(mergeHeadStateInfo);
					break;
				}
			}
		}

		// Token: 0x0603D59A RID: 251290 RVA: 0x00F9A62C File Offset: 0x00F9882C
		public void OnAddEntity(EntityHandle handle)
		{
			if (this.ListenMonsterAddMap.Count <= 0)
			{
				return;
			}
			int pbDataIdByEntity = ModelBase<CreatureModel>.Instance.GetPbDataIdByEntity(handle);
			MergeHeadStateMonsterInfo valueOrDefault = this.ListenMonsterAddMap.GetValueOrDefault(pbDataIdByEntity);
			if (valueOrDefault == null)
			{
				return;
			}
			this.ListenMonsterAddMap.Remove(pbDataIdByEntity);
			valueOrDefault.EntityHandle = handle;
			this.AddMonsterListener(valueOrDefault);
			MergeHeadStateInfo valueOrDefault2 = this.InfoMap.GetValueOrDefault(valueOrDefault.Id);
			if (valueOrDefault2 == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "合并怪物血条添加实体时InfoId错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", valueOrDefault.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			bool flag = false;
			if (valueOrDefault.AttributeComponent != null)
			{
				float currentValue = valueOrDefault.AttributeComponent.GetCurrentValue(EAttributeType.Life);
				float currentValue2 = valueOrDefault.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
				if (currentValue != valueOrDefault.Hp || currentValue2 != valueOrDefault.HpMax)
				{
					float num = 0f;
					if (valueOrDefault.HpMax > 0f)
					{
						num = valueOrDefault.Hp / valueOrDefault.HpMax;
					}
					float num2 = 0f;
					if (currentValue2 > 0f)
					{
						num2 = currentValue / currentValue2;
					}
					valueOrDefault2.TotalHp += (float)((int)((num2 - num) * valueOrDefault.BaseLife));
					valueOrDefault.Hp = currentValue;
					valueOrDefault.HpMax = currentValue2;
					flag = true;
				}
			}
			if (valueOrDefault2.IsVisible)
			{
				if (flag)
				{
					this.DispatchHealthChangeEvent(valueOrDefault2);
				}
				return;
			}
			if (valueOrDefault.HasFightTag)
			{
				valueOrDefault2.IsVisible = true;
				this.DispatchVisibleChangeEvent(valueOrDefault2);
			}
		}

		// Token: 0x0603D59B RID: 251291 RVA: 0x00F9A794 File Offset: 0x00F98994
		public void OnRemoveEntity(EntityHandle handle)
		{
			if (this.ListenMonsterRemoveMap.Count <= 0)
			{
				return;
			}
			MergeHeadStateMonsterInfo valueOrDefault = this.ListenMonsterRemoveMap.GetValueOrDefault(handle.Id);
			if (valueOrDefault == null)
			{
				return;
			}
			this.ListenMonsterRemoveMap.Remove(handle.Id);
			valueOrDefault.EntityHandle = null;
			this.RemoveMonsterListener(valueOrDefault);
			MergeHeadStateInfo valueOrDefault2 = this.InfoMap.GetValueOrDefault(valueOrDefault.Id);
			if (valueOrDefault2 == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "合并怪物血条移除实体时InfoId错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", valueOrDefault.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (valueOrDefault.HasFightTag)
			{
				valueOrDefault.HasFightTag = false;
				this.UpdateVisible(valueOrDefault2, true);
			}
		}

		// Token: 0x0603D59C RID: 251292 RVA: 0x00F9A844 File Offset: 0x00F98A44
		[NullableContext(2)]
		private void CreateMergeHeadStateInfo(long treeId, int nodeId, [Nullable(1)] MonsterCreatorProgress monsterCreator, string monsterGroupName, IMonsterMergedHpBarSettings monsterMergedHpBarSettings)
		{
			MergeHeadStateInfo mergeHeadStateInfo = new MergeHeadStateInfo();
			this.IncId++;
			mergeHeadStateInfo.Id = this.IncId;
			mergeHeadStateInfo.TreeId = new long?(treeId);
			mergeHeadStateInfo.NodeId = nodeId;
			mergeHeadStateInfo.MonsterGroupName = (monsterGroupName ?? string.Empty);
			mergeHeadStateInfo.MonsterMergedHpBarSettings = monsterMergedHpBarSettings;
			foreach (MonsterCreatorProgressSlot monsterCreatorProgressSlot in monsterCreator.Slots)
			{
				foreach (SceneMonsterCreatedMonsterInfo sceneMonsterCreatedMonsterInfo in monsterCreatorProgressSlot.MonsterInfo)
				{
					MergeHeadStateMonsterInfo mergeHeadStateMonsterInfo = new MergeHeadStateMonsterInfo();
					mergeHeadStateMonsterInfo.Id = mergeHeadStateInfo.Id;
					mergeHeadStateMonsterInfo.PbDataId = sceneMonsterCreatedMonsterInfo.EntityConfigId;
					mergeHeadStateMonsterInfo.IsDead = (sceneMonsterCreatedMonsterInfo.State == 2);
					mergeHeadStateMonsterInfo.BaseLife = (float)((int)sceneMonsterCreatedMonsterInfo.BaseLife);
					mergeHeadStateMonsterInfo.EntityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(mergeHeadStateMonsterInfo.PbDataId);
					EntityHandle entityHandle = mergeHeadStateMonsterInfo.EntityHandle;
					if (entityHandle != null && entityHandle.Valid)
					{
						this.AddMonsterListener(mergeHeadStateMonsterInfo);
						if (mergeHeadStateMonsterInfo.AttributeComponent != null)
						{
							mergeHeadStateMonsterInfo.Hp = mergeHeadStateMonsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.Life);
							mergeHeadStateMonsterInfo.HpMax = mergeHeadStateMonsterInfo.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
						}
					}
					else
					{
						if (!mergeHeadStateMonsterInfo.IsDead)
						{
							this.ListenMonsterAddMap[mergeHeadStateMonsterInfo.PbDataId] = mergeHeadStateMonsterInfo;
							mergeHeadStateMonsterInfo.Hp = mergeHeadStateMonsterInfo.BaseLife;
						}
						else
						{
							mergeHeadStateMonsterInfo.Hp = 0f;
						}
						mergeHeadStateMonsterInfo.HpMax = mergeHeadStateMonsterInfo.BaseLife;
					}
					mergeHeadStateInfo.MonsterInfos[mergeHeadStateMonsterInfo.PbDataId] = mergeHeadStateMonsterInfo;
				}
			}
			foreach (MergeHeadStateMonsterInfo mergeHeadStateMonsterInfo2 in mergeHeadStateInfo.MonsterInfos.Values)
			{
				if (mergeHeadStateMonsterInfo2.HpMax > 0f)
				{
					mergeHeadStateInfo.TotalHp += (float)((int)((double)mergeHeadStateMonsterInfo2.Hp / (double)mergeHeadStateMonsterInfo2.HpMax * (double)mergeHeadStateMonsterInfo2.BaseLife));
				}
				mergeHeadStateInfo.TotalHpMax += mergeHeadStateMonsterInfo2.BaseLife;
			}
			this.UpdateVisible(mergeHeadStateInfo, false);
			this.InfoMap[mergeHeadStateInfo.Id] = mergeHeadStateInfo;
			if (mergeHeadStateInfo.IsVisible)
			{
				this.DispatchVisibleChangeEvent(mergeHeadStateInfo);
			}
		}

		// Token: 0x0603D59D RID: 251293 RVA: 0x00F9AAF4 File Offset: 0x00F98CF4
		private void UpdateMergeHeadStateInfo(MergeHeadStateInfo info, MonsterCreatorProgress monsterCreator)
		{
			foreach (MonsterCreatorProgressSlot monsterCreatorProgressSlot in monsterCreator.Slots)
			{
				foreach (SceneMonsterCreatedMonsterInfo sceneMonsterCreatedMonsterInfo in monsterCreatorProgressSlot.MonsterInfo)
				{
					MergeHeadStateMonsterInfo valueOrDefault = info.MonsterInfos.GetValueOrDefault(sceneMonsterCreatedMonsterInfo.EntityConfigId);
					if (valueOrDefault == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "合并怪物血条更新怪物数据时与缓存对不上", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					else if (!valueOrDefault.IsDead)
					{
						valueOrDefault.IsDead = (sceneMonsterCreatedMonsterInfo.State == 2);
						if (valueOrDefault.IsDead)
						{
							this.RemoveMonsterListener(valueOrDefault);
							if (valueOrDefault.Hp != 0f || valueOrDefault.HpMax != valueOrDefault.BaseLife)
							{
								if (valueOrDefault.HpMax > 0f)
								{
									info.TotalHp -= (float)((int)((double)valueOrDefault.Hp / (double)valueOrDefault.HpMax * (double)valueOrDefault.BaseLife));
								}
								valueOrDefault.Hp = 0f;
								valueOrDefault.HpMax = valueOrDefault.BaseLife;
								this.DispatchHealthChangeEvent(info);
							}
						}
					}
				}
			}
		}

		// Token: 0x0603D59E RID: 251294 RVA: 0x00F9AC60 File Offset: 0x00F98E60
		private void DeleteMergeHeadStateInfo(MergeHeadStateInfo info)
		{
			foreach (MergeHeadStateMonsterInfo mergeHeadStateMonsterInfo in info.MonsterInfos.Values)
			{
				mergeHeadStateMonsterInfo.RemoveListener();
				if (mergeHeadStateMonsterInfo.EntityHandle != null)
				{
					this.ListenMonsterRemoveMap.Remove(mergeHeadStateMonsterInfo.EntityHandle.Id);
				}
				else
				{
					this.ListenMonsterAddMap.Remove(mergeHeadStateMonsterInfo.PbDataId);
				}
			}
			if (info.IsVisible)
			{
				info.IsVisible = false;
				this.DispatchVisibleChangeEvent(info);
			}
			this.InfoMap.Remove(info.Id);
		}

		// Token: 0x0603D59F RID: 251295 RVA: 0x00F9AD14 File Offset: 0x00F98F14
		private void AddMonsterListener(MergeHeadStateMonsterInfo monsterInfo)
		{
			if (!monsterInfo.AddListener())
			{
				return;
			}
			this.ListenMonsterRemoveMap[monsterInfo.EntityHandle.Id] = monsterInfo;
		}

		// Token: 0x0603D5A0 RID: 251296 RVA: 0x00F9AD36 File Offset: 0x00F98F36
		private void RemoveMonsterListener(MergeHeadStateMonsterInfo monsterInfo)
		{
			monsterInfo.RemoveListener();
			if (!monsterInfo.IsDead)
			{
				this.ListenMonsterAddMap[monsterInfo.PbDataId] = monsterInfo;
			}
		}

		// Token: 0x0603D5A1 RID: 251297 RVA: 0x00F9AD58 File Offset: 0x00F98F58
		public void OnMonsterFightTagChange(int id, bool hasFightTag)
		{
			MergeHeadStateInfo valueOrDefault = this.InfoMap.GetValueOrDefault(id);
			if (valueOrDefault == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "合并怪物血条更新进战时InfoId错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (valueOrDefault.IsVisible == hasFightTag)
			{
				return;
			}
			if (hasFightTag)
			{
				valueOrDefault.IsVisible = true;
				this.DispatchVisibleChangeEvent(valueOrDefault);
				return;
			}
			this.UpdateVisible(valueOrDefault, true);
		}

		// Token: 0x0603D5A2 RID: 251298 RVA: 0x00F9ADC8 File Offset: 0x00F98FC8
		public void UpdateVisible(MergeHeadStateInfo info, bool dispatchEvent)
		{
			bool flag = false;
			using (Dictionary<int, MergeHeadStateMonsterInfo>.ValueCollection.Enumerator enumerator = info.MonsterInfos.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.HasFightTag)
					{
						flag = true;
						break;
					}
				}
			}
			if (info.IsVisible != flag)
			{
				info.IsVisible = flag;
				if (dispatchEvent)
				{
					this.DispatchVisibleChangeEvent(info);
				}
			}
		}

		// Token: 0x0603D5A3 RID: 251299 RVA: 0x00F9AE40 File Offset: 0x00F99040
		private void DispatchVisibleChangeEvent(MergeHeadStateInfo info)
		{
			Singleton<EventSystem>.Instance.Emit<MergeHeadStateInfo>(EEventName.BattleUiMergeHeadStateVisibleChanged, info);
		}

		// Token: 0x0603D5A4 RID: 251300 RVA: 0x00F9AE54 File Offset: 0x00F99054
		public void OnMonsterHealthChange(int id, float hpChange)
		{
			MergeHeadStateInfo valueOrDefault = this.InfoMap.GetValueOrDefault(id);
			if (valueOrDefault == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "合并怪物血条更新血量时InfoId错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			valueOrDefault.TotalHp += hpChange;
			this.DispatchHealthChangeEvent(valueOrDefault);
		}

		// Token: 0x0603D5A5 RID: 251301 RVA: 0x00F9AEB3 File Offset: 0x00F990B3
		private void DispatchHealthChangeEvent(MergeHeadStateInfo info)
		{
			Singleton<EventSystem>.Instance.Emit<MergeHeadStateInfo>(EEventName.BattleUiMergeHeadStateHealthChanged, info);
		}

		// Token: 0x04022741 RID: 141121
		private int IncId;

		// Token: 0x04022742 RID: 141122
		public Dictionary<int, MergeHeadStateInfo> InfoMap = new Dictionary<int, MergeHeadStateInfo>();

		// Token: 0x04022743 RID: 141123
		public Dictionary<int, MergeHeadStateMonsterInfo> ListenMonsterAddMap = new Dictionary<int, MergeHeadStateMonsterInfo>();

		// Token: 0x04022744 RID: 141124
		public Dictionary<int, MergeHeadStateMonsterInfo> ListenMonsterRemoveMap = new Dictionary<int, MergeHeadStateMonsterInfo>();
	}
}
