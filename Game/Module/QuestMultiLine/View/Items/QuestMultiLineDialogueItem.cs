using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x0200532B RID: 21291
	public class QuestMultiLineDialogueItem : UiPanelBase
	{
		// Token: 0x0603654F RID: 222543 RVA: 0x00DB1C75 File Offset: 0x00DAFE75
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite))
			};
		}

		// Token: 0x06036550 RID: 222544 RVA: 0x00DB1CAE File Offset: 0x00DAFEAE
		[NullableContext(1)]
		public void RefreshDialogue(QuestMultiLineComponentData componentData)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), componentData.OnGoingDesc, Array.Empty<object>());
		}

		// Token: 0x06036551 RID: 222545 RVA: 0x00DB1CCC File Offset: 0x00DAFECC
		public void SetDialogueActive(bool active)
		{
			base.SetUiActive(active);
		}
	}
}
