using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A17 RID: 18967
	public class ViewHotKeyHandleQuestView : ViewHotKeyHandle
	{
		// Token: 0x06031903 RID: 203011 RVA: 0x00C5A40D File Offset: 0x00C5860D
		[NullableContext(1)]
		public ViewHotKeyHandleQuestView(IOpenAndCloseViewHotKey parameters) : base(parameters)
		{
		}

		// Token: 0x1700844E RID: 33870
		// (get) Token: 0x06031904 RID: 203012 RVA: 0x00C5A416 File Offset: 0x00C58616
		public override EUiViewName? ViewName
		{
			get
			{
				if (HonamiStoryUtil.CheckHonamiQuestOpen())
				{
					return new EUiViewName?(EUiViewName.HonamiStoryQuestView);
				}
				return this.DefaultViewName;
			}
		}

		// Token: 0x06031905 RID: 203013 RVA: 0x00C5A430 File Offset: 0x00C58630
		protected override void OnOpenViewImplement()
		{
			if (HonamiStoryUtil.CheckHonamiQuestOpen())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryQuestView, null, null);
				return;
			}
			base.OnOpenViewImplement();
		}
	}
}
