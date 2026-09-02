using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BED RID: 11245
public class TowerDetailInformationBuffSubItem : UiPanelBase
{
	// Token: 0x0601670B RID: 91915 RVA: 0x0063BA0D File Offset: 0x00639C0D
	[NullableContext(1)]
	public TowerDetailInformationBuffSubItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0601670C RID: 91916 RVA: 0x0063BA24 File Offset: 0x00639C24
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601670D RID: 91917 RVA: 0x0063BAAE File Offset: 0x00639CAE
	[NullableContext(1)]
	public void Update(TowerDetailBuff data)
	{
		this.Data = data;
		this.RefreshView();
	}

	// Token: 0x0601670E RID: 91918 RVA: 0x0063BAC0 File Offset: 0x00639CC0
	private void RefreshView()
	{
		string desc = this.Data.Desc;
		base.GetText(2).SetText(desc, true);
		string name = this.Data.Name;
		base.GetText(1).SetText(name, true);
		string iconPath = this.Data.IconPath;
		if (iconPath == "" || iconPath == null)
		{
			if (StringUtils.IsEmpty(iconPath))
			{
				base.GetTexture(0).SetUIActive(false);
				return;
			}
			base.SetTextureByPath(iconPath, base.GetTexture(0), null, null);
			base.GetTexture(0).SetUIActive(true);
		}
	}

	// Token: 0x0400ADC2 RID: 44482
	[Nullable(2)]
	private TowerDetailBuff Data;

	// Token: 0x02008EE2 RID: 36578
	private enum EChildType
	{
		// Token: 0x0402FFFB RID: 196603
		Icon,
		// Token: 0x0402FFFC RID: 196604
		BuffName,
		// Token: 0x0402FFFD RID: 196605
		Desc
	}
}
