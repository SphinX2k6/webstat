using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CommonH5
{
	// Token: 0x020069B2 RID: 27058
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonH5Data : ActivityBaseData
	{
		// Token: 0x06043187 RID: 274823 RVA: 0x0113B99C File Offset: 0x01139B9C
		protected override void PhraseEx(ActivityData data)
		{
			H5ViewActivityData h5ViewActivityData = data.H5ViewActivityData;
			if (h5ViewActivityData != null)
			{
				this.ChangeServerRedDotState(h5ViewActivityData.RedDot);
				this.RewardClaimState = h5ViewActivityData.AllRewardClaimed;
			}
		}

		// Token: 0x06043188 RID: 274824 RVA: 0x0113B9CC File Offset: 0x01139BCC
		public string GetBgPrefabPath()
		{
			H5JumpActivity? config = ConfigH5JumpActivityById.GetConfig(base.Id, true);
			return ((config != null) ? config.GetValueOrDefault().BgPath : null) ?? "";
		}

		// Token: 0x06043189 RID: 274825 RVA: 0x0113BA0A File Offset: 0x01139C0A
		public void ChangeServerRedDotState(bool state)
		{
			this.RedDotInternal = state;
		}

		// Token: 0x0604318A RID: 274826 RVA: 0x0113BA13 File Offset: 0x01139C13
		public bool GetRewardClaimState()
		{
			return this.RewardClaimState;
		}

		// Token: 0x0604318B RID: 274827 RVA: 0x0113BA1B File Offset: 0x01139C1B
		public bool GetClickRedDotState()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, 0, 0) == 0;
		}

		// Token: 0x0604318C RID: 274828 RVA: 0x0113BA34 File Offset: 0x01139C34
		public void SetCurrentLoginClickState(bool state)
		{
			this.CurrentLoginClickState = state;
		}

		// Token: 0x0604318D RID: 274829 RVA: 0x0113BA3D File Offset: 0x01139C3D
		public void SaveClickRedDotState()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 1, 0, 0, 1);
		}

		// Token: 0x0604318E RID: 274830 RVA: 0x0113BA53 File Offset: 0x01139C53
		public override bool GetExDataRedPointShowState()
		{
			return this.GetClickRedDotState() || (this.RedDotInternal && !this.CurrentLoginClickState);
		}

		// Token: 0x0604318F RID: 274831 RVA: 0x0113BA72 File Offset: 0x01139C72
		protected override bool GetExDataFinishShowState()
		{
			return this.RewardClaimState;
		}

		// Token: 0x06043190 RID: 274832 RVA: 0x0113BA7C File Offset: 0x01139C7C
		[NullableContext(2)]
		public string GetRootUrl()
		{
			if (this.GmUrl != null && this.GmUrl != "")
			{
				return this.GmUrl;
			}
			H5JumpActivity? config = ConfigH5JumpActivityById.GetConfig(base.Id, true);
			if (!ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				if (config == null)
				{
					return null;
				}
				return config.GetValueOrDefault().CNRootUrl;
			}
			else
			{
				if (config == null)
				{
					return null;
				}
				return config.GetValueOrDefault().OverseaRootUrl;
			}
		}

		// Token: 0x04025645 RID: 153157
		[Nullable(2)]
		public string GmUrl;

		// Token: 0x04025646 RID: 153158
		private bool RedDotInternal;

		// Token: 0x04025647 RID: 153159
		private bool CurrentLoginClickState;

		// Token: 0x04025648 RID: 153160
		private bool RewardClaimState;

		// Token: 0x04025649 RID: 153161
		private const int CLICKKEY = 1;
	}
}
