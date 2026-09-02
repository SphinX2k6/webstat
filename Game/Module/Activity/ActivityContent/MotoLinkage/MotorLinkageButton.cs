using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage
{
	// Token: 0x02006718 RID: 26392
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorLinkageButton : UiPanelBase
	{
		// Token: 0x06041D8E RID: 269710 RVA: 0x010E50D8 File Offset: 0x010E32D8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick))
			};
		}

		// Token: 0x06041D8F RID: 269711 RVA: 0x010E516C File Offset: 0x010E336C
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.OnPointEnterCallBack.Bind(new Action(this.OnButtonEnter));
				button.OnPointExitCallBack.Bind(new Action(this.OnButtonExit));
			}
		}

		// Token: 0x06041D90 RID: 269712 RVA: 0x010E51B2 File Offset: 0x010E33B2
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x06041D91 RID: 269713 RVA: 0x010E51BC File Offset: 0x010E33BC
		public void Refresh()
		{
			MotorLinkageIp ipConfig = ConfigBase<ActivityMotorLinkageConfig>.Instance.GetIpConfig(this.IpId);
			ActivityMotorLinkageData activityData = ControllerBase<ActivityMotorLinkageController>.Instance.ActivityData;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(activityData.IsStickerReceived(ipConfig.IpStickerList(0)));
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(activityData.IsStickerReceived(ipConfig.IpStickerList(1)));
			}
			bool uiactive = activityData.IpHasAnyRewardCanReceive(this.IpId);
			UUIItem item3 = base.GetItem(3);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(uiactive);
		}

		// Token: 0x06041D92 RID: 269714 RVA: 0x010E5244 File Offset: 0x010E3444
		public void SetIpId(int ipId)
		{
			this.IpId = ipId;
		}

		// Token: 0x06041D93 RID: 269715 RVA: 0x010E524D File Offset: 0x010E344D
		public void SetClickCallback(Action<int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06041D94 RID: 269716 RVA: 0x010E5256 File Offset: 0x010E3456
		public void SetEnterCallback(Action<int> callback)
		{
			this.EnterCallback = callback;
		}

		// Token: 0x06041D95 RID: 269717 RVA: 0x010E525F File Offset: 0x010E345F
		public void SetExitCallback(Action callback)
		{
			this.ExitCallback = callback;
		}

		// Token: 0x06041D96 RID: 269718 RVA: 0x010E5268 File Offset: 0x010E3468
		private void OnButtonClick()
		{
			Action<int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.IpId);
		}

		// Token: 0x06041D97 RID: 269719 RVA: 0x010E5280 File Offset: 0x010E3480
		private void OnButtonEnter()
		{
			Action<int> enterCallback = this.EnterCallback;
			if (enterCallback == null)
			{
				return;
			}
			enterCallback(this.IpId);
		}

		// Token: 0x06041D98 RID: 269720 RVA: 0x010E5298 File Offset: 0x010E3498
		private void OnButtonExit()
		{
			Action exitCallback = this.ExitCallback;
			if (exitCallback == null)
			{
				return;
			}
			exitCallback();
		}

		// Token: 0x04024BEF RID: 150511
		private int IpId;

		// Token: 0x04024BF0 RID: 150512
		[Nullable(2)]
		private Action<int> ClickCallback;

		// Token: 0x04024BF1 RID: 150513
		[Nullable(2)]
		private Action<int> EnterCallback;

		// Token: 0x04024BF2 RID: 150514
		[Nullable(2)]
		private Action ExitCallback;
	}
}
