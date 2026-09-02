using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalComponents
{
	// Token: 0x0200624C RID: 25164
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class ActivityConditionItem : GridProxyAbstract<IActivityConditionData>
	{
		// Token: 0x0603F6F9 RID: 259833 RVA: 0x010430F4 File Offset: 0x010412F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.ButtonJumpClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.ButtonJumpClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F6FA RID: 259834 RVA: 0x010432A8 File Offset: 0x010414A8
		[NullableContext(1)]
		public override void Refresh(IActivityConditionData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			bool isFinished = data.IsFinished;
			bool flag = data.AccessType == 7;
			bool flag2 = data.AccessType == 16;
			bool flag3 = data.AccessId == 0;
			UUIText text = base.GetText(4);
			if (!StringUtils.IsEmpty(data.ConditionTextId))
			{
				text.ShowTextNew(data.ConditionTextId);
			}
			else
			{
				text.SetText(string.Empty, true);
			}
			UUIItem uuiitem = text;
			bool bUseChangeColor = isFinished;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			base.GetItem(0).SetUIActive(isFinished);
			base.GetItem(1).SetUIActive(!isFinished && flag);
			base.GetItem(2).SetUIActive(!isFinished && !flag);
			base.GetItem(3).SetUIActive(!isFinished);
			base.GetItem(6).SetUIActive(isFinished);
			base.GetItem(7).SetUIActive(!isFinished && flag3);
			base.GetButton(5).RootUIComp.Get().SetUIActive(!isFinished && !flag3 && !flag2);
			base.GetButton(8).RootUIComp.Get().SetUIActive(!isFinished && !flag3 && flag2);
		}

		// Token: 0x0603F6FB RID: 259835 RVA: 0x010433DD File Offset: 0x010415DD
		private void ButtonJumpClick()
		{
			IActivityConditionData data = this.Data;
			if (data == null || data.AccessId != 0)
			{
				SkipTaskManager.RunByConfigId(this.Data.AccessId, null);
			}
		}

		// Token: 0x040239A4 RID: 145828
		[Nullable(2)]
		private IActivityConditionData Data;

		// Token: 0x0200C351 RID: 50001
		internal class EItemComponents
		{
			// Token: 0x0403C31B RID: 246555
			public const int PanelDone = 0;

			// Token: 0x0403C31C RID: 246556
			public const int PanelType1 = 1;

			// Token: 0x0403C31D RID: 246557
			public const int PanelType2 = 2;

			// Token: 0x0403C31E RID: 246558
			public const int SpriteGoing = 3;

			// Token: 0x0403C31F RID: 246559
			public const int Txt = 4;

			// Token: 0x0403C320 RID: 246560
			public const int ButtonType1 = 5;

			// Token: 0x0403C321 RID: 246561
			public const int SpriteDone = 6;

			// Token: 0x0403C322 RID: 246562
			public const int TxtGoing = 7;

			// Token: 0x0403C323 RID: 246563
			public const int ButtonType2 = 8;
		}
	}
}
