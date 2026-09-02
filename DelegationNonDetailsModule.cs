using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013C8 RID: 5064
[NullableContext(1)]
[Nullable(0)]
public class DelegationNonDetailsModule : UiPanelBase
{
	// Token: 0x06008BD6 RID: 35798 RVA: 0x0024CC84 File Offset: 0x0024AE84
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUITexture)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnButton))
		};
	}

	// Token: 0x06008BD7 RID: 35799 RVA: 0x0024CDE4 File Offset: 0x0024AFE4
	protected override UniTask OnBeforeStartAsync()
	{
		DelegationNonDetailsModule.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DelegationNonDetailsModule.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008BD8 RID: 35800 RVA: 0x0024CE28 File Offset: 0x0024B028
	private void OnButton()
	{
		if (!this.Data.IsVisible)
		{
			BusinessViewController vc = this.Vc;
			if (vc == null)
			{
				return;
			}
			vc.JumpByConfigCondition(this.Data.Id);
			return;
		}
		else
		{
			int notEnoughConsumeItemId = this.Data.GetNotEnoughConsumeItemId();
			if (notEnoughConsumeItemId <= 0)
			{
				BusinessViewController vc2 = this.Vc;
				if (vc2 == null)
				{
					return;
				}
				vc2.SwitchToState(EBusinessSkipDefine.DelegationDetails, new object[]
				{
					this.Data.Id
				});
				return;
			}
			else
			{
				int powerItemId = ConfigBase<BusinessConfig>.Instance.GetPowerItemId();
				int coinItemId = ConfigBase<BusinessConfig>.Instance.GetCoinItemId();
				if (notEnoughConsumeItemId != powerItemId)
				{
					if (notEnoughConsumeItemId == coinItemId)
					{
						BusinessViewController vc3 = this.Vc;
						if (vc3 == null)
						{
							return;
						}
						vc3.JumpMoneyNotEnough();
					}
					return;
				}
				BusinessViewController vc4 = this.Vc;
				if (vc4 == null)
				{
					return;
				}
				vc4.JumpEnergyNotEnough();
				return;
			}
		}
	}

	// Token: 0x06008BD9 RID: 35801 RVA: 0x0024CED8 File Offset: 0x0024B0D8
	private DelegationNonDetailsModuleStarItem InitStarItem()
	{
		return new DelegationNonDetailsModuleStarItem();
	}

	// Token: 0x06008BDA RID: 35802 RVA: 0x0024CEE0 File Offset: 0x0024B0E0
	private void RefreshLockState()
	{
		bool isVisible = this.Data.IsVisible;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(!isVisible);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(isVisible);
	}

	// Token: 0x06008BDB RID: 35803 RVA: 0x0024CF21 File Offset: 0x0024B121
	private void RefreshLockCondition()
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(this.Data.GetLockText(), true);
	}

	// Token: 0x06008BDC RID: 35804 RVA: 0x0024CF40 File Offset: 0x0024B140
	private void RefreshConsumePrivate()
	{
		List<IItemData> consumeList = this.Data.GetConsumeList();
		IItemData itemData = consumeList[0];
		this.FirstCost.UpdateItem(itemData.ItemId, itemData.Count);
		IItemData itemData2 = consumeList[1];
		this.SecondCurrency.UpdateItem(itemData2.ItemId, itemData2.Count);
	}

	// Token: 0x06008BDD RID: 35805 RVA: 0x0024CF98 File Offset: 0x0024B198
	private void RefreshTitle()
	{
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Data.Id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), delegationConfig.Title, Array.Empty<object>());
	}

	// Token: 0x06008BDE RID: 35806 RVA: 0x0024CFD8 File Offset: 0x0024B1D8
	private void RefreshStar()
	{
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Data.Id);
		this.StarLayout.RefreshByDataAsync(new List<object>(), false, new int?(delegationConfig.Star)).Forget();
	}

	// Token: 0x06008BDF RID: 35807 RVA: 0x0024D020 File Offset: 0x0024B220
	private void RefreshEvaluate()
	{
		base.GetItem(7).SetUIActive(this.Data.HasBestEvaluate());
		if (this.Data.HasBestEvaluate())
		{
			base.SetTextureByPath(ConfigBase<BusinessConfig>.Instance.GetEvaluateByLevel(this.Data.BestEvaluateLevel).Icon, base.GetTexture(8), null, null);
		}
	}

	// Token: 0x06008BE0 RID: 35808 RVA: 0x0024D088 File Offset: 0x0024B288
	private void RefreshIcon()
	{
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Data.Id);
		EntrustType entrustTypeById = ConfigBase<BusinessConfig>.Instance.GetEntrustTypeById(delegationConfig.EntrustType);
		UUITexture texture = base.GetTexture(11);
		base.SetTextureByPath(entrustTypeById.Icon, texture, null, null);
		UUIItem uuiitem = texture;
		bool bUseChangeColor = !this.Data.IsVisible;
		FColor? fcolor = new FColor?(texture.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x06008BE1 RID: 35809 RVA: 0x0024D101 File Offset: 0x0024B301
	private void RefreshNewTag()
	{
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!this.Data.HasBestEvaluate());
	}

	// Token: 0x06008BE2 RID: 35810 RVA: 0x0024D124 File Offset: 0x0024B324
	public void Refresh(DelegationData data)
	{
		this.Data = data;
		if (!this.Data.IsVisible)
		{
			this.RefreshLockState();
			this.RefreshLockCondition();
			this.RefreshIcon();
			return;
		}
		this.RefreshLockState();
		this.RefreshConsumePrivate();
		this.RefreshTitle();
		this.RefreshStar();
		this.RefreshEvaluate();
		this.RefreshIcon();
		this.RefreshNewTag();
	}

	// Token: 0x06008BE3 RID: 35811 RVA: 0x0024D182 File Offset: 0x0024B382
	public void RefreshConsume()
	{
		if (this.Data.IsVisible)
		{
			this.RefreshConsumePrivate();
		}
	}

	// Token: 0x06008BE4 RID: 35812 RVA: 0x0024D197 File Offset: 0x0024B397
	public void RegisterViewController(BusinessViewController vc)
	{
		this.Vc = vc;
	}

	// Token: 0x04004134 RID: 16692
	protected DelegationNonDetailsModuleCostItem FirstCost;

	// Token: 0x04004135 RID: 16693
	protected DelegationNonDetailsModuleCostItem SecondCurrency;

	// Token: 0x04004136 RID: 16694
	protected DelegationData Data;

	// Token: 0x04004137 RID: 16695
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	protected GenericLayout<DelegationNonDetailsModuleStarItem, object> StarLayout;

	// Token: 0x04004138 RID: 16696
	[Nullable(2)]
	private BusinessViewController Vc;

	// Token: 0x0200779C RID: 30620
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040292BA RID: 168634
		public const int Button = 0;

		// Token: 0x040292BB RID: 168635
		public const int LockItem = 1;

		// Token: 0x040292BC RID: 168636
		public const int LockText = 2;

		// Token: 0x040292BD RID: 168637
		public const int UnLockItem = 3;

		// Token: 0x040292BE RID: 168638
		public const int Title = 4;

		// Token: 0x040292BF RID: 168639
		public const int StarLayout = 5;

		// Token: 0x040292C0 RID: 168640
		public const int StarItem = 6;

		// Token: 0x040292C1 RID: 168641
		public const int BestEvaluateItem = 7;

		// Token: 0x040292C2 RID: 168642
		public const int BestEvaluateTexture = 8;

		// Token: 0x040292C3 RID: 168643
		public const int FirstCost = 9;

		// Token: 0x040292C4 RID: 168644
		public const int SecondCost = 10;

		// Token: 0x040292C5 RID: 168645
		public const int Icon = 11;

		// Token: 0x040292C6 RID: 168646
		public const int NewTag = 12;
	}
}
