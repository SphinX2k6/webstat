using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F9B RID: 24475
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleTopPanelHookCenter
	{
		// Token: 0x17009A5E RID: 39518
		// (get) Token: 0x0603D74C RID: 251724 RVA: 0x00FA3648 File Offset: 0x00FA1848
		private List<IBattleTopPanelHook> Hooks
		{
			get
			{
				return ModelBase<BattleUiModel>.Instance.TopPanelHooks;
			}
		}

		// Token: 0x0603D74D RID: 251725 RVA: 0x00FA3654 File Offset: 0x00FA1854
		public UniTask OnInitAsync(TopPanel topPanel)
		{
			BattleTopPanelHookCenter.<OnInitAsync>d__2 <OnInitAsync>d__;
			<OnInitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnInitAsync>d__.<>4__this = this;
			<OnInitAsync>d__.topPanel = topPanel;
			<OnInitAsync>d__.<>1__state = -1;
			<OnInitAsync>d__.<>t__builder.Start<BattleTopPanelHookCenter.<OnInitAsync>d__2>(ref <OnInitAsync>d__);
			return <OnInitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D74E RID: 251726 RVA: 0x00FA36A0 File Offset: 0x00FA18A0
		public void OnShow(TopPanel topPanel)
		{
			foreach (IBattleTopPanelHook battleTopPanelHook in this.Hooks)
			{
				battleTopPanelHook.OnShow(topPanel);
			}
		}

		// Token: 0x0603D74F RID: 251727 RVA: 0x00FA36F4 File Offset: 0x00FA18F4
		public void OnHide(TopPanel topPanel)
		{
			foreach (IBattleTopPanelHook battleTopPanelHook in this.Hooks)
			{
				battleTopPanelHook.OnHide(topPanel);
			}
		}

		// Token: 0x0603D750 RID: 251728 RVA: 0x00FA3748 File Offset: 0x00FA1948
		public void OnAddEventListener(TopPanel topPanel)
		{
			foreach (IBattleTopPanelHook battleTopPanelHook in this.Hooks)
			{
				battleTopPanelHook.OnAddEventListener(topPanel);
			}
		}

		// Token: 0x0603D751 RID: 251729 RVA: 0x00FA379C File Offset: 0x00FA199C
		public void OnRemoveEventListener(TopPanel topPanel)
		{
			foreach (IBattleTopPanelHook battleTopPanelHook in this.Hooks)
			{
				battleTopPanelHook.OnRemoveEventListener(topPanel);
			}
		}

		// Token: 0x0603D752 RID: 251730 RVA: 0x00FA37F0 File Offset: 0x00FA19F0
		public void OnRefresh(TopPanel topPanel)
		{
			foreach (IBattleTopPanelHook battleTopPanelHook in this.Hooks)
			{
				battleTopPanelHook.OnRefresh(topPanel);
			}
		}

		// Token: 0x0603D753 RID: 251731 RVA: 0x00FA3844 File Offset: 0x00FA1A44
		public void OnReset(TopPanel topPanel)
		{
			foreach (IBattleTopPanelHook battleTopPanelHook in this.Hooks)
			{
				battleTopPanelHook.OnReset(topPanel);
			}
			this.Clear();
		}

		// Token: 0x0603D754 RID: 251732 RVA: 0x00FA389C File Offset: 0x00FA1A9C
		public void Clear()
		{
			ModelBase<BattleUiModel>.Instance.TopPanelHooks.Clear();
		}
	}
}
