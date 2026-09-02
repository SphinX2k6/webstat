using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardReward
{
	// Token: 0x02005528 RID: 21800
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RewardGridCardItem : CommonGridCardItem<CollectGridCardData>
	{
		// Token: 0x060379CD RID: 227789 RVA: 0x00E1C6CC File Offset: 0x00E1A8CC
		protected override void OnRegisterCardComponent()
		{
			if (this.IsNewPhantomArenaActivity)
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.NewCommonBaseCardComponent, base.GetRootItem())
				};
			}
			else
			{
				this.ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>
				{
					new TCardComponentsRegisterInfoByItem(ECardItemComponent.CommonBaseCardComponent, base.GetRootItem())
				};
			}
			this.ComponentsRegisterInfoByResourceId = new List<TCardComponentsRegisterInfoByResourceId>
			{
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSpineComponent, "UiItem_SoundRemnantItem512Spine", base.GetSpineRootItem())
			};
		}

		// Token: 0x060379CE RID: 227790 RVA: 0x00E1C740 File Offset: 0x00E1A940
		public override void Refresh(CollectGridCardData data)
		{
			this.Refresh(data, false, 0);
		}

		// Token: 0x060379CF RID: 227791 RVA: 0x00E1C74C File Offset: 0x00E1A94C
		public override void Refresh(CollectGridCardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			CommonBaseCardComponentData data2 = new CommonBaseCardComponentData
			{
				CardId = data.CardId,
				Attack = data.Attack,
				Life = data.Life,
				Element = data.Element,
				CardFaceTexturePath = data.CardFaceTexturePath,
				ShowCardFaceTexture = (data.CardFaceType == ECardFaceType.Texture),
				Cost = data.Cost,
				OnPointerUp = new Action(this.OnPointerUp),
				CanToggleExecuteChange = new Func<bool>(this.CanToggleChange),
				OutlookUnlocked = data.OutlookUnlocked
			};
			if (this.IsNewPhantomArenaActivity)
			{
				NewCommonBaseCardComponent component = base.GetComponent<NewCommonBaseCardComponent>(ECardItemComponent.NewCommonBaseCardComponent);
				if (component != null)
				{
					component.Refresh(data2);
				}
			}
			else
			{
				CommonBaseCardComponent component2 = base.GetComponent<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
				if (component2 != null)
				{
					component2.Refresh(data2);
				}
			}
			CardSpineComponentData data3 = new CardSpineComponentData
			{
				CardSpineData = data.CardSpineData,
				ShowSpine = (data.CardFaceType == ECardFaceType.Spine)
			};
			CardSpineComponent component3 = base.GetComponent<CardSpineComponent>(ECardItemComponent.CardSpineComponent);
			if (component3 == null)
			{
				return;
			}
			component3.Refresh(data3);
		}

		// Token: 0x060379D0 RID: 227792 RVA: 0x00E1C851 File Offset: 0x00E1AA51
		private void OnPointerUp()
		{
			ControllerBase<PhantomArenaController>.Instance.OpenDeckBuilderCardInfoViewWithoutOutlookTab(this.Data.CardId);
		}

		// Token: 0x060379D1 RID: 227793 RVA: 0x00E1C868 File Offset: 0x00E1AA68
		private bool CanToggleChange()
		{
			return false;
		}

		// Token: 0x060379D2 RID: 227794 RVA: 0x00E1C86B File Offset: 0x00E1AA6B
		public new object GetKey(CollectGridCardData data, int gridIndex)
		{
			return data.CardId;
		}

		// Token: 0x0401FE1B RID: 130587
		protected CollectGridCardData Data;

		// Token: 0x0401FE1C RID: 130588
		public bool IsNewPhantomArenaActivity;
	}
}
