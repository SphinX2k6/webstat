using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface
{
	// Token: 0x02006AE6 RID: 27366
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class KeyPointState : IKeyPointState
	{
		// Token: 0x1700A2EE RID: 41710
		// (get) Token: 0x06043ABB RID: 277179 RVA: 0x01173B9A File Offset: 0x01171D9A
		// (set) Token: 0x06043ABC RID: 277180 RVA: 0x01173BA2 File Offset: 0x01171DA2
		[RequiredMember]
		public IDragActorPlayKeyPointConfig Config { get; set; }

		// Token: 0x1700A2EF RID: 41711
		// (get) Token: 0x06043ABD RID: 277181 RVA: 0x01173BAB File Offset: 0x01171DAB
		// (set) Token: 0x06043ABE RID: 277182 RVA: 0x01173BB3 File Offset: 0x01171DB3
		[RequiredMember]
		public Vector Position { get; set; }

		// Token: 0x1700A2F0 RID: 41712
		// (get) Token: 0x06043ABF RID: 277183 RVA: 0x01173BBC File Offset: 0x01171DBC
		// (set) Token: 0x06043AC0 RID: 277184 RVA: 0x01173BC4 File Offset: 0x01171DC4
		public bool IsInside { get; set; }

		// Token: 0x06043AC1 RID: 277185 RVA: 0x01173BCD File Offset: 0x01171DCD
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public KeyPointState()
		{
		}
	}
}
