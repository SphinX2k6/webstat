using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.SkillButtonUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006046 RID: 24646
	[NullableContext(2)]
	[Nullable(0)]
	public class CombineKeyItem : KeyItemBase
	{
		// Token: 0x0603E2B5 RID: 254645 RVA: 0x00FDFA4C File Offset: 0x00FDDC4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E2B6 RID: 254646 RVA: 0x00FDFAD6 File Offset: 0x00FDDCD6
		public override void Reset()
		{
			base.Reset();
			this.SubKeyTexturePath = null;
		}

		// Token: 0x0603E2B7 RID: 254647 RVA: 0x00FDFAE5 File Offset: 0x00FDDCE5
		protected override void AddEvents()
		{
			base.AddEvents();
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiSwitchInteractStateChanged, new Action(this.OnSwitchInteractStateChanged));
		}

		// Token: 0x0603E2B8 RID: 254648 RVA: 0x00FDFB09 File Offset: 0x00FDDD09
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiSwitchInteractStateChanged, new Action(this.OnSwitchInteractStateChanged));
		}

		// Token: 0x0603E2B9 RID: 254649 RVA: 0x00FDFB2D File Offset: 0x00FDDD2D
		private void OnSwitchInteractStateChanged()
		{
			if (Singleton<Info>.Instance.IsInGamepad() && this.ActionName == "幻象1")
			{
				this.RefreshAction(this.ActionName);
			}
		}

		// Token: 0x0603E2BA RID: 254650 RVA: 0x00FDFB59 File Offset: 0x00FDDD59
		protected override UUIText GetKeyText()
		{
			return null;
		}

		// Token: 0x0603E2BB RID: 254651 RVA: 0x00FDFB5C File Offset: 0x00FDDD5C
		protected override UUITexture GetKeyTexture()
		{
			return base.GetTexture(0);
		}

		// Token: 0x0603E2BC RID: 254652 RVA: 0x00FDFB68 File Offset: 0x00FDDD68
		[NullableContext(1)]
		public override void RefreshAction(string actionName)
		{
			if (this.ActionName != actionName)
			{
				base.UnBindAction();
				this.ActionName = actionName;
				this.AxisName = null;
				base.BindAction();
			}
			if (this.CheckGamepadSwitchInteract())
			{
				return;
			}
			InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(this.ActionName);
			if (combinationActionBindingByActionName != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				combinationActionBindingByActionName.GetCurrentPlatformKeyNameMap(dictionary);
				using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, string> keyValuePair = enumerator.Current;
						string key = keyValuePair.Key;
						string value = keyValuePair.Value;
						base.RefreshKey(Singleton<InputSettings>.Instance.GetKey(key));
						this.RefreshSubKey(Singleton<InputSettings>.Instance.GetKey(value));
						base.GetTexture(2).SetUIActive(true);
						base.GetText(1).SetUIActive(!this.IsHideMainKey);
						this.GetKeyTexture().SetUIActive(!this.IsHideMainKey);
						this.IsCombineKey = true;
						return;
					}
				}
			}
			this.IsCombineKey = false;
			base.GetTexture(2).SetUIActive(false);
			base.GetText(1).SetUIActive(false);
			this.GetKeyTexture().SetUIActive(!this.IsHideMainKey);
			if (Singleton<InputSettingsManager>.Instance.GetActionBinding(this.ActionName) != null)
			{
				base.RefreshAction(actionName);
			}
		}

		// Token: 0x0603E2BD RID: 254653 RVA: 0x00FDFCCC File Offset: 0x00FDDECC
		private bool CheckGamepadSwitchInteract()
		{
			if (Singleton<Info>.Instance.IsInGamepad() && this.ActionName == "幻象1")
			{
				SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
				if (gamepadData != null && gamepadData.SwitchInteractData.State == EGamepadSwitchInteractState.Explore)
				{
					InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName("通用交互");
					if (combinationActionBindingByActionName != null)
					{
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						combinationActionBindingByActionName.GetCurrentPlatformKeyNameMap(dictionary);
						using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								KeyValuePair<string, string> keyValuePair = enumerator.Current;
								string key = keyValuePair.Key;
								string value = keyValuePair.Value;
								base.RefreshKey(Singleton<InputSettings>.Instance.GetKey(key));
								this.RefreshSubKey(Singleton<InputSettings>.Instance.GetKey(value));
								base.GetTexture(2).SetUIActive(true);
								base.GetText(1).SetUIActive(!this.IsHideMainKey);
								this.GetKeyTexture().SetUIActive(!this.IsHideMainKey);
								this.IsCombineKey = true;
								return true;
							}
						}
					}
					this.IsCombineKey = false;
					base.GetTexture(2).SetUIActive(false);
					base.GetText(1).SetUIActive(false);
					this.GetKeyTexture().SetUIActive(!this.IsHideMainKey);
					InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding("通用交互");
					InputKey inputKey = (actionBinding != null) ? actionBinding.GetCurrentPlatformKey() : null;
					if (inputKey != null)
					{
						base.RefreshKey(inputKey);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603E2BE RID: 254654 RVA: 0x00FDFE60 File Offset: 0x00FDE060
		[NullableContext(1)]
		public void RefreshSubKey(InputKey key)
		{
			string keyName = key.GetKeyName();
			if (this.SubKeyName == keyName)
			{
				return;
			}
			string keyTexturePath = key.GetKeyIconPath();
			if (!string.IsNullOrEmpty(keyTexturePath))
			{
				UUITexture keyTexture = base.GetTexture(2);
				keyTexture.SetUIActive(false);
				this.SubKeyTexturePath = keyTexturePath;
				base.SetTextureByPath(keyTexturePath, keyTexture, null, delegate(bool _)
				{
					if (this.SubKeyTexturePath != keyTexturePath)
					{
						return;
					}
					keyTexture.SetSizeFromTexture();
					keyTexture.SetUIActive(true);
				});
			}
			this.SubKeyName = keyName;
		}

		// Token: 0x0603E2BF RID: 254655 RVA: 0x00FDFEFC File Offset: 0x00FDE0FC
		public void HideMainKey(bool bHide)
		{
			if (this.IsHideMainKey == bHide)
			{
				return;
			}
			this.IsHideMainKey = bHide;
			base.GetText(1).SetUIActive(!this.IsHideMainKey && this.IsCombineKey);
			this.GetKeyTexture().SetUIActive(!this.IsHideMainKey || !this.IsCombineKey);
		}

		// Token: 0x0603E2C0 RID: 254656 RVA: 0x00FDFF58 File Offset: 0x00FDE158
		protected override void OnSetGray()
		{
			UUITexture texture = base.GetTexture(0);
			UUIItem uuiitem = texture;
			bool isGray = this.IsGray;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(isGray, fcolor);
			UUITexture texture2 = base.GetTexture(2);
			UUIItem uuiitem2 = texture2;
			bool isGray2 = this.IsGray;
			fcolor = new FColor?(texture2.changeColor);
			uuiitem2.SetChangeColor(isGray2, fcolor);
		}

		// Token: 0x0603E2C1 RID: 254657 RVA: 0x00FDFFA9 File Offset: 0x00FDE1A9
		public string GetKeyName()
		{
			return this.KeyName;
		}

		// Token: 0x04022DAC RID: 142764
		[Nullable(1)]
		private string SubKeyName = string.Empty;

		// Token: 0x04022DAD RID: 142765
		private string SubKeyTexturePath;

		// Token: 0x04022DAE RID: 142766
		private bool IsHideMainKey;

		// Token: 0x04022DAF RID: 142767
		private bool IsCombineKey;

		// Token: 0x0200C106 RID: 49414
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B710 RID: 243472
			KeyTextureMain,
			// Token: 0x0403B711 RID: 243473
			AddText,
			// Token: 0x0403B712 RID: 243474
			KeyTextureSub
		}
	}
}
