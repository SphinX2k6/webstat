using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E1F RID: 19999
	public class TrapDefenseResultButton : UiPanelBase
	{
		// Token: 0x06033B60 RID: 211808 RVA: 0x00CECCD8 File Offset: 0x00CEAED8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B61 RID: 211809 RVA: 0x00CECD80 File Offset: 0x00CEAF80
		public void BindRedDot(ERedDotName redDotName, int? uid = null)
		{
			this.RedDotName = new ERedDotName?(redDotName);
			UUIItem item = base.GetItem(1);
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uid.GetValueOrDefault());
		}

		// Token: 0x06033B62 RID: 211810 RVA: 0x00CECDB8 File Offset: 0x00CEAFB8
		public void UnBindRedDot()
		{
			if (this.RedDotName == null)
			{
				return;
			}
			UUIItem item = base.GetItem(1);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, 0);
		}

		// Token: 0x06033B63 RID: 211811 RVA: 0x00CECDF2 File Offset: 0x00CEAFF2
		private void OnClickedBtn()
		{
			if (this.OnClickCb != null)
			{
				this.OnClickCb();
			}
		}

		// Token: 0x0401DF0D RID: 122637
		[Nullable(2)]
		public Action OnClickCb;

		// Token: 0x0401DF0E RID: 122638
		private ERedDotName? RedDotName;

		// Token: 0x0200AD9A RID: 44442
		private class EBtn
		{
			// Token: 0x04035E92 RID: 220818
			public const int Btn = 0;

			// Token: 0x04035E93 RID: 220819
			public const int RedDot = 1;
		}
	}
}
