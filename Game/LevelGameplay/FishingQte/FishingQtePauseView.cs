using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E95 RID: 28309
	public class FishingQtePauseView : UiViewBase
	{
		// Token: 0x06044A5E RID: 281182 RVA: 0x011D7BC3 File Offset: 0x011D5DC3
		[NullableContext(1)]
		public FishingQtePauseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06044A5F RID: 281183 RVA: 0x011D7BCC File Offset: 0x011D5DCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonExitClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnButtonCabinClicked));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnButtonResumeClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044A60 RID: 281184 RVA: 0x011D7CD9 File Offset: 0x011D5ED9
		protected override void OnStart()
		{
		}

		// Token: 0x06044A61 RID: 281185 RVA: 0x011D7CDB File Offset: 0x011D5EDB
		private void OnButtonExitClicked()
		{
			ControllerBase<FishingController>.Instance.ShowConfirmBoxAndRequestFishingExit(delegate(bool success)
			{
				if (success)
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x06044A62 RID: 281186 RVA: 0x011D7CF3 File Offset: 0x011D5EF3
		private void OnButtonCabinClicked()
		{
			ControllerBase<FishingController>.Instance.OpenDockyardWareHouseView(true);
			base.CloseMe(null);
		}

		// Token: 0x06044A63 RID: 281187 RVA: 0x011D7D07 File Offset: 0x011D5F07
		private void OnButtonResumeClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200CB5A RID: 52058
		private class EComponents
		{
			// Token: 0x0403E68D RID: 255629
			public const int ButtonExit = 0;

			// Token: 0x0403E68E RID: 255630
			public const int ButtonCabin = 1;

			// Token: 0x0403E68F RID: 255631
			public const int ButtonResume = 2;
		}
	}
}
