using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056F2 RID: 22258
	[NullableContext(2)]
	[Nullable(0)]
	public class MovieModeUiView : UiPanelBase
	{
		// Token: 0x06038A3F RID: 231999 RVA: 0x00E57A98 File Offset: 0x00E55C98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038A40 RID: 232000 RVA: 0x00E57B64 File Offset: 0x00E55D64
		protected override void OnStart()
		{
			this.AddEvents();
			this.InitParameter();
			this.InitMaskBtn();
			this.InitExitBtn();
			this.InitRightDownButtons();
			this.ApplyMovieAspectOffset();
			this.AddTick();
			this.RefreshUiVisible();
		}

		// Token: 0x06038A41 RID: 232001 RVA: 0x00E57B98 File Offset: 0x00E55D98
		private void InitParameter()
		{
			IEnterMovieModeParams enterMovieModeParams = this.OpenParam as IEnterMovieModeParams;
			this.DelayShowUiDuration = ((enterMovieModeParams != null) ? enterMovieModeParams.DelayDuration : null).GetValueOrDefault();
			this.DelayShowUiDuration *= 1000f;
			this.IsCanShowUi = (this.DelayShowUiDuration == 0f);
		}

		// Token: 0x06038A42 RID: 232002 RVA: 0x00E57BF8 File Offset: 0x00E55DF8
		private void InitMaskBtn()
		{
			this.MaskBtn = base.GetButton(0);
			UUIButtonComponent maskBtn = this.MaskBtn;
			if (maskBtn == null)
			{
				return;
			}
			maskBtn.OnClickCallBack.Bind(new Action(this.OnClickMaskBtn));
		}

		// Token: 0x06038A43 RID: 232003 RVA: 0x00E57C28 File Offset: 0x00E55E28
		private void OnClickMaskBtn()
		{
			ControllerBase<MovieModeController>.Instance.ResetMovieModeHideUi(false);
		}

		// Token: 0x06038A44 RID: 232004 RVA: 0x00E57C35 File Offset: 0x00E55E35
		private void OnMovieModeHideUiChange(bool isHide)
		{
			this.HandleMovieModeHideUiChange(isHide);
		}

		// Token: 0x06038A45 RID: 232005 RVA: 0x00E57C3E File Offset: 0x00E55E3E
		private void HandleMovieModeHideUiChange(bool isHide)
		{
			if (this.IsMovieModeHideUi == isHide)
			{
				return;
			}
			this.IsMovieModeHideUi = isHide;
			this.RefreshUiVisible();
		}

		// Token: 0x06038A46 RID: 232006 RVA: 0x00E57C57 File Offset: 0x00E55E57
		private void InitExitBtn()
		{
			this.ExitBtn = base.GetButton(1);
			UUIButtonComponent exitBtn = this.ExitBtn;
			if (exitBtn == null)
			{
				return;
			}
			exitBtn.OnClickCallBack.Bind(new Action(this.OnClickExitBtn));
		}

		// Token: 0x06038A47 RID: 232007 RVA: 0x00E57C88 File Offset: 0x00E55E88
		private void OnClickExitBtn()
		{
			ExitMovieModeParams param = new ExitMovieModeParams
			{
				BlendTime = (float)ConfigCommonParamById.GetIntConfig("ExitMovieModeTimeThreshold").GetValueOrDefault(1)
			};
			ControllerBase<MovieModeController>.Instance.ExitMovieMode(param, null);
		}

		// Token: 0x06038A48 RID: 232008 RVA: 0x00E57CC2 File Offset: 0x00E55EC2
		private void InitRightDownButtons()
		{
			this.InitPhotoBtn();
		}

		// Token: 0x06038A49 RID: 232009 RVA: 0x00E57CCA File Offset: 0x00E55ECA
		private void InitPhotoBtn()
		{
			this.PhotoBtn = base.GetButton(2);
			UUIButtonComponent photoBtn = this.PhotoBtn;
			if (photoBtn == null)
			{
				return;
			}
			photoBtn.OnClickCallBack.Bind(new Action(this.OnClickPhotoBtn));
		}

		// Token: 0x06038A4A RID: 232010 RVA: 0x00E57CFC File Offset: 0x00E55EFC
		private void OnClickPhotoBtn()
		{
			ControllerBase<PhotographController>.Instance.ScreenShot(new PhotoSaveViewParam
			{
				ScreenShot = true,
				PrepareFullScreenShot = false,
				IsHiddenBattleView = true,
				HandBookPhotoData = null,
				GachaData = null,
				FragmentMemory = null,
				RoleSkinData = null,
				ShareId = 1
			});
		}

		// Token: 0x06038A4B RID: 232011 RVA: 0x00E57D50 File Offset: 0x00E55F50
		public void OnTick(float deltaTime)
		{
			this.OnTickCanShowUi(deltaTime);
		}

		// Token: 0x06038A4C RID: 232012 RVA: 0x00E57D59 File Offset: 0x00E55F59
		private void OnTickCanShowUi(float deltaTime)
		{
			if (this.IsCanShowUi)
			{
				return;
			}
			this.DelayShowUiDuration -= deltaTime;
			if (this.DelayShowUiDuration <= 0f)
			{
				this.IsCanShowUi = true;
				ControllerBase<MovieModeController>.Instance.ResetMovieModeHideUi(false);
			}
		}

		// Token: 0x06038A4D RID: 232013 RVA: 0x00E57D91 File Offset: 0x00E55F91
		private void AddTick()
		{
			this.TickHandle = ControllerBase<MovieModeController>.Instance.AddTick(new Action<float>(this.OnTick));
		}

		// Token: 0x06038A4E RID: 232014 RVA: 0x00E57DAF File Offset: 0x00E55FAF
		private void RemoveTick()
		{
			ControllerBase<MovieModeController>.Instance.RemoveTick(this.TickHandle);
			this.TickHandle = -1;
		}

		// Token: 0x06038A4F RID: 232015 RVA: 0x00E57DC8 File Offset: 0x00E55FC8
		private void ApplyMovieAspectOffset()
		{
			IMovieModeAspectOffset aspectOffset = ControllerBase<MovieModeController>.Instance.GetAspectOffset();
			if (aspectOffset == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MovieMode, ELogAuthor.CB, "MovieModeUiView:MovieModeController.GetAspectOffset is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FVector2D anchorOffset = base.GetButton(1).RootUIComp.Get().GetAnchorOffset();
			FVector2D anchorOffset2 = base.GetItem(4).GetAnchorOffset();
			if (aspectOffset.IsWidthBlend)
			{
				UUIButtonComponent button = base.GetButton(1);
				if (button != null)
				{
					button.RootUIComp.Get().SetAnchorOffsetX(anchorOffset.X - aspectOffset.Offset);
				}
				UUIItem item = base.GetItem(4);
				if (item == null)
				{
					return;
				}
				item.SetAnchorOffsetX(anchorOffset2.X - aspectOffset.Offset);
				return;
			}
			else
			{
				UUIButtonComponent button2 = base.GetButton(1);
				if (button2 != null)
				{
					button2.RootUIComp.Get().SetAnchorOffsetY(anchorOffset.Y - aspectOffset.Offset);
				}
				UUIItem item2 = base.GetItem(4);
				if (item2 == null)
				{
					return;
				}
				item2.SetAnchorOffsetY(anchorOffset2.Y + aspectOffset.Offset);
				return;
			}
		}

		// Token: 0x06038A50 RID: 232016 RVA: 0x00E57ECA File Offset: 0x00E560CA
		private void RefreshUiVisible()
		{
			this.RefreshExitBtnVisible();
			this.RefreshPhotoBtnVisible();
			this.RefreshMaskBtnVisible();
		}

		// Token: 0x06038A51 RID: 232017 RVA: 0x00E57EE0 File Offset: 0x00E560E0
		private void RefreshExitBtnVisible()
		{
			IEnterMovieModeParams enterMovieModeParams = this.OpenParam as IEnterMovieModeParams;
			bool valueOrDefault = ((enterMovieModeParams != null) ? enterMovieModeParams.IsEnableEsc : null).GetValueOrDefault();
			UUIButtonComponent exitBtn = this.ExitBtn;
			if (exitBtn == null)
			{
				return;
			}
			UUIItem uuiitem = exitBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(!this.IsMovieModeHideUi && valueOrDefault && this.IsCanShowUi);
		}

		// Token: 0x06038A52 RID: 232018 RVA: 0x00E57F50 File Offset: 0x00E56150
		private void RefreshPhotoBtnVisible()
		{
			IEnterMovieModeParams enterMovieModeParams = this.OpenParam as IEnterMovieModeParams;
			bool valueOrDefault = ((enterMovieModeParams != null) ? enterMovieModeParams.IsEnablePhoto : null).GetValueOrDefault();
			UUIButtonComponent photoBtn = this.PhotoBtn;
			if (photoBtn == null)
			{
				return;
			}
			UUIItem uuiitem = photoBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(!this.IsMovieModeHideUi && valueOrDefault && this.IsCanShowUi);
		}

		// Token: 0x06038A53 RID: 232019 RVA: 0x00E57FC0 File Offset: 0x00E561C0
		private void RefreshMaskBtnVisible()
		{
			UUIButtonComponent maskBtn = this.MaskBtn;
			if (maskBtn == null)
			{
				return;
			}
			UUIItem uuiitem = maskBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(this.IsMovieModeHideUi);
		}

		// Token: 0x06038A54 RID: 232020 RVA: 0x00E57FF5 File Offset: 0x00E561F5
		private void TryActivateTimer()
		{
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				ControllerBase<MovieModeController>.Instance.ResetMovieModeHideUi(true);
				this.DeactivateTimer();
			}, (float)ModelBase<MovieModeModel>.Instance.MovieModeHideUiTimeThreshold, null, null, true, 1f);
		}

		// Token: 0x06038A55 RID: 232021 RVA: 0x00E58026 File Offset: 0x00E56226
		private void DeactivateTimer()
		{
			if (this.TimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.TimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x06038A56 RID: 232022 RVA: 0x00E5805A File Offset: 0x00E5625A
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
			Singleton<EventSystem>.Instance.Add(EEventName.MovieModeHideUiChange, new Action<bool>(this.OnMovieModeHideUiChange));
		}

		// Token: 0x06038A57 RID: 232023 RVA: 0x00E58094 File Offset: 0x00E56294
		[NullableContext(1)]
		private void OnInputAnyKey(bool bPress, FKey key)
		{
			if (bPress)
			{
				this.DeactivateTimer();
				this.IsAnyKeyPressed = true;
				ControllerBase<MovieModeController>.Instance.ResetMovieModeHideUi(false);
				return;
			}
			if (this.IsAnyKeyPressed)
			{
				this.ActivateTimer();
				this.IsAnyKeyPressed = false;
			}
		}

		// Token: 0x06038A58 RID: 232024 RVA: 0x00E580C7 File Offset: 0x00E562C7
		public void ActivateTimer()
		{
			this.DeactivateTimer();
			this.TryActivateTimer();
		}

		// Token: 0x06038A59 RID: 232025 RVA: 0x00E580D5 File Offset: 0x00E562D5
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
			Singleton<EventSystem>.Instance.Remove(EEventName.MovieModeHideUiChange, new Action<bool>(this.OnMovieModeHideUiChange));
		}

		// Token: 0x06038A5A RID: 232026 RVA: 0x00E5810F File Offset: 0x00E5630F
		protected override void OnBeforeDestroy()
		{
			this.RemoveTick();
			this.RemoveEvents();
			this.DeactivateTimer();
		}

		// Token: 0x040204DD RID: 132317
		private UUIButtonComponent ExitBtn;

		// Token: 0x040204DE RID: 132318
		private UUIButtonComponent PhotoBtn;

		// Token: 0x040204DF RID: 132319
		private UUIButtonComponent MaskBtn;

		// Token: 0x040204E0 RID: 132320
		private int TickHandle = -1;

		// Token: 0x040204E1 RID: 132321
		private float DelayShowUiDuration;

		// Token: 0x040204E2 RID: 132322
		private bool IsCanShowUi;

		// Token: 0x040204E3 RID: 132323
		private bool IsMovieModeHideUi;

		// Token: 0x040204E4 RID: 132324
		private TimerHandle TimerHandle;

		// Token: 0x040204E5 RID: 132325
		private bool IsAnyKeyPressed;

		// Token: 0x0200B769 RID: 46953
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04038B96 RID: 232342
			BtnMask,
			// Token: 0x04038B97 RID: 232343
			BtnExit,
			// Token: 0x04038B98 RID: 232344
			BtnPhoto,
			// Token: 0x04038B99 RID: 232345
			SpriteBtnPhotoIcon,
			// Token: 0x04038B9A RID: 232346
			RightDownBtnRoot
		}
	}
}
