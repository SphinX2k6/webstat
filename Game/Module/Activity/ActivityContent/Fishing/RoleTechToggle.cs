using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200682C RID: 26668
	public class RoleTechToggle : UiPanelBase
	{
		// Token: 0x060427E3 RID: 272355 RVA: 0x01110EAC File Offset: 0x0110F0AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060427E4 RID: 272356 RVA: 0x01110F52 File Offset: 0x0110F152
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(base.GetExtendToggle(0));
		}

		// Token: 0x060427E5 RID: 272357 RVA: 0x01110F6C File Offset: 0x0110F16C
		public void RefreshItem(int roleType)
		{
			string resourceId;
			if (roleType != 4)
			{
				if (roleType != 5)
				{
					resourceId = "SP_RoleFeibi";
				}
				else
				{
					resourceId = "SP_RoleFeibi";
				}
			}
			else
			{
				resourceId = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "SP_RoleFemale" : "SP_RoleMale");
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
		}

		// Token: 0x060427E6 RID: 272358 RVA: 0x01110FD7 File Offset: 0x0110F1D7
		public void SelectToggle()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x04025032 RID: 151602
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<UUIExtendToggle> OnClickToggleBack;

		// Token: 0x0200C86B RID: 51307
		private class ERoleTechToggle
		{
			// Token: 0x0403DB02 RID: 252674
			public const int Toggle = 0;

			// Token: 0x0403DB03 RID: 252675
			public const int Sprite = 1;
		}
	}
}
