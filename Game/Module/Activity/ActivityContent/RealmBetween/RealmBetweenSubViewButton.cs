using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200653F RID: 25919
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenSubViewButton : UiPanelBase
	{
		// Token: 0x06040CC2 RID: 265410 RVA: 0x0109DA56 File Offset: 0x0109BC56
		public RealmBetweenSubViewButton(ERealmBetweenSubType type)
		{
			this.Type = type;
		}

		// Token: 0x06040CC3 RID: 265411 RVA: 0x0109DA68 File Offset: 0x0109BC68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton))
			};
		}

		// Token: 0x06040CC4 RID: 265412 RVA: 0x0109DAFB File Offset: 0x0109BCFB
		public void SetProgressText(string text)
		{
			base.GetText(1).SetText(text, true);
		}

		// Token: 0x06040CC5 RID: 265413 RVA: 0x0109DB0B File Offset: 0x0109BD0B
		public void SeFinishIconState(bool b)
		{
			base.GetSprite(3).SetUIActive(b);
		}

		// Token: 0x06040CC6 RID: 265414 RVA: 0x0109DB1A File Offset: 0x0109BD1A
		public void RefreshRedDot(bool bVisible)
		{
			base.GetItem(2).SetUIActive(bVisible);
		}

		// Token: 0x06040CC7 RID: 265415 RVA: 0x0109DB29 File Offset: 0x0109BD29
		public void SetFunction(Action<ERealmBetweenSubType> func)
		{
			this.ClickedFunc = func;
		}

		// Token: 0x06040CC8 RID: 265416 RVA: 0x0109DB32 File Offset: 0x0109BD32
		private void OnClickedButton()
		{
			Action<ERealmBetweenSubType> clickedFunc = this.ClickedFunc;
			if (clickedFunc == null)
			{
				return;
			}
			clickedFunc(this.Type);
		}

		// Token: 0x0402458C RID: 148876
		[Nullable(2)]
		private Action<ERealmBetweenSubType> ClickedFunc;

		// Token: 0x0402458D RID: 148877
		protected ERealmBetweenSubType Type;
	}
}
