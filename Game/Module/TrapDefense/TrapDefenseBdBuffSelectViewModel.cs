using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E01 RID: 19969
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdBuffSelectViewModel
	{
		// Token: 0x06033A24 RID: 211492 RVA: 0x00CE69E0 File Offset: 0x00CE4BE0
		public static TrapDefenseBdBuffSelectViewModel Create(TrapDefenseModel model)
		{
			return new TrapDefenseBdBuffSelectViewModel
			{
				Model = model
			};
		}

		// Token: 0x06033A25 RID: 211493 RVA: 0x00CE69EE File Offset: 0x00CE4BEE
		private TrapDefenseBdBuffSelectViewModel()
		{
		}

		// Token: 0x06033A26 RID: 211494 RVA: 0x00CE6A14 File Offset: 0x00CE4C14
		public bool SetBuffList(List<int> idList, int? selectId = null)
		{
			this.BdBuffDataList.Clear();
			foreach (int key in idList)
			{
				TrapDefenseBdBuffData trapDefenseBdBuffData;
				this.Model.RougeModeData.BdBuffDataMap.TryGetValue(key, out trapDefenseBdBuffData);
				if (trapDefenseBdBuffData != null)
				{
					this.BdBuffDataList.Add(trapDefenseBdBuffData);
				}
			}
			this.SetSelectBuffId(selectId);
			return true;
		}

		// Token: 0x06033A27 RID: 211495 RVA: 0x00CE6A98 File Offset: 0x00CE4C98
		public void SetSelectBuffId(int? id)
		{
			TrapDefenseBdBuffData selectBuff = this.BdBuffDataList.Find(delegate(TrapDefenseBdBuffData data)
			{
				int id2 = data.Id;
				int? id3 = id;
				return id2 == id3.GetValueOrDefault() & id3 != null;
			});
			this.SetSelectBuff(selectBuff);
		}

		// Token: 0x06033A28 RID: 211496 RVA: 0x00CE6AD4 File Offset: 0x00CE4CD4
		[NullableContext(2)]
		public void SetSelectBuff(TrapDefenseBdBuffData buff)
		{
			TrapDefenseBdBuffData curSelectBdBuffData = this.CurSelectBdBuffData;
			if (curSelectBdBuffData != null)
			{
				curSelectBdBuffData.GetBelongBdData().SetPreAddedBuff(null);
			}
			this.CurSelectBdBuffData = buff;
			if (buff != null)
			{
				buff.GetBelongBdData().SetPreAddedBuff(buff);
			}
			if (buff != null)
			{
				Singleton<EventSystem>.Instance.Emit<TrapDefenseBdBuffData, TrapDefenseBdData>(EEventName.TrapDefenseBdBuffSelectChange, buff, buff.GetBelongBdData());
			}
		}

		// Token: 0x06033A29 RID: 211497 RVA: 0x00CE6B28 File Offset: 0x00CE4D28
		public List<TrapDefenseBdData> GetShowBdDataList()
		{
			TrapDefenseLevelData curInstToLevelData = this.Model.GetCurInstToLevelData();
			return ((curInstToLevelData != null) ? curInstToLevelData.GetShowBdList() : null) ?? this.Model.RougeModeData.BdDataListIgnoreZero;
		}

		// Token: 0x06033A2A RID: 211498 RVA: 0x00CE6B55 File Offset: 0x00CE4D55
		public int GetRefreshBuffCostId()
		{
			return ConfigBase<TrapDefenseConfig>.Instance.GetBattleGoldToItemId();
		}

		// Token: 0x06033A2B RID: 211499 RVA: 0x00CE6B61 File Offset: 0x00CE4D61
		public long GetRefreshBuffCostRemainNum()
		{
			return this.Model.BattleData.GetGoldNum();
		}

		// Token: 0x06033A2C RID: 211500 RVA: 0x00CE6B73 File Offset: 0x00CE4D73
		public void SetRefreshBuffCostNum(int num)
		{
			this.RefreshBuffCostNum = num;
		}

		// Token: 0x06033A2D RID: 211501 RVA: 0x00CE6B7C File Offset: 0x00CE4D7C
		public void SetMaxRefreshCount(int count)
		{
			this.MaxRefreshCount = count;
		}

		// Token: 0x06033A2E RID: 211502 RVA: 0x00CE6B85 File Offset: 0x00CE4D85
		public void SetRemainRefreshCount(int count)
		{
			this.RemainRefreshCount = count;
		}

		// Token: 0x06033A2F RID: 211503 RVA: 0x00CE6B90 File Offset: 0x00CE4D90
		public string GetRefreshBuffCostIconPath(int? id)
		{
			int itemConfigId = id ?? this.GetRefreshBuffCostId();
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemConfigId);
			return ((itemConfig != null) ? itemConfig.GetValueOrDefault().IconSmall : null) ?? itemConfigId.ToString();
		}

		// Token: 0x06033A30 RID: 211504 RVA: 0x00CE6BEC File Offset: 0x00CE4DEC
		public bool RefreshBuffIsEnoughCost(int? costNum = null)
		{
			long refreshBuffCostRemainNum = this.GetRefreshBuffCostRemainNum();
			int num = costNum ?? this.RefreshBuffCostNum;
			return refreshBuffCostRemainNum >= (long)num;
		}

		// Token: 0x06033A31 RID: 211505 RVA: 0x00CE6C21 File Offset: 0x00CE4E21
		public void OnOpenView()
		{
			this.ShowingViewProcess = true;
		}

		// Token: 0x06033A32 RID: 211506 RVA: 0x00CE6C2C File Offset: 0x00CE4E2C
		public void OnViewClose()
		{
			if (this.BdBuffDataList.Count <= 0)
			{
				this.Model.BdBuffSelectProcessFinish();
				return;
			}
			if (this.CurSelectBdBuffData == null)
			{
				return;
			}
			this.CurSelectBdBuffData.GetBelongBdData().SetPreAddedBuff(null);
			if (!this.CurSelectBdBuffData.IsStrengthenFinish())
			{
				this.Model.BdBuffSelectProcessFinish();
			}
		}

		// Token: 0x06033A33 RID: 211507 RVA: 0x00CE6C85 File Offset: 0x00CE4E85
		public void ViewProcessFinish()
		{
			this.ShowingViewProcess = false;
		}

		// Token: 0x06033A34 RID: 211508 RVA: 0x00CE6C90 File Offset: 0x00CE4E90
		[NullableContext(0)]
		public UniTask<bool> RequestSureBuffSelect()
		{
			TrapDefenseBdBuffSelectViewModel.<RequestSureBuffSelect>d__24 <RequestSureBuffSelect>d__;
			<RequestSureBuffSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestSureBuffSelect>d__.<>4__this = this;
			<RequestSureBuffSelect>d__.<>1__state = -1;
			<RequestSureBuffSelect>d__.<>t__builder.Start<TrapDefenseBdBuffSelectViewModel.<RequestSureBuffSelect>d__24>(ref <RequestSureBuffSelect>d__);
			return <RequestSureBuffSelect>d__.<>t__builder.Task;
		}

		// Token: 0x06033A35 RID: 211509 RVA: 0x00CE6CD4 File Offset: 0x00CE4ED4
		[NullableContext(0)]
		public UniTask<bool> RequestUpdateBdBuffList()
		{
			TrapDefenseBdBuffSelectViewModel.<RequestUpdateBdBuffList>d__25 <RequestUpdateBdBuffList>d__;
			<RequestUpdateBdBuffList>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestUpdateBdBuffList>d__.<>1__state = -1;
			<RequestUpdateBdBuffList>d__.<>t__builder.Start<TrapDefenseBdBuffSelectViewModel.<RequestUpdateBdBuffList>d__25>(ref <RequestUpdateBdBuffList>d__);
			return <RequestUpdateBdBuffList>d__.<>t__builder.Task;
		}

		// Token: 0x0401DE98 RID: 122520
		public TrapDefenseModel Model;

		// Token: 0x0401DE99 RID: 122521
		public List<TrapDefenseBdBuffData> BdBuffDataList = new List<TrapDefenseBdBuffData>();

		// Token: 0x0401DE9A RID: 122522
		[Nullable(2)]
		public TrapDefenseBdBuffData CurSelectBdBuffData;

		// Token: 0x0401DE9B RID: 122523
		public int MaxRefreshCount = 1;

		// Token: 0x0401DE9C RID: 122524
		public int RemainRefreshCount;

		// Token: 0x0401DE9D RID: 122525
		public int RefreshBuffCostNum;

		// Token: 0x0401DE9E RID: 122526
		public bool ShowingViewProcess;

		// Token: 0x0401DE9F RID: 122527
		public List<List<int>> BackupIdList = new List<List<int>>();
	}
}
