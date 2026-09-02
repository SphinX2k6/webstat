using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection.SelectServer
{
	// Token: 0x02004527 RID: 17703
	public class HotFixNetworkDetectSelectItem : LaunchComponentsAction, IHotFixLayoutItem
	{
		// Token: 0x0602EA25 RID: 191013 RVA: 0x00B0C05D File Offset: 0x00B0A25D
		[NullableContext(1)]
		public void SetRootActor(AActor actor)
		{
			base.SetRootActorLaunchComponentsAction(actor);
		}

		// Token: 0x0602EA26 RID: 191014 RVA: 0x00B0C066 File Offset: 0x00B0A266
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnSelectServerToggleEvent));
		}

		// Token: 0x0602EA27 RID: 191015 RVA: 0x00B0C09F File Offset: 0x00B0A29F
		[NullableContext(1)]
		public UUIExtendToggle GetToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x0602EA28 RID: 191016 RVA: 0x00B0C0A8 File Offset: 0x00B0A2A8
		protected override void OnBeforeDestroy()
		{
			base.GetExtendToggle(0).OnStateChange.Clear();
		}

		// Token: 0x0602EA29 RID: 191017 RVA: 0x00B0C0BC File Offset: 0x00B0A2BC
		public void RefreshToggleState()
		{
			bool flag = Singleton<HotFixNetworkDetectionModel>.Instance.CurrentUiSelectSeverData == this.Data.LoginServersData;
			base.GetExtendToggle(0).SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0602EA2A RID: 191018 RVA: 0x00B0C0F8 File Offset: 0x00B0A2F8
		protected override void OnShow()
		{
			this.UpdateServerInfo();
			this.RefreshToggleState();
		}

		// Token: 0x0602EA2B RID: 191019 RVA: 0x00B0C106 File Offset: 0x00B0A306
		[NullableContext(1)]
		public void Refresh(IHotFixLayoutData data)
		{
			this.Data = (IHotFixNetworkDetectSelectData)data;
		}

		// Token: 0x0602EA2C RID: 191020 RVA: 0x00B0C114 File Offset: 0x00B0A314
		private void UpdateServerInfo()
		{
			base.GetText(1).SetText(this.Data.LoginServersData.name, true);
		}

		// Token: 0x0602EA2D RID: 191021 RVA: 0x00B0C133 File Offset: 0x00B0A333
		private void OnSelectServerToggleEvent(EToggleState state)
		{
			if (this.Data != null)
			{
				Singleton<HotFixNetworkDetectionModel>.Instance.CurrentUiSelectSeverData = this.Data.LoginServersData;
			}
			Action onToggleStateChange = this.OnToggleStateChange;
			if (onToggleStateChange == null)
			{
				return;
			}
			onToggleStateChange();
		}

		// Token: 0x0401A7B5 RID: 108469
		[Nullable(2)]
		public IHotFixNetworkDetectSelectData Data;

		// Token: 0x0401A7B6 RID: 108470
		[Nullable(2)]
		public Action OnToggleStateChange;

		// Token: 0x0200A742 RID: 42818
		private static class EComponents
		{
			// Token: 0x04033E9D RID: 212637
			public const int StripToggle = 0;

			// Token: 0x04033E9E RID: 212638
			public const int TxtServerName = 1;

			// Token: 0x04033E9F RID: 212639
			public const int ServerInfo = 2;

			// Token: 0x04033EA0 RID: 212640
			public const int RoleNode = 3;

			// Token: 0x04033EA1 RID: 212641
			public const int TxtLevel = 4;

			// Token: 0x04033EA2 RID: 212642
			public const int PnlState = 5;
		}
	}
}
