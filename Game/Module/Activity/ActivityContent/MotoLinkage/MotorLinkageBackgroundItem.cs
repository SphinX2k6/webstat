using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x02006716 RID: 26390
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorLinkageBackgroundItem : UiPanelBase
	{
		// Token: 0x06041D80 RID: 269696 RVA: 0x010E4DCC File Offset: 0x010E2FCC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06041D81 RID: 269697 RVA: 0x010E4E3C File Offset: 0x010E303C
		protected override UniTask OnBeforeStartAsync()
		{
			MotorLinkageBackgroundItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorLinkageBackgroundItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041D82 RID: 269698 RVA: 0x010E4E80 File Offset: 0x010E3080
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.StickerItemA.ClickToggleCallback = delegate()
			{
				this.OnToggleClick(0);
			};
			this.StickerItemB.ClickToggleCallback = delegate()
			{
				this.OnToggleClick(1);
			};
			this.RefreshToggle();
			this.SelectFirstIncompleteToggle();
		}

		// Token: 0x06041D83 RID: 269699 RVA: 0x010E4ED8 File Offset: 0x010E30D8
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x06041D84 RID: 269700 RVA: 0x010E4EEA File Offset: 0x010E30EA
		protected override void OnBeforeShow()
		{
			this.Refresh(false);
		}

		// Token: 0x06041D85 RID: 269701 RVA: 0x010E4EF4 File Offset: 0x010E30F4
		public void Refresh(bool skipAnim = false)
		{
			ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfig(this.IpId);
			this.RefreshToggle();
			if (skipAnim)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x06041D86 RID: 269702 RVA: 0x010E4F40 File Offset: 0x010E3140
		private void RefreshToggle()
		{
			MotorLinkageIp ipConfig = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfig(this.IpId);
			MotorLinkageStickerItem stickerItemA = this.StickerItemA;
			if (stickerItemA != null)
			{
				stickerItemA.Refresh(ipConfig.IpStickerList(0));
			}
			MotorLinkageStickerItem stickerItemB = this.StickerItemB;
			if (stickerItemB == null)
			{
				return;
			}
			stickerItemB.Refresh(ipConfig.IpStickerList(1));
		}

		// Token: 0x06041D87 RID: 269703 RVA: 0x010E4F8F File Offset: 0x010E318F
		public void SetIpId(int ipId)
		{
			this.IpId = ipId;
		}

		// Token: 0x06041D88 RID: 269704 RVA: 0x010E4F98 File Offset: 0x010E3198
		private void OnToggleClick(int index)
		{
			if (index == 0)
			{
				MotorLinkageStickerItem stickerItemB = this.StickerItemB;
				if (stickerItemB != null)
				{
					stickerItemB.SetToggleSelect(false, null);
				}
			}
			else
			{
				MotorLinkageStickerItem stickerItemA = this.StickerItemA;
				if (stickerItemA != null)
				{
					stickerItemA.SetToggleSelect(false, null);
				}
			}
			this.SelectedIndex = index;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x06041D89 RID: 269705 RVA: 0x010E5006 File Offset: 0x010E3206
		public void RefreshTexture()
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(this.SelectedIndex == 0);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(this.SelectedIndex == 1);
		}

		// Token: 0x06041D8A RID: 269706 RVA: 0x010E5040 File Offset: 0x010E3240
		private void SelectFirstIncompleteToggle()
		{
			if (this.StickerItemA != null && !this.StickerItemA.IsReceived())
			{
				this.StickerItemA.SetToggleSelect(true, new bool?(true));
			}
			else if (this.StickerItemB != null && !this.StickerItemB.IsReceived())
			{
				this.StickerItemB.SetToggleSelect(true, new bool?(true));
			}
			else
			{
				MotorLinkageStickerItem stickerItemA = this.StickerItemA;
				if (stickerItemA != null)
				{
					stickerItemA.SetToggleSelect(true, new bool?(true));
				}
			}
			this.RefreshTexture();
		}

		// Token: 0x04024BE5 RID: 150501
		private int IpId;

		// Token: 0x04024BE6 RID: 150502
		private int SelectedIndex;

		// Token: 0x04024BE7 RID: 150503
		private MotorLinkageStickerItem StickerItemA;

		// Token: 0x04024BE8 RID: 150504
		private MotorLinkageStickerItem StickerItemB;

		// Token: 0x04024BE9 RID: 150505
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
