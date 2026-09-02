using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F11 RID: 28433
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabSmallItemGrid : SmallItemGrid, IGridProxy<IGrabItemData>
	{
		// Token: 0x1700A442 RID: 42050
		// (get) Token: 0x06044DF7 RID: 282103 RVA: 0x011EC596 File Offset: 0x011EA796
		// (set) Token: 0x06044DF8 RID: 282104 RVA: 0x011EC59E File Offset: 0x011EA79E
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<IGrabItemData>, IGrabItemData> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] set; }

		// Token: 0x1700A443 RID: 42051
		// (get) Token: 0x06044DF9 RID: 282105 RVA: 0x011EC5A7 File Offset: 0x011EA7A7
		// (set) Token: 0x06044DFA RID: 282106 RVA: 0x011EC5AF File Offset: 0x011EA7AF
		public int GridIndex { get; set; }

		// Token: 0x1700A444 RID: 42052
		// (get) Token: 0x06044DFB RID: 282107 RVA: 0x011EC5B8 File Offset: 0x011EA7B8
		// (set) Token: 0x06044DFC RID: 282108 RVA: 0x011EC5C0 File Offset: 0x011EA7C0
		public int DisplayIndex { get; set; }

		// Token: 0x06044DFD RID: 282109 RVA: 0x011EC5CC File Offset: 0x011EA7CC
		public void Refresh(IGrabItemData data, bool isSelected, int gridIndex)
		{
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.ItemId),
				BottomText = data.Count.ToString()
			};
			base.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x06044DFE RID: 282110 RVA: 0x011EC612 File Offset: 0x011EA812
		public void Clear()
		{
		}

		// Token: 0x06044DFF RID: 282111 RVA: 0x011EC614 File Offset: 0x011EA814
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06044E00 RID: 282112 RVA: 0x011EC616 File Offset: 0x011EA816
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06044E01 RID: 282113 RVA: 0x011EC618 File Offset: 0x011EA818
		public object GetKey(IGrabItemData data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
