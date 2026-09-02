using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Controller
{
	// Token: 0x0200705D RID: 28765
	[NullableContext(1)]
	[Nullable(0)]
	public class TsPureUiKeyHandle
	{
		// Token: 0x06045A69 RID: 285289 RVA: 0x01233875 File Offset: 0x01231A75
		public void Initialize(TsCharacterController playerController)
		{
			this.PlayerController = playerController;
		}

		// Token: 0x06045A6A RID: 285290 RVA: 0x01233880 File Offset: 0x01231A80
		public void Reset()
		{
			this.PlayerController = null;
			if (this.OnSetUiRootActiveDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FKey>(this.OnSetUiRootActive));
				this.OnSetUiRootActiveDelegate = null;
			}
			if (this.OnSetUiRootDeactivateDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FKey>(this.OnSetUiRootDeactivate));
				this.OnSetUiRootDeactivateDelegate = null;
			}
		}

		// Token: 0x06045A6B RID: 285291 RVA: 0x012338D4 File Offset: 0x01231AD4
		public void BindKey()
		{
			if (this.PlayerController == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.WLJ, "[TsPureUiKeyHandle::BindTouch]PlayerController为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.OnSetUiRootActiveDelegate == null)
			{
				this.OnSetUiRootActiveDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKeyBindingDelegate>(new Action<FKey>(this.OnSetUiRootActive));
			}
			UKuroInputDelegateLibrary.RegisterKeyBinding(new FInputChord(new FKey(TsPureUiKeyHandle.LEFT_BARACKET_NAME), false, false, false, false), EInputEvent.IE_Released, this.PlayerController, this.OnSetUiRootActiveDelegate);
			if (this.OnSetUiRootDeactivateDelegate == null)
			{
				this.OnSetUiRootDeactivateDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKeyBindingDelegate>(new Action<FKey>(this.OnSetUiRootDeactivate));
			}
			UKuroInputDelegateLibrary.RegisterKeyBinding(new FInputChord(new FKey(TsPureUiKeyHandle.RIGHT_BARACKET_NAME), false, false, false, false), EInputEvent.IE_Released, this.PlayerController, this.OnSetUiRootDeactivateDelegate);
		}

		// Token: 0x06045A6C RID: 285292 RVA: 0x01233990 File Offset: 0x01231B90
		private void OnSetUiRootActive(FKey key)
		{
			if (ModelBase<SundryModel>.Instance.CanOpenGmView)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "按下 】 键显示所有界面", default(ReadOnlySpan<ValueTuple<string, object>>));
				Singleton<UiLayer>.Instance.ForceShowUi();
			}
		}

		// Token: 0x06045A6D RID: 285293 RVA: 0x012339D0 File Offset: 0x01231BD0
		private void OnSetUiRootDeactivate(FKey key)
		{
			if (ModelBase<SundryModel>.Instance.CanOpenGmView)
			{
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "按下 【 键隐藏所有界面", default(ReadOnlySpan<ValueTuple<string, object>>));
				Singleton<UiLayer>.Instance.ForceHideUi();
			}
		}

		// Token: 0x04026E21 RID: 159265
		private static readonly FName LEFT_BARACKET_NAME = new FName("LeftBracket");

		// Token: 0x04026E22 RID: 159266
		private static readonly FName RIGHT_BARACKET_NAME = new FName("RightBracket");

		// Token: 0x04026E23 RID: 159267
		[Nullable(2)]
		private TsCharacterController PlayerController;

		// Token: 0x04026E24 RID: 159268
		[Nullable(2)]
		private FKeyBindingDelegate OnSetUiRootActiveDelegate;

		// Token: 0x04026E25 RID: 159269
		[Nullable(2)]
		private FKeyBindingDelegate OnSetUiRootDeactivateDelegate;
	}
}
