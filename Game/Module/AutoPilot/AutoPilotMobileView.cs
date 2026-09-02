using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006146 RID: 24902
	public class AutoPilotMobileView : AutoPilotView
	{
		// Token: 0x0603EE7A RID: 257658 RVA: 0x0101FD78 File Offset: 0x0101DF78
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EE7B RID: 257659 RVA: 0x0101FEC9 File Offset: 0x0101E0C9
		protected override int GetSkipBtnCompId()
		{
			return 0;
		}

		// Token: 0x0603EE7C RID: 257660 RVA: 0x0101FECC File Offset: 0x0101E0CC
		protected override int GetRideShareBtnCompId()
		{
			return 6;
		}

		// Token: 0x0603EE7D RID: 257661 RVA: 0x0101FECF File Offset: 0x0101E0CF
		protected override int GetExitBtnCompId()
		{
			return 1;
		}

		// Token: 0x0603EE7E RID: 257662 RVA: 0x0101FED2 File Offset: 0x0101E0D2
		protected override int GetPhotoBtnCompId()
		{
			return 4;
		}

		// Token: 0x0603EE7F RID: 257663 RVA: 0x0101FED5 File Offset: 0x0101E0D5
		protected override int GetMovieBtnCompId()
		{
			return 2;
		}

		// Token: 0x0603EE80 RID: 257664 RVA: 0x0101FED8 File Offset: 0x0101E0D8
		protected override int GetMovieBtnProgressCompId()
		{
			return 3;
		}

		// Token: 0x0603EE81 RID: 257665 RVA: 0x0101FEDB File Offset: 0x0101E0DB
		protected override void InitUi()
		{
			base.InitUi();
			this.InitRideShareProgress();
		}

		// Token: 0x0603EE82 RID: 257666 RVA: 0x0101FEEC File Offset: 0x0101E0EC
		protected override void HandleClickSkipBtn()
		{
			if (ModelBase<AutoPilotModel>.Instance.IsSkipConfirmBoxShow)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SkipPlot);
				confirmBoxDataNew.HasToggle = true;
				confirmBoxDataNew.ToggleText = ConfigBase<TextConfig>.Instance.GetTextById("PlotSkipConfirmToggle");
				confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnToggle));
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ModelBase<AutoPilotModel>.Instance.IsSkipConfirmBoxShow = this.IsSkipConfirmBoxShow;
					ControllerBase<AutoPilotController>.Instance.SkipToTarget();
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<AutoPilotController>.Instance.SkipToTarget();
		}

		// Token: 0x0603EE83 RID: 257667 RVA: 0x0101FF6D File Offset: 0x0101E16D
		private void OnToggle(bool isSelectOn)
		{
			this.IsSkipConfirmBoxShow = !isSelectOn;
		}

		// Token: 0x0603EE84 RID: 257668 RVA: 0x0101FF79 File Offset: 0x0101E179
		private void InitRideShareProgress()
		{
			this.RideShareProgress = base.GetTexture(8);
		}

		// Token: 0x0603EE85 RID: 257669 RVA: 0x0101FF88 File Offset: 0x0101E188
		protected override void UpdateRideShareProgress(float progress)
		{
			UUITexture rideShareProgress = this.RideShareProgress;
			if (rideShareProgress == null)
			{
				return;
			}
			rideShareProgress.SetFillAmount(progress);
		}

		// Token: 0x040234CC RID: 144588
		[Nullable(2)]
		private UUITexture RideShareProgress;

		// Token: 0x040234CD RID: 144589
		private bool IsSkipConfirmBoxShow = true;

		// Token: 0x0200C2D6 RID: 49878
		private enum EAutoPilotMobileComponents
		{
			// Token: 0x0403C128 RID: 246056
			SkipBtn,
			// Token: 0x0403C129 RID: 246057
			ExitBtn,
			// Token: 0x0403C12A RID: 246058
			MovieBtn,
			// Token: 0x0403C12B RID: 246059
			MovieBtnProgress,
			// Token: 0x0403C12C RID: 246060
			PhotoBtn,
			// Token: 0x0403C12D RID: 246061
			MovieBtnIcon,
			// Token: 0x0403C12E RID: 246062
			RideShareBtn,
			// Token: 0x0403C12F RID: 246063
			RightDownBtnRoot,
			// Token: 0x0403C130 RID: 246064
			RideShareProgress
		}
	}
}
