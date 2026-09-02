using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002534 RID: 9524
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionNewRecommendFetterDescItem : GridProxyAbstract<VisionNewRecommendFetterDescItemData>
{
	// Token: 0x06012881 RID: 75905 RVA: 0x0051B37C File Offset: 0x0051957C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06012882 RID: 75906 RVA: 0x0051B3EC File Offset: 0x005195EC
	[NullableContext(1)]
	public override void Refresh(VisionNewRecommendFetterDescItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshIcon();
		this.RefreshName();
		this.RefreshDesc();
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.IsNeedLine);
	}

	// Token: 0x06012883 RID: 75907 RVA: 0x0051B41E File Offset: 0x0051961E
	public void SetSimpleMode(bool isSimple)
	{
		if (this.IsSimple == isSimple)
		{
			return;
		}
		this.IsSimple = isSimple;
		this.RefreshDesc();
	}

	// Token: 0x06012884 RID: 75908 RVA: 0x0051B438 File Offset: 0x00519638
	private void RefreshIcon()
	{
		base.TrySetTextureByPath(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.Data.FetterData.GroupId).FetterElementPath, base.GetTexture(0), null, null);
	}

	// Token: 0x06012885 RID: 75909 RVA: 0x0051B480 File Offset: 0x00519680
	private void RefreshName()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(this.Data.FetterData.FetterId).Name, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "VisionFetterDetailViewName", new <>z__ReadOnlyArray<object>(new object[]
		{
			localTextNew,
			this.Data.FetterData.Count.ToString()
		}));
	}

	// Token: 0x06012886 RID: 75910 RVA: 0x0051B4F8 File Offset: 0x005196F8
	private void RefreshDesc()
	{
		if (this.Data == null)
		{
			return;
		}
		PhantomFetter phantomFetterById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(this.Data.FetterData.FetterId);
		if (!this.IsSimple)
		{
			int effectDescriptionParamLength = phantomFetterById.EffectDescriptionParamLength;
			object[] array = new object[effectDescriptionParamLength];
			for (int i = 0; i < effectDescriptionParamLength; i++)
			{
				array[i] = phantomFetterById.EffectDescriptionParam(i);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomFetterById.EffectDescription, array);
			return;
		}
		if (!StringUtils.IsEmpty(phantomFetterById.SimplyEffectDesc))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), phantomFetterById.SimplyEffectDesc, Array.Empty<object>());
			return;
		}
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText("", true);
	}

	// Token: 0x04009070 RID: 36976
	private bool IsSimple;

	// Token: 0x04009071 RID: 36977
	[Nullable(2)]
	private VisionNewRecommendFetterDescItemData Data;

	// Token: 0x0200885B RID: 34907
	private enum EComp
	{
		// Token: 0x0402E0ED RID: 188653
		Icon,
		// Token: 0x0402E0EE RID: 188654
		Name,
		// Token: 0x0402E0EF RID: 188655
		Desc,
		// Token: 0x0402E0F0 RID: 188656
		Line
	}
}
