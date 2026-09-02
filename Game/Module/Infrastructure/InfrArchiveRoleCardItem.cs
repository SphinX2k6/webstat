using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C52 RID: 23634
	public class InfrArchiveRoleCardItem : GridProxyAbstract<int>
	{
		// Token: 0x170097E5 RID: 38885
		// (get) Token: 0x0603BB5F RID: 244575 RVA: 0x00F20128 File Offset: 0x00F1E328
		public int MsgId
		{
			get
			{
				return this.Id;
			}
		}

		// Token: 0x0603BB60 RID: 244576 RVA: 0x00F20130 File Offset: 0x00F1E330
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB61 RID: 244577 RVA: 0x00F2025A File Offset: 0x00F1E45A
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.Id = data;
			this.RefreshCardView();
		}

		// Token: 0x0603BB62 RID: 244578 RVA: 0x00F2026C File Offset: 0x00F1E46C
		private void RefreshCardView()
		{
			InfrPhoneMessage? infrPhoneMessageConfigById = ConfigBase<InfrastructureConfig>.Instance.GetInfrPhoneMessageConfigById(this.Id);
			bool flag = ModelBase<PhoneMsgModel>.Instance.IsPhoneMsgUnlock(this.Id);
			base.GetItem(1).SetUIActive(!flag);
			base.GetItem(3).SetUIActive(flag);
			base.SetTextureByPath(infrPhoneMessageConfigById.Value.RoleTexturePath, base.GetTexture(4), null, null);
			base.GetText(5).ShowTextNew(infrPhoneMessageConfigById.Value.Name);
		}

		// Token: 0x0603BB63 RID: 244579 RVA: 0x00F202F9 File Offset: 0x00F1E4F9
		[NullableContext(1)]
		public void SetSelectedCallBack(Action<int> callback)
		{
			this.SelectedCallBack = callback;
		}

		// Token: 0x0603BB64 RID: 244580 RVA: 0x00F20302 File Offset: 0x00F1E502
		private void OnClickBtnItem()
		{
			Action<int> selectedCallBack = this.SelectedCallBack;
			if (selectedCallBack == null)
			{
				return;
			}
			selectedCallBack(base.GridIndex);
		}

		// Token: 0x04021922 RID: 137506
		private int Id;

		// Token: 0x04021923 RID: 137507
		[Nullable(2)]
		public Action<int> SelectedCallBack;

		// Token: 0x0200BCC8 RID: 48328
		private class EChildType
		{
			// Token: 0x0403A293 RID: 238227
			public const int BtnItem = 0;

			// Token: 0x0403A294 RID: 238228
			public const int PanelLock = 1;

			// Token: 0x0403A295 RID: 238229
			public const int TextLockTitle = 2;

			// Token: 0x0403A296 RID: 238230
			public const int PanelUnlock = 3;

			// Token: 0x0403A297 RID: 238231
			public const int TextureCardRole = 4;

			// Token: 0x0403A298 RID: 238232
			public const int TextTitle = 5;
		}
	}
}
