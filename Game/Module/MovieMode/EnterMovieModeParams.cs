using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E4 RID: 22244
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class EnterMovieModeParams : IEnterMovieModeParams
	{
		// Token: 0x170090E2 RID: 37090
		// (get) Token: 0x060389D2 RID: 231890 RVA: 0x00E577E3 File Offset: 0x00E559E3
		// (set) Token: 0x060389D3 RID: 231891 RVA: 0x00E577EB File Offset: 0x00E559EB
		[RequiredMember]
		public float BlendTime { get; set; }

		// Token: 0x170090E3 RID: 37091
		// (get) Token: 0x060389D4 RID: 231892 RVA: 0x00E577F4 File Offset: 0x00E559F4
		// (set) Token: 0x060389D5 RID: 231893 RVA: 0x00E577FC File Offset: 0x00E559FC
		public IMovieCameraConfig MovieCameraConfig { get; set; }

		// Token: 0x170090E4 RID: 37092
		// (get) Token: 0x060389D6 RID: 231894 RVA: 0x00E57805 File Offset: 0x00E55A05
		// (set) Token: 0x060389D7 RID: 231895 RVA: 0x00E5780D File Offset: 0x00E55A0D
		public float? DelayDuration { get; set; }

		// Token: 0x170090E5 RID: 37093
		// (get) Token: 0x060389D8 RID: 231896 RVA: 0x00E57816 File Offset: 0x00E55A16
		// (set) Token: 0x060389D9 RID: 231897 RVA: 0x00E5781E File Offset: 0x00E55A1E
		public bool? IsEnableEsc { get; set; }

		// Token: 0x170090E6 RID: 37094
		// (get) Token: 0x060389DA RID: 231898 RVA: 0x00E57827 File Offset: 0x00E55A27
		// (set) Token: 0x060389DB RID: 231899 RVA: 0x00E5782F File Offset: 0x00E55A2F
		public bool? IsEnablePhoto { get; set; }

		// Token: 0x170090E7 RID: 37095
		// (get) Token: 0x060389DC RID: 231900 RVA: 0x00E57838 File Offset: 0x00E55A38
		// (set) Token: 0x060389DD RID: 231901 RVA: 0x00E57840 File Offset: 0x00E55A40
		public bool? IsAutoExitInFlowSequence { get; set; }

		// Token: 0x170090E8 RID: 37096
		// (get) Token: 0x060389DE RID: 231902 RVA: 0x00E57849 File Offset: 0x00E55A49
		// (set) Token: 0x060389DF RID: 231903 RVA: 0x00E57851 File Offset: 0x00E55A51
		public bool? IsBanAdaptation { get; set; }

		// Token: 0x170090E9 RID: 37097
		// (get) Token: 0x060389E0 RID: 231904 RVA: 0x00E5785A File Offset: 0x00E55A5A
		// (set) Token: 0x060389E1 RID: 231905 RVA: 0x00E57862 File Offset: 0x00E55A62
		public UiPanelBase Parent { get; set; }

		// Token: 0x170090EA RID: 37098
		// (get) Token: 0x060389E2 RID: 231906 RVA: 0x00E5786B File Offset: 0x00E55A6B
		// (set) Token: 0x060389E3 RID: 231907 RVA: 0x00E57873 File Offset: 0x00E55A73
		public ELayerType? UiLayer { get; set; }

		// Token: 0x170090EB RID: 37099
		// (get) Token: 0x060389E4 RID: 231908 RVA: 0x00E5787C File Offset: 0x00E55A7C
		// (set) Token: 0x060389E5 RID: 231909 RVA: 0x00E57884 File Offset: 0x00E55A84
		public ELayerType[] AdaptUiLayers { get; set; }

		// Token: 0x170090EC RID: 37100
		// (get) Token: 0x060389E6 RID: 231910 RVA: 0x00E5788D File Offset: 0x00E55A8D
		// (set) Token: 0x060389E7 RID: 231911 RVA: 0x00E57895 File Offset: 0x00E55A95
		public bool? IsIgnoreUiLayerVisible { get; set; }

		// Token: 0x170090ED RID: 37101
		// (get) Token: 0x060389E8 RID: 231912 RVA: 0x00E5789E File Offset: 0x00E55A9E
		// (set) Token: 0x060389E9 RID: 231913 RVA: 0x00E578A6 File Offset: 0x00E55AA6
		public bool? IsNeedMovieModeUi { get; set; }

		// Token: 0x060389EA RID: 231914 RVA: 0x00E578AF File Offset: 0x00E55AAF
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public EnterMovieModeParams()
		{
		}
	}
}
