using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056A2 RID: 22178
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueResTrialView : UiViewBase
	{
		// Token: 0x0603875D RID: 231261 RVA: 0x00E4DDDF File Offset: 0x00E4BFDF
		public RogueResTrialView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603875E RID: 231262 RVA: 0x00E4DDE8 File Offset: 0x00E4BFE8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn))
			};
		}

		// Token: 0x0603875F RID: 231263 RVA: 0x00E4DE65 File Offset: 0x00E4C065
		protected override void OnStart()
		{
			this.CurSeason = (int)this.OpenParam;
			this.ScrollView = new GenericScrollViewNew<RogueResTrialTabItem, ERogueResTrialType>(base.GetScrollViewWithScrollbar(1), new Func<RogueResTrialTabItem>(this.InitTab), null, false, null);
		}

		// Token: 0x06038760 RID: 231264 RVA: 0x00E4DE99 File Offset: 0x00E4C099
		protected override void OnBeforeShow()
		{
			this.RefreshTab();
		}

		// Token: 0x06038761 RID: 231265 RVA: 0x00E4DEA1 File Offset: 0x00E4C0A1
		protected override void OnBeforeDestroy()
		{
			this.ScrollView = null;
		}

		// Token: 0x06038762 RID: 231266 RVA: 0x00E4DEAA File Offset: 0x00E4C0AA
		private RogueResTrialTabItem InitTab()
		{
			return new RogueResTrialTabItem
			{
				SeasonId = this.CurSeason
			};
		}

		// Token: 0x06038763 RID: 231267 RVA: 0x00E4DEBD File Offset: 0x00E4C0BD
		private void OnClickBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(261);
		}

		// Token: 0x06038764 RID: 231268 RVA: 0x00E4DED0 File Offset: 0x00E4C0D0
		public void RefreshTab()
		{
			List<ERogueResTrialType> data = new List<ERogueResTrialType>
			{
				ERogueResTrialType.Dynamic,
				ERogueResTrialType.Static
			};
			GenericScrollViewNew<RogueResTrialTabItem, ERogueResTrialType> scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return;
			}
			scrollView.RefreshByData(data, null, false);
		}

		// Token: 0x040203C1 RID: 132033
		private int CurSeason;

		// Token: 0x040203C2 RID: 132034
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<RogueResTrialTabItem, ERogueResTrialType> ScrollView;

		// Token: 0x040203C3 RID: 132035
		private const int BTN_HELPID = 261;
	}
}
