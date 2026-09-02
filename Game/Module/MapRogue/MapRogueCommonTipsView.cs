using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200594D RID: 22861
	public class MapRogueCommonTipsView : UiViewBase
	{
		// Token: 0x06039F77 RID: 237431 RVA: 0x00EABB57 File Offset: 0x00EA9D57
		[NullableContext(1)]
		public MapRogueCommonTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039F78 RID: 237432 RVA: 0x00EABB60 File Offset: 0x00EA9D60
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnMaskButtonClick))
			};
		}

		// Token: 0x06039F79 RID: 237433 RVA: 0x00EABBB1 File Offset: 0x00EA9DB1
		private void OnMaskButtonClick()
		{
			if (this.UiViewSequence.HasSequenceNameInPlaying(this.UiViewSequence.StartSequenceName))
			{
				this.UiViewSequence.StopSequenceByKey(this.UiViewSequence.StartSequenceName, true, true);
			}
		}

		// Token: 0x06039F7A RID: 237434 RVA: 0x00EABBE3 File Offset: 0x00EA9DE3
		protected override void OnAfterShow()
		{
			base.CloseMe(delegate(bool _)
			{
				ModelBase<MapRogueModel>.Instance.ExecuteOpData(this.OpIncId, null);
			});
		}

		// Token: 0x06039F7B RID: 237435 RVA: 0x00EABBF7 File Offset: 0x00EA9DF7
		protected override void OnStart()
		{
			this.OpIncId = (int)this.OpenParam;
		}

		// Token: 0x06039F7C RID: 237436 RVA: 0x00EABC0A File Offset: 0x00EA9E0A
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x04020D97 RID: 134551
		private int OpIncId;
	}
}
