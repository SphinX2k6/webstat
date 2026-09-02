using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200635C RID: 25436
	public class SpringManorUnlockView : UiTickViewBase
	{
		// Token: 0x0603FDBF RID: 261567 RVA: 0x010619C4 File Offset: 0x0105FBC4
		[NullableContext(1)]
		public SpringManorUnlockView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FDC0 RID: 261568 RVA: 0x010619F0 File Offset: 0x0105FBF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FDC1 RID: 261569 RVA: 0x01061AD8 File Offset: 0x0105FCD8
		protected override void OnStart()
		{
			this.CloseTimer = (float)this.CloseTime;
			this.FillBar = base.GetSprite(1);
		}

		// Token: 0x0603FDC2 RID: 261570 RVA: 0x01061AF4 File Offset: 0x0105FCF4
		protected override void OnTick(float delta)
		{
			UUISprite fillBar = this.FillBar;
			if (fillBar != null)
			{
				fillBar.SetFillAmount(this.CloseTimer / (float)this.CloseTime);
			}
			if (this.CloseTimer <= 0f)
			{
				if (!this.IsClosing)
				{
					base.CloseMe(null);
					this.IsClosing = true;
					return;
				}
			}
			else
			{
				this.CloseTimer -= delta;
			}
		}

		// Token: 0x0603FDC3 RID: 261571 RVA: 0x01061B53 File Offset: 0x0105FD53
		private void OnClickButton()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAtmosphereLevelView, null, null);
		}

		// Token: 0x04023E5A RID: 147034
		private bool IsClosing;

		// Token: 0x04023E5B RID: 147035
		private float CloseTimer;

		// Token: 0x04023E5C RID: 147036
		private readonly int CloseTime = ConfigCommonParamById.GetIntConfig("SpringManorLevelDisplayTime").Value;

		// Token: 0x04023E5D RID: 147037
		[Nullable(2)]
		private UUISprite FillBar;
	}
}
