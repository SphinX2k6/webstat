using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AD1 RID: 27345
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemSplineMoveTaskParam : ISceneItemSplineMoveTaskParam
	{
		// Token: 0x1700A2B4 RID: 41652
		// (get) Token: 0x060439B0 RID: 276912 RVA: 0x011708C4 File Offset: 0x0116EAC4
		// (set) Token: 0x060439B1 RID: 276913 RVA: 0x011708CC File Offset: 0x0116EACC
		public int SplineId { get; set; }

		// Token: 0x1700A2B5 RID: 41653
		// (get) Token: 0x060439B2 RID: 276914 RVA: 0x011708D5 File Offset: 0x0116EAD5
		// (set) Token: 0x060439B3 RID: 276915 RVA: 0x011708DD File Offset: 0x0116EADD
		public ISceneItemSplineMoveConfig SplineMoveConfig { get; set; }

		// Token: 0x1700A2B6 RID: 41654
		// (get) Token: 0x060439B4 RID: 276916 RVA: 0x011708E6 File Offset: 0x0116EAE6
		// (set) Token: 0x060439B5 RID: 276917 RVA: 0x011708EE File Offset: 0x0116EAEE
		public bool EnableSplineMoveSync { get; set; }

		// Token: 0x1700A2B7 RID: 41655
		// (get) Token: 0x060439B6 RID: 276918 RVA: 0x011708F7 File Offset: 0x0116EAF7
		// (set) Token: 0x060439B7 RID: 276919 RVA: 0x011708FF File Offset: 0x0116EAFF
		public bool EnableMovementSync { get; set; }

		// Token: 0x1700A2B8 RID: 41656
		// (get) Token: 0x060439B8 RID: 276920 RVA: 0x01170908 File Offset: 0x0116EB08
		// (set) Token: 0x060439B9 RID: 276921 RVA: 0x01170910 File Offset: 0x0116EB10
		public bool NeedMoveToStartPoint { get; set; }

		// Token: 0x1700A2B9 RID: 41657
		// (get) Token: 0x060439BA RID: 276922 RVA: 0x01170919 File Offset: 0x0116EB19
		// (set) Token: 0x060439BB RID: 276923 RVA: 0x01170921 File Offset: 0x0116EB21
		public ISceneItemSplineMoveRuntimeData SplineMoveRuntimeData { get; set; }

		// Token: 0x1700A2BA RID: 41658
		// (get) Token: 0x060439BC RID: 276924 RVA: 0x0117092A File Offset: 0x0116EB2A
		// (set) Token: 0x060439BD RID: 276925 RVA: 0x01170932 File Offset: 0x0116EB32
		[Nullable(2)]
		public Action<bool> Callback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A2BB RID: 41659
		// (get) Token: 0x060439BE RID: 276926 RVA: 0x0117093B File Offset: 0x0116EB3B
		// (set) Token: 0x060439BF RID: 276927 RVA: 0x01170943 File Offset: 0x0116EB43
		[Nullable(2)]
		public GeneralContext Context { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A2BC RID: 41660
		// (get) Token: 0x060439C0 RID: 276928 RVA: 0x0117094C File Offset: 0x0116EB4C
		// (set) Token: 0x060439C1 RID: 276929 RVA: 0x01170954 File Offset: 0x0116EB54
		public bool? UseSplineMoveSyncSwitchOnStart { get; set; }
	}
}
