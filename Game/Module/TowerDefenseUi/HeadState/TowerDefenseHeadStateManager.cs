using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseUi.HeadState
{
	// Token: 0x02004E7E RID: 20094
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseHeadStateManager
	{
		// Token: 0x06033E9E RID: 212638 RVA: 0x00CFDE90 File Offset: 0x00CFC090
		public void Init()
		{
			this.MaxDistanceSquared = (double)ConfigCommonParamById.GetIntConfig("TowerDefenseHeadStateShowMaxDistance").Value;
			this.MinDistanceSquared = (double)ConfigCommonParamById.GetIntConfig("TowerDefenseHeadStateShowMinDistance").Value;
		}

		// Token: 0x06033E9F RID: 212639 RVA: 0x00CFDECF File Offset: 0x00CFC0CF
		public void OnWorldDone()
		{
			this.LoadDynamicBatchView();
		}

		// Token: 0x06033EA0 RID: 212640 RVA: 0x00CFDED7 File Offset: 0x00CFC0D7
		public void LoadDynamicBatchView()
		{
			this.DynamicBatchView = new TowerDefenseHeadStateDynamicBatchView();
			this.DynamicBatchView.CreateThenShowByResourceIdAsync("UiItem_TowerDefenseHPDynamicBatch", Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, true).Forget();
		}

		// Token: 0x06033EA1 RID: 212641 RVA: 0x00CFDF04 File Offset: 0x00CFC104
		public void AddEntity(int entityId, global::Vector position, int maxHp, int hp, int shield)
		{
			if (this.HeadStateMap.ContainsKey(entityId))
			{
				return;
			}
			TowerDefenseHeadStateData towerDefenseHeadStateData = new TowerDefenseHeadStateData();
			towerDefenseHeadStateData.EntityId = entityId;
			towerDefenseHeadStateData.UpdatePosition(position);
			towerDefenseHeadStateData.UpdateHp(hp, maxHp, shield);
			this.HeadStateMap[entityId] = towerDefenseHeadStateData;
			this.CreateList.Add(towerDefenseHeadStateData);
			this.ModifyHpList.Add(towerDefenseHeadStateData);
		}

		// Token: 0x06033EA2 RID: 212642 RVA: 0x00CFDF68 File Offset: 0x00CFC168
		public void HandleMsg(int entityId, global::Vector position, int maxHp, int hp, int shield)
		{
			TowerDefenseHeadStateData towerDefenseHeadStateData;
			if (!this.HeadStateMap.TryGetValue(entityId, out towerDefenseHeadStateData))
			{
				this.AddEntity(entityId, position, maxHp, hp, shield);
				return;
			}
			towerDefenseHeadStateData.UpdatePosition(position);
			if (towerDefenseHeadStateData.UpdateHp(hp, maxHp, shield))
			{
				this.ModifyHpList.Add(towerDefenseHeadStateData);
			}
		}

		// Token: 0x06033EA3 RID: 212643 RVA: 0x00CFDFB4 File Offset: 0x00CFC1B4
		public void RemoveEntity(int entityId)
		{
			TowerDefenseHeadStateData item;
			if (this.HeadStateMap.Remove(entityId, out item))
			{
				this.DestroyList.Add(item);
			}
		}

		// Token: 0x06033EA4 RID: 212644 RVA: 0x00CFDFE0 File Offset: 0x00CFC1E0
		public void Tick(float delta)
		{
			foreach (TowerDefenseHeadStateData towerDefenseHeadStateData in this.CreateList)
			{
				towerDefenseHeadStateData.ScaleCurve = this.GetScaleCurve();
			}
			this.CreateList.Clear();
			foreach (TowerDefenseHeadStateData towerDefenseHeadStateData2 in this.ModifyHpList)
			{
				towerDefenseHeadStateData2.RefreshHpAndShield();
			}
			this.ModifyHpList.Clear();
			this.SortList.Clear();
			global::Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
			foreach (TowerDefenseHeadStateData towerDefenseHeadStateData3 in this.HeadStateMap.Values)
			{
				towerDefenseHeadStateData3.RefreshDistance(cameraLocation);
				if (towerDefenseHeadStateData3.DistanceSquared < this.MaxDistanceSquared && towerDefenseHeadStateData3.DistanceSquared > this.MinDistanceSquared)
				{
					towerDefenseHeadStateData3.SetVisible(true);
					towerDefenseHeadStateData3.Tick(delta);
					this.SortList.Add(towerDefenseHeadStateData3);
				}
				else
				{
					towerDefenseHeadStateData3.SetVisible(false);
				}
			}
			foreach (TowerDefenseHeadStateData towerDefenseHeadStateData4 in this.DestroyList)
			{
				towerDefenseHeadStateData4.Destroy();
			}
			this.DestroyList.Clear();
			TowerDefenseHeadStateDynamicBatchView dynamicBatchView = this.DynamicBatchView;
			if (dynamicBatchView != null && dynamicBatchView.GetIsEnable())
			{
				this.DynamicBatchView.ClearDynamicBatchMesh();
				if (this.SortList.Count > 0)
				{
					this.SortList.Sort((TowerDefenseHeadStateData a, TowerDefenseHeadStateData b) => b.DistanceSquared.CompareTo(a.DistanceSquared));
					int num = 15;
					for (int i = Math.Max(this.SortList.Count - num, 0); i < this.SortList.Count; i++)
					{
						this.DynamicBatchView.AddToDynamicBatchMesh(this.SortList[i]);
					}
					this.SortList.Clear();
				}
			}
		}

		// Token: 0x06033EA5 RID: 212645 RVA: 0x00CFE224 File Offset: 0x00CFC424
		public UCurveFloat GetScaleCurve()
		{
			if (this.ScaleCurve == null)
			{
				string stringConfig = ConfigCommonParamById.GetStringConfig("HeadStateScaleCurvePath");
				this.ScaleCurve = Singleton<ResourceSystem>.Instance.Load<UCurveFloat>(stringConfig, "Ui.TrapDefenseUi");
			}
			return this.ScaleCurve;
		}

		// Token: 0x06033EA6 RID: 212646 RVA: 0x00CFE260 File Offset: 0x00CFC460
		public void Clear()
		{
			this.CreateList.Clear();
			this.ModifyHpList.Clear();
			foreach (TowerDefenseHeadStateData towerDefenseHeadStateData in this.HeadStateMap.Values)
			{
				towerDefenseHeadStateData.Destroy();
			}
			this.HeadStateMap.Clear();
			foreach (TowerDefenseHeadStateData towerDefenseHeadStateData2 in this.DestroyList)
			{
				towerDefenseHeadStateData2.Destroy();
			}
			this.DestroyList.Clear();
			this.ScaleCurve = null;
			TowerDefenseHeadStateDynamicBatchView dynamicBatchView = this.DynamicBatchView;
			if (dynamicBatchView != null)
			{
				dynamicBatchView.Destroy(null);
			}
			this.DynamicBatchView = null;
		}

		// Token: 0x0401E062 RID: 122978
		private readonly Dictionary<int, TowerDefenseHeadStateData> HeadStateMap = new Dictionary<int, TowerDefenseHeadStateData>();

		// Token: 0x0401E063 RID: 122979
		private readonly List<TowerDefenseHeadStateData> CreateList = new List<TowerDefenseHeadStateData>();

		// Token: 0x0401E064 RID: 122980
		private readonly List<TowerDefenseHeadStateData> ModifyHpList = new List<TowerDefenseHeadStateData>();

		// Token: 0x0401E065 RID: 122981
		private readonly List<TowerDefenseHeadStateData> DestroyList = new List<TowerDefenseHeadStateData>();

		// Token: 0x0401E066 RID: 122982
		private readonly List<TowerDefenseHeadStateData> SortList = new List<TowerDefenseHeadStateData>();

		// Token: 0x0401E067 RID: 122983
		[Nullable(2)]
		private UCurveFloat ScaleCurve;

		// Token: 0x0401E068 RID: 122984
		private double MaxDistanceSquared;

		// Token: 0x0401E069 RID: 122985
		private double MinDistanceSquared;

		// Token: 0x0401E06A RID: 122986
		[Nullable(2)]
		private TowerDefenseHeadStateDynamicBatchView DynamicBatchView;
	}
}
