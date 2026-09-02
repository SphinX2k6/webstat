using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005332 RID: 21298
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineNormalItem : UiPanelBase
	{
		// Token: 0x06036588 RID: 222600 RVA: 0x00DB32E4 File Offset: 0x00DB14E4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClick))
			};
		}

		// Token: 0x06036589 RID: 222601 RVA: 0x00DB3378 File Offset: 0x00DB1578
		public void RefreshItem(QuestMultiLineBranchData branchData)
		{
			if (branchData == null)
			{
				this.BranchData = null;
				base.GetItem(1).SetUIActive(false);
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			this.BranchData = branchData;
			base.SetTextureByPath(QuestMultiLineUtils.GetIconForGender(branchData.Icons), base.GetTexture(0), null, null);
			base.GetItem(1).SetUIActive(branchData.State == EBranchState.Finish);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), branchData.Name, Array.Empty<object>());
		}

		// Token: 0x0603658A RID: 222602 RVA: 0x00DB3405 File Offset: 0x00DB1605
		public void SetClickFunction(Action<int> clickFunction)
		{
			this.ClickFunction = clickFunction;
		}

		// Token: 0x0603658B RID: 222603 RVA: 0x00DB340E File Offset: 0x00DB160E
		public void ResetFinishIcon()
		{
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x0603658C RID: 222604 RVA: 0x00DB341D File Offset: 0x00DB161D
		private void OnClick()
		{
			QuestMultiLineBranchData branchData = this.BranchData;
			if (branchData != null && branchData.State == EBranchState.Finish)
			{
				return;
			}
			Action<int> clickFunction = this.ClickFunction;
			if (clickFunction == null)
			{
				return;
			}
			clickFunction(this.BranchData.BranchId);
		}

		// Token: 0x0401F3FA RID: 127994
		[Nullable(2)]
		private Action<int> ClickFunction;

		// Token: 0x0401F3FB RID: 127995
		[Nullable(2)]
		private QuestMultiLineBranchData BranchData;
	}
}
