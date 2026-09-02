using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.PhoneMessage.View;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200608E RID: 24718
	public class GamepadPhoneMessageButton : UiPanelBase, IPhoneMessageButtonImplement
	{
		// Token: 0x0603E5DD RID: 255453 RVA: 0x00FED97C File Offset: 0x00FEBB7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E5DE RID: 255454 RVA: 0x00FEDAE8 File Offset: 0x00FEBCE8
		protected override void OnStart()
		{
			base.GetItem(1).SetUIActive(false);
			this.Helper = new PhoneMessageButtonHelper(this.RootItem, this.RootActor, base.GetItem(1), base.GetSprite(2), base.GetItem(4), base.GetTexture(5), base.GetItem(6), base.GetUiNiagara(7), delegate(string path, UUITexture texture)
			{
				base.SetTextureByPath(path, texture, null, null);
			});
			this.Helper.Init();
		}

		// Token: 0x0603E5DF RID: 255455 RVA: 0x00FEDB5A File Offset: 0x00FEBD5A
		public void OnShowGamepadTopPanel()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.OnShowBattleChildView();
		}

		// Token: 0x0603E5E0 RID: 255456 RVA: 0x00FEDB6C File Offset: 0x00FEBD6C
		public void OnHideGamepadTopPanel()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.OnHideBattleChildView();
		}

		// Token: 0x0603E5E1 RID: 255457 RVA: 0x00FEDB7E File Offset: 0x00FEBD7E
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.Clear();
		}

		// Token: 0x0603E5E2 RID: 255458 RVA: 0x00FEDB96 File Offset: 0x00FEBD96
		private void OnButtonClick()
		{
			ControllerBase<PhoneMsgController>.Instance.OpenAndJumpShowTipShortMessage(EPhoneMsgOpenWay.HUD, EPhoneMsgViewType.Big);
		}

		// Token: 0x0603E5E3 RID: 255459 RVA: 0x00FEDBA4 File Offset: 0x00FEBDA4
		public void CheckAndPlayPhoneSequence()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.CheckAndPlayPhoneSequence();
		}

		// Token: 0x0603E5E4 RID: 255460 RVA: 0x00FEDBB6 File Offset: 0x00FEBDB6
		public void PopShowHeadIcon()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.PopShowHeadIcon();
		}

		// Token: 0x0603E5E5 RID: 255461 RVA: 0x00FEDBC8 File Offset: 0x00FEBDC8
		public void HideHeadIcon()
		{
			PhoneMessageButtonHelper helper = this.Helper;
			if (helper == null)
			{
				return;
			}
			helper.HideHeadIcon();
		}

		// Token: 0x04022F3F RID: 143167
		[Nullable(2)]
		private PhoneMessageButtonHelper Helper;

		// Token: 0x0200C17B RID: 49531
		private enum EChildType
		{
			// Token: 0x0403B946 RID: 244038
			Button,
			// Token: 0x0403B947 RID: 244039
			RedDotItem,
			// Token: 0x0403B948 RID: 244040
			SpriteEnterIcon,
			// Token: 0x0403B949 RID: 244041
			TexPhoneBlue,
			// Token: 0x0403B94A RID: 244042
			PanelPrefabHead,
			// Token: 0x0403B94B RID: 244043
			TexIconHead,
			// Token: 0x0403B94C RID: 244044
			BubbleItem,
			// Token: 0x0403B94D RID: 244045
			NiagaraItem
		}
	}
}
