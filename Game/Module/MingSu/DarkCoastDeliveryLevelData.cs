using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x0200572F RID: 22319
	public class DarkCoastDeliveryLevelData
	{
		// Token: 0x06038CDE RID: 232670 RVA: 0x00E63DEB File Offset: 0x00E61FEB
		public DarkCoastDeliveryLevelData(DarkCoastDelivery config, int goal, int dropId)
		{
			this.Config = config;
			this.Id = config.Id;
			this.Goal = goal;
			this.DropId = dropId;
		}

		// Token: 0x06038CDF RID: 232671 RVA: 0x00E63E15 File Offset: 0x00E62015
		private void InitRewardItems()
		{
			this.RewardItems = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.DropId);
		}

		// Token: 0x06038CE0 RID: 232672 RVA: 0x00E63E2D File Offset: 0x00E6202D
		public void SetDefeatedGuardState(bool state)
		{
			this.DefeatedGuard = state;
		}

		// Token: 0x06038CE1 RID: 232673 RVA: 0x00E63E36 File Offset: 0x00E62036
		public void SetReceivedGuardRewardState(bool state)
		{
			this.ReceivedGuardReward = state;
		}

		// Token: 0x06038CE2 RID: 232674 RVA: 0x00E63E3F File Offset: 0x00E6203F
		public void SetIsUnLockState(int level)
		{
			this.IsUnLock = (this.Id <= level);
		}

		// Token: 0x06038CE3 RID: 232675 RVA: 0x00E63E53 File Offset: 0x00E62053
		public bool GetIsUnLock()
		{
			return this.IsUnLock;
		}

		// Token: 0x06038CE4 RID: 232676 RVA: 0x00E63E5B File Offset: 0x00E6205B
		public void SetReceiveRewardState(bool state)
		{
			this.IsReceiveReward = state;
		}

		// Token: 0x06038CE5 RID: 232677 RVA: 0x00E63E64 File Offset: 0x00E62064
		public MingSuDefine.EDarkCoastDeliveryLevelDataState GetDarkCoastDeliveryGuardState()
		{
			if (this.ReceivedGuardReward)
			{
				return MingSuDefine.EDarkCoastDeliveryLevelDataState.Received;
			}
			if (this.DefeatedGuard)
			{
				return MingSuDefine.EDarkCoastDeliveryLevelDataState.Passed;
			}
			if (this.IsUnLock)
			{
				return MingSuDefine.EDarkCoastDeliveryLevelDataState.UnLock;
			}
			return MingSuDefine.EDarkCoastDeliveryLevelDataState.Lock;
		}

		// Token: 0x06038CE6 RID: 232678 RVA: 0x00E63E85 File Offset: 0x00E62085
		public EActivityRewardState GetDarkCoastDeliveryRewardState()
		{
			if (this.IsReceiveReward)
			{
				return EActivityRewardState.Claimed;
			}
			if (this.IsUnLock)
			{
				return EActivityRewardState.Enable;
			}
			return EActivityRewardState.Disabled;
		}

		// Token: 0x06038CE7 RID: 232679 RVA: 0x00E63E9C File Offset: 0x00E6209C
		[NullableContext(1)]
		public List<TItem> GetRewardItems()
		{
			if (this.RewardItems == null)
			{
				this.InitRewardItems();
			}
			return this.RewardItems;
		}

		// Token: 0x040205C4 RID: 132548
		public readonly int Id;

		// Token: 0x040205C5 RID: 132549
		public readonly DarkCoastDelivery Config;

		// Token: 0x040205C6 RID: 132550
		private readonly int DropId;

		// Token: 0x040205C7 RID: 132551
		public readonly int Goal;

		// Token: 0x040205C8 RID: 132552
		private bool DefeatedGuard;

		// Token: 0x040205C9 RID: 132553
		private bool ReceivedGuardReward;

		// Token: 0x040205CA RID: 132554
		private bool IsUnLock;

		// Token: 0x040205CB RID: 132555
		private bool IsReceiveReward;

		// Token: 0x040205CC RID: 132556
		[Nullable(2)]
		private List<TItem> RewardItems;
	}
}
