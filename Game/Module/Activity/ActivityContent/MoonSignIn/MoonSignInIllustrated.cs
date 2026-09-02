using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x0200672C RID: 26412
	internal class MoonSignInIllustrated : UiPanelBase
	{
		// Token: 0x06041E29 RID: 269865 RVA: 0x010E7A88 File Offset: 0x010E5C88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickSwitchToWishBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickRewardBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041E2A RID: 269866 RVA: 0x010E7CE8 File Offset: 0x010E5EE8
		protected override UniTask OnBeforeStartAsync()
		{
			MoonSignInIllustrated.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoonSignInIllustrated.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041E2B RID: 269867 RVA: 0x010E7D2C File Offset: 0x010E5F2C
		public void RefreshPhaseView()
		{
			for (int i = 1; i <= 10; i++)
			{
				MoonSignInPhase moonSignInPhase = this.PhaseItemMap[i];
				if (moonSignInPhase != null)
				{
					moonSignInPhase.RefreshItemLockState();
				}
			}
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			base.GetText(11).SetText(data.GetMoonPhaseProgress(), true);
			base.GetItem(13).SetUIActive(data.GetCanGetMoonGrandReward());
		}

		// Token: 0x06041E2C RID: 269868 RVA: 0x010E7D93 File Offset: 0x010E5F93
		private void OnClickSwitchToWishBtn()
		{
			Action onClickSwitchWishBtnCallBack = this.OnClickSwitchWishBtnCallBack;
			if (onClickSwitchWishBtnCallBack == null)
			{
				return;
			}
			onClickSwitchWishBtnCallBack();
		}

		// Token: 0x06041E2D RID: 269869 RVA: 0x010E7DA5 File Offset: 0x010E5FA5
		private void OnClickRewardBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoonSignInRewardView, null, null);
		}

		// Token: 0x04024C24 RID: 150564
		[Nullable(2)]
		public Action OnClickSwitchWishBtnCallBack;

		// Token: 0x04024C25 RID: 150565
		[Nullable(1)]
		private readonly Dictionary<int, MoonSignInPhase> PhaseItemMap = new Dictionary<int, MoonSignInPhase>();

		// Token: 0x0200C761 RID: 51041
		private class EMoonSignInIllustratedDefine
		{
			// Token: 0x0403D614 RID: 251412
			public const int MoonPhaseItem1 = 0;

			// Token: 0x0403D615 RID: 251413
			public const int MoonPhaseItem2 = 1;

			// Token: 0x0403D616 RID: 251414
			public const int MoonPhaseItem3 = 2;

			// Token: 0x0403D617 RID: 251415
			public const int MoonPhaseItem4 = 3;

			// Token: 0x0403D618 RID: 251416
			public const int MoonPhaseItem5 = 4;

			// Token: 0x0403D619 RID: 251417
			public const int MoonPhaseItem6 = 5;

			// Token: 0x0403D61A RID: 251418
			public const int MoonPhaseItem7 = 6;

			// Token: 0x0403D61B RID: 251419
			public const int MoonPhaseItem8 = 7;

			// Token: 0x0403D61C RID: 251420
			public const int MoonPhaseItem9 = 8;

			// Token: 0x0403D61D RID: 251421
			public const int MoonPhaseItem10 = 9;

			// Token: 0x0403D61E RID: 251422
			public const int RewardBtn = 10;

			// Token: 0x0403D61F RID: 251423
			public const int ProgressText = 11;

			// Token: 0x0403D620 RID: 251424
			public const int SwitchToWishBtn = 12;

			// Token: 0x0403D621 RID: 251425
			public const int RewardBtnRedDotItem = 13;
		}
	}
}
