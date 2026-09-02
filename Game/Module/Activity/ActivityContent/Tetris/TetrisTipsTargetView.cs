using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062E7 RID: 25319
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisTipsTargetView : TetrisTipsBaseView
	{
		// Token: 0x0603FAA1 RID: 260769 RVA: 0x0105286D File Offset: 0x01050A6D
		public TetrisTipsTargetView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FAA2 RID: 260770 RVA: 0x01052876 File Offset: 0x01050A76
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603FAA3 RID: 260771 RVA: 0x010528AF File Offset: 0x01050AAF
		protected override void OnStart()
		{
			base.OnStart();
			this.Param = (this.OpenParam as Dictionary<int, int>);
			this.TargetsList = new GenericLayout<TetrisTipsTargetGrid, ITetrisTargetData>(base.GetHorizontalLayout(0), new Func<TetrisTipsTargetGrid>(this.UpdateItem), null, false, true);
		}

		// Token: 0x0603FAA4 RID: 260772 RVA: 0x010528E9 File Offset: 0x01050AE9
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x0603FAA5 RID: 260773 RVA: 0x010528F4 File Offset: 0x01050AF4
		private void Refresh()
		{
			List<ITetrisTargetData> list = new List<ITetrisTargetData>();
			foreach (KeyValuePair<int, int> keyValuePair in this.Param)
			{
				list.Add(new TetrisTargetData
				{
					Icon = ConfigBase<ActivityTetrisConfig>.Instance.GetGemConfig(keyValuePair.Key).Value.TargetIconPath,
					Num = keyValuePair.Value,
					Tip = ((keyValuePair.Key == 0) ? "Tetristext_09" : "Tetristext_10")
				});
			}
			this.TargetsList.RefreshByData(list, null, false);
		}

		// Token: 0x0603FAA6 RID: 260774 RVA: 0x010529B0 File Offset: 0x01050BB0
		private TetrisTipsTargetGrid UpdateItem()
		{
			return new TetrisTipsTargetGrid();
		}

		// Token: 0x04023C01 RID: 146433
		[Nullable(2)]
		private Dictionary<int, int> Param;

		// Token: 0x04023C02 RID: 146434
		private GenericLayout<TetrisTipsTargetGrid, ITetrisTargetData> TargetsList;
	}
}
