using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x0200553F RID: 21823
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DetailViewCardItem : CommonBaseCardItem<DetailViewCardItemData>
	{
		// Token: 0x06037A45 RID: 227909 RVA: 0x00E1DD94 File Offset: 0x00E1BF94
		protected override void OnRegisterCardComponent()
		{
			string resourceId = this.IsNewPhantomArenaActivity ? "UiItem_CardLockNew" : "UiItem_CardLock";
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
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardLockComponent, resourceId, base.GetContentRootItem()),
				new TCardComponentsRegisterInfoByResourceId(ECardItemComponent.CardSpineComponent, "UiItem_SoundRemnantItem512Spine", base.GetSpineRootItem())
			};
		}

		// Token: 0x06037A46 RID: 227910 RVA: 0x00E1DE30 File Offset: 0x00E1C030
		public override void Refresh(DetailViewCardItemData data)
		{
			this.Data = data;
			CommonBaseCardComponentData data2 = new CommonBaseCardComponentData
			{
				CardId = data.CardId,
				Cost = data.Cost,
				Attack = data.Attack,
				Life = data.Life,
				Element = data.Element,
				CardFaceTexturePath = data.CardFaceTexturePath,
				ShowCardFaceTexture = (data.CardFaceType == ECardFaceType.Texture),
				CanToggleExecuteChange = new Func<bool>(this.CanToggleChange),
				OutlookUnlocked = data.OutlookUnlocked
			};
			CommonBaseCardComponent component = base.GetComponent<CommonBaseCardComponent>(ECardItemComponent.CommonBaseCardComponent);
			if (component != null)
			{
				component.Refresh(data2);
			}
			NewCommonBaseCardComponent component2 = base.GetComponent<NewCommonBaseCardComponent>(ECardItemComponent.NewCommonBaseCardComponent);
			if (component2 != null)
			{
				component2.Refresh(data2);
			}
			CardSpineComponentData data3 = new CardSpineComponentData
			{
				CardSpineData = data.CardSpineData,
				ShowSpine = (data.CardFaceType == ECardFaceType.Spine)
			};
			CardSpineComponent component3 = base.GetComponent<CardSpineComponent>(ECardItemComponent.CardSpineComponent);
			if (component3 != null)
			{
				component3.Refresh(data3);
			}
			this.RefreshIsLocked();
		}

		// Token: 0x06037A47 RID: 227911 RVA: 0x00E1DF20 File Offset: 0x00E1C120
		public void RefreshIsLocked()
		{
			CardLockComponent component = base.GetComponent<CardLockComponent>(ECardItemComponent.CardLockComponent);
			if (component == null)
			{
				return;
			}
			component.Refresh(this.Data.IsLock);
		}

		// Token: 0x06037A48 RID: 227912 RVA: 0x00E1DF3E File Offset: 0x00E1C13E
		private bool CanToggleChange()
		{
			return false;
		}

		// Token: 0x0401FE51 RID: 130641
		protected DetailViewCardItemData Data;

		// Token: 0x0401FE52 RID: 130642
		public bool IsNewPhantomArenaActivity;
	}
}
