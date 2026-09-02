using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FD1 RID: 20433
	public class SheriffCriminalIdentityConfirmedView : UiViewBase
	{
		// Token: 0x06034B07 RID: 215815 RVA: 0x00D36585 File Offset: 0x00D34785
		[NullableContext(1)]
		public SheriffCriminalIdentityConfirmedView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034B08 RID: 215816 RVA: 0x00D36590 File Offset: 0x00D34790
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCloseClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034B09 RID: 215817 RVA: 0x00D366DC File Offset: 0x00D348DC
		protected override void OnStart()
		{
			SheriffCriminalIdentityConfirmedViewData sheriffCriminalIdentityConfirmedViewData = this.OpenParam as SheriffCriminalIdentityConfirmedViewData;
			if (sheriffCriminalIdentityConfirmedViewData == null)
			{
				return;
			}
			SheriffIdentity? identityConfigById = ConfigBase<SheriffConfig>.Instance.GetIdentityConfigById(sheriffCriminalIdentityConfirmedViewData.BoardId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), (identityConfigById != null) ? identityConfigById.GetValueOrDefault().Name : null, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), (identityConfigById != null) ? identityConfigById.GetValueOrDefault().Accusal : null, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), (identityConfigById != null) ? identityConfigById.GetValueOrDefault().Witness : null, Array.Empty<object>());
			string valueOrDefault = SheriffPopupDefine.SheriffCriminalIdentityTxt.GetValueOrDefault((identityConfigById != null) ? identityConfigById.GetValueOrDefault().IdentityState : 0, "");
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), valueOrDefault, Array.Empty<object>());
			if (identityConfigById != null && !string.IsNullOrEmpty(identityConfigById.Value.IconConfirm))
			{
				base.SetTextureByPath(identityConfigById.Value.IconConfirm, base.GetTexture(1), null, null);
			}
			SheriffCriminal? criminalConfigById = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById((identityConfigById != null) ? identityConfigById.GetValueOrDefault().CriminalId : 0);
			Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview((criminalConfigById != null) ? criminalConfigById.GetValueOrDefault().DropId : 0);
			List<int> payShopInfoMoney = ModelBase<PayShopModel>.Instance.GetPayShopInfoMoney(ModelBase<SheriffModel>.Instance.ShopId);
			int num = (payShopInfoMoney.Count > 0) ? payShopInfoMoney[0] : 0;
			int num3;
			int num2 = (dropPackagePreview != null && dropPackagePreview.TryGetValue(num, out num3)) ? num3 : 0;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num);
			string str = (itemConfigData != null) ? itemConfigData.Icon : "";
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), "Sheriff_HudDesc_7", new <>z__ReadOnlyArray<object>(new object[]
			{
				str + ",0.2",
				num2
			}));
		}

		// Token: 0x06034B0A RID: 215818 RVA: 0x00D3691A File Offset: 0x00D34B1A
		private void OnBtnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200AF9C RID: 44956
		private static class EComponents
		{
			// Token: 0x040367F4 RID: 223220
			public const int BtnClose = 0;

			// Token: 0x040367F5 RID: 223221
			public const int ImgNpc = 1;

			// Token: 0x040367F6 RID: 223222
			public const int TxtBountyNum = 2;

			// Token: 0x040367F7 RID: 223223
			public const int TxtCriminalName = 3;

			// Token: 0x040367F8 RID: 223224
			public const int TxtCriminalDescription = 4;

			// Token: 0x040367F9 RID: 223225
			public const int TxtEnvironment = 5;

			// Token: 0x040367FA RID: 223226
			public const int TxtCriminalIdentity = 6;
		}
	}
}
