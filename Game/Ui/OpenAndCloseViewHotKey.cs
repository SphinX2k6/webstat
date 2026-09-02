using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A22 RID: 18978
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenAndCloseViewHotKey : IOpenAndCloseViewHotKey
	{
		// Token: 0x17008463 RID: 33891
		// (get) Token: 0x06031965 RID: 203109 RVA: 0x00C5B208 File Offset: 0x00C59408
		// (set) Token: 0x06031966 RID: 203110 RVA: 0x00C5B210 File Offset: 0x00C59410
		public int ConfigId { get; set; }

		// Token: 0x17008464 RID: 33892
		// (get) Token: 0x06031967 RID: 203111 RVA: 0x00C5B219 File Offset: 0x00C59419
		// (set) Token: 0x06031968 RID: 203112 RVA: 0x00C5B221 File Offset: 0x00C59421
		public string ActionName { get; set; }

		// Token: 0x17008465 RID: 33893
		// (get) Token: 0x06031969 RID: 203113 RVA: 0x00C5B22A File Offset: 0x00C5942A
		// (set) Token: 0x0603196A RID: 203114 RVA: 0x00C5B232 File Offset: 0x00C59432
		public EOpenAndCloseViewInputControllerType InputControllerType { get; set; }

		// Token: 0x17008466 RID: 33894
		// (get) Token: 0x0603196B RID: 203115 RVA: 0x00C5B23B File Offset: 0x00C5943B
		// (set) Token: 0x0603196C RID: 203116 RVA: 0x00C5B243 File Offset: 0x00C59443
		public EUiViewName ViewName { get; set; }

		// Token: 0x17008467 RID: 33895
		// (get) Token: 0x0603196D RID: 203117 RVA: 0x00C5B24C File Offset: 0x00C5944C
		// (set) Token: 0x0603196E RID: 203118 RVA: 0x00C5B254 File Offset: 0x00C59454
		public string[] ViewParam { get; set; }

		// Token: 0x17008468 RID: 33896
		// (get) Token: 0x0603196F RID: 203119 RVA: 0x00C5B25D File Offset: 0x00C5945D
		// (set) Token: 0x06031970 RID: 203120 RVA: 0x00C5B265 File Offset: 0x00C59465
		public bool IsPressTrigger { get; set; }

		// Token: 0x17008469 RID: 33897
		// (get) Token: 0x06031971 RID: 203121 RVA: 0x00C5B26E File Offset: 0x00C5946E
		// (set) Token: 0x06031972 RID: 203122 RVA: 0x00C5B276 File Offset: 0x00C59476
		public int PressStartTime { get; set; }

		// Token: 0x1700846A RID: 33898
		// (get) Token: 0x06031973 RID: 203123 RVA: 0x00C5B27F File Offset: 0x00C5947F
		// (set) Token: 0x06031974 RID: 203124 RVA: 0x00C5B287 File Offset: 0x00C59487
		public int PressTriggerTime { get; set; }

		// Token: 0x1700846B RID: 33899
		// (get) Token: 0x06031975 RID: 203125 RVA: 0x00C5B290 File Offset: 0x00C59490
		// (set) Token: 0x06031976 RID: 203126 RVA: 0x00C5B298 File Offset: 0x00C59498
		public bool IsReleaseTrigger { get; set; }

		// Token: 0x1700846C RID: 33900
		// (get) Token: 0x06031977 RID: 203127 RVA: 0x00C5B2A1 File Offset: 0x00C594A1
		// (set) Token: 0x06031978 RID: 203128 RVA: 0x00C5B2A9 File Offset: 0x00C594A9
		public int ReleaseInvalidTime { get; set; }

		// Token: 0x1700846D RID: 33901
		// (get) Token: 0x06031979 RID: 203129 RVA: 0x00C5B2B2 File Offset: 0x00C594B2
		// (set) Token: 0x0603197A RID: 203130 RVA: 0x00C5B2BA File Offset: 0x00C594BA
		public bool IsPressClose { get; set; }

		// Token: 0x1700846E RID: 33902
		// (get) Token: 0x0603197B RID: 203131 RVA: 0x00C5B2C3 File Offset: 0x00C594C3
		// (set) Token: 0x0603197C RID: 203132 RVA: 0x00C5B2CB File Offset: 0x00C594CB
		public bool IsReleaseClose { get; set; }

		// Token: 0x1700846F RID: 33903
		// (get) Token: 0x0603197D RID: 203133 RVA: 0x00C5B2D4 File Offset: 0x00C594D4
		// (set) Token: 0x0603197E RID: 203134 RVA: 0x00C5B2DC File Offset: 0x00C594DC
		public Func<bool> IsAllowOpenViewByShortcutKey { get; set; }

		// Token: 0x17008470 RID: 33904
		// (get) Token: 0x0603197F RID: 203135 RVA: 0x00C5B2E5 File Offset: 0x00C594E5
		// (set) Token: 0x06031980 RID: 203136 RVA: 0x00C5B2ED File Offset: 0x00C594ED
		public Func<bool> IsAllowCloseViewByShortcutKey { get; set; }

		// Token: 0x17008471 RID: 33905
		// (get) Token: 0x06031981 RID: 203137 RVA: 0x00C5B2F6 File Offset: 0x00C594F6
		// (set) Token: 0x06031982 RID: 203138 RVA: 0x00C5B2FE File Offset: 0x00C594FE
		public Func<string, InputDistributeDefine.EActionType, bool> IsLockShortcutKey { get; set; }

		// Token: 0x17008472 RID: 33906
		// (get) Token: 0x06031983 RID: 203139 RVA: 0x00C5B307 File Offset: 0x00C59507
		// (set) Token: 0x06031984 RID: 203140 RVA: 0x00C5B30F File Offset: 0x00C5950F
		[Nullable(2)]
		public Action OpenViewCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008473 RID: 33907
		// (get) Token: 0x06031985 RID: 203141 RVA: 0x00C5B318 File Offset: 0x00C59518
		// (set) Token: 0x06031986 RID: 203142 RVA: 0x00C5B320 File Offset: 0x00C59520
		[Nullable(2)]
		public Action CloseViewCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
