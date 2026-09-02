using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C86 RID: 19590
	[NullableContext(1)]
	[Nullable(0)]
	public class PcAndGamepadProgressBar
	{
		// Token: 0x06033101 RID: 209153 RVA: 0x00CC9AC4 File Offset: 0x00CC7CC4
		public UniTask Init(UUIItem pcItem, UUIItem gamePadItem)
		{
			PcAndGamepadProgressBar.<Init>d__2 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.pcItem = pcItem;
			<Init>d__.gamePadItem = gamePadItem;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<PcAndGamepadProgressBar.<Init>d__2>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033102 RID: 209154 RVA: 0x00CC9B17 File Offset: 0x00CC7D17
		public void SetProgressPercent(float percent)
		{
			this.SetPercent(percent);
			this.RefreshProgressVisible();
		}

		// Token: 0x06033103 RID: 209155 RVA: 0x00CC9B26 File Offset: 0x00CC7D26
		public void SetPercent(float percent)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				ProgressBar gamepadProgress = this.GamepadProgress;
				if (gamepadProgress == null)
				{
					return;
				}
				gamepadProgress.SetPercent(percent);
				return;
			}
			else
			{
				ProgressBar pcProgress = this.PcProgress;
				if (pcProgress == null)
				{
					return;
				}
				pcProgress.SetPercent(percent);
				return;
			}
		}

		// Token: 0x06033104 RID: 209156 RVA: 0x00CC9B57 File Offset: 0x00CC7D57
		public void SetProgressVisible(bool bVisible)
		{
			if (bVisible)
			{
				this.RefreshProgressVisible();
				return;
			}
			ProgressBar pcProgress = this.PcProgress;
			if (pcProgress != null)
			{
				pcProgress.SetActive(false);
			}
			ProgressBar gamepadProgress = this.GamepadProgress;
			if (gamepadProgress == null)
			{
				return;
			}
			gamepadProgress.SetActive(false);
		}

		// Token: 0x06033105 RID: 209157 RVA: 0x00CC9B88 File Offset: 0x00CC7D88
		public void RefreshProgressVisible()
		{
			bool flag = Singleton<Info>.Instance.IsInGamepad();
			bool flag2 = !flag;
			bool flag3 = flag;
			ProgressBar pcProgress = this.PcProgress;
			if (pcProgress == null || pcProgress.GetActive() != flag2)
			{
				ProgressBar pcProgress2 = this.PcProgress;
				if (pcProgress2 != null)
				{
					pcProgress2.SetActive(flag2);
				}
			}
			ProgressBar gamepadProgress = this.GamepadProgress;
			if (gamepadProgress == null || gamepadProgress.GetActive() != flag3)
			{
				ProgressBar gamepadProgress2 = this.GamepadProgress;
				if (gamepadProgress2 == null)
				{
					return;
				}
				gamepadProgress2.SetActive(flag3);
			}
		}

		// Token: 0x0401DB0E RID: 121614
		private ProgressBar PcProgress;

		// Token: 0x0401DB0F RID: 121615
		private ProgressBar GamepadProgress;
	}
}
