using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005336 RID: 21302
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineSelectItem : UiPanelBase
	{
		// Token: 0x0603659A RID: 222618 RVA: 0x00DB3B34 File Offset: 0x00DB1D34
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickOk))
			};
		}

		// Token: 0x0603659B RID: 222619 RVA: 0x00DB3BB4 File Offset: 0x00DB1DB4
		public void RefreshItem(QuestMultiLineBranchData branchData)
		{
			if (branchData == null)
			{
				this.BranchData = null;
				base.SetUiActive(false);
				return;
			}
			this.BranchData = branchData;
			base.SetTextureByPath(QuestMultiLineUtils.GetIconForGender(branchData.Icons), base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), branchData.Desc, Array.Empty<object>());
		}

		// Token: 0x0603659C RID: 222620 RVA: 0x00DB3C18 File Offset: 0x00DB1E18
		public void SetClickFunction(Action<int> clickFunction)
		{
			this.ClickFunction = clickFunction;
		}

		// Token: 0x0603659D RID: 222621 RVA: 0x00DB3C21 File Offset: 0x00DB1E21
		private void OnClickOk()
		{
			Action<int> clickFunction = this.ClickFunction;
			if (clickFunction == null)
			{
				return;
			}
			clickFunction(this.BranchData.BranchId);
		}

		// Token: 0x0401F406 RID: 128006
		[Nullable(2)]
		private Action<int> ClickFunction;

		// Token: 0x0401F407 RID: 128007
		[Nullable(2)]
		private QuestMultiLineBranchData BranchData;
	}
}
