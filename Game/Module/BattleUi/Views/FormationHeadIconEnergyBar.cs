using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006019 RID: 24601
	[NullableContext(1)]
	[Nullable(0)]
	public class FormationHeadIconEnergyBar
	{
		// Token: 0x0603DFDE RID: 253918 RVA: 0x00FD1AEC File Offset: 0x00FCFCEC
		public void InitParentItem(int index, UUIItem parentItem)
		{
			if (index >= this.ParentItemList.Length)
			{
				UUIItem[] array = new UUIItem[index + 1];
				for (int i = 0; i < this.ParentItemList.Length; i++)
				{
					array[i] = this.ParentItemList[i];
				}
				this.ParentItemList = array;
			}
			this.ParentItemList[index] = parentItem;
		}

		// Token: 0x0603DFDF RID: 253919 RVA: 0x00FD1B3C File Offset: 0x00FCFD3C
		public void RemoveEntity(int entityId)
		{
			HeadIconEnergyBarBase headIconEnergyBarBase;
			if (this.EnergyBarMap.Remove(entityId, out headIconEnergyBarBase))
			{
				headIconEnergyBarBase.Destroy(null);
				return;
			}
			this.DisableEntityIdSet.Remove(entityId);
		}

		// Token: 0x0603DFE0 RID: 253920 RVA: 0x00FD1B70 File Offset: 0x00FCFD70
		public void InitData(int position, FormationItemData formationItemData, [Nullable(2)] BattleUiRoleData roleData, int parentItemIndex)
		{
			int? num;
			if (roleData == null)
			{
				num = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				num = ((entityHandle != null) ? new int?(entityHandle.Id) : null);
			}
			int? num2 = num;
			if (num2 == null)
			{
				return;
			}
			if (this.DisableEntityIdSet.Contains(num2.Value))
			{
				return;
			}
			if (this.EnergyBarMap.ContainsKey(num2.Value))
			{
				this.RefreshVisible(num2.Value, roleData.IsCurEntity, parentItemIndex);
				return;
			}
			HeadIconEnergyBar? headIconEnergyBarConfig = roleData.HeadIconEnergyBarConfig;
			if (headIconEnergyBarConfig == null)
			{
				this.DisableEntityIdSet.Add(num2.Value);
				return;
			}
			int playerId = formationItemData.PlayerId;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			bool flag = playerId == id.GetValueOrDefault() & id != null;
			if (!headIconEnergyBarConfig.Value.FormationVisible && !flag)
			{
				this.DisableEntityIdSet.Add(num2.Value);
				return;
			}
			UUIItem parentItem = (parentItemIndex >= 0) ? this.ParentItemList[parentItemIndex] : this.ParentItemList[0];
			this.LoadByConfig(parentItem, roleData, num2.Value, headIconEnergyBarConfig.Value);
			this.RefreshVisible(num2.Value, roleData.IsCurEntity, -1);
		}

		// Token: 0x0603DFE1 RID: 253921 RVA: 0x00FD1CAC File Offset: 0x00FCFEAC
		public void RefreshVisible(int entityId, bool isCurEntity, int parentItemIndex = -1)
		{
			if (entityId == 0)
			{
				return;
			}
			HeadIconEnergyBarBase valueOrDefault = this.EnergyBarMap.GetValueOrDefault(entityId);
			if (valueOrDefault != null)
			{
				if (isCurEntity)
				{
					valueOrDefault.SetVisible(false, 1);
					return;
				}
				valueOrDefault.SetVisible(true, 1);
				if (parentItemIndex >= 0)
				{
					UUIItem valueOrDefault2 = this.ParentItemList.GetValueOrDefault(parentItemIndex);
					if (valueOrDefault2 != null)
					{
						valueOrDefault.ChangeParent(valueOrDefault2);
					}
				}
			}
		}

		// Token: 0x0603DFE2 RID: 253922 RVA: 0x00FD1CFC File Offset: 0x00FCFEFC
		public void Destroy()
		{
			foreach (HeadIconEnergyBarBase headIconEnergyBarBase in this.EnergyBarMap.Values)
			{
				headIconEnergyBarBase.Destroy(null);
			}
			this.EnergyBarMap.Clear();
			this.DisableEntityIdSet.Clear();
		}

		// Token: 0x0603DFE3 RID: 253923 RVA: 0x00FD1D68 File Offset: 0x00FCFF68
		public void Tick(float delta)
		{
			foreach (HeadIconEnergyBarBase headIconEnergyBarBase in this.EnergyBarMap.Values)
			{
				headIconEnergyBarBase.Tick(delta);
			}
		}

		// Token: 0x0603DFE4 RID: 253924 RVA: 0x00FD1DC0 File Offset: 0x00FCFFC0
		private void LoadByConfig(UUIItem parentItem, BattleUiRoleData roleData, int entityId, HeadIconEnergyBar config)
		{
			Func<HeadIconEnergyBarBase> func;
			HeadIconEnergyBarBase headIconEnergyBarBase = FormationHeadIconEnergyBar.EnergyBarClassMap.TryGetValue(config.Type, out func) ? func() : new HeadIconEnergyBarCommon();
			headIconEnergyBarBase.InitData(roleData, config);
			this.EnergyBarMap[entityId] = headIconEnergyBarBase;
			headIconEnergyBarBase.InitByPath(parentItem, config.PrefabPath);
			headIconEnergyBarBase.SetVisible(true, 0);
		}

		// Token: 0x0603DFE6 RID: 253926 RVA: 0x00FD1E48 File Offset: 0x00FD0048
		// Note: this type is marked as 'beforefieldinit'.
		static FormationHeadIconEnergyBar()
		{
			Dictionary<int, Func<HeadIconEnergyBarBase>> dictionary = new Dictionary<int, Func<HeadIconEnergyBarBase>>();
			dictionary[0] = (() => new HeadIconEnergyBarCommon());
			dictionary[1] = (() => new HeadIconEnergyBarFuLuoLuo());
			dictionary[2] = (() => new HeadIconEnergyBarJiaBeiLiNa());
			dictionary[3] = (() => new HeadIconEnergyBarDaniya());
			dictionary[4] = (() => new HeadIconEnergyBarXigelika());
			dictionary[5] = (() => new HeadIconEnergyBarRuibeika());
			dictionary[6] = (() => new HeadIconEnergyBarSuisui());
			FormationHeadIconEnergyBar.EnergyBarClassMap = dictionary;
		}

		// Token: 0x04022C38 RID: 142392
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, Func<HeadIconEnergyBarBase>> EnergyBarClassMap;

		// Token: 0x04022C39 RID: 142393
		private UUIItem[] ParentItemList = Array.Empty<UUIItem>();

		// Token: 0x04022C3A RID: 142394
		private readonly Dictionary<int, HeadIconEnergyBarBase> EnergyBarMap = new Dictionary<int, HeadIconEnergyBarBase>();

		// Token: 0x04022C3B RID: 142395
		private readonly HashSet<int> DisableEntityIdSet = new HashSet<int>();

		// Token: 0x0200C0C3 RID: 49347
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403B58D RID: 243085
			Default,
			// Token: 0x0403B58E RID: 243086
			RoleForeground
		}

		// Token: 0x0200C0C4 RID: 49348
		[NullableContext(0)]
		private enum EHeadIconEnergyBarType
		{
			// Token: 0x0403B590 RID: 243088
			Common,
			// Token: 0x0403B591 RID: 243089
			FuLuoLuo,
			// Token: 0x0403B592 RID: 243090
			JiaBeiLiNa,
			// Token: 0x0403B593 RID: 243091
			Daniya,
			// Token: 0x0403B594 RID: 243092
			Xigelika,
			// Token: 0x0403B595 RID: 243093
			Ruibeika,
			// Token: 0x0403B596 RID: 243094
			Suisui
		}
	}
}
