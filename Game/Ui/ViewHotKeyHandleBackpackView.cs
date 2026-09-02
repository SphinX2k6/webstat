using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Functional;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A12 RID: 18962
	public class ViewHotKeyHandleBackpackView : ViewHotKeyHandle
	{
		// Token: 0x060318F0 RID: 202992 RVA: 0x00C5A09B File Offset: 0x00C5829B
		[NullableContext(1)]
		public ViewHotKeyHandleBackpackView(IOpenAndCloseViewHotKey parameters) : base(parameters)
		{
		}

		// Token: 0x1700844D RID: 33869
		// (get) Token: 0x060318F1 RID: 202993 RVA: 0x00C5A0A4 File Offset: 0x00C582A4
		public override EUiViewName? ViewName
		{
			get
			{
				if (HonamiStoryUtil.CheckInHonamiStoryDungeon())
				{
					return new EUiViewName?(EUiViewName.HonamiStoryBackpackView);
				}
				return this.DefaultViewName;
			}
		}

		// Token: 0x060318F2 RID: 202994 RVA: 0x00C5A0BE File Offset: 0x00C582BE
		protected override void OnOpenViewImplement()
		{
			if (HonamiStoryUtil.CheckInHonamiStoryDungeon())
			{
				if (ModelBase<FunctionModel>.Instance.IsOpen(10102))
				{
					ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.HonamiStoryBackpack);
				}
				return;
			}
			base.OnOpenViewImplement();
		}
	}
}
