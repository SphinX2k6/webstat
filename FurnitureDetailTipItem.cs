using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001087 RID: 4231
public class FurnitureDetailTipItem : UiPanelBase, IItemTipsUiProxy
{
	// Token: 0x06006E6A RID: 28266 RVA: 0x001CBFAC File Offset: 0x001CA1AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUISprite)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickJumpButton))
		};
	}

	// Token: 0x06006E6B RID: 28267 RVA: 0x001CC137 File Offset: 0x001CA337
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06006E6C RID: 28268 RVA: 0x001CC14C File Offset: 0x001CA34C
	public UniTask PlayCloseSequence()
	{
		FurnitureDetailTipItem.<PlayCloseSequence>d__5 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<FurnitureDetailTipItem.<PlayCloseSequence>d__5>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06006E6D RID: 28269 RVA: 0x001CC190 File Offset: 0x001CA390
	[NullableContext(1)]
	public void Refresh(ItemTipsData data)
	{
		TipsFurnitureData tipsFurnitureData = data as TipsFurnitureData;
		if (tipsFurnitureData == null)
		{
			return;
		}
		this.RefreshByFurnitureId(tipsFurnitureData.ConfigId, false);
	}

	// Token: 0x06006E6E RID: 28270 RVA: 0x001CC1B8 File Offset: 0x001CA3B8
	public void RefreshByFurnitureId(int id, bool showBottomEmptyItem)
	{
		this.FurnitureId = id;
		Furniture? furnitureConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureConfig(id);
		if (furnitureConfig == null)
		{
			return;
		}
		base.SetTextureByPath(furnitureConfig.Value.Icon, base.GetTexture(2), null, null);
		int tagId = furnitureConfig.Value.TagId;
		FurnitureDiyTag? furnitureTagConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureTagConfig(tagId);
		if (furnitureTagConfig != null)
		{
			this.SetSpriteByPath(furnitureTagConfig.Value.OccupiedIcon, base.GetSprite(3), false, null, null);
		}
		base.GetText(4).SetText(furnitureConfig.Value.Atmosphere.ToString(), true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), furnitureConfig.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), furnitureConfig.Value.AttributesDescription, Array.Empty<object>());
		FurnitureQualityConfig? furnitureQualityConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureQualityConfig(furnitureConfig.Value.QualityId);
		if (furnitureQualityConfig != null)
		{
			base.GetSprite(0).SetColor(FColor.FromHex(furnitureQualityConfig.Value.TipBgColor));
			base.GetSprite(1).SetColor(FColor.FromHex(furnitureQualityConfig.Value.TipLineColor));
		}
		EFurnitureSourceType sourceType = (EFurnitureSourceType)furnitureConfig.Value.SourceType;
		bool isFurnitureUnlockById = ModelBase<FurnitureModel>.Instance.GetIsFurnitureUnlockById(furnitureConfig.Value.Id);
		base.GetButton(7).RootUIComp.Get().SetUIActive(!isFurnitureUnlockById);
		base.GetItem(13).SetUIActive(!isFurnitureUnlockById);
		base.GetItem(14).SetUIActive(isFurnitureUnlockById && showBottomEmptyItem);
		base.GetTexture(2).SetAlpha(isFurnitureUnlockById ? 1f : 0.5f);
		if (!isFurnitureUnlockById)
		{
			base.GetItem(8).SetUIActive(sourceType == EFurnitureSourceType.Gift);
			UUISprite sprite = base.GetSprite(10);
			string textStringId = "";
			string[] array = null;
			string resourceId = "";
			bool flag = false;
			bool flag2 = false;
			switch (sourceType)
			{
			case EFurnitureSourceType.Shop:
				textStringId = "DIY_Furniture_Obtain_ShopState";
				flag = true;
				resourceId = "SP_FuncIconShop";
				flag2 = true;
				break;
			case EFurnitureSourceType.Gift:
				textStringId = "DIY_Furniture_Obtain_PresentState";
				base.SetTextureByPath(furnitureConfig.Value.RoleIconPath, base.GetTexture(9), null, null);
				flag2 = true;
				break;
			case EFurnitureSourceType.Atmosphere:
				textStringId = "DIY_Dic_AtmoLockedState";
				flag = true;
				resourceId = "SP_FurnitureInfoIconEmpty";
				array = new string[]
				{
					furnitureConfig.Value.GetWayId.ToString()
				};
				break;
			}
			sprite.SetUIActive(flag);
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.RootUIComp.Get().SetRaycastTarget(flag2);
			}
			UUISprite sprite2 = base.GetSprite(12);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(flag2);
			}
			if (flag)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
				this.SetSpriteByPath(resourcePath, sprite, false, null, null);
			}
			if (array != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), textStringId, array);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), textStringId, Array.Empty<object>());
		}
	}

	// Token: 0x06006E6F RID: 28271 RVA: 0x001CC52C File Offset: 0x001CA72C
	private void OnClickJumpButton()
	{
		Furniture? furnitureConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureConfig(this.FurnitureId);
		if (furnitureConfig == null)
		{
			return;
		}
		EFurnitureSourceType sourceType = (EFurnitureSourceType)furnitureConfig.Value.SourceType;
		if (sourceType == EFurnitureSourceType.Shop)
		{
			ControllerBase<FurnitureController>.Instance.OpenFurnitureShopViewAsync(furnitureConfig.Value.GetWayId);
			return;
		}
		if (sourceType == EFurnitureSourceType.Gift)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SpringManorQuestView))
			{
				Action tipViewCloseDelegate = this.TipViewCloseDelegate;
				if (tipViewCloseDelegate == null)
				{
					return;
				}
				tipViewCloseDelegate();
				return;
			}
			else
			{
				ControllerBase<FurnitureController>.Instance.TryJumpToFurnitureGift(furnitureConfig.Value);
			}
		}
	}

	// Token: 0x0400349E RID: 13470
	protected int FurnitureId;

	// Token: 0x0400349F RID: 13471
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040034A0 RID: 13472
	[Nullable(2)]
	public Action TipViewCloseDelegate;
}
