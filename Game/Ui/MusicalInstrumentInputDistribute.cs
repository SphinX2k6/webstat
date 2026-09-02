using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.MusicalInstrument;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A03 RID: 18947
	public class MusicalInstrumentInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318C9 RID: 202953 RVA: 0x00C59984 File Offset: 0x00C57B84
		public override bool OnRefresh()
		{
			MusicalInstrumentModel instance = ModelBase<MusicalInstrumentModel>.Instance;
			if (instance == null || !instance.IsAnyInputRestricted)
			{
				return false;
			}
			this.TagNames.Clear();
			this.TagNames.Add("UiInputRoot");
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.HelpView))
			{
				if (!Singleton<Info>.Instance.IsInGamepad())
				{
					this.TagNames.Add("FightInputRoot.FightInput.AxisInput.CameraInput");
				}
				else
				{
					this.TagNames.Add("FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation");
				}
			}
			base.SetInputDistributeTags(this.TagNames);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.CB;
			string message = "[InputDistribute] 乐器玩法下允许的输入";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagNames", this.TagNames);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}

		// Token: 0x0401CCD6 RID: 117974
		[Nullable(1)]
		private readonly List<string> TagNames = new List<string>();
	}
}
