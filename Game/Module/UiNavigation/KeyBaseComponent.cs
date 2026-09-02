using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C83 RID: 19587
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class KeyBaseComponent : UiPanelBase
	{
		// Token: 0x060330E1 RID: 209121
		protected abstract UUIText GetNameText();

		// Token: 0x060330E2 RID: 209122
		protected abstract UUITexture GetKeyTexture();

		// Token: 0x060330E3 RID: 209123
		protected abstract UUIItem GetLongPressItem();

		// Token: 0x060330E4 RID: 209124
		protected abstract UUIItem GetCircleItem();

		// Token: 0x060330E5 RID: 209125
		protected abstract UUIItem GetSquareItem();

		// Token: 0x060330E6 RID: 209126
		protected abstract UUITexture GetLongPressTipTexture();

		// Token: 0x060330E7 RID: 209127 RVA: 0x00CC97DC File Offset: 0x00CC79DC
		protected override UniTask OnBeforeStartAsync()
		{
			KeyBaseComponent.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KeyBaseComponent.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060330E8 RID: 209128 RVA: 0x00CC981F File Offset: 0x00CC7A1F
		[NullableContext(2)]
		public void SetKeyName(string keyName)
		{
			this.KeyName = keyName;
		}

		// Token: 0x060330E9 RID: 209129 RVA: 0x00CC9828 File Offset: 0x00CC7A28
		public void SetIsNeedLongPress(bool value)
		{
			this.IsNeedLongPress = value;
		}

		// Token: 0x060330EA RID: 209130 RVA: 0x00CC9831 File Offset: 0x00CC7A31
		[NullableContext(2)]
		public void RefreshKeyIcon(string keyName)
		{
			this.SetKeyName(keyName);
			this.SetKeyIcon(keyName);
		}

		// Token: 0x060330EB RID: 209131 RVA: 0x00CC9844 File Offset: 0x00CC7A44
		public void RefreshNameText(string textId)
		{
			if (StringUtils.IsEmpty(textId))
			{
				this.SetNameTextVisible(false);
				return;
			}
			if (textId == "Hide")
			{
				this.SetNameTextVisible(false);
				return;
			}
			string hotKeyText = ConfigBase<UiNavigationConfig>.Instance.GetHotKeyText(textId);
			if (hotKeyText == null)
			{
				this.SetNameTextVisible(false);
				return;
			}
			this.SetNameTextById(hotKeyText);
			this.SetNameTextVisible(true);
		}

		// Token: 0x060330EC RID: 209132 RVA: 0x00CC989B File Offset: 0x00CC7A9B
		[NullableContext(2)]
		private void SetKeyIcon(string keyName)
		{
			this.SetKeyIconAsync(keyName);
		}

		// Token: 0x060330ED RID: 209133 RVA: 0x00CC98A8 File Offset: 0x00CC7AA8
		[NullableContext(2)]
		private UniTask SetKeyIconAsync(string keyName)
		{
			KeyBaseComponent.<SetKeyIconAsync>d__18 <SetKeyIconAsync>d__;
			<SetKeyIconAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetKeyIconAsync>d__.<>4__this = this;
			<SetKeyIconAsync>d__.keyName = keyName;
			<SetKeyIconAsync>d__.<>1__state = -1;
			<SetKeyIconAsync>d__.<>t__builder.Start<KeyBaseComponent.<SetKeyIconAsync>d__18>(ref <SetKeyIconAsync>d__);
			return <SetKeyIconAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060330EE RID: 209134 RVA: 0x00CC98F4 File Offset: 0x00CC7AF4
		private void SetKeyIconVisible(bool bVisible)
		{
			UUITexture keyTexture = this.GetKeyTexture();
			if (keyTexture == null)
			{
				return;
			}
			keyTexture.SetUIActive(bVisible);
		}

		// Token: 0x060330EF RID: 209135 RVA: 0x00CC9914 File Offset: 0x00CC7B14
		public void SetNameTextById(string keyTextId)
		{
			if (this.IsForceSetText)
			{
				return;
			}
			UUIText nameText = this.GetNameText();
			if (nameText == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(nameText, keyTextId, Array.Empty<object>());
		}

		// Token: 0x060330F0 RID: 209136 RVA: 0x00CC9948 File Offset: 0x00CC7B48
		public void SetNameText(string keyText)
		{
			UUIText nameText = this.GetNameText();
			if (nameText == null)
			{
				return;
			}
			nameText.SetText(keyText, true);
		}

		// Token: 0x060330F1 RID: 209137 RVA: 0x00CC9968 File Offset: 0x00CC7B68
		public void SetNameTextForce(bool value)
		{
			this.IsForceSetText = value;
		}

		// Token: 0x060330F2 RID: 209138 RVA: 0x00CC9971 File Offset: 0x00CC7B71
		public bool GetIsForceSetText()
		{
			return this.IsForceSetText;
		}

		// Token: 0x060330F3 RID: 209139 RVA: 0x00CC997C File Offset: 0x00CC7B7C
		public void SetNameTextVisible(bool bVisible)
		{
			UUIText nameText = this.GetNameText();
			if (nameText == null)
			{
				return;
			}
			nameText.SetUIActive(bVisible);
		}

		// Token: 0x060330F4 RID: 209140 RVA: 0x00CC999C File Offset: 0x00CC7B9C
		private void SetLongPressItemVisible(bool bVisible)
		{
			UUIItem longPressItem = this.GetLongPressItem();
			if (longPressItem == null)
			{
				return;
			}
			if (longPressItem.bIsUIActive == bVisible)
			{
				return;
			}
			longPressItem.SetUIActive(bVisible);
		}

		// Token: 0x060330F5 RID: 209141 RVA: 0x00CC99C5 File Offset: 0x00CC7BC5
		public void SetLongPressState(float percent)
		{
			this.SetLongPressPercent(percent);
			this.SetLongPressTipTextureActive(percent == 0f);
		}

		// Token: 0x060330F6 RID: 209142 RVA: 0x00CC99DC File Offset: 0x00CC7BDC
		public void SetLongPressItemAlpha(float alpha)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAlpha(alpha);
		}

		// Token: 0x060330F7 RID: 209143 RVA: 0x00CC99EF File Offset: 0x00CC7BEF
		private void SetLongPressPercent(float percent)
		{
			if (this.PcAndGamepad == null)
			{
				return;
			}
			this.PcAndGamepad.SetProgressPercent(percent);
		}

		// Token: 0x060330F8 RID: 209144 RVA: 0x00CC9A08 File Offset: 0x00CC7C08
		private void SetLongPressTipTextureActive(bool active)
		{
			UUITexture longPressTipTexture = this.GetLongPressTipTexture();
			if (longPressTipTexture == null)
			{
				return;
			}
			longPressTipTexture.SetUIActive(active);
		}

		// Token: 0x060330F9 RID: 209145 RVA: 0x00CC9A27 File Offset: 0x00CC7C27
		public void SetHotKeyType(HotKeyTypeBase hotKeyType)
		{
			this.HotKeyType = hotKeyType;
		}

		// Token: 0x060330FA RID: 209146 RVA: 0x00CC9A30 File Offset: 0x00CC7C30
		public void RefreshPcAndGamepad()
		{
			if (this.IsNeedLongPress)
			{
				PcAndGamepadProgressBar pcAndGamepad = this.PcAndGamepad;
				if (pcAndGamepad == null)
				{
					return;
				}
				pcAndGamepad.RefreshProgressVisible();
			}
		}

		// Token: 0x060330FB RID: 209147 RVA: 0x00CC9A4A File Offset: 0x00CC7C4A
		public override void SetActive(bool value)
		{
			base.SetActive(value);
			HotKeyTypeBase hotKeyType = this.HotKeyType;
			if (hotKeyType == null)
			{
				return;
			}
			hotKeyType.KeyItemNotifySetActive(value);
		}

		// Token: 0x0401DB06 RID: 121606
		private bool IsForceSetText;

		// Token: 0x0401DB07 RID: 121607
		[Nullable(2)]
		private HotKeyTypeBase HotKeyType;

		// Token: 0x0401DB08 RID: 121608
		[Nullable(2)]
		private PcAndGamepadProgressBar PcAndGamepad;

		// Token: 0x0401DB09 RID: 121609
		[Nullable(2)]
		private string KeyName;

		// Token: 0x0401DB0A RID: 121610
		private bool IsNeedLongPress;

		// Token: 0x0401DB0B RID: 121611
		private string KeyIconPath = "";
	}
}
