using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x0200614B RID: 24907
	public class AutoPilotPcView : AutoPilotView
	{
		// Token: 0x0603EEC8 RID: 257736 RVA: 0x01021168 File Offset: 0x0101F368
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EEC9 RID: 257737 RVA: 0x010212B9 File Offset: 0x0101F4B9
		protected override int GetSkipBtnCompId()
		{
			return 4;
		}

		// Token: 0x0603EECA RID: 257738 RVA: 0x010212BC File Offset: 0x0101F4BC
		protected override int GetRideShareBtnCompId()
		{
			return 6;
		}

		// Token: 0x0603EECB RID: 257739 RVA: 0x010212BF File Offset: 0x0101F4BF
		protected override int GetExitBtnCompId()
		{
			return 7;
		}

		// Token: 0x0603EECC RID: 257740 RVA: 0x010212C2 File Offset: 0x0101F4C2
		protected override int GetPhotoBtnCompId()
		{
			return 0;
		}

		// Token: 0x0603EECD RID: 257741 RVA: 0x010212C5 File Offset: 0x0101F4C5
		protected override int GetMovieBtnCompId()
		{
			return 1;
		}

		// Token: 0x0603EECE RID: 257742 RVA: 0x010212C8 File Offset: 0x0101F4C8
		protected override int GetMovieBtnProgressCompId()
		{
			return 2;
		}

		// Token: 0x0603EECF RID: 257743 RVA: 0x010212CB File Offset: 0x0101F4CB
		protected override void InitUi()
		{
			base.InitUi();
			this.InitMovieModePhotoBtn();
		}

		// Token: 0x0603EED0 RID: 257744 RVA: 0x010212D9 File Offset: 0x0101F4D9
		protected override void HandleClickSkipBtn()
		{
			ControllerBase<AutoPilotController>.Instance.SkipToTarget();
		}

		// Token: 0x0603EED1 RID: 257745 RVA: 0x010212E5 File Offset: 0x0101F4E5
		private void InitMovieModePhotoBtn()
		{
			this.MovieModePhotoBtn = base.GetButton(5);
			UUIButtonComponent movieModePhotoBtn = this.MovieModePhotoBtn;
			if (movieModePhotoBtn == null)
			{
				return;
			}
			movieModePhotoBtn.OnClickCallBack.Bind(new Action(base.OnClickPhotoBtn));
		}

		// Token: 0x0603EED2 RID: 257746 RVA: 0x01021315 File Offset: 0x0101F515
		protected override void RefreshUiVisible()
		{
			base.RefreshUiVisible();
			this.RefreshMovieModePhotoBtnVisible();
		}

		// Token: 0x0603EED3 RID: 257747 RVA: 0x01021323 File Offset: 0x0101F523
		protected override void RefreshUiByIsMovieModeHideUi()
		{
			base.RefreshUiByIsMovieModeHideUi();
			this.RefreshMovieModePhotoBtnVisible();
		}

		// Token: 0x0603EED4 RID: 257748 RVA: 0x01021331 File Offset: 0x0101F531
		protected override void RefreshUiByIsInMovieMode()
		{
			base.RefreshUiByIsInMovieMode();
			this.RefreshPhotoBtnVisible();
			this.RefreshMovieModePhotoBtnVisible();
		}

		// Token: 0x0603EED5 RID: 257749 RVA: 0x01021348 File Offset: 0x0101F548
		private void RefreshMovieModePhotoBtnVisible()
		{
			bool isInMovieMode = ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode();
			UUIButtonComponent movieModePhotoBtn = this.MovieModePhotoBtn;
			if (movieModePhotoBtn == null)
			{
				return;
			}
			UUIItem uuiitem = movieModePhotoBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(isInMovieMode && !this.IsMovieModeHideUi);
		}

		// Token: 0x0603EED6 RID: 257750 RVA: 0x01021394 File Offset: 0x0101F594
		protected override void RefreshPhotoBtnVisible()
		{
			bool isInMovieMode = ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode();
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
			uuiitem.SetUIActive(!isInMovieMode);
		}

		// Token: 0x040234FD RID: 144637
		[Nullable(2)]
		private UUIButtonComponent MovieModePhotoBtn;

		// Token: 0x0200C2DA RID: 49882
		private enum EAutoPilotPcComponents
		{
			// Token: 0x0403C137 RID: 246071
			PhotoBtn,
			// Token: 0x0403C138 RID: 246072
			MovieBtn,
			// Token: 0x0403C139 RID: 246073
			MovieBtnProgress,
			// Token: 0x0403C13A RID: 246074
			MovieBtnIcon,
			// Token: 0x0403C13B RID: 246075
			SkipBtn,
			// Token: 0x0403C13C RID: 246076
			MovieModePhotoBtn,
			// Token: 0x0403C13D RID: 246077
			RideShareBtn,
			// Token: 0x0403C13E RID: 246078
			ExitBtn,
			// Token: 0x0403C13F RID: 246079
			RightDownBtnRoot
		}
	}
}
