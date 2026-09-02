using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.Views
{
	// Token: 0x0200576E RID: 22382
	[NullableContext(1)]
	[Nullable(0)]
	public class MenuScrollSettingButtonItem : MenuScrollSettingBaseItem
	{
		// Token: 0x06038F4E RID: 233294 RVA: 0x00E6E378 File Offset: 0x00E6C578
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggleSpriteTransition))
			};
		}

		// Token: 0x06038F4F RID: 233295 RVA: 0x00E6E42A File Offset: 0x00E6C62A
		protected override void OnStart()
		{
			this.ButtonItem = new ButtonItem(base.GetItem(1));
			this.ButtonItem.GetBtn().SetCanClickWhenDisable(true);
			this.ButtonItem.SetFunction(new Action<int>(this.OnButtonClickCallback));
		}

		// Token: 0x06038F50 RID: 233296 RVA: 0x00E6E466 File Offset: 0x00E6C666
		protected override void OnBeforeDestroy()
		{
			if (this.Data != null)
			{
				this.Data = null;
			}
		}

		// Token: 0x06038F51 RID: 233297 RVA: 0x00E6E478 File Offset: 0x00E6C678
		private void OnButtonClickCallback(int _)
		{
			if (base.GetItemClickLimit(this.ButtonItem.GetBtn()))
			{
				return;
			}
			EUiViewName euiViewName = (EUiViewName)this.Data.ButtonViewName;
			if (euiViewName.ToString().Contains(this.AccountSettingPrefix))
			{
				int type;
				if (int.TryParse(euiViewName.ToString().Substring(this.AccountSettingPrefix.Length), out type))
				{
					ControllerBase<ChannelController>.Instance.ProcessAccountSetting((EChannelAccountSetting)type);
				}
				return;
			}
			Action action;
			if (ControllerBase<MenuController>.Instance.OpenViewFuncMap.TryGetValue(euiViewName, out action))
			{
				action();
				return;
			}
			Singleton<UiManager>.Instance.OpenView(euiViewName, new object[]
			{
				this.Data,
				new Action<int, float>(delegate(int functionId, float index)
				{
					this.ChangeButton(functionId, (int)index);
				})
			}, null);
		}

		// Token: 0x06038F52 RID: 233298 RVA: 0x00E6E53C File Offset: 0x00E6C73C
		public override void Update(MenuData data, bool bGameSettingsUpdate)
		{
			this.Data = data;
			this.RefreshTitle();
			this.RefreshButton();
			this.RefreshDetailText();
			this.RefreshDetailSpriteVisible();
			this.RefreshDetailSprite().Forget();
			this.SetInteractionActive(data.GetEnable());
			this.Data.OnRefresh();
			this.RefreshRedDot();
		}

		// Token: 0x06038F53 RID: 233299 RVA: 0x00E6E590 File Offset: 0x00E6C790
		protected void RefreshTitle()
		{
			if (this.Data.CustomTitleArgs != null && this.Data.CustomTitleArgs.Length != 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.FunctionName, this.Data.CustomTitleArgs.ToArray<string>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.FunctionName, Array.Empty<object>());
		}

		// Token: 0x06038F54 RID: 233300 RVA: 0x00E6E608 File Offset: 0x00E6C808
		private void RefreshButton()
		{
			base.GetRootItem().SetUIActive(true);
			if (!this.Data.GetEnable())
			{
				string disableOverrideText = this.Data.GetDisableOverrideText();
				if (disableOverrideText != null)
				{
					base.GetText(2).ShowTextNew(disableOverrideText);
					return;
				}
			}
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(this.Data.FunctionId);
			if (this.Data.FunctionId == EFunction.RESOLUTION)
			{
				this.SetButtonTextForResolution(targetConfig, false);
				return;
			}
			this.SetButtonText((this.Data.OptionsNameList.Count > targetConfig) ? this.Data.OptionsNameList[targetConfig] : null, targetConfig, false);
		}

		// Token: 0x06038F55 RID: 233301 RVA: 0x00E6E6A8 File Offset: 0x00E6C8A8
		private void RefreshDetailText()
		{
			if (this.Data == null)
			{
				return;
			}
			if (!this.Data.HasDetailText())
			{
				return;
			}
			UUIText text = base.GetText(4);
			string detailTextId = this.Data.GetDetailTextId();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, detailTextId, Array.Empty<object>());
		}

		// Token: 0x06038F56 RID: 233302 RVA: 0x00E6E6F1 File Offset: 0x00E6C8F1
		private void RefreshDetailSpriteVisible()
		{
			if (this.Data == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(5);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(this.Data.ShowHelpBtn());
		}

		// Token: 0x06038F57 RID: 233303 RVA: 0x00E6E718 File Offset: 0x00E6C918
		public UniTask RefreshDetailSprite()
		{
			MenuScrollSettingButtonItem.<RefreshDetailSprite>d__13 <RefreshDetailSprite>d__;
			<RefreshDetailSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshDetailSprite>d__.<>4__this = this;
			<RefreshDetailSprite>d__.<>1__state = -1;
			<RefreshDetailSprite>d__.<>t__builder.Start<MenuScrollSettingButtonItem.<RefreshDetailSprite>d__13>(ref <RefreshDetailSprite>d__);
			return <RefreshDetailSprite>d__.<>t__builder.Task;
		}

		// Token: 0x06038F58 RID: 233304 RVA: 0x00E6E75C File Offset: 0x00E6C95C
		private void ChangeButton(int functionId, int index)
		{
			if (this.Data == null)
			{
				return;
			}
			if (functionId != (int)this.Data.FunctionId)
			{
				return;
			}
			if (functionId == 6)
			{
				this.SetButtonTextForResolution(index, true);
				return;
			}
			if (functionId == 7)
			{
				this.FireSaveMenuChange(index);
				return;
			}
			this.SetButtonText(this.Data.OptionsNameList[index], index, true);
		}

		// Token: 0x06038F59 RID: 233305 RVA: 0x00E6E7B8 File Offset: 0x00E6C9B8
		private void SetButtonTextForResolution(int index, bool fire = false)
		{
			string newText;
			if (ControllerBase<MenuController>.Instance.GetTargetConfig(EFunction.DISPLAYMODE) == 0)
			{
				FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
				newText = string.Format(this.ButtonResolutionFormatStr, viewportSize.X, viewportSize.Y);
			}
			else
			{
				FIntPoint resolutionByList = Singleton<GameSettingsDeviceRender>.Instance.GetResolutionByList(index);
				newText = string.Format(this.ButtonResolutionFormatStr, resolutionByList.X, resolutionByList.Y);
			}
			base.GetText(2).SetText(newText, true);
			if (fire)
			{
				this.FireSaveMenuChange(index);
			}
		}

		// Token: 0x06038F5A RID: 233306 RVA: 0x00E6E858 File Offset: 0x00E6CA58
		[NullableContext(2)]
		public void SetButtonText(string value, int index, bool fire = false)
		{
			string buttonTextId = this.Data.ButtonTextId;
			UUIText text = base.GetText(2);
			if (!string.IsNullOrEmpty(buttonTextId))
			{
				text.ShowTextNew(buttonTextId);
			}
			else
			{
				text.ShowTextNew(value ?? "");
			}
			if (fire)
			{
				this.FireSaveMenuChange(index);
			}
		}

		// Token: 0x06038F5B RID: 233307 RVA: 0x00E6E8A9 File Offset: 0x00E6CAA9
		public override void SetInteractionActive(bool val)
		{
			this.ButtonItem.SetEnableClick(val && this.Data.GetButtonEnable());
		}

		// Token: 0x06038F5C RID: 233308 RVA: 0x00E6E8C8 File Offset: 0x00E6CAC8
		protected override void OnSetDetailVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(bVisible);
			}
			if (this.Data == null)
			{
				return;
			}
			if (this.Data.CanClickWhenDisable && !this.Data.GetEnable())
			{
				FColor color = bVisible ? FColor.FromHex("FFF7B6FF") : FColor.FromHex("FFFFFFFF");
				base.GetSprite(5).SetColor(color);
				base.GetUiExtendToggleSpriteTransition(6).TransitionState.UnDetermineUnHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(6).TransitionState.UnDetermineHoverState.Color = color;
				base.GetUiExtendToggleSpriteTransition(6).TransitionState.UnDeterminePressedState.Color = color;
			}
		}

		// Token: 0x06038F5D RID: 233309 RVA: 0x00E6E977 File Offset: 0x00E6CB77
		private void RefreshRedDot()
		{
			ButtonItem buttonItem = this.ButtonItem;
			if (buttonItem == null)
			{
				return;
			}
			buttonItem.SetRedDotVisible(this.Data.EnableRedDot);
		}

		// Token: 0x040206E6 RID: 132838
		private readonly string ButtonResolutionFormatStr = "{0}x{1}";

		// Token: 0x040206E7 RID: 132839
		private readonly string AccountSettingPrefix = "Account,";

		// Token: 0x040206E8 RID: 132840
		[Nullable(2)]
		private ButtonItem ButtonItem;

		// Token: 0x0200B806 RID: 47110
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04038EC9 RID: 233161
			public const int Title = 0;

			// Token: 0x04038ECA RID: 233162
			public const int Button = 1;

			// Token: 0x04038ECB RID: 233163
			public const int Name = 2;

			// Token: 0x04038ECC RID: 233164
			public const int DetailItem = 3;

			// Token: 0x04038ECD RID: 233165
			public const int DetailText = 4;

			// Token: 0x04038ECE RID: 233166
			public const int DetailSprite = 5;

			// Token: 0x04038ECF RID: 233167
			public const int DetailToggleTransition = 6;
		}
	}
}
