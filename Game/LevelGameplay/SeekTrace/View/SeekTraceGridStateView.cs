using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace.View
{
	// Token: 0x02006B10 RID: 27408
	public class SeekTraceGridStateView : UiPanelBase, IGridProxy<ESeekTraceGridStateViewType>
	{
		// Token: 0x1700A300 RID: 41728
		// (get) Token: 0x06043BA2 RID: 277410 RVA: 0x01179F41 File Offset: 0x01178141
		// (set) Token: 0x06043BA3 RID: 277411 RVA: 0x01179F49 File Offset: 0x01178149
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IScrollViewDelegate<IGridProxy<ESeekTraceGridStateViewType>, ESeekTraceGridStateViewType> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700A301 RID: 41729
		// (get) Token: 0x06043BA4 RID: 277412 RVA: 0x01179F52 File Offset: 0x01178152
		// (set) Token: 0x06043BA5 RID: 277413 RVA: 0x01179F5A File Offset: 0x0117815A
		public int GridIndex { get; set; }

		// Token: 0x1700A302 RID: 41730
		// (get) Token: 0x06043BA6 RID: 277414 RVA: 0x01179F63 File Offset: 0x01178163
		// (set) Token: 0x06043BA7 RID: 277415 RVA: 0x01179F6B File Offset: 0x0117816B
		public int DisplayIndex { get; set; }

		// Token: 0x06043BA8 RID: 277416 RVA: 0x01179F74 File Offset: 0x01178174
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06043BA9 RID: 277417 RVA: 0x01179FB0 File Offset: 0x011781B0
		public void Refresh(ESeekTraceGridStateViewType data, bool isSelected, int gridIndex)
		{
			UUIItem item = base.GetItem(0);
			UUIItem item2 = base.GetItem(1);
			switch (data)
			{
			case ESeekTraceGridStateViewType.None:
				item.SetUIActive(false);
				item2.SetUIActive(false);
				return;
			case ESeekTraceGridStateViewType.Light:
				item.SetUIActive(false);
				item2.SetUIActive(true);
				return;
			case ESeekTraceGridStateViewType.LightGreen:
			{
				item.SetUIActive(true);
				UUIItem uuiitem = item;
				bool bUseChangeColor = true;
				FColor? fcolor = new FColor?(item.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				item2.SetUIActive(true);
				return;
			}
			case ESeekTraceGridStateViewType.Red:
			{
				item.SetUIActive(true);
				UUIItem uuiitem2 = item;
				bool bUseChangeColor2 = false;
				FColor? fcolor = new FColor?(item.changeColor);
				uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
				item2.SetUIActive(false);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06043BAA RID: 277418 RVA: 0x0117A049 File Offset: 0x01178249
		public void Clear()
		{
		}

		// Token: 0x06043BAB RID: 277419 RVA: 0x0117A04B File Offset: 0x0117824B
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06043BAC RID: 277420 RVA: 0x0117A04D File Offset: 0x0117824D
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06043BAD RID: 277421 RVA: 0x0117A04F File Offset: 0x0117824F
		[NullableContext(2)]
		public object GetKey(ESeekTraceGridStateViewType data, int gridIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x0200CA0B RID: 51723
		public enum EComponentType
		{
			// Token: 0x0403E145 RID: 254277
			StateSprite,
			// Token: 0x0403E146 RID: 254278
			LightSprite
		}
	}
}
