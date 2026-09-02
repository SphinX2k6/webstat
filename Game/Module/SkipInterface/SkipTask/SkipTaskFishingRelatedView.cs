using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F29 RID: 20265
	[NullableContext(1)]
	[Nullable(0)]
	public class SkipTaskFishingRelatedView : SkipTask
	{
		// Token: 0x060345A4 RID: 214436 RVA: 0x00D1A20C File Offset: 0x00D1840C
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string param1 = (string)data[1];
			string param2 = (string)data[2];
			switch (int.Parse(s))
			{
			case 1:
				this.OpenViewInMainViewAndSailing(this.OpenQuestView);
				break;
			case 2:
				this.OpenViewInMainViewAndSailing(this.OpenHandBookView);
				break;
			case 3:
				this.OpenViewInMainView(delegate
				{
					if (this.CheckViewExistAndReset(EUiViewName.FishingTechRootView))
					{
						return;
					}
					int type = int.Parse(param1);
					int nodeId = int.Parse(param2);
					FishingTechOpenParam param = new FishingTechOpenParam
					{
						Type = type,
						NodeId = nodeId
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingTechRootView, param, null);
				});
				break;
			case 4:
				this.OpenViewInMainViewAndSailing(this.OpenDockyardView);
				break;
			case 5:
				this.OpenViewInMainView(this.OpenShopShopBuyView);
				break;
			case 6:
				this.OpenViewInMainView(this.OpenShopSellView);
				break;
			}
			base.Finish();
		}

		// Token: 0x060345A5 RID: 214437 RVA: 0x00D1A2D0 File Offset: 0x00D184D0
		protected bool CheckMainViewOpen()
		{
			return Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FishingDockView) != null;
		}

		// Token: 0x060345A6 RID: 214438 RVA: 0x00D1A2E4 File Offset: 0x00D184E4
		protected bool CheckIsInSailing()
		{
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			return shipData != null && shipData.IsShipDriving();
		}

		// Token: 0x060345A7 RID: 214439 RVA: 0x00D1A2FC File Offset: 0x00D184FC
		protected void SkipToMap()
		{
			int num = ModelBase<FishingModel>.Instance.GetShipData().GetLastPortId();
			if (num <= 0)
			{
				num = 1;
			}
			FishingPort fishingPortConfig = ConfigBase<FishingConfig>.Instance.GetFishingPortConfig(num);
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(fishingPortConfig.MarkId),
				MarkType = EMarkType.FishingDock
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		}

		// Token: 0x060345A8 RID: 214440 RVA: 0x00D1A359 File Offset: 0x00D18559
		private void OpenViewInMainView(Action openViewFunc)
		{
			if (this.CheckMainViewOpen())
			{
				openViewFunc();
				return;
			}
			this.SkipToMap();
		}

		// Token: 0x060345A9 RID: 214441 RVA: 0x00D1A370 File Offset: 0x00D18570
		private void OpenViewInMainViewAndSailing(Action openViewFunc)
		{
			if (this.CheckMainViewOpen() || this.CheckIsInSailing())
			{
				openViewFunc();
				return;
			}
			this.SkipToMap();
		}

		// Token: 0x060345AA RID: 214442 RVA: 0x00D1A38F File Offset: 0x00D1858F
		private bool CheckViewExistAndReset(EUiViewName viewName)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
			if (Singleton<UiManager>.Instance.GetViewByName(viewName) != null)
			{
				Singleton<UiManager>.Instance.NormalResetToView(viewName, null, true);
				return true;
			}
			return false;
		}

		// Token: 0x060345AB RID: 214443 RVA: 0x00D1A3C0 File Offset: 0x00D185C0
		public SkipTaskFishingRelatedView()
		{
			this.OpenQuestView = delegate()
			{
				if (this.CheckViewExistAndReset(EUiViewName.FishingQuestView))
				{
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingQuestView, null, null);
			};
			this.OpenHandBookView = delegate()
			{
				if (this.CheckViewExistAndReset(EUiViewName.FishingHandBookView))
				{
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingHandBookView, null, null);
			};
			this.OpenDockyardView = delegate()
			{
				if (this.CheckViewExistAndReset(EUiViewName.DockyardView))
				{
					return;
				}
				ControllerBase<FishingController>.Instance.OpenDockyardView();
			};
			this.OpenShopShopBuyView = delegate()
			{
				if (this.CheckViewExistAndReset(EUiViewName.DockyardShopMainView))
				{
					return;
				}
				ControllerBase<FishingController>.Instance.OpenDockyardShopView(new EDockyardShopTabType?(EDockyardShopTabType.Buy));
			};
			this.OpenShopSellView = delegate()
			{
				if (this.CheckViewExistAndReset(EUiViewName.DockyardShopMainView))
				{
					return;
				}
				ControllerBase<FishingController>.Instance.OpenDockyardShopView(new EDockyardShopTabType?(EDockyardShopTabType.Sell));
			};
		}

		// Token: 0x0401E308 RID: 123656
		private const int DEFAULT_PORT_ID = 1;

		// Token: 0x0401E309 RID: 123657
		private readonly Action OpenQuestView;

		// Token: 0x0401E30A RID: 123658
		private readonly Action OpenHandBookView;

		// Token: 0x0401E30B RID: 123659
		private readonly Action OpenDockyardView;

		// Token: 0x0401E30C RID: 123660
		private readonly Action OpenShopShopBuyView;

		// Token: 0x0401E30D RID: 123661
		private readonly Action OpenShopSellView;

		// Token: 0x0200AF70 RID: 44912
		[NullableContext(0)]
		private enum EFishingViewDefine
		{
			// Token: 0x04036713 RID: 222995
			Quest = 1,
			// Token: 0x04036714 RID: 222996
			HandBook,
			// Token: 0x04036715 RID: 222997
			TechView,
			// Token: 0x04036716 RID: 222998
			WareHouse,
			// Token: 0x04036717 RID: 222999
			ShopBuy,
			// Token: 0x04036718 RID: 223000
			ShopSell
		}
	}
}
