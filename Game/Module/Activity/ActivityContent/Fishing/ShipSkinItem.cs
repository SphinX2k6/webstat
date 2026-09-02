using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006817 RID: 26647
	internal class ShipSkinItem : GridProxyAbstract<int>
	{
		// Token: 0x060426AF RID: 272047 RVA: 0x01106FA0 File Offset: 0x011051A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060426B0 RID: 272048 RVA: 0x011070CC File Offset: 0x011052CC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.SkinId = data;
			FishingShipSkin fishingShipSkinConfig = ConfigBase<FishingConfig>.Instance.GetFishingShipSkinConfig(data);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), fishingShipSkinConfig.Name, Array.Empty<object>());
			base.SetTextureByPath(fishingShipSkinConfig.BigTexture, base.GetTexture(1), null, null);
			bool flag = this.SkinId == ModelBase<FishingModel>.Instance.GetShipData().GetCurrentSkinId();
			base.GetItem(3).SetUIActive(flag);
			base.GetExtendToggle(0).SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			bool flag2 = ModelBase<FishingModel>.Instance.UnlockShipSkin.Contains(this.SkinId);
			base.GetItem(4).SetUIActive(!flag2);
			bool flag3 = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.FishingShipSkinRecord, this.SkinId);
			if (flag2)
			{
				base.GetItem(5).SetUIActive(!flag3);
				return;
			}
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x060426B1 RID: 272049 RVA: 0x011071BE File Offset: 0x011053BE
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<UUIExtendToggle, int> clickFunc = this.ClickFunc;
			if (clickFunc != null)
			{
				clickFunc(base.GetExtendToggle(0), this.SkinId);
			}
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x060426B2 RID: 272050 RVA: 0x011071EB File Offset: 0x011053EB
		public void SelectToggle()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			Action<UUIExtendToggle, int> clickFunc = this.ClickFunc;
			if (clickFunc != null)
			{
				clickFunc(base.GetExtendToggle(0), this.SkinId);
			}
			base.GetItem(5).SetUIActive(false);
		}

		// Token: 0x04024FAA RID: 151466
		public int SkinId;

		// Token: 0x04024FAB RID: 151467
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<UUIExtendToggle, int> ClickFunc;

		// Token: 0x0200C84C RID: 51276
		private class EShipSkinItemComponent
		{
			// Token: 0x0403DA36 RID: 252470
			public const int Toggle = 0;

			// Token: 0x0403DA37 RID: 252471
			public const int Texture = 1;

			// Token: 0x0403DA38 RID: 252472
			public const int NameText = 2;

			// Token: 0x0403DA39 RID: 252473
			public const int CurrentItem = 3;

			// Token: 0x0403DA3A RID: 252474
			public const int LockItem = 4;

			// Token: 0x0403DA3B RID: 252475
			public const int RedDotItem = 5;
		}
	}
}
