using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001653 RID: 5715
public class WheelTowerBuffGridItem : GridProxyAbstract<int>
{
	// Token: 0x0600A064 RID: 41060 RVA: 0x0029FA54 File Offset: 0x0029DC54
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A065 RID: 41061 RVA: 0x0029FA9C File Offset: 0x0029DC9C
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerBuffGridItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerBuffGridItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A066 RID: 41062 RVA: 0x0029FAE0 File Offset: 0x0029DCE0
	protected override void OnStart()
	{
		MediumItemGrid gridItem = this.GridItem;
		if (gridItem != null)
		{
			gridItem.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		}
		MediumItemGrid gridItem2 = this.GridItem;
		if (gridItem2 == null)
		{
			return;
		}
		gridItem2.SetToggleInteractive(false);
	}

	// Token: 0x0600A067 RID: 41063 RVA: 0x0029FB30 File Offset: 0x0029DD30
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		NewTowerBuff? buffConfigById = ConfigBase<WheelTowerConfig>.Instance.GetBuffConfigById(data);
		if (buffConfigById == null)
		{
			return;
		}
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			IconPath = buffConfigById.Value.Icon,
			BottomTextId = buffConfigById.Value.Name,
			IsQualityHidden = new bool?(true)
		};
		MediumItemGrid gridItem = this.GridItem;
		if (gridItem == null)
		{
			return;
		}
		gridItem.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x040049FE RID: 18942
	[Nullable(2)]
	private MediumItemGrid GridItem;
}
