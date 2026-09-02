using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Sheriff;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data
{
	// Token: 0x02004BF8 RID: 19448
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class RegionalTerminalGameplayData
	{
		// Token: 0x06032C00 RID: 207872
		public abstract ERedDotName? GetRedDotName();

		// Token: 0x06032C01 RID: 207873
		public abstract int GetRedDotId();

		// Token: 0x06032C02 RID: 207874
		public abstract bool GetRedDotState();

		// Token: 0x06032C03 RID: 207875
		public abstract void BarFunction();

		// Token: 0x06032C04 RID: 207876
		public abstract void TerminalFunction(Action<bool> callback = null);

		// Token: 0x06032C05 RID: 207877
		public abstract bool GetShowState();

		// Token: 0x06032C06 RID: 207878
		public abstract bool GetLockState();

		// Token: 0x06032C07 RID: 207879
		[NullableContext(1)]
		public abstract IRegionalTerminalViewParams GetViewParams();

		// Token: 0x06032C08 RID: 207880 RVA: 0x00CB68E4 File Offset: 0x00CB4AE4
		public virtual List<TItem> GetRewardPreviewList()
		{
			int rewardPreview = this.GetGameplayConfig().RewardPreview;
			if (rewardPreview == 0)
			{
				return null;
			}
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardPreview);
		}

		// Token: 0x06032C09 RID: 207881 RVA: 0x00CB6910 File Offset: 0x00CB4B10
		protected AreaTerminal GetGameplayConfig()
		{
			return ConfigBase<RegionalTerminalConfig>.Instance.GetAreaTerminalByGameplayId(this.Id).Value;
		}

		// Token: 0x06032C0A RID: 207882 RVA: 0x00CB6938 File Offset: 0x00CB4B38
		public void OnSelected()
		{
			if (this.GetRedDotName().GetValueOrDefault() == ERedDotName.SheriffMap)
			{
				ControllerBase<SheriffController>.Instance.ReadTerminalFirstOpenRedDot();
			}
		}

		// Token: 0x0401D885 RID: 120965
		public int Id;

		// Token: 0x0401D886 RID: 120966
		public int GameplayId;

		// Token: 0x0401D887 RID: 120967
		public int GroupId;

		// Token: 0x0401D888 RID: 120968
		public int SortId;

		// Token: 0x0401D889 RID: 120969
		public bool CloseTerminalWhenForwarding = true;
	}
}
