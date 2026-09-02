using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EAC RID: 7852
public class WeaponHandBookDynamicItem : UiPanelBase, IDynamicScrollBaseItem<WeaponHandBookDynamicData>
{
	// Token: 0x0600E83E RID: 59454 RVA: 0x003EC9DC File Offset: 0x003EABDC
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		WeaponHandBookDynamicItem.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<WeaponHandBookDynamicItem.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E83F RID: 59455 RVA: 0x003ECA27 File Offset: 0x003EAC27
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E840 RID: 59456 RVA: 0x003ECA60 File Offset: 0x003EAC60
	[NullableContext(1)]
	public FVector2D GetItemSize(WeaponHandBookDynamicData data)
	{
		if (!string.IsNullOrEmpty(data.TitleId))
		{
			UUIItem item = base.GetItem(0);
			return new FVector2D(item.GetWidth(), item.GetHeight());
		}
		UUIItem item2 = base.GetItem(1);
		return new FVector2D(item2.GetWidth(), item2.GetHeight());
	}

	// Token: 0x0600E841 RID: 59457 RVA: 0x003ECAAD File Offset: 0x003EACAD
	public void ClearItem()
	{
	}

	// Token: 0x020081EB RID: 33259
	private class EWeaponDynamicItemDefine
	{
		// Token: 0x0402C13D RID: 180541
		public const int TitleItem = 0;

		// Token: 0x0402C13E RID: 180542
		public const int LayoutItem = 1;
	}
}
