using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E3 RID: 22243
	[NullableContext(2)]
	public interface IEnterMovieModeParams
	{
		// Token: 0x170090D6 RID: 37078
		// (get) Token: 0x060389BA RID: 231866
		// (set) Token: 0x060389BB RID: 231867
		float BlendTime { get; set; }

		// Token: 0x170090D7 RID: 37079
		// (get) Token: 0x060389BC RID: 231868
		// (set) Token: 0x060389BD RID: 231869
		IMovieCameraConfig MovieCameraConfig { get; set; }

		// Token: 0x170090D8 RID: 37080
		// (get) Token: 0x060389BE RID: 231870
		// (set) Token: 0x060389BF RID: 231871
		float? DelayDuration { get; set; }

		// Token: 0x170090D9 RID: 37081
		// (get) Token: 0x060389C0 RID: 231872
		// (set) Token: 0x060389C1 RID: 231873
		bool? IsEnableEsc { get; set; }

		// Token: 0x170090DA RID: 37082
		// (get) Token: 0x060389C2 RID: 231874
		// (set) Token: 0x060389C3 RID: 231875
		bool? IsEnablePhoto { get; set; }

		// Token: 0x170090DB RID: 37083
		// (get) Token: 0x060389C4 RID: 231876
		// (set) Token: 0x060389C5 RID: 231877
		bool? IsAutoExitInFlowSequence { get; set; }

		// Token: 0x170090DC RID: 37084
		// (get) Token: 0x060389C6 RID: 231878
		// (set) Token: 0x060389C7 RID: 231879
		bool? IsBanAdaptation { get; set; }

		// Token: 0x170090DD RID: 37085
		// (get) Token: 0x060389C8 RID: 231880
		// (set) Token: 0x060389C9 RID: 231881
		UiPanelBase Parent { get; set; }

		// Token: 0x170090DE RID: 37086
		// (get) Token: 0x060389CA RID: 231882
		// (set) Token: 0x060389CB RID: 231883
		ELayerType? UiLayer { get; set; }

		// Token: 0x170090DF RID: 37087
		// (get) Token: 0x060389CC RID: 231884
		// (set) Token: 0x060389CD RID: 231885
		ELayerType[] AdaptUiLayers { get; set; }

		// Token: 0x170090E0 RID: 37088
		// (get) Token: 0x060389CE RID: 231886
		// (set) Token: 0x060389CF RID: 231887
		bool? IsIgnoreUiLayerVisible { get; set; }

		// Token: 0x170090E1 RID: 37089
		// (get) Token: 0x060389D0 RID: 231888
		// (set) Token: 0x060389D1 RID: 231889
		bool? IsNeedMovieModeUi { get; set; }
	}
}
