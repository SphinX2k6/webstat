using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001154 RID: 4436
[NullableContext(1)]
[Nullable(0)]
public class ActivityRecommendItem : GridProxyAbstract<int>
{
	// Token: 0x060074E1 RID: 29921 RVA: 0x001EAEC6 File Offset: 0x001E90C6
	public void SetViewModel(ActivityRecommendViewModel vm)
	{
		this.Vm = vm;
	}

	// Token: 0x060074E2 RID: 29922 RVA: 0x001EAED0 File Offset: 0x001E90D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUISprite)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUISprite)),
			new ValueTuple<int, Type>(18, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickJumpBtn)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickPreOpenBtn))
		};
	}

	// Token: 0x060074E3 RID: 29923 RVA: 0x001EB0D1 File Offset: 0x001E92D1
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(9), new Func<CommonItemSmallItemGrid>(this.InitRewardItem), null, false, true);
	}

	// Token: 0x060074E4 RID: 29924 RVA: 0x001EB0F5 File Offset: 0x001E92F5
	private CommonItemSmallItemGrid InitRewardItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = ((TItem _) => this.RewardShowReceived)
		};
	}

	// Token: 0x060074E5 RID: 29925 RVA: 0x001EB110 File Offset: 0x001E9310
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.CurrentId = data;
		ActivityRecommendViewModel vm = this.Vm;
		RecommendItemDisplay? recommendItemDisplay = (vm != null) ? vm.GetItemDisplayData(data) : null;
		if (recommendItemDisplay == null)
		{
			return;
		}
		this.ApplyDisplay(recommendItemDisplay.Value);
	}

	// Token: 0x060074E6 RID: 29926 RVA: 0x001EB158 File Offset: 0x001E9358
	private void ApplyDisplay(RecommendItemDisplay display)
	{
		base.GetText(3).SetText(display.Title, true);
		UUIText text = base.GetText(4);
		if (display.SubTitle == null)
		{
			text.SetUIActive(false);
		}
		else
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, display.SubTitle.Value.Key, display.SubTitle.Value.Args);
		}
		this.ApplyIcon(display);
		UUIItem item = base.GetItem(5);
		if (display.Tag == null)
		{
			item.SetUIActive(false);
		}
		else
		{
			RecommendTagDisplay value = display.Tag.Value;
			item.SetUIActive(true);
			this.SetSpriteByPath(value.BgSpritePath, base.GetSprite(6), false, null, null);
			UUISprite sprite = base.GetSprite(7);
			if (!string.IsNullOrEmpty(value.IconSpritePath))
			{
				sprite.SetUIActive(true);
				this.SetSpriteByPath(value.IconSpritePath, sprite, false, null, null);
				sprite.SetColor(value.IconColor ?? ActivityRecommendItem.FallbackTagColor);
			}
			else
			{
				sprite.SetUIActive(false);
			}
			UUIText text2 = base.GetText(8);
			if (value.TextLocalize != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, value.TextLocalize.Value.Key, value.TextLocalize.Value.Args);
			}
			else
			{
				text2.SetText(value.Text ?? "", true);
			}
			text2.SetColor(value.IconColor ?? ActivityRecommendItem.FallbackTagColor);
		}
		this.RewardShowReceived = display.ShowDownMask;
		if (display.Tag != null && display.Tag.GetValueOrDefault().Style == ERecommendTagStyle.Area)
		{
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout != null)
			{
				rewardLayout.RefreshByData(display.RewardList, delegate
				{
					List<CommonItemSmallItemGrid> layoutItemList = this.RewardLayout.GetLayoutItemList();
					if (layoutItemList != null)
					{
						foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in layoutItemList)
						{
							commonItemSmallItemGrid.SetBottomTextVisible(false);
						}
					}
				}, false);
			}
		}
		else
		{
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout2 = this.RewardLayout;
			if (rewardLayout2 != null)
			{
				rewardLayout2.RefreshByData(display.RewardList, null, false);
			}
		}
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout3 = this.RewardLayout;
		if (rewardLayout3 != null)
		{
			UUIItem rootUiItem = rewardLayout3.GetRootUiItem();
			if (rootUiItem != null)
			{
				rootUiItem.SetUIActive(display.RewardList.Count > 0);
			}
		}
		UUIItem uuiitem = base.GetButton(11).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(display.ShowJumpBtn);
		}
		UUIItem uuiitem2 = base.GetButton(12).RootUIComp.Get();
		if (uuiitem2 != null)
		{
			uuiitem2.SetUIActive(display.ShowPreOpenBtn);
		}
		base.GetItem(18).SetUIActive(display.ShowLockedBtn);
		base.GetItem(13).SetUIActive(display.ShowDownMask);
		base.GetItem(14).SetUIActive(!display.IsMainQuestFinished);
	}

	// Token: 0x060074E7 RID: 29927 RVA: 0x001EB430 File Offset: 0x001E9630
	private void ApplyIcon(RecommendItemDisplay display)
	{
		UUISprite iconSprite = base.GetSprite(1);
		UUITexture iconTexture = base.GetTexture(2);
		UUIItem item = base.GetItem(16);
		if (display.IsBigIcon)
		{
			iconSprite.SetUIActive(false);
			iconTexture.SetUIActive(false);
			if (!string.IsNullOrEmpty(display.IconSpritePath))
			{
				item.SetUIActive(true);
				this.SetSpriteByPath(display.IconSpritePath, base.GetSprite(17), false, null, null);
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			item.SetUIActive(false);
			switch (display.IconSource)
			{
			case ERecommendIconSource.None:
				iconSprite.SetUIActive(false);
				iconTexture.SetUIActive(false);
				return;
			case ERecommendIconSource.Sprite:
				if (string.IsNullOrEmpty(display.IconSpritePath))
				{
					iconSprite.SetUIActive(false);
					iconTexture.SetUIActive(false);
					return;
				}
				iconTexture.SetUIActive(false);
				this.SetSpriteByPath(display.IconSpritePath, iconSprite, false, null, delegate(bool _)
				{
					iconSprite.SetUIActive(true);
				});
				return;
			case ERecommendIconSource.Texture:
				if (string.IsNullOrEmpty(display.IconTexturePath))
				{
					iconSprite.SetUIActive(false);
					iconTexture.SetUIActive(false);
					return;
				}
				iconSprite.SetUIActive(false);
				base.SetTextureByPath(display.IconTexturePath, iconTexture, null, delegate(bool _)
				{
					iconTexture.SetUIActive(true);
				});
				return;
			default:
				return;
			}
		}
	}

	// Token: 0x060074E8 RID: 29928 RVA: 0x001EB5B0 File Offset: 0x001E97B0
	private void OnClickJumpBtn()
	{
		ActivityRecommendViewModel vm = this.Vm;
		if (vm == null)
		{
			return;
		}
		vm.OnClickJump(this.CurrentId);
	}

	// Token: 0x060074E9 RID: 29929 RVA: 0x001EB5C8 File Offset: 0x001E97C8
	private void OnClickPreOpenBtn()
	{
		ActivityRecommendViewModel vm = this.Vm;
		if (vm == null)
		{
			return;
		}
		vm.OnClickPreOpen(this.CurrentId);
	}

	// Token: 0x04003886 RID: 14470
	[StaticVariableRuleIgnore]
	private static readonly FColor FallbackTagColor = FColor.FromHex("FFFFFF");

	// Token: 0x04003887 RID: 14471
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04003888 RID: 14472
	[Nullable(2)]
	private ActivityRecommendViewModel Vm;

	// Token: 0x04003889 RID: 14473
	private int CurrentId;

	// Token: 0x0400388A RID: 14474
	private bool RewardShowReceived;
}
