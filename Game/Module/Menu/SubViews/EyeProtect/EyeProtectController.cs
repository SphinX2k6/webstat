using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.EyeProtect
{
	// Token: 0x020057AB RID: 22443
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class EyeProtectController : UiControllerBase<EyeProtectController>
	{
		// Token: 0x060390F9 RID: 233721 RVA: 0x00E76387 File Offset: 0x00E74587
		protected override void OnRegisterNetEvent()
		{
		}

		// Token: 0x060390FA RID: 233722 RVA: 0x00E76389 File Offset: 0x00E74589
		protected override void OnUnRegisterNetEvent()
		{
		}

		// Token: 0x060390FB RID: 233723 RVA: 0x00E7638B File Offset: 0x00E7458B
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Add(EEventName.LogOut, new Action(this.HandleBackLoginView));
		}

		// Token: 0x060390FC RID: 233724 RVA: 0x00E763C5 File Offset: 0x00E745C5
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Remove(EEventName.LogOut, new Action(this.HandleBackLoginView));
		}

		// Token: 0x060390FD RID: 233725 RVA: 0x00E76400 File Offset: 0x00E74600
		public UniTask<bool> BuildViewModelAndOpen([Nullable(1)] EyeProtectViewModel viewModel)
		{
			EyeProtectController.<BuildViewModelAndOpen>d__4 <BuildViewModelAndOpen>d__;
			<BuildViewModelAndOpen>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<BuildViewModelAndOpen>d__.viewModel = viewModel;
			<BuildViewModelAndOpen>d__.<>1__state = -1;
			<BuildViewModelAndOpen>d__.<>t__builder.Start<EyeProtectController.<BuildViewModelAndOpen>d__4>(ref <BuildViewModelAndOpen>d__);
			return <BuildViewModelAndOpen>d__.<>t__builder.Task;
		}

		// Token: 0x060390FE RID: 233726 RVA: 0x00E76444 File Offset: 0x00E74644
		public UniTask<bool> OpenEyeProtectView()
		{
			EyeProtectController.<OpenEyeProtectView>d__5 <OpenEyeProtectView>d__;
			<OpenEyeProtectView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenEyeProtectView>d__.<>4__this = this;
			<OpenEyeProtectView>d__.<>1__state = -1;
			<OpenEyeProtectView>d__.<>t__builder.Start<EyeProtectController.<OpenEyeProtectView>d__5>(ref <OpenEyeProtectView>d__);
			return <OpenEyeProtectView>d__.<>t__builder.Task;
		}

		// Token: 0x060390FF RID: 233727 RVA: 0x00E76488 File Offset: 0x00E74688
		public UniTask CloseEyeProtectView()
		{
			EyeProtectController.<CloseEyeProtectView>d__6 <CloseEyeProtectView>d__;
			<CloseEyeProtectView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseEyeProtectView>d__.<>1__state = -1;
			<CloseEyeProtectView>d__.<>t__builder.Start<EyeProtectController.<CloseEyeProtectView>d__6>(ref <CloseEyeProtectView>d__);
			return <CloseEyeProtectView>d__.<>t__builder.Task;
		}

		// Token: 0x06039100 RID: 233728 RVA: 0x00E764C3 File Offset: 0x00E746C3
		[NullableContext(1)]
		private EyeProtectViewModel BuildViewModel()
		{
			return new EyeProtectViewModel();
		}

		// Token: 0x06039101 RID: 233729 RVA: 0x00E764CA File Offset: 0x00E746CA
		public void ApplyEyeProtectSetting()
		{
			GameSettingsUtils.ApplyEyeProtectionMode(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true));
		}

		// Token: 0x06039102 RID: 233730 RVA: 0x00E764E3 File Offset: 0x00E746E3
		public void SwitchFilter(bool isOn)
		{
			if (isOn)
			{
				GameSettingsUtils.ApplyImageDisplayMode(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.ImageDisplayMode, 0, true));
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.BlueLightFilter.Disable 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Tonemapper.BrightnessAndTextureDisable 1", null);
		}

		// Token: 0x06039103 RID: 233731 RVA: 0x00E76520 File Offset: 0x00E74720
		private void HandleBackLoginView()
		{
			this.SwitchFilter(false);
		}

		// Token: 0x06039104 RID: 233732 RVA: 0x00E76529 File Offset: 0x00E74729
		private void OnRoleDead(int charId)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.EyeProtectView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.EyeProtectView, null);
			}
		}
	}
}
