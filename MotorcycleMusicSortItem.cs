using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002324 RID: 8996
public class MotorcycleMusicSortItem : DragSortGridAbstract<int>
{
	// Token: 0x060111DA RID: 70106 RVA: 0x004B3C2D File Offset: 0x004B1E2D
	[NullableContext(2)]
	protected override UUIDraggableComponent GetDraggableComp()
	{
		return base.GetDraggable(5);
	}

	// Token: 0x060111DB RID: 70107 RVA: 0x004B3C38 File Offset: 0x004B1E38
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIDraggableComponent))
		};
	}

	// Token: 0x060111DC RID: 70108 RVA: 0x004B3CD4 File Offset: 0x004B1ED4
	protected override void OnStartImplement()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(1);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.CanExecuteChange.Bind(() => false);
	}

	// Token: 0x060111DD RID: 70109 RVA: 0x004B3D0C File Offset: 0x004B1F0C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(data) : null;
		if (phonographMusic == null)
		{
			return;
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew(phonographMusic.Value.Title);
		}
		if (phonographMusic.Value.GetAlbumArray().Length != 0)
		{
			PhonographConfig instance2 = ConfigBase<PhonographConfig>.Instance;
			PhonographAlbum? phonographAlbum = (instance2 != null) ? instance2.GetMusicAlbumById(phonographMusic.Value.GetAlbumArray()[0]) : null;
			if (phonographAlbum != null)
			{
				base.GetText(3).ShowTextNew(phonographAlbum.Value.Title);
			}
		}
	}

	// Token: 0x02008635 RID: 34357
	private class ESortItemComponents
	{
		// Token: 0x0402D63D RID: 185917
		public const int Item = 0;

		// Token: 0x0402D63E RID: 185918
		public const int TogList = 1;

		// Token: 0x0402D63F RID: 185919
		public const int TxtName1 = 2;

		// Token: 0x0402D640 RID: 185920
		public const int TxtName2 = 3;

		// Token: 0x0402D641 RID: 185921
		public const int PanelItem = 4;

		// Token: 0x0402D642 RID: 185922
		public const int DragItem = 5;
	}
}
