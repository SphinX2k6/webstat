using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.View
{
	// Token: 0x02004BEF RID: 19439
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegionalTerminalBarGameplayItem : GridProxyAbstract<RegionalTerminalGameplayData>
	{
		// Token: 0x06032B80 RID: 207744 RVA: 0x00CB4478 File Offset: 0x00CB2678
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032B81 RID: 207745 RVA: 0x00CB4584 File Offset: 0x00CB2784
		[NullableContext(1)]
		public override void Refresh(RegionalTerminalGameplayData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			AreaTerminal? areaTerminalByGameplayId = ConfigBase<RegionalTerminalConfig>.Instance.GetAreaTerminalByGameplayId(this.Data.Id);
			if (areaTerminalByGameplayId == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				UUIItem uuiitem = texture;
				bool lockState = data.GetLockState();
				FColor? fcolor = new FColor?(texture.changeColor);
				uuiitem.SetChangeColor(lockState, fcolor);
				base.SetTextureShowUntilLoaded(areaTerminalByGameplayId.Value.Icon, texture, null);
			}
			this.BindRedDot();
			this.RefreshFunctional();
		}

		// Token: 0x06032B82 RID: 207746 RVA: 0x00CB4600 File Offset: 0x00CB2800
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x06032B83 RID: 207747 RVA: 0x00CB4608 File Offset: 0x00CB2808
		private void RefreshFunctional()
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(ModelBase<RegionalTerminalModel>.Instance.IsGameplayPin(this.Data.Id));
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(this.Data.GetLockState());
			}
		}

		// Token: 0x06032B84 RID: 207748 RVA: 0x00CB4658 File Offset: 0x00CB2858
		private void BindRedDot()
		{
			this.UnBindRedDot();
			this.RedDotName = this.Data.GetRedDotName();
			this.RedDotId = this.Data.GetRedDotId();
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				if (this.RedDotName != null)
				{
					ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, item, null, this.RedDotId);
					return;
				}
				item.SetUIActive(this.Data.GetRedDotState());
			}
		}

		// Token: 0x06032B85 RID: 207749 RVA: 0x00CB46D4 File Offset: 0x00CB28D4
		private void UnBindRedDot()
		{
			if (this.RedDotName != null)
			{
				UUIItem item = base.GetItem(4);
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, this.RedDotId);
				this.RedDotId = 0;
				this.RedDotName = null;
			}
		}

		// Token: 0x06032B86 RID: 207750 RVA: 0x00CB4728 File Offset: 0x00CB2928
		private void OnClickButton()
		{
			this.Data.BarFunction();
			if (!this.Data.GetLockState())
			{
				AreaTerminalOpenActivityLogEvent areaTerminalOpenActivityLogEvent = new AreaTerminalOpenActivityLogEvent();
				areaTerminalOpenActivityLogEvent.i_id = this.Data.Id;
				areaTerminalOpenActivityLogEvent.i_type = 1;
				ControllerBase<LogReportController>.Instance.LogReport(areaTerminalOpenActivityLogEvent);
			}
		}

		// Token: 0x0401D85B RID: 120923
		[Nullable(2)]
		private RegionalTerminalGameplayData Data;

		// Token: 0x0401D85C RID: 120924
		private ERedDotName? RedDotName;

		// Token: 0x0401D85D RID: 120925
		private int RedDotId;

		// Token: 0x0200ACDD RID: 44253
		public static class EComponents
		{
			// Token: 0x04035B0E RID: 219918
			public const int Button = 0;

			// Token: 0x04035B0F RID: 219919
			public const int TexIcon = 1;

			// Token: 0x04035B10 RID: 219920
			public const int ItemLock = 2;

			// Token: 0x04035B11 RID: 219921
			public const int ItemPin = 3;

			// Token: 0x04035B12 RID: 219922
			public const int ItemRedDot = 4;
		}
	}
}
