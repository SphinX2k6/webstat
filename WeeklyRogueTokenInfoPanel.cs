using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D41 RID: 11585
[NullableContext(2)]
[Nullable(0)]
public class WeeklyRogueTokenInfoPanel : UiPanelBase
{
	// Token: 0x060175EE RID: 95726 RVA: 0x0067AF84 File Offset: 0x00679184
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x060175EF RID: 95727 RVA: 0x0067B064 File Offset: 0x00679264
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueTokenInfoPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueTokenInfoPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060175F0 RID: 95728 RVA: 0x0067B0A7 File Offset: 0x006792A7
	protected override void OnStart()
	{
		this.RefreshArtifact();
		this.RefreshCoreBuff();
		this.RefreshBuff();
		WeeklyRogueArtifactGrid artifactGrid = this.ArtifactGrid;
		if (artifactGrid == null)
		{
			return;
		}
		artifactGrid.OnSelected(true);
	}

	// Token: 0x060175F1 RID: 95729 RVA: 0x0067B0CC File Offset: 0x006792CC
	private void OnTokenSelectedChange(int tokenId, bool selectOn)
	{
		if (!selectOn)
		{
			return;
		}
		this.RefreshSelectOn(tokenId);
	}

	// Token: 0x060175F2 RID: 95730 RVA: 0x0067B0D9 File Offset: 0x006792D9
	[NullableContext(1)]
	private bool OnCanExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		return (int)data > 0;
	}

	// Token: 0x060175F3 RID: 95731 RVA: 0x0067B0E4 File Offset: 0x006792E4
	[NullableContext(1)]
	private WeeklyRogueTokenInfoGrid CreateTokenItem()
	{
		WeeklyRogueTokenInfoGrid weeklyRogueTokenInfoGrid = new WeeklyRogueTokenInfoGrid();
		weeklyRogueTokenInfoGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnCanExecuteChange));
		weeklyRogueTokenInfoGrid.OnSelectedChange = new Action<int, bool>(this.OnTokenSelectedChange);
		return weeklyRogueTokenInfoGrid;
	}

	// Token: 0x060175F4 RID: 95732 RVA: 0x0067B110 File Offset: 0x00679310
	private void RefreshSelectOn(int tokenId)
	{
		if (this.SelectOnTokenId > 0)
		{
			RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(this.SelectOnTokenId);
			if (rogueWeeklyBuffPool == null)
			{
				return;
			}
			int buffType = rogueWeeklyBuffPool.Value.BuffType;
			if (buffType != 1)
			{
				if (buffType != 2)
				{
					GenericLayout<WeeklyRogueTokenInfoGrid, int> tokenLayout = this.TokenLayout;
					if (tokenLayout != null)
					{
						WeeklyRogueTokenInfoGrid layoutItemByKey = tokenLayout.GetLayoutItemByKey(this.SelectOnTokenId);
						if (layoutItemByKey != null)
						{
							layoutItemByKey.OnDeselected(false);
						}
					}
				}
				else
				{
					GenericLayout<WeeklyRogueTokenInfoGrid, int> coreTokenLayout = this.CoreTokenLayout;
					if (coreTokenLayout != null)
					{
						WeeklyRogueTokenInfoGrid layoutItemByKey2 = coreTokenLayout.GetLayoutItemByKey(this.SelectOnTokenId);
						if (layoutItemByKey2 != null)
						{
							layoutItemByKey2.OnDeselected(false);
						}
					}
				}
			}
			else
			{
				WeeklyRogueArtifactGrid artifactGrid = this.ArtifactGrid;
				if (artifactGrid != null)
				{
					artifactGrid.OnDeselected(false);
				}
			}
		}
		RogueWeeklyBuffPool? rogueWeeklyBuffPool2 = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(tokenId);
		if (rogueWeeklyBuffPool2 == null)
		{
			return;
		}
		if (rogueWeeklyBuffPool2.Value.BuffType == 1)
		{
			WeeklyRogueTokenItem tokenItem = this.TokenItem;
			if (tokenItem != null)
			{
				tokenItem.SetActive(false);
			}
			WeeklyRogueArtifactItem artifactItem = this.ArtifactItem;
			if (artifactItem != null)
			{
				artifactItem.UpdateByConfigId(tokenId);
			}
			WeeklyRogueArtifactItem artifactItem2 = this.ArtifactItem;
			if (artifactItem2 != null)
			{
				artifactItem2.SetActive(true);
			}
		}
		else
		{
			WeeklyRogueArtifactItem artifactItem3 = this.ArtifactItem;
			if (artifactItem3 != null)
			{
				artifactItem3.SetActive(false);
			}
			WeeklyRogueTokenItem tokenItem2 = this.TokenItem;
			if (tokenItem2 != null)
			{
				tokenItem2.UpdateByConfigId(tokenId);
			}
			WeeklyRogueTokenItem tokenItem3 = this.TokenItem;
			if (tokenItem3 != null)
			{
				tokenItem3.SetActive(true);
			}
		}
		this.SelectOnTokenId = tokenId;
	}

	// Token: 0x060175F5 RID: 95733 RVA: 0x0067B264 File Offset: 0x00679464
	private void RefreshArtifact()
	{
		int artifactBuffId = ModelBase<WeeklyRogueModel>.Instance.GetArtifactBuffId();
		WeeklyRogueArtifactGrid artifactGrid = this.ArtifactGrid;
		if (artifactGrid == null)
		{
			return;
		}
		artifactGrid.Refresh(artifactBuffId, true, 0);
	}

	// Token: 0x060175F6 RID: 95734 RVA: 0x0067B290 File Offset: 0x00679490
	private void RefreshCoreBuff()
	{
		int artifactBuffId = ModelBase<WeeklyRogueModel>.Instance.GetArtifactBuffId();
		List<int> coreTokenIdListByArtifactId = ModelBase<WeeklyRogueModel>.Instance.GetCoreTokenIdListByArtifactId(artifactBuffId);
		List<int> buffIdListByType = ModelBase<WeeklyRogueModel>.Instance.GetBuffIdListByType(EWeeklyRogueBuffType.CoreToken);
		List<int> list = new List<int>();
		for (int i = 0; i < coreTokenIdListByArtifactId.Count; i++)
		{
			if (i < buffIdListByType.Count)
			{
				list.Add(buffIdListByType[i]);
			}
			else
			{
				list.Add(0);
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WeRogueOverviewCoreBuff", new <>z__ReadOnlyArray<object>(new object[]
		{
			buffIdListByType.Count,
			coreTokenIdListByArtifactId.Count
		}));
		GenericLayout<WeeklyRogueTokenInfoGrid, int> coreTokenLayout = this.CoreTokenLayout;
		if (coreTokenLayout == null)
		{
			return;
		}
		coreTokenLayout.RefreshByData(list, null, false);
	}

	// Token: 0x060175F7 RID: 95735 RVA: 0x0067B34C File Offset: 0x0067954C
	private void RefreshBuff()
	{
		List<int> buffIdListByType = ModelBase<WeeklyRogueModel>.Instance.GetBuffIdListByType(EWeeklyRogueBuffType.Token);
		List<int> buffIdListByType2 = ModelBase<WeeklyRogueModel>.Instance.GetBuffIdListByType(EWeeklyRogueBuffType.Modifier);
		buffIdListByType.AddRange(buffIdListByType2);
		GenericLayout<WeeklyRogueTokenInfoGrid, int> tokenLayout = this.TokenLayout;
		if (tokenLayout != null)
		{
			tokenLayout.SetActive(buffIdListByType.Count > 0);
		}
		if (buffIdListByType.Count > 0)
		{
			GenericLayout<WeeklyRogueTokenInfoGrid, int> tokenLayout2 = this.TokenLayout;
			if (tokenLayout2 != null)
			{
				tokenLayout2.RefreshByData(buffIdListByType, null, false);
			}
		}
		base.GetItem(6).SetUIActive(buffIdListByType.Count == 0);
	}

	// Token: 0x0400B36D RID: 45933
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<WeeklyRogueTokenInfoGrid, int> CoreTokenLayout;

	// Token: 0x0400B36E RID: 45934
	protected WeeklyRogueArtifactGrid ArtifactGrid;

	// Token: 0x0400B36F RID: 45935
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<WeeklyRogueTokenInfoGrid, int> TokenLayout;

	// Token: 0x0400B370 RID: 45936
	protected WeeklyRogueTokenItem TokenItem;

	// Token: 0x0400B371 RID: 45937
	protected WeeklyRogueArtifactItem ArtifactItem;

	// Token: 0x0400B372 RID: 45938
	protected int SelectOnTokenId = -1;

	// Token: 0x02009006 RID: 36870
	[NullableContext(0)]
	private enum EWeeklyRogueTokenInfoPanelDefine
	{
		// Token: 0x04030523 RID: 197923
		ItemArtifact,
		// Token: 0x04030524 RID: 197924
		TxtCoreToken,
		// Token: 0x04030525 RID: 197925
		CoreTokenLayout,
		// Token: 0x04030526 RID: 197926
		CoreTokenItem,
		// Token: 0x04030527 RID: 197927
		TokenLayout,
		// Token: 0x04030528 RID: 197928
		TokenItem,
		// Token: 0x04030529 RID: 197929
		EmptyItem,
		// Token: 0x0403052A RID: 197930
		TokenTips,
		// Token: 0x0403052B RID: 197931
		ArtifactTips
	}
}
