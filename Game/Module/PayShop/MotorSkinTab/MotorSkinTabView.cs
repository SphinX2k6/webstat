using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PayShop.MotorSkinTab
{
	// Token: 0x020056BB RID: 22203
	public class MotorSkinTabView : UiTabViewBase, IUiTabViewRefresh
	{
		// Token: 0x06038849 RID: 231497 RVA: 0x00E51926 File Offset: 0x00E4FB26
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603884A RID: 231498 RVA: 0x00E51960 File Offset: 0x00E4FB60
		protected override void OnStart()
		{
			this.CurrentShopId = (int)(this.ExtraParams ?? 0);
			this.TabId = (int)(this.Params ?? 0);
			this.Layout = new LoopScrollView<SkinItemContent, SkinItemContentData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<SkinItemContent>(this.OnCreateItem), false);
		}

		// Token: 0x0603884B RID: 231499 RVA: 0x00E519D3 File Offset: 0x00E4FBD3
		[NullableContext(1)]
		private SkinItemContent OnCreateItem()
		{
			return new SkinItemContent();
		}

		// Token: 0x0603884C RID: 231500 RVA: 0x00E519DA File Offset: 0x00E4FBDA
		protected override void OnBeforeShow()
		{
			this.RefreshLayout();
		}

		// Token: 0x0603884D RID: 231501 RVA: 0x00E519E4 File Offset: 0x00E4FBE4
		private void RefreshLayout()
		{
			List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.CurrentShopId, this.TabId, true);
			List<SkinItemContentData> list = new List<SkinItemContentData>();
			int count = payShopTabData.Count;
			for (int i = 0; i < count; i++)
			{
				PayShopGoods data = payShopTabData[i];
				SkinItemContentData skinItemContentData = new SkinItemContentData();
				ShopMotorSkinData shopMotorSkinData = ShopMotorSkinData.Create(data);
				skinItemContentData.ShopMotorSkinData = shopMotorSkinData;
				skinItemContentData.AllData = payShopTabData;
				list.Add(skinItemContentData);
			}
			this.Layout.RefreshByData(list, false, null, true);
		}

		// Token: 0x0603884E RID: 231502 RVA: 0x00E51A5F File Offset: 0x00E4FC5F
		[NullableContext(2)]
		public void RefreshView(object @params)
		{
		}

		// Token: 0x04020431 RID: 132145
		private int CurrentShopId;

		// Token: 0x04020432 RID: 132146
		private int TabId;

		// Token: 0x04020433 RID: 132147
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<SkinItemContent, SkinItemContentData> Layout;

		// Token: 0x0200B72D RID: 46893
		private enum EComponent
		{
			// Token: 0x04038A7E RID: 232062
			GridLayout,
			// Token: 0x04038A7F RID: 232063
			Item
		}
	}
}
