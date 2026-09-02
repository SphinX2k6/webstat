using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x0200672D RID: 26413
	internal class MoonSignInPhase : UiPanelBase
	{
		// Token: 0x06041E2F RID: 269871 RVA: 0x010E7DCC File Offset: 0x010E5FCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041E30 RID: 269872 RVA: 0x010E7E93 File Offset: 0x010E6093
		protected override void OnStart()
		{
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnClickUndeterminedToggle));
		}

		// Token: 0x06041E31 RID: 269873 RVA: 0x010E7EB4 File Offset: 0x010E60B4
		public void RefreshItem(int phaseId)
		{
			PhaseOfMoon? phaseOfMoonById = ConfigBase<MoonSignInConfig>.Instance.GetPhaseOfMoonById(phaseId);
			if (phaseOfMoonById == null)
			{
				return;
			}
			this.PhaseId = phaseId;
			base.SetTextureShowUntilLoaded(phaseOfMoonById.Value.Texture, base.GetTexture(1), null);
			base.SetTextureShowUntilLoaded(phaseOfMoonById.Value.Texture, base.GetTexture(2), null);
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			bool flag = data.CheckPhaseLock(this.PhaseId);
			base.GetExtendToggle(0).SetToggleState(flag ? EToggleState.ETT_UnDetermined : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06041E32 RID: 269874 RVA: 0x010E7F4C File Offset: 0x010E614C
		public void RefreshItemLockState()
		{
			if (this.PhaseId == 0)
			{
				return;
			}
			MoonSignInData data = ControllerBase<MoonSignInController>.Instance.GetData();
			if (data == null)
			{
				return;
			}
			bool flag = data.CheckPhaseLock(this.PhaseId);
			base.GetExtendToggle(0).SetToggleState(flag ? EToggleState.ETT_UnDetermined : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06041E33 RID: 269875 RVA: 0x010E7F95 File Offset: 0x010E6195
		private void OnClickToggle(EToggleState toggleState)
		{
			this.OnClickUndeterminedToggle();
		}

		// Token: 0x06041E34 RID: 269876 RVA: 0x010E7FA0 File Offset: 0x010E61A0
		private void OnClickUndeterminedToggle()
		{
			MoonSignInDetailViewOpenData param = new MoonSignInDetailViewOpenData
			{
				MoonId = this.PhaseId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoonSignInDetailView, param, null);
		}

		// Token: 0x04024C26 RID: 150566
		private int PhaseId;

		// Token: 0x0200C763 RID: 51043
		private class EMoonSignInPhaseDefine
		{
			// Token: 0x0403D626 RID: 251430
			public const int Toggle = 0;

			// Token: 0x0403D627 RID: 251431
			public const int Texture = 1;

			// Token: 0x0403D628 RID: 251432
			public const int DisableTexture = 2;
		}
	}
}
