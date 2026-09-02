using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006048 RID: 24648
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class KeyItemBase : UiPanelBase
	{
		// Token: 0x0603E2C8 RID: 254664 RVA: 0x00FE004E File Offset: 0x00FDE24E
		protected override void OnStartImplement()
		{
			this.AddEvents();
		}

		// Token: 0x0603E2C9 RID: 254665 RVA: 0x00FE0056 File Offset: 0x00FDE256
		protected override void OnBeforeDestroyImplement()
		{
			this.UnBindAction();
			this.RemoveEvents();
			this.Reset();
		}

		// Token: 0x0603E2CA RID: 254666 RVA: 0x00FE006A File Offset: 0x00FDE26A
		public virtual void Reset()
		{
			this.CustomKeyName = null;
			this.KeyName = null;
			this.ActionName = null;
			this.AxisName = null;
			this.KeyTexturePath = null;
		}

		// Token: 0x0603E2CB RID: 254667 RVA: 0x00FE008F File Offset: 0x00FDE28F
		public void SetCustomKeyName(string keyName)
		{
			this.CustomKeyName = keyName;
		}

		// Token: 0x0603E2CC RID: 254668 RVA: 0x00FE0098 File Offset: 0x00FDE298
		public virtual void RefreshAction(string actionName)
		{
			this.UnBindAction();
			this.ActionName = actionName;
			this.AxisName = null;
			if (!string.IsNullOrEmpty(this.CustomKeyName))
			{
				this.RefreshKey(Singleton<InputSettings>.Instance.GetKey(this.CustomKeyName));
			}
			else
			{
				InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding(this.ActionName);
				if (actionBinding == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "[KeyItem]刷新按键图标时找不到对应Action";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionName", this.ActionName);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				InputKey currentPlatformKey = actionBinding.GetCurrentPlatformKey();
				if (currentPlatformKey == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Battle;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "[KeyItem]刷新按键图标时Action没有对应按键";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("actionName", this.ActionName);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				this.RefreshKey(currentPlatformKey);
			}
			this.BindAction();
		}

		// Token: 0x0603E2CD RID: 254669 RVA: 0x00FE0164 File Offset: 0x00FDE364
		public virtual void RefreshAxis(string axisName)
		{
			this.UnBindAction();
			this.AxisName = axisName;
			this.ActionName = null;
			if (!string.IsNullOrEmpty(this.CustomKeyName))
			{
				this.RefreshKey(Singleton<InputSettings>.Instance.GetKey(this.CustomKeyName));
				return;
			}
			InputAxisBinding axisBinding = Singleton<InputSettingsManager>.Instance.GetAxisBinding(axisName);
			if (axisBinding == null)
			{
				return;
			}
			InputAxisKey currentPlatformKey = axisBinding.GetCurrentPlatformKey();
			if (currentPlatformKey == null)
			{
				return;
			}
			this.RefreshKey(currentPlatformKey.GetKey());
		}

		// Token: 0x0603E2CE RID: 254670 RVA: 0x00FE01D0 File Offset: 0x00FDE3D0
		protected void BindAction()
		{
			if (!StringUtils.IsEmpty(this.ActionName))
			{
				ControllerBase<InputDistributeController>.Instance.BindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputActionInternal));
			}
		}

		// Token: 0x0603E2CF RID: 254671 RVA: 0x00FE01FB File Offset: 0x00FDE3FB
		protected void UnBindAction()
		{
			if (!StringUtils.IsEmpty(this.ActionName))
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputActionInternal));
			}
		}

		// Token: 0x0603E2D0 RID: 254672 RVA: 0x00FE0228 File Offset: 0x00FDE428
		protected virtual void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnAxisKeyChanged, new Action<string>(this.OnAxisKeyChanged));
		}

		// Token: 0x0603E2D1 RID: 254673 RVA: 0x00FE028C File Offset: 0x00FDE48C
		protected virtual void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAxisKeyChanged, new Action<string>(this.OnAxisKeyChanged));
		}

		// Token: 0x0603E2D2 RID: 254674 RVA: 0x00FE02ED File Offset: 0x00FDE4ED
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (!StringUtils.IsEmpty(this.ActionName))
			{
				this.RefreshAction(this.ActionName);
				return;
			}
			if (!StringUtils.IsEmpty(this.AxisName))
			{
				this.RefreshAxis(this.AxisName);
			}
		}

		// Token: 0x0603E2D3 RID: 254675 RVA: 0x00FE0322 File Offset: 0x00FDE522
		private void OnActionKeyChanged(string actionName)
		{
			if (!StringUtils.IsEmpty(this.ActionName) && this.ActionName == actionName)
			{
				this.RefreshAction(this.ActionName);
			}
		}

		// Token: 0x0603E2D4 RID: 254676 RVA: 0x00FE034B File Offset: 0x00FDE54B
		private void OnAxisKeyChanged(string axisName)
		{
			if (!StringUtils.IsEmpty(this.AxisName) && this.AxisName == axisName)
			{
				this.RefreshAxis(this.AxisName);
			}
		}

		// Token: 0x0603E2D5 RID: 254677 RVA: 0x00FE0374 File Offset: 0x00FDE574
		private void OnInputActionInternal(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			this.OnInputAction(actionName, actionType);
		}

		// Token: 0x0603E2D6 RID: 254678 RVA: 0x00FE037E File Offset: 0x00FDE57E
		protected virtual void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType)
		{
		}

		// Token: 0x0603E2D7 RID: 254679 RVA: 0x00FE0380 File Offset: 0x00FDE580
		public void RefreshKey(InputKey key)
		{
			string keyName = key.GetKeyName();
			string keyIconPath = key.GetKeyIconPath();
			if (this.KeyName == keyName && this.KeyTexturePath == keyIconPath)
			{
				return;
			}
			if (StringUtils.IsEmpty(keyIconPath))
			{
				this.SetKeyText(keyName);
			}
			else
			{
				this.SetKeyTexture(keyIconPath);
			}
			this.KeyName = keyName;
		}

		// Token: 0x0603E2D8 RID: 254680 RVA: 0x00FE03D8 File Offset: 0x00FDE5D8
		public void RefreshKeyByName(string keyName)
		{
			InputKey key = Singleton<InputSettings>.Instance.GetKey(keyName);
			if (key == null)
			{
				return;
			}
			this.RefreshKey(key);
		}

		// Token: 0x0603E2D9 RID: 254681 RVA: 0x00FE03FC File Offset: 0x00FDE5FC
		public void SetKeyText(string keyName)
		{
			UUIText keyText = this.GetKeyText();
			UUITexture keyTexture = this.GetKeyTexture();
			if (keyTexture != null)
			{
				keyTexture.SetUIActive(false);
			}
			if (keyText != null)
			{
				if (StringUtils.IsEmpty(keyName))
				{
					keyText.SetUIActive(false);
					return;
				}
				keyText.SetText(keyName, true);
				keyText.SetUIActive(true);
			}
		}

		// Token: 0x0603E2DA RID: 254682 RVA: 0x00FE0444 File Offset: 0x00FDE644
		public void SetLocalText(string textTableId, params object[] args)
		{
			UUIText keyText = this.GetKeyText();
			UUITexture keyTexture = this.GetKeyTexture();
			if (keyTexture != null)
			{
				keyTexture.SetUIActive(false);
			}
			if (keyText != null)
			{
				if (StringUtils.IsEmpty(textTableId))
				{
					keyText.SetUIActive(false);
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalText(keyText, textTableId, args);
				keyText.SetUIActive(true);
			}
		}

		// Token: 0x0603E2DB RID: 254683 RVA: 0x00FE0494 File Offset: 0x00FDE694
		private void SetKeyTexture(string keyTexturePath)
		{
			UUIText keyText = this.GetKeyText();
			if (keyText != null)
			{
				keyText.SetUIActive(false);
			}
			UUITexture keyTexture = this.GetKeyTexture();
			if (keyTexture == null)
			{
				return;
			}
			keyTexture.SetUIActive(false);
			if (StringUtils.IsEmpty(keyTexturePath))
			{
				return;
			}
			this.KeyTexturePath = keyTexturePath;
			base.SetTextureByPath(keyTexturePath, keyTexture, null, delegate(bool _)
			{
				if (this.KeyTexturePath != keyTexturePath)
				{
					return;
				}
				keyTexture.SetSizeFromTexture();
				keyTexture.SetUIActive(true);
			});
		}

		// Token: 0x0603E2DC RID: 254684 RVA: 0x00FE0529 File Offset: 0x00FDE729
		public void SetEnable(bool bEnable, bool bForce = false)
		{
			if (this.IsEnable == bEnable && !bForce)
			{
				return;
			}
			if (bEnable)
			{
				this.RootItem.SetAlpha(1f);
			}
			else
			{
				this.RootItem.SetAlpha(0.2f);
			}
			this.IsEnable = bEnable;
		}

		// Token: 0x0603E2DD RID: 254685 RVA: 0x00FE0564 File Offset: 0x00FDE764
		public void SetGray(bool bIsGray)
		{
			if (this.IsGray == bIsGray)
			{
				return;
			}
			this.IsGray = bIsGray;
			this.OnSetGray();
		}

		// Token: 0x0603E2DE RID: 254686 RVA: 0x00FE057D File Offset: 0x00FDE77D
		protected virtual void OnSetGray()
		{
		}

		// Token: 0x0603E2DF RID: 254687
		[NullableContext(2)]
		protected abstract UUIText GetKeyText();

		// Token: 0x0603E2E0 RID: 254688
		[NullableContext(2)]
		protected abstract UUITexture GetKeyTexture();

		// Token: 0x04022DB0 RID: 142768
		[Nullable(2)]
		protected string ActionName;

		// Token: 0x04022DB1 RID: 142769
		[Nullable(2)]
		protected string AxisName;

		// Token: 0x04022DB2 RID: 142770
		[Nullable(2)]
		private string CustomKeyName;

		// Token: 0x04022DB3 RID: 142771
		[Nullable(2)]
		protected string KeyName;

		// Token: 0x04022DB4 RID: 142772
		[Nullable(2)]
		protected string KeyTexturePath;

		// Token: 0x04022DB5 RID: 142773
		protected bool IsEnable;

		// Token: 0x04022DB6 RID: 142774
		protected bool IsGray;

		// Token: 0x04022DB7 RID: 142775
		private const float DISABLE_ALPHA = 0.2f;
	}
}
