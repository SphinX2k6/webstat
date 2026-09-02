using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018AA RID: 6314
public class CommonSkillIconItem : UiPanelBase
{
	// Token: 0x0600B562 RID: 46434 RVA: 0x003048A6 File Offset: 0x00302AA6
	[NullableContext(1)]
	public CommonSkillIconItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B563 RID: 46435 RVA: 0x003048BB File Offset: 0x00302ABB
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x0600B564 RID: 46436 RVA: 0x003048E0 File Offset: 0x00302AE0
	[NullableContext(1)]
	public void UpdateItem(string path)
	{
		UUITexture texture = base.GetTexture(0);
		if (!string.IsNullOrEmpty(path))
		{
			base.SetTextureByPath(path, texture, null, null);
			this.SetActive(true);
			return;
		}
		this.SetActive(false);
	}

	// Token: 0x02007C35 RID: 31797
	private enum ECommonSkillItem
	{
		// Token: 0x0402A6C0 RID: 173760
		SkillIcon
	}
}
